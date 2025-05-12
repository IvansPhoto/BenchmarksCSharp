BenchmarkDotNet v0.14.0, Fedora Linux 42 (KDE Plasma Desktop Edition)
AMD Ryzen 7 6800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.105
[Host]     : .NET 9.0.4 (9.0.425.16305), X64 RyuJIT AVX2
DefaultJob : .NET 9.0.4 (9.0.425.16305), X64 RyuJIT AVX2


| Method  | text                 | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------- |--------------------- |----------:|---------:|---------:|-------:|----------:|
| Replace | BlaBa(...) 25/1 [24] |  28.42 ns | 0.381 ns | 0.338 ns | 0.0124 |     104 B |
| Select  | BlaBa(...) 25/1 [24] | 104.99 ns | 0.762 ns | 0.636 ns | 0.0315 |     264 B |
| Replace | BlaBa(...)100/2 [98] |  39.86 ns | 0.675 ns | 0.598 ns | 0.0306 |     256 B |
| Select  | BlaBa(...)100/2 [98] | 268.88 ns | 4.084 ns | 3.620 ns | 0.0677 |     568 B |
| Replace | BlaBa(...)100/3 [98] |  56.44 ns | 1.104 ns | 1.134 ns | 0.0573 |     480 B |
| Select  | BlaBa(...)100/3 [98] | 270.73 ns | 3.055 ns | 2.708 ns | 0.0677 |     568 B |
| Replace | BlaBa(...)100/4 [98] |  63.66 ns | 0.236 ns | 0.209 ns | 0.0842 |     704 B |
| Select  | BlaBa(...)100/4 [98] | 287.03 ns | 4.127 ns | 3.861 ns | 0.0677 |     568 B |