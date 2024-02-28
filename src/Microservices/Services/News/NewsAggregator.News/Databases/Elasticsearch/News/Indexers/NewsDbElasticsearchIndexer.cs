using Elastic.Clients.Elasticsearch;
using NewsAggregator.Domain.Entities;
using NewsAggregator.Infrastructure.Databases.Elasticsearch.Indexers;

namespace NewsAggregator.News.Databases.Elasticsearch.News.Indexers
{
    public class NewsDbElasticsearchIndexer : ElasticsearchIndexer
    {
        public NewsDbElasticsearchIndexer(ElasticsearchClient client) : base(client)
        {

        }
    }

    public class NewsDbElasticsearchIndexer<TEntity> : ElasticsearchIndexer<TEntity>
        where TEntity : EntityBase
    {
        public NewsDbElasticsearchIndexer(ElasticsearchClient client) : base(client)
        {

        }
    }
}
