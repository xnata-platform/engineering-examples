# One lock object. Two threads can enter.

Preserve the synchronization primitive and its static type across helper boundaries.

Requires the [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0). Run from the repository root.

```sh
git clone https://github.com/xnata-platform/engineering-examples.git
cd engineering-examples
dotnet run --project dotnet/lock-static-type/Demo.csproj
```

Expected output

```text
Monitor entered while Lock was held: True
Consistent Lock scope acquired.
```

Follow the numbered comments in [Program.cs](Program.cs). System.Threading.Lock arrived before .NET 10. The card omits the pragma and bounded Join handling, both present in the full deliberately incorrect demonstration.

## Sources

- [Microsoft documentation 1](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/lock)
