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

            if (filters.IsEnabledRequired)
            {
                ApplyFilter(news => news.IsEnabled);
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
