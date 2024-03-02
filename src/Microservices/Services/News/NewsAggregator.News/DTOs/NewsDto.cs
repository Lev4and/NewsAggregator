namespace NewsAggregator.News.DTOs
{
    public class NewsDto
    {
        public string Url { get; }

        public string Title { get; }

        public string? SubTitle { get; }

        public string EditorName { get; }

        public string? PictureUrl { get; }

        public string? VideoUrl { get; }

        public string HtmlDescription { get; }

        public string TextDescription { get; }

        public DateTime? PublishedAt { get; }

        public DateTime? ModifiedAt { get; }

        public DateTime ParsedAt { get; }

        public NewsDto(string url, string title, string htmlDescription, string textDescription, string? subTitle, string editorName, 
            string? pictureUrl, string? videoUrl, DateTime? publishedAt, DateTime? modifiedAt, DateTime parsedAt)
        {
            Url = url;
            Title = title;
            SubTitle = subTitle;
            EditorName = editorName;
            PictureUrl = pictureUrl;
            VideoUrl = videoUrl;
            HtmlDescription = htmlDescription;
            TextDescription = textDescription;
            PublishedAt = publishedAt;
            ModifiedAt = modifiedAt;
            ParsedAt = parsedAt;
        }
    }
}
