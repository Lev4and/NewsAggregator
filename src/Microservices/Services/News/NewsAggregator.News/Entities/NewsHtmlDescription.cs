using NewsAggregator.Domain.Entities;

namespace NewsAggregator.News.Entities
{
    public class NewsHtmlDescription : EntityBase
    {
        public Guid NewsId { get; set; }

        public string Description { get; set; }

        public virtual News? News { get; set; }
    }
}
