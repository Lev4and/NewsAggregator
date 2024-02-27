using NewsAggregator.Domain.Searchers;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.Entities;

namespace NewsAggregator.News.Searchers
{
    public interface INewsSourceSearcher : ISearcher<NewsSource>
    {
        Task<long> CountByFiltersAsync(GetNewsSourceListFilters filters,
            CancellationToken cancellationToken = default);

        Task<IReadOnlyCollection<NewsSource>> SearchByFiltersAsync(GetNewsSourceListFilters filters,
            CancellationToken cancellationToken = default);
    }
}
