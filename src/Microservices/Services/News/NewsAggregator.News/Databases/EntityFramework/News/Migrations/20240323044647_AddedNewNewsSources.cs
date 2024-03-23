using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NewsAggregator.News.Databases.EntityFramework.News.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewNewsSources : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "news_sources",
                columns: new[] { "id", "is_enabled", "is_system", "site_url", "title" },
                values: new object[,]
                {
                    { new Guid("7c0ac71c-0e8e-425b-ac26-424b152415f5"), true, true, "https://www.politico.com/", "POLITICO" },
                    { new Guid("e5afb99f-47ff-4822-89fa-2ff8859a5c42"), true, true, "https://www.foxnews.com/", "Fox News" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_settings",
                columns: new[] { "id", "html_description_x_path", "source_id", "text_description_x_path", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("00a974a4-e223-45fb-965e-97269039d94a"), "//div[@class='article-body']//div[contains(@class, 'paywall')]/*", new Guid("e5afb99f-47ff-4822-89fa-2ff8859a5c42"), "//div[@class='article-body']//div[contains(@class, 'paywall')]//p/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("1a5ca4c2-2984-4c52-9fa2-d7f564fd6add"), "//div[@class='sidebar-grid__content article__content']", new Guid("7c0ac71c-0e8e-425b-ac26-424b152415f5"), "//div[@class='sidebar-grid__content article__content']//text()", "//meta[@property='og:title']/@content" }
                });

            migrationBuilder.InsertData(
                table: "news_search_settings",
                columns: new[] { "id", "news_site_url", "news_url_x_path", "source_id" },
                values: new object[,]
                {
                    { new Guid("5ef6d413-2916-4259-b2e1-6e5dc36f8e2c"), "https://www.foxnews.com/", "//header[@class='info-header']/h3[@class='title']/a/@href", new Guid("e5afb99f-47ff-4822-89fa-2ff8859a5c42") },
                    { new Guid("93606f5a-dd33-4a66-8c13-d718d2082e07"), "https://www.politico.com/", "//a[starts-with(@href, 'https://www.politico.com/news/')]/@href", new Guid("7c0ac71c-0e8e-425b-ac26-424b152415f5") }
                });

            migrationBuilder.InsertData(
                table: "news_source_logos",
                columns: new[] { "id", "original", "small", "source_id" },
                values: new object[,]
                {
                    { new Guid("3cd265f4-637e-480c-8294-9d81d9027538"), "https://static.foxnews.com/static/orion/styles/img/fox-news/favicons/apple-touch-icon-180x180.png", "https://static.foxnews.com/static/orion/styles/img/fox-news/favicons/favicon-32x32.png", new Guid("e5afb99f-47ff-4822-89fa-2ff8859a5c42") },
                    { new Guid("cdfd8be8-f692-48f3-a06d-e290f20d92e2"), "https://www.politico.com/apple-touch-icon-180x180.png", "https://www.politico.com/favicon-32x32.png", new Guid("7c0ac71c-0e8e-425b-ac26-424b152415f5") }
                });

            migrationBuilder.InsertData(
                table: "news_source_tags",
                columns: new[] { "id", "source_id", "tag_id" },
                values: new object[,]
                {
                    { new Guid("0840963c-95b1-40c4-9806-a3f96a510b2f"), new Guid("e5afb99f-47ff-4822-89fa-2ff8859a5c42"), new Guid("8e8ec992-5b4b-43d9-b290-73fbfcd8a32e") },
                    { new Guid("291c690f-9a53-4ae0-9480-2475af09adeb"), new Guid("e5afb99f-47ff-4822-89fa-2ff8859a5c42"), new Guid("302d7e19-c80f-4e1a-8877-3e9b17f9baeb") },
                    { new Guid("48a9904d-be59-4aac-8abb-5959bbd10a36"), new Guid("e5afb99f-47ff-4822-89fa-2ff8859a5c42"), new Guid("f06891c5-6324-4bab-b836-a78a4d2c603d") },
                    { new Guid("526e62ee-b4d1-4575-ba8a-8ee1ba5a041c"), new Guid("e5afb99f-47ff-4822-89fa-2ff8859a5c42"), new Guid("ae20fd4f-a451-42cb-aae6-875d0bfacaa7") },
                    { new Guid("996ec670-045e-45e0-bb3b-d0218e36704d"), new Guid("7c0ac71c-0e8e-425b-ac26-424b152415f5"), new Guid("f06891c5-6324-4bab-b836-a78a4d2c603d") },
                    { new Guid("acc922e5-bf8f-4bd7-bc82-7e75d87bc245"), new Guid("7c0ac71c-0e8e-425b-ac26-424b152415f5"), new Guid("8e8ec992-5b4b-43d9-b290-73fbfcd8a32e") },
                    { new Guid("cc81438d-b3a7-44cb-bb91-7b8b01b2b700"), new Guid("7c0ac71c-0e8e-425b-ac26-424b152415f5"), new Guid("302d7e19-c80f-4e1a-8877-3e9b17f9baeb") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_editor_settings",
                columns: new[] { "id", "is_required", "name_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("cb8f6ea0-5566-4656-a109-c2daadc5b5a0"), false, "//meta[@name='dc.creator']/@content", new Guid("00a974a4-e223-45fb-965e-97269039d94a") },
                    { new Guid("eabe266c-ac67-4803-8901-6deb6edfa5e6"), false, "//div[@class='story-meta']//p[@class='story-meta__authors']/span[@class='vcard']/a/text()", new Guid("1a5ca4c2-2984-4c52-9fa2-d7f564fd6add") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_modified_at_settings",
                columns: new[] { "id", "is_required", "modified_at_culture_info", "modified_at_time_zone_info_id", "modified_at_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("48f6b66c-3b41-49fd-b4ec-d2d1e3ced579"), false, "en-US", null, "//meta[@name='dcterms.modified']/@content", new Guid("00a974a4-e223-45fb-965e-97269039d94a") },
                    { new Guid("ac1075c5-1536-4691-bc44-c67665d0e2e2"), false, "en-US", "Eastern Standard Time", "//div[@class='story-meta']//p[@class='story-meta__updated']/time/@datetime", new Guid("1a5ca4c2-2984-4c52-9fa2-d7f564fd6add") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_picture_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("e5f37d04-6aa1-4e5c-b850-387388d0c62e"), false, new Guid("00a974a4-e223-45fb-965e-97269039d94a"), "//meta[@property='og:image']/@content" },
                    { new Guid("eb0cb4fc-8982-465c-87a0-d5a83e2c579a"), false, new Guid("1a5ca4c2-2984-4c52-9fa2-d7f564fd6add"), "//meta[@property='og:image']/@content" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "published_at_culture_info", "published_at_time_zone_info_id", "published_at_x_path" },
                values: new object[,]
                {
                    { new Guid("21813794-9df2-4993-a696-a65ee04af666"), true, new Guid("00a974a4-e223-45fb-965e-97269039d94a"), "en-US", null, "//meta[@name='dcterms.created']/@content" },
                    { new Guid("2dfea686-66c2-4b59-86cf-01fdce1da6c5"), true, new Guid("1a5ca4c2-2984-4c52-9fa2-d7f564fd6add"), "en-US", "Eastern Standard Time", "//div[@class='story-meta']//p[@class='story-meta__timestamp']/time/@datetime" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_sub_title_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("ef3237fa-b43a-4deb-b9d1-2e0b64d98a2a"), false, new Guid("00a974a4-e223-45fb-965e-97269039d94a"), "//meta[@property='og:description']/@content" },
                    { new Guid("f7cd72a9-93c2-4f46-b76c-65cbe87a49ef"), false, new Guid("1a5ca4c2-2984-4c52-9fa2-d7f564fd6add"), "//meta[@property='og:description']/@content" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_modified_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_modified_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("1ae044f9-a228-41a3-a0c1-a708c760fe88"), "yyyy-MM-dd HH:mm:ss", new Guid("ac1075c5-1536-4691-bc44-c67665d0e2e2") },
                    { new Guid("adad19a0-95c1-40ee-a691-b4a8bcbf18b7"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("48f6b66c-3b41-49fd-b4ec-d2d1e3ced579") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_published_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("0ab06b9d-5327-4461-9493-a01ff9b37dfa"), "yyyy-MM-dd HH:mm:ss", new Guid("2dfea686-66c2-4b59-86cf-01fdce1da6c5") },
                    { new Guid("5c71bd20-8b52-4291-89a4-8a54bb2e374b"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("21813794-9df2-4993-a696-a65ee04af666") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "news_parse_editor_settings",
                keyColumn: "id",
                keyValue: new Guid("cb8f6ea0-5566-4656-a109-c2daadc5b5a0"));

            migrationBuilder.DeleteData(
                table: "news_parse_editor_settings",
                keyColumn: "id",
                keyValue: new Guid("eabe266c-ac67-4803-8901-6deb6edfa5e6"));

            migrationBuilder.DeleteData(
                table: "news_parse_modified_at_settings_formats",
                keyColumn: "id",
                keyValue: new Guid("1ae044f9-a228-41a3-a0c1-a708c760fe88"));

            migrationBuilder.DeleteData(
                table: "news_parse_modified_at_settings_formats",
                keyColumn: "id",
                keyValue: new Guid("adad19a0-95c1-40ee-a691-b4a8bcbf18b7"));

            migrationBuilder.DeleteData(
                table: "news_parse_picture_settings",
                keyColumn: "id",
                keyValue: new Guid("e5f37d04-6aa1-4e5c-b850-387388d0c62e"));

            migrationBuilder.DeleteData(
                table: "news_parse_picture_settings",
                keyColumn: "id",
                keyValue: new Guid("eb0cb4fc-8982-465c-87a0-d5a83e2c579a"));

            migrationBuilder.DeleteData(
                table: "news_parse_published_at_settings_formats",
                keyColumn: "id",
                keyValue: new Guid("0ab06b9d-5327-4461-9493-a01ff9b37dfa"));

            migrationBuilder.DeleteData(
                table: "news_parse_published_at_settings_formats",
                keyColumn: "id",
                keyValue: new Guid("5c71bd20-8b52-4291-89a4-8a54bb2e374b"));

            migrationBuilder.DeleteData(
                table: "news_parse_sub_title_settings",
                keyColumn: "id",
                keyValue: new Guid("ef3237fa-b43a-4deb-b9d1-2e0b64d98a2a"));

            migrationBuilder.DeleteData(
                table: "news_parse_sub_title_settings",
                keyColumn: "id",
                keyValue: new Guid("f7cd72a9-93c2-4f46-b76c-65cbe87a49ef"));

            migrationBuilder.DeleteData(
                table: "news_search_settings",
                keyColumn: "id",
                keyValue: new Guid("5ef6d413-2916-4259-b2e1-6e5dc36f8e2c"));

            migrationBuilder.DeleteData(
                table: "news_search_settings",
                keyColumn: "id",
                keyValue: new Guid("93606f5a-dd33-4a66-8c13-d718d2082e07"));

            migrationBuilder.DeleteData(
                table: "news_source_logos",
                keyColumn: "id",
                keyValue: new Guid("3cd265f4-637e-480c-8294-9d81d9027538"));

            migrationBuilder.DeleteData(
                table: "news_source_logos",
                keyColumn: "id",
                keyValue: new Guid("cdfd8be8-f692-48f3-a06d-e290f20d92e2"));

            migrationBuilder.DeleteData(
                table: "news_source_tags",
                keyColumn: "id",
                keyValue: new Guid("0840963c-95b1-40c4-9806-a3f96a510b2f"));

            migrationBuilder.DeleteData(
                table: "news_source_tags",
                keyColumn: "id",
                keyValue: new Guid("291c690f-9a53-4ae0-9480-2475af09adeb"));

            migrationBuilder.DeleteData(
                table: "news_source_tags",
                keyColumn: "id",
                keyValue: new Guid("48a9904d-be59-4aac-8abb-5959bbd10a36"));

            migrationBuilder.DeleteData(
                table: "news_source_tags",
                keyColumn: "id",
                keyValue: new Guid("526e62ee-b4d1-4575-ba8a-8ee1ba5a041c"));

            migrationBuilder.DeleteData(
                table: "news_source_tags",
                keyColumn: "id",
                keyValue: new Guid("996ec670-045e-45e0-bb3b-d0218e36704d"));

            migrationBuilder.DeleteData(
                table: "news_source_tags",
                keyColumn: "id",
                keyValue: new Guid("acc922e5-bf8f-4bd7-bc82-7e75d87bc245"));

            migrationBuilder.DeleteData(
                table: "news_source_tags",
                keyColumn: "id",
                keyValue: new Guid("cc81438d-b3a7-44cb-bb91-7b8b01b2b700"));

            migrationBuilder.DeleteData(
                table: "news_parse_modified_at_settings",
                keyColumn: "id",
                keyValue: new Guid("48f6b66c-3b41-49fd-b4ec-d2d1e3ced579"));

            migrationBuilder.DeleteData(
                table: "news_parse_modified_at_settings",
                keyColumn: "id",
                keyValue: new Guid("ac1075c5-1536-4691-bc44-c67665d0e2e2"));

            migrationBuilder.DeleteData(
                table: "news_parse_published_at_settings",
                keyColumn: "id",
                keyValue: new Guid("21813794-9df2-4993-a696-a65ee04af666"));

            migrationBuilder.DeleteData(
                table: "news_parse_published_at_settings",
                keyColumn: "id",
                keyValue: new Guid("2dfea686-66c2-4b59-86cf-01fdce1da6c5"));

            migrationBuilder.DeleteData(
                table: "news_parse_settings",
                keyColumn: "id",
                keyValue: new Guid("00a974a4-e223-45fb-965e-97269039d94a"));

            migrationBuilder.DeleteData(
                table: "news_parse_settings",
                keyColumn: "id",
                keyValue: new Guid("1a5ca4c2-2984-4c52-9fa2-d7f564fd6add"));

            migrationBuilder.DeleteData(
                table: "news_sources",
                keyColumn: "id",
                keyValue: new Guid("7c0ac71c-0e8e-425b-ac26-424b152415f5"));

            migrationBuilder.DeleteData(
                table: "news_sources",
                keyColumn: "id",
                keyValue: new Guid("e5afb99f-47ff-4822-89fa-2ff8859a5c42"));
        }
    }
}
