using NewsAggregator.Domain.Entities;

namespace NewsAggregator.News.Entities
{
    public class NewsSourceLogo : EntityBase
    {
        public Guid SourceId { get; set; }

        public string Small { get; set; }

        public string Original { get; set; }

        public virtual NewsSource? Source { get; set; }
    }
}
