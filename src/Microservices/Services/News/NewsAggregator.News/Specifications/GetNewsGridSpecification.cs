using MediatR;
using Microsoft.EntityFrameworkCore;
using NewsAggregator.Domain.Enums;
using NewsAggregator.Domain.Specification;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.Enums;

namespace NewsAggregator.News.Specifications
{
    public class GetNewsGridSpecification : GridSpecificationBase<Entities.News>
    {
        public GetNewsGridSpecification(GetNewsListFilters filters)
        {
            AddInclude(news => news.Editor);
            AddInclude(news => news.Editor.Source);
            AddInclude(news => news.Editor.Source.Logo);
            AddInclude(news => news.Editor.Source.Tags);
            AddInclude(news => news.SubTitle);
            AddInclude(news => news.Picture);
            AddInclude(news => news.Video);

            if (filters.HasPublishedAt is not null)
            {
                ApplyFilter(news => (news.PublishedAt != null) == filters.HasPublishedAt);
            }

            if (filters.HasModifiedAt is not null)
            {
                ApplyFilter(news => (news.ModifiedAt != null) == filters.HasModifiedAt);
            }

            if (filters.HasSubTitle is not null)
            {
                ApplyFilter(news => (news.SubTitle != null) == filters.HasSubTitle);
            }

            if (filters.HasPicture is not null)
            {
                ApplyFilter(news => (news.Picture != null) == filters.HasPicture);
            }

            if (filters.HasVideo is not null)
            {
                ApplyFilter(news => (news.Video != null) == filters.HasVideo);
            }

            if (!string.IsNullOrEmpty(filters.SearchString))
            {
                ApplyFilter(news => news.Title.ToLower().Contains(filters.SearchString.ToLower()) ||
                    news.SubTitle.Title.ToLower().Contains(filters.SearchString.ToLower()));
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

                ApplyFilter(news => news.PublishedAt >= startPublishedAt &&
                    news.PublishedAt <= DateTime.UtcNow);
            }
            else if (filters.EndPublishedAt is not null)
            {
                var endPublishedAt = TimeZoneInfo.ConvertTime(filters.EndPublishedAt.Value, TimeZoneInfo.Utc,
                    TimeZoneInfo.Utc);

                ApplyFilter(news => news.PublishedAt <= endPublishedAt);
            }
            else
            {
                ApplyFilter(news => news.PublishedAt != null ? news.PublishedAt <= DateTime.UtcNow : true);
            }

            if (filters.NewsTagsIds is not null && filters.NewsTagsIds?.Length > 0)
            {
                ApplyFilter(news => filters.NewsTagsIds.Any(tagId => 
                    news.Editor.Source.Tags.Any(tag => tag.TagId == tagId)));
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

            var newsSotringOptions = new NewsSortingOptions();

            var newsSotringOption = newsSotringOptions[filters.SortBy];

            if (newsSotringOption.Key == SortingMode.Ascending)
            {
                ApplyOrderBy(newsSotringOption.Value);
            }

            if (newsSotringOption.Key == SortingMode.Descending)
            {
                ApplyOrderByDescending(newsSotringOption.Value);
            }
        }
    }
}
