using Microsoft.EntityFrameworkCore;
using NewsAggregator.Domain.Entities;

namespace NewsAggregator.News.Entities
{
    public class NewsEditor : EntityBase
    {
        public const string Empty = "Unknown";

        public Guid SourceId { get; set; }

        public string Name { get; set; }

        public virtual NewsSource? Source { get; set; }

        public virtual IReadOnlyCollection<News>? News { get; set; }
    }
}
