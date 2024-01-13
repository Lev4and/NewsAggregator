﻿using NewsAggregator.Domain.Infrastructure.Databases.Repositories;
using NewsAggregator.News.Databases.EntityFramework.News.Entities;

namespace NewsAggregator.News.Databases.EntityFramework.News.Repositories
{
    public interface INewsSourceRepository : IRepository<NewsSource>
    {
        Task<IReadOnlyCollection<NewsSource>> FindNewsSourcesAsync(CancellationToken cancellationToken = default);

        Task<IReadOnlyCollection<NewsSource>> FindNewsSourcesExtendedAsync(CancellationToken cancellationToken = default);

        Task<NewsSource?> FindNewsSourceByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<NewsSource?> FindNewsSourceBySiteUrlAsync(string siteUrl, CancellationToken cancellationToken = default);
    }
}