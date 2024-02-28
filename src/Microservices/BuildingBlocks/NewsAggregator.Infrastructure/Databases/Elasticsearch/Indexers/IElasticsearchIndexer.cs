using NewsAggregator.Domain.Entities;
using NewsAggregator.Domain.Indexers;

namespace NewsAggregator.Infrastructure.Databases.Elasticsearch.Indexers
{
    public interface IElasticsearchIndexer : IIndexer
    {

    }

    public interface IElasticsearchIndexer<TEntity> : IIndexer<TEntity>
        where TEntity : EntityBase
    {

    }
}
