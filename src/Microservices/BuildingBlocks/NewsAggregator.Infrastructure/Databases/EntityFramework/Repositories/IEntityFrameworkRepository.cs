using NewsAggregator.Domain.Entities;
using NewsAggregator.Domain.Repositories;

namespace NewsAggregator.Infrastructure.Databases.EntityFramework.Repositories
{
    public interface IEntityFrameworkRepository : IRepository, IGridRepository
    {

    }

    public interface IEntityFrameworkRepository<TEntity> : IRepository<TEntity>, IGridRepository<TEntity>
        where TEntity : EntityBase
    {

    }
}
