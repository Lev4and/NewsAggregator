using Microsoft.EntityFrameworkCore;
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

        public DbSet<NewsHtmlDescription> NewsHtmlDescriptions { get; set; }

        public DbSet<NewsEditor> NewsEditors { get; set; }

        public DbSet<NewsParseEditorSettings> NewsParseEditorSettings { get; set; }

        public DbSet<NewsParseError> NewsParseErrors { get; set; }

        public DbSet<NewsParseModifiedAtSettings> NewsParseModifiedAtSettings { get; set; }

        public DbSet<NewsParseModifiedAtSettingsFormat> NewsParseModifiedAtSettingsFormats { get; set; }

        public DbSet<NewsParseNeed> NewsParseNeeds { get; set; }

        public DbSet<NewsParseNetworkError> NewsParseNetworkErrors { get; set; }

        public DbSet<NewsParsePictureSettings> NewsParsePictureSettings { get; set; }

        public DbSet<NewsParsePublishedAtSettings> NewsParsePublishedAtSettings { get; set; }

        public DbSet<NewsParsePublishedAtSettingsFormat> NewsParsePublishedAtSettingsFormats { get; set; }

        public DbSet<NewsParseSettings> NewsParseSettings { get; set; }

        public DbSet<NewsParseSubTitleSettings> NewsParseSubTitleSettings { get; set; }

        public DbSet<NewsParseVideoSettings> NewsParseVideoSettings { get; set; }

        public DbSet<NewsPicture> NewsPictures { get; set; }

        public DbSet<NewsSearchSettings> NewsSearchSettings { get; set; }

        public DbSet<NewsSource> NewsSources { get; set; }

        public DbSet<NewsSourceLogo> NewsSourceLogos { get; set; }

        public DbSet<NewsSubTitle> NewsSubTitles { get; set; }

        public DbSet<NewsTextDescription> NewsTextDescriptions { get; set; }

        public DbSet<NewsVideo> NewsVideos { get; set; }

        public NewsDbContext(DbContextOptions options) : base(options)
        {

        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public Task<IDatabaseTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult<IDatabaseTransaction>(new EntityFrameworkDatabaseTransaction(this));
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
                .HasIndex(news => news.ModifiedAt);

            modelBuilder.Entity<Entities.News>()
                .HasIndex(news => news.ParsedAt);

            modelBuilder.Entity<Entities.News>()
                .HasIndex(news => news.AddedAt);

            modelBuilder.Entity<Entities.News>()
                .HasOne(news => news.SubTitle)
                    .WithOne(subTitle => subTitle.News)
                        .HasForeignKey<NewsSubTitle>(subTitle => subTitle.NewsId);

            modelBuilder.Entity<Entities.News>()
                .HasOne(news => news.Picture)
                    .WithOne(picture => picture.News)
                        .HasForeignKey<NewsPicture>(picture => picture.NewsId);

            modelBuilder.Entity<Entities.News>()
                .HasOne(news => news.Video)
                    .WithOne(video => video.News)
                        .HasForeignKey<NewsVideo>(video => video.NewsId);

            modelBuilder.Entity<Entities.News>()
                .HasOne(news => news.HtmlDescription)
                    .WithOne(description => description.News)
                        .HasForeignKey<NewsHtmlDescription>(description => description.NewsId);

            modelBuilder.Entity<Entities.News>()
                .HasOne(news => news.TextDescription)
                    .WithOne(description => description.News)
                        .HasForeignKey<NewsTextDescription>(description => description.NewsId);

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

            modelBuilder.Entity<NewsParseModifiedAtSettings>()
                .HasMany(settings => settings.Formats)
                    .WithOne(format => format.Settings)
                        .HasForeignKey(format => format.NewsParseModifiedAtSettingsId);

            modelBuilder.Entity<NewsParseNeed>()
                .HasIndex(error => error.NewsUrl);

            modelBuilder.Entity<NewsParseNetworkError>()
                .HasIndex(error => error.NewsUrl);

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
                .HasOne(settings => settings.ParseVideoSettings)
                    .WithOne(videoSettings => videoSettings.ParseSettings)
                        .HasForeignKey<NewsParseVideoSettings>(videoSettings => videoSettings.ParseSettingsId);

            modelBuilder.Entity<NewsParseSettings>()
                .HasOne(settings => settings.ParseSubTitleSettings)
                    .WithOne(subTitleSettings => subTitleSettings.ParseSettings)
                        .HasForeignKey<NewsParseSubTitleSettings>(subTitleSettings => subTitleSettings.ParseSettingsId);

            modelBuilder.Entity<NewsParseSettings>()
                .HasOne(settings => settings.ParsePublishedAtSettings)
                    .WithOne(publishedAtSettings => publishedAtSettings.ParseSettings)
                        .HasForeignKey<NewsParsePublishedAtSettings>(publishedAtSettings => publishedAtSettings.ParseSettingsId);

            modelBuilder.Entity<NewsParseSettings>()
                .HasOne(settings => settings.ParseModifiedAtSettings)
                    .WithOne(modifiedAtSettings => modifiedAtSettings.ParseSettings)
                        .HasForeignKey<NewsParseModifiedAtSettings>(modifiedAtSettings => modifiedAtSettings.ParseSettingsId);

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
