# Three spellings. How many HashSet entries?

Preserve comparer semantics when adopting collection expression arguments.

Requires the [.NET 11 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/11.0). Run from the repository root.

```sh
git clone https://github.com/xnata-platform/engineering-examples.git
cd engineering-examples
dotnet run --project dotnet/collection-expression-comparer/Demo.csproj
```

Expected output

```text
Default comparer count: 3
Explicit comparer count: 1
Reserved list count: 1; capacity: 8
```

Follow the numbered comments in [Program.cs](Program.cs). Collection expression arguments are a C# 15/.NET 11 feature. The program targets net11.0 with the default stable language version.

## Sources

- [Microsoft documentation 1](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/collection-expressions)
