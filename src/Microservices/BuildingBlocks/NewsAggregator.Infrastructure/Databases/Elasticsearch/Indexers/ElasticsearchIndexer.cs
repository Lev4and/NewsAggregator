using Elastic.Clients.Elasticsearch;
using NewsAggregator.Domain.Entities;

namespace NewsAggregator.Infrastructure.Databases.Elasticsearch.Indexers
{
    public class ElasticsearchIndexer : IElasticsearchIndexer
    {
        protected readonly ElasticsearchClient _client;

        public ElasticsearchIndexer(ElasticsearchClient client)
        {
            _client = client;
        }

        public TEntity Index<TEntity>(TEntity entity) 
            where TEntity : EntityBase
        {
            _client.Index(entity);

            return entity;
        }

        public async Task<TEntity> IndexAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) 
            where TEntity : EntityBase
        {
            await _client.IndexAsync(entity, cancellationToken);

            return entity;
        }
    }

    public class ElasticsearchIndexer<TEntity> : IElasticsearchIndexer<TEntity>
        where TEntity : EntityBase
    {
        protected readonly ElasticsearchClient _client;

        public ElasticsearchIndexer(ElasticsearchClient client)
        {
            _client = client;
        }

        public TEntity Index(TEntity entity)
        {
            _client.Index(entity);

            return entity;
        }

        public async Task<TEntity> IndexAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _client.IndexAsync(entity, cancellationToken);

            return entity;
        }
    }
}
