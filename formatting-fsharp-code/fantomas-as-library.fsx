#r @"C:\Users\nojaf\.nuget\packages\fsharp.compiler.service\34.1.0\lib\netstandard2.0\FSharp.Compiler.Service.dll"
#r @"C:\Users\nojaf\.nuget\packages\fantomas\3.3.0\lib\netstandard2.0\Fantomas.dll"
#r @"C:\Users\nojaf\.nuget\packages\fsast\0.2.0\lib\netstandard2.0\FsAst.dll"

open FSharp.Compiler.Ast
open FsAst

// See http://localhost:9060/#/ast?data=N4KABGBEAmCmBmBLAdrAzpAXFSAacUiaAYmolmPAIYA2as%2BEkAxgPZwWQC27ArjbDABZAJ5C%2BAgDoAnSchlyBAFzBVo0VWABG2FCoC8mgNTbIIAL5A

let parsedFile =
    let mdl = "MyModule"

    let actualAddition: SynExpr =
        SynExpr.CreateApp
            (SynExpr.CreateAppInfix
                (SynExpr.CreateIdent(Ident.Create "op_Addition"), SynExpr.CreateIdent(Ident.Create "a")),
             SynExpr.CreateIdent(Ident.Create "b"))

    let myModuleDeclaration =
        SynModuleDecl.CreateLet
            ({ SynBindingRcd.Let with
                   Pattern =
                       SynPatRcd.CreateLongIdent
                           (LongIdentWithDots.CreateString "add",
                            [ SynPatRcd.CreateNamed(Ident.Create "a", SynPatRcd.CreateWild)
                              SynPatRcd.CreateNamed(Ident.Create "b", SynPatRcd.CreateWild) ])
                   ReturnInfo = SynBindingReturnInfoRcd.Create(SynType.CreateLongIdent("int")) |> Some
                   Attributes = []
                   Expr = SynExpr.CreateTyped(actualAddition, SynType.CreateLongIdent("int")) }
             |> List.singleton)

    // create file
    ParsedInput.CreateImplFile
        (ParsedImplFileInputRcd.CreateFs(mdl)
                               .AddModule(SynModuleOrNamespaceRcd.CreateModule(Ident.CreateLong mdl)
                                                                 .AddDeclaration(myModuleDeclaration)))
printfn "%A" parsedFile



open Fantomas

CodeFormatter.GetVersion()

CodeFormatter.FormatASTAsync
    (parsedFile, "tmp.fsx", [], None, ({ FormatConfig.FormatConfig.Default with StrictMode = true }))
|> Async.RunSynchronously
