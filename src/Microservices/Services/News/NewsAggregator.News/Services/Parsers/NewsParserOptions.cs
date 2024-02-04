namespace NewsAggregator.News.Services.Parsers
{
    public class NewsParserOptions
    {
        public string TitleXPath { get; set; }

        public string DescriptionXPath { get; set; }

        public string? SubTitleXPath { get; set; }

        public bool IsSubTitleRequired { get; set; }

        public string? EditorNameXPath { get; set; }

        public bool IsEditorNameRequired { get; set; }

        public string? PictureUrlXPath { get; set; }

        public bool IsPictureUrlRequired { get; set; }

        public string? PublishedAtXPath { get; set; }

        public bool IsVideoUrlRequired { get; set; }

        public string? VideoUrlXPath { get; set; }

        public string[]? PublishedAtFormats { get; set; }

        public string? PublishedAtCultureInfo { get; set; }

        public string? PublishedAtTimeZoneInfoId { get; set; }

        public bool IsPublishedAtRequired { get; set; }

        public string? ModifiedAtXPath { get; set; }

        public string[]? ModifiedAtFormats { get; set; }

        public string? ModifiedAtCultureInfo { get; set; }

        public string? ModifiedAtTimeZoneInfoId { get; set; }

        public bool IsModifiedAtRequired { get; set; }
    }
}
