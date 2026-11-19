# The operation took minus 270 seconds.

Choose UTC instants for shared dates and monotonic timestamps for local elapsed intervals.

Requires the [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0). Run from the repository root.

```sh
git clone https://github.com/xnata-platform/engineering-examples.git
cd engineering-examples
dotnet run --project dotnet/elapsed-time-clock/Demo.csproj
```

Expected output

```text
UTC difference in seconds: -270
Timestamp elapsed seconds: 30
```

Follow the numbered comments in [Program.cs](Program.cs). TimeProvider predates .NET 10. ControlledClock is an explicitly synthetic test double defined in the linked program. It uses no real sleep.

## Sources

- [Microsoft documentation 1](https://learn.microsoft.com/en-us/dotnet/standard/datetime/timeprovider-overview)
