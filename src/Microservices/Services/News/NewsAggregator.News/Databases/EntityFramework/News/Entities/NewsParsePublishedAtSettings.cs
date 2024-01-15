using NewsAggregator.Domain.Entities;

namespace NewsAggregator.News.Databases.EntityFramework.News.Entities
{
    public class NewsParsePublishedAtSettings : EntityBase
    {
        public Guid ParseSettingsId { get; set; }

        public string PublishedAtXPath { get; set; }

        public string PublishedAtFormat { get; set; }

        public string PublishedAtCultureInfo { get; set; }

        public bool IsRequired { get; set; }

        public virtual NewsParseSettings? ParseSettings { get; set; }
    }
}
