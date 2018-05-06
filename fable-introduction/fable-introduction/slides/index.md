- title : Introduction to Fable
- description : Introduction to Fable, The compiler that emits JavaScript you can be proud of!
- author : Florian Verdonck
- theme : axxes
- transition : default

***
<script>
const link = document.createElement("link");
link.setAttribute("rel","icon");
link.setAttribute("href", ""./images/favicon.ico?v=2");
document.documentElement.firstElementChild.append(link);
</script>
<div id="axxes-logo">
    <img src="images/axxes-logo.png" />
</div>
<br />
<br />
## Introduction to Fable

<br />
<br />

> The compiler that emits JavaScript you can be proud of!

<br />
<br />
Florian Verdonck - [@verdonckflorian](https://twitter.com/verdonckflorian)

***

### F# to JavaScript?

* <span>Recap F#</span>
* <span>Fable</span>
* <span>Sample</span>
* <span>Elmish</span>

***

### Recap F#

- <span>Functional-first</span>
- <span>Microsoft + Community</span>
- <span>Runs on .NET</span>

---

### Recap F#

- <span>Less noise</span>
- <span>Declarative language</span>
- <span>Let binding</span>
- <span>Pipe operator</span>

---

### Recap F#

#### Less noise

- <span>Fewer `;`</span>
- <span>Identation instead of `{`</span>
- <span>Less type declarations</span>
- <span>Whitespace instead of `,`</span>
- <span>no return keyword</span>

---

### Recap F#

#### Declarative language

*Question: write a function that returns the sum of list of squares*

---

### Recap F#

#### Declarative language

*Answer: imperative C#*

```csharp
public double SumOfSquares(List<double> source)
{
    var acc = 0d;
    foreach(var n in source)
    {
        acc += Math.Pow(n, 2d) 
    }
    return acc;
}
```

' you tell the compiler what you want to happen, step by step.

---

### Recap F#

#### Declarative language

*Answer: declarative F#*

```fsharp
let square n = n ** 2.0

let sumOfSquares source =
    source
    |> List.map square
    |> List.sum
```

' you write code that describes what you want, but not necessarily how to get it

---

### Recap F#

#### let binding

- <span>bind a name to:</span>
    - value
    - function
- <span>top level or local</span>
- <span>nested let</span>    

---

### Recap F#

#### let binding

```fsharp
module MyModule =

    let topLevelFn a b =
        let localLevel =
            let innerLevel = a + b
            printfn "meh"
            innerLevel
        localLevel
```

---

### Recap F#

#### Pipe operator `|>`

> pass the result left to expression right

```fsharp
let (|>) x f = f x

let minus a b = a - b 

9
|> minus 6
|> minus 3
|> (=) 0

// (minus (minus 6 9) 3 )= 0
```

*** 

## Enter Fable

*** 

### Fable

- <span>What?</span>
- <span>How?</span>
- <span>Why?</span>
- <span>Template</span>

***

### Fable

#### What?

- <span>F# -> JavaScript</span>
- <span>FSharp.Core & BCL</span>
- <span>Interopt with existing JS</span>
- <span>Community</span>

' transpiling piece
' additional npm package to polyfill missing stuff in JS
' 

---

### What is Fable?

#### F#

```fsharp
let add a b = a + b
```

#### to JavaScript

```js
export function add(a, b) {
  return a + b | 0;
}
```

--- 

### What is Fable?

#### FSharp.Core

```fsharp
type Person = { 
    Name:string
    Age: int
}

let barry = { Name = "Barry"; Age = 20 }
let olderBarry = { barry with Age = 40 }

if barry = olderBarry then
    printfn "same barry"
else
    printfn "different barry"
```

--- 

### What is Fable?

#### FSharp.Core -> JavaScript

<div class="scroll">
```js
import { setType } from "fable-core/Symbol";
import _Symbol from "fable-core/Symbol";
import { compareRecords, equalsRecords } from "fable-core/Util";
import { printf, toConsole } from "fable-core/String";
export class Person {
  constructor(name, age) {
    this.Name = name;
    this.Age = age | 0;
  }

  [_Symbol.reflection]() {
    return {
      type: "Test.Person",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        Name: "string",
        Age: "number"
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Test.Person", Person);
export const barry = new Person("Barry", 20);
export const olderBarry = new Person(barry.Name, 40);

if (barry.Equals(olderBarry)) {
  toConsole(printf("same barry"));
} else {
  toConsole(printf("different barry"));
}
```
</div>

---

### What is Fable?

#### BCL

```fsharp
open System

let printString s = printfn "%s" s

Guid.NewGuid().ToString() |> printString
DateTime.Now.ToString("dd/MM/yyyy") |> printString
```

---

### What is Fable?

#### BCL

```js
import { newGuid, printf, toConsole } from "fable-core/String";
import { toString } from "fable-core/Util";
import { toString as toString_1, now } from "fable-core/Date";
export function printString(s) {
  toConsole(printf("%s"))(s);
}
printString((() => {
  let copyOfStruct = newGuid();
  return toString(copyOfStruct);
})());
printString((() => {
  let copyOfStruct_1 = now();
  return toString_1(copyOfStruct_1, "dd/MM/yyyy");
})());
```

---
 
### What is Fable?

#### Interopt with existing JS

```fsharp
open Fable.Core.JsInterop

let myExistingFn: (string -> bool) = import "myFn" "../existing-code"
```

```js
import { myFn } from "../existing-code";
export const myExistingFn = myFn;
```

--- 

### What is Fable?

#### Interopt with existing JS

```fsharp
open Fable.Import.Browser
open Fable.Core
open Fable.Core.JsInterop

type IJQuery = interface end

[<Emit("window['$']($0)")>]
let select (selector: string) : IJQuery = jsNative

[<Emit("window['$']($0)")>]
let ready (handler: unit -> unit) : unit = jsNative

[<Emit("$2.css($0, $1)")>]
let css (prop: string) (value: string) (el: IJQuery) : IJQuery = jsNative

JQuery.ready (fun () ->
    JQuery.select "#main"
    |> JQuery.css "background-color" "red"
    |> ignore
)
```

---

### What is Fable?

#### Interopt with existing JS

```js
window["$"](function () {
  (function (el) {
    return el.css("background-color", "red");
  })(window["$"]("#main")), void 0;
});
```

---

### What is Fable?

#### Community

- <span>Awesome [maintainers](https://github.com/orgs/fable-compiler/people)</span>
- <span>Active [Gitter channel](gitter.im/fable-compiler/Fable)</span>
- <span>Amazing libraries</span>
- <span>And of course [FableConf](http://fable.io/fableconf/)</span>

*** 

### Fable

#### How?

- <span>Fable daemon</span>
- <span>JS client</span>

---

### Fable

#### Fable daemon

- <span>TCP server</span>
- <span>fsproj/fs files</span>
- <span>Transforms F#</span>

---

### Fable

#### Fable daemon: Transforms F#

- <span>F# -> Fable AST</span>
- <span>Fable AST -> Babel AST</span>

---

### AST?

- Abstract syntax tree
- Abstract syntactic structure of source code 

<img src="./images/csharp-ast.png" />

---

### Fable

#### Fable daemon: Transforms F#

- <span>FSharp.Compiler.Service</span>
- <span>F# -> F# AST</span>

```fsharp
let add a b = a + b
```

---

#### FSC AST

```fsharp
[Let
 (false,
  [Binding
     (None,NormalBinding,false,false,[],
      PreXmlDoc
        (Microsoft.FSharp.Compiler.Range+pos,
         Microsoft.FSharp.Compiler.Ast+XmlDocCollector),
      SynValData
        (None,
         SynValInfo
           ([[SynArgInfo ([],false,Some a)];
             [SynArgInfo ([],false,Some b)]],
            SynArgInfo ([],false,None)),None),
      LongIdent
        (LongIdentWithDots ([add],[]),None,None,
         Pats
           [Named
              (Wild Program.fs (2,8--2,9) IsSynthetic=false,a,false,
               None,Program.fs (2,8--2,9) IsSynthetic=false);
            Named
              (Wild Program.fs (2,10--2,11) IsSynthetic=false,b,
               false,None,Program.fs (2,10--2,11) IsSynthetic=false)],
         None,Program.fs (2,4--2,11) IsSynthetic=false),None,
```

---

#### Fable AST

```fsharp
Entity
  (Program,
   [MemberOrFunctionOrValue
      (val add,[[val a]; [val b]],
       Call
  (None,val op_Addition,[],
   [type Microsoft.FSharp.Core.int; type Microsoft.FSharp.Core.int;
    type Microsoft.FSharp.Core.int],[Value val a; Value val b]))])
```

---

#### Babel AST

<div class="scroll">
```js
{
    "sourceType": "module",
    "body": [
        {
            "declaration": {
                "id": {
                    "name": "add",
                    "type": "Identifier"
                },
                "params": [
                    {
                        "name": "a",
                        "type": "Identifier"
                    },
                    {
                        "name": "b",
                        "type": "Identifier"
                    }
                ],
                "body": {
                    "body": [
                        {
                            "argument": {
                                "left": {
                                    "left": {
                                        "name": "a",
                                        "type": "Identifier"
                                    },
                                    "right": {
                                        "name": "b",
                                        "type": "Identifier"
                                    },
                                    "operator": "+",
                                    "type": "BinaryExpression",
                                    "loc": {
                                        "start": {
                                            "line": 16,
                                            "column": 14
                                        },
                                        "end": {
                                            "line": 16,
                                            "column": 19
                                        }
                                    }
                                },
                                "right": {
                                    "value": 0,
                                    "type": "NumericLiteral"
                                },
                                "operator": "|",
                                "type": "BinaryExpression",
                                "loc": {
                                    "start": {
                                        "line": 16,
                                        "column": 14
                                    },
                                    "end": {
                                        "line": 16,
                                        "column": 19
                                    }
                                }
                            },
                            "type": "ReturnStatement",
                            "loc": {
                                "start": {
                                    "line": 16,
                                    "column": 14
                                },
                                "end": {
                                    "line": 16,
                                    "column": 19
                                }
                            }
                        }
                    ],
                    "directives": [],
                    "type": "BlockStatement",
                    "loc": {
                        "start": {
                            "line": 16,
                            "column": 14
                        },
                        "end": {
                            "line": 16,
                            "column": 19
                        }
                    }
                },
                "generator": false,
                "async": false,
                "type": "FunctionDeclaration",
                "loc": {
                    "start": {
                        "line": 16,
                        "column": 14
                    },
                    "end": {
                        "line": 16,
                        "column": 19
                    }
                }
            },
            "specifiers": [],
            "type": "ExportNamedDeclaration",
            "loc": {
                "start": {
                    "line": 16,
                    "column": 4
                },
                "end": {
                    "line": 16,
                    "column": 19
                }
            } 
        }
    ],
    "directives": [],
    "fileName": "C:/Users/nojaf/Projects/Fable/src/tools/QuickTest.fs",
    "logs": {},
    "dependencies": [],
    "sourceFiles": [],
    "type": "Program",
    "loc": {
        "start": {
            "line": 1,
            "column": 0
        },
        "end": {
            "line": 16,
            "column": 7
        }
    }
}
```
</div>

---

### Fable

#### JS Client

- <span>Pass Babel AST to Babel</span>
- <span>Webpack</span>
- <span>Rollup</span>

***

### Fable

#### Why?

- <span>Why F#</span>
- <span>Same language as backend</span>
- <span>JS lacks functional stuff</span>
- <span>The F# compiler is clever</span>
- <span>Because you can</span>

***

## Fable

#### Demo

***

### Fable

#### Elmish

- <span>Elm but with Fable<span>
- <span>model, view, update<span>
- <span>Fable at its best<span>

--- 

### Fable

#### Elmish

**ish**
>a suffix used to convey the sense of “having some characteristics of”

---

### Fable

#### Elmish

- <span>model</span>
- <span>view</span> 
- <span>update</span>

<div id="tea-container">
<img src="images/tea.jpg" />
</div>

Art by [@kolja](https://twitter.com/01k)

---

### Fable

#### Elmish: Model

- <span>Snapshot of the application state</span>
- <span>Immutable data structure</span>

---

### Fable

#### Elmish: Init

- Provides the first `Model`

---

### Fable

#### Elmish: Message

- <span>change or delta in state</span>
- <span>discriminated union</span>

---

### Fable

#### Elmish: Update

- <span>pure function</span>
- <span>applies `Message` to the `Model`</span>

---

### Fable

#### Elmish: View

- <span>render of the `Model` to the UI</span>
- <span>Mostly using React</span>

---

### Fable

#### Elmish: Demo

- <span>[Counter](https://elmish.github.io/#samples/counter)</span>
- <span>[Source](https://github.com/    elmish/sample-react-counter/blob/master/src/app.fs)</span>

--- 

### Fable

#### Elmish: Command

- <span>Generates one or more `Message`(`s`) over time</span>
- <span>Http calls, promises, impure stuff</span>
- <span>Interopt with existing libraries</span>

***

### Fable

#### Exercise: Axxes quotes

- <span>SAFE</span>
- <span>Basic Elmish</span>
- <span>Share code between Client and Server</span>

---

### Fable

#### Exercise: Step 1

- <span>Complete Elmish app</span>
- <span>Show existing quotes</span>
- <span>Add new quote to existing list</span>
- <span>Clear the form on cancel</span>

```

```

--- 

### Fable

#### Exercise: Step 2

- <span>Load initial state from Server</span>
- <span>Implement exception handling</span>

---

### Fable

##### Exercise: Step 3

- <span>Post quote to Server</span>
- <span>Only add quote when 200 received</span>