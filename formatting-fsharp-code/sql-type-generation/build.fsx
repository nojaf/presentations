#r "paket:
nuget BlackFox.ColoredPrintf
nuget FSharp.Compiler.Service 35.0.0
nuget FsAST
nuget Fantomas prerelease
nuget DustyTables
nuget Fake.Core.Target"
#load ".fake/build.fsx/intellisense.fsx"

open System
open DustyTables
open FSharp.Compiler.SyntaxTree
open Fake.Core
open Fake.IO
open Fake.IO.FileSystemOperators
open FsAst
open FSharp.Compiler.Range
open Fantomas
open Fantomas.FakeHelpers
open Fantomas.FormatConfig
open BlackFox.ColoredPrintf

type TableInfo =
    { Name: string
      Columns: Map<string, string> }

let connectionString = "Server=localhost;Database=twitter;User Id=sa;Password=Password1!;"

let getTableInfo() =
    connectionString
    |> Sql.connect
    |> Sql.query """SELECT TABLE_NAME, COLUMN_NAME, DATA_TYPE
                    FROM INFORMATION_SCHEMA.COLUMNS"""
    |> Sql.execute (fun read ->
        {| TableName = read.string "TABLE_NAME"
           ColumnName = read.string "COLUMN_NAME"
           DataType = read.string "DATA_TYPE" |})
    |> Result.map (fun rows ->
        rows
        |> List.groupBy (fun r -> r.TableName)
        |> List.map (fun (tableName, rows) ->
            let columns =
                rows
                |> List.map (fun r -> r.ColumnName, r.DataType)
                |> Map.ofList
            { Name = tableName
              Columns = columns }))

let generateModuleAndConnectionString moduleName = SynModuleOrNamespaceRcd.CreateModule(Ident.CreateLong moduleName)

(*
open DustyTables

// get the connection from the environment
let connectionString() = Env.getVar "app_db"

type User = { Id: int; Username: string }

let getUsers() : Result<User list, exn> =
    connectionString()
    |> Sql.connect
    |> Sql.query "SELECT * FROM dbo.[Users]"
    |> Sql.execute (fun read ->
        {
            Id = read.int "user_id"
            Username = read.string "username"
        })
*)

let pascalCase (v: string) = v.Substring(0, 1).ToUpper() + v.Substring(1, v.Length - 1)
let snakeToPascal (v: string) =
    v.Split('_')
    |> Array.map pascalCase
    |> String.concat ""

let generateCodeForTable tableInfo =
    let fields =
        tableInfo.Columns
        |> Map.toList
        |> List.map (fun (name, dbType) ->
            let fieldName = snakeToPascal name
            if dbType = "int" then SynFieldRcd.CreateInt(fieldName)
            else SynFieldRcd.CreateString(fieldName))

    let typeName =
        let p = pascalCase tableInfo.Name
        p.Substring(0, p.Length - 1) // remove s

    let typeDeclaration =
        SynModuleDecl.CreateSimpleType
            (SynComponentInfoRcd.Create(Ident.CreateLong typeName),
             SynTypeDefnSimpleReprRcd.Record(SynTypeDefnSimpleReprRecordRcd.Create(fields)))

    let getFunctionDeclaration =
        let functionName = sprintf "get%s" (pascalCase tableInfo.Name)

        let pattern =
            SynPatRcd.CreateLongIdent
                (LongIdentWithDots.CreateString(functionName),
                 [ SynPatRcd.CreateParen
                     (SynPatRcd.Const
                         ({ Const = SynConst.Unit
                            Range = range.Zero })) ])
        let returnType =
            SynType.CreateApp
                (SynType.CreateLongIdent("Result"),
                 [ SynType.CreateApp(SynType.CreateLongIdent("list"), [ SynType.CreateLongIdent(typeName) ])
                   SynType.CreateLongIdent("exn") ])

        let synApp fExpr aExpr = SynExpr.CreateApp(fExpr, aExpr)
        let pipeRight aExpr =  SynExpr.CreateAppInfix(SynExpr.CreateIdentString "op_PipeRight", aExpr)

        let lambdaExpr =
            let body: SynExpr =
                let recordFields =
                    tableInfo.Columns
                    |> Map.toList
                    |> List.map (fun (columnName, columnType) ->
                        let fieldName: RecordFieldName = LongIdentWithDots.CreateString(snakeToPascal columnName), true

                        let fieldExpr: SynExpr option =
                            let getColumnFunctionName =
                                if columnType = "int" then "int"
                                else "string"
                            SynExpr.CreateConstString columnName
                            |> synApp
                                (SynExpr.CreateLongIdent
                                    (false, LongIdentWithDots.Create([ "reader"; getColumnFunctionName ]), None))
                            |> Some
                        fieldName, fieldExpr, Some(range.Zero, None))
                SynExpr.Record(None, None, recordFields, range.Zero)

            SynExpr.Lambda
                (false, false,
                 SynSimplePats.SimplePats
                     ([ SynSimplePat.Id(Ident.Create "reader", None, false, false, false, range.Zero) ], range.Zero), body,
                 range.Zero) |> SynExpr.CreateParen

        let functionExpr =
            let connectionStringCall =
                let cn = SynExpr.CreateIdentString "connectionString"
                let sc = SynExpr.CreateLongIdent(false, LongIdentWithDots.Create([ "Sql"; "connect" ]), None)
                let sq =
                    synApp (SynExpr.CreateLongIdent(false, LongIdentWithDots.Create([ "Sql"; "query" ]), None))
                        (SynExpr.CreateConstString(sprintf "SELECT * FROM [dbo].%s" tableInfo.Name))
                let se =
                    synApp (SynExpr.CreateLongIdent(false, LongIdentWithDots.Create([ "Sql"; "execute" ]), None))
                        lambdaExpr

                se
                |> synApp (pipeRight sq)
                |> synApp (pipeRight sc)
                |> synApp (pipeRight cn)

            connectionStringCall

        SynModuleDecl.CreateLet
            ([ { SynBindingRcd.Let with
                     Pattern = pattern
                     Expr = SynExpr.CreateTyped(functionExpr, returnType) } ])

    [ typeDeclaration; getFunctionDeclaration ]

let connectionStringDeclaration =
    let pattern = SynPatRcd.CreateNamed(Ident.Create "connectionString", SynPatRcd.CreateWild)

    SynModuleDecl.CreateLet
        ([ { SynBindingRcd.Let with
                 Pattern = pattern
                 Expr = SynExpr.CreateConstString(connectionString) } ])

let generateDatabaseCode() =
    match getTableInfo() with
    | Result.Ok tables ->
        let mdl = "MyApp.Database"
        let tableInfoDeclarations = tables |> List.collect generateCodeForTable

        ParsedInput.CreateImplFile
            (ParsedImplFileInputRcd.CreateFs(mdl)
                                   .AddModule(SynModuleOrNamespaceRcd.CreateModule(Ident.CreateLong mdl)
                                                                     .AddDeclaration(SynModuleDecl.CreateOpen
                                                                                         (LongIdentWithDots.CreateString
                                                                                             ("DustyTables")))
                                                                     .AddDeclaration(connectionStringDeclaration)
                                                                     .AddDeclarations(tableInfoDeclarations)))
    | Result.Error err -> failwithf "yeah something went wrong: %A" err

Target.create "Generate" (fun _ ->
    let timestamp = DateTime.Now.ToString()
    let ast = generateDatabaseCode()
    let sourceCode =
        CodeFormatter.FormatASTAsync
            (ast, "tmp.fsx", [], None, FormatConfig.FormatConfig.Default) //({ FormatConfig.FormatConfig.Default with StrictMode = true }))
        |> Async.RunSynchronously
        |> sprintf "/// Warning: generated code at %s 😅🙈🙉\n%s" timestamp

    System.IO.File.WriteAllText((Shell.pwd() </> "MyApp" </> "Database.fs"), sourceCode)
    printfn "generated database code")



Target.create "Format" (fun _ ->
    FakeHelpers.formatCode FormatConfig.Default [| "MyApp" </> "Program.fs" |]
    |> Async.RunSynchronously
    |> printfn "%O")

Target.create "Check" (fun _ ->
    FakeHelpers.checkCode FormatConfig.Default [| "MyApp" </> "Program.fs" |]
    |> Async.RunSynchronously
    |> fun checkResult ->
        if checkResult.NeedsFormatting then
            failwith "%A needs formatting!" checkResult.Formatted
        else
            colorprintfn  "$DarkCyan[All files are formatted!]")

Target.runOrDefault "Generate"