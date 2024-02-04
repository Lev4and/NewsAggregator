using Microsoft.EntityFrameworkCore;
using NewsAggregator.Domain.Enums;
using NewsAggregator.Domain.Specification;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Enums;

namespace NewsAggregator.News.Specifications
{
    public class GetNewsEditorGridSpecification : GridSpecificationBase<NewsEditor>
    {
        public GetNewsEditorGridSpecification(GetNewsEditorListFilters filters)
        {
            AddInclude(editor => editor.Source);
            AddInclude(editor => editor.Source.Logo);

            if (!string.IsNullOrEmpty(filters.SearchString))
            {
                ApplyFilter(editor => EF.Functions.Like(editor.Name, $"%{filters.SearchString}%"));
            }

            if (filters.NewsSourcesIds is not null && filters.NewsSourcesIds?.Length > 0)
            {
                ApplyFilter(editor => filters.NewsSourcesIds.Contains(editor.SourceId));
            }

            ApplyPaging(filters.Page * filters.PageSize - filters.PageSize, filters.PageSize);

            var newsSotringOptions = new NewsEditorSortingOptions();

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
