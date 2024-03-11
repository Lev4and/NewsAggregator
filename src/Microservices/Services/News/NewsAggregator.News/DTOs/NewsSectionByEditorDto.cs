using NewsAggregator.News.Entities;

namespace NewsAggregator.News.DTOs
{
    public class NewsSectionByEditorDto
    {
        public NewsEditor Editor { get; set; }

        public IReadOnlyCollection<Entities.News> News { get; set; }
    }
}
