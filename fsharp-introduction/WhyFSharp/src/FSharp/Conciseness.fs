namespace FSharp

open System

module Conciseness =

    type Person = { Name : string; Age : int; }
    type Animal = { Color : string; Age : int; }
    
    let printPerson (person:Person) =
        let (name, age) = ("some name", person.Age)
        [0..age]
        |> List.map (fun i -> sprintf "%s -- %i" name i) 
        |> fun names -> String.Join(",", names)
        |> printfn "%s"