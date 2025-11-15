using BenchmarkDotNet.Running;
using Serialisation.Benchmarks;

_ = BenchmarkRunner.Run<BenchmarkDeserialize>();
_ = BenchmarkRunner.Run<BenchmarkSerialize>();