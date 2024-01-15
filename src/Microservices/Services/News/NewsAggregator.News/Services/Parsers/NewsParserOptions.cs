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

        public string? PublishedAtFormat { get; set; }

        public string? PublishedAtCultureInfo { get; set; }

        public bool IsPublishedAtRequired { get; set; }

        public NewsParserOptions() : this("", "", null, false, null, false, null, false, null, null, null, false)
        {

        }

        public NewsParserOptions(string titleXPath, string descriptionXPath, string? subTitleXPath, bool isSubTitleRequired, 
            string? editorNameXPath, bool isEditorNameRequired, string? pictureUrlXPath, bool isPictureUrlRequired, 
            string? publishedAtXPath, string? publishedAtFormat, string? publishedAtCultureInfo, bool isPublishedAtRequired)
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
            PublishedAtFormat = publishedAtFormat;
            PublishedAtCultureInfo = publishedAtCultureInfo;
            IsPublishedAtRequired = isPublishedAtRequired;
        }
    }
}
