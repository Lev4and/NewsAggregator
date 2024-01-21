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
                    { new Guid("147258ad-f05d-4a77-b556-7e56c86194bf"), true, "https://lenta.ru/", "Лента.Ру" },
                    { new Guid("19a35add-963d-4275-bfa0-c3ecad4e3358"), true, "https://www.pravda.ru/", "Правда.ру" },
                    { new Guid("29efc8d3-2497-4424-ab9b-7d2f2eb5c7c8"), true, "https://www.interfax.ru/", "Интерфакс" },
                    { new Guid("2c8f34b3-2fd2-434a-9904-bca6b86cd975"), true, "https://www.m24.ru/", "Москва 24" },
                    { new Guid("2daa5eaa-b8c7-4b56-a453-c44726bf7960"), false, "https://ixbt.games/", "iXBT.games" },
                    { new Guid("2f301bfd-431a-4151-bef4-a138cb3df95e"), true, "https://3dnews.ru/", "3Dnews.ru" },
                    { new Guid("37c74940-de98-46c5-bbf3-d9bb2fb0daa5"), true, "https://www.belta.by/", "БелТА" },
                    { new Guid("38157586-4145-4907-b5ad-ec1fb2750f9b"), true, "https://aif.ru/", "Аргументы и факты" },
                    { new Guid("4acb15a0-d483-4bae-afc3-69d4fedcd248"), true, "https://tass.ru/", "ТАСС" },
                    { new Guid("50f4d942-72ec-443b-8a1d-c889097934e7"), true, "https://rg.ru/", "Российская газета" },
                    { new Guid("64473c5d-9e36-499e-bf21-9af4e85c2e14"), true, "https://svpressa.ru/", "СвободнаяПресса" },
                    { new Guid("6f51eeb9-c29a-41cc-aad4-6936097e1528"), true, "https://ura.news/", "Ura.ru" },
                    { new Guid("8ba42a81-271a-4436-bdc6-ded2cc6eb7ec"), true, "https://www.rbc.ru/", "РБК" },
                    { new Guid("929ebcc1-ff93-43a4-a0c6-980f713a8136"), true, "https://vz.ru/", "ВЗГЛЯД.РУ" },
                    { new Guid("99c694ad-df8b-4f5f-8112-f9f2ab32dbe3"), true, "https://life.ru/", "Life" },
                    { new Guid("a197952e-7499-4f8b-9536-1b41e2a10d24"), true, "https://ria.ru/", "РИА Новости" },
                    { new Guid("ba60670c-60b0-4e77-9905-636565c6fe11"), true, "https://www.gazeta.ru/", "Газета.Ru" },
                    { new Guid("bcaea141-1b53-46c3-91c1-46003251bddf"), true, "https://www.championat.com/", "Чемпионат.com" },
                    { new Guid("d1a0d69f-10e9-4710-8fe1-a45fe2735e48"), true, "https://www.sports.ru/", "Storts.ru" },
                    { new Guid("d62e974f-a9b7-4a2d-a137-250a019400d1"), true, "https://www.kommersant.ru/", "Коммерсантъ" },
                    { new Guid("dd145374-ff9c-4599-ade5-8d43651e0eef"), false, "https://tsargrad.tv/", "Царьград" },
                    { new Guid("e9cf1dfb-a5ab-430d-9fd1-becc34f78728"), true, "https://russian.rt.com/", "RT на русском" },
                    { new Guid("f500aa54-f266-4e9d-a8e7-ec23a3552d2a"), true, "https://www.ixbt.com/", "iXBT.com" },
                    { new Guid("f99e47cb-be14-491e-bce3-afaf830bd1e7"), true, "https://iz.ru/", "Известия" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_settings",
                columns: new[] { "id", "description_x_path", "source_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("05e1dd93-5fb4-4595-8de3-047f4d03f624"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview'))]", new Guid("8ba42a81-271a-4436-bdc6-ded2cc6eb7ec"), "//h1/text()" },
                    { new Guid("163c7384-de2b-439c-9617-c7b4fd6c270b"), "//div[@class='container-fluid shifted']/p[@class='announce lead']", new Guid("2daa5eaa-b8c7-4b56-a453-c44726bf7960"), "//h1/text()" },
                    { new Guid("1ca4538c-ef2b-44a4-ac9b-d27b40c95e1b"), "//article/div[@class='article-content']/*[not(@class)]", new Guid("bcaea141-1b53-46c3-91c1-46003251bddf"), "//article/header/div[@class='article-head__title']/text()" },
                    { new Guid("1dc1dc93-a870-4ab5-a6dd-37a709eed7b7"), "//div[@class='topic-body__content']", new Guid("147258ad-f05d-4a77-b556-7e56c86194bf"), "//h1[@class='topic-body__titles']/span[@class='topic-body__title']/text()" },
                    { new Guid("2d9502b8-ac2b-442f-b201-01b22d67154f"), "//div[@itemprop='articleBody']", new Guid("ba60670c-60b0-4e77-9905-636565c6fe11"), "//h1/text()" },
                    { new Guid("2f3e3168-006b-4cdb-8204-5dcafa065de6"), "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]", new Guid("2c8f34b3-2fd2-434a-9904-bca6b86cd975"), "//h1/text()" },
                    { new Guid("38b04bdb-1c58-4cb1-8eb4-78d321405886"), "//div[contains(@class, 'news-item__content')]", new Guid("d1a0d69f-10e9-4710-8fe1-a45fe2735e48"), "//h1/text()" },
                    { new Guid("3ee3448d-bd4f-4477-8daf-3de4e50aa96a"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]", new Guid("d62e974f-a9b7-4a2d-a137-250a019400d1"), "//h1/text()" },
                    { new Guid("49e093cd-3af7-4003-8927-d6b02046a503"), "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]", new Guid("29efc8d3-2497-4424-ab9b-7d2f2eb5c7c8"), "//h1/text()" },
                    { new Guid("4ff97136-173c-489a-9ca2-31ab866769ca"), "//div[@itemprop='articleBody']/*[not(name()='div')]", new Guid("6f51eeb9-c29a-41cc-aad4-6936097e1528"), "//h1/text()" },
                    { new Guid("5437770d-51cd-4224-acfe-71ac8643933b"), "//div[@class='js-mediator-article']", new Guid("37c74940-de98-46c5-bbf3-d9bb2fb0daa5"), "//h1/text()" },
                    { new Guid("6263c88f-f7c2-4829-ad04-83037c479360"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]", new Guid("dd145374-ff9c-4599-ade5-8d43651e0eef"), "//h1[@class='article__title']/text()" },
                    { new Guid("62a2836b-0bc4-4bdd-8fdc-08098a893046"), "//div[@class='article_text']", new Guid("38157586-4145-4907-b5ad-ec1fb2750f9b"), "//h1/text()" },
                    { new Guid("753f91b8-25fb-4c8c-b6e2-14b91ee7f358"), "//article", new Guid("4acb15a0-d483-4bae-afc3-69d4fedcd248"), "//h1/text()" },
                    { new Guid("76e0cdbd-76ca-4143-b592-c7c6e97c187e"), "//div[@itemprop='articleBody']", new Guid("f500aa54-f266-4e9d-a8e7-ec23a3552d2a"), "//h1/text()" },
                    { new Guid("80846df7-b64a-4963-a976-57299a2e46b6"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()>1]", new Guid("2f301bfd-431a-4151-bef4-a138cb3df95e"), "//h1/text()" },
                    { new Guid("9349a121-f4f6-4b0f-9d35-1e1b4d812f4c"), "//div[contains(@class, 'article__body')]", new Guid("a197952e-7499-4f8b-9536-1b41e2a10d24"), "//div[@class='article__title']/text()" },
                    { new Guid("a6841495-39a8-4f93-a985-bf1abd099ad3"), "//div[contains(@class, 'article__text ')]", new Guid("e9cf1dfb-a5ab-430d-9fd1-becc34f78728"), "//h1/text()" },
                    { new Guid("a944a4cc-622d-42c0-9ba3-cc2193760dea"), "//div[@itemprop='articleBody']", new Guid("f99e47cb-be14-491e-bce3-afaf830bd1e7"), "//h1/span/text()" },
                    { new Guid("afcd2e00-4b85-4f71-bb86-abbf28380745"), "//div[contains(@class, 'PageContentCommonStyling_text')]", new Guid("50f4d942-72ec-443b-8a1d-c889097934e7"), "//h1/text()" },
                    { new Guid("b28d1a10-856c-4485-8d17-ef59370e2409"), "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]", new Guid("99c694ad-df8b-4f5f-8112-f9f2ab32dbe3"), "//h1/text()" },
                    { new Guid("bcc61929-4aec-4515-bf48-4898367e61ce"), "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]", new Guid("64473c5d-9e36-499e-bf21-9af4e85c2e14"), "//h1[@class='b-text__title']/text()" },
                    { new Guid("be652a00-ce3b-426b-b877-bd8bb94c2e34"), "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]", new Guid("19a35add-963d-4275-bfa0-c3ecad4e3358"), "//h1/text()" },
                    { new Guid("bf6e90ae-1901-4f8b-89f2-909e305d05f0"), "//article/div[@class='news_text']", new Guid("929ebcc1-ff93-43a4-a0c6-980f713a8136"), "//h1/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_search_settings",
                columns: new[] { "id", "news_site_url", "news_url_x_path", "source_id" },
                values: new object[,]
                {
                    { new Guid("00ee14e9-c84c-4df3-8eed-946e8b54a522"), "https://svpressa.ru/all/news/", "//a[contains(@href, '/news/') and not(contains(@href, '?')) and not(starts-with(@href, '/all/news/'))]/@href", new Guid("64473c5d-9e36-499e-bf21-9af4e85c2e14") },
                    { new Guid("05d0e9f1-f058-410f-ad9b-97b8855fd536"), "https://iz.ru/news/", "//a[contains(@href, '?main_click')]/@href", new Guid("f99e47cb-be14-491e-bce3-afaf830bd1e7") },
                    { new Guid("0aea9241-eabe-4233-9254-d15fa7297fda"), "https://www.championat.com/news/1.html?utm_source=button&utm_medium=news", "//a[contains(@href, 'news-') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("bcaea141-1b53-46c3-91c1-46003251bddf") },
                    { new Guid("16b0bcbc-bea4-469b-9277-806c1d684ddb"), "https://3dnews.ru/news/", "//div[@class='news-feed-all']//a[@class='entry-header']/h1/../@href", new Guid("2f301bfd-431a-4151-bef4-a138cb3df95e") },
                    { new Guid("1cff152f-188b-4c6d-bb69-b0082ccdc734"), "https://rg.ru/", "//a[contains(@href, '.html')]/@href", new Guid("50f4d942-72ec-443b-8a1d-c889097934e7") },
                    { new Guid("554d1854-d455-46b8-9f5c-e4c4222af75d"), "https://russian.rt.com/", "//a[contains(@class, 'link') and contains(@href, 'news/')]/@href", new Guid("e9cf1dfb-a5ab-430d-9fd1-becc34f78728") },
                    { new Guid("64b49bce-e1e9-4072-9c00-d7456908704e"), "https://tass.ru/", "//a[contains(@class, 'tass_pkg_link-v5WdK') and contains(substring(@href, 2), '/') and not(contains(@href, '/spec/')) and not(contains(@href, 'spec.tass.ru'))]/@href", new Guid("4acb15a0-d483-4bae-afc3-69d4fedcd248") },
                    { new Guid("69b33768-6cf9-418e-baf6-3b8de2bedfbc"), "https://www.sports.ru/news/", "//a[contains(@href, '.html') and not(contains(@href, '.html#comments'))]/@href", new Guid("d1a0d69f-10e9-4710-8fe1-a45fe2735e48") },
                    { new Guid("756edc5e-ceaa-4f26-b942-6360f2154368"), "https://ura.news/", "//a[contains(@href, '/news/')]/@href", new Guid("6f51eeb9-c29a-41cc-aad4-6936097e1528") },
                    { new Guid("7bbcc591-7884-490f-bf65-779549bc443d"), "https://www.ixbt.com/news/", "//a[starts-with(@href, '/news/') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("f500aa54-f266-4e9d-a8e7-ec23a3552d2a") },
                    { new Guid("8a2d2f95-5a5b-4144-a07f-57eec9f7dc04"), "https://www.kommersant.ru/", "//a[contains(@href, '/doc/') and contains(@href, '?from=')]/@href", new Guid("d62e974f-a9b7-4a2d-a137-250a019400d1") },
                    { new Guid("8d1e7fb3-27bf-467e-9783-69c949a9243f"), "https://www.gazeta.ru/news/", "//a[contains(@href, '/news/') and contains(@href, '.shtml') and not(contains(@href, '?'))]/@href", new Guid("ba60670c-60b0-4e77-9905-636565c6fe11") },
                    { new Guid("a4d51c01-89e4-400b-b3e4-18f3962705fd"), "https://tsargrad.tv/", "//a[contains(@class, 'news-item__link')]/@href", new Guid("dd145374-ff9c-4599-ade5-8d43651e0eef") },
                    { new Guid("b2beb5cb-e9f5-45d4-a5d0-a286844ffbba"), "https://www.pravda.ru/", "//a[contains(@href, '/news/') and not(@href='https://www.pravda.ru/news/')]/@href", new Guid("19a35add-963d-4275-bfa0-c3ecad4e3358") },
                    { new Guid("b539a2a6-fe43-4fe0-9bde-821594942eab"), "https://www.m24.ru/", "//a[contains(@href, '/news/')]/@href", new Guid("2c8f34b3-2fd2-434a-9904-bca6b86cd975") },
                    { new Guid("c132ccfa-c8e5-4ad3-929a-a8ca2a7b8fa4"), "https://aif.ru/", "//span[contains(@class, 'item_text__title')]/../@href", new Guid("38157586-4145-4907-b5ad-ec1fb2750f9b") },
                    { new Guid("c83d178c-7212-4a67-86b6-cfe50f1eee74"), "https://lenta.ru/", "//a[starts-with(@href, '/news/')]/@href", new Guid("147258ad-f05d-4a77-b556-7e56c86194bf") },
                    { new Guid("ca20471c-4ca4-406e-a27a-cac3cdfde6eb"), "https://life.ru/s/novosti", "//a[contains(@href, '/p/')]/@href", new Guid("99c694ad-df8b-4f5f-8112-f9f2ab32dbe3") },
                    { new Guid("d144b835-27ea-454c-bfa0-2cf6925f4a66"), "https://www.belta.by/", "//a[contains(@href, 'https://www.belta.by/') and contains(@href, '/view/')]/@href", new Guid("37c74940-de98-46c5-bbf3-d9bb2fb0daa5") },
                    { new Guid("deae4842-1289-4e26-928c-6317f30482aa"), "https://ixbt.games/news/", "//a[@class='card-link']/@href", new Guid("2daa5eaa-b8c7-4b56-a453-c44726bf7960") },
                    { new Guid("e39d4870-606c-480d-879a-6d0f54592c59"), "https://ria.ru/", "//a[contains(@class, 'cell-list__item-link')]/@href", new Guid("a197952e-7499-4f8b-9536-1b41e2a10d24") },
                    { new Guid("e62deb5b-e764-4e17-a69c-ba6543288305"), "https://vz.ru/", "//a[contains(@href, '.html') and not(contains(@href, '#comments')) and not(contains(@href, '?')) and not(contains(@href, '/about/'))]/@href", new Guid("929ebcc1-ff93-43a4-a0c6-980f713a8136") },
                    { new Guid("e7492f37-3bf2-4e43-b105-5cdf3225251e"), "https://www.rbc.ru/", "//a[contains(@href, 'https://www.rbc.ru/') and contains(@href, '?from=')]/@href", new Guid("8ba42a81-271a-4436-bdc6-ded2cc6eb7ec") },
                    { new Guid("f7e6a3c5-7748-4c46-bb15-e56f66d9dcf9"), "https://www.interfax.ru/", "//div[@class='timeline']//a[@tabindex=5]/@href", new Guid("29efc8d3-2497-4424-ab9b-7d2f2eb5c7c8") }
                });

            migrationBuilder.InsertData(
                table: "news_source_logos",
                columns: new[] { "id", "source_id", "url" },
                values: new object[] { new Guid("7f98b3ef-03b1-434f-8041-f71236c99521"), new Guid("2daa5eaa-b8c7-4b56-a453-c44726bf7960"), "https://sun13-2.userapi.com/s/v1/ig2/_ID-2w6Llad8ig5_987dKAfh1pyLdj7HfLHqGx9HxyDjoEDN7wxR0ZWJm5ja1Ey6UuQXaEYEBW1Zd51cpRrjSGfS.jpg?size=100x100&quality=96&crop=22,22,626,626&ava=1" });

            migrationBuilder.InsertData(
                table: "news_parse_editor_settings",
                columns: new[] { "id", "is_required", "name_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("278844a1-77e4-400d-851a-d28fd5176bed"), true, "//div[@itemprop='author']/span[@itemprop='name']/text()", new Guid("4ff97136-173c-489a-9ca2-31ab866769ca") },
                    { new Guid("2b2e0508-06d0-4988-be9d-303eee482389"), true, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']//a[@itemprop='author']//span[@itemprop='name']/text()", new Guid("80846df7-b64a-4963-a976-57299a2e46b6") },
                    { new Guid("2ebbf9d8-6864-4db9-a543-1f2201b8923e"), true, "//span[@itemprop='author']/span[@itemprop='name']/@content", new Guid("76e0cdbd-76ca-4143-b592-c7c6e97c187e") },
                    { new Guid("5620535c-e334-4d44-b7b6-680876919991"), false, "//div[@class='article__authors']//*[@class='article__authors__author']/span[@class='article__authors__author__name']/text()", new Guid("05e1dd93-5fb4-4595-8de3-047f4d03f624") },
                    { new Guid("74079e66-75ee-4932-945a-1890fd4e08b3"), false, "//div[@class='author']/span[@itemprop='author']/span[@itemprop='name']/a/text()", new Guid("2d9502b8-ac2b-442f-b201-01b22d67154f") },
                    { new Guid("974a7ba8-32d8-4d9e-8e2b-038dead7c088"), true, "//div[contains(@class, 'styles_bodyWrapper')]//div[contains(@class, 'styles_authorsLinks')]/a/text()", new Guid("b28d1a10-856c-4485-8d17-ef59370e2409") },
                    { new Guid("b1fbd03e-f19e-45a8-b814-3ee89c9b932a"), true, "//footer[@class='news-item__footer']/div[@class='news-item__footer-after-news']/p[position()=1]//span/text()", new Guid("38b04bdb-1c58-4cb1-8eb4-78d321405886") },
                    { new Guid("b4d1c26d-3fde-4ca0-87bf-3b1d42d6ee84"), true, "//div[contains(@class, 'full-article')]/div[@class='authors-block']//span[text()='Автор']/../a/text()", new Guid("be652a00-ce3b-426b-b877-bd8bb94c2e34") },
                    { new Guid("be11cf13-de7f-49be-9cdd-10e2f1d8a864"), true, "//div[@class='article_top']//div[@class='authors']//div[@class='autor']//span/text()", new Guid("62a2836b-0bc4-4bdd-8fdc-08098a893046") },
                    { new Guid("d3a9e6b1-b45d-44d3-b4d0-c10f595d34a3"), true, "//a[@class='article__author']/text()", new Guid("6263c88f-f7c2-4829-ad04-83037c479360") },
                    { new Guid("d3b692e7-584b-4a17-9e51-24123e8d45ab"), true, "//div[contains(@class, 'PageArticleContent_authors')]//a[contains(@class, 'LinksOfAuthor_item')]/text()", new Guid("afcd2e00-4b85-4f71-bb86-abbf28380745") },
                    { new Guid("d5097df8-e366-43a4-9e4c-415e330880dd"), true, "//div[@class='container-fluid publication-footer']//a[contains(@class, 'text-secondary')]/@title", new Guid("163c7384-de2b-439c-9617-c7b4fd6c270b") },
                    { new Guid("d77058e2-74ed-4bbf-a0f8-449b80ab86cf"), true, "//article//header//div[@class='article-head__author-name']/a[@rel='author']/span/text()", new Guid("1ca4538c-ef2b-44a4-ac9b-d27b40c95e1b") },
                    { new Guid("e867d306-5c93-4e3c-b102-671bceb69934"), false, "//p[@class='doc__text document_authors']/text()", new Guid("3ee3448d-bd4f-4477-8daf-3de4e50aa96a") },
                    { new Guid("e9e8379b-1bda-4711-8cd5-b11fd7f7eaae"), false, "//div[@class='topic-authors']/a[@class='topic-authors__author']/text()", new Guid("1dc1dc93-a870-4ab5-a6dd-37a709eed7b7") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_picture_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("03f09b97-3094-4603-81a8-7f3b601efb92"), true, new Guid("6263c88f-f7c2-4829-ad04-83037c479360"), "//div[@class='article__media']//img/@src" },
                    { new Guid("265d5dd2-4966-46c6-9e65-8b34c9ba421f"), false, new Guid("b28d1a10-856c-4485-8d17-ef59370e2409"), "//article//header/div[contains(@class, 'styles_cover_media')]/img/@src" },
                    { new Guid("27d52dac-7d79-4652-b2af-2f0417bf9b25"), false, new Guid("bf6e90ae-1901-4f8b-89f2-909e305d05f0"), "//article/figure/img/@src" },
                    { new Guid("2b576f9f-dc55-4713-8303-4b0b2dcf1da8"), false, new Guid("80846df7-b64a-4963-a976-57299a2e46b6"), "//div[contains(@class, 'article-entry')]//div[contains(@class, 'entry-body')]//div[@class='source-wrapper']/img[@itemprop='image']/@src" },
                    { new Guid("2f4fa5ee-6272-4ea1-862b-da0b424b5295"), false, new Guid("be652a00-ce3b-426b-b877-bd8bb94c2e34"), "//div[contains(@class, 'full-article')]/div[contains(@class, 'gallery')]/picture/img/@src" },
                    { new Guid("3080198a-a6e9-4eac-8575-983cac8fc2f1"), false, new Guid("9349a121-f4f6-4b0f-9d35-1e1b4d812f4c"), "//div[@class='photoview__open']/img/@src" },
                    { new Guid("35ca950a-2d08-4a5b-b933-b11d40862974"), true, new Guid("163c7384-de2b-439c-9617-c7b4fd6c270b"), "//a[@class='glightbox']/img[contains(@class, 'pub-cover')]/@src" },
                    { new Guid("472f71f7-ba60-4dd8-8b33-2697978dd787"), false, new Guid("2d9502b8-ac2b-442f-b201-01b22d67154f"), "//div[@class='b_article-media']//div[@class='mainarea-wrapper']/figure/img[@class='item-image-front']/@src" },
                    { new Guid("535c1044-744b-4788-91d8-ee3d24895700"), true, new Guid("4ff97136-173c-489a-9ca2-31ab866769ca"), "//div[@itemprop='articleBody']//div[@itemprop='image']/picture/img[@itemprop='contentUrl']/@src" },
                    { new Guid("729fb8f8-16a4-4863-89f8-7dbe9d54b91a"), false, new Guid("5437770d-51cd-4224-acfe-71ac8643933b"), "//div[@class='inner_content']//div[@class='main_img']//img/@src" },
                    { new Guid("80901c3b-59b1-43bf-8424-f4d46fcea84f"), false, new Guid("753f91b8-25fb-4c8c-b6e2-14b91ee7f358"), "//div[contains(@class, 'HeaderMedia_image')]//img[contains(@class, 'Image_image')]/@src" },
                    { new Guid("ab5428d5-7c7b-4b4c-ac53-0e4aa47b7389"), false, new Guid("1dc1dc93-a870-4ab5-a6dd-37a709eed7b7"), "//div[contains(@class, 'topic-body__title-image')]//img[contains(@class, 'picture__image')]/@src" },
                    { new Guid("ae279204-3bf7-42a7-a103-556d726b78ee"), true, new Guid("a944a4cc-622d-42c0-9ba3-cc2193760dea"), "//div[contains(@class, 'big_photo')]//div[@class='big_photo__img']//img/@src" },
                    { new Guid("bf71c232-2fb0-459a-9a11-a07513fb29b2"), false, new Guid("1ca4538c-ef2b-44a4-ac9b-d27b40c95e1b"), "//article//header/div[@class='article-head__photo']/img/@src" },
                    { new Guid("c807f750-9fa1-47de-b52d-63d990b60afc"), false, new Guid("62a2836b-0bc4-4bdd-8fdc-08098a893046"), "//div[@class='img_box']/a[@class='zoom_js']/img/@src" },
                    { new Guid("c9b38268-3fe1-485c-8575-bbd390c95fbf"), true, new Guid("2f3e3168-006b-4cdb-8204-5dcafa065de6"), "//div[@class='b-material-incut-m-image']//@src" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "published_at_culture_info", "published_at_time_zone_info_id", "published_at_x_path" },
                values: new object[,]
                {
                    { new Guid("0080d000-f9f2-44a1-a170-a4088a754d54"), true, new Guid("bf6e90ae-1901-4f8b-89f2-909e305d05f0"), "ru-RU", "Russian Standard Time", "//article/div[@class='header']/span/text()" },
                    { new Guid("01c415d2-b197-4f99-8d9d-188663af8dc6"), true, new Guid("2d9502b8-ac2b-442f-b201-01b22d67154f"), "ru-RU", null, "//article/div[@class='b_article-header']//time[@itemprop='datePublished']/@datetime" },
                    { new Guid("0aefb553-2918-4b25-bee5-8fc1a0fe5a68"), true, new Guid("1ca4538c-ef2b-44a4-ac9b-d27b40c95e1b"), "ru-RU", "Russian Standard Time", "//article//header//time[@class='article-head__date']/text()" },
                    { new Guid("13ff07fd-4685-4511-92e0-8e10a660b010"), true, new Guid("a6841495-39a8-4f93-a985-bf1abd099ad3"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'article__date-autor-shortcode')]/div[contains(@class, 'article__date')]/time[@class='date']/@datetime" },
                    { new Guid("24f401f7-2c34-4c86-b4ec-d6fcea3dcc41"), true, new Guid("1dc1dc93-a870-4ab5-a6dd-37a709eed7b7"), "ru-RU", "Russian Standard Time", "//div[@class='topic-page__header']//a[contains(@class, 'topic-header__time')]/text()" },
                    { new Guid("2e232f21-fe86-4e78-b3a1-6948d2c46803"), true, new Guid("bcc61929-4aec-4515-bf48-4898367e61ce"), "ru-RU", "Russian Standard Time", "//div[@class='b-text__date']/text()" },
                    { new Guid("35bfa071-de11-495d-93dd-b40c2371e65b"), true, new Guid("62a2836b-0bc4-4bdd-8fdc-08098a893046"), "ru-RU", "Russian Standard Time", "//div[@class='article_top']//div[@class='date']//time/text()" },
                    { new Guid("3bec87cb-a160-4795-8083-eec7267f3212"), true, new Guid("163c7384-de2b-439c-9617-c7b4fd6c270b"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'publication-footer')]//div[contains(@class, 'pubdatetime')]//div[contains(@class, 'badge-time')]/text()" },
                    { new Guid("422ed1a2-a6ad-42ee-8b56-ff69011d02ff"), true, new Guid("38b04bdb-1c58-4cb1-8eb4-78d321405886"), "ru-RU", null, "//header[@class='news-item__header']//time/@content" },
                    { new Guid("552683f8-8848-43a5-b57c-927bfd06b23e"), true, new Guid("76e0cdbd-76ca-4143-b592-c7c6e97c187e"), "ru-RU", "Russian Standard Time", "//div[@class='b-article__top-author']/p[@class='date']/text()" },
                    { new Guid("5fe0613d-38d3-4848-ab76-c2848ae68188"), true, new Guid("4ff97136-173c-489a-9ca2-31ab866769ca"), "ru-RU", null, "//div[@class='publication-info']/time[@itemprop='datePublished']/@datetime" },
                    { new Guid("649b89fe-000a-469b-a618-bc3644b9f140"), true, new Guid("be652a00-ce3b-426b-b877-bd8bb94c2e34"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'full-article')]//time/text()" },
                    { new Guid("72e77997-5546-4b49-9697-2d8a8e27219f"), true, new Guid("80846df7-b64a-4963-a976-57299a2e46b6"), "ru-RU", null, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']/span[@itemprop='datePublished']/@content" },
                    { new Guid("7996146f-490a-408a-999b-204d3c747a9c"), true, new Guid("3ee3448d-bd4f-4477-8daf-3de4e50aa96a"), "ru-RU", null, "//div[@class='doc_header__time']/time[@class='doc_header__publish_time']/@datetime" },
                    { new Guid("7d06a275-028c-4021-995a-66bb200bf510"), true, new Guid("49e093cd-3af7-4003-8927-d6b02046a503"), "ru-RU", "Russian Standard Time", "//article[@itemprop='articleBody']/meta[@itemprop='datePublished']/@content" },
                    { new Guid("7d4c3440-3741-4dd2-af21-417403054367"), true, new Guid("afcd2e00-4b85-4f71-bb86-abbf28380745"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'PageArticleContent_date')]/text()" },
                    { new Guid("7fd02af4-d286-47da-83df-5d3a88822d18"), true, new Guid("9349a121-f4f6-4b0f-9d35-1e1b4d812f4c"), "ru-RU", "Russian Standard Time", "//div[@class='article__info']//div[@class='article__info-date']/a/text()" },
                    { new Guid("9c5ecd0b-b433-4542-804d-66eedcd1d7da"), true, new Guid("6263c88f-f7c2-4829-ad04-83037c479360"), "ru-RU", "Russian Standard Time", "//div[@class='article__meta']/time/text()" },
                    { new Guid("afab8f1c-8af4-4315-a26e-0816a26755d2"), true, new Guid("b28d1a10-856c-4485-8d17-ef59370e2409"), "ru-RU", "UTC", "//article//header//div[contains(@class, 'styles_meta')]//div[contains(@class, 'styles_metaItem')]/text()" },
                    { new Guid("b8e58a34-0faa-430c-beaa-25f9af3be339"), true, new Guid("05e1dd93-5fb4-4595-8de3-047f4d03f624"), "ru-RU", null, "//div[@class='article__header__info-block']/time[@class='article__header__date']/@datetime" },
                    { new Guid("c7d69b56-09b1-4497-826b-ce6c68510ede"), true, new Guid("5437770d-51cd-4224-acfe-71ac8643933b"), "ru-RU", "Russian Standard Time", "//div[@class='date_full']/text()" },
                    { new Guid("f212d64c-e7bb-43f9-a06e-d66b3f05bb52"), true, new Guid("753f91b8-25fb-4c8c-b6e2-14b91ee7f358"), "ru-RU", "UTC", "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark')]//span[@ca-ts]/text()" },
                    { new Guid("f88e47bc-c24a-4ce0-bc28-e5038366abb1"), true, new Guid("2f3e3168-006b-4cdb-8204-5dcafa065de6"), "ru-RU", "Russian Standard Time", "//p[@class='b-material__date']/text()" },
                    { new Guid("fa88741b-d158-4c3d-94a7-387d13b0260f"), true, new Guid("a944a4cc-622d-42c0-9ba3-cc2193760dea"), "ru-RU", null, "//div[@class='article_page__left__top__left']//div[@class='article_page__left__top__time']//time/@datetime" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_sub_title_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("00a63017-114f-4262-a8a1-e94e138b75a5"), true, new Guid("163c7384-de2b-439c-9617-c7b4fd6c270b"), "//div[@class='container-fluid shifted']/p[@class='announce lead']/text()" },
                    { new Guid("02c8384e-6824-4897-9af7-945ca8a3dbe3"), false, new Guid("76e0cdbd-76ca-4143-b592-c7c6e97c187e"), "//h4/text()" },
                    { new Guid("0b148c62-9e4b-43b1-94d1-95bbf320d626"), false, new Guid("afcd2e00-4b85-4f71-bb86-abbf28380745"), "//div[contains(@class, 'PageArticleContent_lead')]/text()" },
                    { new Guid("10e6cdf0-0010-436f-967b-6714c61bf805"), true, new Guid("a6841495-39a8-4f93-a985-bf1abd099ad3"), "//div[contains(@class, 'article__summary')]/text()" },
                    { new Guid("13ae90f0-2448-4752-b941-0fbbeaae01c6"), true, new Guid("be652a00-ce3b-426b-b877-bd8bb94c2e34"), "//h1/text()" },
                    { new Guid("26ae1787-3601-417a-8c38-daeb01326245"), false, new Guid("b28d1a10-856c-4485-8d17-ef59370e2409"), "//article//header//p[contains(@class, 'styles_subtitle')]/text()" },
                    { new Guid("32970001-947e-4d3b-820e-784cfecf2d35"), false, new Guid("753f91b8-25fb-4c8c-b6e2-14b91ee7f358"), "//h3/text()" },
                    { new Guid("40458738-b3dd-457e-a9cf-f37d977940d5"), false, new Guid("bf6e90ae-1901-4f8b-89f2-909e305d05f0"), "//h4/text()" },
                    { new Guid("48314a5a-e0d0-4b55-94e7-0a584b0b1e27"), true, new Guid("2d9502b8-ac2b-442f-b201-01b22d67154f"), "//h2/text()" },
                    { new Guid("a6b05cfe-1eec-4691-ae8c-2b047a9e0675"), false, new Guid("05e1dd93-5fb4-4595-8de3-047f4d03f624"), "//div[contains(@class, 'article__text')]/div[@class='article__text__overview']/span/text()" },
                    { new Guid("ae1923d9-635b-4bb2-a326-81e05612347c"), true, new Guid("9349a121-f4f6-4b0f-9d35-1e1b4d812f4c"), "//h1[@class='article__second-title']/text()" },
                    { new Guid("b847ad15-20bd-4274-9632-1a0e3e72a0d2"), true, new Guid("6263c88f-f7c2-4829-ad04-83037c479360"), "//div[@class='article__intro']/p/text()" },
                    { new Guid("e21a43d9-2899-40c6-9216-c10fad04c9dc"), false, new Guid("1dc1dc93-a870-4ab5-a6dd-37a709eed7b7"), "//div[contains(@class, 'topic-body__title')]/text()" },
                    { new Guid("e88117e4-5a9b-4514-ad36-d22a4e813801"), true, new Guid("80846df7-b64a-4963-a976-57299a2e46b6"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()=1]/text()" },
                    { new Guid("f5064daf-e9c1-40e5-9e85-55b13b3bba33"), false, new Guid("3ee3448d-bd4f-4477-8daf-3de4e50aa96a"), "//header[@class='doc_header']/h2[contains(@class, 'doc_header__subheader')]/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_published_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("13639129-3718-463a-8f55-c9480deca981"), "dd.MM.yyyy HH:mm", new Guid("35bfa071-de11-495d-93dd-b40c2371e65b") },
                    { new Guid("1671dd1e-be8f-4e17-83b8-0b7eb759b53e"), "dd MMMM yyyy в HH:mm", new Guid("552683f8-8848-43a5-b57c-927bfd06b23e") },
                    { new Guid("196f9924-edaf-472e-9d4d-42c92a0e367f"), "dd MMMM yyyy, HH:mm", new Guid("0080d000-f9f2-44a1-a170-a4088a754d54") },
                    { new Guid("20570763-888a-4063-8d43-8b9993df5dc4"), "yyyy-MM-dd HH:mm:ss", new Guid("3bec87cb-a160-4795-8083-eec7267f3212") },
                    { new Guid("260b36bb-d8e1-4c47-a6fc-00136764f92a"), "dd MMMM yyyy HH:mm", new Guid("2e232f21-fe86-4e78-b3a1-6948d2c46803") },
                    { new Guid("2cf7deb6-f217-4d35-91f0-60bc76671926"), "dd.MM.yyyy HH:mm", new Guid("649b89fe-000a-469b-a618-bc3644b9f140") },
                    { new Guid("2f1f0d26-1b31-47c7-9c52-ec9c82488338"), "HH:mm", new Guid("9c5ecd0b-b433-4542-804d-66eedcd1d7da") },
                    { new Guid("35b11128-a7b6-4258-8514-660b85b448a6"), "dd MMMM yyyy, HH:mm", new Guid("afab8f1c-8af4-4315-a26e-0816a26755d2") },
                    { new Guid("3fcd5446-d86f-4a9a-9d1d-07585006cbde"), "yyyy-MM-d HH:mm", new Guid("13ff07fd-4685-4511-92e0-8e10a660b010") },
                    { new Guid("5f6dea4a-6229-4970-9820-2472a2451af4"), "yyyy-MM-ddTHH:mm:ss", new Guid("7d06a275-028c-4021-995a-66bb200bf510") },
                    { new Guid("6181d869-4a78-44f0-82b1-18a1e206089d"), "dd MMMM yyyy, HH:mm", new Guid("c7d69b56-09b1-4497-826b-ce6c68510ede") },
                    { new Guid("61cff827-381a-4470-8a14-03887b543e03"), "dd MMMM, HH:mm", new Guid("f88e47bc-c24a-4ce0-bc28-e5038366abb1") },
                    { new Guid("64c37409-de70-45a8-b57f-3418cbc34332"), "dd MMMM yyyy, HH:mm", new Guid("f212d64c-e7bb-43f9-a06e-d66b3f05bb52") },
                    { new Guid("75fe5a06-241a-4675-840d-e599bd57258f"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("7996146f-490a-408a-999b-204d3c747a9c") },
                    { new Guid("7ff09c4d-d5c2-499d-869a-7990755fabee"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("72e77997-5546-4b49-9697-2d8a8e27219f") },
                    { new Guid("85c388a5-7f0a-4c19-b026-431b564d594d"), "HH:mm", new Guid("f88e47bc-c24a-4ce0-bc28-e5038366abb1") },
                    { new Guid("8e8adeca-f39b-4962-8851-e6161c9978b8"), "dd MMMM yyyy, HH:mm,", new Guid("f212d64c-e7bb-43f9-a06e-d66b3f05bb52") },
                    { new Guid("927a406f-1164-46b7-a24e-d7ad8e59e5f2"), "dd.MM.yyyy HH:mm", new Guid("7d4c3440-3741-4dd2-af21-417403054367") },
                    { new Guid("9af50549-8724-41d7-925e-1c2b53234eb8"), "dd MMMM yyyy, HH:mm МСК", new Guid("0aefb553-2918-4b25-bee5-8fc1a0fe5a68") },
                    { new Guid("a0af0ee0-44dc-467d-91d0-bf0353954fe8"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("01c415d2-b197-4f99-8d9d-188663af8dc6") },
                    { new Guid("a14f588b-feef-4753-b9d3-68d127f64004"), "dd MMMM, HH:mm", new Guid("f212d64c-e7bb-43f9-a06e-d66b3f05bb52") },
                    { new Guid("a17484e5-3a3c-40f7-adad-07671bd63c3e"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("5fe0613d-38d3-4848-ab76-c2848ae68188") },
                    { new Guid("b5d81399-cf09-4e6e-8248-9111f2db1234"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("422ed1a2-a6ad-42ee-8b56-ff69011d02ff") },
                    { new Guid("c1f43425-2013-4b25-8e38-eb400652f379"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("fa88741b-d158-4c3d-94a7-387d13b0260f") },
                    { new Guid("c393f311-2a17-49b0-a2bc-a41b0d334ead"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("b8e58a34-0faa-430c-beaa-25f9af3be339") },
                    { new Guid("e4682bc2-05a5-42fa-851d-1a6d87673a46"), "HH:mm dd.MM.yyyy", new Guid("7fd02af4-d286-47da-83df-5d3a88822d18") },
                    { new Guid("e58a8d5b-b5f3-485d-8a0d-fbb5f8b8466b"), "dd MMMM, HH:mm,", new Guid("f212d64c-e7bb-43f9-a06e-d66b3f05bb52") },
                    { new Guid("f28a707f-d826-4584-9563-dbba9744cb9b"), "dd MMMM, HH:mm", new Guid("afab8f1c-8af4-4315-a26e-0816a26755d2") },
                    { new Guid("f80277ed-34e1-47e5-9150-bb2c69be80e2"), "dd MMMM yyyy, HH:mm", new Guid("f88e47bc-c24a-4ce0-bc28-e5038366abb1") },
                    { new Guid("fa7b673f-b748-46d7-80d6-268c1e5983c1"), "HH:mm, dd MMMM yyyy", new Guid("24f401f7-2c34-4c86-b4ec-d6fcea3dcc41") },
                    { new Guid("fcb1952d-0c59-478d-b91e-979cdf404c6e"), "dd MMMM yyyy HH:mm", new Guid("9c5ecd0b-b433-4542-804d-66eedcd1d7da") },
                    { new Guid("fe458c41-7738-49f0-bb7f-736692f9a8d2"), "dd MMMM  HH:mm", new Guid("2e232f21-fe86-4e78-b3a1-6948d2c46803") }
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
