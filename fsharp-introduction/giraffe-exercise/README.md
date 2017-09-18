# Giraffe exercise

## Get started

- restore dependencies with `dotnet restore`
- run with `dotnet run`
- watch with `dotnet run watch`
- http://localhost:5000 should return _Giraffe exercise_


## Objectives

### 1 Construct the layout

- Create a view for the `'/'` route as shown in `wwwroot/preview.html`
- Use `Giraffe.XmlViewEngine`, [source](https://github.com/dustinmoris/Giraffe/blob/master/src/Giraffe/XmlViewEngine.fs)
- Consider a strategy for recurring html element on each page to follow.

### 2 Create the form postback

- Fetch the repos of the username submitted by the form
- Use `"http://api.github.com/users/%s/repos"` to get the data from Github.
- Add a mechanism of choice to link the result page to an unique url. This url should work on a get request as well.

### 3 Add an integration test

- Check out [SampleApp.Tests](https://github.com/dustinmoris/Giraffe/tree/master/samples/SampleApp/SampleApp.Tests)

### 4 Extra: Add Barba.js for smooth transitions

See [barbajs.org](http://barbajs.org/)