# Blazor in .NET 5 demo

## Setup

- Install Visual Studio 2019 16.8
- Enable auto rebuild and refresh in VS: Tools > Options > Projects and Solutions > ASP.NET Core > Auto build and refresh option > Auto build and refresh browser after saving changes
- Screen res at 1080p
- Open BlazorNet5
- Blazor WASM perf slide ready to show
- Remove Component1 from Index.razor
- Comment out `Console.Readline` in BlazorNet5.Client/Program.cs

## Intro

Hi everyone! Blazor is your web UI framework for building single page web apps with just .NET, no JavaScript required. Let's take a look at what Blazor has to offer in .NET 5. 

## One .NET

> Show Blazor project templates in the New Project Dialog

.NET 5 includes support for both Blazor Server and Blazor WebAssembly, as you can see here in Visual Studo.

> Open 3.2 and 5.0 Blazor.Client projects side-by-side

Previously Blazor WebAssembly only supported .NET Standard, but now in .NET 5 Blazor WebAssembly apps have full access to all the .NET 5 APIs using the same core framework libraries used on the server and desktop. This is the begining of One .NET and we expect that Xamarin will make a similar move for .NET 6.

## Compat analyzer

Now just because all those APIs are available, it doesn't mean all of them work in a browser. Blazor WebAssembly apps still have to run in the browser security sandbox. But fortunately the new platform compatibility analyzer will now let you know when you try to use an API that isn't supported.

For example, browsers don't have a console that you can read from. If I try to read from the console in my Blazor WebAssembly app, I get a nice warning.

> Uncomment `Console.Readline` and show warning

## Performance

> Show perf slide

Blazor WebAssembly is much faster in .NET 5. Component rendering and general runtime executation is 2-3x faster. This is thanks to optimizations across the stack, including in the WebAssembly runtime, core libraries and in Blazor's rendering engine.

## Prerendering

We've also made it so that Blazor WebAssembly apps load faster.

> Run the app and show that it refreshes really fast

Notice that as I refresh the app it feels like it loads almost instantly. No Loading... This is because in .NET 5 we've added support for Blazor WebAssembly prerendering.

> Open _Host.cshtml

Here in the Server project you can see that this Blazor WebAssembly app is prerendered on the server when it is first requested using the component tag helper in this host Razor Page. This helps get pixels on the screen as fast as possible while the runtime is downloaded in the background. 

## Virtualization

Blazor also now has built-in support for component virtualization to speed up rendering of large lists of data.

> Open the fetch data page

For example, let's imagine that we're now in the future when we can predict the weather as far out as we want. This table of weather forecasts has almost 10,000 rows.

> Show the Virtualize component in FetchData.razor

But thanks to the new Virtualize component, only the data for the visible rows are fetched and then rendered. 

> Open the browser dev tools to the Network tab
> Scroll down in the tab

As I scroll down in this table we can see the data being dynamically requested as it becomes visible.

## CSS isolation

.NET 5 also makes building component libraries easier with CSS & JS isolation. Here I have a default Razor class library with a simple component. The component has it's own CSS file. This file will get processed at build time so that it will only get applied to this comopent. 

> Show Component1.razor.css

When I reference the library and use the component from my app, the component specific styles are picked up automatically without me having to add any additional links.

> Add MyComponent to Index.razor with VS and the app side-by-side

If I add MyComponent to the home page of my app, it shows up with all of its component specific styles.

By the way, watch the tab as I do this. I love how Visual Studio will now auto rebuild and refresh my app as I make changes! This same functionality is also available from the command-line using `dotnet watch run`.

