using Microsoft.AspNetCore.Mvc;
using NewsAggregator.Domain.Entities;
using NewsAggregator.News.Entities;

namespace NewsAggregator.News.DTOs
{
    public class GetNewsListDto
    {
        public GetNewsListFilters Filters { get; }

        public PagedResultModel<Entities.News> Result { get; }

        public IReadOnlyCollection<long> PageSizes { get; } = new List<long>() { 10, 25, 50, 75, 100 };

        public IReadOnlyCollection<NewsEditor> NewsEditors { get; }

        public IReadOnlyCollection<NewsSource> NewsSources { get; }

        public GetNewsListDto(GetNewsListFilters filters, PagedResultModel<Entities.News> result,
            IReadOnlyCollection<NewsEditor> newsEditors, IReadOnlyCollection<NewsSource> newsSources)
        {
            Filters = filters;
            Result = result;
            NewsEditors = newsEditors;
            NewsSources = newsSources;
        }
    }

    public class GetNewsListFilters
    {
        public long Page { get; set; } = 1;

        public long PageSize { get; set; } = 100;

        public string SearchString { get; set; } = string.Empty;

        public DateTime? StartPublishedAt { get; set; } = null;

        public DateTime? EndPublishedAt { get; set; } = null;

        public Guid[]? NewsEditorsIds { get; set; } = null;

        public Guid[]? NewsSourcesIds { get; set; } = null;
    }
}
