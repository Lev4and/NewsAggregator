using NewsAggregator.Domain.Entities;
using NewsAggregator.Domain.Indexers;

namespace NewsAggregator.Infrastructure.Databases.Fake.Indexers
{
    public class FakeIndexer : IIndexer
    {
        public TEntity Index<TEntity>(TEntity entity) 
            where TEntity : EntityBase
        {
            return entity;
        }

        public Task<TEntity> IndexAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) 
            where TEntity : EntityBase
        {
            return Task.FromResult(entity);
        }
    }

    public class FakeIndexer<TEntity> : IIndexer<TEntity>
        where TEntity : EntityBase
    {
        public TEntity Index(TEntity entity)
        {
            return entity;
        }

        public Task<TEntity> IndexAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(entity);
        }
    }
}
