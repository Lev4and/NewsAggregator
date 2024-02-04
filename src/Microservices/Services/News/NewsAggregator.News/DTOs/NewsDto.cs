namespace NewsAggregator.News.DTOs
{
    public class NewsDto
    {
        public string Url { get; }

        public string Title { get; }

        public string? SubTitle { get; }

        public string? EditorName { get; }

        public string? PictureUrl { get; }

        public string? VideoUrl { get; }

        public string Description { get; }

        public DateTime? PublishedAt { get; }

        public DateTime? ModifiedAt { get; }

        public DateTime ParsedAt { get; }

        public NewsDto(string url, string title, string description, string? subTitle, string? editorName, 
            string? pictureUrl, string? videoUrl, DateTime? publishedAt, DateTime? modifiedAt, DateTime parsedAt)
        {
            Url = url;
            Title = title;
            SubTitle = subTitle;
            EditorName = editorName;
            PictureUrl = pictureUrl;
            VideoUrl = videoUrl;
            Description = description;
            PublishedAt = publishedAt;
            ModifiedAt = modifiedAt;
            ParsedAt = parsedAt;
        }
    }
}
