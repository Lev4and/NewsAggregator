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
                    published_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
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
                    { new Guid("080c028e-43cf-4f92-8ff3-98e22521ef56"), false, "https://ria.ru/", "РИА Новости" },
                    { new Guid("11cbd8ac-ffa4-4dfa-8059-36166c9c5ee6"), false, "https://rg.ru/", "Российская газета" },
                    { new Guid("1437ab5a-cc4f-403c-8da9-a2fec7bfa098"), false, "https://vz.ru/", "ВЗГЛЯД.РУ" },
                    { new Guid("1b5284c1-9c5a-4680-98fd-2cc4a5ae00bc"), false, "https://life.ru/", "Life" },
                    { new Guid("27e8d065-557e-4dea-b69a-e25e3d745111"), false, "https://ura.news/", "Ura.ru" },
                    { new Guid("2dbe1967-5446-4fdb-a9f7-107dde70318c"), false, "https://www.championat.com/", "Чемпионат.com" },
                    { new Guid("3dcee46d-9fae-4803-98a8-b0c0b7a0216a"), false, "https://russian.rt.com/", "RT на русском" },
                    { new Guid("403a51b2-9ba6-45d3-ba84-6a704effec27"), false, "https://www.belta.by/", "БелТА" },
                    { new Guid("47c332c2-2206-456b-bfbc-95d2aab7c100"), false, "https://aif.ru/", "Аргументы и факты" },
                    { new Guid("4a08e18f-ca0b-486e-9e28-f04a5efea8f8"), false, "https://www.interfax.ru/", "Интерфакс" },
                    { new Guid("4b315eea-71f8-4a31-b15e-6fa216901c8f"), false, "https://www.pravda.ru/", "Правда.ру" },
                    { new Guid("4c9503c2-21cb-467b-a9ba-4cafd666e5e3"), false, "https://tass.ru/", "ТАСС" },
                    { new Guid("57195a5c-3910-4850-a36a-bbcc062d7243"), false, "https://ixbt.games/", "iXBT.games" },
                    { new Guid("588d2f78-c600-4977-bc27-659a7a28deb1"), false, "https://www.ixbt.com/", "iXBT.com" },
                    { new Guid("67b7c7b8-7113-4bbe-88c0-9d3d3b75f9ea"), false, "https://tsargrad.tv/", "Царьград" },
                    { new Guid("7d1bc6af-63e8-4e49-b454-5f17f4e0348e"), false, "https://www.kommersant.ru/", "Коммерсантъ" },
                    { new Guid("855ab8f4-be57-47a0-a4f1-6351bb004ac2"), false, "https://www.m24.ru/", "Москва 24" },
                    { new Guid("9fc4ed64-cc93-4b68-a883-706f92dc4021"), false, "https://lenta.ru/", "Лента.Ру" },
                    { new Guid("ac803c39-359c-4d64-8dcf-55d98893ad08"), false, "https://www.sports.ru/", "Storts.ru" },
                    { new Guid("c3f9e8d2-2be1-4c90-a80d-e6cb449a641d"), false, "https://svpressa.ru/", "СвободнаяПресса" },
                    { new Guid("cd902470-b0bc-47fa-933e-a586b2e63ec6"), false, "https://3dnews.ru/", "3Dnews.ru" },
                    { new Guid("d6052e12-6290-4578-8397-7b1e95a1add8"), false, "https://www.gazeta.ru/", "Газета.Ru" },
                    { new Guid("f284497b-898a-465f-9946-148276d0ccf0"), false, "https://iz.ru/", "Известия" },
                    { new Guid("f8ff74fc-85cd-453b-8334-cc8cb39eeb32"), false, "https://www.rbc.ru/", "РБК" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_settings",
                columns: new[] { "id", "description_x_path", "source_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("1af8a18d-a1f8-4212-a7f3-fb386cd48108"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]", new Guid("7d1bc6af-63e8-4e49-b454-5f17f4e0348e"), "//h1/text()" },
                    { new Guid("3245e73e-5095-4ace-baaa-7bd98636c5f7"), "//article", new Guid("4c9503c2-21cb-467b-a9ba-4cafd666e5e3"), "//h1/text()" },
                    { new Guid("32b9b313-6761-4279-93e2-039019ec5a50"), "//div[@itemprop='articleBody']/*[not(name()='div')]", new Guid("27e8d065-557e-4dea-b69a-e25e3d745111"), "//h1/text()" },
                    { new Guid("38f81d5f-7291-45cc-837c-a6b1f084e0b8"), "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]", new Guid("1b5284c1-9c5a-4680-98fd-2cc4a5ae00bc"), "//h1/text()" },
                    { new Guid("406583f6-7546-4f56-a64f-c607fdceb816"), "//div[@class='container-fluid shifted']/p[@class='announce lead']", new Guid("57195a5c-3910-4850-a36a-bbcc062d7243"), "//h1/text()" },
                    { new Guid("49b0c029-7644-4da9-baf1-17ead81a7092"), "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]", new Guid("4a08e18f-ca0b-486e-9e28-f04a5efea8f8"), "//h1/text()" },
                    { new Guid("4daaa8c5-637e-4310-98c3-4614db190c23"), "//div[contains(@class, 'PageContentCommonStyling_text')]", new Guid("11cbd8ac-ffa4-4dfa-8059-36166c9c5ee6"), "//h1/text()" },
                    { new Guid("4f549988-5e22-4ff7-894a-5c4534286c27"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview'))]", new Guid("f8ff74fc-85cd-453b-8334-cc8cb39eeb32"), "//h1/text()" },
                    { new Guid("5365e832-0a0a-4a13-b8a7-c636817cd4a3"), "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]", new Guid("4b315eea-71f8-4a31-b15e-6fa216901c8f"), "//h1/text()" },
                    { new Guid("6162836a-2a06-435f-a68a-8e5c71e7dc55"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]", new Guid("67b7c7b8-7113-4bbe-88c0-9d3d3b75f9ea"), "//h1[@class='article__title']/text()" },
                    { new Guid("90595a15-043e-4d33-88a5-769e3b8faff1"), "//article/div[@class='news_text']", new Guid("1437ab5a-cc4f-403c-8da9-a2fec7bfa098"), "//h1/text()" },
                    { new Guid("916f215f-4052-4081-a6ab-ab8293c8339b"), "//div[@itemprop='articleBody']", new Guid("d6052e12-6290-4578-8397-7b1e95a1add8"), "//h1/text()" },
                    { new Guid("92aa3ce7-c623-4d06-a26b-65e488c65507"), "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]", new Guid("855ab8f4-be57-47a0-a4f1-6351bb004ac2"), "//h1/text()" },
                    { new Guid("b4868cc2-8a0b-41fc-9b79-c27ff2e32367"), "//div[@class='article_text']", new Guid("47c332c2-2206-456b-bfbc-95d2aab7c100"), "//h1/text()" },
                    { new Guid("c62f66a6-e033-49da-be9d-5b2f91ccf681"), "//div[contains(@class, 'article__text ')]", new Guid("3dcee46d-9fae-4803-98a8-b0c0b7a0216a"), "//h1/text()" },
                    { new Guid("d2a5c82c-9f0d-4ff1-84b7-36fa0764cd8e"), "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]", new Guid("c3f9e8d2-2be1-4c90-a80d-e6cb449a641d"), "//h1[@class='b-text__title']/text()" },
                    { new Guid("e1843acf-0d2a-42b1-8413-8bc7dd7fe353"), "//article/div[@class='article-content']/*[not(@class)]", new Guid("2dbe1967-5446-4fdb-a9f7-107dde70318c"), "//article/header/div[@class='article-head__title']/text()" },
                    { new Guid("e458f8da-388a-4cbc-afb9-78fc41777a42"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()>1]", new Guid("cd902470-b0bc-47fa-933e-a586b2e63ec6"), "//h1/text()" },
                    { new Guid("e6096bc4-52cb-47f4-9abf-39cfcfd5b225"), "//div[@class='topic-body__content']", new Guid("9fc4ed64-cc93-4b68-a883-706f92dc4021"), "//h1[@class='topic-body__titles']/span[@class='topic-body__title']/text()" },
                    { new Guid("e827cb65-2270-434d-9d6d-22bb28fec91e"), "//div[contains(@class, 'article__body')]", new Guid("080c028e-43cf-4f92-8ff3-98e22521ef56"), "//div[@class='article__title']/text()" },
                    { new Guid("f062cb88-d748-4041-a882-83f880f6ae90"), "//div[contains(@class, 'news-item__content')]", new Guid("ac803c39-359c-4d64-8dcf-55d98893ad08"), "//h1/text()" },
                    { new Guid("f4dac8a2-4cd0-4583-8ed8-cbb2727aa905"), "//div[@itemprop='articleBody']", new Guid("f284497b-898a-465f-9946-148276d0ccf0"), "//h1/span/text()" },
                    { new Guid("fc7511f4-cefd-42bc-887d-ecd3fe1f1f5c"), "//div[@class='js-mediator-article']", new Guid("403a51b2-9ba6-45d3-ba84-6a704effec27"), "//h1/text()" },
                    { new Guid("fd11966c-2354-4de8-bcf3-32cf13af8557"), "//div[@itemprop='articleBody']", new Guid("588d2f78-c600-4977-bc27-659a7a28deb1"), "//h1/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_search_settings",
                columns: new[] { "id", "news_site_url", "news_url_x_path", "source_id" },
                values: new object[,]
                {
                    { new Guid("1a014bc9-b4a7-4752-b709-201cd7fa21d2"), "https://life.ru/s/novosti", "//a[contains(@href, '/p/')]/@href", new Guid("1b5284c1-9c5a-4680-98fd-2cc4a5ae00bc") },
                    { new Guid("1afa9b64-1de5-4261-baea-42666bac08b2"), "https://vz.ru/", "//a[contains(@href, '.html') and not(contains(@href, '#comments')) and not(contains(@href, '?')) and not(contains(@href, '/about/'))]/@href", new Guid("1437ab5a-cc4f-403c-8da9-a2fec7bfa098") },
                    { new Guid("1d52a27a-5b63-43f7-b184-2ac2eaa00226"), "https://iz.ru/news/", "//a[contains(@href, '?main_click')]/@href", new Guid("f284497b-898a-465f-9946-148276d0ccf0") },
                    { new Guid("273b6382-8288-45cb-89a5-fb6570021d16"), "https://ixbt.games/news/", "//a[@class='card-link']/@href", new Guid("57195a5c-3910-4850-a36a-bbcc062d7243") },
                    { new Guid("2cb6df85-39d6-41a4-99ed-d0834d197b3f"), "https://tsargrad.tv/", "//a[contains(@class, 'news-item__link')]/@href", new Guid("67b7c7b8-7113-4bbe-88c0-9d3d3b75f9ea") },
                    { new Guid("411999cf-8276-413e-985f-f6cb7ec36cbe"), "https://lenta.ru/", "//a[starts-with(@href, '/news/')]/@href", new Guid("9fc4ed64-cc93-4b68-a883-706f92dc4021") },
                    { new Guid("42f01c18-b6a4-4743-bc9a-ceb1c153fc0d"), "https://svpressa.ru/all/news/", "//a[contains(@href, '/news/') and not(contains(@href, '?')) and not(starts-with(@href, '/all/news/'))]/@href", new Guid("c3f9e8d2-2be1-4c90-a80d-e6cb449a641d") },
                    { new Guid("62e5f888-4559-443b-95a9-a2cfd6d8c055"), "https://www.belta.by/", "//a[contains(@href, 'https://www.belta.by/') and contains(@href, '/view/')]/@href", new Guid("403a51b2-9ba6-45d3-ba84-6a704effec27") },
                    { new Guid("71ad97af-ffbb-45be-be06-9b35b492b9c8"), "https://www.pravda.ru/", "//a[contains(@href, '/news/') and not(@href='https://www.pravda.ru/news/')]/@href", new Guid("4b315eea-71f8-4a31-b15e-6fa216901c8f") },
                    { new Guid("75793e0a-3e18-47dd-a4c2-7bda6b5eb847"), "https://www.rbc.ru/", "//a[contains(@href, 'https://www.rbc.ru/') and contains(@href, '?from=')]/@href", new Guid("f8ff74fc-85cd-453b-8334-cc8cb39eeb32") },
                    { new Guid("772e00ad-36c2-41ba-b1e6-2b00ee4a16c6"), "https://ura.news/", "//a[contains(@href, '/news/')]/@href", new Guid("27e8d065-557e-4dea-b69a-e25e3d745111") },
                    { new Guid("a06d2c9b-d440-489b-83b5-05d35208ccce"), "https://tass.ru/", "//a[contains(@class, 'tass_pkg_link-v5WdK') and contains(substring(@href, 2), '/')]/@href", new Guid("4c9503c2-21cb-467b-a9ba-4cafd666e5e3") },
                    { new Guid("a510c71f-d989-4f7a-80d5-a7d464bdd015"), "https://aif.ru/", "//span[contains(@class, 'item_text__title')]/../@href", new Guid("47c332c2-2206-456b-bfbc-95d2aab7c100") },
                    { new Guid("b5386f14-382b-4a88-a68b-ef5d4be48649"), "https://3dnews.ru/news/", "//div[@class='news-feed-all']//a[@class='entry-header']/h1/../@href", new Guid("cd902470-b0bc-47fa-933e-a586b2e63ec6") },
                    { new Guid("b9c71a71-aeb0-4e90-9c18-dbb6a417679a"), "https://www.championat.com/news/1.html?utm_source=button&utm_medium=news", "//a[contains(@href, 'news-') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("2dbe1967-5446-4fdb-a9f7-107dde70318c") },
                    { new Guid("b9ea3527-4610-4565-bba9-10b5927c01d0"), "https://www.sports.ru/news/", "//a[contains(@href, '.html') and not(contains(@href, '.html#comments'))]/@href", new Guid("ac803c39-359c-4d64-8dcf-55d98893ad08") },
                    { new Guid("e1701777-acb7-49e4-aff6-733ead66077a"), "https://www.kommersant.ru/", "//a[contains(@href, '/doc/') and contains(@href, '?from=')]/@href", new Guid("7d1bc6af-63e8-4e49-b454-5f17f4e0348e") },
                    { new Guid("f2029ddd-060f-4eb3-b502-27973ca4b0d8"), "https://www.m24.ru/", "//a[contains(@href, '/news/')]/@href", new Guid("855ab8f4-be57-47a0-a4f1-6351bb004ac2") },
                    { new Guid("f48c7d45-51e5-481f-a7fc-d4e245121136"), "https://www.interfax.ru/", "//div[@class='timeline']//a[@tabindex=5]/@href", new Guid("4a08e18f-ca0b-486e-9e28-f04a5efea8f8") },
                    { new Guid("f540d50c-e274-4799-bc2a-abdfc52e00be"), "https://www.ixbt.com/news/", "//a[starts-with(@href, '/news/') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("588d2f78-c600-4977-bc27-659a7a28deb1") },
                    { new Guid("f82fdc3b-2794-48cd-b82d-8ad0c5ad29a0"), "https://russian.rt.com/", "//a[contains(@class, 'link') and contains(@href, 'news/')]/@href", new Guid("3dcee46d-9fae-4803-98a8-b0c0b7a0216a") },
                    { new Guid("fb11b51d-3d52-4817-990a-e8fab10b89f2"), "https://www.gazeta.ru/news/", "//a[contains(@href, '/news/') and contains(@href, '.shtml') and not(contains(@href, '?'))]/@href", new Guid("d6052e12-6290-4578-8397-7b1e95a1add8") },
                    { new Guid("fbf41fd8-6f4a-4e63-a0bf-f63d2a7e1a8f"), "https://rg.ru/", "//a[contains(@href, '.html')]/@href", new Guid("11cbd8ac-ffa4-4dfa-8059-36166c9c5ee6") },
                    { new Guid("ffe22da5-46e9-49fe-a3c6-4c4deec9224f"), "https://ria.ru/", "//a[contains(@class, 'cell-list__item-link')]/@href", new Guid("080c028e-43cf-4f92-8ff3-98e22521ef56") }
                });

            migrationBuilder.InsertData(
                table: "news_source_logos",
                columns: new[] { "id", "source_id", "url" },
                values: new object[] { new Guid("310fb688-85bd-45a1-b065-7dd4ab79e41b"), new Guid("57195a5c-3910-4850-a36a-bbcc062d7243"), "https://sun13-2.userapi.com/s/v1/ig2/_ID-2w6Llad8ig5_987dKAfh1pyLdj7HfLHqGx9HxyDjoEDN7wxR0ZWJm5ja1Ey6UuQXaEYEBW1Zd51cpRrjSGfS.jpg?size=100x100&quality=96&crop=22,22,626,626&ava=1" });

            migrationBuilder.InsertData(
                table: "news_parse_editor_settings",
                columns: new[] { "id", "is_required", "name_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("0461cd04-ec2b-48da-9f9b-83ae35d103e9"), false, "//div[@class='topic-authors']/a[@class='topic-authors__author']/text()", new Guid("e6096bc4-52cb-47f4-9abf-39cfcfd5b225") },
                    { new Guid("236690be-0cee-439e-b3c3-70c5d2500ace"), false, "//p[@class='doc__text document_authors']/text()", new Guid("1af8a18d-a1f8-4212-a7f3-fb386cd48108") },
                    { new Guid("41d9e22a-cd65-48ee-befb-d51d9bc626d9"), false, "//div[@class='article__authors']//span[@class='article__authors__author']/span[@class='article__authors__author__name']/text()", new Guid("4f549988-5e22-4ff7-894a-5c4534286c27") },
                    { new Guid("58797d2b-dc41-41e9-be7b-2bfd0db5deaf"), false, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']//a[@itemprop='author']//span[@itemprop='name']/text()", new Guid("e458f8da-388a-4cbc-afb9-78fc41777a42") },
                    { new Guid("834ecf84-66a8-4a3e-abdc-03424b010219"), false, "//div[@class='article_top']//div[@class='authors']//div[@class='autor']//span/text()", new Guid("b4868cc2-8a0b-41fc-9b79-c27ff2e32367") },
                    { new Guid("84858e3c-b7e2-4e55-a1e3-67a2eaad7adf"), false, "//div[contains(@class, 'PageArticleContent_authors')]//a[contains(@class, 'LinksOfAuthor_item')]/text()", new Guid("4daaa8c5-637e-4310-98c3-4614db190c23") },
                    { new Guid("8bc4b2f9-62a4-4cc9-8fd8-4d48d80a8a19"), false, "//a[@class='article__author']/text()", new Guid("6162836a-2a06-435f-a68a-8e5c71e7dc55") },
                    { new Guid("9923fcdf-6212-45ef-b716-51401137c300"), false, "//footer[@class='news-item__footer']/div[@class='news-item__footer-after-news']/p[position()=1]//span/text()", new Guid("f062cb88-d748-4041-a882-83f880f6ae90") },
                    { new Guid("a121ad3d-5bb3-4e4f-813f-18235956f4b7"), false, "//span[@itemprop='author']/span[@itemprop='name']/@content", new Guid("fd11966c-2354-4de8-bcf3-32cf13af8557") },
                    { new Guid("a664a53b-bd5c-4ded-bac4-5f5e30ea156d"), false, "//div[@itemprop='author']/span[@itemprop='name']/text()", new Guid("32b9b313-6761-4279-93e2-039019ec5a50") },
                    { new Guid("ab25de0f-93f0-43ce-af84-672d949c03bd"), false, "//div[contains(@class, 'full-article')]/div[@class='authors-block']//span[text()='Автор']/../a/text()", new Guid("5365e832-0a0a-4a13-b8a7-c636817cd4a3") },
                    { new Guid("e2a9bef8-d575-4d1e-b2dd-834c33a37cb1"), false, "//article//header//div[@class='article-head__author-name']/a[@rel='author']/span/text()", new Guid("e1843acf-0d2a-42b1-8413-8bc7dd7fe353") },
                    { new Guid("e35efd69-d607-4d13-92e5-c7349d9e8a20"), false, "//div[contains(@class, 'styles_bodyWrapper')]//div[contains(@class, 'styles_authorsLinks')]/a/text()", new Guid("38f81d5f-7291-45cc-837c-a6b1f084e0b8") },
                    { new Guid("eba9655b-a25f-4b6c-8119-b934cd2c7f76"), false, "//div[@class='container-fluid publication-footer']//a[contains(@class, 'text-secondary')]/@title", new Guid("406583f6-7546-4f56-a64f-c607fdceb816") },
                    { new Guid("f2681fcf-92e0-45e7-9172-5950067c130e"), false, "//div[@class='author']/span[@itemprop='author']/span[@itemprop='name']/a/text()", new Guid("916f215f-4052-4081-a6ab-ab8293c8339b") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_picture_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("0076f013-b785-4e9e-ae98-0b17b5cdd8d9"), false, new Guid("916f215f-4052-4081-a6ab-ab8293c8339b"), "//div[@class='b_article-media']//div[@class='mainarea-wrapper']/figure/img[@class='item-image-front']/@src" },
                    { new Guid("0f97a44d-9e70-41bf-903d-a3a377906226"), false, new Guid("fc7511f4-cefd-42bc-887d-ecd3fe1f1f5c"), "//div[@class='inner_content']//div[@class='main_img']//img/@src" },
                    { new Guid("1ab65f9e-48b7-4eef-9a13-4a84d6e31618"), false, new Guid("90595a15-043e-4d33-88a5-769e3b8faff1"), "//article/figure/img/@src" },
                    { new Guid("20595b66-ee94-4b0a-860d-774f93ee49a6"), false, new Guid("e1843acf-0d2a-42b1-8413-8bc7dd7fe353"), "//article//header/div[@class='article-head__photo']/img/@src" },
                    { new Guid("227d85bf-e796-42db-a6eb-732264210ae9"), false, new Guid("e827cb65-2270-434d-9d6d-22bb28fec91e"), "//div[@class='photoview__open']/img/@src" },
                    { new Guid("3680c224-dffd-4819-b525-22122cf0489c"), false, new Guid("3245e73e-5095-4ace-baaa-7bd98636c5f7"), "//div[contains(@class, 'HeaderMedia_image')]//img[contains(@class, 'Image_image')]/@src" },
                    { new Guid("4191e706-445a-4c80-8e86-80e70a493d13"), false, new Guid("e6096bc4-52cb-47f4-9abf-39cfcfd5b225"), "//div[contains(@class, 'topic-body__title-image')]//img[contains(@class, 'picture__image')]/@src" },
                    { new Guid("6e124de6-7bf6-4411-817b-8b9a83791251"), false, new Guid("406583f6-7546-4f56-a64f-c607fdceb816"), "//a[@class='glightbox']/img[contains(@class, 'pub-cover')]/@src" },
                    { new Guid("766f24da-9715-4d6b-abb8-4b8167d4c474"), false, new Guid("92aa3ce7-c623-4d06-a26b-65e488c65507"), "//div[@class='b-material-incut-m-image']//@src" },
                    { new Guid("784948bd-f46a-4b79-a42c-d3db3e897dd1"), false, new Guid("5365e832-0a0a-4a13-b8a7-c636817cd4a3"), "//div[contains(@class, 'full-article')]/div[contains(@class, 'gallery')]/picture/img/@src" },
                    { new Guid("8273b8b0-4afe-4e32-8856-449a9d4c3f36"), false, new Guid("b4868cc2-8a0b-41fc-9b79-c27ff2e32367"), "//div[@class='img_box']/a[@class='zoom_js']/img/@src" },
                    { new Guid("86379287-1f83-4b90-93c8-c962c50d6ec1"), false, new Guid("38f81d5f-7291-45cc-837c-a6b1f084e0b8"), "//article//header/div[contains(@class, 'styles_cover_media')]/img/@src" },
                    { new Guid("a39068b1-747e-4c98-b266-92e814e06233"), false, new Guid("6162836a-2a06-435f-a68a-8e5c71e7dc55"), "//div[@class='article__media']//img/@src" },
                    { new Guid("dce29bde-a18b-4357-9aa6-afc77f0aee76"), false, new Guid("f4dac8a2-4cd0-4583-8ed8-cbb2727aa905"), "//div[contains(@class, 'big_photo')]//div[@class='big_photo__img']//img/@src" },
                    { new Guid("e6cd9266-a1be-4164-b96e-3edf022c77c5"), false, new Guid("32b9b313-6761-4279-93e2-039019ec5a50"), "//div[@itemprop='articleBody']//div[@itemprop='image']/picture/img[@itemprop='contentUrl']/@src" },
                    { new Guid("e8929540-517d-4ea9-af45-26898d55bd3c"), false, new Guid("e458f8da-388a-4cbc-afb9-78fc41777a42"), "//div[contains(@class, 'article-entry')]//div[contains(@class, 'entry-body')]//div[@class='source-wrapper']/img[@itemprop='image']/@src" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "published_at_culture_info", "published_at_x_path" },
                values: new object[,]
                {
                    { new Guid("0d821148-acdc-4c1f-9e3a-c4c9cec23414"), false, new Guid("e1843acf-0d2a-42b1-8413-8bc7dd7fe353"), "ru-RU", "//article//header//time[@class='article-head__date']/text()" },
                    { new Guid("105ad8fc-668d-4399-9420-50cccf35095f"), false, new Guid("e6096bc4-52cb-47f4-9abf-39cfcfd5b225"), "ru-RU", "//div[@class='topic-page__header']//a[contains(@class, 'topic-header__time')]/text()" },
                    { new Guid("1e1a2d1e-2c4e-4798-a492-f0bf9f2eb98d"), false, new Guid("e458f8da-388a-4cbc-afb9-78fc41777a42"), "ru-RU", "//div[contains(@class, 'article-entry')]//div[@class='entry-info']/span[@itemprop='datePublished']/@content" },
                    { new Guid("1fec5734-9042-47ce-ab19-7cbc596ad5dc"), false, new Guid("d2a5c82c-9f0d-4ff1-84b7-36fa0764cd8e"), "ru-RU", "//div[@class='b-text__date']/text()" },
                    { new Guid("3b1932ca-c7ec-4a26-933d-3884efe34501"), false, new Guid("90595a15-043e-4d33-88a5-769e3b8faff1"), "ru-RU", "//article/div[@class='header']/span/text()" },
                    { new Guid("3fa07d3e-ecea-4664-ae68-42a8a49a79a5"), false, new Guid("92aa3ce7-c623-4d06-a26b-65e488c65507"), "ru-RU", "//p[@class='b-material__date']/text()" },
                    { new Guid("468c15ea-5df8-4254-8655-7aed64532930"), false, new Guid("6162836a-2a06-435f-a68a-8e5c71e7dc55"), "ru-RU", "//div[@class='article__meta']/time/text()" },
                    { new Guid("4dd95883-c45d-4a6e-bc80-f49f71166902"), false, new Guid("c62f66a6-e033-49da-be9d-5b2f91ccf681"), "ru-RU", "//div[contains(@class, 'article__date-autor-shortcode')]/div[contains(@class, 'article__date')]/time[@class='date']/@datetime" },
                    { new Guid("583d6366-1146-4f67-b452-59b6f2134fed"), false, new Guid("4f549988-5e22-4ff7-894a-5c4534286c27"), "ru-RU", "//div[@class='article__header__info-block']/time[@class='article__header__date']/@datetime" },
                    { new Guid("5b67448a-65f6-42b5-b543-91a91aa4591a"), false, new Guid("38f81d5f-7291-45cc-837c-a6b1f084e0b8"), "ru-RU", "//article//header//div[contains(@class, 'styles_meta')]//div[contains(@class, 'styles_metaItem')]/text()" },
                    { new Guid("78bf8a2d-b919-4336-aa91-e73ca419c483"), false, new Guid("b4868cc2-8a0b-41fc-9b79-c27ff2e32367"), "ru-RU", "//div[@class='article_top']//div[@class='date']//time/text()" },
                    { new Guid("864d2301-0313-4d24-bfdb-2ff60e9629af"), false, new Guid("3245e73e-5095-4ace-baaa-7bd98636c5f7"), "ru-RU", "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark_publish')]//span[@ca-ts]/text()" },
                    { new Guid("95aba396-f90d-472f-ad37-0ec375925b3d"), false, new Guid("406583f6-7546-4f56-a64f-c607fdceb816"), "ru-RU", "//div[contains(@class, 'publication-footer')]//div[contains(@class, 'pubdatetime')]//div[contains(@class, 'badge-time')]/text()" },
                    { new Guid("9b0d6fb1-344f-4f8c-a4b2-f71baa46b9ba"), false, new Guid("fc7511f4-cefd-42bc-887d-ecd3fe1f1f5c"), "ru-RU", "//div[@class='date_full']/text()" },
                    { new Guid("9d589bf8-8ba7-427b-b10f-4a6a5a8c5807"), false, new Guid("fd11966c-2354-4de8-bcf3-32cf13af8557"), "ru-RU", "//div[@class='b-article__top-author']/p[@class='date']/text()" },
                    { new Guid("b689bd17-ab25-4737-8c4f-14d03e9c6110"), false, new Guid("32b9b313-6761-4279-93e2-039019ec5a50"), "ru-RU", "//div[@class='publication-info']/time[@itemprop='datePublished']/@datetime" },
                    { new Guid("bc71ee80-df2e-455a-9d88-e2e24eda93ad"), false, new Guid("5365e832-0a0a-4a13-b8a7-c636817cd4a3"), "ru-RU", "//div[contains(@class, 'full-article')]//time/text()" },
                    { new Guid("c48e8cd5-4448-4d89-95c6-2f95eb22d3d4"), false, new Guid("1af8a18d-a1f8-4212-a7f3-fb386cd48108"), "ru-RU", "//div[@class='doc_header__time']/time[@class='doc_header__publish_time']/@datetime" },
                    { new Guid("c5bb1825-5722-432f-992c-9b75b3443062"), false, new Guid("916f215f-4052-4081-a6ab-ab8293c8339b"), "ru-RU", "//article/div[@class='b_article-header']//time[@itemprop='datePublished']/@datetime" },
                    { new Guid("d41f5d9e-44e2-46b5-ba73-2bc50279c5e6"), false, new Guid("f062cb88-d748-4041-a882-83f880f6ae90"), "ru-RU", "//header[@class='news-item__header']//time/@content" },
                    { new Guid("da532857-460f-4763-a08b-7e9969fcce6c"), false, new Guid("49b0c029-7644-4da9-baf1-17ead81a7092"), "ru-RU", "//article[@itemprop='articleBody']/meta[@itemprop='datePublished']/@content" },
                    { new Guid("def71465-5535-4075-853c-787e0c4b5dd3"), false, new Guid("4daaa8c5-637e-4310-98c3-4614db190c23"), "ru-RU", "//div[contains(@class, 'PageArticleContent_date')]/text()" },
                    { new Guid("ed69c2d9-d54f-4535-a0a3-f1b8b5929e61"), false, new Guid("e827cb65-2270-434d-9d6d-22bb28fec91e"), "ru-RU", "//div[@class='article__info']//div[@class='article__info-date']/a/text()" },
                    { new Guid("faeae440-e28c-490d-a146-4fb8e67061ef"), false, new Guid("f4dac8a2-4cd0-4583-8ed8-cbb2727aa905"), "ru-RU", "//div[@class='article_page__left__top__left']//div[@class='article_page__left__top__time']//time/@datetime" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_sub_title_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("30d36136-4df5-4f36-983c-9754f70e46d2"), false, new Guid("4f549988-5e22-4ff7-894a-5c4534286c27"), "//div[contains(@class, 'article__text')]/div[@class='article__text__overview']/span/text()" },
                    { new Guid("4738e2e4-9f08-4789-be51-723c5895ca9d"), false, new Guid("90595a15-043e-4d33-88a5-769e3b8faff1"), "//h4/text()" },
                    { new Guid("54992a81-47e9-47cf-b26e-d7e81c7efaf2"), false, new Guid("fd11966c-2354-4de8-bcf3-32cf13af8557"), "//h4/text()" },
                    { new Guid("77dc627b-c239-4f0d-bc5e-5eb2b328ce14"), false, new Guid("e6096bc4-52cb-47f4-9abf-39cfcfd5b225"), "//div[contains(@class, 'topic-body__title')]/text()" },
                    { new Guid("78e1c370-521c-46e6-9dda-7393d78b14ea"), false, new Guid("916f215f-4052-4081-a6ab-ab8293c8339b"), "//h2/text()" },
                    { new Guid("7ab915c3-e988-435b-a8d5-c2ba5590cd0c"), false, new Guid("1af8a18d-a1f8-4212-a7f3-fb386cd48108"), "//header[@class='doc_header']/h2[contains(@class, 'doc_header__subheader')]/text()" },
                    { new Guid("8ae45fee-845c-47db-92a3-c4de5bf31cb7"), false, new Guid("e458f8da-388a-4cbc-afb9-78fc41777a42"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()=1]/text()" },
                    { new Guid("b2fa01ff-590e-4948-b652-3656102bc1ca"), false, new Guid("406583f6-7546-4f56-a64f-c607fdceb816"), "//div[@class='container-fluid shifted']/p[@class='announce lead']/text()" },
                    { new Guid("c311e235-521b-4f0b-94cb-4b3912850d88"), false, new Guid("e827cb65-2270-434d-9d6d-22bb28fec91e"), "//h1[@class='article__second-title']/text()" },
                    { new Guid("c6561422-6b01-49e1-b16d-2b322fc76303"), false, new Guid("38f81d5f-7291-45cc-837c-a6b1f084e0b8"), "//article//header//p[contains(@class, 'styles_subtitle')]/text()" },
                    { new Guid("d5ea3504-08b4-42b2-8bcc-ad47f0cdd122"), false, new Guid("4daaa8c5-637e-4310-98c3-4614db190c23"), "//div[contains(@class, 'PageArticleContent_lead')]/text()" },
                    { new Guid("eb82ffbb-bd82-4aef-a41c-724e3641ea61"), false, new Guid("5365e832-0a0a-4a13-b8a7-c636817cd4a3"), "//h1/text()" },
                    { new Guid("f4ba68cc-84e9-4759-ba7e-e6430c51abfc"), false, new Guid("3245e73e-5095-4ace-baaa-7bd98636c5f7"), "//h3/text()" },
                    { new Guid("fb4e915a-66ec-466d-874d-5988179520e0"), false, new Guid("c62f66a6-e033-49da-be9d-5b2f91ccf681"), "//div[contains(@class, 'article__summary')]/text()" },
                    { new Guid("fd453ee8-23c7-41c5-af6e-9234c137629b"), false, new Guid("6162836a-2a06-435f-a68a-8e5c71e7dc55"), "//div[@class='article__intro']/p/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_published_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("076e6afe-7a4f-4468-82d2-e1fbb9e9895f"), "HH:mm, dd MMMM yyyy", new Guid("105ad8fc-668d-4399-9420-50cccf35095f") },
                    { new Guid("09ac904e-9637-4b21-bf49-28f36c469da0"), "dd MMMM, HH:mm", new Guid("3fa07d3e-ecea-4664-ae68-42a8a49a79a5") },
                    { new Guid("0ae15cf2-a6f5-4036-aa99-c0f3bdfb397d"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("c48e8cd5-4448-4d89-95c6-2f95eb22d3d4") },
                    { new Guid("0bd77520-78e5-43e5-8be2-6e40a9596846"), "dd MMMM yyyy в HH:mm", new Guid("9d589bf8-8ba7-427b-b10f-4a6a5a8c5807") },
                    { new Guid("2e1eb39c-3b3e-4aaf-ab03-2f13c38c67c3"), "dd MMMM yyyy, HH:mm", new Guid("9b0d6fb1-344f-4f8c-a4b2-f71baa46b9ba") },
                    { new Guid("3cf43814-4dff-41c2-a917-f6d36d86eb0e"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("583d6366-1146-4f67-b452-59b6f2134fed") },
                    { new Guid("3d119bb3-cbfa-40a3-842f-2570dc1bdf8d"), "dd.MM.yyyy HH:mm", new Guid("bc71ee80-df2e-455a-9d88-e2e24eda93ad") },
                    { new Guid("3f2a03da-7fcd-4dc8-8c2c-7d92dbeb74c7"), "yyyy-MM-dd HH:mm:ss", new Guid("95aba396-f90d-472f-ad37-0ec375925b3d") },
                    { new Guid("4b161906-ed5b-4f15-806a-2ccd97e8a497"), "HH:mm dd.MM.yyyy", new Guid("ed69c2d9-d54f-4535-a0a3-f1b8b5929e61") },
                    { new Guid("56b32f9d-5b24-4ad3-b0b2-79d7f0940d60"), "dd MMMM yyyy, HH:mm", new Guid("5b67448a-65f6-42b5-b543-91a91aa4591a") },
                    { new Guid("5d1bb3e1-1b66-46d9-b9db-cc0af679fe25"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("c5bb1825-5722-432f-992c-9b75b3443062") },
                    { new Guid("7033633c-641a-4fcb-926f-b90ead0a0909"), "dd.MM.yyyy HH:mm", new Guid("def71465-5535-4075-853c-787e0c4b5dd3") },
                    { new Guid("82fd3c7d-1ad0-40f6-8f71-3b4139e17ced"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("d41f5d9e-44e2-46b5-ba73-2bc50279c5e6") },
                    { new Guid("85f2fa35-d435-4c06-9a73-5713c2d5e1ae"), "dd MMMM yyyy, HH:mm,", new Guid("864d2301-0313-4d24-bfdb-2ff60e9629af") },
                    { new Guid("8a89faf0-f6c4-4718-82ba-c670989bcbea"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("faeae440-e28c-490d-a146-4fb8e67061ef") },
                    { new Guid("8f92c2d9-d714-4239-ab85-5f9a8eb3c2a2"), "dd.MM.yyyy HH:mm", new Guid("78bf8a2d-b919-4336-aa91-e73ca419c483") },
                    { new Guid("9605e251-cee3-473f-bb06-a814e0c8d92c"), "dd MMMM yyyy HH:mm", new Guid("468c15ea-5df8-4254-8655-7aed64532930") },
                    { new Guid("abe8d881-f50c-4509-801d-606a08b51d88"), "dd MMMM  HH:mm", new Guid("1fec5734-9042-47ce-ab19-7cbc596ad5dc") },
                    { new Guid("afe589f8-5272-4c53-b254-d85f01594ed4"), "yyyy-MM-ddTHH:mm:ss", new Guid("da532857-460f-4763-a08b-7e9969fcce6c") },
                    { new Guid("b6f78c83-e41d-4fac-a18c-891c2e8d597d"), "dd MMMM yyyy, HH:mm", new Guid("3b1932ca-c7ec-4a26-933d-3884efe34501") },
                    { new Guid("b95d5925-b395-4929-aadb-e5762c0b0268"), "dd MMMM, HH:mm", new Guid("864d2301-0313-4d24-bfdb-2ff60e9629af") },
                    { new Guid("c2fe9413-dcf8-4049-9b8a-b117559b76e9"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("1e1a2d1e-2c4e-4798-a492-f0bf9f2eb98d") },
                    { new Guid("c96f9680-8cd3-414f-a9a2-e84b285b4050"), "dd MMMM yyyy, HH:mm", new Guid("864d2301-0313-4d24-bfdb-2ff60e9629af") },
                    { new Guid("d102b4a0-df7d-47ae-bb43-a7e523ce1866"), "dd MMMM, HH:mm", new Guid("5b67448a-65f6-42b5-b543-91a91aa4591a") },
                    { new Guid("d230a2d6-0e25-4967-a241-93bab65627f7"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("b689bd17-ab25-4737-8c4f-14d03e9c6110") },
                    { new Guid("d323c4a3-f8fc-4f12-936a-3473f797ae01"), "dd MMMM yyyy, HH:mm", new Guid("3fa07d3e-ecea-4664-ae68-42a8a49a79a5") },
                    { new Guid("dcb929ad-4c51-4325-b941-ee90f57a9e6f"), "dd MMMM yyyy, HH:mm МСК", new Guid("0d821148-acdc-4c1f-9e3a-c4c9cec23414") },
                    { new Guid("ee0681bd-4200-469a-8f48-e1d9e87250ec"), "dd MMMM, HH:mm,", new Guid("864d2301-0313-4d24-bfdb-2ff60e9629af") },
                    { new Guid("ee4f290a-9c56-41f5-83fc-6f057abb13b0"), "yyyy-MM-d HH:mm", new Guid("4dd95883-c45d-4a6e-bc80-f49f71166902") }
                });

            migrationBuilder.CreateIndex(
                name: "ix_news_editor_id",
                table: "news",
                column: "editor_id");

            migrationBuilder.CreateIndex(
                name: "ix_news_url_title",
                table: "news",
                columns: new[] { "url", "title" });

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
                name: "ix_news_sources_title_site_url_is_enabled",
                table: "news_sources",
                columns: new[] { "title", "site_url", "is_enabled" });

            migrationBuilder.CreateIndex(
                name: "ix_news_sub_titles_news_id",
                table: "news_sub_titles",
                column: "news_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_news_sub_titles_title",
                table: "news_sub_titles",
                column: "title");
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
                name: "news_parse_picture_settings");

            migrationBuilder.DropTable(
                name: "news_parse_published_at_settings_formats");

            migrationBuilder.DropTable(
                name: "news_parse_sub_title_settings");

            migrationBuilder.DropTable(
                name: "news_pictures");

            migrationBuilder.DropTable(
                name: "news_search_settings");

            migrationBuilder.DropTable(
                name: "news_source_logos");

            migrationBuilder.DropTable(
                name: "news_sub_titles");

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
