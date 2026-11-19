// 1. Two views of one object can select different synchronization mechanisms.
var gate = new System.Threading.Lock();
// Suppress this one diagnostic to execute the intentionally incorrect example.
#pragma warning disable CS9216
object alias = gate;
#pragma warning restore CS9216
bool monitorEntered = false;

// 2. Hold the new Lock on this thread while another thread acquires its monitor.
lock (gate)
{
    var worker = new Thread(() =>
    {
        lock (alias)
        {
            monitorEntered = true;
        }
    }) { IsBackground = true };
    worker.Start();
    if (!worker.Join(TimeSpan.FromSeconds(5)))
    {
        throw new InvalidOperationException("Expected the separate monitor to remain available.");
    }
}

// 3. Preserve the Lock type across helpers, or use EnterScope consistently.
Console.WriteLine($"Monitor entered while Lock was held: {monitorEntered}");
using (gate.EnterScope())
{
    Console.WriteLine("Consistent Lock scope acquired.");
}
