using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsReactions
{
    public class AstonishedReaction : Reaction
    {
        public AstonishedReaction()
        {
            Id = Guid.Parse("64f9b137-6ec4-4026-84f6-371fd15b2d7a");
            Title = "Astonished";
            Icon = new ReactionIcon
            {
                Id = Guid.Parse("02c35a67-344b-4520-b04c-ea8e92d62dbf"),
                IconClass = "bi-emoji-astonished-fill"
            };
        }
    }
}
