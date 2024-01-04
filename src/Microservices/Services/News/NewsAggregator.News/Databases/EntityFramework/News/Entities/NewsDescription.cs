using NewsAggregator.Domain.Entities;

namespace NewsAggregator.News.Databases.EntityFramework.News.Entities
{
    public class NewsDescription : EntityBase
    {
        public Guid NewsId { get; set; }

        public string Description { get; set; }

        public virtual News? News { get; set; }
    }
}
