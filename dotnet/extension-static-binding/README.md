# The same object returns two different labels.

Use interface members for behavior that belongs to a polymorphic contract.

Requires the [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0). Run from the repository root.

```sh
git clone https://github.com/xnata-platform/engineering-examples.git
cd engineering-examples
dotnet run --project dotnet/extension-static-binding/Demo.csproj
```

Expected output

```text
Concrete: instance
Interface: extension
Contract: instance
```

Follow the numbered comments in [Program.cs](Program.cs). Extension properties and extension blocks are new in C# 14, shipped with .NET 10. Instance declarations are in the full sample and described above the card.

## Sources

- [Microsoft documentation 1](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods)
