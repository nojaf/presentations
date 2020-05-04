// Learn more about F# at http://fsharp.org

open MyApp.Database

[<EntryPoint>]
let main _ =
    match getTweets() with
    | Ok tweets ->
        tweets |> List.iter (fun tweet -> printfn "%d _ %s" tweet.Id tweet.Content)
        0
    | Error err ->
        eprintfn "%A" err
        1
