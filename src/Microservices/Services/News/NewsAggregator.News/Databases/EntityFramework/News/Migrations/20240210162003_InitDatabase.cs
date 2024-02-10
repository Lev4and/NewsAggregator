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
                    { new Guid("1630fcbc-1b8e-4eb9-854c-1dbdc82efc38"), true, "https://tass.ru/", "ТАСС" },
                    { new Guid("19984ab7-14ad-452a-90a7-55cdbb71ab24"), true, "https://www.gazeta.ru/", "Газета.Ru" },
                    { new Guid("23d12650-b6d1-4e41-9923-aa9128cd8b69"), true, "https://svpressa.ru/", "СвободнаяПресса" },
                    { new Guid("327de9a7-8cf4-4689-ae67-9f426af7fb14"), true, "https://www.ixbt.com/", "iXBT.com" },
                    { new Guid("38e09388-ff01-4a42-9c19-a608b60e7bd2"), true, "https://life.ru/", "Life" },
                    { new Guid("4411d20c-6e7c-4164-a235-7552f6fd6478"), true, "https://www.sports.ru/", "Storts.ru" },
                    { new Guid("44ea05b4-59d9-4f18-9908-4c9e7523c0ef"), true, "https://ixbt.games/", "iXBT.games" },
                    { new Guid("5b691dd0-331f-4e90-a2ba-d92592103782"), true, "https://www.nytimes.com/", "The New York Times" },
                    { new Guid("71c5491e-1f01-46da-b3f2-8a6e9ba6b94a"), true, "https://www.championat.com/", "Чемпионат.com" },
                    { new Guid("733afd7f-5d5d-482c-84ef-a2c3af5479c5"), true, "https://russian.rt.com/", "RT на русском" },
                    { new Guid("82fa1e10-8941-4695-942d-9b860580c23e"), true, "https://www.m24.ru/", "Москва 24" },
                    { new Guid("8ce25186-d143-47ad-8eba-a566eee5fec9"), true, "https://74.ru/", "74.ru" },
                    { new Guid("92108297-2a73-44c6-8921-fd1d6e2d1b57"), true, "https://vz.ru/", "ВЗГЛЯД.РУ" },
                    { new Guid("a8226ee2-8a5c-4bfb-8658-c1d396b9f72c"), true, "https://rg.ru/", "Российская газета" },
                    { new Guid("aa701a83-7c4f-463b-8e65-eebd1803f9a2"), true, "https://ura.news/", "Ura.ru" },
                    { new Guid("b41417a6-34b5-4bfe-8f20-d4d4ba8e6493"), true, "https://3dnews.ru/", "3Dnews.ru" },
                    { new Guid("b8220e30-e475-4b59-8fd4-f55de2d6c92f"), true, "https://ria.ru/", "РИА Новости" },
                    { new Guid("c0162824-c0f4-4256-9fbe-ec6e39dfb8ae"), true, "https://iz.ru/", "Известия" },
                    { new Guid("c2557465-c8af-444c-b34c-5a175ccd2993"), true, "https://www.belta.by/", "БелТА" },
                    { new Guid("cedf60ac-dae5-4769-a61c-5b6caf1c0ef6"), true, "https://edition.cnn.com/", "CNN" },
                    { new Guid("cee32e2b-6360-41ca-b815-a35893dd06cf"), true, "https://aif.ru/", "Аргументы и факты" },
                    { new Guid("def52732-4306-4ba0-9d4b-ee7cfe4ebb13"), true, "https://www.pravda.ru/", "Правда.ру" },
                    { new Guid("e31e9aee-5dc1-4854-bdcb-c977d2cf8a25"), true, "https://www.1obl.ru/", "Первый областной" },
                    { new Guid("e51f4ec5-2ea4-4f5a-b87b-943a53385329"), true, "https://lenta.ru/", "Лента.Ру" },
                    { new Guid("e547e4f9-c163-4c53-8442-072dacdf0253"), true, "https://tsargrad.tv/", "Царьград" },
                    { new Guid("e95d4455-05ab-4a8b-bd40-ece1caef9411"), true, "https://www.rbc.ru/", "РБК" },
                    { new Guid("e9aa816c-1525-42cb-92e6-81802e9663e8"), true, "https://www.interfax.ru/", "Интерфакс" },
                    { new Guid("f04463e8-559d-4501-b653-cee9e7552c43"), true, "https://www.kommersant.ru/", "Коммерсантъ" },
                    { new Guid("f057ee19-3d7d-4cc9-a267-98f5f437d010"), true, "https://www.hltv.org/", "HLTV.org" },
                    { new Guid("fd39c3f9-fe35-4c01-abe4-c510b6d5e7c3"), true, "https://www.cybersport.ru/", "Cybersport.ru" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_settings",
                columns: new[] { "id", "description_x_path", "source_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("0cbe1d16-9feb-4c9e-9e7a-52071c59f3ab"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()>1]", new Guid("b41417a6-34b5-4bfe-8f20-d4d4ba8e6493"), "//h1/text()" },
                    { new Guid("20ee359a-2579-489b-a970-71e8f4c15fdd"), "//div[@itemprop='articleBody']/*", new Guid("c0162824-c0f4-4256-9fbe-ec6e39dfb8ae"), "//h1/span/text()" },
                    { new Guid("22388dda-8d23-40b9-a324-5a512d3c5e77"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview'))]", new Guid("e95d4455-05ab-4a8b-bd40-ece1caef9411"), "//h1/text()" },
                    { new Guid("26bcd1cd-f0db-402a-8448-1050d09ec02b"), "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]", new Guid("def52732-4306-4ba0-9d4b-ee7cfe4ebb13"), "//h1/text()" },
                    { new Guid("2c256dba-f80c-402b-b064-87a185d954be"), "//div[contains(@class, 'js-mediator-article')]/*[position()>1]", new Guid("fd39c3f9-fe35-4c01-abe4-c510b6d5e7c3"), "//h1/text()" },
                    { new Guid("2da9ac83-9968-45be-b2e6-37c5c73e5d45"), "//div[@itemprop='articleBody']/*[not(name() = 'figure')]", new Guid("8ce25186-d143-47ad-8eba-a566eee5fec9"), "//h1[@itemprop='headline']/span/text()" },
                    { new Guid("300dd4d5-b4e4-4404-914e-1190e7bc1457"), "//div[contains(@class, 'PageContentCommonStyling_text')]/*[not(name() = 'rg-video')]", new Guid("a8226ee2-8a5c-4bfb-8658-c1d396b9f72c"), "//h1/text()" },
                    { new Guid("34530e8d-de51-421a-a6d3-181e9fbf276b"), "//section[@name='articleBody']/*", new Guid("5b691dd0-331f-4e90-a2ba-d92592103782"), "//h1/text()" },
                    { new Guid("40e72807-a539-458d-bf50-68fc96f1904d"), "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]", new Guid("38e09388-ff01-4a42-9c19-a608b60e7bd2"), "//h1/text()" },
                    { new Guid("48e91757-5d42-44cf-9970-240a64fb8f8a"), "//div[@itemprop='articleBody']/*", new Guid("cedf60ac-dae5-4769-a61c-5b6caf1c0ef6"), "//h1/text()" },
                    { new Guid("5242e435-6eeb-458b-94f0-4fdbf0818702"), "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]", new Guid("23d12650-b6d1-4e41-9923-aa9128cd8b69"), "//h1[@class='b-text__title']/text()" },
                    { new Guid("52e0701b-95ac-4ff9-a8da-2db05e303ddf"), "//div[@itemprop='articleBody']/*[not(name()='div')]", new Guid("aa701a83-7c4f-463b-8e65-eebd1803f9a2"), "//h1/text()" },
                    { new Guid("657f6c1b-b7fa-4a1d-ad94-9d5a439526e5"), "//article/div[@class='news_text']", new Guid("92108297-2a73-44c6-8921-fd1d6e2d1b57"), "//h1/text()" },
                    { new Guid("67443929-b833-4bb5-b650-e97beb8929a7"), "//div[contains(@class, 'news-item__content')]", new Guid("4411d20c-6e7c-4164-a235-7552f6fd6478"), "//h1/text()" },
                    { new Guid("6a25edd6-63bf-45ce-bb0f-bfe6b139b476"), "//div[@class='article_text']", new Guid("cee32e2b-6360-41ca-b815-a35893dd06cf"), "//h1/text()" },
                    { new Guid("7718d879-36d6-4f21-a617-db317d94b5c9"), "//div[contains(@class, 'container-fluid shifted') and not(p[@class='announce lead']) and not(h1) and not(hr)]", new Guid("44ea05b4-59d9-4f18-9908-4c9e7523c0ef"), "//h1/text()" },
                    { new Guid("7eb1d86a-44ce-435d-a050-5e1a2d5002ce"), "//div[@class='js-mediator-article']", new Guid("c2557465-c8af-444c-b34c-5a175ccd2993"), "//h1/text()" },
                    { new Guid("8aa4c993-8f67-41c4-918d-013a61e7a35b"), "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]", new Guid("e9aa816c-1525-42cb-92e6-81802e9663e8"), "//h1/text()" },
                    { new Guid("9557b72f-078e-4611-a6e0-230a7e437697"), "//div[contains(@class, 'article__text ')]", new Guid("733afd7f-5d5d-482c-84ef-a2c3af5479c5"), "//h1/text()" },
                    { new Guid("a6306e58-0edb-4b1b-b8f8-d1930e46d5d0"), "//article/*", new Guid("1630fcbc-1b8e-4eb9-854c-1dbdc82efc38"), "//h1/text()" },
                    { new Guid("a6b0f1b0-20ff-4cff-842a-a6a92a413364"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]", new Guid("f04463e8-559d-4501-b653-cee9e7552c43"), "//h1/text()" },
                    { new Guid("ab5a812f-e2cc-46f7-833a-2c3c8202a2a5"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]", new Guid("e547e4f9-c163-4c53-8442-072dacdf0253"), "//h1[@class='article__title']/text()" },
                    { new Guid("ab5cf625-0f36-4a5b-84dd-390632f6c615"), "//div[@itemprop='articleBody']/*", new Guid("e31e9aee-5dc1-4854-bdcb-c977d2cf8a25"), "//h1[@itemprop='headline']/text()" },
                    { new Guid("ab664e06-ec91-4e04-8eb1-350fd21c8e93"), "//article//div[@class='newstext-con']/*[position()>2]", new Guid("f057ee19-3d7d-4cc9-a267-98f5f437d010"), "//h1[@class='headline']/text()" },
                    { new Guid("ad982c68-2bc8-453e-8b32-bab6944a3f5f"), "//div[@itemprop='articleBody']/*", new Guid("19984ab7-14ad-452a-90a7-55cdbb71ab24"), "//h1/text()" },
                    { new Guid("bdb18f62-4976-446a-af4b-13f093e7e200"), "//div[@class='topic-body__content']", new Guid("e51f4ec5-2ea4-4f5a-b87b-943a53385329"), "//h1[@class='topic-body__titles']/span[@class='topic-body__title']/text()" },
                    { new Guid("cdb667f0-3518-4e71-a60d-bd82d5fa07d4"), "//div[@itemprop='articleBody']/*", new Guid("327de9a7-8cf4-4689-ae67-9f426af7fb14"), "//h1/text()" },
                    { new Guid("eed3873d-da7e-49e4-8f21-db82ef61ac53"), "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]", new Guid("82fa1e10-8941-4695-942d-9b860580c23e"), "//h1/text()" },
                    { new Guid("f2c805a6-d0e1-4b4c-ad51-7782c91fd5b9"), "//article/div[@class='article-content']/*[not(@class)]", new Guid("71c5491e-1f01-46da-b3f2-8a6e9ba6b94a"), "//article/header/div[@class='article-head__title']/text()" },
                    { new Guid("f654e9b0-9f41-46d7-9070-dbbcc932dbb1"), "//div[contains(@class, 'article__body')]", new Guid("b8220e30-e475-4b59-8fd4-f55de2d6c92f"), "//div[@class='article__title']/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_search_settings",
                columns: new[] { "id", "news_site_url", "news_url_x_path", "source_id" },
                values: new object[,]
                {
                    { new Guid("10436b87-5493-45f5-bef0-963c42bcb4ba"), "https://www.championat.com/news/1.html?utm_source=button&utm_medium=news", "//a[contains(@href, 'news-') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("71c5491e-1f01-46da-b3f2-8a6e9ba6b94a") },
                    { new Guid("1281376a-01c5-4afb-9eb3-bdbfa4b0fd64"), "https://www.gazeta.ru/news/", "//a[contains(@href, '/news/') and contains(@href, '.shtml') and not(contains(@href, '?'))]/@href", new Guid("19984ab7-14ad-452a-90a7-55cdbb71ab24") },
                    { new Guid("146e1475-9d23-4a0f-a4c5-e10a6109f7a0"), "https://ura.news/", "//a[contains(@href, '/news/')]/@href", new Guid("aa701a83-7c4f-463b-8e65-eebd1803f9a2") },
                    { new Guid("18776022-3890-4e52-b125-fdcaf9ff24e5"), "https://www.1obl.ru/news/", "//a[starts-with(@href, '/news/') and not(contains(@href, '?'))]/@href", new Guid("e31e9aee-5dc1-4854-bdcb-c977d2cf8a25") },
                    { new Guid("21690aac-f77b-4520-8858-09f5004518d5"), "https://www.nytimes.com/", "//a[contains(@href, '.html')]/@href", new Guid("5b691dd0-331f-4e90-a2ba-d92592103782") },
                    { new Guid("30a7e0dc-2c20-44e0-9bdf-ec9a4968c7b0"), "https://3dnews.ru/news/", "//div[@class='news-feed-all']//a[@class='entry-header']/h1/../@href", new Guid("b41417a6-34b5-4bfe-8f20-d4d4ba8e6493") },
                    { new Guid("378ab7ff-f111-4e4c-99be-f6841f1c5cc4"), "https://www.sports.ru/news/", "//a[contains(@href, '.html') and not(contains(@href, '.html#comments')) and not (contains(@href, '/blogs/'))]/@href", new Guid("4411d20c-6e7c-4164-a235-7552f6fd6478") },
                    { new Guid("38009dde-3a10-47d4-a4df-95d5c51b53a7"), "https://www.kommersant.ru/", "//a[contains(@href, '/doc/') and contains(@href, '?from=')]/@href", new Guid("f04463e8-559d-4501-b653-cee9e7552c43") },
                    { new Guid("4d5222ff-2d3f-493e-be14-b45d57b25eb9"), "https://www.interfax.ru/", "//div[@class='timeline']//a[@tabindex=5]/@href", new Guid("e9aa816c-1525-42cb-92e6-81802e9663e8") },
                    { new Guid("51fb7935-28bf-4cdc-8daa-91a68626abb8"), "https://lenta.ru/", "//a[starts-with(@href, '/news/')]/@href", new Guid("e51f4ec5-2ea4-4f5a-b87b-943a53385329") },
                    { new Guid("54b3f096-967e-4098-b5a8-e6d3502a53da"), "https://iz.ru/news/", "//a[contains(@href, '?main_click')]/@href", new Guid("c0162824-c0f4-4256-9fbe-ec6e39dfb8ae") },
                    { new Guid("5da8227a-ece2-402a-b745-0bce66339b73"), "https://www.rbc.ru/", "//a[contains(@href, 'https://www.rbc.ru/') and contains(@href, '?from=')]/@href", new Guid("e95d4455-05ab-4a8b-bd40-ece1caef9411") },
                    { new Guid("65602c39-ffda-4283-9b32-c2ca0bdf583b"), "https://vz.ru/", "//a[contains(@href, '.html') and not(contains(@href, '#comments')) and not(contains(@href, '?')) and not(contains(@href, '/about/'))]/@href", new Guid("92108297-2a73-44c6-8921-fd1d6e2d1b57") },
                    { new Guid("7ea2836d-2dd3-4768-b5dd-5f1cb59d37f1"), "https://edition.cnn.com/", "//a[contains(@href, '.html')]/@href", new Guid("cedf60ac-dae5-4769-a61c-5b6caf1c0ef6") },
                    { new Guid("880827ad-ce0b-4de0-9909-3cddb0a73434"), "https://www.belta.by/", "//a[contains(@href, 'https://www.belta.by/') and contains(@href, '/view/')]/@href", new Guid("c2557465-c8af-444c-b34c-5a175ccd2993") },
                    { new Guid("9a61be30-87eb-4c41-8ee0-44c36992447b"), "https://www.ixbt.com/news/", "//a[starts-with(@href, '/news/') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("327de9a7-8cf4-4689-ae67-9f426af7fb14") },
                    { new Guid("9d5f9ca4-1573-466d-ad91-621b36370e8e"), "https://ixbt.games/news/", "//a[@class='card-link']/@href", new Guid("44ea05b4-59d9-4f18-9908-4c9e7523c0ef") },
                    { new Guid("a09d3eac-9aae-44a2-b096-77e62e497306"), "https://aif.ru/", "//span[contains(@class, 'item_text__title')]/../@href", new Guid("cee32e2b-6360-41ca-b815-a35893dd06cf") },
                    { new Guid("a2f5c13f-2948-4137-9c5b-2ddd327ef169"), "https://life.ru/s/novosti", "//a[contains(@href, '/p/')]/@href", new Guid("38e09388-ff01-4a42-9c19-a608b60e7bd2") },
                    { new Guid("a3b7b7d3-9969-486a-9fcf-0ae9fddcfded"), "https://svpressa.ru/all/news/", "//a[contains(@href, '/news/') and not(contains(@href, '?')) and not(starts-with(@href, '/all/news/'))]/@href", new Guid("23d12650-b6d1-4e41-9923-aa9128cd8b69") },
                    { new Guid("a9c2c17a-8b52-4d29-9d7a-17da8d891ce3"), "https://tass.ru/", "//a[contains(@class, 'tass_pkg_link-v5WdK') and contains(substring(@href, 2), '/') and not(contains(@href, '/spec/')) and not(contains(@href, 'spec.tass.ru'))]/@href", new Guid("1630fcbc-1b8e-4eb9-854c-1dbdc82efc38") },
                    { new Guid("ae884008-38bb-4217-8b2b-1bd0210d54c9"), "https://74.ru/", "//a[starts-with(@href, '/text/') and not(contains(@href, '?')) and not(contains(@href, 'comments/')) and not(@href='/text/')]/@href", new Guid("8ce25186-d143-47ad-8eba-a566eee5fec9") },
                    { new Guid("b4e550f7-cec3-4bae-8080-1c10cdee6283"), "https://tsargrad.tv/", "//a[contains(@class, 'news-item__link')]/@href", new Guid("e547e4f9-c163-4c53-8442-072dacdf0253") },
                    { new Guid("bb903d3a-fbf1-42b9-a812-7c4b24999a25"), "https://www.pravda.ru/", "//a[contains(@href, '/news/') and not(@href='https://www.pravda.ru/news/')]/@href", new Guid("def52732-4306-4ba0-9d4b-ee7cfe4ebb13") },
                    { new Guid("c06cd553-4f1b-4765-9526-97d829fa206b"), "https://www.m24.ru/", "//a[contains(@href, '/news/')]/@href", new Guid("82fa1e10-8941-4695-942d-9b860580c23e") },
                    { new Guid("d08ea3e4-2b0e-435b-9f51-b3dedc5618f5"), "https://www.hltv.org/", "//a[contains(@href, '/news/')]/@href", new Guid("f057ee19-3d7d-4cc9-a267-98f5f437d010") },
                    { new Guid("dad64d7b-faf4-41e7-8a06-bb4d6b8fbc16"), "https://ria.ru/", "//a[contains(@class, 'cell-list__item-link')]/@href", new Guid("b8220e30-e475-4b59-8fd4-f55de2d6c92f") },
                    { new Guid("dc2c2f99-6c7b-48bc-8f1e-2c633581c524"), "https://rg.ru/", "//a[contains(@href, '.html')]/@href", new Guid("a8226ee2-8a5c-4bfb-8658-c1d396b9f72c") },
                    { new Guid("e2d7f51d-d3e1-4f5a-b83d-b51530a88c40"), "https://www.cybersport.ru/", "//a[contains(@href, '/tags/')]/@href", new Guid("fd39c3f9-fe35-4c01-abe4-c510b6d5e7c3") },
                    { new Guid("f5d08b59-505c-4b69-ac8d-d659292edc9b"), "https://russian.rt.com/", "//a[contains(@class, 'link') and contains(@href, 'news/')]/@href", new Guid("733afd7f-5d5d-482c-84ef-a2c3af5479c5") }
                });

            migrationBuilder.InsertData(
                table: "news_source_logos",
                columns: new[] { "id", "original", "small", "source_id" },
                values: new object[,]
                {
                    { new Guid("0665e489-ae45-4199-b0fc-041d696e29f6"), "https://www.hltv.org/img/static/favicon/apple-touch-icon.png", "https://www.hltv.org/img/static/favicon/favicon-32x32.png", new Guid("f057ee19-3d7d-4cc9-a267-98f5f437d010") },
                    { new Guid("0f1b48fc-4878-4e85-8951-3f3dab39ba7c"), "https://www.ixbt.com/favicon.ico", "https://www.ixbt.com/favicon.ico", new Guid("327de9a7-8cf4-4689-ae67-9f426af7fb14") },
                    { new Guid("1f0cc17c-c76e-4305-a428-986d2bcf8798"), "https://edition.cnn.com/media/sites/cnn/apple-touch-icon.png", "https://edition.cnn.com/media/sites/cnn/favicon.ico", new Guid("cedf60ac-dae5-4769-a61c-5b6caf1c0ef6") },
                    { new Guid("22eafd30-c38f-4556-bedb-0000d734f216"), "https://cdn.iz.ru/profiles/portal/themes/purple/images/favicons/android-icon-192x192.png", "https://cdn.iz.ru/profiles/portal/themes/purple/images/favicons/favicon-32x32.png", new Guid("c0162824-c0f4-4256-9fbe-ec6e39dfb8ae") },
                    { new Guid("287f03f0-d635-4bf0-83a2-7bff3775bcce"), "https://st.championat.com/i/favicon/apple-touch-icon.png", "https://st.championat.com/i/favicon/favicon-32x32.png", new Guid("71c5491e-1f01-46da-b3f2-8a6e9ba6b94a") },
                    { new Guid("3868eb92-9c4a-4606-9c80-26f4bc8fb56f"), "https://ixbt.games/images/favicon/gt/apple-touch-icon.png", "https://ixbt.games/images/favicon/gt/apple-touch-icon.png", new Guid("44ea05b4-59d9-4f18-9908-4c9e7523c0ef") },
                    { new Guid("47ef850e-4de2-4e1d-86d0-ed27e3b8940c"), "https://www.sports.ru/apple-touch-icon-1024.png", "https://www.sports.ru/apple-touch-icon-76.png", new Guid("4411d20c-6e7c-4164-a235-7552f6fd6478") },
                    { new Guid("4a6b8f9f-7f8b-4e80-ad73-32dbbef2f992"), "https://www.interfax.ru/touch-icon-ipad-retina.png", "https://www.interfax.ru/touch-icon-iphone.png", new Guid("e9aa816c-1525-42cb-92e6-81802e9663e8") },
                    { new Guid("4fb1d2dd-8b1d-4ac7-880f-c8c84e06aac8"), "https://www.1obl.ru/apple-touch-icon.png", "https://www.1obl.ru/favicon-32x32.png", new Guid("e31e9aee-5dc1-4854-bdcb-c977d2cf8a25") },
                    { new Guid("55538906-acec-4d9e-a531-a2b603b5b159"), "https://s.rbk.ru/v10_rbcnews_static/common/common-10.10.120/images/android-chrome-512x512.png", "https://s.rbk.ru/v10_rbcnews_static/common/common-10.10.120/images/favicon.png", new Guid("e95d4455-05ab-4a8b-bd40-ece1caef9411") },
                    { new Guid("76db8c7b-b55c-456f-ad5d-02c4bd84b061"), "https://3dnews.ru/assets/images/3dnews_logo_soc.png", "https://3dnews.ru/assets/3dnews_logo_color.png", new Guid("b41417a6-34b5-4bfe-8f20-d4d4ba8e6493") },
                    { new Guid("8242fe79-f902-4fa6-a42f-2fd8de3fb9a0"), "https://www.belta.by/images/storage/banners/000016_a133e848cb2e7b1debb7102d19e4d139_work.svg", "https://www.belta.by/images/storage/banners/000016_a133e848cb2e7b1debb7102d19e4d139_work.svg", new Guid("c2557465-c8af-444c-b34c-5a175ccd2993") },
                    { new Guid("9324298e-6936-4f8e-8195-d445075c64b7"), "https://cdnn21.img.ria.ru/i/favicons/favicon.svg", "https://cdnn21.img.ria.ru/i/favicons/favicon.ico", new Guid("b8220e30-e475-4b59-8fd4-f55de2d6c92f") },
                    { new Guid("a20ea9c1-dc38-4feb-90d7-761ac092671f"), "https://www.pravda.ru/pix/apple-touch-icon.png", "https://www.pravda.ru/favicon.ico", new Guid("def52732-4306-4ba0-9d4b-ee7cfe4ebb13") },
                    { new Guid("ab09a2a1-a934-44dc-b518-6150d5794752"), "https://www.cybersport.ru/favicon-192x192.png", "https://www.cybersport.ru/favicon-32x32.png", new Guid("fd39c3f9-fe35-4c01-abe4-c510b6d5e7c3") },
                    { new Guid("abef1cdf-4981-454e-8c90-1fbf6824d671"), "https://static.gazeta.ru/nm2021/img/icons/favicon.svg", "https://static.gazeta.ru/nm2021/img/icons/favicon.svg", new Guid("19984ab7-14ad-452a-90a7-55cdbb71ab24") },
                    { new Guid("b95d9c13-c633-4718-8f57-f1654c0895e8"), "https://vz.ru/apple-touch-icon.png", "https://vz.ru/static/images/favicon.ico", new Guid("92108297-2a73-44c6-8921-fd1d6e2d1b57") },
                    { new Guid("bad73842-90bc-4030-bf1d-047522da2478"), "https://im.kommersant.ru/ContentFlex/images/favicons2020/apple-touch-icon-180.png", "https://im.kommersant.ru/ContentFlex/images/favicons2020/favicon-32.png", new Guid("f04463e8-559d-4501-b653-cee9e7552c43") },
                    { new Guid("c46f1fe2-da1f-4484-851f-908b74a5f967"), "https://svpressa.ru/favicon-96x96.png?v=1471426270000", "https://svpressa.ru/favicon-32x32.png?v=1471426270000", new Guid("23d12650-b6d1-4e41-9923-aa9128cd8b69") },
                    { new Guid("cce36eb5-df11-4d7f-93d5-0c493285bc8b"), "https://www.m24.ru/img/fav/apple-touch-icon.png", "https://www.m24.ru/img/fav/favicon-32x32.png", new Guid("82fa1e10-8941-4695-942d-9b860580c23e") },
                    { new Guid("cd392602-c63f-4bdc-ae4d-e0f72ff706ef"), "https://life.ru/appletouch/apple-icon-180%D1%85180.png", "https://life.ru/favicon-32%D1%8532.png", new Guid("38e09388-ff01-4a42-9c19-a608b60e7bd2") },
                    { new Guid("cfcbb358-1f45-4975-8650-0ccba5a1c1d4"), "https://cdnstatic.rg.ru/images/touch-icon-ipad-retina_512x512.png", "https://rg.ru/favicon.ico", new Guid("a8226ee2-8a5c-4bfb-8658-c1d396b9f72c") },
                    { new Guid("d0280ac0-ae8d-47ec-be37-ec0b64557ec8"), "https://russian.rt.com/static/blocks/touch-icon/apple-touch-icon-144x144-precomposed.png", "https://russian.rt.com/favicon.ico", new Guid("733afd7f-5d5d-482c-84ef-a2c3af5479c5") },
                    { new Guid("d35a06e1-da04-4bdd-a20c-12b5c5531985"), "https://icdn.lenta.ru/images/icons/icon-256x256.png", "https://icdn.lenta.ru/favicon.ico", new Guid("e51f4ec5-2ea4-4f5a-b87b-943a53385329") },
                    { new Guid("d8c531d8-d56e-47ad-82ca-36723ec5ead8"), "https://ura.news/apple-touch-icon.png", "https://s.ura.news/favicon.ico?3", new Guid("aa701a83-7c4f-463b-8e65-eebd1803f9a2") },
                    { new Guid("e0173595-a2a3-4ff6-9357-22be6e56de20"), "https://www.nytimes.com/vi-assets/static-assets/apple-touch-icon-28865b72953380a40aa43318108876cb.png", "https://www.nytimes.com/vi-assets/static-assets/ios-default-homescreen-57x57-dark-b395ebcad5b63aff9285aab58e31035e.png", new Guid("5b691dd0-331f-4e90-a2ba-d92592103782") },
                    { new Guid("e60d1915-699f-45e0-931c-828ca5331e7f"), "https://tass.ru/favicon/180.svg", "https://tass.ru/favicon/57.png", new Guid("1630fcbc-1b8e-4eb9-854c-1dbdc82efc38") },
                    { new Guid("ee27ed59-293e-4960-8c89-7daf762dfed1"), "https://aif.ru/img/icon/apple-touch-icon.png?44f", "https://aif.ru/img/icon/favicon-32x32.png?44f", new Guid("cee32e2b-6360-41ca-b815-a35893dd06cf") },
                    { new Guid("fb9c16a8-e786-4ebe-90d1-aded4f35cc96"), "https://tsargrad.tv/favicons/apple-touch-icon-180x180.png?s2", "https://tsargrad.tv/favicons/favicon-32x32.png?s2", new Guid("e547e4f9-c163-4c53-8442-072dacdf0253") },
                    { new Guid("fef8a7bd-d02f-4b1f-a16b-15ad3cbae97b"), "https://static.ngs.ru/jtnews/dist/static/favicons/apple/apple-favicon-74-180.png", "https://static.ngs.ru/jtnews/dist/static/favicons/favicon-rugion-32.ico", new Guid("8ce25186-d143-47ad-8eba-a566eee5fec9") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_editor_settings",
                columns: new[] { "id", "is_required", "name_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("13f93d30-9cfa-498e-845d-a35602b976b3"), true, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']//a[@itemprop='author']//span[@itemprop='name']/text()", new Guid("0cbe1d16-9feb-4c9e-9e7a-52071c59f3ab") },
                    { new Guid("2522f5bd-8fad-4aa3-b847-345a437cf766"), false, "//div[@class='author']/span[@itemprop='author']/span[@itemprop='name']/a/text()", new Guid("ad982c68-2bc8-453e-8b32-bab6944a3f5f") },
                    { new Guid("3222a788-5349-41df-a778-15713f02c057"), true, "//div[@class='container-fluid publication-footer']//a[contains(@class, 'text-secondary')]/@title", new Guid("7718d879-36d6-4f21-a617-db317d94b5c9") },
                    { new Guid("3b24ce81-79cb-4df7-8497-7b98cfae82e6"), true, "//div[@class='article_top']//div[@class='authors']//div[@class='autor']//span/text()", new Guid("6a25edd6-63bf-45ce-bb0f-bfe6b139b476") },
                    { new Guid("3e1ab46e-6336-45c4-bdd8-e7e6a7cbd432"), false, "//div[@class='topic-authors']/a[@class='topic-authors__author']/text()", new Guid("bdb18f62-4976-446a-af4b-13f093e7e200") },
                    { new Guid("48854a28-c782-4b7d-8181-b83fd2489cce"), true, "//*[@itemprop='author']/*[@itemprop='name']//text()", new Guid("ab5cf625-0f36-4a5b-84dd-390632f6c615") },
                    { new Guid("4e31fd66-0d69-4d6c-ab2d-694b10a1af1f"), false, "//div[@class='article__authors']//*[@class='article__authors__author']/span[@class='article__authors__author__name']/text()", new Guid("22388dda-8d23-40b9-a324-5a512d3c5e77") },
                    { new Guid("4e8b4f97-5c8c-4d07-aaa2-376425758fce"), true, "//a[@class='article__author']/text()", new Guid("ab5a812f-e2cc-46f7-833a-2c3c8202a2a5") },
                    { new Guid("7232e8f9-97bc-4110-8abc-870cc29080ee"), true, "//div[contains(@class, 'PageArticleContent_authors')]//a[contains(@class, 'LinksOfAuthor_item')]/text()", new Guid("300dd4d5-b4e4-4404-914e-1190e7bc1457") },
                    { new Guid("892b5df9-95a6-4275-8245-781b3ddbda1b"), true, "//span[@itemprop='name']/a/text()", new Guid("34530e8d-de51-421a-a6d3-181e9fbf276b") },
                    { new Guid("903d2889-92e8-4ea8-aa75-cb7a8e1bc280"), true, "//span[@itemprop='author']/span[@itemprop='name']/@content", new Guid("cdb667f0-3518-4e71-a60d-bd82d5fa07d4") },
                    { new Guid("9d5e3af6-c4cd-44b6-bee0-12b1f60496dd"), true, "//div[@itemprop='author']/span[@itemprop='name']/text()", new Guid("52e0701b-95ac-4ff9-a8da-2db05e303ddf") },
                    { new Guid("b3a16cec-e2ef-4537-98d8-3f975f40b97a"), true, "//article//header//div[@class='article-head__author-name']/a[@rel='author']/span/text()", new Guid("f2c805a6-d0e1-4b4c-ad51-7782c91fd5b9") },
                    { new Guid("c72ee54e-4e65-4de4-8c80-1c82cc148b9c"), false, "//div[@itemprop='author']//p[@itemprop='name']/text()", new Guid("2da9ac83-9968-45be-b2e6-37c5c73e5d45") },
                    { new Guid("d04b2a5b-25c8-4bb9-9164-c31669afedc9"), true, "//div[contains(@class, 'full-article')]/div[@class='authors-block']//span[text()='Автор']/../a/text()", new Guid("26bcd1cd-f0db-402a-8448-1050d09ec02b") },
                    { new Guid("d0de08c3-59d7-45b0-be65-c01ec0e67ee6"), true, "//div[contains(@class, 'styles_bodyWrapper')]//div[contains(@class, 'styles_authorsLinks')]/a/text()", new Guid("40e72807-a539-458d-bf50-68fc96f1904d") },
                    { new Guid("e092066a-c61a-4366-acf7-ea2283a72996"), true, "//footer[@class='news-item__footer']/div[@class='news-item__footer-after-news']/p[position()=1]//span/text()", new Guid("67443929-b833-4bb5-b650-e97beb8929a7") },
                    { new Guid("ec1c623f-b8a2-4817-a12e-b2fbe4ed678d"), true, "//article//span[@class='author']/a[@class='authorName']/span/text()", new Guid("ab664e06-ec91-4e04-8eb1-350fd21c8e93") },
                    { new Guid("f45aa61d-e9d2-426f-bf35-09a940b110c7"), true, "//div[@class='headline__footer']//div[@class='byline__names']/span[@class='byline__name']/text()", new Guid("48e91757-5d42-44cf-9970-240a64fb8f8a") },
                    { new Guid("fb442543-c3b5-46ed-9afb-56305e72c27a"), false, "//p[@class='doc__text document_authors']/text()", new Guid("a6b0f1b0-20ff-4cff-842a-a6a92a413364") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_modified_at_settings",
                columns: new[] { "id", "is_required", "modified_at_culture_info", "modified_at_time_zone_info_id", "modified_at_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("51b14447-ca1d-4c52-beb2-b609e20b456f"), true, "ru-RU", "Russian Standard Time", "//div[@class='article__info']//div[@class='article__info-date']/span[@class='article__info-date-modified']/text()", new Guid("f654e9b0-9f41-46d7-9070-dbbcc932dbb1") },
                    { new Guid("cee486ab-db21-47da-96e7-67094cbd84dc"), false, "ru-RU", "Russian Standard Time", "//div[@class='doc_header__time']/span[contains(@class, 'publish_update')]/text()", new Guid("a6b0f1b0-20ff-4cff-842a-a6a92a413364") },
                    { new Guid("f9f00a28-c179-496e-8f27-436d1d4f60a6"), false, "ru-RU", "UTC", "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark_update')]//span[@ca-ts]/text()", new Guid("a6306e58-0edb-4b1b-b8f8-d1930e46d5d0") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_picture_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("04e07fcc-d1be-4e76-8f56-5746544e2344"), false, new Guid("ab664e06-ec91-4e04-8eb1-350fd21c8e93"), "//article//div[@class='image-con' and position() = 1]/picture/img/@src" },
                    { new Guid("0fae7a18-0bae-424f-91f9-4b6e94a97b0d"), true, new Guid("48e91757-5d42-44cf-9970-240a64fb8f8a"), "//div[contains(@class, 'article__lede-wrapper')]//picture/img/@src" },
                    { new Guid("12f5cdbb-92b6-4987-97cc-3fb6a87edd5a"), true, new Guid("2c256dba-f80c-402b-b064-87a185d954be"), "//meta[@property='og:image']/@content" },
                    { new Guid("4eeaae50-804f-492c-93f5-22e5de3fced6"), false, new Guid("26bcd1cd-f0db-402a-8448-1050d09ec02b"), "//div[contains(@class, 'full-article')]/div[contains(@class, 'gallery')]/picture/img/@src" },
                    { new Guid("54120ca5-a8f9-4cb1-8d83-46430e2cee73"), false, new Guid("6a25edd6-63bf-45ce-bb0f-bfe6b139b476"), "//div[@class='img_box']/a[@class='zoom_js']/img/@src" },
                    { new Guid("55cb18dd-12d3-4204-816c-fdf3a9d83877"), false, new Guid("40e72807-a539-458d-bf50-68fc96f1904d"), "//article//header/div[contains(@class, 'styles_cover_media')]/img/@src" },
                    { new Guid("57335581-ed97-4d05-93cd-922370a8ec14"), false, new Guid("eed3873d-da7e-49e4-8f21-db82ef61ac53"), "//div[@class='b-material-incut-m-image']//@src" },
                    { new Guid("5736e79d-b344-4884-9359-70eb2f908a7d"), true, new Guid("ab5cf625-0f36-4a5b-84dd-390632f6c615"), "//div[contains(@class, 'newsMediaContainer')]/img/@data-src" },
                    { new Guid("5b98121c-ee75-4a2d-bf88-b04b85a07d74"), true, new Guid("7718d879-36d6-4f21-a617-db317d94b5c9"), "//a[@class='glightbox']/img[contains(@class, 'pub-cover')]/@src" },
                    { new Guid("63c04d1a-ea11-45f9-832a-038bec7f0ca2"), false, new Guid("f654e9b0-9f41-46d7-9070-dbbcc932dbb1"), "//div[@class='photoview__open']/img/@src" },
                    { new Guid("74110903-98d3-4c9c-ad0e-fb020c282599"), true, new Guid("5242e435-6eeb-458b-94f0-4fdbf0818702"), "//picture/img/@src" },
                    { new Guid("81706bf5-103e-4d1e-8e48-7652fb409d52"), false, new Guid("9557b72f-078e-4611-a6e0-230a7e437697"), "//div[contains(@class, 'article__cover')]/img[@class='article__cover-image ']/@src" },
                    { new Guid("84a4b2f3-1277-44fb-9679-abafcd92f4f3"), true, new Guid("ab5a812f-e2cc-46f7-833a-2c3c8202a2a5"), "//div[@class='article__media']//img/@src" },
                    { new Guid("9318e705-44fb-4b45-b1c8-99041269e17f"), false, new Guid("7eb1d86a-44ce-435d-a050-5e1a2d5002ce"), "//div[@class='inner_content']//div[@class='main_img']//img/@src" },
                    { new Guid("a35e2a60-4e6a-4114-bc7e-463f036aa644"), false, new Guid("f2c805a6-d0e1-4b4c-ad51-7782c91fd5b9"), "//article//header/div[@class='article-head__photo']/img/@src" },
                    { new Guid("afcfc5d2-55aa-4d01-b74a-b85bdd81b05b"), false, new Guid("2da9ac83-9968-45be-b2e6-37c5c73e5d45"), "//figure//img/@src" },
                    { new Guid("c7844c4c-3c4f-4d25-b7f1-f43a6dccbe06"), false, new Guid("a6306e58-0edb-4b1b-b8f8-d1930e46d5d0"), "//div[contains(@class, 'HeaderMedia_image')]//img[contains(@class, 'Image_image')]/@src" },
                    { new Guid("d314a2fa-85bc-4a6a-af1e-c71c30f82a6c"), true, new Guid("52e0701b-95ac-4ff9-a8da-2db05e303ddf"), "//div[@itemprop='articleBody']//div[@itemprop='image']/picture/img[@itemprop='contentUrl']/@src" },
                    { new Guid("da2c443a-afe0-48ec-8521-84b1e49beb2b"), true, new Guid("20ee359a-2579-489b-a970-71e8f4c15fdd"), "//div[contains(@class, 'big_photo')]//div[@class='big_photo__img']//img/@data-src" },
                    { new Guid("dd6f7bcd-79df-498e-a6ab-b4940aff1285"), false, new Guid("0cbe1d16-9feb-4c9e-9e7a-52071c59f3ab"), "//img[@itemprop='image']/@src" },
                    { new Guid("e18f5902-51ba-45bf-ae5a-9d97b27839a4"), true, new Guid("34530e8d-de51-421a-a6d3-181e9fbf276b"), "//header//figure//picture/img/@src" },
                    { new Guid("e593926e-2798-4212-a847-372166b96a5d"), false, new Guid("ad982c68-2bc8-453e-8b32-bab6944a3f5f"), "//div[@class='b_article-media']//div[@class='mainarea-wrapper']/figure/img[@class='item-image-front']/@src" },
                    { new Guid("f06bcb73-abe1-4256-bcfe-4e68bb984c56"), false, new Guid("657f6c1b-b7fa-4a1d-ad94-9d5a439526e5"), "//article/figure/img/@src" },
                    { new Guid("f880e90b-a0b0-4ef4-a0ee-658681f2c3a3"), false, new Guid("bdb18f62-4976-446a-af4b-13f093e7e200"), "//div[contains(@class, 'topic-body__title-image')]//img[contains(@class, 'picture__image')]/@src" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "published_at_culture_info", "published_at_time_zone_info_id", "published_at_x_path" },
                values: new object[,]
                {
                    { new Guid("000888c1-c7f7-4cf4-8638-73f62eb54872"), true, new Guid("5242e435-6eeb-458b-94f0-4fdbf0818702"), "ru-RU", "Russian Standard Time", "//div[@class='b-text__date']/text()" },
                    { new Guid("00a5a566-c149-48c9-bc23-ecb155b9192f"), true, new Guid("a6306e58-0edb-4b1b-b8f8-d1930e46d5d0"), "ru-RU", "UTC", "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark')]//span[@ca-ts]/text()" },
                    { new Guid("1771ffbd-6453-4278-a967-e5a9725bcbc4"), true, new Guid("cdb667f0-3518-4e71-a60d-bd82d5fa07d4"), "ru-RU", "Russian Standard Time", "//div[@class='b-article__top-author']/p[@class='date']/text()" },
                    { new Guid("1b2a54ed-17dc-416c-a6ff-2df126f7f9db"), true, new Guid("26bcd1cd-f0db-402a-8448-1050d09ec02b"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'full-article')]//time/text()" },
                    { new Guid("20adec64-602f-428a-a4a0-d1ba2a58c83b"), true, new Guid("8aa4c993-8f67-41c4-918d-013a61e7a35b"), "ru-RU", "Russian Standard Time", "//article[@itemprop='articleBody']/meta[@itemprop='datePublished']/@content" },
                    { new Guid("2231d574-f788-4fc9-b96d-ffead974094b"), true, new Guid("7eb1d86a-44ce-435d-a050-5e1a2d5002ce"), "ru-RU", "Russian Standard Time", "//div[@class='date_full']/text()" },
                    { new Guid("2efdf061-972f-4d4a-839c-1cc2e4b3c9ec"), true, new Guid("300dd4d5-b4e4-4404-914e-1190e7bc1457"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'PageArticleContent_date')]/text()" },
                    { new Guid("2fa78afe-4efb-4bb2-ab1f-d7fdd360583a"), true, new Guid("ab5cf625-0f36-4a5b-84dd-390632f6c615"), "ru-RU", null, "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("32fc85ba-8d96-4ec9-9e16-95951b22a3d9"), true, new Guid("f654e9b0-9f41-46d7-9070-dbbcc932dbb1"), "ru-RU", "Russian Standard Time", "//div[@class='article__info']//div[@class='article__info-date']/a/text()" },
                    { new Guid("3436025e-2561-4081-af75-96691ea1afae"), true, new Guid("2da9ac83-9968-45be-b2e6-37c5c73e5d45"), "ru-RU", "Ekaterinburg Standard Time", "//div[@itemprop='datePublished']/time/@datetime" },
                    { new Guid("4b537e6f-130d-40ef-9705-6ca9b33aa33d"), true, new Guid("eed3873d-da7e-49e4-8f21-db82ef61ac53"), "ru-RU", "Russian Standard Time", "//p[@class='b-material__date']/text()" },
                    { new Guid("515625ea-34f8-4c8f-b26d-e602d0d3606b"), true, new Guid("67443929-b833-4bb5-b650-e97beb8929a7"), "ru-RU", null, "//header[@class='news-item__header']//time/@content" },
                    { new Guid("54a215e7-4d0b-4ed9-91ba-9f8ba8db80e1"), true, new Guid("2c256dba-f80c-402b-b064-87a185d954be"), "ru-RU", null, "//article/header//time/@datetime" },
                    { new Guid("5a7c1038-d633-41b3-acde-b76f75d1921b"), true, new Guid("22388dda-8d23-40b9-a324-5a512d3c5e77"), "ru-RU", null, "//div[@class='article__header__info-block']/time[@class='article__header__date']/@datetime" },
                    { new Guid("60ffc607-9db0-4c10-b5e9-22b244dc79d4"), true, new Guid("34530e8d-de51-421a-a6d3-181e9fbf276b"), "en-US", null, "//time/@datetime" },
                    { new Guid("7509a840-31e0-411e-a6fa-608f28545de6"), true, new Guid("f2c805a6-d0e1-4b4c-ad51-7782c91fd5b9"), "ru-RU", "Russian Standard Time", "//article//header//time[@class='article-head__date']/text()" },
                    { new Guid("75248dde-5196-4b89-9ae8-ab5a54f50e91"), true, new Guid("657f6c1b-b7fa-4a1d-ad94-9d5a439526e5"), "ru-RU", "Russian Standard Time", "//article/div[@class='header']/span/text()" },
                    { new Guid("8096550f-3e72-4a3d-bc2f-8ecebadfe85b"), true, new Guid("bdb18f62-4976-446a-af4b-13f093e7e200"), "ru-RU", "Russian Standard Time", "//div[@class='topic-page__header']//a[contains(@class, 'topic-header__time')]/text()" },
                    { new Guid("86310d31-2932-4fb1-a52e-04f88e62ec7e"), true, new Guid("20ee359a-2579-489b-a970-71e8f4c15fdd"), "ru-RU", null, "//div[@class='article_page__left__top__left']//div[@class='article_page__left__top__time']//time/@datetime" },
                    { new Guid("8be676bc-0a86-45d4-8e0a-f94a33995051"), true, new Guid("ab5a812f-e2cc-46f7-833a-2c3c8202a2a5"), "ru-RU", "Russian Standard Time", "//div[@class='article__meta']/time/text()" },
                    { new Guid("91cacd0b-68f0-4ff9-a209-1793604a3705"), true, new Guid("40e72807-a539-458d-bf50-68fc96f1904d"), "ru-RU", "UTC", "//article//header//div[contains(@class, 'styles_meta')]//div[contains(@class, 'styles_metaItem')]/text()" },
                    { new Guid("9a8fa318-b6dd-4a22-b76b-d8e9fb845e20"), true, new Guid("52e0701b-95ac-4ff9-a8da-2db05e303ddf"), "ru-RU", null, "//div[@class='publication-info']/time[@itemprop='datePublished']/@datetime" },
                    { new Guid("ba656e9e-246d-4057-867e-ed1d4e3053ad"), false, new Guid("7718d879-36d6-4f21-a617-db317d94b5c9"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'pubdatetime')]/text()" },
                    { new Guid("bbf950aa-2214-4de2-b1c6-502a3b56f11a"), true, new Guid("0cbe1d16-9feb-4c9e-9e7a-52071c59f3ab"), "ru-RU", null, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']/span[@itemprop='datePublished']/@content" },
                    { new Guid("be488117-e31c-4b22-a90d-1cdf146ecdc4"), true, new Guid("ab664e06-ec91-4e04-8eb1-350fd21c8e93"), "en-US", "Central Europe Standard Time", "//article//div[@class='article-info']/div[@class='date']/text()" },
                    { new Guid("cac8fcbc-5342-43aa-ae1f-7747fefd12cc"), true, new Guid("ad982c68-2bc8-453e-8b32-bab6944a3f5f"), "ru-RU", null, "//article/div[@class='b_article-header']//time[@itemprop='datePublished']/@datetime" },
                    { new Guid("d73652f2-870e-4091-8fed-fc4631d30b26"), true, new Guid("48e91757-5d42-44cf-9970-240a64fb8f8a"), "en-US", "Eastern Standard Time", "//div[@class='headline__footer']//div[contains(@class, 'headline__byline-sub-text')]/div[@class='timestamp']/text()" },
                    { new Guid("d94eff3d-208f-4410-915d-ee767d880c71"), true, new Guid("9557b72f-078e-4611-a6e0-230a7e437697"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'article__date-autor-shortcode')]/div[contains(@class, 'article__date')]/time[@class='date']/@datetime" },
                    { new Guid("e9e0a46f-9c67-4946-ad82-01beaf2b569d"), true, new Guid("a6b0f1b0-20ff-4cff-842a-a6a92a413364"), "ru-RU", null, "//div[@class='doc_header__time']/time[@class='doc_header__publish_time']/@datetime" },
                    { new Guid("f3800065-00eb-442d-b5c7-bb3552255411"), true, new Guid("6a25edd6-63bf-45ce-bb0f-bfe6b139b476"), "ru-RU", "Russian Standard Time", "//div[@class='article_top']//div[@class='date']//time/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_sub_title_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("31f8f1af-6778-4982-9aae-549251dbedba"), true, new Guid("34530e8d-de51-421a-a6d3-181e9fbf276b"), "//header/p[@id='article-summary']/text()" },
                    { new Guid("39d2a269-d42a-41f1-a029-7708fac536dc"), false, new Guid("a6b0f1b0-20ff-4cff-842a-a6a92a413364"), "//header[@class='doc_header']/h2[contains(@class, 'doc_header__subheader')]/text()" },
                    { new Guid("3f5e19e6-0217-4b3c-8b38-94d9e557adf5"), true, new Guid("9557b72f-078e-4611-a6e0-230a7e437697"), "//div[contains(@class, 'article__summary')]/text()" },
                    { new Guid("471c6c2e-8bfe-444b-94b5-4ba536e5db36"), true, new Guid("26bcd1cd-f0db-402a-8448-1050d09ec02b"), "//h1/text()" },
                    { new Guid("52437c20-c911-4474-bf4e-c3ba3284dde7"), false, new Guid("300dd4d5-b4e4-4404-914e-1190e7bc1457"), "//div[contains(@class, 'PageArticleContent_lead')]/text()" },
                    { new Guid("579499be-8194-4d37-8ceb-78c84bd24e38"), false, new Guid("40e72807-a539-458d-bf50-68fc96f1904d"), "//article//header//p[contains(@class, 'styles_subtitle')]/text()" },
                    { new Guid("6957fa53-1482-4459-b3d2-03a29a67e2b9"), true, new Guid("ab5a812f-e2cc-46f7-833a-2c3c8202a2a5"), "//div[@class='article__intro']/p/text()" },
                    { new Guid("70bd9c65-f21b-4ca8-a0cb-a729e6e9a726"), false, new Guid("22388dda-8d23-40b9-a324-5a512d3c5e77"), "//div[contains(@class, 'article__text')]/div[@class='article__text__overview']/span/text()" },
                    { new Guid("761670ce-ac91-4f84-acb6-699b316199ea"), false, new Guid("657f6c1b-b7fa-4a1d-ad94-9d5a439526e5"), "//h4/text()" },
                    { new Guid("7986e4b5-821b-4d30-9cf1-bbd82f77e785"), false, new Guid("bdb18f62-4976-446a-af4b-13f093e7e200"), "//div[contains(@class, 'topic-body__title')]/text()" },
                    { new Guid("82233758-0e0c-458a-99c1-9255f4b9d960"), false, new Guid("a6306e58-0edb-4b1b-b8f8-d1930e46d5d0"), "//h3/text()" },
                    { new Guid("88e76e41-29ae-4f03-bd52-7668a7b59436"), true, new Guid("ad982c68-2bc8-453e-8b32-bab6944a3f5f"), "//h2/text()" },
                    { new Guid("92b2090d-1fa6-4a7a-9544-15bc24a6f38f"), true, new Guid("2da9ac83-9968-45be-b2e6-37c5c73e5d45"), "//p[@itemprop='alternativeHeadline']/span/text()" },
                    { new Guid("98f1818d-80ed-4e0e-a87d-569590d72bcb"), true, new Guid("f654e9b0-9f41-46d7-9070-dbbcc932dbb1"), "//h1[@class='article__second-title']/text()" },
                    { new Guid("9af17776-5e90-4356-82f9-a12b10dbffac"), true, new Guid("7718d879-36d6-4f21-a617-db317d94b5c9"), "//div[@class='container-fluid shifted']/p[@class='announce lead']/text()" },
                    { new Guid("c98c6c80-bdd1-47f4-a492-436b8c897979"), false, new Guid("cdb667f0-3518-4e71-a60d-bd82d5fa07d4"), "//h4/text()" },
                    { new Guid("d859790b-8579-4b0b-9adc-a06944f8a09f"), true, new Guid("0cbe1d16-9feb-4c9e-9e7a-52071c59f3ab"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()=1]/text()" },
                    { new Guid("d98b221b-fa36-4897-9ec9-68921da8f98a"), true, new Guid("ab664e06-ec91-4e04-8eb1-350fd21c8e93"), "//p[@class='headertext' and @itemprop='description']/text()" },
                    { new Guid("f7914f87-c4ec-4268-90da-0aed62026a1a"), true, new Guid("ab5cf625-0f36-4a5b-84dd-390632f6c615"), "//div[@itemprop='alternativeHeadline']/text()" },
                    { new Guid("fb774895-a033-4bf6-8b4b-ab7354502e2d"), true, new Guid("2c256dba-f80c-402b-b064-87a185d954be"), "//div[contains(@class, 'js-mediator-article')]/*[position()=1]/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_video_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("2e06bfa1-ad1d-4018-b04b-f778ff4c7e48"), false, new Guid("bdb18f62-4976-446a-af4b-13f093e7e200"), "//div[contains(@class='eagleplayer')]//video/@src" },
                    { new Guid("47cbf7f2-6e77-4485-a00b-1bf91ecd311b"), false, new Guid("f654e9b0-9f41-46d7-9070-dbbcc932dbb1"), "//div[@class='article__header']//div[@class='media__video']//video/@src" },
                    { new Guid("96bfd022-e06f-4bae-803a-6a304504cef3"), false, new Guid("ab664e06-ec91-4e04-8eb1-350fd21c8e93"), "//article//div[@class='videoWrapper' and @itemprop='video']/iframe[@class='video']/@src" },
                    { new Guid("ec3e62b4-b940-4e47-8766-a522bd88aec0"), false, new Guid("300dd4d5-b4e4-4404-914e-1190e7bc1457"), "//div[contains(@class, 'PageContentCommonStyling_text')]/rg-video//video/@src" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_modified_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_modified_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("5599171d-9ec1-4d5c-8ff9-3807a5d792ec"), "(\"обновлено:\" HH:mm dd.MM.yyyy)", new Guid("51b14447-ca1d-4c52-beb2-b609e20b456f") },
                    { new Guid("863995b0-c833-46ff-a464-8aa1878c5987"), "\"обновлено\" d MMMM, HH:mm", new Guid("f9f00a28-c179-496e-8f27-436d1d4f60a6") },
                    { new Guid("a6e72c9b-10cc-440f-bd21-c093cf081838"), "\"обновлено\" HH:mm , dd.MM", new Guid("cee486ab-db21-47da-96e7-67094cbd84dc") },
                    { new Guid("abc811b7-d9d2-4843-a782-857458663cd9"), "\"обновлено\" HH:mm , dd.MM.yyyy", new Guid("cee486ab-db21-47da-96e7-67094cbd84dc") },
                    { new Guid("c6cb317e-dec0-4027-83b0-2490b0a4c778"), "\"обновлено\" d MMMM yyyy, HH:mm", new Guid("f9f00a28-c179-496e-8f27-436d1d4f60a6") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_published_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("007e2b0d-0ff6-4a2b-adf5-6fab2aafebd7"), "d MMMM yyyy \"в\" HH:mm", new Guid("1771ffbd-6453-4278-a967-e5a9725bcbc4") },
                    { new Guid("008fd6cb-f5c2-46d9-8ac7-89765ae80f28"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("86310d31-2932-4fb1-a52e-04f88e62ec7e") },
                    { new Guid("014d6782-956a-4845-9bd9-65367bb932a4"), "HH:mm", new Guid("4b537e6f-130d-40ef-9705-6ca9b33aa33d") },
                    { new Guid("0d664a60-5c11-4101-8a53-3d88890fefc1"), "dd MMMM, HH:mm", new Guid("4b537e6f-130d-40ef-9705-6ca9b33aa33d") },
                    { new Guid("13fd15d2-470e-494c-a100-622520d2def8"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("cac8fcbc-5342-43aa-ae1f-7747fefd12cc") },
                    { new Guid("1ee43c7f-cfaf-4eb1-82fc-6ad9c6c131cc"), "d MMMM yyyy, HH:mm", new Guid("75248dde-5196-4b89-9ae8-ab5a54f50e91") },
                    { new Guid("2b05d5cc-8cbf-4dd4-bc12-58b0292b4773"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("e9e0a46f-9c67-4946-ad82-01beaf2b569d") },
                    { new Guid("3adb0918-0e04-4f8b-9c65-caf1ad0a5ae1"), "d MMMM, HH:mm,", new Guid("00a5a566-c149-48c9-bc23-ecb155b9192f") },
                    { new Guid("567c14fd-9d2d-4c07-ac75-d76f0f4b0b79"), "dd MMMM yyyy, HH:mm", new Guid("4b537e6f-130d-40ef-9705-6ca9b33aa33d") },
                    { new Guid("5d135f73-4140-4a04-ae7d-a39b0870d4ec"), "d MMMM yyyy, HH:mm", new Guid("91cacd0b-68f0-4ff9-a209-1793604a3705") },
                    { new Guid("6db2ba1d-08dd-46a4-8904-2318b58421a0"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("515625ea-34f8-4c8f-b26d-e602d0d3606b") },
                    { new Guid("7411f650-d901-40a6-bae8-0b75fa47ee3d"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("60ffc607-9db0-4c10-b5e9-22b244dc79d4") },
                    { new Guid("7980f52a-3ff7-48c3-aa78-7f14b1052e26"), "d MMMM yyyy, HH:mm \"МСК\"", new Guid("7509a840-31e0-411e-a6fa-608f28545de6") },
                    { new Guid("7df9e44a-7eb0-4b7f-a7ac-73dca4422999"), "yyyy-MM-ddTHH:mm:ss", new Guid("20adec64-602f-428a-a4a0-d1ba2a58c83b") },
                    { new Guid("7e222ec3-566a-441e-b79a-716b5e2fd2eb"), "dd MMMM yyyy, HH:mm", new Guid("2231d574-f788-4fc9-b96d-ffead974094b") },
                    { new Guid("809eb2be-8247-4740-88ab-9a5a2f367475"), "dd.MM.yyyy HH:mm", new Guid("2efdf061-972f-4d4a-839c-1cc2e4b3c9ec") },
                    { new Guid("80a9dea9-7742-40fb-b9b4-0a0621fba062"), "d MMMM yyyy, HH:mm", new Guid("00a5a566-c149-48c9-bc23-ecb155b9192f") },
                    { new Guid("81966b6e-078f-4c93-aa43-146c3b841e1e"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("9a8fa318-b6dd-4a22-b76b-d8e9fb845e20") },
                    { new Guid("937932e9-77c5-4c8e-a473-c4359ecf6063"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("2fa78afe-4efb-4bb2-ab1f-d7fdd360583a") },
                    { new Guid("a18b2aeb-ebeb-480b-8847-fcd11f64d4a5"), "dd.MM.yyyy HH:mm", new Guid("f3800065-00eb-442d-b5c7-bb3552255411") },
                    { new Guid("a4313fcc-14b8-4cec-a053-1f90707663e8"), "yyyy-MM-ddTHH:mm:ss.fffZ", new Guid("54a215e7-4d0b-4ed9-91ba-9f8ba8db80e1") },
                    { new Guid("af870d97-39aa-4e3b-be12-bf72df523e85"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("bbf950aa-2214-4de2-b1c6-502a3b56f11a") },
                    { new Guid("b55265c4-1f5f-4674-9071-30a4c90c55ef"), "d-M-yyyy HH:mm", new Guid("be488117-e31c-4b22-a90d-1cdf146ecdc4") },
                    { new Guid("b56fa9c1-dab4-4948-8f1b-63e907db2e4f"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("5a7c1038-d633-41b3-acde-b76f75d1921b") },
                    { new Guid("b69453ca-48d4-46d5-b13e-dd8bd6755cac"), "HH:mm", new Guid("8be676bc-0a86-45d4-8e0a-f94a33995051") },
                    { new Guid("b89b5e8a-cc30-4be0-aa31-5e8dadc8d0c0"), "HH:mm, d MMMM yyyy", new Guid("8096550f-3e72-4a3d-bc2f-8ecebadfe85b") },
                    { new Guid("c082d506-c493-4ec4-8823-8fbad47f7d68"), "yyyy-MM-dd HH:mm:ss", new Guid("ba656e9e-246d-4057-867e-ed1d4e3053ad") },
                    { new Guid("c0c9236b-cd23-4961-b8f9-570fdabd90f7"), "yyyy-MM-ddTHH:mm:ss", new Guid("3436025e-2561-4081-af75-96691ea1afae") },
                    { new Guid("c77b649e-639b-4873-8459-ab700b6a3193"), "dd MMMM yyyy HH:mm", new Guid("8be676bc-0a86-45d4-8e0a-f94a33995051") },
                    { new Guid("d29f6ffe-4307-453a-9dcb-ff7dd7fb9bd5"), "d MMMM yyyy, HH:mm,", new Guid("00a5a566-c149-48c9-bc23-ecb155b9192f") },
                    { new Guid("d4a8e413-5432-4f8b-ad3b-e9aeef9fc333"), "d MMMM, HH:mm", new Guid("00a5a566-c149-48c9-bc23-ecb155b9192f") },
                    { new Guid("d95afa8c-60cf-4092-b4b0-503b468d70c4"), "d MMMM yyyy HH:mm", new Guid("000888c1-c7f7-4cf4-8638-73f62eb54872") },
                    { new Guid("df6e7cc4-01ee-482b-995e-9fcc74d3bb67"), "dd.MM.yyyy HH:mm", new Guid("1b2a54ed-17dc-416c-a6ff-2df126f7f9db") },
                    { new Guid("e8e4366d-e2eb-4ac2-80fd-e45725ff248f"), "yyyy-MM-d HH:mm", new Guid("d94eff3d-208f-4410-915d-ee767d880c71") },
                    { new Guid("efdd2830-631a-4768-9260-676c2360f694"), "\"Published\n       \" HH:mm tt \"EST\", ddd MMMM d, yyyy", new Guid("d73652f2-870e-4091-8fed-fc4631d30b26") },
                    { new Guid("f89774ac-7ce1-4c15-84b3-0ec79aa4b554"), "d MMMM, HH:mm", new Guid("91cacd0b-68f0-4ff9-a209-1793604a3705") },
                    { new Guid("fbf168ff-3245-4227-932e-a7da8a4bd0b4"), "HH:mm dd.MM.yyyy", new Guid("32fc85ba-8d96-4ec9-9e16-95951b22a3d9") },
                    { new Guid("fdecf271-97d3-493c-8f9a-159ed7443b70"), "d MMMM  HH:mm", new Guid("000888c1-c7f7-4cf4-8638-73f62eb54872") }
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
