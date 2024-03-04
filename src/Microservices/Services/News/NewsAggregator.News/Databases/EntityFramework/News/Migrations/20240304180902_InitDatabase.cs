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
                    { new Guid("058fb34e-8a52-40c8-aeb6-2a108e422a9c"), true, "https://www.hltv.org/", "HLTV.org" },
                    { new Guid("06fe9e1a-73fb-4ddc-89cd-ee22c58ea200"), true, "https://life.ru/", "Life" },
                    { new Guid("09a011a2-0603-4b79-b448-cab8e14728a6"), true, "https://rg.ru/", "Российская газета" },
                    { new Guid("0c0be34e-9b65-4787-9f6d-fbffc742b65e"), true, "https://aif.ru/", "Аргументы и факты" },
                    { new Guid("1af9e323-2262-4da8-aa41-1a2355bdc39b"), true, "https://3dnews.ru/", "3Dnews.ru" },
                    { new Guid("1e71bc14-9e3e-45f4-ad53-7e9877006752"), true, "https://www.belta.by/", "БелТА" },
                    { new Guid("29f2e267-70b4-4c52-a7cb-cf714645abfe"), true, "https://lenta.ru/", "Лента.Ру" },
                    { new Guid("376484e3-3274-46ec-b6fa-b0d0a8e84f66"), true, "https://www.starhit.ru/", "Сетевое издание «Онлайн журнал StarHit (СтарХит)" },
                    { new Guid("39e2555b-4a16-4bb5-906f-99e76da71843"), true, "https://74.ru/", "74.ru" },
                    { new Guid("46ebd707-ea41-4e15-93f7-3fb42294d131"), true, "https://www.m24.ru/", "Москва 24" },
                    { new Guid("4865583f-68e2-40d0-b6a4-586ae44b3981"), true, "https://ixbt.games/", "iXBT.games" },
                    { new Guid("4b5301f0-b935-4d5a-82cc-0e03a0fecbcd"), false, "https://www.kinonews.ru/", "KinoNews.ru" },
                    { new Guid("4db87416-349e-4e41-91ee-a157d203504f"), true, "https://www.gazeta.ru/", "Газета.Ru" },
                    { new Guid("5a5501d3-5ddc-4647-a460-388dd67d4955"), true, "https://edition.cnn.com/", "CNN" },
                    { new Guid("5de8e431-2e67-411a-b3fb-e00d749b2e1f"), true, "https://www.avtovzglyad.ru/", "АвтоВзгляд" },
                    { new Guid("5e0aa8a4-6226-40f6-81a6-01a1c37ff349"), true, "https://www.kp.ru/", "Комсомольская правда" },
                    { new Guid("6461a868-5a41-4cb5-bc2a-f364df709c78"), true, "https://www.nytimes.com/", "The New York Times" },
                    { new Guid("69532d48-dd7e-47c4-953a-fcaee8a0d383"), true, "https://www.zr.ru/", "Журнал \"За рулем\"" },
                    { new Guid("6af837d5-8da9-472e-aba3-379b349c61d8"), true, "https://www.rbc.ru/", "РБК" },
                    { new Guid("6d9f241f-77fa-4304-b537-e6be871c09bb"), true, "https://russian.rt.com/", "RT на русском" },
                    { new Guid("7a418133-b763-44d4-87c2-39aa7f5d473d"), true, "https://stopgame.ru/", "StopGame" },
                    { new Guid("7d880f25-1e34-4d21-a977-c8310cce0169"), true, "https://www.sports.ru/", "Storts.ru" },
                    { new Guid("81886d95-cacb-41f0-8fd0-6254b9109c99"), true, "https://overclockers.ru/", "Overclockers" },
                    { new Guid("8ba3d9b3-dbc6-4f0d-8299-5a5cb9825ca4"), true, "https://www.pravda.ru/", "Правда.ру" },
                    { new Guid("8c820201-8f42-47e5-8bdf-7e5abeda0023"), true, "https://7days.ru/", "7дней.ru" },
                    { new Guid("99e4ed22-f5b1-418b-b160-449335418412"), true, "https://www.championat.com/", "Чемпионат.com" },
                    { new Guid("9f4139c1-3f0e-4aa3-8dd3-2dd53f10350e"), true, "https://www.kommersant.ru/", "Коммерсантъ" },
                    { new Guid("9ff1e0de-3e12-4ef0-8d89-aa0b64b3e81d"), true, "https://www.interfax.ru/", "Интерфакс" },
                    { new Guid("a0139787-54aa-4217-91f2-cdfae254386c"), true, "https://vz.ru/", "ВЗГЛЯД.РУ" },
                    { new Guid("a6502d65-7ce4-4a55-882b-5f11ac09a744"), true, "https://ria.ru/", "РИА Новости" },
                    { new Guid("a9720706-fc1b-4da4-bcb8-18b95bc4943d"), true, "https://www.1obl.ru/", "Первый областной" },
                    { new Guid("b1a5ac8a-9120-46c1-abc1-4b91733e8217"), true, "https://www.cybersport.ru/", "Cybersport.ru" },
                    { new Guid("c17ff619-40c3-4ce7-9102-250b9924353c"), true, "https://tass.ru/", "ТАСС" },
                    { new Guid("c4a07c17-132f-4cd6-80fa-57c354c75c13"), true, "https://tsargrad.tv/", "Царьград" },
                    { new Guid("cb674f53-894b-4cad-8e09-8a88c097ddfc"), true, "https://www.ixbt.com/", "iXBT.com" },
                    { new Guid("dcc3269f-645c-49ec-9b24-3593dad26990"), true, "https://svpressa.ru/", "СвободнаяПресса" },
                    { new Guid("e36864b6-c3c0-4b20-b629-091668c3c5e4"), true, "https://iz.ru/", "Известия" },
                    { new Guid("f7273c3f-a355-4fbe-8412-e337e4e17d86"), true, "https://ura.news/", "Ura.ru" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_settings",
                columns: new[] { "id", "html_description_x_path", "source_id", "text_description_x_path", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("01914729-c0f7-4b44-a450-e2d8b0eab357"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]", new Guid("9f4139c1-3f0e-4aa3-8dd3-2dd53f10350e"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]/text()", "//h1/text()" },
                    { new Guid("0233cf68-eb05-4c15-ba1a-f14b76434916"), "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]", new Guid("46ebd707-ea41-4e15-93f7-3fb42294d131"), "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]/text()", "//h1/text()" },
                    { new Guid("02ad6cb8-7406-4672-85f1-93f9a481f892"), "//div[@itemprop='articleBody']/*", new Guid("4db87416-349e-4e41-91ee-a157d203504f"), "//div[@itemprop='articleBody']/*/text()", "//h1/text()" },
                    { new Guid("0a56106a-1a96-4553-a4c7-fa3b85d1c636"), "//div[@itemprop='articleBody']/*[not(name() = 'figure')]", new Guid("39e2555b-4a16-4bb5-906f-99e76da71843"), "//div[@itemprop='articleBody']/*[not(name() = 'figure')]/text()", "//h1[@itemprop='headline']/span/text()" },
                    { new Guid("107b0b2d-892c-4c37-8bdf-ab63b071ffee"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]", new Guid("c4a07c17-132f-4cd6-80fa-57c354c75c13"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]/text()", "//h1[@class='article__title']/text()" },
                    { new Guid("11cb58ce-1388-4e38-ac45-386b63039b68"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/*[position()>1 and not(div)]", new Guid("1af9e323-2262-4da8-aa41-1a2355bdc39b"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()>1]/text()", "//h1/text()" },
                    { new Guid("1f52c5b0-093c-4327-84d4-75aa8bccac4e"), "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]", new Guid("8ba3d9b3-dbc6-4f0d-8299-5a5cb9825ca4"), "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]/text()", "//h1/text()" },
                    { new Guid("3b5479c0-92ce-4cd8-8619-03f5f3c5e6a6"), "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]", new Guid("dcc3269f-645c-49ec-9b24-3593dad26990"), "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]/text()", "//h1[@class='b-text__title']/text()" },
                    { new Guid("469c5c35-5a60-4d55-bb27-eb33aee632ce"), "//div[contains(@class, 'material-content')]/*", new Guid("81886d95-cacb-41f0-8fd0-6254b9109c99"), "//div[contains(@class, 'material-content')]/p/text()", "//a[@class='header']/text()" },
                    { new Guid("4af9e5bb-677e-4186-832d-2778bebe0f6c"), "//div[contains(@class, 'article__body')]", new Guid("a6502d65-7ce4-4a55-882b-5f11ac09a744"), "//div[contains(@class, 'article__body')]/text()", "//div[@class='article__title']/text()" },
                    { new Guid("4f17562f-3759-4e6f-b2ba-e1926cdc7190"), "//div[@itemprop='articleBody']/*", new Guid("cb674f53-894b-4cad-8e09-8a88c097ddfc"), "//div[@itemprop='articleBody']/*/text()", "//h1/text()" },
                    { new Guid("5236f34d-7077-4fe2-a4fe-573ac5126f7d"), "//div[@class='textart']/div[not(@class)]/*", new Guid("4b5301f0-b935-4d5a-82cc-0e03a0fecbcd"), "//div[@class='textart']/div[not(@class)]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("616cb1ff-8d47-49fe-b0e6-f67148b21d31"), "//div[@itemprop='articleBody']/*", new Guid("a9720706-fc1b-4da4-bcb8-18b95bc4943d"), "//div[@itemprop='articleBody']/*/text()", "//h1[@itemprop='headline']/text()" },
                    { new Guid("62ab442c-14e5-43c9-8f1b-d7f5050a461b"), "//article/*", new Guid("c17ff619-40c3-4ce7-9102-250b9924353c"), "//article/*/text()", "//h1/text()" },
                    { new Guid("648ebc10-5c3f-46ac-9a93-ab2d50785c06"), "//div[contains(@class, 'PageContentCommonStyling_text')]/*[not(name() = 'rg-video')]", new Guid("09a011a2-0603-4b79-b448-cab8e14728a6"), "//div[contains(@class, 'PageContentCommonStyling_text')]/*[not(name() = 'rg-video')]/text()", "//h1/text()" },
                    { new Guid("6536a997-6bfc-4bef-bcde-1619c4b6d47a"), "//section[@name='articleBody']/*", new Guid("6461a868-5a41-4cb5-bc2a-f364df709c78"), "//section[@name='articleBody']/*/text()", "//h1/text()" },
                    { new Guid("6d040458-5310-4ed1-96cf-00f28e248600"), "//div[contains(@class, 'container-fluid shifted') and not(p[@class='announce lead']) and not(h1) and not(hr)]", new Guid("4865583f-68e2-40d0-b6a4-586ae44b3981"), "//div[contains(@class, 'container-fluid shifted') and not(p[@class='announce lead']) and not(h1) and not(hr)]/text()", "//h1/text()" },
                    { new Guid("789735b4-4e60-43eb-a422-55ab2c60e419"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview'))]", new Guid("6af837d5-8da9-472e-aba3-379b349c61d8"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview'))]/text()", "//h1/text()" },
                    { new Guid("7bc1101f-3abd-46f1-aecc-9e930836536b"), "//article/div[@class='news_text']", new Guid("a0139787-54aa-4217-91f2-cdfae254386c"), "//article/div[@class='news_text']/text()", "//h1/text()" },
                    { new Guid("823a518a-94e0-4a10-87ef-62c01233cd01"), "//div[@class='topic-body__content']", new Guid("29f2e267-70b4-4c52-a7cb-cf714645abfe"), "//div[@class='topic-body__content']/text()", "//h1[@class='topic-body__titles']/span[@class='topic-body__title']/text()" },
                    { new Guid("83890049-1c2b-4fb9-a240-8d1a58072a95"), "//div[@data-gtm-el='content-body']/*[not(name()='div' and @data-wide='true')]", new Guid("5e0aa8a4-6226-40f6-81a6-01a1c37ff349"), "//div[@data-gtm-el='content-body']/*[not(name()='div' and @data-wide='true')]/text()", "//h1/text()" },
                    { new Guid("9507883c-7527-4657-8d22-9f4c93ab4743"), "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]", new Guid("9ff1e0de-3e12-4ef0-8d89-aa0b64b3e81d"), "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]/text()", "//h1/text()" },
                    { new Guid("9611b7d1-3fef-4cc8-bba6-615104fbd904"), "//div[contains(@class, 'news-item__content')]", new Guid("7d880f25-1e34-4d21-a977-c8310cce0169"), "//div[contains(@class, 'news-item__content')]/text()", "//h1/text()" },
                    { new Guid("9a8fc5ed-99dc-4e9f-970a-9fca4c4e689d"), "//div[@itemprop='articleBody']/*", new Guid("e36864b6-c3c0-4b20-b629-091668c3c5e4"), "//div[@itemprop='articleBody']//text()", "//h1/span/text()" },
                    { new Guid("a261b1e7-8770-4ab6-9972-711d92ce6ac3"), "//div[contains(@class, 'styled__StoryBody')]/*[not(name()='p' and contains(@class, 'styled__StoryParagraph') and position()=1) and not(name()='div' and contains(@class, 'styled__StoryImgContainer') and position()=2)]", new Guid("69532d48-dd7e-47c4-953a-fcaee8a0d383"), "//div[contains(@class, 'styled__StoryBody')]/*[not(name()='p' and contains(@class, 'styled__StoryParagraph') and position()=1) and not(name()='div' and contains(@class, 'styled__StoryImgContainer') and position()=2)]/text()", "//meta[@name='og:title']/@content" },
                    { new Guid("a2acfcb4-2852-49c4-8ea2-420f3cc9ea83"), "//div[@itemprop='articleBody']/*[not(name()='div')]", new Guid("f7273c3f-a355-4fbe-8412-e337e4e17d86"), "//div[@itemprop='articleBody']/*[not(name()='div')]/text()", "//h1/text()" },
                    { new Guid("a722c0ae-78b4-4efe-9fb4-c09a2c73585c"), "//div[@itemprop='articleBody']/*", new Guid("5a5501d3-5ddc-4647-a460-388dd67d4955"), "//div[@itemprop='articleBody']/*/text()", "//h1/text()" },
                    { new Guid("aac9a853-d700-4df0-83e0-247b1976e34a"), "//section[@itemprop='articleBody']/div[@class='ds-article-content-block-and-creative-container']/*[not(name()='div' and contains(@class, 'ds-article-content__block_image') and position()=1)]", new Guid("376484e3-3274-46ec-b6fa-b0d0a8e84f66"), "//section[@itemprop='articleBody']//div[contains(@class, 'ds-article-content__block_text')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("aecd6ab1-ca0b-4f18-aea8-192550ba9631"), "//article//div[@class='newstext-con']/*[position()>2]", new Guid("058fb34e-8a52-40c8-aeb6-2a108e422a9c"), "//article//div[@class='newstext-con']/*[position()>2]/text()", "//h1[@class='headline']/text()" },
                    { new Guid("b04c0205-8eb2-47d9-8f2c-71156a1aade8"), "//div[@class='js-mediator-article']", new Guid("1e71bc14-9e3e-45f4-ad53-7e9877006752"), "//div[@class='js-mediator-article']/text()", "//h1/text()" },
                    { new Guid("be973044-7cc2-4ffa-b51d-4363aaec14cc"), "//div[@class='article_text']", new Guid("0c0be34e-9b65-4787-9f6d-fbffc742b65e"), "//div[@class='article_text']/text()", "//h1/text()" },
                    { new Guid("cde1c65d-c8ae-4ab9-bf14-55b86846acc4"), "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]", new Guid("06fe9e1a-73fb-4ddc-89cd-ee22c58ea200"), "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]/text()", "//h1/text()" },
                    { new Guid("d682fb0f-2bf0-416a-9a8f-a0b9897157c2"), "//section[@itemprop='articleBody']/*", new Guid("5de8e431-2e67-411a-b3fb-e00d749b2e1f"), "//section[@itemprop='articleBody']/*[not(name()='script')]/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("df1e0e9b-364c-4a45-b02a-f4130ecb8183"), "//div[@class='material-7days__paragraf-content']/*[not(name()='div' and @itemprop='image' and position()=1)]", new Guid("8c820201-8f42-47e5-8bdf-7e5abeda0023"), "//div[@class='material-7days__paragraf-content']//p/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("df70cfb3-7d39-4e28-b944-e711c3b8966e"), "//section[contains(@class, '_page-section')]/div[contains(@class, '_content_')]/*", new Guid("7a418133-b763-44d4-87c2-39aa7f5d473d"), "//section[contains(@class, '_page-section')]/div[contains(@class, '_content_')]/*[contains(@class, '_text_')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("e15645fe-9624-4293-a437-bed1f6ced43b"), "//div[contains(@class, 'js-mediator-article')]/*[position()>1]", new Guid("b1a5ac8a-9120-46c1-abc1-4b91733e8217"), "//div[contains(@class, 'js-mediator-article')]/*[position()>1]/text()", "//h1/text()" },
                    { new Guid("f2fa9a76-4748-4c50-8427-4326b6cc1b49"), "//article/div[@class='article-content']/*[not(@class)]", new Guid("99e4ed22-f5b1-418b-b160-449335418412"), "//article/div[@class='article-content']/*[not(@class)]/text()", "//article/header/div[@class='article-head__title']/text()" },
                    { new Guid("f49de1e2-73e1-4562-ab52-719513961ec0"), "//div[contains(@class, 'article__text ')]", new Guid("6d9f241f-77fa-4304-b537-e6be871c09bb"), "//div[contains(@class, 'article__text ')]/text()", "//h1/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_search_settings",
                columns: new[] { "id", "news_site_url", "news_url_x_path", "source_id" },
                values: new object[,]
                {
                    { new Guid("06ef6bf0-93f3-4b2e-91a4-167e2713ca88"), "https://74.ru/", "//a[starts-with(@href, '/text/') and not(contains(@href, '?')) and not(contains(@href, 'comments/')) and not(@href='/text/')]/@href", new Guid("39e2555b-4a16-4bb5-906f-99e76da71843") },
                    { new Guid("177ef78a-e146-439d-aca3-7e15f7a0e396"), "https://www.zr.ru/news/", "//a[contains(@href, '/news/') and not(starts-with(@href, '/news/')) and not(starts-with(@href, 'https://'))]/@href", new Guid("69532d48-dd7e-47c4-953a-fcaee8a0d383") },
                    { new Guid("1812ee6f-894d-44c8-b791-04c5091c2a60"), "https://www.starhit.ru/novosti/", "//a[@class='announce-inline-tile__label-container']/@href", new Guid("376484e3-3274-46ec-b6fa-b0d0a8e84f66") },
                    { new Guid("1a9102bc-3831-4192-9c8e-d779078175f3"), "https://stopgame.ru/news", "//div[contains(@class, 'list-view')]//div[contains(@class, '_card')]/a/@href", new Guid("7a418133-b763-44d4-87c2-39aa7f5d473d") },
                    { new Guid("2972b603-0c6b-489a-80ed-3c4f1123c398"), "https://tass.ru/", "//a[contains(@class, 'tass_pkg_link-v5WdK') and contains(substring(@href, 2), '/') and not(contains(@href, '/spec/')) and not(contains(@href, 'spec.tass.ru'))]/@href", new Guid("c17ff619-40c3-4ce7-9102-250b9924353c") },
                    { new Guid("2a81bbb6-8615-4b1e-93ff-f940daed5cb8"), "https://iz.ru/news/", "//a[contains(@href, '?main_click')]/@href", new Guid("e36864b6-c3c0-4b20-b629-091668c3c5e4") },
                    { new Guid("2c05b311-d429-4728-a193-4f32bfbd151a"), "https://vz.ru/", "//a[contains(@href, '.html') and not(contains(@href, '#comments')) and not(contains(@href, '?')) and not(contains(@href, '/about/'))]/@href", new Guid("a0139787-54aa-4217-91f2-cdfae254386c") },
                    { new Guid("2f09d8d2-7318-4698-91da-96c81855d2b3"), "https://lenta.ru/", "//a[starts-with(@href, '/news/')]/@href", new Guid("29f2e267-70b4-4c52-a7cb-cf714645abfe") },
                    { new Guid("38419e54-8ead-498e-be7d-93713415804d"), "https://svpressa.ru/all/news/", "//a[contains(@href, '/news/') and not(contains(@href, '?')) and not(starts-with(@href, '/all/news/'))]/@href", new Guid("dcc3269f-645c-49ec-9b24-3593dad26990") },
                    { new Guid("4202ed5b-460a-469d-9aa0-58434a826832"), "https://tsargrad.tv/", "//a[contains(@class, 'news-item__link')]/@href", new Guid("c4a07c17-132f-4cd6-80fa-57c354c75c13") },
                    { new Guid("426f5a6d-2732-41f8-a642-e01ffc9833a1"), "https://www.pravda.ru/", "//a[contains(@href, '/news/') and not(@href='https://www.pravda.ru/news/')]/@href", new Guid("8ba3d9b3-dbc6-4f0d-8299-5a5cb9825ca4") },
                    { new Guid("44ae3db9-c94f-4cc3-b7e3-c1c631ecef61"), "https://www.sports.ru/news/", "//a[contains(@href, '.html') and not(contains(@href, '.html#comments')) and not (contains(@href, '/blogs/'))]/@href", new Guid("7d880f25-1e34-4d21-a977-c8310cce0169") },
                    { new Guid("4a99f23d-dd54-4fe6-9fa3-c9da987ba702"), "https://3dnews.ru/news/", "//div[@class='news-feed-all']//a[@class='entry-header']/h1/../@href", new Guid("1af9e323-2262-4da8-aa41-1a2355bdc39b") },
                    { new Guid("4a9c2864-3f31-41cd-ae76-c28b929a46d8"), "https://www.hltv.org/", "//a[contains(@href, '/news/')]/@href", new Guid("058fb34e-8a52-40c8-aeb6-2a108e422a9c") },
                    { new Guid("4d3662c0-431b-4281-8048-ea05825529ea"), "https://7days.ru/news/", "//a[contains(@class, '7days__item_href') and starts-with(@href, '/news/')]/@href", new Guid("8c820201-8f42-47e5-8bdf-7e5abeda0023") },
                    { new Guid("50cb8d6d-a5eb-4bd8-9038-c8a2c4531450"), "https://overclockers.ru/news", "//div[contains(@class, 'event')]//a[not(contains(@href, '#comments'))]/@href", new Guid("81886d95-cacb-41f0-8fd0-6254b9109c99") },
                    { new Guid("5e274f58-0e2a-47f8-8ba0-cc3e0ef7de30"), "https://www.rbc.ru/", "//a[contains(@href, 'https://www.rbc.ru/') and contains(@href, '?from=')]/@href", new Guid("6af837d5-8da9-472e-aba3-379b349c61d8") },
                    { new Guid("641203c5-8f10-42bf-b11c-fabc4f13035c"), "https://ixbt.games/news/", "//a[@class='card-link']/@href", new Guid("4865583f-68e2-40d0-b6a4-586ae44b3981") },
                    { new Guid("6ade2b74-cb4c-441a-ad03-ab0fb64bfd26"), "https://ria.ru/", "//a[contains(@class, 'cell-list__item-link')]/@href", new Guid("a6502d65-7ce4-4a55-882b-5f11ac09a744") },
                    { new Guid("744a0049-063e-4d69-9514-c85d641d4d07"), "https://www.1obl.ru/news/", "//a[starts-with(@href, '/news/') and not(contains(@href, '?'))]/@href", new Guid("a9720706-fc1b-4da4-bcb8-18b95bc4943d") },
                    { new Guid("810fffcf-168f-4e7f-b9cc-12fdab1e18a6"), "https://edition.cnn.com/", "//a[contains(@href, '.html')]/@href", new Guid("5a5501d3-5ddc-4647-a460-388dd67d4955") },
                    { new Guid("8156c083-c973-41b9-8f64-fc0a4ec76672"), "https://life.ru/s/novosti", "//a[contains(@href, '/p/')]/@href", new Guid("06fe9e1a-73fb-4ddc-89cd-ee22c58ea200") },
                    { new Guid("85036e98-ae82-4e9e-ad28-c091e17d7f45"), "https://www.kommersant.ru/", "//a[contains(@href, '/doc/') and contains(@href, '?from=')]/@href", new Guid("9f4139c1-3f0e-4aa3-8dd3-2dd53f10350e") },
                    { new Guid("a2f21576-f02d-4067-9bf3-93d854de9c96"), "https://www.avtovzglyad.ru/news/", "//a[@class='news-card__link']/@href", new Guid("5de8e431-2e67-411a-b3fb-e00d749b2e1f") },
                    { new Guid("a8a14958-046b-4ad4-a624-f33d70537a24"), "https://www.kinonews.ru/news/", "//a[contains(@href, '/news_') and not(contains(@href, 'comments')) and not(contains(@href, 'news_p'))]/@href", new Guid("4b5301f0-b935-4d5a-82cc-0e03a0fecbcd") },
                    { new Guid("a9ea0be0-dbf6-448b-966d-381059632446"), "https://www.ixbt.com/news/", "//a[starts-with(@href, '/news/') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("cb674f53-894b-4cad-8e09-8a88c097ddfc") },
                    { new Guid("b67aa307-58d7-4722-88d8-4b41347db7e1"), "https://www.nytimes.com/", "//a[contains(@href, '.html')]/@href", new Guid("6461a868-5a41-4cb5-bc2a-f364df709c78") },
                    { new Guid("ba4666be-784a-45df-8fa8-de987dead6d3"), "https://aif.ru/", "//span[contains(@class, 'item_text__title')]/../@href", new Guid("0c0be34e-9b65-4787-9f6d-fbffc742b65e") },
                    { new Guid("be75324c-6307-46b9-beff-14eae870893b"), "https://rg.ru/", "//a[contains(@href, '.html')]/@href", new Guid("09a011a2-0603-4b79-b448-cab8e14728a6") },
                    { new Guid("bfae497b-727a-4609-99fb-052516e3c408"), "https://www.m24.ru/", "//a[contains(@href, '/news/')]/@href", new Guid("46ebd707-ea41-4e15-93f7-3fb42294d131") },
                    { new Guid("ce1e349a-1e75-478b-9a79-33dd205de9f0"), "https://www.kp.ru/", "//a[contains(@href, '/news/')]/@href", new Guid("5e0aa8a4-6226-40f6-81a6-01a1c37ff349") },
                    { new Guid("cf76d2fa-0eff-4929-86e5-46a0f8d54339"), "https://ura.news/", "//a[contains(@href, '/news/')]/@href", new Guid("f7273c3f-a355-4fbe-8412-e337e4e17d86") },
                    { new Guid("d1478ff8-ec3c-4492-a4f4-4d6921a6bf47"), "https://www.championat.com/news/1.html?utm_source=button&utm_medium=news", "//a[contains(@href, 'news-') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("99e4ed22-f5b1-418b-b160-449335418412") },
                    { new Guid("d608a4cb-63a9-4a4e-881f-927f4d77a52e"), "https://russian.rt.com/", "//a[contains(@class, 'link') and contains(@href, 'news/')]/@href", new Guid("6d9f241f-77fa-4304-b537-e6be871c09bb") },
                    { new Guid("da9beb8d-3bf6-4c18-b23a-0be69f1653f2"), "https://www.belta.by/", "//a[contains(@href, 'www.belta.by') and contains(@href, '/view/')]/@href", new Guid("1e71bc14-9e3e-45f4-ad53-7e9877006752") },
                    { new Guid("e22d92ac-bdbf-4e44-922b-fde68c6cf06b"), "https://www.interfax.ru/", "//div[@class='timeline']//a[@tabindex=5]/@href", new Guid("9ff1e0de-3e12-4ef0-8d89-aa0b64b3e81d") },
                    { new Guid("e2dbae98-fa47-4273-baf7-7fb926707bb9"), "https://www.cybersport.ru/", "//a[contains(@href, '/tags/')]/@href", new Guid("b1a5ac8a-9120-46c1-abc1-4b91733e8217") },
                    { new Guid("e75b4006-c4a9-4957-83e7-d00f3258e916"), "https://www.gazeta.ru/news/", "//a[contains(@href, '/news/') and contains(@href, '.shtml') and not(contains(@href, '?'))]/@href", new Guid("4db87416-349e-4e41-91ee-a157d203504f") }
                });

            migrationBuilder.InsertData(
                table: "news_source_logos",
                columns: new[] { "id", "original", "small", "source_id" },
                values: new object[,]
                {
                    { new Guid("002e51b3-8132-4652-9f23-f865ff411604"), "https://www.m24.ru/img/fav/apple-touch-icon.png", "https://www.m24.ru/img/fav/favicon-32x32.png", new Guid("46ebd707-ea41-4e15-93f7-3fb42294d131") },
                    { new Guid("10f4dc97-6c76-4eaa-8af5-dd6418cb6701"), "https://www.zr.ru/favicons/safari-pinned-tab.svg", "https://www.zr.ru/favicons/favicon.ico", new Guid("69532d48-dd7e-47c4-953a-fcaee8a0d383") },
                    { new Guid("1120abdc-6226-4d17-8d3f-7c9de28f998b"), "https://cdnstatic.rg.ru/images/touch-icon-ipad-retina_512x512.png", "https://rg.ru/favicon.ico", new Guid("09a011a2-0603-4b79-b448-cab8e14728a6") },
                    { new Guid("1717b662-4ce6-4d87-9e40-819f50f1b2b9"), "https://cdn.iz.ru/profiles/portal/themes/purple/images/favicons/android-icon-192x192.png", "https://cdn.iz.ru/profiles/portal/themes/purple/images/favicons/favicon-32x32.png", new Guid("e36864b6-c3c0-4b20-b629-091668c3c5e4") },
                    { new Guid("1fe2d9cd-d8a2-4111-a841-94cb9374540b"), "https://www.belta.by/images/storage/banners/000016_a133e848cb2e7b1debb7102d19e4d139_work.svg", "https://www.belta.by/images/storage/banners/000016_a133e848cb2e7b1debb7102d19e4d139_work.svg", new Guid("1e71bc14-9e3e-45f4-ad53-7e9877006752") },
                    { new Guid("210ea267-15ba-4be8-958f-25bca80f0dc7"), "https://overclockers.ru/assets/apple-touch-icon-120x120.png", "https://overclockers.ru/assets/apple-touch-icon.png", new Guid("81886d95-cacb-41f0-8fd0-6254b9109c99") },
                    { new Guid("2136b233-d41d-44ac-b8ac-987c9ca50524"), "https://static.gazeta.ru/nm2021/img/icons/favicon.svg", "https://static.gazeta.ru/nm2021/img/icons/favicon.svg", new Guid("4db87416-349e-4e41-91ee-a157d203504f") },
                    { new Guid("2530ba8f-8dca-4863-bebd-9220242be3a6"), "https://3dnews.ru/assets/images/3dnews_logo_soc.png", "https://3dnews.ru/assets/3dnews_logo_color.png", new Guid("1af9e323-2262-4da8-aa41-1a2355bdc39b") },
                    { new Guid("27950b36-d5d5-4a38-8df6-b8e6e2d8d63d"), "https://edition.cnn.com/media/sites/cnn/apple-touch-icon.png", "https://edition.cnn.com/media/sites/cnn/favicon.ico", new Guid("5a5501d3-5ddc-4647-a460-388dd67d4955") },
                    { new Guid("372d6f21-536c-4d2a-9092-33abb8ceb161"), "https://www.kinonews.ru/favicon.ico", "https://www.kinonews.ru/favicon.ico", new Guid("4b5301f0-b935-4d5a-82cc-0e03a0fecbcd") },
                    { new Guid("444fc30e-d458-4dd5-959d-0b076d7779f2"), "https://russian.rt.com/static/blocks/touch-icon/apple-touch-icon-144x144-precomposed.png", "https://russian.rt.com/favicon.ico", new Guid("6d9f241f-77fa-4304-b537-e6be871c09bb") },
                    { new Guid("46d683c5-67bc-433e-951c-6087f96848e6"), "https://7days.ru/android-icon-192x192.png", "https://7days.ru/favicon-32x32.png", new Guid("8c820201-8f42-47e5-8bdf-7e5abeda0023") },
                    { new Guid("48ab3df5-d1a7-489a-8e0e-6085d19b8cc8"), "https://cdnn21.img.ria.ru/i/favicons/favicon.svg", "https://cdnn21.img.ria.ru/i/favicons/favicon.ico", new Guid("a6502d65-7ce4-4a55-882b-5f11ac09a744") },
                    { new Guid("5006b00f-6f45-47ce-bd71-7413f7dcebcf"), "https://ura.news/apple-touch-icon.png", "https://s.ura.news/favicon.ico?3", new Guid("f7273c3f-a355-4fbe-8412-e337e4e17d86") },
                    { new Guid("55b88580-5fc3-4083-b31b-12f49ccd97bc"), "https://stopgame.ru/favicon_512.png", "https://stopgame.ru/favicon.ico", new Guid("7a418133-b763-44d4-87c2-39aa7f5d473d") },
                    { new Guid("621d697b-77aa-41dd-9b0c-7ca2e31c1948"), "https://www.cybersport.ru/favicon-192x192.png", "https://www.cybersport.ru/favicon-32x32.png", new Guid("b1a5ac8a-9120-46c1-abc1-4b91733e8217") },
                    { new Guid("6afcd5fc-874d-43dc-a42e-baac116b5fef"), "https://www.sports.ru/apple-touch-icon-1024.png", "https://www.sports.ru/apple-touch-icon-76.png", new Guid("7d880f25-1e34-4d21-a977-c8310cce0169") },
                    { new Guid("70302e10-11b9-4752-9c35-eecdb0d3ae3d"), "https://cdn.hsmedia.ru/public/favicon/starhit/apple-touch-icon.png", "https://cdn.hsmedia.ru/public/favicon/starhit/favicon.png", new Guid("376484e3-3274-46ec-b6fa-b0d0a8e84f66") },
                    { new Guid("7bd770bd-7a8e-4370-a88a-ee921d35c27c"), "https://www.ixbt.com/favicon.ico", "https://www.ixbt.com/favicon.ico", new Guid("cb674f53-894b-4cad-8e09-8a88c097ddfc") },
                    { new Guid("8414cbc3-ea77-4c11-b0e8-35f5c8fea536"), "https://static.ngs.ru/jtnews/dist/static/favicons/apple/apple-favicon-74-180.png", "https://static.ngs.ru/jtnews/dist/static/favicons/favicon-rugion-32.ico", new Guid("39e2555b-4a16-4bb5-906f-99e76da71843") },
                    { new Guid("84752027-b817-4478-9b44-180baf97d45f"), "https://aif.ru/img/icon/apple-touch-icon.png?44f", "https://aif.ru/img/icon/favicon-32x32.png?44f", new Guid("0c0be34e-9b65-4787-9f6d-fbffc742b65e") },
                    { new Guid("87dfe6f7-f780-4968-93d9-f47e6e4d8b03"), "https://svpressa.ru/favicon-96x96.png?v=1471426270000", "https://svpressa.ru/favicon-32x32.png?v=1471426270000", new Guid("dcc3269f-645c-49ec-9b24-3593dad26990") },
                    { new Guid("8835ec75-a553-4ba4-9f45-e876b84dcb7c"), "https://im.kommersant.ru/ContentFlex/images/favicons2020/apple-touch-icon-180.png", "https://im.kommersant.ru/ContentFlex/images/favicons2020/favicon-32.png", new Guid("9f4139c1-3f0e-4aa3-8dd3-2dd53f10350e") },
                    { new Guid("95358dd7-eb5e-4da4-9cad-913b86f62732"), "https://s01.stc.yc.kpcdn.net/s0/2.1.321/adaptive/favicon-128.png", "https://s01.stc.yc.kpcdn.net/s0/2.1.321/adaptive/favicon-32.png", new Guid("5e0aa8a4-6226-40f6-81a6-01a1c37ff349") },
                    { new Guid("9c87d753-ba69-4550-8971-d0991262eb57"), "https://vz.ru/apple-touch-icon.png", "https://vz.ru/static/images/favicon.ico", new Guid("a0139787-54aa-4217-91f2-cdfae254386c") },
                    { new Guid("a1254a6f-43ff-4ec4-9cb8-75bac48c1afe"), "https://www.interfax.ru/touch-icon-ipad-retina.png", "https://www.interfax.ru/touch-icon-iphone.png", new Guid("9ff1e0de-3e12-4ef0-8d89-aa0b64b3e81d") },
                    { new Guid("a1fe269c-57c9-4466-882d-366e66c91856"), "https://tass.ru/favicon/180.svg", "https://tass.ru/favicon/57.png", new Guid("c17ff619-40c3-4ce7-9102-250b9924353c") },
                    { new Guid("a33747c2-a9b4-4ea2-afa6-d61711bab380"), "https://icdn.lenta.ru/images/icons/icon-256x256.png", "https://icdn.lenta.ru/favicon.ico", new Guid("29f2e267-70b4-4c52-a7cb-cf714645abfe") },
                    { new Guid("b505881b-04e3-4ab4-85ce-1065f92a98b0"), "https://st.championat.com/i/favicon/apple-touch-icon.png", "https://st.championat.com/i/favicon/favicon-32x32.png", new Guid("99e4ed22-f5b1-418b-b160-449335418412") },
                    { new Guid("b545201e-3974-4f5c-8d2b-ec35bf266ce2"), "https://s.rbk.ru/v10_rbcnews_static/common/common-10.10.120/images/android-chrome-512x512.png", "https://s.rbk.ru/v10_rbcnews_static/common/common-10.10.120/images/favicon.png", new Guid("6af837d5-8da9-472e-aba3-379b349c61d8") },
                    { new Guid("b5824c2b-82fc-4c1d-b458-c63cbb4227eb"), "https://www.1obl.ru/apple-touch-icon.png", "https://www.1obl.ru/favicon-32x32.png", new Guid("a9720706-fc1b-4da4-bcb8-18b95bc4943d") },
                    { new Guid("bf5fe060-3413-41fa-a141-07e29f97d517"), "https://www.pravda.ru/pix/apple-touch-icon.png", "https://www.pravda.ru/favicon.ico", new Guid("8ba3d9b3-dbc6-4f0d-8299-5a5cb9825ca4") },
                    { new Guid("c474e2bb-b4d7-42d7-bfb2-e9a6e1244641"), "https://life.ru/appletouch/apple-icon-180%D1%85180.png", "https://life.ru/favicon-32%D1%8532.png", new Guid("06fe9e1a-73fb-4ddc-89cd-ee22c58ea200") },
                    { new Guid("d05c598e-784b-4c9f-9caf-0b061bed58ae"), "https://www.avtovzglyad.ru/static/images/favicon/safari-pinned-tab.svg", "https://www.avtovzglyad.ru/static/images/favicon/favicon-32x32.png", new Guid("5de8e431-2e67-411a-b3fb-e00d749b2e1f") },
                    { new Guid("eea7b737-391d-4c7a-8802-0b2579f686b9"), "https://ixbt.games/images/favicon/gt/apple-touch-icon.png", "https://ixbt.games/images/favicon/gt/apple-touch-icon.png", new Guid("4865583f-68e2-40d0-b6a4-586ae44b3981") },
                    { new Guid("f0289553-cf78-4440-9703-fcd8fd907b23"), "https://tsargrad.tv/favicons/apple-touch-icon-180x180.png?s2", "https://tsargrad.tv/favicons/favicon-32x32.png?s2", new Guid("c4a07c17-132f-4cd6-80fa-57c354c75c13") },
                    { new Guid("f75239f1-6901-470c-a0fb-6b9fc8568b16"), "https://www.nytimes.com/vi-assets/static-assets/apple-touch-icon-28865b72953380a40aa43318108876cb.png", "https://www.nytimes.com/vi-assets/static-assets/ios-default-homescreen-57x57-dark-b395ebcad5b63aff9285aab58e31035e.png", new Guid("6461a868-5a41-4cb5-bc2a-f364df709c78") },
                    { new Guid("f7e1ac3f-ca51-4c6d-bb0b-575e761c6a44"), "https://www.hltv.org/img/static/favicon/apple-touch-icon.png", "https://www.hltv.org/img/static/favicon/favicon-32x32.png", new Guid("058fb34e-8a52-40c8-aeb6-2a108e422a9c") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_editor_settings",
                columns: new[] { "id", "is_required", "name_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("014fd786-a02d-44f6-bcc2-5fabd1215667"), false, "//div[@class='preview__author-block']//div[@class='author__about']/a[@itemprop='name']/@content", new Guid("d682fb0f-2bf0-416a-9a8f-a0b9897157c2") },
                    { new Guid("0fe6fa56-b0fd-469a-8278-4437f121e5a8"), true, "//div[contains(@class, 'styles_bodyWrapper')]//div[contains(@class, 'styles_authorsLinks')]/a/text()", new Guid("cde1c65d-c8ae-4ab9-bf14-55b86846acc4") },
                    { new Guid("1e8d1f8b-2abd-4663-8759-fe113346720c"), true, "//div[@itemprop='author']/span[@itemprop='name']/text()", new Guid("a2acfcb4-2852-49c4-8ea2-420f3cc9ea83") },
                    { new Guid("2dcdcf68-6cc9-45eb-b4f4-5d5a39b295a7"), false, "//div[@class='author']/span[@itemprop='author']/span[@itemprop='name']/a/text()", new Guid("02ad6cb8-7406-4672-85f1-93f9a481f892") },
                    { new Guid("32716a53-f8cd-4398-9f08-243b97ea873e"), true, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']//a[@itemprop='author']//span[@itemprop='name']/text()", new Guid("11cb58ce-1388-4e38-ac45-386b63039b68") },
                    { new Guid("3f0f7d83-fd27-45b4-9657-4bb20b5d130e"), false, "//meta[@property='article:author']/@content", new Guid("5236f34d-7077-4fe2-a4fe-573ac5126f7d") },
                    { new Guid("4dce6b89-87a4-4992-a768-44859cac114e"), false, "//div[@class='article__authors']//*[@class='article__authors__author']/span[@class='article__authors__author__name']/text()", new Guid("789735b4-4e60-43eb-a422-55ab2c60e419") },
                    { new Guid("54c4a3d9-d555-42a9-aca5-b8b0927b9f63"), true, "//article//span[@class='author']/a[@class='authorName']/span/text()", new Guid("aecd6ab1-ca0b-4f18-aea8-192550ba9631") },
                    { new Guid("589ede40-9d73-4d98-8235-9b71c3e81887"), true, "//article//header//div[@class='article-head__author-name']/a[@rel='author']/span/text()", new Guid("f2fa9a76-4748-4c50-8427-4326b6cc1b49") },
                    { new Guid("5d88e245-dda8-49f7-a98a-8deb4d317b9a"), true, "//span[@itemprop='name']/a/text()", new Guid("6536a997-6bfc-4bef-bcde-1619c4b6d47a") },
                    { new Guid("605f8264-b2db-4c3f-8706-882df79dd7ef"), true, "//span[@itemprop='author']/span[@itemprop='name']/@content", new Guid("4f17562f-3759-4e6f-b2ba-e1926cdc7190") },
                    { new Guid("686a9d6e-48a3-4c04-bab7-eb202044e53e"), false, "//span[@class='author']/a/text()", new Guid("469c5c35-5a60-4d55-bb27-eb33aee632ce") },
                    { new Guid("6e169e1a-94e3-44bf-9da4-badfc9158ea8"), true, "//a[@class='article__author']/text()", new Guid("107b0b2d-892c-4c37-8bdf-ab63b071ffee") },
                    { new Guid("6e7cfefe-d9e2-4bf2-99b8-9aa4e4260bf3"), false, "//div[@itemprop='author']//p[@itemprop='name']/text()", new Guid("0a56106a-1a96-4553-a4c7-fa3b85d1c636") },
                    { new Guid("75aab348-07b5-4972-8b17-b71cff5dbfb4"), false, "//p[@class='doc__text document_authors']/text()", new Guid("01914729-c0f7-4b44-a450-e2d8b0eab357") },
                    { new Guid("7d4f7937-e21b-48c4-8fa0-9a26f09ff62d"), true, "//div[contains(@class, 'PageArticleContent_authors')]//a[contains(@class, 'LinksOfAuthor_item')]/text()", new Guid("648ebc10-5c3f-46ac-9a93-ab2d50785c06") },
                    { new Guid("9277d8d8-95c4-4618-a67a-910ffe3360ee"), false, "//div[contains(@class, 'styled__StoryInfoAuthors')]/div[contains(@class, 'styled__InfoAuthor')]//span[contains(@class, 'styled__AuthorName')]/text()", new Guid("a261b1e7-8770-4ab6-9972-711d92ce6ac3") },
                    { new Guid("9c930324-3826-4999-ba3a-5508ee141ee0"), false, "//meta[@name='author']/@content", new Guid("aac9a853-d700-4df0-83e0-247b1976e34a") },
                    { new Guid("ae4eaad2-677e-4c57-9cc0-07b9a8b0459b"), false, "//meta[@property='article:author']/@content", new Guid("9a8fc5ed-99dc-4e9f-970a-9fca4c4e689d") },
                    { new Guid("b36c0c2f-d286-4203-8546-9d8fe590cd58"), true, "//footer[@class='news-item__footer']/div[@class='news-item__footer-after-news']/p[position()=1]//span/text()", new Guid("9611b7d1-3fef-4cc8-bba6-615104fbd904") },
                    { new Guid("b4f5b3d6-3efb-483e-b04b-fa1c840b6e0b"), true, "//div[contains(@class, 'full-article')]/div[@class='authors-block']//span[text()='Автор']/../a/text()", new Guid("1f52c5b0-093c-4327-84d4-75aa8bccac4e") },
                    { new Guid("b852be66-b498-433b-beec-5f1ee8cf85be"), true, "//*[@itemprop='author']/*[@itemprop='name']//text()", new Guid("616cb1ff-8d47-49fe-b0e6-f67148b21d31") },
                    { new Guid("d502946a-a490-47d6-9842-4d17604e1acc"), true, "//div[@class='article_top']//div[@class='authors']//div[@class='autor']//span/text()", new Guid("be973044-7cc2-4ffa-b51d-4363aaec14cc") },
                    { new Guid("e06121d5-318b-4c1b-9e9b-83096fe1d735"), false, "//section[contains(@class, '_page-section')]//div[contains(@class, '_bottom-info_')]//span[contains(@class, '_user-info__name_')]/text()", new Guid("df70cfb3-7d39-4e28-b944-e711c3b8966e") },
                    { new Guid("e0cbf566-74c3-4307-ba38-e83f1606e73d"), false, "//div[@class='topic-authors']/a[@class='topic-authors__author']/text()", new Guid("823a518a-94e0-4a10-87ef-62c01233cd01") },
                    { new Guid("eaf40465-bd09-405c-893a-d2a892c7c102"), true, "//div[@class='container-fluid publication-footer']//a[contains(@class, 'text-secondary')]/@title", new Guid("6d040458-5310-4ed1-96cf-00f28e248600") },
                    { new Guid("fac1de0e-2b93-4ec3-b5f7-747c71323182"), false, "//meta[@name='author']/@content", new Guid("a722c0ae-78b4-4efe-9fb4-c09a2c73585c") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_modified_at_settings",
                columns: new[] { "id", "is_required", "modified_at_culture_info", "modified_at_time_zone_info_id", "modified_at_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("0523e291-36b8-4f41-90cd-5bd4af94c073"), false, "ru-RU", "UTC", "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark_update')]//span[@ca-ts]/text()", new Guid("62ab442c-14e5-43c9-8f1b-d7f5050a461b") },
                    { new Guid("0640026d-49de-42b1-9fa7-113b0dad6edb"), false, "ru-RU", null, "//meta[@itemprop='dateModified']/@content", new Guid("aac9a853-d700-4df0-83e0-247b1976e34a") },
                    { new Guid("0dbc564c-0b79-4aab-b2ce-0ec5da48cc62"), false, "ru-RU", null, "//meta[@itemprop='dateModified']/@content", new Guid("789735b4-4e60-43eb-a422-55ab2c60e419") },
                    { new Guid("5087457f-1e91-4e89-a20e-8dcb7c8cfb94"), true, "ru-RU", "Russian Standard Time", "//meta[@property='article:modified_time']/@content", new Guid("83890049-1c2b-4fb9-a240-8d1a58072a95") },
                    { new Guid("5751c545-5dd9-4cbc-80f4-10abbf785c07"), false, "ru-RU", "Russian Standard Time", "//meta[@itemprop='dateModified']/@content", new Guid("df1e0e9b-364c-4a45-b02a-f4130ecb8183") },
                    { new Guid("6ea68a1d-0867-4f54-9de1-1af4267177a3"), false, "en-US", null, "//meta[@property='article:modified_time']/@content", new Guid("a722c0ae-78b4-4efe-9fb4-c09a2c73585c") },
                    { new Guid("a6c2cdcc-db87-420e-8404-b9941819fb33"), true, "ru-RU", "Russian Standard Time", "//div[@class='article__info']//div[@class='article__info-date']/span[@class='article__info-date-modified']/text()", new Guid("4af9e5bb-677e-4186-832d-2778bebe0f6c") },
                    { new Guid("aa59b4d5-d5ba-40e4-a612-e3e85762c5e0"), false, "ru-RU", "Russian Standard Time", "//div[@class='doc_header__time']/span[contains(@class, 'publish_update')]/text()", new Guid("01914729-c0f7-4b44-a450-e2d8b0eab357") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_picture_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("10a06ff2-f74d-4061-a2c0-8d3ac51e31ff"), false, new Guid("789735b4-4e60-43eb-a422-55ab2c60e419"), "//meta[@itemprop='url']/@content" },
                    { new Guid("1c96bf95-3083-4d18-a923-a40f80ba9e84"), false, new Guid("7bc1101f-3abd-46f1-aecc-9e930836536b"), "//article/figure/img/@src" },
                    { new Guid("3f0a3b3d-ab00-48f2-9ffa-836408ca4b98"), true, new Guid("6536a997-6bfc-4bef-bcde-1619c4b6d47a"), "//header//figure//picture/img/@src" },
                    { new Guid("53dabff5-8e0f-4426-8225-adf2eaac2de3"), false, new Guid("62ab442c-14e5-43c9-8f1b-d7f5050a461b"), "//div[contains(@class, 'HeaderMedia_image')]//img[contains(@class, 'Image_image')]/@src" },
                    { new Guid("56b81bac-87f2-418b-b562-7baf1091830c"), false, new Guid("df1e0e9b-364c-4a45-b02a-f4130ecb8183"), "//meta[@property='og:image']/@content" },
                    { new Guid("5cda0669-c783-44d8-a3c6-fbb05849effd"), true, new Guid("83890049-1c2b-4fb9-a240-8d1a58072a95"), "//div[@data-gtm-el='content-body']//picture/img/@src" },
                    { new Guid("5d31bd09-75b6-4002-a7a4-a54dbcbeaaaf"), false, new Guid("3b5479c0-92ce-4cd8-8619-03f5f3c5e6a6"), "//meta[@property='og:image']/@content" },
                    { new Guid("5e128277-f1e0-4a04-9df8-84ccabe46ef9"), false, new Guid("0a56106a-1a96-4553-a4c7-fa3b85d1c636"), "//figure//img/@src" },
                    { new Guid("707e39b7-132e-408a-b70d-ef2ead0c3beb"), false, new Guid("cde1c65d-c8ae-4ab9-bf14-55b86846acc4"), "//article//header/div[contains(@class, 'styles_cover_media')]/img/@src" },
                    { new Guid("77909b05-b346-41fb-93ed-7e326da7a6fe"), false, new Guid("1f52c5b0-093c-4327-84d4-75aa8bccac4e"), "//div[contains(@class, 'full-article')]/div[contains(@class, 'gallery')]/picture/img/@src" },
                    { new Guid("7af7dee0-5a6e-4deb-8d15-8bf00a263d18"), true, new Guid("e15645fe-9624-4293-a437-bed1f6ced43b"), "//meta[@property='og:image']/@content" },
                    { new Guid("7e701b48-aeb7-41ee-842a-b72cd73b0c25"), true, new Guid("9a8fc5ed-99dc-4e9f-970a-9fca4c4e689d"), "//div[contains(@class, 'big_photo')]//div[@class='big_photo__img']//img/@data-src" },
                    { new Guid("8cff1a02-11ba-404d-8d97-48a94b355824"), false, new Guid("469c5c35-5a60-4d55-bb27-eb33aee632ce"), "//meta[@property='og:image']/@content" },
                    { new Guid("91fac4d4-7a4a-4adf-b4e9-df1a59945ac4"), false, new Guid("02ad6cb8-7406-4672-85f1-93f9a481f892"), "//div[@class='b_article-media']//div[@class='mainarea-wrapper']/figure/img[@class='item-image-front']/@src" },
                    { new Guid("924b54da-4caf-4a3a-80f5-b3a790c492fb"), false, new Guid("d682fb0f-2bf0-416a-9a8f-a0b9897157c2"), "//meta[@property='og:image']/@content" },
                    { new Guid("92fb7a49-4192-4ac5-81e8-4cb76e8f4657"), false, new Guid("b04c0205-8eb2-47d9-8f2c-71156a1aade8"), "//div[@class='inner_content']//div[@class='main_img']//img/@src" },
                    { new Guid("9e345386-8f45-496b-ac54-19dc1acf8e93"), false, new Guid("648ebc10-5c3f-46ac-9a93-ab2d50785c06"), "//meta[@property='og:image']/@content" },
                    { new Guid("a397011c-0fa1-4f80-8554-074a226ad318"), true, new Guid("107b0b2d-892c-4c37-8bdf-ab63b071ffee"), "//div[@class='article__media']//img/@src" },
                    { new Guid("bbc826ec-3934-469f-bf20-f424d965fa69"), true, new Guid("6d040458-5310-4ed1-96cf-00f28e248600"), "//a[@class='glightbox']/img[contains(@class, 'pub-cover')]/@src" },
                    { new Guid("c19cf2c9-4f72-4fd7-9d69-b82deb708188"), true, new Guid("616cb1ff-8d47-49fe-b0e6-f67148b21d31"), "//div[contains(@class, 'newsMediaContainer')]/img/@data-src" },
                    { new Guid("c3813679-fb99-439d-9066-6352c9a981a1"), false, new Guid("aecd6ab1-ca0b-4f18-aea8-192550ba9631"), "//article//div[@class='image-con' and position() = 1]/picture/img/@src" },
                    { new Guid("cc32b2c8-9a6f-4ade-9f37-8ab66f2c45a8"), false, new Guid("823a518a-94e0-4a10-87ef-62c01233cd01"), "//div[contains(@class, 'topic-body__title-image')]//img[contains(@class, 'picture__image')]/@src" },
                    { new Guid("cf081d86-663a-4afc-b784-80837ecfd206"), false, new Guid("11cb58ce-1388-4e38-ac45-386b63039b68"), "//img[@itemprop='image']/@src" },
                    { new Guid("cfc5ce41-f906-483c-97b0-f1dc87e607ad"), true, new Guid("a2acfcb4-2852-49c4-8ea2-420f3cc9ea83"), "//div[@itemprop='articleBody']//div[@itemprop='image']/picture/img[@itemprop='contentUrl']/@src" },
                    { new Guid("d12bb1ee-50ee-412a-a872-3cb253befbca"), false, new Guid("be973044-7cc2-4ffa-b51d-4363aaec14cc"), "//div[@class='img_box']/a[@class='zoom_js']/img/@src" },
                    { new Guid("e09e41da-bcf8-4c7d-a40d-6a5f675f89ba"), false, new Guid("a722c0ae-78b4-4efe-9fb4-c09a2c73585c"), "//meta[@property='og:image']/@content" },
                    { new Guid("e45cec72-9694-4e00-b798-e40a300b66b8"), false, new Guid("f49de1e2-73e1-4562-ab52-719513961ec0"), "//div[contains(@class, 'article__cover')]/img[@class='article__cover-image ']/@src" },
                    { new Guid("e79f79a8-9bf8-4a3e-8e97-630e2597a3d2"), false, new Guid("0233cf68-eb05-4c15-ba1a-f14b76434916"), "//meta[@property='og:image']/@content" },
                    { new Guid("eb1fa768-1d49-4df1-9c27-7ba736b7c9da"), false, new Guid("f2fa9a76-4748-4c50-8427-4326b6cc1b49"), "//article//header/div[@class='article-head__photo']/img/@src" },
                    { new Guid("ef394603-a79f-44e3-b755-69d4561ea9d9"), false, new Guid("df70cfb3-7d39-4e28-b944-e711c3b8966e"), "//meta[@property='og:image']/@content" },
                    { new Guid("f156838a-c9d4-438b-b71e-19c2da07b380"), false, new Guid("5236f34d-7077-4fe2-a4fe-573ac5126f7d"), "//meta[@property='og:image']/@content" },
                    { new Guid("f47f946a-6d98-41c7-a7b2-546e63387693"), false, new Guid("a261b1e7-8770-4ab6-9972-711d92ce6ac3"), "//meta[@name='og:image']/@content" },
                    { new Guid("fabf889a-8b10-477a-99b8-f103931ecbc4"), false, new Guid("4af9e5bb-677e-4186-832d-2778bebe0f6c"), "//div[@class='photoview__open']/img/@src" },
                    { new Guid("ffc0514b-9fb2-4977-b17f-b0395c71ad13"), false, new Guid("aac9a853-d700-4df0-83e0-247b1976e34a"), "//meta[@property='og:image']/@content" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "published_at_culture_info", "published_at_time_zone_info_id", "published_at_x_path" },
                values: new object[,]
                {
                    { new Guid("1d606da7-8987-4e3a-ae35-1c0cc5a88422"), true, new Guid("107b0b2d-892c-4c37-8bdf-ab63b071ffee"), "ru-RU", "Russian Standard Time", "//div[@class='article__meta']/time/text()" },
                    { new Guid("24adabb1-a8c7-4036-96f4-4c535cb3583a"), true, new Guid("11cb58ce-1388-4e38-ac45-386b63039b68"), "ru-RU", null, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']/span[@itemprop='datePublished']/@content" },
                    { new Guid("2bde93d0-4f3b-4696-86e0-01d893b76ad1"), true, new Guid("9a8fc5ed-99dc-4e9f-970a-9fca4c4e689d"), "ru-RU", null, "//div[@class='article_page__left__top__left']//div[@class='article_page__left__top__time']//time/@datetime" },
                    { new Guid("2d7a3fd2-0bc1-441e-b610-bb73eeb48f35"), true, new Guid("a2acfcb4-2852-49c4-8ea2-420f3cc9ea83"), "ru-RU", null, "//div[@class='publication-info']/time[@itemprop='datePublished']/@datetime" },
                    { new Guid("31562623-6f5b-4312-9372-8c5ce5918f3c"), true, new Guid("f2fa9a76-4748-4c50-8427-4326b6cc1b49"), "ru-RU", "Russian Standard Time", "//article//header//time[@class='article-head__date']/text()" },
                    { new Guid("36821546-2e7f-41b6-ae8a-9d7bc3fd9a1d"), true, new Guid("be973044-7cc2-4ffa-b51d-4363aaec14cc"), "ru-RU", "Russian Standard Time", "//div[@class='article_top']//div[@class='date']//time/text()" },
                    { new Guid("4dce29e1-924c-4d9b-8e65-d016d349b560"), true, new Guid("62ab442c-14e5-43c9-8f1b-d7f5050a461b"), "ru-RU", "UTC", "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark')]//span[@ca-ts]/text()" },
                    { new Guid("5361cfc6-a016-4d56-8635-b27291cd0293"), true, new Guid("648ebc10-5c3f-46ac-9a93-ab2d50785c06"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'PageArticleContent_date')]/text()" },
                    { new Guid("56f40a90-ac93-4c40-9e0d-75c07025490a"), true, new Guid("b04c0205-8eb2-47d9-8f2c-71156a1aade8"), "ru-RU", "Russian Standard Time", "//div[@class='date_full']/text()" },
                    { new Guid("5bf97260-a2e3-46be-913d-ef95eb778a47"), true, new Guid("d682fb0f-2bf0-416a-9a8f-a0b9897157c2"), "ru-RU", "Russian Standard Time", "//div[@class='article-details']/span[@class='article-details__time']/time/@datetime" },
                    { new Guid("5f596da4-f76f-49cd-b63f-21c4abe98dac"), true, new Guid("e15645fe-9624-4293-a437-bed1f6ced43b"), "ru-RU", null, "//article/header//time/@datetime" },
                    { new Guid("5fa65713-7359-4048-b99d-b04392421dfb"), true, new Guid("df1e0e9b-364c-4a45-b02a-f4130ecb8183"), "ru-RU", "Russian Standard Time", "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("6142f014-679e-4adc-be63-7693b3c79bfc"), true, new Guid("3b5479c0-92ce-4cd8-8619-03f5f3c5e6a6"), "ru-RU", "Russian Standard Time", "//div[@class='b-text__date']/text()" },
                    { new Guid("6a425372-7826-4afa-a407-978122bcd52d"), true, new Guid("a722c0ae-78b4-4efe-9fb4-c09a2c73585c"), "en-US", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("88645029-3e0b-4431-9d2a-526c71e72c02"), true, new Guid("789735b4-4e60-43eb-a422-55ab2c60e419"), "ru-RU", null, "//div[@class='article__header__info-block']/time[@class='article__header__date']/@datetime" },
                    { new Guid("93557da2-9e59-4d48-bfae-144e09137dd1"), true, new Guid("823a518a-94e0-4a10-87ef-62c01233cd01"), "ru-RU", "Russian Standard Time", "//div[@class='topic-page__header']//a[contains(@class, 'topic-header__time')]/text()" },
                    { new Guid("9f232cbb-76bc-449e-8d8b-71c5130435fe"), true, new Guid("469c5c35-5a60-4d55-bb27-eb33aee632ce"), "ru-RU", "Russian Standard Time", "//span[@class='date']/time/@datetime" },
                    { new Guid("ac0b318a-96bf-43df-96ec-049384bc036e"), true, new Guid("02ad6cb8-7406-4672-85f1-93f9a481f892"), "ru-RU", null, "//article/div[@class='b_article-header']//time[@itemprop='datePublished']/@datetime" },
                    { new Guid("aca17ded-4a12-43c0-a463-ad05512dd613"), true, new Guid("0233cf68-eb05-4c15-ba1a-f14b76434916"), "ru-RU", "Russian Standard Time", "//p[@class='b-material__date']/text()" },
                    { new Guid("b5c866d8-334d-4913-8f78-85d1ec2191ea"), true, new Guid("4af9e5bb-677e-4186-832d-2778bebe0f6c"), "ru-RU", "Russian Standard Time", "//div[@class='article__info']//div[@class='article__info-date']/a/text()" },
                    { new Guid("b642abea-8580-4149-8c0b-71768cd4389e"), true, new Guid("616cb1ff-8d47-49fe-b0e6-f67148b21d31"), "ru-RU", null, "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("b6575fbf-3e23-4be2-96db-50c5be9378a8"), true, new Guid("1f52c5b0-093c-4327-84d4-75aa8bccac4e"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'full-article')]//time/text()" },
                    { new Guid("be399a82-080b-4717-9039-7c425fc798a4"), true, new Guid("6536a997-6bfc-4bef-bcde-1619c4b6d47a"), "en-US", null, "//time/@datetime" },
                    { new Guid("be517827-b252-44bf-bb80-400e2733d267"), true, new Guid("5236f34d-7077-4fe2-a4fe-573ac5126f7d"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("bece1223-ba55-466f-83ab-4eaae37d8df0"), true, new Guid("aecd6ab1-ca0b-4f18-aea8-192550ba9631"), "en-US", "Central Europe Standard Time", "//article//div[@class='article-info']/div[@class='date']/text()" },
                    { new Guid("bedfbc98-2768-4726-843f-5bff3e45e772"), true, new Guid("aac9a853-d700-4df0-83e0-247b1976e34a"), "ru-RU", null, "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("cc7ddcc5-0783-46c0-8af6-e15922731008"), true, new Guid("01914729-c0f7-4b44-a450-e2d8b0eab357"), "ru-RU", null, "//div[@class='doc_header__time']/time[@class='doc_header__publish_time']/@datetime" },
                    { new Guid("cd756c24-39b4-4fe0-80da-f02a97f6e467"), true, new Guid("4f17562f-3759-4e6f-b2ba-e1926cdc7190"), "ru-RU", "Russian Standard Time", "//div[@class='b-article__top-author']/p[@class='date']/text()" },
                    { new Guid("d189fcf9-dcc6-4ec3-b741-d430d3d64857"), false, new Guid("6d040458-5310-4ed1-96cf-00f28e248600"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'pubdatetime')]/text()" },
                    { new Guid("d4e6575b-98f6-46d0-8d42-3c5d6646bac3"), true, new Guid("83890049-1c2b-4fb9-a240-8d1a58072a95"), "ru-RU", "Russian Standard Time", "//meta[@property='article:published_time']/@content" },
                    { new Guid("d5a9c12b-3dee-41e1-a59f-fd88a28eee42"), true, new Guid("9507883c-7527-4657-8d22-9f4c93ab4743"), "ru-RU", "Russian Standard Time", "//article[@itemprop='articleBody']/meta[@itemprop='datePublished']/@content" },
                    { new Guid("d785e100-a83f-458c-8026-e1d8c0440b88"), true, new Guid("f49de1e2-73e1-4562-ab52-719513961ec0"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'article__date-autor-shortcode')]/div[contains(@class, 'article__date')]/time[@class='date']/@datetime" },
                    { new Guid("e8f48bc8-20ad-43a4-92c6-c9946765cbcc"), true, new Guid("0a56106a-1a96-4553-a4c7-fa3b85d1c636"), "ru-RU", "Ekaterinburg Standard Time", "//div[@itemprop='datePublished']/time/@datetime" },
                    { new Guid("f0bae0a1-0289-4a8d-803e-9a4c98fddedf"), true, new Guid("9611b7d1-3fef-4cc8-bba6-615104fbd904"), "ru-RU", null, "//header[@class='news-item__header']//time/@content" },
                    { new Guid("f6ca88ed-fbc0-4414-a474-ef8dfde8aee6"), true, new Guid("cde1c65d-c8ae-4ab9-bf14-55b86846acc4"), "ru-RU", "UTC", "//article//header//div[contains(@class, 'styles_meta')]//div[contains(@class, 'styles_metaItem')]/text()" },
                    { new Guid("fc4108af-dcbf-418f-86ca-cf9988f97df7"), true, new Guid("7bc1101f-3abd-46f1-aecc-9e930836536b"), "ru-RU", "Russian Standard Time", "//article/div[@class='header']/span/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_sub_title_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("04f7ea3c-d7f7-41e8-b754-677b1b1813e1"), false, new Guid("df70cfb3-7d39-4e28-b944-e711c3b8966e"), "//meta[@property='og:description']/@content" },
                    { new Guid("0c18a796-2e7e-4aff-83df-8fb28ec5960a"), true, new Guid("6d040458-5310-4ed1-96cf-00f28e248600"), "//div[@class='container-fluid shifted']/p[@class='announce lead']/text()" },
                    { new Guid("164209d9-42cb-4211-9a5a-8a210249a7f4"), true, new Guid("02ad6cb8-7406-4672-85f1-93f9a481f892"), "//h2/text()" },
                    { new Guid("18e8c1e1-4334-4558-ae8b-96be1fe780cc"), false, new Guid("a722c0ae-78b4-4efe-9fb4-c09a2c73585c"), "//meta[@name='description']/@content" },
                    { new Guid("1dad8c13-15fb-45b8-95fa-f04065a8550c"), false, new Guid("aac9a853-d700-4df0-83e0-247b1976e34a"), "//p[contains(@itemprop, 'alternativeHeadline')]/text()" },
                    { new Guid("262ad377-f221-4250-9656-23a4fd47b340"), false, new Guid("648ebc10-5c3f-46ac-9a93-ab2d50785c06"), "//div[contains(@class, 'PageArticleContent_lead')]/text()" },
                    { new Guid("2785379c-69cb-4848-9cd6-3923abf8a340"), false, new Guid("789735b4-4e60-43eb-a422-55ab2c60e419"), "//div[contains(@class, 'article__text')]/div[@class='article__text__overview']/span/text()" },
                    { new Guid("2a457db0-0fe4-405c-87e8-35789d080f5f"), false, new Guid("0233cf68-eb05-4c15-ba1a-f14b76434916"), "//meta[@property='og:description']/@content" },
                    { new Guid("2dadb04c-3ad1-428e-9bf3-2873cfd5a424"), true, new Guid("11cb58ce-1388-4e38-ac45-386b63039b68"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()=1]/text()" },
                    { new Guid("2e1f415a-d77a-452a-a466-83c895e520cf"), true, new Guid("aecd6ab1-ca0b-4f18-aea8-192550ba9631"), "//p[@class='headertext' and @itemprop='description']/text()" },
                    { new Guid("3ad3fb7b-b4f0-47af-a974-cecb636b2b22"), false, new Guid("a261b1e7-8770-4ab6-9972-711d92ce6ac3"), "//div[contains(@class, 'styled__StoryBody')]/p[contains(@class, 'styled__StoryParagraph') and position()=1]/text()" },
                    { new Guid("3db81576-858e-471f-89e5-f8aa1b357c6d"), true, new Guid("6536a997-6bfc-4bef-bcde-1619c4b6d47a"), "//header/p[@id='article-summary']/text()" },
                    { new Guid("4114232a-81d7-4006-9d7d-1c847f75568b"), false, new Guid("4f17562f-3759-4e6f-b2ba-e1926cdc7190"), "//h4/text()" },
                    { new Guid("4cdb152b-e120-4fde-a97a-d0b1272bc3c6"), false, new Guid("cde1c65d-c8ae-4ab9-bf14-55b86846acc4"), "//article//header//p[contains(@class, 'styles_subtitle')]/text()" },
                    { new Guid("4dc5a49d-a26a-42fe-b64a-64f4b9b92dd8"), true, new Guid("1f52c5b0-093c-4327-84d4-75aa8bccac4e"), "//h1/text()" },
                    { new Guid("530d8f39-f9ae-4797-bd3d-039d0778308a"), true, new Guid("f49de1e2-73e1-4562-ab52-719513961ec0"), "//div[contains(@class, 'article__summary')]/text()" },
                    { new Guid("6ae03f27-4fae-4d19-9b6f-3037df5fa761"), false, new Guid("9a8fc5ed-99dc-4e9f-970a-9fca4c4e689d"), "//div[@itemprop='alternativeHeadline']/text()" },
                    { new Guid("7784484a-7868-4e28-9cff-02cac4e20c30"), false, new Guid("62ab442c-14e5-43c9-8f1b-d7f5050a461b"), "//h3/text()" },
                    { new Guid("79b8fb8c-c9e4-4ab3-a263-a6668f50925e"), false, new Guid("469c5c35-5a60-4d55-bb27-eb33aee632ce"), "//meta[@name='description']/@content" },
                    { new Guid("7bb71659-9fcd-419e-af29-33623c3929fb"), false, new Guid("3b5479c0-92ce-4cd8-8619-03f5f3c5e6a6"), "//meta[@property='og:description']/@content" },
                    { new Guid("9232b046-4eaf-4f25-b47f-2a0f1f3c79b7"), false, new Guid("5236f34d-7077-4fe2-a4fe-573ac5126f7d"), "//div[@class='block-page-new']/h2/text()" },
                    { new Guid("939cc3c0-5591-4ccd-ae89-438b9ded6b09"), true, new Guid("e15645fe-9624-4293-a437-bed1f6ced43b"), "//div[contains(@class, 'js-mediator-article')]/*[position()=1]/text()" },
                    { new Guid("9e2ebe45-fa90-4a70-92df-99f4af31d0ef"), true, new Guid("4af9e5bb-677e-4186-832d-2778bebe0f6c"), "//h1[@class='article__second-title']/text()" },
                    { new Guid("a148be6f-bb41-467b-ad1b-8c07b83f68e0"), true, new Guid("83890049-1c2b-4fb9-a240-8d1a58072a95"), "//meta[@name='description']/@content" },
                    { new Guid("aed99b43-8c15-4481-90df-31559ee504a3"), true, new Guid("0a56106a-1a96-4553-a4c7-fa3b85d1c636"), "//p[@itemprop='alternativeHeadline']/span/text()" },
                    { new Guid("b371112a-3eb9-4995-9338-64650c47ed39"), false, new Guid("7bc1101f-3abd-46f1-aecc-9e930836536b"), "//h4/text()" },
                    { new Guid("b556a0e8-7dbb-4599-b124-b3664842c982"), false, new Guid("01914729-c0f7-4b44-a450-e2d8b0eab357"), "//header[@class='doc_header']/h2[contains(@class, 'doc_header__subheader')]/text()" },
                    { new Guid("bad1ca16-cee6-480e-9605-754193b5f64f"), true, new Guid("616cb1ff-8d47-49fe-b0e6-f67148b21d31"), "//div[@itemprop='alternativeHeadline']/text()" },
                    { new Guid("c5986d67-7662-4081-8d2f-c16999386149"), true, new Guid("107b0b2d-892c-4c37-8bdf-ab63b071ffee"), "//div[@class='article__intro']/p/text()" },
                    { new Guid("ce71d7c4-6c3f-490c-a68c-a8d6d9fba224"), false, new Guid("d682fb0f-2bf0-416a-9a8f-a0b9897157c2"), "//meta[@name='description']/@content" },
                    { new Guid("da33203a-7c6f-4196-8043-99348b656f2b"), false, new Guid("a2acfcb4-2852-49c4-8ea2-420f3cc9ea83"), "//meta[@itemprop='description']/@content" },
                    { new Guid("e52e6494-32c2-477d-b38d-ee47a02d2227"), false, new Guid("df1e0e9b-364c-4a45-b02a-f4130ecb8183"), "//meta[@property='og:description']/@content" },
                    { new Guid("e99dd324-652a-414c-a39e-b0cf70a94729"), false, new Guid("823a518a-94e0-4a10-87ef-62c01233cd01"), "//div[contains(@class, 'topic-body__title')]/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_video_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("8b418d1f-d179-43d2-9245-6d5416df35d0"), false, new Guid("648ebc10-5c3f-46ac-9a93-ab2d50785c06"), "//div[contains(@class, 'PageContentCommonStyling_text')]/rg-video//video/@src" },
                    { new Guid("95ba1be7-f305-490a-a26e-ca97ed6c7b90"), false, new Guid("823a518a-94e0-4a10-87ef-62c01233cd01"), "//div[contains(@class='eagleplayer')]//video/@src" },
                    { new Guid("a5c71b46-0a55-4a45-a91a-d708a01437a6"), false, new Guid("4af9e5bb-677e-4186-832d-2778bebe0f6c"), "//div[@class='article__header']//div[@class='media__video']//video/@src" },
                    { new Guid("c4654e7a-9888-4568-84de-7302759c17d2"), false, new Guid("0233cf68-eb05-4c15-ba1a-f14b76434916"), "//meta[@property='og:video:url']/@content" },
                    { new Guid("c6796e51-a7d3-40d7-8669-8c1567d06aa8"), false, new Guid("aecd6ab1-ca0b-4f18-aea8-192550ba9631"), "//article//div[@class='videoWrapper' and @itemprop='video']/iframe[@class='video']/@src" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_modified_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_modified_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("06e72f1e-7798-4694-b987-c42e60c6216b"), "\"обновлено\" HH:mm , dd.MM.yyyy", new Guid("aa59b4d5-d5ba-40e4-a612-e3e85762c5e0") },
                    { new Guid("0f39304a-c166-4e8a-b946-d0188aa71efb"), "yyyy-MM-dd", new Guid("5751c545-5dd9-4cbc-80f4-10abbf785c07") },
                    { new Guid("1f6ae925-4218-4d68-8609-701fe3affadf"), "yyyy-MM-ddTHH:mm:ss.fff\"Z+0300\"", new Guid("5087457f-1e91-4e89-a20e-8dcb7c8cfb94") },
                    { new Guid("5604e87e-3d7d-4a8c-bd51-0fb2e72bbec1"), "\"обновлено\" d MMMM, HH:mm", new Guid("0523e291-36b8-4f41-90cd-5bd4af94c073") },
                    { new Guid("624bf8b1-6121-4836-94e7-c440611d3f85"), "yyyy-MM-ddTHH:mm:ss.fffZ", new Guid("6ea68a1d-0867-4f54-9de1-1af4267177a3") },
                    { new Guid("c2eb77f8-32af-415f-9ace-0089d1c5d62b"), "\"обновлено\" HH:mm , dd.MM", new Guid("aa59b4d5-d5ba-40e4-a612-e3e85762c5e0") },
                    { new Guid("d03c91c1-83fb-4589-a2f7-5a7cc3c8aa65"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("0640026d-49de-42b1-9fa7-113b0dad6edb") },
                    { new Guid("d8756ec3-5eef-46a3-b004-7578ccfdc42d"), "\"обновлено\" d MMMM yyyy, HH:mm", new Guid("0523e291-36b8-4f41-90cd-5bd4af94c073") },
                    { new Guid("e9470573-c5c0-4ab3-b9b0-35f20825e307"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("0dbc564c-0b79-4aab-b2ce-0ec5da48cc62") },
                    { new Guid("ff884c84-d763-4078-bcb9-f802b109b10b"), "(\"обновлено:\" HH:mm dd.MM.yyyy)", new Guid("a6c2cdcc-db87-420e-8404-b9941819fb33") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_published_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("07859e1c-0704-4fe4-abf3-1cb2cddf5720"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("bedfbc98-2768-4726-843f-5bff3e45e772") },
                    { new Guid("0be12b3f-bda3-447b-ad1a-3fc4eeb22763"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("be517827-b252-44bf-bb80-400e2733d267") },
                    { new Guid("0f09f0db-5467-4855-b11e-afd521e22a35"), "d MMMM yyyy, HH:mm", new Guid("f6ca88ed-fbc0-4414-a474-ef8dfde8aee6") },
                    { new Guid("14af44c6-6cd6-4f47-9775-c9b1bae0161b"), "d MMMM yyyy \"в\" HH:mm", new Guid("cd756c24-39b4-4fe0-80da-f02a97f6e467") },
                    { new Guid("1e0b044f-e078-4f93-b88f-32271ce56453"), "d MMMM yyyy HH:mm", new Guid("6142f014-679e-4adc-be63-7693b3c79bfc") },
                    { new Guid("1ef77a0b-d386-4969-add6-63d6999a4008"), "d MMMM yyyy, HH:mm,", new Guid("4dce29e1-924c-4d9b-8e65-d016d349b560") },
                    { new Guid("25ca6059-11c7-4123-a96d-ee040e82db06"), "d MMMM yyyy, HH:mm\" •\"", new Guid("fc4108af-dcbf-418f-86ca-cf9988f97df7") },
                    { new Guid("2bb30206-b399-4515-b96a-b5d35a14d9fb"), "HH:mm, d MMMM yyyy", new Guid("93557da2-9e59-4d48-bfae-144e09137dd1") },
                    { new Guid("2f5d0316-16b4-491f-9d83-ee15686230a6"), "d MMMM, HH:mm", new Guid("4dce29e1-924c-4d9b-8e65-d016d349b560") },
                    { new Guid("31dce796-6c96-49dd-ba5e-a8b3a7ec0550"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("2bde93d0-4f3b-4696-86e0-01d893b76ad1") },
                    { new Guid("3c078b0b-75b9-4c05-b069-e7ecef26e866"), "d MMMM yyyy", new Guid("5bf97260-a2e3-46be-913d-ef95eb778a47") },
                    { new Guid("3ff42b90-83e9-4d3e-a324-f784123f6175"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("be399a82-080b-4717-9039-7c425fc798a4") },
                    { new Guid("47505907-c055-4064-a06a-1d50beef24dd"), "dd.MM.yyyy HH:mm", new Guid("36821546-2e7f-41b6-ae8a-9d7bc3fd9a1d") },
                    { new Guid("51edfdd0-5624-48e5-81d4-bb3f1df81acb"), "dd MMMM yyyy, HH:mm", new Guid("56f40a90-ac93-4c40-9e0d-75c07025490a") },
                    { new Guid("65fcb10e-b9f2-4eb1-8ba4-84fc131a5057"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("ac0b318a-96bf-43df-96ec-049384bc036e") },
                    { new Guid("69d23396-cff3-4d9e-9c02-54f34f2e8698"), "yyyy-MM-ddTHH:mm:ss.fffZ", new Guid("5f596da4-f76f-49cd-b63f-21c4abe98dac") },
                    { new Guid("744dfe46-e255-4af8-95cd-0ebdeceb3554"), "dd MMMM, HH:mm", new Guid("aca17ded-4a12-43c0-a463-ad05512dd613") },
                    { new Guid("76e19a7d-0371-458e-ad72-95f6fa1cf5b1"), "HH:mm dd.MM.yyyy", new Guid("b5c866d8-334d-4913-8f78-85d1ec2191ea") },
                    { new Guid("81236cd9-1dd8-4b35-a5b3-e4dbfca15fa6"), "yyyy-MM-dd HH:mm:ss", new Guid("d189fcf9-dcc6-4ec3-b741-d430d3d64857") },
                    { new Guid("81b3aca2-e8d6-4c9e-a032-aafe11b85cb9"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("24adabb1-a8c7-4036-96f4-4c535cb3583a") },
                    { new Guid("893e23c6-ae79-4fe2-8cdf-cbd8278e2a8c"), "yyyy-MM-dd", new Guid("5fa65713-7359-4048-b99d-b04392421dfb") },
                    { new Guid("90218691-0553-4afc-9d09-c99ce19766fe"), "d MMMM yyyy, HH:mm", new Guid("4dce29e1-924c-4d9b-8e65-d016d349b560") },
                    { new Guid("908097d2-9b7c-4a99-a0d4-eff7cb8a9125"), "d-M-yyyy HH:mm", new Guid("bece1223-ba55-466f-83ab-4eaae37d8df0") },
                    { new Guid("956b7180-303e-4730-84ec-ac41cf3059e0"), "dd.MM.yyyy HH:mm", new Guid("b6575fbf-3e23-4be2-96db-50c5be9378a8") },
                    { new Guid("a1f1a17e-1062-4894-9feb-71550526a698"), "yyyy-MM-d HH:mm", new Guid("d785e100-a83f-458c-8026-e1d8c0440b88") },
                    { new Guid("a662ab99-0a38-4f5e-8fa5-48487e86afc2"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("cc7ddcc5-0783-46c0-8af6-e15922731008") },
                    { new Guid("aaad6f38-a375-42fb-a43c-c994a9774b3a"), "yyyy-MM-ddTHH:mm:ss.fff\"Z+0300\"", new Guid("d4e6575b-98f6-46d0-8d42-3c5d6646bac3") },
                    { new Guid("adba4c38-0fc6-4af0-a5b4-27b06c73e712"), "d MMMM, HH:mm", new Guid("f6ca88ed-fbc0-4414-a474-ef8dfde8aee6") },
                    { new Guid("aedd04a2-eb76-4fe9-b656-548ca1ec0bd5"), "yyyy-MM-ddTHH:mm:ss", new Guid("e8f48bc8-20ad-43a4-92c6-c9946765cbcc") },
                    { new Guid("c023788a-1a16-4f34-814b-483ec1a594c3"), "dd.MM.yyyy HH:mm", new Guid("5361cfc6-a016-4d56-8635-b27291cd0293") },
                    { new Guid("c333cb20-c4a8-43d6-b33c-792f43d55d80"), "yyyy-MM-ddTHH:mm:ss.fffZ", new Guid("6a425372-7826-4afa-a407-978122bcd52d") },
                    { new Guid("c3c559a6-3664-433e-84be-ae98ad31d1ed"), "HH:mm", new Guid("1d606da7-8987-4e3a-ae35-1c0cc5a88422") },
                    { new Guid("c949b58e-c37e-45eb-8c4a-b708a5de8afc"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("88645029-3e0b-4431-9d2a-526c71e72c02") },
                    { new Guid("cf75f947-7087-400c-8087-a2806c8300db"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("b642abea-8580-4149-8c0b-71768cd4389e") },
                    { new Guid("d8f0712a-a78c-4258-9653-a3fde7b37022"), "d MMMM, HH:mm,", new Guid("4dce29e1-924c-4d9b-8e65-d016d349b560") },
                    { new Guid("d93937f4-a440-4533-90a1-ad8a09be72ca"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("2d7a3fd2-0bc1-441e-b610-bb73eeb48f35") },
                    { new Guid("dabacd15-aa0f-4660-902d-9d977bd34b36"), "dd MMMM yyyy HH:mm", new Guid("1d606da7-8987-4e3a-ae35-1c0cc5a88422") },
                    { new Guid("dec31f38-46d7-4328-9726-96b6d9e53717"), "yyyy-MM-dd HH:mm", new Guid("9f232cbb-76bc-449e-8d8b-71c5130435fe") },
                    { new Guid("e27ccad0-fe8b-4347-a427-43b8bd7dbd90"), "dd MMMM yyyy, HH:mm", new Guid("aca17ded-4a12-43c0-a463-ad05512dd613") },
                    { new Guid("e2a204af-683b-4e19-832a-60049dbe16ce"), "HH:mm", new Guid("aca17ded-4a12-43c0-a463-ad05512dd613") },
                    { new Guid("e7cc466e-f39a-4d75-a62c-880846a88800"), "d MMMM yyyy, HH:mm \"МСК\"", new Guid("31562623-6f5b-4312-9372-8c5ce5918f3c") },
                    { new Guid("eb5ce8ed-b24e-46a5-99c1-3425a960f182"), "d MMMM  HH:mm", new Guid("6142f014-679e-4adc-be63-7693b3c79bfc") },
                    { new Guid("ec9bdca4-9da6-4a2d-9e10-fbef19e98758"), "yyyy-MM-ddTHH:mm:ss", new Guid("d5a9c12b-3dee-41e1-a59f-fd88a28eee42") },
                    { new Guid("f75fc163-a391-4a0a-bfed-3408b38e79dd"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("f0bae0a1-0289-4a8d-803e-9a4c98fddedf") }
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
