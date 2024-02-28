using Elastic.Clients.Elasticsearch;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.Searchers;

namespace NewsAggregator.News.Databases.Elasticsearch.News.Searchers
{
    public class NewsSearcher : NewsDbElasticsearchSearcher<Entities.News>, INewsSearcher
    {
        public NewsSearcher(ElasticsearchClient client) : base(client)
        {

        }

        public Task<long> CountByFiltersAsync(GetNewsListFilters filters, 
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<Entities.News>> SearchByFiltersAsync(GetNewsListFilters filters, 
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
