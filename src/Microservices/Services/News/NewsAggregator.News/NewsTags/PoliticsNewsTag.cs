using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsTags
{
    public class PoliticsNewsTag : NewsTag
    {
        public PoliticsNewsTag()
        {
            Id = Guid.Parse("302d7e19-c80f-4e1a-8877-3e9b17f9baeb");
            Name = "Politics";
        }
    }
}
