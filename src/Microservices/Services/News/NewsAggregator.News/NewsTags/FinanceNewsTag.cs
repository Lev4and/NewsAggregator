using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsTags
{
    public class FinanceNewsTag : NewsTag
    {
        public FinanceNewsTag()
        {
            Id = Guid.Parse("19db4d3d-b17a-45ff-9853-cdce9630c08f");
            Name = "Finance";
        }
    }
}
