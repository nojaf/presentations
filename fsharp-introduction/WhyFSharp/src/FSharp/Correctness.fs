namespace WhyFSharp

module Correctness =

    type PersonalName = {FirstName:string; LastName:string}
    
    let changeFirstNameToBob personName =
        { personName with FirstName = "Bob" }
        
    type Address =
        { Street: string; City: string; Zip: string; }
        
    let printAddress address =
        printfn "%A " address
        
    let compareNames a b =
        printfn "%s %s %s" a.FirstName (if a = b then "equals" else "does not equal") b.FirstName
         