using NewsAggregator.News.DTOs;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Searchers;

namespace NewsAggregator.News.Databases.EntityFramework.News.Searchers
{
    public class NewsEditorSearcher : NewsDbEntityFrameworkSearcher<NewsEditor>, INewsEditorSearcher
    {
        public NewsEditorSearcher(NewsDbContext dbContext) : base(dbContext)
        {

        }

        public Task<long> CountByFiltersAsync(GetNewsEditorListFilters filters, 
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<NewsEditor>> SearchByFiltersAsync(GetNewsEditorListFilters filters, 
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
