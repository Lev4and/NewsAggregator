namespace NewsAggregator.News.Services.Parsers
{
    public class NewsParserOptions
    {
        public string TitleXPath { get; set; }

        public string DescriptionXPath { get; set; }

        public string? SubTitleXPath { get; set; }

        public string? EditorNameXPath { get; set; }

        public string? PictureUrlXPath { get; set; }

        public string? PublishedAtXPath { get; set; }

        public string? PublishedAtFormat { get; set; }

        public string? PublishedAtCultureInfo { get; set; }

        public NewsParserOptions() : this("", "", null, null, null, null, null, null)
        {

        }

        public NewsParserOptions(string titleXPath, string descriptionXPath, string? subTitleXPath, string? editorNameXPath, 
            string? pictureUrlXPath, string? publishedAtXPath, string? publishedAtFormat, string? publishedAtCultureInfo)
        {
            TitleXPath = titleXPath;
            DescriptionXPath = descriptionXPath;
            SubTitleXPath = subTitleXPath;
            EditorNameXPath = editorNameXPath;
            PictureUrlXPath = pictureUrlXPath;
            PublishedAtXPath = publishedAtXPath;
            PublishedAtFormat = publishedAtFormat;
            PublishedAtCultureInfo = publishedAtCultureInfo;
        }
    }
}
