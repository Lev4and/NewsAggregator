﻿using Microsoft.EntityFrameworkCore;
using NewsAggregator.Domain.Entities;

namespace NewsAggregator.News.Databases.EntityFramework.News.Entities
{
    [Index(nameof(Name))]
    public class NewsEditor : EntityBase
    {
        public Guid SourceId { get; set; }

        public string? Name { get; set; }

        public virtual NewsSource? Source { get; set; }

        public virtual IReadOnlyCollection<News>? News { get; set; }
    }
}
