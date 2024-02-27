using Microsoft.EntityFrameworkCore;
using NewsAggregator.Domain.Entities;
using NewsAggregator.Domain.Infrastructure.Databases;

namespace NewsAggregator.Infrastructure.Databases.EntityFramework.Searchers
{
    public class EntityFrameworkSearcher<TDbContext> : IEntityFrameworkSearcher
        where TDbContext : DbContext, IUnitOfWork
    {
        protected readonly TDbContext _dbContext;

        public EntityFrameworkSearcher(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }

    public class EntityFrameworkSearcher<TDbContext, TEntity> : IEntityFrameworkSearcher<TEntity>
        where TDbContext : DbContext, IUnitOfWork where TEntity : EntityBase
    {
        protected readonly TDbContext _dbContext;

        public EntityFrameworkSearcher(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
