module App

open System

type User = {
    Name:string;
    Age: int;
    Email: string;
    Password: string;
}

type GetUser = string -> User option

let getUserByNameFromDatabase userName =
    (* ... some database code ... *)
    None

let verifyPassword (getUserByName:GetUser) name password =
    match getUserByName name with
    | Some user -> 
        match user.Password = password with
        | true -> Ok ()
        | false -> Error "password doesn't match"
    | None ->
        Error "user not found"