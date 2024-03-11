using NewsAggregator.Domain.Entities;

namespace NewsAggregator.News.Entities
{
    public class NewsTag : EntityBase
    {
        public string Name { get; set; }

        public virtual IReadOnlyCollection<NewsSourceTag>? Sources { get; set; }
    }
}
