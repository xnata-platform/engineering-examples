using System.Text.Json;

// 1. Nullability checks reject explicit null, but a missing argument is separate.
var nullableOnly = new JsonSerializerOptions { RespectNullableAnnotations = true };
var incomplete = JsonSerializer.Deserialize<Customer>("{}", nullableOnly)!;
Console.WriteLine($"Missing Name accepted: {incomplete.Name is null}");

// 2. Require presence and enforce nullability for this constructor contract.
var strict = new JsonSerializerOptions
{
    RespectNullableAnnotations = true,
    RespectRequiredConstructorParameters = true
};

// 3. Exercise omission, explicit null, and a valid customer.
foreach (string json in new[] { "{}", """{"Name":null}""", """{"Name":"Ada"}""" })
{
    try
    {
        var customer = JsonSerializer.Deserialize<Customer>(json, strict)!;
        Console.WriteLine($"Accepted: {customer.Name}");
    }
    catch (JsonException)
    {
        Console.WriteLine($"Rejected: {json}");
    }
}

record Customer(string Name);
