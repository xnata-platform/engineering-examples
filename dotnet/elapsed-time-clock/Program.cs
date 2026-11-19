// 1. Capture wall-clock time and a monotonic timestamp.
var clock = new ControlledClock();
DateTimeOffset startedAt = clock.GetUtcNow();
long startedTick = clock.GetTimestamp();

// 2. Thirty seconds pass, then the UTC clock is corrected backwards.
clock.Advance(TimeSpan.FromSeconds(30));
clock.ShiftUtc(TimeSpan.FromMinutes(-5));

TimeSpan wall = clock.GetUtcNow() - startedAt;
TimeSpan elapsed = clock.GetElapsedTime(startedTick);
Console.WriteLine($"UTC difference in seconds: {wall.TotalSeconds:0}");
Console.WriteLine($"Timestamp elapsed seconds: {elapsed.TotalSeconds:0}");

// 3. Measure an in-process interval using timestamps.
if (wall.TotalSeconds != -270 || elapsed.TotalSeconds != 30)
{
    throw new InvalidOperationException("Unexpected elapsed-time calculation.");
}

sealed class ControlledClock : TimeProvider
{
    private DateTimeOffset utc = new(2026, 1, 1, 0, 0, 0, TimeSpan.Zero);
    private long ticks;
    public override long TimestampFrequency => TimeSpan.TicksPerSecond;
    public override DateTimeOffset GetUtcNow() => utc;
    public override long GetTimestamp() => ticks;

    public void Advance(TimeSpan elapsed)
    {
        ticks += elapsed.Ticks;
        utc += elapsed;
    }

    public void ShiftUtc(TimeSpan adjustment) => utc += adjustment;
}
