// Bind: Switch Track

module Result =
    let bind f a =
        match a with
        | Ok b -> f b
        | Error e -> Error e


let (>>=) r f = Result.bind f r

type User = {Name:string;}

let receiveRequest input:Result<string,int> =
    Ok input

let validateRequest request =
    Ok request

let updateExistingRecord request =
    let existingRecord = {Name = "dave"}
    Ok existingRecord

let sendVerificationEmail user =
    Ok ()

let executeUseCase input =
    (receiveRequest input) 
    >>= validateRequest 
    >>= updateExistingRecord 
    >>= sendVerificationEmail
    
executeUseCase "input1"
    
// >>= is |> with Result type

// >=> is >> with Result type, Kleisli composition

let (>=>) switch1 switch2 =
   fun x -> switch1 x >>= switch2
    
let executeUseCase2 input =
    input
    |> (receiveRequest >=> validateRequest >=> updateExistingRecord >=> sendVerificationEmail)
    
executeUseCase2 "input2"