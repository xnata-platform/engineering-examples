# Storefront page cache version

A storefront template changes while the URL, sort order, and visitor context stay the same. The demo warms two cache entries and compares what happens after the edit.

Requires the [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0). Run from the repository root.

```sh
git clone https://github.com/xnata-platform/engineering-examples.git
cd engineering-examples
dotnet run --project dotnet/storefront-cache-version/StorefrontCacheVersion.csproj
```

Expected output

```text
Before edit: both keys hit the cache.
Request-only key: hit, <h1>Tea</h1>
Theme-version key: miss, <h1>Fresh tea</h1>
Repeat with new version: hit, <h1>Fresh tea</h1>
```

Follow the numbered comments in [Program.cs](Program.cs). This standalone model uses an in-memory cache and an integer theme version. A new version changes which entry the request reads. The old entry still needs an expiry or eviction policy.
