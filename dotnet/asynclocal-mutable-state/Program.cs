// 1. A child flow receives the same mutable object reference.
var mutable = new AsyncLocal<RequestState>();
mutable.Value = new RequestState { Tenant = "A" };
await Task.Run(() => mutable.Value!.Tenant = "B");
Console.WriteLine($"Parent after mutation: {mutable.Value.Tenant}");

// 2. Use an immutable value and replace the child's ambient binding.
var immutable = new AsyncLocal<RequestContext>();
immutable.Value = new RequestContext("A");
await Task.Run(() => immutable.Value = immutable.Value! with { Tenant = "B" });
Console.WriteLine($"Parent after replacement: {immutable.Value.Tenant}");

// 3. Assert both outcomes after the child has finished.
if (mutable.Value.Tenant != "B" || immutable.Value.Tenant != "A")
{
    throw new InvalidOperationException("Unexpected ambient context behavior.");
}

sealed class RequestState
{
    public required string Tenant { get; set; }
}

record RequestContext(string Tenant);
