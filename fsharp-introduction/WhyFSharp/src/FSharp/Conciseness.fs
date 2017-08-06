namespace WhyFSharp

open System

module Conciseness =

    type Person = { Name : string; Age : int; }
    
    let printPerson person =
        let (name, age) = (person.Name, person.Age)
        [0..age]
        |> List.map (sprintf "%s -- %i" name) 
        |> fun names -> String.Join(",")
        |> printfn "%s"
        
