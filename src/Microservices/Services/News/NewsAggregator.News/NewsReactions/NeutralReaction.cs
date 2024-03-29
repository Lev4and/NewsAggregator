using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsReactions
{
    public class NeutralReaction : Reaction
    {
        public NeutralReaction()
        {
            Id = Guid.Parse("60e71cd7-12a3-4c2e-b626-ffba6415b814");
            Title = "Neutral";
            Icon = new ReactionIcon
            {
                Id = Guid.Parse("26c1d336-5429-4343-ac30-651bab560ca9"),
                IconClass = "bi-emoji-neutral-fill"
            };
        }
    }
}
