using Microsoft.Extensions.Caching.Memory;

namespace Designophy.Infrastructure.Caches.LocalCache.Providers
{
    public class LocalCacheProvider : ILocalCacheProvider
    {
        private readonly IMemoryCache _memoryCache;

        public LocalCacheProvider(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public IMemoryCache GetCache() => _memoryCache;
    }
}
