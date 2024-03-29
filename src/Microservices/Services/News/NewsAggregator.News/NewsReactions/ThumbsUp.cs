using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsReactions
{
    public class ThumbsUp : Reaction
    {
        public ThumbsUp()
        {
            Id = Guid.Parse("015aae0f-d855-4f47-b001-4b45c5a837db");
            Title = "Thumbs up";
            Icon = new ReactionIcon
            {
                Id = Guid.Parse("66874c88-c3f0-4836-b340-d186b264e32c"),
                IconClass = "bi-hand-thumbs-up-fill"
            };
        }
    }
}
