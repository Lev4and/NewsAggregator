using Elastic.Clients.Elasticsearch;
using NewsAggregator.Domain.Entities;
using NewsAggregator.Infrastructure.Databases.Elasticsearch.Repositories;

namespace NewsAggregator.News.Databases.Elasticsearch.News.Repositories
{
    public class NewsDbElasticsearchRepository : ElasticsearchRepository
    {
        public NewsDbElasticsearchRepository(ElasticsearchClient client) : base(client)
        {

        }
    }

    public class NewsDbElasticsearchRepository<TEntity> : ElasticsearchRepository<TEntity>
        where TEntity : EntityBase
    {
        public NewsDbElasticsearchRepository(ElasticsearchClient client) : base(client)
        {

        }
    }
}
