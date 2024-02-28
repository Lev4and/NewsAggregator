using NewsAggregator.Domain.Entities;
using NewsAggregator.Domain.Searchers;

namespace NewsAggregator.Infrastructure.Databases.Elasticsearch.Searchers
{
    public interface IElasticsearchSearcher : ISearcher
    {

    }

    public interface IElasticsearchSearcher<TEntity> : ISearcher<TEntity>
        where TEntity : EntityBase
    {

    }
}
