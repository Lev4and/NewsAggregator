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
                    { new Guid("015f14ed-89d5-4419-9bb8-07236babea26"), true, "https://www.m24.ru/", "Москва 24" },
                    { new Guid("04598dc4-1fd5-4c46-97df-6d002744472a"), true, "https://rg.ru/", "Российская газета" },
                    { new Guid("04a47d2b-413c-489f-b28b-a00b0d658e81"), true, "https://www.1obl.ru/", "Первый областной" },
                    { new Guid("0e2f1688-ef45-4665-b60f-a55e9f936110"), true, "https://tsargrad.tv/", "Царьград" },
                    { new Guid("11f18674-2670-4b0d-a711-5233348db847"), true, "https://www.gazeta.ru/", "Газета.Ru" },
                    { new Guid("14c8aa4a-a15f-446e-a54f-e11b75470805"), true, "https://edition.cnn.com/", "CNN" },
                    { new Guid("1d117d80-6da8-4ff4-8cef-a5e0782a7f9d"), true, "https://www.rbc.ru/", "РБК" },
                    { new Guid("207ff6e9-462f-41b6-8ee3-d669a5fc4626"), true, "https://www.belta.by/", "БелТА" },
                    { new Guid("2ffe0806-12cc-484f-8bda-3bb68c0f6296"), true, "https://ura.news/", "Ura.ru" },
                    { new Guid("30b87320-a9e5-4629-863d-6a6058f4376d"), true, "https://www.cybersport.ru/", "Cybersport.ru" },
                    { new Guid("3a58362d-021a-42b0-a21a-08b8112e1268"), true, "https://aif.ru/", "Аргументы и факты" },
                    { new Guid("450215ec-7b94-43bb-a29e-c4a2119de619"), true, "https://russian.rt.com/", "RT на русском" },
                    { new Guid("47225f47-920d-4f3e-894f-9af040f0df18"), true, "https://www.hltv.org/", "HLTV.org" },
                    { new Guid("4c63a583-f031-469e-867c-addbac5ea5d9"), true, "https://life.ru/", "Life" },
                    { new Guid("53d6d909-9745-4dfe-81d2-2f52d4ae5435"), true, "https://74.ru/", "74.ru" },
                    { new Guid("615246dc-075d-47ab-a20a-de9752c9c89d"), true, "https://www.sports.ru/", "Storts.ru" },
                    { new Guid("6941a070-2bc9-4fa8-ac0f-7f09a8364995"), true, "https://www.kommersant.ru/", "Коммерсантъ" },
                    { new Guid("7a54db8d-0f5f-42c4-8e4d-2e659bc56edd"), true, "https://tass.ru/", "ТАСС" },
                    { new Guid("8cfdd2b7-96b6-46ec-8a0c-5fa2d0ca41b5"), true, "https://ixbt.games/", "iXBT.games" },
                    { new Guid("903b7201-e2fa-4d7f-8f6f-5c1927a64d65"), true, "https://www.ixbt.com/", "iXBT.com" },
                    { new Guid("9adbe408-3ee4-481d-a636-0abd97efb01a"), true, "https://www.pravda.ru/", "Правда.ру" },
                    { new Guid("a21fc63f-0900-4859-887d-5d2141560379"), true, "https://www.nytimes.com/", "The New York Times" },
                    { new Guid("b39d411f-c5e4-44fd-9bb3-6abd6056bb7a"), true, "https://vz.ru/", "ВЗГЛЯД.РУ" },
                    { new Guid("b6d21eea-5972-444a-88d5-e32dead54c23"), true, "https://3dnews.ru/", "3Dnews.ru" },
                    { new Guid("b947d4d5-83d0-4a46-ae6c-463d47faaa24"), true, "https://www.interfax.ru/", "Интерфакс" },
                    { new Guid("bc88aa39-8679-4352-a585-2dbf12034f36"), true, "https://svpressa.ru/", "СвободнаяПресса" },
                    { new Guid("d57bc663-559d-4db0-850e-382d7e6c0c10"), true, "https://www.championat.com/", "Чемпионат.com" },
                    { new Guid("e0abe23f-4762-473f-92a4-37da060466ec"), true, "https://ria.ru/", "РИА Новости" },
                    { new Guid("f922e439-58c0-4c9e-813b-9d59b2e3fd69"), true, "https://iz.ru/", "Известия" },
                    { new Guid("fb2e0531-15a1-47b4-9dc2-f8d509211899"), true, "https://lenta.ru/", "Лента.Ру" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_settings",
                columns: new[] { "id", "description_x_path", "source_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("12176b4b-da6d-497b-a336-2d82abf0353e"), "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]", new Guid("b947d4d5-83d0-4a46-ae6c-463d47faaa24"), "//h1/text()" },
                    { new Guid("12c2cecd-1943-499c-b457-249383dbed9c"), "//div[@itemprop='articleBody']/*", new Guid("04a47d2b-413c-489f-b28b-a00b0d658e81"), "//h1[@itemprop='headline']/text()" },
                    { new Guid("2437ef1a-cbe3-4b80-9d03-9d1c856d5ed0"), "//div[@itemprop='articleBody']/*", new Guid("11f18674-2670-4b0d-a711-5233348db847"), "//h1/text()" },
                    { new Guid("28828d64-4283-4bce-9ee4-85a3a854323f"), "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]", new Guid("4c63a583-f031-469e-867c-addbac5ea5d9"), "//h1/text()" },
                    { new Guid("35a24ff2-fa01-499f-8323-9c79bc797d31"), "//div[@itemprop='articleBody']/*[not(name() = 'figure')]", new Guid("53d6d909-9745-4dfe-81d2-2f52d4ae5435"), "//h1[@itemprop='headline']/span/text()" },
                    { new Guid("39f368f2-881c-40a6-8f22-8987bb28f1f6"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]", new Guid("0e2f1688-ef45-4665-b60f-a55e9f936110"), "//h1[@class='article__title']/text()" },
                    { new Guid("3ac34c13-6431-4002-ac19-49587497f2e9"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]", new Guid("6941a070-2bc9-4fa8-ac0f-7f09a8364995"), "//h1/text()" },
                    { new Guid("4ba0a0f2-55ec-473b-a5ba-8a074191953c"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()>1]", new Guid("b6d21eea-5972-444a-88d5-e32dead54c23"), "//h1/text()" },
                    { new Guid("5c8b9127-76cf-42b9-840a-37208c5ae0b8"), "//div[contains(@class, 'article__body')]", new Guid("e0abe23f-4762-473f-92a4-37da060466ec"), "//div[@class='article__title']/text()" },
                    { new Guid("64b22c28-8507-4f9c-9fbd-a3705d71f942"), "//section[@name='articleBody']/*", new Guid("a21fc63f-0900-4859-887d-5d2141560379"), "//h1/text()" },
                    { new Guid("7013650a-9d08-4906-ab97-baa2aac17af4"), "//article/div[@class='article-content']/*[not(@class)]", new Guid("d57bc663-559d-4db0-850e-382d7e6c0c10"), "//article/header/div[@class='article-head__title']/text()" },
                    { new Guid("7d674500-835d-4344-9d2b-a36c447f71a8"), "//div[contains(@class, 'article__text ')]", new Guid("450215ec-7b94-43bb-a29e-c4a2119de619"), "//h1/text()" },
                    { new Guid("7ebbac2d-5cd7-4464-bf67-0b476d348ffe"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview'))]", new Guid("1d117d80-6da8-4ff4-8cef-a5e0782a7f9d"), "//h1/text()" },
                    { new Guid("81f44eba-b916-4ff4-ae69-048c9394b8a9"), "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]", new Guid("015f14ed-89d5-4419-9bb8-07236babea26"), "//h1/text()" },
                    { new Guid("83225235-0e2f-4f68-9ca0-1d00760f97cd"), "//div[contains(@class, 'PageContentCommonStyling_text')]", new Guid("04598dc4-1fd5-4c46-97df-6d002744472a"), "//h1/text()" },
                    { new Guid("8acfe480-e5a7-411f-aaee-ec5d17815ac5"), "//div[@itemprop='articleBody']/*", new Guid("14c8aa4a-a15f-446e-a54f-e11b75470805"), "//h1/text()" },
                    { new Guid("a075eef1-9c39-4de0-b59f-0f43dfad5afe"), "//div[@class='article_text']", new Guid("3a58362d-021a-42b0-a21a-08b8112e1268"), "//h1/text()" },
                    { new Guid("aa3b00e6-d2f2-498a-a2ef-b5e607f180c3"), "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]", new Guid("9adbe408-3ee4-481d-a636-0abd97efb01a"), "//h1/text()" },
                    { new Guid("ac7d5e90-329c-4060-90c9-2bfbe94ef6ca"), "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]", new Guid("bc88aa39-8679-4352-a585-2dbf12034f36"), "//h1[@class='b-text__title']/text()" },
                    { new Guid("b2866d0e-18d7-4892-8d60-574c24329294"), "//div[contains(@class, 'container-fluid shifted') and not(p[@class='announce lead']) and not(h1) and not(hr)]", new Guid("8cfdd2b7-96b6-46ec-8a0c-5fa2d0ca41b5"), "//h1/text()" },
                    { new Guid("b56cc4ac-0416-4f95-9395-8ea087908d2d"), "//div[contains(@class, 'news-item__content')]", new Guid("615246dc-075d-47ab-a20a-de9752c9c89d"), "//h1/text()" },
                    { new Guid("b9752dc1-ae7f-4b93-ae54-69d5e9ac7369"), "//div[@itemprop='articleBody']/*[not(name()='div')]", new Guid("2ffe0806-12cc-484f-8bda-3bb68c0f6296"), "//h1/text()" },
                    { new Guid("bab7cc8f-22f1-4827-a907-0d4fea6d85f9"), "//div[@class='js-mediator-article']", new Guid("207ff6e9-462f-41b6-8ee3-d669a5fc4626"), "//h1/text()" },
                    { new Guid("c4883f4c-672c-4947-88db-4bebc8b28b21"), "//div[@itemprop='articleBody']/*", new Guid("903b7201-e2fa-4d7f-8f6f-5c1927a64d65"), "//h1/text()" },
                    { new Guid("c6a7b7c8-5612-43f4-9ad2-314b3678844b"), "//div[@class='topic-body__content']", new Guid("fb2e0531-15a1-47b4-9dc2-f8d509211899"), "//h1[@class='topic-body__titles']/span[@class='topic-body__title']/text()" },
                    { new Guid("dab966dc-f416-4f44-ad15-cba6b82845b0"), "//div[@itemprop='articleBody']/*", new Guid("f922e439-58c0-4c9e-813b-9d59b2e3fd69"), "//h1/span/text()" },
                    { new Guid("db565ffd-6dbb-4f69-a06f-3a6ae4c07c76"), "//div[contains(@class, 'js-mediator-article')]/*[position()>1]", new Guid("30b87320-a9e5-4629-863d-6a6058f4376d"), "//h1/text()" },
                    { new Guid("eef6cc12-742c-43a7-8493-966f8f1decc5"), "//article/*", new Guid("7a54db8d-0f5f-42c4-8e4d-2e659bc56edd"), "//h1/text()" },
                    { new Guid("efe75535-e961-4e17-99db-c5a7c8fe8e7b"), "//article/div[@class='news_text']", new Guid("b39d411f-c5e4-44fd-9bb3-6abd6056bb7a"), "//h1/text()" },
                    { new Guid("fc0a9476-bb36-4e0b-a751-8f746aa0a9ff"), "//article//div[@class='newstext-con']/*[position()>2]", new Guid("47225f47-920d-4f3e-894f-9af040f0df18"), "//h1[@class='headline']/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_search_settings",
                columns: new[] { "id", "news_site_url", "news_url_x_path", "source_id" },
                values: new object[,]
                {
                    { new Guid("002a1947-400b-420d-8b9a-fb79f124a8fb"), "https://74.ru/", "//a[starts-with(@href, '/text/') and not(contains(@href, '?')) and not(contains(@href, 'comments/')) and not(@href='/text/')]/@href", new Guid("53d6d909-9745-4dfe-81d2-2f52d4ae5435") },
                    { new Guid("036a3c13-847c-4de4-a2e8-16da442d0170"), "https://www.m24.ru/", "//a[contains(@href, '/news/')]/@href", new Guid("015f14ed-89d5-4419-9bb8-07236babea26") },
                    { new Guid("0a7b47a6-80d7-4147-a0d5-a2bc969b66c4"), "https://rg.ru/", "//a[contains(@href, '.html')]/@href", new Guid("04598dc4-1fd5-4c46-97df-6d002744472a") },
                    { new Guid("0bdecabd-599f-41f1-902c-118075b3b1e6"), "https://www.kommersant.ru/", "//a[contains(@href, '/doc/') and contains(@href, '?from=')]/@href", new Guid("6941a070-2bc9-4fa8-ac0f-7f09a8364995") },
                    { new Guid("0cb2b1b1-a98a-447d-9d6c-82f48c4bde2c"), "https://www.1obl.ru/news/", "//a[starts-with(@href, '/news/') and not(contains(@href, '?'))]/@href", new Guid("04a47d2b-413c-489f-b28b-a00b0d658e81") },
                    { new Guid("1cc9c339-08c9-4a3e-a684-082c8a4a79a1"), "https://ixbt.games/news/", "//a[@class='card-link']/@href", new Guid("8cfdd2b7-96b6-46ec-8a0c-5fa2d0ca41b5") },
                    { new Guid("24f712e4-9661-4566-abf4-5d9c76c8cf06"), "https://www.sports.ru/news/", "//a[contains(@href, '.html') and not(contains(@href, '.html#comments')) and not (contains(@href, '/blogs/'))]/@href", new Guid("615246dc-075d-47ab-a20a-de9752c9c89d") },
                    { new Guid("25a4a713-2934-409e-9479-c353760a8570"), "https://www.ixbt.com/news/", "//a[starts-with(@href, '/news/') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("903b7201-e2fa-4d7f-8f6f-5c1927a64d65") },
                    { new Guid("267ed48e-c011-4b4b-96fe-730118d5b7ea"), "https://tass.ru/", "//a[contains(@class, 'tass_pkg_link-v5WdK') and contains(substring(@href, 2), '/') and not(contains(@href, '/spec/')) and not(contains(@href, 'spec.tass.ru'))]/@href", new Guid("7a54db8d-0f5f-42c4-8e4d-2e659bc56edd") },
                    { new Guid("30522e4a-c7e5-443d-a3a7-baa5295d41a0"), "https://vz.ru/", "//a[contains(@href, '.html') and not(contains(@href, '#comments')) and not(contains(@href, '?')) and not(contains(@href, '/about/'))]/@href", new Guid("b39d411f-c5e4-44fd-9bb3-6abd6056bb7a") },
                    { new Guid("3a23df11-dcd3-424b-a879-063678bd68d6"), "https://www.interfax.ru/", "//div[@class='timeline']//a[@tabindex=5]/@href", new Guid("b947d4d5-83d0-4a46-ae6c-463d47faaa24") },
                    { new Guid("3eaece90-b00b-40cc-9745-ec61bc56e5ca"), "https://www.pravda.ru/", "//a[contains(@href, '/news/') and not(@href='https://www.pravda.ru/news/')]/@href", new Guid("9adbe408-3ee4-481d-a636-0abd97efb01a") },
                    { new Guid("4ccc8d41-8d45-4039-8729-04bf8667ca2d"), "https://russian.rt.com/", "//a[contains(@class, 'link') and contains(@href, 'news/')]/@href", new Guid("450215ec-7b94-43bb-a29e-c4a2119de619") },
                    { new Guid("610a0e8e-f888-46d8-8475-723155246ccc"), "https://www.gazeta.ru/news/", "//a[contains(@href, '/news/') and contains(@href, '.shtml') and not(contains(@href, '?'))]/@href", new Guid("11f18674-2670-4b0d-a711-5233348db847") },
                    { new Guid("68c3d34f-53ac-4810-96e6-1454389ed3c1"), "https://ria.ru/", "//a[contains(@class, 'cell-list__item-link')]/@href", new Guid("e0abe23f-4762-473f-92a4-37da060466ec") },
                    { new Guid("6f5b3b87-d0fd-4031-ac9e-913223806b35"), "https://edition.cnn.com/", "//a[contains(@href, '.html')]/@href", new Guid("14c8aa4a-a15f-446e-a54f-e11b75470805") },
                    { new Guid("717d6d3b-1f63-4548-ad04-62ec7db20f45"), "https://life.ru/s/novosti", "//a[contains(@href, '/p/')]/@href", new Guid("4c63a583-f031-469e-867c-addbac5ea5d9") },
                    { new Guid("79cd016c-d6e8-4a93-b1db-9ac42d106b25"), "https://3dnews.ru/news/", "//div[@class='news-feed-all']//a[@class='entry-header']/h1/../@href", new Guid("b6d21eea-5972-444a-88d5-e32dead54c23") },
                    { new Guid("9c29b1aa-82be-4819-9b10-258d21d9f0a1"), "https://www.championat.com/news/1.html?utm_source=button&utm_medium=news", "//a[contains(@href, 'news-') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("d57bc663-559d-4db0-850e-382d7e6c0c10") },
                    { new Guid("9dda1c6a-2095-4f29-9b56-a27c59369a41"), "https://svpressa.ru/all/news/", "//a[contains(@href, '/news/') and not(contains(@href, '?')) and not(starts-with(@href, '/all/news/'))]/@href", new Guid("bc88aa39-8679-4352-a585-2dbf12034f36") },
                    { new Guid("9ecd68a7-816d-4690-907b-29ea2f3fca64"), "https://lenta.ru/", "//a[starts-with(@href, '/news/')]/@href", new Guid("fb2e0531-15a1-47b4-9dc2-f8d509211899") },
                    { new Guid("a44e2f1f-e964-4ff6-a997-6773e0a14b4f"), "https://www.belta.by/", "//a[contains(@href, 'https://www.belta.by/') and contains(@href, '/view/')]/@href", new Guid("207ff6e9-462f-41b6-8ee3-d669a5fc4626") },
                    { new Guid("a6ba75ef-b064-43a6-9180-3694253a57e4"), "https://tsargrad.tv/", "//a[contains(@class, 'news-item__link')]/@href", new Guid("0e2f1688-ef45-4665-b60f-a55e9f936110") },
                    { new Guid("abe562b0-9b20-47c7-97cd-ba6acb0f4b3a"), "https://iz.ru/news/", "//a[contains(@href, '?main_click')]/@href", new Guid("f922e439-58c0-4c9e-813b-9d59b2e3fd69") },
                    { new Guid("abfe011e-38df-431a-8dea-f1f62e719728"), "https://www.cybersport.ru/", "//a[contains(@href, '/tags/')]/@href", new Guid("30b87320-a9e5-4629-863d-6a6058f4376d") },
                    { new Guid("bb2e6d01-0ad6-4e6f-afb9-4e56df937c01"), "https://aif.ru/", "//span[contains(@class, 'item_text__title')]/../@href", new Guid("3a58362d-021a-42b0-a21a-08b8112e1268") },
                    { new Guid("cc522656-84d0-4bf5-8388-9fbe540a6c45"), "https://ura.news/", "//a[contains(@href, '/news/')]/@href", new Guid("2ffe0806-12cc-484f-8bda-3bb68c0f6296") },
                    { new Guid("e061c8f2-d519-4f8e-88f4-60f1b2cf8e46"), "https://www.nytimes.com/", "//a[contains(@href, '.html')]/@href", new Guid("a21fc63f-0900-4859-887d-5d2141560379") },
                    { new Guid("f27184fe-6284-479d-910e-10d684af6bfd"), "https://www.hltv.org/", "//a[contains(@href, '/news/')]/@href", new Guid("47225f47-920d-4f3e-894f-9af040f0df18") },
                    { new Guid("f2b5676d-ed0c-449e-8908-2801e40f352e"), "https://www.rbc.ru/", "//a[contains(@href, 'https://www.rbc.ru/') and contains(@href, '?from=')]/@href", new Guid("1d117d80-6da8-4ff4-8cef-a5e0782a7f9d") }
                });

            migrationBuilder.InsertData(
                table: "news_source_logos",
                columns: new[] { "id", "source_id", "url" },
                values: new object[,]
                {
                    { new Guid("01e8f4a9-f56d-47be-8571-dad68303bb58"), new Guid("0e2f1688-ef45-4665-b60f-a55e9f936110"), "https://ural.tsargrad.tv/favicons/apple-touch-icon-120x120.png?s2" },
                    { new Guid("04441bb9-481a-4fe4-bd5f-778f99df6268"), new Guid("207ff6e9-462f-41b6-8ee3-d669a5fc4626"), "https://www.belta.by/images/storage/banners/000016_a133e848cb2e7b1debb7102d19e4d139_work.svg" },
                    { new Guid("054bfb31-fb51-4206-bd0d-d64c772c2c51"), new Guid("015f14ed-89d5-4419-9bb8-07236babea26"), "https://www.m24.ru/img/fav/apple-touch-icon.png" },
                    { new Guid("0de52dd2-3c50-4859-8764-6e5b1c0ea814"), new Guid("7a54db8d-0f5f-42c4-8e4d-2e659bc56edd"), "https://tass.ru/favicon/180.svg" },
                    { new Guid("0f0c9470-1883-4901-a326-14a69299dc9a"), new Guid("47225f47-920d-4f3e-894f-9af040f0df18"), "https://www.hltv.org/img/static/favicon/apple-touch-icon.png" },
                    { new Guid("10bd391a-8dd1-492f-87fe-1bad1b9d0a92"), new Guid("9adbe408-3ee4-481d-a636-0abd97efb01a"), "https://www.pravda.ru/pix/apple-touch-icon.png" },
                    { new Guid("1177dd01-7d11-43a4-8f67-4ed40383cba6"), new Guid("04598dc4-1fd5-4c46-97df-6d002744472a"), "https://cdnstatic.rg.ru/images/touch-icon-iphone-retina.png" },
                    { new Guid("122a9171-5c7b-48c2-90f2-b0e3637a504d"), new Guid("30b87320-a9e5-4629-863d-6a6058f4376d"), "https://www.cybersport.ru/favicon-192x192.png" },
                    { new Guid("1b2592e4-7f6d-478c-abb2-83b0c537d535"), new Guid("1d117d80-6da8-4ff4-8cef-a5e0782a7f9d"), "https://s.rbk.ru/v10_rbcnews_static/common/common-10.10.116/images/apple-touch-icon-120x120.png" },
                    { new Guid("37dfefa6-c2be-4995-90aa-c494ac470b31"), new Guid("8cfdd2b7-96b6-46ec-8a0c-5fa2d0ca41b5"), "https://ixbt.games/images/favicon/gt/apple-touch-icon.png" },
                    { new Guid("3bbe294c-8a25-44f1-b5cd-cb0b399753c7"), new Guid("53d6d909-9745-4dfe-81d2-2f52d4ae5435"), "https://static.ngs.ru/jtnews/dist/static/favicons/apple/apple-favicon-74-120.png" },
                    { new Guid("43f6bc59-a393-4358-aba9-0a2b461b60e2"), new Guid("f922e439-58c0-4c9e-813b-9d59b2e3fd69"), "https://cdn.iz.ru/profiles/portal/themes/purple/images/favicons/apple-icon-120x120.png" },
                    { new Guid("455133a3-09fc-4002-ad4a-953e67b0f360"), new Guid("4c63a583-f031-469e-867c-addbac5ea5d9"), "https://life.ru/appletouch/apple-icon-120х120.png" },
                    { new Guid("63b62336-3deb-4c38-bd30-170e493043f7"), new Guid("fb2e0531-15a1-47b4-9dc2-f8d509211899"), "https://icdn.lenta.ru/images/icons/icon-256x256.png" },
                    { new Guid("6a1a4a46-ec22-41a5-98d2-4402b136f71c"), new Guid("a21fc63f-0900-4859-887d-5d2141560379"), "https://www.nytimes.com/vi-assets/static-assets/apple-touch-icon-28865b72953380a40aa43318108876cb.png" },
                    { new Guid("758ced3f-741c-4b7e-b5fa-1bf937b4ec18"), new Guid("903b7201-e2fa-4d7f-8f6f-5c1927a64d65"), "https://www.ixbt.com/favicon.ico" },
                    { new Guid("7b2d4174-973d-42da-9860-eb54fca62d53"), new Guid("3a58362d-021a-42b0-a21a-08b8112e1268"), "https://chel.aif.ru/img/icon/apple-touch-icon.png?37f" },
                    { new Guid("7f53389b-8777-4abb-ba13-a178d7df49a6"), new Guid("6941a070-2bc9-4fa8-ac0f-7f09a8364995"), "https://im.kommersant.ru/ContentFlex/images/favicons2020/apple-touch-icon-120.png" },
                    { new Guid("8314e49e-a0de-4b47-8b6d-613a806bb3e2"), new Guid("450215ec-7b94-43bb-a29e-c4a2119de619"), "https://russian.rt.com/static/img/listing-uwc-logo.png" },
                    { new Guid("85fb5689-577a-4b21-a290-0e8f960883b2"), new Guid("e0abe23f-4762-473f-92a4-37da060466ec"), "https://cdnn21.img.ria.ru/i/favicons/favicon.svg" },
                    { new Guid("89776dff-b42d-4521-8e5e-3cc1d9f7c770"), new Guid("d57bc663-559d-4db0-850e-382d7e6c0c10"), "https://st.championat.com/i/favicon/apple-touch-icon.png" },
                    { new Guid("8a0ef8a5-4a22-40c8-8a63-4c0f79d54372"), new Guid("11f18674-2670-4b0d-a711-5233348db847"), "https://static.gazeta.ru/nm2021/img/icons/favicon.svg" },
                    { new Guid("8f76989a-238a-495e-933f-9f963aaa8818"), new Guid("04a47d2b-413c-489f-b28b-a00b0d658e81"), "https://www.1obl.ru/apple-touch-icon.png" },
                    { new Guid("9d2c6477-b965-49e9-bdfe-0d9d9c45369f"), new Guid("2ffe0806-12cc-484f-8bda-3bb68c0f6296"), "https://ura.news/apple-touch-icon.png" },
                    { new Guid("a198931d-08f3-4c6e-a616-9cd034e83816"), new Guid("14c8aa4a-a15f-446e-a54f-e11b75470805"), "https://edition.cnn.com/media/sites/cnn/apple-touch-icon.png" },
                    { new Guid("b5a41719-60e9-42c1-8c88-c267b41aff80"), new Guid("bc88aa39-8679-4352-a585-2dbf12034f36"), "https://svpressa.ru/favicon-96x96.png?v=1471426270000" },
                    { new Guid("c0ec500b-9117-4de3-a216-d6972c362068"), new Guid("b947d4d5-83d0-4a46-ae6c-463d47faaa24"), "https://www.interfax.ru/touch-icon-iphone-retina.png" },
                    { new Guid("c7cfa61a-9620-4204-aebe-8b62cdcbe9a7"), new Guid("615246dc-075d-47ab-a20a-de9752c9c89d"), "https://www.sports.ru/apple-touch-icon-120.png" },
                    { new Guid("eb95d6b5-ae04-415c-8282-78329998fab0"), new Guid("b39d411f-c5e4-44fd-9bb3-6abd6056bb7a"), "https://vz.ru/apple-touch-icon.png" },
                    { new Guid("fac35b1b-df13-48f3-9851-723dc18d2f00"), new Guid("b6d21eea-5972-444a-88d5-e32dead54c23"), "https://3dnews.ru/assets/images/3dnews_logo_soc.png" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_editor_settings",
                columns: new[] { "id", "is_required", "name_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("1e7c619d-b05c-4461-996f-f9cd88dbafe0"), true, "//div[contains(@class, 'full-article')]/div[@class='authors-block']//span[text()='Автор']/../a/text()", new Guid("aa3b00e6-d2f2-498a-a2ef-b5e607f180c3") },
                    { new Guid("2c92239f-1148-4a7c-bcf7-d03785feee14"), true, "//div[@class='container-fluid publication-footer']//a[contains(@class, 'text-secondary')]/@title", new Guid("b2866d0e-18d7-4892-8d60-574c24329294") },
                    { new Guid("2d5ac920-7cf2-4bc5-8989-d22e0c75a29a"), true, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']//a[@itemprop='author']//span[@itemprop='name']/text()", new Guid("4ba0a0f2-55ec-473b-a5ba-8a074191953c") },
                    { new Guid("3d8de4f3-e927-47ab-8471-97b2e09db90e"), true, "//*[@itemprop='author']/*[@itemprop='name']//text()", new Guid("12c2cecd-1943-499c-b457-249383dbed9c") },
                    { new Guid("53bc8789-b1fa-4419-ac99-fbe165f48494"), false, "//div[@class='author']/span[@itemprop='author']/span[@itemprop='name']/a/text()", new Guid("2437ef1a-cbe3-4b80-9d03-9d1c856d5ed0") },
                    { new Guid("5d36b6d3-6f7e-41e6-9e3d-367088efc7ce"), true, "//div[@class='headline__footer']//div[@class='byline__names']/span[@class='byline__name']/text()", new Guid("8acfe480-e5a7-411f-aaee-ec5d17815ac5") },
                    { new Guid("7499b817-0114-4407-ae9c-29e9fe40ce14"), true, "//article//header//div[@class='article-head__author-name']/a[@rel='author']/span/text()", new Guid("7013650a-9d08-4906-ab97-baa2aac17af4") },
                    { new Guid("75367a7d-c2bd-44af-8efe-1cab5ffc8c57"), true, "//a[@class='article__author']/text()", new Guid("39f368f2-881c-40a6-8f22-8987bb28f1f6") },
                    { new Guid("7db6c288-ce6e-4215-b188-84f29253e6bd"), true, "//div[@itemprop='author']/span[@itemprop='name']/text()", new Guid("b9752dc1-ae7f-4b93-ae54-69d5e9ac7369") },
                    { new Guid("8258c326-9deb-44b7-bd45-343051154054"), true, "//div[contains(@class, 'styles_bodyWrapper')]//div[contains(@class, 'styles_authorsLinks')]/a/text()", new Guid("28828d64-4283-4bce-9ee4-85a3a854323f") },
                    { new Guid("8f1a8d7a-6cd4-4b9b-80b7-ae4d24e401e9"), false, "//div[@itemprop='author']//p[@itemprop='name']/text()", new Guid("35a24ff2-fa01-499f-8323-9c79bc797d31") },
                    { new Guid("9e74edaa-5d29-4df3-b567-db713a6b13d3"), true, "//div[@class='article_top']//div[@class='authors']//div[@class='autor']//span/text()", new Guid("a075eef1-9c39-4de0-b59f-0f43dfad5afe") },
                    { new Guid("aa087853-8dfb-46db-bc08-d730b54f1f19"), true, "//div[contains(@class, 'PageArticleContent_authors')]//a[contains(@class, 'LinksOfAuthor_item')]/text()", new Guid("83225235-0e2f-4f68-9ca0-1d00760f97cd") },
                    { new Guid("b635e234-178b-4237-8c20-52497053e657"), false, "//div[@class='article__authors']//*[@class='article__authors__author']/span[@class='article__authors__author__name']/text()", new Guid("7ebbac2d-5cd7-4464-bf67-0b476d348ffe") },
                    { new Guid("bb32c992-3739-43f8-baaa-7bce25cbde2c"), true, "//article//span[@class='author']/a[@class='authorName']/span/text()", new Guid("fc0a9476-bb36-4e0b-a751-8f746aa0a9ff") },
                    { new Guid("bdf9b210-4b4a-4482-9e40-72557829e545"), true, "//span[@itemprop='author']/span[@itemprop='name']/@content", new Guid("c4883f4c-672c-4947-88db-4bebc8b28b21") },
                    { new Guid("c9aac6c1-fef9-4fef-977d-3c4e6699bc08"), true, "//footer[@class='news-item__footer']/div[@class='news-item__footer-after-news']/p[position()=1]//span/text()", new Guid("b56cc4ac-0416-4f95-9395-8ea087908d2d") },
                    { new Guid("ca3b6928-8df8-4956-9d1e-2e5b12ad6228"), true, "//span[@itemprop='name']/a/text()", new Guid("64b22c28-8507-4f9c-9fbd-a3705d71f942") },
                    { new Guid("e3dc9194-26db-42bf-919f-cf20af2c7aa6"), false, "//div[@class='topic-authors']/a[@class='topic-authors__author']/text()", new Guid("c6a7b7c8-5612-43f4-9ad2-314b3678844b") },
                    { new Guid("e882105b-998b-4c7a-b530-6c2d6c7940e9"), false, "//p[@class='doc__text document_authors']/text()", new Guid("3ac34c13-6431-4002-ac19-49587497f2e9") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_modified_at_settings",
                columns: new[] { "id", "is_required", "modified_at_culture_info", "modified_at_time_zone_info_id", "modified_at_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("abf75d2b-1713-4194-b155-1169201184ec"), true, "ru-RU", "Russian Standard Time", "//div[@class='article__info']//div[@class='article__info-date']/span[@class='article__info-date-modified']/text()", new Guid("5c8b9127-76cf-42b9-840a-37208c5ae0b8") },
                    { new Guid("ba69f4c3-ea25-4d70-a621-2cfe6a8e8b60"), false, "ru-RU", "Russian Standard Time", "//div[@class='doc_header__time']/span[contains(@class, 'publish_update')]/text()", new Guid("3ac34c13-6431-4002-ac19-49587497f2e9") },
                    { new Guid("e6552281-f68d-4c70-bbd8-b2d9cc96693f"), false, "ru-RU", "UTC", "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark_update')]//span[@ca-ts]/text()", new Guid("eef6cc12-742c-43a7-8493-966f8f1decc5") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_picture_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("1139bbfd-4a12-4370-bf78-1289b97d7b59"), false, new Guid("c6a7b7c8-5612-43f4-9ad2-314b3678844b"), "//div[contains(@class, 'topic-body__title-image')]//img[contains(@class, 'picture__image')]/@src" },
                    { new Guid("1d226ba8-ffe7-4eba-92ee-a00aa3f1e8f0"), true, new Guid("dab966dc-f416-4f44-ad15-cba6b82845b0"), "//div[contains(@class, 'big_photo')]//div[@class='big_photo__img']//img/@src" },
                    { new Guid("35c81469-53f3-40f8-a3a0-ba4880ffdee6"), true, new Guid("39f368f2-881c-40a6-8f22-8987bb28f1f6"), "//div[@class='article__media']//img/@src" },
                    { new Guid("415aa161-492c-4974-8486-e24e288b84ab"), true, new Guid("ac7d5e90-329c-4060-90c9-2bfbe94ef6ca"), "//picture/img/@src" },
                    { new Guid("57478817-54d4-4db7-94cc-5157de54f797"), false, new Guid("fc0a9476-bb36-4e0b-a751-8f746aa0a9ff"), "//article//div[@class='image-con' and position() = 1]/picture/img/@src" },
                    { new Guid("5b70968a-52ca-4dea-bd23-f37d73c04a1c"), true, new Guid("64b22c28-8507-4f9c-9fbd-a3705d71f942"), "//header//figure//picture/img/@src" },
                    { new Guid("5d47de26-9b53-4164-be50-776564362037"), false, new Guid("35a24ff2-fa01-499f-8323-9c79bc797d31"), "//figure//img/@src" },
                    { new Guid("60c878c9-6f5d-440f-8233-2a3d85852922"), false, new Guid("5c8b9127-76cf-42b9-840a-37208c5ae0b8"), "//div[@class='photoview__open']/img/@src" },
                    { new Guid("61cc0a36-e72b-4f58-8a53-f2df2283c54d"), false, new Guid("7013650a-9d08-4906-ab97-baa2aac17af4"), "//article//header/div[@class='article-head__photo']/img/@src" },
                    { new Guid("627623e5-96da-4f04-8830-f41b0e3ef2f7"), false, new Guid("eef6cc12-742c-43a7-8493-966f8f1decc5"), "//div[contains(@class, 'HeaderMedia_image')]//img[contains(@class, 'Image_image')]/@src" },
                    { new Guid("660aaf2e-2d2a-4bb2-b6db-1e33b16d964a"), false, new Guid("efe75535-e961-4e17-99db-c5a7c8fe8e7b"), "//article/figure/img/@src" },
                    { new Guid("83951a48-5c0e-4c61-b5f5-e80279c74beb"), true, new Guid("db565ffd-6dbb-4f69-a06f-3a6ae4c07c76"), "//meta[@property='og:image']/@content" },
                    { new Guid("98940d26-9178-4e43-a39d-53119a1d30a8"), false, new Guid("2437ef1a-cbe3-4b80-9d03-9d1c856d5ed0"), "//div[@class='b_article-media']//div[@class='mainarea-wrapper']/figure/img[@class='item-image-front']/@src" },
                    { new Guid("99daac7e-a529-4db7-9827-9109f4d07f22"), false, new Guid("4ba0a0f2-55ec-473b-a5ba-8a074191953c"), "//img[@itemprop='image']/@src" },
                    { new Guid("9de0a8bb-0c51-46dd-b3dd-7584d1d859f2"), true, new Guid("b2866d0e-18d7-4892-8d60-574c24329294"), "//a[@class='glightbox']/img[contains(@class, 'pub-cover')]/@src" },
                    { new Guid("a8b9e368-7907-4d40-a81b-0b601c8aec55"), false, new Guid("aa3b00e6-d2f2-498a-a2ef-b5e607f180c3"), "//div[contains(@class, 'full-article')]/div[contains(@class, 'gallery')]/picture/img/@src" },
                    { new Guid("b09b8138-69c9-4c27-8ca5-5db24639d22d"), true, new Guid("12c2cecd-1943-499c-b457-249383dbed9c"), "//div[contains(@class, 'newsMediaContainer')]/img/@src" },
                    { new Guid("c72f1e7f-fa95-4be8-a9d0-e55c2224966f"), false, new Guid("81f44eba-b916-4ff4-ae69-048c9394b8a9"), "//div[@class='b-material-incut-m-image']//@src" },
                    { new Guid("d1043b59-588d-48fe-87fa-e206e43bf175"), false, new Guid("a075eef1-9c39-4de0-b59f-0f43dfad5afe"), "//div[@class='img_box']/a[@class='zoom_js']/img/@src" },
                    { new Guid("e03ee263-8bcd-4c3c-b2ea-86a0ee45da2a"), false, new Guid("bab7cc8f-22f1-4827-a907-0d4fea6d85f9"), "//div[@class='inner_content']//div[@class='main_img']//img/@src" },
                    { new Guid("f5cab39d-c86f-4f34-810f-43e497a25c46"), false, new Guid("28828d64-4283-4bce-9ee4-85a3a854323f"), "//article//header/div[contains(@class, 'styles_cover_media')]/img/@src" },
                    { new Guid("f6ffdad2-60fb-48a5-bc6a-b9810946b5b3"), true, new Guid("8acfe480-e5a7-411f-aaee-ec5d17815ac5"), "//div[contains(@class, 'article__lede-wrapper')]//picture/img/@src" },
                    { new Guid("f84d245e-df39-44a7-9b7a-875ab162ff14"), true, new Guid("b9752dc1-ae7f-4b93-ae54-69d5e9ac7369"), "//div[@itemprop='articleBody']//div[@itemprop='image']/picture/img[@itemprop='contentUrl']/@src" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "published_at_culture_info", "published_at_time_zone_info_id", "published_at_x_path" },
                values: new object[,]
                {
                    { new Guid("0c529d52-43f0-4cde-9061-10fb46b14152"), true, new Guid("5c8b9127-76cf-42b9-840a-37208c5ae0b8"), "ru-RU", "Russian Standard Time", "//div[@class='article__info']//div[@class='article__info-date']/a/text()" },
                    { new Guid("1abc5adf-51ca-4a9d-9979-b22df7eecf32"), true, new Guid("12176b4b-da6d-497b-a336-2d82abf0353e"), "ru-RU", "Russian Standard Time", "//article[@itemprop='articleBody']/meta[@itemprop='datePublished']/@content" },
                    { new Guid("1be4abc7-c0b1-42dd-a839-ee52eb2fdab9"), true, new Guid("db565ffd-6dbb-4f69-a06f-3a6ae4c07c76"), "ru-RU", null, "//article/header//time/@datetime" },
                    { new Guid("3957517e-3cb2-4638-97c2-661f499bbf07"), true, new Guid("efe75535-e961-4e17-99db-c5a7c8fe8e7b"), "ru-RU", "Russian Standard Time", "//article/div[@class='header']/span/text()" },
                    { new Guid("3dff3b6f-3a80-4c00-bc62-508ee2a27236"), true, new Guid("64b22c28-8507-4f9c-9fbd-a3705d71f942"), "en-US", null, "//time/@datetime" },
                    { new Guid("47ae90e8-8ea8-403c-885f-c5acdab500e4"), true, new Guid("c6a7b7c8-5612-43f4-9ad2-314b3678844b"), "ru-RU", "Russian Standard Time", "//div[@class='topic-page__header']//a[contains(@class, 'topic-header__time')]/text()" },
                    { new Guid("5621942b-3359-4bd6-b593-d2b34b7b1102"), true, new Guid("3ac34c13-6431-4002-ac19-49587497f2e9"), "ru-RU", null, "//div[@class='doc_header__time']/time[@class='doc_header__publish_time']/@datetime" },
                    { new Guid("5787c6da-53a2-4b5f-9074-8446530e5371"), true, new Guid("35a24ff2-fa01-499f-8323-9c79bc797d31"), "ru-RU", "Ekaterinburg Standard Time", "//div[@itemprop='datePublished']/time/@datetime" },
                    { new Guid("58842a2e-afd5-4bd8-960b-079d1eef610e"), true, new Guid("4ba0a0f2-55ec-473b-a5ba-8a074191953c"), "ru-RU", null, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']/span[@itemprop='datePublished']/@content" },
                    { new Guid("6c5e4b87-be6e-4f2d-80b6-b3d944cf70d2"), true, new Guid("a075eef1-9c39-4de0-b59f-0f43dfad5afe"), "ru-RU", "Russian Standard Time", "//div[@class='article_top']//div[@class='date']//time/text()" },
                    { new Guid("7434d0c5-d9d5-4d0e-bde7-a87cee78c68f"), true, new Guid("12c2cecd-1943-499c-b457-249383dbed9c"), "ru-RU", null, "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("7ed3aeb1-d49d-4f81-8b65-55519428481f"), false, new Guid("b2866d0e-18d7-4892-8d60-574c24329294"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'pubdatetime')]/text()" },
                    { new Guid("956ccdbb-68a4-402d-bfd3-9dd0058677d4"), true, new Guid("aa3b00e6-d2f2-498a-a2ef-b5e607f180c3"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'full-article')]//time/text()" },
                    { new Guid("9d1e0812-4265-403a-b342-384e65d8795a"), true, new Guid("7013650a-9d08-4906-ab97-baa2aac17af4"), "ru-RU", "Russian Standard Time", "//article//header//time[@class='article-head__date']/text()" },
                    { new Guid("a0feacd8-07ad-444a-8cae-4a9ce01c027b"), true, new Guid("bab7cc8f-22f1-4827-a907-0d4fea6d85f9"), "ru-RU", "Russian Standard Time", "//div[@class='date_full']/text()" },
                    { new Guid("ad6b1faa-7a90-461d-ad99-c9d27a008f14"), true, new Guid("eef6cc12-742c-43a7-8493-966f8f1decc5"), "ru-RU", "UTC", "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark')]//span[@ca-ts]/text()" },
                    { new Guid("b782572b-b5e1-4803-8759-1961be147677"), true, new Guid("7d674500-835d-4344-9d2b-a36c447f71a8"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'article__date-autor-shortcode')]/div[contains(@class, 'article__date')]/time[@class='date']/@datetime" },
                    { new Guid("bcd6bdb1-3b84-4bef-a624-7a4d5e37ed0c"), true, new Guid("c4883f4c-672c-4947-88db-4bebc8b28b21"), "ru-RU", "Russian Standard Time", "//div[@class='b-article__top-author']/p[@class='date']/text()" },
                    { new Guid("c2134632-d93f-4b9e-817b-2c0e016b32e1"), true, new Guid("81f44eba-b916-4ff4-ae69-048c9394b8a9"), "ru-RU", "Russian Standard Time", "//p[@class='b-material__date']/text()" },
                    { new Guid("c2b540d8-325d-4e85-b3d7-81a125ebf07c"), true, new Guid("ac7d5e90-329c-4060-90c9-2bfbe94ef6ca"), "ru-RU", "Russian Standard Time", "//div[@class='b-text__date']/text()" },
                    { new Guid("cbc83ba0-0099-497a-8161-3e4632bc090a"), true, new Guid("28828d64-4283-4bce-9ee4-85a3a854323f"), "ru-RU", "UTC", "//article//header//div[contains(@class, 'styles_meta')]//div[contains(@class, 'styles_metaItem')]/text()" },
                    { new Guid("ccf73ab0-6f45-476d-8f0b-91a2d9e89aea"), true, new Guid("b9752dc1-ae7f-4b93-ae54-69d5e9ac7369"), "ru-RU", null, "//div[@class='publication-info']/time[@itemprop='datePublished']/@datetime" },
                    { new Guid("dc435a67-b162-44a0-a55f-fc86ded584ce"), true, new Guid("8acfe480-e5a7-411f-aaee-ec5d17815ac5"), "en-US", "Eastern Standard Time", "//div[@class='headline__footer']//div[contains(@class, 'headline__byline-sub-text')]/div[@class='timestamp']/text()" },
                    { new Guid("ddd4edff-bac3-4261-a061-bb15616fbdc5"), true, new Guid("7ebbac2d-5cd7-4464-bf67-0b476d348ffe"), "ru-RU", null, "//div[@class='article__header__info-block']/time[@class='article__header__date']/@datetime" },
                    { new Guid("df2cb0ff-6fd5-43c7-b04c-20e0ff750137"), true, new Guid("dab966dc-f416-4f44-ad15-cba6b82845b0"), "ru-RU", null, "//div[@class='article_page__left__top__left']//div[@class='article_page__left__top__time']//time/@datetime" },
                    { new Guid("e38faedf-1155-49d5-a3d7-024438afc593"), true, new Guid("2437ef1a-cbe3-4b80-9d03-9d1c856d5ed0"), "ru-RU", null, "//article/div[@class='b_article-header']//time[@itemprop='datePublished']/@datetime" },
                    { new Guid("e5debb07-c0c6-4067-b154-3b2cbbfcc77a"), true, new Guid("b56cc4ac-0416-4f95-9395-8ea087908d2d"), "ru-RU", null, "//header[@class='news-item__header']//time/@content" },
                    { new Guid("ea9ba5c8-add5-4953-80a2-6848f077cb42"), true, new Guid("39f368f2-881c-40a6-8f22-8987bb28f1f6"), "ru-RU", "Russian Standard Time", "//div[@class='article__meta']/time/text()" },
                    { new Guid("ef35894d-f7f2-49dc-ad0b-cda12c6e7d71"), true, new Guid("83225235-0e2f-4f68-9ca0-1d00760f97cd"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'PageArticleContent_date')]/text()" },
                    { new Guid("f1e4ba77-88af-49d7-b891-039686a9e505"), true, new Guid("fc0a9476-bb36-4e0b-a751-8f746aa0a9ff"), "en-US", "Central Europe Standard Time", "//article//div[@class='article-info']/div[@class='date']/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_sub_title_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("01ea96cd-9873-4297-b2fa-2a79e2c16151"), true, new Guid("db565ffd-6dbb-4f69-a06f-3a6ae4c07c76"), "//div[contains(@class, 'js-mediator-article')]/*[position()=1]/text()" },
                    { new Guid("2afc1024-e3ee-43cc-a723-0fc2af90d1f8"), true, new Guid("fc0a9476-bb36-4e0b-a751-8f746aa0a9ff"), "//p[@class='headertext' and @itemprop='description']/text()" },
                    { new Guid("34debd04-93e4-4141-b683-9d6407136893"), true, new Guid("64b22c28-8507-4f9c-9fbd-a3705d71f942"), "//header/p[@id='article-summary']/text()" },
                    { new Guid("3d97dcc8-0acb-48bf-9d42-34fb818d5060"), true, new Guid("b2866d0e-18d7-4892-8d60-574c24329294"), "//div[@class='container-fluid shifted']/p[@class='announce lead']/text()" },
                    { new Guid("409b7a3f-59f6-4f55-8b66-726259404536"), true, new Guid("4ba0a0f2-55ec-473b-a5ba-8a074191953c"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()=1]/text()" },
                    { new Guid("4ed736ca-5a54-4933-a690-0c2a76752a47"), true, new Guid("aa3b00e6-d2f2-498a-a2ef-b5e607f180c3"), "//h1/text()" },
                    { new Guid("52d6b90b-5c8b-4091-a301-a434d1b656d3"), true, new Guid("2437ef1a-cbe3-4b80-9d03-9d1c856d5ed0"), "//h2/text()" },
                    { new Guid("5628a7fd-edb5-466f-8fd2-9912bd3fb6c5"), true, new Guid("12c2cecd-1943-499c-b457-249383dbed9c"), "//div[@itemprop='alternativeHeadline']/text()" },
                    { new Guid("684b9261-6d50-4db7-885f-7917553c5f4f"), false, new Guid("3ac34c13-6431-4002-ac19-49587497f2e9"), "//header[@class='doc_header']/h2[contains(@class, 'doc_header__subheader')]/text()" },
                    { new Guid("69e29366-3061-4b76-8a23-0ed1db69c8e8"), true, new Guid("39f368f2-881c-40a6-8f22-8987bb28f1f6"), "//div[@class='article__intro']/p/text()" },
                    { new Guid("781f72c4-1f70-497f-80a0-a25d1e80709e"), false, new Guid("c4883f4c-672c-4947-88db-4bebc8b28b21"), "//h4/text()" },
                    { new Guid("7a027eee-5213-4c9e-a043-6f46db587156"), false, new Guid("7ebbac2d-5cd7-4464-bf67-0b476d348ffe"), "//div[contains(@class, 'article__text')]/div[@class='article__text__overview']/span/text()" },
                    { new Guid("8e850a31-f798-476f-b450-6ee5bcac3f21"), true, new Guid("7d674500-835d-4344-9d2b-a36c447f71a8"), "//div[contains(@class, 'article__summary')]/text()" },
                    { new Guid("9573975c-7b86-4017-b81a-95092169d505"), false, new Guid("c6a7b7c8-5612-43f4-9ad2-314b3678844b"), "//div[contains(@class, 'topic-body__title')]/text()" },
                    { new Guid("a642788f-0d72-4758-8faf-626b3745d829"), true, new Guid("5c8b9127-76cf-42b9-840a-37208c5ae0b8"), "//h1[@class='article__second-title']/text()" },
                    { new Guid("c46f725d-7a05-426e-921c-3562fccf394b"), false, new Guid("83225235-0e2f-4f68-9ca0-1d00760f97cd"), "//div[contains(@class, 'PageArticleContent_lead')]/text()" },
                    { new Guid("d8628ef7-523e-40cf-b6e5-131a9690935c"), false, new Guid("efe75535-e961-4e17-99db-c5a7c8fe8e7b"), "//h4/text()" },
                    { new Guid("dfdd29a8-f6c0-49e2-93b7-7089c5cf21b6"), false, new Guid("eef6cc12-742c-43a7-8493-966f8f1decc5"), "//h3/text()" },
                    { new Guid("e128cffa-d8ba-46da-889b-90a09f0482fd"), false, new Guid("28828d64-4283-4bce-9ee4-85a3a854323f"), "//article//header//p[contains(@class, 'styles_subtitle')]/text()" },
                    { new Guid("f0924cad-3d01-4544-9980-5001cd8ef6be"), true, new Guid("35a24ff2-fa01-499f-8323-9c79bc797d31"), "//p[@itemprop='alternativeHeadline']/span/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_video_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[] { new Guid("c11634f9-86c5-4a2d-ae3d-28d18b08dc47"), false, new Guid("fc0a9476-bb36-4e0b-a751-8f746aa0a9ff"), "//article//div[@class='videoWrapper' and @itemprop='video']/iframe[@class='video']/@src" });

            migrationBuilder.InsertData(
                table: "news_parse_modified_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_modified_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("4a2d70c6-d339-45a0-bd38-746e448ec495"), "\"обновлено\" d MMMM, HH:mm", new Guid("e6552281-f68d-4c70-bbd8-b2d9cc96693f") },
                    { new Guid("60abf4e9-bad2-48d2-8a68-cf86ef42787f"), "(\"обновлено:\" HH:mm dd.MM.yyyy)", new Guid("abf75d2b-1713-4194-b155-1169201184ec") },
                    { new Guid("7e197562-f895-4f66-8800-ed7410e691b8"), "\"обновлено\" d MMMM yyyy, HH:mm", new Guid("e6552281-f68d-4c70-bbd8-b2d9cc96693f") },
                    { new Guid("b41beeb4-e45d-4b90-ab72-80fe34d77ff7"), "\"обновлено\" HH:mm , dd.MM", new Guid("ba69f4c3-ea25-4d70-a621-2cfe6a8e8b60") },
                    { new Guid("d8361bfe-c3d2-4603-98b4-e7822b978d04"), "\"обновлено\" HH:mm , dd.MM.yyyy", new Guid("ba69f4c3-ea25-4d70-a621-2cfe6a8e8b60") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_published_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("00b8ebcc-377e-485d-bd80-dc56ef00a00c"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("df2cb0ff-6fd5-43c7-b04c-20e0ff750137") },
                    { new Guid("025009ed-a580-49f3-b4a0-d4ff2ec1c59d"), "yyyy-MM-ddTHH:mm:ss", new Guid("1abc5adf-51ca-4a9d-9979-b22df7eecf32") },
                    { new Guid("0ccbd3d9-7d85-4b48-b975-e53bdba9bc2a"), "d MMMM yyyy \"в\" HH:mm", new Guid("bcd6bdb1-3b84-4bef-a624-7a4d5e37ed0c") },
                    { new Guid("1a453630-80f3-4a1e-9503-b79e6584d199"), "d MMMM  HH:mm", new Guid("c2b540d8-325d-4e85-b3d7-81a125ebf07c") },
                    { new Guid("1b708bfe-49f5-433c-8294-c49db8f44e19"), "yyyy-MM-ddTHH:mm:ss.fffZ", new Guid("1be4abc7-c0b1-42dd-a839-ee52eb2fdab9") },
                    { new Guid("1ddf4cdc-e794-4e4d-bcb9-317751d47815"), "d MMMM yyyy, HH:mm", new Guid("3957517e-3cb2-4638-97c2-661f499bbf07") },
                    { new Guid("216d0fb5-1bc7-42d4-aa5a-606724db72b2"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("3dff3b6f-3a80-4c00-bc62-508ee2a27236") },
                    { new Guid("24e3731b-3de8-48be-9644-fe6ad54470ac"), "dd MMMM yyyy, HH:mm", new Guid("a0feacd8-07ad-444a-8cae-4a9ce01c027b") },
                    { new Guid("2be437eb-de0d-4533-bd88-356255c5197c"), "d MMMM yyyy, HH:mm \"МСК\"", new Guid("9d1e0812-4265-403a-b342-384e65d8795a") },
                    { new Guid("2fb01569-725c-4a96-8d2b-0590261143e8"), "yyyy-MM-ddTHH:mm:ss", new Guid("5787c6da-53a2-4b5f-9074-8446530e5371") },
                    { new Guid("3c3198f0-aee6-4ba0-8611-703f6561deb3"), "d MMMM yyyy, HH:mm", new Guid("cbc83ba0-0099-497a-8161-3e4632bc090a") },
                    { new Guid("3d5f540b-21f3-4c05-af79-1cdb5dbf18fc"), "\"Published\n       \" HH:mm tt \"EST\", ddd MMMM d, yyyy", new Guid("dc435a67-b162-44a0-a55f-fc86ded584ce") },
                    { new Guid("3f595865-0b9c-4c56-80f9-062d8dc52302"), "dd MMMM yyyy, HH:mm", new Guid("c2134632-d93f-4b9e-817b-2c0e016b32e1") },
                    { new Guid("44897482-1c8f-4246-8953-2fe09410db2a"), "d MMMM, HH:mm", new Guid("ad6b1faa-7a90-461d-ad99-c9d27a008f14") },
                    { new Guid("4ccaeb1a-4fc2-4b80-b560-806dee309b7e"), "d MMMM yyyy, HH:mm,", new Guid("ad6b1faa-7a90-461d-ad99-c9d27a008f14") },
                    { new Guid("5434f3d9-99be-42b5-94d8-a1991e151c51"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("e5debb07-c0c6-4067-b154-3b2cbbfcc77a") },
                    { new Guid("59e435dd-34e2-40d3-ab36-d2d11a418b5f"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("5621942b-3359-4bd6-b593-d2b34b7b1102") },
                    { new Guid("5afb7f04-3ef6-4c0a-bc67-2353e6157d03"), "yyyy-MM-dd HH:mm:ss", new Guid("7ed3aeb1-d49d-4f81-8b65-55519428481f") },
                    { new Guid("81f3c450-ecc9-4440-b4f7-25775ca481c8"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("ddd4edff-bac3-4261-a061-bb15616fbdc5") },
                    { new Guid("84a3cf06-900c-466c-bcb0-8f01cd24c1ee"), "d MMMM, HH:mm", new Guid("cbc83ba0-0099-497a-8161-3e4632bc090a") },
                    { new Guid("8873f015-b5ef-4508-b0df-a0ed7da5db15"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("7434d0c5-d9d5-4d0e-bde7-a87cee78c68f") },
                    { new Guid("8e600018-aa4e-4b79-9167-680b66647678"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("58842a2e-afd5-4bd8-960b-079d1eef610e") },
                    { new Guid("94b919ee-59ad-46ad-ac67-e222fe4a3ef6"), "d MMMM, HH:mm,", new Guid("ad6b1faa-7a90-461d-ad99-c9d27a008f14") },
                    { new Guid("a40ee49c-3b32-4257-85bb-6d631da65345"), "d MMMM yyyy HH:mm", new Guid("c2b540d8-325d-4e85-b3d7-81a125ebf07c") },
                    { new Guid("a7f01589-ddc1-4025-af14-2d787ec1384e"), "dd.MM.yyyy HH:mm", new Guid("ef35894d-f7f2-49dc-ad0b-cda12c6e7d71") },
                    { new Guid("a904084b-297e-4826-bd66-4e5a0c3a9179"), "HH:mm", new Guid("ea9ba5c8-add5-4953-80a2-6848f077cb42") },
                    { new Guid("b221385b-c1ac-4091-8bfe-cb450d1d91e0"), "yyyy-MM-d HH:mm", new Guid("b782572b-b5e1-4803-8759-1961be147677") },
                    { new Guid("b2e88000-e890-43df-acc5-2f8f5284e270"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("ccf73ab0-6f45-476d-8f0b-91a2d9e89aea") },
                    { new Guid("b44f306c-697d-40af-8f6e-3c87d13b571c"), "HH:mm", new Guid("c2134632-d93f-4b9e-817b-2c0e016b32e1") },
                    { new Guid("baa170fd-8bdd-4169-bcaa-e555834dadc8"), "dd MMMM yyyy HH:mm", new Guid("ea9ba5c8-add5-4953-80a2-6848f077cb42") },
                    { new Guid("c1623615-6430-4453-aa80-67a7255532ea"), "HH:mm dd.MM.yyyy", new Guid("0c529d52-43f0-4cde-9061-10fb46b14152") },
                    { new Guid("c7c01655-46d4-4947-9235-2731e74397ba"), "HH:mm, d MMMM yyyy", new Guid("47ae90e8-8ea8-403c-885f-c5acdab500e4") },
                    { new Guid("d281e160-ce1a-4a59-a73c-9ea1358ffe2a"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("e38faedf-1155-49d5-a3d7-024438afc593") },
                    { new Guid("e0e0d0df-feb4-4046-9365-e71298219b97"), "d MMMM yyyy, HH:mm", new Guid("ad6b1faa-7a90-461d-ad99-c9d27a008f14") },
                    { new Guid("e3f64196-e624-441a-84aa-d3b0ebbc2313"), "dd MMMM, HH:mm", new Guid("c2134632-d93f-4b9e-817b-2c0e016b32e1") },
                    { new Guid("f05aa390-2059-4efd-9bda-79aee198edb8"), "dd.MM.yyyy HH:mm", new Guid("956ccdbb-68a4-402d-bfd3-9dd0058677d4") },
                    { new Guid("f8983989-0ce4-47ba-8476-95d645437278"), "dd.MM.yyyy HH:mm", new Guid("6c5e4b87-be6e-4f2d-80b6-b3d944cf70d2") },
                    { new Guid("fa45d623-d46f-46b2-a8c7-6d7f8842d485"), "d-M-yyyy HH:mm", new Guid("f1e4ba77-88af-49d7-b891-039686a9e505") }
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
