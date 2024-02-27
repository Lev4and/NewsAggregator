using NewsAggregator.Domain.Searchers;
using NewsAggregator.News.DTOs;

namespace NewsAggregator.News.Searchers
{
    public interface INewsSearcher : ISearcher<Entities.News>
    {
        Task<long> CountByFiltersAsync(GetNewsListFilters filters,
            CancellationToken cancellationToken = default);

        Task<IReadOnlyCollection<Entities.News>> SearchByFiltersAsync(GetNewsListFilters filters,
            CancellationToken cancellationToken = default);
    }
}
