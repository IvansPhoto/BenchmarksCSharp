# Result table

## NormalizeStrings result
The task goal is to create a new string without symbols that may affect CSV file structure: '\n', '\r', ';', ',';

BenchmarkDotNet v0.14.0, Fedora Linux 42 (KDE Plasma Desktop Edition)
AMD Ryzen 7 6800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.105
[Host]     : .NET 9.0.4 (9.0.425.16305), X64 RyuJIT AVX2
DefaultJob : .NET 9.0.4 (9.0.425.16305), X64 RyuJIT AVX2

The CPU supports AVX256.

### Runtime generated test data
| Method              | Text                 | Mean      | Error    | StdDev   | Median    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------- |--------------------- |----------:|---------:|---------:|----------:|------:|--------:|-------:|----------:|------------:|
| **Replace**             | **,H9J(...)A 20 [100]**  |  **56.85 ns** | **1.189 ns** | **3.152 ns** |  **55.28 ns** |  **1.00** |    **0.08** | **0.0802** |     **672 B** |        **1.00** |
| StringCreate        | ,H9J(...)A 20 [100]  | 479.90 ns | 2.425 ns | 2.268 ns | 479.39 ns |  8.47 |    0.44 | 0.0267 |     224 B |        0.33 |
| Select              | ,H9J(...)A 20 [100]  | 263.77 ns | 1.286 ns | 1.140 ns | 263.76 ns |  4.65 |    0.24 | 0.0639 |     536 B |        0.80 |
| SelectStringBuilder | ,H9J(...)A 20 [100]  | 173.15 ns | 0.465 ns | 0.435 ns | 173.09 ns |  3.05 |    0.16 | 0.0918 |     768 B |        1.14 |
| ReplaceRegex        | ,H9J(...)A 20 [100]  | 237.10 ns | 1.138 ns | 1.064 ns | 237.11 ns |  4.18 |    0.22 | 0.0267 |     224 B |        0.33 |
|                     |                      |           |          |          |           |       |         |        |           |             |
| **Replace**             | **,U0Dy(...),d 10 [25]** |  **21.68 ns** | **0.211 ns** | **0.198 ns** |  **21.72 ns** |  **1.00** |    **0.01** | **0.0086** |      **72 B** |        **1.00** |
| StringCreate        | ,U0Dy(...),d 10 [25] | 124.42 ns | 1.438 ns | 1.345 ns | 124.20 ns |  5.74 |    0.08 | 0.0086 |      72 B |        1.00 |
| Select              | ,U0Dy(...),d 10 [25] | 115.21 ns | 1.236 ns | 1.156 ns | 115.11 ns |  5.32 |    0.07 | 0.0286 |     240 B |        3.33 |
| SelectStringBuilder | ,U0Dy(...),d 10 [25] |  57.45 ns | 1.143 ns | 1.173 ns |  57.18 ns |  2.65 |    0.06 | 0.0334 |     280 B |        3.89 |
| ReplaceRegex        | ,U0Dy(...),d 10 [25] | 139.25 ns | 0.339 ns | 0.283 ns | 139.24 ns |  6.42 |    0.06 | 0.0086 |      72 B |        1.00 |
|                     |                      |           |          |          |           |       |         |        |           |             |
| **Replace**             | **,xoL(...)s 25 [100]**  |  **46.79 ns** | **0.949 ns** | **0.932 ns** |  **46.99 ns** |  **1.00** |    **0.03** | **0.0535** |     **448 B** |        **1.00** |
| StringCreate        | ,xoL(...)s 25 [100]  | 473.91 ns | 2.082 ns | 1.846 ns | 473.77 ns | 10.13 |    0.21 | 0.0267 |     224 B |        0.50 |
| Select              | ,xoL(...)s 25 [100]  | 271.17 ns | 1.858 ns | 1.738 ns | 271.41 ns |  5.80 |    0.13 | 0.0639 |     536 B |        1.20 |
| SelectStringBuilder | ,xoL(...)s 25 [100]  | 171.34 ns | 1.958 ns | 1.736 ns | 171.88 ns |  3.66 |    0.08 | 0.0918 |     768 B |        1.71 |
| ReplaceRegex        | ,xoL(...)s 25 [100]  | 193.48 ns | 1.247 ns | 1.105 ns | 193.64 ns |  4.14 |    0.09 | 0.0267 |     224 B |        0.50 |


## Compile-time created test data
| Method          | text                 | Mean      | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------- |--------------------- |----------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| **Replace**         | **BlaBa(...) 25/1 [24]** |  **22.94 ns** | **0.399 ns** | **0.373 ns** |  **1.00** |    **0.02** | **0.0086** |      **72 B** |        **1.00** |
| StringNewSelect | BlaBa(...) 25/1 [24] |  94.76 ns | 0.688 ns | 0.644 ns |  4.13 |    0.07 | 0.0277 |     232 B |        3.22 |
| ReplaceRegex    | BlaBa(...) 25/1 [24] |  77.47 ns | 0.473 ns | 0.443 ns |  3.38 |    0.06 | 0.0086 |      72 B |        1.00 |
| StringBuilder   | BlaBa(...) 25/1 [24] |  57.01 ns | 0.739 ns | 0.656 ns |  2.49 |    0.05 | 0.0334 |     280 B |        3.89 |
| StringCreateFor | BlaBa(...) 25/1 [24] | 120.98 ns | 0.660 ns | 0.585 ns |  5.27 |    0.09 | 0.0086 |      72 B |        1.00 |
|                 |                      |           |          |          |       |         |        |           |             |
| **Replace**         | **BlaBa(...)100/2 [98]** |  **30.30 ns** | **0.047 ns** | **0.040 ns** |  **1.00** |    **0.00** | **0.0268** |     **224 B** |        **1.00** |
| StringNewSelect | BlaBa(...)100/2 [98] | 256.24 ns | 2.837 ns | 2.369 ns |  8.46 |    0.08 | 0.0639 |     536 B |        2.39 |
| ReplaceRegex    | BlaBa(...)100/2 [98] | 117.91 ns | 0.652 ns | 0.578 ns |  3.89 |    0.02 | 0.0267 |     224 B |        1.00 |
| StringBuilder   | BlaBa(...)100/2 [98] | 159.80 ns | 2.315 ns | 2.166 ns |  5.27 |    0.07 | 0.0918 |     768 B |        3.43 |
| StringCreateFor | BlaBa(...)100/2 [98] | 471.32 ns | 1.839 ns | 1.721 ns | 15.56 |    0.06 | 0.0267 |     224 B |        1.00 |
|                 |                      |           |          |          |       |         |        |           |             |
| **Replace**         | **BlaBa(...)100/3 [98]** |  **46.29 ns** | **0.955 ns** | **1.062 ns** |  **1.00** |    **0.03** | **0.0535** |     **448 B** |        **1.00** |
| StringNewSelect | BlaBa(...)100/3 [98] | 257.47 ns | 1.947 ns | 1.822 ns |  5.57 |    0.13 | 0.0639 |     536 B |        1.20 |
| ReplaceRegex    | BlaBa(...)100/3 [98] | 148.01 ns | 0.561 ns | 0.525 ns |  3.20 |    0.07 | 0.0267 |     224 B |        0.50 |
| StringBuilder   | BlaBa(...)100/3 [98] | 171.31 ns | 1.577 ns | 1.317 ns |  3.70 |    0.09 | 0.0918 |     768 B |        1.71 |
| StringCreateFor | BlaBa(...)100/3 [98] | 469.86 ns | 0.789 ns | 0.738 ns | 10.16 |    0.24 | 0.0267 |     224 B |        0.50 |
|                 |                      |           |          |          |       |         |        |           |             |
| **Replace**         | **BlaBa(...)100/4 [98]** |  **62.34 ns** | **1.218 ns** | **1.303 ns** |  **1.00** |    **0.03** | **0.0803** |     **672 B** |        **1.00** |
| StringNewSelect | BlaBa(...)100/4 [98] | 278.92 ns | 2.370 ns | 1.850 ns |  4.48 |    0.10 | 0.0639 |     536 B |        0.80 |
| ReplaceRegex    | BlaBa(...)100/4 [98] | 173.14 ns | 0.311 ns | 0.291 ns |  2.78 |    0.06 | 0.0267 |     224 B |        0.33 |
| StringBuilder   | BlaBa(...)100/4 [98] | 182.47 ns | 1.434 ns | 1.342 ns |  2.93 |    0.07 | 0.0918 |     768 B |        1.14 |
| StringCreateFor | BlaBa(...)100/4 [98] | 475.02 ns | 0.611 ns | 0.510 ns |  7.62 |    0.17 | 0.0267 |     224 B |        0.33 |
