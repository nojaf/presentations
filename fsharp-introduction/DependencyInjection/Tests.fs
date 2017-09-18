module Tests

open System
open Xunit
open App

let noUserFound:GetUser = fun _ -> None
let userFound:GetUser = 
    fun u ->
     {
        Name = u;
        Age = 33;
        Email = "foo@bar.com";
        Password = "sdfksdmklsdmfklwsnf"
     } |> Some

let assertError fn result =
    match result with 
    | Ok _ -> Assert.False(true)
    | Error error -> fn error
    
let isOk result =
    match result with 
    | Ok _ -> true
    | Error _ -> false

[<Fact>]
let ``When no user is found, Error should be returned`` () =
    verifyPassword noUserFound "barry" "123456"
    |> assertError (fun err ->
        Assert.Equal("user not found", err)
    )
    
[<Fact>]
let ``When password do not match, Error should be returned``() =
    verifyPassword userFound "barry" "123456"
    |> assertError (fun err ->
        Assert.Equal("password doesn't match", err)
    )
    
[<Fact>]
let ``When password is valid, Ok should be returned``() =
    verifyPassword userFound "barry" "sdfksdmklsdmfklwsnf"
    |> isOk
    |> fun res -> Assert.True(res)