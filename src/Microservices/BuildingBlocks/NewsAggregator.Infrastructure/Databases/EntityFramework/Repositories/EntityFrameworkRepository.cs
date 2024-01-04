using Microsoft.EntityFrameworkCore;
using NewsAggregator.Domain.Entities;
using NewsAggregator.Domain.Infrastructure.Databases;
using NewsAggregator.Domain.Infrastructure.Databases.Repositories;
using System.Linq.Expressions;

namespace NewsAggregator.Infrastructure.Databases.EntityFramework.Repositories
{
    public abstract class EntityFrameworkRepository<TDbContext> : IRepository
        where TDbContext : DbContext, IUnitOfWork
    {
        protected readonly TDbContext _dbContext;

        public EntityFrameworkRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TEntity Add<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            return _dbContext.Set<TEntity>().Add(entity).Entity;
        }

        public async Task<TEntity?> FindOneByIdAsync<TEntity>(Guid id, CancellationToken cancellationToken = default)
            where TEntity : EntityBase
        {
            return await _dbContext.Set<TEntity>().AsNoTracking()
                .SingleOrDefaultAsync(item => item.Id == id, cancellationToken);
        }

        public async Task<TEntity?> FindOneByExpressionAsync<TEntity>(Expression<Func<TEntity, bool>> expression,
            CancellationToken cancellationToken = default) where TEntity : EntityBase
        {
            return await _dbContext.Set<TEntity>().AsNoTracking()
                .SingleOrDefaultAsync(expression, cancellationToken);
        }

        public async Task<TEntity> FindOneByExpressionOrAddAsync<TEntity>(TEntity entity,
            Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
                where TEntity : EntityBase
        {
            return await FindOneByExpressionAsync(expression, cancellationToken)
                ?? Add(entity);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            _dbContext.Set<TEntity>().Update(entity);
        }

        public void Remove<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }
    }

    public abstract class EntityFrameworkRepository<TDbContext, TEntity> : IRepository<TEntity>
        where TDbContext : DbContext, IUnitOfWork where TEntity : EntityBase
    {
        protected readonly TDbContext _dbContext;

        public EntityFrameworkRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TEntity Add(TEntity entity)
        {
            return _dbContext.Set<TEntity>().Add(entity).Entity;
        }

        public async Task<TEntity?> FindOneByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<TEntity>().AsNoTracking()
                .SingleOrDefaultAsync(item => item.Id == id, cancellationToken);
        }

        public async Task<TEntity?> FindOneByExpressionAsync(Expression<Func<TEntity, bool>> expression,
            CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<TEntity>().AsNoTracking()
                .SingleOrDefaultAsync(expression, cancellationToken);
        }

        public async Task<TEntity> FindOneByExpressionOrAddAsync(TEntity entity,
            Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await FindOneByExpressionAsync(expression, cancellationToken)
                ?? Add(entity);
        }

        public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }

        public void Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }
    }
}
