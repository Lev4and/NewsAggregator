using NewsAggregator.Domain.Entities;
using NewsAggregator.Domain.Extensions;
using NewsAggregator.News.Mvc.Models;

namespace NewsAggregator.News.Mvc.Extensions
{
    public static class PagedResultModelExtensions
    {
        public static PaginationModel ToPaginationModel<TResult>(this PagedResultModel<TResult> resultModel, string formId)
        {
            return new PaginationModel 
            {
                FormId = formId,
                Page = resultModel.Page,
                TotalPages = resultModel.TotalPages,
                PageNumbers = resultModel.GetPageNumbers()
            };
        }
    }
}
