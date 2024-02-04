using NewsAggregator.Domain.Enums;
using NewsAggregator.News.Entities;
using System.Linq.Expressions;

namespace NewsAggregator.News.Enums
{
    public enum NewsSourceSortingOption
    {
        Default,
        ByAscendingTitle,
        ByDescendingTitle,
    }

    public class NewsSourceSortingOptions :
        Dictionary<NewsSourceSortingOption, KeyValuePair<SortingMode, Expression<Func<NewsSource, object>>>>
    {
        public NewsSourceSortingOptions()
        {
            Add(NewsSourceSortingOption.Default, new(SortingMode.Ascending, source => source.Id));
            Add(NewsSourceSortingOption.ByAscendingTitle, new(SortingMode.Ascending, source => source.Title));
            Add(NewsSourceSortingOption.ByDescendingTitle, new(SortingMode.Descending, source => source.Title));
        }
    }
}
