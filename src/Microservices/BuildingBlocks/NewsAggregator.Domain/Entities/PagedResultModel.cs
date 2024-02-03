namespace NewsAggregator.Domain.Entities
{
    public class PagedResultModel<TResult>
    {
        public long Page { get; }

        public long PageSize { get; }

        public long TotalItems { get; }

        public long TotalPages => Convert.ToInt64(Math.Ceiling((decimal)TotalItems / (decimal)PageSize));

        public IReadOnlyCollection<TResult> Items { get; }

        public PagedResultModel(IReadOnlyCollection<TResult> items, long page, long pageSize, long totalItems)
        {
            Page = page;
            Items = items;
            PageSize = pageSize;
            TotalItems = totalItems;
        }
    }
}
