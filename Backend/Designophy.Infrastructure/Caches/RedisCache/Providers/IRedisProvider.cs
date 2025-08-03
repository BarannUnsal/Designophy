using StackExchange.Redis;

namespace Designophy.Infrastructure.Caches.RedisCache.Providers
{
    public interface IRedisProvider
    {
        IDatabase GetDatabase(int db = 0);
    }
}
