namespace NewsAggregator.News.Mvc.Models
{
    public class PaginationModel
    {
        public string FormId { get; set; }

        public long Page { get; set; }

        public long TotalPages { get; set; }

        public IReadOnlyCollection<long> PageNumbers { get; set; }
    }
}
