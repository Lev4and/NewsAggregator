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
                    { new Guid("01d104fc-d148-4320-b02b-3be781863a3d"), true, "https://ura.news/", "Ura.ru" },
                    { new Guid("05050d03-9ae2-42b4-96b6-38efcdfd60cd"), true, "https://www.belta.by/", "БелТА" },
                    { new Guid("08eab921-8e96-4bbe-a2c8-1f42695cd810"), true, "https://www.ixbt.com/", "iXBT.com" },
                    { new Guid("0fdbb2af-4c70-4348-a96d-d629c5e25a73"), true, "https://ixbt.games/", "iXBT.games" },
                    { new Guid("2c4f2081-79f4-42ae-aa1f-ca8bd38d0a65"), true, "https://life.ru/", "Life" },
                    { new Guid("40ddd749-69ca-4291-8397-036bed0dc24a"), true, "https://rg.ru/", "Российская газета" },
                    { new Guid("476b1cca-8c27-42f3-aa3f-3fb766f20257"), true, "https://ria.ru/", "РИА Новости" },
                    { new Guid("4e17a164-7981-4f8e-bd32-b389c2253f7b"), true, "https://lenta.ru/", "Лента.Ру" },
                    { new Guid("5217bf6b-ed90-45ba-9af5-c7b93b21662b"), true, "https://vz.ru/", "ВЗГЛЯД.РУ" },
                    { new Guid("5ea50de1-1a7c-4425-b957-f980031cf142"), true, "https://www.1obl.ru/", "Первый областной" },
                    { new Guid("67f9c437-142a-4590-9c54-f4fd0dcd62fd"), true, "https://www.cybersport.ru/", "Cybersport.ru" },
                    { new Guid("694293b2-ab85-4df1-9ebd-97b11db40d00"), true, "https://www.m24.ru/", "Москва 24" },
                    { new Guid("6b6548aa-7519-4b9d-a28d-2ec3f8390b9d"), true, "https://russian.rt.com/", "RT на русском" },
                    { new Guid("70db3a25-3dda-4c90-9415-45aa2bb3786b"), true, "https://iz.ru/", "Известия" },
                    { new Guid("79a1c30b-491b-4a16-82ca-5df01840d4df"), true, "https://svpressa.ru/", "СвободнаяПресса" },
                    { new Guid("8ef814ea-b385-4961-877f-616465489d12"), true, "https://www.championat.com/", "Чемпионат.com" },
                    { new Guid("952bcdd9-31c1-445c-8e6f-e8840fe66582"), true, "https://www.hltv.org/", "HLTV.org" },
                    { new Guid("98b37d57-098e-4adc-a755-453c524c1285"), true, "https://www.gazeta.ru/", "Газета.Ru" },
                    { new Guid("9cb57cb6-a9aa-475a-af36-b298ad44f4ed"), true, "https://edition.cnn.com/", "CNN" },
                    { new Guid("a10ff3ae-ba0d-4403-aa81-7fe4888192d2"), true, "https://www.rbc.ru/", "РБК" },
                    { new Guid("b53f72d7-3e6c-4775-907f-6fec19a69bbf"), true, "https://www.kommersant.ru/", "Коммерсантъ" },
                    { new Guid("bca69b6a-09a2-4924-b30a-6441f897c927"), true, "https://74.ru/", "74.ru" },
                    { new Guid("bf001fe5-1726-49b9-9a5b-1eee7fa4a68d"), true, "https://3dnews.ru/", "3Dnews.ru" },
                    { new Guid("c3cc1487-1760-49bf-a872-31bb14e82482"), true, "https://tass.ru/", "ТАСС" },
                    { new Guid("d65e36c7-50e8-48ce-bfd3-51377f584bdc"), true, "https://aif.ru/", "Аргументы и факты" },
                    { new Guid("db88042d-a75f-42d5-81c2-82941af0582a"), true, "https://www.sports.ru/", "Storts.ru" },
                    { new Guid("e92c3e10-4d52-41c9-a929-7ecab78d7f33"), true, "https://tsargrad.tv/", "Царьград" },
                    { new Guid("f2988ea9-8126-41c6-b883-73489581e830"), true, "https://www.nytimes.com/", "The New York Times" },
                    { new Guid("f450828e-ee83-4773-9294-ee5047cc43c2"), true, "https://www.pravda.ru/", "Правда.ру" },
                    { new Guid("fc2ba994-7933-46bb-872e-3037acf09f33"), true, "https://www.interfax.ru/", "Интерфакс" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_settings",
                columns: new[] { "id", "description_x_path", "source_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("088e6c62-9c69-45e0-9f2c-e71191bcab16"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview'))]", new Guid("a10ff3ae-ba0d-4403-aa81-7fe4888192d2"), "//h1/text()" },
                    { new Guid("0d476cb0-495d-4849-8067-27f8f8b2fa33"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]", new Guid("b53f72d7-3e6c-4775-907f-6fec19a69bbf"), "//h1/text()" },
                    { new Guid("135fd3e7-619d-401b-b4fa-37b42737d76a"), "//div[contains(@class, 'PageContentCommonStyling_text')]", new Guid("40ddd749-69ca-4291-8397-036bed0dc24a"), "//h1/text()" },
                    { new Guid("1670bd43-36de-487d-9e75-2ab62abe1ae8"), "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]", new Guid("694293b2-ab85-4df1-9ebd-97b11db40d00"), "//h1/text()" },
                    { new Guid("2cd2a6b9-dac0-493a-afc9-aecc3204bb22"), "//div[contains(@class, 'news-item__content')]", new Guid("db88042d-a75f-42d5-81c2-82941af0582a"), "//h1/text()" },
                    { new Guid("36d58463-243a-4078-bf7f-31a4f8dd3b7e"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()>1]", new Guid("bf001fe5-1726-49b9-9a5b-1eee7fa4a68d"), "//h1/text()" },
                    { new Guid("4a6e9be9-505f-4e53-8116-986243d3e3ec"), "//div[@class='article_text']", new Guid("d65e36c7-50e8-48ce-bfd3-51377f584bdc"), "//h1/text()" },
                    { new Guid("582d8633-b699-484b-818c-d37ffc21aad3"), "//div[contains(@class, 'container-fluid shifted') and not(p[@class='announce lead']) and not(h1) and not(hr)]", new Guid("0fdbb2af-4c70-4348-a96d-d629c5e25a73"), "//h1/text()" },
                    { new Guid("5fe78e0c-dfec-4ddc-aaab-2edfa8d3f15f"), "//article//div[@class='newstext-con']/*[position()>2]", new Guid("952bcdd9-31c1-445c-8e6f-e8840fe66582"), "//h1[@class='headline']/text()" },
                    { new Guid("629d5be2-8e64-4b7d-9e9c-62226dab1a8d"), "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]", new Guid("2c4f2081-79f4-42ae-aa1f-ca8bd38d0a65"), "//h1/text()" },
                    { new Guid("655c4fae-a8de-4805-9403-4d6130a823cf"), "//div[@class='js-mediator-article']", new Guid("05050d03-9ae2-42b4-96b6-38efcdfd60cd"), "//h1/text()" },
                    { new Guid("6a606189-dd29-4baa-8326-8cf946711f3a"), "//div[@itemprop='articleBody']/*", new Guid("5ea50de1-1a7c-4425-b957-f980031cf142"), "//h1[@itemprop='headline']/text()" },
                    { new Guid("703ef2a6-ea52-4f76-bf99-6483201fd307"), "//div[contains(@class, 'js-mediator-article')]/*[position()>1]", new Guid("67f9c437-142a-4590-9c54-f4fd0dcd62fd"), "//h1/text()" },
                    { new Guid("73f3ba13-7f45-4c2c-bdb6-3305153e6780"), "//div[contains(@class, 'article__text ')]", new Guid("6b6548aa-7519-4b9d-a28d-2ec3f8390b9d"), "//h1/text()" },
                    { new Guid("74fba5ff-b002-487d-adf6-a663ac6aebdd"), "//div[@itemprop='articleBody']/*[not(name() = 'figure')]", new Guid("bca69b6a-09a2-4924-b30a-6441f897c927"), "//h1[@itemprop='headline']/span/text()" },
                    { new Guid("7f1b4b5c-69c7-4ac3-8234-53d8182cba11"), "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]", new Guid("f450828e-ee83-4773-9294-ee5047cc43c2"), "//h1/text()" },
                    { new Guid("8ef23ca4-bd72-4d52-b6e7-19f95b637d7b"), "//div[@itemprop='articleBody']/*", new Guid("9cb57cb6-a9aa-475a-af36-b298ad44f4ed"), "//h1/text()" },
                    { new Guid("925f8f8e-6297-4e74-a8f2-726177da02ff"), "//article/*", new Guid("c3cc1487-1760-49bf-a872-31bb14e82482"), "//h1/text()" },
                    { new Guid("a2fe2851-26d4-4c23-a035-05022a43a944"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]", new Guid("e92c3e10-4d52-41c9-a929-7ecab78d7f33"), "//h1[@class='article__title']/text()" },
                    { new Guid("a5b15f94-5d87-4e5e-8f2e-256dd8e4338b"), "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]", new Guid("79a1c30b-491b-4a16-82ca-5df01840d4df"), "//h1[@class='b-text__title']/text()" },
                    { new Guid("a92a297e-eb0b-41bc-a138-dcfc69d82ec6"), "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]", new Guid("fc2ba994-7933-46bb-872e-3037acf09f33"), "//h1/text()" },
                    { new Guid("ae4f5b30-485b-447d-b582-20869b936a02"), "//div[@itemprop='articleBody']/*", new Guid("98b37d57-098e-4adc-a755-453c524c1285"), "//h1/text()" },
                    { new Guid("b183f5de-0fbf-410f-8f15-941a4ffc4539"), "//div[@itemprop='articleBody']/*", new Guid("08eab921-8e96-4bbe-a2c8-1f42695cd810"), "//h1/text()" },
                    { new Guid("b1ec7fe4-421c-4425-9e43-94456f06a614"), "//section[@name='articleBody']/*", new Guid("f2988ea9-8126-41c6-b883-73489581e830"), "//h1/text()" },
                    { new Guid("bdfae62e-79cd-4780-99e2-e3b76b884588"), "//div[@itemprop='articleBody']/*", new Guid("70db3a25-3dda-4c90-9415-45aa2bb3786b"), "//h1/span/text()" },
                    { new Guid("c3b68972-e113-4a84-a5f3-bc7168749912"), "//div[@class='topic-body__content']", new Guid("4e17a164-7981-4f8e-bd32-b389c2253f7b"), "//h1[@class='topic-body__titles']/span[@class='topic-body__title']/text()" },
                    { new Guid("e19e5962-6786-4c4b-9433-f079005d547a"), "//div[contains(@class, 'article__body')]", new Guid("476b1cca-8c27-42f3-aa3f-3fb766f20257"), "//div[@class='article__title']/text()" },
                    { new Guid("e7e2cfbe-ea6c-4970-8128-1dd6ea3c9c80"), "//article/div[@class='news_text']", new Guid("5217bf6b-ed90-45ba-9af5-c7b93b21662b"), "//h1/text()" },
                    { new Guid("edc7334a-2eb9-416c-8764-d45f2618827b"), "//article/div[@class='article-content']/*[not(@class)]", new Guid("8ef814ea-b385-4961-877f-616465489d12"), "//article/header/div[@class='article-head__title']/text()" },
                    { new Guid("ff521c54-8939-4d86-86bd-fa3420dd41e2"), "//div[@itemprop='articleBody']/*[not(name()='div')]", new Guid("01d104fc-d148-4320-b02b-3be781863a3d"), "//h1/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_search_settings",
                columns: new[] { "id", "news_site_url", "news_url_x_path", "source_id" },
                values: new object[,]
                {
                    { new Guid("07513001-c649-4a15-9819-1123c723103e"), "https://www.belta.by/", "//a[contains(@href, 'https://www.belta.by/') and contains(@href, '/view/')]/@href", new Guid("05050d03-9ae2-42b4-96b6-38efcdfd60cd") },
                    { new Guid("0a69c2cc-9fb4-491d-9c27-ee354af2749a"), "https://ria.ru/", "//a[contains(@class, 'cell-list__item-link')]/@href", new Guid("476b1cca-8c27-42f3-aa3f-3fb766f20257") },
                    { new Guid("1f23ac5c-685e-40a9-9e8d-b0d59ce037e9"), "https://ura.news/", "//a[contains(@href, '/news/')]/@href", new Guid("01d104fc-d148-4320-b02b-3be781863a3d") },
                    { new Guid("1f24b6ac-b3b2-4596-a66e-587788661f28"), "https://www.ixbt.com/news/", "//a[starts-with(@href, '/news/') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("08eab921-8e96-4bbe-a2c8-1f42695cd810") },
                    { new Guid("2518521d-c6aa-4d12-a7b4-981042020255"), "https://74.ru/", "//a[starts-with(@href, '/text/') and not(contains(@href, '?')) and not(contains(@href, 'comments/')) and not(@href='/text/')]/@href", new Guid("bca69b6a-09a2-4924-b30a-6441f897c927") },
                    { new Guid("26e63c33-1790-4b6e-a7a9-4ec81dfa4a14"), "https://www.m24.ru/", "//a[contains(@href, '/news/')]/@href", new Guid("694293b2-ab85-4df1-9ebd-97b11db40d00") },
                    { new Guid("2dfd8191-12bf-400d-92d0-1f814fbe4535"), "https://rg.ru/", "//a[contains(@href, '.html')]/@href", new Guid("40ddd749-69ca-4291-8397-036bed0dc24a") },
                    { new Guid("46f82d14-ca51-4fbd-9575-f9a5e5eec5fa"), "https://www.pravda.ru/", "//a[contains(@href, '/news/') and not(@href='https://www.pravda.ru/news/')]/@href", new Guid("f450828e-ee83-4773-9294-ee5047cc43c2") },
                    { new Guid("4b4dc83b-42e3-4254-89cc-7f2f0e843aee"), "https://www.sports.ru/news/", "//a[contains(@href, '.html') and not(contains(@href, '.html#comments')) and not (contains(@href, '/blogs/'))]/@href", new Guid("db88042d-a75f-42d5-81c2-82941af0582a") },
                    { new Guid("531bc5a8-5078-4791-81f2-ecae9e4035f2"), "https://www.kommersant.ru/", "//a[contains(@href, '/doc/') and contains(@href, '?from=')]/@href", new Guid("b53f72d7-3e6c-4775-907f-6fec19a69bbf") },
                    { new Guid("583801a7-5f6b-4034-93d5-2c22cda3ac17"), "https://www.championat.com/news/1.html?utm_source=button&utm_medium=news", "//a[contains(@href, 'news-') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("8ef814ea-b385-4961-877f-616465489d12") },
                    { new Guid("6073c99f-7c29-43c0-b4b6-0893f8be67e7"), "https://tsargrad.tv/", "//a[contains(@class, 'news-item__link')]/@href", new Guid("e92c3e10-4d52-41c9-a929-7ecab78d7f33") },
                    { new Guid("616f9d15-5bd7-4272-8f15-435b0f4bd7a8"), "https://www.cybersport.ru/", "//a[contains(@href, '/tags/')]/@href", new Guid("67f9c437-142a-4590-9c54-f4fd0dcd62fd") },
                    { new Guid("6368132c-6adc-4e69-9f21-8ae90798f1e4"), "https://ixbt.games/news/", "//a[@class='card-link']/@href", new Guid("0fdbb2af-4c70-4348-a96d-d629c5e25a73") },
                    { new Guid("6ed2ce0a-53f2-4307-a4b0-98765ae43422"), "https://russian.rt.com/", "//a[contains(@class, 'link') and contains(@href, 'news/')]/@href", new Guid("6b6548aa-7519-4b9d-a28d-2ec3f8390b9d") },
                    { new Guid("75198d04-41dd-4282-9cb7-c409a2de2a32"), "https://tass.ru/", "//a[contains(@class, 'tass_pkg_link-v5WdK') and contains(substring(@href, 2), '/') and not(contains(@href, '/spec/')) and not(contains(@href, 'spec.tass.ru'))]/@href", new Guid("c3cc1487-1760-49bf-a872-31bb14e82482") },
                    { new Guid("7816009a-245a-41c3-9748-bd4d76ed46a3"), "https://svpressa.ru/all/news/", "//a[contains(@href, '/news/') and not(contains(@href, '?')) and not(starts-with(@href, '/all/news/'))]/@href", new Guid("79a1c30b-491b-4a16-82ca-5df01840d4df") },
                    { new Guid("85ebd251-b253-4296-912d-19d16fa68f8d"), "https://life.ru/s/novosti", "//a[contains(@href, '/p/')]/@href", new Guid("2c4f2081-79f4-42ae-aa1f-ca8bd38d0a65") },
                    { new Guid("94826592-6846-47a1-b76f-64e05cb3c817"), "https://www.rbc.ru/", "//a[contains(@href, 'https://www.rbc.ru/') and contains(@href, '?from=')]/@href", new Guid("a10ff3ae-ba0d-4403-aa81-7fe4888192d2") },
                    { new Guid("9e298968-d13d-4017-b7f8-76bd533fac35"), "https://edition.cnn.com/", "//a[contains(@href, '.html')]/@href", new Guid("9cb57cb6-a9aa-475a-af36-b298ad44f4ed") },
                    { new Guid("b1053fe1-82d4-46b7-905c-76b67d44791d"), "https://www.hltv.org/", "//a[contains(@href, '/news/')]/@href", new Guid("952bcdd9-31c1-445c-8e6f-e8840fe66582") },
                    { new Guid("b3e14653-610e-434b-b536-8d5a026a684d"), "https://lenta.ru/", "//a[starts-with(@href, '/news/')]/@href", new Guid("4e17a164-7981-4f8e-bd32-b389c2253f7b") },
                    { new Guid("c4609472-c33e-48bb-8fe9-ed05124815b6"), "https://iz.ru/news/", "//a[contains(@href, '?main_click')]/@href", new Guid("70db3a25-3dda-4c90-9415-45aa2bb3786b") },
                    { new Guid("cb43afad-cda1-40cb-8674-8c762f8a66af"), "https://www.1obl.ru/news/", "//a[starts-with(@href, '/news/') and not(contains(@href, '?'))]/@href", new Guid("5ea50de1-1a7c-4425-b957-f980031cf142") },
                    { new Guid("ccd83cac-9b22-4837-a17d-be8a366bfa17"), "https://vz.ru/", "//a[contains(@href, '.html') and not(contains(@href, '#comments')) and not(contains(@href, '?')) and not(contains(@href, '/about/'))]/@href", new Guid("5217bf6b-ed90-45ba-9af5-c7b93b21662b") },
                    { new Guid("ccf4d458-f0e8-457d-a219-e74250e7df28"), "https://aif.ru/", "//span[contains(@class, 'item_text__title')]/../@href", new Guid("d65e36c7-50e8-48ce-bfd3-51377f584bdc") },
                    { new Guid("d465fcad-f9fd-4d02-99f1-54ff6909a8a1"), "https://www.nytimes.com/", "//a[contains(@href, '.html')]/@href", new Guid("f2988ea9-8126-41c6-b883-73489581e830") },
                    { new Guid("dbba3df8-ee0d-4733-950c-933496d1a9be"), "https://www.interfax.ru/", "//div[@class='timeline']//a[@tabindex=5]/@href", new Guid("fc2ba994-7933-46bb-872e-3037acf09f33") },
                    { new Guid("e8a9ea35-8755-45dc-9bd5-8ae5b2f27ef5"), "https://www.gazeta.ru/news/", "//a[contains(@href, '/news/') and contains(@href, '.shtml') and not(contains(@href, '?'))]/@href", new Guid("98b37d57-098e-4adc-a755-453c524c1285") },
                    { new Guid("ffdef01c-4105-4175-916b-8823da38c05e"), "https://3dnews.ru/news/", "//div[@class='news-feed-all']//a[@class='entry-header']/h1/../@href", new Guid("bf001fe5-1726-49b9-9a5b-1eee7fa4a68d") }
                });

            migrationBuilder.InsertData(
                table: "news_source_logos",
                columns: new[] { "id", "original", "small", "source_id" },
                values: new object[,]
                {
                    { new Guid("05bbfd29-eb26-491b-bd8b-4d6d6ac4e87a"), "https://im.kommersant.ru/ContentFlex/images/favicons2020/apple-touch-icon-180.png", "https://im.kommersant.ru/ContentFlex/images/favicons2020/favicon-32.png", new Guid("b53f72d7-3e6c-4775-907f-6fec19a69bbf") },
                    { new Guid("075a7da2-cc63-43f9-8a5b-6e3f21355692"), "https://www.pravda.ru/pix/apple-touch-icon.png", "https://www.pravda.ru/favicon.ico", new Guid("f450828e-ee83-4773-9294-ee5047cc43c2") },
                    { new Guid("0eb373ca-0851-4da4-adc1-a2c469c6ac96"), "https://tsargrad.tv/favicons/apple-touch-icon-180x180.png?s2", "https://tsargrad.tv/favicons/favicon-32x32.png?s2", new Guid("e92c3e10-4d52-41c9-a929-7ecab78d7f33") },
                    { new Guid("1a295e05-d4a2-41e2-92b4-1a5d1e1b3a55"), "https://cdnstatic.rg.ru/images/touch-icon-ipad-retina_512x512.png", "https://rg.ru/favicon.ico", new Guid("40ddd749-69ca-4291-8397-036bed0dc24a") },
                    { new Guid("30933afb-0723-46dd-8d85-54882614299f"), "https://www.cybersport.ru/favicon-192x192.png", "https://www.cybersport.ru/favicon-32x32.png", new Guid("67f9c437-142a-4590-9c54-f4fd0dcd62fd") },
                    { new Guid("361455f7-a1ec-492b-a550-5edbe8e61201"), "https://svpressa.ru/favicon-96x96.png?v=1471426270000", "https://svpressa.ru/favicon-32x32.png?v=1471426270000", new Guid("79a1c30b-491b-4a16-82ca-5df01840d4df") },
                    { new Guid("3c98ff44-5694-4e9b-bc83-3eea799e1a7d"), "https://cdn.iz.ru/profiles/portal/themes/purple/images/favicons/android-icon-192x192.png", "https://cdn.iz.ru/profiles/portal/themes/purple/images/favicons/favicon-32x32.png", new Guid("70db3a25-3dda-4c90-9415-45aa2bb3786b") },
                    { new Guid("47133328-2203-4a09-84b0-756b6e6a897d"), "https://ixbt.games/images/favicon/gt/apple-touch-icon.png", "https://ixbt.games/images/favicon/gt/apple-touch-icon.png", new Guid("0fdbb2af-4c70-4348-a96d-d629c5e25a73") },
                    { new Guid("4873de85-959c-466e-b3e4-67edda0fdc0b"), "https://static.ngs.ru/jtnews/dist/static/favicons/apple/apple-favicon-74-180.png", "https://static.ngs.ru/jtnews/dist/static/favicons/favicon-rugion-32.ico", new Guid("bca69b6a-09a2-4924-b30a-6441f897c927") },
                    { new Guid("4b3a65dc-ade8-4ee0-99f6-e4af93cb4238"), "https://ura.news/apple-touch-icon.png", "https://s.ura.news/favicon.ico?3", new Guid("01d104fc-d148-4320-b02b-3be781863a3d") },
                    { new Guid("51f6e9f7-2f5a-4b8d-8e1a-928218b4d239"), "https://www.belta.by/images/storage/banners/000016_a133e848cb2e7b1debb7102d19e4d139_work.svg", "https://www.belta.by/images/storage/banners/000016_a133e848cb2e7b1debb7102d19e4d139_work.svg", new Guid("05050d03-9ae2-42b4-96b6-38efcdfd60cd") },
                    { new Guid("5474b978-0381-4a6f-832d-091912c22a3f"), "https://www.ixbt.com/favicon.ico", "https://www.ixbt.com/favicon.ico", new Guid("08eab921-8e96-4bbe-a2c8-1f42695cd810") },
                    { new Guid("62a401bd-5b7f-4a77-8f91-2e9f41c1e03d"), "https://static.gazeta.ru/nm2021/img/icons/favicon.svg", "https://static.gazeta.ru/nm2021/img/icons/favicon.svg", new Guid("98b37d57-098e-4adc-a755-453c524c1285") },
                    { new Guid("67bf4169-2248-4e48-b5f0-c6d571a75b16"), "https://edition.cnn.com/media/sites/cnn/apple-touch-icon.png", "https://edition.cnn.com/media/sites/cnn/favicon.ico", new Guid("9cb57cb6-a9aa-475a-af36-b298ad44f4ed") },
                    { new Guid("694f2cf3-0964-47f9-9504-30cad127b7bc"), "https://www.nytimes.com/vi-assets/static-assets/apple-touch-icon-28865b72953380a40aa43318108876cb.png", "https://www.nytimes.com/vi-assets/static-assets/ios-default-homescreen-57x57-dark-b395ebcad5b63aff9285aab58e31035e.png", new Guid("f2988ea9-8126-41c6-b883-73489581e830") },
                    { new Guid("80323fd9-b8fa-43ba-a223-759d2456d4d0"), "https://cdnn21.img.ria.ru/i/favicons/favicon.svg", "https://cdnn21.img.ria.ru/i/favicons/favicon.ico", new Guid("476b1cca-8c27-42f3-aa3f-3fb766f20257") },
                    { new Guid("80864647-9f53-4774-a48f-ee2d74b4dee7"), "https://tass.ru/favicon/180.svg", "https://tass.ru/favicon/57.png", new Guid("c3cc1487-1760-49bf-a872-31bb14e82482") },
                    { new Guid("89bf19db-6821-495c-b23f-996ba44ca8d2"), "https://life.ru/appletouch/apple-icon-180%D1%85180.png", "https://life.ru/favicon-32%D1%8532.png", new Guid("2c4f2081-79f4-42ae-aa1f-ca8bd38d0a65") },
                    { new Guid("8af2989d-c250-40d5-b34b-b7178785c8ae"), "https://aif.ru/img/icon/apple-touch-icon.png?44f", "https://aif.ru/img/icon/favicon-32x32.png?44f", new Guid("d65e36c7-50e8-48ce-bfd3-51377f584bdc") },
                    { new Guid("925e4518-1e81-4514-b0bc-26db97a52504"), "https://www.interfax.ru/touch-icon-ipad-retina.png", "https://www.interfax.ru/touch-icon-iphone.png", new Guid("fc2ba994-7933-46bb-872e-3037acf09f33") },
                    { new Guid("9526ec3a-3e80-44c2-ab95-23da0b3ed33e"), "https://russian.rt.com/static/blocks/touch-icon/apple-touch-icon-144x144-precomposed.png", "https://russian.rt.com/favicon.ico", new Guid("6b6548aa-7519-4b9d-a28d-2ec3f8390b9d") },
                    { new Guid("a39a891b-714d-4793-8428-395292be999b"), "https://www.m24.ru/img/fav/apple-touch-icon.png", "https://www.m24.ru/img/fav/favicon-32x32.png", new Guid("694293b2-ab85-4df1-9ebd-97b11db40d00") },
                    { new Guid("a8a1f1a8-e2ba-4d04-9932-6f81929f1811"), "https://www.hltv.org/img/static/favicon/apple-touch-icon.png", "https://www.hltv.org/img/static/favicon/favicon-32x32.png", new Guid("952bcdd9-31c1-445c-8e6f-e8840fe66582") },
                    { new Guid("bed45923-c351-4bf1-823c-86879f4e1bea"), "https://3dnews.ru/assets/images/3dnews_logo_soc.png", "https://3dnews.ru/assets/3dnews_logo_color.png", new Guid("bf001fe5-1726-49b9-9a5b-1eee7fa4a68d") },
                    { new Guid("c4bfc0e6-4409-4369-8212-aa8d1e079ce6"), "https://www.sports.ru/apple-touch-icon-1024.png", "https://www.sports.ru/apple-touch-icon-76.png", new Guid("db88042d-a75f-42d5-81c2-82941af0582a") },
                    { new Guid("d5d7e515-25b6-40e1-8589-30a5ea60d202"), "https://s.rbk.ru/v10_rbcnews_static/common/common-10.10.120/images/android-chrome-512x512.png", "https://s.rbk.ru/v10_rbcnews_static/common/common-10.10.120/images/favicon.png", new Guid("a10ff3ae-ba0d-4403-aa81-7fe4888192d2") },
                    { new Guid("d7ed0812-475a-4a18-a13e-92f631804646"), "https://icdn.lenta.ru/images/icons/icon-256x256.png", "https://icdn.lenta.ru/favicon.ico", new Guid("4e17a164-7981-4f8e-bd32-b389c2253f7b") },
                    { new Guid("db395080-bad2-4507-9543-3e6d6b55dc77"), "https://vz.ru/apple-touch-icon.png", "https://vz.ru/static/images/favicon.ico", new Guid("5217bf6b-ed90-45ba-9af5-c7b93b21662b") },
                    { new Guid("ed5b281f-8f44-462a-822f-ce9f5a963743"), "https://www.1obl.ru/apple-touch-icon.png", "https://www.1obl.ru/favicon-32x32.png", new Guid("5ea50de1-1a7c-4425-b957-f980031cf142") },
                    { new Guid("f6083181-810c-40b9-a63b-d88bc408ed3f"), "https://st.championat.com/i/favicon/apple-touch-icon.png", "https://st.championat.com/i/favicon/favicon-32x32.png", new Guid("8ef814ea-b385-4961-877f-616465489d12") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_editor_settings",
                columns: new[] { "id", "is_required", "name_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("00449553-df9b-420a-9cc8-131aed7e6b41"), false, "//div[@class='author']/span[@itemprop='author']/span[@itemprop='name']/a/text()", new Guid("ae4f5b30-485b-447d-b582-20869b936a02") },
                    { new Guid("1ca8d9f4-8873-471e-8e1c-bc530efaede9"), false, "//div[@itemprop='author']//p[@itemprop='name']/text()", new Guid("74fba5ff-b002-487d-adf6-a663ac6aebdd") },
                    { new Guid("390a34a4-b68d-458d-94ca-79d6cd556e11"), true, "//footer[@class='news-item__footer']/div[@class='news-item__footer-after-news']/p[position()=1]//span/text()", new Guid("2cd2a6b9-dac0-493a-afc9-aecc3204bb22") },
                    { new Guid("4339d9a5-ccee-40e6-a6e6-7ac425a09158"), true, "//div[@itemprop='author']/span[@itemprop='name']/text()", new Guid("ff521c54-8939-4d86-86bd-fa3420dd41e2") },
                    { new Guid("49586a19-9feb-4a5a-a43f-910c5dac0350"), false, "//p[@class='doc__text document_authors']/text()", new Guid("0d476cb0-495d-4849-8067-27f8f8b2fa33") },
                    { new Guid("4e0bea88-c0bb-49a5-a0aa-262e8ca018fc"), true, "//div[@class='headline__footer']//div[@class='byline__names']/span[@class='byline__name']/text()", new Guid("8ef23ca4-bd72-4d52-b6e7-19f95b637d7b") },
                    { new Guid("53b66340-084c-4f6f-809f-3b84252d99e2"), true, "//span[@itemprop='author']/span[@itemprop='name']/@content", new Guid("b183f5de-0fbf-410f-8f15-941a4ffc4539") },
                    { new Guid("5a28dc95-0ee4-42ac-bd88-59edfc6ed070"), true, "//div[@class='container-fluid publication-footer']//a[contains(@class, 'text-secondary')]/@title", new Guid("582d8633-b699-484b-818c-d37ffc21aad3") },
                    { new Guid("61442059-884b-4da5-b118-3c94062e6539"), true, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']//a[@itemprop='author']//span[@itemprop='name']/text()", new Guid("36d58463-243a-4078-bf7f-31a4f8dd3b7e") },
                    { new Guid("61c805e0-1cd8-430d-9e56-2828c3145cc1"), true, "//div[@class='article_top']//div[@class='authors']//div[@class='autor']//span/text()", new Guid("4a6e9be9-505f-4e53-8116-986243d3e3ec") },
                    { new Guid("65e8b6db-eca3-4bca-8c97-f591ee135360"), true, "//div[contains(@class, 'PageArticleContent_authors')]//a[contains(@class, 'LinksOfAuthor_item')]/text()", new Guid("135fd3e7-619d-401b-b4fa-37b42737d76a") },
                    { new Guid("699d9861-5bfe-4dc9-b753-edf83e137c1a"), true, "//div[contains(@class, 'full-article')]/div[@class='authors-block']//span[text()='Автор']/../a/text()", new Guid("7f1b4b5c-69c7-4ac3-8234-53d8182cba11") },
                    { new Guid("a9101cd1-6f56-40b7-b883-a61c99c350e5"), true, "//div[contains(@class, 'styles_bodyWrapper')]//div[contains(@class, 'styles_authorsLinks')]/a/text()", new Guid("629d5be2-8e64-4b7d-9e9c-62226dab1a8d") },
                    { new Guid("ab08aa89-5af9-46ee-9bc8-e91769ce16d5"), false, "//div[@class='topic-authors']/a[@class='topic-authors__author']/text()", new Guid("c3b68972-e113-4a84-a5f3-bc7168749912") },
                    { new Guid("ac8b4672-4e2d-48d4-9284-92edaf3599c6"), true, "//a[@class='article__author']/text()", new Guid("a2fe2851-26d4-4c23-a035-05022a43a944") },
                    { new Guid("b4c39928-bd60-4fb0-a4e8-788cd385de97"), true, "//article//span[@class='author']/a[@class='authorName']/span/text()", new Guid("5fe78e0c-dfec-4ddc-aaab-2edfa8d3f15f") },
                    { new Guid("c352ee41-f313-430c-932c-8c116780890f"), false, "//div[@class='article__authors']//*[@class='article__authors__author']/span[@class='article__authors__author__name']/text()", new Guid("088e6c62-9c69-45e0-9f2c-e71191bcab16") },
                    { new Guid("d1877424-043f-4c49-85b1-1067bf2d5ada"), true, "//article//header//div[@class='article-head__author-name']/a[@rel='author']/span/text()", new Guid("edc7334a-2eb9-416c-8764-d45f2618827b") },
                    { new Guid("e30f734c-6e03-4458-ab20-d4c20617a2af"), true, "//*[@itemprop='author']/*[@itemprop='name']//text()", new Guid("6a606189-dd29-4baa-8326-8cf946711f3a") },
                    { new Guid("ea17e8c8-c7ba-4e98-af57-4d2e76517cd0"), true, "//span[@itemprop='name']/a/text()", new Guid("b1ec7fe4-421c-4425-9e43-94456f06a614") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_modified_at_settings",
                columns: new[] { "id", "is_required", "modified_at_culture_info", "modified_at_time_zone_info_id", "modified_at_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("904ddff5-82d6-4f14-82f2-42a5924ba05a"), false, "ru-RU", "Russian Standard Time", "//div[@class='doc_header__time']/span[contains(@class, 'publish_update')]/text()", new Guid("0d476cb0-495d-4849-8067-27f8f8b2fa33") },
                    { new Guid("91866992-beab-4b00-8685-34e9e2fcf549"), true, "ru-RU", "Russian Standard Time", "//div[@class='article__info']//div[@class='article__info-date']/span[@class='article__info-date-modified']/text()", new Guid("e19e5962-6786-4c4b-9433-f079005d547a") },
                    { new Guid("a6e3586a-421e-418a-a705-29a13a6c5e97"), false, "ru-RU", "UTC", "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark_update')]//span[@ca-ts]/text()", new Guid("925f8f8e-6297-4e74-a8f2-726177da02ff") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_picture_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("00518bbb-ae58-4794-a52f-4305718549f1"), true, new Guid("703ef2a6-ea52-4f76-bf99-6483201fd307"), "//meta[@property='og:image']/@content" },
                    { new Guid("26c4e5ae-6745-4788-bc4a-1885d5e97dd4"), true, new Guid("a5b15f94-5d87-4e5e-8f2e-256dd8e4338b"), "//picture/img/@src" },
                    { new Guid("409c8fae-7f24-4a42-b880-50e86d748188"), false, new Guid("edc7334a-2eb9-416c-8764-d45f2618827b"), "//article//header/div[@class='article-head__photo']/img/@src" },
                    { new Guid("4e35d8ea-e666-4d90-9cf2-c715128db019"), true, new Guid("582d8633-b699-484b-818c-d37ffc21aad3"), "//a[@class='glightbox']/img[contains(@class, 'pub-cover')]/@src" },
                    { new Guid("51dcd576-13f2-4fcd-8081-3f7bd994e437"), false, new Guid("1670bd43-36de-487d-9e75-2ab62abe1ae8"), "//div[@class='b-material-incut-m-image']//@src" },
                    { new Guid("76066448-f494-426d-800d-f2795f7ce362"), false, new Guid("5fe78e0c-dfec-4ddc-aaab-2edfa8d3f15f"), "//article//div[@class='image-con' and position() = 1]/picture/img/@src" },
                    { new Guid("766becd8-8c87-4825-bcee-39368c2cf3ea"), false, new Guid("925f8f8e-6297-4e74-a8f2-726177da02ff"), "//div[contains(@class, 'HeaderMedia_image')]//img[contains(@class, 'Image_image')]/@src" },
                    { new Guid("7b136d77-e2c7-43bd-bbf3-6aefec7e61e6"), false, new Guid("e19e5962-6786-4c4b-9433-f079005d547a"), "//div[@class='photoview__open']/img/@src" },
                    { new Guid("86c0ccad-40e2-41ae-862a-00eadd01a85e"), false, new Guid("629d5be2-8e64-4b7d-9e9c-62226dab1a8d"), "//article//header/div[contains(@class, 'styles_cover_media')]/img/@src" },
                    { new Guid("86fb4c95-97d7-4f84-a1de-663dd3d43c5e"), true, new Guid("b1ec7fe4-421c-4425-9e43-94456f06a614"), "//header//figure//picture/img/@src" },
                    { new Guid("a08848ba-86bf-4558-b8f9-f0b648e60a16"), false, new Guid("36d58463-243a-4078-bf7f-31a4f8dd3b7e"), "//img[@itemprop='image']/@src" },
                    { new Guid("acacdbe8-5577-4bd0-aec3-ba96d65d421e"), false, new Guid("655c4fae-a8de-4805-9403-4d6130a823cf"), "//div[@class='inner_content']//div[@class='main_img']//img/@src" },
                    { new Guid("ae79f3db-77b7-487a-a149-f823d65d7a77"), true, new Guid("ff521c54-8939-4d86-86bd-fa3420dd41e2"), "//div[@itemprop='articleBody']//div[@itemprop='image']/picture/img[@itemprop='contentUrl']/@src" },
                    { new Guid("b51bcdb6-0546-4cb0-a9bc-19c64052208b"), false, new Guid("ae4f5b30-485b-447d-b582-20869b936a02"), "//div[@class='b_article-media']//div[@class='mainarea-wrapper']/figure/img[@class='item-image-front']/@src" },
                    { new Guid("bbc2f9d9-6c0d-4f96-84fa-53b7d4b7e886"), false, new Guid("7f1b4b5c-69c7-4ac3-8234-53d8182cba11"), "//div[contains(@class, 'full-article')]/div[contains(@class, 'gallery')]/picture/img/@src" },
                    { new Guid("bc426967-33ea-43e2-bbea-15316e1dd070"), false, new Guid("74fba5ff-b002-487d-adf6-a663ac6aebdd"), "//figure//img/@src" },
                    { new Guid("c9b78727-3617-42ac-898b-cae6ef812fc1"), true, new Guid("6a606189-dd29-4baa-8326-8cf946711f3a"), "//div[contains(@class, 'newsMediaContainer')]/img/@src" },
                    { new Guid("d307b13b-ac94-4aee-aa44-f31061a3299e"), true, new Guid("a2fe2851-26d4-4c23-a035-05022a43a944"), "//div[@class='article__media']//img/@src" },
                    { new Guid("d4730ceb-e4ac-4067-bee5-039518b52a9d"), true, new Guid("bdfae62e-79cd-4780-99e2-e3b76b884588"), "//div[contains(@class, 'big_photo')]//div[@class='big_photo__img']//img/@src" },
                    { new Guid("d8a06088-8673-4615-9c93-d9107f5b62bc"), false, new Guid("4a6e9be9-505f-4e53-8116-986243d3e3ec"), "//div[@class='img_box']/a[@class='zoom_js']/img/@src" },
                    { new Guid("e981d417-097a-4491-a4a2-68aaa98a3e6e"), false, new Guid("c3b68972-e113-4a84-a5f3-bc7168749912"), "//div[contains(@class, 'topic-body__title-image')]//img[contains(@class, 'picture__image')]/@src" },
                    { new Guid("f815a515-dd87-41d1-bb6d-ce4c19842fa2"), false, new Guid("e7e2cfbe-ea6c-4970-8128-1dd6ea3c9c80"), "//article/figure/img/@src" },
                    { new Guid("fd235f8f-0b70-42e3-a0bb-f92933ac1a14"), true, new Guid("8ef23ca4-bd72-4d52-b6e7-19f95b637d7b"), "//div[contains(@class, 'article__lede-wrapper')]//picture/img/@src" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "published_at_culture_info", "published_at_time_zone_info_id", "published_at_x_path" },
                values: new object[,]
                {
                    { new Guid("012459f7-7aad-487b-ace7-7647a4cc147b"), true, new Guid("655c4fae-a8de-4805-9403-4d6130a823cf"), "ru-RU", "Russian Standard Time", "//div[@class='date_full']/text()" },
                    { new Guid("0147beb3-30c3-46a6-8402-9d2b86d72ca2"), true, new Guid("8ef23ca4-bd72-4d52-b6e7-19f95b637d7b"), "en-US", "Eastern Standard Time", "//div[@class='headline__footer']//div[contains(@class, 'headline__byline-sub-text')]/div[@class='timestamp']/text()" },
                    { new Guid("05abf043-b510-46b0-a6b8-422508445945"), true, new Guid("135fd3e7-619d-401b-b4fa-37b42737d76a"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'PageArticleContent_date')]/text()" },
                    { new Guid("120d5355-9792-4b6b-bd7d-9e0073eab8d2"), true, new Guid("6a606189-dd29-4baa-8326-8cf946711f3a"), "ru-RU", null, "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("12b4f98e-3ff3-4e76-8945-16257967243f"), true, new Guid("74fba5ff-b002-487d-adf6-a663ac6aebdd"), "ru-RU", "Ekaterinburg Standard Time", "//div[@itemprop='datePublished']/time/@datetime" },
                    { new Guid("14e95394-4b1b-4c76-b7e3-25b5803e9d29"), true, new Guid("edc7334a-2eb9-416c-8764-d45f2618827b"), "ru-RU", "Russian Standard Time", "//article//header//time[@class='article-head__date']/text()" },
                    { new Guid("18cf5dad-d044-4e95-a3c5-530ec5e6e9ac"), true, new Guid("36d58463-243a-4078-bf7f-31a4f8dd3b7e"), "ru-RU", null, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']/span[@itemprop='datePublished']/@content" },
                    { new Guid("1bd14540-26ad-45b8-a941-b3329814c3a2"), true, new Guid("a2fe2851-26d4-4c23-a035-05022a43a944"), "ru-RU", "Russian Standard Time", "//div[@class='article__meta']/time/text()" },
                    { new Guid("213636f7-9cc7-427a-b612-1dea732b97d7"), true, new Guid("e7e2cfbe-ea6c-4970-8128-1dd6ea3c9c80"), "ru-RU", "Russian Standard Time", "//article/div[@class='header']/span/text()" },
                    { new Guid("22fe930a-15ad-45a1-a083-bda50ca6de78"), true, new Guid("5fe78e0c-dfec-4ddc-aaab-2edfa8d3f15f"), "en-US", "Central Europe Standard Time", "//article//div[@class='article-info']/div[@class='date']/text()" },
                    { new Guid("32b9c9b0-8760-4d7f-9f57-61713f574a6b"), false, new Guid("582d8633-b699-484b-818c-d37ffc21aad3"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'pubdatetime')]/text()" },
                    { new Guid("477c6ad2-d599-466c-bf67-e7c7b797cf39"), true, new Guid("1670bd43-36de-487d-9e75-2ab62abe1ae8"), "ru-RU", "Russian Standard Time", "//p[@class='b-material__date']/text()" },
                    { new Guid("56b535cb-b1df-4f98-92b9-b2dd1a8e8e38"), true, new Guid("2cd2a6b9-dac0-493a-afc9-aecc3204bb22"), "ru-RU", null, "//header[@class='news-item__header']//time/@content" },
                    { new Guid("686ab1da-4d81-4fc5-9ccc-0a8c0d93eaac"), true, new Guid("ae4f5b30-485b-447d-b582-20869b936a02"), "ru-RU", null, "//article/div[@class='b_article-header']//time[@itemprop='datePublished']/@datetime" },
                    { new Guid("6a9a460f-824d-4417-92ab-4a4630475cae"), true, new Guid("0d476cb0-495d-4849-8067-27f8f8b2fa33"), "ru-RU", null, "//div[@class='doc_header__time']/time[@class='doc_header__publish_time']/@datetime" },
                    { new Guid("6fad202c-4740-4f86-b0bb-b4281a08c092"), true, new Guid("4a6e9be9-505f-4e53-8116-986243d3e3ec"), "ru-RU", "Russian Standard Time", "//div[@class='article_top']//div[@class='date']//time/text()" },
                    { new Guid("70550747-f413-45c4-be36-5fe5133f768b"), true, new Guid("703ef2a6-ea52-4f76-bf99-6483201fd307"), "ru-RU", null, "//article/header//time/@datetime" },
                    { new Guid("71c7104e-7fd0-4ed5-891d-58881b4fe158"), true, new Guid("73f3ba13-7f45-4c2c-bdb6-3305153e6780"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'article__date-autor-shortcode')]/div[contains(@class, 'article__date')]/time[@class='date']/@datetime" },
                    { new Guid("867815cc-afba-44da-8ea4-d96bd087555f"), true, new Guid("a5b15f94-5d87-4e5e-8f2e-256dd8e4338b"), "ru-RU", "Russian Standard Time", "//div[@class='b-text__date']/text()" },
                    { new Guid("a205bc5a-65a0-4006-8133-8a9dbc585aeb"), true, new Guid("a92a297e-eb0b-41bc-a138-dcfc69d82ec6"), "ru-RU", "Russian Standard Time", "//article[@itemprop='articleBody']/meta[@itemprop='datePublished']/@content" },
                    { new Guid("b472b2ef-1b3f-45a4-8f5f-2d68b1ab5609"), true, new Guid("ff521c54-8939-4d86-86bd-fa3420dd41e2"), "ru-RU", null, "//div[@class='publication-info']/time[@itemprop='datePublished']/@datetime" },
                    { new Guid("b5323a71-6766-4dbd-a3d7-021f9c444a97"), true, new Guid("e19e5962-6786-4c4b-9433-f079005d547a"), "ru-RU", "Russian Standard Time", "//div[@class='article__info']//div[@class='article__info-date']/a/text()" },
                    { new Guid("b5fa627d-9fbc-44a0-a6c4-523eb8164e8c"), true, new Guid("7f1b4b5c-69c7-4ac3-8234-53d8182cba11"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'full-article')]//time/text()" },
                    { new Guid("bae4b561-8b66-4144-a152-015649ab7a97"), true, new Guid("629d5be2-8e64-4b7d-9e9c-62226dab1a8d"), "ru-RU", "UTC", "//article//header//div[contains(@class, 'styles_meta')]//div[contains(@class, 'styles_metaItem')]/text()" },
                    { new Guid("bc73c6dc-9165-40a6-9271-0c7d05e934d9"), true, new Guid("b1ec7fe4-421c-4425-9e43-94456f06a614"), "en-US", null, "//time/@datetime" },
                    { new Guid("bd339852-07d3-4488-98fe-23c6c30b4df1"), true, new Guid("b183f5de-0fbf-410f-8f15-941a4ffc4539"), "ru-RU", "Russian Standard Time", "//div[@class='b-article__top-author']/p[@class='date']/text()" },
                    { new Guid("bf357ada-5eec-4a67-8385-7a629a19030d"), true, new Guid("925f8f8e-6297-4e74-a8f2-726177da02ff"), "ru-RU", "UTC", "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark')]//span[@ca-ts]/text()" },
                    { new Guid("c242a290-00f7-443e-b4cd-55805127d1bf"), true, new Guid("c3b68972-e113-4a84-a5f3-bc7168749912"), "ru-RU", "Russian Standard Time", "//div[@class='topic-page__header']//a[contains(@class, 'topic-header__time')]/text()" },
                    { new Guid("d89ef8d4-dc46-47ba-b14e-570e65739f7f"), true, new Guid("bdfae62e-79cd-4780-99e2-e3b76b884588"), "ru-RU", null, "//div[@class='article_page__left__top__left']//div[@class='article_page__left__top__time']//time/@datetime" },
                    { new Guid("e73b2898-1e58-4a42-85ad-8d82ba958f4b"), true, new Guid("088e6c62-9c69-45e0-9f2c-e71191bcab16"), "ru-RU", null, "//div[@class='article__header__info-block']/time[@class='article__header__date']/@datetime" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_sub_title_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("1023ba98-90b7-4603-b025-ccccf06f1b53"), false, new Guid("135fd3e7-619d-401b-b4fa-37b42737d76a"), "//div[contains(@class, 'PageArticleContent_lead')]/text()" },
                    { new Guid("1a9c65bf-5ade-43bb-a78b-00df605fb1a5"), true, new Guid("7f1b4b5c-69c7-4ac3-8234-53d8182cba11"), "//h1/text()" },
                    { new Guid("24131043-b22b-4d51-8196-25b6e531485f"), true, new Guid("b1ec7fe4-421c-4425-9e43-94456f06a614"), "//header/p[@id='article-summary']/text()" },
                    { new Guid("26ecf1ba-f81c-40ea-b60b-30a07ed7744e"), true, new Guid("73f3ba13-7f45-4c2c-bdb6-3305153e6780"), "//div[contains(@class, 'article__summary')]/text()" },
                    { new Guid("334234d6-dcee-48ed-b386-8f492cb4becb"), false, new Guid("e7e2cfbe-ea6c-4970-8128-1dd6ea3c9c80"), "//h4/text()" },
                    { new Guid("44c15019-9794-4586-9515-b062e7cc38d7"), true, new Guid("582d8633-b699-484b-818c-d37ffc21aad3"), "//div[@class='container-fluid shifted']/p[@class='announce lead']/text()" },
                    { new Guid("58b545aa-279d-425d-ade9-e81a02b90e9e"), false, new Guid("c3b68972-e113-4a84-a5f3-bc7168749912"), "//div[contains(@class, 'topic-body__title')]/text()" },
                    { new Guid("6cbe6d55-224a-43c3-ac32-74b2c47574e4"), false, new Guid("b183f5de-0fbf-410f-8f15-941a4ffc4539"), "//h4/text()" },
                    { new Guid("6f770e01-cafa-4ba2-adcd-53940a34f5a5"), true, new Guid("ae4f5b30-485b-447d-b582-20869b936a02"), "//h2/text()" },
                    { new Guid("72241abe-1d1b-4f2e-93cd-a75db349ecea"), false, new Guid("925f8f8e-6297-4e74-a8f2-726177da02ff"), "//h3/text()" },
                    { new Guid("77a36e79-a5c1-446c-b982-cec0dab6cee3"), false, new Guid("088e6c62-9c69-45e0-9f2c-e71191bcab16"), "//div[contains(@class, 'article__text')]/div[@class='article__text__overview']/span/text()" },
                    { new Guid("7f84fc9b-d80d-43b7-9234-3aec56c8b9b6"), false, new Guid("629d5be2-8e64-4b7d-9e9c-62226dab1a8d"), "//article//header//p[contains(@class, 'styles_subtitle')]/text()" },
                    { new Guid("86e929bf-bac8-4463-8ad7-80245a70faf8"), true, new Guid("36d58463-243a-4078-bf7f-31a4f8dd3b7e"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()=1]/text()" },
                    { new Guid("87ba86ca-c1ad-4531-87cb-53c6e8d5295a"), true, new Guid("e19e5962-6786-4c4b-9433-f079005d547a"), "//h1[@class='article__second-title']/text()" },
                    { new Guid("8cc1c84e-7c3a-4239-b63a-b44891a7ab36"), true, new Guid("6a606189-dd29-4baa-8326-8cf946711f3a"), "//div[@itemprop='alternativeHeadline']/text()" },
                    { new Guid("a2d6aad7-d73e-430d-8e39-611873c46b21"), true, new Guid("703ef2a6-ea52-4f76-bf99-6483201fd307"), "//div[contains(@class, 'js-mediator-article')]/*[position()=1]/text()" },
                    { new Guid("bbe6c4fd-9b35-4c14-ba0f-2c8ebfb7118c"), true, new Guid("5fe78e0c-dfec-4ddc-aaab-2edfa8d3f15f"), "//p[@class='headertext' and @itemprop='description']/text()" },
                    { new Guid("ca331177-280d-4689-8876-437754e581d5"), true, new Guid("a2fe2851-26d4-4c23-a035-05022a43a944"), "//div[@class='article__intro']/p/text()" },
                    { new Guid("d999cb63-9a7b-41af-a8f4-b882f3eafc05"), false, new Guid("0d476cb0-495d-4849-8067-27f8f8b2fa33"), "//header[@class='doc_header']/h2[contains(@class, 'doc_header__subheader')]/text()" },
                    { new Guid("e3ff5d34-32ae-4a7a-b9b9-3e61795e4599"), true, new Guid("74fba5ff-b002-487d-adf6-a663ac6aebdd"), "//p[@itemprop='alternativeHeadline']/span/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_video_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[] { new Guid("04b106e3-ba2b-46f9-a03f-53dc3dfdb878"), false, new Guid("5fe78e0c-dfec-4ddc-aaab-2edfa8d3f15f"), "//article//div[@class='videoWrapper' and @itemprop='video']/iframe[@class='video']/@src" });

            migrationBuilder.InsertData(
                table: "news_parse_modified_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_modified_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("33907b46-df46-4559-a98d-20e7a5cfcb61"), "\"обновлено\" d MMMM, HH:mm", new Guid("a6e3586a-421e-418a-a705-29a13a6c5e97") },
                    { new Guid("4068eebf-e3dd-43e7-8954-5bf71b0d5224"), "\"обновлено\" HH:mm , dd.MM.yyyy", new Guid("904ddff5-82d6-4f14-82f2-42a5924ba05a") },
                    { new Guid("6967c296-20e7-46a8-95f9-9193e3b71946"), "(\"обновлено:\" HH:mm dd.MM.yyyy)", new Guid("91866992-beab-4b00-8685-34e9e2fcf549") },
                    { new Guid("a21fb3c7-f6fa-4c14-8c5d-7a93af22e139"), "\"обновлено\" HH:mm , dd.MM", new Guid("904ddff5-82d6-4f14-82f2-42a5924ba05a") },
                    { new Guid("f266148e-24f2-45cd-9743-0d9b8a197922"), "\"обновлено\" d MMMM yyyy, HH:mm", new Guid("a6e3586a-421e-418a-a705-29a13a6c5e97") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_published_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("171be2eb-d965-4faf-a5ba-c7bca740e691"), "dd MMMM yyyy, HH:mm", new Guid("012459f7-7aad-487b-ace7-7647a4cc147b") },
                    { new Guid("17ef0677-0ec2-4301-bae8-c13b0cb7dab7"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("120d5355-9792-4b6b-bd7d-9e0073eab8d2") },
                    { new Guid("1a3aab09-9fed-49c4-bc2b-e4fa27eafaa4"), "yyyy-MM-d HH:mm", new Guid("71c7104e-7fd0-4ed5-891d-58881b4fe158") },
                    { new Guid("1cbe84bc-3767-414d-8cb1-51125e9ad753"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("56b535cb-b1df-4f98-92b9-b2dd1a8e8e38") },
                    { new Guid("248c8676-c0f0-4364-9e8b-74316643b7ea"), "HH:mm dd.MM.yyyy", new Guid("b5323a71-6766-4dbd-a3d7-021f9c444a97") },
                    { new Guid("277df5e9-2976-4ff4-9e8a-bce71ca48030"), "\"Published\n       \" HH:mm tt \"EST\", ddd MMMM d, yyyy", new Guid("0147beb3-30c3-46a6-8402-9d2b86d72ca2") },
                    { new Guid("29b5f7f8-7c6f-4317-85bf-02cf779ff4e6"), "d MMMM yyyy \"в\" HH:mm", new Guid("bd339852-07d3-4488-98fe-23c6c30b4df1") },
                    { new Guid("2a093757-411a-492e-93fe-cb77b14eea7b"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("d89ef8d4-dc46-47ba-b14e-570e65739f7f") },
                    { new Guid("2ac3bdb1-393d-461e-b530-71e14916db72"), "dd.MM.yyyy HH:mm", new Guid("b5fa627d-9fbc-44a0-a6c4-523eb8164e8c") },
                    { new Guid("2ce7093f-b829-4a08-b6d8-2149e9296b12"), "yyyy-MM-ddTHH:mm:ss", new Guid("a205bc5a-65a0-4006-8133-8a9dbc585aeb") },
                    { new Guid("30b6f493-7649-4cc2-a2c5-b367a4299b7d"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("bc73c6dc-9165-40a6-9271-0c7d05e934d9") },
                    { new Guid("3399bfe9-4a2b-42e3-98bd-e681dca5e134"), "dd MMMM yyyy HH:mm", new Guid("1bd14540-26ad-45b8-a941-b3329814c3a2") },
                    { new Guid("34c4f422-06ff-4785-8535-aa245988e58d"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("6a9a460f-824d-4417-92ab-4a4630475cae") },
                    { new Guid("38b7ea2b-313f-4284-b1e7-a03b544575c1"), "d MMMM yyyy HH:mm", new Guid("867815cc-afba-44da-8ea4-d96bd087555f") },
                    { new Guid("49d3d396-82db-4ee2-9a24-05570766d76f"), "dd MMMM, HH:mm", new Guid("477c6ad2-d599-466c-bf67-e7c7b797cf39") },
                    { new Guid("4f2f3dc1-c72b-42ec-9b2d-aa7fb1a7a03f"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("18cf5dad-d044-4e95-a3c5-530ec5e6e9ac") },
                    { new Guid("5b9cec54-032d-40ed-a04b-94f413521579"), "d MMMM  HH:mm", new Guid("867815cc-afba-44da-8ea4-d96bd087555f") },
                    { new Guid("5fd90e35-1862-4d97-951f-0c7741859c7b"), "HH:mm", new Guid("1bd14540-26ad-45b8-a941-b3329814c3a2") },
                    { new Guid("69c90f4a-3716-4aa7-af20-ccfe49138c40"), "d MMMM, HH:mm,", new Guid("bf357ada-5eec-4a67-8385-7a629a19030d") },
                    { new Guid("71cd1e5c-eed2-4a68-93ac-e662972aec22"), "dd.MM.yyyy HH:mm", new Guid("6fad202c-4740-4f86-b0bb-b4281a08c092") },
                    { new Guid("78cd970d-23be-4ee5-b93e-6c4260f7a33b"), "d MMMM, HH:mm", new Guid("bf357ada-5eec-4a67-8385-7a629a19030d") },
                    { new Guid("7f76ff55-d292-4034-9f46-dbd658a34cb1"), "d MMMM yyyy, HH:mm,", new Guid("bf357ada-5eec-4a67-8385-7a629a19030d") },
                    { new Guid("8719845c-100f-4138-8003-973371714e13"), "yyyy-MM-ddTHH:mm:ss", new Guid("12b4f98e-3ff3-4e76-8945-16257967243f") },
                    { new Guid("87d90ee8-4b9c-4139-b9b0-f31fbfac0821"), "d-M-yyyy HH:mm", new Guid("22fe930a-15ad-45a1-a083-bda50ca6de78") },
                    { new Guid("884b2fae-2f78-4533-a276-da002bebd863"), "d MMMM yyyy, HH:mm", new Guid("bf357ada-5eec-4a67-8385-7a629a19030d") },
                    { new Guid("94379024-bbc0-458c-a4a7-37178bd379c1"), "d MMMM yyyy, HH:mm", new Guid("bae4b561-8b66-4144-a152-015649ab7a97") },
                    { new Guid("9a4dd0c6-060a-4472-9f80-4efa0c407bcf"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("686ab1da-4d81-4fc5-9ccc-0a8c0d93eaac") },
                    { new Guid("a35f2225-612c-454f-9250-c8296534ba7c"), "d MMMM yyyy, HH:mm", new Guid("213636f7-9cc7-427a-b612-1dea732b97d7") },
                    { new Guid("aa6c5a0f-94e5-4c4a-8395-5018fe1b5e84"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("e73b2898-1e58-4a42-85ad-8d82ba958f4b") },
                    { new Guid("aaad58de-580d-4bf6-8e8d-da505b2d8c28"), "HH:mm", new Guid("477c6ad2-d599-466c-bf67-e7c7b797cf39") },
                    { new Guid("bc7323ae-ebff-42d2-aaa7-6b12117d4e69"), "dd MMMM yyyy, HH:mm", new Guid("477c6ad2-d599-466c-bf67-e7c7b797cf39") },
                    { new Guid("c9c20f83-c10d-4a42-8fb2-f4a0a3849351"), "yyyy-MM-ddTHH:mm:ss.fffZ", new Guid("70550747-f413-45c4-be36-5fe5133f768b") },
                    { new Guid("d597ac56-abd3-4b0e-8244-66acc2adb46a"), "yyyy-MM-dd HH:mm:ss", new Guid("32b9c9b0-8760-4d7f-9f57-61713f574a6b") },
                    { new Guid("def0fad0-a24c-4069-8920-0777163039c6"), "HH:mm, d MMMM yyyy", new Guid("c242a290-00f7-443e-b4cd-55805127d1bf") },
                    { new Guid("e8a576fc-a5ba-4233-82a6-2a2c2e572e56"), "dd.MM.yyyy HH:mm", new Guid("05abf043-b510-46b0-a6b8-422508445945") },
                    { new Guid("f53b7a9d-254a-4d78-8a6c-5ffaeb86c169"), "d MMMM, HH:mm", new Guid("bae4b561-8b66-4144-a152-015649ab7a97") },
                    { new Guid("f691dd50-9023-4e0e-a6ec-4cbc3858127a"), "d MMMM yyyy, HH:mm \"МСК\"", new Guid("14e95394-4b1b-4c76-b7e3-25b5803e9d29") },
                    { new Guid("fe025c98-ed6c-4878-b76a-fabc229e5d2f"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("b472b2ef-1b3f-45a4-8f5f-2d68b1ab5609") }
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
