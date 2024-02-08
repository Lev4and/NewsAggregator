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
                    { new Guid("012bc825-0a21-4006-8178-e45e7736e5be"), true, "https://ura.news/", "Ura.ru" },
                    { new Guid("05f7dcf8-55bb-4fcb-bce3-711e597db407"), true, "https://www.interfax.ru/", "Интерфакс" },
                    { new Guid("0809b166-0bf7-437e-9e16-463505e0d507"), true, "https://www.sports.ru/", "Storts.ru" },
                    { new Guid("0c5d99a0-04d1-49ab-818e-44e94b7ff962"), true, "https://tass.ru/", "ТАСС" },
                    { new Guid("1622dfed-cb56-4ceb-a582-cdc1d916bae9"), true, "https://www.gazeta.ru/", "Газета.Ru" },
                    { new Guid("1ada8c4a-62e7-45b4-bf2d-e2f83013ea8c"), true, "https://www.ixbt.com/", "iXBT.com" },
                    { new Guid("3aaf4995-a018-48fe-8fa5-77f922961583"), true, "https://www.belta.by/", "БелТА" },
                    { new Guid("3d3bdccb-02b5-4c74-9f23-c0117d47ebab"), true, "https://www.cybersport.ru/", "Cybersport.ru" },
                    { new Guid("4d1a37f3-5890-4677-982a-b2142867e8e7"), true, "https://74.ru/", "74.ru" },
                    { new Guid("4d22b1f7-871f-4bf6-a8bf-7d98058d84ba"), true, "https://edition.cnn.com/", "CNN" },
                    { new Guid("52f68ae4-fcd3-4ced-811e-51a2ce3f9271"), true, "https://www.1obl.ru/", "Первый областной" },
                    { new Guid("5aa05c63-3407-4c5e-be61-7c0c0a0ca184"), true, "https://russian.rt.com/", "RT на русском" },
                    { new Guid("5e15add7-f754-4572-8f92-3ee677981dd3"), true, "https://3dnews.ru/", "3Dnews.ru" },
                    { new Guid("67a8e2c2-22fb-4e88-83c3-9cec8e2f5980"), true, "https://life.ru/", "Life" },
                    { new Guid("695e3634-ea0e-48b2-9a5f-ce0bae5a1beb"), true, "https://vz.ru/", "ВЗГЛЯД.РУ" },
                    { new Guid("6ee36679-7428-408c-a667-4e85a5d4bd2f"), true, "https://www.pravda.ru/", "Правда.ру" },
                    { new Guid("6f7dde80-fdc6-435c-9165-de16e5fdcd67"), true, "https://tsargrad.tv/", "Царьград" },
                    { new Guid("90110e1d-5129-4e3d-aa9b-ab6608794240"), true, "https://lenta.ru/", "Лента.Ру" },
                    { new Guid("99946b37-2e11-40bd-8f52-40dfd69979b2"), true, "https://aif.ru/", "Аргументы и факты" },
                    { new Guid("abd7c1c0-fe43-4142-b676-b6fd45343e62"), true, "https://ixbt.games/", "iXBT.games" },
                    { new Guid("b1e6c3f7-ed51-4567-affe-ef90e75897b0"), true, "https://rg.ru/", "Российская газета" },
                    { new Guid("c08010a1-aca2-4e8e-862d-fb004e8dbd6e"), true, "https://www.championat.com/", "Чемпионат.com" },
                    { new Guid("c4005c3e-d002-4380-984f-ba44c8a29fcc"), true, "https://svpressa.ru/", "СвободнаяПресса" },
                    { new Guid("c5d3427f-b7d7-4506-bec9-102f2a8b81c3"), true, "https://ria.ru/", "РИА Новости" },
                    { new Guid("ccf92a65-f905-4dda-a8a3-0f49c06b660e"), true, "https://www.nytimes.com/", "The New York Times" },
                    { new Guid("dc08bb45-b806-4c6a-98a1-420739afe64b"), true, "https://www.kommersant.ru/", "Коммерсантъ" },
                    { new Guid("df2ca6ab-b740-425d-bcc3-6dc1f0914923"), true, "https://www.rbc.ru/", "РБК" },
                    { new Guid("e7872d23-7546-4384-a1ca-2e7e1e4b4493"), true, "https://iz.ru/", "Известия" },
                    { new Guid("ebea8e7d-692e-418f-8a25-ddba70e174e9"), true, "https://www.hltv.org/", "HLTV.org" },
                    { new Guid("f804205f-80f2-4e66-ae29-41f83c5ab67a"), true, "https://www.m24.ru/", "Москва 24" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_settings",
                columns: new[] { "id", "description_x_path", "source_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("138196a1-bcd0-476c-be15-8209de199d60"), "//div[contains(@class, 'container-fluid shifted') and not(p[@class='announce lead']) and not(h1) and not(hr)]", new Guid("abd7c1c0-fe43-4142-b676-b6fd45343e62"), "//h1/text()" },
                    { new Guid("1541f78b-b3db-4bd1-be09-325723dbcb8e"), "//div[@class='js-mediator-article']", new Guid("3aaf4995-a018-48fe-8fa5-77f922961583"), "//h1/text()" },
                    { new Guid("173516b7-36ab-4d1d-8e5c-d9904b9549f8"), "//div[@itemprop='articleBody']/*", new Guid("52f68ae4-fcd3-4ced-811e-51a2ce3f9271"), "//h1[@itemprop='headline']/text()" },
                    { new Guid("1f07dc2d-efec-44ad-9716-40804a4acf07"), "//section[@name='articleBody']/*", new Guid("ccf92a65-f905-4dda-a8a3-0f49c06b660e"), "//h1/text()" },
                    { new Guid("2074b9da-b3a1-41bd-94e1-16e15cec533e"), "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]", new Guid("05f7dcf8-55bb-4fcb-bce3-711e597db407"), "//h1/text()" },
                    { new Guid("2c2ea3b8-1135-4ed2-8748-75a0aa585214"), "//article/div[@class='news_text']", new Guid("695e3634-ea0e-48b2-9a5f-ce0bae5a1beb"), "//h1/text()" },
                    { new Guid("2f47781a-aa13-41a3-aef5-87fb50195e17"), "//div[contains(@class, 'news-item__content')]", new Guid("0809b166-0bf7-437e-9e16-463505e0d507"), "//h1/text()" },
                    { new Guid("43ad817b-830c-4f7d-a3bd-3b1f0faa441d"), "//div[contains(@class, 'PageContentCommonStyling_text')]", new Guid("b1e6c3f7-ed51-4567-affe-ef90e75897b0"), "//h1/text()" },
                    { new Guid("44751716-8fa8-49a3-9c46-e25f6002bdbb"), "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]", new Guid("6ee36679-7428-408c-a667-4e85a5d4bd2f"), "//h1/text()" },
                    { new Guid("4abde494-e1fd-435a-b0f9-9921c8a3de1a"), "//div[contains(@class, 'js-mediator-article')]/*[position()>1]", new Guid("3d3bdccb-02b5-4c74-9f23-c0117d47ebab"), "//h1/text()" },
                    { new Guid("4ebd46d3-4c15-4111-a01c-460a06b9bd2f"), "//div[contains(@class, 'article__body')]", new Guid("c5d3427f-b7d7-4506-bec9-102f2a8b81c3"), "//div[@class='article__title']/text()" },
                    { new Guid("52373fb1-cd9a-4ac9-adea-eca235fa0bab"), "//article/div[@class='article-content']/*[not(@class)]", new Guid("c08010a1-aca2-4e8e-862d-fb004e8dbd6e"), "//article/header/div[@class='article-head__title']/text()" },
                    { new Guid("5ddd6a70-d9c6-4bd7-8329-eac27fe95267"), "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]", new Guid("67a8e2c2-22fb-4e88-83c3-9cec8e2f5980"), "//h1/text()" },
                    { new Guid("5fe6d8cb-de7e-4f1c-a221-7f221174d5ab"), "//div[@class='article_text']", new Guid("99946b37-2e11-40bd-8f52-40dfd69979b2"), "//h1/text()" },
                    { new Guid("6bb35eb9-688b-4773-9bc2-bb7e0aaf6ae8"), "//div[@itemprop='articleBody']/*", new Guid("1ada8c4a-62e7-45b4-bf2d-e2f83013ea8c"), "//h1/text()" },
                    { new Guid("7138d587-06ea-4001-8ce0-87a488ea9cfe"), "//article/*", new Guid("0c5d99a0-04d1-49ab-818e-44e94b7ff962"), "//h1/text()" },
                    { new Guid("75e5df1e-275e-4553-84c7-e4196dd6d6ce"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()>1]", new Guid("5e15add7-f754-4572-8f92-3ee677981dd3"), "//h1/text()" },
                    { new Guid("7ef111f4-2921-418a-8734-2a0c9ba1cb8b"), "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]", new Guid("f804205f-80f2-4e66-ae29-41f83c5ab67a"), "//h1/text()" },
                    { new Guid("87c0553e-8864-4a06-a0b8-90fad746fbeb"), "//div[@itemprop='articleBody']/*", new Guid("4d22b1f7-871f-4bf6-a8bf-7d98058d84ba"), "//h1/text()" },
                    { new Guid("a40ac08c-69b4-4465-a751-49b4e70c26ef"), "//div[contains(@class, 'article__text ')]", new Guid("5aa05c63-3407-4c5e-be61-7c0c0a0ca184"), "//h1/text()" },
                    { new Guid("a65db7d8-91e6-4950-93cd-91a440a0c040"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]", new Guid("6f7dde80-fdc6-435c-9165-de16e5fdcd67"), "//h1[@class='article__title']/text()" },
                    { new Guid("b4580d0d-f69a-4f3c-bd19-f4513d413a46"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]", new Guid("dc08bb45-b806-4c6a-98a1-420739afe64b"), "//h1/text()" },
                    { new Guid("c25171a1-027c-4668-9b8c-5529c03b4b05"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview'))]", new Guid("df2ca6ab-b740-425d-bcc3-6dc1f0914923"), "//h1/text()" },
                    { new Guid("c9c58939-3e33-4fce-8da8-8db8826df031"), "//div[@itemprop='articleBody']/*[not(name()='div')]", new Guid("012bc825-0a21-4006-8178-e45e7736e5be"), "//h1/text()" },
                    { new Guid("ce6f725a-1015-412c-a1b8-c8f88a02758b"), "//div[@itemprop='articleBody']/*", new Guid("1622dfed-cb56-4ceb-a582-cdc1d916bae9"), "//h1/text()" },
                    { new Guid("d3ef3c08-5ec4-47d1-9fc8-650c7028cacb"), "//article//div[@class='newstext-con']/*[position()>2]", new Guid("ebea8e7d-692e-418f-8a25-ddba70e174e9"), "//h1[@class='headline']/text()" },
                    { new Guid("e303fcb9-bb0d-46b8-b371-f7b8d855fc8d"), "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]", new Guid("c4005c3e-d002-4380-984f-ba44c8a29fcc"), "//h1[@class='b-text__title']/text()" },
                    { new Guid("ec6b15e0-d3ae-440d-bbac-4e263a79c76a"), "//div[@class='topic-body__content']", new Guid("90110e1d-5129-4e3d-aa9b-ab6608794240"), "//h1[@class='topic-body__titles']/span[@class='topic-body__title']/text()" },
                    { new Guid("ee0f8000-a0af-43bb-90f7-d0773d6a4f14"), "//div[@itemprop='articleBody']/*", new Guid("e7872d23-7546-4384-a1ca-2e7e1e4b4493"), "//h1/span/text()" },
                    { new Guid("f36fd2ae-8e84-49b8-894a-1ceadd9b4e11"), "//div[@itemprop='articleBody']/*[not(name() = 'figure')]", new Guid("4d1a37f3-5890-4677-982a-b2142867e8e7"), "//h1[@itemprop='headline']/span/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_search_settings",
                columns: new[] { "id", "news_site_url", "news_url_x_path", "source_id" },
                values: new object[,]
                {
                    { new Guid("00a50d94-e1a6-438f-9218-1c3551bc7690"), "https://tass.ru/", "//a[contains(@class, 'tass_pkg_link-v5WdK') and contains(substring(@href, 2), '/') and not(contains(@href, '/spec/')) and not(contains(@href, 'spec.tass.ru'))]/@href", new Guid("0c5d99a0-04d1-49ab-818e-44e94b7ff962") },
                    { new Guid("01375ee9-1bcb-4d66-9f98-4769e30d4098"), "https://lenta.ru/", "//a[starts-with(@href, '/news/')]/@href", new Guid("90110e1d-5129-4e3d-aa9b-ab6608794240") },
                    { new Guid("014d0489-b430-4574-872b-3aa1b7f84c25"), "https://www.sports.ru/news/", "//a[contains(@href, '.html') and not(contains(@href, '.html#comments')) and not (contains(@href, '/blogs/'))]/@href", new Guid("0809b166-0bf7-437e-9e16-463505e0d507") },
                    { new Guid("078b0d23-c9e4-465a-82b7-059f3e3a0112"), "https://life.ru/s/novosti", "//a[contains(@href, '/p/')]/@href", new Guid("67a8e2c2-22fb-4e88-83c3-9cec8e2f5980") },
                    { new Guid("0aac94d2-927c-48cc-818c-68a907c727b0"), "https://iz.ru/news/", "//a[contains(@href, '?main_click')]/@href", new Guid("e7872d23-7546-4384-a1ca-2e7e1e4b4493") },
                    { new Guid("25465733-5c16-4c48-9e5b-6b929c1ee8b1"), "https://ria.ru/", "//a[contains(@class, 'cell-list__item-link')]/@href", new Guid("c5d3427f-b7d7-4506-bec9-102f2a8b81c3") },
                    { new Guid("49ff12ec-c4ed-4cd9-9a2e-a2e9f3105944"), "https://www.rbc.ru/", "//a[contains(@href, 'https://www.rbc.ru/') and contains(@href, '?from=')]/@href", new Guid("df2ca6ab-b740-425d-bcc3-6dc1f0914923") },
                    { new Guid("61cec1ae-e8dc-4be3-ad02-d4258efaee44"), "https://rg.ru/", "//a[contains(@href, '.html')]/@href", new Guid("b1e6c3f7-ed51-4567-affe-ef90e75897b0") },
                    { new Guid("728ad43b-9f31-4f26-aa4b-20ce43fa37d2"), "https://vz.ru/", "//a[contains(@href, '.html') and not(contains(@href, '#comments')) and not(contains(@href, '?')) and not(contains(@href, '/about/'))]/@href", new Guid("695e3634-ea0e-48b2-9a5f-ce0bae5a1beb") },
                    { new Guid("79ae11be-5343-4ea1-a896-fc63a4dd4e40"), "https://www.gazeta.ru/news/", "//a[contains(@href, '/news/') and contains(@href, '.shtml') and not(contains(@href, '?'))]/@href", new Guid("1622dfed-cb56-4ceb-a582-cdc1d916bae9") },
                    { new Guid("7e43feea-6e2f-4f0f-8dd6-4e4c35060516"), "https://www.belta.by/", "//a[contains(@href, 'https://www.belta.by/') and contains(@href, '/view/')]/@href", new Guid("3aaf4995-a018-48fe-8fa5-77f922961583") },
                    { new Guid("822a4e7a-461e-4a48-92a0-12a1cd1a17aa"), "https://www.m24.ru/", "//a[contains(@href, '/news/')]/@href", new Guid("f804205f-80f2-4e66-ae29-41f83c5ab67a") },
                    { new Guid("87163831-3ac2-4fd8-8b7a-081e10f61b84"), "https://ixbt.games/news/", "//a[@class='card-link']/@href", new Guid("abd7c1c0-fe43-4142-b676-b6fd45343e62") },
                    { new Guid("8d196049-60ad-4ee6-b4c8-f04be58a0374"), "https://74.ru/", "//a[starts-with(@href, '/text/') and not(contains(@href, '?')) and not(contains(@href, 'comments/')) and not(@href='/text/')]/@href", new Guid("4d1a37f3-5890-4677-982a-b2142867e8e7") },
                    { new Guid("95b6fece-3daa-4176-bb44-89ea35f0abd6"), "https://www.kommersant.ru/", "//a[contains(@href, '/doc/') and contains(@href, '?from=')]/@href", new Guid("dc08bb45-b806-4c6a-98a1-420739afe64b") },
                    { new Guid("99d42ffa-fbbb-44cc-8951-6b1739c6bc63"), "https://www.hltv.org/", "//a[contains(@href, '/news/')]/@href", new Guid("ebea8e7d-692e-418f-8a25-ddba70e174e9") },
                    { new Guid("9ce59dad-359e-4bf9-8dc5-fde642c52511"), "https://russian.rt.com/", "//a[contains(@class, 'link') and contains(@href, 'news/')]/@href", new Guid("5aa05c63-3407-4c5e-be61-7c0c0a0ca184") },
                    { new Guid("a25250cc-694d-4622-a128-768bcdf76b83"), "https://edition.cnn.com/", "//a[contains(@href, '.html')]/@href", new Guid("4d22b1f7-871f-4bf6-a8bf-7d98058d84ba") },
                    { new Guid("aa0ce3ff-a9b7-4077-b9ca-855515e031f4"), "https://ura.news/", "//a[contains(@href, '/news/')]/@href", new Guid("012bc825-0a21-4006-8178-e45e7736e5be") },
                    { new Guid("acb78e0e-4d1f-4b6f-8082-415033218b83"), "https://aif.ru/", "//span[contains(@class, 'item_text__title')]/../@href", new Guid("99946b37-2e11-40bd-8f52-40dfd69979b2") },
                    { new Guid("b2c98ce5-4c73-41ec-a992-58f29aae288b"), "https://www.interfax.ru/", "//div[@class='timeline']//a[@tabindex=5]/@href", new Guid("05f7dcf8-55bb-4fcb-bce3-711e597db407") },
                    { new Guid("b7acae56-d2f2-4242-98be-4dfc1b2cacfd"), "https://www.cybersport.ru/", "//a[contains(@href, '/tags/')]/@href", new Guid("3d3bdccb-02b5-4c74-9f23-c0117d47ebab") },
                    { new Guid("c191d2eb-1cf0-48b0-84be-3e79c7b3e286"), "https://tsargrad.tv/", "//a[contains(@class, 'news-item__link')]/@href", new Guid("6f7dde80-fdc6-435c-9165-de16e5fdcd67") },
                    { new Guid("ca1fb577-5f68-4307-9419-f8466ee2ecdb"), "https://www.championat.com/news/1.html?utm_source=button&utm_medium=news", "//a[contains(@href, 'news-') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("c08010a1-aca2-4e8e-862d-fb004e8dbd6e") },
                    { new Guid("dd93c5d7-a9cc-4ab2-b283-1fc872d58733"), "https://www.1obl.ru/news/", "//a[starts-with(@href, '/news/') and not(contains(@href, '?'))]/@href", new Guid("52f68ae4-fcd3-4ced-811e-51a2ce3f9271") },
                    { new Guid("eb816edd-092d-4872-b97a-de7e77e78b0e"), "https://www.nytimes.com/", "//a[contains(@href, '.html')]/@href", new Guid("ccf92a65-f905-4dda-a8a3-0f49c06b660e") },
                    { new Guid("ee07ea41-3d3a-4eba-8f63-ca49f651ab87"), "https://svpressa.ru/all/news/", "//a[contains(@href, '/news/') and not(contains(@href, '?')) and not(starts-with(@href, '/all/news/'))]/@href", new Guid("c4005c3e-d002-4380-984f-ba44c8a29fcc") },
                    { new Guid("f201fb72-c64b-4552-8e92-2ce4482e89d2"), "https://3dnews.ru/news/", "//div[@class='news-feed-all']//a[@class='entry-header']/h1/../@href", new Guid("5e15add7-f754-4572-8f92-3ee677981dd3") },
                    { new Guid("f374897a-9a23-40e6-b366-a57c8e1e527d"), "https://www.ixbt.com/news/", "//a[starts-with(@href, '/news/') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("1ada8c4a-62e7-45b4-bf2d-e2f83013ea8c") },
                    { new Guid("f97eb911-e635-41ad-b972-d027c95c9d74"), "https://www.pravda.ru/", "//a[contains(@href, '/news/') and not(@href='https://www.pravda.ru/news/')]/@href", new Guid("6ee36679-7428-408c-a667-4e85a5d4bd2f") }
                });

            migrationBuilder.InsertData(
                table: "news_source_logos",
                columns: new[] { "id", "source_id", "url" },
                values: new object[,]
                {
                    { new Guid("039812b3-44b7-4a20-a401-8d5a99343503"), new Guid("90110e1d-5129-4e3d-aa9b-ab6608794240"), "https://icdn.lenta.ru/images/icons/icon-256x256.png" },
                    { new Guid("19054bde-8e5c-4da8-ae4b-19c74e62cd53"), new Guid("ccf92a65-f905-4dda-a8a3-0f49c06b660e"), "https://www.nytimes.com/vi-assets/static-assets/apple-touch-icon-28865b72953380a40aa43318108876cb.png" },
                    { new Guid("1b73a01f-e394-4914-8433-5cc5c59b5741"), new Guid("e7872d23-7546-4384-a1ca-2e7e1e4b4493"), "https://cdn.iz.ru/profiles/portal/themes/purple/images/favicons/apple-icon-120x120.png" },
                    { new Guid("28748f24-9fa7-41b5-9cfa-e8a8c38ed875"), new Guid("5e15add7-f754-4572-8f92-3ee677981dd3"), "https://3dnews.ru/assets/images/3dnews_logo_soc.png" },
                    { new Guid("37ed08bf-773c-4686-ae4c-a9de0609b815"), new Guid("ebea8e7d-692e-418f-8a25-ddba70e174e9"), "https://www.hltv.org/img/static/favicon/apple-touch-icon.png" },
                    { new Guid("3e661b96-a558-4c41-a9cd-ed197e91c5dd"), new Guid("695e3634-ea0e-48b2-9a5f-ce0bae5a1beb"), "https://vz.ru/apple-touch-icon.png" },
                    { new Guid("49697217-0a57-4edd-a717-ad08ba93d5bb"), new Guid("99946b37-2e11-40bd-8f52-40dfd69979b2"), "https://chel.aif.ru/img/icon/apple-touch-icon.png?37f" },
                    { new Guid("49ec504e-88a9-452a-a0c9-0cf916700772"), new Guid("5aa05c63-3407-4c5e-be61-7c0c0a0ca184"), "https://russian.rt.com/static/img/listing-uwc-logo.png" },
                    { new Guid("563aced8-11a7-45d5-aa0a-ba2c64db1a87"), new Guid("dc08bb45-b806-4c6a-98a1-420739afe64b"), "https://im.kommersant.ru/ContentFlex/images/favicons2020/apple-touch-icon-120.png" },
                    { new Guid("5a74c888-a9a3-4adb-b8ce-79c9f49b49af"), new Guid("4d22b1f7-871f-4bf6-a8bf-7d98058d84ba"), "https://edition.cnn.com/media/sites/cnn/apple-touch-icon.png" },
                    { new Guid("623a6045-4ea1-4bc3-857e-6d40685967cf"), new Guid("c08010a1-aca2-4e8e-862d-fb004e8dbd6e"), "https://st.championat.com/i/favicon/apple-touch-icon.png" },
                    { new Guid("66600d13-12a0-48af-80a4-f79cdad8e73f"), new Guid("c5d3427f-b7d7-4506-bec9-102f2a8b81c3"), "https://cdnn21.img.ria.ru/i/favicons/favicon.svg" },
                    { new Guid("68ad1337-8cf9-443c-8fdb-1d882760d62f"), new Guid("4d1a37f3-5890-4677-982a-b2142867e8e7"), "https://static.ngs.ru/jtnews/dist/static/favicons/apple/apple-favicon-74-120.png" },
                    { new Guid("6a1daa36-f513-4244-b704-6a036ff0922b"), new Guid("012bc825-0a21-4006-8178-e45e7736e5be"), "https://ura.news/apple-touch-icon.png" },
                    { new Guid("73ed0acc-f4e2-4c13-a9bf-8448a4a92647"), new Guid("1ada8c4a-62e7-45b4-bf2d-e2f83013ea8c"), "https://www.ixbt.com/favicon.ico" },
                    { new Guid("77a25066-1f91-4013-a8d2-3f82cc835663"), new Guid("67a8e2c2-22fb-4e88-83c3-9cec8e2f5980"), "https://life.ru/appletouch/apple-icon-120х120.png" },
                    { new Guid("78c8fcc7-7e89-429f-91af-07cc2475c131"), new Guid("c4005c3e-d002-4380-984f-ba44c8a29fcc"), "https://svpressa.ru/favicon-96x96.png?v=1471426270000" },
                    { new Guid("7ebacc2b-2c9c-4cea-8941-ae98bd88c806"), new Guid("05f7dcf8-55bb-4fcb-bce3-711e597db407"), "https://www.interfax.ru/touch-icon-iphone-retina.png" },
                    { new Guid("86ae06f4-73d7-42b5-85a3-5c94c064f390"), new Guid("b1e6c3f7-ed51-4567-affe-ef90e75897b0"), "https://cdnstatic.rg.ru/images/touch-icon-iphone-retina.png" },
                    { new Guid("9c20c42d-c6e0-4145-aded-d5c36a6784d4"), new Guid("52f68ae4-fcd3-4ced-811e-51a2ce3f9271"), "https://www.1obl.ru/apple-touch-icon.png" },
                    { new Guid("b0a9bfed-6300-4a1e-8e82-176581d33afe"), new Guid("3d3bdccb-02b5-4c74-9f23-c0117d47ebab"), "https://www.cybersport.ru/favicon-192x192.png" },
                    { new Guid("b53100bd-3b24-48fe-9554-7ba3e0fcd99b"), new Guid("1622dfed-cb56-4ceb-a582-cdc1d916bae9"), "https://static.gazeta.ru/nm2021/img/icons/favicon.svg" },
                    { new Guid("baa1271a-9ac5-4b92-9ab6-7f5a25979137"), new Guid("0c5d99a0-04d1-49ab-818e-44e94b7ff962"), "https://tass.ru/favicon/180.svg" },
                    { new Guid("c7902ecd-656d-4544-996b-b5ee209dab55"), new Guid("f804205f-80f2-4e66-ae29-41f83c5ab67a"), "https://www.m24.ru/img/fav/apple-touch-icon.png" },
                    { new Guid("c79276b1-57bc-4368-8300-b3657e334fc0"), new Guid("0809b166-0bf7-437e-9e16-463505e0d507"), "https://www.sports.ru/apple-touch-icon-120.png" },
                    { new Guid("d74d800e-2cc1-45ad-a6ca-577061468ca0"), new Guid("df2ca6ab-b740-425d-bcc3-6dc1f0914923"), "https://s.rbk.ru/v10_rbcnews_static/common/common-10.10.116/images/apple-touch-icon-120x120.png" },
                    { new Guid("d9b89f3a-4b31-4759-ae17-84d447e7c531"), new Guid("6f7dde80-fdc6-435c-9165-de16e5fdcd67"), "https://ural.tsargrad.tv/favicons/apple-touch-icon-120x120.png?s2" },
                    { new Guid("dba3bfec-3cbc-4fe7-b3f2-dec636ccd094"), new Guid("6ee36679-7428-408c-a667-4e85a5d4bd2f"), "https://www.pravda.ru/pix/apple-touch-icon.png" },
                    { new Guid("f27452b8-2ed8-4414-a18e-3ae5d2b23384"), new Guid("3aaf4995-a018-48fe-8fa5-77f922961583"), "https://www.belta.by/images/storage/banners/000016_a133e848cb2e7b1debb7102d19e4d139_work.svg" },
                    { new Guid("f3e20b67-81d1-4a0f-837a-926ad8d13393"), new Guid("abd7c1c0-fe43-4142-b676-b6fd45343e62"), "https://ixbt.games/images/favicon/gt/apple-touch-icon.png" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_editor_settings",
                columns: new[] { "id", "is_required", "name_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("2a41e360-dbcd-4e75-99b6-5bd29857bf6d"), true, "//div[@class='container-fluid publication-footer']//a[contains(@class, 'text-secondary')]/@title", new Guid("138196a1-bcd0-476c-be15-8209de199d60") },
                    { new Guid("353b863c-30b3-4d09-a2f2-b9a60f17703f"), true, "//article//span[@class='author']/a[@class='authorName']/span/text()", new Guid("d3ef3c08-5ec4-47d1-9fc8-650c7028cacb") },
                    { new Guid("400cc847-a47c-438a-ba33-d485a43c9a53"), false, "//div[@class='article__authors']//*[@class='article__authors__author']/span[@class='article__authors__author__name']/text()", new Guid("c25171a1-027c-4668-9b8c-5529c03b4b05") },
                    { new Guid("5393211a-c14f-43f6-8fc7-4fa2a124daf9"), true, "//span[@itemprop='name']/a/text()", new Guid("1f07dc2d-efec-44ad-9716-40804a4acf07") },
                    { new Guid("68620aec-d728-42ea-a336-80eeb3a75c36"), true, "//a[@class='article__author']/text()", new Guid("a65db7d8-91e6-4950-93cd-91a440a0c040") },
                    { new Guid("690b5c5e-feb3-435c-bdc5-aa64aa4c9b09"), true, "//div[@class='article_top']//div[@class='authors']//div[@class='autor']//span/text()", new Guid("5fe6d8cb-de7e-4f1c-a221-7f221174d5ab") },
                    { new Guid("6b4cd72c-9c4b-40de-bf44-f8135b05eb80"), false, "//p[@class='doc__text document_authors']/text()", new Guid("b4580d0d-f69a-4f3c-bd19-f4513d413a46") },
                    { new Guid("75a0c4c1-ce21-4659-ba7a-e42e7ee1bfce"), true, "//div[@itemprop='author']/span[@itemprop='name']/text()", new Guid("c9c58939-3e33-4fce-8da8-8db8826df031") },
                    { new Guid("83b3679d-8326-4485-9d4d-1a4210a80675"), true, "//div[contains(@class, 'full-article')]/div[@class='authors-block']//span[text()='Автор']/../a/text()", new Guid("44751716-8fa8-49a3-9c46-e25f6002bdbb") },
                    { new Guid("a0b9f97b-fa16-47d1-ac4c-17d2f9b03711"), false, "//div[@class='topic-authors']/a[@class='topic-authors__author']/text()", new Guid("ec6b15e0-d3ae-440d-bbac-4e263a79c76a") },
                    { new Guid("acb7facc-ed2c-443e-afcf-778101b4ab12"), true, "//span[@itemprop='author']/span[@itemprop='name']/@content", new Guid("6bb35eb9-688b-4773-9bc2-bb7e0aaf6ae8") },
                    { new Guid("b6f856ba-a7f8-4b31-8288-b8e1d829066a"), false, "//div[@class='author']/span[@itemprop='author']/span[@itemprop='name']/a/text()", new Guid("ce6f725a-1015-412c-a1b8-c8f88a02758b") },
                    { new Guid("c2a0437c-ce10-4e77-b431-d110b05b80f1"), true, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']//a[@itemprop='author']//span[@itemprop='name']/text()", new Guid("75e5df1e-275e-4553-84c7-e4196dd6d6ce") },
                    { new Guid("cc651c9c-2582-4d52-b140-9c43ed0225bf"), false, "//div[@itemprop='author']//p[@itemprop='name']/text()", new Guid("f36fd2ae-8e84-49b8-894a-1ceadd9b4e11") },
                    { new Guid("d8fcf131-ad7f-40af-b219-51538ca7dcc8"), true, "//article//header//div[@class='article-head__author-name']/a[@rel='author']/span/text()", new Guid("52373fb1-cd9a-4ac9-adea-eca235fa0bab") },
                    { new Guid("dbd90f7c-8d2e-47c6-bc0a-8bf72d8510a3"), true, "//div[contains(@class, 'styles_bodyWrapper')]//div[contains(@class, 'styles_authorsLinks')]/a/text()", new Guid("5ddd6a70-d9c6-4bd7-8329-eac27fe95267") },
                    { new Guid("dc0bc343-ca81-487b-ac1a-a95d16ce0f95"), true, "//*[@itemprop='author']/*[@itemprop='name']//text()", new Guid("173516b7-36ab-4d1d-8e5c-d9904b9549f8") },
                    { new Guid("e8a74573-2dd4-4e0d-a606-0496915a7e27"), true, "//footer[@class='news-item__footer']/div[@class='news-item__footer-after-news']/p[position()=1]//span/text()", new Guid("2f47781a-aa13-41a3-aef5-87fb50195e17") },
                    { new Guid("edf4581c-cdd3-44b2-a0c7-c939cbbfbd86"), true, "//div[contains(@class, 'PageArticleContent_authors')]//a[contains(@class, 'LinksOfAuthor_item')]/text()", new Guid("43ad817b-830c-4f7d-a3bd-3b1f0faa441d") },
                    { new Guid("fab4f27b-b31f-4f3f-b3e5-d09ba91987ad"), true, "//div[@class='headline__footer']//div[@class='byline__names']/span[@class='byline__name']/text()", new Guid("87c0553e-8864-4a06-a0b8-90fad746fbeb") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_modified_at_settings",
                columns: new[] { "id", "is_required", "modified_at_culture_info", "modified_at_time_zone_info_id", "modified_at_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("ce058351-981d-44df-9c95-45dd1c18cb20"), true, "ru-RU", "Russian Standard Time", "//div[@class='article__info']//div[@class='article__info-date']/span[@class='article__info-date-modified']/text()", new Guid("4ebd46d3-4c15-4111-a01c-460a06b9bd2f") },
                    { new Guid("df145263-e894-4546-a98e-ecbc413cfbe6"), false, "ru-RU", "UTC", "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark_update')]//span[@ca-ts]/text()", new Guid("7138d587-06ea-4001-8ce0-87a488ea9cfe") },
                    { new Guid("edbe873b-ecf2-48c5-b885-6d4815d115b9"), false, "ru-RU", "Russian Standard Time", "//div[@class='doc_header__time']/span[contains(@class, 'publish_update')]/text()", new Guid("b4580d0d-f69a-4f3c-bd19-f4513d413a46") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_picture_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("0976648c-3cd8-4e13-a20a-89ebe4fa8422"), false, new Guid("ce6f725a-1015-412c-a1b8-c8f88a02758b"), "//div[@class='b_article-media']//div[@class='mainarea-wrapper']/figure/img[@class='item-image-front']/@src" },
                    { new Guid("1d4fb81c-6afc-4b6d-8f4b-2d6090ab443a"), true, new Guid("e303fcb9-bb0d-46b8-b371-f7b8d855fc8d"), "//picture/img/@src" },
                    { new Guid("20411011-7a8c-4f4e-a022-545b3b5f0eb2"), false, new Guid("d3ef3c08-5ec4-47d1-9fc8-650c7028cacb"), "//article//div[@class='image-con' and position() = 1]/picture/img/@src" },
                    { new Guid("270a8009-ad54-4ab7-9afc-fdd7f842f0af"), false, new Guid("5fe6d8cb-de7e-4f1c-a221-7f221174d5ab"), "//div[@class='img_box']/a[@class='zoom_js']/img/@src" },
                    { new Guid("3192b410-9695-4879-86cd-33cea0b8cf0a"), true, new Guid("c9c58939-3e33-4fce-8da8-8db8826df031"), "//div[@itemprop='articleBody']//div[@itemprop='image']/picture/img[@itemprop='contentUrl']/@src" },
                    { new Guid("4006412d-05d2-4e21-a08f-30dcb026ea45"), false, new Guid("44751716-8fa8-49a3-9c46-e25f6002bdbb"), "//div[contains(@class, 'full-article')]/div[contains(@class, 'gallery')]/picture/img/@src" },
                    { new Guid("61a90170-9c34-4023-90e1-d4099c4300c2"), false, new Guid("f36fd2ae-8e84-49b8-894a-1ceadd9b4e11"), "//figure//img/@src" },
                    { new Guid("7e510908-5459-4d4e-a8dd-f32139bd3112"), true, new Guid("1f07dc2d-efec-44ad-9716-40804a4acf07"), "//header//figure//picture/img/@src" },
                    { new Guid("94c86b43-15ed-4ff5-8356-5936cfbf436e"), true, new Guid("87c0553e-8864-4a06-a0b8-90fad746fbeb"), "//div[contains(@class, 'article__lede-wrapper')]//picture/img/@src" },
                    { new Guid("95ca75cd-6515-4f35-b2bb-488cf4d436e9"), true, new Guid("a65db7d8-91e6-4950-93cd-91a440a0c040"), "//div[@class='article__media']//img/@src" },
                    { new Guid("ac802582-53e7-46a9-8ffd-d7570bdfc8df"), false, new Guid("52373fb1-cd9a-4ac9-adea-eca235fa0bab"), "//article//header/div[@class='article-head__photo']/img/@src" },
                    { new Guid("aca3bbcf-9850-4adc-a001-16acc86ea9ea"), true, new Guid("ee0f8000-a0af-43bb-90f7-d0773d6a4f14"), "//div[contains(@class, 'big_photo')]//div[@class='big_photo__img']//img/@src" },
                    { new Guid("b5ad084f-4c46-49fd-9381-2f9b7b967399"), false, new Guid("75e5df1e-275e-4553-84c7-e4196dd6d6ce"), "//img[@itemprop='image']/@src" },
                    { new Guid("b6812c27-5f50-4f91-9852-a6d812b04337"), true, new Guid("138196a1-bcd0-476c-be15-8209de199d60"), "//a[@class='glightbox']/img[contains(@class, 'pub-cover')]/@src" },
                    { new Guid("bb38de5e-c9cf-4cac-b3be-5d8188caacf3"), false, new Guid("7138d587-06ea-4001-8ce0-87a488ea9cfe"), "//div[contains(@class, 'HeaderMedia_image')]//img[contains(@class, 'Image_image')]/@src" },
                    { new Guid("c77bb16b-0351-46ab-b58f-907c09f69e84"), false, new Guid("4ebd46d3-4c15-4111-a01c-460a06b9bd2f"), "//div[@class='photoview__open']/img/@src" },
                    { new Guid("de4a48f3-25f8-4632-950e-b0a643bbaa5b"), false, new Guid("7ef111f4-2921-418a-8734-2a0c9ba1cb8b"), "//div[@class='b-material-incut-m-image']//@src" },
                    { new Guid("e03534db-c76a-4242-a55e-301a4487a3ae"), false, new Guid("2c2ea3b8-1135-4ed2-8748-75a0aa585214"), "//article/figure/img/@src" },
                    { new Guid("e5c53c8c-3567-4f6a-b2f3-85b937ac742a"), true, new Guid("4abde494-e1fd-435a-b0f9-9921c8a3de1a"), "//meta[@property='og:image']/@content" },
                    { new Guid("e5fdfe57-2a06-44cf-aa83-24fceaeb15ba"), false, new Guid("1541f78b-b3db-4bd1-be09-325723dbcb8e"), "//div[@class='inner_content']//div[@class='main_img']//img/@src" },
                    { new Guid("f21c48c9-0c90-4287-9a4a-25977b70d2b3"), false, new Guid("ec6b15e0-d3ae-440d-bbac-4e263a79c76a"), "//div[contains(@class, 'topic-body__title-image')]//img[contains(@class, 'picture__image')]/@src" },
                    { new Guid("f6dd1f61-379d-49f7-b529-43e51ffccd64"), true, new Guid("173516b7-36ab-4d1d-8e5c-d9904b9549f8"), "//div[contains(@class, 'newsMediaContainer')]/img/@src" },
                    { new Guid("fe1cc75a-700a-42bf-a8e6-7856b10b6426"), false, new Guid("5ddd6a70-d9c6-4bd7-8329-eac27fe95267"), "//article//header/div[contains(@class, 'styles_cover_media')]/img/@src" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "published_at_culture_info", "published_at_time_zone_info_id", "published_at_x_path" },
                values: new object[,]
                {
                    { new Guid("095fe271-c3c9-46ac-900a-2dcd12cfb0bd"), true, new Guid("ec6b15e0-d3ae-440d-bbac-4e263a79c76a"), "ru-RU", "Russian Standard Time", "//div[@class='topic-page__header']//a[contains(@class, 'topic-header__time')]/text()" },
                    { new Guid("23536539-cdb9-4d5f-a44c-90393d79a801"), true, new Guid("1541f78b-b3db-4bd1-be09-325723dbcb8e"), "ru-RU", "Russian Standard Time", "//div[@class='date_full']/text()" },
                    { new Guid("258c906f-5899-47ca-a150-742411b6be59"), true, new Guid("2c2ea3b8-1135-4ed2-8748-75a0aa585214"), "ru-RU", "Russian Standard Time", "//article/div[@class='header']/span/text()" },
                    { new Guid("34a64cd2-1d20-411d-b3a3-cc9a8fd7b8d8"), true, new Guid("52373fb1-cd9a-4ac9-adea-eca235fa0bab"), "ru-RU", "Russian Standard Time", "//article//header//time[@class='article-head__date']/text()" },
                    { new Guid("3699d3d3-6840-44df-aaff-0a10e9920fbb"), true, new Guid("d3ef3c08-5ec4-47d1-9fc8-650c7028cacb"), "en-US", "Central Europe Standard Time", "//article//div[@class='article-info']/div[@class='date']/text()" },
                    { new Guid("405e6b05-14b0-4421-a94d-48ac6dfb7540"), true, new Guid("a40ac08c-69b4-4465-a751-49b4e70c26ef"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'article__date-autor-shortcode')]/div[contains(@class, 'article__date')]/time[@class='date']/@datetime" },
                    { new Guid("48c995f9-5de4-416d-b64d-22726cca15bd"), true, new Guid("87c0553e-8864-4a06-a0b8-90fad746fbeb"), "en-US", "Eastern Standard Time", "//div[@class='headline__footer']//div[contains(@class, 'headline__byline-sub-text')]/div[@class='timestamp']/text()" },
                    { new Guid("4985aa86-2f40-498b-b4f3-48a7a9dc1a69"), true, new Guid("c9c58939-3e33-4fce-8da8-8db8826df031"), "ru-RU", null, "//div[@class='publication-info']/time[@itemprop='datePublished']/@datetime" },
                    { new Guid("4d23ccdc-1787-4d3b-9d3c-ff8d3a82bf3b"), true, new Guid("75e5df1e-275e-4553-84c7-e4196dd6d6ce"), "ru-RU", null, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']/span[@itemprop='datePublished']/@content" },
                    { new Guid("52713fba-278d-49d8-8dd2-f43970e6c622"), true, new Guid("43ad817b-830c-4f7d-a3bd-3b1f0faa441d"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'PageArticleContent_date')]/text()" },
                    { new Guid("55879f9d-d444-406b-9e1f-775aa115b30b"), true, new Guid("6bb35eb9-688b-4773-9bc2-bb7e0aaf6ae8"), "ru-RU", "Russian Standard Time", "//div[@class='b-article__top-author']/p[@class='date']/text()" },
                    { new Guid("5b3839cb-f456-42fa-a3f3-67173c400651"), true, new Guid("5fe6d8cb-de7e-4f1c-a221-7f221174d5ab"), "ru-RU", "Russian Standard Time", "//div[@class='article_top']//div[@class='date']//time/text()" },
                    { new Guid("66588c1b-5083-44fd-b22c-136aea55709c"), true, new Guid("5ddd6a70-d9c6-4bd7-8329-eac27fe95267"), "ru-RU", "UTC", "//article//header//div[contains(@class, 'styles_meta')]//div[contains(@class, 'styles_metaItem')]/text()" },
                    { new Guid("7b2f3d46-6c1d-4162-b5e0-b065e2f93149"), true, new Guid("7ef111f4-2921-418a-8734-2a0c9ba1cb8b"), "ru-RU", "Russian Standard Time", "//p[@class='b-material__date']/text()" },
                    { new Guid("7fdf804d-f65d-4bfe-a17a-0e8925f2377e"), true, new Guid("c25171a1-027c-4668-9b8c-5529c03b4b05"), "ru-RU", null, "//div[@class='article__header__info-block']/time[@class='article__header__date']/@datetime" },
                    { new Guid("85ba7673-b49d-46e2-a761-5efbc2eeaead"), true, new Guid("a65db7d8-91e6-4950-93cd-91a440a0c040"), "ru-RU", "Russian Standard Time", "//div[@class='article__meta']/time/text()" },
                    { new Guid("86b3f1a0-eeff-43e4-8f46-f38af215595e"), true, new Guid("ce6f725a-1015-412c-a1b8-c8f88a02758b"), "ru-RU", null, "//article/div[@class='b_article-header']//time[@itemprop='datePublished']/@datetime" },
                    { new Guid("89053ab0-73a1-48bb-bbc1-39e10959d752"), true, new Guid("b4580d0d-f69a-4f3c-bd19-f4513d413a46"), "ru-RU", null, "//div[@class='doc_header__time']/time[@class='doc_header__publish_time']/@datetime" },
                    { new Guid("8b2d46c2-afe6-40b7-b04d-72dc4db1ac3e"), true, new Guid("1f07dc2d-efec-44ad-9716-40804a4acf07"), "en-US", null, "//time/@datetime" },
                    { new Guid("b4db3853-a26a-4807-864b-a06b455944e2"), true, new Guid("ee0f8000-a0af-43bb-90f7-d0773d6a4f14"), "ru-RU", null, "//div[@class='article_page__left__top__left']//div[@class='article_page__left__top__time']//time/@datetime" },
                    { new Guid("bc737611-d1c6-4218-9002-f8a3e868cd94"), false, new Guid("138196a1-bcd0-476c-be15-8209de199d60"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'pubdatetime')]/text()" },
                    { new Guid("bdff02f8-a1df-4ee8-94d0-c9563c54301b"), true, new Guid("e303fcb9-bb0d-46b8-b371-f7b8d855fc8d"), "ru-RU", "Russian Standard Time", "//div[@class='b-text__date']/text()" },
                    { new Guid("cedd9712-048d-4b0f-ae5d-fbc4487037d7"), true, new Guid("2f47781a-aa13-41a3-aef5-87fb50195e17"), "ru-RU", null, "//header[@class='news-item__header']//time/@content" },
                    { new Guid("d66037b6-5928-4cb0-9aea-aa8fbb040ba4"), true, new Guid("f36fd2ae-8e84-49b8-894a-1ceadd9b4e11"), "ru-RU", "Ekaterinburg Standard Time", "//div[@itemprop='datePublished']/time/@datetime" },
                    { new Guid("d6b29e9c-f524-4604-9ce7-eafd920b9e24"), true, new Guid("2074b9da-b3a1-41bd-94e1-16e15cec533e"), "ru-RU", "Russian Standard Time", "//article[@itemprop='articleBody']/meta[@itemprop='datePublished']/@content" },
                    { new Guid("d708e73f-6cde-4697-8c99-3e8d6a2bc703"), true, new Guid("173516b7-36ab-4d1d-8e5c-d9904b9549f8"), "ru-RU", null, "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("d717b7b0-733f-454d-9113-fe4173a109a0"), true, new Guid("44751716-8fa8-49a3-9c46-e25f6002bdbb"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'full-article')]//time/text()" },
                    { new Guid("e9e0fc10-5f11-45ff-9ae0-982ff91366b7"), true, new Guid("7138d587-06ea-4001-8ce0-87a488ea9cfe"), "ru-RU", "UTC", "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark')]//span[@ca-ts]/text()" },
                    { new Guid("f360dcf2-1078-4e61-b10c-7b592d5daa66"), true, new Guid("4abde494-e1fd-435a-b0f9-9921c8a3de1a"), "ru-RU", null, "//article/header//time/@datetime" },
                    { new Guid("f48e17a3-5a4f-4a09-8873-dba78ca2d685"), true, new Guid("4ebd46d3-4c15-4111-a01c-460a06b9bd2f"), "ru-RU", "Russian Standard Time", "//div[@class='article__info']//div[@class='article__info-date']/a/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_sub_title_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("07e03603-6671-4dbc-800e-d4a99cae79c9"), true, new Guid("4abde494-e1fd-435a-b0f9-9921c8a3de1a"), "//div[contains(@class, 'js-mediator-article')]/*[position()=1]/text()" },
                    { new Guid("293050d7-0635-4725-b8a0-211771d16c82"), true, new Guid("a40ac08c-69b4-4465-a751-49b4e70c26ef"), "//div[contains(@class, 'article__summary')]/text()" },
                    { new Guid("355fa1d9-a163-4c2a-be10-eb0665dd3a2d"), true, new Guid("f36fd2ae-8e84-49b8-894a-1ceadd9b4e11"), "//p[@itemprop='alternativeHeadline']/span/text()" },
                    { new Guid("44f10b8d-6c54-4614-b8d3-25b67101f1a5"), false, new Guid("c25171a1-027c-4668-9b8c-5529c03b4b05"), "//div[contains(@class, 'article__text')]/div[@class='article__text__overview']/span/text()" },
                    { new Guid("524198db-5407-4caa-8846-feb08a8e618b"), false, new Guid("6bb35eb9-688b-4773-9bc2-bb7e0aaf6ae8"), "//h4/text()" },
                    { new Guid("580653f1-0404-4bdc-ac42-e0a90d46495c"), true, new Guid("ce6f725a-1015-412c-a1b8-c8f88a02758b"), "//h2/text()" },
                    { new Guid("5afa6bf7-7cad-486c-a9d2-fc269a08a921"), false, new Guid("ec6b15e0-d3ae-440d-bbac-4e263a79c76a"), "//div[contains(@class, 'topic-body__title')]/text()" },
                    { new Guid("6834efb3-e26d-461a-8424-859d934cd7d1"), false, new Guid("b4580d0d-f69a-4f3c-bd19-f4513d413a46"), "//header[@class='doc_header']/h2[contains(@class, 'doc_header__subheader')]/text()" },
                    { new Guid("7748d51e-e502-4280-91ad-a6fc6440e83d"), true, new Guid("1f07dc2d-efec-44ad-9716-40804a4acf07"), "//header/p[@id='article-summary']/text()" },
                    { new Guid("8bbe092a-aed5-4aec-9d09-9098552d99f8"), true, new Guid("138196a1-bcd0-476c-be15-8209de199d60"), "//div[@class='container-fluid shifted']/p[@class='announce lead']/text()" },
                    { new Guid("8d876c94-b2af-4693-bc21-502c2fa92ad0"), true, new Guid("44751716-8fa8-49a3-9c46-e25f6002bdbb"), "//h1/text()" },
                    { new Guid("9e864efe-6b3e-4ccc-a0ec-ee7f32d7e8ab"), true, new Guid("a65db7d8-91e6-4950-93cd-91a440a0c040"), "//div[@class='article__intro']/p/text()" },
                    { new Guid("a958ce2f-2b79-4968-b699-b2eec29d2d1c"), true, new Guid("d3ef3c08-5ec4-47d1-9fc8-650c7028cacb"), "//p[@class='headertext' and @itemprop='description']/text()" },
                    { new Guid("b325ebaf-ea09-4c54-ab0f-753a9707b65b"), true, new Guid("4ebd46d3-4c15-4111-a01c-460a06b9bd2f"), "//h1[@class='article__second-title']/text()" },
                    { new Guid("b4a1a701-016d-4800-95d0-71b46c9390b6"), false, new Guid("7138d587-06ea-4001-8ce0-87a488ea9cfe"), "//h3/text()" },
                    { new Guid("b6ca9d1d-902f-4097-bb43-823dd06c27f7"), false, new Guid("5ddd6a70-d9c6-4bd7-8329-eac27fe95267"), "//article//header//p[contains(@class, 'styles_subtitle')]/text()" },
                    { new Guid("b8fac3c5-1d3e-4d40-958e-4d2125fb1278"), false, new Guid("43ad817b-830c-4f7d-a3bd-3b1f0faa441d"), "//div[contains(@class, 'PageArticleContent_lead')]/text()" },
                    { new Guid("bb70b5bd-1d39-4216-9091-e0f0221a2970"), true, new Guid("75e5df1e-275e-4553-84c7-e4196dd6d6ce"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()=1]/text()" },
                    { new Guid("eeef300a-c3bc-4cff-a8cd-7c1217b05dd5"), true, new Guid("173516b7-36ab-4d1d-8e5c-d9904b9549f8"), "//div[@itemprop='alternativeHeadline']/text()" },
                    { new Guid("f79e1312-72fd-47a4-80da-73f4465fcea4"), false, new Guid("2c2ea3b8-1135-4ed2-8748-75a0aa585214"), "//h4/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_video_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[] { new Guid("5094a5dd-9e63-4921-8e89-200841af2bd2"), false, new Guid("d3ef3c08-5ec4-47d1-9fc8-650c7028cacb"), "//article//div[@class='videoWrapper' and @itemprop='video']/iframe[@class='video']/@src" });

            migrationBuilder.InsertData(
                table: "news_parse_modified_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_modified_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("2ca3ba38-89af-4225-855c-6cf49e3afb18"), "\"обновлено\" d MMMM yyyy, HH:mm", new Guid("df145263-e894-4546-a98e-ecbc413cfbe6") },
                    { new Guid("36713128-6e32-4737-a98b-cf4566957ff6"), "(\"обновлено:\" HH:mm dd.MM.yyyy)", new Guid("ce058351-981d-44df-9c95-45dd1c18cb20") },
                    { new Guid("811109f0-a78b-4901-9399-75ef7fe088d1"), "\"обновлено\" d MMMM, HH:mm", new Guid("df145263-e894-4546-a98e-ecbc413cfbe6") },
                    { new Guid("9755fadc-bb97-46ad-8d8f-bbb8f2808e49"), "\"обновлено\" HH:mm , dd.MM.yyyy", new Guid("edbe873b-ecf2-48c5-b885-6d4815d115b9") },
                    { new Guid("c3458af6-8b0f-47fa-844a-e0ce708e5f4a"), "\"обновлено\" HH:mm , dd.MM", new Guid("edbe873b-ecf2-48c5-b885-6d4815d115b9") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_published_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("16899f0a-6b7e-4e61-b9a6-ec58ecb510e6"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("b4db3853-a26a-4807-864b-a06b455944e2") },
                    { new Guid("1c257d78-f59e-425e-80f2-d65742fea8f4"), "dd MMMM, HH:mm", new Guid("7b2f3d46-6c1d-4162-b5e0-b065e2f93149") },
                    { new Guid("2b22fbc3-e2da-454a-af57-5cdd5ae6f193"), "d MMMM, HH:mm", new Guid("e9e0fc10-5f11-45ff-9ae0-982ff91366b7") },
                    { new Guid("366f05ec-8c4c-4374-85ed-27ed0fc9741b"), "yyyy-MM-ddTHH:mm:ss", new Guid("d66037b6-5928-4cb0-9aea-aa8fbb040ba4") },
                    { new Guid("37f10081-6a77-4b5c-bb41-ad33c576b551"), "dd.MM.yyyy HH:mm", new Guid("52713fba-278d-49d8-8dd2-f43970e6c622") },
                    { new Guid("39be5524-d87d-42ae-a47a-e43af0ededa5"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("7fdf804d-f65d-4bfe-a17a-0e8925f2377e") },
                    { new Guid("43bf6444-5115-4611-8c3e-2926a86c9b10"), "d MMMM yyyy HH:mm", new Guid("bdff02f8-a1df-4ee8-94d0-c9563c54301b") },
                    { new Guid("47b19add-561e-461b-be3c-3434563488af"), "dd MMMM yyyy HH:mm", new Guid("85ba7673-b49d-46e2-a761-5efbc2eeaead") },
                    { new Guid("4afec75d-90c9-4c6b-afa4-b26603c3a8de"), "HH:mm", new Guid("7b2f3d46-6c1d-4162-b5e0-b065e2f93149") },
                    { new Guid("4ce3f908-cb94-45eb-ad14-d025f1555baf"), "yyyy-MM-d HH:mm", new Guid("405e6b05-14b0-4421-a94d-48ac6dfb7540") },
                    { new Guid("4f5a08ca-c4d4-44ba-927f-905ca208827e"), "yyyy-MM-dd HH:mm:ss", new Guid("bc737611-d1c6-4218-9002-f8a3e868cd94") },
                    { new Guid("58eb1ad1-2a6c-4a17-a633-002fc2d70b79"), "yyyy-MM-ddTHH:mm:ss", new Guid("d6b29e9c-f524-4604-9ce7-eafd920b9e24") },
                    { new Guid("5b429174-0d5b-41a1-80fd-17fb3891e943"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("4985aa86-2f40-498b-b4f3-48a7a9dc1a69") },
                    { new Guid("6204ff1b-4346-48e3-a981-0a73dded29db"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("8b2d46c2-afe6-40b7-b04d-72dc4db1ac3e") },
                    { new Guid("7837e85b-90ee-40ac-b225-5f4f5c32bf6a"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("86b3f1a0-eeff-43e4-8f46-f38af215595e") },
                    { new Guid("81000cea-c602-404d-8b0c-8c1960d62ecb"), "HH:mm dd.MM.yyyy", new Guid("f48e17a3-5a4f-4a09-8873-dba78ca2d685") },
                    { new Guid("81f35136-e632-41ab-b1d6-665c1f2ef883"), "d MMMM, HH:mm", new Guid("66588c1b-5083-44fd-b22c-136aea55709c") },
                    { new Guid("851ddb7f-1754-4552-9fee-b3b99d671f0c"), "yyyy-MM-ddTHH:mm:ss.fffZ", new Guid("f360dcf2-1078-4e61-b10c-7b592d5daa66") },
                    { new Guid("86dcb35c-e5a1-440e-8a68-b58f1957dff5"), "d MMMM yyyy \"в\" HH:mm", new Guid("55879f9d-d444-406b-9e1f-775aa115b30b") },
                    { new Guid("8f415428-62f6-4285-a117-e1c7e2c7618b"), "HH:mm", new Guid("85ba7673-b49d-46e2-a761-5efbc2eeaead") },
                    { new Guid("9344e7f4-0843-4089-ad23-debd9925fee1"), "dd.MM.yyyy HH:mm", new Guid("d717b7b0-733f-454d-9113-fe4173a109a0") },
                    { new Guid("990d233b-57eb-4904-9829-053bb261ccc8"), "HH:mm, d MMMM yyyy", new Guid("095fe271-c3c9-46ac-900a-2dcd12cfb0bd") },
                    { new Guid("9cc45d83-4aee-4461-a425-8d7aa9fe2473"), "dd.MM.yyyy HH:mm", new Guid("5b3839cb-f456-42fa-a3f3-67173c400651") },
                    { new Guid("a1d045e0-5a62-4391-8863-7a996b09f436"), "dd MMMM yyyy, HH:mm", new Guid("23536539-cdb9-4d5f-a44c-90393d79a801") },
                    { new Guid("a8128930-fd31-4bac-a257-af3b155d085f"), "d MMMM yyyy, HH:mm", new Guid("e9e0fc10-5f11-45ff-9ae0-982ff91366b7") },
                    { new Guid("a913d353-36c4-4367-b0c5-b9f71b112402"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("89053ab0-73a1-48bb-bbc1-39e10959d752") },
                    { new Guid("ac09d677-3e96-4a56-87eb-65fb6f987524"), "d MMMM yyyy, HH:mm,", new Guid("e9e0fc10-5f11-45ff-9ae0-982ff91366b7") },
                    { new Guid("ba6ecebc-bc87-4336-8ccc-ea9476210d01"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("4d23ccdc-1787-4d3b-9d3c-ff8d3a82bf3b") },
                    { new Guid("bfd6f8a2-409f-4b04-88cd-d6089d458431"), "dd MMMM yyyy, HH:mm", new Guid("7b2f3d46-6c1d-4162-b5e0-b065e2f93149") },
                    { new Guid("c22f2cd7-6eee-4fc3-96a5-b3fe952acced"), "d MMMM, HH:mm,", new Guid("e9e0fc10-5f11-45ff-9ae0-982ff91366b7") },
                    { new Guid("c433dd15-d193-446c-ad0f-f4b2fdcf6350"), "d MMMM  HH:mm", new Guid("bdff02f8-a1df-4ee8-94d0-c9563c54301b") },
                    { new Guid("ca33aa33-617d-4c26-83a1-02050a670866"), "d MMMM yyyy, HH:mm", new Guid("258c906f-5899-47ca-a150-742411b6be59") },
                    { new Guid("d0db4fde-3e36-4438-9176-7d199da7fe70"), "d MMMM yyyy, HH:mm", new Guid("66588c1b-5083-44fd-b22c-136aea55709c") },
                    { new Guid("dbcdf30c-85d9-47ec-83d0-4b16d18451ae"), "d MMMM yyyy, HH:mm \"МСК\"", new Guid("34a64cd2-1d20-411d-b3a3-cc9a8fd7b8d8") },
                    { new Guid("de676180-da41-4255-b379-31897a7620a7"), "d-M-yyyy HH:mm", new Guid("3699d3d3-6840-44df-aaff-0a10e9920fbb") },
                    { new Guid("f9f9e78f-70cb-4415-ac91-e02552efe0a2"), "\"Published\n       \" HH:mm tt \"EST\", ddd MMMM d, yyyy", new Guid("48c995f9-5de4-416d-b64d-22726cca15bd") },
                    { new Guid("fe1cc56c-74fb-47f0-b7eb-b54b9a4e07b2"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("cedd9712-048d-4b0f-ae5d-fbc4487037d7") },
                    { new Guid("ff580b25-7255-4ba5-8866-939630321e68"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("d708e73f-6cde-4697-8c99-3e8d6a2bc703") }
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
