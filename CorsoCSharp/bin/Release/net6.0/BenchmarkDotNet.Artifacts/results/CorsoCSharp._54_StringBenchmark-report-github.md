``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
11th Gen Intel Core i7-11700K 3.60GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.301
  [Host] : .NET 6.0.6 (6.0.622.26707), X64 RyuJIT  [AttachedDebugger]


```
|                  Method | Mean | Error | Ratio | RatioSD |
|------------------------ |-----:|------:|------:|--------:|
| StringConcatenationTest |   NA |    NA |     ? |       ? |

Benchmarks with issues:
  _54_StringBenchmark.StringConcatenationTest: DefaultJob
