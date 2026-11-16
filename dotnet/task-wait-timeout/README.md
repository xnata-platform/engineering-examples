# The timed-out save

Requires the [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0). Clone the repository and run the project from its root.

```sh
git clone https://github.com/xnata-platform/engineering-examples.git
cd engineering-examples
dotnet run --project dotnet/task-wait-timeout/LateCompletion.csproj
```

Expected output:

```text
Caller timed out. Save is still pending.
Original save completed. Revision: 42
```

Follow the numbered comments in [Program.cs](Program.cs).

1. Start the simulated save and hold it at a gate.
2. Call `WaitAsync(TimeSpan.Zero)` while the save is pending. The zero timeout makes the result reproducible without sleeps.
3. Catch `TimeoutException` from the wait and check that the original task is still pending.
4. Open the gate and await the original task, which returns revision `42`.

The demo uses an in-memory stand-in for a save and has no external services or packages.
