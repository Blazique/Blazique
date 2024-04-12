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

## Possible Advantages and Disadvantages

- **Pros**:
  - Simplifies testing with pure functions and immutable data.
  - Enhances debugging with a clear unidirectional data flow.
  - Offers a familiar development environment for C# developers.

- **Cons**:
  - Steeper learning curve for those new to a functional programming style.
  - Less mature tooling and ecosystem compared to MVC or MVVM patterns.

## Usage Examples

Here are code samples demonstrating how to use Blazique for each component type:

```csharp
// Component without a model
public class Index : Component
{
    public override Node[] Render() =>
            [
                component<PageTitle>
                (
                    [],
                    [
                        text("Home")
                    ]
                ),
                h1
                (
                    [],
                    [
                        text("Home")
                    ]
                ),
                text("Welcome to your new app."),
                component<SurveyPrompt>
                (
                    [
                        attribute("Title", ["How is Blazor working for you? "])
                    ],
                    []
                )
            ];
}

public class SurveyPrompt : Component
{
    public override Node[] Render() =>
    [
        div
        (
            [
                @class(["alert alert-secondary mt-4"])
            ],
            [
                span
                (
                    [
                        @class(["oi oi-pencil me-2"]),
                        aria_hidden(["true"])
                    ],
                    []
                ),
                strong
                (
                    [
                        text(Title)
                    ]
                ),
                span
                (
                    [
                        @class(["text-nowrap"])
                    ],
                    [
                        text("Please take our "),
                        a
                        (
                            [
                                href(["https://go.microsoft.com/fwlink/?linkid=2186158"]),
                                @class(["font-weight-bold link-dark"])
                            ],
                            [
                                text("brief survey")
                            ]
                        ),
                        text(" and tell us what you think.")
                    ]
                )
            ]
        )
    ];
    

    [Parameter]
    public string? Title { get; set; }
}

// Component with a model
public class Weather : Component<WeatherModel>
{        
    private static readonly string[] Summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

    protected override async Task OnInitializedAsync()
    {
        // Simulate retrieving the data asynchronously.
        await Task.Delay(1000);

        var startDate = DateOnly.FromDateTime(DateTime.Now);
        Model.Forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = startDate.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }).ToArray();
    }

    public override Node[] Render() =>
        [
            component<PageTitle>([], [text("Weather forecast")]),

            h1([text("Weather")]),

            p([text("This component demonstrates showing data from the server.")]),

            Model.Forecasts is null
            ?
                p([em([text("Loading...")])])
            :
                table([@class(["table"])],[
                        thead([
                            tr([
                                th([text("Date")]),
                                th([text("Temp. (C)")]),
                                th([text("Temp. (F)")]),
                                th([text("Summary")]
                                )]
                            )]
                        ),
                        tbody(
                            Model.Forecasts.Select(forecast =>
                                tr([
                                    td([text(forecast.Date.ToShortDateString())]),
                                    td([text(forecast.TemperatureC)]),
                                    td([text(forecast.TemperatureC)]),
                                    td([text(forecast.Summary ?? "")])
                                ])
                        ).ToArray())]
                )];
}

public record WeatherModel
{
    public WeatherForecast[]? Forecasts { get; internal set; }
}

// Component implementing MVU pattern
public class Counter : Component<CounterModel, CounterCommand>
{
    public override Node[] View(CounterModel model, Func<CounterCommand, Task> dispatch) =>
        [
            div
            (
                [],
                [
                    button
                    (
                        [
                            type(["button"]),
                            @class(["btn", "btn-primary"]),
                            on.click(_ => dispatch(new Increment()))
                        ],
                        [
                            text("+")
                        ]
                    ),
                    div
                    (
                        [],
                        [
                           text(model.Count.ToString())
                        ]
                    ),
                    button
                    (
                        [
                            type(["button"]),
                            @class(["btn", "btn-primary"]),
                            on.click
                            (
                                 _ => dispatch(new Decrement())
                            )
                        ],
                        [
                            text("-")
                        ]
                    )
                ]
            )
        ];

    public override async ValueTask<CounterModel> Update(CounterModel model, CounterCommand command) =>
            command switch
            {
                Increment => model with { Count = model.Count + 1 },
                Decrement => model with { Count = model.Count - 1 },
                _ => throw new NotImplementedException(),
            };
}

public interface CounterCommand
{
}

public record Increment : CounterCommand;
public record Decrement : CounterCommand;

public record CounterModel
{
    public required int Count { get; init; }
};

````

## Installation

To install Blazique, run the following command in your terminal:

```bash
dotnet add package Blazique
```
## Benchmark Results
[View Benchmark Results](https://blazique.github.io/Blazique/benchmark-results/)