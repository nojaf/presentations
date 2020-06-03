/// Formatting F# code
/// A case study

type FormatConfig = { 
    PageWidth: int; 
    Indent: int } // the number of spaces

let binaryUIntValue = 0x4000u

type ILogger =
    member this.LogDebug message = printfn (* TODO: implement something *) ()

let run (req: HttpRequest) (log: ILogger) =
    Http.main getFantomasVersion format FormatConfig.FormatConfig.Default log req
    |> Async.StartAsTask
