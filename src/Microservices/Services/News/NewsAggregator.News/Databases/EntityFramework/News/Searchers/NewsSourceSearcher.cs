using NewsAggregator.Infrastructure.Databases.EntityFramework.Searchers;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Searchers;

namespace NewsAggregator.News.Databases.EntityFramework.News.Searchers
{
    public class NewsSourceSearcher : NewsDbEntityFrameworkSearcher<NewsSource>, INewsSourceSearcher
    {
        public NewsSourceSearcher(NewsDbContext dbContext) : base(dbContext)
        {

        }

        public Task<long> CountByFiltersAsync(GetNewsSourceListFilters filters, 
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<NewsSource>> SearchByFiltersAsync(GetNewsSourceListFilters filters, 
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
