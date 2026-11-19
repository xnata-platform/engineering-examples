using System.Runtime.InteropServices;

// 1. Force the list to fill its current backing array.
var prices = new List<int>(capacity: 2) { 10, 20 };
Span<int> borrowed = CollectionsMarshal.AsSpan(prices);

// 2. Growing the list reallocates its array. The span keeps the old array.
prices.Add(30);
borrowed[0] = 99;
Console.WriteLine($"Old span: {borrowed[0]}; list: {prices[0]}");
if (prices[0] != 10)
{
    throw new InvalidOperationException("Expected the list to use its new backing array.");
}

// 3. Finish structural edits before borrowing a span for element updates.
Span<int> current = CollectionsMarshal.AsSpan(prices);
current[0] = 42;
Console.WriteLine($"Fresh span: {current[0]}; list: {prices[0]}");
