using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsReactions
{
    public class AngryReaction : Reaction
    {
        public AngryReaction()
        {
            Id = Guid.Parse("79569ca3-5279-4f10-a69b-a1c01bc4aafc");
            Title = "Angry";
            Icon = new ReactionIcon
            {
                Id = Guid.Parse("c815a7e1-385a-4b64-9351-04c32b9a45d5"),
                IconClass = "bi-emoji-angry-fill",
                IconColor = "red"
            };
        }
    }
}
