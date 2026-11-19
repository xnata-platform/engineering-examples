# A record copy changed the original basket.

Match copy depth to the mutable state owned by each record.

Requires the [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0). Run from the repository root.

```sh
git clone https://github.com/xnata-platform/engineering-examples.git
cd engineering-examples
dotnet run --project dotnet/record-shared-list/Demo.csproj
```

Expected output

```text
Original after shallow copy: tea, coffee
Original after list copy: tea, coffee
Independent: tea, coffee, cocoa
```

Follow the numbered comments in [Program.cs](Program.cs). Records and with-expressions predate .NET 10. The suggested list copy is sufficient for the sample’s string elements.

## Sources

- [Microsoft documentation 1](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record)
