using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using Blazique.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Blazique.Benchmarks.Counter;


[MemoryDiagnoser]
[MinIterationTime(100)]
[JsonExporterAttribute.Full]
public class BuildRenderTreeBenchmarks
{

    [Benchmark(Baseline = true, Description = "Standard Razor Counter Component")]
    public async Task BuildRenderTree()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddLogging();

        IServiceProvider serviceProvider = services.BuildServiceProvider();
        ILoggerFactory loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

        await using var htmlRenderer = new HtmlRenderer(serviceProvider, loggerFactory);

        await htmlRenderer.Dispatcher.InvokeAsync(async () =>
        {
            var output = await htmlRenderer.RenderComponentAsync<Counter>();
        });
    }

    [Benchmark(Description = "Blazique Counter Component")]
    public async Task BuildRenderTreeWithBlazique()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddLogging();

        IServiceProvider serviceProvider = services.BuildServiceProvider();
        ILoggerFactory loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

        await using var htmlRenderer = new HtmlRenderer(serviceProvider, loggerFactory);

        await htmlRenderer.Dispatcher.InvokeAsync(async () =>
        {
             var output = await htmlRenderer.RenderComponentAsync<BlaziqueCounter>();
        });
    }
}