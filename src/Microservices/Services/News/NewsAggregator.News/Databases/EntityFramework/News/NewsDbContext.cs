﻿using Microsoft.EntityFrameworkCore;
using NewsAggregator.Domain.Infrastructure.Databases;
using NewsAggregator.Domain.Infrastructure.Databases.Transactions;
using NewsAggregator.Infrastructure.Databases.EntityFramework.Transactions;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Extensions;

namespace NewsAggregator.News.Databases.EntityFramework.News
{
    public class NewsDbContext : DbContext, IUnitOfWork
    {
        public DbSet<Entities.News> News { get; set; }

        public DbSet<NewsDescription> NewsDescriptions { get; set; }

        public DbSet<NewsEditor> NewsEditors { get; set; }

        public DbSet<NewsParseEditorSettings> NewsParseEditorSettings { get; set; }

        public DbSet<NewsParseError> NewsParseErrors { get; set; }

        public DbSet<NewsParsePictureSettings> NewsParsePictureSettings { get; set; }

        public DbSet<NewsParsePublishedAtSettings> NewsParsePublishedAtSettings { get; set; }

        public DbSet<NewsParsePublishedAtSettingsFormat> NewsParsePublishedAtSettingsFormats { get; set; }

        public DbSet<NewsParseSettings> NewsParseSettings { get; set; }

        public DbSet<NewsParseSubTitleSettings> NewsParseSubTitleSettings { get; set; }

        public DbSet<NewsPicture> NewsPictures { get; set; }

        public DbSet<NewsSearchSettings> NewsSearchSettings { get; set; }

        public DbSet<NewsSource> NewsSources { get; set; }

        public DbSet<NewsSourceLogo> NewsSourceLogos { get; set; }

        public DbSet<NewsSubTitle> NewsSubTitles { get; set; }

        public NewsDbContext(DbContextOptions options) : base(options)
        {

        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public async Task<IDatabaseTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;

            return new EntityFrameworkDatabaseTransaction(this);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.AddNewsSources();

            modelBuilder.Entity<Entities.News>()
                .HasIndex(news => news.Url);

            modelBuilder.Entity<Entities.News>()
                .HasIndex(news => news.Title);

            modelBuilder.Entity<Entities.News>()
                .HasIndex(news => news.PublishedAt);

            modelBuilder.Entity<Entities.News>()
                .HasOne(news => news.SubTitle)
                    .WithOne(subTitle => subTitle.News)
                        .HasForeignKey<NewsSubTitle>(subTitle => subTitle.NewsId);

            modelBuilder.Entity<Entities.News>()
                .HasOne(news => news.Picture)
                    .WithOne(picture => picture.News)
                        .HasForeignKey<NewsPicture>(picture => picture.NewsId);

            modelBuilder.Entity<Entities.News>()
                .HasOne(news => news.Description)
                    .WithOne(description => description.News)
                        .HasForeignKey<NewsDescription>(description => description.NewsId);

            modelBuilder.Entity<NewsEditor>()
                .HasIndex(editor => editor.Name);

            modelBuilder.Entity<NewsEditor>()
                .HasMany(editor => editor.News)
                    .WithOne(news => news.Editor)
                        .HasForeignKey(news => news.EditorId);

            modelBuilder.Entity<NewsParseError>()
                .HasIndex(error => error.NewsUrl);

            modelBuilder.Entity<NewsParseError>()
                .HasIndex(error => error.CreatedAt);

            modelBuilder.Entity<NewsParsePublishedAtSettings>()
                .HasMany(settings => settings.Formats)
                    .WithOne(format => format.Settings)
                        .HasForeignKey(format => format.NewsParsePublishedAtSettingsId);

            modelBuilder.Entity<NewsParseSettings>()
                .HasOne(settings => settings.ParseEditorSettings)
                    .WithOne(editorSettings => editorSettings.ParseSettings)
                        .HasForeignKey<NewsParseEditorSettings>(editorSettings => editorSettings.ParseSettingsId);

            modelBuilder.Entity<NewsParseSettings>()
                .HasOne(settings => settings.ParsePictureSettings)
                    .WithOne(pictureSettings => pictureSettings.ParseSettings)
                        .HasForeignKey<NewsParsePictureSettings>(pictureSettings => pictureSettings.ParseSettingsId);

            modelBuilder.Entity<NewsParseSettings>()
                .HasOne(settings => settings.ParseSubTitleSettings)
                    .WithOne(subTitleSettings => subTitleSettings.ParseSettings)
                        .HasForeignKey<NewsParseSubTitleSettings>(subTitleSettings => subTitleSettings.ParseSettingsId);

            modelBuilder.Entity<NewsParseSettings>()
                .HasOne(settings => settings.ParsePublishedAtSettings)
                    .WithOne(publishedAtSettings => publishedAtSettings.ParseSettings)
                        .HasForeignKey<NewsParsePublishedAtSettings>(publishedAtSettings => publishedAtSettings.ParseSettingsId);

            modelBuilder.Entity<NewsSource>()
                .HasIndex(source => source.Title);

            modelBuilder.Entity<NewsSource>()
                .HasIndex(source => source.SiteUrl);

            modelBuilder.Entity<NewsSource>()
                .HasIndex(source => source.IsEnabled);

            modelBuilder.Entity<NewsSource>()
                .HasOne(source => source.Logo)
                    .WithOne(logo => logo.Source)
                        .HasForeignKey<NewsSourceLogo>(logo => logo.SourceId);

            modelBuilder.Entity<NewsSource>()
                .HasOne(source => source.ParseSettings)
                    .WithOne(parseSettings => parseSettings.Source)
                        .HasForeignKey<NewsParseSettings>(parseSettings => parseSettings.SourceId);

            modelBuilder.Entity<NewsSource>()
                .HasOne(source => source.SearchSettings)
                    .WithOne(searchSettings => searchSettings.Source)
                        .HasForeignKey<NewsSearchSettings>(searchSettings => searchSettings.SourceId);

            modelBuilder.Entity<NewsSource>()
                .HasMany(source => source.Editors)
                    .WithOne(editor => editor.Source)
                        .HasForeignKey(editor => editor.SourceId);
        }
    }
}
