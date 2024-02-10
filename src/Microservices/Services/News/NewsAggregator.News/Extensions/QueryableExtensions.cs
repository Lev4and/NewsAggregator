using Microsoft.EntityFrameworkCore;
using NewsAggregator.News.Entities;

namespace NewsAggregator.News.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<NewsSource> IncludeAll(this IQueryable<NewsSource> newsSources)
        {
            return newsSources.Include(source => source.Logo)
                .Include(source => source.SearchSettings)
                .Include(source => source.ParseSettings)
                .Include(source => source.ParseSettings.ParseSubTitleSettings)
                .Include(source => source.ParseSettings.ParsePublishedAtSettings)
                .Include(source => source.ParseSettings.ParsePublishedAtSettings.Formats)
                .Include(source => source.ParseSettings.ParseModifiedAtSettings)
                .Include(source => source.ParseSettings.ParseModifiedAtSettings.Formats)
                .Include(source => source.ParseSettings.ParseEditorSettings)
                .Include(source => source.ParseSettings.ParsePictureSettings)
                .Include(source => source.ParseSettings.ParseVideoSettings);
        }
    }
}
