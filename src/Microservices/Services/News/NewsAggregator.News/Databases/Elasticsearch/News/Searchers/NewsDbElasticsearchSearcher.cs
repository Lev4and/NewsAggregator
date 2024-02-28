using Elastic.Clients.Elasticsearch;
using NewsAggregator.Domain.Entities;
using NewsAggregator.Infrastructure.Databases.Elasticsearch.Searchers;

namespace NewsAggregator.News.Databases.Elasticsearch.News.Searchers
{
    public class NewsDbElasticsearchSearcher : ElasticsearchSearcher
    {
        public NewsDbElasticsearchSearcher(ElasticsearchClient client) : base(client)
        {

        }
    }

    public class NewsDbElasticsearchSearcher<TEntity> : ElasticsearchSearcher<TEntity>
        where TEntity : EntityBase
    {
        public NewsDbElasticsearchSearcher(ElasticsearchClient client) : base(client)
        {

        }
    }
}
