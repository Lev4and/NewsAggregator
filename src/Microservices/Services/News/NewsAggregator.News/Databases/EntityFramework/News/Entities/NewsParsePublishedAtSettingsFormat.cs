using NewsAggregator.Domain.Entities;

namespace NewsAggregator.News.Databases.EntityFramework.News.Entities
{
    public class NewsParsePublishedAtSettingsFormat : EntityBase
    {
        public Guid NewsParsePublishedAtSettingsId { get; set; }

        public string Format { get; set; }

        public virtual NewsParsePublishedAtSettings? Settings { get; set; }
    }
}
