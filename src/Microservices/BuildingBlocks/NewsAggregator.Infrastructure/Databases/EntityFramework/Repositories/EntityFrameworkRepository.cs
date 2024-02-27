using Microsoft.EntityFrameworkCore;
using NewsAggregator.Domain.Entities;
using NewsAggregator.Domain.Extensions;
using NewsAggregator.Domain.Infrastructure.Databases;
using NewsAggregator.Domain.Specification;
using System.Linq.Expressions;

namespace NewsAggregator.Infrastructure.Databases.EntityFramework.Repositories
{
    public abstract class EntityFrameworkRepository<TDbContext> : IEntityFrameworkRepository
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

        public async Task<TEntity> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) 
            where TEntity : EntityBase
        {
            return (await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken)).Entity;
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

        public async Task UpdateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) 
            where TEntity : EntityBase
        {
            _dbContext.Set<TEntity>().Update(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public void Remove<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public async Task RemoveAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) 
            where TEntity : EntityBase
        {
            _dbContext.Set<TEntity>().Remove(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);
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
                var criteria = specification.Criterias.First();

                for (var i = 1; i < specification.Criterias.Count; i++)
                {
                    criteria = criteria.And(specification.Criterias.ElementAt(i));
                }

                query = query.Where(criteria);
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
                var criteria = specification.Criterias.First();

                for (var i = 1; i < specification.Criterias.Count; i++)
                {
                    criteria = criteria.And(specification.Criterias.ElementAt(i));
                }

                query = query.Where(criteria);
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
                query = query.Skip(Convert.ToInt32(specification.Skip))
                    .Take(Convert.ToInt32(specification.Take));
            }

            return await query.ToListAsync(cancellationToken);
        }
    }

    public abstract class EntityFrameworkRepository<TDbContext, TEntity> : IEntityFrameworkRepository<TEntity>
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

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return (await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken)).Entity;
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

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<TEntity>().Update(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public void Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public async Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<TEntity>().Remove(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async ValueTask<long> CountAsync(IGridSpecification<TEntity> specification, 
            CancellationToken cancellationToken = default)
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
                var criteria = specification.Criterias.First();

                for (var i = 1; i < specification.Criterias.Count; i++)
                {
                    criteria = criteria.And(specification.Criterias.ElementAt(i));
                }

                query = query.Where(criteria);
            }

            if (specification.GroupBy is not null)
            {
                query = query.GroupBy(specification.GroupBy).SelectMany(selector => selector);
            }

            return await query.CountAsync(cancellationToken);
        }

        public async Task<IReadOnlyCollection<TEntity>> FindAsync(IGridSpecification<TEntity> specification, 
            CancellationToken cancellationToken = default)
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
                var criteria = specification.Criterias.First();

                for (var i = 1; i < specification.Criterias.Count; i++)
                {
                    criteria = criteria.And(specification.Criterias.ElementAt(i));
                }

                query = query.Where(criteria);
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
                query = query.Skip(Convert.ToInt32(specification.Skip))
                    .Take(Convert.ToInt32(specification.Take));
            }

            return await query.ToListAsync(cancellationToken);
        }
    }
}
