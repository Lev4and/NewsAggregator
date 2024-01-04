﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewsAggregator.News.Databases.EntityFramework.News;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NewsAggregator.News.Databases.EntityFramework.News.Migrations
{
    [DbContext(typeof(NewsDbContext))]
    [Migration("20240104182349_InitDatabse")]
    partial class InitDatabse
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NewsAggregator.News.Databases.EntityFramework.News.Entities.News", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("EditorId")
                        .HasColumnType("uuid")
                        .HasColumnName("editor_id");

                    b.Property<DateTime?>("PublishedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("published_at");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("url");

                    b.HasKey("Id")
                        .HasName("pk_news");

                    b.HasIndex("EditorId")
                        .HasDatabaseName("ix_news_editor_id");

                    b.HasIndex("Url", "Title")
                        .HasDatabaseName("ix_news_url_title");

                    b.ToTable("news", (string)null);
                });

            modelBuilder.Entity("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsDescription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<Guid>("NewsId")
                        .HasColumnType("uuid")
                        .HasColumnName("news_id");

                    b.HasKey("Id")
                        .HasName("pk_news_descriptions");

                    b.HasIndex("NewsId")
                        .IsUnique()
                        .HasDatabaseName("ix_news_descriptions_news_id");

                    b.ToTable("news_descriptions", (string)null);
                });

            modelBuilder.Entity("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsEditor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<Guid>("SourceId")
                        .HasColumnType("uuid")
                        .HasColumnName("source_id");

                    b.HasKey("Id")
                        .HasName("pk_news_editors");

                    b.HasIndex("Name")
                        .HasDatabaseName("ix_news_editors_name");

                    b.HasIndex("SourceId")
                        .HasDatabaseName("ix_news_editors_source_id");

                    b.ToTable("news_editors", (string)null);
                });

            modelBuilder.Entity("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsParseEditorSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("NameXPath")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name_x_path");

                    b.Property<Guid>("ParseSettingsId")
                        .HasColumnType("uuid")
                        .HasColumnName("parse_settings_id");

                    b.HasKey("Id")
                        .HasName("pk_news_parse_editor_settings");

                    b.HasIndex("ParseSettingsId")
                        .IsUnique()
                        .HasDatabaseName("ix_news_parse_editor_settings_parse_settings_id");

                    b.ToTable("news_parse_editor_settings", (string)null);
                });

            modelBuilder.Entity("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsParsePictureSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("ParseSettingsId")
                        .HasColumnType("uuid")
                        .HasColumnName("parse_settings_id");

                    b.Property<string>("UrlXPath")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("url_x_path");

                    b.HasKey("Id")
                        .HasName("pk_news_parse_picture_settings");

                    b.HasIndex("ParseSettingsId")
                        .IsUnique()
                        .HasDatabaseName("ix_news_parse_picture_settings_parse_settings_id");

                    b.ToTable("news_parse_picture_settings", (string)null);
                });

            modelBuilder.Entity("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsParsePublishedAtSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("ParseSettingsId")
                        .HasColumnType("uuid")
                        .HasColumnName("parse_settings_id");

                    b.Property<string>("PublishedAtCultureInfo")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("published_at_culture_info");

                    b.Property<string>("PublishedAtFormat")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("published_at_format");

                    b.Property<string>("PublishedAtXPath")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("published_at_x_path");

                    b.HasKey("Id")
                        .HasName("pk_news_parse_published_at_settings");

                    b.HasIndex("ParseSettingsId")
                        .IsUnique()
                        .HasDatabaseName("ix_news_parse_published_at_settings_parse_settings_id");

                    b.ToTable("news_parse_published_at_settings", (string)null);
                });

            modelBuilder.Entity("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsParseSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("DescriptionXPath")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description_x_path");

                    b.Property<Guid>("SourceId")
                        .HasColumnType("uuid")
                        .HasColumnName("source_id");

                    b.Property<string>("TitleXPath")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title_x_path");

                    b.HasKey("Id")
                        .HasName("pk_news_parse_settings");

                    b.HasIndex("SourceId")
                        .IsUnique()
                        .HasDatabaseName("ix_news_parse_settings_source_id");

                    b.ToTable("news_parse_settings", (string)null);
                });

            modelBuilder.Entity("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsParseSubTitleSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("ParseSettingsId")
                        .HasColumnType("uuid")
                        .HasColumnName("parse_settings_id");

                    b.Property<string>("TitleXPath")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title_x_path");

                    b.HasKey("Id")
                        .HasName("pk_news_parse_sub_title_settings");

                    b.HasIndex("ParseSettingsId")
                        .IsUnique()
                        .HasDatabaseName("ix_news_parse_sub_title_settings_parse_settings_id");

                    b.ToTable("news_parse_sub_title_settings", (string)null);
                });

            modelBuilder.Entity("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsPicture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("NewsId")
                        .HasColumnType("uuid")
                        .HasColumnName("news_id");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("url");

                    b.HasKey("Id")
                        .HasName("pk_news_pictures");

                    b.HasIndex("NewsId")
                        .IsUnique()
                        .HasDatabaseName("ix_news_pictures_news_id");

                    b.ToTable("news_pictures", (string)null);
                });

            modelBuilder.Entity("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsSearchSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("NewsSiteUrl")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("news_site_url");

                    b.Property<string>("NewsUrlXPath")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("news_url_x_path");

                    b.Property<Guid>("SourceId")
                        .HasColumnType("uuid")
                        .HasColumnName("source_id");

                    b.HasKey("Id")
                        .HasName("pk_news_search_settings");

                    b.HasIndex("SourceId")
                        .IsUnique()
                        .HasDatabaseName("ix_news_search_settings_source_id");

                    b.ToTable("news_search_settings", (string)null);
                });

            modelBuilder.Entity("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsSource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("SiteUrl")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("site_url");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_news_sources");

                    b.HasIndex("Title", "SiteUrl")
                        .HasDatabaseName("ix_news_sources_title_site_url");

                    b.ToTable("news_sources", (string)null);
                });

            modelBuilder.Entity("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsSourceLogo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("SourceId")
                        .HasColumnType("uuid")
                        .HasColumnName("source_id");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("url");

                    b.HasKey("Id")
                        .HasName("pk_news_source_logos");

                    b.HasIndex("SourceId")
                        .IsUnique()
                        .HasDatabaseName("ix_news_source_logos_source_id");

                    b.ToTable("news_source_logos", (string)null);
                });

            modelBuilder.Entity("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsSubTitle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("NewsId")
                        .HasColumnType("uuid")
                        .HasColumnName("news_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_news_sub_titles");

                    b.HasIndex("NewsId")
                        .IsUnique()
                        .HasDatabaseName("ix_news_sub_titles_news_id");

                    b.HasIndex("Title")
                        .HasDatabaseName("ix_news_sub_titles_title");

                    b.ToTable("news_sub_titles", (string)null);
                });

            modelBuilder.Entity("NewsAggregator.News.Databases.EntityFramework.News.Entities.News", b =>
                {
                    b.HasOne("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsEditor", "Editor")
                        .WithMany("News")
                        .HasForeignKey("EditorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_news_news_editors_editor_id");

                    b.Navigation("Editor");
                });

            modelBuilder.Entity("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsDescription", b =>
                {
                    b.HasOne("NewsAggregator.News.Databases.EntityFramework.News.Entities.News", "News")
                        .WithOne("Description")
                        .HasForeignKey("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsDescription", "NewsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_news_descriptions_news_news_id");

                    b.Navigation("News");
                });

            modelBuilder.Entity("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsEditor", b =>
                {
                    b.HasOne("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsSource", "Source")
                        .WithMany("Editors")
                        .HasForeignKey("SourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_news_editors_news_sources_source_id");

                    b.Navigation("Source");
                });

            modelBuilder.Entity("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsParseEditorSettings", b =>
                {
                    b.HasOne("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsParseSettings", "ParseSettings")
                        .WithOne("ParseEditorSettings")
                        .HasForeignKey("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsParseEditorSettings", "ParseSettingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_news_parse_editor_settings_news_parse_settings_parse_settin");

                    b.Navigation("ParseSettings");
                });

            modelBuilder.Entity("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsParsePictureSettings", b =>
                {
                    b.HasOne("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsParseSettings", "ParseSettings")
                        .WithOne("ParsePictureSettings")
                        .HasForeignKey("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsParsePictureSettings", "ParseSettingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_news_parse_picture_settings_news_parse_settings_parse_setti");

                    b.Navigation("ParseSettings");
                });

            modelBuilder.Entity("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsParsePublishedAtSettings", b =>
                {
                    b.HasOne("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsParseSettings", "ParseSettings")
                        .WithOne("ParsePublishedAtSettings")
                        .HasForeignKey("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsParsePublishedAtSettings", "ParseSettingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_news_parse_published_at_settings_news_parse_settings_parse_");

                    b.Navigation("ParseSettings");
                });

            modelBuilder.Entity("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsParseSettings", b =>
                {
                    b.HasOne("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsSource", "Source")
                        .WithOne("ParseSettings")
                        .HasForeignKey("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsParseSettings", "SourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_news_parse_settings_news_sources_source_id");

                    b.Navigation("Source");
                });

            modelBuilder.Entity("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsParseSubTitleSettings", b =>
                {
                    b.HasOne("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsParseSettings", "ParseSettings")
                        .WithOne("ParseSubTitleSettings")
                        .HasForeignKey("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsParseSubTitleSettings", "ParseSettingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_news_parse_sub_title_settings_news_parse_settings_parse_set");

                    b.Navigation("ParseSettings");
                });

            modelBuilder.Entity("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsPicture", b =>
                {
                    b.HasOne("NewsAggregator.News.Databases.EntityFramework.News.Entities.News", "News")
                        .WithOne("Picture")
                        .HasForeignKey("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsPicture", "NewsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_news_pictures_news_news_id");

                    b.Navigation("News");
                });

            modelBuilder.Entity("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsSearchSettings", b =>
                {
                    b.HasOne("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsSource", "Source")
                        .WithOne("SearchSettings")
                        .HasForeignKey("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsSearchSettings", "SourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_news_search_settings_news_sources_source_id");

                    b.Navigation("Source");
                });

            modelBuilder.Entity("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsSourceLogo", b =>
                {
                    b.HasOne("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsSource", "Source")
                        .WithOne("Logo")
                        .HasForeignKey("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsSourceLogo", "SourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_news_source_logos_news_sources_source_id");

                    b.Navigation("Source");
                });

            modelBuilder.Entity("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsSubTitle", b =>
                {
                    b.HasOne("NewsAggregator.News.Databases.EntityFramework.News.Entities.News", "News")
                        .WithOne("SubTitle")
                        .HasForeignKey("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsSubTitle", "NewsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_news_sub_titles_news_news_id");

                    b.Navigation("News");
                });

            modelBuilder.Entity("NewsAggregator.News.Databases.EntityFramework.News.Entities.News", b =>
                {
                    b.Navigation("Description");

                    b.Navigation("Picture");

                    b.Navigation("SubTitle");
                });

            modelBuilder.Entity("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsEditor", b =>
                {
                    b.Navigation("News");
                });

            modelBuilder.Entity("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsParseSettings", b =>
                {
                    b.Navigation("ParseEditorSettings");

                    b.Navigation("ParsePictureSettings");

                    b.Navigation("ParsePublishedAtSettings");

                    b.Navigation("ParseSubTitleSettings");
                });

            modelBuilder.Entity("NewsAggregator.News.Databases.EntityFramework.News.Entities.NewsSource", b =>
                {
                    b.Navigation("Editors");

                    b.Navigation("Logo");

                    b.Navigation("ParseSettings");

                    b.Navigation("SearchSettings");
                });
#pragma warning restore 612, 618
        }
    }
}
