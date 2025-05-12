namespace NormalizeStrings.Benchmarks;

public static class NormalizeTextForCsv
{
    public static readonly char[] CharToReplace = ['\n', '\r', ',', ';'];
    
    public static string Replace(string text) => text.Replace('\n', ' ').Replace('\r', ' ').Replace(',' , ' ').Replace(';', ' ');

    public static string Select(string text) => new(text.Select(c => c is '\n' or '\r' or ',' or ';' ? ' ' : c).ToArray());
}