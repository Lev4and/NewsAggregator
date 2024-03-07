using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.QueryDsl;
using NewsAggregator.Domain.Entities;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.Searchers;

namespace NewsAggregator.News.Databases.Elasticsearch.News.Searchers
{
    public class NewsSearcher : NewsDbElasticsearchSearcher<Entities.News>, INewsSearcher
    {
        public NewsSearcher(ElasticsearchClient client) : base(client)
        {

        }

        public async Task<PagedResultModel<Entities.News>> SearchByFiltersAsync(GetNewsListFilters filters,
                    CancellationToken cancellationToken = default)
        {
            var searchDescriptor = new SearchRequestDescriptor<Entities.News>();

            searchDescriptor = searchDescriptor.SourceExcludes($"*description*");

            var query = new QueryDescriptor<Entities.News>();

            if (filters.HasPublishedAt is not null)
            {
                query = query.Exists(descriptor => descriptor
                    .Field(news => news.PublishedAt));
            }

            if (filters.HasModifiedAt is not null)
            {
                query = query.Exists(descriptor => descriptor
                    .Field(news => news.ModifiedAt));
            }

            if (filters.HasSubTitle is not null)
            {
                query = query.Exists(descriptor => descriptor
                    .Field(news => news.SubTitle));
            }

            if (filters.HasPicture is not null)
            {
                query = query.Exists(descriptor => descriptor
                    .Field(news => news.Picture));
            }

            if (filters.HasVideo is not null)
            {
                query = query.Exists(descriptor => descriptor
                    .Field(news => news.Video));
            }

            if (!string.IsNullOrEmpty(filters.SearchString))
            {
                query = query.QueryString(queryStringDescriptor => queryStringDescriptor
                    .Query(filters.SearchString)
                    .Fields("*"));
            }

            if (filters.StartPublishedAt is not null && filters.EndPublishedAt is not null)
            {
                var startPublishedAt = TimeZoneInfo.ConvertTime(filters.StartPublishedAt.Value, 
                    TimeZoneInfo.Utc, TimeZoneInfo.Utc);

                var endPublishedAt = TimeZoneInfo.ConvertTime(filters.EndPublishedAt.Value, 
                    TimeZoneInfo.Utc, TimeZoneInfo.Utc);

                query = query.Range(descriptor => descriptor
                    .DateRange(dateRangeDescriptor => dateRangeDescriptor
                        .Field(news => news.PublishedAt)
                        .Gte(startPublishedAt)
                        .Lte(endPublishedAt)));
            }
            else if (filters.StartPublishedAt is not null)
            {
                var startPublishedAt = TimeZoneInfo.ConvertTime(filters.StartPublishedAt.Value,
                    TimeZoneInfo.Utc, TimeZoneInfo.Utc);

                query = query.Range(descriptor => descriptor
                    .DateRange(dateRangeDescriptor => dateRangeDescriptor
                        .Field(news => news.PublishedAt)
                        .Gte(startPublishedAt)));
            }
            else if (filters.EndPublishedAt is not null)
            {
                var endPublishedAt = TimeZoneInfo.ConvertTime(filters.EndPublishedAt.Value,
                    TimeZoneInfo.Utc, TimeZoneInfo.Utc);

                query = query.Range(descriptor => descriptor
                    .DateRange(dateRangeDescriptor => dateRangeDescriptor
                        .Field(news => news.PublishedAt)
                        .Lte(endPublishedAt)));
            }

            if (filters.NewsEditorsIds is not null && filters.NewsEditorsIds?.Length > 0)
            {
                var values = filters.NewsEditorsIds.Select(id => (FieldValue)id.ToString()).ToList();

                query = query.Terms(termsQuery => termsQuery
                    .Field(news => news.EditorId).Terms(
                        new TermsQueryField(values)));
            }

            if (filters.NewsSourcesIds is not null && filters.NewsSourcesIds?.Length > 0)
            {
                var values = filters.NewsSourcesIds.Select(id => (FieldValue)id.ToString()).ToList();

                query = query.Terms(termsQuery => termsQuery
                    .Field(news => news.EditorId).Terms(
                        new TermsQueryField(values)));
            }

            searchDescriptor = searchDescriptor.Query(queryDescriptor => queryDescriptor
                .Bool(boolDescriptor => boolDescriptor.Filter(query)));

            searchDescriptor = searchDescriptor.Sort(sortDescriptor =>
                sortDescriptor.Field(news => news.PublishedAt, new FieldSort() { Order = SortOrder.Desc }));

            searchDescriptor = searchDescriptor
                .From((int)filters.Page * (int)filters.PageSize - (int)filters.PageSize)
                .Size((int)filters.PageSize);

            var response = await _client.SearchAsync(searchDescriptor, cancellationToken);

            return new PagedResultModel<Entities.News>(response.Documents, filters.Page, 
                filters.PageSize, response.Total);
        }
    }
}
