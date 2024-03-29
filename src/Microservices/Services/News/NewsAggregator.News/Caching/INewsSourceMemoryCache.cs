﻿using NewsAggregator.News.Entities;

namespace NewsAggregator.News.Caching
{
    public interface INewsSourceMemoryCache
    {
        Task<IReadOnlyCollection<NewsSource>> GetNewsSourcesAsync(Func<Task<IReadOnlyCollection<NewsSource>>> factory,
            CancellationToken cancellationToken = default);

        Task<NewsSource> GetNewsSourceByIdAsync(Guid id, Func<Task<NewsSource>> factory,
            CancellationToken cancellationToken = default);

        Task<NewsSource?> GetNewsSourceByDomainAsync(string domain,
            CancellationToken cancellationToken = default);

        Task<NewsSource> GetNewsSourceByDomainAsync(string domain, Func<Task<NewsSource>> factory,
            CancellationToken cancellationToken = default);

        Task<NewsSource?> GetNewsSourceBySiteUrlAsync(string siteUrl,
            CancellationToken cancellationToken = default);

        Task<NewsSource> GetNewsSourceBySiteUrlAsync(string siteUrl, Func<Task<NewsSource>> factory,
            CancellationToken cancellationToken = default);

        Task<IReadOnlyCollection<NewsSource>> GetAvailableNewsSourcesAsync(CancellationToken cancellationToken = default);

        Task<IReadOnlyCollection<NewsSource>> GetAvailableNewsSourcesAsync(Func<Task<IReadOnlyCollection<NewsSource>>> factory, 
            CancellationToken cancellationToken = default);

        Task RemoveNewsSourceByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task RemoveNewsSourceByDomainAsync(string domain, CancellationToken cancellationToken = default);

        Task RemoveNewsSourceBySiteUrlAsync(string siteUrl, CancellationToken cancellationToken = default);

        Task RemoveAvailableNewsSourcesAsync(CancellationToken cancellationToken = default);
    }
}
