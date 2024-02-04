using NewsAggregator.Domain.Entities;

namespace NewsAggregator.News.Entities
{
    public class NewsParseSettings : EntityBase
    {
        public Guid SourceId { get; set; }

        public string TitleXPath { get; set; }

        public string DescriptionXPath { get; set; }

        public virtual NewsSource? Source { get; set; }

        public virtual NewsParseEditorSettings? ParseEditorSettings { get; set; }

        public virtual NewsParsePictureSettings? ParsePictureSettings { get; set; }

        public virtual NewsParseVideoSettings? ParseVideoSettings { get; set; }

        public virtual NewsParseSubTitleSettings? ParseSubTitleSettings { get; set; }

        public virtual NewsParsePublishedAtSettings? ParsePublishedAtSettings { get; set; }

        public virtual NewsParseModifiedAtSettings? ParseModifiedAtSettings { get; set; }
    }
}
