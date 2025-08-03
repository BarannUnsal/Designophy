using StackExchange.Redis;

namespace Designophy.Infrastructure.Caches.RedisCache.Providers
{
    public class RedisProvider : IRedisProvider
    {
        private readonly IConnectionMultiplexer _multiplexer;

        public RedisProvider(IConnectionMultiplexer multiplexer)
        {
            _multiplexer = multiplexer;
        }

        public IDatabase GetDatabase(int db = 0)
        {
            return _multiplexer.GetDatabase(db);
        }
    }
}
