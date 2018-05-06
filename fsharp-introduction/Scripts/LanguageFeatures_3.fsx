(* Option type *)

//type Option<'t> =
//    | Some of t
//    | None

let getUserFromDatabase id =
    if id = 8 then
        Some "barry" // do a database call, record was found and name was returned
    else
        None // nothing found in the database
        
let printUser user =
    match user with
    | Some u -> u
    | None -> "none found"
    |> printfn "%s"
    
8  
|> getUserFromDatabase 
|> printUser

(getUserFromDatabase >> printUser) 7


(* Option.bind

f:('a -> 'b option) -> m:'a option -> 'b option
module Option = 
    let bind f m =
       match m with
       | None -> 
           None
       | Some x -> 
           x |> f 
           
*)


let reverse (string : System.String) =
    printfn "enter reverse"
    match string with
    | "" -> None
    | s -> 
        string.ToCharArray() 
        |> Array.rev
        |> fun chars -> new System.String(chars)
        |> Some
    
getUserFromDatabase 5
|> Option.bind reverse

(* Option.map

f:('a -> 'b) -> m:'a option -> 'b option
module Option =
    let map f m =
        match m with
        | None -> None
        | Some x -> f x |> Some
*)

Some 42
|> Option.map (fun fourtyTwo -> "answer to the universe")

(* Result type *)

//type Result<'a,'b> =
//    | Ok of 'a
//    | Error of 'b

type GetUserError =
    | DatabaseError of exn
    | UserNotFound
    | ExpiredUserFound of string

let findUser id =
    match id with
    | a when (a = 1) -> Ok a
    | b when (b < 5) -> DatabaseError (System.Exception "meh") |> Error
    | c when (c > 5 && c < 100) -> ExpiredUserFound "john.doe" |> Error
    | _ -> UserNotFound |> Error
   
let printDBUser u =
    match u with
    | Ok id -> printfn "OK: %i" id
    | Error err -> printfn "Erreur: %A" err
    
findUser 1 |> printDBUser
2 |> (findUser >> printDBUser)

(* Result.bind 
f:('a -> Result<'b,'c>) -> a:Result<'a,'c> -> Result<'b,'c>
module Result =
    let bind f a =
        match a with
        | Ok b -> f b
        | Error e -> Error e
*)

let userIdPlusOne u =
    printfn "inside plus one"
    (+) u 1
    |> fun r -> 
        match (r % 2 = 0) with
        | true -> Ok r
        | false -> UserNotFound |> Error
    
findUser 1
|> Result.bind userIdPlusOne
|> printfn "%A"

findUser 2
|> Result.bind userIdPlusOne
|> printfn "%A"

(* Result.map
f:('a -> 'b) -> a:Result<'a,'c> -> Result<'b,'c>
module Result =
    let map f a =
        match a with
        | Ok aa -> f aa |> Ok
        | Error e -> Error e
*)

type UserDto = {
    Id:int;
    Name:string;
}

let validateUser user =
    if user.Name <> "barry" then
        Ok user
    else
        UserNotFound |> Error
        
{ Name = "James"; Id = 1; }
|> validateUser
|> Result.bind (fun u -> findUser u.Id)
|> Result.map (fun id -> sprintf "Found user with id: {%i}" id)

{ Name = "barry"; Id = 2; }
|> validateUser
|> Result.bind (fun u -> findUser u.Id)
|> Result.map (fun id -> sprintf "Found user with id: {%i}" id)

{ Name = "Steve"; Id = 3; }
|> validateUser
|> Result.bind (fun u -> findUser u.Id)
|> Result.map (fun id -> sprintf "Found user with id: {%i}" id)