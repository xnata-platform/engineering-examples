# A new result case should reach every switch.

Keep explicit result-case handling where a new outcome needs a deliberate decision.

Requires the [.NET 11 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/11.0). Run from the repository root.

```sh
git clone https://github.com/xnata-platform/engineering-examples.git
cd engineering-examples
dotnet run --project dotnet/union-result-cases/Demo.csproj
```

Expected output

```text
Available units: 5
Ask before promising a delivery date.
```

Follow the numbered comments in [Program.cs](Program.cs). Union types are a C# 15/.NET 11 feature. The sample models local stock outcomes and makes no claim about distributed compatibility.

## Sources

- [Microsoft documentation 1](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-15)
