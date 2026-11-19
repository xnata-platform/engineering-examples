// 1. Name the outcomes of a local stock check.
StockResult available = new InStock(5);
StockResult unavailable = new OutOfStock();
Console.WriteLine(Describe(available));
Console.WriteLine(Describe(unavailable));

// 2. Handle each union case explicitly in a switch expression.
static string Describe(StockResult result) => result switch
{
    InStock(var units) => $"Available units: {units}",
    OutOfStock => "Ask before promising a delivery date."
};

// 3. Add a new case to StockResult to explore exhaustiveness diagnostics.
public record InStock(int Units);
public record OutOfStock;
public union StockResult(InStock, OutOfStock);
