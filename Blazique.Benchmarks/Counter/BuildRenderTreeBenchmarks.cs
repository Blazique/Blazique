using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using Blazique.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Blazique.Benchmarks.Counter;


[MinIterationTime(100)]
public class BuildRenderTreeBenchmarks
{

    [Benchmark(Baseline = true)]
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

    [Benchmark]
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