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
                    { new Guid("05fb1bcd-0df0-4234-9171-2f443471b2e4"), true, "https://tass.ru/", "ТАСС" },
                    { new Guid("09c17939-0afd-47b3-abf7-11d7e44dad3c"), true, "https://vz.ru/", "ВЗГЛЯД.РУ" },
                    { new Guid("10738b63-d4fd-4c44-92ef-a74e7617dee5"), true, "https://tsargrad.tv/", "Царьград" },
                    { new Guid("11ea1d14-bf43-4384-bda5-d6af7e50ff0e"), true, "https://www.m24.ru/", "Москва 24" },
                    { new Guid("28d2cbe0-290d-46f3-ad86-04301a878e1b"), true, "https://www.pravda.ru/", "Правда.ру" },
                    { new Guid("3af21ee7-2dc1-43a3-9b5b-7d8a79f582de"), true, "https://74.ru/", "74.ru" },
                    { new Guid("3c2445b4-fe82-44a0-b2c7-010ec31df86e"), true, "https://rg.ru/", "Российская газета" },
                    { new Guid("3e669eb1-6022-4111-85af-21798fdf33aa"), true, "https://iz.ru/", "Известия" },
                    { new Guid("4d8c14b2-1008-40ac-8374-c508d554acc8"), true, "https://aif.ru/", "Аргументы и факты" },
                    { new Guid("4fe3ed6b-56c7-4dfb-8c6a-ac5493141356"), true, "https://life.ru/", "Life" },
                    { new Guid("521a13c0-2966-45f7-ac9e-dc3c53324797"), true, "https://ria.ru/", "РИА Новости" },
                    { new Guid("554538c6-aae8-4a3c-a80d-fdb0996cd738"), true, "https://www.1obl.ru/", "Первый областной" },
                    { new Guid("5a42851e-c4d5-41e2-841f-951b4b9d9776"), true, "https://3dnews.ru/", "3Dnews.ru" },
                    { new Guid("5f000a39-56b4-4930-91a6-cf6d0e3589e0"), true, "https://ura.news/", "Ura.ru" },
                    { new Guid("630cb70b-fc8a-44f8-b95a-6d992f851c00"), true, "https://www.kommersant.ru/", "Коммерсантъ" },
                    { new Guid("674983d4-17f8-49cb-b5e5-532c991a1ea9"), true, "https://www.cybersport.ru/", "Cybersport.ru" },
                    { new Guid("6cba110f-0615-42e7-8b60-9a2091ecead4"), true, "https://www.nytimes.com/", "The New York Times" },
                    { new Guid("7a1bbb2e-8d2b-415c-b40e-5d1dde4ae728"), true, "https://www.gazeta.ru/", "Газета.Ru" },
                    { new Guid("82e1f2e7-5add-49aa-b54e-e4c19ac7d4a8"), true, "https://www.belta.by/", "БелТА" },
                    { new Guid("98c584cd-d773-4d3c-9cc0-d0a82f8f132c"), true, "https://www.championat.com/", "Чемпионат.com" },
                    { new Guid("9c0e1b9f-ff42-4f3b-9ad6-9d731a7569e9"), true, "https://www.rbc.ru/", "РБК" },
                    { new Guid("adee8cec-1fc0-4f80-99cc-0cb7a7491b31"), true, "https://www.hltv.org/", "HLTV.org" },
                    { new Guid("b27d78f7-e7dd-4936-85f0-fb3de14e0f22"), true, "https://www.ixbt.com/", "iXBT.com" },
                    { new Guid("b64e8ec9-5ca8-4ec6-a4f1-8133fddb77aa"), true, "https://edition.cnn.com/", "CNN" },
                    { new Guid("b6664cf4-d8fd-4fa1-9d23-4b29ef937d6e"), true, "https://svpressa.ru/", "СвободнаяПресса" },
                    { new Guid("cc712913-0c5b-4457-8cf3-5f367216db16"), true, "https://ixbt.games/", "iXBT.games" },
                    { new Guid("cc9b3267-e1f5-4464-808d-fbd6a6942710"), true, "https://lenta.ru/", "Лента.Ру" },
                    { new Guid("da04003c-8f7d-4d2d-84cd-a1555bd8f135"), true, "https://www.interfax.ru/", "Интерфакс" },
                    { new Guid("e9150808-e27a-4d2e-915a-c78f7c4b34d6"), true, "https://russian.rt.com/", "RT на русском" },
                    { new Guid("f8115fea-d658-42e0-9fb7-18e880bde8f2"), true, "https://www.sports.ru/", "Storts.ru" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_settings",
                columns: new[] { "id", "description_x_path", "source_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("006a35f4-b40b-4761-ae70-f0ec1ad7f574"), "//div[contains(@class, 'news-item__content')]", new Guid("f8115fea-d658-42e0-9fb7-18e880bde8f2"), "//h1/text()" },
                    { new Guid("007b3a5a-5541-4c33-8074-c071ac21a7f9"), "//div[@class='topic-body__content']", new Guid("cc9b3267-e1f5-4464-808d-fbd6a6942710"), "//h1[@class='topic-body__titles']/span[@class='topic-body__title']/text()" },
                    { new Guid("28d0b9f2-f3b5-432d-a6e3-0977657e4e6f"), "//div[@itemprop='articleBody']/*", new Guid("554538c6-aae8-4a3c-a80d-fdb0996cd738"), "//h1[@itemprop='headline']/text()" },
                    { new Guid("2c6df20a-dd41-4742-a081-4a4295f93522"), "//article//div[@class='newstext-con']/*[not(name()='p' and @class='headertext') and not(name()='div' and @class='image-con' and position()=1)]", new Guid("adee8cec-1fc0-4f80-99cc-0cb7a7491b31"), "//h1[@class='headline']/text()" },
                    { new Guid("37624e88-06d7-440e-a686-c0732673e7e1"), "//div[@itemprop='articleBody']/*", new Guid("b64e8ec9-5ca8-4ec6-a4f1-8133fddb77aa"), "//h1/text()" },
                    { new Guid("3e09a3ba-ec3b-4a56-aa92-e24db5d0e1fc"), "//div[contains(@class, 'article__text ')]", new Guid("e9150808-e27a-4d2e-915a-c78f7c4b34d6"), "//h1/text()" },
                    { new Guid("4a9c502d-182d-45f8-b574-357b75cc5c2e"), "//article/*", new Guid("05fb1bcd-0df0-4234-9171-2f443471b2e4"), "//h1/text()" },
                    { new Guid("4e3c0ae9-2df7-48be-923d-d734249dd2ee"), "//div[contains(@class, 'article__body')]", new Guid("521a13c0-2966-45f7-ac9e-dc3c53324797"), "//div[@class='article__title']/text()" },
                    { new Guid("536d7436-a908-4cb7-be60-4ed6691e3a5f"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]", new Guid("630cb70b-fc8a-44f8-b95a-6d992f851c00"), "//h1/text()" },
                    { new Guid("54e3ee89-0964-4d16-85a5-fe411bb2aa91"), "//div[contains(@class, 'js-mediator-article')]/*[position()>1]", new Guid("674983d4-17f8-49cb-b5e5-532c991a1ea9"), "//h1/text()" },
                    { new Guid("56f0cb28-ff88-4710-b696-777657256918"), "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]", new Guid("da04003c-8f7d-4d2d-84cd-a1555bd8f135"), "//h1/text()" },
                    { new Guid("69cc661a-fb9f-4310-bcc1-67efea1a4e30"), "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]", new Guid("4fe3ed6b-56c7-4dfb-8c6a-ac5493141356"), "//h1/text()" },
                    { new Guid("79d0e094-f8d7-4857-8a78-2fa85ca75da7"), "//article/div[@class='article-content']/*[not(@class)]", new Guid("98c584cd-d773-4d3c-9cc0-d0a82f8f132c"), "//article/header/div[@class='article-head__title']/text()" },
                    { new Guid("7e843443-01fa-4130-acec-c5b420b4379b"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview'))]", new Guid("9c0e1b9f-ff42-4f3b-9ad6-9d731a7569e9"), "//h1/text()" },
                    { new Guid("925d85ba-1b2d-47c6-a67d-f4ecea0a7737"), "//div[@itemprop='articleBody']/*", new Guid("3e669eb1-6022-4111-85af-21798fdf33aa"), "//h1/span/text()" },
                    { new Guid("9315fdbb-e46f-4513-8420-ddbcc0318a30"), "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]", new Guid("b6664cf4-d8fd-4fa1-9d23-4b29ef937d6e"), "//h1[@class='b-text__title']/text()" },
                    { new Guid("97fe792b-ff52-4a9e-85e9-852691241616"), "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]", new Guid("11ea1d14-bf43-4384-bda5-d6af7e50ff0e"), "//h1/text()" },
                    { new Guid("98bb0174-82fc-43bf-8f36-40413c5a64d0"), "//article/div[@class='news_text']", new Guid("09c17939-0afd-47b3-abf7-11d7e44dad3c"), "//h1/text()" },
                    { new Guid("a0387851-c771-47c2-b47f-ab64355f892a"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]", new Guid("10738b63-d4fd-4c44-92ef-a74e7617dee5"), "//h1[@class='article__title']/text()" },
                    { new Guid("a35233d9-911e-4d7a-bb48-84c4e2cd892e"), "//section[@name='articleBody']/*", new Guid("6cba110f-0615-42e7-8b60-9a2091ecead4"), "//h1/text()" },
                    { new Guid("b729d17e-19a3-493e-9364-2cb21a0f8ae2"), "//div[contains(@class, 'PageContentCommonStyling_text')]", new Guid("3c2445b4-fe82-44a0-b2c7-010ec31df86e"), "//h1/text()" },
                    { new Guid("c35f7865-8454-4aa8-a87f-081d20ea0ac6"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()>1]", new Guid("5a42851e-c4d5-41e2-841f-951b4b9d9776"), "//h1/text()" },
                    { new Guid("c9e7dbbc-7c81-41c2-9682-8bb2079b7d76"), "//div[@itemprop='articleBody']/*", new Guid("b27d78f7-e7dd-4936-85f0-fb3de14e0f22"), "//h1/text()" },
                    { new Guid("ca22af7f-1d1f-4e94-980e-2d910c8d775b"), "//div[contains(@class, 'container-fluid shifted') and not(p[@class='announce lead']) and not(h1) and not(hr)]", new Guid("cc712913-0c5b-4457-8cf3-5f367216db16"), "//h1/text()" },
                    { new Guid("e3db1466-78f5-45ab-997b-c0334555ea55"), "//div[@class='article_text']", new Guid("4d8c14b2-1008-40ac-8374-c508d554acc8"), "//h1/text()" },
                    { new Guid("e5b5dfab-8121-47d9-96d9-aecc6f4959fa"), "//div[@itemprop='articleBody']/*[not(name()='div')]", new Guid("5f000a39-56b4-4930-91a6-cf6d0e3589e0"), "//h1/text()" },
                    { new Guid("eadf0a4a-1419-491a-89ed-2821a661f0f6"), "//div[@itemprop='articleBody']/*", new Guid("7a1bbb2e-8d2b-415c-b40e-5d1dde4ae728"), "//h1/text()" },
                    { new Guid("ec2311c8-3a76-4cc5-9220-527a1c3e799d"), "//div[@class='js-mediator-article']", new Guid("82e1f2e7-5add-49aa-b54e-e4c19ac7d4a8"), "//h1/text()" },
                    { new Guid("f47e776e-f731-4186-a675-7a61f6756a68"), "//div[@itemprop='articleBody']/*[not(name() = 'figure')]", new Guid("3af21ee7-2dc1-43a3-9b5b-7d8a79f582de"), "//h1[@itemprop='headline']/span/text()" },
                    { new Guid("fe028391-1d68-4212-83e0-270832a78c2b"), "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]", new Guid("28d2cbe0-290d-46f3-ad86-04301a878e1b"), "//h1/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_search_settings",
                columns: new[] { "id", "news_site_url", "news_url_x_path", "source_id" },
                values: new object[,]
                {
                    { new Guid("04e7238a-2512-4998-99c5-d006bca19fd2"), "https://ixbt.games/news/", "//a[@class='card-link']/@href", new Guid("cc712913-0c5b-4457-8cf3-5f367216db16") },
                    { new Guid("05978bfb-fc23-4155-b608-dffe85ec34ab"), "https://www.m24.ru/", "//a[contains(@href, '/news/')]/@href", new Guid("11ea1d14-bf43-4384-bda5-d6af7e50ff0e") },
                    { new Guid("275e3de1-2371-429e-af85-7a5b515d56a8"), "https://www.gazeta.ru/news/", "//a[contains(@href, '/news/') and contains(@href, '.shtml') and not(contains(@href, '?'))]/@href", new Guid("7a1bbb2e-8d2b-415c-b40e-5d1dde4ae728") },
                    { new Guid("317eb010-88a1-41fd-a2c5-2bf8dbbe4714"), "https://lenta.ru/", "//a[starts-with(@href, '/news/')]/@href", new Guid("cc9b3267-e1f5-4464-808d-fbd6a6942710") },
                    { new Guid("35c27254-4eef-4d9b-bd96-dd5d0d684510"), "https://rg.ru/", "//a[contains(@href, '.html')]/@href", new Guid("3c2445b4-fe82-44a0-b2c7-010ec31df86e") },
                    { new Guid("40f41fe6-9497-4d44-bd0b-a2cb122a8e1e"), "https://www.championat.com/news/1.html?utm_source=button&utm_medium=news", "//a[contains(@href, 'news-') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("98c584cd-d773-4d3c-9cc0-d0a82f8f132c") },
                    { new Guid("4680fc62-f2d6-4619-8752-124ee923e29a"), "https://www.kommersant.ru/", "//a[contains(@href, '/doc/') and contains(@href, '?from=')]/@href", new Guid("630cb70b-fc8a-44f8-b95a-6d992f851c00") },
                    { new Guid("46ce48fd-4f9c-4d6b-b65c-2f0cf6e78ee6"), "https://iz.ru/news/", "//a[contains(@href, '?main_click')]/@href", new Guid("3e669eb1-6022-4111-85af-21798fdf33aa") },
                    { new Guid("4a6002d9-c514-4944-9e9f-82e465fda54e"), "https://tsargrad.tv/", "//a[contains(@class, 'news-item__link')]/@href", new Guid("10738b63-d4fd-4c44-92ef-a74e7617dee5") },
                    { new Guid("50ea3f21-fdad-49d4-8ad2-3af1da189374"), "https://vz.ru/", "//a[contains(@href, '.html') and not(contains(@href, '#comments')) and not(contains(@href, '?')) and not(contains(@href, '/about/'))]/@href", new Guid("09c17939-0afd-47b3-abf7-11d7e44dad3c") },
                    { new Guid("548b73c9-9834-4e8b-b38d-661a6bdcbbf8"), "https://3dnews.ru/news/", "//div[@class='news-feed-all']//a[@class='entry-header']/h1/../@href", new Guid("5a42851e-c4d5-41e2-841f-951b4b9d9776") },
                    { new Guid("6106a959-60c2-49e0-a317-6d06db766fa9"), "https://ria.ru/", "//a[contains(@class, 'cell-list__item-link')]/@href", new Guid("521a13c0-2966-45f7-ac9e-dc3c53324797") },
                    { new Guid("668fad20-af38-4106-acdf-f4ca6a68846c"), "https://www.ixbt.com/news/", "//a[starts-with(@href, '/news/') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("b27d78f7-e7dd-4936-85f0-fb3de14e0f22") },
                    { new Guid("6bfd7507-112d-437a-a997-114902d92a9f"), "https://edition.cnn.com/", "//a[contains(@href, '.html')]/@href", new Guid("b64e8ec9-5ca8-4ec6-a4f1-8133fddb77aa") },
                    { new Guid("6d4591f4-79c0-4557-944f-5f979bd6055a"), "https://svpressa.ru/all/news/", "//a[contains(@href, '/news/') and not(contains(@href, '?')) and not(starts-with(@href, '/all/news/'))]/@href", new Guid("b6664cf4-d8fd-4fa1-9d23-4b29ef937d6e") },
                    { new Guid("7554944e-d5d8-4a26-994a-6067afed9f5b"), "https://tass.ru/", "//a[contains(@class, 'tass_pkg_link-v5WdK') and contains(substring(@href, 2), '/') and not(contains(@href, '/spec/')) and not(contains(@href, 'spec.tass.ru'))]/@href", new Guid("05fb1bcd-0df0-4234-9171-2f443471b2e4") },
                    { new Guid("7e1f9f24-ae2b-4155-a948-d69c657c3d85"), "https://aif.ru/", "//span[contains(@class, 'item_text__title')]/../@href", new Guid("4d8c14b2-1008-40ac-8374-c508d554acc8") },
                    { new Guid("80a007b5-b709-472e-aeda-782d7a9b8128"), "https://www.pravda.ru/", "//a[contains(@href, '/news/') and not(@href='https://www.pravda.ru/news/')]/@href", new Guid("28d2cbe0-290d-46f3-ad86-04301a878e1b") },
                    { new Guid("85e29345-f02a-4f72-bb06-3df90ebfe1b6"), "https://www.nytimes.com/", "//a[contains(@href, '.html')]/@href", new Guid("6cba110f-0615-42e7-8b60-9a2091ecead4") },
                    { new Guid("94b2ad60-9844-4a5a-a282-b1b7835d8c21"), "https://www.hltv.org/", "//a[contains(@href, '/news/')]/@href", new Guid("adee8cec-1fc0-4f80-99cc-0cb7a7491b31") },
                    { new Guid("a348160c-32fa-4c7b-95e9-9a98e7856c64"), "https://www.belta.by/", "//a[contains(@href, 'https://www.belta.by/') and contains(@href, '/view/')]/@href", new Guid("82e1f2e7-5add-49aa-b54e-e4c19ac7d4a8") },
                    { new Guid("ab129c14-c69b-4005-a555-1975b3e57ba5"), "https://www.cybersport.ru/", "//a[contains(@href, '/tags/')]/@href", new Guid("674983d4-17f8-49cb-b5e5-532c991a1ea9") },
                    { new Guid("ab17abd6-ee76-40f3-ae33-3ea1c0879b7e"), "https://74.ru/", "//a[starts-with(@href, '/text/') and not(contains(@href, '?')) and not(contains(@href, 'comments/')) and not(@href='/text/')]/@href", new Guid("3af21ee7-2dc1-43a3-9b5b-7d8a79f582de") },
                    { new Guid("b0f0d1b4-c5cb-472c-b4c3-50d80f36249c"), "https://www.sports.ru/news/", "//a[contains(@href, '.html') and not(contains(@href, '.html#comments')) and not (contains(@href, '/blogs/'))]/@href", new Guid("f8115fea-d658-42e0-9fb7-18e880bde8f2") },
                    { new Guid("b4b5d76e-2b37-471a-8465-dfb55aac33d4"), "https://www.interfax.ru/", "//div[@class='timeline']//a[@tabindex=5]/@href", new Guid("da04003c-8f7d-4d2d-84cd-a1555bd8f135") },
                    { new Guid("cfaf640b-0d2f-405a-b19c-d974428dd30f"), "https://russian.rt.com/", "//a[contains(@class, 'link') and contains(@href, 'news/')]/@href", new Guid("e9150808-e27a-4d2e-915a-c78f7c4b34d6") },
                    { new Guid("d3f16e4e-e1f4-4920-b1f5-1e8f6aa89bd3"), "https://life.ru/s/novosti", "//a[contains(@href, '/p/')]/@href", new Guid("4fe3ed6b-56c7-4dfb-8c6a-ac5493141356") },
                    { new Guid("ee32e2d4-9713-400c-8130-0c32f8aacb22"), "https://www.rbc.ru/", "//a[contains(@href, 'https://www.rbc.ru/') and contains(@href, '?from=')]/@href", new Guid("9c0e1b9f-ff42-4f3b-9ad6-9d731a7569e9") },
                    { new Guid("eecddf98-cad8-41b2-b128-3be645284a2a"), "https://www.1obl.ru/news/", "//a[starts-with(@href, '/news/') and not(contains(@href, '?'))]/@href", new Guid("554538c6-aae8-4a3c-a80d-fdb0996cd738") },
                    { new Guid("fd736cf9-9a81-4f6c-87d0-e57d35a5f0ca"), "https://ura.news/", "//a[contains(@href, '/news/')]/@href", new Guid("5f000a39-56b4-4930-91a6-cf6d0e3589e0") }
                });

            migrationBuilder.InsertData(
                table: "news_source_logos",
                columns: new[] { "id", "source_id", "url" },
                values: new object[,]
                {
                    { new Guid("099c92c1-d1e1-4619-bbe3-0ab99bcbb02f"), new Guid("5f000a39-56b4-4930-91a6-cf6d0e3589e0"), "https://ura.news/apple-touch-icon.png" },
                    { new Guid("0a785e29-0bfa-4a4f-b137-462f8beb6d64"), new Guid("3e669eb1-6022-4111-85af-21798fdf33aa"), "https://cdn.iz.ru/profiles/portal/themes/purple/images/favicons/apple-icon-120x120.png" },
                    { new Guid("0e333bf4-165f-4fe5-b875-04f95e252fd5"), new Guid("630cb70b-fc8a-44f8-b95a-6d992f851c00"), "https://im.kommersant.ru/ContentFlex/images/favicons2020/apple-touch-icon-120.png" },
                    { new Guid("1064ad0a-10c7-4396-943f-1d036aa5b111"), new Guid("b27d78f7-e7dd-4936-85f0-fb3de14e0f22"), "https://www.ixbt.com/favicon.ico" },
                    { new Guid("11439c9f-71ba-41ed-9964-4ffc5309729c"), new Guid("cc9b3267-e1f5-4464-808d-fbd6a6942710"), "https://icdn.lenta.ru/images/icons/icon-256x256.png" },
                    { new Guid("1839aa6d-d4e6-4180-bd43-65a4631f53c8"), new Guid("10738b63-d4fd-4c44-92ef-a74e7617dee5"), "https://ural.tsargrad.tv/favicons/apple-touch-icon-120x120.png?s2" },
                    { new Guid("2071dfc4-f561-453a-9e87-3bb223e04290"), new Guid("09c17939-0afd-47b3-abf7-11d7e44dad3c"), "https://vz.ru/apple-touch-icon.png" },
                    { new Guid("2414b2da-cee8-48b2-91ff-fc00e4b1c24e"), new Guid("9c0e1b9f-ff42-4f3b-9ad6-9d731a7569e9"), "https://s.rbk.ru/v10_rbcnews_static/common/common-10.10.116/images/apple-touch-icon-120x120.png" },
                    { new Guid("37b608be-81c2-4a45-832e-a437401d5e55"), new Guid("28d2cbe0-290d-46f3-ad86-04301a878e1b"), "https://www.pravda.ru/pix/apple-touch-icon.png" },
                    { new Guid("3df7b142-59ea-434a-95a3-b4fb82a27566"), new Guid("adee8cec-1fc0-4f80-99cc-0cb7a7491b31"), "https://www.hltv.org/img/static/favicon/apple-touch-icon.png" },
                    { new Guid("51356ebb-37b3-4b0d-8aac-1d05d9b5ec34"), new Guid("4fe3ed6b-56c7-4dfb-8c6a-ac5493141356"), "https://life.ru/appletouch/apple-icon-120х120.png" },
                    { new Guid("809df266-9133-4d3b-8c70-5f70b6af15d8"), new Guid("e9150808-e27a-4d2e-915a-c78f7c4b34d6"), "https://russian.rt.com/static/img/listing-uwc-logo.png" },
                    { new Guid("8b29e2be-7605-4970-8ccf-3d80f16c6eb1"), new Guid("b6664cf4-d8fd-4fa1-9d23-4b29ef937d6e"), "https://svpressa.ru/favicon-96x96.png?v=1471426270000" },
                    { new Guid("a1ec55c8-0a87-4d8e-a839-9bd11aa13939"), new Guid("3c2445b4-fe82-44a0-b2c7-010ec31df86e"), "https://cdnstatic.rg.ru/images/touch-icon-iphone-retina.png" },
                    { new Guid("a4adbfbf-6428-4528-80b5-634f3138231c"), new Guid("82e1f2e7-5add-49aa-b54e-e4c19ac7d4a8"), "https://www.belta.by/images/storage/banners/000016_a133e848cb2e7b1debb7102d19e4d139_work.svg" },
                    { new Guid("a83a258e-2811-4fb3-834d-a49afd0b858c"), new Guid("05fb1bcd-0df0-4234-9171-2f443471b2e4"), "https://tass.ru/favicon/180.svg" },
                    { new Guid("b8dbba7b-98af-4ff0-8dc0-5ad13650f7a1"), new Guid("674983d4-17f8-49cb-b5e5-532c991a1ea9"), "https://www.cybersport.ru/favicon-192x192.png" },
                    { new Guid("c5915014-1899-46cc-aa30-3b4542607e48"), new Guid("6cba110f-0615-42e7-8b60-9a2091ecead4"), "https://www.nytimes.com/vi-assets/static-assets/apple-touch-icon-28865b72953380a40aa43318108876cb.png" },
                    { new Guid("cda157b8-c1bb-4f44-809a-85a36874c6cb"), new Guid("11ea1d14-bf43-4384-bda5-d6af7e50ff0e"), "https://www.m24.ru/img/fav/apple-touch-icon.png" },
                    { new Guid("cddfcab7-b613-4ae7-916c-c98578cb9a1f"), new Guid("521a13c0-2966-45f7-ac9e-dc3c53324797"), "https://cdnn21.img.ria.ru/i/favicons/favicon.svg" },
                    { new Guid("cfddd430-5f0f-4aee-9963-132fffd7669e"), new Guid("da04003c-8f7d-4d2d-84cd-a1555bd8f135"), "https://www.interfax.ru/touch-icon-iphone-retina.png" },
                    { new Guid("d0dadd6a-00bf-4466-b106-fa9097d3f526"), new Guid("cc712913-0c5b-4457-8cf3-5f367216db16"), "https://ixbt.games/images/favicon/gt/apple-touch-icon.png" },
                    { new Guid("e6f9a377-d16d-451e-ad0f-b3ba97929324"), new Guid("98c584cd-d773-4d3c-9cc0-d0a82f8f132c"), "https://st.championat.com/i/favicon/apple-touch-icon.png" },
                    { new Guid("f2097ba1-8202-400f-b1a1-360600f6f487"), new Guid("7a1bbb2e-8d2b-415c-b40e-5d1dde4ae728"), "https://static.gazeta.ru/nm2021/img/icons/favicon.svg" },
                    { new Guid("f354487b-f817-4ded-a64c-a3bd3def5e72"), new Guid("5a42851e-c4d5-41e2-841f-951b4b9d9776"), "https://3dnews.ru/assets/images/3dnews_logo_soc.png" },
                    { new Guid("f3cc0711-20a5-473b-9dcf-d15703e944b3"), new Guid("554538c6-aae8-4a3c-a80d-fdb0996cd738"), "https://www.1obl.ru/apple-touch-icon.png" },
                    { new Guid("f42eea19-3dcf-4773-b9a5-38d80b5c0b9c"), new Guid("4d8c14b2-1008-40ac-8374-c508d554acc8"), "https://chel.aif.ru/img/icon/apple-touch-icon.png?37f" },
                    { new Guid("fbc67586-559c-4fd1-98da-dbcb0c79c886"), new Guid("3af21ee7-2dc1-43a3-9b5b-7d8a79f582de"), "https://static.ngs.ru/jtnews/dist/static/favicons/apple/apple-favicon-74-120.png" },
                    { new Guid("fe309290-4635-46b1-be5b-4809a6afe34b"), new Guid("f8115fea-d658-42e0-9fb7-18e880bde8f2"), "https://www.sports.ru/apple-touch-icon-120.png" },
                    { new Guid("fe4f3c26-9425-4078-93ef-260659bce179"), new Guid("b64e8ec9-5ca8-4ec6-a4f1-8133fddb77aa"), "https://edition.cnn.com/media/sites/cnn/apple-touch-icon.png" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_editor_settings",
                columns: new[] { "id", "is_required", "name_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("1607bb07-4a95-443b-a865-b8301cda16b4"), true, "//span[@itemprop='name']/a/text()", new Guid("a35233d9-911e-4d7a-bb48-84c4e2cd892e") },
                    { new Guid("1af0f811-4aba-4189-90fe-547c7a2f025d"), true, "//div[@class='headline__footer']//div[@class='byline__names']/span[@class='byline__name']/text()", new Guid("37624e88-06d7-440e-a686-c0732673e7e1") },
                    { new Guid("32f2b0dd-d183-45aa-a82d-585afd79322f"), true, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']//a[@itemprop='author']//span[@itemprop='name']/text()", new Guid("c35f7865-8454-4aa8-a87f-081d20ea0ac6") },
                    { new Guid("3ec69893-a874-4262-8e3b-8419bcdee634"), true, "//div[@class='container-fluid publication-footer']//a[contains(@class, 'text-secondary')]/@title", new Guid("ca22af7f-1d1f-4e94-980e-2d910c8d775b") },
                    { new Guid("427889e2-9046-4100-82e6-09e86bbd9731"), false, "//p[@class='doc__text document_authors']/text()", new Guid("536d7436-a908-4cb7-be60-4ed6691e3a5f") },
                    { new Guid("4b90910c-99ac-406d-b1ee-39659482dac1"), true, "//div[contains(@class, 'PageArticleContent_authors')]//a[contains(@class, 'LinksOfAuthor_item')]/text()", new Guid("b729d17e-19a3-493e-9364-2cb21a0f8ae2") },
                    { new Guid("5b3834e2-12fe-4ab9-befb-ccd103180202"), false, "//div[@itemprop='author']//p[@itemprop='name']/text()", new Guid("f47e776e-f731-4186-a675-7a61f6756a68") },
                    { new Guid("604099ef-9a10-428c-be83-c354ba962c16"), true, "//a[@class='article__author']/text()", new Guid("a0387851-c771-47c2-b47f-ab64355f892a") },
                    { new Guid("9681856e-fde2-429d-983a-92d035e88664"), true, "//div[@itemprop='author']/span[@itemprop='name']/text()", new Guid("e5b5dfab-8121-47d9-96d9-aecc6f4959fa") },
                    { new Guid("97383d4d-66eb-4a29-8db6-b6e05047e6a0"), true, "//footer[@class='news-item__footer']/div[@class='news-item__footer-after-news']/p[position()=1]//span/text()", new Guid("006a35f4-b40b-4761-ae70-f0ec1ad7f574") },
                    { new Guid("9a93e765-4f1e-4d34-901e-bd48ab0daa59"), false, "//div[@class='article__authors']//*[@class='article__authors__author']/span[@class='article__authors__author__name']/text()", new Guid("7e843443-01fa-4130-acec-c5b420b4379b") },
                    { new Guid("a7a918bf-baca-4667-903b-36d7c90c869f"), true, "//*[@itemprop='author']/*[@itemprop='name']//text()", new Guid("28d0b9f2-f3b5-432d-a6e3-0977657e4e6f") },
                    { new Guid("ac9147aa-4b7b-4fd7-8905-df41d7073d6a"), true, "//div[contains(@class, 'styles_bodyWrapper')]//div[contains(@class, 'styles_authorsLinks')]/a/text()", new Guid("69cc661a-fb9f-4310-bcc1-67efea1a4e30") },
                    { new Guid("adfb830c-56f4-4bad-958d-8a79e9fc4f9d"), true, "//div[contains(@class, 'full-article')]/div[@class='authors-block']//span[text()='Автор']/../a/text()", new Guid("fe028391-1d68-4212-83e0-270832a78c2b") },
                    { new Guid("b9ef868b-a482-4167-8646-6d461dc884c9"), true, "//span[@itemprop='author']/span[@itemprop='name']/@content", new Guid("c9e7dbbc-7c81-41c2-9682-8bb2079b7d76") },
                    { new Guid("bde82cf6-dbee-4b82-a4e2-53d7a3a1870f"), false, "//div[@class='author']/span[@itemprop='author']/span[@itemprop='name']/a/text()", new Guid("eadf0a4a-1419-491a-89ed-2821a661f0f6") },
                    { new Guid("c843ec79-7602-47a7-8b98-cf4cbc7fc102"), false, "//div[@class='topic-authors']/a[@class='topic-authors__author']/text()", new Guid("007b3a5a-5541-4c33-8074-c071ac21a7f9") },
                    { new Guid("d64d1335-7be4-4774-a78e-58543f64d0bb"), true, "//article//span[@class='author']/a[@class='authorName']/span/text()", new Guid("2c6df20a-dd41-4742-a081-4a4295f93522") },
                    { new Guid("e61e50ee-86cf-4169-8c9f-e74258aa8af7"), true, "//article//header//div[@class='article-head__author-name']/a[@rel='author']/span/text()", new Guid("79d0e094-f8d7-4857-8a78-2fa85ca75da7") },
                    { new Guid("eb7053e9-686d-4f38-8423-c4d15922c864"), true, "//div[@class='article_top']//div[@class='authors']//div[@class='autor']//span/text()", new Guid("e3db1466-78f5-45ab-997b-c0334555ea55") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_modified_at_settings",
                columns: new[] { "id", "is_required", "modified_at_culture_info", "modified_at_time_zone_info_id", "modified_at_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("538eaa09-4874-42d4-bb55-ec7d3c99b165"), true, "ru-RU", "Russian Standard Time", "//div[@class='article__info']//div[@class='article__info-date']/span[@class='article__info-date-modified']/text()", new Guid("4e3c0ae9-2df7-48be-923d-d734249dd2ee") },
                    { new Guid("5a2a332a-f99b-43ae-8558-032646590b7f"), false, "ru-RU", "UTC", "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark_update')]//span[@ca-ts]/text()", new Guid("4a9c502d-182d-45f8-b574-357b75cc5c2e") },
                    { new Guid("e3886f10-f9a0-4a79-8222-be0627483ea4"), false, "ru-RU", "Russian Standard Time", "//div[@class='doc_header__time']/span[contains(@class, 'publish_update')]/text()", new Guid("536d7436-a908-4cb7-be60-4ed6691e3a5f") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_picture_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("03f43c0f-354d-4d3f-aa32-158698add9ac"), false, new Guid("e3db1466-78f5-45ab-997b-c0334555ea55"), "//div[@class='img_box']/a[@class='zoom_js']/img/@src" },
                    { new Guid("348be02e-1fc3-4ce1-b9b6-e2c544c2b472"), true, new Guid("9315fdbb-e46f-4513-8420-ddbcc0318a30"), "//picture/img/@src" },
                    { new Guid("4931db7f-1dc0-437d-8342-d5a35a4c5dcc"), false, new Guid("f47e776e-f731-4186-a675-7a61f6756a68"), "//figure//img/@src" },
                    { new Guid("4f993f39-24fe-48ed-8e5e-590c7c163aec"), false, new Guid("c35f7865-8454-4aa8-a87f-081d20ea0ac6"), "//img[@itemprop='image']/@src" },
                    { new Guid("5cdb875e-fe14-48e0-b673-2e280c34446f"), false, new Guid("4a9c502d-182d-45f8-b574-357b75cc5c2e"), "//div[contains(@class, 'HeaderMedia_image')]//img[contains(@class, 'Image_image')]/@src" },
                    { new Guid("63cb56fc-1414-47ad-9b12-5d3e4f4be52d"), false, new Guid("79d0e094-f8d7-4857-8a78-2fa85ca75da7"), "//article//header/div[@class='article-head__photo']/img/@src" },
                    { new Guid("7d5b62e9-10c6-47bd-8176-80b7de505c0f"), true, new Guid("ca22af7f-1d1f-4e94-980e-2d910c8d775b"), "//a[@class='glightbox']/img[contains(@class, 'pub-cover')]/@src" },
                    { new Guid("7e2800e5-ab04-43ec-883a-d7d54536e46e"), true, new Guid("925d85ba-1b2d-47c6-a67d-f4ecea0a7737"), "//div[contains(@class, 'big_photo')]//div[@class='big_photo__img']//img/@src" },
                    { new Guid("7f6a9d6d-ecc9-4271-85d3-3de6fff959bf"), false, new Guid("fe028391-1d68-4212-83e0-270832a78c2b"), "//div[contains(@class, 'full-article')]/div[contains(@class, 'gallery')]/picture/img/@src" },
                    { new Guid("88e9537c-5a45-477b-9bb1-381e9c0e235e"), true, new Guid("e5b5dfab-8121-47d9-96d9-aecc6f4959fa"), "//div[@itemprop='articleBody']//div[@itemprop='image']/picture/img[@itemprop='contentUrl']/@src" },
                    { new Guid("8f84e7a4-6116-4913-81cc-7bd55e5aff13"), true, new Guid("54e3ee89-0964-4d16-85a5-fe411bb2aa91"), "//meta[@property='og:image']/@content" },
                    { new Guid("929a436c-2b7c-4206-b0df-d0b3804f780d"), false, new Guid("007b3a5a-5541-4c33-8074-c071ac21a7f9"), "//div[contains(@class, 'topic-body__title-image')]//img[contains(@class, 'picture__image')]/@src" },
                    { new Guid("936cd1db-e7fe-4a5f-92ed-b966e7ad61ff"), true, new Guid("a35233d9-911e-4d7a-bb48-84c4e2cd892e"), "//header//figure//picture/img/@src" },
                    { new Guid("9bd37ed1-0983-4f56-8db5-6a626bd0ebb7"), false, new Guid("4e3c0ae9-2df7-48be-923d-d734249dd2ee"), "//div[@class='photoview__open']/img/@src" },
                    { new Guid("ace2f324-69f8-4b42-827f-6756749ad09d"), true, new Guid("37624e88-06d7-440e-a686-c0732673e7e1"), "//div[contains(@class, 'article__lede-wrapper')]//picture/img/@src" },
                    { new Guid("b38dd29d-3e7e-4367-8e44-707b56a23730"), false, new Guid("eadf0a4a-1419-491a-89ed-2821a661f0f6"), "//div[@class='b_article-media']//div[@class='mainarea-wrapper']/figure/img[@class='item-image-front']/@src" },
                    { new Guid("b52707cf-4a04-4064-8c24-42303a50d825"), true, new Guid("28d0b9f2-f3b5-432d-a6e3-0977657e4e6f"), "//div[contains(@class, 'newsMediaContainer')]/img/@src" },
                    { new Guid("b9f1ed8b-ac34-4bb2-90d3-b706e19744a2"), false, new Guid("2c6df20a-dd41-4742-a081-4a4295f93522"), "//article//div[@class='image-con' and position() = 1]/picture/img/@src" },
                    { new Guid("cb9f7b5b-df29-4c3f-814e-63aabba7b6d5"), false, new Guid("69cc661a-fb9f-4310-bcc1-67efea1a4e30"), "//article//header/div[contains(@class, 'styles_cover_media')]/img/@src" },
                    { new Guid("cbaf493e-f0fe-450e-8da0-2d6d8cb438a8"), false, new Guid("97fe792b-ff52-4a9e-85e9-852691241616"), "//div[@class='b-material-incut-m-image']//@src" },
                    { new Guid("e41d6196-9f7f-40a2-b4c3-d578b40b8e21"), false, new Guid("98bb0174-82fc-43bf-8f36-40413c5a64d0"), "//article/figure/img/@src" },
                    { new Guid("f7af3aaf-79f0-49e5-93a8-d26d5630c5f0"), false, new Guid("ec2311c8-3a76-4cc5-9220-527a1c3e799d"), "//div[@class='inner_content']//div[@class='main_img']//img/@src" },
                    { new Guid("faf5e01f-19d5-435a-af84-1fb0fb700f01"), true, new Guid("a0387851-c771-47c2-b47f-ab64355f892a"), "//div[@class='article__media']//img/@src" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "published_at_culture_info", "published_at_time_zone_info_id", "published_at_x_path" },
                values: new object[,]
                {
                    { new Guid("072f29e3-9b07-4473-a4de-18d503e94959"), true, new Guid("4e3c0ae9-2df7-48be-923d-d734249dd2ee"), "ru-RU", "Russian Standard Time", "//div[@class='article__info']//div[@class='article__info-date']/a/text()" },
                    { new Guid("0776d29a-4707-4068-bcfd-349ec7d02b86"), true, new Guid("9315fdbb-e46f-4513-8420-ddbcc0318a30"), "ru-RU", "Russian Standard Time", "//div[@class='b-text__date']/text()" },
                    { new Guid("0995ad7a-5403-4b1b-b6c0-9c6714807728"), true, new Guid("ec2311c8-3a76-4cc5-9220-527a1c3e799d"), "ru-RU", "Russian Standard Time", "//div[@class='date_full']/text()" },
                    { new Guid("0c3b40fe-817f-48e2-af85-3d023332a958"), true, new Guid("69cc661a-fb9f-4310-bcc1-67efea1a4e30"), "ru-RU", "UTC", "//article//header//div[contains(@class, 'styles_meta')]//div[contains(@class, 'styles_metaItem')]/text()" },
                    { new Guid("0c9d1c96-4f87-4f6b-b037-3474c0227db5"), true, new Guid("3e09a3ba-ec3b-4a56-aa92-e24db5d0e1fc"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'article__date-autor-shortcode')]/div[contains(@class, 'article__date')]/time[@class='date']/@datetime" },
                    { new Guid("0d6d5303-a517-45d6-939e-84cc3b9a1664"), true, new Guid("97fe792b-ff52-4a9e-85e9-852691241616"), "ru-RU", "Russian Standard Time", "//p[@class='b-material__date']/text()" },
                    { new Guid("0fdd2655-e677-47a3-8eb8-85a78485afc8"), true, new Guid("37624e88-06d7-440e-a686-c0732673e7e1"), "en-US", "Eastern Standard Time", "//div[@class='headline__footer']//div[contains(@class, 'headline__byline-sub-text')]/div[@class='timestamp']/text()" },
                    { new Guid("1252e9fe-b95b-48c4-a93d-6cbaeea18917"), true, new Guid("56f0cb28-ff88-4710-b696-777657256918"), "ru-RU", "Russian Standard Time", "//article[@itemprop='articleBody']/meta[@itemprop='datePublished']/@content" },
                    { new Guid("19a5adac-4e1c-42c2-bf33-d43f8a37fe57"), true, new Guid("eadf0a4a-1419-491a-89ed-2821a661f0f6"), "ru-RU", null, "//article/div[@class='b_article-header']//time[@itemprop='datePublished']/@datetime" },
                    { new Guid("2286bb66-dead-4101-949d-59fd4f38ac15"), true, new Guid("536d7436-a908-4cb7-be60-4ed6691e3a5f"), "ru-RU", null, "//div[@class='doc_header__time']/time[@class='doc_header__publish_time']/@datetime" },
                    { new Guid("233a6e22-d2bb-44bb-bbca-be2e5082f981"), true, new Guid("a35233d9-911e-4d7a-bb48-84c4e2cd892e"), "en-US", null, "//time/@datetime" },
                    { new Guid("2dd4a8d5-479e-42e4-9115-e2d2feb6bc19"), true, new Guid("f47e776e-f731-4186-a675-7a61f6756a68"), "ru-RU", "Ekaterinburg Standard Time", "//div[@itemprop='datePublished']/time/@datetime" },
                    { new Guid("35e49b4b-35d0-4a83-88f8-6ed7c2e46f83"), true, new Guid("006a35f4-b40b-4761-ae70-f0ec1ad7f574"), "ru-RU", null, "//header[@class='news-item__header']//time/@content" },
                    { new Guid("4f68644a-a20e-489c-90cb-3db758b7ac0c"), true, new Guid("7e843443-01fa-4130-acec-c5b420b4379b"), "ru-RU", null, "//div[@class='article__header__info-block']/time[@class='article__header__date']/@datetime" },
                    { new Guid("6ee5c065-ad8f-440c-8c52-748a970b8768"), true, new Guid("007b3a5a-5541-4c33-8074-c071ac21a7f9"), "ru-RU", "Russian Standard Time", "//div[@class='topic-page__header']//a[contains(@class, 'topic-header__time')]/text()" },
                    { new Guid("6effb944-676e-4a0c-8ab7-bcbf5c587d0c"), true, new Guid("98bb0174-82fc-43bf-8f36-40413c5a64d0"), "ru-RU", "Russian Standard Time", "//article/div[@class='header']/span/text()" },
                    { new Guid("81cb7ded-133d-4e6b-8aee-40882c30a1a1"), true, new Guid("e5b5dfab-8121-47d9-96d9-aecc6f4959fa"), "ru-RU", null, "//div[@class='publication-info']/time[@itemprop='datePublished']/@datetime" },
                    { new Guid("9410acba-9faf-4777-b5fc-1e5b24cba4b4"), false, new Guid("ca22af7f-1d1f-4e94-980e-2d910c8d775b"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'pubdatetime')]/text()" },
                    { new Guid("9b7f7645-c4fe-4eb7-9f6e-f72b45f55a46"), true, new Guid("c35f7865-8454-4aa8-a87f-081d20ea0ac6"), "ru-RU", null, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']/span[@itemprop='datePublished']/@content" },
                    { new Guid("a005060b-4bc7-4062-848d-b1d00073acbf"), true, new Guid("c9e7dbbc-7c81-41c2-9682-8bb2079b7d76"), "ru-RU", "Russian Standard Time", "//div[@class='b-article__top-author']/p[@class='date']/text()" },
                    { new Guid("a7b50af4-7a6d-4696-9b2b-426329655aa2"), true, new Guid("fe028391-1d68-4212-83e0-270832a78c2b"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'full-article')]//time/text()" },
                    { new Guid("a8f65a30-18c8-4053-910d-c7aad1c9aaa6"), true, new Guid("b729d17e-19a3-493e-9364-2cb21a0f8ae2"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'PageArticleContent_date')]/text()" },
                    { new Guid("b356d55a-54be-4523-bcc3-e518e4a1d0f4"), true, new Guid("79d0e094-f8d7-4857-8a78-2fa85ca75da7"), "ru-RU", "Russian Standard Time", "//article//header//time[@class='article-head__date']/text()" },
                    { new Guid("cb2ca541-fb9b-4529-b53b-7bb8f2cf41e1"), true, new Guid("54e3ee89-0964-4d16-85a5-fe411bb2aa91"), "ru-RU", null, "//article/header//time/@datetime" },
                    { new Guid("cca3df2d-cdb0-4793-afef-82798489424c"), true, new Guid("2c6df20a-dd41-4742-a081-4a4295f93522"), "en-US", "Central Europe Standard Time", "//article//div[@class='article-info']/div[@class='date']/text()" },
                    { new Guid("dc32bacd-4064-48de-992a-9a5ce45d5d1d"), true, new Guid("925d85ba-1b2d-47c6-a67d-f4ecea0a7737"), "ru-RU", null, "//div[@class='article_page__left__top__left']//div[@class='article_page__left__top__time']//time/@datetime" },
                    { new Guid("dca0d0df-2f51-4329-b43f-d9fc7cc27c6f"), true, new Guid("28d0b9f2-f3b5-432d-a6e3-0977657e4e6f"), "ru-RU", null, "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("f2f8f115-9d12-4f8f-abac-68f0cf127634"), true, new Guid("4a9c502d-182d-45f8-b574-357b75cc5c2e"), "ru-RU", "UTC", "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark')]//span[@ca-ts]/text()" },
                    { new Guid("f908a2ed-849c-498e-864c-1126a52ab3b8"), true, new Guid("a0387851-c771-47c2-b47f-ab64355f892a"), "ru-RU", "Russian Standard Time", "//div[@class='article__meta']/time/text()" },
                    { new Guid("feac238c-65f8-48d0-8c6e-7b1d96912b8d"), true, new Guid("e3db1466-78f5-45ab-997b-c0334555ea55"), "ru-RU", "Russian Standard Time", "//div[@class='article_top']//div[@class='date']//time/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_sub_title_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("0e233b4d-335e-4fb2-9f7f-1e1080cbc3d5"), false, new Guid("c9e7dbbc-7c81-41c2-9682-8bb2079b7d76"), "//h4/text()" },
                    { new Guid("229f46b4-fdc0-4faf-b07b-5935505cce06"), false, new Guid("536d7436-a908-4cb7-be60-4ed6691e3a5f"), "//header[@class='doc_header']/h2[contains(@class, 'doc_header__subheader')]/text()" },
                    { new Guid("254afe6f-ecbd-4c26-b030-1943bba4198b"), true, new Guid("c35f7865-8454-4aa8-a87f-081d20ea0ac6"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()=1]/text()" },
                    { new Guid("2aab9e99-80e5-40f5-9ae0-d2cbb263677b"), true, new Guid("fe028391-1d68-4212-83e0-270832a78c2b"), "//h1/text()" },
                    { new Guid("38b2bd64-eee9-49dc-8b5d-e022cb3cf6e9"), true, new Guid("2c6df20a-dd41-4742-a081-4a4295f93522"), "//p[@class='headertext' and @itemprop='description']/text()" },
                    { new Guid("450c62e1-a340-4db4-b7e3-7e502f5679b0"), true, new Guid("eadf0a4a-1419-491a-89ed-2821a661f0f6"), "//h2/text()" },
                    { new Guid("5469eb83-35db-4ceb-a569-2e3e9e5a22ef"), false, new Guid("007b3a5a-5541-4c33-8074-c071ac21a7f9"), "//div[contains(@class, 'topic-body__title')]/text()" },
                    { new Guid("68b8ad89-baab-4234-a202-a19815cf9e94"), true, new Guid("3e09a3ba-ec3b-4a56-aa92-e24db5d0e1fc"), "//div[contains(@class, 'article__summary')]/text()" },
                    { new Guid("6a817fa8-85e6-4d9d-81d6-07d3582b74df"), false, new Guid("69cc661a-fb9f-4310-bcc1-67efea1a4e30"), "//article//header//p[contains(@class, 'styles_subtitle')]/text()" },
                    { new Guid("74262d1e-f10d-444c-a522-1472a4e6db65"), true, new Guid("4e3c0ae9-2df7-48be-923d-d734249dd2ee"), "//h1[@class='article__second-title']/text()" },
                    { new Guid("79961c74-f737-4cdb-9245-7592f60b24ff"), true, new Guid("54e3ee89-0964-4d16-85a5-fe411bb2aa91"), "//div[contains(@class, 'js-mediator-article')]/*[position()=1]/text()" },
                    { new Guid("aa1d7a7d-553c-4681-8c90-000fe775ed90"), false, new Guid("b729d17e-19a3-493e-9364-2cb21a0f8ae2"), "//div[contains(@class, 'PageArticleContent_lead')]/text()" },
                    { new Guid("ace5a4e1-d516-47b1-a72e-25548cc92207"), true, new Guid("ca22af7f-1d1f-4e94-980e-2d910c8d775b"), "//div[@class='container-fluid shifted']/p[@class='announce lead']/text()" },
                    { new Guid("ad231fe9-9bcf-4a46-a43e-14261da3a609"), true, new Guid("28d0b9f2-f3b5-432d-a6e3-0977657e4e6f"), "//div[@itemprop='alternativeHeadline']/text()" },
                    { new Guid("b5df5f5f-7ca9-41fc-a82e-afe4f377099e"), false, new Guid("98bb0174-82fc-43bf-8f36-40413c5a64d0"), "//h4/text()" },
                    { new Guid("bab005c4-1018-4080-bb75-9897714e6849"), true, new Guid("a35233d9-911e-4d7a-bb48-84c4e2cd892e"), "//header/p[@id='article-summary']/text()" },
                    { new Guid("c5e4c559-3829-4818-a177-21e2aa2a13ca"), false, new Guid("4a9c502d-182d-45f8-b574-357b75cc5c2e"), "//h3/text()" },
                    { new Guid("cd8bea32-f417-4689-befc-2122ec1a811d"), true, new Guid("f47e776e-f731-4186-a675-7a61f6756a68"), "//p[@itemprop='alternativeHeadline']/span/text()" },
                    { new Guid("e08a40ac-f0ea-4284-a349-4d7925b513cb"), true, new Guid("a0387851-c771-47c2-b47f-ab64355f892a"), "//div[@class='article__intro']/p/text()" },
                    { new Guid("f7126b2e-1e46-4791-9774-94a093d33228"), false, new Guid("7e843443-01fa-4130-acec-c5b420b4379b"), "//div[contains(@class, 'article__text')]/div[@class='article__text__overview']/span/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_video_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[] { new Guid("ae891401-0178-4313-a865-4f01e9396c0e"), false, new Guid("2c6df20a-dd41-4742-a081-4a4295f93522"), "//article//div[@class='videoWrapper' and @itemprop='video']/iframe[@class='video']/@src" });

            migrationBuilder.InsertData(
                table: "news_parse_modified_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_modified_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("1b9f55cc-73f1-4fc8-8a06-4139972875c9"), "(\"обновлено:\" HH:mm dd.MM.yyyy)", new Guid("538eaa09-4874-42d4-bb55-ec7d3c99b165") },
                    { new Guid("28cd5578-992d-43cd-a5f2-2793365f55b6"), "\"обновлено\" HH:mm , dd.MM", new Guid("e3886f10-f9a0-4a79-8222-be0627483ea4") },
                    { new Guid("4b12556a-17fe-4091-a65e-de7727ca5025"), "\"обновлено\" d MMMM yyyy, HH:mm", new Guid("5a2a332a-f99b-43ae-8558-032646590b7f") },
                    { new Guid("4c746339-be6b-46e8-88b1-8bf11fbb1824"), "\"обновлено\" d MMMM, HH:mm", new Guid("5a2a332a-f99b-43ae-8558-032646590b7f") },
                    { new Guid("f128199e-d635-495d-b1cd-5fa08b993b92"), "\"обновлено\" HH:mm , dd.MM.yyyy", new Guid("e3886f10-f9a0-4a79-8222-be0627483ea4") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_published_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("011ca840-a652-42a7-899b-1c99b96db05b"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("19a5adac-4e1c-42c2-bf33-d43f8a37fe57") },
                    { new Guid("029ed727-7318-4262-9fea-2795ecf124b2"), "d MMMM, HH:mm", new Guid("f2f8f115-9d12-4f8f-abac-68f0cf127634") },
                    { new Guid("033e2644-b4bc-494c-b0cc-d136c7ebc18a"), "dd.MM.yyyy HH:mm", new Guid("a7b50af4-7a6d-4696-9b2b-426329655aa2") },
                    { new Guid("06fbc9fe-7e6e-4020-9388-c73bdc122c34"), "HH:mm, d MMMM yyyy", new Guid("6ee5c065-ad8f-440c-8c52-748a970b8768") },
                    { new Guid("0db3979a-17fe-4d1f-93d0-8a89929ed354"), "d MMMM yyyy, HH:mm", new Guid("6effb944-676e-4a0c-8ab7-bcbf5c587d0c") },
                    { new Guid("0f708f95-17c3-4e29-aa8a-1d92c7a31e98"), "d MMMM yyyy, HH:mm", new Guid("f2f8f115-9d12-4f8f-abac-68f0cf127634") },
                    { new Guid("0f7916eb-3bdd-4248-8977-241c2e2284e3"), "dd MMMM yyyy HH:mm", new Guid("f908a2ed-849c-498e-864c-1126a52ab3b8") },
                    { new Guid("114680a9-6ae4-48e5-96a6-edaef3250aae"), "d MMMM yyyy, HH:mm \"МСК\"", new Guid("b356d55a-54be-4523-bcc3-e518e4a1d0f4") },
                    { new Guid("18a6ed83-8a46-433e-ab21-dbf9954e9cf1"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("9b7f7645-c4fe-4eb7-9f6e-f72b45f55a46") },
                    { new Guid("19b58c82-4467-42d1-8e0f-d3b50f65df81"), "d-M-yyyy HH:mm", new Guid("cca3df2d-cdb0-4793-afef-82798489424c") },
                    { new Guid("3168ef9e-19f3-4484-8e85-018b5e1f30d3"), "yyyy-MM-ddTHH:mm:ss", new Guid("1252e9fe-b95b-48c4-a93d-6cbaeea18917") },
                    { new Guid("37e066bd-cd44-4d9b-bd2d-4c725e125410"), "dd MMMM yyyy, HH:mm", new Guid("0995ad7a-5403-4b1b-b6c0-9c6714807728") },
                    { new Guid("391ac5ad-7ed2-4839-8856-b9e7c27d5261"), "d MMMM yyyy HH:mm", new Guid("0776d29a-4707-4068-bcfd-349ec7d02b86") },
                    { new Guid("3d582e6b-ab60-452c-ac51-6f0d5e438ed2"), "dd.MM.yyyy HH:mm", new Guid("feac238c-65f8-48d0-8c6e-7b1d96912b8d") },
                    { new Guid("3f5bba28-ed2c-4560-ae86-9132f399be97"), "d MMMM  HH:mm", new Guid("0776d29a-4707-4068-bcfd-349ec7d02b86") },
                    { new Guid("5c0cdf29-d504-4aaf-91ad-74c2aa55cb5d"), "\"Published\n       \" HH:mm tt \"EST\", ddd MMMM d, yyyy", new Guid("0fdd2655-e677-47a3-8eb8-85a78485afc8") },
                    { new Guid("5e59bbef-0c47-4382-a4a9-dbb2faf4f2b7"), "HH:mm dd.MM.yyyy", new Guid("072f29e3-9b07-4473-a4de-18d503e94959") },
                    { new Guid("62421e6a-7f6c-4c83-9431-9e024902e86a"), "HH:mm", new Guid("f908a2ed-849c-498e-864c-1126a52ab3b8") },
                    { new Guid("62ef8351-6925-4b35-a22a-9d891903c084"), "d MMMM, HH:mm,", new Guid("f2f8f115-9d12-4f8f-abac-68f0cf127634") },
                    { new Guid("731e6a29-cba7-4306-955f-00d13c675b3d"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("dca0d0df-2f51-4329-b43f-d9fc7cc27c6f") },
                    { new Guid("854b5327-7daf-4e5b-bb56-b8b7bb2f2785"), "yyyy-MM-dd HH:mm:ss", new Guid("9410acba-9faf-4777-b5fc-1e5b24cba4b4") },
                    { new Guid("8a932d02-64bf-42dd-8d1f-b7b410118235"), "dd MMMM yyyy, HH:mm", new Guid("0d6d5303-a517-45d6-939e-84cc3b9a1664") },
                    { new Guid("8c57b9ec-327c-4060-b635-d6d6afe039e8"), "yyyy-MM-ddTHH:mm:ss", new Guid("2dd4a8d5-479e-42e4-9115-e2d2feb6bc19") },
                    { new Guid("8fd49876-d1b7-4155-bc12-006d619538ed"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("35e49b4b-35d0-4a83-88f8-6ed7c2e46f83") },
                    { new Guid("9d05aafb-5ecc-4da5-aa0f-ad8550a5e302"), "d MMMM yyyy \"в\" HH:mm", new Guid("a005060b-4bc7-4062-848d-b1d00073acbf") },
                    { new Guid("a51a28a4-977b-4374-b4d2-c9a5fb4fcf4a"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("4f68644a-a20e-489c-90cb-3db758b7ac0c") },
                    { new Guid("a9092c1b-40fa-4676-b1ab-2809b3f6b497"), "d MMMM, HH:mm", new Guid("0c3b40fe-817f-48e2-af85-3d023332a958") },
                    { new Guid("ad082536-ce9f-4976-a096-ee0b0cd9cbe2"), "HH:mm", new Guid("0d6d5303-a517-45d6-939e-84cc3b9a1664") },
                    { new Guid("b38edd64-a634-41e3-a992-1fab6d7dd07d"), "dd.MM.yyyy HH:mm", new Guid("a8f65a30-18c8-4053-910d-c7aad1c9aaa6") },
                    { new Guid("b571b737-e402-4b0c-b03d-66c5379a0189"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("2286bb66-dead-4101-949d-59fd4f38ac15") },
                    { new Guid("b595be6c-e38a-4bcd-ba40-e55a9bdb6537"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("81cb7ded-133d-4e6b-8aee-40882c30a1a1") },
                    { new Guid("bee934c3-8bf2-4293-b115-5e97e572b5e2"), "yyyy-MM-d HH:mm", new Guid("0c9d1c96-4f87-4f6b-b037-3474c0227db5") },
                    { new Guid("bf3a43fa-8cfb-4506-bbe5-5186d99a373e"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("dc32bacd-4064-48de-992a-9a5ce45d5d1d") },
                    { new Guid("c6b97bdd-9499-4718-81ea-4bb147a6d9dc"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("233a6e22-d2bb-44bb-bbca-be2e5082f981") },
                    { new Guid("d6934438-a1e5-46da-b0db-08fa276cdb68"), "yyyy-MM-ddTHH:mm:ss.fffZ", new Guid("cb2ca541-fb9b-4529-b53b-7bb8f2cf41e1") },
                    { new Guid("e4807baa-b6d5-404e-87a7-c4a0316a4076"), "d MMMM yyyy, HH:mm,", new Guid("f2f8f115-9d12-4f8f-abac-68f0cf127634") },
                    { new Guid("e696a727-9794-4467-beee-706421e7b420"), "d MMMM yyyy, HH:mm", new Guid("0c3b40fe-817f-48e2-af85-3d023332a958") },
                    { new Guid("f9660507-5d4d-476b-a6c4-a9237278b7a3"), "dd MMMM, HH:mm", new Guid("0d6d5303-a517-45d6-939e-84cc3b9a1664") }
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
