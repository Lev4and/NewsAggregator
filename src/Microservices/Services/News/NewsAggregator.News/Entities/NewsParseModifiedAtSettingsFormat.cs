using NewsAggregator.Domain.Entities;

namespace NewsAggregator.News.Entities
{
    public class NewsParseModifiedAtSettingsFormat : EntityBase
    {
        public Guid NewsParseModifiedAtSettingsId { get; set; }

        public string Format { get; set; }

        public virtual NewsParseModifiedAtSettings? Settings { get; set; }
    }
}
