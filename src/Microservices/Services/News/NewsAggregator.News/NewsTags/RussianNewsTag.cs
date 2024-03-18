using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsTags
{
    public class RussianNewsTag : NewsTag
    {
        public RussianNewsTag()
        {
            Id = Guid.Parse("d57fa572-a720-432c-a372-b8ade1a7edff");
            Name = "Russian";
        }
    }
}
