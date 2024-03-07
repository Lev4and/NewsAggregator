using Elastic.Clients.Elasticsearch;
using NewsAggregator.Domain.Entities;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Searchers;

namespace NewsAggregator.News.Databases.Elasticsearch.News.Searchers
{
    public class NewsEditorSearcher : NewsDbElasticsearchSearcher<NewsEditor>, INewsEditorSearcher
    {
        public NewsEditorSearcher(ElasticsearchClient client) : base(client)
        {

        }

        public async Task<PagedResultModel<NewsEditor>> SearchByFiltersAsync(GetNewsEditorListFilters filters, 
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
