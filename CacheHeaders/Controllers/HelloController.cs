using CacheCow.Server.Core.Mvc;
using CacheHeaders.Models;
using Microsoft.AspNetCore.Mvc;

namespace CacheHeaders.Controllers;

public class HelloController : Controller
{
    public static Result Result
        = new("world", DateTimeOffset.Now);

    [HttpGet, Route("/")]
    // necessary to generate the etag
    [HttpCacheFactory(300, ViewModelType = typeof(Result))]
    public ActionResult<Result> Index()
    {
        return Ok(Result);
    }

    [HttpPut, Route("/")]
    [HttpCacheFactory(0, ViewModelType = typeof(Result))]
    public ActionResult<Result> Put()
    {
        return Ok(Result = Result with {
            LastModified = DateTimeOffset.Now
        });
    }
}