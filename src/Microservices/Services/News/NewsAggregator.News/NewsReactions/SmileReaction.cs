using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsReactions
{
    public class SmileReaction : Reaction
    {
        public SmileReaction()
        {
            Id = Guid.Parse("44135679-ac4c-4a3b-8f60-eb645bdda922");
            Title = "Smile";
            Icon = new ReactionIcon
            {
                Id = Guid.Parse("2ffbe56a-543f-4f3b-8196-8886ce47f12a"),
                IconClass = "bi-emoji-smile-fill"
            };
        }
    }
}
