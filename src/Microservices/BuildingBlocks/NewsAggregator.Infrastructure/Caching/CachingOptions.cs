using NewsAggregator.Infrastructure.Caching.Redis;

namespace NewsAggregator.Infrastructure.Caching
{
    public class CachingOptions
    {
        public RedisOptions Redis { get; set; }
    }
}
