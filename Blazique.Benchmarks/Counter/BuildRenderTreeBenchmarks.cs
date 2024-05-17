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
[MinIterationTime(250)]
[JsonExporterAttribute.Full]
[MinIterationCount(15)]
[MaxIterationCount(20)]
public class BuildRenderTreeBenchmarks
{

    [Benchmark(Baseline = true, Description = "Standard Razor Counter Component")]
    public async Task BuildRenderTree()
    {
        var counter = new Counter();
        var builder = new RenderTreeBuilder();
        counter.BuildRenderTreeExternal(builder);
    }

    [Benchmark(Description = "Blazique Counter Component")]
    public async Task BuildRenderTreeWithBlazique()
    {
        var blaziqueCounter = new BlaziqueCounter();
        var builder = new RenderTreeBuilder();
        blaziqueCounter.BuildRenderTreeExternal(builder);
    }
}