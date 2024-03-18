using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsTags
{
    public class RussiaNewsTag : NewsTag
    {
        public RussiaNewsTag()
        {
            Id = Guid.Parse("9503b07f-c97a-49e7-b177-97e3a293dc31");
            Name = "Russia";
        }
    }
}
