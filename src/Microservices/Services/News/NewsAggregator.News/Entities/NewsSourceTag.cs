using NewsAggregator.Domain.Entities;

namespace NewsAggregator.News.Entities
{
    public class NewsSourceTag : EntityBase
    {
        public Guid SourceId { get; set; }

        public Guid TagId { get; set; }

        public virtual NewsSource? Source { get; set; }

        public virtual NewsTag? Tag { get; set; }
    }
}
