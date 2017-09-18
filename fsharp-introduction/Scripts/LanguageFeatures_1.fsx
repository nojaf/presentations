open System

// Rider: send to repl ctrl + /

(* Tuples *)

let myFirstTuple = ("foo", 42)

let destructed () =
    let (name, age) = myFirstTuple
    printfn "%s %i" name age

destructed ()

(* Records *)

type Person = {
    Address: Address;
    Name: FullName;
}

and Address = {
    Street: string;
    Number: string;
    City: string;
    Zip: string;
}

and FullName = {
    FirstName: string;
    LastName: string;
}

let james = 
    {
        Address = 
            {
                Street = "Elm street";
                Number = "14";
                City = "New York";
                Zip = "Q1902290_3";
            };
        Name = 
            {
                FirstName = "James";
                LastName = "Doe";
            };
    }
    
(* Discriminated Unions *)
    
type ContactInfo =
    | Phone of string
    | Address of Address
    | Email of EmailAddress
    
and EmailAddress =
    | UnVerified of string
    | Verified of string
    
let phoneNumber = ContactInfo.Phone "02/000.111.44"

let email = 
    EmailAddress.Verified "mike@somecompany.com"
    |> ContactInfo.Email
    
// Well known discrimintated union, dealing with null

type Option<'t> =
    | Some of t
    | None
    
(* Pattern Matching: if/else on steriods *)
    
let printContactDetails info =
    match info with
    | ContactInfo.Phone phoneNumber ->
        sprintf "Phone: %s" phoneNumber
    | ContactInfo.Address address ->
        sprintf "Address: %A" address
    | ContactInfo.Email email ->
        match email with
        | EmailAddress.UnVerified unverifiedEmail ->
            sprintf "unverified %s" unverifiedEmail
        | EmailAddress.Verified verified ->
            sprintf "yay verified %s" verified
    |> printfn "%s"           
     
printContactDetails phoneNumber
printContactDetails email
     
let incomplete info =
    match info with 
    | ContactInfo.Phone phone -> phone
    
(* Active Patterns *)


let (|Even|Odd|) input =
    if input % 2 = 0 then
        Even
    else
        Odd
        
let oddOrEven a =
    match a with
    | Even -> printfn "%i is even" a
    | Odd -> printfn "%i is odd" a
    
oddOrEven 3
oddOrEven 4