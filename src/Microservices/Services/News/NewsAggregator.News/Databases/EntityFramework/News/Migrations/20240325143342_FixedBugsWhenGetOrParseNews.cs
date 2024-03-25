using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsAggregator.News.Databases.EntityFramework.News.Migrations
{
    /// <inheritdoc />
    public partial class FixedBugsWhenGetOrParseNews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "news_parse_modified_at_settings",
                columns: new[] { "id", "is_required", "modified_at_culture_info", "modified_at_time_zone_info_id", "modified_at_x_path", "parse_settings_id" },
                values: new object[] { new Guid("46cff913-17ee-438f-8f82-778002dbdcac"), false, "ru-RU", "Russian Standard Time", "//meta[@name='article:modified_time']/@content", new Guid("e8ea5810-3cc4-46dd-84d7-eb7b5cbf3f3b") });

            migrationBuilder.UpdateData(
                table: "news_parse_published_at_settings",
                keyColumn: "id",
                keyValue: new Guid("21890de7-31ad-4c9e-a749-05f565d45905"),
                column: "published_at_x_path",
                value: "//meta[@name='article:published_time']/@content");

            migrationBuilder.UpdateData(
                table: "news_parse_published_at_settings_formats",
                keyColumn: "id",
                keyValue: new Guid("098793a2-d99d-494b-afba-e727e26214b7"),
                column: "format",
                value: "yyyy-MM-ddTHH:mm:ss\"+0300\"");

            migrationBuilder.UpdateData(
                table: "news_search_settings",
                keyColumn: "id",
                keyValue: new Guid("92324d14-49b0-409a-96e1-6a37a8691c6e"),
                column: "news_url_x_path",
                value: "//section//ul/li//div[@class]/div[not(@class)]/a[starts-with(@href, '/') and not(contains(@href, 'all.comments.html')) and not(contains(@href, '?'))]/@href");

            migrationBuilder.InsertData(
                table: "news_parse_modified_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_modified_at_settings_id" },
                values: new object[] { new Guid("a6d9eabc-e130-4d14-9cdf-1d0374e5fc6e"), "yyyy-MM-ddTHH:mm:ss\"+0300\"", new Guid("46cff913-17ee-438f-8f82-778002dbdcac") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "news_parse_modified_at_settings_formats",
                keyColumn: "id",
                keyValue: new Guid("a6d9eabc-e130-4d14-9cdf-1d0374e5fc6e"));

            migrationBuilder.DeleteData(
                table: "news_parse_modified_at_settings",
                keyColumn: "id",
                keyValue: new Guid("46cff913-17ee-438f-8f82-778002dbdcac"));

            migrationBuilder.UpdateData(
                table: "news_parse_published_at_settings",
                keyColumn: "id",
                keyValue: new Guid("21890de7-31ad-4c9e-a749-05f565d45905"),
                column: "published_at_x_path",
                value: "//div[@class='article_top']//div[@class='date']//time/text()");

            migrationBuilder.UpdateData(
                table: "news_parse_published_at_settings_formats",
                keyColumn: "id",
                keyValue: new Guid("098793a2-d99d-494b-afba-e727e26214b7"),
                column: "format",
                value: "dd.MM.yyyy HH:mm");

            migrationBuilder.UpdateData(
                table: "news_search_settings",
                keyColumn: "id",
                keyValue: new Guid("92324d14-49b0-409a-96e1-6a37a8691c6e"),
                column: "news_url_x_path",
                value: "//section//ul/li[@class='IBae3']//a[@class='IBd3']/@href");
        }
    }
}
