using Microsoft.EntityFrameworkCore;
using NewsAggregator.Domain.Specification;
using NewsAggregator.News.DTOs;
using System.Linq.Expressions;

namespace NewsAggregator.News.Specifications
{
    public class GetNewsListSpecification : GridSpecificationBase<Entities.News>
    {
        public GetNewsListSpecification(GetNewsListFilters filters)
        {
            AddInclude(news => news.Editor);
            AddInclude(news => news.Editor.Source);
            AddInclude(news => news.Editor.Source.Logo);
            AddInclude(news => news.SubTitle);
            AddInclude(news => news.Picture);

            if (!string.IsNullOrEmpty(filters.SearchString))
            {
                ApplyFilter(news => EF.Functions.Like(news.Title, $"%{filters.SearchString}%"));
            }

            if (filters.StartPublishedAt is not null && filters.EndPublishedAt is not null) 
            {
                var startPublishedAt = TimeZoneInfo.ConvertTime(filters.StartPublishedAt.Value, TimeZoneInfo.Utc, 
                    TimeZoneInfo.Utc);

                var endPublishedAt = TimeZoneInfo.ConvertTime(filters.EndPublishedAt.Value, TimeZoneInfo.Utc,
                    TimeZoneInfo.Utc);

                ApplyFilter(news => news.PublishedAt >= startPublishedAt &&
                    news.PublishedAt <= endPublishedAt);
            }
            else if (filters.StartPublishedAt is not null)
            {
                var startPublishedAt = TimeZoneInfo.ConvertTime(filters.StartPublishedAt.Value, TimeZoneInfo.Utc,
                    TimeZoneInfo.Utc);

                ApplyFilter(news => news.PublishedAt >= startPublishedAt);
            }
            else if (filters.EndPublishedAt is not null)
            {
                var endPublishedAt = TimeZoneInfo.ConvertTime(filters.EndPublishedAt.Value, TimeZoneInfo.Utc,
                    TimeZoneInfo.Utc);

                ApplyFilter(news => news.PublishedAt <= endPublishedAt);
            }

            if (filters.NewsEditorsIds is not null && filters.NewsEditorsIds?.Length > 0)
            {
                ApplyFilter(news => filters.NewsEditorsIds.Contains(news.EditorId));
            }

            if (filters.NewsSourcesIds is not null && filters.NewsSourcesIds?.Length > 0)
            {
                ApplyFilter(news => filters.NewsSourcesIds.Contains(news.Editor.SourceId));
            }

            ApplyPaging(filters.Page * filters.PageSize - filters.PageSize, filters.PageSize);

            ApplyOrderByDescending(news => news.PublishedAt);
        }
    }
}
