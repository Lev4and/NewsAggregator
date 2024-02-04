using NewsAggregator.Domain.Enums;
using NewsAggregator.News.Entities;
using System.Linq.Expressions;

namespace NewsAggregator.News.Enums
{
    public enum NewsEditorSortingOption
    {
        Default,
        ByAscendingName,
        ByDescendingName,
        ByAscendingNewsSourceTitle,
        ByDescendingNewsSourceTitle,
    }

    public class NewsEditorSortingOptions :
        Dictionary<NewsEditorSortingOption, KeyValuePair<SortingMode, Expression<Func<NewsEditor, object>>>>
    {
        public NewsEditorSortingOptions()
        {
            Add(NewsEditorSortingOption.Default, new(SortingMode.Ascending, editor => editor.Id));
            Add(NewsEditorSortingOption.ByAscendingName, new(SortingMode.Ascending, editor => editor.Name));
            Add(NewsEditorSortingOption.ByDescendingName, new(SortingMode.Descending, editor => editor.Name));
            Add(NewsEditorSortingOption.ByAscendingNewsSourceTitle, new(SortingMode.Ascending, editor => editor.Source.Title));
            Add(NewsEditorSortingOption.ByDescendingNewsSourceTitle, new(SortingMode.Descending, editor => editor.Source.Title));
        }
    }
}
