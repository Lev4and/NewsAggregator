using NewsAggregator.Domain.Entities;

namespace NewsAggregator.News.Entities
{
    public class NewsSiteVisit : EntityBase
    {
        public string IpAddress { get; set; }

        public DateTime VisitedAt { get; set; }
    }
}
