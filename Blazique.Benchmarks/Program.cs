
using System;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Exporters.Json;

namespace Blazique.Benchmarks;

class Program
{
    static void Main(string[] args)
    {
        IConfig config = DefaultConfig.Instance
            .AddDiagnoser(MemoryDiagnoser.Default)
            .AddDiagnoser(EventPipeProfiler.Default);

        var summary = BenchmarkRunner.Run<Counter.BuildRenderTreeBenchmarks>(config);
    }
}