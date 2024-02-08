using NewsAggregator.Domain.Entities;

namespace NewsAggregator.News.Entities
{
    public class NewsParseNetworkError : EntityBase
    {
        public string NewsUrl { get; set; }

        public string Message { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
