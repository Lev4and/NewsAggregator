﻿using Microsoft.EntityFrameworkCore;
using NewsAggregator.Domain.Entities;

namespace NewsAggregator.News.Databases.EntityFramework.News.Entities
{
    [Index(nameof(Url), nameof(Title))]
    public class News : EntityBase
    {
        public Guid EditorId { get; set; }

        public string Url { get; set; }

        public string Title { get; set; }

        public virtual DateTime? PublishedAt { get; set; }

        public virtual NewsEditor? Editor { get; set; }

        public virtual NewsSubTitle? SubTitle { get; set; }

        public virtual NewsPicture? Picture { get; set; }

        public virtual NewsDescription? Description { get; set; }
    }
}