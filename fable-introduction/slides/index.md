- title : Introduction to Fable
- description : Introduction to Fable, The compiler that emits JavaScript you can be proud of!
- author : Florian Verdonck
- theme : axxes
- transition : default

***
<script>
    window.addEventListener("load", () => {
        const link = document.createElement("link");
        link.setAttribute("rel","icon");
        link.setAttribute("href", "./images/favicon.ico?v=2");
        document.documentElement.firstElementChild.append(link);
    });
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

## F# to JavaScript?

* <span>Recap F#</span>
* <span>Fable</span>
* <span>Sample</span>
* <span>Elmish</span>

***

## Recap F#

- <span>Functional-first</span>
- <span>Microsoft + Community</span>
- <span>Runs on .NET</span>
- <span>Code samples</span>

***

## Enter Fable

*** 

### Fable

- <span>What?</span>
- <span>Why?</span>
- <span>How?</span>
- <span>Code samples</span>

***

## Fable

### Why?

- <span>Because you can</span>
- <span>Why F#</span>
- <span>Same language as backend</span>
- <span>JS lacks functional stuff</span>
- <span>The F# compiler is clever</span>
- <span>Because you can</span>

***

## Fable

### The end?

- <span>Only scratched the surface</span>
- <span>Gitter</span>
- <span>Some Q's, some A's</span>
- <span>Swing by our booth</span>

***

## Fable

### Elmish

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