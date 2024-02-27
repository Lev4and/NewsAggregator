using NewsAggregator.Domain.Searchers;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.Entities;

namespace NewsAggregator.News.Searchers
{
    public interface INewsEditorSearcher : ISearcher<NewsEditor>
    {
        Task<long> CountByFiltersAsync(GetNewsEditorListFilters filters,
            CancellationToken cancellationToken = default);

        Task<IReadOnlyCollection<NewsEditor>> SearchByFiltersAsync(GetNewsEditorListFilters filters,
            CancellationToken cancellationToken = default);
    }
}
