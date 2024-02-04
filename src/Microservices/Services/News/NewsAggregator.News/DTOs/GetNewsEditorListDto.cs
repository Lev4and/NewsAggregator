using NewsAggregator.Domain.Entities;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Enums;

namespace NewsAggregator.News.DTOs
{
    public class GetNewsEditorListDto
    {
        public GetNewsEditorListFilters Filters { get; }

        public PagedResultModel<NewsEditor> Result { get; }

        public IReadOnlyCollection<long> PageSizes { get; } = new List<long>() { 10, 25, 50, 75, 100 };

        public IReadOnlyCollection<NewsSource> NewsSources { get; }

        public IReadOnlyDictionary<NewsEditorSortingOption, string> SortingOptions = 
            new Dictionary<NewsEditorSortingOption, string>()
            {
                { NewsEditorSortingOption.Default, "Default" },
                { NewsEditorSortingOption.ByAscendingName, "By ascending name" },
                { NewsEditorSortingOption.ByDescendingName, "By descending name" },
                { NewsEditorSortingOption.ByAscendingNewsSourceTitle, "By ascending news source title" },
                { NewsEditorSortingOption.ByDescendingNewsSourceTitle, "By descending news source title" }
            };

        public GetNewsEditorListDto(GetNewsEditorListFilters filters, PagedResultModel<NewsEditor> result,
            IReadOnlyCollection<NewsSource> newsSources)
        {
            Filters = filters;
            Result = result;
            NewsSources = newsSources;
        }
    }

    public class GetNewsEditorListFilters
    {
        public long Page { get; set; } = 1;

        public long PageSize { get; set; } = 100;

        public string SearchString { get; set; } = string.Empty;

        public NewsEditorSortingOption SortBy { get; set; } = NewsEditorSortingOption.ByAscendingName;

        public Guid[]? NewsSourcesIds { get; set; } = null;
    }
}
