using NewsAggregator.Domain.Entities;

namespace NewsAggregator.News.Databases.EntityFramework.News.Entities
{
    public class NewsParseEditorSettings : EntityBase
    {
        public Guid ParseSettingsId { get; set; }

        public string NameXPath { get; set; }

        public virtual NewsParseSettings? ParseSettings { get; set; }
    }
}
