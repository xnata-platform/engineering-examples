// 1. Start the simulated save and hold it at a gate.
var allowSave = new TaskCompletionSource(
    TaskCreationOptions.RunContinuationsAsynchronously);
Task<int> save = SaveDraftAsync(allowSave.Task);

try
{
    // 2. Time out the caller's wait while the save is still pending.
    await save.WaitAsync(TimeSpan.Zero);
    throw new InvalidOperationException("Expected the wait to time out.");
}
catch (TimeoutException)
{
    // 3. Check that the original task is still pending.
    if (save.IsCompleted)
    {
        throw new InvalidOperationException("Save should still be pending.");
    }

    Console.WriteLine("Caller timed out. Save is still pending.");
}

// 4. Open the gate and await the same task to get the saved revision.
allowSave.SetResult();
int savedRevision = await save;
Console.WriteLine($"Original save completed. Revision: {savedRevision}");

static async Task<int> SaveDraftAsync(Task allowSave)
{
    await allowSave;
    return 42;
}
