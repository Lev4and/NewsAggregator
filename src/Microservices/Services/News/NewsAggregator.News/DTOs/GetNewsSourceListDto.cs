using NewsAggregator.Domain.Entities;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Enums;

namespace NewsAggregator.News.DTOs
{
    public class GetNewsSourceListDto
    {
        public GetNewsSourceListFilters Filters { get; }

        public PagedResultModel<NewsSource> Result { get; }

        public IReadOnlyCollection<long> PageSizes { get; } = new List<long>() { 10, 25, 50, 75, 100 };

        public IReadOnlyCollection<NewsTag> NewsTags { get; }

        public IReadOnlyDictionary<NewsSourceSortingOption, string> SortingOptions = 
            new Dictionary<NewsSourceSortingOption, string>()
            {
                { NewsSourceSortingOption.Default, "Default" },
                { NewsSourceSortingOption.ByAscendingTitle, "By ascending title" },
                { NewsSourceSortingOption.ByDescendingTitle, "By descending title" }
            };

        public GetNewsSourceListDto(GetNewsSourceListFilters filters, PagedResultModel<NewsSource> result, 
            IReadOnlyCollection<NewsTag> newsTags)
        {
            Filters = filters;
            Result = result;
            NewsTags = newsTags;
        }
    }

    public class GetNewsSourceListFilters
    {
        public bool? IsSystem { get; set; } = null;

        public bool? IsEnabled { get; set; } = null;

        public bool? SupportedParseSubTitle { get; set; } = null;

        public bool? SupportedParsePublishedAt { get; set; } = null;

        public bool? SupportedParseModifiedAt { get; set; } = null;

        public bool? SupportedParseEditor { get; set; } = null;

        public bool? SupportedParsePicture { get; set; } = null;

        public bool? SupportedParseVideo { get; set; } = null;

        public long Page { get; set; } = 1;

        public long PageSize { get; set; } = 100;

        public string SearchString { get; set; } = string.Empty;

        public Guid[]? NewsTagsIds { get; set; } = null;

        public NewsSourceSortingOption SortBy { get; set; } = NewsSourceSortingOption.ByAscendingTitle;
    }
}
