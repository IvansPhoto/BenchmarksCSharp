# Replace with AVX versus the for loop…
## Task description
I had a task at my job about creating CSV files from another string. A CSV file has a simple structure where each line is a row, separated by the usual new line symbol: ‘\n’ or ‘\r’, and each cell in a row (or value) that is separated with a delimiter, should be a comma (from the format name), but also can be a semicolon or any symbol. A string should contain these symbols only in specific places; otherwise, the SCV structure will be broken. To avoid it, the string of each cell should be normalized.
So, my task in technical terms was to create a method that replaces these symbols with something neutral.
Quite a simple task, yeah?
Yes and no. “Yes” - because it can be done in one string, and “No” because it might allocate a lot of objects in a heap because string is immutable in .NET.

## Naive solutions
The first idea that may come to your mind is to iterate over the string, replace all undesired characters with a suitable replacement, make a new array of chars, and create a new string based on this array.
```csharp
public static string StringNewSelect(string text) => 
    new(text.Select(c => c is '\n' or '\r' or ',' or ';' ? ' ' : c).ToArray());
```
But how about build-in methods? 
There is the `string Replace(char oldChar, char newChar)` method.
It can replace only one character per invocation, but we need to replace four, so we have to call it four times, and each call invocation returns a string.
```csharp
public static string Replace(string text) => 
    text.Replace('\n', ' ').Replace('\r', ' ').Replace(',' , ' ').Replace(';', ' ');
```
I had doubts about its performance, and decided to check the hidden implementation in .NET 9.0 and almost at the begging find `Vector512`.
That is a hardware acceleration!
It was not a surprise to me, because the C# development team added vectorization support to many LINQ methods in the last years.
After that, I stated think that even four `Replace` calls might be faster than a single iteration, but I could not predict the behavior and created Benchmarks to test both solutions.

### Benchmark results with support up to AVX256
| Method              | Text                 | Mean      | Error    | StdDev   | Median    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------- |--------------------- |----------:|---------:|---------:|----------:|------:|--------:|-------:|----------:|------------:|
| **Replace**             | **,H9J(...)A 20 [100]**  |  **57.13 ns** | **1.184 ns** | **3.240 ns** |  **55.40 ns** |  **1.15** |    **0.06** | **0.0803** |     **672 B** |        **3.00** |
| Select              | ,H9J(...)A 20 [100]  | 271.77 ns | 2.501 ns | 2.217 ns | 271.91 ns |  5.46 |    0.04 | 0.0639 |     536 B |        2.39 |
|                     |                      |           |          |          |           |       |         |        |           |             |
| **Replace**             | **,U0Dy(...),d 10 [25]** |  **21.72 ns** | **0.250 ns** | **0.221 ns** |  **21.77 ns** |  **0.46** |    **0.00** | **0.0086** |      **72 B** |        **1.00** |
| Select              | ,U0Dy(...),d 10 [25] | 116.44 ns | 0.739 ns | 0.691 ns | 116.41 ns |  2.48 |    0.01 | 0.0286 |     240 B |        3.33 |
|                     |                      |           |          |          |           |       |         |        |           |             |
| **Replace**             | **,xoL(...)s 25 [100]**  |  **45.76 ns** | **0.915 ns** | **0.811 ns** |  **46.01 ns** |  **0.92** |    **0.02** | **0.0535** |     **448 B** |        **2.00** |
| Select              | ,xoL(...)s 25 [100]  | 253.05 ns | 1.703 ns | 1.593 ns | 253.10 ns |  5.10 |    0.03 | 0.0639 |     536 B |        2.39 |

As you can see from the benchmark results, four `Replace()` invocations are faster than one cycle in the `Select()` method.

## More advance solutions
After some web research, I found that there is a more memory and CPU-efficient way to create a string rather than `new string()`.
It is the `string.Create()` method, not as concise as the previous couple, and requires more code, but acceleration requires some effort.
```csharp
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
```
After thinking about this solution, I found that it could be combined with `Replace()` and created the fourth solution:
```csharp
public static string StringCreateReplace(string text) =>
    string.Create(text.Length, text, static (chars, state) =>
    {
        state.CopyTo(chars);

        chars.Replace('\n', ' ');
        chars.Replace('\r', ' ');
        chars.Replace(',', ' ');
        chars.Replace(';', ' ');
    });
```
And then I realize that the built-in `StringBuilder` can append not only a string but also a char.
This led me to the fifth solution:
```csharp
public static string StringBuilder(string text)
{
    var sb = new StringBuilder();
    foreach (var ch in text)
    {
        sb.Append(ch is '\n' or '\r' or ',' or ';' ? ' ' : ch);
    }

    return sb.ToString();
}
```
I think many .NET engineers know about the efficiency of `StringBuilder`.
It is good enough for a general task but might not be good for a service that struggles from pressure on GC.
I did the same exercise as before and many other developers - copied-passed the internal `ValueStringBuilder` and created the sixth solution:
```csharp
public static string ValueStringBuilder(string text)
{
    var sb = new ValueStringBuilder(text.Length);
    foreach (var ch in text)
    {
        sb.Append(ch is '\n' or '\r' or ',' or ';' ? ' ' : ch);
    }

    return sb.ToString();
}
```
It looks the same as the previous because the API of `ValueStringBuilder` is very similar to the usual `StringBuilder`.

### The final Benchmark results with support up to AVX256.
I created a benchmark payload close to my production requirements.
The result highly depends on the string length and the number of symbols for replacement, but the `Replace()` method will be even more efficient on a CPU with AVX516 support.
That led us to the usual conclusion - there is no silver bullet, and the right approach should be chosen under your conditions.