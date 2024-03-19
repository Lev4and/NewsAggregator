using Microsoft.AspNetCore.Mvc;
using NewsAggregator.Domain.Entities;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Enums;

namespace NewsAggregator.News.DTOs
{
    public class GetNewsListDto
    {
        public GetNewsListFilters Filters { get; }

        public PagedResultModel<Entities.News> Result { get; }

        public IReadOnlyCollection<long> PageSizes { get; } = new List<long>() { 10, 25, 50, 75, 100 };

        public IReadOnlyCollection<NewsTag> NewsTags { get; }

        public IReadOnlyCollection<NewsSource> NewsSources { get; }

        public IReadOnlyDictionary<NewsSortingOption, string> SortingOptions = 
            new Dictionary<NewsSortingOption, string>()
            {
                { NewsSortingOption.Default, "Default" },
                { NewsSortingOption.ByOld, "By ascending published at" },
                { NewsSortingOption.ByRecently, "By descending published at" },
                { NewsSortingOption.ByAscendingTitle, "By ascending title" },
                { NewsSortingOption.ByDescendingTitle, "By descending title" },
                { NewsSortingOption.ByAscendingNewsEditorName, "By ascending news editor name" },
                { NewsSortingOption.ByAscendingNewsSourceTitle, "By ascending news source title" },
                { NewsSortingOption.ByDescendingNewsEditorName, "By descending news editor name" },
                { NewsSortingOption.ByDescendingNewsSourceTitle, "By descending news source title" }
            };

        public GetNewsListDto(GetNewsListFilters filters, PagedResultModel<Entities.News> result,
            IReadOnlyCollection<NewsTag> newsTags, IReadOnlyCollection<NewsSource> newsSources)
        {
            Filters = filters;
            Result = result;
            NewsTags = newsTags;
            NewsSources = newsSources;
        }
    }

    public class GetNewsListFilters
    {
        public bool? HasPublishedAt { get; set; } = null;

        public bool? HasModifiedAt { get; set; } = null;

        public bool? HasSubTitle { get; set; } = null;

        public bool? HasPicture { get; set; } = null;

        public bool? HasVideo { get; set; } = null;

        public long Page { get; set; } = 1;

        public long PageSize { get; set; } = 25;

        public string SearchString { get; set; } = string.Empty;

        public NewsSortingOption SortBy { get; set; } = NewsSortingOption.ByRecently;

        public DateTime? StartPublishedAt { get; set; } = null;

        public DateTime? EndPublishedAt { get; set; } = null;

        public Guid[]? NewsTagsIds { get; set; } = null;

        public Guid[]? NewsEditorsIds { get; set; } = null;

        public Guid[]? NewsSourcesIds { get; set; } = null;
    }
}
