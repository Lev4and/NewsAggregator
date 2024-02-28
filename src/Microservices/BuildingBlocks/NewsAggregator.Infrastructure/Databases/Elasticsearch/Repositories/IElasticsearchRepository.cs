using NewsAggregator.Domain.Entities;
using NewsAggregator.Domain.Repositories;

namespace NewsAggregator.Infrastructure.Databases.Elasticsearch.Repositories
{
    public interface IElasticsearchRepository : IRepository, IGridRepository
    {

    }

    public interface IElasticsearchRepository<TEntity> : IRepository<TEntity>, IGridRepository<TEntity>
        where TEntity : EntityBase
    {

    }
}
