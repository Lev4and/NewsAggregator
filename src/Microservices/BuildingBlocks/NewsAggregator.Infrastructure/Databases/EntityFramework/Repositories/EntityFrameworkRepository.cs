using Microsoft.EntityFrameworkCore;
using NewsAggregator.Domain.Entities;
using NewsAggregator.Domain.Infrastructure.Databases;
using NewsAggregator.Domain.Repositories;
using NewsAggregator.Domain.Specification;
using System.Linq.Expressions;

namespace NewsAggregator.Infrastructure.Databases.EntityFramework.Repositories
{
    public abstract class EntityFrameworkRepository<TDbContext> : IRepository, IGridRepository
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

        public async ValueTask<long> CountAsync<TEntity>(IGridSpecification<TEntity> specification, 
            CancellationToken cancellationToken = default) where TEntity : EntityBase
        {
            var query = _dbContext.Set<TEntity>().AsNoTracking();

            if (specification.Includes is not null && specification.Includes.Count() > 0)
            {
                foreach (var include in specification.Includes)
                {
                    query = query.Include(include);
                }
            }

            if (specification.Criterias is not null && specification.Criterias.Count() > 0)
            {
                var expression = specification.Criterias.First();

                for (var i = 1; i <  specification.Criterias.Count(); i++)
                {
                    
                }

                query = query.Where(expression);
            }

            if (specification.GroupBy is not null)
            {
                query = query.GroupBy(specification.GroupBy).SelectMany(selector => selector);
            }

            return await query.CountAsync(cancellationToken);
        }

        public async Task<IReadOnlyCollection<TEntity>> FindAsync<TEntity>(IGridSpecification<TEntity> specification, 
            CancellationToken cancellationToken = default) where TEntity : EntityBase
        {
            var query = _dbContext.Set<TEntity>().AsNoTracking();

            if (specification.Includes is not null && specification.Includes.Count() > 0)
            {
                foreach (var include in specification.Includes)
                {
                    query = query.Include(include);
                }
            }

            if (specification.Criterias is not null && specification.Criterias.Count() > 0)
            {
                var expression = specification.Criterias.First();

                for (var i = 1; i < specification.Criterias.Count(); i++)
                {
                    //TODO
                }

                query = query.Where(expression);
            }

            if (specification.GroupBy is not null)
            {
                query = query.GroupBy(specification.GroupBy).SelectMany(selector => selector);
            }

            if (specification.OrderBy is not null)
            {
                query = query.OrderBy(specification.OrderBy);
            }

            if (specification.OrderByDescending is not null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }

            if (specification.IsPagingEnabled)
            {
                query = query.Skip(specification.Skip).Take(specification.Take);
            }

            return await query.ToListAsync(cancellationToken);
        }
    }

    public abstract class EntityFrameworkRepository<TDbContext, TEntity> : IRepository<TEntity>, IGridRepository<TEntity>
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

        public async ValueTask<long> CountAsync(IGridSpecification<TEntity> specification, 
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<TEntity>> FindAsync(IGridSpecification<TEntity> specification, 
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
