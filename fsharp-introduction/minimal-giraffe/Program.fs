module minimal_giraffe.App

open System
open System.IO
open System.Collections.Generic
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Primitives
open Giraffe.HttpHandlers
open Giraffe.Middleware
open Giraffe
open System.Text

// ---------------------------------
// Web app
// ---------------------------------

let webApp (next:HttpFunc) (context:HttpContext) =
    // fun (next: HttpFunc) ->
    //     fun (context: HttpContext) ->
    task {
        let content = Encoding.UTF8.GetBytes "Hello Giraffe"
        do! context.Response.Body.WriteAsync(content, 0, content.Length)
        return Some context
    }

let configureApp (app : IApplicationBuilder) =
    app.UseGiraffe webApp


[<EntryPoint>]
let main argv =
    WebHostBuilder()
        .UseKestrel()
        .Configure(Action<IApplicationBuilder> configureApp)
        .Build()
        .Run()
    0