using NewsAggregator.Domain.Entities;

namespace NewsAggregator.News.Entities
{
    public class Reaction : EntityBase
    {
        public string Title { get; set; }

        public virtual ReactionIcon? Icon { get; set; }

        public virtual IReadOnlyCollection<NewsReaction>? News { get; set; }
    }
}
