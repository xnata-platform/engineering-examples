// 1. The same object is viewed through two compile-time types.
var concrete = new Order();
IOrder abstraction = concrete;
IOrderContract contract = concrete;
Console.WriteLine($"Concrete: {concrete.Label}");
Console.WriteLine($"Interface: {abstraction.Label}");
Console.WriteLine($"Contract: {contract.Label}");

// 2. Verify that the interface extension has not become virtual dispatch.
if (concrete.Label != "instance" || abstraction.Label != "extension" || contract.Label != "instance")
{
    throw new InvalidOperationException("Unexpected member binding.");
}

interface IOrder;

// 3. Put polymorphic behavior into the interface contract.
interface IOrderContract : IOrder
{
    string Label { get; }
}

sealed class Order : IOrderContract
{
    public string Label => "instance";
}

static class OrderExtensions
{
    // 4. C# 14 extension properties bind through the receiver's static type.
    extension(IOrder order)
    {
        public string Label => "extension";
    }
}
