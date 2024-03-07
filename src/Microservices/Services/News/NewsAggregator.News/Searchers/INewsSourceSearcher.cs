using NewsAggregator.Domain.Entities;
using NewsAggregator.Domain.Searchers;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.Entities;

namespace NewsAggregator.News.Searchers
{
    public interface INewsSourceSearcher : ISearcher<NewsSource>
    {
        Task<PagedResultModel<NewsSource>> SearchByFiltersAsync(GetNewsSourceListFilters filters,
            CancellationToken cancellationToken = default);
    }
}
