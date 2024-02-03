using NewsAggregator.Domain.Infrastructure.Caching;
using NewsAggregator.News.Entities;

namespace NewsAggregator.News.Caching
{
    public class NewsEditorMemoryCache : INewsEditorMemoryCache
    {
        private readonly IMemoryCache _cache;

        public NewsEditorMemoryCache(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task<NewsEditor> GetNewsEditorByIdAsync(Guid id, Func<Task<NewsEditor>> factory, 
            CancellationToken cancellationToken = default)
        {
            return await _cache.GetAsync($"newseditor:{id}", factory, cancellationToken);
        }
    }
}
