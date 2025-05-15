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
| **Replace**             | **,H9J(...)A 20 [100]**  |  **57.13 ns** | **1.184 ns** | **3.240 ns** |  **55.40 ns** |  **1.15** |    **0.06** | **0.0803** |     **672 B** |        **3.00** |
| StringCreateFor     | ,H9J(...)A 20 [100]  |  53.92 ns | 0.177 ns | 0.165 ns |  53.88 ns |  1.08 |    0.00 | 0.0268 |     224 B |        1.00 |
| StringCreateReplace | ,H9J(...)A 20 [100]  |  49.78 ns | 0.097 ns | 0.086 ns |  49.77 ns |  1.00 |    0.00 | 0.0268 |     224 B |        1.00 |
| Select              | ,H9J(...)A 20 [100]  | 271.77 ns | 2.501 ns | 2.217 ns | 271.91 ns |  5.46 |    0.04 | 0.0639 |     536 B |        2.39 |
| ReplaceRegex        | ,H9J(...)A 20 [100]  | 208.23 ns | 0.896 ns | 0.838 ns | 208.11 ns |  4.18 |    0.02 | 0.0267 |     224 B |        1.00 |
| SelectStringBuilder | ,H9J(...)A 20 [100]  | 172.08 ns | 0.458 ns | 0.428 ns | 171.97 ns |  3.46 |    0.01 | 0.0918 |     768 B |        3.43 |
| ValueStringBuilder  | ,H9J(...)A 20 [100]  | 126.77 ns | 0.703 ns | 0.658 ns | 126.45 ns |  2.55 |    0.01 | 0.0267 |     224 B |        1.00 |
|                     |                      |           |          |          |           |       |         |        |           |             |
| **Replace**             | **,U0Dy(...),d 10 [25]** |  **21.72 ns** | **0.250 ns** | **0.221 ns** |  **21.77 ns** |  **0.46** |    **0.00** | **0.0086** |      **72 B** |        **1.00** |
| StringCreateFor     | ,U0Dy(...),d 10 [25] |  17.76 ns | 0.175 ns | 0.163 ns |  17.80 ns |  0.38 |    0.00 | 0.0086 |      72 B |        1.00 |
| StringCreateReplace | ,U0Dy(...),d 10 [25] |  47.00 ns | 0.065 ns | 0.055 ns |  46.99 ns |  1.00 |    0.00 | 0.0086 |      72 B |        1.00 |
| Select              | ,U0Dy(...),d 10 [25] | 116.44 ns | 0.739 ns | 0.691 ns | 116.41 ns |  2.48 |    0.01 | 0.0286 |     240 B |        3.33 |
| ReplaceRegex        | ,U0Dy(...),d 10 [25] | 141.46 ns | 0.787 ns | 0.698 ns | 141.47 ns |  3.01 |    0.01 | 0.0086 |      72 B |        1.00 |
| SelectStringBuilder | ,U0Dy(...),d 10 [25] |  73.42 ns | 1.157 ns | 1.083 ns |  73.45 ns |  1.56 |    0.02 | 0.0334 |     280 B |        3.89 |
| ValueStringBuilder  | ,U0Dy(...),d 10 [25] |  42.55 ns | 0.250 ns | 0.234 ns |  42.65 ns |  0.91 |    0.00 | 0.0086 |      72 B |        1.00 |
|                     |                      |           |          |          |           |       |         |        |           |             |
| **Replace**             | **,xoL(...)s 25 [100]**  |  **45.76 ns** | **0.915 ns** | **0.811 ns** |  **46.01 ns** |  **0.92** |    **0.02** | **0.0535** |     **448 B** |        **2.00** |
| StringCreateFor     | ,xoL(...)s 25 [100]  |  64.09 ns | 0.723 ns | 0.641 ns |  64.25 ns |  1.29 |    0.01 | 0.0267 |     224 B |        1.00 |
| StringCreateReplace | ,xoL(...)s 25 [100]  |  49.61 ns | 0.106 ns | 0.094 ns |  49.62 ns |  1.00 |    0.00 | 0.0268 |     224 B |        1.00 |
| Select              | ,xoL(...)s 25 [100]  | 253.05 ns | 1.703 ns | 1.593 ns | 253.10 ns |  5.10 |    0.03 | 0.0639 |     536 B |        2.39 |
| ReplaceRegex        | ,xoL(...)s 25 [100]  | 199.31 ns | 0.881 ns | 0.781 ns | 199.23 ns |  4.02 |    0.02 | 0.0267 |     224 B |        1.00 |
| SelectStringBuilder | ,xoL(...)s 25 [100]  | 172.93 ns | 2.453 ns | 2.049 ns | 173.35 ns |  3.49 |    0.04 | 0.0918 |     768 B |        3.43 |
| ValueStringBuilder  | ,xoL(...)s 25 [100]  | 124.30 ns | 0.800 ns | 0.749 ns | 124.37 ns |  2.51 |    0.02 | 0.0267 |     224 B |        1.00 |

## Compile-time created test data
| Method              | text                 | Mean      | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------- |--------------------- |----------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| **Replace**             | **BlaBa(...) 25/1 [24]** |  **22.78 ns** | **0.255 ns** | **0.226 ns** |  **0.52** |    **0.01** | **0.0086** |      **72 B** |        **1.00** |
| StringCreateFor     | BlaBa(...) 25/1 [24] |  18.22 ns | 0.191 ns | 0.179 ns |  0.42 |    0.00 | 0.0086 |      72 B |        1.00 |
| StringCreateReplace | BlaBa(...) 25/1 [24] |  43.60 ns | 0.076 ns | 0.067 ns |  1.00 |    0.00 | 0.0086 |      72 B |        1.00 |
| StringNewSelect     | BlaBa(...) 25/1 [24] |  94.98 ns | 0.782 ns | 0.731 ns |  2.18 |    0.02 | 0.0277 |     232 B |        3.22 |
| ReplaceRegex        | BlaBa(...) 25/1 [24] |  82.15 ns | 0.157 ns | 0.139 ns |  1.88 |    0.00 | 0.0086 |      72 B |        1.00 |
| StringBuilder       | BlaBa(...) 25/1 [24] |  57.04 ns | 0.819 ns | 0.726 ns |  1.31 |    0.02 | 0.0334 |     280 B |        3.89 |
| ValueStringBuilder  | BlaBa(...) 25/1 [24] |  41.88 ns | 0.111 ns | 0.103 ns |  0.96 |    0.00 | 0.0086 |      72 B |        1.00 |
|                     |                      |           |          |          |       |         |        |           |             |
| **Replace**             | **BlaBa(...)100/2 [98]** |  **30.52 ns** | **0.085 ns** | **0.075 ns** |  **0.62** |    **0.00** | **0.0268** |     **224 B** |        **1.00** |
| StringCreateFor     | BlaBa(...)100/2 [98] |  54.88 ns | 0.497 ns | 0.388 ns |  1.11 |    0.01 | 0.0268 |     224 B |        1.00 |
| StringCreateReplace | BlaBa(...)100/2 [98] |  49.46 ns | 0.153 ns | 0.143 ns |  1.00 |    0.00 | 0.0268 |     224 B |        1.00 |
| StringNewSelect     | BlaBa(...)100/2 [98] | 255.51 ns | 2.688 ns | 2.245 ns |  5.17 |    0.05 | 0.0639 |     536 B |        2.39 |
| ReplaceRegex        | BlaBa(...)100/2 [98] | 119.00 ns | 0.213 ns | 0.199 ns |  2.41 |    0.01 | 0.0267 |     224 B |        1.00 |
| StringBuilder       | BlaBa(...)100/2 [98] | 161.69 ns | 1.089 ns | 1.018 ns |  3.27 |    0.02 | 0.0918 |     768 B |        3.43 |
| ValueStringBuilder  | BlaBa(...)100/2 [98] | 120.58 ns | 0.503 ns | 0.471 ns |  2.44 |    0.01 | 0.0267 |     224 B |        1.00 |
|                     |                      |           |          |          |       |         |        |           |             |
| **Replace**             | **BlaBa(...)100/3 [98]** |  **46.21 ns** | **0.976 ns** | **1.044 ns** |  **0.93** |    **0.02** | **0.0535** |     **448 B** |        **2.00** |
| StringCreateFor     | BlaBa(...)100/3 [98] |  81.93 ns | 0.650 ns | 0.577 ns |  1.65 |    0.01 | 0.0267 |     224 B |        1.00 |
| StringCreateReplace | BlaBa(...)100/3 [98] |  49.66 ns | 0.035 ns | 0.031 ns |  1.00 |    0.00 | 0.0268 |     224 B |        1.00 |
| StringNewSelect     | BlaBa(...)100/3 [98] | 262.44 ns | 2.162 ns | 1.917 ns |  5.29 |    0.04 | 0.0639 |     536 B |        2.39 |
| ReplaceRegex        | BlaBa(...)100/3 [98] | 144.50 ns | 0.593 ns | 0.525 ns |  2.91 |    0.01 | 0.0267 |     224 B |        1.00 |
| StringBuilder       | BlaBa(...)100/3 [98] | 159.54 ns | 2.185 ns | 2.044 ns |  3.21 |    0.04 | 0.0918 |     768 B |        3.43 |
| ValueStringBuilder  | BlaBa(...)100/3 [98] | 120.88 ns | 0.615 ns | 0.546 ns |  2.43 |    0.01 | 0.0267 |     224 B |        1.00 |
|                     |                      |           |          |          |       |         |        |           |             |
| **Replace**             | **BlaBa(...)100/4 [98]** |  **61.27 ns** | **1.249 ns** | **1.283 ns** |  **1.23** |    **0.03** | **0.0802** |     **672 B** |        **3.00** |
| StringCreateFor     | BlaBa(...)100/4 [98] |  85.94 ns | 0.762 ns | 0.713 ns |  1.73 |    0.01 | 0.0267 |     224 B |        1.00 |
| StringCreateReplace | BlaBa(...)100/4 [98] |  49.79 ns | 0.105 ns | 0.093 ns |  1.00 |    0.00 | 0.0268 |     224 B |        1.00 |
| StringNewSelect     | BlaBa(...)100/4 [98] | 299.24 ns | 2.827 ns | 2.361 ns |  6.01 |    0.05 | 0.0639 |     536 B |        2.39 |
| ReplaceRegex        | BlaBa(...)100/4 [98] | 178.00 ns | 0.640 ns | 0.534 ns |  3.58 |    0.01 | 0.0267 |     224 B |        1.00 |
| StringBuilder       | BlaBa(...)100/4 [98] | 182.83 ns | 2.497 ns | 2.213 ns |  3.67 |    0.04 | 0.0918 |     768 B |        3.43 |
| ValueStringBuilder  | BlaBa(...)100/4 [98] | 129.75 ns | 0.409 ns | 0.383 ns |  2.61 |    0.01 | 0.0267 |     224 B |        1.00 |
