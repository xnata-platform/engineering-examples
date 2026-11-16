# Shipping quote approval

A customer approves a EUR 50 quote. Their agent resumes after it expires and finds a EUR 65 replacement. The demo checks that the booking waits for the customer to accept the replacement.

Requires the [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0). Run from the repository root.

```sh
git clone https://github.com/xnata-platform/engineering-examples.git
cd engineering-examples
dotnet run --project dotnet/shipping-quote-approval/ShippingQuoteApproval.csproj
```

Expected output

```text
Blocked Q-50. The quote expired.
Blocked Q-65. The replacement needs a new approval.
Booked Q-65 for EUR 65.
```

Follow the numbered comments in [Program.cs](Program.cs). The timestamps are fixed so the demo runs immediately. The quotes and booking are simulated in memory. The example illustrates a proposed approval rule and runs without carrier or XNata services.
