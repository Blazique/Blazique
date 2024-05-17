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

    private RenderTreeBuilder builder;
    private Blazique.Benchmarks.Counter.Counter counter;
    private BlaziqueCounter blaziqueCounter;

    [GlobalSetup]
    public void GlobalSetup()
    {
        builder = new RenderTreeBuilder();
        counter = new Blazique.Benchmarks.Counter.Counter();
        blaziqueCounter = new BlaziqueCounter();
    }

    [Benchmark(Baseline = true, Description = "Standard Razor Counter Component")]
    public void BuildRenderTree()
    {
        counter.BuildRenderTreeExternal(builder);
    }

    [Benchmark(Description = "Blazique Counter Component")]
    public void BuildRenderTreeWithBlazique()
    {
        blaziqueCounter.BuildRenderTreeExternal(builder);
    }
}