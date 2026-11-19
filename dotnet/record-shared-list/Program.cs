// 1. A with-expression copies the record and retains the nested list reference.
var original = new Basket("original", ["tea"]);
var copy = original with { Name = "copy" };
copy.Items.Add("coffee");
Console.WriteLine($"Original after shallow copy: {string.Join(", ", original.Items)}");

// 2. For a list of immutable strings, copy the collection at the boundary.
var independent = original with { Name = "independent", Items = [.. original.Items] };
independent.Items.Add("cocoa");
Console.WriteLine($"Original after list copy: {string.Join(", ", original.Items)}");
Console.WriteLine($"Independent: {string.Join(", ", independent.Items)}");

// 3. If the elements themselves were mutable, copying the list would still share them.
if (ReferenceEquals(original.Items, independent.Items) || original.Items.Contains("cocoa"))
{
    throw new InvalidOperationException("Expected separate lists.");
}

record Basket(string Name, List<string> Items);
