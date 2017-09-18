#load "./paket-files/dustinmoris/Giraffe/src/Giraffe/Tasks.fs"

open Giraffe
open System.Threading.Tasks

let add a b =
    task {
        let! a' = Task.FromResult(a + 5)
        let! b' = Task.FromResult(b + 3)
        return! Task.FromResult(a' + b')
    }