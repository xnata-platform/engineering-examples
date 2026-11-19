// 1. These two sets use different equality policies for the same data.
HashSet<string> defaultSet = ["Tea", "TEA", "tea"];
HashSet<string> catalogKeys =
[
    with(StringComparer.OrdinalIgnoreCase),
    "Tea", "TEA", "tea"
];

Console.WriteLine($"Default comparer count: {defaultSet.Count}");
Console.WriteLine($"Explicit comparer count: {catalogKeys.Count}");

// 2. Constructor arguments are part of the collection expression in C# 15.
List<string> reserved = [with(capacity: 8), .. catalogKeys];
Console.WriteLine($"Reserved list count: {reserved.Count}; capacity: {reserved.Capacity}");

// 3. Verify equality policy and the explicit capacity separately.
if (catalogKeys.Count != 1 || reserved.Capacity != 8)
{
    throw new InvalidOperationException("Unexpected collection construction.");
}
