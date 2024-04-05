
using System;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Running;

namespace Blazique.Benchmarks;

class Program
{
    static void Main(string[] args)
    {
        IConfig config = DefaultConfig.Instance
            .AddDiagnoser(MemoryDiagnoser.Default)
            .AddDiagnoser(EventPipeProfiler.Default)
            .AddExporter(JsonExporter.Default);

        var summary = BenchmarkRunner.Run<Benchmarks.Counter.BuildRenderTreeBenchmarks>(config);
    }
}