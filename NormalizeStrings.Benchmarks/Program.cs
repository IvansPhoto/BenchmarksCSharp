using BenchmarkDotNet.Running;
using NormalizeStrings.Benchmarks;

_ = BenchmarkRunner.Run<BenchmarkTextGeneratedData>();
_ = BenchmarkRunner.Run<BenchmarkTextStaticData>();