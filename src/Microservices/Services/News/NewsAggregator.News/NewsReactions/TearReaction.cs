using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsReactions
{
    public class TearReaction : Reaction
    {
        public TearReaction()
        {
            Id = Guid.Parse("81f8a4e0-f850-411b-ba9a-6131c6768658");
            Title = "Tear";
            Icon = new ReactionIcon
            {
                Id = Guid.Parse("2158fcf6-039c-49f4-8e2e-9867ba006e1f"),
                IconClass = "bi-emoji-tear-fill"
            };
        }
    }
}
