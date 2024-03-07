using Elastic.Clients.Elasticsearch;
using NewsAggregator.Domain.Entities;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Searchers;

namespace NewsAggregator.News.Databases.Elasticsearch.News.Searchers
{
    public class NewsSourceSearcher : NewsDbElasticsearchSearcher<NewsSource>, INewsSourceSearcher
    {
        public NewsSourceSearcher(ElasticsearchClient client) : base(client)
        {

        }

        public Task<PagedResultModel<NewsSource>> SearchByFiltersAsync(GetNewsSourceListFilters filters, 
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
