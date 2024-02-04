using Microsoft.EntityFrameworkCore;
using NewsAggregator.Domain.Entities;

namespace NewsAggregator.News.Entities
{
    public class News : EntityBase
    {
        public Guid EditorId { get; set; }

        public string Url { get; set; }

        public string Title { get; set; }

        public DateTime? PublishedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public DateTime ParsedAt { get; set; }

        public DateTime AddedAt { get; set; }

        public virtual NewsEditor? Editor { get; set; }

        public virtual NewsSubTitle? SubTitle { get; set; }

        public virtual NewsPicture? Picture { get; set; }

        public virtual NewsVideo? Video { get; set; }

        public virtual NewsDescription? Description { get; set; }
    }
}
