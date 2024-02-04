using NewsAggregator.Domain.Entities;

namespace NewsAggregator.News.Entities
{
    public class NewsParseModifiedAtSettings : EntityBase
    {
        public Guid ParseSettingsId { get; set; }

        public string ModifiedAtXPath { get; set; }

        public string ModifiedAtCultureInfo { get; set; }

        public string? ModifiedAtTimeZoneInfoId { get; set; }

        public bool IsRequired { get; set; }

        public virtual NewsParseSettings? ParseSettings { get; set; }

        public virtual IReadOnlyCollection<NewsParseModifiedAtSettingsFormat>? Formats { get; set; }
    }
}
