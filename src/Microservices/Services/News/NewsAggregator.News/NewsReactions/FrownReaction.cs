using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsReactions
{
    public class FrownReaction : Reaction
    {
        public FrownReaction()
        {
            Id = Guid.Parse("7f2a58e7-34f8-4551-a1d6-8cd2f132351d");
            Title = "Frown";
            Icon = new ReactionIcon
            {
                Id = Guid.Parse("e1f9ac21-e918-4ab7-a051-43e0fec7e7c5"),
                IconClass = "bi-emoji-frown-fill"
            };
        }
    }
}
