using NewsAggregator.News.Entities;

namespace NewsAggregator.News.Extensions
{
    public static class NewsEditorExtensions
    {
        public static string GetFormattedName(this NewsEditor editor)
        {
            return editor.Name ?? "Unknown";
        }
    }
}
