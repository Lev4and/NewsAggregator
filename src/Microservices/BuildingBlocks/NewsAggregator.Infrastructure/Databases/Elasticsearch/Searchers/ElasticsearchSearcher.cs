using Elastic.Clients.Elasticsearch;
using NewsAggregator.Domain.Entities;

namespace NewsAggregator.Infrastructure.Databases.Elasticsearch.Searchers
{
    public class ElasticsearchSearcher : IElasticsearchSearcher
    {
        protected readonly ElasticsearchClient _client;

        public ElasticsearchSearcher(ElasticsearchClient client)
        {
            _client = client;
        }
    }

    public class ElasticsearchSearcher<TEntity> : IElasticsearchSearcher<TEntity>
        where TEntity : EntityBase
    {
        protected readonly ElasticsearchClient _client;

        public ElasticsearchSearcher(ElasticsearchClient client)
        {
            _client = client;
        }
    }
}
