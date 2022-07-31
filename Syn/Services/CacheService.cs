using Microsoft.Extensions.Caching.Memory;

namespace Syn.Services;

public class CacheService : ICacheService
{
    private readonly IMemoryCache _memoryCache;

    public CacheService(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public T GetOrCreate<T>(string key, Func<T> factory)
        => _memoryCache.GetOrCreate(key, c =>
        {
            c.SetAbsoluteExpiration(TimeSpan.FromMinutes(30));
            c.SetSlidingExpiration(TimeSpan.FromMinutes(5));
            return factory();
        });

    public void Remove(string key) => _memoryCache.Remove(key);
}
