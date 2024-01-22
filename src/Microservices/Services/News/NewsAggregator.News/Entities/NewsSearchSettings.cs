using NewsAggregator.Domain.Entities;

namespace NewsAggregator.News.Entities
{
    public class NewsSearchSettings : EntityBase
    {
        public Guid SourceId { get; set; }

        public string NewsSiteUrl { get; set; }

        public string NewsUrlXPath { get; set; }

        public virtual NewsSource? Source { get; set; }
    }
}
