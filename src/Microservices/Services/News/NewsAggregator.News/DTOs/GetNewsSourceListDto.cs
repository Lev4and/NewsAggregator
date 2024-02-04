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

        public IReadOnlyDictionary<NewsSourceSortingOption, string> SortingOptions = 
            new Dictionary<NewsSourceSortingOption, string>()
            {
                { NewsSourceSortingOption.Default, "Default" },
                { NewsSourceSortingOption.ByAscendingTitle, "By ascending title" },
                { NewsSourceSortingOption.ByDescendingTitle, "By descending title" }
            };

        public GetNewsSourceListDto(GetNewsSourceListFilters filters, PagedResultModel<NewsSource> result)
        {
            Filters = filters;
            Result = result;
        }
    }

    public class GetNewsSourceListFilters
    {
        public bool IsEnabledRequired { get; set; } = false;

        public long Page { get; set; } = 1;

        public long PageSize { get; set; } = 100;

        public string SearchString { get; set; } = string.Empty;

        public NewsSourceSortingOption SortBy { get; set; } = NewsSourceSortingOption.ByAscendingTitle;
    }
}
