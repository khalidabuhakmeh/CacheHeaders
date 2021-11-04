using CacheCow.Server;
using CacheHeaders.Controllers;
using CacheHeaders.Models;

namespace CacheHeaders.Caching;

/// <summary>
/// Generates the etag using the current model
/// or in other words -- extracts from the model.
/// </summary>
public class EtagExtractor : ITimedETagExtractor<Result>
{
    public TimedEntityTagHeaderValue Extract(Result? viewModel)
    {
        return viewModel is null 
            ? null! 
            : new TimedEntityTagHeaderValue(viewModel.LastModified.ToEtag());
    }

    public TimedEntityTagHeaderValue Extract(object viewModel)
    {
        return Extract(viewModel as Result);
    }
}