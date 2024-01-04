using NewsAggregator.Domain.Infrastructure.Databases.Transactions;

namespace NewsAggregator.Domain.Infrastructure.Databases
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        Task<IDatabaseTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
    }
}
