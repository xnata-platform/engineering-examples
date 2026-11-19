# Non-nullable Name. Missing JSON still gets through.

Specify required presence and nullability independently for a constructor-based JSON contract.

Requires the [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0). Run from the repository root.

```sh
git clone https://github.com/xnata-platform/engineering-examples.git
cd engineering-examples
dotnet run --project dotnet/json-constructor-contract/Demo.csproj
```

Expected output

```text
Missing Name accepted: True
Rejected: {}
Rejected: {"Name":null}
Accepted: Ada
```

Follow the numbered comments in [Program.cs](Program.cs). Both serializer options predate .NET 10. This is a boundary-design exercise verified on .NET 10.

## Sources

- [Microsoft documentation 1](https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/nullable-annotations)
- [Microsoft documentation 2](https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/required-properties)
