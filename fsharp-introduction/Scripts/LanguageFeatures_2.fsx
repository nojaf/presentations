open System

(* partial application *)

let add a b =
    a + b
    
let add50 =
    add 50
    
add50 20
    
(* currying *)

let times a = // times a b c
    fun b ->
        fun c ->
            a * b * c
            
let twelve = (((times 2) 3) 2)

(* Piping |> *)

let printDate () =
    DateTime.Now.ToString("d")
    |> sprintf "Today is %i %s" 3
    
printDate()

(* Composing *)

let divideByTwo a =
    a / 2
    
let addAndDivide a =
    (add50 >> divideByTwo) a
    
addAndDivide 10
    
(* Infix operator *)
let (---) a b =
    a - b - 3
    
13 --- 3

3
|> (+) 2
    
(* Type Alias *)    

type Street = string

let enterStreet (street:Street) =
    printfn "Street: %s" street
    
enterStreet "Bakerstreet"
    
module Finances =    
    type BankAccount = private Account of string

    let createBankAccount input =
        if String.IsNullOrWhiteSpace(input) then
            None
        else
        match input.[0] with
        | x when (x = '0') -> 
            BankAccount.Account input
            |> Some
        | _ -> None
        
    let readBankAccount account =
        match account with
        | Account ba -> ba

let printBankAccount (account:Finances.BankAccount option) =
    match account with
    | Some ba ->
        Finances.readBankAccount ba
        |> printfn "Valid account %s"
    | None ->
        printfn "Invalid account"
      
let myAccount = Finances.createBankAccount "089980089"
printBankAccount myAccount
        
(* Array/Seq/List *)

let emptyArray =
    Array.zeroCreate<string> 7 
 
let lettersArray =
    [|"a";"b";"c"|]
    
// List => Immutable!
let lettersList =
    ["a";"b";"c"]
    
lettersList.Head
lettersList.Tail

let rec printList list =
    match list with
    | [] -> printfn "empty list"
    | [single] -> 
        printfn "last %A" single
    | head::tail ->
        printfn "%A" head
        printList tail
 
printList lettersList
        
(* 
    List.map, List.iter, List.filter, 
    List.x <fun> list
*)

// Seq => IEnumerable
seq { 0..49 }