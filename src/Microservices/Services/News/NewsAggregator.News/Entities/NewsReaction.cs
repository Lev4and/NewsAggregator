using NewsAggregator.Domain.Entities;

namespace NewsAggregator.News.Entities
{
    public class NewsReaction : EntityBase
    {
        public Guid NewsId { get; set; }

        public Guid ReactionId { get; set; }

        public string IpAddress { get; set; }

        public DateTime ReactedAt { get; set; }

        public virtual News? News { get; set; }

        public virtual Reaction? Reaction { get; set; }
    }
}
