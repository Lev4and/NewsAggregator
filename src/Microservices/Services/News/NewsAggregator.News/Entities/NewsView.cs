using NewsAggregator.Domain.Entities;

namespace NewsAggregator.News.Entities
{
    public class NewsView : EntityBase
    {
        public Guid NewsId { get; set; }

        public string IpAddress { get; set; }

        public DateTime ViewedAt { get; set; }

        public virtual News? News { get; set; }
    }
}
