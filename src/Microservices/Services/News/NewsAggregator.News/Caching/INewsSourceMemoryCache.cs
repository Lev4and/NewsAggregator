using NewsAggregator.News.Entities;

namespace NewsAggregator.News.Caching
{
    public interface INewsSourceMemoryCache
    {
        Task<IReadOnlyCollection<NewsSource>> GetNewsSourcesAsync(Func<Task<IReadOnlyCollection<NewsSource>>> factory,
            CancellationToken cancellationToken = default);

        Task<NewsSource> GetNewsSourceByIdAsync(Guid id, Func<Task<NewsSource>> factory,
            CancellationToken cancellationToken = default);

        Task<NewsSource> GetNewsSourceBySiteUrlAsync(string siteUrl, Func<Task<NewsSource>> factory,
            CancellationToken cancellationToken = default);

        Task<IReadOnlyCollection<NewsSource>> GetAvailableNewsSourcesAsync(Func<Task<IReadOnlyCollection<NewsSource>>> factory, 
            CancellationToken cancellationToken = default);

        Task ClearAsync(CancellationToken cancellationToken = default);
    }
}
