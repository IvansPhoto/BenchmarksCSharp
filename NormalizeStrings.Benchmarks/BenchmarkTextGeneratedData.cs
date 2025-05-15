using BenchmarkDotNet.Attributes;

namespace NormalizeStrings.Benchmarks;

[RPlotExporter]
[MemoryDiagnoser]
public class BenchmarkTextGeneratedData
{
    private static readonly Random LocalRandom = new (17);
    private readonly char[] _normalChars =
    [
        'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
        'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
        'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
        '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
    ];

    [ParamsSource(nameof(Generator))]
    public string Text { get; set; } = null!;
    
    public IEnumerable<string> Generator()
    {
        yield return GenerateString(25, 100);
        yield return GenerateString(20, 100);
        yield return GenerateString(10, 25);
    }
    
    public string GenerateString(ushort eachElement, ushort length)
    {
        var lengthFinal = length - eachElement.ToString().Length - 1;
        Span<char> buffer = stackalloc char[lengthFinal];
        for (var i = 0; i < lengthFinal; i++)
        {
            buffer[i] = i % eachElement == 0
                ? NormalizeTextForCsv.CharToReplace[LocalRandom.Next(NormalizeTextForCsv.CharToReplace.Length)]
                : _normalChars[LocalRandom.Next(_normalChars.Length)];
        }
    
        return $"{buffer} {eachElement}";
    }
    
    [Benchmark]
    public string Replace()
    {
        return NormalizeTextForCsv.Replace(Text);
    }
        
    [Benchmark(Baseline = true)]
    public string StringCreateReplace()
    {
        return NormalizeTextForCsv.StringCreateReplace(Text);
    }
    
    [Benchmark]
    public string Select()
    {
        return NormalizeTextForCsv.StringNewSelect(Text);
    }
    
    [Benchmark]
    public string ReplaceRegex()
    {
        return NormalizeTextForCsv.ReplaceRegex(Text);
    }
    
    [Benchmark]
    public string SelectStringBuilder()
    {
        return NormalizeTextForCsv.StringBuilder(Text);
    }
    
    [Benchmark]
    public string ValueStringBuilder()
    {
        return NormalizeTextForCsv.ValueStringBuilder(Text);
    }
}