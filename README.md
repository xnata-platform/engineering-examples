# XNata Engineering Examples

Small runnable examples from [XNata engineering posts](https://www.linkedin.com/company/xnata/).

| Example | Runtime | What it demonstrates |
| --- | --- | --- |
| [The timed-out save](dotnet/task-wait-timeout/) | .NET 10 | A caller's wait can time out while the original task is still running. |
| [Shipping quote approval](dotnet/shipping-quote-approval/) | .NET 10 | An expired quote and an unapproved replacement both stop a booking. |
| [Storefront page cache version](dotnet/storefront-cache-version/) | .NET 10 | A theme edit can change the cache key while the storefront request stays identical. |
| [Non-nullable Name. Missing JSON still gets through.](dotnet/json-constructor-contract/) | .NET 10 | Specify required presence and nullability independently for a constructor-based JSON contract. |
| [The span changed. The list did not.](dotnet/list-span-reallocation/) | .NET 10 | Keep structural list changes outside a borrowed span’s lifetime. |
| [The child task changed the parent’s tenant.](dotnet/asynclocal-mutable-state/) | .NET 10 | Use immutable ambient values and replace bindings when entering a child context. |
| [A record copy changed the original basket.](dotnet/record-shared-list/) | .NET 10 | Match copy depth to the mutable state owned by each record. |
| [One lock object. Two threads can enter.](dotnet/lock-static-type/) | .NET 10 | Preserve the synchronization primitive and its static type across helper boundaries. |
| [WithCancellation needs a path into the iterator.](dotnet/iterator-cancellation/) | .NET 10 | Wire the enumeration token into the iterator and observe it in the body. |
| [The same object returns two different labels.](dotnet/extension-static-binding/) | .NET 10 | Use interface members for behavior that belongs to a polymorphic contract. |
| [The operation took minus 270 seconds.](dotnet/elapsed-time-clock/) | .NET 10 | Choose UTC instants for shared dates and monotonic timestamps for local elapsed intervals. |
| [Three spellings. How many HashSet entries?](dotnet/collection-expression-comparer/) | .NET 11 | Preserve comparer semantics when adopting collection expression arguments. |
| [A new result case should reach every switch.](dotnet/union-result-cases/) | .NET 11 | Keep explicit result-case handling where a new outcome needs a deliberate decision. |
