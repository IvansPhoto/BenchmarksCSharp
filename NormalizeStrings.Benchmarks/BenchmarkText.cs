using BenchmarkDotNet.Attributes;

namespace NormalizeStrings.Benchmarks;

[RPlotExporter]
[MemoryDiagnoser]
public class BenchmarkText
{
    [Benchmark(Baseline = true)]
    [Arguments(TestData.Chars1)]
    [Arguments(TestData.Chars2)]
    [Arguments(TestData.Chars3)]
    [Arguments(TestData.Chars4)]
    public string Replace(string text)
    {
        return NormalizeTextForCsv.Replace(text);
    }
    
    [Benchmark]
    [Arguments(TestData.Chars1)]
    [Arguments(TestData.Chars2)]
    [Arguments(TestData.Chars3)]
    [Arguments(TestData.Chars4)]
    public string Select(string text)
    {
        return NormalizeTextForCsv.Select(text);
    }
}