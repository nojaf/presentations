open Microsoft.FSharp.Control.CommonExtensions
open System.Net
open System
open System.IO


let fetchUrlAsync url =        
    async {                             
        let req = WebRequest.Create(Uri(url)) 
        use! resp = req.AsyncGetResponse()  // new keyword "use!"  
        use stream = resp.GetResponseStream() 
        use reader = new IO.StreamReader(stream) 
        let html = reader.ReadToEnd()
        html.Substring(0,100) |> printfn "\nhtml code: \n%s\n"
        printfn "finished downloading %s" url 
        }
        
fetchUrlAsync "https://axxes.com"
|> Async.RunSynchronously

System.Threading.Tasks.Task.FromResult(printfn "Do")