var approvedAt = new DateTimeOffset(2026, 1, 1, 12, 0, 0, TimeSpan.Zero);
var resumeAt = approvedAt.AddMinutes(10);

// 1. Capture the exact quote the customer approved before the agent paused.
var original = new Quote("Q-50", 50m, "EUR", approvedAt.AddMinutes(5));
var approvedQuote = original with { };

// 2. On resume, the original quote has expired and cannot be booked.
bool bookedExpired = TryBook(approvedQuote, original, resumeAt);

// 3. The replacement is valid, but the previous approval covers different terms.
var replacement = new Quote("Q-65", 65m, "EUR", resumeAt.AddMinutes(5));
bool bookedWithoutNewApproval = TryBook(approvedQuote, replacement, resumeAt);

// 4. Once the customer accepts the replacement, the booking can proceed.
var newApproval = replacement with { };
bool bookedAfterNewApproval = TryBook(newApproval, replacement, resumeAt.AddMinutes(1));

if (bookedExpired || bookedWithoutNewApproval || !bookedAfterNewApproval)
{
    throw new InvalidOperationException("Expected only the newly approved booking to succeed.");
}

static bool TryBook(Quote approved, Quote current, DateTimeOffset now)
{
    if (now >= current.ExpiresAt)
    {
        Console.WriteLine($"Blocked {current.Id}. The quote expired.");
        return false;
    }

    // 5. Compare the immutable snapshots by value, including their quoted terms.
    if (approved != current)
    {
        Console.WriteLine($"Blocked {current.Id}. The replacement needs a new approval.");
        return false;
    }

    Console.WriteLine($"Booked {current.Id} for {current.Currency} {current.Amount:0}.");
    return true;
}

record Quote(string Id, decimal Amount, string Currency, DateTimeOffset ExpiresAt);
