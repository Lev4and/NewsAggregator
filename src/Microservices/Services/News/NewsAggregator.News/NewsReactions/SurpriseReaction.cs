using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsReactions
{
    public class SurpriseReaction : Reaction
    {
        public SurpriseReaction()
        {
            Id = Guid.Parse("1ef9784e-14e3-4435-b536-9467a7a66176");
            Title = "Surprise";
            Icon = new ReactionIcon
            {
                Id = Guid.Parse("19ca1fb2-5435-4f26-90b6-9e96d0d6821c"),
                IconClass = "bi-emoji-surprise-fill",
                IconColor = "lime"
            };
        }
    }
}
