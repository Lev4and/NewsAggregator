namespace NewsAggregator.News.Services.Parsers
{
    public class NewsParserOptions
    {
        public string TitleXPath { get; }

        public string? SubTitleXPath { get; }

        public string? EditorNameXPath { get; }

        public string? PictureUrlXPath { get; }

        public string? DescriptionXPath { get; }

        public string? PublishedAtXPath { get; }

        public string? PublishedAtFormat { get; }

        public string? PublishedAtCultureInfo { get; }

        public NewsParserOptions(string titleXPath, string? subTitleXPath, string? editorNameXPath, string? pictureUrlXPath, 
            string? descriptionXPath, string? publishedAtXPath, string? publishedAtFormat, string? publishedAtCultureInfo)
        {
            TitleXPath = titleXPath;
            SubTitleXPath = subTitleXPath;
            EditorNameXPath = editorNameXPath;
            PictureUrlXPath = pictureUrlXPath;
            DescriptionXPath = descriptionXPath;
            PublishedAtXPath = publishedAtXPath;
            PublishedAtFormat = publishedAtFormat;
            PublishedAtCultureInfo = publishedAtCultureInfo;
        }
    }
}
