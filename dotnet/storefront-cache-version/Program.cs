var cache = new Dictionary<CacheKey, string>();
var request = new StorefrontRequest("/collections/tea?sort=price", "en");
int themeVersion = 1;
string heading = "Tea";

// 1. Fill both cache entries and verify that the repeat requests hit them.
var requestKey = new CacheKey(request, ThemeVersion: null);
var versionedKey = new CacheKey(request, themeVersion);
_ = ReadPage(cache, requestKey, heading);
_ = ReadPage(cache, versionedKey, heading);

var warmRequest = ReadPage(cache, requestKey, heading);
var warmVersioned = ReadPage(cache, versionedKey, heading);
if (!warmRequest.Hit || !warmVersioned.Hit)
{
    throw new InvalidOperationException("Expected both cache entries to be warm before the edit.");
}

Console.WriteLine("Before edit: both keys hit the cache.");

// 2. Edit the template and advance its version. Keep the request unchanged.
heading = "Fresh tea";
themeVersion++;

// 3. The request-only key hits stale HTML. The versioned key misses and renders fresh HTML.
var stale = ReadPage(cache, requestKey, heading);
var updatedKey = new CacheKey(request, themeVersion);
var fresh = ReadPage(cache, updatedKey, heading);

// 4. A repeat request at the new version should hit the freshly populated entry.
var repeat = ReadPage(cache, updatedKey, heading);
const string expectedHtml = "<h1>Fresh tea</h1>";
if (stale != warmRequest || fresh != (false, expectedHtml) || repeat != (true, expectedHtml))
{
    throw new InvalidOperationException("Unexpected storefront cache behavior after the edit.");
}

Console.WriteLine($"Request-only key: hit, {stale.Html}");
Console.WriteLine($"Theme-version key: miss, {fresh.Html}");
Console.WriteLine($"Repeat with new version: hit, {repeat.Html}");

static (bool Hit, string Html) ReadPage(
    Dictionary<CacheKey, string> cache,
    CacheKey key,
    string heading)
{
    if (cache.TryGetValue(key, out var cachedHtml))
    {
        return (true, cachedHtml);
    }

    string renderedHtml = $"<h1>{heading}</h1>";
    cache[key] = renderedHtml;
    return (false, renderedHtml);
}

record StorefrontRequest(string Url, string Variant);
record CacheKey(StorefrontRequest Request, int? ThemeVersion);
