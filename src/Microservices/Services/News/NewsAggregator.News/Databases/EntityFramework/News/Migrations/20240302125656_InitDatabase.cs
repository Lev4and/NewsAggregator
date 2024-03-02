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
                    { new Guid("019d9405-8c57-4a83-9c27-278f4c3d2857"), true, "https://www.hltv.org/", "HLTV.org" },
                    { new Guid("16ba03ad-b234-422d-bed1-b82a80d58f1f"), true, "https://lenta.ru/", "Лента.Ру" },
                    { new Guid("177d73de-56e1-4976-b896-7eaa63a26e9a"), true, "https://www.belta.by/", "БелТА" },
                    { new Guid("20b89422-0d9f-4dc4-b58b-73b03dbeaff0"), true, "https://russian.rt.com/", "RT на русском" },
                    { new Guid("20cec815-9736-4114-b31d-386741e63e78"), true, "https://www.kp.ru/", "Комсомольская правда" },
                    { new Guid("2e12143b-93c7-4d1e-a743-3a37b441adf0"), true, "https://www.kommersant.ru/", "Коммерсантъ" },
                    { new Guid("427c22c2-9bf1-486c-9567-3e014e8c5e5d"), true, "https://www.sports.ru/", "Storts.ru" },
                    { new Guid("4dd1448e-cdf3-4750-89bd-5364cc2351fb"), true, "https://iz.ru/", "Известия" },
                    { new Guid("57f00175-5f15-40e5-b916-cb9ddce8f48e"), true, "https://www.ixbt.com/", "iXBT.com" },
                    { new Guid("5db48a6c-28d2-45e5-bcf4-5fbaa5d9c377"), true, "https://tsargrad.tv/", "Царьград" },
                    { new Guid("6121ae9f-44ad-429d-9265-16f1d6aa285b"), true, "https://ixbt.games/", "iXBT.games" },
                    { new Guid("6be0b2ec-653f-4e8e-85e8-aab303c8e631"), true, "https://3dnews.ru/", "3Dnews.ru" },
                    { new Guid("7764ba9d-b1b2-45df-8bc4-af11e680f124"), true, "https://ria.ru/", "РИА Новости" },
                    { new Guid("78096d9a-daaf-4268-9c38-d3161bc84809"), true, "https://www.cybersport.ru/", "Cybersport.ru" },
                    { new Guid("78d5b76d-67e9-440b-b8fc-23a3a709fb24"), true, "https://www.pravda.ru/", "Правда.ру" },
                    { new Guid("7d7bea19-21c2-4fb8-a6ee-3ca263e0638d"), true, "https://www.gazeta.ru/", "Газета.Ru" },
                    { new Guid("90032753-6d6b-4066-ba0c-cd2a922c3833"), true, "https://www.m24.ru/", "Москва 24" },
                    { new Guid("96c5304f-da5a-4afd-84c3-09ba850c1738"), true, "https://edition.cnn.com/", "CNN" },
                    { new Guid("a1124959-5396-44f8-8c7b-01e7efcdc823"), true, "https://tass.ru/", "ТАСС" },
                    { new Guid("a2ad35d8-90cf-4409-bbfd-c07861da373b"), true, "https://ura.news/", "Ura.ru" },
                    { new Guid("b2fb45d4-a7c0-473f-bdb6-0d31c53afe4a"), true, "https://www.championat.com/", "Чемпионат.com" },
                    { new Guid("b3a8f5c8-b7ad-444c-8558-893e41b5b117"), true, "https://rg.ru/", "Российская газета" },
                    { new Guid("b69ca73d-e019-4a9c-9bee-075a94cb71e6"), true, "https://svpressa.ru/", "СвободнаяПресса" },
                    { new Guid("baa4c41d-5043-404f-94d9-3c7f3fa6a362"), true, "https://www.1obl.ru/", "Первый областной" },
                    { new Guid("bfa58065-cc2a-463b-884a-f14dbd140f17"), true, "https://www.nytimes.com/", "The New York Times" },
                    { new Guid("c37f18b1-17a3-4c6f-8f2e-067e33ec5abb"), true, "https://life.ru/", "Life" },
                    { new Guid("c4912fba-ab5c-4d50-8cf0-263cf9cff9ff"), true, "https://www.rbc.ru/", "РБК" },
                    { new Guid("d31a10b3-97a3-40ed-9a9a-5d49610f0337"), true, "https://74.ru/", "74.ru" },
                    { new Guid("d37f1561-ed9d-4487-8762-d153d2eafa65"), true, "https://vz.ru/", "ВЗГЛЯД.РУ" },
                    { new Guid("d8df4791-788b-4dd1-8433-2cb5043c3d05"), true, "https://aif.ru/", "Аргументы и факты" },
                    { new Guid("f3c6a043-5f62-4556-a9ad-987946855540"), true, "https://www.interfax.ru/", "Интерфакс" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_settings",
                columns: new[] { "id", "html_description_x_path", "source_id", "text_description_x_path", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("0846cfbd-daec-4840-82c8-1a6396bc68d4"), "//div[contains(@class, 'article__text ')]", new Guid("20b89422-0d9f-4dc4-b58b-73b03dbeaff0"), "//div[contains(@class, 'article__text ')]/text()", "//h1/text()" },
                    { new Guid("08e3734e-ce93-4bb9-b1af-26011fc19be6"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]", new Guid("5db48a6c-28d2-45e5-bcf4-5fbaa5d9c377"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]/text()", "//h1[@class='article__title']/text()" },
                    { new Guid("176bd21c-7f2b-4119-a6a7-ce4ff03f9e09"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]", new Guid("2e12143b-93c7-4d1e-a743-3a37b441adf0"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]/text()", "//h1/text()" },
                    { new Guid("1789ce3c-74e0-486d-bef4-c72125575acb"), "//div[contains(@class, 'news-item__content')]", new Guid("427c22c2-9bf1-486c-9567-3e014e8c5e5d"), "//div[contains(@class, 'news-item__content')]/text()", "//h1/text()" },
                    { new Guid("26ba4a33-d7d2-4fad-b982-0bf2fec9f7f2"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()>1]", new Guid("6be0b2ec-653f-4e8e-85e8-aab303c8e631"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()>1]/text()", "//h1/text()" },
                    { new Guid("30976135-f330-49f7-a835-d8e3414db02e"), "//section[@name='articleBody']/*", new Guid("bfa58065-cc2a-463b-884a-f14dbd140f17"), "//section[@name='articleBody']/*/text()", "//h1/text()" },
                    { new Guid("338849b8-0ae0-4b12-98f3-f46657efdec8"), "//div[@itemprop='articleBody']/*[not(name() = 'figure')]", new Guid("d31a10b3-97a3-40ed-9a9a-5d49610f0337"), "//div[@itemprop='articleBody']/*[not(name() = 'figure')]/text()", "//h1[@itemprop='headline']/span/text()" },
                    { new Guid("37f332ce-c861-4008-9f09-af03d20d39cf"), "//div[@data-gtm-el='content-body']/*[not(name()='div' and @data-wide='true')]", new Guid("20cec815-9736-4114-b31d-386741e63e78"), "//div[@data-gtm-el='content-body']/*[not(name()='div' and @data-wide='true')]/text()", "//h1/text()" },
                    { new Guid("39e5eab7-7867-44db-91b2-fdd8ee159665"), "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]", new Guid("f3c6a043-5f62-4556-a9ad-987946855540"), "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]/text()", "//h1/text()" },
                    { new Guid("4486a185-5466-41cf-9f16-43a63dbbec7b"), "//div[@itemprop='articleBody']/*", new Guid("7d7bea19-21c2-4fb8-a6ee-3ca263e0638d"), "//div[@itemprop='articleBody']/*/text()", "//h1/text()" },
                    { new Guid("4bc575be-67cd-4488-880c-93e8ad9f978b"), "//article/div[@class='article-content']/*[not(@class)]", new Guid("b2fb45d4-a7c0-473f-bdb6-0d31c53afe4a"), "//article/div[@class='article-content']/*[not(@class)]/text()", "//article/header/div[@class='article-head__title']/text()" },
                    { new Guid("6fc60d09-2fc4-4ad8-8dee-bb611058cf2e"), "//article/div[@class='news_text']", new Guid("d37f1561-ed9d-4487-8762-d153d2eafa65"), "//article/div[@class='news_text']/text()", "//h1/text()" },
                    { new Guid("757f5794-0c34-4451-99d1-02d8213c663e"), "//div[@class='article_text']", new Guid("d8df4791-788b-4dd1-8433-2cb5043c3d05"), "//div[@class='article_text']/text()", "//h1/text()" },
                    { new Guid("7878ff5d-1e93-45e5-a6a2-dfcdd2c5b826"), "//div[@itemprop='articleBody']/*[not(name()='div')]", new Guid("a2ad35d8-90cf-4409-bbfd-c07861da373b"), "//div[@itemprop='articleBody']/*[not(name()='div')]/text()", "//h1/text()" },
                    { new Guid("79f68b7e-c6a9-45ef-8ead-35afb3a15955"), "//div[@class='topic-body__content']", new Guid("16ba03ad-b234-422d-bed1-b82a80d58f1f"), "//div[@class='topic-body__content']/text()", "//h1[@class='topic-body__titles']/span[@class='topic-body__title']/text()" },
                    { new Guid("7e6554f8-2b2e-4c28-81b3-300619a7aedb"), "//div[@itemprop='articleBody']/*", new Guid("96c5304f-da5a-4afd-84c3-09ba850c1738"), "//div[@itemprop='articleBody']/*/text()", "//h1/text()" },
                    { new Guid("820650a0-dde5-47bd-9212-3ce27f09dbc9"), "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]", new Guid("78d5b76d-67e9-440b-b8fc-23a3a709fb24"), "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]/text()", "//h1/text()" },
                    { new Guid("83b05f08-1095-462d-a8e5-3a3db953c1b4"), "//article//div[@class='newstext-con']/*[position()>2]", new Guid("019d9405-8c57-4a83-9c27-278f4c3d2857"), "//article//div[@class='newstext-con']/*[position()>2]/text()", "//h1[@class='headline']/text()" },
                    { new Guid("857dff07-a9c8-443c-91e1-02ff334625ee"), "//div[contains(@class, 'js-mediator-article')]/*[position()>1]", new Guid("78096d9a-daaf-4268-9c38-d3161bc84809"), "//div[contains(@class, 'js-mediator-article')]/*[position()>1]/text()", "//h1/text()" },
                    { new Guid("8735fee4-71c9-4733-b987-e91a03d7252c"), "//div[@itemprop='articleBody']/*", new Guid("4dd1448e-cdf3-4750-89bd-5364cc2351fb"), "//div[@itemprop='articleBody']/*/text()", "//h1/span/text()" },
                    { new Guid("93c893f7-b6e4-41af-acc8-573ba0be0280"), "//div[@itemprop='articleBody']/*", new Guid("baa4c41d-5043-404f-94d9-3c7f3fa6a362"), "//div[@itemprop='articleBody']/*/text()", "//h1[@itemprop='headline']/text()" },
                    { new Guid("9ac79fb9-acd1-4533-91a9-01b677955ef4"), "//article/*", new Guid("a1124959-5396-44f8-8c7b-01e7efcdc823"), "//article/*/text()", "//h1/text()" },
                    { new Guid("9b9bc804-6747-464e-ae8d-746acb9bd7b6"), "//div[contains(@class, 'container-fluid shifted') and not(p[@class='announce lead']) and not(h1) and not(hr)]", new Guid("6121ae9f-44ad-429d-9265-16f1d6aa285b"), "//div[contains(@class, 'container-fluid shifted') and not(p[@class='announce lead']) and not(h1) and not(hr)]/text()", "//h1/text()" },
                    { new Guid("a9a5a136-342b-4b21-a7b5-4cd077ff62fc"), "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]", new Guid("c37f18b1-17a3-4c6f-8f2e-067e33ec5abb"), "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]/text()", "//h1/text()" },
                    { new Guid("c9e29a4e-08f4-4a66-b328-74981adfdcee"), "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]", new Guid("b69ca73d-e019-4a9c-9bee-075a94cb71e6"), "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]/text()", "//h1[@class='b-text__title']/text()" },
                    { new Guid("cc37b3d9-b6a8-4c52-87aa-879a3ced3de1"), "//div[contains(@class, 'article__body')]", new Guid("7764ba9d-b1b2-45df-8bc4-af11e680f124"), "//div[contains(@class, 'article__body')]/text()", "//div[@class='article__title']/text()" },
                    { new Guid("d2a7f188-5b3f-409b-b544-3d587a8900b8"), "//div[contains(@class, 'PageContentCommonStyling_text')]/*[not(name() = 'rg-video')]", new Guid("b3a8f5c8-b7ad-444c-8558-893e41b5b117"), "//div[contains(@class, 'PageContentCommonStyling_text')]/*[not(name() = 'rg-video')]/text()", "//h1/text()" },
                    { new Guid("ebf5a57a-96d0-495d-a967-e94965bd48a2"), "//div[@class='js-mediator-article']", new Guid("177d73de-56e1-4976-b896-7eaa63a26e9a"), "//div[@class='js-mediator-article']/text()", "//h1/text()" },
                    { new Guid("f6e16297-26ea-492d-8117-d89dc49be348"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview'))]", new Guid("c4912fba-ab5c-4d50-8cf0-263cf9cff9ff"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview'))]/text()", "//h1/text()" },
                    { new Guid("f7fffc1f-b099-441d-92b6-d9a68b0eb763"), "//div[@itemprop='articleBody']/*", new Guid("57f00175-5f15-40e5-b916-cb9ddce8f48e"), "//div[@itemprop='articleBody']/*/text()", "//h1/text()" },
                    { new Guid("f89bf1b3-d18f-4eea-8c3e-f2254fabb0fd"), "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]", new Guid("90032753-6d6b-4066-ba0c-cd2a922c3833"), "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]/text()", "//h1/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_search_settings",
                columns: new[] { "id", "news_site_url", "news_url_x_path", "source_id" },
                values: new object[,]
                {
                    { new Guid("005289cb-ab40-4a98-b7c7-86b1a6d3aed1"), "https://aif.ru/", "//span[contains(@class, 'item_text__title')]/../@href", new Guid("d8df4791-788b-4dd1-8433-2cb5043c3d05") },
                    { new Guid("11f57b12-ea7b-400c-86d8-60477ac91a52"), "https://www.gazeta.ru/news/", "//a[contains(@href, '/news/') and contains(@href, '.shtml') and not(contains(@href, '?'))]/@href", new Guid("7d7bea19-21c2-4fb8-a6ee-3ca263e0638d") },
                    { new Guid("17ec0ba5-b75f-46ad-972a-4134cbfa149c"), "https://www.1obl.ru/news/", "//a[starts-with(@href, '/news/') and not(contains(@href, '?'))]/@href", new Guid("baa4c41d-5043-404f-94d9-3c7f3fa6a362") },
                    { new Guid("22f06929-bcff-432e-a5fb-e4b1ba36b22a"), "https://www.rbc.ru/", "//a[contains(@href, 'https://www.rbc.ru/') and contains(@href, '?from=')]/@href", new Guid("c4912fba-ab5c-4d50-8cf0-263cf9cff9ff") },
                    { new Guid("25e0e148-6a70-44ab-b82a-ef70752d8271"), "https://www.m24.ru/", "//a[contains(@href, '/news/')]/@href", new Guid("90032753-6d6b-4066-ba0c-cd2a922c3833") },
                    { new Guid("27b1198e-7019-4411-b06b-6738b34a4f0d"), "https://www.interfax.ru/", "//div[@class='timeline']//a[@tabindex=5]/@href", new Guid("f3c6a043-5f62-4556-a9ad-987946855540") },
                    { new Guid("37240787-7cc0-4bf3-95d5-57a3ac093de8"), "https://www.hltv.org/", "//a[contains(@href, '/news/')]/@href", new Guid("019d9405-8c57-4a83-9c27-278f4c3d2857") },
                    { new Guid("408b5174-43f2-42dd-96de-ed885f328080"), "https://ixbt.games/news/", "//a[@class='card-link']/@href", new Guid("6121ae9f-44ad-429d-9265-16f1d6aa285b") },
                    { new Guid("4626a9df-d59c-49c9-938c-544db1611a5f"), "https://ura.news/", "//a[contains(@href, '/news/')]/@href", new Guid("a2ad35d8-90cf-4409-bbfd-c07861da373b") },
                    { new Guid("534675d1-138e-4ddf-a98b-c5902f79b9b2"), "https://www.belta.by/", "//a[contains(@href, 'https://www.belta.by/') and contains(@href, '/view/')]/@href", new Guid("177d73de-56e1-4976-b896-7eaa63a26e9a") },
                    { new Guid("58b1112d-0ae6-45ae-bb0e-3fc65b1e37d0"), "https://www.nytimes.com/", "//a[contains(@href, '.html')]/@href", new Guid("bfa58065-cc2a-463b-884a-f14dbd140f17") },
                    { new Guid("5b7c2e8e-c321-444b-88bc-755c6e5a2ecf"), "https://3dnews.ru/news/", "//div[@class='news-feed-all']//a[@class='entry-header']/h1/../@href", new Guid("6be0b2ec-653f-4e8e-85e8-aab303c8e631") },
                    { new Guid("6325dbb1-ba60-497c-b893-e9d451a269e5"), "https://edition.cnn.com/", "//a[contains(@href, '.html')]/@href", new Guid("96c5304f-da5a-4afd-84c3-09ba850c1738") },
                    { new Guid("67ed8d96-e029-47b6-a3fe-000d53243878"), "https://www.kommersant.ru/", "//a[contains(@href, '/doc/') and contains(@href, '?from=')]/@href", new Guid("2e12143b-93c7-4d1e-a743-3a37b441adf0") },
                    { new Guid("76b9fad1-0592-410d-8d16-da7cf47619f8"), "https://www.pravda.ru/", "//a[contains(@href, '/news/') and not(@href='https://www.pravda.ru/news/')]/@href", new Guid("78d5b76d-67e9-440b-b8fc-23a3a709fb24") },
                    { new Guid("7e9f4d1c-7366-4d2e-af86-f6eed2fd80af"), "https://www.sports.ru/news/", "//a[contains(@href, '.html') and not(contains(@href, '.html#comments')) and not (contains(@href, '/blogs/'))]/@href", new Guid("427c22c2-9bf1-486c-9567-3e014e8c5e5d") },
                    { new Guid("8064abb7-f98b-4f20-9cbd-f86fec222f74"), "https://tsargrad.tv/", "//a[contains(@class, 'news-item__link')]/@href", new Guid("5db48a6c-28d2-45e5-bcf4-5fbaa5d9c377") },
                    { new Guid("9bafbe9e-59e6-4c0d-b838-0b82e6dd3381"), "https://www.cybersport.ru/", "//a[contains(@href, '/tags/')]/@href", new Guid("78096d9a-daaf-4268-9c38-d3161bc84809") },
                    { new Guid("a2442bf8-3a31-45fc-9848-16c92b21cc2d"), "https://www.ixbt.com/news/", "//a[starts-with(@href, '/news/') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("57f00175-5f15-40e5-b916-cb9ddce8f48e") },
                    { new Guid("a9d84935-d611-43ff-951d-b24450a92a8e"), "https://tass.ru/", "//a[contains(@class, 'tass_pkg_link-v5WdK') and contains(substring(@href, 2), '/') and not(contains(@href, '/spec/')) and not(contains(@href, 'spec.tass.ru'))]/@href", new Guid("a1124959-5396-44f8-8c7b-01e7efcdc823") },
                    { new Guid("bc5d0ac6-f489-4255-831f-1b93c6fcd227"), "https://www.kp.ru/", "//a[contains(@href, '/news/')]/@href", new Guid("20cec815-9736-4114-b31d-386741e63e78") },
                    { new Guid("bef28957-669d-4bb9-b9e6-9c9f917cc007"), "https://russian.rt.com/", "//a[contains(@class, 'link') and contains(@href, 'news/')]/@href", new Guid("20b89422-0d9f-4dc4-b58b-73b03dbeaff0") },
                    { new Guid("bfbf0754-f76d-4a1a-93eb-85dd12abba2b"), "https://74.ru/", "//a[starts-with(@href, '/text/') and not(contains(@href, '?')) and not(contains(@href, 'comments/')) and not(@href='/text/')]/@href", new Guid("d31a10b3-97a3-40ed-9a9a-5d49610f0337") },
                    { new Guid("c416c703-10d9-4807-ae59-abc542f9203f"), "https://rg.ru/", "//a[contains(@href, '.html')]/@href", new Guid("b3a8f5c8-b7ad-444c-8558-893e41b5b117") },
                    { new Guid("d16b8bc7-282c-4a95-84cc-50b03c3d0217"), "https://iz.ru/news/", "//a[contains(@href, '?main_click')]/@href", new Guid("4dd1448e-cdf3-4750-89bd-5364cc2351fb") },
                    { new Guid("d23c45f1-de32-493b-824a-e6259082aa7f"), "https://svpressa.ru/all/news/", "//a[contains(@href, '/news/') and not(contains(@href, '?')) and not(starts-with(@href, '/all/news/'))]/@href", new Guid("b69ca73d-e019-4a9c-9bee-075a94cb71e6") },
                    { new Guid("d5c1fe42-1661-4aef-832a-f788c7d080be"), "https://vz.ru/", "//a[contains(@href, '.html') and not(contains(@href, '#comments')) and not(contains(@href, '?')) and not(contains(@href, '/about/'))]/@href", new Guid("d37f1561-ed9d-4487-8762-d153d2eafa65") },
                    { new Guid("d65624d9-5063-46eb-aefc-27ad4a13a6e1"), "https://ria.ru/", "//a[contains(@class, 'cell-list__item-link')]/@href", new Guid("7764ba9d-b1b2-45df-8bc4-af11e680f124") },
                    { new Guid("e381f398-ead3-4e7c-91b9-ae84af97a328"), "https://www.championat.com/news/1.html?utm_source=button&utm_medium=news", "//a[contains(@href, 'news-') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("b2fb45d4-a7c0-473f-bdb6-0d31c53afe4a") },
                    { new Guid("ea152cb1-e4da-4336-8163-5c7ab4df5575"), "https://lenta.ru/", "//a[starts-with(@href, '/news/')]/@href", new Guid("16ba03ad-b234-422d-bed1-b82a80d58f1f") },
                    { new Guid("edacbfc1-78ca-41d3-aafa-588889302579"), "https://life.ru/s/novosti", "//a[contains(@href, '/p/')]/@href", new Guid("c37f18b1-17a3-4c6f-8f2e-067e33ec5abb") }
                });

            migrationBuilder.InsertData(
                table: "news_source_logos",
                columns: new[] { "id", "original", "small", "source_id" },
                values: new object[,]
                {
                    { new Guid("0f8d97db-08d0-4701-8b24-a303c9e38dee"), "https://www.1obl.ru/apple-touch-icon.png", "https://www.1obl.ru/favicon-32x32.png", new Guid("baa4c41d-5043-404f-94d9-3c7f3fa6a362") },
                    { new Guid("14a8242b-5a25-49fa-a22b-d40a59959613"), "https://tass.ru/favicon/180.svg", "https://tass.ru/favicon/57.png", new Guid("a1124959-5396-44f8-8c7b-01e7efcdc823") },
                    { new Guid("1719b89f-9fc6-4a15-9808-18f5044671e1"), "https://cdnstatic.rg.ru/images/touch-icon-ipad-retina_512x512.png", "https://rg.ru/favicon.ico", new Guid("b3a8f5c8-b7ad-444c-8558-893e41b5b117") },
                    { new Guid("25dad03a-19c9-4b73-92d8-1b3268834c30"), "https://s01.stc.yc.kpcdn.net/s0/2.1.321/adaptive/favicon-128.png", "https://s01.stc.yc.kpcdn.net/s0/2.1.321/adaptive/favicon-32.png", new Guid("20cec815-9736-4114-b31d-386741e63e78") },
                    { new Guid("26c4d1ee-cc57-4894-8130-62011e769794"), "https://edition.cnn.com/media/sites/cnn/apple-touch-icon.png", "https://edition.cnn.com/media/sites/cnn/favicon.ico", new Guid("96c5304f-da5a-4afd-84c3-09ba850c1738") },
                    { new Guid("27b4d2a5-c615-4de2-9df9-53a07ac80886"), "https://ixbt.games/images/favicon/gt/apple-touch-icon.png", "https://ixbt.games/images/favicon/gt/apple-touch-icon.png", new Guid("6121ae9f-44ad-429d-9265-16f1d6aa285b") },
                    { new Guid("39e51803-01df-4214-a706-9e16cc79ef15"), "https://www.interfax.ru/touch-icon-ipad-retina.png", "https://www.interfax.ru/touch-icon-iphone.png", new Guid("f3c6a043-5f62-4556-a9ad-987946855540") },
                    { new Guid("3ca54cc4-c207-4144-9449-e963bf6b698e"), "https://st.championat.com/i/favicon/apple-touch-icon.png", "https://st.championat.com/i/favicon/favicon-32x32.png", new Guid("b2fb45d4-a7c0-473f-bdb6-0d31c53afe4a") },
                    { new Guid("451f6206-758f-4be7-ac08-35538a36771b"), "https://im.kommersant.ru/ContentFlex/images/favicons2020/apple-touch-icon-180.png", "https://im.kommersant.ru/ContentFlex/images/favicons2020/favicon-32.png", new Guid("2e12143b-93c7-4d1e-a743-3a37b441adf0") },
                    { new Guid("48d2be15-a368-4cfb-8745-8701805c8c24"), "https://www.pravda.ru/pix/apple-touch-icon.png", "https://www.pravda.ru/favicon.ico", new Guid("78d5b76d-67e9-440b-b8fc-23a3a709fb24") },
                    { new Guid("4ccdc30f-4d26-48f1-9271-3d7355068fd8"), "https://www.ixbt.com/favicon.ico", "https://www.ixbt.com/favicon.ico", new Guid("57f00175-5f15-40e5-b916-cb9ddce8f48e") },
                    { new Guid("4d29ca25-56bc-4c21-b4f3-e6b8d42e67bf"), "https://svpressa.ru/favicon-96x96.png?v=1471426270000", "https://svpressa.ru/favicon-32x32.png?v=1471426270000", new Guid("b69ca73d-e019-4a9c-9bee-075a94cb71e6") },
                    { new Guid("5572038f-d445-4832-8e6f-75d321d272c3"), "https://tsargrad.tv/favicons/apple-touch-icon-180x180.png?s2", "https://tsargrad.tv/favicons/favicon-32x32.png?s2", new Guid("5db48a6c-28d2-45e5-bcf4-5fbaa5d9c377") },
                    { new Guid("56312a34-ef32-47a9-81e1-0e3d676feff1"), "https://www.hltv.org/img/static/favicon/apple-touch-icon.png", "https://www.hltv.org/img/static/favicon/favicon-32x32.png", new Guid("019d9405-8c57-4a83-9c27-278f4c3d2857") },
                    { new Guid("56f37d10-c24f-4d2d-8e78-12f68beae34e"), "https://www.cybersport.ru/favicon-192x192.png", "https://www.cybersport.ru/favicon-32x32.png", new Guid("78096d9a-daaf-4268-9c38-d3161bc84809") },
                    { new Guid("57e237bf-49a3-43e0-a59b-f69815ca3519"), "https://ura.news/apple-touch-icon.png", "https://s.ura.news/favicon.ico?3", new Guid("a2ad35d8-90cf-4409-bbfd-c07861da373b") },
                    { new Guid("59134a00-bc30-494f-bace-c70f7b462cca"), "https://vz.ru/apple-touch-icon.png", "https://vz.ru/static/images/favicon.ico", new Guid("d37f1561-ed9d-4487-8762-d153d2eafa65") },
                    { new Guid("5fb53e97-dab9-4811-8cf2-f0a38bd614b1"), "https://cdn.iz.ru/profiles/portal/themes/purple/images/favicons/android-icon-192x192.png", "https://cdn.iz.ru/profiles/portal/themes/purple/images/favicons/favicon-32x32.png", new Guid("4dd1448e-cdf3-4750-89bd-5364cc2351fb") },
                    { new Guid("61e25d02-bbd0-48f2-9141-913f24e7c080"), "https://aif.ru/img/icon/apple-touch-icon.png?44f", "https://aif.ru/img/icon/favicon-32x32.png?44f", new Guid("d8df4791-788b-4dd1-8433-2cb5043c3d05") },
                    { new Guid("6cbfb537-06e0-419e-8b66-861f8be78ff1"), "https://3dnews.ru/assets/images/3dnews_logo_soc.png", "https://3dnews.ru/assets/3dnews_logo_color.png", new Guid("6be0b2ec-653f-4e8e-85e8-aab303c8e631") },
                    { new Guid("6ceb5db9-7555-4f61-abde-d4c89b608163"), "https://www.nytimes.com/vi-assets/static-assets/apple-touch-icon-28865b72953380a40aa43318108876cb.png", "https://www.nytimes.com/vi-assets/static-assets/ios-default-homescreen-57x57-dark-b395ebcad5b63aff9285aab58e31035e.png", new Guid("bfa58065-cc2a-463b-884a-f14dbd140f17") },
                    { new Guid("a68c3bcb-b7a2-4ba0-ab28-21e6f3102e7d"), "https://s.rbk.ru/v10_rbcnews_static/common/common-10.10.120/images/android-chrome-512x512.png", "https://s.rbk.ru/v10_rbcnews_static/common/common-10.10.120/images/favicon.png", new Guid("c4912fba-ab5c-4d50-8cf0-263cf9cff9ff") },
                    { new Guid("ab98bb55-0276-407b-91b2-4a69249ad1df"), "https://www.m24.ru/img/fav/apple-touch-icon.png", "https://www.m24.ru/img/fav/favicon-32x32.png", new Guid("90032753-6d6b-4066-ba0c-cd2a922c3833") },
                    { new Guid("b6044c8d-0206-4844-9b12-9087fec4ff4f"), "https://cdnn21.img.ria.ru/i/favicons/favicon.svg", "https://cdnn21.img.ria.ru/i/favicons/favicon.ico", new Guid("7764ba9d-b1b2-45df-8bc4-af11e680f124") },
                    { new Guid("b6dbca46-8332-4548-9f8f-15fcb6f334a1"), "https://life.ru/appletouch/apple-icon-180%D1%85180.png", "https://life.ru/favicon-32%D1%8532.png", new Guid("c37f18b1-17a3-4c6f-8f2e-067e33ec5abb") },
                    { new Guid("c6b84e13-8c08-4276-abb9-4a389f1e8a63"), "https://russian.rt.com/static/blocks/touch-icon/apple-touch-icon-144x144-precomposed.png", "https://russian.rt.com/favicon.ico", new Guid("20b89422-0d9f-4dc4-b58b-73b03dbeaff0") },
                    { new Guid("e69ba140-f233-4132-bf74-ea75431dd953"), "https://static.gazeta.ru/nm2021/img/icons/favicon.svg", "https://static.gazeta.ru/nm2021/img/icons/favicon.svg", new Guid("7d7bea19-21c2-4fb8-a6ee-3ca263e0638d") },
                    { new Guid("ed60a42b-2a39-4aab-94c1-c3c187e71fc9"), "https://static.ngs.ru/jtnews/dist/static/favicons/apple/apple-favicon-74-180.png", "https://static.ngs.ru/jtnews/dist/static/favicons/favicon-rugion-32.ico", new Guid("d31a10b3-97a3-40ed-9a9a-5d49610f0337") },
                    { new Guid("f38fb214-02ec-4b13-b241-3fb240c7af9a"), "https://www.sports.ru/apple-touch-icon-1024.png", "https://www.sports.ru/apple-touch-icon-76.png", new Guid("427c22c2-9bf1-486c-9567-3e014e8c5e5d") },
                    { new Guid("f6ed34cd-62a2-45d4-bb9f-0e9c6c6dd0d1"), "https://www.belta.by/images/storage/banners/000016_a133e848cb2e7b1debb7102d19e4d139_work.svg", "https://www.belta.by/images/storage/banners/000016_a133e848cb2e7b1debb7102d19e4d139_work.svg", new Guid("177d73de-56e1-4976-b896-7eaa63a26e9a") },
                    { new Guid("f7c068fb-60a5-407b-81e3-0808c752ac5b"), "https://icdn.lenta.ru/images/icons/icon-256x256.png", "https://icdn.lenta.ru/favicon.ico", new Guid("16ba03ad-b234-422d-bed1-b82a80d58f1f") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_editor_settings",
                columns: new[] { "id", "is_required", "name_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("0b3e3484-3e73-4c03-95aa-4c3949b06734"), true, "//span[@itemprop='name']/a/text()", new Guid("30976135-f330-49f7-a835-d8e3414db02e") },
                    { new Guid("0c7af982-2192-4db5-ba12-d0179536c95b"), true, "//div[contains(@class, 'PageArticleContent_authors')]//a[contains(@class, 'LinksOfAuthor_item')]/text()", new Guid("d2a7f188-5b3f-409b-b544-3d587a8900b8") },
                    { new Guid("2124bf63-20d8-4bc0-ab3a-47e83c1ff270"), true, "//footer[@class='news-item__footer']/div[@class='news-item__footer-after-news']/p[position()=1]//span/text()", new Guid("1789ce3c-74e0-486d-bef4-c72125575acb") },
                    { new Guid("2a98eda5-0eec-4017-92c2-8a3c58a86a97"), true, "//div[@class='headline__footer']//div[@class='byline__names']/span[@class='byline__name']/text()", new Guid("7e6554f8-2b2e-4c28-81b3-300619a7aedb") },
                    { new Guid("476e78c0-8d08-4929-95cd-3143e9c2836b"), true, "//div[contains(@class, 'styles_bodyWrapper')]//div[contains(@class, 'styles_authorsLinks')]/a/text()", new Guid("a9a5a136-342b-4b21-a7b5-4cd077ff62fc") },
                    { new Guid("4c106db2-84b0-4d57-83df-5553626feafb"), true, "//article//header//div[@class='article-head__author-name']/a[@rel='author']/span/text()", new Guid("4bc575be-67cd-4488-880c-93e8ad9f978b") },
                    { new Guid("589fc5b5-12d9-4d6e-ad8e-b852b544210b"), true, "//a[@class='article__author']/text()", new Guid("08e3734e-ce93-4bb9-b1af-26011fc19be6") },
                    { new Guid("5cda786f-26f7-4517-b000-fd8f48d1ea95"), true, "//span[@itemprop='author']/span[@itemprop='name']/@content", new Guid("f7fffc1f-b099-441d-92b6-d9a68b0eb763") },
                    { new Guid("6a940f99-c038-4181-ad26-1f52e8422e6e"), false, "//div[@itemprop='author']//p[@itemprop='name']/text()", new Guid("338849b8-0ae0-4b12-98f3-f46657efdec8") },
                    { new Guid("6c9bc4d4-35b5-477b-a586-5b75ec58ca74"), true, "//div[@class='article_top']//div[@class='authors']//div[@class='autor']//span/text()", new Guid("757f5794-0c34-4451-99d1-02d8213c663e") },
                    { new Guid("7e41a6c1-f590-4c60-90e6-87c19baf47d5"), false, "//div[@class='author']/span[@itemprop='author']/span[@itemprop='name']/a/text()", new Guid("4486a185-5466-41cf-9f16-43a63dbbec7b") },
                    { new Guid("8c37c31f-ade7-4f5f-aac2-dfece6c4e8f2"), true, "//div[@itemprop='author']/span[@itemprop='name']/text()", new Guid("7878ff5d-1e93-45e5-a6a2-dfcdd2c5b826") },
                    { new Guid("9e9437a7-7bc4-4e2f-a408-c382e99cb3c9"), true, "//article//span[@class='author']/a[@class='authorName']/span/text()", new Guid("83b05f08-1095-462d-a8e5-3a3db953c1b4") },
                    { new Guid("b0304e80-37d6-46e1-ba03-f308f07f2453"), true, "//*[@itemprop='author']/*[@itemprop='name']//text()", new Guid("93c893f7-b6e4-41af-acc8-573ba0be0280") },
                    { new Guid("d63b17c1-11ef-43a8-b3b9-cba6651bbc4e"), false, "//p[@class='doc__text document_authors']/text()", new Guid("176bd21c-7f2b-4119-a6a7-ce4ff03f9e09") },
                    { new Guid("d6d0cdc3-2ac5-4f73-b966-976c7c0cd944"), true, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']//a[@itemprop='author']//span[@itemprop='name']/text()", new Guid("26ba4a33-d7d2-4fad-b982-0bf2fec9f7f2") },
                    { new Guid("d815b2c9-9c97-4397-b364-d9b1d6162131"), false, "//div[@class='article__authors']//*[@class='article__authors__author']/span[@class='article__authors__author__name']/text()", new Guid("f6e16297-26ea-492d-8117-d89dc49be348") },
                    { new Guid("dac259f0-21d8-404d-ab19-8ae2a8f4c5d1"), false, "//div[@class='topic-authors']/a[@class='topic-authors__author']/text()", new Guid("79f68b7e-c6a9-45ef-8ead-35afb3a15955") },
                    { new Guid("f1c3cb5f-c5d4-41c7-873b-c0e7382bd78d"), true, "//div[contains(@class, 'full-article')]/div[@class='authors-block']//span[text()='Автор']/../a/text()", new Guid("820650a0-dde5-47bd-9212-3ce27f09dbc9") },
                    { new Guid("f55e941a-5ea0-4829-ba52-8ed81bf40e86"), true, "//div[@class='container-fluid publication-footer']//a[contains(@class, 'text-secondary')]/@title", new Guid("9b9bc804-6747-464e-ae8d-746acb9bd7b6") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_modified_at_settings",
                columns: new[] { "id", "is_required", "modified_at_culture_info", "modified_at_time_zone_info_id", "modified_at_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("3227cb5b-ac62-4c29-a0d7-acf54f68b918"), false, "ru-RU", "Russian Standard Time", "//div[@class='doc_header__time']/span[contains(@class, 'publish_update')]/text()", new Guid("176bd21c-7f2b-4119-a6a7-ce4ff03f9e09") },
                    { new Guid("a11e812e-9077-4117-8ee9-104a84ae0110"), true, "ru-RU", "Russian Standard Time", "//div[@class='article__info']//div[@class='article__info-date']/span[@class='article__info-date-modified']/text()", new Guid("cc37b3d9-b6a8-4c52-87aa-879a3ced3de1") },
                    { new Guid("ae2d9f6a-4206-4b43-867f-78661c89d979"), true, "ru-RU", "Russian Standard Time", "//meta[@property='article:modified_time']/@content", new Guid("37f332ce-c861-4008-9f09-af03d20d39cf") },
                    { new Guid("ffe0ec56-f763-45cf-a8a2-c289f832ca1d"), false, "ru-RU", "UTC", "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark_update')]//span[@ca-ts]/text()", new Guid("9ac79fb9-acd1-4533-91a9-01b677955ef4") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_picture_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("012f4711-f266-4d29-9972-49aa8005a38b"), true, new Guid("30976135-f330-49f7-a835-d8e3414db02e"), "//header//figure//picture/img/@src" },
                    { new Guid("0d175dab-1a82-4246-8858-187e68e080b3"), true, new Guid("93c893f7-b6e4-41af-acc8-573ba0be0280"), "//div[contains(@class, 'newsMediaContainer')]/img/@data-src" },
                    { new Guid("174963a7-a4fe-4b41-8514-9bcbd048be0f"), false, new Guid("4bc575be-67cd-4488-880c-93e8ad9f978b"), "//article//header/div[@class='article-head__photo']/img/@src" },
                    { new Guid("31ea98f6-fc7c-42d5-9839-93bc5b70180b"), false, new Guid("26ba4a33-d7d2-4fad-b982-0bf2fec9f7f2"), "//img[@itemprop='image']/@src" },
                    { new Guid("4135ab8b-ce43-4162-8768-6f7b974e41c7"), true, new Guid("37f332ce-c861-4008-9f09-af03d20d39cf"), "//div[@data-gtm-el='content-body']//picture/img/@src" },
                    { new Guid("48002e86-1133-4b53-9be7-85b5c838b36c"), false, new Guid("f89bf1b3-d18f-4eea-8c3e-f2254fabb0fd"), "//div[@class='b-material-incut-m-image']//@src" },
                    { new Guid("487147bd-36f2-4895-861c-5fbe6d8b64c0"), false, new Guid("338849b8-0ae0-4b12-98f3-f46657efdec8"), "//figure//img/@src" },
                    { new Guid("4ef9e71e-dede-4215-bf05-c31aad196dfe"), false, new Guid("79f68b7e-c6a9-45ef-8ead-35afb3a15955"), "//div[contains(@class, 'topic-body__title-image')]//img[contains(@class, 'picture__image')]/@src" },
                    { new Guid("59b9d108-f908-4026-9c51-4c72ce604a3b"), true, new Guid("8735fee4-71c9-4733-b987-e91a03d7252c"), "//div[contains(@class, 'big_photo')]//div[@class='big_photo__img']//img/@data-src" },
                    { new Guid("5c388e64-3c9d-4511-bfbb-6de343ef1f44"), true, new Guid("7878ff5d-1e93-45e5-a6a2-dfcdd2c5b826"), "//div[@itemprop='articleBody']//div[@itemprop='image']/picture/img[@itemprop='contentUrl']/@src" },
                    { new Guid("6fb5020f-a82e-40fb-8526-60d170d4cd69"), true, new Guid("9b9bc804-6747-464e-ae8d-746acb9bd7b6"), "//a[@class='glightbox']/img[contains(@class, 'pub-cover')]/@src" },
                    { new Guid("78c332cc-12cf-437e-876b-e48579ec8183"), false, new Guid("a9a5a136-342b-4b21-a7b5-4cd077ff62fc"), "//article//header/div[contains(@class, 'styles_cover_media')]/img/@src" },
                    { new Guid("7ae0536c-69e5-45e6-974d-97679f4b3411"), true, new Guid("08e3734e-ce93-4bb9-b1af-26011fc19be6"), "//div[@class='article__media']//img/@src" },
                    { new Guid("7db1c378-30f5-4cbb-9f3b-c9a5bf7e4cbb"), false, new Guid("cc37b3d9-b6a8-4c52-87aa-879a3ced3de1"), "//div[@class='photoview__open']/img/@src" },
                    { new Guid("843f9bb9-1f50-40c8-9752-022fb1e21b7e"), false, new Guid("6fc60d09-2fc4-4ad8-8dee-bb611058cf2e"), "//article/figure/img/@src" },
                    { new Guid("87a7445a-9f82-4fa2-99bd-94ff8c570087"), false, new Guid("820650a0-dde5-47bd-9212-3ce27f09dbc9"), "//div[contains(@class, 'full-article')]/div[contains(@class, 'gallery')]/picture/img/@src" },
                    { new Guid("93ca1cc7-4142-44eb-8065-b902568b6fc3"), true, new Guid("c9e29a4e-08f4-4a66-b328-74981adfdcee"), "//picture/img/@src" },
                    { new Guid("975ff01a-a951-4327-bb89-e3bcb563936e"), true, new Guid("7e6554f8-2b2e-4c28-81b3-300619a7aedb"), "//div[contains(@class, 'article__lede-wrapper')]//picture/img/@src" },
                    { new Guid("a8547d98-40e3-4a94-b250-ce98dd106e16"), true, new Guid("857dff07-a9c8-443c-91e1-02ff334625ee"), "//meta[@property='og:image']/@content" },
                    { new Guid("aa289646-7102-4c2c-a40f-6ca780aa3c3c"), false, new Guid("0846cfbd-daec-4840-82c8-1a6396bc68d4"), "//div[contains(@class, 'article__cover')]/img[@class='article__cover-image ']/@src" },
                    { new Guid("ad87d080-c2f4-4f07-b255-1828c5edbf5e"), false, new Guid("4486a185-5466-41cf-9f16-43a63dbbec7b"), "//div[@class='b_article-media']//div[@class='mainarea-wrapper']/figure/img[@class='item-image-front']/@src" },
                    { new Guid("c1032035-8b62-4807-a49c-ccdd093d4e98"), false, new Guid("9ac79fb9-acd1-4533-91a9-01b677955ef4"), "//div[contains(@class, 'HeaderMedia_image')]//img[contains(@class, 'Image_image')]/@src" },
                    { new Guid("c838372f-d48d-46d9-b775-af0a274b3078"), false, new Guid("83b05f08-1095-462d-a8e5-3a3db953c1b4"), "//article//div[@class='image-con' and position() = 1]/picture/img/@src" },
                    { new Guid("d1e93eb6-bec3-4831-bf74-7ba6d74f73bf"), false, new Guid("ebf5a57a-96d0-495d-a967-e94965bd48a2"), "//div[@class='inner_content']//div[@class='main_img']//img/@src" },
                    { new Guid("fd995373-f7c9-4695-9503-77b90d3e9165"), false, new Guid("757f5794-0c34-4451-99d1-02d8213c663e"), "//div[@class='img_box']/a[@class='zoom_js']/img/@src" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "published_at_culture_info", "published_at_time_zone_info_id", "published_at_x_path" },
                values: new object[,]
                {
                    { new Guid("01defbcf-eae7-45f4-8e82-049aeaa49b97"), true, new Guid("79f68b7e-c6a9-45ef-8ead-35afb3a15955"), "ru-RU", "Russian Standard Time", "//div[@class='topic-page__header']//a[contains(@class, 'topic-header__time')]/text()" },
                    { new Guid("05b0240e-0f0e-49c2-bf13-e744829c506e"), true, new Guid("83b05f08-1095-462d-a8e5-3a3db953c1b4"), "en-US", "Central Europe Standard Time", "//article//div[@class='article-info']/div[@class='date']/text()" },
                    { new Guid("14d40d60-d0ec-409b-8f8e-54f30dbfee54"), true, new Guid("7878ff5d-1e93-45e5-a6a2-dfcdd2c5b826"), "ru-RU", null, "//div[@class='publication-info']/time[@itemprop='datePublished']/@datetime" },
                    { new Guid("1bfe0ff9-532a-4481-a3c6-4d3dceeb7fe9"), true, new Guid("f7fffc1f-b099-441d-92b6-d9a68b0eb763"), "ru-RU", "Russian Standard Time", "//div[@class='b-article__top-author']/p[@class='date']/text()" },
                    { new Guid("1ef5734c-8ca6-4409-833c-83a9e44b76d0"), true, new Guid("8735fee4-71c9-4733-b987-e91a03d7252c"), "ru-RU", null, "//div[@class='article_page__left__top__left']//div[@class='article_page__left__top__time']//time/@datetime" },
                    { new Guid("20189b50-1bab-4c55-87d5-36ea2c5ef3d4"), true, new Guid("820650a0-dde5-47bd-9212-3ce27f09dbc9"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'full-article')]//time/text()" },
                    { new Guid("290bd535-94b5-4040-b9d6-7f6b2ee139be"), true, new Guid("d2a7f188-5b3f-409b-b544-3d587a8900b8"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'PageArticleContent_date')]/text()" },
                    { new Guid("2b0052bc-82cc-451d-b052-aa65c45bf7b0"), true, new Guid("6fc60d09-2fc4-4ad8-8dee-bb611058cf2e"), "ru-RU", "Russian Standard Time", "//article/div[@class='header']/span/text()" },
                    { new Guid("39d98bae-9b4d-4218-a954-37e4d04aa931"), true, new Guid("757f5794-0c34-4451-99d1-02d8213c663e"), "ru-RU", "Russian Standard Time", "//div[@class='article_top']//div[@class='date']//time/text()" },
                    { new Guid("4d7ba2d1-e735-4700-b35c-91011b59bfdd"), true, new Guid("4486a185-5466-41cf-9f16-43a63dbbec7b"), "ru-RU", null, "//article/div[@class='b_article-header']//time[@itemprop='datePublished']/@datetime" },
                    { new Guid("513326f1-fc7d-4f91-a5a4-354223165531"), true, new Guid("f6e16297-26ea-492d-8117-d89dc49be348"), "ru-RU", null, "//div[@class='article__header__info-block']/time[@class='article__header__date']/@datetime" },
                    { new Guid("515812c9-0bc6-45e8-a14f-0e684c8657b2"), true, new Guid("9ac79fb9-acd1-4533-91a9-01b677955ef4"), "ru-RU", "UTC", "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark')]//span[@ca-ts]/text()" },
                    { new Guid("63907809-a945-4065-9429-1abcabc8db0b"), true, new Guid("30976135-f330-49f7-a835-d8e3414db02e"), "en-US", null, "//time/@datetime" },
                    { new Guid("6bd21ba9-8ea7-4677-9fc9-36190288182c"), true, new Guid("338849b8-0ae0-4b12-98f3-f46657efdec8"), "ru-RU", "Ekaterinburg Standard Time", "//div[@itemprop='datePublished']/time/@datetime" },
                    { new Guid("77dc783c-304f-48e9-9fab-da12f7b78789"), true, new Guid("39e5eab7-7867-44db-91b2-fdd8ee159665"), "ru-RU", "Russian Standard Time", "//article[@itemprop='articleBody']/meta[@itemprop='datePublished']/@content" },
                    { new Guid("949d55f0-ab6a-4f82-9941-0799bf3e33bb"), true, new Guid("7e6554f8-2b2e-4c28-81b3-300619a7aedb"), "en-US", "Eastern Standard Time", "//div[@class='headline__footer']//div[contains(@class, 'headline__byline-sub-text')]/div[@class='timestamp']/text()" },
                    { new Guid("9f43bb60-a5a6-4886-a963-336c6b3e31be"), true, new Guid("93c893f7-b6e4-41af-acc8-573ba0be0280"), "ru-RU", null, "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("a35fe3f0-f8c2-4e7d-a401-5a56b6855cfc"), true, new Guid("0846cfbd-daec-4840-82c8-1a6396bc68d4"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'article__date-autor-shortcode')]/div[contains(@class, 'article__date')]/time[@class='date']/@datetime" },
                    { new Guid("aa38108d-6f02-4418-a2b1-4a7fdfb0477f"), true, new Guid("4bc575be-67cd-4488-880c-93e8ad9f978b"), "ru-RU", "Russian Standard Time", "//article//header//time[@class='article-head__date']/text()" },
                    { new Guid("aa50ca5a-a1d3-42a3-a3d4-5276ca15edb0"), true, new Guid("26ba4a33-d7d2-4fad-b982-0bf2fec9f7f2"), "ru-RU", null, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']/span[@itemprop='datePublished']/@content" },
                    { new Guid("ae403b01-a18c-421c-ba2e-deffb24286d2"), true, new Guid("c9e29a4e-08f4-4a66-b328-74981adfdcee"), "ru-RU", "Russian Standard Time", "//div[@class='b-text__date']/text()" },
                    { new Guid("b40710f0-99f2-49b1-9bbe-5cbcc2c69e9f"), true, new Guid("08e3734e-ce93-4bb9-b1af-26011fc19be6"), "ru-RU", "Russian Standard Time", "//div[@class='article__meta']/time/text()" },
                    { new Guid("b938f3c0-aeb9-4d81-99c7-5b91d0172251"), false, new Guid("9b9bc804-6747-464e-ae8d-746acb9bd7b6"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'pubdatetime')]/text()" },
                    { new Guid("c677ed50-5a4d-4b9f-bb13-cb4ec259ff20"), true, new Guid("f89bf1b3-d18f-4eea-8c3e-f2254fabb0fd"), "ru-RU", "Russian Standard Time", "//p[@class='b-material__date']/text()" },
                    { new Guid("caaec88b-9f54-4082-9c23-9be89fa2a7cd"), true, new Guid("1789ce3c-74e0-486d-bef4-c72125575acb"), "ru-RU", null, "//header[@class='news-item__header']//time/@content" },
                    { new Guid("d2aeb81c-63b9-474a-a949-b44be596d1c9"), true, new Guid("176bd21c-7f2b-4119-a6a7-ce4ff03f9e09"), "ru-RU", null, "//div[@class='doc_header__time']/time[@class='doc_header__publish_time']/@datetime" },
                    { new Guid("d2c7deea-325f-4f8a-ad52-c9352829382e"), true, new Guid("a9a5a136-342b-4b21-a7b5-4cd077ff62fc"), "ru-RU", "UTC", "//article//header//div[contains(@class, 'styles_meta')]//div[contains(@class, 'styles_metaItem')]/text()" },
                    { new Guid("d6063bcf-8442-495f-8298-8fa99f10c0d1"), true, new Guid("37f332ce-c861-4008-9f09-af03d20d39cf"), "ru-RU", "Russian Standard Time", "//meta[@property='article:published_time']/@content" },
                    { new Guid("e6039292-04e7-4aab-a124-bf3a6c113445"), true, new Guid("857dff07-a9c8-443c-91e1-02ff334625ee"), "ru-RU", null, "//article/header//time/@datetime" },
                    { new Guid("fe579abd-c5b4-49ef-825a-97557030476c"), true, new Guid("ebf5a57a-96d0-495d-a967-e94965bd48a2"), "ru-RU", "Russian Standard Time", "//div[@class='date_full']/text()" },
                    { new Guid("fe77f1ed-0b50-4d88-88ab-8f660e3cb204"), true, new Guid("cc37b3d9-b6a8-4c52-87aa-879a3ced3de1"), "ru-RU", "Russian Standard Time", "//div[@class='article__info']//div[@class='article__info-date']/a/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_sub_title_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("0114a05b-7af1-492d-a77b-1dda18723c07"), false, new Guid("f7fffc1f-b099-441d-92b6-d9a68b0eb763"), "//h4/text()" },
                    { new Guid("033a19ab-b6b8-4d0f-a1d9-5c041b95b53a"), true, new Guid("338849b8-0ae0-4b12-98f3-f46657efdec8"), "//p[@itemprop='alternativeHeadline']/span/text()" },
                    { new Guid("0ba3b846-2ebf-45d7-a819-a79b5e06a940"), true, new Guid("4486a185-5466-41cf-9f16-43a63dbbec7b"), "//h2/text()" },
                    { new Guid("0cb02dd1-646d-43a6-89b2-6fa66378c9f4"), true, new Guid("26ba4a33-d7d2-4fad-b982-0bf2fec9f7f2"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()=1]/text()" },
                    { new Guid("1033793b-baab-4203-97ab-9dc6af915c51"), false, new Guid("9ac79fb9-acd1-4533-91a9-01b677955ef4"), "//h3/text()" },
                    { new Guid("1bb66a2d-d794-4675-a281-6a735e944b66"), true, new Guid("93c893f7-b6e4-41af-acc8-573ba0be0280"), "//div[@itemprop='alternativeHeadline']/text()" },
                    { new Guid("4356bcaf-bcc6-41bf-a516-3c2511e070b5"), true, new Guid("08e3734e-ce93-4bb9-b1af-26011fc19be6"), "//div[@class='article__intro']/p/text()" },
                    { new Guid("4e8666d0-b9db-4f80-a04b-65c6a6369b53"), true, new Guid("37f332ce-c861-4008-9f09-af03d20d39cf"), "//meta[@name='description']/@content" },
                    { new Guid("517c4400-d422-4d0f-8006-eaeda6586ae7"), true, new Guid("9b9bc804-6747-464e-ae8d-746acb9bd7b6"), "//div[@class='container-fluid shifted']/p[@class='announce lead']/text()" },
                    { new Guid("58d87828-4fb6-47a8-b375-891cd70748ca"), true, new Guid("cc37b3d9-b6a8-4c52-87aa-879a3ced3de1"), "//h1[@class='article__second-title']/text()" },
                    { new Guid("723bf373-1e02-4871-8347-4b514729108a"), false, new Guid("d2a7f188-5b3f-409b-b544-3d587a8900b8"), "//div[contains(@class, 'PageArticleContent_lead')]/text()" },
                    { new Guid("7b3ab4b3-50d6-4003-bc67-8b2116ff3648"), false, new Guid("f6e16297-26ea-492d-8117-d89dc49be348"), "//div[contains(@class, 'article__text')]/div[@class='article__text__overview']/span/text()" },
                    { new Guid("8b95eac2-07f1-433d-9d2e-7168f7a97f96"), true, new Guid("0846cfbd-daec-4840-82c8-1a6396bc68d4"), "//div[contains(@class, 'article__summary')]/text()" },
                    { new Guid("9515b168-080d-437e-8051-6f1fcd677b94"), false, new Guid("176bd21c-7f2b-4119-a6a7-ce4ff03f9e09"), "//header[@class='doc_header']/h2[contains(@class, 'doc_header__subheader')]/text()" },
                    { new Guid("9889a6a0-5c77-48ce-af46-07ce8621f0cd"), false, new Guid("79f68b7e-c6a9-45ef-8ead-35afb3a15955"), "//div[contains(@class, 'topic-body__title')]/text()" },
                    { new Guid("ad690012-45dc-41e1-8bc4-afc368ee27d5"), true, new Guid("30976135-f330-49f7-a835-d8e3414db02e"), "//header/p[@id='article-summary']/text()" },
                    { new Guid("ae9aaeb8-0489-4f21-a161-f152f5bd776d"), false, new Guid("6fc60d09-2fc4-4ad8-8dee-bb611058cf2e"), "//h4/text()" },
                    { new Guid("cb270498-4a97-4dfc-bb67-f725612c37fb"), true, new Guid("820650a0-dde5-47bd-9212-3ce27f09dbc9"), "//h1/text()" },
                    { new Guid("d4de6a70-191b-43f6-8787-c6c374b15936"), true, new Guid("83b05f08-1095-462d-a8e5-3a3db953c1b4"), "//p[@class='headertext' and @itemprop='description']/text()" },
                    { new Guid("d7f73583-901b-4b0f-95e7-f0248ba518ae"), true, new Guid("857dff07-a9c8-443c-91e1-02ff334625ee"), "//div[contains(@class, 'js-mediator-article')]/*[position()=1]/text()" },
                    { new Guid("fcce5642-31f8-4444-9244-b138e3437428"), false, new Guid("a9a5a136-342b-4b21-a7b5-4cd077ff62fc"), "//article//header//p[contains(@class, 'styles_subtitle')]/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_video_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("02df7689-1ef0-4fa8-8cc6-20d51f96c40e"), false, new Guid("79f68b7e-c6a9-45ef-8ead-35afb3a15955"), "//div[contains(@class='eagleplayer')]//video/@src" },
                    { new Guid("aabc6147-d7c5-4cb3-b418-cb7b52591c7d"), false, new Guid("cc37b3d9-b6a8-4c52-87aa-879a3ced3de1"), "//div[@class='article__header']//div[@class='media__video']//video/@src" },
                    { new Guid("b2c36fcd-f83e-49f7-9e06-a1f0af00b1d3"), false, new Guid("83b05f08-1095-462d-a8e5-3a3db953c1b4"), "//article//div[@class='videoWrapper' and @itemprop='video']/iframe[@class='video']/@src" },
                    { new Guid("d10ca59c-a8bc-40e0-bab2-63bf818ccaba"), false, new Guid("d2a7f188-5b3f-409b-b544-3d587a8900b8"), "//div[contains(@class, 'PageContentCommonStyling_text')]/rg-video//video/@src" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_modified_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_modified_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("3af984ef-7353-47df-9e5c-ce743b963297"), "\"обновлено\" HH:mm , dd.MM.yyyy", new Guid("3227cb5b-ac62-4c29-a0d7-acf54f68b918") },
                    { new Guid("4013a47a-4cac-4c40-b237-52c77f24e071"), "yyyy-MM-ddTHH:mm:ss.fff\"Z+0300\"", new Guid("ae2d9f6a-4206-4b43-867f-78661c89d979") },
                    { new Guid("5bd27634-6ac5-4e68-b66a-056105692edf"), "\"обновлено\" d MMMM, HH:mm", new Guid("ffe0ec56-f763-45cf-a8a2-c289f832ca1d") },
                    { new Guid("60661525-c370-4621-a3a9-f525f1feb83e"), "\"обновлено\" HH:mm , dd.MM", new Guid("3227cb5b-ac62-4c29-a0d7-acf54f68b918") },
                    { new Guid("7273991d-f174-4eea-87eb-97596505033b"), "\"обновлено\" d MMMM yyyy, HH:mm", new Guid("ffe0ec56-f763-45cf-a8a2-c289f832ca1d") },
                    { new Guid("97972f5c-c78b-4f0b-a229-9eeadb13ee74"), "(\"обновлено:\" HH:mm dd.MM.yyyy)", new Guid("a11e812e-9077-4117-8ee9-104a84ae0110") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_published_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("1290673c-fcd6-405b-96d9-5a031ec50f32"), "yyyy-MM-ddTHH:mm:ss.fffZ", new Guid("e6039292-04e7-4aab-a124-bf3a6c113445") },
                    { new Guid("1c3d55e7-b723-4b12-96a0-bb4aed13f644"), "HH:mm", new Guid("c677ed50-5a4d-4b9f-bb13-cb4ec259ff20") },
                    { new Guid("2eb6cfee-e04a-4332-bfd4-9950b8afbc24"), "d MMMM, HH:mm", new Guid("d2c7deea-325f-4f8a-ad52-c9352829382e") },
                    { new Guid("38b3b7b6-6b1e-4473-bbb5-d62a19a3306b"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("63907809-a945-4065-9429-1abcabc8db0b") },
                    { new Guid("4ee53c7e-7c74-4e0c-a280-54da577fec4f"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("d2aeb81c-63b9-474a-a949-b44be596d1c9") },
                    { new Guid("5950050d-8087-4525-8df5-e819f6fdd7cc"), "HH:mm", new Guid("b40710f0-99f2-49b1-9bbe-5cbcc2c69e9f") },
                    { new Guid("5d280743-f629-4bd7-a668-24ded48dc56d"), "d MMMM, HH:mm", new Guid("515812c9-0bc6-45e8-a14f-0e684c8657b2") },
                    { new Guid("6220adc6-0385-4a92-a6d2-d2dfccda94f4"), "dd MMMM yyyy HH:mm", new Guid("b40710f0-99f2-49b1-9bbe-5cbcc2c69e9f") },
                    { new Guid("641aa11a-b884-49ad-a8ac-cb6ebba86402"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("aa50ca5a-a1d3-42a3-a3d4-5276ca15edb0") },
                    { new Guid("702de334-8dd8-44e7-87dc-2159891e216f"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("caaec88b-9f54-4082-9c23-9be89fa2a7cd") },
                    { new Guid("73c28d07-3db9-4b41-a917-5b4d1aab383a"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("513326f1-fc7d-4f91-a5a4-354223165531") },
                    { new Guid("75e90581-2a06-4f6b-97e1-ea167222443a"), "\"Published\n       \" HH:mm tt \"EST\", ddd MMMM d, yyyy", new Guid("949d55f0-ab6a-4f82-9941-0799bf3e33bb") },
                    { new Guid("771b0ef8-18f8-4772-b378-a205623081d5"), "yyyy-MM-ddTHH:mm:ss", new Guid("77dc783c-304f-48e9-9fab-da12f7b78789") },
                    { new Guid("79fdb8ac-31eb-4842-8cee-97ea1cbbb8f9"), "d MMMM yyyy, HH:mm", new Guid("515812c9-0bc6-45e8-a14f-0e684c8657b2") },
                    { new Guid("7cd60a15-52ad-42f4-89a9-899eb6205ace"), "dd MMMM, HH:mm", new Guid("c677ed50-5a4d-4b9f-bb13-cb4ec259ff20") },
                    { new Guid("86418e50-dac7-4639-9b05-1bb875bc50c2"), "d MMMM  HH:mm", new Guid("ae403b01-a18c-421c-ba2e-deffb24286d2") },
                    { new Guid("8f259138-3ed7-4888-a742-d1846159024c"), "HH:mm dd.MM.yyyy", new Guid("fe77f1ed-0b50-4d88-88ab-8f660e3cb204") },
                    { new Guid("93b3b71d-fc31-4a3e-bd33-6b52c018d453"), "dd MMMM yyyy, HH:mm", new Guid("fe579abd-c5b4-49ef-825a-97557030476c") },
                    { new Guid("94566a3e-465e-4b39-b8cb-fc4672ad3807"), "dd.MM.yyyy HH:mm", new Guid("39d98bae-9b4d-4218-a954-37e4d04aa931") },
                    { new Guid("a1f33747-8a2b-406e-9ac3-7215dd2ab6c5"), "HH:mm, d MMMM yyyy", new Guid("01defbcf-eae7-45f4-8e82-049aeaa49b97") },
                    { new Guid("a2b50ffb-506a-4b5e-b740-ab7eedcad3d2"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("9f43bb60-a5a6-4886-a963-336c6b3e31be") },
                    { new Guid("a6207494-99ce-4d0a-84ab-277e8cc95e99"), "yyyy-MM-ddTHH:mm:ss", new Guid("6bd21ba9-8ea7-4677-9fc9-36190288182c") },
                    { new Guid("a9f02065-62b8-4f50-9e1a-8fef32f0f2a5"), "d MMMM yyyy \"в\" HH:mm", new Guid("1bfe0ff9-532a-4481-a3c6-4d3dceeb7fe9") },
                    { new Guid("ae7c0697-49e9-4ccb-8a96-fb5e445c9a9b"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("4d7ba2d1-e735-4700-b35c-91011b59bfdd") },
                    { new Guid("b856bc88-ad80-4126-8b30-a703b5069bb4"), "dd.MM.yyyy HH:mm", new Guid("290bd535-94b5-4040-b9d6-7f6b2ee139be") },
                    { new Guid("bba264d6-940f-4063-9ee4-434963a78c34"), "yyyy-MM-ddTHH:mm:ss.fff\"Z+0300\"", new Guid("d6063bcf-8442-495f-8298-8fa99f10c0d1") },
                    { new Guid("bed190e4-73bd-4dec-8572-838b1f6a9c05"), "d MMMM yyyy, HH:mm", new Guid("2b0052bc-82cc-451d-b052-aa65c45bf7b0") },
                    { new Guid("c07d7539-f510-44a6-afc7-fa86d6809715"), "d-M-yyyy HH:mm", new Guid("05b0240e-0f0e-49c2-bf13-e744829c506e") },
                    { new Guid("c853a801-4034-49c3-aac8-2f7b5dfbb495"), "d MMMM yyyy, HH:mm,", new Guid("515812c9-0bc6-45e8-a14f-0e684c8657b2") },
                    { new Guid("cc834852-e157-4225-8f8b-aad551a09033"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("14d40d60-d0ec-409b-8f8e-54f30dbfee54") },
                    { new Guid("cd49debd-33bc-4237-9cb7-95363ff68761"), "yyyy-MM-dd HH:mm:ss", new Guid("b938f3c0-aeb9-4d81-99c7-5b91d0172251") },
                    { new Guid("d5997b49-c167-4043-884f-2ec0e1b89abc"), "dd.MM.yyyy HH:mm", new Guid("20189b50-1bab-4c55-87d5-36ea2c5ef3d4") },
                    { new Guid("d9d4c41e-f1f1-44ee-955c-3629851ec6ae"), "d MMMM yyyy HH:mm", new Guid("ae403b01-a18c-421c-ba2e-deffb24286d2") },
                    { new Guid("deb39f9d-a0dc-43d0-bbe9-928613f9a7fa"), "yyyy-MM-d HH:mm", new Guid("a35fe3f0-f8c2-4e7d-a401-5a56b6855cfc") },
                    { new Guid("e77f32fe-2509-4c4c-8e92-c60713681025"), "d MMMM, HH:mm,", new Guid("515812c9-0bc6-45e8-a14f-0e684c8657b2") },
                    { new Guid("f030219a-11be-44db-a963-75210c21da06"), "d MMMM yyyy, HH:mm \"МСК\"", new Guid("aa38108d-6f02-4418-a2b1-4a7fdfb0477f") },
                    { new Guid("f1b1f611-db5c-41ad-ad86-c696085eca64"), "d MMMM yyyy, HH:mm", new Guid("d2c7deea-325f-4f8a-ad52-c9352829382e") },
                    { new Guid("f3307f81-e393-4184-ace8-295f7a2fec7d"), "dd MMMM yyyy, HH:mm", new Guid("c677ed50-5a4d-4b9f-bb13-cb4ec259ff20") },
                    { new Guid("f4adbf9b-2cca-453a-a3f0-0446995f6314"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("1ef5734c-8ca6-4409-833c-83a9e44b76d0") }
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
