using NewsAggregator.Domain.Entities;

namespace NewsAggregator.News.Databases.EntityFramework.News.Entities
{
    public class NewsSourceLogo : EntityBase
    {
        public Guid SourceId { get; set; }

        public string Url { get; set; }

        public virtual NewsSource? Source { get; set; }
    }
}
