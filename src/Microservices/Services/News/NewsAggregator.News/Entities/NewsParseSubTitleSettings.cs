using NewsAggregator.Domain.Entities;

namespace NewsAggregator.News.Entities
{
    public class NewsParseSubTitleSettings : EntityBase
    {
        public Guid ParseSettingsId { get; set; }

        public string TitleXPath { get; set; }

        public bool IsRequired { get; set; }

        public virtual NewsParseSettings? ParseSettings { get; set; }
    }
}
