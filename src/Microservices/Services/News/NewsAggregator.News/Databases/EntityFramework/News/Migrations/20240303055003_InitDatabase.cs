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
                name: "news_parse_needs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    news_url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_parse_needs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "news_parse_network_errors",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    news_url = table.Column<string>(type: "text", nullable: false),
                    message = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_parse_network_errors", x => x.id);
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
                    name = table.Column<string>(type: "text", nullable: false)
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
                    html_description_x_path = table.Column<string>(type: "text", nullable: false),
                    text_description_x_path = table.Column<string>(type: "text", nullable: false)
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
                    small = table.Column<string>(type: "text", nullable: false),
                    original = table.Column<string>(type: "text", nullable: false)
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
                    published_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    parsed_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    added_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                name: "news_parse_modified_at_settings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    parse_settings_id = table.Column<Guid>(type: "uuid", nullable: false),
                    modified_at_x_path = table.Column<string>(type: "text", nullable: false),
                    modified_at_culture_info = table.Column<string>(type: "text", nullable: false),
                    modified_at_time_zone_info_id = table.Column<string>(type: "text", nullable: true),
                    is_required = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_parse_modified_at_settings", x => x.id);
                    table.ForeignKey(
                        name: "fk_news_parse_modified_at_settings_news_parse_settings_parse_s",
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
                name: "news_parse_video_settings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    parse_settings_id = table.Column<Guid>(type: "uuid", nullable: false),
                    url_x_path = table.Column<string>(type: "text", nullable: false),
                    is_required = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_parse_video_settings", x => x.id);
                    table.ForeignKey(
                        name: "fk_news_parse_video_settings_news_parse_settings_parse_setting",
                        column: x => x.parse_settings_id,
                        principalTable: "news_parse_settings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "news_html_descriptions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    news_id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_html_descriptions", x => x.id);
                    table.ForeignKey(
                        name: "fk_news_html_descriptions_news_news_id",
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
                name: "news_text_descriptions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    news_id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_text_descriptions", x => x.id);
                    table.ForeignKey(
                        name: "fk_news_text_descriptions_news_news_id",
                        column: x => x.news_id,
                        principalTable: "news",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "news_videos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    news_id = table.Column<Guid>(type: "uuid", nullable: false),
                    url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_videos", x => x.id);
                    table.ForeignKey(
                        name: "fk_news_videos_news_news_id",
                        column: x => x.news_id,
                        principalTable: "news",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "news_parse_modified_at_settings_formats",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    news_parse_modified_at_settings_id = table.Column<Guid>(type: "uuid", nullable: false),
                    format = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_parse_modified_at_settings_formats", x => x.id);
                    table.ForeignKey(
                        name: "fk_news_parse_modified_at_settings_formats_news_parse_modified",
                        column: x => x.news_parse_modified_at_settings_id,
                        principalTable: "news_parse_modified_at_settings",
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
                    { new Guid("124cbee6-1024-4a3e-9c5e-0c933a7038da"), true, "https://russian.rt.com/", "RT на русском" },
                    { new Guid("140af428-7470-4359-8d41-a11c6f8f1296"), true, "https://ixbt.games/", "iXBT.games" },
                    { new Guid("152f014b-adc5-417c-a77a-e7954ccea85f"), true, "https://tsargrad.tv/", "Царьград" },
                    { new Guid("16921563-c306-4151-a4fe-84feca5bf907"), true, "https://www.1obl.ru/", "Первый областной" },
                    { new Guid("1a59b2d6-eebb-4947-9320-47b934dabf02"), true, "https://ura.news/", "Ura.ru" },
                    { new Guid("1e6056d2-4d80-4c19-aa1a-b801bbd13b94"), true, "https://www.m24.ru/", "Москва 24" },
                    { new Guid("37cfc39a-4c6f-4b6e-a896-c8291621d53e"), true, "https://www.rbc.ru/", "РБК" },
                    { new Guid("3a58fde9-80be-436d-bfc2-c784ae01aacd"), true, "https://vz.ru/", "ВЗГЛЯД.РУ" },
                    { new Guid("44833008-4e54-4db4-9c14-144bbbf31681"), true, "https://svpressa.ru/", "СвободнаяПресса" },
                    { new Guid("45969ebf-b644-447a-9c24-f053cd0c275a"), true, "https://ria.ru/", "РИА Новости" },
                    { new Guid("4deff799-6286-4c7f-9aef-e5849549f49e"), true, "https://www.interfax.ru/", "Интерфакс" },
                    { new Guid("4e2c9d7b-b6fb-47b1-b02b-0c7c29751e1d"), true, "https://rg.ru/", "Российская газета" },
                    { new Guid("4efd0f06-a505-4db0-a58f-53226f316c3b"), true, "https://www.championat.com/", "Чемпионат.com" },
                    { new Guid("5111f651-fc32-498c-9ad5-97f9a81f99d4"), true, "https://www.pravda.ru/", "Правда.ру" },
                    { new Guid("53adf9ee-9e10-4288-b568-002b9b0caf0f"), true, "https://edition.cnn.com/", "CNN" },
                    { new Guid("60a170bd-7d39-4a18-822f-172b2fc26eb5"), true, "https://tass.ru/", "ТАСС" },
                    { new Guid("67fdbd9f-910c-4d4f-9c5d-fd774e648ebb"), true, "https://life.ru/", "Life" },
                    { new Guid("74018562-9296-484e-9399-6c1725aa5658"), true, "https://www.gazeta.ru/", "Газета.Ru" },
                    { new Guid("7a70bd26-6c97-4335-b1ee-6ab6768cbf34"), true, "https://3dnews.ru/", "3Dnews.ru" },
                    { new Guid("8bcc6292-4945-48df-bf9e-b3eb08e15954"), true, "https://www.sports.ru/", "Storts.ru" },
                    { new Guid("900494d6-4599-4ca5-aa75-79a287b06bfa"), true, "https://www.kommersant.ru/", "Коммерсантъ" },
                    { new Guid("a0d63964-fcb9-4684-a646-2ae8835609d1"), true, "https://www.cybersport.ru/", "Cybersport.ru" },
                    { new Guid("a25689eb-af08-4db9-90a4-0c8b1ff0a077"), true, "https://www.hltv.org/", "HLTV.org" },
                    { new Guid("a6d8185f-6b24-402b-b7c1-78f513c4e87b"), true, "https://www.nytimes.com/", "The New York Times" },
                    { new Guid("b795f4e6-b74b-4b67-907a-0162e720d963"), true, "https://lenta.ru/", "Лента.Ру" },
                    { new Guid("cef6d844-69d2-4052-a1a6-147c147e026a"), true, "https://www.ixbt.com/", "iXBT.com" },
                    { new Guid("d9fc32f0-49a5-438b-8f4a-a12ecbd64cf5"), true, "https://aif.ru/", "Аргументы и факты" },
                    { new Guid("ddfa3107-7ce2-4359-bb91-6314782064ab"), true, "https://iz.ru/", "Известия" },
                    { new Guid("f11fcd12-e088-4f02-8c7e-1f4b8a593913"), true, "https://www.belta.by/", "БелТА" },
                    { new Guid("f6028a8e-7569-4fd8-b9c1-689f483ddb67"), true, "https://74.ru/", "74.ru" },
                    { new Guid("fb88ee1e-9e21-443b-88b2-d0e932247d39"), true, "https://www.kp.ru/", "Комсомольская правда" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_settings",
                columns: new[] { "id", "html_description_x_path", "source_id", "text_description_x_path", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("02fad26b-a95f-4d46-a7c9-8762ae0f8134"), "//div[contains(@class, 'news-item__content')]", new Guid("8bcc6292-4945-48df-bf9e-b3eb08e15954"), "//div[contains(@class, 'news-item__content')]/text()", "//h1/text()" },
                    { new Guid("03d93f48-edb7-4bce-8e37-a603de0deccc"), "//div[@class='topic-body__content']", new Guid("b795f4e6-b74b-4b67-907a-0162e720d963"), "//div[@class='topic-body__content']/text()", "//h1[@class='topic-body__titles']/span[@class='topic-body__title']/text()" },
                    { new Guid("05df79d9-7007-4a9a-8013-f3abacc092e6"), "//div[@itemprop='articleBody']/*", new Guid("cef6d844-69d2-4052-a1a6-147c147e026a"), "//div[@itemprop='articleBody']/*/text()", "//h1/text()" },
                    { new Guid("06e0d828-1e71-4db2-9a6b-9ce66c6cb82c"), "//div[@itemprop='articleBody']/*[not(name() = 'figure')]", new Guid("f6028a8e-7569-4fd8-b9c1-689f483ddb67"), "//div[@itemprop='articleBody']/*[not(name() = 'figure')]/text()", "//h1[@itemprop='headline']/span/text()" },
                    { new Guid("0ca09c5d-1ec1-41c1-b2e4-555ed5329930"), "//article/div[@class='news_text']", new Guid("3a58fde9-80be-436d-bfc2-c784ae01aacd"), "//article/div[@class='news_text']/text()", "//h1/text()" },
                    { new Guid("219bc6f5-2d7a-4517-8f83-83cc29cbe2cd"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]", new Guid("152f014b-adc5-417c-a77a-e7954ccea85f"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]/text()", "//h1[@class='article__title']/text()" },
                    { new Guid("2c684f99-4d5f-4d39-ab68-a193d1f856be"), "//article/*", new Guid("60a170bd-7d39-4a18-822f-172b2fc26eb5"), "//article/*/text()", "//h1/text()" },
                    { new Guid("35e374bb-fd03-4637-9b51-6325de8d1f8b"), "//div[@itemprop='articleBody']/*", new Guid("ddfa3107-7ce2-4359-bb91-6314782064ab"), "//div[@itemprop='articleBody']//text()", "//h1/span/text()" },
                    { new Guid("3b732126-69d3-4190-b677-398b9d4d452b"), "//article//div[@class='newstext-con']/*[position()>2]", new Guid("a25689eb-af08-4db9-90a4-0c8b1ff0a077"), "//article//div[@class='newstext-con']/*[position()>2]/text()", "//h1[@class='headline']/text()" },
                    { new Guid("4b61a21f-568c-42b4-a582-112787958a2d"), "//div[contains(@class, 'PageContentCommonStyling_text')]/*[not(name() = 'rg-video')]", new Guid("4e2c9d7b-b6fb-47b1-b02b-0c7c29751e1d"), "//div[contains(@class, 'PageContentCommonStyling_text')]/*[not(name() = 'rg-video')]/text()", "//h1/text()" },
                    { new Guid("53eaeace-f448-4272-aa46-81f56a74cf8d"), "//article/div[@class='article-content']/*[not(@class)]", new Guid("4efd0f06-a505-4db0-a58f-53226f316c3b"), "//article/div[@class='article-content']/*[not(@class)]/text()", "//article/header/div[@class='article-head__title']/text()" },
                    { new Guid("54f1d5d5-c78b-441b-a9e2-084a87a83f69"), "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]", new Guid("67fdbd9f-910c-4d4f-9c5d-fd774e648ebb"), "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]/text()", "//h1/text()" },
                    { new Guid("5c108d6a-3e29-4ac1-83ee-af335d5809de"), "//section[@name='articleBody']/*", new Guid("a6d8185f-6b24-402b-b7c1-78f513c4e87b"), "//section[@name='articleBody']/*/text()", "//h1/text()" },
                    { new Guid("6a0c0a18-2c05-4bce-bda2-efe743b3f36d"), "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]", new Guid("4deff799-6286-4c7f-9aef-e5849549f49e"), "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]/text()", "//h1/text()" },
                    { new Guid("7893cdf9-d4a6-44ff-9559-cbabae4ca1da"), "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]", new Guid("44833008-4e54-4db4-9c14-144bbbf31681"), "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]/text()", "//h1[@class='b-text__title']/text()" },
                    { new Guid("78b60ed5-7609-4a64-8008-4d151b12d817"), "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]", new Guid("1e6056d2-4d80-4c19-aa1a-b801bbd13b94"), "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]/text()", "//h1/text()" },
                    { new Guid("88b069e5-1cc6-4a5a-bcb1-14f0c0d72fff"), "//div[contains(@class, 'article__text ')]", new Guid("124cbee6-1024-4a3e-9c5e-0c933a7038da"), "//div[contains(@class, 'article__text ')]/text()", "//h1/text()" },
                    { new Guid("a418ae38-d4cb-479f-9a6b-ebc514037ad1"), "//div[contains(@class, 'container-fluid shifted') and not(p[@class='announce lead']) and not(h1) and not(hr)]", new Guid("140af428-7470-4359-8d41-a11c6f8f1296"), "//div[contains(@class, 'container-fluid shifted') and not(p[@class='announce lead']) and not(h1) and not(hr)]/text()", "//h1/text()" },
                    { new Guid("aeff35e9-ba98-4db2-9819-78893432c10f"), "//div[contains(@class, 'article__body')]", new Guid("45969ebf-b644-447a-9c24-f053cd0c275a"), "//div[contains(@class, 'article__body')]/text()", "//div[@class='article__title']/text()" },
                    { new Guid("ca89bf1b-c939-4781-92a0-0ef67bd9dea6"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/*[position()>1 and not(div)]", new Guid("7a70bd26-6c97-4335-b1ee-6ab6768cbf34"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()>1]/text()", "//h1/text()" },
                    { new Guid("d0a90bb4-1793-4099-9a2b-8277ed784b1b"), "//div[@itemprop='articleBody']/*", new Guid("74018562-9296-484e-9399-6c1725aa5658"), "//div[@itemprop='articleBody']/*/text()", "//h1/text()" },
                    { new Guid("dd9f3d71-2974-4ede-b96d-6cd2fc85f5ff"), "//div[@itemprop='articleBody']/*", new Guid("53adf9ee-9e10-4288-b568-002b9b0caf0f"), "//div[@itemprop='articleBody']/*/text()", "//h1/text()" },
                    { new Guid("df3024d6-97f2-4777-8971-6ae5beefd8d6"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview'))]", new Guid("37cfc39a-4c6f-4b6e-a896-c8291621d53e"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview'))]/text()", "//h1/text()" },
                    { new Guid("e3989a89-fd8c-4f17-b908-42047971638c"), "//div[@itemprop='articleBody']/*", new Guid("16921563-c306-4151-a4fe-84feca5bf907"), "//div[@itemprop='articleBody']/*/text()", "//h1[@itemprop='headline']/text()" },
                    { new Guid("e684b8d9-0b92-4824-ad8e-8898003641f7"), "//div[contains(@class, 'js-mediator-article')]/*[position()>1]", new Guid("a0d63964-fcb9-4684-a646-2ae8835609d1"), "//div[contains(@class, 'js-mediator-article')]/*[position()>1]/text()", "//h1/text()" },
                    { new Guid("ec5cb8ee-73ad-46d8-acf3-8cfa31e1b254"), "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]", new Guid("5111f651-fc32-498c-9ad5-97f9a81f99d4"), "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]/text()", "//h1/text()" },
                    { new Guid("f0ccbec0-7a27-4a80-b55c-b674f56b83ca"), "//div[@itemprop='articleBody']/*[not(name()='div')]", new Guid("1a59b2d6-eebb-4947-9320-47b934dabf02"), "//div[@itemprop='articleBody']/*[not(name()='div')]/text()", "//h1/text()" },
                    { new Guid("f1467024-27c3-4c32-b394-c6771f70e258"), "//div[@class='js-mediator-article']", new Guid("f11fcd12-e088-4f02-8c7e-1f4b8a593913"), "//div[@class='js-mediator-article']/text()", "//h1/text()" },
                    { new Guid("f5f7e3a7-e7cd-48d0-9b7f-988e397b9056"), "//div[@data-gtm-el='content-body']/*[not(name()='div' and @data-wide='true')]", new Guid("fb88ee1e-9e21-443b-88b2-d0e932247d39"), "//div[@data-gtm-el='content-body']/*[not(name()='div' and @data-wide='true')]/text()", "//h1/text()" },
                    { new Guid("fa8c4179-2296-40f2-a831-a49b50bc1c95"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]", new Guid("900494d6-4599-4ca5-aa75-79a287b06bfa"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]/text()", "//h1/text()" },
                    { new Guid("ff453439-4dc9-4b63-a01d-401c8ad8290f"), "//div[@class='article_text']", new Guid("d9fc32f0-49a5-438b-8f4a-a12ecbd64cf5"), "//div[@class='article_text']/text()", "//h1/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_search_settings",
                columns: new[] { "id", "news_site_url", "news_url_x_path", "source_id" },
                values: new object[,]
                {
                    { new Guid("07c62146-2cc5-4b9c-8842-7f307e234631"), "https://www.gazeta.ru/news/", "//a[contains(@href, '/news/') and contains(@href, '.shtml') and not(contains(@href, '?'))]/@href", new Guid("74018562-9296-484e-9399-6c1725aa5658") },
                    { new Guid("147d029f-c6f5-426a-9785-9a3cae0b8e56"), "https://russian.rt.com/", "//a[contains(@class, 'link') and contains(@href, 'news/')]/@href", new Guid("124cbee6-1024-4a3e-9c5e-0c933a7038da") },
                    { new Guid("1db45c00-f41f-4b1f-aebf-954c1831534a"), "https://www.rbc.ru/", "//a[contains(@href, 'https://www.rbc.ru/') and contains(@href, '?from=')]/@href", new Guid("37cfc39a-4c6f-4b6e-a896-c8291621d53e") },
                    { new Guid("3b9767e9-392f-4509-a560-54aa0ae2cc2b"), "https://www.cybersport.ru/", "//a[contains(@href, '/tags/')]/@href", new Guid("a0d63964-fcb9-4684-a646-2ae8835609d1") },
                    { new Guid("555273b2-97cc-49d7-b642-b246b45834c1"), "https://aif.ru/", "//span[contains(@class, 'item_text__title')]/../@href", new Guid("d9fc32f0-49a5-438b-8f4a-a12ecbd64cf5") },
                    { new Guid("64913f53-a36a-410a-b382-d954d5914bec"), "https://www.kommersant.ru/", "//a[contains(@href, '/doc/') and contains(@href, '?from=')]/@href", new Guid("900494d6-4599-4ca5-aa75-79a287b06bfa") },
                    { new Guid("71b4f7e1-8a51-4793-b260-16ee83a9cb79"), "https://www.championat.com/news/1.html?utm_source=button&utm_medium=news", "//a[contains(@href, 'news-') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("4efd0f06-a505-4db0-a58f-53226f316c3b") },
                    { new Guid("7b6526cf-be04-47ce-8f56-684abc64461f"), "https://www.hltv.org/", "//a[contains(@href, '/news/')]/@href", new Guid("a25689eb-af08-4db9-90a4-0c8b1ff0a077") },
                    { new Guid("8378bbb7-03cb-4adf-8b2a-26bb7995a7de"), "https://ixbt.games/news/", "//a[@class='card-link']/@href", new Guid("140af428-7470-4359-8d41-a11c6f8f1296") },
                    { new Guid("8dc58551-2c29-4227-ad66-bc0f6d9d723e"), "https://www.m24.ru/", "//a[contains(@href, '/news/')]/@href", new Guid("1e6056d2-4d80-4c19-aa1a-b801bbd13b94") },
                    { new Guid("8f279af2-c362-4e5a-b746-c157984b288b"), "https://ria.ru/", "//a[contains(@class, 'cell-list__item-link')]/@href", new Guid("45969ebf-b644-447a-9c24-f053cd0c275a") },
                    { new Guid("928e2f14-a0f0-45e0-94a2-85bd43ba7887"), "https://www.interfax.ru/", "//div[@class='timeline']//a[@tabindex=5]/@href", new Guid("4deff799-6286-4c7f-9aef-e5849549f49e") },
                    { new Guid("97adfb62-70b7-4620-83fd-2ab698324cb6"), "https://ura.news/", "//a[contains(@href, '/news/')]/@href", new Guid("1a59b2d6-eebb-4947-9320-47b934dabf02") },
                    { new Guid("9eb11856-b458-41cf-a714-1253c726479f"), "https://74.ru/", "//a[starts-with(@href, '/text/') and not(contains(@href, '?')) and not(contains(@href, 'comments/')) and not(@href='/text/')]/@href", new Guid("f6028a8e-7569-4fd8-b9c1-689f483ddb67") },
                    { new Guid("a53164cf-85c2-44f1-b7d9-2c15579a57a1"), "https://tsargrad.tv/", "//a[contains(@class, 'news-item__link')]/@href", new Guid("152f014b-adc5-417c-a77a-e7954ccea85f") },
                    { new Guid("ab72fcff-e5ab-4b49-bf72-aeb291d7e85b"), "https://3dnews.ru/news/", "//div[@class='news-feed-all']//a[@class='entry-header']/h1/../@href", new Guid("7a70bd26-6c97-4335-b1ee-6ab6768cbf34") },
                    { new Guid("afec85d8-ffb9-47a6-b542-790058821298"), "https://life.ru/s/novosti", "//a[contains(@href, '/p/')]/@href", new Guid("67fdbd9f-910c-4d4f-9c5d-fd774e648ebb") },
                    { new Guid("b35d198a-1a07-4c3c-a610-e0b283cda10e"), "https://www.pravda.ru/", "//a[contains(@href, '/news/') and not(@href='https://www.pravda.ru/news/')]/@href", new Guid("5111f651-fc32-498c-9ad5-97f9a81f99d4") },
                    { new Guid("b63c76bd-5477-48ff-92e6-52a2ea377729"), "https://edition.cnn.com/", "//a[contains(@href, '.html')]/@href", new Guid("53adf9ee-9e10-4288-b568-002b9b0caf0f") },
                    { new Guid("bae88518-cda3-4566-8078-b4c42d9650d6"), "https://iz.ru/news/", "//a[contains(@href, '?main_click')]/@href", new Guid("ddfa3107-7ce2-4359-bb91-6314782064ab") },
                    { new Guid("c3b9bc9f-d37a-435e-a6c5-c982a588c1a3"), "https://www.belta.by/", "//a[contains(@href, 'https://www.belta.by/') and contains(@href, '/view/')]/@href", new Guid("f11fcd12-e088-4f02-8c7e-1f4b8a593913") },
                    { new Guid("ce09657d-5d85-4d73-94e0-4dcf98320922"), "https://www.kp.ru/", "//a[contains(@href, '/news/')]/@href", new Guid("fb88ee1e-9e21-443b-88b2-d0e932247d39") },
                    { new Guid("d825b5c5-ca59-4c1c-918b-85c97c83fe48"), "https://lenta.ru/", "//a[starts-with(@href, '/news/')]/@href", new Guid("b795f4e6-b74b-4b67-907a-0162e720d963") },
                    { new Guid("e26bdb3f-0822-40bc-a4df-86b8398716d2"), "https://www.sports.ru/news/", "//a[contains(@href, '.html') and not(contains(@href, '.html#comments')) and not (contains(@href, '/blogs/'))]/@href", new Guid("8bcc6292-4945-48df-bf9e-b3eb08e15954") },
                    { new Guid("e73dc316-f73d-4bcd-83e8-3752720b2d4b"), "https://www.nytimes.com/", "//a[contains(@href, '.html')]/@href", new Guid("a6d8185f-6b24-402b-b7c1-78f513c4e87b") },
                    { new Guid("ebd78618-dbee-4e32-a15b-e6bb078858d7"), "https://rg.ru/", "//a[contains(@href, '.html')]/@href", new Guid("4e2c9d7b-b6fb-47b1-b02b-0c7c29751e1d") },
                    { new Guid("edd6a341-d302-410e-b9cc-016bbbb62902"), "https://tass.ru/", "//a[contains(@class, 'tass_pkg_link-v5WdK') and contains(substring(@href, 2), '/') and not(contains(@href, '/spec/')) and not(contains(@href, 'spec.tass.ru'))]/@href", new Guid("60a170bd-7d39-4a18-822f-172b2fc26eb5") },
                    { new Guid("ef39acb7-5f0d-4959-8143-58bcefc49a1b"), "https://vz.ru/", "//a[contains(@href, '.html') and not(contains(@href, '#comments')) and not(contains(@href, '?')) and not(contains(@href, '/about/'))]/@href", new Guid("3a58fde9-80be-436d-bfc2-c784ae01aacd") },
                    { new Guid("f1fbe4c0-1613-47db-bb74-e7f47120b048"), "https://svpressa.ru/all/news/", "//a[contains(@href, '/news/') and not(contains(@href, '?')) and not(starts-with(@href, '/all/news/'))]/@href", new Guid("44833008-4e54-4db4-9c14-144bbbf31681") },
                    { new Guid("f2a5c12b-cc0b-4e9d-aaa7-28ef0d8cc625"), "https://www.ixbt.com/news/", "//a[starts-with(@href, '/news/') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("cef6d844-69d2-4052-a1a6-147c147e026a") },
                    { new Guid("fcbe6410-f854-4970-a5ef-5f672392d184"), "https://www.1obl.ru/news/", "//a[starts-with(@href, '/news/') and not(contains(@href, '?'))]/@href", new Guid("16921563-c306-4151-a4fe-84feca5bf907") }
                });

            migrationBuilder.InsertData(
                table: "news_source_logos",
                columns: new[] { "id", "original", "small", "source_id" },
                values: new object[,]
                {
                    { new Guid("02a4ca8f-75af-4881-be94-0e8f0bbb9bc2"), "https://static.ngs.ru/jtnews/dist/static/favicons/apple/apple-favicon-74-180.png", "https://static.ngs.ru/jtnews/dist/static/favicons/favicon-rugion-32.ico", new Guid("f6028a8e-7569-4fd8-b9c1-689f483ddb67") },
                    { new Guid("02bac2cc-d2a7-41c6-b999-fba7c14c7765"), "https://www.interfax.ru/touch-icon-ipad-retina.png", "https://www.interfax.ru/touch-icon-iphone.png", new Guid("4deff799-6286-4c7f-9aef-e5849549f49e") },
                    { new Guid("0aaaf697-4cf9-4f79-8bee-76e327541eb5"), "https://cdnstatic.rg.ru/images/touch-icon-ipad-retina_512x512.png", "https://rg.ru/favicon.ico", new Guid("4e2c9d7b-b6fb-47b1-b02b-0c7c29751e1d") },
                    { new Guid("16a7d959-c05c-4e03-a20d-41296217e407"), "https://www.nytimes.com/vi-assets/static-assets/apple-touch-icon-28865b72953380a40aa43318108876cb.png", "https://www.nytimes.com/vi-assets/static-assets/ios-default-homescreen-57x57-dark-b395ebcad5b63aff9285aab58e31035e.png", new Guid("a6d8185f-6b24-402b-b7c1-78f513c4e87b") },
                    { new Guid("16b23b16-5b37-476a-9cc9-0ba98eec9147"), "https://tsargrad.tv/favicons/apple-touch-icon-180x180.png?s2", "https://tsargrad.tv/favicons/favicon-32x32.png?s2", new Guid("152f014b-adc5-417c-a77a-e7954ccea85f") },
                    { new Guid("2e463491-5f23-4693-8977-989ef2035d64"), "https://www.m24.ru/img/fav/apple-touch-icon.png", "https://www.m24.ru/img/fav/favicon-32x32.png", new Guid("1e6056d2-4d80-4c19-aa1a-b801bbd13b94") },
                    { new Guid("3b253580-f834-45fc-9d39-e71f4a5fcc14"), "https://www.sports.ru/apple-touch-icon-1024.png", "https://www.sports.ru/apple-touch-icon-76.png", new Guid("8bcc6292-4945-48df-bf9e-b3eb08e15954") },
                    { new Guid("40935a4e-3273-4d65-9ef5-5f8d7ce4840d"), "https://cdnn21.img.ria.ru/i/favicons/favicon.svg", "https://cdnn21.img.ria.ru/i/favicons/favicon.ico", new Guid("45969ebf-b644-447a-9c24-f053cd0c275a") },
                    { new Guid("46e4b315-b5bd-49fb-819e-aad904a2ecb6"), "https://russian.rt.com/static/blocks/touch-icon/apple-touch-icon-144x144-precomposed.png", "https://russian.rt.com/favicon.ico", new Guid("124cbee6-1024-4a3e-9c5e-0c933a7038da") },
                    { new Guid("4a4840fe-9982-4e2a-a721-afd9ac575a6f"), "https://ura.news/apple-touch-icon.png", "https://s.ura.news/favicon.ico?3", new Guid("1a59b2d6-eebb-4947-9320-47b934dabf02") },
                    { new Guid("4a5f46ad-8f1a-4af6-9ade-a9346a9611ba"), "https://icdn.lenta.ru/images/icons/icon-256x256.png", "https://icdn.lenta.ru/favicon.ico", new Guid("b795f4e6-b74b-4b67-907a-0162e720d963") },
                    { new Guid("5ff4b311-e43d-41f7-8ba1-cc36a173fdee"), "https://www.cybersport.ru/favicon-192x192.png", "https://www.cybersport.ru/favicon-32x32.png", new Guid("a0d63964-fcb9-4684-a646-2ae8835609d1") },
                    { new Guid("71e6a420-f907-424f-8b8b-82afdd14acfa"), "https://cdn.iz.ru/profiles/portal/themes/purple/images/favicons/android-icon-192x192.png", "https://cdn.iz.ru/profiles/portal/themes/purple/images/favicons/favicon-32x32.png", new Guid("ddfa3107-7ce2-4359-bb91-6314782064ab") },
                    { new Guid("77a16d65-eccd-4c27-a1b9-adc713b95996"), "https://3dnews.ru/assets/images/3dnews_logo_soc.png", "https://3dnews.ru/assets/3dnews_logo_color.png", new Guid("7a70bd26-6c97-4335-b1ee-6ab6768cbf34") },
                    { new Guid("8210f7df-c1a0-4c4b-ab5a-5dfcf9a7e9d0"), "https://www.ixbt.com/favicon.ico", "https://www.ixbt.com/favicon.ico", new Guid("cef6d844-69d2-4052-a1a6-147c147e026a") },
                    { new Guid("8364336f-46a3-4d71-86f7-b872dad2820e"), "https://www.pravda.ru/pix/apple-touch-icon.png", "https://www.pravda.ru/favicon.ico", new Guid("5111f651-fc32-498c-9ad5-97f9a81f99d4") },
                    { new Guid("87942ca0-748c-4ae1-bd00-f6bfdf262079"), "https://tass.ru/favicon/180.svg", "https://tass.ru/favicon/57.png", new Guid("60a170bd-7d39-4a18-822f-172b2fc26eb5") },
                    { new Guid("9237d5bd-61c7-45e2-a498-199118555174"), "https://edition.cnn.com/media/sites/cnn/apple-touch-icon.png", "https://edition.cnn.com/media/sites/cnn/favicon.ico", new Guid("53adf9ee-9e10-4288-b568-002b9b0caf0f") },
                    { new Guid("9a90b4d4-f3be-4f27-8308-5c8560ddbbb1"), "https://www.belta.by/images/storage/banners/000016_a133e848cb2e7b1debb7102d19e4d139_work.svg", "https://www.belta.by/images/storage/banners/000016_a133e848cb2e7b1debb7102d19e4d139_work.svg", new Guid("f11fcd12-e088-4f02-8c7e-1f4b8a593913") },
                    { new Guid("9ccc9bcf-80aa-48a4-af99-080293756c23"), "https://www.1obl.ru/apple-touch-icon.png", "https://www.1obl.ru/favicon-32x32.png", new Guid("16921563-c306-4151-a4fe-84feca5bf907") },
                    { new Guid("9f2742b2-3de6-41c9-beed-3588a6b768d1"), "https://life.ru/appletouch/apple-icon-180%D1%85180.png", "https://life.ru/favicon-32%D1%8532.png", new Guid("67fdbd9f-910c-4d4f-9c5d-fd774e648ebb") },
                    { new Guid("a272c52b-a862-474a-a9f4-d67e953d46dc"), "https://ixbt.games/images/favicon/gt/apple-touch-icon.png", "https://ixbt.games/images/favicon/gt/apple-touch-icon.png", new Guid("140af428-7470-4359-8d41-a11c6f8f1296") },
                    { new Guid("a4ffc4fa-32cd-4b15-b3cb-2a3bdb8cc01a"), "https://svpressa.ru/favicon-96x96.png?v=1471426270000", "https://svpressa.ru/favicon-32x32.png?v=1471426270000", new Guid("44833008-4e54-4db4-9c14-144bbbf31681") },
                    { new Guid("afc48ec5-4732-49a5-b892-cb0848a0e91b"), "https://aif.ru/img/icon/apple-touch-icon.png?44f", "https://aif.ru/img/icon/favicon-32x32.png?44f", new Guid("d9fc32f0-49a5-438b-8f4a-a12ecbd64cf5") },
                    { new Guid("b42a01f7-c02d-48bc-bc16-22ad72ce3147"), "https://www.hltv.org/img/static/favicon/apple-touch-icon.png", "https://www.hltv.org/img/static/favicon/favicon-32x32.png", new Guid("a25689eb-af08-4db9-90a4-0c8b1ff0a077") },
                    { new Guid("b8ad9304-9eba-41bc-a72f-eab927eb450e"), "https://st.championat.com/i/favicon/apple-touch-icon.png", "https://st.championat.com/i/favicon/favicon-32x32.png", new Guid("4efd0f06-a505-4db0-a58f-53226f316c3b") },
                    { new Guid("bd8f030f-9ad1-4f6a-9c5d-c2e1ca88494e"), "https://s01.stc.yc.kpcdn.net/s0/2.1.321/adaptive/favicon-128.png", "https://s01.stc.yc.kpcdn.net/s0/2.1.321/adaptive/favicon-32.png", new Guid("fb88ee1e-9e21-443b-88b2-d0e932247d39") },
                    { new Guid("befc0792-2ce3-4ed0-9493-540ac17e78e0"), "https://static.gazeta.ru/nm2021/img/icons/favicon.svg", "https://static.gazeta.ru/nm2021/img/icons/favicon.svg", new Guid("74018562-9296-484e-9399-6c1725aa5658") },
                    { new Guid("e45baca9-70a9-425d-845a-c9332467ab6c"), "https://im.kommersant.ru/ContentFlex/images/favicons2020/apple-touch-icon-180.png", "https://im.kommersant.ru/ContentFlex/images/favicons2020/favicon-32.png", new Guid("900494d6-4599-4ca5-aa75-79a287b06bfa") },
                    { new Guid("ea95127d-8d78-4ce4-82a1-bea15cbc2672"), "https://s.rbk.ru/v10_rbcnews_static/common/common-10.10.120/images/android-chrome-512x512.png", "https://s.rbk.ru/v10_rbcnews_static/common/common-10.10.120/images/favicon.png", new Guid("37cfc39a-4c6f-4b6e-a896-c8291621d53e") },
                    { new Guid("eeecbd75-628d-4a64-8cf3-27fceb47305d"), "https://vz.ru/apple-touch-icon.png", "https://vz.ru/static/images/favicon.ico", new Guid("3a58fde9-80be-436d-bfc2-c784ae01aacd") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_editor_settings",
                columns: new[] { "id", "is_required", "name_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("05a8204b-d971-44f0-a6c0-463a4b061e3a"), true, "//span[@itemprop='author']/span[@itemprop='name']/@content", new Guid("05df79d9-7007-4a9a-8013-f3abacc092e6") },
                    { new Guid("0dddbe6d-3678-4376-96e5-f725f36fc017"), true, "//*[@itemprop='author']/*[@itemprop='name']//text()", new Guid("e3989a89-fd8c-4f17-b908-42047971638c") },
                    { new Guid("16c449c8-e093-467c-81b6-9fe0eb53bfa9"), true, "//div[@itemprop='author']/span[@itemprop='name']/text()", new Guid("f0ccbec0-7a27-4a80-b55c-b674f56b83ca") },
                    { new Guid("1ae582d6-ada8-4013-8133-3f78f8d15825"), true, "//div[contains(@class, 'full-article')]/div[@class='authors-block']//span[text()='Автор']/../a/text()", new Guid("ec5cb8ee-73ad-46d8-acf3-8cfa31e1b254") },
                    { new Guid("20527613-da64-4d3b-bb9b-353c2db34c3e"), true, "//div[@class='container-fluid publication-footer']//a[contains(@class, 'text-secondary')]/@title", new Guid("a418ae38-d4cb-479f-9a6b-ebc514037ad1") },
                    { new Guid("218175fd-1ab8-4b70-ae34-20cc8052dbf7"), true, "//article//header//div[@class='article-head__author-name']/a[@rel='author']/span/text()", new Guid("53eaeace-f448-4272-aa46-81f56a74cf8d") },
                    { new Guid("3f2b4426-527d-4c13-a80d-62311089db6a"), true, "//div[contains(@class, 'PageArticleContent_authors')]//a[contains(@class, 'LinksOfAuthor_item')]/text()", new Guid("4b61a21f-568c-42b4-a582-112787958a2d") },
                    { new Guid("499749b4-1a5d-44b9-86db-84cbed6767a0"), true, "//footer[@class='news-item__footer']/div[@class='news-item__footer-after-news']/p[position()=1]//span/text()", new Guid("02fad26b-a95f-4d46-a7c9-8762ae0f8134") },
                    { new Guid("4d90e5cc-7257-41f1-b7df-9b5f546e306b"), true, "//article//span[@class='author']/a[@class='authorName']/span/text()", new Guid("3b732126-69d3-4190-b677-398b9d4d452b") },
                    { new Guid("61b28f43-daf6-4b9a-a168-546c7c9ff375"), false, "//p[@class='doc__text document_authors']/text()", new Guid("fa8c4179-2296-40f2-a831-a49b50bc1c95") },
                    { new Guid("643c4333-d630-481a-82c6-d6a9b173f991"), true, "//a[@class='article__author']/text()", new Guid("219bc6f5-2d7a-4517-8f83-83cc29cbe2cd") },
                    { new Guid("6d7c882f-dc28-4a1a-bee7-a43c8c21c6a9"), false, "//div[@itemprop='author']//p[@itemprop='name']/text()", new Guid("06e0d828-1e71-4db2-9a6b-9ce66c6cb82c") },
                    { new Guid("9aaa6a4f-c8b2-4908-a672-51c40849c165"), false, "//div[@class='topic-authors']/a[@class='topic-authors__author']/text()", new Guid("03d93f48-edb7-4bce-8e37-a603de0deccc") },
                    { new Guid("abf47cd4-75e4-4d09-9080-02af5c99cc20"), false, "//meta[@property='article:author']/@content", new Guid("35e374bb-fd03-4637-9b51-6325de8d1f8b") },
                    { new Guid("b5f3ea99-cc4d-4cba-8e9d-68c6cf0b4ab5"), true, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']//a[@itemprop='author']//span[@itemprop='name']/text()", new Guid("ca89bf1b-c939-4781-92a0-0ef67bd9dea6") },
                    { new Guid("c9d01ae2-66bc-48e9-ae7c-bf0cb7436d59"), true, "//div[contains(@class, 'styles_bodyWrapper')]//div[contains(@class, 'styles_authorsLinks')]/a/text()", new Guid("54f1d5d5-c78b-441b-a9e2-084a87a83f69") },
                    { new Guid("d67619ec-22ce-4422-95b1-2d20d4fd1565"), false, "//div[@class='article__authors']//*[@class='article__authors__author']/span[@class='article__authors__author__name']/text()", new Guid("df3024d6-97f2-4777-8971-6ae5beefd8d6") },
                    { new Guid("db9c2da0-5faa-4501-9168-6ceeb7689362"), true, "//div[@class='headline__footer']//div[@class='byline__names']/span[@class='byline__name']/text()", new Guid("dd9f3d71-2974-4ede-b96d-6cd2fc85f5ff") },
                    { new Guid("e4fb180c-1094-47bc-8a22-7d8eeb0e780d"), false, "//div[@class='author']/span[@itemprop='author']/span[@itemprop='name']/a/text()", new Guid("d0a90bb4-1793-4099-9a2b-8277ed784b1b") },
                    { new Guid("e9dee87d-7f6c-48f3-a511-fbc27df7b751"), true, "//span[@itemprop='name']/a/text()", new Guid("5c108d6a-3e29-4ac1-83ee-af335d5809de") },
                    { new Guid("f14be9c8-74b4-45e2-8978-93c8212854d2"), true, "//div[@class='article_top']//div[@class='authors']//div[@class='autor']//span/text()", new Guid("ff453439-4dc9-4b63-a01d-401c8ad8290f") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_modified_at_settings",
                columns: new[] { "id", "is_required", "modified_at_culture_info", "modified_at_time_zone_info_id", "modified_at_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("6539f6b9-f3bb-435b-b002-7cc0a99dd109"), false, "ru-RU", "UTC", "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark_update')]//span[@ca-ts]/text()", new Guid("2c684f99-4d5f-4d39-ab68-a193d1f856be") },
                    { new Guid("70187950-553e-424e-8e3a-e3020172ec0e"), true, "ru-RU", "Russian Standard Time", "//meta[@property='article:modified_time']/@content", new Guid("f5f7e3a7-e7cd-48d0-9b7f-988e397b9056") },
                    { new Guid("9e417e0a-d393-40de-850e-2cc894e171a6"), false, "ru-RU", null, "//meta[@itemprop='dateModified']/@content", new Guid("df3024d6-97f2-4777-8971-6ae5beefd8d6") },
                    { new Guid("bfd983a8-ee54-419d-9b90-76fcbfeb752e"), true, "ru-RU", "Russian Standard Time", "//div[@class='article__info']//div[@class='article__info-date']/span[@class='article__info-date-modified']/text()", new Guid("aeff35e9-ba98-4db2-9819-78893432c10f") },
                    { new Guid("da4c9ec4-5b0b-4e47-87ec-af1f8c70ab02"), false, "ru-RU", "Russian Standard Time", "//div[@class='doc_header__time']/span[contains(@class, 'publish_update')]/text()", new Guid("fa8c4179-2296-40f2-a831-a49b50bc1c95") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_picture_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("0897316d-ce2b-40dc-a24a-e6422aa06278"), false, new Guid("4b61a21f-568c-42b4-a582-112787958a2d"), "//meta[@property='og:image']/@content" },
                    { new Guid("1a909321-46d3-4012-a705-8153be5d88de"), false, new Guid("53eaeace-f448-4272-aa46-81f56a74cf8d"), "//article//header/div[@class='article-head__photo']/img/@src" },
                    { new Guid("1f71835c-7f91-46ee-9c5d-c95115b42b7c"), false, new Guid("06e0d828-1e71-4db2-9a6b-9ce66c6cb82c"), "//figure//img/@src" },
                    { new Guid("34101056-4721-4d17-a39d-afcd35c8a011"), false, new Guid("7893cdf9-d4a6-44ff-9559-cbabae4ca1da"), "//meta[@property='og:image']/@content" },
                    { new Guid("40ed620d-c926-484a-9678-c10ce3cb3885"), true, new Guid("e684b8d9-0b92-4824-ad8e-8898003641f7"), "//meta[@property='og:image']/@content" },
                    { new Guid("4839e11b-6ed9-4b53-b56d-d79c4c4af830"), true, new Guid("35e374bb-fd03-4637-9b51-6325de8d1f8b"), "//div[contains(@class, 'big_photo')]//div[@class='big_photo__img']//img/@data-src" },
                    { new Guid("5318b4ec-97b3-4afb-af20-28ec85b64677"), true, new Guid("5c108d6a-3e29-4ac1-83ee-af335d5809de"), "//header//figure//picture/img/@src" },
                    { new Guid("5bb3adf2-8111-4eeb-99ef-64dc12c86118"), false, new Guid("ec5cb8ee-73ad-46d8-acf3-8cfa31e1b254"), "//div[contains(@class, 'full-article')]/div[contains(@class, 'gallery')]/picture/img/@src" },
                    { new Guid("68ebaded-a9d7-477c-b013-65bff9515d9a"), false, new Guid("3b732126-69d3-4190-b677-398b9d4d452b"), "//article//div[@class='image-con' and position() = 1]/picture/img/@src" },
                    { new Guid("69dad069-fb0b-470f-a060-01a8fa57277c"), false, new Guid("aeff35e9-ba98-4db2-9819-78893432c10f"), "//div[@class='photoview__open']/img/@src" },
                    { new Guid("6bd117bd-2e42-4bed-b519-d8adb8ee9b00"), false, new Guid("0ca09c5d-1ec1-41c1-b2e4-555ed5329930"), "//article/figure/img/@src" },
                    { new Guid("6d6224d7-d83a-47ff-a3d0-10c8d1e7d2d0"), false, new Guid("88b069e5-1cc6-4a5a-bcb1-14f0c0d72fff"), "//div[contains(@class, 'article__cover')]/img[@class='article__cover-image ']/@src" },
                    { new Guid("787a159a-190e-4a19-a363-d00228306cd5"), true, new Guid("f5f7e3a7-e7cd-48d0-9b7f-988e397b9056"), "//div[@data-gtm-el='content-body']//picture/img/@src" },
                    { new Guid("844d2578-34ba-470b-894c-325353b9d707"), true, new Guid("a418ae38-d4cb-479f-9a6b-ebc514037ad1"), "//a[@class='glightbox']/img[contains(@class, 'pub-cover')]/@src" },
                    { new Guid("8c40fb9c-7b2e-4714-ac43-c19b388555f7"), true, new Guid("dd9f3d71-2974-4ede-b96d-6cd2fc85f5ff"), "//div[contains(@class, 'article__lede-wrapper')]//picture/img/@src" },
                    { new Guid("8fafb61a-39be-4286-8a59-9111d19dc89b"), false, new Guid("df3024d6-97f2-4777-8971-6ae5beefd8d6"), "//meta[@itemprop='url']/@content" },
                    { new Guid("929513a4-26e8-4f9f-a550-720e4630eafa"), false, new Guid("78b60ed5-7609-4a64-8008-4d151b12d817"), "//meta[@property='og:image']/@content" },
                    { new Guid("b7884f76-0f9c-4ae2-8ed0-32c042875dcc"), false, new Guid("54f1d5d5-c78b-441b-a9e2-084a87a83f69"), "//article//header/div[contains(@class, 'styles_cover_media')]/img/@src" },
                    { new Guid("b8db157c-1bfe-42f8-86d1-44ec50a43998"), false, new Guid("f1467024-27c3-4c32-b394-c6771f70e258"), "//div[@class='inner_content']//div[@class='main_img']//img/@src" },
                    { new Guid("b93c7dc1-0705-456e-81e3-de660ca08d13"), false, new Guid("2c684f99-4d5f-4d39-ab68-a193d1f856be"), "//div[contains(@class, 'HeaderMedia_image')]//img[contains(@class, 'Image_image')]/@src" },
                    { new Guid("bbd3996e-36fd-4840-8edf-18b7a4943998"), true, new Guid("219bc6f5-2d7a-4517-8f83-83cc29cbe2cd"), "//div[@class='article__media']//img/@src" },
                    { new Guid("cea1e3ac-eaef-4750-81f0-f452cf45a882"), false, new Guid("03d93f48-edb7-4bce-8e37-a603de0deccc"), "//div[contains(@class, 'topic-body__title-image')]//img[contains(@class, 'picture__image')]/@src" },
                    { new Guid("cf75c580-f96d-48e8-a589-fcc517b19aa1"), true, new Guid("f0ccbec0-7a27-4a80-b55c-b674f56b83ca"), "//div[@itemprop='articleBody']//div[@itemprop='image']/picture/img[@itemprop='contentUrl']/@src" },
                    { new Guid("d677f9ed-de54-4fb3-998d-93c2bb47698c"), false, new Guid("ca89bf1b-c939-4781-92a0-0ef67bd9dea6"), "//img[@itemprop='image']/@src" },
                    { new Guid("d7a980a0-f80f-4ff0-829e-3143db486283"), true, new Guid("e3989a89-fd8c-4f17-b908-42047971638c"), "//div[contains(@class, 'newsMediaContainer')]/img/@data-src" },
                    { new Guid("da231194-9690-4b87-9588-2fbae97c6b2e"), false, new Guid("ff453439-4dc9-4b63-a01d-401c8ad8290f"), "//div[@class='img_box']/a[@class='zoom_js']/img/@src" },
                    { new Guid("f385bf98-80d7-46cc-9659-ffd1e19901a2"), false, new Guid("d0a90bb4-1793-4099-9a2b-8277ed784b1b"), "//div[@class='b_article-media']//div[@class='mainarea-wrapper']/figure/img[@class='item-image-front']/@src" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "published_at_culture_info", "published_at_time_zone_info_id", "published_at_x_path" },
                values: new object[,]
                {
                    { new Guid("00370dfc-c896-492e-a2d5-f734c7dc0ffe"), true, new Guid("6a0c0a18-2c05-4bce-bda2-efe743b3f36d"), "ru-RU", "Russian Standard Time", "//article[@itemprop='articleBody']/meta[@itemprop='datePublished']/@content" },
                    { new Guid("00f59fab-0b5e-4027-ac21-7b93a0fe2b26"), true, new Guid("78b60ed5-7609-4a64-8008-4d151b12d817"), "ru-RU", "Russian Standard Time", "//p[@class='b-material__date']/text()" },
                    { new Guid("0b9a9169-2751-41e5-89c7-6e818cc7e2f9"), true, new Guid("02fad26b-a95f-4d46-a7c9-8762ae0f8134"), "ru-RU", null, "//header[@class='news-item__header']//time/@content" },
                    { new Guid("1365b264-a13c-4181-865c-5fcbcde1e917"), true, new Guid("2c684f99-4d5f-4d39-ab68-a193d1f856be"), "ru-RU", "UTC", "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark')]//span[@ca-ts]/text()" },
                    { new Guid("140f6f55-9281-4b8a-b0bc-8c7f81623cf2"), true, new Guid("5c108d6a-3e29-4ac1-83ee-af335d5809de"), "en-US", null, "//time/@datetime" },
                    { new Guid("1623d5cb-c6ad-40e1-83a5-328e4c43ca0c"), true, new Guid("0ca09c5d-1ec1-41c1-b2e4-555ed5329930"), "ru-RU", "Russian Standard Time", "//article/div[@class='header']/span/text()" },
                    { new Guid("2172f069-ec58-4852-ad2e-0286fb67118a"), true, new Guid("06e0d828-1e71-4db2-9a6b-9ce66c6cb82c"), "ru-RU", "Ekaterinburg Standard Time", "//div[@itemprop='datePublished']/time/@datetime" },
                    { new Guid("25eaf935-bb1a-4c00-97e5-3595cc0b32df"), true, new Guid("88b069e5-1cc6-4a5a-bcb1-14f0c0d72fff"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'article__date-autor-shortcode')]/div[contains(@class, 'article__date')]/time[@class='date']/@datetime" },
                    { new Guid("27d0e969-d8f9-4643-bd37-0b249e71bff7"), true, new Guid("ec5cb8ee-73ad-46d8-acf3-8cfa31e1b254"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'full-article')]//time/text()" },
                    { new Guid("2b381663-ecce-4049-ac22-dc7180daf73a"), true, new Guid("05df79d9-7007-4a9a-8013-f3abacc092e6"), "ru-RU", "Russian Standard Time", "//div[@class='b-article__top-author']/p[@class='date']/text()" },
                    { new Guid("3175c1a1-01b9-4e33-ac84-3cc28db9cca7"), true, new Guid("54f1d5d5-c78b-441b-a9e2-084a87a83f69"), "ru-RU", "UTC", "//article//header//div[contains(@class, 'styles_meta')]//div[contains(@class, 'styles_metaItem')]/text()" },
                    { new Guid("4b39e545-0ef1-44a6-a7de-6eca7fbee816"), true, new Guid("fa8c4179-2296-40f2-a831-a49b50bc1c95"), "ru-RU", null, "//div[@class='doc_header__time']/time[@class='doc_header__publish_time']/@datetime" },
                    { new Guid("53e2bc72-f88f-4e73-a00f-a3a61b3939b1"), true, new Guid("03d93f48-edb7-4bce-8e37-a603de0deccc"), "ru-RU", "Russian Standard Time", "//div[@class='topic-page__header']//a[contains(@class, 'topic-header__time')]/text()" },
                    { new Guid("54394100-e651-44d9-99ef-a2ab9c1eab39"), false, new Guid("a418ae38-d4cb-479f-9a6b-ebc514037ad1"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'pubdatetime')]/text()" },
                    { new Guid("7bce7dbf-c7df-4bfc-9b88-629aca6698f3"), true, new Guid("53eaeace-f448-4272-aa46-81f56a74cf8d"), "ru-RU", "Russian Standard Time", "//article//header//time[@class='article-head__date']/text()" },
                    { new Guid("83dd7ced-efd6-482e-9236-672107b1bc0b"), true, new Guid("ca89bf1b-c939-4781-92a0-0ef67bd9dea6"), "ru-RU", null, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']/span[@itemprop='datePublished']/@content" },
                    { new Guid("8c49e75c-a346-48f3-b253-0e71af31486b"), true, new Guid("e684b8d9-0b92-4824-ad8e-8898003641f7"), "ru-RU", null, "//article/header//time/@datetime" },
                    { new Guid("906349e5-6045-483f-a1cc-9a642e0f6f38"), true, new Guid("3b732126-69d3-4190-b677-398b9d4d452b"), "en-US", "Central Europe Standard Time", "//article//div[@class='article-info']/div[@class='date']/text()" },
                    { new Guid("a711352c-e350-45c0-a8dd-e31711bb64ef"), true, new Guid("aeff35e9-ba98-4db2-9819-78893432c10f"), "ru-RU", "Russian Standard Time", "//div[@class='article__info']//div[@class='article__info-date']/a/text()" },
                    { new Guid("a78fdd7d-4929-406f-bd92-a3aec51f30e3"), true, new Guid("35e374bb-fd03-4637-9b51-6325de8d1f8b"), "ru-RU", null, "//div[@class='article_page__left__top__left']//div[@class='article_page__left__top__time']//time/@datetime" },
                    { new Guid("a7dbecbf-9770-4fed-abf0-f08f6aa90a33"), true, new Guid("219bc6f5-2d7a-4517-8f83-83cc29cbe2cd"), "ru-RU", "Russian Standard Time", "//div[@class='article__meta']/time/text()" },
                    { new Guid("b76f9d2e-4293-4c4f-a4b3-dea4825abcce"), true, new Guid("4b61a21f-568c-42b4-a582-112787958a2d"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'PageArticleContent_date')]/text()" },
                    { new Guid("c66d79b2-5a9f-4ee4-a852-02641cbf4ae7"), true, new Guid("f1467024-27c3-4c32-b394-c6771f70e258"), "ru-RU", "Russian Standard Time", "//div[@class='date_full']/text()" },
                    { new Guid("c7c6c49e-426f-44bd-9f5b-e678d97b7111"), true, new Guid("df3024d6-97f2-4777-8971-6ae5beefd8d6"), "ru-RU", null, "//div[@class='article__header__info-block']/time[@class='article__header__date']/@datetime" },
                    { new Guid("cde66d7c-fe79-4e3c-9852-92e9aecf9c2e"), true, new Guid("f0ccbec0-7a27-4a80-b55c-b674f56b83ca"), "ru-RU", null, "//div[@class='publication-info']/time[@itemprop='datePublished']/@datetime" },
                    { new Guid("ce5950bc-016c-4725-b289-137ec5efbb45"), true, new Guid("dd9f3d71-2974-4ede-b96d-6cd2fc85f5ff"), "en-US", "Eastern Standard Time", "//div[@class='headline__footer']//div[contains(@class, 'headline__byline-sub-text')]/div[@class='timestamp']/text()" },
                    { new Guid("e3b91a98-df65-406d-9dc2-d70a4bebaa73"), true, new Guid("e3989a89-fd8c-4f17-b908-42047971638c"), "ru-RU", null, "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("e546adec-9d5d-4490-8ef7-7833ce0569b1"), true, new Guid("d0a90bb4-1793-4099-9a2b-8277ed784b1b"), "ru-RU", null, "//article/div[@class='b_article-header']//time[@itemprop='datePublished']/@datetime" },
                    { new Guid("e948f5cb-9714-4f93-9a27-e2be53fca31e"), true, new Guid("f5f7e3a7-e7cd-48d0-9b7f-988e397b9056"), "ru-RU", "Russian Standard Time", "//meta[@property='article:published_time']/@content" },
                    { new Guid("eca14bbc-d96f-4d69-8aa7-b99c48434d02"), true, new Guid("7893cdf9-d4a6-44ff-9559-cbabae4ca1da"), "ru-RU", "Russian Standard Time", "//div[@class='b-text__date']/text()" },
                    { new Guid("ee18251d-a953-4841-8e55-ab6b81d50200"), true, new Guid("ff453439-4dc9-4b63-a01d-401c8ad8290f"), "ru-RU", "Russian Standard Time", "//div[@class='article_top']//div[@class='date']//time/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_sub_title_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("085a7989-2a3d-4b05-878b-b31547a045dd"), false, new Guid("f0ccbec0-7a27-4a80-b55c-b674f56b83ca"), "//meta[@itemprop='description']/@content" },
                    { new Guid("107a647a-7bd3-402b-93c0-5916a2b37184"), true, new Guid("e684b8d9-0b92-4824-ad8e-8898003641f7"), "//div[contains(@class, 'js-mediator-article')]/*[position()=1]/text()" },
                    { new Guid("1c144882-f32c-4dea-bf79-4a86bf6f4ef2"), true, new Guid("06e0d828-1e71-4db2-9a6b-9ce66c6cb82c"), "//p[@itemprop='alternativeHeadline']/span/text()" },
                    { new Guid("280f6cc8-eb93-4974-aba6-f73e8768aadf"), true, new Guid("ec5cb8ee-73ad-46d8-acf3-8cfa31e1b254"), "//h1/text()" },
                    { new Guid("2a30f710-bd39-4687-b0d8-6b7549827c37"), false, new Guid("54f1d5d5-c78b-441b-a9e2-084a87a83f69"), "//article//header//p[contains(@class, 'styles_subtitle')]/text()" },
                    { new Guid("30610cf9-97a7-4b5b-8f4f-0fd936e7dbfc"), true, new Guid("a418ae38-d4cb-479f-9a6b-ebc514037ad1"), "//div[@class='container-fluid shifted']/p[@class='announce lead']/text()" },
                    { new Guid("48239d8c-2839-4288-b4e2-e5a25a8204e3"), false, new Guid("7893cdf9-d4a6-44ff-9559-cbabae4ca1da"), "//meta[@property='og:description']/@content" },
                    { new Guid("618b11b4-10d1-461c-9ffc-6732f4df66a8"), true, new Guid("d0a90bb4-1793-4099-9a2b-8277ed784b1b"), "//h2/text()" },
                    { new Guid("6ec15049-c793-4922-9738-fd1ee95afd09"), true, new Guid("5c108d6a-3e29-4ac1-83ee-af335d5809de"), "//header/p[@id='article-summary']/text()" },
                    { new Guid("7bc5b661-197c-49c1-9ff6-35e161a96542"), true, new Guid("219bc6f5-2d7a-4517-8f83-83cc29cbe2cd"), "//div[@class='article__intro']/p/text()" },
                    { new Guid("82cf964a-5173-42de-b414-0ae49455da44"), false, new Guid("df3024d6-97f2-4777-8971-6ae5beefd8d6"), "//div[contains(@class, 'article__text')]/div[@class='article__text__overview']/span/text()" },
                    { new Guid("981a9bad-91a3-400c-b7e1-9f9a60226377"), false, new Guid("05df79d9-7007-4a9a-8013-f3abacc092e6"), "//h4/text()" },
                    { new Guid("b545cd8c-46e3-4c35-88e0-2d39accceaf9"), true, new Guid("88b069e5-1cc6-4a5a-bcb1-14f0c0d72fff"), "//div[contains(@class, 'article__summary')]/text()" },
                    { new Guid("b95863ed-20c3-478c-be47-7e8295de66d5"), true, new Guid("ca89bf1b-c939-4781-92a0-0ef67bd9dea6"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()=1]/text()" },
                    { new Guid("bda8f0c9-e045-4ff6-97fe-7a67ae726d12"), false, new Guid("4b61a21f-568c-42b4-a582-112787958a2d"), "//div[contains(@class, 'PageArticleContent_lead')]/text()" },
                    { new Guid("ca73766d-f233-45d3-b230-c011765fc600"), true, new Guid("e3989a89-fd8c-4f17-b908-42047971638c"), "//div[@itemprop='alternativeHeadline']/text()" },
                    { new Guid("cba13d4d-d60e-4589-92f2-04b098769218"), false, new Guid("03d93f48-edb7-4bce-8e37-a603de0deccc"), "//div[contains(@class, 'topic-body__title')]/text()" },
                    { new Guid("cef0e959-5a9b-4e21-af7c-a1d76f2afaad"), false, new Guid("35e374bb-fd03-4637-9b51-6325de8d1f8b"), "//div[@itemprop='alternativeHeadline']/text()" },
                    { new Guid("d23802b6-c0a4-41eb-b48c-e71893bea9d0"), true, new Guid("f5f7e3a7-e7cd-48d0-9b7f-988e397b9056"), "//meta[@name='description']/@content" },
                    { new Guid("d35dd1d1-00ac-4040-a8d7-d7b254219130"), false, new Guid("fa8c4179-2296-40f2-a831-a49b50bc1c95"), "//header[@class='doc_header']/h2[contains(@class, 'doc_header__subheader')]/text()" },
                    { new Guid("d72b73bd-f9f6-4358-8c15-c5ab4c62cae4"), false, new Guid("2c684f99-4d5f-4d39-ab68-a193d1f856be"), "//h3/text()" },
                    { new Guid("d9042649-60dd-44de-8328-69849992c0b1"), true, new Guid("aeff35e9-ba98-4db2-9819-78893432c10f"), "//h1[@class='article__second-title']/text()" },
                    { new Guid("e20e090a-4f6a-4761-bce4-bab5a42c611a"), false, new Guid("78b60ed5-7609-4a64-8008-4d151b12d817"), "//meta[@property='og:description']/@content" },
                    { new Guid("e5cafa48-a3d6-4b24-bd30-6cea2180d85b"), true, new Guid("3b732126-69d3-4190-b677-398b9d4d452b"), "//p[@class='headertext' and @itemprop='description']/text()" },
                    { new Guid("f428d7d2-41e4-41e1-b9e3-c42a96aa53c1"), false, new Guid("0ca09c5d-1ec1-41c1-b2e4-555ed5329930"), "//h4/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_video_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("3a0164ca-0df5-4a6d-9f36-2e67b3be764d"), false, new Guid("78b60ed5-7609-4a64-8008-4d151b12d817"), "//meta[@property='og:video:url']/@content" },
                    { new Guid("835edda5-d085-4642-b974-a5ffb281a857"), false, new Guid("aeff35e9-ba98-4db2-9819-78893432c10f"), "//div[@class='article__header']//div[@class='media__video']//video/@src" },
                    { new Guid("9171dfe6-3246-4cd8-a5c1-02e81fecd5cd"), false, new Guid("4b61a21f-568c-42b4-a582-112787958a2d"), "//div[contains(@class, 'PageContentCommonStyling_text')]/rg-video//video/@src" },
                    { new Guid("c5aa98eb-ec09-4052-90b6-3394ec573287"), false, new Guid("3b732126-69d3-4190-b677-398b9d4d452b"), "//article//div[@class='videoWrapper' and @itemprop='video']/iframe[@class='video']/@src" },
                    { new Guid("f9f271f0-f6f3-4d64-9635-b32fa84bef4a"), false, new Guid("03d93f48-edb7-4bce-8e37-a603de0deccc"), "//div[contains(@class='eagleplayer')]//video/@src" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_modified_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_modified_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("3cd5fe48-9611-4863-ae5c-ba39d61a5034"), "(\"обновлено:\" HH:mm dd.MM.yyyy)", new Guid("bfd983a8-ee54-419d-9b90-76fcbfeb752e") },
                    { new Guid("69f01c52-cff8-4896-bdb4-e7454a9732a6"), "\"обновлено\" HH:mm , dd.MM.yyyy", new Guid("da4c9ec4-5b0b-4e47-87ec-af1f8c70ab02") },
                    { new Guid("7b2bc8d9-369c-4c22-b25f-46a75812510f"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("9e417e0a-d393-40de-850e-2cc894e171a6") },
                    { new Guid("7b7fbb3b-7f67-4dbd-9d2c-ba88bf7862b7"), "\"обновлено\" d MMMM yyyy, HH:mm", new Guid("6539f6b9-f3bb-435b-b002-7cc0a99dd109") },
                    { new Guid("8ddc5988-d883-4cf1-844f-b8d3e6ac8dd2"), "\"обновлено\" d MMMM, HH:mm", new Guid("6539f6b9-f3bb-435b-b002-7cc0a99dd109") },
                    { new Guid("9cf83073-a71b-48d0-a9e1-ce0b29016232"), "yyyy-MM-ddTHH:mm:ss.fff\"Z+0300\"", new Guid("70187950-553e-424e-8e3a-e3020172ec0e") },
                    { new Guid("a0148b72-8e89-415a-8f09-5790526a9e1e"), "\"обновлено\" HH:mm , dd.MM", new Guid("da4c9ec4-5b0b-4e47-87ec-af1f8c70ab02") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_published_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("0815bc08-19de-4c79-9495-4ef17ef65d79"), "dd.MM.yyyy HH:mm", new Guid("ee18251d-a953-4841-8e55-ab6b81d50200") },
                    { new Guid("106e0c14-897e-4eed-81ad-da951ad1369a"), "d MMMM yyyy, HH:mm", new Guid("1365b264-a13c-4181-865c-5fcbcde1e917") },
                    { new Guid("12207c3b-23c2-4fc4-baea-1ad8726dfc87"), "yyyy-MM-ddTHH:mm:ss.fffZ", new Guid("8c49e75c-a346-48f3-b253-0e71af31486b") },
                    { new Guid("18f5b82c-0a76-47cd-a51c-9d53dda23737"), "HH:mm dd.MM.yyyy", new Guid("a711352c-e350-45c0-a8dd-e31711bb64ef") },
                    { new Guid("200861f3-2aa9-48f7-a031-c9a6041ef9d8"), "yyyy-MM-ddTHH:mm:ss", new Guid("00370dfc-c896-492e-a2d5-f734c7dc0ffe") },
                    { new Guid("20e1f078-511a-4a16-86e3-af280a38941d"), "d MMMM yyyy, HH:mm", new Guid("3175c1a1-01b9-4e33-ac84-3cc28db9cca7") },
                    { new Guid("225fff9b-8b3f-43ad-a4e0-c9aa968dd495"), "dd MMMM yyyy HH:mm", new Guid("a7dbecbf-9770-4fed-abf0-f08f6aa90a33") },
                    { new Guid("2ba629d9-28e2-408d-9bb1-90aa0d3298b4"), "HH:mm", new Guid("a7dbecbf-9770-4fed-abf0-f08f6aa90a33") },
                    { new Guid("3a5d473a-5566-4056-b74a-64f7932fd082"), "\"Published\n       \" HH:mm tt \"EST\", ddd MMMM d, yyyy", new Guid("ce5950bc-016c-4725-b289-137ec5efbb45") },
                    { new Guid("3c2b8705-da5b-4c7b-83e2-28363632ee68"), "dd.MM.yyyy HH:mm", new Guid("27d0e969-d8f9-4643-bd37-0b249e71bff7") },
                    { new Guid("3da9ba22-28ac-422b-9ff9-77ee9728ba0e"), "d MMMM yyyy, HH:mm,", new Guid("1365b264-a13c-4181-865c-5fcbcde1e917") },
                    { new Guid("3dc2fd08-8f8e-4036-80ec-d549976fd845"), "yyyy-MM-ddTHH:mm:ss", new Guid("2172f069-ec58-4852-ad2e-0286fb67118a") },
                    { new Guid("418baf3a-b98e-496b-af8a-5f79f5b0154b"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("c7c6c49e-426f-44bd-9f5b-e678d97b7111") },
                    { new Guid("42aa02f9-d280-4315-a6e6-39f6d5f9cb93"), "dd MMMM yyyy, HH:mm", new Guid("00f59fab-0b5e-4027-ac21-7b93a0fe2b26") },
                    { new Guid("47688917-8339-4a49-a354-e68df6c93e19"), "yyyy-MM-ddTHH:mm:ss.fff\"Z+0300\"", new Guid("e948f5cb-9714-4f93-9a27-e2be53fca31e") },
                    { new Guid("54fe50a9-1540-41d8-835e-0c0708694015"), "HH:mm", new Guid("00f59fab-0b5e-4027-ac21-7b93a0fe2b26") },
                    { new Guid("5654db99-e946-4f33-8cf7-3fc324301891"), "yyyy-MM-dd HH:mm:ss", new Guid("54394100-e651-44d9-99ef-a2ab9c1eab39") },
                    { new Guid("5aba5e30-b5d0-457f-bb13-7ec5516ea004"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("e3b91a98-df65-406d-9dc2-d70a4bebaa73") },
                    { new Guid("5c9f28ea-6413-41fd-ab03-38825ae16428"), "d MMMM, HH:mm", new Guid("1365b264-a13c-4181-865c-5fcbcde1e917") },
                    { new Guid("5f341c9d-f425-49cc-ab77-842d3b95f05d"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("83dd7ced-efd6-482e-9236-672107b1bc0b") },
                    { new Guid("634151ee-2e6f-4426-8a69-5ab64a03a4a1"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("cde66d7c-fe79-4e3c-9852-92e9aecf9c2e") },
                    { new Guid("6ef7e3e7-4e2f-4957-b35f-334f0d135ec7"), "dd MMMM yyyy, HH:mm", new Guid("c66d79b2-5a9f-4ee4-a852-02641cbf4ae7") },
                    { new Guid("722340cd-4fbb-4d4b-8f36-f202ee0b7baf"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("e546adec-9d5d-4490-8ef7-7833ce0569b1") },
                    { new Guid("7bd39f68-9da3-437a-b03d-ccd02fcb5627"), "d MMMM yyyy \"в\" HH:mm", new Guid("2b381663-ecce-4049-ac22-dc7180daf73a") },
                    { new Guid("7fd8aa58-b112-4d0f-af34-789f13a99c32"), "HH:mm, d MMMM yyyy", new Guid("53e2bc72-f88f-4e73-a00f-a3a61b3939b1") },
                    { new Guid("9e3686f4-8170-45f2-98f0-74c054d77237"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("a78fdd7d-4929-406f-bd92-a3aec51f30e3") },
                    { new Guid("9fdaaa5a-9a57-4422-b374-2fa208a512c8"), "d MMMM  HH:mm", new Guid("eca14bbc-d96f-4d69-8aa7-b99c48434d02") },
                    { new Guid("a10759b7-33b5-4b1f-8d3c-df4f01522fe2"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("4b39e545-0ef1-44a6-a7de-6eca7fbee816") },
                    { new Guid("b310403a-ceda-4ebf-93d1-655ee3acbd2b"), "d MMMM yyyy, HH:mm \"МСК\"", new Guid("7bce7dbf-c7df-4bfc-9b88-629aca6698f3") },
                    { new Guid("b951ba98-0139-49a6-8339-0cd391d84115"), "dd.MM.yyyy HH:mm", new Guid("b76f9d2e-4293-4c4f-a4b3-dea4825abcce") },
                    { new Guid("bdd68990-171f-477d-8f85-65935942c07f"), "d MMMM yyyy, HH:mm", new Guid("1623d5cb-c6ad-40e1-83a5-328e4c43ca0c") },
                    { new Guid("c966f04d-5bd5-4482-9243-8cb214372e10"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("140f6f55-9281-4b8a-b0bc-8c7f81623cf2") },
                    { new Guid("cd2bf0f3-6936-433d-9003-e201a43fd15d"), "yyyy-MM-d HH:mm", new Guid("25eaf935-bb1a-4c00-97e5-3595cc0b32df") },
                    { new Guid("d729acbd-35de-4a5c-bf9b-9f3b32ae312d"), "d-M-yyyy HH:mm", new Guid("906349e5-6045-483f-a1cc-9a642e0f6f38") },
                    { new Guid("dc939e94-7b79-426e-b7b6-19846dc65a7d"), "d MMMM, HH:mm,", new Guid("1365b264-a13c-4181-865c-5fcbcde1e917") },
                    { new Guid("e028f4b4-d5f4-4466-b0a0-d5201985834b"), "dd MMMM, HH:mm", new Guid("00f59fab-0b5e-4027-ac21-7b93a0fe2b26") },
                    { new Guid("e86d8f99-f922-4014-b719-38ac9bf8c0d0"), "d MMMM yyyy HH:mm", new Guid("eca14bbc-d96f-4d69-8aa7-b99c48434d02") },
                    { new Guid("ed99edad-4025-431d-8dfe-301a06ad1afa"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("0b9a9169-2751-41e5-89c7-6e818cc7e2f9") },
                    { new Guid("f812c045-7ff5-4bfb-9d8b-8e5e5fc28417"), "d MMMM, HH:mm", new Guid("3175c1a1-01b9-4e33-ac84-3cc28db9cca7") }
                });

            migrationBuilder.CreateIndex(
                name: "ix_news_added_at",
                table: "news",
                column: "added_at");

            migrationBuilder.CreateIndex(
                name: "ix_news_editor_id",
                table: "news",
                column: "editor_id");

            migrationBuilder.CreateIndex(
                name: "ix_news_modified_at",
                table: "news",
                column: "modified_at");

            migrationBuilder.CreateIndex(
                name: "ix_news_parsed_at",
                table: "news",
                column: "parsed_at");

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
                name: "ix_news_editors_name",
                table: "news_editors",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "ix_news_editors_source_id",
                table: "news_editors",
                column: "source_id");

            migrationBuilder.CreateIndex(
                name: "ix_news_html_descriptions_news_id",
                table: "news_html_descriptions",
                column: "news_id",
                unique: true);

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
                name: "ix_news_parse_modified_at_settings_parse_settings_id",
                table: "news_parse_modified_at_settings",
                column: "parse_settings_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_news_parse_modified_at_settings_formats_news_parse_modified",
                table: "news_parse_modified_at_settings_formats",
                column: "news_parse_modified_at_settings_id");

            migrationBuilder.CreateIndex(
                name: "ix_news_parse_needs_news_url",
                table: "news_parse_needs",
                column: "news_url");

            migrationBuilder.CreateIndex(
                name: "ix_news_parse_network_errors_news_url",
                table: "news_parse_network_errors",
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
                name: "ix_news_parse_video_settings_parse_settings_id",
                table: "news_parse_video_settings",
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

            migrationBuilder.CreateIndex(
                name: "ix_news_text_descriptions_news_id",
                table: "news_text_descriptions",
                column: "news_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_news_videos_news_id",
                table: "news_videos",
                column: "news_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "news_html_descriptions");

            migrationBuilder.DropTable(
                name: "news_parse_editor_settings");

            migrationBuilder.DropTable(
                name: "news_parse_errors");

            migrationBuilder.DropTable(
                name: "news_parse_modified_at_settings_formats");

            migrationBuilder.DropTable(
                name: "news_parse_needs");

            migrationBuilder.DropTable(
                name: "news_parse_network_errors");

            migrationBuilder.DropTable(
                name: "news_parse_picture_settings");

            migrationBuilder.DropTable(
                name: "news_parse_published_at_settings_formats");

            migrationBuilder.DropTable(
                name: "news_parse_sub_title_settings");

            migrationBuilder.DropTable(
                name: "news_parse_video_settings");

            migrationBuilder.DropTable(
                name: "news_pictures");

            migrationBuilder.DropTable(
                name: "news_search_settings");

            migrationBuilder.DropTable(
                name: "news_source_logos");

            migrationBuilder.DropTable(
                name: "news_sub_titles");

            migrationBuilder.DropTable(
                name: "news_text_descriptions");

            migrationBuilder.DropTable(
                name: "news_videos");

            migrationBuilder.DropTable(
                name: "news_parse_modified_at_settings");

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
