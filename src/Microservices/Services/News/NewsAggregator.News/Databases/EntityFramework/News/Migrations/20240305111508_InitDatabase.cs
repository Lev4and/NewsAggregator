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
                    { new Guid("08c00b76-e6e7-4bdd-b5c6-39cf1fc5e620"), true, "https://www.avtovzglyad.ru/", "АвтоВзгляд" },
                    { new Guid("0c84be0b-ff10-4c02-b21a-a9cf448b3231"), true, "https://life.ru/", "Life" },
                    { new Guid("0e1aa03f-ef5b-4b40-aaf1-360edc088e01"), true, "https://ixbt.games/", "iXBT.games" },
                    { new Guid("1522ea71-31d5-44b8-ade3-d17737c4a59a"), true, "https://edition.cnn.com/", "CNN" },
                    { new Guid("23b94c0b-2e91-4691-bf9b-0eb592952a15"), true, "https://ura.news/", "Ura.ru" },
                    { new Guid("282139c4-4ee1-434f-a07d-3b782b869a4e"), true, "https://ria.ru/", "РИА Новости" },
                    { new Guid("2b4bb14a-7c9c-45db-aaf1-04eed2635410"), true, "https://www.sports.ru/", "Storts.ru" },
                    { new Guid("311b1e93-ca44-4578-980b-dc520d986aef"), true, "https://russian.rt.com/", "RT на русском" },
                    { new Guid("3434406f-ba29-4624-a326-61359ff796bd"), true, "https://svpressa.ru/", "СвободнаяПресса" },
                    { new Guid("3ae55f16-0cd5-4486-a8ca-00ab4af26558"), true, "https://www.1obl.ru/", "Первый областной" },
                    { new Guid("3d026519-7eff-402d-9647-f3781b093d99"), true, "https://vz.ru/", "ВЗГЛЯД.РУ" },
                    { new Guid("3db88fea-a678-463c-b933-571deac480ae"), true, "https://www.cybersport.ru/", "Cybersport.ru" },
                    { new Guid("47766571-2bd4-4cff-ae7f-fb1a4442f7b5"), true, "https://www.pravda.ru/", "Правда.ру" },
                    { new Guid("4adf62bb-0923-48f3-ad0c-cc52b22f86c2"), true, "https://www.championat.com/", "Чемпионат.com" },
                    { new Guid("554d00bd-e971-46ed-93b7-4f6734154885"), true, "https://www.kommersant.ru/", "Коммерсантъ" },
                    { new Guid("57b1778d-afe4-4b0c-ba92-caa714f788a6"), true, "https://www.zr.ru/", "Журнал \"За рулем\"" },
                    { new Guid("59152ee7-f743-4410-a51f-c2ca010c6d08"), true, "https://www.hltv.org/", "HLTV.org" },
                    { new Guid("892afab0-a880-457c-9e0b-741ee25a4468"), true, "https://www.starhit.ru/", "Сетевое издание «Онлайн журнал StarHit (СтарХит)" },
                    { new Guid("8b6381a4-2b50-4841-a981-175c4e1beb7e"), true, "https://rg.ru/", "Российская газета" },
                    { new Guid("971ca435-dd43-4863-9ff3-010b0bf23917"), true, "https://tass.ru/", "ТАСС" },
                    { new Guid("a45f190a-a426-4eb9-af21-ed86d6a3adfc"), true, "https://aif.ru/", "Аргументы и факты" },
                    { new Guid("a831084a-eb27-4de8-aa96-4a50525a4819"), true, "https://www.rbc.ru/", "РБК" },
                    { new Guid("b1cb3540-817d-4276-b32e-68af1a12c4b3"), true, "https://tsargrad.tv/", "Царьград" },
                    { new Guid("b93a580a-6907-4ad6-9b24-ffe79a121058"), true, "https://3dnews.ru/", "3Dnews.ru" },
                    { new Guid("c3ae47f1-2820-41f8-823c-3eb227768ea1"), true, "https://lenta.ru/", "Лента.Ру" },
                    { new Guid("d0c9c267-e4b1-478a-a22e-cc5918e29e09"), true, "https://www.m24.ru/", "Москва 24" },
                    { new Guid("d35440ac-a44b-48d6-93ed-ef53ac59d22d"), true, "https://7days.ru/", "7дней.ru" },
                    { new Guid("d6389497-b1d1-4ee0-b976-a4ab44330fdd"), true, "https://www.gazeta.ru/", "Газета.Ru" },
                    { new Guid("d984d8f6-19d9-4e4c-a4a7-c1ae08c18846"), true, "https://www.nytimes.com/", "The New York Times" },
                    { new Guid("e83b5985-3a5e-4e67-80bc-f61a69e7dedc"), true, "https://iz.ru/", "Известия" },
                    { new Guid("e963a900-bdd8-4c5f-a752-55b2dbcafc5b"), false, "https://www.kinonews.ru/", "KinoNews.ru" },
                    { new Guid("eb71a9e0-8d8b-4812-aae7-edd0a82c1e22"), true, "https://stopgame.ru/", "StopGame" },
                    { new Guid("ed90f75a-64a2-4fc7-9513-03cac1685f3c"), true, "https://www.kp.ru/", "Комсомольская правда" },
                    { new Guid("f025cee2-bad5-48fd-b09b-eb5314bd86dd"), true, "https://74.ru/", "74.ru" },
                    { new Guid("f046c8d9-135a-45f5-a8b0-7c9174833c94"), true, "http://www.belta.by/", "БелТА" },
                    { new Guid("f605fece-3480-4543-9734-abfc18fb2da0"), true, "https://overclockers.ru/", "Overclockers" },
                    { new Guid("f9ba04c2-2754-45c9-b6b5-336f2a317ee4"), true, "https://www.interfax.ru/", "Интерфакс" },
                    { new Guid("ffa8cbf6-240f-4eca-99e5-00eff2902b3c"), true, "https://www.ixbt.com/", "iXBT.com" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_settings",
                columns: new[] { "id", "html_description_x_path", "source_id", "text_description_x_path", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("04e4d3d6-edce-41d3-80b6-6594ba543493"), "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]", new Guid("0c84be0b-ff10-4c02-b21a-a9cf448b3231"), "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("0639d907-e065-4e84-9eb8-f4c0815b76d0"), "//div[@class='material-7days__paragraf-content']/*[not(name()='div' and @itemprop='image' and position()=1)]", new Guid("d35440ac-a44b-48d6-93ed-ef53ac59d22d"), "//div[@class='material-7days__paragraf-content']//p/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("0abec58f-9bef-4360-a474-c3fb0d47b0d6"), "//article//div[@class='newstext-con']/*[position()>2]", new Guid("59152ee7-f743-4410-a51f-c2ca010c6d08"), "//article//div[@class='newstext-con']/*[position()>2]/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("10822532-c84b-4cd9-9d47-359d66928bb8"), "//div[@itemprop='articleBody']/*", new Guid("ffa8cbf6-240f-4eca-99e5-00eff2902b3c"), "//div[@itemprop='articleBody']/*/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("10b37602-0255-4c93-bb7e-0b4f3a9507f1"), "//article/div[@class='news_text']", new Guid("3d026519-7eff-402d-9647-f3781b093d99"), "//article/div[@class='news_text']/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("1f805852-e4a1-4923-b2d1-2234162ab732"), "//div[contains(@class, 'container-fluid shifted') and not(p[@class='announce lead']) and not(h1) and not(hr)]", new Guid("0e1aa03f-ef5b-4b40-aaf1-360edc088e01"), "//div[contains(@class, 'container-fluid shifted') and not(p[@class='announce lead']) and not(h1) and not(hr)]/text()", "//meta[@name='og:title']/@content" },
                    { new Guid("26268bfb-61c1-4f55-871a-6fbb23efb903"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]", new Guid("b1cb3540-817d-4276-b32e-68af1a12c4b3"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("2912b538-8919-4f1e-9b88-070cd3f0e005"), "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]", new Guid("d0c9c267-e4b1-478a-a22e-cc5918e29e09"), "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("3996446f-7310-4200-b279-dfe2ab621ffd"), "//article/*", new Guid("971ca435-dd43-4863-9ff3-010b0bf23917"), "//article/*/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("3c066479-20b7-4bb2-8ea5-b5c3cb41344a"), "//div[contains(@class, 'styled__StoryBody')]/*[not(name()='p' and contains(@class, 'styled__StoryParagraph') and position()=1) and not(name()='div' and contains(@class, 'styled__StoryImgContainer') and position()=2)]", new Guid("57b1778d-afe4-4b0c-ba92-caa714f788a6"), "//div[contains(@class, 'styled__StoryBody')]/*[not(name()='p' and contains(@class, 'styled__StoryParagraph') and position()=1) and not(name()='div' and contains(@class, 'styled__StoryImgContainer') and position()=2)]/text()", "//meta[@name='og:title']/@content" },
                    { new Guid("3ee8abe2-e64d-4add-9537-ca788b9e4304"), "//div[contains(@class, 'material-content')]/*", new Guid("f605fece-3480-4543-9734-abfc18fb2da0"), "//div[contains(@class, 'material-content')]/p/text()", "//a[@class='header']/text()" },
                    { new Guid("40acf021-a0d5-45bf-83b0-78edcb1049ab"), "//div[contains(@class, 'PageContentCommonStyling_text')]/*[not(name() = 'rg-video')]", new Guid("8b6381a4-2b50-4841-a981-175c4e1beb7e"), "//div[contains(@class, 'PageContentCommonStyling_text')]/*[not(name() = 'rg-video')]/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("454a5585-4625-4296-b47c-938aeb1e237e"), "//div[@itemprop='articleBody']/*[not(name()='div')]", new Guid("23b94c0b-2e91-4691-bf9b-0eb592952a15"), "//div[@itemprop='articleBody']/*[not(name()='div')]/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("5ae040e0-9913-44b6-a4d8-afe7a1fbb2c4"), "//section[@itemprop='articleBody']/div[@class='ds-article-content-block-and-creative-container']/*[not(name()='div' and contains(@class, 'ds-article-content__block_image') and position()=1)]", new Guid("892afab0-a880-457c-9e0b-741ee25a4468"), "//section[@itemprop='articleBody']//div[contains(@class, 'ds-article-content__block_text')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("5dc7511d-9b88-4aed-b2a7-5264e6c3f0db"), "//div[@class='article_text']", new Guid("a45f190a-a426-4eb9-af21-ed86d6a3adfc"), "//div[@class='article_text']/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("5dd62ab7-517f-4dc2-b820-5afec397151f"), "//div[@itemprop='articleBody']/*", new Guid("d6389497-b1d1-4ee0-b976-a4ab44330fdd"), "//div[@itemprop='articleBody']/*/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("5f44d5e8-eeea-4635-b4de-775525e81fc1"), "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]", new Guid("f9ba04c2-2754-45c9-b6b5-336f2a317ee4"), "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("644827eb-8c66-4937-805e-b33f81a46f8f"), "//div[@itemprop='articleBody']/*[not(name() = 'figure')]", new Guid("f025cee2-bad5-48fd-b09b-eb5314bd86dd"), "//div[@itemprop='articleBody']/*[not(name() = 'figure')]/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("6e95bdee-9ac3-4e97-8098-6cc977c9a1a3"), "//div[contains(@class, 'js-mediator-article')]/*[position()>1]", new Guid("3db88fea-a678-463c-b933-571deac480ae"), "//div[contains(@class, 'js-mediator-article')]/*[position()>1]/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("71ba03bb-3895-4392-8240-95602937ad3c"), "//section[@itemprop='articleBody']/*", new Guid("08c00b76-e6e7-4bdd-b5c6-39cf1fc5e620"), "//section[@itemprop='articleBody']/*[not(name()='script')]/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("7243dcd7-74e9-4824-b026-617c981e51e5"), "//div[@class='js-mediator-article']", new Guid("f046c8d9-135a-45f5-a8b0-7c9174833c94"), "//div[@class='js-mediator-article']/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("818c4f01-7173-4b44-93d9-38f8e18ad70e"), "//section[contains(@class, '_page-section')]/div[contains(@class, '_content_')]/*", new Guid("eb71a9e0-8d8b-4812-aae7-edd0a82c1e22"), "//section[contains(@class, '_page-section')]/div[contains(@class, '_content_')]/*[contains(@class, '_text_')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("930057a3-2611-48d1-8698-039f0d3148be"), "//section[@name='articleBody']/*", new Guid("d984d8f6-19d9-4e4c-a4a7-c1ae08c18846"), "//section[@name='articleBody']/*/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("98babc23-2e39-495f-8818-dd2051b9ad56"), "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]", new Guid("47766571-2bd4-4cff-ae7f-fb1a4442f7b5"), "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]/text()", "//meta[@name='title']/@content" },
                    { new Guid("a02a3dfd-d4ac-46c4-ba6e-70dfd1985d83"), "//div[contains(@class, 'news-item__content')]", new Guid("2b4bb14a-7c9c-45db-aaf1-04eed2635410"), "//div[contains(@class, 'news-item__content')]/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("a3f6077e-808d-41ea-902b-c3ba497bf76c"), "//div[@itemprop='articleBody']/*", new Guid("3ae55f16-0cd5-4486-a8ca-00ab4af26558"), "//div[@itemprop='articleBody']/*/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("bbbc3e1f-8636-4a8e-8028-db2809fbc322"), "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]", new Guid("3434406f-ba29-4624-a326-61359ff796bd"), "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("bfb1e358-63cf-4783-b50c-6057f6182afd"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview'))]", new Guid("a831084a-eb27-4de8-aa96-4a50525a4819"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview'))]/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("c0383ccc-97df-4d77-befd-f457aaa4cfca"), "//div[@itemprop='articleBody']/*", new Guid("1522ea71-31d5-44b8-ade3-d17737c4a59a"), "//div[@itemprop='articleBody']/*/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("c22cac53-048e-490d-bf13-1cd33cf49a41"), "//div[@itemprop='articleBody']/*", new Guid("e83b5985-3a5e-4e67-80bc-f61a69e7dedc"), "//div[@itemprop='articleBody']//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("d07eb353-fbc5-4fbf-87f6-0a12f2cc7bc6"), "//div[@data-gtm-el='content-body']/*[not(name()='div' and @data-wide='true')]", new Guid("ed90f75a-64a2-4fc7-9513-03cac1685f3c"), "//div[@data-gtm-el='content-body']/*[not(name()='div' and @data-wide='true')]/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("d3c68a73-22f4-4fd5-9000-a6bb360dcdf8"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/*[position()>1 and not(div)]", new Guid("b93a580a-6907-4ad6-9b24-ffe79a121058"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()>1]/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("d568477b-f295-4e73-96cc-a83f33e247be"), "//div[contains(@class, 'article__body')]", new Guid("282139c4-4ee1-434f-a07d-3b782b869a4e"), "//div[contains(@class, 'article__body')]/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("e1d313bd-7c6e-4ed6-aa7f-825263066cc3"), "//div[contains(@class, 'article__text ')]", new Guid("311b1e93-ca44-4578-980b-dc520d986aef"), "//div[contains(@class, 'article__text ')]/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("e5dbfd3e-0e53-4897-b2fd-60dd4e358080"), "//div[@class='topic-body__content']", new Guid("c3ae47f1-2820-41f8-823c-3eb227768ea1"), "//div[@class='topic-body__content']/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("ef8be70e-2690-4f1b-b288-fb38d4401eb8"), "//article/div[@class='article-content']/*[not(@class)]", new Guid("4adf62bb-0923-48f3-ad0c-cc52b22f86c2"), "//article/div[@class='article-content']/*[not(@class)]/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("fd2aace8-0740-4ccf-b990-09f1dad45f0c"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]", new Guid("554d00bd-e971-46ed-93b7-4f6734154885"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("ff99e50b-27ac-49b3-8fe8-7d936c486227"), "//div[@class='textart']/div[not(@class)]/*", new Guid("e963a900-bdd8-4c5f-a752-55b2dbcafc5b"), "//div[@class='textart']/div[not(@class)]//text()", "//meta[@property='og:title']/@content" }
                });

            migrationBuilder.InsertData(
                table: "news_search_settings",
                columns: new[] { "id", "news_site_url", "news_url_x_path", "source_id" },
                values: new object[,]
                {
                    { new Guid("041af4cc-9b0e-4fa5-9a05-4ca3150aa884"), "https://www.pravda.ru/", "//a[contains(@href, '/news/') and not(@href='https://www.pravda.ru/news/')]/@href", new Guid("47766571-2bd4-4cff-ae7f-fb1a4442f7b5") },
                    { new Guid("048b693b-d660-4ee4-8a93-f6d3d72c1ff1"), "https://www.zr.ru/news/", "//a[contains(@href, '/news/') and not(starts-with(@href, '/news/')) and not(starts-with(@href, 'https://'))]/@href", new Guid("57b1778d-afe4-4b0c-ba92-caa714f788a6") },
                    { new Guid("0875c527-827f-4340-a961-fc406ad3b4a8"), "https://www.avtovzglyad.ru/news/", "//a[@class='news-card__link']/@href", new Guid("08c00b76-e6e7-4bdd-b5c6-39cf1fc5e620") },
                    { new Guid("103112c2-e6ce-4207-91d2-527574f42635"), "https://www.cybersport.ru/", "//a[contains(@href, '/tags/')]/@href", new Guid("3db88fea-a678-463c-b933-571deac480ae") },
                    { new Guid("1268876d-7c72-40a4-a9b6-9d11d9887ff9"), "https://3dnews.ru/news/", "//div[@class='news-feed-all']//a[@class='entry-header']/h1/../@href", new Guid("b93a580a-6907-4ad6-9b24-ffe79a121058") },
                    { new Guid("12d5f83e-cb55-456b-af34-02fd18ffcc47"), "https://www.interfax.ru/", "//div[@class='timeline']//a[@tabindex=5]/@href", new Guid("f9ba04c2-2754-45c9-b6b5-336f2a317ee4") },
                    { new Guid("25805d05-3076-40a4-ad36-1a5bd1253252"), "https://ixbt.games/news/", "//a[@class='card-link']/@href", new Guid("0e1aa03f-ef5b-4b40-aaf1-360edc088e01") },
                    { new Guid("274f59b2-ce68-4b62-8b27-0e9d4e9a2ebd"), "https://ria.ru/", "//a[contains(@class, 'cell-list__item-link')]/@href", new Guid("282139c4-4ee1-434f-a07d-3b782b869a4e") },
                    { new Guid("2f77d987-5865-46b0-9ab9-98a7e92a5dba"), "https://lenta.ru/", "//a[starts-with(@href, '/news/')]/@href", new Guid("c3ae47f1-2820-41f8-823c-3eb227768ea1") },
                    { new Guid("46892c79-a870-487e-b6b8-e45cc9b1a2c0"), "https://www.kinonews.ru/news/", "//a[contains(@href, '/news_') and not(contains(@href, 'comments')) and not(contains(@href, 'news_p'))]/@href", new Guid("e963a900-bdd8-4c5f-a752-55b2dbcafc5b") },
                    { new Guid("5580fcb1-c9a0-499b-a011-7cf6808d83f0"), "https://www.gazeta.ru/news/", "//a[contains(@href, '/news/') and contains(@href, '.shtml') and not(contains(@href, '?'))]/@href", new Guid("d6389497-b1d1-4ee0-b976-a4ab44330fdd") },
                    { new Guid("56795767-8d0a-4396-96ba-c53d8b3303f0"), "https://life.ru/s/novosti", "//a[contains(@href, '/p/')]/@href", new Guid("0c84be0b-ff10-4c02-b21a-a9cf448b3231") },
                    { new Guid("5ddbb67f-daff-4459-ba21-656490094615"), "https://www.hltv.org/", "//a[contains(@href, '/news/')]/@href", new Guid("59152ee7-f743-4410-a51f-c2ca010c6d08") },
                    { new Guid("5eeced40-ae06-4304-b55a-f49b1cfc223b"), "https://www.kp.ru/", "//a[contains(@href, '/news/')]/@href", new Guid("ed90f75a-64a2-4fc7-9513-03cac1685f3c") },
                    { new Guid("6354feb9-1160-4d73-b2e8-aff452e2d6d8"), "https://rg.ru/", "//a[contains(@href, '.html')]/@href", new Guid("8b6381a4-2b50-4841-a981-175c4e1beb7e") },
                    { new Guid("6a8d1d5c-af78-4a73-810f-cece1d397859"), "https://ura.news/", "//a[contains(@href, '/news/')]/@href", new Guid("23b94c0b-2e91-4691-bf9b-0eb592952a15") },
                    { new Guid("70337aef-4dbc-4a42-9e3a-e58eb0ab0ec5"), "https://www.nytimes.com/", "//a[contains(@href, '.html')]/@href", new Guid("d984d8f6-19d9-4e4c-a4a7-c1ae08c18846") },
                    { new Guid("79bd2f01-26c8-440f-8bac-bc2b90dc6ede"), "https://7days.ru/news/", "//a[contains(@class, '7days__item_href') and starts-with(@href, '/news/')]/@href", new Guid("d35440ac-a44b-48d6-93ed-ef53ac59d22d") },
                    { new Guid("7dbc8efc-a839-48c9-9d0b-a7ce7bbc947e"), "https://www.sports.ru/news/", "//a[contains(@href, '.html') and not(contains(@href, '.html#comments')) and not (contains(@href, '/blogs/'))]/@href", new Guid("2b4bb14a-7c9c-45db-aaf1-04eed2635410") },
                    { new Guid("7ffab97e-651d-4814-9861-dd55d6e54073"), "http://www.belta.by/", "//a[contains(@href, 'www.belta.by') and contains(@href, '/view/')]/@href", new Guid("f046c8d9-135a-45f5-a8b0-7c9174833c94") },
                    { new Guid("87752f18-c048-42e2-9347-6a0e7ec37434"), "https://tass.ru/", "//a[contains(@class, 'tass_pkg_link-v5WdK') and contains(substring(@href, 2), '/') and not(contains(@href, '/spec/')) and not(contains(@href, 'spec.tass.ru'))]/@href", new Guid("971ca435-dd43-4863-9ff3-010b0bf23917") },
                    { new Guid("98a67a11-e126-4b51-a326-888683792d0b"), "https://www.starhit.ru/novosti/", "//a[@class='announce-inline-tile__label-container']/@href", new Guid("892afab0-a880-457c-9e0b-741ee25a4468") },
                    { new Guid("a25be4ef-fd4c-4809-bcc5-c1891c54ab97"), "https://aif.ru/", "//span[contains(@class, 'item_text__title')]/../@href", new Guid("a45f190a-a426-4eb9-af21-ed86d6a3adfc") },
                    { new Guid("a6a54cec-c187-4716-b147-780ccfe32083"), "https://edition.cnn.com/", "//a[contains(@href, '.html')]/@href", new Guid("1522ea71-31d5-44b8-ade3-d17737c4a59a") },
                    { new Guid("a8d8ccea-0c2d-48e9-a694-37540d1dfa91"), "https://www.ixbt.com/news/", "//a[starts-with(@href, '/news/') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("ffa8cbf6-240f-4eca-99e5-00eff2902b3c") },
                    { new Guid("ac0f9b8e-a16d-49d8-915c-5fbb71732e2d"), "https://vz.ru/", "//a[contains(@href, '.html') and not(contains(@href, '#comments')) and not(contains(@href, '?')) and not(contains(@href, '/about/'))]/@href", new Guid("3d026519-7eff-402d-9647-f3781b093d99") },
                    { new Guid("af2f43b2-cf2e-44fd-9353-5471af4eeee9"), "https://www.rbc.ru/", "//a[contains(@href, 'https://www.rbc.ru/') and contains(@href, '?from=')]/@href", new Guid("a831084a-eb27-4de8-aa96-4a50525a4819") },
                    { new Guid("c612b078-d23d-484f-ad78-986d41c12f2e"), "https://www.1obl.ru/news/", "//a[starts-with(@href, '/news/') and not(contains(@href, '?'))]/@href", new Guid("3ae55f16-0cd5-4486-a8ca-00ab4af26558") },
                    { new Guid("c8a1f755-0eaa-467b-9827-227a8f88c147"), "https://stopgame.ru/news", "//div[contains(@class, 'list-view')]//div[contains(@class, '_card')]/a/@href", new Guid("eb71a9e0-8d8b-4812-aae7-edd0a82c1e22") },
                    { new Guid("cd426d0c-182c-4d71-8206-81ab430d82cd"), "https://www.m24.ru/", "//a[contains(@href, '/news/')]/@href", new Guid("d0c9c267-e4b1-478a-a22e-cc5918e29e09") },
                    { new Guid("d0208473-ca0a-4ec2-9c90-de094ef3cd08"), "https://www.kommersant.ru/", "//a[contains(@href, '/doc/') and contains(@href, '?from=')]/@href", new Guid("554d00bd-e971-46ed-93b7-4f6734154885") },
                    { new Guid("d6f0e76f-8386-4f5a-9049-09671fecd524"), "https://74.ru/", "//a[starts-with(@href, '/text/') and not(contains(@href, '?')) and not(contains(@href, 'comments/')) and not(@href='/text/')]/@href", new Guid("f025cee2-bad5-48fd-b09b-eb5314bd86dd") },
                    { new Guid("dc21a561-3b13-42a5-9755-107669fe6dd1"), "https://russian.rt.com/", "//a[contains(@class, 'link') and contains(@href, 'news/')]/@href", new Guid("311b1e93-ca44-4578-980b-dc520d986aef") },
                    { new Guid("dda5a289-4018-448f-8213-4899ff8eb743"), "https://tsargrad.tv/", "//a[contains(@class, 'news-item__link')]/@href", new Guid("b1cb3540-817d-4276-b32e-68af1a12c4b3") },
                    { new Guid("eeca6dbd-2006-407b-ae94-6e2683fb22a4"), "https://svpressa.ru/all/news/", "//a[contains(@href, '/news/') and not(contains(@href, '?')) and not(starts-with(@href, '/all/news/'))]/@href", new Guid("3434406f-ba29-4624-a326-61359ff796bd") },
                    { new Guid("eef16f62-d83f-4f97-94a6-33e938c01a30"), "https://overclockers.ru/news", "//div[contains(@class, 'event')]//a[not(contains(@href, '#comments'))]/@href", new Guid("f605fece-3480-4543-9734-abfc18fb2da0") },
                    { new Guid("f623be66-f107-4b8e-92b7-3bb1f689a191"), "https://www.championat.com/news/1.html?utm_source=button&utm_medium=news", "//a[contains(@href, 'news-') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("4adf62bb-0923-48f3-ad0c-cc52b22f86c2") },
                    { new Guid("f85a99a9-0a0d-4e7a-beb3-e0de18001e16"), "https://iz.ru/news/", "//a[contains(@href, '?main_click')]/@href", new Guid("e83b5985-3a5e-4e67-80bc-f61a69e7dedc") }
                });

            migrationBuilder.InsertData(
                table: "news_source_logos",
                columns: new[] { "id", "original", "small", "source_id" },
                values: new object[,]
                {
                    { new Guid("0909e715-6b98-465c-9633-e9037046736b"), "https://st.championat.com/i/favicon/apple-touch-icon.png", "https://st.championat.com/i/favicon/favicon-32x32.png", new Guid("4adf62bb-0923-48f3-ad0c-cc52b22f86c2") },
                    { new Guid("0bac30ec-8a9d-445f-b409-39197b09e90c"), "https://www.pravda.ru/pix/apple-touch-icon.png", "https://www.pravda.ru/favicon.ico", new Guid("47766571-2bd4-4cff-ae7f-fb1a4442f7b5") },
                    { new Guid("188d7933-1433-4843-b199-c53081b18b20"), "https://svpressa.ru/favicon-96x96.png?v=1471426270000", "https://svpressa.ru/favicon-32x32.png?v=1471426270000", new Guid("3434406f-ba29-4624-a326-61359ff796bd") },
                    { new Guid("1bdac472-2d28-4a42-a761-65e4c5b42298"), "https://7days.ru/android-icon-192x192.png", "https://7days.ru/favicon-32x32.png", new Guid("d35440ac-a44b-48d6-93ed-ef53ac59d22d") },
                    { new Guid("1e67d773-5581-420f-b33b-a309e744ccdc"), "https://tass.ru/favicon/180.svg", "https://tass.ru/favicon/57.png", new Guid("971ca435-dd43-4863-9ff3-010b0bf23917") },
                    { new Guid("2160d172-5e8b-45da-a702-2ced3e71c8a2"), "https://cdnn21.img.ria.ru/i/favicons/favicon.svg", "https://cdnn21.img.ria.ru/i/favicons/favicon.ico", new Guid("282139c4-4ee1-434f-a07d-3b782b869a4e") },
                    { new Guid("26160952-1f9b-4a48-9769-b2f722e9ac67"), "https://s01.stc.yc.kpcdn.net/s0/2.1.321/adaptive/favicon-128.png", "https://s01.stc.yc.kpcdn.net/s0/2.1.321/adaptive/favicon-32.png", new Guid("ed90f75a-64a2-4fc7-9513-03cac1685f3c") },
                    { new Guid("2eb6b3a0-59bf-4477-b3cb-d0a2472a706a"), "https://3dnews.ru/assets/images/3dnews_logo_soc.png", "https://3dnews.ru/assets/3dnews_logo_color.png", new Guid("b93a580a-6907-4ad6-9b24-ffe79a121058") },
                    { new Guid("2fc29ef9-610b-4bb8-b2dc-cc0a86b2a4d3"), "https://www.belta.by/images/storage/banners/000016_a133e848cb2e7b1debb7102d19e4d139_work.svg", "https://www.belta.by/images/storage/banners/000016_a133e848cb2e7b1debb7102d19e4d139_work.svg", new Guid("f046c8d9-135a-45f5-a8b0-7c9174833c94") },
                    { new Guid("32f8abd0-9781-4525-9bca-976fbd243fda"), "https://life.ru/appletouch/apple-icon-180%D1%85180.png", "https://life.ru/favicon-32%D1%8532.png", new Guid("0c84be0b-ff10-4c02-b21a-a9cf448b3231") },
                    { new Guid("38c81fff-afbd-4fe2-b1c4-ad168b3b818e"), "https://www.cybersport.ru/favicon-192x192.png", "https://www.cybersport.ru/favicon-32x32.png", new Guid("3db88fea-a678-463c-b933-571deac480ae") },
                    { new Guid("3ab98557-1e28-4a21-b76b-6666d7bca6bc"), "https://icdn.lenta.ru/images/icons/icon-256x256.png", "https://icdn.lenta.ru/favicon.ico", new Guid("c3ae47f1-2820-41f8-823c-3eb227768ea1") },
                    { new Guid("4500fd3f-1ea0-452c-8748-5331a86dd317"), "https://www.zr.ru/favicons/safari-pinned-tab.svg", "https://www.zr.ru/favicons/favicon.ico", new Guid("57b1778d-afe4-4b0c-ba92-caa714f788a6") },
                    { new Guid("5085e577-042a-4c5b-9f60-d22a9949ce68"), "https://im.kommersant.ru/ContentFlex/images/favicons2020/apple-touch-icon-180.png", "https://im.kommersant.ru/ContentFlex/images/favicons2020/favicon-32.png", new Guid("554d00bd-e971-46ed-93b7-4f6734154885") },
                    { new Guid("55c52f05-bde0-4d95-9f2c-d0dd0d99fb34"), "https://overclockers.ru/assets/apple-touch-icon-120x120.png", "https://overclockers.ru/assets/apple-touch-icon.png", new Guid("f605fece-3480-4543-9734-abfc18fb2da0") },
                    { new Guid("5d6d080a-816c-4261-9ad5-ca988a6b6861"), "https://s.rbk.ru/v10_rbcnews_static/common/common-10.10.120/images/android-chrome-512x512.png", "https://s.rbk.ru/v10_rbcnews_static/common/common-10.10.120/images/favicon.png", new Guid("a831084a-eb27-4de8-aa96-4a50525a4819") },
                    { new Guid("5de6a8a8-fdc9-4d7f-8f7a-0911cb2a8bc0"), "https://ura.news/apple-touch-icon.png", "https://s.ura.news/favicon.ico?3", new Guid("23b94c0b-2e91-4691-bf9b-0eb592952a15") },
                    { new Guid("652777c3-cc0e-4cc6-8e29-174e7e01c947"), "https://cdn.hsmedia.ru/public/favicon/starhit/apple-touch-icon.png", "https://cdn.hsmedia.ru/public/favicon/starhit/favicon.png", new Guid("892afab0-a880-457c-9e0b-741ee25a4468") },
                    { new Guid("707babd1-ad2d-41d6-8b71-2c7b00d5cff3"), "https://static.ngs.ru/jtnews/dist/static/favicons/apple/apple-favicon-74-180.png", "https://static.ngs.ru/jtnews/dist/static/favicons/favicon-rugion-32.ico", new Guid("f025cee2-bad5-48fd-b09b-eb5314bd86dd") },
                    { new Guid("80bc44fb-5744-4723-a739-c5ddd94e0860"), "https://edition.cnn.com/media/sites/cnn/apple-touch-icon.png", "https://edition.cnn.com/media/sites/cnn/favicon.ico", new Guid("1522ea71-31d5-44b8-ade3-d17737c4a59a") },
                    { new Guid("81a15271-1e3a-4e43-9ee1-acef72024aae"), "https://www.m24.ru/img/fav/apple-touch-icon.png", "https://www.m24.ru/img/fav/favicon-32x32.png", new Guid("d0c9c267-e4b1-478a-a22e-cc5918e29e09") },
                    { new Guid("9227b2c7-174a-4f8e-81c9-d35fccf28c54"), "https://russian.rt.com/static/blocks/touch-icon/apple-touch-icon-144x144-precomposed.png", "https://russian.rt.com/favicon.ico", new Guid("311b1e93-ca44-4578-980b-dc520d986aef") },
                    { new Guid("92773d04-a2ab-4450-a69e-c0134253d2e8"), "https://stopgame.ru/favicon_512.png", "https://stopgame.ru/favicon.ico", new Guid("eb71a9e0-8d8b-4812-aae7-edd0a82c1e22") },
                    { new Guid("99028094-1090-4ca5-8e66-ce7cfa98b16a"), "https://cdn.iz.ru/profiles/portal/themes/purple/images/favicons/android-icon-192x192.png", "https://cdn.iz.ru/profiles/portal/themes/purple/images/favicons/favicon-32x32.png", new Guid("e83b5985-3a5e-4e67-80bc-f61a69e7dedc") },
                    { new Guid("a7ba9b03-041b-4d0e-adbf-7df000825e69"), "https://www.hltv.org/img/static/favicon/apple-touch-icon.png", "https://www.hltv.org/img/static/favicon/favicon-32x32.png", new Guid("59152ee7-f743-4410-a51f-c2ca010c6d08") },
                    { new Guid("ac3a7662-975b-407e-a8b9-0ea4391cc4da"), "https://www.avtovzglyad.ru/static/images/favicon/safari-pinned-tab.svg", "https://www.avtovzglyad.ru/static/images/favicon/favicon-32x32.png", new Guid("08c00b76-e6e7-4bdd-b5c6-39cf1fc5e620") },
                    { new Guid("b2a97b17-bdf4-4d66-a1eb-88f1b77dc83f"), "https://www.ixbt.com/favicon.ico", "https://www.ixbt.com/favicon.ico", new Guid("ffa8cbf6-240f-4eca-99e5-00eff2902b3c") },
                    { new Guid("b3380748-0a9f-4e31-b5b6-538b7bf8b4f3"), "https://www.sports.ru/apple-touch-icon-1024.png", "https://www.sports.ru/apple-touch-icon-76.png", new Guid("2b4bb14a-7c9c-45db-aaf1-04eed2635410") },
                    { new Guid("b960ee94-2435-42d6-93ad-34d029433138"), "https://aif.ru/img/icon/apple-touch-icon.png?44f", "https://aif.ru/img/icon/favicon-32x32.png?44f", new Guid("a45f190a-a426-4eb9-af21-ed86d6a3adfc") },
                    { new Guid("c6c74d1e-1f9f-49ee-8147-59d32d2bcc6d"), "https://vz.ru/apple-touch-icon.png", "https://vz.ru/static/images/favicon.ico", new Guid("3d026519-7eff-402d-9647-f3781b093d99") },
                    { new Guid("c970ca99-b1c8-47be-b182-7f21bb731418"), "https://www.interfax.ru/touch-icon-ipad-retina.png", "https://www.interfax.ru/touch-icon-iphone.png", new Guid("f9ba04c2-2754-45c9-b6b5-336f2a317ee4") },
                    { new Guid("cccccf5b-15c8-4b18-afc5-2024df0a193c"), "https://www.kinonews.ru/favicon.ico", "https://www.kinonews.ru/favicon.ico", new Guid("e963a900-bdd8-4c5f-a752-55b2dbcafc5b") },
                    { new Guid("cd09a592-dd0b-4466-9527-611b7697a4cc"), "https://www.nytimes.com/vi-assets/static-assets/apple-touch-icon-28865b72953380a40aa43318108876cb.png", "https://www.nytimes.com/vi-assets/static-assets/ios-default-homescreen-57x57-dark-b395ebcad5b63aff9285aab58e31035e.png", new Guid("d984d8f6-19d9-4e4c-a4a7-c1ae08c18846") },
                    { new Guid("d194d57f-4172-4de0-b544-32f76a917871"), "https://www.1obl.ru/apple-touch-icon.png", "https://www.1obl.ru/favicon-32x32.png", new Guid("3ae55f16-0cd5-4486-a8ca-00ab4af26558") },
                    { new Guid("d726bf8f-7693-4931-9d3c-938223db6e14"), "https://ixbt.games/images/favicon/gt/apple-touch-icon.png", "https://ixbt.games/images/favicon/gt/apple-touch-icon.png", new Guid("0e1aa03f-ef5b-4b40-aaf1-360edc088e01") },
                    { new Guid("e208e14e-c07a-41d7-a34e-bf2865bdac4c"), "https://tsargrad.tv/favicons/apple-touch-icon-180x180.png?s2", "https://tsargrad.tv/favicons/favicon-32x32.png?s2", new Guid("b1cb3540-817d-4276-b32e-68af1a12c4b3") },
                    { new Guid("e2b423e1-5d7e-40bb-92bf-9f9df57964fc"), "https://cdnstatic.rg.ru/images/touch-icon-ipad-retina_512x512.png", "https://rg.ru/favicon.ico", new Guid("8b6381a4-2b50-4841-a981-175c4e1beb7e") },
                    { new Guid("fc60cc37-92e6-4d71-bbb7-3da7a8de3e01"), "https://static.gazeta.ru/nm2021/img/icons/favicon.svg", "https://static.gazeta.ru/nm2021/img/icons/favicon.svg", new Guid("d6389497-b1d1-4ee0-b976-a4ab44330fdd") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_editor_settings",
                columns: new[] { "id", "is_required", "name_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("069fe32e-0a55-449f-9db9-2ecfb3904204"), false, "//span[@itemprop='author']/span[@itemprop='name']/@content", new Guid("10822532-c84b-4cd9-9d47-359d66928bb8") },
                    { new Guid("0c83d161-7289-4b24-a4c9-a7ff89145604"), false, "//meta[@name='author']/@content", new Guid("c0383ccc-97df-4d77-befd-f457aaa4cfca") },
                    { new Guid("0e95f398-0a64-4198-997e-5a86f9369a15"), false, "//p[@class='doc__text document_authors']/text()", new Guid("fd2aace8-0740-4ccf-b990-09f1dad45f0c") },
                    { new Guid("0f1e8545-918c-4f19-b90b-c2a7c31c5f5c"), false, "//footer[@class='news-item__footer']/div[@class='news-item__footer-after-news']/p[position()=1]//span/text()", new Guid("a02a3dfd-d4ac-46c4-ba6e-70dfd1985d83") },
                    { new Guid("0f2cd9b4-a19b-49aa-956d-0f0736df15e0"), false, "//meta[@name='author']/@content", new Guid("98babc23-2e39-495f-8818-dd2051b9ad56") },
                    { new Guid("12199212-78a9-46fa-b64f-95cf8f851215"), false, "//div[contains(@class, 'styled__StoryInfoAuthors')]/div[contains(@class, 'styled__InfoAuthor')]//span[contains(@class, 'styled__AuthorName')]/text()", new Guid("3c066479-20b7-4bb2-8ea5-b5c3cb41344a") },
                    { new Guid("2069c731-1661-4ac0-be44-90a12de51527"), false, "//article/p[@class='author']/text()", new Guid("10b37602-0255-4c93-bb7e-0b4f3a9507f1") },
                    { new Guid("36e6bd32-0b73-4cbb-9d00-dfde4bd21c0c"), false, "//*[@itemprop='author']/*[@itemprop='name']//text()", new Guid("a3f6077e-808d-41ea-902b-c3ba497bf76c") },
                    { new Guid("4acc9ecb-8f5b-4c69-b50d-89f697e561d7"), false, "//a[@class='article__author']/text()", new Guid("26268bfb-61c1-4f55-871a-6fbb23efb903") },
                    { new Guid("52d3dd42-82d8-4e7f-827b-dda6c52e650a"), false, "//meta[@name='mediator_author']/@content", new Guid("d3c68a73-22f4-4fd5-9000-a6bb360dcdf8") },
                    { new Guid("576c2534-323a-4eab-bf38-d72d6e9412ea"), false, "//meta[@name='author']/@content", new Guid("5ae040e0-9913-44b6-a4d8-afe7a1fbb2c4") },
                    { new Guid("5a351706-b851-44f0-91f3-9dccf8883418"), false, "//section[contains(@class, '_page-section')]//div[contains(@class, '_bottom-info_')]//span[contains(@class, '_user-info__name_')]/text()", new Guid("818c4f01-7173-4b44-93d9-38f8e18ad70e") },
                    { new Guid("5ce9b318-417c-4097-a8d0-c183b9401127"), false, "//article//span[@class='author']/a[@class='authorName']/span/text()", new Guid("0abec58f-9bef-4360-a474-c3fb0d47b0d6") },
                    { new Guid("61b083ed-6840-418a-9c91-a79a9d9f7b7b"), false, "//meta[@property='article:author']/@content", new Guid("ff99e50b-27ac-49b3-8fe8-7d936c486227") },
                    { new Guid("61c40ec2-6aa7-48d2-8bff-9074230587c9"), false, "//div[@class='container-fluid publication-footer']//a[contains(@class, 'text-secondary')]/@title", new Guid("1f805852-e4a1-4923-b2d1-2234162ab732") },
                    { new Guid("74fbb6a3-5bb8-4981-840a-1ef4d0c767aa"), false, "//div[@itemprop='author']//p[@itemprop='name']/text()", new Guid("644827eb-8c66-4937-805e-b33f81a46f8f") },
                    { new Guid("7e8b8940-60d1-481f-a5db-f77f00e6ca68"), false, "//span[@itemprop='name']/a/text()", new Guid("930057a3-2611-48d1-8698-039f0d3148be") },
                    { new Guid("8621808d-b0f1-4634-a2ed-5ff6b6802851"), false, "//meta[@property='article:author']/@content", new Guid("c22cac53-048e-490d-bf13-1cd33cf49a41") },
                    { new Guid("8a57f390-eb3c-4947-b65d-bb098556745d"), false, "//div[@itemprop='author']/span[@itemprop='name']/text()", new Guid("454a5585-4625-4296-b47c-938aeb1e237e") },
                    { new Guid("8b338ab0-43ea-425c-805b-59bd7fa00f18"), false, "//div[contains(@class, 'PageArticleContent_authors')]//a[contains(@class, 'LinksOfAuthor_item')]/text()", new Guid("40acf021-a0d5-45bf-83b0-78edcb1049ab") },
                    { new Guid("9cdef2d1-e5dc-4c94-89e4-f1c0658cca35"), false, "//span[@class='author']/a/text()", new Guid("3ee8abe2-e64d-4add-9537-ca788b9e4304") },
                    { new Guid("aaec74cc-c451-41b2-8a01-73458f5c7981"), false, "//div[@class='article_top']//div[@class='authors']//div[@class='autor']//span/text()", new Guid("5dc7511d-9b88-4aed-b2a7-5264e6c3f0db") },
                    { new Guid("ac7b83e8-1676-47cd-aa96-efbb98eaabbc"), false, "//div[contains(@class, 'styles_bodyWrapper')]//div[contains(@class, 'styles_authorsLinks')]/a/text()", new Guid("04e4d3d6-edce-41d3-80b6-6594ba543493") },
                    { new Guid("b66fe045-5b83-4610-99ff-4f11cdee34aa"), false, "//meta[@property='article:author']/@content", new Guid("ef8be70e-2690-4f1b-b288-fb38d4401eb8") },
                    { new Guid("b7393a6a-0d84-4c3f-98d5-08bfece97f9e"), false, "//article//header//div[@class='b-authors']/div[@class='b-author' and position()=1]//text()", new Guid("bbbc3e1f-8636-4a8e-8028-db2809fbc322") },
                    { new Guid("bbc06f81-b82d-4e52-b377-560833f00ecf"), false, "//meta[@name='mediator_author']/@content", new Guid("e1d313bd-7c6e-4ed6-aa7f-825263066cc3") },
                    { new Guid("d1432154-68a5-4dff-a54e-6118431647c6"), false, "//div[@class='author']/span[@itemprop='author']/span[@itemprop='name']/a/text()", new Guid("5dd62ab7-517f-4dc2-b820-5afec397151f") },
                    { new Guid("e09ddab0-2a4b-4d35-94ce-fc5a35fdda58"), false, "//div[@class='preview__author-block']//div[@class='author__about']/a[@itemprop='name']/@content", new Guid("71ba03bb-3895-4392-8240-95602937ad3c") },
                    { new Guid("f1adc8e1-aef4-4685-962d-06cc85076f4d"), false, "//div[@class='article__authors']//*[@class='article__authors__author']/span[@class='article__authors__author__name']/text()", new Guid("bfb1e358-63cf-4783-b50c-6057f6182afd") },
                    { new Guid("f2dd9574-0191-40b9-8615-6662c95f7fe6"), false, "//div[@class='topic-authors']/a[@class='topic-authors__author']/text()", new Guid("e5dbfd3e-0e53-4897-b2fd-60dd4e358080") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_modified_at_settings",
                columns: new[] { "id", "is_required", "modified_at_culture_info", "modified_at_time_zone_info_id", "modified_at_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("18b4f1b5-6433-4a8e-8fe5-60f6d7bb234e"), false, "ru-RU", null, "//meta[@itemprop='dateModified']/@content", new Guid("bfb1e358-63cf-4783-b50c-6057f6182afd") },
                    { new Guid("19bccdd6-272e-4c45-a829-7291e7be5250"), false, "ru-RU", null, "//meta[@itemprop='dateModified']/@content", new Guid("5ae040e0-9913-44b6-a4d8-afe7a1fbb2c4") },
                    { new Guid("21cdfcfd-34c5-4521-b4c5-6bad1eaba480"), false, "ru-RU", null, "//meta[@itemprop='dateModified']/@content", new Guid("a3f6077e-808d-41ea-902b-c3ba497bf76c") },
                    { new Guid("28470237-ec37-4f49-adb2-9ac6f814d6ae"), false, "ru-RU", "Russian Standard Time", "//meta[@itemprop='dateModified']/@content", new Guid("5f44d5e8-eeea-4635-b4de-775525e81fc1") },
                    { new Guid("2d1f4932-c999-41b6-9db7-5e335f31fcdb"), false, "ru-RU", null, "//meta[@property='article:modified_time']/@content", new Guid("26268bfb-61c1-4f55-871a-6fbb23efb903") },
                    { new Guid("33ab759f-0aad-4284-8ff8-810ba0028887"), false, "ru-RU", null, "//meta[@property='article:modified_time']/@content", new Guid("6e95bdee-9ac3-4e97-8098-6cc977c9a1a3") },
                    { new Guid("4220a824-4dc3-4bbe-ab89-c3b138690450"), false, "ru-RU", null, "//meta[@property='article:modified_time']/@content", new Guid("c22cac53-048e-490d-bf13-1cd33cf49a41") },
                    { new Guid("4521dfe1-e258-4c94-8deb-4db9de7c82bc"), false, "en-US", null, "//meta[@property='article:modified_time']/@content", new Guid("c0383ccc-97df-4d77-befd-f457aaa4cfca") },
                    { new Guid("5440d436-9051-4d2a-aa74-00c638a15f5a"), false, "en-US", null, "//meta[@property='article:modified_time']/@content", new Guid("930057a3-2611-48d1-8698-039f0d3148be") },
                    { new Guid("5c956fd5-dcfb-4093-91e0-4987e8bd4e85"), false, "ru-RU", "UTC", "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark_update')]//span[@ca-ts]/text()", new Guid("3996446f-7310-4200-b279-dfe2ab621ffd") },
                    { new Guid("7253b463-d898-4d06-bb67-50bb51324881"), false, "ru-RU", "Russian Standard Time", "//meta[@itemprop='dateModified']/@content", new Guid("0639d907-e065-4e84-9eb8-f4c0815b76d0") },
                    { new Guid("7cbce9e0-e49d-4604-8b95-5439920c8cf6"), false, "ru-RU", null, "//meta[@property='article:modified_time']/@content", new Guid("fd2aace8-0740-4ccf-b990-09f1dad45f0c") },
                    { new Guid("89589911-320a-48ad-a0ab-c350a9b010a4"), false, "ru-RU", "Russian Standard Time", "//meta[@property='article:modified_time']/@content", new Guid("7243dcd7-74e9-4824-b026-617c981e51e5") },
                    { new Guid("a9d07320-fb30-47d3-a3a7-6c0539c20b4d"), false, "ru-RU", "Russian Standard Time", "//meta[@property='article:modified_time']/@content", new Guid("40acf021-a0d5-45bf-83b0-78edcb1049ab") },
                    { new Guid("bd04ef00-bded-488b-be4e-91b4b8dae000"), false, "ru-RU", "Russian Standard Time", "//meta[@property='article:modified_time']/@content", new Guid("d07eb353-fbc5-4fbf-87f6-0a12f2cc7bc6") },
                    { new Guid("c8e2ed1b-41bd-4e0c-969b-18416178ec92"), true, "ru-RU", "Russian Standard Time", "//meta[@property='article:modified_time']/@content", new Guid("d568477b-f295-4e73-96cc-a83f33e247be") },
                    { new Guid("def56141-b0fc-4925-a3c3-9d64fb23f0ea"), false, "ru-RU", null, "//meta[@property='article:modified_time']/@content", new Guid("98babc23-2e39-495f-8818-dd2051b9ad56") },
                    { new Guid("ef202f8f-cf1c-474f-af9d-e5bee1408560"), false, "ru-RU", null, "//meta[@itemprop='dateModified']/@content", new Guid("644827eb-8c66-4937-805e-b33f81a46f8f") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_picture_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("00a6bfdf-fa98-4d46-95f3-ad37986187c3"), false, new Guid("5ae040e0-9913-44b6-a4d8-afe7a1fbb2c4"), "//meta[@property='og:image']/@content" },
                    { new Guid("0d198ea6-45a2-4fad-a315-7066b54dc6ee"), false, new Guid("1f805852-e4a1-4923-b2d1-2234162ab732"), "//meta[@name='og:image']/@content" },
                    { new Guid("0f588a1b-6a7b-4a18-ab3a-9e7f6b406095"), false, new Guid("c22cac53-048e-490d-bf13-1cd33cf49a41"), "//meta[@property='og:image']/@content" },
                    { new Guid("160bace7-80b7-4d56-8c67-033e30addf77"), false, new Guid("10b37602-0255-4c93-bb7e-0b4f3a9507f1"), "//meta[@property='og:image']/@content" },
                    { new Guid("191713b9-2b9f-4610-9759-75c27f451d1b"), false, new Guid("644827eb-8c66-4937-805e-b33f81a46f8f"), "//meta[@property='og:image']/@content" },
                    { new Guid("29a1af9b-0552-4f83-b80c-a1153b7e91f3"), false, new Guid("7243dcd7-74e9-4824-b026-617c981e51e5"), "//meta[@property='og:image']/@content" },
                    { new Guid("2a94f873-6902-469c-8d7a-d21d7a4075a5"), false, new Guid("3ee8abe2-e64d-4add-9537-ca788b9e4304"), "//meta[@property='og:image']/@content" },
                    { new Guid("2bcf7d6e-a211-43cc-a8ca-676bb73a79be"), false, new Guid("d07eb353-fbc5-4fbf-87f6-0a12f2cc7bc6"), "//meta[@property='og:image']/@content" },
                    { new Guid("327f9db3-c67c-4729-bb5c-e52e2040ea18"), false, new Guid("fd2aace8-0740-4ccf-b990-09f1dad45f0c"), "//meta[@property='og:image']/@content" },
                    { new Guid("3766e994-67ee-4343-905d-10eedcd90e81"), false, new Guid("3996446f-7310-4200-b279-dfe2ab621ffd"), "//meta[@property='og:image']/@content" },
                    { new Guid("42425b29-e64c-4f43-932b-af06f900cc74"), false, new Guid("0abec58f-9bef-4360-a474-c3fb0d47b0d6"), "//meta[@property='og:image']/@content" },
                    { new Guid("5cbc1ef7-8ba4-4538-82cd-56277d7269c5"), false, new Guid("2912b538-8919-4f1e-9b88-070cd3f0e005"), "//meta[@property='og:image']/@content" },
                    { new Guid("628ae2c8-6efb-4ba2-92c0-d09ce149075e"), false, new Guid("c0383ccc-97df-4d77-befd-f457aaa4cfca"), "//meta[@property='og:image']/@content" },
                    { new Guid("683b28a2-1b25-4a7a-9a7b-125e789821ac"), false, new Guid("5f44d5e8-eeea-4635-b4de-775525e81fc1"), "//meta[@property='og:image']/@content" },
                    { new Guid("6a2c6198-e605-4b21-b300-b5d2e2e4b6c7"), false, new Guid("bbbc3e1f-8636-4a8e-8028-db2809fbc322"), "//meta[@property='og:image']/@content" },
                    { new Guid("6dcaf3f4-b218-4c89-a05d-22afc12ae8cb"), false, new Guid("ff99e50b-27ac-49b3-8fe8-7d936c486227"), "//meta[@property='og:image']/@content" },
                    { new Guid("6fff7298-592d-4a0d-a297-b133de6d399e"), false, new Guid("a02a3dfd-d4ac-46c4-ba6e-70dfd1985d83"), "//meta[@property='og:image']/@content" },
                    { new Guid("706dd3fe-3379-490f-9a18-54c22744650f"), false, new Guid("5dc7511d-9b88-4aed-b2a7-5264e6c3f0db"), "//meta[@property='og:image']/@content" },
                    { new Guid("833c1922-0d88-488f-961c-bb0b6f26fdf1"), false, new Guid("d3c68a73-22f4-4fd5-9000-a6bb360dcdf8"), "//meta[@property='og:image']/@content" },
                    { new Guid("8533afbf-f58c-48b2-9c4e-9d7e461eb58c"), false, new Guid("98babc23-2e39-495f-8818-dd2051b9ad56"), "//meta[@property='og:image']/@content" },
                    { new Guid("876dcf94-0845-47d4-b905-4f6ea8272ba7"), false, new Guid("5dd62ab7-517f-4dc2-b820-5afec397151f"), "//meta[@property='og:image']/@content" },
                    { new Guid("98b51d3d-5d79-4f98-93c4-596e3658f723"), false, new Guid("bfb1e358-63cf-4783-b50c-6057f6182afd"), "//meta[@itemprop='url']/@content" },
                    { new Guid("98c68b24-2094-4c93-ba50-7dc9fea3b329"), false, new Guid("3c066479-20b7-4bb2-8ea5-b5c3cb41344a"), "//meta[@name='og:image']/@content" },
                    { new Guid("998eb7ee-aa5c-4fec-91f9-8c761e2a6531"), false, new Guid("818c4f01-7173-4b44-93d9-38f8e18ad70e"), "//meta[@property='og:image']/@content" },
                    { new Guid("9fa875ec-62a9-4594-883e-ca206d4db569"), false, new Guid("a3f6077e-808d-41ea-902b-c3ba497bf76c"), "//meta[@property='og:image']/@content" },
                    { new Guid("a08996cb-cb77-43bd-bb1c-9a09bf50fa05"), false, new Guid("d568477b-f295-4e73-96cc-a83f33e247be"), "//meta[@property='og:image']/@content" },
                    { new Guid("a9d84f7e-90f1-48f5-ae16-cdf5b4f51b9b"), false, new Guid("04e4d3d6-edce-41d3-80b6-6594ba543493"), "//meta[@property='og:image']/@content" },
                    { new Guid("ba24ba33-d6c8-403d-a24e-c5cf78e122a5"), false, new Guid("930057a3-2611-48d1-8698-039f0d3148be"), "//meta[@property='og:image']/@content" },
                    { new Guid("c084b89a-bf20-4fe0-a9ab-1788756a5b6e"), false, new Guid("40acf021-a0d5-45bf-83b0-78edcb1049ab"), "//meta[@property='og:image']/@content" },
                    { new Guid("cefb9ec7-cf74-47d0-accf-bd59ea2f919c"), false, new Guid("e5dbfd3e-0e53-4897-b2fd-60dd4e358080"), "//meta[@property='og:image']/@content" },
                    { new Guid("d1d68748-e14e-4d13-9728-87245fc3cda4"), false, new Guid("10822532-c84b-4cd9-9d47-359d66928bb8"), "//meta[@property='og:image']/@content" },
                    { new Guid("d4a94452-b131-416f-8108-d6b2752061ce"), false, new Guid("71ba03bb-3895-4392-8240-95602937ad3c"), "//meta[@property='og:image']/@content" },
                    { new Guid("d5498b01-eb34-45b6-a79e-6e3cd7096a3d"), false, new Guid("0639d907-e065-4e84-9eb8-f4c0815b76d0"), "//meta[@property='og:image']/@content" },
                    { new Guid("d718060d-71a0-4e92-a24f-cb5ed0609a23"), false, new Guid("26268bfb-61c1-4f55-871a-6fbb23efb903"), "//meta[@property='og:image']/@content" },
                    { new Guid("e04c40d0-62dc-4371-97b0-72a2a37145c2"), false, new Guid("6e95bdee-9ac3-4e97-8098-6cc977c9a1a3"), "//meta[@property='og:image']/@content" },
                    { new Guid("e424b4c6-cdbb-48c2-8b44-953051a7d544"), false, new Guid("ef8be70e-2690-4f1b-b288-fb38d4401eb8"), "//meta[@property='og:image']/@content" },
                    { new Guid("e946a28e-8cae-429b-9c86-c5642b97cbda"), false, new Guid("454a5585-4625-4296-b47c-938aeb1e237e"), "//meta[@property='og:image']/@content" },
                    { new Guid("e94f03ae-9978-44aa-80a7-84b23d015bfd"), false, new Guid("e1d313bd-7c6e-4ed6-aa7f-825263066cc3"), "//meta[@property='og:image']/@content" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "published_at_culture_info", "published_at_time_zone_info_id", "published_at_x_path" },
                values: new object[,]
                {
                    { new Guid("06763b65-9e19-4cf8-b09a-9fe38ce6b1aa"), true, new Guid("c22cac53-048e-490d-bf13-1cd33cf49a41"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("08658e4c-5da0-4914-ba29-1ad9bb2ce687"), true, new Guid("5dd62ab7-517f-4dc2-b820-5afec397151f"), "ru-RU", null, "//meta[@itemprop='dateModified']/@content" },
                    { new Guid("0a566073-0919-4207-ac9b-30734b248b6a"), true, new Guid("d568477b-f295-4e73-96cc-a83f33e247be"), "ru-RU", "Russian Standard Time", "//meta[@property='article:published_time']/@content" },
                    { new Guid("0dfd4862-4fa2-44f5-be26-4ccf854763b9"), true, new Guid("e1d313bd-7c6e-4ed6-aa7f-825263066cc3"), "ru-RU", null, "//meta[@name='mediator_published_time']/@content" },
                    { new Guid("13ae2cff-f7e7-49bc-8d3f-7309053921e2"), true, new Guid("5dc7511d-9b88-4aed-b2a7-5264e6c3f0db"), "ru-RU", "Russian Standard Time", "//div[@class='article_top']//div[@class='date']//time/text()" },
                    { new Guid("1d5d484e-51ca-490c-b689-f042e40202a6"), true, new Guid("10822532-c84b-4cd9-9d47-359d66928bb8"), "ru-RU", "Russian Standard Time", "//div[@class='b-article__top-author']/p[@class='date']/text()" },
                    { new Guid("2451f613-aa58-420f-b552-f067122dab2d"), true, new Guid("644827eb-8c66-4937-805e-b33f81a46f8f"), "ru-RU", null, "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("37254915-954e-4d11-8aad-3c535b4eef3d"), true, new Guid("a02a3dfd-d4ac-46c4-ba6e-70dfd1985d83"), "ru-RU", null, "//header[@class='news-item__header']//time/@content" },
                    { new Guid("3e724008-22d0-4904-9f50-2149e9c467bf"), true, new Guid("3996446f-7310-4200-b279-dfe2ab621ffd"), "ru-RU", "UTC", "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark')]//span[@ca-ts]/text()" },
                    { new Guid("3f099fa1-c8e3-46c1-9227-ff8d30760906"), true, new Guid("bbbc3e1f-8636-4a8e-8028-db2809fbc322"), "ru-RU", "Russian Standard Time", "//div[@class='b-text__date']/text()" },
                    { new Guid("4381098e-25aa-4f0e-a57f-a6db730d9ecf"), true, new Guid("d07eb353-fbc5-4fbf-87f6-0a12f2cc7bc6"), "ru-RU", "Russian Standard Time", "//meta[@property='article:published_time']/@content" },
                    { new Guid("4842b695-2bf7-4963-a55d-74b2c57839b3"), true, new Guid("40acf021-a0d5-45bf-83b0-78edcb1049ab"), "ru-RU", "Russian Standard Time", "//meta[@property='article:published_time']/@content" },
                    { new Guid("5130b348-db31-4933-8617-25c2bd43260e"), true, new Guid("e5dbfd3e-0e53-4897-b2fd-60dd4e358080"), "ru-RU", "Russian Standard Time", "//div[@class='topic-page__header']//a[contains(@class, 'topic-header__time')]/text()" },
                    { new Guid("5e76d007-ff16-4e2f-a2ce-9a6e6538da7f"), true, new Guid("5ae040e0-9913-44b6-a4d8-afe7a1fbb2c4"), "ru-RU", null, "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("5f758a31-fc83-44a9-96b7-a13303fea4b4"), true, new Guid("98babc23-2e39-495f-8818-dd2051b9ad56"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("713325ae-059e-45c4-9413-0c79b4b5530c"), true, new Guid("04e4d3d6-edce-41d3-80b6-6594ba543493"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("79e01bdc-d942-4d82-a8b6-422a2a90c548"), true, new Guid("d3c68a73-22f4-4fd5-9000-a6bb360dcdf8"), "ru-RU", null, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']/span[@itemprop='datePublished']/@content" },
                    { new Guid("854d602d-e9ba-4279-a57c-547fd486ca60"), true, new Guid("fd2aace8-0740-4ccf-b990-09f1dad45f0c"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("8f47d604-45a9-4b09-a1ed-a46909a7e452"), true, new Guid("ef8be70e-2690-4f1b-b288-fb38d4401eb8"), "ru-RU", "Russian Standard Time", "//article//header//time[@class='article-head__date']/text()" },
                    { new Guid("8fa9c9f8-5e68-42a9-bd82-d35a2d7e6099"), true, new Guid("ff99e50b-27ac-49b3-8fe8-7d936c486227"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("9015544d-abed-4a72-9f1b-b0627963c828"), true, new Guid("a3f6077e-808d-41ea-902b-c3ba497bf76c"), "ru-RU", null, "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("9bf1aa61-7cf7-4516-9c68-23be901655d0"), true, new Guid("26268bfb-61c1-4f55-871a-6fbb23efb903"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("9d3dc0b8-497d-4d8e-8358-b0b465c7dc0a"), true, new Guid("10b37602-0255-4c93-bb7e-0b4f3a9507f1"), "ru-RU", "Russian Standard Time", "//article/div[@class='header']/span/text()" },
                    { new Guid("a5b5a345-7451-4bae-9435-a0fcc7fa0391"), true, new Guid("c0383ccc-97df-4d77-befd-f457aaa4cfca"), "en-US", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("a70ff055-1da1-476a-8b1a-861dfc33f17e"), true, new Guid("930057a3-2611-48d1-8698-039f0d3148be"), "en-US", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("a8f77c22-617f-4c85-9f22-c47ed399ee01"), true, new Guid("6e95bdee-9ac3-4e97-8098-6cc977c9a1a3"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("b063c4de-3e4a-4d19-a9a9-042c63e41a73"), true, new Guid("5f44d5e8-eeea-4635-b4de-775525e81fc1"), "ru-RU", "Russian Standard Time", "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("b82a7632-ab80-491c-8ac5-bfd4c7c25efe"), true, new Guid("0639d907-e065-4e84-9eb8-f4c0815b76d0"), "ru-RU", "Russian Standard Time", "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("bbbb561d-dc10-4d2c-81f4-af29797934ee"), true, new Guid("bfb1e358-63cf-4783-b50c-6057f6182afd"), "ru-RU", null, "//div[@class='article__header__info-block']/time[@class='article__header__date']/@datetime" },
                    { new Guid("be988bdb-e984-40de-8138-c2893b469dab"), true, new Guid("2912b538-8919-4f1e-9b88-070cd3f0e005"), "ru-RU", "Russian Standard Time", "//p[@class='b-material__date']/text()" },
                    { new Guid("bfbd6c7c-d74a-4c0c-b747-4a0e5d594b99"), true, new Guid("454a5585-4625-4296-b47c-938aeb1e237e"), "ru-RU", null, "//div[@class='publication-info']/time[@itemprop='datePublished']/@datetime" },
                    { new Guid("c166ab4f-a20a-4a4e-82d4-8d272d9aebea"), false, new Guid("1f805852-e4a1-4923-b2d1-2234162ab732"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'pubdatetime')]/text()" },
                    { new Guid("c1c3d74b-e4c3-4cb1-a01b-6f7ba88e32be"), true, new Guid("3ee8abe2-e64d-4add-9537-ca788b9e4304"), "ru-RU", "Russian Standard Time", "//span[@class='date']/time/@datetime" },
                    { new Guid("cb5a909a-663a-498c-895b-0ddd045bce1f"), true, new Guid("0abec58f-9bef-4360-a474-c3fb0d47b0d6"), "en-US", "Central Europe Standard Time", "//article//div[@class='article-info']/div[@class='date']/text()" },
                    { new Guid("d59966fc-e272-497c-9172-ab547a8442d9"), true, new Guid("7243dcd7-74e9-4824-b026-617c981e51e5"), "ru-RU", "Russian Standard Time", "//meta[@property='article:published_time']/@content" },
                    { new Guid("de09a202-a067-447e-acdd-b4f8c8380f05"), true, new Guid("71ba03bb-3895-4392-8240-95602937ad3c"), "ru-RU", "Russian Standard Time", "//div[@class='article-details']/span[@class='article-details__time']/time/@datetime" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_sub_title_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("05782b6a-3c7f-40ee-8956-b82b2faa937a"), false, new Guid("98babc23-2e39-495f-8818-dd2051b9ad56"), "//meta[@name='description']/@content" },
                    { new Guid("0907a82b-a852-4cfa-9d44-e206266229b4"), false, new Guid("10822532-c84b-4cd9-9d47-359d66928bb8"), "//meta[@property='og:description']/@content" },
                    { new Guid("09a2f71a-af26-4e45-8f2d-133c72a41960"), false, new Guid("930057a3-2611-48d1-8698-039f0d3148be"), "//meta[@property='og:description']/@content" },
                    { new Guid("20b62cc6-2791-4ce4-ad83-0cd998ec98fd"), false, new Guid("c0383ccc-97df-4d77-befd-f457aaa4cfca"), "//meta[@name='description']/@content" },
                    { new Guid("21b3ecb6-66aa-4851-b056-e8a81b97238f"), false, new Guid("04e4d3d6-edce-41d3-80b6-6594ba543493"), "//meta[@property='og:description']/@content" },
                    { new Guid("32cb3ef9-ab83-4e54-8a55-b6daa0e2f490"), false, new Guid("e5dbfd3e-0e53-4897-b2fd-60dd4e358080"), "//meta[@property='og:description']/@content" },
                    { new Guid("340ae75a-5a69-4fdb-8688-95f7dfa28c47"), false, new Guid("0abec58f-9bef-4360-a474-c3fb0d47b0d6"), "//meta[@property='og:description']/@content" },
                    { new Guid("3adcddc0-7b2f-405a-ba1b-1f8c7ff55896"), false, new Guid("a02a3dfd-d4ac-46c4-ba6e-70dfd1985d83"), "//meta[@property='og:description']/@content" },
                    { new Guid("42eead83-13d0-40e2-a9d0-1311cda54c60"), false, new Guid("40acf021-a0d5-45bf-83b0-78edcb1049ab"), "//meta[@property='og:description']/@content" },
                    { new Guid("4f954690-a171-49ff-9899-0d834c264077"), false, new Guid("454a5585-4625-4296-b47c-938aeb1e237e"), "//meta[@itemprop='description']/@content" },
                    { new Guid("544b76c9-c365-4f7c-b2e9-2a920eacf625"), false, new Guid("fd2aace8-0740-4ccf-b990-09f1dad45f0c"), "//meta[@name='description']/@content" },
                    { new Guid("55b22c6a-ad89-4f46-ab6b-6c3011eb824b"), false, new Guid("0639d907-e065-4e84-9eb8-f4c0815b76d0"), "//meta[@property='og:description']/@content" },
                    { new Guid("5892ae47-c5f5-4af6-bb97-077bbccbf859"), false, new Guid("bbbc3e1f-8636-4a8e-8028-db2809fbc322"), "//meta[@property='og:description']/@content" },
                    { new Guid("6c5d8378-a3f2-4ec2-ac30-e073e3258882"), false, new Guid("bfb1e358-63cf-4783-b50c-6057f6182afd"), "//meta[@property='og:description']/@content" },
                    { new Guid("743d775e-2246-46ff-8220-0f8af310bba1"), false, new Guid("5dc7511d-9b88-4aed-b2a7-5264e6c3f0db"), "//meta[@property='og:description']/@content" },
                    { new Guid("778fc460-b661-4552-a3ca-ef03a51c487b"), false, new Guid("e1d313bd-7c6e-4ed6-aa7f-825263066cc3"), "//meta[@property='og:description']/@content" },
                    { new Guid("8450cb4b-ec4a-42b8-8c90-490a8c81e690"), false, new Guid("ef8be70e-2690-4f1b-b288-fb38d4401eb8"), "//meta[@property='og:description']/@content" },
                    { new Guid("8e190b83-7f47-4542-8647-3f99dba7be1d"), false, new Guid("5ae040e0-9913-44b6-a4d8-afe7a1fbb2c4"), "//p[contains(@itemprop, 'alternativeHeadline')]/text()" },
                    { new Guid("93b2961e-b639-4c1f-a2c9-7917fb67d3f8"), false, new Guid("3c066479-20b7-4bb2-8ea5-b5c3cb41344a"), "//div[contains(@class, 'styled__StoryBody')]/p[contains(@class, 'styled__StoryParagraph') and position()=1]/text()" },
                    { new Guid("946d704d-0603-4e50-95b1-104ae5db5ca9"), false, new Guid("d07eb353-fbc5-4fbf-87f6-0a12f2cc7bc6"), "//meta[@property='og:description']/@content" },
                    { new Guid("97f426ec-217b-49f4-9e91-6327920cf080"), false, new Guid("c22cac53-048e-490d-bf13-1cd33cf49a41"), "//meta[@property='og:description']/@content" },
                    { new Guid("9dbfccf0-281c-4c73-827c-1e8e2efbbd1f"), false, new Guid("818c4f01-7173-4b44-93d9-38f8e18ad70e"), "//meta[@property='og:description']/@content" },
                    { new Guid("a38db77b-eae3-4d23-adb6-e9f95169498a"), false, new Guid("3996446f-7310-4200-b279-dfe2ab621ffd"), "//meta[@property='og:description']/@content" },
                    { new Guid("a6f6b62a-c554-4501-b36b-e8299fb3c5f8"), false, new Guid("d3c68a73-22f4-4fd5-9000-a6bb360dcdf8"), "//meta[@property='og:description']/@content" },
                    { new Guid("aa681d60-b531-42bd-815f-5f0c026879fd"), false, new Guid("3ee8abe2-e64d-4add-9537-ca788b9e4304"), "//meta[@name='description']/@content" },
                    { new Guid("b100a501-b195-4e3a-831d-879193bba5b9"), false, new Guid("1f805852-e4a1-4923-b2d1-2234162ab732"), "//meta[@name='og:description']/@content" },
                    { new Guid("b9487830-3120-4db7-b8de-3d6bebfb0c1e"), false, new Guid("ff99e50b-27ac-49b3-8fe8-7d936c486227"), "//div[@class='block-page-new']/h2/text()" },
                    { new Guid("c2cf6821-4ca4-4b74-8018-a57a85564f14"), false, new Guid("a3f6077e-808d-41ea-902b-c3ba497bf76c"), "//meta[@property='og:description']/@content" },
                    { new Guid("c45115f9-b3f4-4d6d-bfc1-30ec49cb2f26"), false, new Guid("71ba03bb-3895-4392-8240-95602937ad3c"), "//meta[@name='description']/@content" },
                    { new Guid("d3e4c421-4dc9-4aea-97a3-26507c9c3645"), false, new Guid("26268bfb-61c1-4f55-871a-6fbb23efb903"), "//meta[@property='og:description']/@content" },
                    { new Guid("d4e687e5-2aef-440e-917a-b50d204cc2a5"), false, new Guid("10b37602-0255-4c93-bb7e-0b4f3a9507f1"), "//meta[@property='og:description']/@content" },
                    { new Guid("e17d09c2-fdec-4672-a412-ec4f350a3d08"), false, new Guid("5f44d5e8-eeea-4635-b4de-775525e81fc1"), "//meta[@property='og:description']/@content" },
                    { new Guid("e3ee4345-969c-4ab7-87bb-bc14ec2ea93d"), false, new Guid("2912b538-8919-4f1e-9b88-070cd3f0e005"), "//meta[@property='og:description']/@content" },
                    { new Guid("ea781ea6-c6ea-4214-be5c-aff85620bda5"), false, new Guid("d568477b-f295-4e73-96cc-a83f33e247be"), "//meta[@property='og:description']/@content" },
                    { new Guid("edeeb550-0ffb-48ca-858f-a4f1eec20d42"), false, new Guid("644827eb-8c66-4937-805e-b33f81a46f8f"), "//meta[@property='og:description']/@content" },
                    { new Guid("f0265abf-90c9-40bd-99fd-9715200882ab"), false, new Guid("7243dcd7-74e9-4824-b026-617c981e51e5"), "//meta[@property='og:description']/@content" },
                    { new Guid("f61efb70-8edc-4242-871a-efb24995c480"), false, new Guid("6e95bdee-9ac3-4e97-8098-6cc977c9a1a3"), "//meta[@property='og:description']/@content" },
                    { new Guid("fc42329f-1cc9-4b83-b365-d6ceb0bb46a4"), false, new Guid("5dd62ab7-517f-4dc2-b820-5afec397151f"), "//meta[@property='og:description']/@content" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_video_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("2545032f-b3ea-4acf-a1c5-af052e66a12b"), false, new Guid("e5dbfd3e-0e53-4897-b2fd-60dd4e358080"), "//div[contains(@class, 'eagleplayer')]//video/@src" },
                    { new Guid("7a524817-4929-4e17-8dc0-3498c5e6f8c3"), false, new Guid("0abec58f-9bef-4360-a474-c3fb0d47b0d6"), "//article//div[@class='videoWrapper' and @itemprop='video']/iframe[@class='video']/@src" },
                    { new Guid("96aa6867-1ba8-4293-af05-cc4756161bff"), false, new Guid("40acf021-a0d5-45bf-83b0-78edcb1049ab"), "//div[contains(@class, 'PageContentCommonStyling_text')]/rg-video//video/@src" },
                    { new Guid("9c8d3b6a-86f7-431a-aac1-215dd2cc7e97"), false, new Guid("d568477b-f295-4e73-96cc-a83f33e247be"), "//div[@class='article__header']//div[@class='media__video']//video/@src" },
                    { new Guid("cd60efad-db42-4400-b572-6fa808179416"), false, new Guid("26268bfb-61c1-4f55-871a-6fbb23efb903"), "//meta[@property='og:video']/@content" },
                    { new Guid("fbb588dc-6659-4db5-b95c-3cea32a139e1"), false, new Guid("2912b538-8919-4f1e-9b88-070cd3f0e005"), "//meta[@property='og:video:url']/@content" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_modified_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_modified_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("0e47ed7f-fe32-4ff5-8bc3-8f5c9c1c9236"), "\"обновлено\" d MMMM yyyy, HH:mm", new Guid("5c956fd5-dcfb-4093-91e0-4987e8bd4e85") },
                    { new Guid("16ade9c2-ae26-4d61-b097-513c230e2761"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("def56141-b0fc-4925-a3c3-9d64fb23f0ea") },
                    { new Guid("3b40ce1b-8dd2-431a-97f3-52025e511fbc"), "yyyy-MM-ddTHH:mm:ss.fffZ", new Guid("5440d436-9051-4d2a-aa74-00c638a15f5a") },
                    { new Guid("3ef8ddfa-14e1-4108-8282-82e2dd80e9ff"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("7cbce9e0-e49d-4604-8b95-5439920c8cf6") },
                    { new Guid("49b31488-b652-49ed-81d0-d8ac70306c50"), "yyyy-MM-ddTHH:mm:ss", new Guid("28470237-ec37-4f49-adb2-9ac6f814d6ae") },
                    { new Guid("5228044c-a33f-453e-a440-c61a992fe1dc"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("21cdfcfd-34c5-4521-b4c5-6bad1eaba480") },
                    { new Guid("5bc981cd-795c-422b-9df5-6b2a109ee22e"), "yyyy-MM-ddTHH:mm:ss", new Guid("a9d07320-fb30-47d3-a3a7-6c0539c20b4d") },
                    { new Guid("60a2684b-fdd4-410f-bf3f-277decb48a22"), "yyyy-MM-dd", new Guid("7253b463-d898-4d06-bb67-50bb51324881") },
                    { new Guid("6ba47d03-51ae-4d03-b308-fb51693e52d7"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("ef202f8f-cf1c-474f-af9d-e5bee1408560") },
                    { new Guid("6e274a0e-f0a2-406e-969f-48af89d880cb"), "yyyyMMddTHHmm", new Guid("c8e2ed1b-41bd-4e0c-969b-18416178ec92") },
                    { new Guid("8acabb72-4863-4323-bdd9-543b71de5a67"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("4220a824-4dc3-4bbe-ab89-c3b138690450") },
                    { new Guid("8b4ef3f7-e6a3-4dcb-8c25-35f2d6fe1c59"), "yyyy-MM-ddTHH:mm:ss.fff\"Z+0300\"", new Guid("bd04ef00-bded-488b-be4e-91b4b8dae000") },
                    { new Guid("91e710a2-1706-4b00-a43f-16e0cbe6717c"), "yyyy-MM-ddTHH:mmzzz", new Guid("2d1f4932-c999-41b6-9db7-5e335f31fcdb") },
                    { new Guid("bea8aefa-4d76-4880-8570-673597062f31"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("18b4f1b5-6433-4a8e-8fe5-60f6d7bb234e") },
                    { new Guid("c76fa716-5024-4d07-8281-fcbcff849352"), "yyyy-MM-dd HH:mm:ss", new Guid("89589911-320a-48ad-a0ab-c350a9b010a4") },
                    { new Guid("f4a85b5f-4100-46f3-9e98-235af0122661"), "yyyy-MM-ddTHH:mm:ss.fffZ", new Guid("4521dfe1-e258-4c94-8deb-4db9de7c82bc") },
                    { new Guid("f9ba53cd-c6d7-4643-aa3b-d6c4f783e110"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("33ab759f-0aad-4284-8ff8-810ba0028887") },
                    { new Guid("fbcbdfd1-d09a-420d-817f-90d4bea23ff5"), "\"обновлено\" d MMMM, HH:mm", new Guid("5c956fd5-dcfb-4093-91e0-4987e8bd4e85") },
                    { new Guid("fc503beb-b113-4568-8501-e26c09cb2402"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("19bccdd6-272e-4c45-a829-7291e7be5250") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_published_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("0226ddf2-3d0e-4532-9db7-283ae0eac267"), "dd.MM.yyyy HH:mm", new Guid("13ae2cff-f7e7-49bc-8d3f-7309053921e2") },
                    { new Guid("08dfa1ec-5f2f-4629-9eb9-cdd379852ea1"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("37254915-954e-4d11-8aad-3c535b4eef3d") },
                    { new Guid("0a57a345-ceb9-4dc5-84ff-2b6cc897b70a"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("08658e4c-5da0-4914-ba29-1ad9bb2ce687") },
                    { new Guid("1cf0f095-ba05-464d-a7f6-664b600b2580"), "d MMMM, HH:mm", new Guid("3e724008-22d0-4904-9f50-2149e9c467bf") },
                    { new Guid("202c499a-c50c-401a-8008-4f963e6ce266"), "d-M-yyyy HH:mm", new Guid("cb5a909a-663a-498c-895b-0ddd045bce1f") },
                    { new Guid("26e3f222-95e0-44a4-be33-3fc972cf604f"), "yyyy-MM-ddTHH:mm:ss.fff\"Z+0300\"", new Guid("4381098e-25aa-4f0e-a57f-a6db730d9ecf") },
                    { new Guid("2ab25e13-bba4-4981-81aa-05632d99784e"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("bbbb561d-dc10-4d2c-81f4-af29797934ee") },
                    { new Guid("2e0f249b-29dd-429f-aa9a-73f8f4fa33fe"), "yyyyMMddTHHmm", new Guid("0a566073-0919-4207-ac9b-30734b248b6a") },
                    { new Guid("32efba09-ea02-43d7-b319-0d2fed180f95"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("9015544d-abed-4a72-9f1b-b0627963c828") },
                    { new Guid("345d4d60-6aa2-476d-9e55-3ed0b42555ce"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("2451f613-aa58-420f-b552-f067122dab2d") },
                    { new Guid("3620cb00-8906-4601-9020-ce78037c783c"), "yyyy-MM-dd", new Guid("b82a7632-ab80-491c-8ac5-bfd4c7c25efe") },
                    { new Guid("3e1e4474-ddb2-4ab0-96f4-733a60f3464b"), "yyyy-MM-ddTHH:mmzzz", new Guid("9bf1aa61-7cf7-4516-9c68-23be901655d0") },
                    { new Guid("4925cf85-4435-4cb9-a496-7ac7f5e61af5"), "HH:mm, d MMMM yyyy", new Guid("5130b348-db31-4933-8617-25c2bd43260e") },
                    { new Guid("4c7d6fcf-07f5-414f-bae1-10fa5073efba"), "d MMMM yyyy, HH:mm", new Guid("3e724008-22d0-4904-9f50-2149e9c467bf") },
                    { new Guid("4d38d1ad-3c24-4674-9dce-748fa458490f"), "HH:mm", new Guid("be988bdb-e984-40de-8138-c2893b469dab") },
                    { new Guid("574bc350-4c88-4f70-99f2-384d046cbc0b"), "yyyy-MM-ddTHH:mm:ss.fffZ", new Guid("a70ff055-1da1-476a-8b1a-861dfc33f17e") },
                    { new Guid("5971fec4-3fb1-4a58-8adc-99736851cee5"), "d MMMM yyyy, HH:mm,", new Guid("3e724008-22d0-4904-9f50-2149e9c467bf") },
                    { new Guid("6a97d366-d284-4bb7-a4c7-3bb0ea6a90ee"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("79e01bdc-d942-4d82-a8b6-422a2a90c548") },
                    { new Guid("75ec7d19-5293-40e6-bbe8-f49c82834d77"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("854d602d-e9ba-4279-a57c-547fd486ca60") },
                    { new Guid("79e1bf8e-4a26-40fd-a7b2-1a5bed28537a"), "d MMMM yyyy, HH:mm \"МСК\"", new Guid("8f47d604-45a9-4b09-a1ed-a46909a7e452") },
                    { new Guid("871d884a-17b0-41a4-8294-024040bf0808"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("5e76d007-ff16-4e2f-a2ce-9a6e6538da7f") },
                    { new Guid("9417d87c-6c7f-488f-aad0-0bc401252a91"), "dd MMMM, HH:mm", new Guid("be988bdb-e984-40de-8138-c2893b469dab") },
                    { new Guid("9a741f24-5ecd-4f94-9498-6efa45c8e82b"), "d MMMM  HH:mm", new Guid("3f099fa1-c8e3-46c1-9227-ff8d30760906") },
                    { new Guid("9cead0fe-c69d-4841-b8f8-7e31c26d5f30"), "yyyy-MM-dd HH:mm:ss", new Guid("d59966fc-e272-497c-9172-ab547a8442d9") },
                    { new Guid("9d722404-deeb-4502-81d2-a7dbd4441022"), "d MMMM yyyy \"в\" HH:mm", new Guid("1d5d484e-51ca-490c-b689-f042e40202a6") },
                    { new Guid("a11d1891-238e-4182-b222-47107b79a086"), "yyyy-MM-ddTHH:mm:ss.fffZ", new Guid("a8f77c22-617f-4c85-9f22-c47ed399ee01") },
                    { new Guid("b3cfefb7-8415-4766-8b37-f5087b79bca0"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("8fa9c9f8-5e68-42a9-bd82-d35a2d7e6099") },
                    { new Guid("b53558c5-396f-4a80-9ff4-e5520bfef343"), "yyyy-MM-dd HH:mm", new Guid("c1c3d74b-e4c3-4cb1-a01b-6f7ba88e32be") },
                    { new Guid("bec78124-c156-4189-a3c0-2e82c23bf012"), "d MMMM yyyy", new Guid("de09a202-a067-447e-acdd-b4f8c8380f05") },
                    { new Guid("c2d0d0fa-a136-422d-af23-d04e3c32b292"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("5f758a31-fc83-44a9-96b7-a13303fea4b4") },
                    { new Guid("c3a59cb8-f04d-480c-85b1-38c04e0bd43e"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("bfbd6c7c-d74a-4c0c-b747-4a0e5d594b99") },
                    { new Guid("c3a6d78e-e16b-4ad7-9187-e09635d913a4"), "d MMMM, HH:mm,", new Guid("3e724008-22d0-4904-9f50-2149e9c467bf") },
                    { new Guid("c95fc736-dbc9-4bfc-b274-ea505c545b7c"), "yyyy-MM-ddTHH:mm:ss.fffZ", new Guid("a5b5a345-7451-4bae-9435-a0fcc7fa0391") },
                    { new Guid("c9edc1fa-3825-4151-9313-4127d4065a83"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("713325ae-059e-45c4-9413-0c79b4b5530c") },
                    { new Guid("e72e8b66-dfe8-44dc-80be-750f1efedb6e"), "yyyy-MM-ddTHH:mm:ss", new Guid("4842b695-2bf7-4963-a55d-74b2c57839b3") },
                    { new Guid("e91e7b15-33b8-4ffa-bed9-fc86d46acdb9"), "d MMMM yyyy, HH:mm\" •\"", new Guid("9d3dc0b8-497d-4d8e-8358-b0b465c7dc0a") },
                    { new Guid("eb7a1f5c-a7a4-4d15-be3d-fefe615601e2"), "yyyy-MM-dd HH:mm:ss", new Guid("c166ab4f-a20a-4a4e-82d4-8d272d9aebea") },
                    { new Guid("ef2919eb-f404-4a93-80ed-f534131724ec"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("06763b65-9e19-4cf8-b09a-9fe38ce6b1aa") },
                    { new Guid("f162f1fd-2914-4914-b521-dd3d171ddb13"), "d MMMM yyyy HH:mm", new Guid("3f099fa1-c8e3-46c1-9227-ff8d30760906") },
                    { new Guid("f2fefe4f-f37b-438e-bb4d-60208d34e7d5"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("0dfd4862-4fa2-44f5-be26-4ccf854763b9") },
                    { new Guid("fb842535-35f8-430e-a4d0-58a013e88f7b"), "yyyy-MM-ddTHH:mm:ss", new Guid("b063c4de-3e4a-4d19-a9a9-042c63e41a73") },
                    { new Guid("ff596f08-452b-421c-9687-ca93ce4b9b47"), "dd MMMM yyyy, HH:mm", new Guid("be988bdb-e984-40de-8138-c2893b469dab") }
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
