using System.Globalization;

namespace NewsAggregator.News.Extensions
{
    public static class NewsExtensions
    {
        public static string GetFormattedPublishedAt(this Entities.News news)
        {
            return news.PublishedAt?.ToString("MMM. dd, yyyy, h:mm tt zzz", new CultureInfo("en-US"))
                ?? string.Empty;
        }
    }
}
