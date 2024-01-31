using Microsoft.EntityFrameworkCore;
using NewsAggregator.Domain.Entities;

namespace NewsAggregator.News.Entities
{
    public class News : EntityBase
    {
        public Guid EditorId { get; set; }

        public string Url { get; set; }

        public string Title { get; set; }

        public virtual DateTime? PublishedAt { get; set; }

        public virtual DateTime ParsedAt { get; set; }

        public virtual DateTime AddedAt { get; set; }

        public virtual NewsEditor? Editor { get; set; }

        public virtual NewsSubTitle? SubTitle { get; set; }

        public virtual NewsPicture? Picture { get; set; }

        public virtual NewsDescription? Description { get; set; }
    }
}
