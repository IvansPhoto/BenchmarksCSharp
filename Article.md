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
It can replace only one character per invocation, but we need to replace four, so we have to use call it four times, and each call invocation returns a string.
I had doubts about its performance and decided to check how it works.