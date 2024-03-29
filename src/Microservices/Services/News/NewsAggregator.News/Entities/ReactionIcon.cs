using NewsAggregator.Domain.Entities;

namespace NewsAggregator.News.Entities
{
    public class ReactionIcon : EntityBase
    {
        public Guid ReactionId { get; set; }

        public string IconClass { get; set; }

        public virtual Reaction? Reaction { get; set; }
    }
}
