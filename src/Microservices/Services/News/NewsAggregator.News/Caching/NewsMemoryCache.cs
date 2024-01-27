using NewsAggregator.Domain.Infrastructure.Caching;

namespace NewsAggregator.News.Caching
{
    public class NewsMemoryCache : INewsMemoryCache
    {
        private readonly IMemoryCache _cache;

        public NewsMemoryCache(IMemoryCache cache)
        {
            _cache = cache;
        }
    }
}
