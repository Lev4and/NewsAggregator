using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsReactions
{
    public class ThumbsDown : Reaction
    {
        public ThumbsDown()
        {
            Id = Guid.Parse("04cd624c-2d10-4be5-8128-7a529e690cc8");
            Title = "Thumbs down";
            Icon = new ReactionIcon
            {
                Id = Guid.Parse("ef493f75-50d3-49c2-9aad-01edf6cd55c2"),
                IconClass = "bi-hand-thumbs-down-fill",
                IconColor = "red"
            };
        }
    }
}
