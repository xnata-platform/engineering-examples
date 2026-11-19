# The span changed. The list did not.

Keep structural list changes outside a borrowed span’s lifetime.

Requires the [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0). Run from the repository root.

```sh
git clone https://github.com/xnata-platform/engineering-examples.git
cd engineering-examples
dotnet run --project dotnet/list-span-reallocation/Demo.csproj
```

Expected output

```text
Old span: 99; list: 10
Fresh span: 42; list: 42
```

Follow the numbered comments in [Program.cs](Program.cs). AsSpan predates .NET 10. The exercise intentionally violates its no-add/remove usage rule to expose the consequence. It makes no performance claim.

## Sources

- [Microsoft documentation 1](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.collectionsmarshal.asspan?view=net-10.0)
