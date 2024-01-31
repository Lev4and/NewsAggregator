using NewsAggregator.Domain.Entities;
using NewsAggregator.Domain.Specification;

namespace NewsAggregator.Domain.Repositories
{
    public interface IGridRepository
    {
        ValueTask<long> CountAsync<TEntity>(IGridSpecification<TEntity> specification, 
            CancellationToken cancellationToken = default) where TEntity : EntityBase;

        Task<IReadOnlyCollection<TEntity>> FindAsync<TEntity>(IGridSpecification<TEntity> specification, 
            CancellationToken cancellationToken = default) where TEntity : EntityBase;
    }

    public interface IGridRepository<TEntity> where TEntity : EntityBase
    {
        ValueTask<long> CountAsync(IGridSpecification<TEntity> specification,
            CancellationToken cancellationToken = default);

        Task<IReadOnlyCollection<TEntity>> FindAsync(IGridSpecification<TEntity> specification,
            CancellationToken cancellationToken = default);
    }
}
