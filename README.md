[![CD](https://github.com/Blazique/Blazique/actions/workflows/cd.yml/badge.svg)](https://github.com/Blazique/Blazique/actions/workflows/cd.yml)
[![NuGet Badge](https://img.shields.io/nuget/v/Blazique)](https://www.nuget.org/packages/Blazique)

![Blazique Logo](https://github.com/Blazique/Blazique/assets/3175802/2933c84a-c9ec-47cd-9bee-2978869894ab)

# Blazique: A Modern MVU Library for Blazor

Blazique is a library designed to enhance the development of Blazor applications using the Model-View-Update (MVU) architecture. For an elaborate explanation on how this library came to be, read [this](https://www.mauricepeters.dev/2023/10/model-view-update-mvu-pattern-using-asp.html) blog post.

## Target Audience

Blazique is ideal for teams with extensive C# expertise who prefer to stay within the C# context. Blazor is already very much suited to building applications in which both client-side (minimizing the need for JavaScript) as well as server-side code can be written in C#. This library will take you the last mile so that even the markup code is pure C#.

## Requirements Summary

Blazique aims to provide a library that:
- Avoids markup languages for output generation.
- Supports efficient DOM updates with minimal performance impact.
- Allows embedding of Razor components within MVU components and vice versa.
- Maintains readability and structure similar to markup languages using C# features.

## Key Features

- **Three Types of Components**: Blazique introduces three base classes for component creation:
  - `Component`: For pure C# markup components without a model or MVU interaction.
  - `Component<TModel>`: Adds a model representing the component's state, with a `ShouldRender` method to check for changes.
  - `Component<TModel, TCommand>`: Implements the MVU pattern with an `Update` method for model changes and a `View` method for UI rendering.

- **Code Layout & Design**: The library ensures that the code layout is readable and similar to markup languages, utilizing C# 12 features like "Collection Expressions" for a cleaner syntax.

- **Integration with Blazor**: Designed to work seamlessly with Blazor's features, Blazique components can be composed with Razor-based components and vice versa.

- **Code only page components**: Use the appropriate attributes to make a page routeable and set the rendermode using attributes (which was depricated from .NET 8 on): 
    ```csharp
    [Route("/")]
    [InteractiveServerRenderMode]
    public class Index : Component
    {
    }
    ```

## Possible Advantages and Disadvantages

- **Pros**:
  - Simplifies testing with pure functions and immutable data.
  - Enhances debugging with a clear unidirectional data flow.
  - Offers a familiar development environment for C# developers.

- **Cons**:
  - Steeper learning curve for those new to a functional programming style.
  - Less mature tooling and ecosystem compared to MVC or MVVM patterns.

## Status
Stabalizing the API surface by implementing the [RealWorld sample application Conduit](https://demo.realworld.io/#/), from the [RealWorld open source project](https://github.com/gothinkster/realworld). This could lead to breaking API changes up untill the release of version 1.x. The reo for the implementation can be found [here](https://github.com/Blazique/conduit). This also serves as an up to date sample.

## Installation

To install Blazique, run the following command in your terminal:

```bash
dotnet add package Blazique
```
## Benchmark Results
[View Benchmark Results](https://blazique.github.io/Blazique/benchmark-results/)