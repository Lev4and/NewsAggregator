using NewsAggregator.Domain.Entities;

namespace NewsAggregator.News.Databases.EntityFramework.News.Entities
{
    public class NewsParsePublishedAtSettings : EntityBase
    {
        public Guid ParseSettingsId { get; set; }

        public string PublishedAtXPath { get; set; }

        public string PublishedAtCultureInfo { get; set; }

        public string? PublishedAtTimeZoneInfoId { get; set; }

        public bool IsRequired { get; set; }

        public virtual NewsParseSettings? ParseSettings { get; set; }

        public virtual IReadOnlyCollection<NewsParsePublishedAtSettingsFormat>? Formats { get; set; }
    }
}
