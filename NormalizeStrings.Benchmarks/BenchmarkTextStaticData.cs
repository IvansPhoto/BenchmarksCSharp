using BenchmarkDotNet.Attributes;

namespace NormalizeStrings.Benchmarks;

[MemoryDiagnoser]
[MarkdownExporterAttribute.GitHub]
public class BenchmarkTextStaticData
{
    [Benchmark(Baseline = true)]
    [Arguments(TestData.CharsRaw1)]
    [Arguments(TestData.CharsRaw2)]
    [Arguments(TestData.CharsRaw3)]
    [Arguments(TestData.CharsRaw4)]
    public string MultipleReplace(string text)
    {
        return NormalizeTextForCsv.MultipleReplace(text);
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



    [Benchmark]
    [Arguments(TestData.CharsRaw1)]
    [Arguments(TestData.CharsRaw2)]
    [Arguments(TestData.CharsRaw3)]
    [Arguments(TestData.CharsRaw4)]
    public string StringCreateReplace(string text)
    {
        return NormalizeTextForCsv.StringCreateReplace(text);
    }

    [Benchmark]
    [Arguments(TestData.CharsRaw1)]
    [Arguments(TestData.CharsRaw2)]
    [Arguments(TestData.CharsRaw3)]
    [Arguments(TestData.CharsRaw4)]
    public string NewSelect(string text)
    {
        return NormalizeTextForCsv.NewSelect(text);
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
    public string ValueStringBuilder(string text)
    {
        return NormalizeTextForCsv.ValueStringBuilder(text);
    }
}