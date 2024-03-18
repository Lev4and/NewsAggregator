using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsTags
{
    public class NewYorkNewsTag : NewsTag
    {
        public NewYorkNewsTag()
        {
            Id = Guid.Parse("e0a5af2c-cb45-40da-90d7-7ba59c662bcb");
            Name = "New York";
        }
    }
}
