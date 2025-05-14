using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace NormalizeStrings.Benchmarks;

public static partial class NormalizeTextForCsv
{
    public static readonly char[] CharToReplace = ['\n', '\r', ',', ';'];
    
    public static string Replace(string text) => text.Replace('\n', ' ').Replace('\r', ' ').Replace(',' , ' ').Replace(';', ' ');

    public static string StringNewSelect(string text) => new(text.Select(c => c is '\n' or '\r' or ',' or ';' ? ' ' : c).ToArray());

    [GeneratedRegex(@"[\r\n,;]+")]
    private static partial Regex _separatorRegex();
    public static string ReplaceRegex(string text) => _separatorRegex().Replace(text, " ");
    
    public static string StringBuilder(string text)
    {
        var sb = new StringBuilder();
        foreach (var ch in text)
        {
            sb.Append(ch is '\n' or '\r' or ',' or ';' ? ' ' : ch);
        }

        return sb.ToString();
    }
    
    public static string StringCreateFor(string text)
    {
        return string.Create(text.Length, text, (chars, buffer) =>
        {
            for (var i = 0; i < chars.Length; i++)
            {
                chars[i] = CharToReplace.Contains(buffer[i]) ? ' ' : buffer[i];
            }
        });
    }
}