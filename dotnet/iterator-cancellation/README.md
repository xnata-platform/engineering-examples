# WithCancellation needs a path into the iterator.

Wire the enumeration token into the iterator and observe it in the body.

Requires the [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0). Run from the repository root.

```sh
git clone https://github.com/xnata-platform/engineering-examples.git
cd engineering-examples
dotnet run --project dotnet/iterator-cancellation/Demo.csproj
```

Expected output

```text
Received: 1
Next move observed cancellation.
```

Follow the numbered comments in [Program.cs](Program.cs). Async iterators and EnumeratorCancellation predate .NET 10. The card contains the corrected producer. The consumer and exception handling are in the linked demo.

## Sources

- [Microsoft documentation 1](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.enumeratorcancellationattribute?view=net-10.0)
