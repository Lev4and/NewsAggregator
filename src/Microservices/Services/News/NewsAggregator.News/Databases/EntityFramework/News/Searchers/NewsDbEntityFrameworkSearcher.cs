using NewsAggregator.Domain.Entities;
using NewsAggregator.Infrastructure.Databases.EntityFramework.Searchers;

namespace NewsAggregator.News.Databases.EntityFramework.News.Searchers
{
    public class NewsDbEntityFrameworkSearcher : EntityFrameworkSearcher<NewsDbContext>
    {
        public NewsDbEntityFrameworkSearcher(NewsDbContext dbContext) : base(dbContext)
        {

        }
    }

    public class NewsDbEntityFrameworkSearcher<TEntity> : EntityFrameworkSearcher<NewsDbContext, TEntity>
        where TEntity : EntityBase
    {
        public NewsDbEntityFrameworkSearcher(NewsDbContext dbContext) : base(dbContext)
        {

        }
    }
}
