using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsReactions
{
    public class LaughingReaction : Reaction
    {
        public LaughingReaction()
        {
            Id = Guid.Parse("181976e1-087d-42dc-9b2b-baeaa79431c7");
            Title = "Laughing";
            Icon = new ReactionIcon
            {
                Id = Guid.Parse("334e08bb-a136-4977-a8e2-d24c01108242"),
                IconClass = "bi-emoji-laughing-fill"
            };
        }
    }
}
