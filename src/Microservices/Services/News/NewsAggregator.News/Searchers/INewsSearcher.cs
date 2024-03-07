using NewsAggregator.Domain.Entities;
using NewsAggregator.Domain.Searchers;
using NewsAggregator.News.DTOs;

namespace NewsAggregator.News.Searchers
{
    public interface INewsSearcher : ISearcher<Entities.News>
    {
        Task<PagedResultModel<Entities.News>> SearchByFiltersAsync(GetNewsListFilters filters,
            CancellationToken cancellationToken = default);
    }
}
