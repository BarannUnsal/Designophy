using Microsoft.Extensions.Caching.Memory;

namespace Designophy.Infrastructure.Caches.LocalCache.Providers
{
    public interface ILocalCacheProvider
    {
        IMemoryCache GetCache();
    }
}
