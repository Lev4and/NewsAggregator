using NewsAggregator.Domain.Infrastructure.Databases.Transactions;
using System.Transactions;

namespace NewsAggregator.Infrastructure.Databases.EntityFramework.Transactions
{
    public class EntityFrameworkRepeatableReadDatabaseTransaction : IDatabaseTransaction
    {
        private readonly TransactionScope _transaction;

        public EntityFrameworkRepeatableReadDatabaseTransaction()
        {
            _transaction = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions() { IsolationLevel = IsolationLevel.RepeatableRead },
                    TransactionScopeAsyncFlowOption.Enabled);
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            _transaction.Complete();

            await Task.CompletedTask;
        }

        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }
    }
}
