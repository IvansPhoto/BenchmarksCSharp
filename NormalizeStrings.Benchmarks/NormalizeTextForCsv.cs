using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace NormalizeStrings.Benchmarks;

public static partial class NormalizeTextForCsv
{
    public static readonly char[] CharToReplace = ['\n', '\r', ',', ';'];

    public static string NewSelect(string text) =>
        new(text.Select(c => c is '\n' or '\r' or ',' or ';' ? ' ' : c).ToArray());

    public static string MultipleReplace(string text) =>
        text.Replace('\n', ' ').Replace('\r', ' ').Replace(',', ' ').Replace(';', ' ');


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

public readonly record struct ParsingResult(
    ParsingResult.Success? SuccessResult,
    ParsingResult.Partially? PartiallyResult,
    ParsingResult.Failed? FailedResult)
{
    public sealed record Success(string[] Text);

    public readonly record struct Partially(string[] Text, string[] Warnings);

    public readonly record struct Failed(string Error);
}

public static class Sample
{
    /// <summary>
    /// Kind of an exhaustive switch
    /// </summary>
    public static void ProcessResultExhaustive(ParsingResult data)
    {
        var result = data switch
        {
            (SuccessResult: not null, PartiallyResult: null, FailedResult: null) =>
                ProcessSuccess(data.SuccessResult!),
            (SuccessResult: null, PartiallyResult: not null, FailedResult: null) =>
                ProcessWarning(data.PartiallyResult!.Value),
            (SuccessResult: null, PartiallyResult: null, FailedResult: not null) =>
                ProcessFailure(data.FailedResult!.Value),
            _ => throw new ArgumentOutOfRangeException(nameof(data), data, null)
        };
    }

    /// <summary>
    /// Non exhaustive switch
    /// </summary>
    public static void ProcessResultNonExhaustive(ParsingResult data)
    {
        var result = data switch
        {
            { SuccessResult: not null, PartiallyResult: null, FailedResult: null } =>
                ProcessSuccess(data.SuccessResult),
            { SuccessResult: null, PartiallyResult: not null, FailedResult: null } =>
                ProcessWarning(data.PartiallyResult.Value),
            { SuccessResult: null, PartiallyResult: null, FailedResult: not null } =>
                ProcessFailure(data.FailedResult.Value),
            _ => throw new ArgumentOutOfRangeException(nameof(data), data, null)
        };
    }

    private static string ProcessSuccess(ParsingResult.Success result) => "Take the result";

    private static string ProcessWarning(ParsingResult.Partially result) => "Pay attention to warnings";

    private static string ProcessFailure(ParsingResult.Failed result) => "Handle errors";
}