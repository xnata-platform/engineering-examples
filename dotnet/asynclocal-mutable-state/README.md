# The child task changed the parent’s tenant.

Use immutable ambient values and replace bindings when entering a child context.

Requires the [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0). Run from the repository root.

```sh
git clone https://github.com/xnata-platform/engineering-examples.git
cd engineering-examples
dotnet run --project dotnet/asynclocal-mutable-state/Demo.csproj
```

Expected output

```text
Parent after mutation: B
Parent after replacement: A
```

Follow the numbered comments in [Program.cs](Program.cs). AsyncLocal predates .NET 10. This demonstrates reference sharing in a local sample and makes no claim about a production tenant incident.

## Sources

- [Microsoft documentation 1](https://learn.microsoft.com/en-us/dotnet/api/system.threading.asynclocal-1?view=net-10.0)
