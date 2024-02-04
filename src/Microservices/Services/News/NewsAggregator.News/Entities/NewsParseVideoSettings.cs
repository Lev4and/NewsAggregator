using NewsAggregator.Domain.Entities;

namespace NewsAggregator.News.Entities
{
    public class NewsParseVideoSettings : EntityBase
    {
        public Guid ParseSettingsId { get; set; }

        public string UrlXPath { get; set; }

        public bool IsRequired { get; set; }

        public virtual NewsParseSettings? ParseSettings { get; set; }
    }
}
