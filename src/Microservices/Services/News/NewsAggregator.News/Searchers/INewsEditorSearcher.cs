using NewsAggregator.Domain.Entities;
using NewsAggregator.Domain.Searchers;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.Entities;

namespace NewsAggregator.News.Searchers
{
    public interface INewsEditorSearcher : ISearcher<NewsEditor>
    {
        Task<PagedResultModel<NewsEditor>> SearchByFiltersAsync(GetNewsEditorListFilters filters,
            CancellationToken cancellationToken = default);
    }
}
