using NewsAggregator.Domain.Entities;
using NewsAggregator.Infrastructure.Databases.EntityFramework.Repositories;

namespace NewsAggregator.News.Databases.EntityFramework.News.Repositories
{
    public class NewsDbRepository : EntityFrameworkRepository<NewsDbContext>
    {
        public NewsDbRepository(NewsDbContext dbContext) : base(dbContext)
        {

        }
    }

    public class NewsDbRepository<TEntity> : EntityFrameworkRepository<NewsDbContext, TEntity>
        where TEntity : EntityBase
    {
        public NewsDbRepository(NewsDbContext dbContext) : base(dbContext)
        {

        }
    }
}
