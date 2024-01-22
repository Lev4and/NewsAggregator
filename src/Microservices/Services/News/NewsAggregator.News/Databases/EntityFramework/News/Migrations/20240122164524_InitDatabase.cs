using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NewsAggregator.News.Databases.EntityFramework.News.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "news_parse_errors",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    news_url = table.Column<string>(type: "text", nullable: false),
                    message = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_parse_errors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "news_sources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    site_url = table.Column<string>(type: "text", nullable: false),
                    is_enabled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_sources", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "news_editors",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    source_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_editors", x => x.id);
                    table.ForeignKey(
                        name: "fk_news_editors_news_sources_source_id",
                        column: x => x.source_id,
                        principalTable: "news_sources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "news_parse_settings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    source_id = table.Column<Guid>(type: "uuid", nullable: false),
                    title_x_path = table.Column<string>(type: "text", nullable: false),
                    description_x_path = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_parse_settings", x => x.id);
                    table.ForeignKey(
                        name: "fk_news_parse_settings_news_sources_source_id",
                        column: x => x.source_id,
                        principalTable: "news_sources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "news_search_settings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    source_id = table.Column<Guid>(type: "uuid", nullable: false),
                    news_site_url = table.Column<string>(type: "text", nullable: false),
                    news_url_x_path = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_search_settings", x => x.id);
                    table.ForeignKey(
                        name: "fk_news_search_settings_news_sources_source_id",
                        column: x => x.source_id,
                        principalTable: "news_sources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "news_source_logos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    source_id = table.Column<Guid>(type: "uuid", nullable: false),
                    url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_source_logos", x => x.id);
                    table.ForeignKey(
                        name: "fk_news_source_logos_news_sources_source_id",
                        column: x => x.source_id,
                        principalTable: "news_sources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "news",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    editor_id = table.Column<Guid>(type: "uuid", nullable: false),
                    url = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    published_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news", x => x.id);
                    table.ForeignKey(
                        name: "fk_news_news_editors_editor_id",
                        column: x => x.editor_id,
                        principalTable: "news_editors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "news_parse_editor_settings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    parse_settings_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name_x_path = table.Column<string>(type: "text", nullable: false),
                    is_required = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_parse_editor_settings", x => x.id);
                    table.ForeignKey(
                        name: "fk_news_parse_editor_settings_news_parse_settings_parse_settin",
                        column: x => x.parse_settings_id,
                        principalTable: "news_parse_settings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "news_parse_picture_settings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    parse_settings_id = table.Column<Guid>(type: "uuid", nullable: false),
                    url_x_path = table.Column<string>(type: "text", nullable: false),
                    is_required = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_parse_picture_settings", x => x.id);
                    table.ForeignKey(
                        name: "fk_news_parse_picture_settings_news_parse_settings_parse_setti",
                        column: x => x.parse_settings_id,
                        principalTable: "news_parse_settings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "news_parse_published_at_settings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    parse_settings_id = table.Column<Guid>(type: "uuid", nullable: false),
                    published_at_x_path = table.Column<string>(type: "text", nullable: false),
                    published_at_culture_info = table.Column<string>(type: "text", nullable: false),
                    published_at_time_zone_info_id = table.Column<string>(type: "text", nullable: true),
                    is_required = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_parse_published_at_settings", x => x.id);
                    table.ForeignKey(
                        name: "fk_news_parse_published_at_settings_news_parse_settings_parse_",
                        column: x => x.parse_settings_id,
                        principalTable: "news_parse_settings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "news_parse_sub_title_settings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    parse_settings_id = table.Column<Guid>(type: "uuid", nullable: false),
                    title_x_path = table.Column<string>(type: "text", nullable: false),
                    is_required = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_parse_sub_title_settings", x => x.id);
                    table.ForeignKey(
                        name: "fk_news_parse_sub_title_settings_news_parse_settings_parse_set",
                        column: x => x.parse_settings_id,
                        principalTable: "news_parse_settings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "news_descriptions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    news_id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_descriptions", x => x.id);
                    table.ForeignKey(
                        name: "fk_news_descriptions_news_news_id",
                        column: x => x.news_id,
                        principalTable: "news",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "news_pictures",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    news_id = table.Column<Guid>(type: "uuid", nullable: false),
                    url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_pictures", x => x.id);
                    table.ForeignKey(
                        name: "fk_news_pictures_news_news_id",
                        column: x => x.news_id,
                        principalTable: "news",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "news_sub_titles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    news_id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_sub_titles", x => x.id);
                    table.ForeignKey(
                        name: "fk_news_sub_titles_news_news_id",
                        column: x => x.news_id,
                        principalTable: "news",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "news_parse_published_at_settings_formats",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    news_parse_published_at_settings_id = table.Column<Guid>(type: "uuid", nullable: false),
                    format = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_parse_published_at_settings_formats", x => x.id);
                    table.ForeignKey(
                        name: "fk_news_parse_published_at_settings_formats_news_parse_publish",
                        column: x => x.news_parse_published_at_settings_id,
                        principalTable: "news_parse_published_at_settings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "news_sources",
                columns: new[] { "id", "is_enabled", "site_url", "title" },
                values: new object[,]
                {
                    { new Guid("05fc1676-4ea1-4528-9936-d094d78b26af"), true, "https://www.interfax.ru/", "Интерфакс" },
                    { new Guid("0785e708-60c3-4bae-9d07-8d604d5898cb"), true, "https://lenta.ru/", "Лента.Ру" },
                    { new Guid("170e2f08-1272-4c8c-b70e-7c162636cf6d"), true, "https://www.m24.ru/", "Москва 24" },
                    { new Guid("1917d8b5-5eaf-4fc6-b192-bccb348eb855"), true, "https://svpressa.ru/", "СвободнаяПресса" },
                    { new Guid("1d06403d-f2bd-4f8d-bc94-7ed5593c0e84"), true, "https://www.sports.ru/", "Storts.ru" },
                    { new Guid("2771015a-9428-47a8-ab75-945663832c95"), true, "https://ria.ru/", "РИА Новости" },
                    { new Guid("4c7ec2da-832d-4860-9928-78ec3e39f37a"), true, "https://www.rbc.ru/", "РБК" },
                    { new Guid("6ac053ae-cc7e-4cdd-9347-f2e8ee895471"), true, "https://3dnews.ru/", "3Dnews.ru" },
                    { new Guid("7dd7886e-182f-42e0-b114-4d4719180e74"), true, "https://www.gazeta.ru/", "Газета.Ru" },
                    { new Guid("8c49701f-a226-46ba-ad92-0a3f3636ca4d"), true, "https://www.kommersant.ru/", "Коммерсантъ" },
                    { new Guid("97b59d7d-020c-4529-92dc-1b47e65abe28"), true, "https://www.pravda.ru/", "Правда.ру" },
                    { new Guid("9a16aef7-c5c5-471a-9a4c-6d00282711f1"), true, "https://www.belta.by/", "БелТА" },
                    { new Guid("9c9c7f2b-596f-4e17-af4e-94f9d1a83457"), true, "https://iz.ru/", "Известия" },
                    { new Guid("a737beb9-0696-406d-919b-4734cfc8a548"), true, "https://www.championat.com/", "Чемпионат.com" },
                    { new Guid("ab7b1a7d-0dbc-4cac-84a1-a62f6de25aaa"), true, "https://tass.ru/", "ТАСС" },
                    { new Guid("b671a6cd-0644-4129-bb41-896332f8d900"), false, "https://ixbt.games/", "iXBT.games" },
                    { new Guid("b789b5bf-35f4-41b8-a665-e71da2cdd52d"), true, "https://life.ru/", "Life" },
                    { new Guid("c4dfafc1-8cfc-43f1-80e1-468a83385395"), true, "https://aif.ru/", "Аргументы и факты" },
                    { new Guid("c7bc5f12-4fb1-4599-9f71-867540631416"), false, "https://tsargrad.tv/", "Царьград" },
                    { new Guid("d8352a4a-e5b3-4d2a-b83d-fb552e7099ea"), true, "https://russian.rt.com/", "RT на русском" },
                    { new Guid("e82c62f4-eb64-4c6f-a566-5e1815683926"), true, "https://www.ixbt.com/", "iXBT.com" },
                    { new Guid("e8c7ada9-6cac-47a8-b947-869c12d4cbbd"), true, "https://vz.ru/", "ВЗГЛЯД.РУ" },
                    { new Guid("ed198753-536f-4aa9-96ab-47508613a619"), true, "https://rg.ru/", "Российская газета" },
                    { new Guid("f83b3a49-b5e7-45ec-bc57-e36661746cd2"), true, "https://ura.news/", "Ura.ru" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_settings",
                columns: new[] { "id", "description_x_path", "source_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("0c803ea7-b0ac-4f64-9d27-6ba032f3cfe7"), "//div[contains(@class, 'PageContentCommonStyling_text')]", new Guid("ed198753-536f-4aa9-96ab-47508613a619"), "//h1/text()" },
                    { new Guid("0cc1d217-bebc-41e6-ba28-50d6b4801c92"), "//div[@class='js-mediator-article']", new Guid("9a16aef7-c5c5-471a-9a4c-6d00282711f1"), "//h1/text()" },
                    { new Guid("17798a10-65b7-4951-bd7b-640fbf184961"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]", new Guid("8c49701f-a226-46ba-ad92-0a3f3636ca4d"), "//h1/text()" },
                    { new Guid("17e173c0-852c-4380-96fc-28b7d6dea461"), "//div[@itemprop='articleBody']", new Guid("7dd7886e-182f-42e0-b114-4d4719180e74"), "//h1/text()" },
                    { new Guid("19923363-631c-4c42-808b-6a2aa28d56e5"), "//div[@class='topic-body__content']", new Guid("0785e708-60c3-4bae-9d07-8d604d5898cb"), "//h1[@class='topic-body__titles']/span[@class='topic-body__title']/text()" },
                    { new Guid("1aadd593-464b-4086-9a72-536f6cc7fd43"), "//div[@class='article_text']", new Guid("c4dfafc1-8cfc-43f1-80e1-468a83385395"), "//h1/text()" },
                    { new Guid("42019620-89fb-4a2a-8e20-9a057d408919"), "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]", new Guid("b789b5bf-35f4-41b8-a665-e71da2cdd52d"), "//h1/text()" },
                    { new Guid("4a0bdcf0-c134-4cad-810d-39a498e1ed78"), "//div[contains(@class, 'news-item__content')]", new Guid("1d06403d-f2bd-4f8d-bc94-7ed5593c0e84"), "//h1/text()" },
                    { new Guid("59295b87-ab0a-4a6a-8269-eb6d7ca82683"), "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]", new Guid("05fc1676-4ea1-4528-9936-d094d78b26af"), "//h1/text()" },
                    { new Guid("5afe940b-5816-4086-8671-324d8c12724f"), "//div[contains(@class, 'article__text ')]", new Guid("d8352a4a-e5b3-4d2a-b83d-fb552e7099ea"), "//h1/text()" },
                    { new Guid("607c372a-b604-4f41-b2cd-b684e0ade253"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()>1]", new Guid("6ac053ae-cc7e-4cdd-9347-f2e8ee895471"), "//h1/text()" },
                    { new Guid("6eadbccf-3792-47fe-801e-17b1c5376f0b"), "//div[@itemprop='articleBody']", new Guid("e82c62f4-eb64-4c6f-a566-5e1815683926"), "//h1/text()" },
                    { new Guid("70551d3a-7dcb-4734-aca0-154e3638c789"), "//div[contains(@class, 'article__body')]", new Guid("2771015a-9428-47a8-ab75-945663832c95"), "//div[@class='article__title']/text()" },
                    { new Guid("72280631-979c-43c5-9783-0c25277b37aa"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]", new Guid("c7bc5f12-4fb1-4599-9f71-867540631416"), "//h1[@class='article__title']/text()" },
                    { new Guid("77219ac0-8842-4126-ab34-c5941ab7be49"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview'))]", new Guid("4c7ec2da-832d-4860-9928-78ec3e39f37a"), "//h1/text()" },
                    { new Guid("8095c0e7-b3ed-44ec-965f-eb8b317a6e3a"), "//article/div[@class='article-content']/*[not(@class)]", new Guid("a737beb9-0696-406d-919b-4734cfc8a548"), "//article/header/div[@class='article-head__title']/text()" },
                    { new Guid("831a00ff-8a04-41b0-a7a4-90bd27053e3e"), "//article/div[@class='news_text']", new Guid("e8c7ada9-6cac-47a8-b947-869c12d4cbbd"), "//h1/text()" },
                    { new Guid("94585b91-fc44-4404-87e8-57c91a67ad5e"), "//article", new Guid("ab7b1a7d-0dbc-4cac-84a1-a62f6de25aaa"), "//h1/text()" },
                    { new Guid("d279459b-a211-4695-b971-adfbb9891657"), "//div[@itemprop='articleBody']/*[not(name()='div')]", new Guid("f83b3a49-b5e7-45ec-bc57-e36661746cd2"), "//h1/text()" },
                    { new Guid("d5b6a69d-1380-4466-bc08-e0f4b54b6336"), "//div[@class='container-fluid shifted']/p[@class='announce lead']", new Guid("b671a6cd-0644-4129-bb41-896332f8d900"), "//h1/text()" },
                    { new Guid("df29dff5-565e-4ab7-99a1-0edd14df9c27"), "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]", new Guid("170e2f08-1272-4c8c-b70e-7c162636cf6d"), "//h1/text()" },
                    { new Guid("e82f0879-d360-4424-983b-20a464e1ca66"), "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]", new Guid("1917d8b5-5eaf-4fc6-b192-bccb348eb855"), "//h1[@class='b-text__title']/text()" },
                    { new Guid("f19690b7-2dbe-431b-8ad7-883c91347c23"), "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]", new Guid("97b59d7d-020c-4529-92dc-1b47e65abe28"), "//h1/text()" },
                    { new Guid("fa31662d-623a-46d5-a76f-b2c0a13f48b9"), "//div[@itemprop='articleBody']", new Guid("9c9c7f2b-596f-4e17-af4e-94f9d1a83457"), "//h1/span/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_search_settings",
                columns: new[] { "id", "news_site_url", "news_url_x_path", "source_id" },
                values: new object[,]
                {
                    { new Guid("11ca6e94-c5b0-465d-8152-ca30d35f6f5c"), "https://www.championat.com/news/1.html?utm_source=button&utm_medium=news", "//a[contains(@href, 'news-') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("a737beb9-0696-406d-919b-4734cfc8a548") },
                    { new Guid("13bbd98f-fe04-42dd-9e57-ce37742a2e13"), "https://ria.ru/", "//a[contains(@class, 'cell-list__item-link')]/@href", new Guid("2771015a-9428-47a8-ab75-945663832c95") },
                    { new Guid("198009c8-3d42-48ee-ae58-468d051ec2c8"), "https://www.belta.by/", "//a[contains(@href, 'https://www.belta.by/') and contains(@href, '/view/')]/@href", new Guid("9a16aef7-c5c5-471a-9a4c-6d00282711f1") },
                    { new Guid("1e4e56a1-92d2-4223-aa29-5cfe1f56f5f7"), "https://www.interfax.ru/", "//div[@class='timeline']//a[@tabindex=5]/@href", new Guid("05fc1676-4ea1-4528-9936-d094d78b26af") },
                    { new Guid("219cc79d-18e6-450b-aba0-b6b2c49673f0"), "https://russian.rt.com/", "//a[contains(@class, 'link') and contains(@href, 'news/')]/@href", new Guid("d8352a4a-e5b3-4d2a-b83d-fb552e7099ea") },
                    { new Guid("24a3d2ad-b862-472f-ba98-64fca3c4d81a"), "https://life.ru/s/novosti", "//a[contains(@href, '/p/')]/@href", new Guid("b789b5bf-35f4-41b8-a665-e71da2cdd52d") },
                    { new Guid("3505b642-5cd9-4691-a5b2-01a7f046d7da"), "https://3dnews.ru/news/", "//div[@class='news-feed-all']//a[@class='entry-header']/h1/../@href", new Guid("6ac053ae-cc7e-4cdd-9347-f2e8ee895471") },
                    { new Guid("358be8e0-23ec-4c9d-8ea7-b1ff827c4b78"), "https://ura.news/", "//a[contains(@href, '/news/')]/@href", new Guid("f83b3a49-b5e7-45ec-bc57-e36661746cd2") },
                    { new Guid("38ad6544-070e-415d-9ffa-701a218f5ee1"), "https://ixbt.games/news/", "//a[@class='card-link']/@href", new Guid("b671a6cd-0644-4129-bb41-896332f8d900") },
                    { new Guid("42968c75-0250-4149-8cdd-4e66c4b2a717"), "https://www.m24.ru/", "//a[contains(@href, '/news/')]/@href", new Guid("170e2f08-1272-4c8c-b70e-7c162636cf6d") },
                    { new Guid("4cc6a4f4-62e3-4bcd-b457-f87cc4faa9e0"), "https://www.sports.ru/news/", "//a[contains(@href, '.html') and not(contains(@href, '.html#comments'))]/@href", new Guid("1d06403d-f2bd-4f8d-bc94-7ed5593c0e84") },
                    { new Guid("50ba4275-abee-4fef-8080-4c69c36431da"), "https://tass.ru/", "//a[contains(@class, 'tass_pkg_link-v5WdK') and contains(substring(@href, 2), '/') and not(contains(@href, '/spec/')) and not(contains(@href, 'spec.tass.ru'))]/@href", new Guid("ab7b1a7d-0dbc-4cac-84a1-a62f6de25aaa") },
                    { new Guid("584c7ce8-f652-486d-9fee-56e182d72606"), "https://lenta.ru/", "//a[starts-with(@href, '/news/')]/@href", new Guid("0785e708-60c3-4bae-9d07-8d604d5898cb") },
                    { new Guid("5a6899c6-5290-4f43-8a9e-6686c97bffcd"), "https://www.gazeta.ru/news/", "//a[contains(@href, '/news/') and contains(@href, '.shtml') and not(contains(@href, '?'))]/@href", new Guid("7dd7886e-182f-42e0-b114-4d4719180e74") },
                    { new Guid("5f6ccad2-21fc-4ba5-82cb-7595154c9856"), "https://www.pravda.ru/", "//a[contains(@href, '/news/') and not(@href='https://www.pravda.ru/news/')]/@href", new Guid("97b59d7d-020c-4529-92dc-1b47e65abe28") },
                    { new Guid("678aa9b7-8707-48b5-8151-9fba9d07ab90"), "https://vz.ru/", "//a[contains(@href, '.html') and not(contains(@href, '#comments')) and not(contains(@href, '?')) and not(contains(@href, '/about/'))]/@href", new Guid("e8c7ada9-6cac-47a8-b947-869c12d4cbbd") },
                    { new Guid("6ea68dc9-bb3e-4e72-a5f0-e6bbee48bda4"), "https://tsargrad.tv/", "//a[contains(@class, 'news-item__link')]/@href", new Guid("c7bc5f12-4fb1-4599-9f71-867540631416") },
                    { new Guid("94358ecc-63a2-42c0-9233-dd9410223b62"), "https://aif.ru/", "//span[contains(@class, 'item_text__title')]/../@href", new Guid("c4dfafc1-8cfc-43f1-80e1-468a83385395") },
                    { new Guid("a08490d8-3442-4e5e-b219-9321e0c1af76"), "https://iz.ru/news/", "//a[contains(@href, '?main_click')]/@href", new Guid("9c9c7f2b-596f-4e17-af4e-94f9d1a83457") },
                    { new Guid("ba9e17b3-9631-43c3-87fc-54d87871cd92"), "https://www.kommersant.ru/", "//a[contains(@href, '/doc/') and contains(@href, '?from=')]/@href", new Guid("8c49701f-a226-46ba-ad92-0a3f3636ca4d") },
                    { new Guid("ccf26ec0-52b5-418e-b2f0-fb6d8c51f415"), "https://www.rbc.ru/", "//a[contains(@href, 'https://www.rbc.ru/') and contains(@href, '?from=')]/@href", new Guid("4c7ec2da-832d-4860-9928-78ec3e39f37a") },
                    { new Guid("db8c813f-eda1-4b23-b386-7b63431338f7"), "https://svpressa.ru/all/news/", "//a[contains(@href, '/news/') and not(contains(@href, '?')) and not(starts-with(@href, '/all/news/'))]/@href", new Guid("1917d8b5-5eaf-4fc6-b192-bccb348eb855") },
                    { new Guid("ddf8da4e-20b7-491b-a250-a67c3d858c1f"), "https://www.ixbt.com/news/", "//a[starts-with(@href, '/news/') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("e82c62f4-eb64-4c6f-a566-5e1815683926") },
                    { new Guid("f169d721-dd24-4dae-bf6a-6f4878f71d38"), "https://rg.ru/", "//a[contains(@href, '.html')]/@href", new Guid("ed198753-536f-4aa9-96ab-47508613a619") }
                });

            migrationBuilder.InsertData(
                table: "news_source_logos",
                columns: new[] { "id", "source_id", "url" },
                values: new object[] { new Guid("55115f94-7b74-43d7-9633-fa9afb2eba0f"), new Guid("b671a6cd-0644-4129-bb41-896332f8d900"), "https://sun13-2.userapi.com/s/v1/ig2/_ID-2w6Llad8ig5_987dKAfh1pyLdj7HfLHqGx9HxyDjoEDN7wxR0ZWJm5ja1Ey6UuQXaEYEBW1Zd51cpRrjSGfS.jpg?size=100x100&quality=96&crop=22,22,626,626&ava=1" });

            migrationBuilder.InsertData(
                table: "news_parse_editor_settings",
                columns: new[] { "id", "is_required", "name_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("268f08e4-a0ba-407f-b2a6-294f25f31ded"), true, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']//a[@itemprop='author']//span[@itemprop='name']/text()", new Guid("607c372a-b604-4f41-b2cd-b684e0ade253") },
                    { new Guid("28b9fea5-b013-40a2-989f-71954c4aae84"), true, "//span[@itemprop='author']/span[@itemprop='name']/@content", new Guid("6eadbccf-3792-47fe-801e-17b1c5376f0b") },
                    { new Guid("49d05892-41d4-48af-9ebb-d808f44a7927"), false, "//p[@class='doc__text document_authors']/text()", new Guid("17798a10-65b7-4951-bd7b-640fbf184961") },
                    { new Guid("53042e4f-787a-4ebb-8553-bc5665091060"), true, "//div[contains(@class, 'styles_bodyWrapper')]//div[contains(@class, 'styles_authorsLinks')]/a/text()", new Guid("42019620-89fb-4a2a-8e20-9a057d408919") },
                    { new Guid("5305c69a-0a01-4f90-80ad-a253db56443c"), true, "//footer[@class='news-item__footer']/div[@class='news-item__footer-after-news']/p[position()=1]//span/text()", new Guid("4a0bdcf0-c134-4cad-810d-39a498e1ed78") },
                    { new Guid("712236fd-19c9-48fe-8dc1-33d28d9c9ed5"), true, "//div[@itemprop='author']/span[@itemprop='name']/text()", new Guid("d279459b-a211-4695-b971-adfbb9891657") },
                    { new Guid("77e035ef-002a-4050-9a35-9d5a02f09e38"), true, "//article//header//div[@class='article-head__author-name']/a[@rel='author']/span/text()", new Guid("8095c0e7-b3ed-44ec-965f-eb8b317a6e3a") },
                    { new Guid("8f73387c-1475-4da6-8680-66d96b0f3c84"), false, "//div[@class='author']/span[@itemprop='author']/span[@itemprop='name']/a/text()", new Guid("17e173c0-852c-4380-96fc-28b7d6dea461") },
                    { new Guid("9272f252-13b8-4cb4-8ee0-5ed5ec3f67ac"), false, "//div[@class='article__authors']//*[@class='article__authors__author']/span[@class='article__authors__author__name']/text()", new Guid("77219ac0-8842-4126-ab34-c5941ab7be49") },
                    { new Guid("b204ba6f-819e-4903-a135-7b8b47ccc7eb"), false, "//div[@class='topic-authors']/a[@class='topic-authors__author']/text()", new Guid("19923363-631c-4c42-808b-6a2aa28d56e5") },
                    { new Guid("baf32dd1-1d9e-464f-ab1c-d3270d7373fa"), true, "//div[@class='article_top']//div[@class='authors']//div[@class='autor']//span/text()", new Guid("1aadd593-464b-4086-9a72-536f6cc7fd43") },
                    { new Guid("cc330e25-b187-49f1-b7af-f2e7e57749cb"), true, "//div[contains(@class, 'PageArticleContent_authors')]//a[contains(@class, 'LinksOfAuthor_item')]/text()", new Guid("0c803ea7-b0ac-4f64-9d27-6ba032f3cfe7") },
                    { new Guid("ec94d468-0fb5-4145-8d88-d080e09ced08"), true, "//div[contains(@class, 'full-article')]/div[@class='authors-block']//span[text()='Автор']/../a/text()", new Guid("f19690b7-2dbe-431b-8ad7-883c91347c23") },
                    { new Guid("f2312844-4951-4fd4-b261-0b5ad1b820ec"), true, "//div[@class='container-fluid publication-footer']//a[contains(@class, 'text-secondary')]/@title", new Guid("d5b6a69d-1380-4466-bc08-e0f4b54b6336") },
                    { new Guid("f5d00f39-9d0e-4d5f-83a9-52fff37b701d"), true, "//a[@class='article__author']/text()", new Guid("72280631-979c-43c5-9783-0c25277b37aa") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_picture_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("14056f89-1835-4b89-98ef-f9954ab63589"), false, new Guid("70551d3a-7dcb-4734-aca0-154e3638c789"), "//div[@class='photoview__open']/img/@src" },
                    { new Guid("20168b03-0ff2-4594-839d-9d5f3f7d58a8"), true, new Guid("d5b6a69d-1380-4466-bc08-e0f4b54b6336"), "//a[@class='glightbox']/img[contains(@class, 'pub-cover')]/@src" },
                    { new Guid("239e459c-8e8b-4f96-8868-076180309b31"), true, new Guid("d279459b-a211-4695-b971-adfbb9891657"), "//div[@itemprop='articleBody']//div[@itemprop='image']/picture/img[@itemprop='contentUrl']/@src" },
                    { new Guid("2c1cb6ac-695c-49ad-8100-fb0afa6128d1"), false, new Guid("8095c0e7-b3ed-44ec-965f-eb8b317a6e3a"), "//article//header/div[@class='article-head__photo']/img/@src" },
                    { new Guid("2ebab6c2-2bb4-470b-97f7-4494d0bf93a1"), false, new Guid("42019620-89fb-4a2a-8e20-9a057d408919"), "//article//header/div[contains(@class, 'styles_cover_media')]/img/@src" },
                    { new Guid("4a0c5d1c-bf24-49cc-af6c-f98315bafe8d"), true, new Guid("72280631-979c-43c5-9783-0c25277b37aa"), "//div[@class='article__media']//img/@src" },
                    { new Guid("54bfe40c-35fa-4be5-8511-da0bc64d55ee"), false, new Guid("1aadd593-464b-4086-9a72-536f6cc7fd43"), "//div[@class='img_box']/a[@class='zoom_js']/img/@src" },
                    { new Guid("6ad8f94c-522f-4764-8656-929af84d7754"), true, new Guid("fa31662d-623a-46d5-a76f-b2c0a13f48b9"), "//div[contains(@class, 'big_photo')]//div[@class='big_photo__img']//img/@src" },
                    { new Guid("6cebfa2a-4712-42ee-ae57-d741f1a8db3c"), false, new Guid("0cc1d217-bebc-41e6-ba28-50d6b4801c92"), "//div[@class='inner_content']//div[@class='main_img']//img/@src" },
                    { new Guid("736e07f0-8434-427e-9ccf-475262d3f3df"), false, new Guid("94585b91-fc44-4404-87e8-57c91a67ad5e"), "//div[contains(@class, 'HeaderMedia_image')]//img[contains(@class, 'Image_image')]/@src" },
                    { new Guid("a937e2bb-c015-452f-908f-e974a67e1667"), false, new Guid("f19690b7-2dbe-431b-8ad7-883c91347c23"), "//div[contains(@class, 'full-article')]/div[contains(@class, 'gallery')]/picture/img/@src" },
                    { new Guid("bbe38f45-b548-4ed8-98b5-0bcd0ce98a4a"), false, new Guid("17e173c0-852c-4380-96fc-28b7d6dea461"), "//div[@class='b_article-media']//div[@class='mainarea-wrapper']/figure/img[@class='item-image-front']/@src" },
                    { new Guid("c34e8250-b485-4eed-9adb-3228b50452e6"), false, new Guid("607c372a-b604-4f41-b2cd-b684e0ade253"), "//div[contains(@class, 'article-entry')]//div[contains(@class, 'entry-body')]//div[@class='source-wrapper']/img[@itemprop='image']/@src" },
                    { new Guid("c4df96d7-c84c-4836-8f1c-d468d671e303"), true, new Guid("df29dff5-565e-4ab7-99a1-0edd14df9c27"), "//div[@class='b-material-incut-m-image']//@src" },
                    { new Guid("e453853e-c83f-4490-a6ba-8ed701922f89"), false, new Guid("831a00ff-8a04-41b0-a7a4-90bd27053e3e"), "//article/figure/img/@src" },
                    { new Guid("e8d5c789-b83b-4f3c-95a6-b2850d2fcc7b"), false, new Guid("19923363-631c-4c42-808b-6a2aa28d56e5"), "//div[contains(@class, 'topic-body__title-image')]//img[contains(@class, 'picture__image')]/@src" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "published_at_culture_info", "published_at_time_zone_info_id", "published_at_x_path" },
                values: new object[,]
                {
                    { new Guid("2616aabd-dbea-4052-a959-1ac9297eb18f"), true, new Guid("8095c0e7-b3ed-44ec-965f-eb8b317a6e3a"), "ru-RU", "Russian Standard Time", "//article//header//time[@class='article-head__date']/text()" },
                    { new Guid("348f1824-adba-4ec8-b5c1-c8d6ce8c3075"), true, new Guid("6eadbccf-3792-47fe-801e-17b1c5376f0b"), "ru-RU", "Russian Standard Time", "//div[@class='b-article__top-author']/p[@class='date']/text()" },
                    { new Guid("37f0098e-26ee-4cf6-81a2-259b1cf6aa72"), true, new Guid("19923363-631c-4c42-808b-6a2aa28d56e5"), "ru-RU", "Russian Standard Time", "//div[@class='topic-page__header']//a[contains(@class, 'topic-header__time')]/text()" },
                    { new Guid("3c074679-136a-4275-9da3-f0f8a1ca3deb"), true, new Guid("72280631-979c-43c5-9783-0c25277b37aa"), "ru-RU", "Russian Standard Time", "//div[@class='article__meta']/time/text()" },
                    { new Guid("66655c0a-f1d2-4a01-8f86-1fd9a6f88b0c"), true, new Guid("5afe940b-5816-4086-8671-324d8c12724f"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'article__date-autor-shortcode')]/div[contains(@class, 'article__date')]/time[@class='date']/@datetime" },
                    { new Guid("77b5fe48-e316-4345-bdf7-e06c921ada1d"), true, new Guid("17798a10-65b7-4951-bd7b-640fbf184961"), "ru-RU", null, "//div[@class='doc_header__time']/time[@class='doc_header__publish_time']/@datetime" },
                    { new Guid("7adaee98-a299-4039-ba80-b3d1b0804d78"), true, new Guid("1aadd593-464b-4086-9a72-536f6cc7fd43"), "ru-RU", "Russian Standard Time", "//div[@class='article_top']//div[@class='date']//time/text()" },
                    { new Guid("80993be5-a917-46ec-a72a-3f472391b3af"), true, new Guid("df29dff5-565e-4ab7-99a1-0edd14df9c27"), "ru-RU", "Russian Standard Time", "//p[@class='b-material__date']/text()" },
                    { new Guid("80a5e2d2-a330-4bb0-b2b5-0ae232c17ee6"), true, new Guid("94585b91-fc44-4404-87e8-57c91a67ad5e"), "ru-RU", "UTC", "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark')]//span[@ca-ts]/text()" },
                    { new Guid("8546664f-e894-4f84-80be-264e610b8b67"), true, new Guid("59295b87-ab0a-4a6a-8269-eb6d7ca82683"), "ru-RU", "Russian Standard Time", "//article[@itemprop='articleBody']/meta[@itemprop='datePublished']/@content" },
                    { new Guid("85474bea-b790-49ed-9764-80565899ff63"), true, new Guid("0cc1d217-bebc-41e6-ba28-50d6b4801c92"), "ru-RU", "Russian Standard Time", "//div[@class='date_full']/text()" },
                    { new Guid("a19e8f3b-c286-47c1-bf54-cfc2a5481a4c"), true, new Guid("17e173c0-852c-4380-96fc-28b7d6dea461"), "ru-RU", null, "//article/div[@class='b_article-header']//time[@itemprop='datePublished']/@datetime" },
                    { new Guid("ca46593e-d92f-4464-987e-02ece771ae4c"), true, new Guid("4a0bdcf0-c134-4cad-810d-39a498e1ed78"), "ru-RU", null, "//header[@class='news-item__header']//time/@content" },
                    { new Guid("d09cf741-8132-4883-8a12-2b94419cff42"), true, new Guid("42019620-89fb-4a2a-8e20-9a057d408919"), "ru-RU", "UTC", "//article//header//div[contains(@class, 'styles_meta')]//div[contains(@class, 'styles_metaItem')]/text()" },
                    { new Guid("d3d8d87d-b57a-4948-ae30-a128b20b1bb6"), true, new Guid("0c803ea7-b0ac-4f64-9d27-6ba032f3cfe7"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'PageArticleContent_date')]/text()" },
                    { new Guid("d996b69d-1180-4e41-a4aa-aa18f32c2ff1"), true, new Guid("e82f0879-d360-4424-983b-20a464e1ca66"), "ru-RU", "Russian Standard Time", "//div[@class='b-text__date']/text()" },
                    { new Guid("d9aef763-0115-40ed-8371-7a372e41fb82"), true, new Guid("607c372a-b604-4f41-b2cd-b684e0ade253"), "ru-RU", null, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']/span[@itemprop='datePublished']/@content" },
                    { new Guid("dd543e7b-3e7c-4eb7-8a51-de9ef3afc994"), true, new Guid("70551d3a-7dcb-4734-aca0-154e3638c789"), "ru-RU", "Russian Standard Time", "//div[@class='article__info']//div[@class='article__info-date']/a/text()" },
                    { new Guid("e69b99d1-3585-4ec1-949b-e2f6b07243f9"), true, new Guid("d5b6a69d-1380-4466-bc08-e0f4b54b6336"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'publication-footer')]//div[contains(@class, 'pubdatetime')]//div[contains(@class, 'badge-time')]/text()" },
                    { new Guid("ee91a4bd-93ff-4282-96f8-39943cb2cfb6"), true, new Guid("f19690b7-2dbe-431b-8ad7-883c91347c23"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'full-article')]//time/text()" },
                    { new Guid("eebe5436-5a64-4825-ab52-ce0eaa1d1534"), true, new Guid("d279459b-a211-4695-b971-adfbb9891657"), "ru-RU", null, "//div[@class='publication-info']/time[@itemprop='datePublished']/@datetime" },
                    { new Guid("f657d795-3592-442b-aded-6070ebc4391f"), true, new Guid("fa31662d-623a-46d5-a76f-b2c0a13f48b9"), "ru-RU", null, "//div[@class='article_page__left__top__left']//div[@class='article_page__left__top__time']//time/@datetime" },
                    { new Guid("fcfbeff1-d6a9-4606-a30d-9732cf318ee2"), true, new Guid("831a00ff-8a04-41b0-a7a4-90bd27053e3e"), "ru-RU", "Russian Standard Time", "//article/div[@class='header']/span/text()" },
                    { new Guid("fd4cb49a-0f3a-4932-b196-292dc7abfcde"), true, new Guid("77219ac0-8842-4126-ab34-c5941ab7be49"), "ru-RU", null, "//div[@class='article__header__info-block']/time[@class='article__header__date']/@datetime" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_sub_title_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("00f8f6a4-5b14-4a18-b41e-534047c78ad5"), false, new Guid("17798a10-65b7-4951-bd7b-640fbf184961"), "//header[@class='doc_header']/h2[contains(@class, 'doc_header__subheader')]/text()" },
                    { new Guid("1a23ca7b-a369-499a-800c-355ddab1be4b"), false, new Guid("19923363-631c-4c42-808b-6a2aa28d56e5"), "//div[contains(@class, 'topic-body__title')]/text()" },
                    { new Guid("2aebb6df-46ad-4e7f-9c70-7bb6f0c88dd9"), true, new Guid("70551d3a-7dcb-4734-aca0-154e3638c789"), "//h1[@class='article__second-title']/text()" },
                    { new Guid("2cc8652a-8db0-466e-9d1e-cfb2c0992404"), true, new Guid("72280631-979c-43c5-9783-0c25277b37aa"), "//div[@class='article__intro']/p/text()" },
                    { new Guid("3c46fd6a-414d-4a7a-a9ac-9de3a5a4ddea"), true, new Guid("17e173c0-852c-4380-96fc-28b7d6dea461"), "//h2/text()" },
                    { new Guid("41c4d934-19a5-4a25-84c0-fada4081f6c0"), true, new Guid("f19690b7-2dbe-431b-8ad7-883c91347c23"), "//h1/text()" },
                    { new Guid("676bf3d7-d09a-4f79-98a0-b0ac3d48659d"), false, new Guid("6eadbccf-3792-47fe-801e-17b1c5376f0b"), "//h4/text()" },
                    { new Guid("74efab96-4418-49c4-902f-f3a371154282"), false, new Guid("77219ac0-8842-4126-ab34-c5941ab7be49"), "//div[contains(@class, 'article__text')]/div[@class='article__text__overview']/span/text()" },
                    { new Guid("8572e029-712d-44b6-a365-823ad7c96307"), false, new Guid("831a00ff-8a04-41b0-a7a4-90bd27053e3e"), "//h4/text()" },
                    { new Guid("88b7693b-c2c5-4e1e-b5eb-1c1e8f7b72cf"), true, new Guid("d5b6a69d-1380-4466-bc08-e0f4b54b6336"), "//div[@class='container-fluid shifted']/p[@class='announce lead']/text()" },
                    { new Guid("8a37f45f-5830-42da-890b-c570fa3da44d"), true, new Guid("5afe940b-5816-4086-8671-324d8c12724f"), "//div[contains(@class, 'article__summary')]/text()" },
                    { new Guid("da00752a-6593-4333-870a-00ac69551969"), true, new Guid("607c372a-b604-4f41-b2cd-b684e0ade253"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()=1]/text()" },
                    { new Guid("de82b120-80e1-4d9d-84d3-297e0775bfff"), false, new Guid("0c803ea7-b0ac-4f64-9d27-6ba032f3cfe7"), "//div[contains(@class, 'PageArticleContent_lead')]/text()" },
                    { new Guid("edb97967-16a5-46f2-b4b2-ef6647b20718"), false, new Guid("94585b91-fc44-4404-87e8-57c91a67ad5e"), "//h3/text()" },
                    { new Guid("f2076544-76c2-487d-b092-6f870ea4bd5a"), false, new Guid("42019620-89fb-4a2a-8e20-9a057d408919"), "//article//header//p[contains(@class, 'styles_subtitle')]/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_published_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("26d3e2b1-e8a7-495c-8bb4-4ba5ce72bdaf"), "dd MMMM yyyy, HH:mm", new Guid("d09cf741-8132-4883-8a12-2b94419cff42") },
                    { new Guid("2c78e403-59cf-42e6-871a-7e4e0d1b37c4"), "yyyy-MM-dd HH:mm:ss", new Guid("e69b99d1-3585-4ec1-949b-e2f6b07243f9") },
                    { new Guid("2ff8f7c3-31b6-4479-9f45-675df599acc1"), "HH:mm", new Guid("80993be5-a917-46ec-a72a-3f472391b3af") },
                    { new Guid("39284310-f063-450b-9c04-02a655cb4fd1"), "dd MMMM yyyy, HH:mm", new Guid("85474bea-b790-49ed-9764-80565899ff63") },
                    { new Guid("3f95b904-b140-4e1c-84d2-60db6c08e92d"), "dd MMMM, HH:mm,", new Guid("80a5e2d2-a330-4bb0-b2b5-0ae232c17ee6") },
                    { new Guid("45965fb6-2889-464b-984d-039f3f0fec98"), "HH:mm dd.MM.yyyy", new Guid("dd543e7b-3e7c-4eb7-8a51-de9ef3afc994") },
                    { new Guid("4aff6fbc-4740-4770-a0d4-22ef0009bbaf"), "dd.MM.yyyy HH:mm", new Guid("d3d8d87d-b57a-4948-ae30-a128b20b1bb6") },
                    { new Guid("56382f47-2ca0-4f3b-95bd-77d853d19c13"), "yyyy-MM-ddTHH:mm:ss", new Guid("8546664f-e894-4f84-80be-264e610b8b67") },
                    { new Guid("5b9a8445-4e1f-4a0f-8a0d-867654c6d0f0"), "dd MMMM yyyy в HH:mm", new Guid("348f1824-adba-4ec8-b5c1-c8d6ce8c3075") },
                    { new Guid("66cbcbf8-8015-436e-9169-bf4e7f04069d"), "dd MMMM, HH:mm", new Guid("d09cf741-8132-4883-8a12-2b94419cff42") },
                    { new Guid("6aa34ecf-b953-4bd6-a99b-e747eb2d8f35"), "dd MMMM yyyy, HH:mm", new Guid("80a5e2d2-a330-4bb0-b2b5-0ae232c17ee6") },
                    { new Guid("76623626-2a30-41bb-b73f-b491fcaac3e2"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("77b5fe48-e316-4345-bdf7-e06c921ada1d") },
                    { new Guid("77ffba3f-d794-4b00-b168-1c06546f78fd"), "dd.MM.yyyy HH:mm", new Guid("ee91a4bd-93ff-4282-96f8-39943cb2cfb6") },
                    { new Guid("79fed005-1fd2-4c76-8e44-d67d38b93c5e"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("d9aef763-0115-40ed-8371-7a372e41fb82") },
                    { new Guid("7c60d2e6-9d5a-490d-a2af-abc47eba2e04"), "dd MMMM yyyy HH:mm", new Guid("3c074679-136a-4275-9da3-f0f8a1ca3deb") },
                    { new Guid("80ac1781-42a7-49c5-b06d-ad9ceadc4d7c"), "dd MMMM yyyy, HH:mm", new Guid("80993be5-a917-46ec-a72a-3f472391b3af") },
                    { new Guid("86ca99b7-a128-407d-b215-7c8602bf5ca5"), "dd MMMM, HH:mm", new Guid("80a5e2d2-a330-4bb0-b2b5-0ae232c17ee6") },
                    { new Guid("99fe755e-11e8-4042-afb6-83df927e665d"), "HH:mm", new Guid("3c074679-136a-4275-9da3-f0f8a1ca3deb") },
                    { new Guid("a69a3c07-9da4-418f-9440-f68fca838e24"), "HH:mm, dd MMMM yyyy", new Guid("37f0098e-26ee-4cf6-81a2-259b1cf6aa72") },
                    { new Guid("aa471669-5a9e-4986-af38-5928e40add28"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("eebe5436-5a64-4825-ab52-ce0eaa1d1534") },
                    { new Guid("aad9855a-50d6-4e7b-9853-fa52f1cbfcab"), "yyyy-MM-d HH:mm", new Guid("66655c0a-f1d2-4a01-8f86-1fd9a6f88b0c") },
                    { new Guid("af90ca8d-dc93-49ad-a886-004dc73569da"), "dd MMMM yyyy HH:mm", new Guid("d996b69d-1180-4e41-a4aa-aa18f32c2ff1") },
                    { new Guid("b0e3da31-fee2-4b4d-9356-8d1a38c43150"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("a19e8f3b-c286-47c1-bf54-cfc2a5481a4c") },
                    { new Guid("ba8aeb8c-007d-487a-bd3e-0af0b53d8931"), "dd MMMM, HH:mm", new Guid("80993be5-a917-46ec-a72a-3f472391b3af") },
                    { new Guid("ca710d58-50c0-4df5-b116-37e127c16b30"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("ca46593e-d92f-4464-987e-02ece771ae4c") },
                    { new Guid("d80f610e-61c5-40a4-8c94-6618b8781197"), "dd MMMM yyyy, HH:mm МСК", new Guid("2616aabd-dbea-4052-a959-1ac9297eb18f") },
                    { new Guid("d933cfee-ce4f-421b-84bd-1c697f8efe79"), "dd.MM.yyyy HH:mm", new Guid("7adaee98-a299-4039-ba80-b3d1b0804d78") },
                    { new Guid("e698ef7e-43d7-4655-a804-0ab1002c51ba"), "dd MMMM  HH:mm", new Guid("d996b69d-1180-4e41-a4aa-aa18f32c2ff1") },
                    { new Guid("e7a2d726-457b-41d2-a765-3204930e6648"), "dd MMMM yyyy, HH:mm", new Guid("fcfbeff1-d6a9-4606-a30d-9732cf318ee2") },
                    { new Guid("e864a629-a856-4930-9cdb-9af0f93dbb32"), "dd MMMM yyyy, HH:mm,", new Guid("80a5e2d2-a330-4bb0-b2b5-0ae232c17ee6") },
                    { new Guid("f435203c-f6ac-4053-9957-2d0c717173c9"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("f657d795-3592-442b-aded-6070ebc4391f") },
                    { new Guid("fb3748bf-306e-42da-98b8-19f0b2110d66"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("fd4cb49a-0f3a-4932-b196-292dc7abfcde") }
                });

            migrationBuilder.CreateIndex(
                name: "ix_news_editor_id",
                table: "news",
                column: "editor_id");

            migrationBuilder.CreateIndex(
                name: "ix_news_published_at",
                table: "news",
                column: "published_at");

            migrationBuilder.CreateIndex(
                name: "ix_news_title",
                table: "news",
                column: "title");

            migrationBuilder.CreateIndex(
                name: "ix_news_url",
                table: "news",
                column: "url");

            migrationBuilder.CreateIndex(
                name: "ix_news_descriptions_news_id",
                table: "news_descriptions",
                column: "news_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_news_editors_name",
                table: "news_editors",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "ix_news_editors_source_id",
                table: "news_editors",
                column: "source_id");

            migrationBuilder.CreateIndex(
                name: "ix_news_parse_editor_settings_parse_settings_id",
                table: "news_parse_editor_settings",
                column: "parse_settings_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_news_parse_errors_created_at",
                table: "news_parse_errors",
                column: "created_at");

            migrationBuilder.CreateIndex(
                name: "ix_news_parse_errors_news_url",
                table: "news_parse_errors",
                column: "news_url");

            migrationBuilder.CreateIndex(
                name: "ix_news_parse_picture_settings_parse_settings_id",
                table: "news_parse_picture_settings",
                column: "parse_settings_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_news_parse_published_at_settings_parse_settings_id",
                table: "news_parse_published_at_settings",
                column: "parse_settings_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_news_parse_published_at_settings_formats_news_parse_publish",
                table: "news_parse_published_at_settings_formats",
                column: "news_parse_published_at_settings_id");

            migrationBuilder.CreateIndex(
                name: "ix_news_parse_settings_source_id",
                table: "news_parse_settings",
                column: "source_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_news_parse_sub_title_settings_parse_settings_id",
                table: "news_parse_sub_title_settings",
                column: "parse_settings_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_news_pictures_news_id",
                table: "news_pictures",
                column: "news_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_news_search_settings_source_id",
                table: "news_search_settings",
                column: "source_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_news_source_logos_source_id",
                table: "news_source_logos",
                column: "source_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_news_sources_is_enabled",
                table: "news_sources",
                column: "is_enabled");

            migrationBuilder.CreateIndex(
                name: "ix_news_sources_site_url",
                table: "news_sources",
                column: "site_url");

            migrationBuilder.CreateIndex(
                name: "ix_news_sources_title",
                table: "news_sources",
                column: "title");

            migrationBuilder.CreateIndex(
                name: "ix_news_sub_titles_news_id",
                table: "news_sub_titles",
                column: "news_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_news_sub_titles_title",
                table: "news_sub_titles",
                column: "title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "news_descriptions");

            migrationBuilder.DropTable(
                name: "news_parse_editor_settings");

            migrationBuilder.DropTable(
                name: "news_parse_errors");

            migrationBuilder.DropTable(
                name: "news_parse_picture_settings");

            migrationBuilder.DropTable(
                name: "news_parse_published_at_settings_formats");

            migrationBuilder.DropTable(
                name: "news_parse_sub_title_settings");

            migrationBuilder.DropTable(
                name: "news_pictures");

            migrationBuilder.DropTable(
                name: "news_search_settings");

            migrationBuilder.DropTable(
                name: "news_source_logos");

            migrationBuilder.DropTable(
                name: "news_sub_titles");

            migrationBuilder.DropTable(
                name: "news_parse_published_at_settings");

            migrationBuilder.DropTable(
                name: "news");

            migrationBuilder.DropTable(
                name: "news_parse_settings");

            migrationBuilder.DropTable(
                name: "news_editors");

            migrationBuilder.DropTable(
                name: "news_sources");
        }
    }
}
