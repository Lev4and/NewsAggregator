using NewsAggregator.Domain.Infrastructure.Caching;
using NewsAggregator.News.Entities;

namespace NewsAggregator.News.Caching
{
    public class NewsSourceMemoryCache : INewsSourceMemoryCache
    {
        private readonly IMemoryCache _cache;

        public NewsSourceMemoryCache(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task<IReadOnlyCollection<NewsSource>> GetNewsSourcesAsync(
            Func<Task<IReadOnlyCollection<NewsSource>>> factory, CancellationToken cancellationToken = default)
        {
            return await _cache.GetAsync("newssources", factory, cancellationToken);
        }

        public async Task<NewsSource> GetNewsSourceByIdAsync(Guid id, Func<Task<NewsSource>> factory,
            CancellationToken cancellationToken = default)
        {
            return await _cache.GetAsync($"newssources:{id}", factory, cancellationToken);
        }

        public async Task<NewsSource> GetNewsSourceBySiteUrlAsync(string siteUrl, Func<Task<NewsSource>> factory, 
            CancellationToken cancellationToken = default)
        {
            return await _cache.GetAsync($"newssources:{siteUrl}", factory, cancellationToken);
        }

        public async Task<IReadOnlyCollection<NewsSource>> GetAvailableNewsSourcesAsync(
            Func<Task<IReadOnlyCollection<NewsSource>>> factory, CancellationToken cancellationToken = default)
        {
            return await _cache.GetAsync("availablenewssources", factory, cancellationToken);
        }
    }
}
