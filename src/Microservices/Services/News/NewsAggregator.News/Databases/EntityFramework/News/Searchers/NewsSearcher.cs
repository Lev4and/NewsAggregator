using NewsAggregator.News.DTOs;
using NewsAggregator.News.Searchers;

namespace NewsAggregator.News.Databases.EntityFramework.News.Searchers
{
    public class NewsSearcher : NewsDbEntityFrameworkSearcher<Entities.News>, INewsSearcher
    {
        public NewsSearcher(NewsDbContext dbContext) : base(dbContext)
        {

        }

        public Task<long> CountByFiltersAsync(GetNewsListFilters filters, 
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<Entities.News>> SearchByFiltersAsync(GetNewsListFilters filters, 
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
