#load "./paket-files/dustinmoris/Giraffe/src/Giraffe/ComputationExpressions.fs"

open Giraffe.ComputationExpressions

type PrintBuilder() =
    member x.Bind(v, f) = 
        let result = f v
        printfn "Inside bind, let! %A" result
        result
        
    member x.Return v =
        printfn "Returning %A" v
        v
        
let prin = PrintBuilder()
        
let doSomething a b =
        prin {
            let! x = a + b
            return (x + 1)
            // return! (x + 5)
        }
        
doSomething 4 9
        
// ComputationExpressions in Giraffe: opt, res & task
(*
    module Giraffe.ComputationExpressions
    
    open System
    
    type OptionBuilder() =
        member x.Bind(v, f) = Option.bind f v
        member x.Return v   = Some v
        member x.Zero()     = None
    
    let opt = OptionBuilder()
    
    type ResultBuilder() =
        member x.Bind(v, f) = Result.bind f v
        member x.Return v   = Ok v
    
    let res = ResultBuilder()
*)

let divide a b =
    match b with
    | 0 -> None
    | _ -> a / b |> Some
    
let divideThreeMeh a b c =
    match divide a b with
    | None -> None
    | Some d->
        match divide d c with
        | None -> None
        | Some e -> Some e
    
let divideThreeCE a b c =
    opt {
        let! d = divide a b
        printfn "foo"
        let! e = divide d c
        return e
    }
    
    
divideThreeMeh 12 3 2
divideThreeCE 12 3 2
divideThreeCE 20 0 10