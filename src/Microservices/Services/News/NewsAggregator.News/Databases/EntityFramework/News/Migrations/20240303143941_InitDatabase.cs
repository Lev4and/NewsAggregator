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
                    { new Guid("03e0504c-3c5f-41ae-802e-887cf55014e2"), true, "https://stopgame.ru/", "StopGame" },
                    { new Guid("0715c73c-01b7-45e1-8057-594b3bfbb7f4"), true, "https://www.hltv.org/", "HLTV.org" },
                    { new Guid("109dbed5-5f9f-4368-bbb3-3513567101da"), true, "https://www.belta.by/", "БелТА" },
                    { new Guid("113eb4ca-db6d-4c2c-a0da-d560a69c5b4f"), true, "https://vz.ru/", "ВЗГЛЯД.РУ" },
                    { new Guid("137a0aba-81a1-4944-a586-6c4c6f0cbace"), true, "https://ixbt.games/", "iXBT.games" },
                    { new Guid("2afc1d33-38c6-4044-8f4c-b87b8def4a6c"), true, "https://www.sports.ru/", "Storts.ru" },
                    { new Guid("345b9cf3-36a4-41d7-9799-834730479fe1"), true, "https://www.ixbt.com/", "iXBT.com" },
                    { new Guid("35c3ebda-c896-4b78-8d78-5e1c7f174b54"), true, "https://tass.ru/", "ТАСС" },
                    { new Guid("539cd0d2-548a-4c9e-9024-a0dc4f603beb"), true, "https://russian.rt.com/", "RT на русском" },
                    { new Guid("59c99538-bf67-426b-9c9b-1c6cdf0675ef"), true, "https://rg.ru/", "Российская газета" },
                    { new Guid("5aefe15e-13f9-42f2-b666-9de76bfb9a3d"), true, "https://www.avtovzglyad.ru/", "АвтоВзгляд" },
                    { new Guid("612000dd-d91f-4a31-974c-eaf4bc151ea7"), true, "https://www.nytimes.com/", "The New York Times" },
                    { new Guid("6521d2f1-2119-41e9-b9cd-731654d88622"), true, "https://3dnews.ru/", "3Dnews.ru" },
                    { new Guid("6f177b19-487f-469c-b668-bd6dbcc0ff7a"), true, "https://www.championat.com/", "Чемпионат.com" },
                    { new Guid("738f3cf2-5f85-482e-b79e-c50206c50504"), true, "https://www.cybersport.ru/", "Cybersport.ru" },
                    { new Guid("74c26784-72c3-4686-8d26-0e1b548620f1"), true, "https://www.gazeta.ru/", "Газета.Ru" },
                    { new Guid("86d7016d-6903-4fdf-a71a-ce9f2e297fa1"), true, "https://www.zr.ru/", "Журнал \"За рулем\"" },
                    { new Guid("8d7c6759-f210-4cdf-b801-69a41b67b190"), true, "https://tsargrad.tv/", "Царьград" },
                    { new Guid("8e7d6e12-3aca-4dd2-a4c3-19f1002c0588"), true, "https://www.interfax.ru/", "Интерфакс" },
                    { new Guid("8ed19b05-50df-4aec-9a1e-ad0f2bf5fa4f"), true, "https://life.ru/", "Life" },
                    { new Guid("9f12486c-c88e-4020-9f90-5a5a80f065f6"), true, "https://www.kp.ru/", "Комсомольская правда" },
                    { new Guid("a05c4170-2a7c-4130-95de-e1d52e970cca"), true, "https://www.1obl.ru/", "Первый областной" },
                    { new Guid("a4879b95-08e2-4b49-85f1-ecb4b09a92bb"), true, "https://7days.ru/", "7дней.ru" },
                    { new Guid("a89699ad-a421-4b27-bf26-04ffd6cba1d4"), true, "https://ura.news/", "Ura.ru" },
                    { new Guid("ae22a034-eae7-423b-964b-34b6d3c41410"), true, "https://svpressa.ru/", "СвободнаяПресса" },
                    { new Guid("b0a11ebc-494c-4879-9a27-dd7fe1a90cfc"), true, "https://www.pravda.ru/", "Правда.ру" },
                    { new Guid("b970ebab-83c9-4f19-b020-f4e2e3de6985"), true, "https://lenta.ru/", "Лента.Ру" },
                    { new Guid("c1049e1c-d1e1-4cc5-8632-2f0cd2ee9a1c"), false, "https://www.kinonews.ru/", "KinoNews.ru" },
                    { new Guid("c1f171e6-d940-4019-bed5-d5aa0ae2490b"), true, "https://iz.ru/", "Известия" },
                    { new Guid("ca47e185-546f-458c-bc8d-69ed5c2f19ec"), true, "https://ria.ru/", "РИА Новости" },
                    { new Guid("cb77eeb1-5b65-48d4-9076-f0c64a2b8aca"), true, "https://www.rbc.ru/", "РБК" },
                    { new Guid("cfc561cc-cd66-4dcc-a367-a94252b3b359"), true, "https://www.m24.ru/", "Москва 24" },
                    { new Guid("d13b83ea-d879-4a67-85e9-2446279d1f66"), true, "https://www.kommersant.ru/", "Коммерсантъ" },
                    { new Guid("dc09014f-7a63-48e5-9d37-190a304a724a"), true, "https://www.starhit.ru/", "Сетевое издание «Онлайн журнал StarHit (СтарХит)" },
                    { new Guid("e23f4c50-4a48-4756-9579-4246831c4362"), true, "https://aif.ru/", "Аргументы и факты" },
                    { new Guid("e308bfa8-c0a2-42c0-a13f-5daeb4b8a7d3"), true, "https://74.ru/", "74.ru" },
                    { new Guid("e47d0a10-5bee-4e51-9969-32d9487a369c"), true, "https://overclockers.ru/", "Overclockers" },
                    { new Guid("fceead9c-0ee0-4b42-8735-2aff6a4198d8"), true, "https://edition.cnn.com/", "CNN" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_settings",
                columns: new[] { "id", "html_description_x_path", "source_id", "text_description_x_path", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("00d50317-7614-4523-9bbc-c6a97bb3bbb1"), "//section[@name='articleBody']/*", new Guid("612000dd-d91f-4a31-974c-eaf4bc151ea7"), "//section[@name='articleBody']/*/text()", "//h1/text()" },
                    { new Guid("040999fb-3f16-4a57-9217-7b89997f59e4"), "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]", new Guid("cfc561cc-cd66-4dcc-a367-a94252b3b359"), "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]/text()", "//h1/text()" },
                    { new Guid("0abb675a-61a0-4682-9f08-39713ddf8b43"), "//div[contains(@class, 'material-content')]/*", new Guid("e47d0a10-5bee-4e51-9969-32d9487a369c"), "//div[contains(@class, 'material-content')]/p/text()", "//a[@class='header']/text()" },
                    { new Guid("1c7f13ca-e036-43ba-9e4e-4992d44e9a61"), "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]", new Guid("8e7d6e12-3aca-4dd2-a4c3-19f1002c0588"), "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]/text()", "//h1/text()" },
                    { new Guid("465024e2-0532-42bc-83dd-c4212753187c"), "//div[@itemprop='articleBody']/*", new Guid("74c26784-72c3-4686-8d26-0e1b548620f1"), "//div[@itemprop='articleBody']/*/text()", "//h1/text()" },
                    { new Guid("4aac24ae-1d63-4d1a-aa6f-fb35591b799a"), "//div[contains(@class, 'news-item__content')]", new Guid("2afc1d33-38c6-4044-8f4c-b87b8def4a6c"), "//div[contains(@class, 'news-item__content')]/text()", "//h1/text()" },
                    { new Guid("528fbf2b-a035-44f4-aa9c-571bb448267f"), "//div[@class='js-mediator-article']", new Guid("109dbed5-5f9f-4368-bbb3-3513567101da"), "//div[@class='js-mediator-article']/text()", "//h1/text()" },
                    { new Guid("56cdb823-fe00-463d-af40-e4b8d1556dda"), "//article/div[@class='article-content']/*[not(@class)]", new Guid("6f177b19-487f-469c-b668-bd6dbcc0ff7a"), "//article/div[@class='article-content']/*[not(@class)]/text()", "//article/header/div[@class='article-head__title']/text()" },
                    { new Guid("5d3598b5-03f2-4f41-bc88-89e95a6910d6"), "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]", new Guid("8ed19b05-50df-4aec-9a1e-ad0f2bf5fa4f"), "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]/text()", "//h1/text()" },
                    { new Guid("5f9e04b0-0550-47db-9672-93ed3c893fc1"), "//div[contains(@class, 'container-fluid shifted') and not(p[@class='announce lead']) and not(h1) and not(hr)]", new Guid("137a0aba-81a1-4944-a586-6c4c6f0cbace"), "//div[contains(@class, 'container-fluid shifted') and not(p[@class='announce lead']) and not(h1) and not(hr)]/text()", "//h1/text()" },
                    { new Guid("6ab078e1-7964-41a5-b5e2-248a2aa004ea"), "//div[contains(@class, 'article__text ')]", new Guid("539cd0d2-548a-4c9e-9024-a0dc4f603beb"), "//div[contains(@class, 'article__text ')]/text()", "//h1/text()" },
                    { new Guid("6d632245-8966-4ad8-927b-b70244ba46e3"), "//div[@itemprop='articleBody']/*", new Guid("a05c4170-2a7c-4130-95de-e1d52e970cca"), "//div[@itemprop='articleBody']/*/text()", "//h1[@itemprop='headline']/text()" },
                    { new Guid("6e7f5c2c-e5be-49ec-8daf-cf6c26b96b71"), "//section[contains(@class, '_page-section')]/div[contains(@class, '_content_')]/*", new Guid("03e0504c-3c5f-41ae-802e-887cf55014e2"), "//section[contains(@class, '_page-section')]/div[contains(@class, '_content_')]/*[contains(@class, '_text_')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("7273650f-34a9-4592-8e45-459af7effe55"), "//div[contains(@class, 'PageContentCommonStyling_text')]/*[not(name() = 'rg-video')]", new Guid("59c99538-bf67-426b-9c9b-1c6cdf0675ef"), "//div[contains(@class, 'PageContentCommonStyling_text')]/*[not(name() = 'rg-video')]/text()", "//h1/text()" },
                    { new Guid("78cf22eb-52f9-47e5-9cdf-30e1d3ed4f76"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview'))]", new Guid("cb77eeb1-5b65-48d4-9076-f0c64a2b8aca"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview'))]/text()", "//h1/text()" },
                    { new Guid("79a6a983-d89f-4000-a249-9f9dbebaaa67"), "//div[contains(@class, 'article__body')]", new Guid("ca47e185-546f-458c-bc8d-69ed5c2f19ec"), "//div[contains(@class, 'article__body')]/text()", "//div[@class='article__title']/text()" },
                    { new Guid("7aa662fc-b9e4-4821-9565-38ba9f409944"), "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]", new Guid("ae22a034-eae7-423b-964b-34b6d3c41410"), "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]/text()", "//h1[@class='b-text__title']/text()" },
                    { new Guid("7ed244cb-9d7c-4e16-868b-9370271300aa"), "//div[@itemprop='articleBody']/*[not(name() = 'figure')]", new Guid("e308bfa8-c0a2-42c0-a13f-5daeb4b8a7d3"), "//div[@itemprop='articleBody']/*[not(name() = 'figure')]/text()", "//h1[@itemprop='headline']/span/text()" },
                    { new Guid("7fbd53c6-ab6f-4d0b-87b0-5948449c30ed"), "//div[@class='textart']/div[not(@class)]/*", new Guid("c1049e1c-d1e1-4cc5-8632-2f0cd2ee9a1c"), "//div[@class='textart']/div[not(@class)]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("885bbecf-0f5a-443e-8fbc-870d910c7afd"), "//section[@itemprop='articleBody']/*", new Guid("5aefe15e-13f9-42f2-b666-9de76bfb9a3d"), "//section[@itemprop='articleBody']/*[not(name()='script')]/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("8c01b16a-ed2b-49b6-8a5c-9c351d530606"), "//div[@itemprop='articleBody']/*", new Guid("c1f171e6-d940-4019-bed5-d5aa0ae2490b"), "//div[@itemprop='articleBody']//text()", "//h1/span/text()" },
                    { new Guid("8c88ccc1-ef46-4716-bb83-32e8bcd1db5a"), "//section[@itemprop='articleBody']/div[@class='ds-article-content-block-and-creative-container']/*[not(name()='div' and contains(@class, 'ds-article-content__block_image') and position()=1)]", new Guid("dc09014f-7a63-48e5-9d37-190a304a724a"), "//section[@itemprop='articleBody']//div[contains(@class, 'ds-article-content__block_text')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("9501ba3e-e8ac-4e77-93fe-d78c169fd93c"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/*[position()>1 and not(div)]", new Guid("6521d2f1-2119-41e9-b9cd-731654d88622"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()>1]/text()", "//h1/text()" },
                    { new Guid("985cfbb4-c03e-475e-85b6-64598145bf3d"), "//div[contains(@class, 'js-mediator-article')]/*[position()>1]", new Guid("738f3cf2-5f85-482e-b79e-c50206c50504"), "//div[contains(@class, 'js-mediator-article')]/*[position()>1]/text()", "//h1/text()" },
                    { new Guid("98c364dd-6bd7-41d2-93ae-5379edce6a56"), "//div[@class='topic-body__content']", new Guid("b970ebab-83c9-4f19-b020-f4e2e3de6985"), "//div[@class='topic-body__content']/text()", "//h1[@class='topic-body__titles']/span[@class='topic-body__title']/text()" },
                    { new Guid("9e6aaa90-d170-4d76-9218-f0333bbcfd09"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]", new Guid("8d7c6759-f210-4cdf-b801-69a41b67b190"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]/text()", "//h1[@class='article__title']/text()" },
                    { new Guid("a7e23b02-5583-4579-95b7-213fc19c69f1"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]", new Guid("d13b83ea-d879-4a67-85e9-2446279d1f66"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]/text()", "//h1/text()" },
                    { new Guid("b1b5811e-d016-4f14-9126-3d64e32beac3"), "//div[@class='article_text']", new Guid("e23f4c50-4a48-4756-9579-4246831c4362"), "//div[@class='article_text']/text()", "//h1/text()" },
                    { new Guid("c18a6ce0-726f-4af8-840c-620feb919e73"), "//div[@itemprop='articleBody']/*", new Guid("345b9cf3-36a4-41d7-9799-834730479fe1"), "//div[@itemprop='articleBody']/*/text()", "//h1/text()" },
                    { new Guid("c38aa27c-b2f3-4e55-8763-3623d994c104"), "//article//div[@class='newstext-con']/*[position()>2]", new Guid("0715c73c-01b7-45e1-8057-594b3bfbb7f4"), "//article//div[@class='newstext-con']/*[position()>2]/text()", "//h1[@class='headline']/text()" },
                    { new Guid("ce69d24c-5229-440d-befa-229f3e0b8b56"), "//article/*", new Guid("35c3ebda-c896-4b78-8d78-5e1c7f174b54"), "//article/*/text()", "//h1/text()" },
                    { new Guid("d0307add-5116-4250-be97-64832529e990"), "//div[@data-gtm-el='content-body']/*[not(name()='div' and @data-wide='true')]", new Guid("9f12486c-c88e-4020-9f90-5a5a80f065f6"), "//div[@data-gtm-el='content-body']/*[not(name()='div' and @data-wide='true')]/text()", "//h1/text()" },
                    { new Guid("dad68ca8-3a95-44e7-8c9c-f0e56095378e"), "//article/div[@class='news_text']", new Guid("113eb4ca-db6d-4c2c-a0da-d560a69c5b4f"), "//article/div[@class='news_text']/text()", "//h1/text()" },
                    { new Guid("e5ad1f96-fc76-4b5f-bdc7-a5cab8ed365c"), "//div[@itemprop='articleBody']/*[not(name()='div')]", new Guid("a89699ad-a421-4b27-bf26-04ffd6cba1d4"), "//div[@itemprop='articleBody']/*[not(name()='div')]/text()", "//h1/text()" },
                    { new Guid("eaa02ca3-dd6a-4fd5-8840-b346ddf58c85"), "//div[@class='material-7days__paragraf-content']/*[not(name()='div' and @itemprop='image' and position()=1)]", new Guid("a4879b95-08e2-4b49-85f1-ecb4b09a92bb"), "//div[@class='material-7days__paragraf-content']//p/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("eb9eaa5a-cbba-47de-befe-eb5f72b13b26"), "//div[@itemprop='articleBody']/*", new Guid("fceead9c-0ee0-4b42-8735-2aff6a4198d8"), "//div[@itemprop='articleBody']/*/text()", "//h1/text()" },
                    { new Guid("efdcadc8-6f2d-49b5-baa2-1649e84f8c77"), "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]", new Guid("b0a11ebc-494c-4879-9a27-dd7fe1a90cfc"), "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]/text()", "//h1/text()" },
                    { new Guid("f5ee5fac-6959-44da-a7e3-324b865bbb90"), "//div[contains(@class, 'styled__StoryBody')]/*[not(name()='p' and contains(@class, 'styled__StoryParagraph') and position()=1) and not(name()='div' and contains(@class, 'styled__StoryImgContainer') and position()=2)]", new Guid("86d7016d-6903-4fdf-a71a-ce9f2e297fa1"), "//div[contains(@class, 'styled__StoryBody')]/*[not(name()='p' and contains(@class, 'styled__StoryParagraph') and position()=1) and not(name()='div' and contains(@class, 'styled__StoryImgContainer') and position()=2)]/text()", "//meta[@name='og:title']/@content" }
                });

            migrationBuilder.InsertData(
                table: "news_search_settings",
                columns: new[] { "id", "news_site_url", "news_url_x_path", "source_id" },
                values: new object[,]
                {
                    { new Guid("14c10ef4-1a5f-4c4a-bee7-a0c7799d1c24"), "https://www.zr.ru/news/", "//a[contains(@href, '/news/') and not(starts-with(@href, '/news/')) and not(starts-with(@href, 'https://'))]/@href", new Guid("86d7016d-6903-4fdf-a71a-ce9f2e297fa1") },
                    { new Guid("1b2760db-51dd-45fa-9171-ea6bf9398389"), "https://russian.rt.com/", "//a[contains(@class, 'link') and contains(@href, 'news/')]/@href", new Guid("539cd0d2-548a-4c9e-9024-a0dc4f603beb") },
                    { new Guid("29bd8a60-136e-4c0a-a46d-d093c5af6583"), "https://www.kinonews.ru/news/", "//a[contains(@href, '/news_') and not(contains(@href, 'comments')) and not(contains(@href, 'news_p'))]/@href", new Guid("c1049e1c-d1e1-4cc5-8632-2f0cd2ee9a1c") },
                    { new Guid("3299001f-a8b4-4d34-b0f7-219fba01170f"), "https://www.nytimes.com/", "//a[contains(@href, '.html')]/@href", new Guid("612000dd-d91f-4a31-974c-eaf4bc151ea7") },
                    { new Guid("3adedc6c-4ad6-4ec3-98ff-c39bec349a2c"), "https://www.kp.ru/", "//a[contains(@href, '/news/')]/@href", new Guid("9f12486c-c88e-4020-9f90-5a5a80f065f6") },
                    { new Guid("45a9554d-8c4f-42d1-b25d-c36ea010888c"), "https://www.sports.ru/news/", "//a[contains(@href, '.html') and not(contains(@href, '.html#comments')) and not (contains(@href, '/blogs/'))]/@href", new Guid("2afc1d33-38c6-4044-8f4c-b87b8def4a6c") },
                    { new Guid("4eb80480-6e93-4a92-9778-9612061ab2c2"), "https://ria.ru/", "//a[contains(@class, 'cell-list__item-link')]/@href", new Guid("ca47e185-546f-458c-bc8d-69ed5c2f19ec") },
                    { new Guid("51488381-79d9-4608-bb3d-8555026dc5ec"), "https://aif.ru/", "//span[contains(@class, 'item_text__title')]/../@href", new Guid("e23f4c50-4a48-4756-9579-4246831c4362") },
                    { new Guid("59b630e9-8d42-4c82-a618-ab8614d65345"), "https://www.1obl.ru/news/", "//a[starts-with(@href, '/news/') and not(contains(@href, '?'))]/@href", new Guid("a05c4170-2a7c-4130-95de-e1d52e970cca") },
                    { new Guid("6e40df2f-df5d-4dba-931d-b7ab92cac63c"), "https://stopgame.ru/news", "//div[contains(@class, 'list-view')]//div[contains(@class, '_card')]/a/@href", new Guid("03e0504c-3c5f-41ae-802e-887cf55014e2") },
                    { new Guid("70d7a825-7f82-4059-8d2d-7c8ece5e7b54"), "https://www.pravda.ru/", "//a[contains(@href, '/news/') and not(@href='https://www.pravda.ru/news/')]/@href", new Guid("b0a11ebc-494c-4879-9a27-dd7fe1a90cfc") },
                    { new Guid("7386154f-229c-47b5-ad90-a46097f654d0"), "https://www.rbc.ru/", "//a[contains(@href, 'https://www.rbc.ru/') and contains(@href, '?from=')]/@href", new Guid("cb77eeb1-5b65-48d4-9076-f0c64a2b8aca") },
                    { new Guid("76b5a97f-767a-4a49-9b98-c1cc1cf17e49"), "https://www.gazeta.ru/news/", "//a[contains(@href, '/news/') and contains(@href, '.shtml') and not(contains(@href, '?'))]/@href", new Guid("74c26784-72c3-4686-8d26-0e1b548620f1") },
                    { new Guid("7f48c307-a728-4660-a088-c0427b3fb619"), "https://www.hltv.org/", "//a[contains(@href, '/news/')]/@href", new Guid("0715c73c-01b7-45e1-8057-594b3bfbb7f4") },
                    { new Guid("80834ee7-bcc1-4e93-97e5-aa8684596f4d"), "https://rg.ru/", "//a[contains(@href, '.html')]/@href", new Guid("59c99538-bf67-426b-9c9b-1c6cdf0675ef") },
                    { new Guid("83a06c03-7279-4701-b5fd-4d09aa693bbc"), "https://tsargrad.tv/", "//a[contains(@class, 'news-item__link')]/@href", new Guid("8d7c6759-f210-4cdf-b801-69a41b67b190") },
                    { new Guid("89958535-af64-4db8-b41d-36a7c3325d58"), "https://74.ru/", "//a[starts-with(@href, '/text/') and not(contains(@href, '?')) and not(contains(@href, 'comments/')) and not(@href='/text/')]/@href", new Guid("e308bfa8-c0a2-42c0-a13f-5daeb4b8a7d3") },
                    { new Guid("8d3c068f-1b46-4b2d-9a8e-c244102742e5"), "https://www.ixbt.com/news/", "//a[starts-with(@href, '/news/') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("345b9cf3-36a4-41d7-9799-834730479fe1") },
                    { new Guid("904e3b77-60ec-42af-842c-5856629626e3"), "https://life.ru/s/novosti", "//a[contains(@href, '/p/')]/@href", new Guid("8ed19b05-50df-4aec-9a1e-ad0f2bf5fa4f") },
                    { new Guid("944fca8c-a155-4a83-867c-364974fdfe37"), "https://www.avtovzglyad.ru/news/", "//a[@class='news-card__link']/@href", new Guid("5aefe15e-13f9-42f2-b666-9de76bfb9a3d") },
                    { new Guid("9e444ebd-e2fb-45dd-a669-5a5ca415d456"), "https://www.starhit.ru/novosti/", "//a[@class='announce-inline-tile__label-container']/@href", new Guid("dc09014f-7a63-48e5-9d37-190a304a724a") },
                    { new Guid("a25a515c-875b-4fc4-b8e5-ff6f35b3c5de"), "https://www.belta.by/", "//a[contains(@href, 'https://www.belta.by/') and contains(@href, '/view/')]/@href", new Guid("109dbed5-5f9f-4368-bbb3-3513567101da") },
                    { new Guid("a57d73c9-b839-412f-8d86-149b27e3a86d"), "https://overclockers.ru/news", "//div[contains(@class, 'event')]//a[not(contains(@href, '#comments'))]/@href", new Guid("e47d0a10-5bee-4e51-9969-32d9487a369c") },
                    { new Guid("a747ccee-0171-4bb6-975f-01571c1b4c2c"), "https://edition.cnn.com/", "//a[contains(@href, '.html')]/@href", new Guid("fceead9c-0ee0-4b42-8735-2aff6a4198d8") },
                    { new Guid("b30c9042-aeae-4424-892c-de16206b4d45"), "https://www.cybersport.ru/", "//a[contains(@href, '/tags/')]/@href", new Guid("738f3cf2-5f85-482e-b79e-c50206c50504") },
                    { new Guid("bc9aaeb6-5487-4e66-ba4e-c7425a87b7f5"), "https://ixbt.games/news/", "//a[@class='card-link']/@href", new Guid("137a0aba-81a1-4944-a586-6c4c6f0cbace") },
                    { new Guid("bd24f2e6-def8-42b5-b078-4feb23023cfb"), "https://www.kommersant.ru/", "//a[contains(@href, '/doc/') and contains(@href, '?from=')]/@href", new Guid("d13b83ea-d879-4a67-85e9-2446279d1f66") },
                    { new Guid("beac79c7-2913-442a-bb6e-e3a43e36a6a4"), "https://lenta.ru/", "//a[starts-with(@href, '/news/')]/@href", new Guid("b970ebab-83c9-4f19-b020-f4e2e3de6985") },
                    { new Guid("c89ad74c-2798-4e0b-a92f-25edca7126ee"), "https://3dnews.ru/news/", "//div[@class='news-feed-all']//a[@class='entry-header']/h1/../@href", new Guid("6521d2f1-2119-41e9-b9cd-731654d88622") },
                    { new Guid("cb7fbbfe-d1a6-46d6-9c39-db30301c5bfd"), "https://ura.news/", "//a[contains(@href, '/news/')]/@href", new Guid("a89699ad-a421-4b27-bf26-04ffd6cba1d4") },
                    { new Guid("d3af9673-c13d-4549-bbd1-fb298f96c2b0"), "https://www.m24.ru/", "//a[contains(@href, '/news/')]/@href", new Guid("cfc561cc-cd66-4dcc-a367-a94252b3b359") },
                    { new Guid("d4d77df5-400e-4ee1-ad74-157c2fb5429e"), "https://iz.ru/news/", "//a[contains(@href, '?main_click')]/@href", new Guid("c1f171e6-d940-4019-bed5-d5aa0ae2490b") },
                    { new Guid("db51325e-7637-4dfb-8113-3d53d3e59df4"), "https://svpressa.ru/all/news/", "//a[contains(@href, '/news/') and not(contains(@href, '?')) and not(starts-with(@href, '/all/news/'))]/@href", new Guid("ae22a034-eae7-423b-964b-34b6d3c41410") },
                    { new Guid("dc8fe22a-2250-4f15-9e81-a8e6b78c3d84"), "https://www.championat.com/news/1.html?utm_source=button&utm_medium=news", "//a[contains(@href, 'news-') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("6f177b19-487f-469c-b668-bd6dbcc0ff7a") },
                    { new Guid("ddb65654-3531-47d1-b243-d599dfd81a33"), "https://7days.ru/news/", "//a[contains(@class, '7days__item_href') and starts-with(@href, '/news/')]/@href", new Guid("a4879b95-08e2-4b49-85f1-ecb4b09a92bb") },
                    { new Guid("e4f9de9e-6086-4222-9e2c-79511db3671d"), "https://tass.ru/", "//a[contains(@class, 'tass_pkg_link-v5WdK') and contains(substring(@href, 2), '/') and not(contains(@href, '/spec/')) and not(contains(@href, 'spec.tass.ru'))]/@href", new Guid("35c3ebda-c896-4b78-8d78-5e1c7f174b54") },
                    { new Guid("ec64d7b9-c529-4e95-8e67-2191a52253cb"), "https://www.interfax.ru/", "//div[@class='timeline']//a[@tabindex=5]/@href", new Guid("8e7d6e12-3aca-4dd2-a4c3-19f1002c0588") },
                    { new Guid("f37f7fdd-8f78-4129-883e-c6cc16315bcf"), "https://vz.ru/", "//a[contains(@href, '.html') and not(contains(@href, '#comments')) and not(contains(@href, '?')) and not(contains(@href, '/about/'))]/@href", new Guid("113eb4ca-db6d-4c2c-a0da-d560a69c5b4f") }
                });

            migrationBuilder.InsertData(
                table: "news_source_logos",
                columns: new[] { "id", "original", "small", "source_id" },
                values: new object[,]
                {
                    { new Guid("09cc09a8-d0b5-492a-8b45-2b883dc30ed9"), "https://russian.rt.com/static/blocks/touch-icon/apple-touch-icon-144x144-precomposed.png", "https://russian.rt.com/favicon.ico", new Guid("539cd0d2-548a-4c9e-9024-a0dc4f603beb") },
                    { new Guid("0fb13e38-7ca3-4339-b5e0-69b72696117c"), "https://overclockers.ru/assets/apple-touch-icon-120x120.png", "https://overclockers.ru/assets/apple-touch-icon.png", new Guid("e47d0a10-5bee-4e51-9969-32d9487a369c") },
                    { new Guid("10219982-5392-45a1-ba49-363e96ab8427"), "https://s.rbk.ru/v10_rbcnews_static/common/common-10.10.120/images/android-chrome-512x512.png", "https://s.rbk.ru/v10_rbcnews_static/common/common-10.10.120/images/favicon.png", new Guid("cb77eeb1-5b65-48d4-9076-f0c64a2b8aca") },
                    { new Guid("163370fd-cf1a-4c1a-90f5-2bf6142f2435"), "https://im.kommersant.ru/ContentFlex/images/favicons2020/apple-touch-icon-180.png", "https://im.kommersant.ru/ContentFlex/images/favicons2020/favicon-32.png", new Guid("d13b83ea-d879-4a67-85e9-2446279d1f66") },
                    { new Guid("1b563a73-7453-4dec-9ad9-bb8f7a03dff1"), "https://aif.ru/img/icon/apple-touch-icon.png?44f", "https://aif.ru/img/icon/favicon-32x32.png?44f", new Guid("e23f4c50-4a48-4756-9579-4246831c4362") },
                    { new Guid("1bd13415-6897-4fbd-b62d-180c51682c85"), "https://7days.ru/android-icon-192x192.png", "https://7days.ru/favicon-32x32.png", new Guid("a4879b95-08e2-4b49-85f1-ecb4b09a92bb") },
                    { new Guid("23897e71-bd7c-4bb5-9110-9d17c8427dcc"), "https://icdn.lenta.ru/images/icons/icon-256x256.png", "https://icdn.lenta.ru/favicon.ico", new Guid("b970ebab-83c9-4f19-b020-f4e2e3de6985") },
                    { new Guid("27e31326-0fdc-4329-8d46-84dea0b0b8d5"), "https://www.interfax.ru/touch-icon-ipad-retina.png", "https://www.interfax.ru/touch-icon-iphone.png", new Guid("8e7d6e12-3aca-4dd2-a4c3-19f1002c0588") },
                    { new Guid("2b649e39-5a63-4095-8611-5cdfb8db198a"), "https://www.m24.ru/img/fav/apple-touch-icon.png", "https://www.m24.ru/img/fav/favicon-32x32.png", new Guid("cfc561cc-cd66-4dcc-a367-a94252b3b359") },
                    { new Guid("2d5c6f77-7231-4465-9ec5-d3167db26a7a"), "https://life.ru/appletouch/apple-icon-180%D1%85180.png", "https://life.ru/favicon-32%D1%8532.png", new Guid("8ed19b05-50df-4aec-9a1e-ad0f2bf5fa4f") },
                    { new Guid("31026c58-f45d-4eb1-ace1-e618f23bbe3d"), "https://www.pravda.ru/pix/apple-touch-icon.png", "https://www.pravda.ru/favicon.ico", new Guid("b0a11ebc-494c-4879-9a27-dd7fe1a90cfc") },
                    { new Guid("3a8d279f-805d-445b-9dd1-7b369b9675d7"), "https://3dnews.ru/assets/images/3dnews_logo_soc.png", "https://3dnews.ru/assets/3dnews_logo_color.png", new Guid("6521d2f1-2119-41e9-b9cd-731654d88622") },
                    { new Guid("4165175d-9d05-477a-8181-8e32a4bff77e"), "https://cdnstatic.rg.ru/images/touch-icon-ipad-retina_512x512.png", "https://rg.ru/favicon.ico", new Guid("59c99538-bf67-426b-9c9b-1c6cdf0675ef") },
                    { new Guid("449a116e-cd2f-4c84-95ce-2dd3d0221a3c"), "https://static.ngs.ru/jtnews/dist/static/favicons/apple/apple-favicon-74-180.png", "https://static.ngs.ru/jtnews/dist/static/favicons/favicon-rugion-32.ico", new Guid("e308bfa8-c0a2-42c0-a13f-5daeb4b8a7d3") },
                    { new Guid("44e5771a-ef1d-47e4-af01-1f56443e3e7e"), "https://ura.news/apple-touch-icon.png", "https://s.ura.news/favicon.ico?3", new Guid("a89699ad-a421-4b27-bf26-04ffd6cba1d4") },
                    { new Guid("454ee28a-7509-4c69-a9b9-2691137274e4"), "https://www.nytimes.com/vi-assets/static-assets/apple-touch-icon-28865b72953380a40aa43318108876cb.png", "https://www.nytimes.com/vi-assets/static-assets/ios-default-homescreen-57x57-dark-b395ebcad5b63aff9285aab58e31035e.png", new Guid("612000dd-d91f-4a31-974c-eaf4bc151ea7") },
                    { new Guid("664a346b-1263-4aac-9f5b-a9dbd0d46364"), "https://www.hltv.org/img/static/favicon/apple-touch-icon.png", "https://www.hltv.org/img/static/favicon/favicon-32x32.png", new Guid("0715c73c-01b7-45e1-8057-594b3bfbb7f4") },
                    { new Guid("69496252-6310-4492-a3d6-62de22194f84"), "https://svpressa.ru/favicon-96x96.png?v=1471426270000", "https://svpressa.ru/favicon-32x32.png?v=1471426270000", new Guid("ae22a034-eae7-423b-964b-34b6d3c41410") },
                    { new Guid("6bace740-c08d-4095-9749-b0749295ca88"), "https://static.gazeta.ru/nm2021/img/icons/favicon.svg", "https://static.gazeta.ru/nm2021/img/icons/favicon.svg", new Guid("74c26784-72c3-4686-8d26-0e1b548620f1") },
                    { new Guid("6c8acdbd-91f9-4eea-8a53-f1487a38bcd1"), "https://cdn.iz.ru/profiles/portal/themes/purple/images/favicons/android-icon-192x192.png", "https://cdn.iz.ru/profiles/portal/themes/purple/images/favicons/favicon-32x32.png", new Guid("c1f171e6-d940-4019-bed5-d5aa0ae2490b") },
                    { new Guid("796dfb41-92fa-4328-bd23-22de129a858f"), "https://www.avtovzglyad.ru/static/images/favicon/safari-pinned-tab.svg", "https://www.avtovzglyad.ru/static/images/favicon/favicon-32x32.png", new Guid("5aefe15e-13f9-42f2-b666-9de76bfb9a3d") },
                    { new Guid("7f611f86-ac56-4bd9-9803-22e49773e76f"), "https://st.championat.com/i/favicon/apple-touch-icon.png", "https://st.championat.com/i/favicon/favicon-32x32.png", new Guid("6f177b19-487f-469c-b668-bd6dbcc0ff7a") },
                    { new Guid("87445589-e065-45e1-98c5-4e5bc283ad46"), "https://vz.ru/apple-touch-icon.png", "https://vz.ru/static/images/favicon.ico", new Guid("113eb4ca-db6d-4c2c-a0da-d560a69c5b4f") },
                    { new Guid("8ff1e6ef-b81f-4e36-befe-7ffc2a97dbb5"), "https://cdn.hsmedia.ru/public/favicon/starhit/apple-touch-icon.png", "https://cdn.hsmedia.ru/public/favicon/starhit/favicon.png", new Guid("dc09014f-7a63-48e5-9d37-190a304a724a") },
                    { new Guid("93404374-7ba7-416f-b2cd-496b9217b309"), "https://stopgame.ru/favicon_512.png", "https://stopgame.ru/favicon.ico", new Guid("03e0504c-3c5f-41ae-802e-887cf55014e2") },
                    { new Guid("9a4748be-8502-4d6e-b2b2-e8e5c96b439e"), "https://www.ixbt.com/favicon.ico", "https://www.ixbt.com/favicon.ico", new Guid("345b9cf3-36a4-41d7-9799-834730479fe1") },
                    { new Guid("a4a80873-12e6-4b8d-88a6-aacf082f5fda"), "https://edition.cnn.com/media/sites/cnn/apple-touch-icon.png", "https://edition.cnn.com/media/sites/cnn/favicon.ico", new Guid("fceead9c-0ee0-4b42-8735-2aff6a4198d8") },
                    { new Guid("a8a668a4-e8d8-4a0e-81de-10086c89f74f"), "https://www.1obl.ru/apple-touch-icon.png", "https://www.1obl.ru/favicon-32x32.png", new Guid("a05c4170-2a7c-4130-95de-e1d52e970cca") },
                    { new Guid("ac7aae11-a805-4e6d-b22a-d6d3f6847ee7"), "https://www.sports.ru/apple-touch-icon-1024.png", "https://www.sports.ru/apple-touch-icon-76.png", new Guid("2afc1d33-38c6-4044-8f4c-b87b8def4a6c") },
                    { new Guid("b34ce98f-e086-4c71-81d8-928e3f871827"), "https://www.belta.by/images/storage/banners/000016_a133e848cb2e7b1debb7102d19e4d139_work.svg", "https://www.belta.by/images/storage/banners/000016_a133e848cb2e7b1debb7102d19e4d139_work.svg", new Guid("109dbed5-5f9f-4368-bbb3-3513567101da") },
                    { new Guid("b5c5df04-656f-42aa-9434-2ff766f0409f"), "https://www.cybersport.ru/favicon-192x192.png", "https://www.cybersport.ru/favicon-32x32.png", new Guid("738f3cf2-5f85-482e-b79e-c50206c50504") },
                    { new Guid("b80c72de-89b1-4ed1-95f4-d3e96f40718f"), "https://cdnn21.img.ria.ru/i/favicons/favicon.svg", "https://cdnn21.img.ria.ru/i/favicons/favicon.ico", new Guid("ca47e185-546f-458c-bc8d-69ed5c2f19ec") },
                    { new Guid("bd1ad396-3d45-4f10-8f51-b0ee388382b4"), "https://ixbt.games/images/favicon/gt/apple-touch-icon.png", "https://ixbt.games/images/favicon/gt/apple-touch-icon.png", new Guid("137a0aba-81a1-4944-a586-6c4c6f0cbace") },
                    { new Guid("c281ec27-b43c-49a3-ab48-a8d2d6572f9a"), "https://www.kinonews.ru/favicon.ico", "https://www.kinonews.ru/favicon.ico", new Guid("c1049e1c-d1e1-4cc5-8632-2f0cd2ee9a1c") },
                    { new Guid("cdaf02e5-4bd1-44c6-9a22-b345a4f792df"), "https://www.zr.ru/favicons/safari-pinned-tab.svg", "https://www.zr.ru/favicons/favicon.ico", new Guid("86d7016d-6903-4fdf-a71a-ce9f2e297fa1") },
                    { new Guid("d8b8a4ac-e7f2-4136-8dbb-b209a534f2ed"), "https://tsargrad.tv/favicons/apple-touch-icon-180x180.png?s2", "https://tsargrad.tv/favicons/favicon-32x32.png?s2", new Guid("8d7c6759-f210-4cdf-b801-69a41b67b190") },
                    { new Guid("e5a3728e-70eb-45d3-b83a-1d8cd02365aa"), "https://s01.stc.yc.kpcdn.net/s0/2.1.321/adaptive/favicon-128.png", "https://s01.stc.yc.kpcdn.net/s0/2.1.321/adaptive/favicon-32.png", new Guid("9f12486c-c88e-4020-9f90-5a5a80f065f6") },
                    { new Guid("e790511b-ed87-4c5a-8dbd-3ce11d7bc14e"), "https://tass.ru/favicon/180.svg", "https://tass.ru/favicon/57.png", new Guid("35c3ebda-c896-4b78-8d78-5e1c7f174b54") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_editor_settings",
                columns: new[] { "id", "is_required", "name_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("00adb1dc-a329-4c20-affa-fdb657c47468"), true, "//div[contains(@class, 'styles_bodyWrapper')]//div[contains(@class, 'styles_authorsLinks')]/a/text()", new Guid("5d3598b5-03f2-4f41-bc88-89e95a6910d6") },
                    { new Guid("01807368-765a-4b88-bad9-01058cf31164"), false, "//p[@class='doc__text document_authors']/text()", new Guid("a7e23b02-5583-4579-95b7-213fc19c69f1") },
                    { new Guid("0bafd18f-732b-4def-9e88-62840be6e7a5"), true, "//a[@class='article__author']/text()", new Guid("9e6aaa90-d170-4d76-9218-f0333bbcfd09") },
                    { new Guid("1b741c21-bda7-40e6-b560-82ba3f3e3284"), false, "//div[@itemprop='author']//p[@itemprop='name']/text()", new Guid("7ed244cb-9d7c-4e16-868b-9370271300aa") },
                    { new Guid("1dd8fe60-af79-4f1e-8d37-2e1679678471"), false, "//div[@class='topic-authors']/a[@class='topic-authors__author']/text()", new Guid("98c364dd-6bd7-41d2-93ae-5379edce6a56") },
                    { new Guid("2d702e8d-3748-4be9-9d28-876ee4c4dba4"), true, "//div[contains(@class, 'PageArticleContent_authors')]//a[contains(@class, 'LinksOfAuthor_item')]/text()", new Guid("7273650f-34a9-4592-8e45-459af7effe55") },
                    { new Guid("35eb4faa-f906-4869-8ded-9ac7d41add58"), false, "//div[contains(@class, 'styled__StoryInfoAuthors')]/div[contains(@class, 'styled__InfoAuthor')]//span[contains(@class, 'styled__AuthorName')]/text()", new Guid("f5ee5fac-6959-44da-a7e3-324b865bbb90") },
                    { new Guid("3f9819e2-fea6-4187-a310-f3ea10f72eca"), true, "//span[@itemprop='name']/a/text()", new Guid("00d50317-7614-4523-9bbc-c6a97bb3bbb1") },
                    { new Guid("422c63ec-f234-4aae-9c0a-65642d016f52"), false, "//div[@class='article__authors']//*[@class='article__authors__author']/span[@class='article__authors__author__name']/text()", new Guid("78cf22eb-52f9-47e5-9cdf-30e1d3ed4f76") },
                    { new Guid("4ee29459-ed50-4b62-9b36-335ac2f81e14"), true, "//div[contains(@class, 'full-article')]/div[@class='authors-block']//span[text()='Автор']/../a/text()", new Guid("efdcadc8-6f2d-49b5-baa2-1649e84f8c77") },
                    { new Guid("4ffb01dc-7e27-413b-abdc-a961ae3c2934"), true, "//article//header//div[@class='article-head__author-name']/a[@rel='author']/span/text()", new Guid("56cdb823-fe00-463d-af40-e4b8d1556dda") },
                    { new Guid("53aba19e-5b35-4d01-93f5-2ac0d15ffca8"), true, "//span[@itemprop='author']/span[@itemprop='name']/@content", new Guid("c18a6ce0-726f-4af8-840c-620feb919e73") },
                    { new Guid("5b3851a8-4a13-4a0f-85d6-eba363d949ac"), true, "//div[@itemprop='author']/span[@itemprop='name']/text()", new Guid("e5ad1f96-fc76-4b5f-bdc7-a5cab8ed365c") },
                    { new Guid("5d0f6e4c-bc92-4ccb-93ff-eb87e4846c79"), true, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']//a[@itemprop='author']//span[@itemprop='name']/text()", new Guid("9501ba3e-e8ac-4e77-93fe-d78c169fd93c") },
                    { new Guid("754f3bd4-d9aa-428e-a46d-eb78238dea93"), false, "//section[contains(@class, '_page-section')]//div[contains(@class, '_bottom-info_')]//span[contains(@class, '_user-info__name_')]/text()", new Guid("6e7f5c2c-e5be-49ec-8daf-cf6c26b96b71") },
                    { new Guid("89c0fa1e-2a22-4cb8-b7b1-1c6fd380affc"), false, "//meta[@property='article:author']/@content", new Guid("7fbd53c6-ab6f-4d0b-87b0-5948449c30ed") },
                    { new Guid("94098e6c-1545-4b29-9877-d6bb3958922e"), false, "//div[@class='author']/span[@itemprop='author']/span[@itemprop='name']/a/text()", new Guid("465024e2-0532-42bc-83dd-c4212753187c") },
                    { new Guid("96b27187-1b17-4723-b48f-27fab720fcae"), true, "//div[@class='container-fluid publication-footer']//a[contains(@class, 'text-secondary')]/@title", new Guid("5f9e04b0-0550-47db-9672-93ed3c893fc1") },
                    { new Guid("9a6c35df-cc86-4aca-8da1-58261bbbad36"), true, "//article//span[@class='author']/a[@class='authorName']/span/text()", new Guid("c38aa27c-b2f3-4e55-8763-3623d994c104") },
                    { new Guid("a01069a9-9da6-49f7-9f7b-33565010322a"), false, "//meta[@name='author']/@content", new Guid("8c88ccc1-ef46-4716-bb83-32e8bcd1db5a") },
                    { new Guid("aee4b225-7bc7-45cb-8ea6-1b17a55dd704"), false, "//meta[@property='article:author']/@content", new Guid("8c01b16a-ed2b-49b6-8a5c-9c351d530606") },
                    { new Guid("b1bdae69-e72b-46d9-9450-2e195a5f122e"), true, "//footer[@class='news-item__footer']/div[@class='news-item__footer-after-news']/p[position()=1]//span/text()", new Guid("4aac24ae-1d63-4d1a-aa6f-fb35591b799a") },
                    { new Guid("e405f951-953f-4221-86e3-1173ed02d1d2"), true, "//*[@itemprop='author']/*[@itemprop='name']//text()", new Guid("6d632245-8966-4ad8-927b-b70244ba46e3") },
                    { new Guid("f3ecf4ba-da50-41aa-a7ca-e60562882528"), true, "//div[@class='article_top']//div[@class='authors']//div[@class='autor']//span/text()", new Guid("b1b5811e-d016-4f14-9126-3d64e32beac3") },
                    { new Guid("f6e0cac4-e93f-4e7e-830a-e48d22fccc88"), true, "//div[@class='headline__footer']//div[@class='byline__names']/span[@class='byline__name']/text()", new Guid("eb9eaa5a-cbba-47de-befe-eb5f72b13b26") },
                    { new Guid("f9e76a06-475b-4591-866c-965cd762e3d1"), false, "//span[@class='author']/a/text()", new Guid("0abb675a-61a0-4682-9f08-39713ddf8b43") },
                    { new Guid("fc076264-2d3b-418e-81dd-e34aeeb51fbd"), false, "//div[@class='preview__author-block']//div[@class='author__about']/a[@itemprop='name']/@content", new Guid("885bbecf-0f5a-443e-8fbc-870d910c7afd") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_modified_at_settings",
                columns: new[] { "id", "is_required", "modified_at_culture_info", "modified_at_time_zone_info_id", "modified_at_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("1e5ad485-4b9d-4924-8348-eacf1da89b9e"), false, "ru-RU", "Russian Standard Time", "//meta[@itemprop='dateModified']/@content", new Guid("eaa02ca3-dd6a-4fd5-8840-b346ddf58c85") },
                    { new Guid("3e966a3a-0a9d-4799-8082-91146fbf52e4"), true, "ru-RU", "Russian Standard Time", "//div[@class='article__info']//div[@class='article__info-date']/span[@class='article__info-date-modified']/text()", new Guid("79a6a983-d89f-4000-a249-9f9dbebaaa67") },
                    { new Guid("696fa1e3-c92c-4c0a-b20f-ccf040433f50"), false, "ru-RU", "UTC", "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark_update')]//span[@ca-ts]/text()", new Guid("ce69d24c-5229-440d-befa-229f3e0b8b56") },
                    { new Guid("79e4cdf5-0234-4de2-a574-7d1c470c1f90"), true, "ru-RU", "Russian Standard Time", "//meta[@property='article:modified_time']/@content", new Guid("d0307add-5116-4250-be97-64832529e990") },
                    { new Guid("9351bba4-a932-491f-9391-02f8f605e842"), false, "ru-RU", "Russian Standard Time", "//div[@class='doc_header__time']/span[contains(@class, 'publish_update')]/text()", new Guid("a7e23b02-5583-4579-95b7-213fc19c69f1") },
                    { new Guid("990e4245-9f31-4f10-b094-f953f3772d2b"), false, "ru-RU", null, "//meta[@itemprop='dateModified']/@content", new Guid("78cf22eb-52f9-47e5-9cdf-30e1d3ed4f76") },
                    { new Guid("eeed95a4-41ad-487d-aee4-47d39893c1ac"), false, "ru-RU", null, "//meta[@itemprop='dateModified']/@content", new Guid("8c88ccc1-ef46-4716-bb83-32e8bcd1db5a") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_picture_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("12387333-a079-4ed3-aad6-765bb4c0000e"), false, new Guid("f5ee5fac-6959-44da-a7e3-324b865bbb90"), "//meta[@name='og:image']/@content" },
                    { new Guid("21df6a12-0307-412e-9e26-39ef1967400d"), true, new Guid("d0307add-5116-4250-be97-64832529e990"), "//div[@data-gtm-el='content-body']//picture/img/@src" },
                    { new Guid("2bcbae4e-e58c-4bec-b0cc-fc745be662e9"), false, new Guid("56cdb823-fe00-463d-af40-e4b8d1556dda"), "//article//header/div[@class='article-head__photo']/img/@src" },
                    { new Guid("32a40c8b-8c9e-468b-b96a-f2295338dee9"), false, new Guid("7273650f-34a9-4592-8e45-459af7effe55"), "//meta[@property='og:image']/@content" },
                    { new Guid("3ba039a9-3138-426e-9f38-29493e05ba8e"), false, new Guid("0abb675a-61a0-4682-9f08-39713ddf8b43"), "//meta[@property='og:image']/@content" },
                    { new Guid("3bc6b092-df9a-465e-a602-ed6b0be489a7"), false, new Guid("5d3598b5-03f2-4f41-bc88-89e95a6910d6"), "//article//header/div[contains(@class, 'styles_cover_media')]/img/@src" },
                    { new Guid("41cb331d-9f05-494e-92d2-84c5123f97b0"), true, new Guid("6d632245-8966-4ad8-927b-b70244ba46e3"), "//div[contains(@class, 'newsMediaContainer')]/img/@data-src" },
                    { new Guid("450ff677-92ef-47f1-a09d-4ab1fce507dd"), false, new Guid("c38aa27c-b2f3-4e55-8763-3623d994c104"), "//article//div[@class='image-con' and position() = 1]/picture/img/@src" },
                    { new Guid("4b44cdfd-aa8f-47d8-9940-51e625666b5a"), true, new Guid("5f9e04b0-0550-47db-9672-93ed3c893fc1"), "//a[@class='glightbox']/img[contains(@class, 'pub-cover')]/@src" },
                    { new Guid("52edbff9-6f28-411f-ae68-75f6c02e2d68"), false, new Guid("98c364dd-6bd7-41d2-93ae-5379edce6a56"), "//div[contains(@class, 'topic-body__title-image')]//img[contains(@class, 'picture__image')]/@src" },
                    { new Guid("5a75c538-ec05-4f5d-af8a-5eff3942a36a"), false, new Guid("ce69d24c-5229-440d-befa-229f3e0b8b56"), "//div[contains(@class, 'HeaderMedia_image')]//img[contains(@class, 'Image_image')]/@src" },
                    { new Guid("64fa050e-ddf2-4e81-91c6-67d7198e0b44"), false, new Guid("528fbf2b-a035-44f4-aa9c-571bb448267f"), "//div[@class='inner_content']//div[@class='main_img']//img/@src" },
                    { new Guid("75a79580-837c-4514-8055-119f95413c64"), true, new Guid("00d50317-7614-4523-9bbc-c6a97bb3bbb1"), "//header//figure//picture/img/@src" },
                    { new Guid("7cd46cde-0324-4fe8-97cb-034629984348"), false, new Guid("78cf22eb-52f9-47e5-9cdf-30e1d3ed4f76"), "//meta[@itemprop='url']/@content" },
                    { new Guid("810a7d1f-ba35-4cea-8125-eac80a41eb27"), false, new Guid("b1b5811e-d016-4f14-9126-3d64e32beac3"), "//div[@class='img_box']/a[@class='zoom_js']/img/@src" },
                    { new Guid("88157b9b-f0da-4fb3-823e-ad3d3686a2e7"), false, new Guid("885bbecf-0f5a-443e-8fbc-870d910c7afd"), "//meta[@property='og:image']/@content" },
                    { new Guid("99551b25-2584-4943-8b8f-faee5976a923"), true, new Guid("985cfbb4-c03e-475e-85b6-64598145bf3d"), "//meta[@property='og:image']/@content" },
                    { new Guid("a3952ac6-8937-4888-8b0b-c82865d91d1b"), false, new Guid("6ab078e1-7964-41a5-b5e2-248a2aa004ea"), "//div[contains(@class, 'article__cover')]/img[@class='article__cover-image ']/@src" },
                    { new Guid("a4aee791-0af2-4a4f-acb2-c2a95ad3a90a"), false, new Guid("7ed244cb-9d7c-4e16-868b-9370271300aa"), "//figure//img/@src" },
                    { new Guid("a6692263-6075-4927-a2b6-a3516ff06324"), true, new Guid("9e6aaa90-d170-4d76-9218-f0333bbcfd09"), "//div[@class='article__media']//img/@src" },
                    { new Guid("a9627c37-809d-4bf6-a882-f24611acc4f5"), false, new Guid("dad68ca8-3a95-44e7-8c9c-f0e56095378e"), "//article/figure/img/@src" },
                    { new Guid("aed9afe0-c96f-4fe1-b25a-dd812abea498"), false, new Guid("79a6a983-d89f-4000-a249-9f9dbebaaa67"), "//div[@class='photoview__open']/img/@src" },
                    { new Guid("b5ddffed-75ec-4237-a031-553229225131"), true, new Guid("eb9eaa5a-cbba-47de-befe-eb5f72b13b26"), "//div[contains(@class, 'article__lede-wrapper')]//picture/img/@src" },
                    { new Guid("ba1fe981-2e4a-4ecc-baa8-3794b67e071d"), false, new Guid("040999fb-3f16-4a57-9217-7b89997f59e4"), "//meta[@property='og:image']/@content" },
                    { new Guid("bea61a20-5eb2-41a7-924e-ca0658018627"), false, new Guid("7fbd53c6-ab6f-4d0b-87b0-5948449c30ed"), "//meta[@property='og:image']/@content" },
                    { new Guid("c2114f29-e5a6-4f30-8a11-656a5fd3e79f"), false, new Guid("9501ba3e-e8ac-4e77-93fe-d78c169fd93c"), "//img[@itemprop='image']/@src" },
                    { new Guid("c53c39b6-5d8a-4301-a1fc-ef28bf60f9d5"), false, new Guid("eaa02ca3-dd6a-4fd5-8840-b346ddf58c85"), "//meta[@property='og:image']/@content" },
                    { new Guid("c63d414d-32e5-4f68-9c46-b0f2607f19ef"), false, new Guid("efdcadc8-6f2d-49b5-baa2-1649e84f8c77"), "//div[contains(@class, 'full-article')]/div[contains(@class, 'gallery')]/picture/img/@src" },
                    { new Guid("c781b800-ffb4-4031-aa7e-f83315bafdfd"), false, new Guid("465024e2-0532-42bc-83dd-c4212753187c"), "//div[@class='b_article-media']//div[@class='mainarea-wrapper']/figure/img[@class='item-image-front']/@src" },
                    { new Guid("d971fb44-6f4f-460e-9fbb-9e96475efe7e"), true, new Guid("e5ad1f96-fc76-4b5f-bdc7-a5cab8ed365c"), "//div[@itemprop='articleBody']//div[@itemprop='image']/picture/img[@itemprop='contentUrl']/@src" },
                    { new Guid("dc269d0e-aa73-4766-a413-5735ca1dec88"), true, new Guid("8c01b16a-ed2b-49b6-8a5c-9c351d530606"), "//div[contains(@class, 'big_photo')]//div[@class='big_photo__img']//img/@data-src" },
                    { new Guid("f61e7e89-2f7d-41f7-a614-470371766a32"), false, new Guid("8c88ccc1-ef46-4716-bb83-32e8bcd1db5a"), "//meta[@property='og:image']/@content" },
                    { new Guid("fd042eb6-7606-4da7-a4e8-59f5683a1467"), false, new Guid("6e7f5c2c-e5be-49ec-8daf-cf6c26b96b71"), "//meta[@property='og:image']/@content" },
                    { new Guid("ff817200-75d8-4363-8a0e-d304cb7ef8d5"), false, new Guid("7aa662fc-b9e4-4821-9565-38ba9f409944"), "//meta[@property='og:image']/@content" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "published_at_culture_info", "published_at_time_zone_info_id", "published_at_x_path" },
                values: new object[,]
                {
                    { new Guid("093dd227-035b-4fd4-bee5-0665bff5fc1e"), true, new Guid("9501ba3e-e8ac-4e77-93fe-d78c169fd93c"), "ru-RU", null, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']/span[@itemprop='datePublished']/@content" },
                    { new Guid("0eaa43d2-5aca-4fba-b6ed-7f9fb539f011"), true, new Guid("885bbecf-0f5a-443e-8fbc-870d910c7afd"), "ru-RU", "Russian Standard Time", "//div[@class='article-details']/span[@class='article-details__time']/time/@datetime" },
                    { new Guid("16e4c71a-afd6-4d7f-806d-2f7f2836d32a"), true, new Guid("5d3598b5-03f2-4f41-bc88-89e95a6910d6"), "ru-RU", "UTC", "//article//header//div[contains(@class, 'styles_meta')]//div[contains(@class, 'styles_metaItem')]/text()" },
                    { new Guid("180cea56-629f-4a8e-9075-467629dd84e5"), true, new Guid("040999fb-3f16-4a57-9217-7b89997f59e4"), "ru-RU", "Russian Standard Time", "//p[@class='b-material__date']/text()" },
                    { new Guid("1aa198e2-9fde-405a-a7b7-3b4cea79f8f1"), true, new Guid("7aa662fc-b9e4-4821-9565-38ba9f409944"), "ru-RU", "Russian Standard Time", "//div[@class='b-text__date']/text()" },
                    { new Guid("2b5d104e-b947-4bb3-87dd-fdfd8f692979"), true, new Guid("c18a6ce0-726f-4af8-840c-620feb919e73"), "ru-RU", "Russian Standard Time", "//div[@class='b-article__top-author']/p[@class='date']/text()" },
                    { new Guid("3148d71a-c773-4d12-8748-0dedba93399d"), true, new Guid("d0307add-5116-4250-be97-64832529e990"), "ru-RU", "Russian Standard Time", "//meta[@property='article:published_time']/@content" },
                    { new Guid("3ad1e07c-b416-407a-abc8-6523563796bb"), true, new Guid("7ed244cb-9d7c-4e16-868b-9370271300aa"), "ru-RU", "Ekaterinburg Standard Time", "//div[@itemprop='datePublished']/time/@datetime" },
                    { new Guid("41917dc3-c774-4f39-9d0a-c3f34f1c49e9"), true, new Guid("6d632245-8966-4ad8-927b-b70244ba46e3"), "ru-RU", null, "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("46a3b890-8d49-4b01-8cfb-5164c6d23907"), true, new Guid("98c364dd-6bd7-41d2-93ae-5379edce6a56"), "ru-RU", "Russian Standard Time", "//div[@class='topic-page__header']//a[contains(@class, 'topic-header__time')]/text()" },
                    { new Guid("56227131-1423-4085-893e-1eeaf20b135d"), true, new Guid("8c01b16a-ed2b-49b6-8a5c-9c351d530606"), "ru-RU", null, "//div[@class='article_page__left__top__left']//div[@class='article_page__left__top__time']//time/@datetime" },
                    { new Guid("578491b9-cd46-4220-aa17-2abdc8dfb41d"), true, new Guid("b1b5811e-d016-4f14-9126-3d64e32beac3"), "ru-RU", "Russian Standard Time", "//div[@class='article_top']//div[@class='date']//time/text()" },
                    { new Guid("5b33d981-cc3c-43d7-80be-0d20d9a77d88"), true, new Guid("9e6aaa90-d170-4d76-9218-f0333bbcfd09"), "ru-RU", "Russian Standard Time", "//div[@class='article__meta']/time/text()" },
                    { new Guid("5ba365f4-fda1-44d8-87c0-3823cf75c22c"), true, new Guid("0abb675a-61a0-4682-9f08-39713ddf8b43"), "ru-RU", "Russian Standard Time", "//span[@class='date']/time/@datetime" },
                    { new Guid("5de72de4-ac1b-4a2f-9e3f-14b045cd5d7f"), false, new Guid("5f9e04b0-0550-47db-9672-93ed3c893fc1"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'pubdatetime')]/text()" },
                    { new Guid("5e8586cd-9507-471a-8226-f5453227f567"), true, new Guid("465024e2-0532-42bc-83dd-c4212753187c"), "ru-RU", null, "//article/div[@class='b_article-header']//time[@itemprop='datePublished']/@datetime" },
                    { new Guid("6d8885af-3f33-476d-a8b9-d5fb76a0caa6"), true, new Guid("00d50317-7614-4523-9bbc-c6a97bb3bbb1"), "en-US", null, "//time/@datetime" },
                    { new Guid("6f045096-2d14-4121-bf74-5b474cc26699"), true, new Guid("56cdb823-fe00-463d-af40-e4b8d1556dda"), "ru-RU", "Russian Standard Time", "//article//header//time[@class='article-head__date']/text()" },
                    { new Guid("70c828a4-cad1-4d11-bf70-d229df855634"), true, new Guid("eb9eaa5a-cbba-47de-befe-eb5f72b13b26"), "en-US", "Eastern Standard Time", "//div[@class='headline__footer']//div[contains(@class, 'headline__byline-sub-text')]/div[@class='timestamp']/text()" },
                    { new Guid("733b12d7-ac6e-4da1-a2a1-36f66b947aad"), true, new Guid("985cfbb4-c03e-475e-85b6-64598145bf3d"), "ru-RU", null, "//article/header//time/@datetime" },
                    { new Guid("76126ca7-2a7a-4db9-a08b-92fec11e3d99"), true, new Guid("e5ad1f96-fc76-4b5f-bdc7-a5cab8ed365c"), "ru-RU", null, "//div[@class='publication-info']/time[@itemprop='datePublished']/@datetime" },
                    { new Guid("7d88e14e-aaa6-4266-bf74-9c7a1bb5cbac"), true, new Guid("eaa02ca3-dd6a-4fd5-8840-b346ddf58c85"), "ru-RU", "Russian Standard Time", "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("8925789b-6d55-4da7-af90-271ac6e385be"), true, new Guid("dad68ca8-3a95-44e7-8c9c-f0e56095378e"), "ru-RU", "Russian Standard Time", "//article/div[@class='header']/span/text()" },
                    { new Guid("8ff0dbec-a22b-4c71-8b5c-c37755d0f12c"), true, new Guid("a7e23b02-5583-4579-95b7-213fc19c69f1"), "ru-RU", null, "//div[@class='doc_header__time']/time[@class='doc_header__publish_time']/@datetime" },
                    { new Guid("9be766b3-3a07-4515-b80e-5540618e5579"), true, new Guid("c38aa27c-b2f3-4e55-8763-3623d994c104"), "en-US", "Central Europe Standard Time", "//article//div[@class='article-info']/div[@class='date']/text()" },
                    { new Guid("9c14a5db-958a-4038-93e1-acd479612d03"), true, new Guid("4aac24ae-1d63-4d1a-aa6f-fb35591b799a"), "ru-RU", null, "//header[@class='news-item__header']//time/@content" },
                    { new Guid("a9087884-5df5-4a06-8c14-18fd6301b8bd"), true, new Guid("8c88ccc1-ef46-4716-bb83-32e8bcd1db5a"), "ru-RU", null, "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("b42707d5-39c2-497d-aed1-ff71f4400a4a"), true, new Guid("ce69d24c-5229-440d-befa-229f3e0b8b56"), "ru-RU", "UTC", "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark')]//span[@ca-ts]/text()" },
                    { new Guid("b6002f63-982d-4f3d-9205-b8b55cd414e1"), true, new Guid("79a6a983-d89f-4000-a249-9f9dbebaaa67"), "ru-RU", "Russian Standard Time", "//div[@class='article__info']//div[@class='article__info-date']/a/text()" },
                    { new Guid("b9d9f08e-163b-4f89-8f51-94ef81b456a9"), true, new Guid("528fbf2b-a035-44f4-aa9c-571bb448267f"), "ru-RU", "Russian Standard Time", "//div[@class='date_full']/text()" },
                    { new Guid("cd1af0db-3664-4349-acda-bf32931ecc43"), true, new Guid("78cf22eb-52f9-47e5-9cdf-30e1d3ed4f76"), "ru-RU", null, "//div[@class='article__header__info-block']/time[@class='article__header__date']/@datetime" },
                    { new Guid("d42ac2af-450a-4218-8e0a-8020e2e8f2e5"), true, new Guid("efdcadc8-6f2d-49b5-baa2-1649e84f8c77"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'full-article')]//time/text()" },
                    { new Guid("d66eb0fb-c215-4264-b24d-61bb8626ab25"), true, new Guid("7fbd53c6-ab6f-4d0b-87b0-5948449c30ed"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("e6761364-f9c5-4a34-9456-dfdcfec0088a"), true, new Guid("7273650f-34a9-4592-8e45-459af7effe55"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'PageArticleContent_date')]/text()" },
                    { new Guid("f4f72b46-b950-4020-b541-9b391ee2eba7"), true, new Guid("1c7f13ca-e036-43ba-9e4e-4992d44e9a61"), "ru-RU", "Russian Standard Time", "//article[@itemprop='articleBody']/meta[@itemprop='datePublished']/@content" },
                    { new Guid("f6000f3b-d1cf-4a94-ad3c-95c861c33318"), true, new Guid("6ab078e1-7964-41a5-b5e2-248a2aa004ea"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'article__date-autor-shortcode')]/div[contains(@class, 'article__date')]/time[@class='date']/@datetime" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_sub_title_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("04a290d5-d8a0-4b0a-ae74-44d322cf5e90"), true, new Guid("6d632245-8966-4ad8-927b-b70244ba46e3"), "//div[@itemprop='alternativeHeadline']/text()" },
                    { new Guid("08faf120-acfe-4320-813a-a34ca090501c"), false, new Guid("a7e23b02-5583-4579-95b7-213fc19c69f1"), "//header[@class='doc_header']/h2[contains(@class, 'doc_header__subheader')]/text()" },
                    { new Guid("1106a2a1-62dc-4ef7-b577-3ce3909ccf22"), false, new Guid("e5ad1f96-fc76-4b5f-bdc7-a5cab8ed365c"), "//meta[@itemprop='description']/@content" },
                    { new Guid("290d4315-f523-496a-af80-cf5d287e8ff1"), false, new Guid("040999fb-3f16-4a57-9217-7b89997f59e4"), "//meta[@property='og:description']/@content" },
                    { new Guid("30bc5463-5a72-4984-a7a1-a2730566bae0"), false, new Guid("8c88ccc1-ef46-4716-bb83-32e8bcd1db5a"), "//p[contains(@itemprop, 'alternativeHeadline')]/text()" },
                    { new Guid("374df4f4-24ec-4503-b0b9-4682ba4dd47e"), true, new Guid("d0307add-5116-4250-be97-64832529e990"), "//meta[@name='description']/@content" },
                    { new Guid("3ce120e0-6297-421e-86d6-7db969d84643"), false, new Guid("ce69d24c-5229-440d-befa-229f3e0b8b56"), "//h3/text()" },
                    { new Guid("4beac3d9-4ea4-40d2-80cd-51a3edb035d2"), false, new Guid("98c364dd-6bd7-41d2-93ae-5379edce6a56"), "//div[contains(@class, 'topic-body__title')]/text()" },
                    { new Guid("4fda0be0-42f7-42d3-ab75-2a0cc2b3d9dc"), false, new Guid("dad68ca8-3a95-44e7-8c9c-f0e56095378e"), "//h4/text()" },
                    { new Guid("598b22f9-e49e-4a65-aae0-a2a1ef4a0a50"), false, new Guid("8c01b16a-ed2b-49b6-8a5c-9c351d530606"), "//div[@itemprop='alternativeHeadline']/text()" },
                    { new Guid("5a3d57f0-b33a-42c3-bb31-ac906a439032"), true, new Guid("985cfbb4-c03e-475e-85b6-64598145bf3d"), "//div[contains(@class, 'js-mediator-article')]/*[position()=1]/text()" },
                    { new Guid("5e0d048f-b371-4f38-afe2-91157907d19f"), false, new Guid("78cf22eb-52f9-47e5-9cdf-30e1d3ed4f76"), "//div[contains(@class, 'article__text')]/div[@class='article__text__overview']/span/text()" },
                    { new Guid("63941327-6ac4-467b-b77c-078275bc4afb"), true, new Guid("79a6a983-d89f-4000-a249-9f9dbebaaa67"), "//h1[@class='article__second-title']/text()" },
                    { new Guid("65a83477-ca69-4cf5-907a-359e46cfc533"), false, new Guid("6e7f5c2c-e5be-49ec-8daf-cf6c26b96b71"), "//meta[@property='og:description']/@content" },
                    { new Guid("6d2fe216-c51f-473e-b106-f75a65c8bfda"), true, new Guid("9e6aaa90-d170-4d76-9218-f0333bbcfd09"), "//div[@class='article__intro']/p/text()" },
                    { new Guid("73d8132f-3a7c-4dc5-aa92-3e80f3c6eb3b"), false, new Guid("7fbd53c6-ab6f-4d0b-87b0-5948449c30ed"), "//div[@class='block-page-new']/h2/text()" },
                    { new Guid("78e5d43e-2c8f-43a4-865e-ebaeb23e62d8"), true, new Guid("9501ba3e-e8ac-4e77-93fe-d78c169fd93c"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()=1]/text()" },
                    { new Guid("9790cc06-9c76-4987-8a07-f966a0fb8706"), true, new Guid("6ab078e1-7964-41a5-b5e2-248a2aa004ea"), "//div[contains(@class, 'article__summary')]/text()" },
                    { new Guid("9bd9c62d-5b23-47b4-9c64-7543ff3910e0"), true, new Guid("efdcadc8-6f2d-49b5-baa2-1649e84f8c77"), "//h1/text()" },
                    { new Guid("9d4e82f4-cdf1-4908-8dcd-0ccce94aefdc"), false, new Guid("eaa02ca3-dd6a-4fd5-8840-b346ddf58c85"), "//meta[@property='og:description']/@content" },
                    { new Guid("a2f36d0b-5ca5-4f23-8cf7-1b829baf8521"), false, new Guid("c18a6ce0-726f-4af8-840c-620feb919e73"), "//h4/text()" },
                    { new Guid("a9ef5925-adba-4d3e-9aca-23f4b783f707"), false, new Guid("885bbecf-0f5a-443e-8fbc-870d910c7afd"), "//meta[@name='description']/@content" },
                    { new Guid("aefbc44c-249f-41d6-ac7b-81fe25082f59"), true, new Guid("c38aa27c-b2f3-4e55-8763-3623d994c104"), "//p[@class='headertext' and @itemprop='description']/text()" },
                    { new Guid("af86bfcd-2ece-4eb5-a862-287164501619"), true, new Guid("00d50317-7614-4523-9bbc-c6a97bb3bbb1"), "//header/p[@id='article-summary']/text()" },
                    { new Guid("c3767303-e945-48aa-8954-44336a86e036"), false, new Guid("7aa662fc-b9e4-4821-9565-38ba9f409944"), "//meta[@property='og:description']/@content" },
                    { new Guid("c41fd63d-3598-4799-95a8-f476e481f052"), false, new Guid("5d3598b5-03f2-4f41-bc88-89e95a6910d6"), "//article//header//p[contains(@class, 'styles_subtitle')]/text()" },
                    { new Guid("df4de43e-2f87-49ba-a9f5-dbb1ade7be76"), true, new Guid("7ed244cb-9d7c-4e16-868b-9370271300aa"), "//p[@itemprop='alternativeHeadline']/span/text()" },
                    { new Guid("ec026be9-e2e5-4f73-87ff-084c1f0aaedf"), false, new Guid("f5ee5fac-6959-44da-a7e3-324b865bbb90"), "//div[contains(@class, 'styled__StoryBody')]/p[contains(@class, 'styled__StoryParagraph') and position()=1]/text()" },
                    { new Guid("edd549bb-52bb-477f-b5d7-6d1c99fff480"), true, new Guid("465024e2-0532-42bc-83dd-c4212753187c"), "//h2/text()" },
                    { new Guid("f120929c-c1e1-40b8-8cee-d3678f7cbe16"), false, new Guid("0abb675a-61a0-4682-9f08-39713ddf8b43"), "//meta[@name='description']/@content" },
                    { new Guid("f1f0056f-edc1-4d38-ad15-9893d1068d81"), true, new Guid("5f9e04b0-0550-47db-9672-93ed3c893fc1"), "//div[@class='container-fluid shifted']/p[@class='announce lead']/text()" },
                    { new Guid("fa126a9c-7360-4a4d-85b4-6d6273a11c4c"), false, new Guid("7273650f-34a9-4592-8e45-459af7effe55"), "//div[contains(@class, 'PageArticleContent_lead')]/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_video_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("280b9eec-d3c8-4ced-b86f-5fdd618d47af"), false, new Guid("c38aa27c-b2f3-4e55-8763-3623d994c104"), "//article//div[@class='videoWrapper' and @itemprop='video']/iframe[@class='video']/@src" },
                    { new Guid("5c337620-2b78-40b7-98b1-984d538c0377"), false, new Guid("7273650f-34a9-4592-8e45-459af7effe55"), "//div[contains(@class, 'PageContentCommonStyling_text')]/rg-video//video/@src" },
                    { new Guid("60b89f59-38c1-4f5a-b501-1b0f0cc1e34c"), false, new Guid("040999fb-3f16-4a57-9217-7b89997f59e4"), "//meta[@property='og:video:url']/@content" },
                    { new Guid("813bdca9-b521-4b45-b7a9-8603e8aae87d"), false, new Guid("98c364dd-6bd7-41d2-93ae-5379edce6a56"), "//div[contains(@class='eagleplayer')]//video/@src" },
                    { new Guid("93a47e0b-acf3-4090-ab3f-d9656a6fddd5"), false, new Guid("79a6a983-d89f-4000-a249-9f9dbebaaa67"), "//div[@class='article__header']//div[@class='media__video']//video/@src" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_modified_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_modified_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("1580ad36-6c8b-45b1-8f4d-b57db21793b3"), "yyyy-MM-ddTHH:mm:ss.fff\"Z+0300\"", new Guid("79e4cdf5-0234-4de2-a574-7d1c470c1f90") },
                    { new Guid("22187f9e-c8d4-406f-874b-101b62e28c21"), "\"обновлено\" d MMMM, HH:mm", new Guid("696fa1e3-c92c-4c0a-b20f-ccf040433f50") },
                    { new Guid("45a01f2e-1f76-43db-98ec-f81fd89c4179"), "yyyy-MM-dd", new Guid("1e5ad485-4b9d-4924-8348-eacf1da89b9e") },
                    { new Guid("651c979f-1606-40ec-9de2-6a01cacc7d53"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("990e4245-9f31-4f10-b094-f953f3772d2b") },
                    { new Guid("8ce0efb1-f67b-4578-83a0-b21420f52c2d"), "\"обновлено\" HH:mm , dd.MM", new Guid("9351bba4-a932-491f-9391-02f8f605e842") },
                    { new Guid("be9789c1-2fdb-414b-b717-c3d8b522dbb2"), "\"обновлено\" d MMMM yyyy, HH:mm", new Guid("696fa1e3-c92c-4c0a-b20f-ccf040433f50") },
                    { new Guid("dcb1a095-a99e-47e1-9add-cf19cb5838ff"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("eeed95a4-41ad-487d-aee4-47d39893c1ac") },
                    { new Guid("e84ef184-ea16-42e3-9608-202226c5d55a"), "\"обновлено\" HH:mm , dd.MM.yyyy", new Guid("9351bba4-a932-491f-9391-02f8f605e842") },
                    { new Guid("f2154c43-3bb8-4aa4-971d-c1804a11b59f"), "(\"обновлено:\" HH:mm dd.MM.yyyy)", new Guid("3e966a3a-0a9d-4799-8082-91146fbf52e4") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_published_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("051eb6d0-737d-4398-b823-f82a66535705"), "d MMMM, HH:mm,", new Guid("b42707d5-39c2-497d-aed1-ff71f4400a4a") },
                    { new Guid("145a9cda-a49b-4b76-8db9-3205e941cc77"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("9c14a5db-958a-4038-93e1-acd479612d03") },
                    { new Guid("145cd059-79f1-4c13-bae2-0e4a4054bfc0"), "d MMMM, HH:mm", new Guid("16e4c71a-afd6-4d7f-806d-2f7f2836d32a") },
                    { new Guid("19fe0d2a-b526-4c33-9404-b653cc1035cc"), "d MMMM yyyy", new Guid("0eaa43d2-5aca-4fba-b6ed-7f9fb539f011") },
                    { new Guid("1bf03228-2b7f-4fa1-b90b-0a97159736a0"), "yyyy-MM-ddTHH:mm:ss", new Guid("f4f72b46-b950-4020-b541-9b391ee2eba7") },
                    { new Guid("1d911fd8-7764-4ea5-b608-5b893f2dd85b"), "yyyy-MM-dd HH:mm:ss", new Guid("5de72de4-ac1b-4a2f-9e3f-14b045cd5d7f") },
                    { new Guid("2c172ae5-24c2-467f-b2d7-4da9c1be4e2e"), "d MMMM yyyy, HH:mm", new Guid("8925789b-6d55-4da7-af90-271ac6e385be") },
                    { new Guid("33a9da1c-3dc9-4705-a33a-565b9764cdbf"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("6d8885af-3f33-476d-a8b9-d5fb76a0caa6") },
                    { new Guid("36b41e93-62bc-4c03-88dc-26143aafffb2"), "yyyy-MM-ddTHH:mm:ss", new Guid("3ad1e07c-b416-407a-abc8-6523563796bb") },
                    { new Guid("3fed4667-4045-414d-bc4d-96a6e4f7cc29"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("d66eb0fb-c215-4264-b24d-61bb8626ab25") },
                    { new Guid("43fc27b5-1815-40c3-a304-31acfb4b1b39"), "dd.MM.yyyy HH:mm", new Guid("578491b9-cd46-4220-aa17-2abdc8dfb41d") },
                    { new Guid("4a37577a-1cf7-4af3-9fb0-1732f51a4656"), "d MMMM, HH:mm", new Guid("b42707d5-39c2-497d-aed1-ff71f4400a4a") },
                    { new Guid("58bd0481-e970-42d0-b430-c3ed62c5d564"), "dd MMMM, HH:mm", new Guid("180cea56-629f-4a8e-9075-467629dd84e5") },
                    { new Guid("63dd5eb5-2a18-48a2-bf62-2dffad9e2250"), "d-M-yyyy HH:mm", new Guid("9be766b3-3a07-4515-b80e-5540618e5579") },
                    { new Guid("6c992d89-bfed-4336-a22f-66f808266f89"), "dd MMMM yyyy, HH:mm", new Guid("b9d9f08e-163b-4f89-8f51-94ef81b456a9") },
                    { new Guid("6dc0f8dd-0356-4bed-831c-f4e4125da0e4"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("41917dc3-c774-4f39-9d0a-c3f34f1c49e9") },
                    { new Guid("7098d9d6-4ba8-4b94-bf7c-4ca10de540b7"), "dd.MM.yyyy HH:mm", new Guid("d42ac2af-450a-4218-8e0a-8020e2e8f2e5") },
                    { new Guid("749513e8-ece2-48be-afaa-c4ff123c1a0e"), "dd.MM.yyyy HH:mm", new Guid("e6761364-f9c5-4a34-9456-dfdcfec0088a") },
                    { new Guid("780f7d56-d464-471b-96e4-b41504ae511f"), "d MMMM yyyy \"в\" HH:mm", new Guid("2b5d104e-b947-4bb3-87dd-fdfd8f692979") },
                    { new Guid("7feb3c1e-005c-42dc-9bd4-63cc700938db"), "yyyy-MM-dd", new Guid("7d88e14e-aaa6-4266-bf74-9c7a1bb5cbac") },
                    { new Guid("8c7824a3-a268-49fb-9e2d-ec381e0724c0"), "HH:mm dd.MM.yyyy", new Guid("b6002f63-982d-4f3d-9205-b8b55cd414e1") },
                    { new Guid("956cc7f9-b510-4dad-a0ac-7a8e7d53e238"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("8ff0dbec-a22b-4c71-8b5c-c37755d0f12c") },
                    { new Guid("9834c1af-1b20-40f7-b239-65cdbf5cb02e"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("093dd227-035b-4fd4-bee5-0665bff5fc1e") },
                    { new Guid("99cb5e56-8a30-4889-86c0-c9b55e7031e9"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("76126ca7-2a7a-4db9-a08b-92fec11e3d99") },
                    { new Guid("9da37442-df68-4a7b-ae0d-caa6356ff7e3"), "yyyy-MM-ddTHH:mm:ss.fff\"Z+0300\"", new Guid("3148d71a-c773-4d12-8748-0dedba93399d") },
                    { new Guid("a1aae896-b01d-45ee-8e1b-18a4ee774980"), "yyyy-MM-ddTHH:mm:ss.fffZ", new Guid("733b12d7-ac6e-4da1-a2a1-36f66b947aad") },
                    { new Guid("a6be8f77-b029-43e2-9847-d4ae5af661b4"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("cd1af0db-3664-4349-acda-bf32931ecc43") },
                    { new Guid("b4280ff4-47a6-466b-8e69-edc2ed11a276"), "d MMMM yyyy, HH:mm", new Guid("b42707d5-39c2-497d-aed1-ff71f4400a4a") },
                    { new Guid("ba070ff9-8e53-4c2c-8921-0cc4367a9bc4"), "HH:mm", new Guid("180cea56-629f-4a8e-9075-467629dd84e5") },
                    { new Guid("bd5c78f2-01bd-43be-86d5-be2dff79ff8e"), "yyyy-MM-dd HH:mm", new Guid("5ba365f4-fda1-44d8-87c0-3823cf75c22c") },
                    { new Guid("caf30c88-aae9-4a79-bf31-d56e76eba88a"), "d MMMM yyyy, HH:mm,", new Guid("b42707d5-39c2-497d-aed1-ff71f4400a4a") },
                    { new Guid("cc1c444e-d6e5-4aa3-aeee-4394a214d7df"), "dd MMMM yyyy, HH:mm", new Guid("180cea56-629f-4a8e-9075-467629dd84e5") },
                    { new Guid("d6e5bf87-c26d-40a5-80de-5d1da638f901"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("5e8586cd-9507-471a-8226-f5453227f567") },
                    { new Guid("dd6f3ac9-fd35-4fdd-b100-2328ccc037a1"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("56227131-1423-4085-893e-1eeaf20b135d") },
                    { new Guid("e1736e52-f387-41dc-8810-8e501d2ec5b2"), "\"Published\n       \" HH:mm tt \"EST\", ddd MMMM d, yyyy", new Guid("70c828a4-cad1-4d11-bf70-d229df855634") },
                    { new Guid("e319d94e-3b3a-4c9e-951b-d1fd4ed73919"), "yyyy-MM-d HH:mm", new Guid("f6000f3b-d1cf-4a94-ad3c-95c861c33318") },
                    { new Guid("e3783be2-3f98-4d03-bc5e-e3904f4dbf9a"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("a9087884-5df5-4a06-8c14-18fd6301b8bd") },
                    { new Guid("e7387134-5077-4289-9b2e-03aa699d02a3"), "HH:mm, d MMMM yyyy", new Guid("46a3b890-8d49-4b01-8cfb-5164c6d23907") },
                    { new Guid("ebcc3ba0-b193-4efd-93c8-6402eedc6d4f"), "d MMMM yyyy, HH:mm", new Guid("16e4c71a-afd6-4d7f-806d-2f7f2836d32a") },
                    { new Guid("f10ff74e-9f64-48b1-95c1-af562fc86b80"), "HH:mm", new Guid("5b33d981-cc3c-43d7-80be-0d20d9a77d88") },
                    { new Guid("f7320dd7-5693-4220-94e4-3ce711963189"), "d MMMM yyyy HH:mm", new Guid("1aa198e2-9fde-405a-a7b7-3b4cea79f8f1") },
                    { new Guid("fbb6d761-591d-4318-986d-a377a94a6d91"), "dd MMMM yyyy HH:mm", new Guid("5b33d981-cc3c-43d7-80be-0d20d9a77d88") },
                    { new Guid("fdedc040-60b2-4d16-84b8-be76e4aa5481"), "d MMMM yyyy, HH:mm \"МСК\"", new Guid("6f045096-2d14-4121-bf74-5b474cc26699") },
                    { new Guid("fe650010-7a8c-4062-b893-2dddc9888f64"), "d MMMM  HH:mm", new Guid("1aa198e2-9fde-405a-a7b7-3b4cea79f8f1") }
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
