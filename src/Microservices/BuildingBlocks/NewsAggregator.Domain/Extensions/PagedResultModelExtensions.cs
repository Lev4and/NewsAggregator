using NewsAggregator.Domain.Entities;

namespace NewsAggregator.Domain.Extensions
{
    public static class PagedResultModelExtensions
    {
        public static IReadOnlyCollection<long> GetPageNumbers<TResult>(this PagedResultModel<TResult> resultModel)
        {
            var centerLeft = 0L;
            var centerRight = 0L;
            var leftSideCount = 1L;
            var rightSideCount = 1L;
            var centerSideCount = 2L;

            var pageNumbers = new List<long>();

            pageNumbers.AddRange(GetNumbers(1, leftSideCount));

            if (resultModel.TotalPages >= 3)
            {
                centerLeft = Math.Max(leftSideCount + 1, resultModel.Page - centerSideCount);

                centerRight = Math.Min(resultModel.TotalPages - rightSideCount, 
                    centerLeft + centerSideCount * 2);

                centerLeft = Math.Max(leftSideCount + 1, centerRight - centerSideCount * 2);

                pageNumbers.AddRange(GetNumbers(centerLeft, centerRight));
            }

            if (resultModel.TotalPages > 1)
            {
                pageNumbers.AddRange(GetNumbers(resultModel.TotalPages - rightSideCount + 1,
                    resultModel.TotalPages));
            }

            return pageNumbers;
        }

        private static IReadOnlyCollection<long> GetNumbers(long start, long end)
        {
            var length = Math.Abs(end - start) + 1;

            var numbers = new List<long>();

            for (int i = 0; i < length; i++)
            {
                numbers.Add(i * Math.Sign(end - start) + start);
            }

            return numbers;
        }
    }
}
