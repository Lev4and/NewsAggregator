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
            return await _cache.GetAsync($"newssource:{id}", factory, cancellationToken);
        }

        public async Task<NewsSource> GetNewsSourceBySiteUrlAsync(string siteUrl, Func<Task<NewsSource>> factory, 
            CancellationToken cancellationToken = default)
        {
            return await _cache.GetAsync($"newssource:{siteUrl}", factory, cancellationToken);
        }

        public async Task<IReadOnlyCollection<NewsSource>> GetAvailableNewsSourcesAsync(
            Func<Task<IReadOnlyCollection<NewsSource>>> factory, CancellationToken cancellationToken = default)
        {
            return await _cache.GetAsync("availablenewssources", factory, cancellationToken);
        }

        public async Task RemoveNewsSourceByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await _cache.RemoveAsync($"newssource:{id}", cancellationToken);
        }

        public async Task RemoveNewsSourceBySiteUrlAsync(string siteUrl, CancellationToken cancellationToken = default)
        {
            await _cache.RemoveAsync($"newssource:{siteUrl}", cancellationToken);
        }

        public async Task RemoveAvailableNewsSourcesAsync(CancellationToken cancellationToken = default)
        {
            await _cache.RemoveAsync("availablenewssources", cancellationToken);
        }
    }
}
