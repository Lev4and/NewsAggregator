using Microsoft.EntityFrameworkCore;
using NewsAggregator.Domain.Enums;
using NewsAggregator.Domain.Specification;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Enums;

namespace NewsAggregator.News.Specifications
{
    public class GetNewsSourceGridSpecification : GridSpecificationBase<NewsSource>
    {
        public GetNewsSourceGridSpecification(GetNewsSourceListFilters filters)
        {
            AddInclude(source => source.Logo);
            AddInclude(source => source.SearchSettings);
            AddInclude(source => source.ParseSettings);
            AddInclude(source => source.ParseSettings.ParseSubTitleSettings);
            AddInclude(source => source.ParseSettings.ParsePublishedAtSettings);
            AddInclude(source => source.ParseSettings.ParsePublishedAtSettings.Formats);
            AddInclude(source => source.ParseSettings.ParseModifiedAtSettings);
            AddInclude(source => source.ParseSettings.ParseModifiedAtSettings.Formats);
            AddInclude(source => source.ParseSettings.ParseEditorSettings);
            AddInclude(source => source.ParseSettings.ParsePictureSettings);
            AddInclude(source => source.ParseSettings.ParseVideoSettings);

            if (filters.IsEnabled is not null)
            {
                ApplyFilter(news => news.IsEnabled == filters.IsEnabled);
            }

            if (filters.SupportedParseSubTitle is not null)
            {
                ApplyFilter(news => (news.ParseSettings.ParseSubTitleSettings != null) == filters.SupportedParseSubTitle);
            }

            if (filters.SupportedParsePublishedAt is not null)
            {
                ApplyFilter(news => (news.ParseSettings.ParsePublishedAtSettings != null) == filters.SupportedParsePublishedAt);
            }

            if (filters.SupportedParseModifiedAt is not null)
            {
                ApplyFilter(news => (news.ParseSettings.ParseModifiedAtSettings != null) == filters.SupportedParseModifiedAt);
            }

            if (filters.SupportedParseEditor is not null)
            {
                ApplyFilter(news => (news.ParseSettings.ParseEditorSettings != null) == filters.SupportedParseEditor);
            }

            if (filters.SupportedParsePicture is not null)
            {
                ApplyFilter(news => (news.ParseSettings.ParsePictureSettings != null) == filters.SupportedParsePicture);
            }

            if (filters.SupportedParseVideo is not null)
            {
                ApplyFilter(news => (news.ParseSettings.ParseVideoSettings != null) == filters.SupportedParseVideo);
            }

            if (!string.IsNullOrEmpty(filters.SearchString))
            {
                ApplyFilter(source => EF.Functions.Like(source.Title, $"%{filters.SearchString}%"));
            }

            ApplyPaging(filters.Page * filters.PageSize - filters.PageSize, filters.PageSize);

            var newsSotringOptions = new NewsSourceSortingOptions();

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
