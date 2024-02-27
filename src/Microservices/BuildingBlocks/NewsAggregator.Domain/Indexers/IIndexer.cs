using NewsAggregator.Domain.Entities;

namespace NewsAggregator.Domain.Indexers
{
    public interface IIndexer
    {
        TEntity Index<TEntity>(TEntity entity)
            where TEntity : EntityBase;

        Task<TEntity> IndexAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
            where TEntity : EntityBase;
    }

    public interface IIndexer<TEntity> where TEntity : EntityBase
    {
        TEntity Index(TEntity entity);

        Task<TEntity> IndexAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
