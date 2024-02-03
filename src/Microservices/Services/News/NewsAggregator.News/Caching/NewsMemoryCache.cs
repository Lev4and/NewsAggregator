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

        public async Task<Entities.News> GetNewsByIdAsync(Guid id, Func<Task<Entities.News>> factory, 
            CancellationToken cancellationToken = default)
        {
            return await _cache.GetAsync($"news:{id}", factory, cancellationToken);
        }
    }
}
