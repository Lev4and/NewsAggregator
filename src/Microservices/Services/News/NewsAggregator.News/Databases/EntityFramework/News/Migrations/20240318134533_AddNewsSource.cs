using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NewsAggregator.News.Databases.EntityFramework.News.Migrations
{
    /// <inheritdoc />
    public partial class AddNewsSource : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "news_sources",
                keyColumn: "id",
                keyValue: new Guid("3e1f065a-c135-4429-941e-d870886b4147"),
                column: "title",
                value: "Sports.ru");

            migrationBuilder.InsertData(
                table: "news_sources",
                columns: new[] { "id", "is_enabled", "is_system", "site_url", "title" },
                values: new object[] { new Guid("1f913a9a-4e5a-4925-89c1-51e985f63e9d"), true, true, "https://www.huffpost.com/", "HuffPost" });

            migrationBuilder.InsertData(
                table: "news_parse_settings",
                columns: new[] { "id", "html_description_x_path", "source_id", "text_description_x_path", "title_x_path" },
                values: new object[] { new Guid("32b2600c-03b7-4d2d-ace8-77b11e1a5041"), "//section[contains(@class, 'entry__content-list js-entry-content')]/*[not(contains(@class, 'cli-embed--header-media')) and not(contains(@class, 'cli-support-huffpost'))]", new Guid("1f913a9a-4e5a-4925-89c1-51e985f63e9d"), "//section[contains(@class, 'entry__content-list js-entry-content')]/*[not(contains(@class, 'cli-embed--header-media')) and not(contains(@class, 'cli-support-huffpost'))]/p//text()", "//meta[@property='og:title']/@content" });

            migrationBuilder.InsertData(
                table: "news_search_settings",
                columns: new[] { "id", "news_site_url", "news_url_x_path", "source_id" },
                values: new object[] { new Guid("d54003f4-dab6-4218-a59d-7374ded91cce"), "https://www.huffpost.com/", "//a[contains(@href, '/entry/')]/@href", new Guid("1f913a9a-4e5a-4925-89c1-51e985f63e9d") });

            migrationBuilder.InsertData(
                table: "news_source_logos",
                columns: new[] { "id", "original", "small", "source_id" },
                values: new object[] { new Guid("aaf79c06-980f-4d3c-9d89-0281ccfecc70"), "https://www.huffpost.com/favicon.ico", "https://www.huffpost.com/favicon.ico", new Guid("1f913a9a-4e5a-4925-89c1-51e985f63e9d") });

            migrationBuilder.InsertData(
                table: "news_source_tags",
                columns: new[] { "id", "source_id", "tag_id" },
                values: new object[,]
                {
                    { new Guid("35a38041-59d7-4924-ad4a-92ac14988e54"), new Guid("1f913a9a-4e5a-4925-89c1-51e985f63e9d"), new Guid("8e8ec992-5b4b-43d9-b290-73fbfcd8a32e") },
                    { new Guid("371d2b27-1b5f-4f87-bb12-3e3b11651b44"), new Guid("1f913a9a-4e5a-4925-89c1-51e985f63e9d"), new Guid("302d7e19-c80f-4e1a-8877-3e9b17f9baeb") },
                    { new Guid("9f4fd158-51d1-4aa9-ad41-0d59d26ac38f"), new Guid("1f913a9a-4e5a-4925-89c1-51e985f63e9d"), new Guid("f06891c5-6324-4bab-b836-a78a4d2c603d") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_editor_settings",
                columns: new[] { "id", "is_required", "name_x_path", "parse_settings_id" },
                values: new object[] { new Guid("10957082-a831-4ffb-86e1-379efef08111"), false, "//header//div[contains(@class, 'bottom-header')]//div[contains(@class, 'author-list')]//a[contains(@class, 'headshot__link') and @data-vars-subunit-name='author']/@data-vars-item-name", new Guid("32b2600c-03b7-4d2d-ace8-77b11e1a5041") });

            migrationBuilder.InsertData(
                table: "news_parse_modified_at_settings",
                columns: new[] { "id", "is_required", "modified_at_culture_info", "modified_at_time_zone_info_id", "modified_at_x_path", "parse_settings_id" },
                values: new object[] { new Guid("50257fdd-fcc6-4a8e-822c-4834d0f1d762"), false, "en-US", null, "//meta[@property='article:modified_time']/@content", new Guid("32b2600c-03b7-4d2d-ace8-77b11e1a5041") });

            migrationBuilder.InsertData(
                table: "news_parse_picture_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[] { new Guid("8c523334-f94b-4c87-ae3d-a6d749bc29b9"), false, new Guid("32b2600c-03b7-4d2d-ace8-77b11e1a5041"), "//meta[@property='og:image']/@content" });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "published_at_culture_info", "published_at_time_zone_info_id", "published_at_x_path" },
                values: new object[] { new Guid("74a87f1a-0325-4690-8c87-8ba4d24e078b"), true, new Guid("32b2600c-03b7-4d2d-ace8-77b11e1a5041"), "en-US", null, "//meta[@property='article:published_time']/@content" });

            migrationBuilder.InsertData(
                table: "news_parse_sub_title_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "title_x_path" },
                values: new object[] { new Guid("82bb1ac2-5fbb-4240-bca2-5417604ec562"), false, new Guid("32b2600c-03b7-4d2d-ace8-77b11e1a5041"), "//meta[@property='og:description']/@content" });

            migrationBuilder.InsertData(
                table: "news_parse_modified_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_modified_at_settings_id" },
                values: new object[] { new Guid("db537dea-c0ab-426c-a394-10231d9c8a29"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("50257fdd-fcc6-4a8e-822c-4834d0f1d762") });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_published_at_settings_id" },
                values: new object[] { new Guid("a77f62ce-bb2c-41a7-8a35-f0aa8147e4de"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("74a87f1a-0325-4690-8c87-8ba4d24e078b") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "news_parse_editor_settings",
                keyColumn: "id",
                keyValue: new Guid("10957082-a831-4ffb-86e1-379efef08111"));

            migrationBuilder.DeleteData(
                table: "news_parse_modified_at_settings_formats",
                keyColumn: "id",
                keyValue: new Guid("db537dea-c0ab-426c-a394-10231d9c8a29"));

            migrationBuilder.DeleteData(
                table: "news_parse_picture_settings",
                keyColumn: "id",
                keyValue: new Guid("8c523334-f94b-4c87-ae3d-a6d749bc29b9"));

            migrationBuilder.DeleteData(
                table: "news_parse_published_at_settings_formats",
                keyColumn: "id",
                keyValue: new Guid("a77f62ce-bb2c-41a7-8a35-f0aa8147e4de"));

            migrationBuilder.DeleteData(
                table: "news_parse_sub_title_settings",
                keyColumn: "id",
                keyValue: new Guid("82bb1ac2-5fbb-4240-bca2-5417604ec562"));

            migrationBuilder.DeleteData(
                table: "news_search_settings",
                keyColumn: "id",
                keyValue: new Guid("d54003f4-dab6-4218-a59d-7374ded91cce"));

            migrationBuilder.DeleteData(
                table: "news_source_logos",
                keyColumn: "id",
                keyValue: new Guid("aaf79c06-980f-4d3c-9d89-0281ccfecc70"));

            migrationBuilder.DeleteData(
                table: "news_source_tags",
                keyColumn: "id",
                keyValue: new Guid("35a38041-59d7-4924-ad4a-92ac14988e54"));

            migrationBuilder.DeleteData(
                table: "news_source_tags",
                keyColumn: "id",
                keyValue: new Guid("371d2b27-1b5f-4f87-bb12-3e3b11651b44"));

            migrationBuilder.DeleteData(
                table: "news_source_tags",
                keyColumn: "id",
                keyValue: new Guid("9f4fd158-51d1-4aa9-ad41-0d59d26ac38f"));

            migrationBuilder.DeleteData(
                table: "news_parse_modified_at_settings",
                keyColumn: "id",
                keyValue: new Guid("50257fdd-fcc6-4a8e-822c-4834d0f1d762"));

            migrationBuilder.DeleteData(
                table: "news_parse_published_at_settings",
                keyColumn: "id",
                keyValue: new Guid("74a87f1a-0325-4690-8c87-8ba4d24e078b"));

            migrationBuilder.DeleteData(
                table: "news_parse_settings",
                keyColumn: "id",
                keyValue: new Guid("32b2600c-03b7-4d2d-ace8-77b11e1a5041"));

            migrationBuilder.DeleteData(
                table: "news_sources",
                keyColumn: "id",
                keyValue: new Guid("1f913a9a-4e5a-4925-89c1-51e985f63e9d"));

            migrationBuilder.UpdateData(
                table: "news_sources",
                keyColumn: "id",
                keyValue: new Guid("3e1f065a-c135-4429-941e-d870886b4147"),
                column: "title",
                value: "Storts.ru");
        }
    }
}
