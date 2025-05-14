using BenchmarkDotNet.Attributes;

namespace NormalizeStrings.Benchmarks;

[RPlotExporter]
[MemoryDiagnoser]
public class BenchmarkTextStaticData
{
    [Benchmark(Baseline = true)]
    [Arguments(TestData.CharsRaw1)]
    [Arguments(TestData.CharsRaw2)]
    [Arguments(TestData.CharsRaw3)]
    [Arguments(TestData.CharsRaw4)]
    public string Replace(string text)
    {
        return NormalizeTextForCsv.Replace(text);
    }
    
    [Benchmark]
    [Arguments(TestData.CharsRaw1)]
    [Arguments(TestData.CharsRaw2)]
    [Arguments(TestData.CharsRaw3)]
    [Arguments(TestData.CharsRaw4)]
    public string StringNewSelect(string text)
    {
        return NormalizeTextForCsv.StringNewSelect(text);
    }    
    
    [Benchmark]
    [Arguments(TestData.CharsRaw1)]
    [Arguments(TestData.CharsRaw2)]
    [Arguments(TestData.CharsRaw3)]
    [Arguments(TestData.CharsRaw4)]
    public string ReplaceRegex(string text)
    {
        return NormalizeTextForCsv.ReplaceRegex(text);
    }    
    
    [Benchmark]
    [Arguments(TestData.CharsRaw1)]
    [Arguments(TestData.CharsRaw2)]
    [Arguments(TestData.CharsRaw3)]
    [Arguments(TestData.CharsRaw4)]
    public string StringBuilder(string text)
    {
        return NormalizeTextForCsv.StringBuilder(text);
    }
        
    [Benchmark]
    [Arguments(TestData.CharsRaw1)]
    [Arguments(TestData.CharsRaw2)]
    [Arguments(TestData.CharsRaw3)]
    [Arguments(TestData.CharsRaw4)]
    public string StringCreateFor(string text)
    {
        return NormalizeTextForCsv.StringCreateFor(text);
    }
}