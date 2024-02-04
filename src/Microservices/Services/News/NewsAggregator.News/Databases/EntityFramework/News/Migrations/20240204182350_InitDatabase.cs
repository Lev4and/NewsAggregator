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
                    { new Guid("02cd9da5-003c-431b-8ec3-6bfaa2890492"), true, "https://74.ru/", "74.ru" },
                    { new Guid("16cb9a03-4384-4070-adf7-4f36247dded1"), true, "https://russian.rt.com/", "RT на русском" },
                    { new Guid("1c1ebd59-4974-48a3-9f92-e19be6007df8"), true, "https://lenta.ru/", "Лента.Ру" },
                    { new Guid("20ce0cfe-a82c-44ac-a2d9-5cce6a7e893c"), true, "https://www.sports.ru/", "Storts.ru" },
                    { new Guid("30c27bb8-67a1-4a13-a096-66d58e1728c0"), false, "https://www.interfax.ru/", "Интерфакс" },
                    { new Guid("49725244-7b76-475a-bbe7-bb3e62a6c805"), true, "https://www.pravda.ru/", "Правда.ру" },
                    { new Guid("4f9f8579-7092-41ec-bbbc-815c7f84af9a"), true, "https://www.m24.ru/", "Москва 24" },
                    { new Guid("55d7c6a8-1df3-4a02-a308-fb5af9cca6b7"), true, "https://www.championat.com/", "Чемпионат.com" },
                    { new Guid("5fc7c836-ff7d-4f83-9991-a1cb19f4504c"), true, "https://life.ru/", "Life" },
                    { new Guid("68b1242b-ff11-4d39-912e-ea5273d29750"), true, "https://tsargrad.tv/", "Царьград" },
                    { new Guid("6dd221e1-446c-46c2-a255-b3ea6e4d7917"), true, "https://www.ixbt.com/", "iXBT.com" },
                    { new Guid("6e266808-ce4b-4910-8ab6-691a37488418"), true, "https://tass.ru/", "ТАСС" },
                    { new Guid("70773383-5dd3-492a-98ae-649615c5f300"), true, "https://www.1obl.ru/", "Первый областной" },
                    { new Guid("7614d037-573c-4b25-8607-2a75ade5ac65"), true, "https://ixbt.games/", "iXBT.games" },
                    { new Guid("8c88b3b3-a98f-4cdf-82fa-7b34418c6e25"), true, "https://www.rbc.ru/", "РБК" },
                    { new Guid("8cfc4dc8-3f52-4552-9a11-461baec4aeda"), true, "https://iz.ru/", "Известия" },
                    { new Guid("99ecc98d-a843-4fd3-b862-151791e3d72b"), true, "https://ura.news/", "Ura.ru" },
                    { new Guid("9aa2faa6-951a-4b36-be82-104bb2d36c55"), true, "https://aif.ru/", "Аргументы и факты" },
                    { new Guid("c2b20ea8-9c77-45df-acab-caa6c96d6d6b"), true, "https://svpressa.ru/", "СвободнаяПресса" },
                    { new Guid("cad8eb6c-417a-4d76-b1bc-df35b541f74c"), true, "https://ria.ru/", "РИА Новости" },
                    { new Guid("cc133108-552b-47b5-b087-e52685cbf91e"), true, "https://www.kommersant.ru/", "Коммерсантъ" },
                    { new Guid("da0da24d-fa2a-4f2b-946b-182732ff4d57"), true, "https://3dnews.ru/", "3Dnews.ru" },
                    { new Guid("dc9c7728-d3f1-453d-b04a-108ce51d2265"), true, "https://rg.ru/", "Российская газета" },
                    { new Guid("de4069cb-f237-404f-bf27-f1a064bbac05"), true, "https://vz.ru/", "ВЗГЛЯД.РУ" },
                    { new Guid("f1c53285-9ac8-495a-86b0-a3d41fc9f6a8"), true, "https://www.belta.by/", "БелТА" },
                    { new Guid("ff3c8147-fa38-4560-ae65-ea9234af8cdd"), true, "https://www.gazeta.ru/", "Газета.Ru" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_settings",
                columns: new[] { "id", "description_x_path", "source_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("0561275c-6138-4ecf-86b4-c6de10f02b08"), "//div[@itemprop='articleBody']/*[not(name()='div')]", new Guid("99ecc98d-a843-4fd3-b862-151791e3d72b"), "//h1/text()" },
                    { new Guid("06f989ad-91e5-47c4-aa78-28bcb3603d0b"), "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]", new Guid("4f9f8579-7092-41ec-bbbc-815c7f84af9a"), "//h1/text()" },
                    { new Guid("085180e1-7639-4cec-a6e0-571f027c5589"), "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]", new Guid("c2b20ea8-9c77-45df-acab-caa6c96d6d6b"), "//h1[@class='b-text__title']/text()" },
                    { new Guid("109d9100-3e0b-4b77-a4b1-ae0b455109d5"), "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]", new Guid("30c27bb8-67a1-4a13-a096-66d58e1728c0"), "//h1/text()" },
                    { new Guid("113a0c0e-b9d4-45da-b885-53c45e891120"), "//div[@itemprop='articleBody']/*[not(name() = 'figure')]", new Guid("02cd9da5-003c-431b-8ec3-6bfaa2890492"), "//h1[@itemprop='headline']/span/text()" },
                    { new Guid("361c89cf-6437-48c9-be2e-96b9049efb8e"), "//article/*", new Guid("6e266808-ce4b-4910-8ab6-691a37488418"), "//h1/text()" },
                    { new Guid("473a5209-23d9-4b6e-8c3e-b222bb957203"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview'))]", new Guid("8c88b3b3-a98f-4cdf-82fa-7b34418c6e25"), "//h1/text()" },
                    { new Guid("4963152c-993c-4c89-a687-51da2a9a2f5e"), "//div[@class='topic-body__content']", new Guid("1c1ebd59-4974-48a3-9f92-e19be6007df8"), "//h1[@class='topic-body__titles']/span[@class='topic-body__title']/text()" },
                    { new Guid("68bd014c-8d60-468f-a5a8-cb1c6e033415"), "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]", new Guid("49725244-7b76-475a-bbe7-bb3e62a6c805"), "//h1/text()" },
                    { new Guid("6a7307ca-70bd-4918-aa11-98c20f66e15f"), "//article/div[@class='article-content']/*[not(@class)]", new Guid("55d7c6a8-1df3-4a02-a308-fb5af9cca6b7"), "//article/header/div[@class='article-head__title']/text()" },
                    { new Guid("6a83af50-69e0-4ca5-8a47-78508e1d5dbe"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]", new Guid("cc133108-552b-47b5-b087-e52685cbf91e"), "//h1/text()" },
                    { new Guid("77ef3722-4acd-4ca1-9fc4-39168eed6ab0"), "//div[@itemprop='articleBody']/*", new Guid("ff3c8147-fa38-4560-ae65-ea9234af8cdd"), "//h1/text()" },
                    { new Guid("7c4db17f-4517-44ed-907d-cfedf832c50d"), "//article/div[@class='news_text']", new Guid("de4069cb-f237-404f-bf27-f1a064bbac05"), "//h1/text()" },
                    { new Guid("8430b0aa-71d0-4156-91f7-137bcdced06e"), "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]", new Guid("5fc7c836-ff7d-4f83-9991-a1cb19f4504c"), "//h1/text()" },
                    { new Guid("86b96bdb-c9df-4976-982c-87319cfe6f46"), "//div[@itemprop='articleBody']/*", new Guid("70773383-5dd3-492a-98ae-649615c5f300"), "//h1[@itemprop='headline']/text()" },
                    { new Guid("89b02524-4541-438e-9940-8c095d8356ab"), "//div[contains(@class, 'PageContentCommonStyling_text')]", new Guid("dc9c7728-d3f1-453d-b04a-108ce51d2265"), "//h1/text()" },
                    { new Guid("9ca756cb-3d96-44c4-b6c7-c01d5a647270"), "//div[@itemprop='articleBody']/*", new Guid("8cfc4dc8-3f52-4552-9a11-461baec4aeda"), "//h1/span/text()" },
                    { new Guid("afaa89ac-2d89-4308-a760-57c2cb11acaf"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()>1]", new Guid("da0da24d-fa2a-4f2b-946b-182732ff4d57"), "//h1/text()" },
                    { new Guid("b561459c-7f9a-4acf-904e-79901a3963f4"), "//div[@class='article_text']", new Guid("9aa2faa6-951a-4b36-be82-104bb2d36c55"), "//h1/text()" },
                    { new Guid("c7f770e1-758f-43ad-827f-d8cd3fcb7c14"), "//div[contains(@class, 'article__text ')]", new Guid("16cb9a03-4384-4070-adf7-4f36247dded1"), "//h1/text()" },
                    { new Guid("c9cee28e-c398-45b0-bcf1-4d809602f54a"), "//div[contains(@class, 'news-item__content')]", new Guid("20ce0cfe-a82c-44ac-a2d9-5cce6a7e893c"), "//h1/text()" },
                    { new Guid("d17c8b47-cdd5-49ca-b958-8cbda8e46ecf"), "//div[contains(@class, 'article__body')]", new Guid("cad8eb6c-417a-4d76-b1bc-df35b541f74c"), "//div[@class='article__title']/text()" },
                    { new Guid("dcd74996-1639-40f8-a860-b5c6e21f095a"), "//div[@itemprop='articleBody']/*", new Guid("6dd221e1-446c-46c2-a255-b3ea6e4d7917"), "//h1/text()" },
                    { new Guid("e3e8c1f6-0e7b-43a3-b89a-eee6505654b2"), "//div[@class='js-mediator-article']", new Guid("f1c53285-9ac8-495a-86b0-a3d41fc9f6a8"), "//h1/text()" },
                    { new Guid("f21f7cf9-c1e0-4f3b-928c-dc5a747cc364"), "//div[contains(@class, 'container-fluid shifted') and not(p[@class='announce lead']) and not(h1) and not(hr)]", new Guid("7614d037-573c-4b25-8607-2a75ade5ac65"), "//h1/text()" },
                    { new Guid("fc37a49a-1e4d-4205-b606-64e48a176108"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]", new Guid("68b1242b-ff11-4d39-912e-ea5273d29750"), "//h1[@class='article__title']/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_search_settings",
                columns: new[] { "id", "news_site_url", "news_url_x_path", "source_id" },
                values: new object[,]
                {
                    { new Guid("04409e61-32bf-447b-a8f0-72c0b4c248e6"), "https://74.ru/", "//a[starts-with(@href, '/text/') and not(contains(@href, '?')) and not(contains(@href, 'comments/')) and not(@href='/text/')]/@href", new Guid("02cd9da5-003c-431b-8ec3-6bfaa2890492") },
                    { new Guid("12200dda-4fb1-4c3a-b0bc-469bd0c06d9a"), "https://tsargrad.tv/", "//a[contains(@class, 'news-item__link')]/@href", new Guid("68b1242b-ff11-4d39-912e-ea5273d29750") },
                    { new Guid("184a6c49-a070-41a6-8f7c-9777bf36cae0"), "https://www.gazeta.ru/news/", "//a[contains(@href, '/news/') and contains(@href, '.shtml') and not(contains(@href, '?'))]/@href", new Guid("ff3c8147-fa38-4560-ae65-ea9234af8cdd") },
                    { new Guid("3abf2eb5-6c7d-4d43-9412-702b26dbdf24"), "https://tass.ru/", "//a[contains(@class, 'tass_pkg_link-v5WdK') and contains(substring(@href, 2), '/') and not(contains(@href, '/spec/')) and not(contains(@href, 'spec.tass.ru'))]/@href", new Guid("6e266808-ce4b-4910-8ab6-691a37488418") },
                    { new Guid("3c85d7a5-a65e-4584-9ee5-83237e86c408"), "https://www.rbc.ru/", "//a[contains(@href, 'https://www.rbc.ru/') and contains(@href, '?from=')]/@href", new Guid("8c88b3b3-a98f-4cdf-82fa-7b34418c6e25") },
                    { new Guid("3d829ac6-6d30-493a-9fda-4359f223497d"), "https://www.m24.ru/", "//a[contains(@href, '/news/')]/@href", new Guid("4f9f8579-7092-41ec-bbbc-815c7f84af9a") },
                    { new Guid("449aa022-e2cb-40c9-a76f-b084ed6a4c44"), "https://aif.ru/", "//span[contains(@class, 'item_text__title')]/../@href", new Guid("9aa2faa6-951a-4b36-be82-104bb2d36c55") },
                    { new Guid("51fb4b77-fa15-4fda-a42b-c0a6ccc21065"), "https://iz.ru/news/", "//a[contains(@href, '?main_click')]/@href", new Guid("8cfc4dc8-3f52-4552-9a11-461baec4aeda") },
                    { new Guid("60dc80c1-ea02-4370-93d9-6b3c09f5bf84"), "https://vz.ru/", "//a[contains(@href, '.html') and not(contains(@href, '#comments')) and not(contains(@href, '?')) and not(contains(@href, '/about/'))]/@href", new Guid("de4069cb-f237-404f-bf27-f1a064bbac05") },
                    { new Guid("614bd2fa-2660-4305-9986-80bee7ddb65d"), "https://www.ixbt.com/news/", "//a[starts-with(@href, '/news/') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("6dd221e1-446c-46c2-a255-b3ea6e4d7917") },
                    { new Guid("61a0c108-473a-4311-97e0-e484ba82e52b"), "https://russian.rt.com/", "//a[contains(@class, 'link') and contains(@href, 'news/')]/@href", new Guid("16cb9a03-4384-4070-adf7-4f36247dded1") },
                    { new Guid("7860a5dd-0e91-4b77-af7e-e0d483bcdc87"), "https://www.belta.by/", "//a[contains(@href, 'https://www.belta.by/') and contains(@href, '/view/')]/@href", new Guid("f1c53285-9ac8-495a-86b0-a3d41fc9f6a8") },
                    { new Guid("99a50556-9858-4800-9853-1fa070482874"), "https://www.pravda.ru/", "//a[contains(@href, '/news/') and not(@href='https://www.pravda.ru/news/')]/@href", new Guid("49725244-7b76-475a-bbe7-bb3e62a6c805") },
                    { new Guid("9cd2d4b7-e780-4002-a95c-80eec6ddc902"), "https://www.kommersant.ru/", "//a[contains(@href, '/doc/') and contains(@href, '?from=')]/@href", new Guid("cc133108-552b-47b5-b087-e52685cbf91e") },
                    { new Guid("a4536cfc-2373-4d2f-b3dc-f32bff3c37c6"), "https://3dnews.ru/news/", "//div[@class='news-feed-all']//a[@class='entry-header']/h1/../@href", new Guid("da0da24d-fa2a-4f2b-946b-182732ff4d57") },
                    { new Guid("ab4597a0-e801-49f3-8df6-60967e210102"), "https://ura.news/", "//a[contains(@href, '/news/')]/@href", new Guid("99ecc98d-a843-4fd3-b862-151791e3d72b") },
                    { new Guid("baa0f3a9-30c6-454e-8ac6-5458362f49bc"), "https://www.1obl.ru/news/", "//a[starts-with(@href, '/news/') and not(contains(@href, '?'))]/@href", new Guid("70773383-5dd3-492a-98ae-649615c5f300") },
                    { new Guid("bebb7419-ee76-4d5a-8355-5ff52c0f13b8"), "https://www.sports.ru/news/", "//a[contains(@href, '.html') and not(contains(@href, '.html#comments'))]/@href", new Guid("20ce0cfe-a82c-44ac-a2d9-5cce6a7e893c") },
                    { new Guid("d81dcad5-aa7e-48e2-a13b-cbb4dee244d7"), "https://life.ru/s/novosti", "//a[contains(@href, '/p/')]/@href", new Guid("5fc7c836-ff7d-4f83-9991-a1cb19f4504c") },
                    { new Guid("e41e4330-d422-44ce-bb52-d2637f723a11"), "https://www.interfax.ru/", "//div[@class='timeline']//a[@tabindex=5]/@href", new Guid("30c27bb8-67a1-4a13-a096-66d58e1728c0") },
                    { new Guid("eb8d8d41-fc47-4235-bda7-a70df35c2108"), "https://svpressa.ru/all/news/", "//a[contains(@href, '/news/') and not(contains(@href, '?')) and not(starts-with(@href, '/all/news/'))]/@href", new Guid("c2b20ea8-9c77-45df-acab-caa6c96d6d6b") },
                    { new Guid("ec171436-cc6d-4af6-bf24-dd224bb5be80"), "https://lenta.ru/", "//a[starts-with(@href, '/news/')]/@href", new Guid("1c1ebd59-4974-48a3-9f92-e19be6007df8") },
                    { new Guid("ef91f99e-c017-4f95-a71c-0c19364fa72b"), "https://ixbt.games/news/", "//a[@class='card-link']/@href", new Guid("7614d037-573c-4b25-8607-2a75ade5ac65") },
                    { new Guid("f1933c10-b0b7-41fb-9e93-63ab08cada36"), "https://ria.ru/", "//a[contains(@class, 'cell-list__item-link')]/@href", new Guid("cad8eb6c-417a-4d76-b1bc-df35b541f74c") },
                    { new Guid("f582bff0-f7ab-44b8-b257-e7f8bd5b06a0"), "https://rg.ru/", "//a[contains(@href, '.html')]/@href", new Guid("dc9c7728-d3f1-453d-b04a-108ce51d2265") },
                    { new Guid("fea73cb0-f9ce-4f79-826a-b867a6fe3fd9"), "https://www.championat.com/news/1.html?utm_source=button&utm_medium=news", "//a[contains(@href, 'news-') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("55d7c6a8-1df3-4a02-a308-fb5af9cca6b7") }
                });

            migrationBuilder.InsertData(
                table: "news_source_logos",
                columns: new[] { "id", "source_id", "url" },
                values: new object[,]
                {
                    { new Guid("0a497612-4864-4764-a1eb-7af2099e643c"), new Guid("8cfc4dc8-3f52-4552-9a11-461baec4aeda"), "https://cdn.iz.ru/profiles/portal/themes/purple/images/favicons/apple-icon-120x120.png" },
                    { new Guid("0e233481-f1d4-4994-a098-f7397179ec57"), new Guid("49725244-7b76-475a-bbe7-bb3e62a6c805"), "https://www.pravda.ru/pix/apple-touch-icon.png" },
                    { new Guid("1195b97e-54d3-4d85-b0a9-83e873c096ae"), new Guid("cc133108-552b-47b5-b087-e52685cbf91e"), "https://im.kommersant.ru/ContentFlex/images/favicons2020/apple-touch-icon-120.png" },
                    { new Guid("1e73bc88-62a7-4bd9-b759-c974c47f1bb0"), new Guid("1c1ebd59-4974-48a3-9f92-e19be6007df8"), "https://icdn.lenta.ru/images/icons/icon-256x256.png" },
                    { new Guid("1fb86067-443f-4725-8e58-813a3a0feb1f"), new Guid("dc9c7728-d3f1-453d-b04a-108ce51d2265"), "https://cdnstatic.rg.ru/images/touch-icon-iphone-retina.png" },
                    { new Guid("3232e1d1-09c6-452d-a49e-d6ab649e356a"), new Guid("cad8eb6c-417a-4d76-b1bc-df35b541f74c"), "https://cdnn21.img.ria.ru/i/favicons/favicon.svg" },
                    { new Guid("3de7d6e7-6ab2-4f52-a0db-6e68fce9e905"), new Guid("c2b20ea8-9c77-45df-acab-caa6c96d6d6b"), "https://svpressa.ru/favicon-96x96.png?v=1471426270000" },
                    { new Guid("3e5abcd4-7222-4054-a1ba-5b5d86a6dcf1"), new Guid("02cd9da5-003c-431b-8ec3-6bfaa2890492"), "https://static.ngs.ru/jtnews/dist/static/favicons/apple/apple-favicon-74-120.png" },
                    { new Guid("464f370d-022c-41f2-a2f7-22b6d869c153"), new Guid("55d7c6a8-1df3-4a02-a308-fb5af9cca6b7"), "https://st.championat.com/i/favicon/apple-touch-icon.png" },
                    { new Guid("4bf2e94e-04af-4943-b896-1232b3c2b85e"), new Guid("8c88b3b3-a98f-4cdf-82fa-7b34418c6e25"), "https://s.rbk.ru/v10_rbcnews_static/common/common-10.10.116/images/apple-touch-icon-120x120.png" },
                    { new Guid("7aba78d4-53d9-4d1c-b16d-3bddf9f91c4b"), new Guid("de4069cb-f237-404f-bf27-f1a064bbac05"), "https://vz.ru/apple-touch-icon.png" },
                    { new Guid("7df5167f-ca9f-4c0c-9a0b-11acfbfa3e42"), new Guid("6dd221e1-446c-46c2-a255-b3ea6e4d7917"), "https://www.ixbt.com/favicon.ico" },
                    { new Guid("7ef43ac3-e570-453e-87d1-b89fd890b884"), new Guid("5fc7c836-ff7d-4f83-9991-a1cb19f4504c"), "https://life.ru/appletouch/apple-icon-120х120.png" },
                    { new Guid("90d5122b-e44c-4475-b56f-cf966729e6a9"), new Guid("30c27bb8-67a1-4a13-a096-66d58e1728c0"), "https://www.interfax.ru/touch-icon-iphone-retina.png" },
                    { new Guid("9a52c785-624b-48b3-98a7-b95f880933e2"), new Guid("6e266808-ce4b-4910-8ab6-691a37488418"), "https://tass.ru/favicon/180.svg" },
                    { new Guid("a2304234-4e74-4a35-989a-861f87e01367"), new Guid("7614d037-573c-4b25-8607-2a75ade5ac65"), "https://ixbt.games/images/favicon/gt/apple-touch-icon.png" },
                    { new Guid("a49a45dd-251b-443b-b55c-bb0043d6cc88"), new Guid("f1c53285-9ac8-495a-86b0-a3d41fc9f6a8"), "https://www.belta.by/images/storage/banners/000016_a133e848cb2e7b1debb7102d19e4d139_work.svg" },
                    { new Guid("ae6e0588-fb87-4205-ab1a-2266433bbade"), new Guid("9aa2faa6-951a-4b36-be82-104bb2d36c55"), "https://chel.aif.ru/img/icon/apple-touch-icon.png?37f" },
                    { new Guid("bb2b8e6b-f5ba-4d5c-a710-a334d8db1d1c"), new Guid("16cb9a03-4384-4070-adf7-4f36247dded1"), "https://russian.rt.com/static/img/listing-uwc-logo.png" },
                    { new Guid("c0c50a9a-2437-44eb-ad67-f58b38676a42"), new Guid("70773383-5dd3-492a-98ae-649615c5f300"), "https://www.1obl.ru/apple-touch-icon.png" },
                    { new Guid("c13f627a-ec39-4e9c-9973-5b24932ef4a8"), new Guid("ff3c8147-fa38-4560-ae65-ea9234af8cdd"), "https://static.gazeta.ru/nm2021/img/icons/favicon.svg" },
                    { new Guid("d71c7832-8a7d-4dc7-b021-3d9de6e14d40"), new Guid("99ecc98d-a843-4fd3-b862-151791e3d72b"), "https://ura.news/apple-touch-icon.png" },
                    { new Guid("dd7c520a-577d-4d49-b966-fe148cc472e1"), new Guid("20ce0cfe-a82c-44ac-a2d9-5cce6a7e893c"), "https://www.sports.ru/apple-touch-icon-120.png" },
                    { new Guid("e23392ae-41ae-4556-9b23-6e5b6e35b078"), new Guid("68b1242b-ff11-4d39-912e-ea5273d29750"), "https://ural.tsargrad.tv/favicons/apple-touch-icon-120x120.png?s2" },
                    { new Guid("f186b4fd-4ca0-4a9a-990d-e66e6309a8e4"), new Guid("da0da24d-fa2a-4f2b-946b-182732ff4d57"), "https://3dnews.ru/assets/images/3dnews_logo_soc.png" },
                    { new Guid("f19d72cf-e329-4cd4-b106-bba1dfa1eb49"), new Guid("4f9f8579-7092-41ec-bbbc-815c7f84af9a"), "https://www.m24.ru/img/fav/apple-touch-icon.png" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_editor_settings",
                columns: new[] { "id", "is_required", "name_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("10fcf504-fc5f-4ca5-9b19-14b416b24ea1"), false, "//div[@itemprop='author']//p[@itemprop='name']/text()", new Guid("113a0c0e-b9d4-45da-b885-53c45e891120") },
                    { new Guid("221d638f-3ed3-42b3-8155-516e1744945f"), true, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']//a[@itemprop='author']//span[@itemprop='name']/text()", new Guid("afaa89ac-2d89-4308-a760-57c2cb11acaf") },
                    { new Guid("2bf23da0-7d8e-4381-ad45-a55236be23d3"), true, "//span[@itemprop='author']/span[@itemprop='name']/@content", new Guid("dcd74996-1639-40f8-a860-b5c6e21f095a") },
                    { new Guid("46f48251-7976-4fe0-9eea-dca5b9b45bd8"), true, "//*[@itemprop='author']/*[@itemprop='name']//text()", new Guid("86b96bdb-c9df-4976-982c-87319cfe6f46") },
                    { new Guid("610b5740-15ba-40be-b8b5-0bcff821fe09"), true, "//div[@itemprop='author']/span[@itemprop='name']/text()", new Guid("0561275c-6138-4ecf-86b4-c6de10f02b08") },
                    { new Guid("613cd06f-98bd-45fd-83ca-5d6f1078b4d6"), true, "//a[@class='article__author']/text()", new Guid("fc37a49a-1e4d-4205-b606-64e48a176108") },
                    { new Guid("6f5d1306-b7ff-42ca-a9df-17c40e7f48be"), true, "//footer[@class='news-item__footer']/div[@class='news-item__footer-after-news']/p[position()=1]//span/text()", new Guid("c9cee28e-c398-45b0-bcf1-4d809602f54a") },
                    { new Guid("79d325a0-b988-4381-8aa2-0c1fd89516bf"), true, "//div[contains(@class, 'styles_bodyWrapper')]//div[contains(@class, 'styles_authorsLinks')]/a/text()", new Guid("8430b0aa-71d0-4156-91f7-137bcdced06e") },
                    { new Guid("931e5ea9-89a3-40c7-a86f-47b9e5271f11"), false, "//div[@class='author']/span[@itemprop='author']/span[@itemprop='name']/a/text()", new Guid("77ef3722-4acd-4ca1-9fc4-39168eed6ab0") },
                    { new Guid("9d372289-3a88-4f18-9f37-f8070504a60b"), true, "//div[@class='container-fluid publication-footer']//a[contains(@class, 'text-secondary')]/@title", new Guid("f21f7cf9-c1e0-4f3b-928c-dc5a747cc364") },
                    { new Guid("be59f90c-a274-41e8-915b-1ebd07a2b575"), true, "//div[contains(@class, 'PageArticleContent_authors')]//a[contains(@class, 'LinksOfAuthor_item')]/text()", new Guid("89b02524-4541-438e-9940-8c095d8356ab") },
                    { new Guid("c388071b-2b8f-4e9e-ad14-038206174126"), true, "//article//header//div[@class='article-head__author-name']/a[@rel='author']/span/text()", new Guid("6a7307ca-70bd-4918-aa11-98c20f66e15f") },
                    { new Guid("c3d3bc32-e57a-478a-8b46-079a17abc245"), false, "//p[@class='doc__text document_authors']/text()", new Guid("6a83af50-69e0-4ca5-8a47-78508e1d5dbe") },
                    { new Guid("e77d1463-de84-4c1c-9acb-26ff700c6de8"), false, "//div[@class='article__authors']//*[@class='article__authors__author']/span[@class='article__authors__author__name']/text()", new Guid("473a5209-23d9-4b6e-8c3e-b222bb957203") },
                    { new Guid("eb3ce22a-c740-4145-890f-7997c27fa1c9"), true, "//div[contains(@class, 'full-article')]/div[@class='authors-block']//span[text()='Автор']/../a/text()", new Guid("68bd014c-8d60-468f-a5a8-cb1c6e033415") },
                    { new Guid("f3cd1d00-d682-4ecb-be5a-c2ef166f5b95"), true, "//div[@class='article_top']//div[@class='authors']//div[@class='autor']//span/text()", new Guid("b561459c-7f9a-4acf-904e-79901a3963f4") },
                    { new Guid("fda78343-3393-4912-9138-c34110574e4e"), false, "//div[@class='topic-authors']/a[@class='topic-authors__author']/text()", new Guid("4963152c-993c-4c89-a687-51da2a9a2f5e") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_modified_at_settings",
                columns: new[] { "id", "is_required", "modified_at_culture_info", "modified_at_time_zone_info_id", "modified_at_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("152825f4-2991-46bc-8ed0-aafe205878c7"), false, "ru-RU", "UTC", "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark_update')]//span[@ca-ts]/text()", new Guid("361c89cf-6437-48c9-be2e-96b9049efb8e") },
                    { new Guid("42ed294b-d14c-443e-b873-99b8f759e632"), false, "ru-RU", "Russian Standard Time", "//div[@class='doc_header__time']/span[contains(@class, 'publish_update')]/text()", new Guid("6a83af50-69e0-4ca5-8a47-78508e1d5dbe") },
                    { new Guid("b24b102a-a6d0-4b28-b12f-949ead993442"), true, "ru-RU", "Russian Standard Time", "//div[@class='article__info']//div[@class='article__info-date']/span[@class='article__info-date-modified']/text()", new Guid("d17c8b47-cdd5-49ca-b958-8cbda8e46ecf") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_picture_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("08fa9904-dfb5-468c-a9fc-2278dc366ba9"), false, new Guid("113a0c0e-b9d4-45da-b885-53c45e891120"), "//figure//img/@src" },
                    { new Guid("151a40d6-c1c0-43fb-84fc-df485daf1156"), false, new Guid("8430b0aa-71d0-4156-91f7-137bcdced06e"), "//article//header/div[contains(@class, 'styles_cover_media')]/img/@src" },
                    { new Guid("1cd693f8-87fe-4c54-a06c-dc043290cfee"), false, new Guid("7c4db17f-4517-44ed-907d-cfedf832c50d"), "//article/figure/img/@src" },
                    { new Guid("317551db-0710-4a28-8b45-6c4d3d83e04e"), false, new Guid("d17c8b47-cdd5-49ca-b958-8cbda8e46ecf"), "//div[@class='photoview__open']/img/@src" },
                    { new Guid("4061014a-6050-4423-96fb-f2e6bdc80995"), false, new Guid("6a7307ca-70bd-4918-aa11-98c20f66e15f"), "//article//header/div[@class='article-head__photo']/img/@src" },
                    { new Guid("63dca47f-cba0-4bf3-8c91-83aef3a08ea1"), false, new Guid("77ef3722-4acd-4ca1-9fc4-39168eed6ab0"), "//div[@class='b_article-media']//div[@class='mainarea-wrapper']/figure/img[@class='item-image-front']/@src" },
                    { new Guid("88c039ac-45e9-4255-9bbd-b5cef3eb45e4"), false, new Guid("e3e8c1f6-0e7b-43a3-b89a-eee6505654b2"), "//div[@class='inner_content']//div[@class='main_img']//img/@src" },
                    { new Guid("a8b77a24-25bf-4047-af58-6c8c6e9740b2"), true, new Guid("0561275c-6138-4ecf-86b4-c6de10f02b08"), "//div[@itemprop='articleBody']//div[@itemprop='image']/picture/img[@itemprop='contentUrl']/@src" },
                    { new Guid("adc157bf-79f8-4dd6-88e8-71a0340dab04"), true, new Guid("fc37a49a-1e4d-4205-b606-64e48a176108"), "//div[@class='article__media']//img/@src" },
                    { new Guid("b3e9a875-2a5f-457b-a719-86078cf7453b"), false, new Guid("361c89cf-6437-48c9-be2e-96b9049efb8e"), "//div[contains(@class, 'HeaderMedia_image')]//img[contains(@class, 'Image_image')]/@src" },
                    { new Guid("be3d9c83-fc01-4526-8b11-4bd8a9a73b55"), false, new Guid("afaa89ac-2d89-4308-a760-57c2cb11acaf"), "//img[@itemprop='image']/@src" },
                    { new Guid("c279f47b-d260-4bf8-b7ff-992f3c259dae"), true, new Guid("085180e1-7639-4cec-a6e0-571f027c5589"), "//picture/img/@src" },
                    { new Guid("c93ea0b7-ae2b-4ab3-b924-b42f3b9e5a76"), true, new Guid("9ca756cb-3d96-44c4-b6c7-c01d5a647270"), "//div[contains(@class, 'big_photo')]//div[@class='big_photo__img']//img/@src" },
                    { new Guid("d0940150-77a5-47d1-b2bc-d4cd56bc6604"), true, new Guid("86b96bdb-c9df-4976-982c-87319cfe6f46"), "//div[contains(@class, 'newsMediaContainer')]/img/@src" },
                    { new Guid("d7979619-0fc6-469f-a463-905d844f0456"), false, new Guid("68bd014c-8d60-468f-a5a8-cb1c6e033415"), "//div[contains(@class, 'full-article')]/div[contains(@class, 'gallery')]/picture/img/@src" },
                    { new Guid("e4453c0e-6dd0-4a65-a1f0-aab5151f52b8"), false, new Guid("06f989ad-91e5-47c4-aa78-28bcb3603d0b"), "//div[@class='b-material-incut-m-image']//@src" },
                    { new Guid("e45dc41e-6c03-4f1b-8d1e-176931fc0dd1"), false, new Guid("4963152c-993c-4c89-a687-51da2a9a2f5e"), "//div[contains(@class, 'topic-body__title-image')]//img[contains(@class, 'picture__image')]/@src" },
                    { new Guid("f413015e-dfbf-47b6-aa24-92fd5300faa0"), true, new Guid("f21f7cf9-c1e0-4f3b-928c-dc5a747cc364"), "//a[@class='glightbox']/img[contains(@class, 'pub-cover')]/@src" },
                    { new Guid("ff6759cf-0970-46f9-9f15-390f365b74cb"), false, new Guid("b561459c-7f9a-4acf-904e-79901a3963f4"), "//div[@class='img_box']/a[@class='zoom_js']/img/@src" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "published_at_culture_info", "published_at_time_zone_info_id", "published_at_x_path" },
                values: new object[,]
                {
                    { new Guid("076bd710-3025-43b1-982e-e80a9684faf7"), true, new Guid("4963152c-993c-4c89-a687-51da2a9a2f5e"), "ru-RU", "Russian Standard Time", "//div[@class='topic-page__header']//a[contains(@class, 'topic-header__time')]/text()" },
                    { new Guid("0f6ad4ad-5c02-4d6b-bf2e-d61ae6c2cd9e"), true, new Guid("fc37a49a-1e4d-4205-b606-64e48a176108"), "ru-RU", "Russian Standard Time", "//div[@class='article__meta']/time/text()" },
                    { new Guid("35a558ef-6c3e-4a4c-9d2f-ef1186066c94"), true, new Guid("d17c8b47-cdd5-49ca-b958-8cbda8e46ecf"), "ru-RU", "Russian Standard Time", "//div[@class='article__info']//div[@class='article__info-date']/a/text()" },
                    { new Guid("451e446b-54d8-4eec-aa63-0f337015eb32"), true, new Guid("c7f770e1-758f-43ad-827f-d8cd3fcb7c14"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'article__date-autor-shortcode')]/div[contains(@class, 'article__date')]/time[@class='date']/@datetime" },
                    { new Guid("4828fc4e-ab99-4da6-b84d-4456ce630bd1"), true, new Guid("085180e1-7639-4cec-a6e0-571f027c5589"), "ru-RU", "Russian Standard Time", "//div[@class='b-text__date']/text()" },
                    { new Guid("4a0f14d6-1ceb-4a4a-9232-025ab96104bf"), true, new Guid("0561275c-6138-4ecf-86b4-c6de10f02b08"), "ru-RU", null, "//div[@class='publication-info']/time[@itemprop='datePublished']/@datetime" },
                    { new Guid("555c6aa5-2a88-4c61-a021-830d403c3c17"), true, new Guid("afaa89ac-2d89-4308-a760-57c2cb11acaf"), "ru-RU", null, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']/span[@itemprop='datePublished']/@content" },
                    { new Guid("61171eda-1082-4027-b127-97d823fb3dcd"), true, new Guid("b561459c-7f9a-4acf-904e-79901a3963f4"), "ru-RU", "Russian Standard Time", "//div[@class='article_top']//div[@class='date']//time/text()" },
                    { new Guid("76d9ae47-e464-4c50-b8a0-6b2b8de698d4"), true, new Guid("113a0c0e-b9d4-45da-b885-53c45e891120"), "ru-RU", "Russian Standard Time", "//div[@itemprop='datePublished']/time/@datetime" },
                    { new Guid("7c9560da-5774-49e5-8dff-a9430a7d2a37"), true, new Guid("109d9100-3e0b-4b77-a4b1-ae0b455109d5"), "ru-RU", "Russian Standard Time", "//article[@itemprop='articleBody']/meta[@itemprop='datePublished']/@content" },
                    { new Guid("87b23a33-f2a4-46c2-8170-e2c3ec6340bf"), true, new Guid("86b96bdb-c9df-4976-982c-87319cfe6f46"), "ru-RU", null, "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("8aa3bdd6-58eb-48d9-b54c-0cf4f07645a9"), true, new Guid("9ca756cb-3d96-44c4-b6c7-c01d5a647270"), "ru-RU", null, "//div[@class='article_page__left__top__left']//div[@class='article_page__left__top__time']//time/@datetime" },
                    { new Guid("8c5ba3ad-760a-41f7-bc8c-ef8ac578370b"), true, new Guid("361c89cf-6437-48c9-be2e-96b9049efb8e"), "ru-RU", "UTC", "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark_publish')]//span[@ca-ts]/text()" },
                    { new Guid("8dd22a62-7ff0-4fac-ac85-3eebcdcf7654"), true, new Guid("dcd74996-1639-40f8-a860-b5c6e21f095a"), "ru-RU", "Russian Standard Time", "//div[@class='b-article__top-author']/p[@class='date']/text()" },
                    { new Guid("9deb90c6-631d-4507-9d1f-50da8df729d6"), true, new Guid("77ef3722-4acd-4ca1-9fc4-39168eed6ab0"), "ru-RU", null, "//article/div[@class='b_article-header']//time[@itemprop='datePublished']/@datetime" },
                    { new Guid("a8952cfb-3bed-4d00-93df-99426e18eefd"), true, new Guid("6a83af50-69e0-4ca5-8a47-78508e1d5dbe"), "ru-RU", null, "//div[@class='doc_header__time']/time[@class='doc_header__publish_time']/@datetime" },
                    { new Guid("ab819ffa-6edf-4f76-ad3a-39a321197c69"), true, new Guid("89b02524-4541-438e-9940-8c095d8356ab"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'PageArticleContent_date')]/text()" },
                    { new Guid("b05169a5-6d95-40e6-a188-031086ef48b0"), true, new Guid("8430b0aa-71d0-4156-91f7-137bcdced06e"), "ru-RU", "UTC", "//article//header//div[contains(@class, 'styles_meta')]//div[contains(@class, 'styles_metaItem')]/text()" },
                    { new Guid("c428e45b-8166-4ea7-bee3-fde8f1091016"), true, new Guid("06f989ad-91e5-47c4-aa78-28bcb3603d0b"), "ru-RU", "Russian Standard Time", "//p[@class='b-material__date']/text()" },
                    { new Guid("cefd73f1-38a9-4416-9b8c-0a0cf3b89b9a"), true, new Guid("6a7307ca-70bd-4918-aa11-98c20f66e15f"), "ru-RU", "Russian Standard Time", "//article//header//time[@class='article-head__date']/text()" },
                    { new Guid("e3a07056-5113-42d5-9999-94901993de11"), false, new Guid("f21f7cf9-c1e0-4f3b-928c-dc5a747cc364"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'pubdatetime')]/text()" },
                    { new Guid("f435204f-6188-45fd-944c-b3b4aab5f191"), true, new Guid("7c4db17f-4517-44ed-907d-cfedf832c50d"), "ru-RU", "Russian Standard Time", "//article/div[@class='header']/span/text()" },
                    { new Guid("f6514277-4374-4cfb-8370-57d868cafca0"), true, new Guid("c9cee28e-c398-45b0-bcf1-4d809602f54a"), "ru-RU", null, "//header[@class='news-item__header']//time/@content" },
                    { new Guid("fb9f762e-cf12-4ea6-961c-ee7a99f4c0c6"), true, new Guid("68bd014c-8d60-468f-a5a8-cb1c6e033415"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'full-article')]//time/text()" },
                    { new Guid("fca3b741-9430-4942-b6ba-279ec688872b"), true, new Guid("e3e8c1f6-0e7b-43a3-b89a-eee6505654b2"), "ru-RU", "Russian Standard Time", "//div[@class='date_full']/text()" },
                    { new Guid("fce250d7-b6fb-469b-acc8-16118da98e3a"), true, new Guid("473a5209-23d9-4b6e-8c3e-b222bb957203"), "ru-RU", null, "//div[@class='article__header__info-block']/time[@class='article__header__date']/@datetime" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_sub_title_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("0018cd8a-2313-406a-ba4a-8abd9c50ce23"), false, new Guid("8430b0aa-71d0-4156-91f7-137bcdced06e"), "//article//header//p[contains(@class, 'styles_subtitle')]/text()" },
                    { new Guid("2104e52f-f58e-4379-b3e8-95093ebea19d"), true, new Guid("68bd014c-8d60-468f-a5a8-cb1c6e033415"), "//h1/text()" },
                    { new Guid("245b9eb8-b4fa-41fd-8c24-3ec66296a24d"), true, new Guid("d17c8b47-cdd5-49ca-b958-8cbda8e46ecf"), "//h1[@class='article__second-title']/text()" },
                    { new Guid("39fc5809-481d-4341-9ee8-2af56f03cffa"), false, new Guid("dcd74996-1639-40f8-a860-b5c6e21f095a"), "//h4/text()" },
                    { new Guid("4e4cbb75-f817-43f0-a222-403722ef2893"), false, new Guid("7c4db17f-4517-44ed-907d-cfedf832c50d"), "//h4/text()" },
                    { new Guid("581a9549-5644-4f18-893e-4aed8cabb8c8"), false, new Guid("473a5209-23d9-4b6e-8c3e-b222bb957203"), "//div[contains(@class, 'article__text')]/div[@class='article__text__overview']/span/text()" },
                    { new Guid("63db722e-8cd4-41ef-82e0-d3a18d4b4331"), false, new Guid("89b02524-4541-438e-9940-8c095d8356ab"), "//div[contains(@class, 'PageArticleContent_lead')]/text()" },
                    { new Guid("8c5b0e8a-5737-49ea-b4c9-6be3fa0d4b54"), true, new Guid("fc37a49a-1e4d-4205-b606-64e48a176108"), "//div[@class='article__intro']/p/text()" },
                    { new Guid("9bd68fa9-f1fa-4399-a428-e9bf642890e8"), true, new Guid("c7f770e1-758f-43ad-827f-d8cd3fcb7c14"), "//div[contains(@class, 'article__summary')]/text()" },
                    { new Guid("b349de97-90fb-41ad-a9f8-c5ea68da9c06"), true, new Guid("113a0c0e-b9d4-45da-b885-53c45e891120"), "//p[@itemprop='alternativeHeadline']/span/text()" },
                    { new Guid("c3dad4ad-3ee1-4155-8a66-de90059e61f5"), true, new Guid("f21f7cf9-c1e0-4f3b-928c-dc5a747cc364"), "//div[@class='container-fluid shifted']/p[@class='announce lead']/text()" },
                    { new Guid("d271b77e-3a25-4497-9a28-5da1a7f3f78f"), true, new Guid("77ef3722-4acd-4ca1-9fc4-39168eed6ab0"), "//h2/text()" },
                    { new Guid("e42b1813-cab0-4ddf-a172-7d47918444c3"), false, new Guid("6a83af50-69e0-4ca5-8a47-78508e1d5dbe"), "//header[@class='doc_header']/h2[contains(@class, 'doc_header__subheader')]/text()" },
                    { new Guid("e8f9564b-a3d4-427a-a3d2-cbe649cda266"), false, new Guid("361c89cf-6437-48c9-be2e-96b9049efb8e"), "//h3/text()" },
                    { new Guid("eb2e708a-6370-476d-a6b7-361504ef7cb0"), true, new Guid("86b96bdb-c9df-4976-982c-87319cfe6f46"), "//div[@itemprop='alternativeHeadline']/text()" },
                    { new Guid("f4f5c4d7-733b-4712-b0e7-2c96575acae5"), true, new Guid("afaa89ac-2d89-4308-a760-57c2cb11acaf"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()=1]/text()" },
                    { new Guid("f6f70928-cc4f-4062-8df6-746c2ab394cb"), false, new Guid("4963152c-993c-4c89-a687-51da2a9a2f5e"), "//div[contains(@class, 'topic-body__title')]/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_modified_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_modified_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("7abc6a83-c8fc-4908-8e10-aa06dc6e3f21"), "обновлено HH:mm , dd.MM.yyyy", new Guid("42ed294b-d14c-443e-b873-99b8f759e632") },
                    { new Guid("b7a8eacd-4eb1-43f7-adb0-4ba90b9f8420"), "обновлено HH:mm , dd.MM", new Guid("42ed294b-d14c-443e-b873-99b8f759e632") },
                    { new Guid("ba2cd6ac-2457-48a6-89cf-638711ffa3da"), "обновлено d MMMM yyyy, HH:mm", new Guid("152825f4-2991-46bc-8ed0-aafe205878c7") },
                    { new Guid("c8e926c8-ac20-4a41-a79b-8ac31fecee9c"), "обновлено d MMMM, HH:mm", new Guid("152825f4-2991-46bc-8ed0-aafe205878c7") },
                    { new Guid("d2ba1a9d-d71c-4dbc-ab67-f2d88b18aac8"), "(обновлено: HH:mm dd.MM.yyyy)", new Guid("b24b102a-a6d0-4b28-b12f-949ead993442") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_published_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("03dcbaab-3030-4b58-a05e-5f29d8f9ed2a"), "dd MMMM yyyy HH:mm", new Guid("0f6ad4ad-5c02-4d6b-bf2e-d61ae6c2cd9e") },
                    { new Guid("066cecf1-5344-4747-81af-2017d79ed5cc"), "d MMMM, HH:mm", new Guid("8c5ba3ad-760a-41f7-bc8c-ef8ac578370b") },
                    { new Guid("104ed52e-1937-4f5f-9560-04654d4dec14"), "yyyy-MM-ddTHH:mm:ss", new Guid("76d9ae47-e464-4c50-b8a0-6b2b8de698d4") },
                    { new Guid("12fabb49-dc9a-4274-9175-9d67f01e7b73"), "d MMMM yyyy, HH:mm,", new Guid("8c5ba3ad-760a-41f7-bc8c-ef8ac578370b") },
                    { new Guid("2330b020-d540-4edb-96dc-8767bf426c1c"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("9deb90c6-631d-4507-9d1f-50da8df729d6") },
                    { new Guid("2e28b6ae-a572-4044-874a-8ddf0782c18c"), "d MMMM, HH:mm,", new Guid("8c5ba3ad-760a-41f7-bc8c-ef8ac578370b") },
                    { new Guid("39621cb7-376c-4db7-bd31-5e6d57b8a2a1"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("fce250d7-b6fb-469b-acc8-16118da98e3a") },
                    { new Guid("3cb097db-5066-4fae-a97a-8f542443f277"), "d MMMM yyyy в HH:mm", new Guid("8dd22a62-7ff0-4fac-ac85-3eebcdcf7654") },
                    { new Guid("3f5a3c18-b1c8-43c0-85fe-583462195dd4"), "d MMMM yyyy, HH:mm", new Guid("f435204f-6188-45fd-944c-b3b4aab5f191") },
                    { new Guid("406d5ae7-7d52-4f86-af9d-4ef2a5d0a8e2"), "d MMMM yyyy, HH:mm", new Guid("b05169a5-6d95-40e6-a188-031086ef48b0") },
                    { new Guid("424e1c6b-1fc5-4268-90c2-7b087aed1fc3"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("87b23a33-f2a4-46c2-8170-e2c3ec6340bf") },
                    { new Guid("43009cc0-f9ef-418d-9577-6e2d8faaca5f"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("4a0f14d6-1ceb-4a4a-9232-025ab96104bf") },
                    { new Guid("4a31b765-3877-4f98-80c2-bde6b5ec171e"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("a8952cfb-3bed-4d00-93df-99426e18eefd") },
                    { new Guid("4afa3064-bf4c-4a07-ad4d-a3b0ce782333"), "yyyy-MM-d HH:mm", new Guid("451e446b-54d8-4eec-aa63-0f337015eb32") },
                    { new Guid("4e9911d8-9caa-4c95-a494-909740834fd3"), "d MMMM, HH:mm", new Guid("b05169a5-6d95-40e6-a188-031086ef48b0") },
                    { new Guid("52581e9a-c717-4b96-89c3-c50fce26e420"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("555c6aa5-2a88-4c61-a021-830d403c3c17") },
                    { new Guid("76a98cd4-cb4d-4d4b-928c-30453ed6e967"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("f6514277-4374-4cfb-8370-57d868cafca0") },
                    { new Guid("78a9d013-29e2-4c33-95e8-c2924157f11b"), "d MMMM  HH:mm", new Guid("4828fc4e-ab99-4da6-b84d-4456ce630bd1") },
                    { new Guid("89df40c2-2fce-4577-8a85-8388a36a065d"), "d MMMM yyyy HH:mm", new Guid("4828fc4e-ab99-4da6-b84d-4456ce630bd1") },
                    { new Guid("8e03a370-8495-44a3-979c-96d155c29a65"), "dd.MM.yyyy HH:mm", new Guid("61171eda-1082-4027-b127-97d823fb3dcd") },
                    { new Guid("8f4c738e-aded-4914-bb62-b021d4c46d6c"), "dd MMMM yyyy, HH:mm", new Guid("fca3b741-9430-4942-b6ba-279ec688872b") },
                    { new Guid("9f5464ed-7d12-4aec-8a5c-153a30582981"), "yyyy-MM-ddTHH:mm:ss", new Guid("7c9560da-5774-49e5-8dff-a9430a7d2a37") },
                    { new Guid("a01551b8-b897-4978-98a7-30243d8b0205"), "HH:mm", new Guid("c428e45b-8166-4ea7-bee3-fde8f1091016") },
                    { new Guid("a90b79f6-23fe-49f5-a520-702e3cb8f753"), "HH:mm dd.MM.yyyy", new Guid("35a558ef-6c3e-4a4c-9d2f-ef1186066c94") },
                    { new Guid("a91c9f38-56be-4845-95c6-c199bafe1fda"), "d MMMM yyyy, HH:mm", new Guid("8c5ba3ad-760a-41f7-bc8c-ef8ac578370b") },
                    { new Guid("ad9ee04c-4ef5-45ed-b41f-e5621b8b235a"), "HH:mm", new Guid("0f6ad4ad-5c02-4d6b-bf2e-d61ae6c2cd9e") },
                    { new Guid("b0369e97-bb7c-4af3-9659-6a2fa50b3fdc"), "HH:mm, d MMMM yyyy", new Guid("076bd710-3025-43b1-982e-e80a9684faf7") },
                    { new Guid("b330c8d8-7c17-4e2e-afc6-65a6540bc5e5"), "yyyy-MM-dd HH:mm:ss", new Guid("e3a07056-5113-42d5-9999-94901993de11") },
                    { new Guid("bdaaabb2-22f9-4e78-9ee7-fa1b926aec67"), "dd.MM.yyyy HH:mm", new Guid("ab819ffa-6edf-4f76-ad3a-39a321197c69") },
                    { new Guid("bfde6fe1-4206-4e50-9cba-552ffe7238c3"), "dd MMMM yyyy, HH:mm", new Guid("c428e45b-8166-4ea7-bee3-fde8f1091016") },
                    { new Guid("c5498f30-b2dd-4150-83f8-2fe26f6fa34d"), "d MMMM yyyy, HH:mm МСК", new Guid("cefd73f1-38a9-4416-9b8c-0a0cf3b89b9a") },
                    { new Guid("cbcca330-49d9-42a6-8b92-9eb976c5d30c"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("8aa3bdd6-58eb-48d9-b54c-0cf4f07645a9") },
                    { new Guid("e2032be1-8d72-4660-99b0-b3dea2ca5527"), "dd.MM.yyyy HH:mm", new Guid("fb9f762e-cf12-4ea6-961c-ee7a99f4c0c6") },
                    { new Guid("f7e758da-9eed-479b-9f85-e7cef7e51b96"), "dd MMMM, HH:mm", new Guid("c428e45b-8166-4ea7-bee3-fde8f1091016") }
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
                name: "ix_news_parse_modified_at_settings_parse_settings_id",
                table: "news_parse_modified_at_settings",
                column: "parse_settings_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_news_parse_modified_at_settings_formats_news_parse_modified",
                table: "news_parse_modified_at_settings_formats",
                column: "news_parse_modified_at_settings_id");

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
                name: "ix_news_videos_news_id",
                table: "news_videos",
                column: "news_id",
                unique: true);
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
                name: "news_parse_modified_at_settings_formats");

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
