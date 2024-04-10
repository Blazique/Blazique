window.BENCHMARK_DATA = {
  "lastUpdate": 1712738500271,
  "repoUrl": "https://github.com/Blazique/Blazique",
  "entries": {
    "Benchmark": [
      {
        "commit": {
          "author": {
            "email": "me@mauricepeters.dev",
            "name": "Maurice CGP Peters"
          },
          "committer": {
            "email": "me@mauricepeters.dev",
            "name": "Maurice CGP Peters"
          },
          "distinct": true,
          "id": "32935338c6e67f90df91d6d0882e5af5c10f2611",
          "message": "Update benchmark workflow to use PUSH_BENCHMARK_RESULTS secret in benchmark.yml",
          "timestamp": "2024-04-10T10:16:44+02:00",
          "tree_id": "7724d1d2eafbed8c3cb414adcf7e39a6cccc21e9",
          "url": "https://github.com/Blazique/Blazique/commit/32935338c6e67f90df91d6d0882e5af5c10f2611"
        },
        "date": 1712737064465,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "Blazique.Benchmarks.Counter.BuildRenderTreeBenchmarks.BuildRenderTree",
            "value": 23736.09683159722,
            "unit": "ns",
            "range": "± 8298.46209370939"
          },
          {
            "name": "Blazique.Benchmarks.Counter.BuildRenderTreeBenchmarks.BuildRenderTreeWithBlazique",
            "value": 24499.23624785959,
            "unit": "ns",
            "range": "± 1194.5816259236874"
          }
        ]
      },
      {
        "commit": {
          "author": {
            "email": "me@mauricepeters.dev",
            "name": "Maurice CGP Peters"
          },
          "committer": {
            "email": "me@mauricepeters.dev",
            "name": "Maurice CGP Peters"
          },
          "distinct": true,
          "id": "d15fbbe92cf0f2b68dc78bb1c03e9e6035801158",
          "message": "Update benchmark workflow to include Blazique Counter Component in BuildRenderTreeBenchmarks.cs",
          "timestamp": "2024-04-10T10:40:40+02:00",
          "tree_id": "d1fadde399fdda0e07b71cc71ad02cbeccecc8ce",
          "url": "https://github.com/Blazique/Blazique/commit/d15fbbe92cf0f2b68dc78bb1c03e9e6035801158"
        },
        "date": 1712738499968,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "Blazique.Benchmarks.Counter.BuildRenderTreeBenchmarks.BuildRenderTree",
            "value": 24750.40571925951,
            "unit": "ns",
            "range": "± 9783.080622554022"
          },
          {
            "name": "Blazique.Benchmarks.Counter.BuildRenderTreeBenchmarks.BuildRenderTreeWithBlazique",
            "value": 23828.547585227272,
            "unit": "ns",
            "range": "± 1010.5232570673602"
          }
        ]
      }
    ]
  }
}