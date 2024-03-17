using NewsAggregator.Domain.Enums;
using System.Linq.Expressions;

namespace NewsAggregator.News.Enums
{
    public enum NewsSortingOption
    {
        Default,
        ByOld,
        ByRecently,
        ByAscendingTitle,
        ByDescendingTitle,
        ByAscendingNewsEditorName,
        ByAscendingNewsSourceTitle,
        ByDescendingNewsEditorName,
        ByDescendingNewsSourceTitle,
    }

    public class NewsSortingOptions : 
        Dictionary<NewsSortingOption, KeyValuePair<SortingMode, Expression<Func<Entities.News, object>>>>
    {
        public NewsSortingOptions()
        {
            Add(NewsSortingOption.Default, new (SortingMode.Ascending, news => news.Id));
            Add(NewsSortingOption.ByOld, new(SortingMode.Ascending, news => news.PublishedAt ?? DateTime.UtcNow));
            Add(NewsSortingOption.ByRecently, new(SortingMode.Descending, news => news.PublishedAt ?? DateTime.UnixEpoch));
            Add(NewsSortingOption.ByAscendingTitle, new(SortingMode.Ascending, news => news.Title));
            Add(NewsSortingOption.ByDescendingTitle, new(SortingMode.Descending, news => news.Title));
            Add(NewsSortingOption.ByAscendingNewsEditorName, new(SortingMode.Ascending, news => news.Editor.Name));
            Add(NewsSortingOption.ByAscendingNewsSourceTitle, new(SortingMode.Ascending, news => news.Editor.Name));
            Add(NewsSortingOption.ByDescendingNewsEditorName, new(SortingMode.Descending, news => news.Editor.Source.Title));
            Add(NewsSortingOption.ByDescendingNewsSourceTitle, new(SortingMode.Descending, news => news.Editor.Source.Title));
        }
    }
}
