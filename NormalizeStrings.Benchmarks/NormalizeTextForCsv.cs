using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace NormalizeStrings.Benchmarks;

public static partial class NormalizeTextForCsv
{
    public static readonly char[] CharToReplace = ['\n', '\r', ',', ';'];
    
    public static string Replace(string text) => text.Replace('\n', ' ').Replace('\r', ' ').Replace(',' , ' ').Replace(';', ' ');
    
    public static string StringCreateFor(string text) =>
        string.Create(text.Length, text, static (chars, state) =>
        {
            const char correctSymbol = ' ';
            for (var i = 0; i < state.Length; i++)
            {
                chars[i] = state[i] switch
                {
                    '\r' or '\n' or ',' or ';' => correctSymbol,
                    _ => state[i]
                };
            }
        });
    
    public static string StringCreateReplace(string text) =>
        string.Create(text.Length, text, static (chars, state) =>
        {
            state.CopyTo(chars);

            chars.Replace('\n', ' ');
            chars.Replace('\r', ' ');
            chars.Replace(',', ' ');
            chars.Replace(';', ' ');
        });
    
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

    public static string ValueStringBuilder(string text)
    {
        var sb = new ValueStringBuilder(text.Length);
        foreach (var ch in text)
        {
            sb.Append(ch is '\n' or '\r' or ',' or ';' ? ' ' : ch);
        }

        return sb.ToString();
    }
}