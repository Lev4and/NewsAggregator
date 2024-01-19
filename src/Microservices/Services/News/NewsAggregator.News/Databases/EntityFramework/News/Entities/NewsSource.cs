﻿using Microsoft.EntityFrameworkCore;
using NewsAggregator.Domain.Entities;

namespace NewsAggregator.News.Databases.EntityFramework.News.Entities
{
    [Index(nameof(Title), nameof(SiteUrl), nameof(IsEnabled))]
    public class NewsSource : EntityBase
    {
        public string Title { get; set; }

        public string SiteUrl { get; set; }

        public bool IsEnabled { get; set; }

        public virtual NewsSourceLogo? Logo { get; set; }

        public virtual NewsParseSettings? ParseSettings { get; set; }

        public virtual NewsSearchSettings? SearchSettings { get; set; }

        public virtual IReadOnlyCollection<NewsEditor>? Editors { get; set; }
    }
}
