using NewsAggregator.Domain.Entities;

namespace NewsAggregator.News.Databases.EntityFramework.News.Entities
{
    public class NewsParsePictureSettings : EntityBase
    {
        public Guid ParseSettingsId { get; set; }

        public string UrlXPath { get; set; }

        public virtual NewsParseSettings? ParseSettings { get; set; }
    }
}
