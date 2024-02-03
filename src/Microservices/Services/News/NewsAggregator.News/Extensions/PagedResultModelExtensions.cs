using NewsAggregator.Domain.Entities;
using System.Globalization;

namespace NewsAggregator.News.Extensions
{
    public static class PagedResultModelExtensions
    {
        public static string GetFormattedTotalItems<TResult>(this PagedResultModel<TResult> resultModel)
        {
            return resultModel.TotalItems.ToString("N0", new CultureInfo("en-US"));
        }
    }
}
