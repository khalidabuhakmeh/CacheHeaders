using CacheCow.Server.Core.Mvc;
using CacheHeaders.Caching;
using CacheHeaders.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// necessary for caching
builder.Services.AddHttpCachingMvc();
builder.Services.AddQueryProviderAndExtractorForViewModelMvc<Result, EtagQueryProvider, EtagExtractor>();

var app = builder.Build();
app.MapControllers();
app.Run();