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

        public string[]? PublishedAtFormats { get; set; }

        public string? PublishedAtCultureInfo { get; set; }

        public string? PublishedAtTimeZoneInfoId { get; set; }

        public bool IsPublishedAtRequired { get; set; }

        public NewsParserOptions() : this("", "", null, false, null, false, null, false, null, null, null, null, false)
        {

        }

        public NewsParserOptions(string titleXPath, string descriptionXPath, string? subTitleXPath, bool isSubTitleRequired, 
            string? editorNameXPath, bool isEditorNameRequired, string? pictureUrlXPath, bool isPictureUrlRequired, 
            string? publishedAtXPath, string[]? publishedAtFormats, string? publishedAtCultureInfo, 
            string? publishedAtTimeZoneId, bool isPublishedAtRequired)
        {
            TitleXPath = titleXPath;
            DescriptionXPath = descriptionXPath;
            SubTitleXPath = subTitleXPath;
            IsSubTitleRequired = isSubTitleRequired;
            EditorNameXPath = editorNameXPath;
            IsEditorNameRequired = isEditorNameRequired;
            PictureUrlXPath = pictureUrlXPath;
            IsPictureUrlRequired = isPictureUrlRequired;
            PublishedAtXPath = publishedAtXPath;
            PublishedAtFormats = publishedAtFormats;
            PublishedAtCultureInfo = publishedAtCultureInfo;
            PublishedAtTimeZoneInfoId = publishedAtTimeZoneId;
            IsPublishedAtRequired = isPublishedAtRequired;
        }
    }
}
