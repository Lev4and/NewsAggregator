using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsTags
{
    public class MoscowNewsTag : NewsTag
    {
        public MoscowNewsTag()
        {
            Id = Guid.Parse("9f2effc4-5f9d-419a-83a9-598c41afc2b8");
            Name = "Moscow";
        }
    }
}
