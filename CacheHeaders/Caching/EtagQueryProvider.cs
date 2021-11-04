using CacheCow.Server;
using CacheHeaders.Controllers;
using CacheHeaders.Models;

namespace CacheHeaders.Caching;


public class EtagQueryProvider : ITimedETagQueryProvider<Result>
{
    // Retrieves an etag using the incoming request
    // call a database, check a cache, etc...
    public Task<TimedEntityTagHeaderValue> QueryAsync(HttpContext context)
    {
        var etag = HelloController.Result.LastModified.ToEtag();
        return Task.FromResult(new TimedEntityTagHeaderValue(etag));
    }

    public void Dispose()
    {
    }
}