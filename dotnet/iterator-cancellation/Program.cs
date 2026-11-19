using System.Runtime.CompilerServices;

// 1. Cancel between two MoveNextAsync calls without timing or sleeps.
using var cts = new CancellationTokenSource();
try
{
    await foreach (int value in ReadAsync().WithCancellation(cts.Token))
    {
        Console.WriteLine($"Received: {value}");
        cts.Cancel();
    }
    throw new InvalidOperationException("Expected enumeration to observe cancellation.");
}
catch (OperationCanceledException) when (cts.IsCancellationRequested)
{
    Console.WriteLine("Next move observed cancellation.");
}

// 2. Route the consumer's enumeration token into this parameter.
static async IAsyncEnumerable<int> ReadAsync(
    [EnumeratorCancellation] CancellationToken ct = default)
{
    for (int i = 1; i <= 2; i++)
    {
        // 3. The iterator still cooperates by checking or forwarding the token.
        ct.ThrowIfCancellationRequested();
        await Task.Yield();
        yield return i;
    }
}
