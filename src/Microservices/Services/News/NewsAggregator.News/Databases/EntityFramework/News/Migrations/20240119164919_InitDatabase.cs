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
                name: "news_sources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    site_url = table.Column<string>(type: "text", nullable: false)
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
                    published_at_format = table.Column<string>(type: "text", nullable: false),
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

            migrationBuilder.InsertData(
                table: "news_sources",
                columns: new[] { "id", "site_url", "title" },
                values: new object[,]
                {
                    { new Guid("07a21532-964c-4293-b726-89479f8c2fc8"), "https://vz.ru/", "ВЗГЛЯД.РУ" },
                    { new Guid("0942dace-6986-4122-9856-e033b2c6e101"), "https://lenta.ru/", "Лента.Ру" },
                    { new Guid("0a3d63e2-a05f-4ebc-9a35-40d2adcea8db"), "https://www.belta.by/", "БелТА" },
                    { new Guid("1c349160-7b68-4690-a1a6-047157579bca"), "https://tass.ru/", "ТАСС" },
                    { new Guid("203e82f2-53d0-4adb-a995-7667ceff5c37"), "https://iz.ru/", "Известия" },
                    { new Guid("216b06c6-5f3b-409a-8f32-48e83f57596f"), "https://tsargrad.tv/", "Царьград" },
                    { new Guid("2c006e16-e863-4b20-abd8-b6c43263735d"), "https://www.m24.ru/", "Москва 24" },
                    { new Guid("2f638674-3cb2-4b2f-9d97-74fc7b272342"), "https://aif.ru/", "Аргументы и факты" },
                    { new Guid("361a2b5b-5a5f-45b4-b104-c1a0a424d2f3"), "https://rg.ru/", "Российская газета" },
                    { new Guid("4b2ebed7-ce61-47df-a1a6-c926c1c2f9bd"), "https://ria.ru/", "РИА Новости" },
                    { new Guid("4dbb879f-798a-4731-8854-06befa039e51"), "https://ura.news/", "Ura.ru" },
                    { new Guid("50be9436-4634-4c4b-97f4-fa18f5ccdc05"), "https://www.interfax.ru/", "Интерфакс" },
                    { new Guid("517abf9f-8a45-46df-82f8-370d5be9b893"), "https://svpressa.ru/", "СвободнаяПресса" },
                    { new Guid("80132545-590e-45d4-bde3-149d747a6039"), "https://www.gazeta.ru/", "Газета.Ru" },
                    { new Guid("8bb4c4fe-77e9-45e2-a03d-847e3b865b30"), "https://life.ru/", "Life" },
                    { new Guid("9e3d8818-06df-4d2a-b177-8ee0c4f0d82d"), "https://ixbt.games/", "iXBT.games" },
                    { new Guid("b0acecea-0420-4b76-b949-7639d7c33fcf"), "https://www.championat.com/", "Чемпионат.com" },
                    { new Guid("b0c9dccd-967b-40b1-a3c4-a73febf76bbb"), "https://www.ixbt.com/", "iXBT.com" },
                    { new Guid("b2e81db8-4502-42da-98ee-a0a1d23b5f10"), "https://www.kommersant.ru/", "Коммерсантъ" },
                    { new Guid("b4d72355-bb27-4222-bb6a-9e90dcce34cc"), "https://www.rbc.ru/", "РБК" },
                    { new Guid("ba9d3f93-0b4c-45d6-a3a9-d221040486bc"), "https://www.pravda.ru/", "Правда.ру" },
                    { new Guid("dd59c1a1-2c75-45e4-b2b9-e40c6b4664df"), "https://3dnews.ru/", "3Dnews.ru" },
                    { new Guid("e8f3066a-ea98-47f0-a60d-a0076bb0670e"), "https://russian.rt.com/", "RT на русском" },
                    { new Guid("f99a9ee3-db00-4d23-aa4b-9694840c88db"), "https://www.sports.ru/", "Storts.ru" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_settings",
                columns: new[] { "id", "description_x_path", "source_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("0421c319-5f3b-4fea-b4d3-40113c3bdc84"), "//div[@class='article_text']", new Guid("2f638674-3cb2-4b2f-9d97-74fc7b272342"), "//h1/text()" },
                    { new Guid("11b2fa2c-0a2a-4543-a946-f25e4676b673"), "//div[contains(@class, 'news-item__content')]", new Guid("f99a9ee3-db00-4d23-aa4b-9694840c88db"), "//h1/text()" },
                    { new Guid("141c4527-7aa4-4f57-8acc-bf2605f9fe7e"), "//div[contains(@class, 'article__body')]", new Guid("4b2ebed7-ce61-47df-a1a6-c926c1c2f9bd"), "//div[@class='article__title']/text()" },
                    { new Guid("1b01b353-acdb-4c52-8ed1-483e2e295620"), "//article", new Guid("1c349160-7b68-4690-a1a6-047157579bca"), "//h1/text()" },
                    { new Guid("1bf195b7-bab5-4cb4-86a3-7c4fe2419896"), "//div[@itemprop='articleBody']", new Guid("80132545-590e-45d4-bde3-149d747a6039"), "//h1/text()" },
                    { new Guid("2016b325-82cc-4cb3-b1ab-1ed09054c230"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview'))]", new Guid("b4d72355-bb27-4222-bb6a-9e90dcce34cc"), "//h1/text()" },
                    { new Guid("3c3b9bec-c4d2-4a7e-9422-0de3fcb23f52"), "//div[@class='container-fluid shifted']/p[@class='announce lead']", new Guid("9e3d8818-06df-4d2a-b177-8ee0c4f0d82d"), "//h1/text()" },
                    { new Guid("40520c7e-8de4-4ec2-8947-46966c8ca551"), "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]", new Guid("2c006e16-e863-4b20-abd8-b6c43263735d"), "//h1/text()" },
                    { new Guid("42096330-4480-42f5-9569-12ccf5db6233"), "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]", new Guid("ba9d3f93-0b4c-45d6-a3a9-d221040486bc"), "//h1/text()" },
                    { new Guid("4c4fc440-a5ba-4a6c-ac39-11875ff35b63"), "//div[contains(@class, 'PageContentCommonStyling_text')]", new Guid("361a2b5b-5a5f-45b4-b104-c1a0a424d2f3"), "//h1/text()" },
                    { new Guid("4cb92bd2-60e1-411d-88fd-c5c1f36a00ed"), "//div[@itemprop='articleBody']/*[not(name()='div')]", new Guid("4dbb879f-798a-4731-8854-06befa039e51"), "//h1/text()" },
                    { new Guid("57914a06-b21a-46a4-bcff-9c7192f4bd3c"), "//article/div[@class='article-content']/*[not(@class)]", new Guid("b0acecea-0420-4b76-b949-7639d7c33fcf"), "//article/header/div[@class='article-head__title']/text()" },
                    { new Guid("60e45cd4-62b2-433e-86de-c576ca116a1e"), "//div[@itemprop='articleBody']", new Guid("203e82f2-53d0-4adb-a995-7667ceff5c37"), "//h1/span/text()" },
                    { new Guid("8e4ffb12-7077-4eed-98be-e48e7b0ef680"), "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]", new Guid("517abf9f-8a45-46df-82f8-370d5be9b893"), "//h1[@class='b-text__title']/text()" },
                    { new Guid("c51c7571-6d0f-4f28-959f-0d61f212bc85"), "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]", new Guid("50be9436-4634-4c4b-97f4-fa18f5ccdc05"), "//h1/text()" },
                    { new Guid("cf6558e6-f5a9-467c-adae-06ed80609454"), "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]", new Guid("8bb4c4fe-77e9-45e2-a03d-847e3b865b30"), "//h1/text()" },
                    { new Guid("d6959c5f-84f1-4f95-ad41-fb63318d5893"), "//article/div[@class='news_text']", new Guid("07a21532-964c-4293-b726-89479f8c2fc8"), "//h1/text()" },
                    { new Guid("d6d06280-2850-4729-a4ee-90a0b57ce934"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]", new Guid("b2e81db8-4502-42da-98ee-a0a1d23b5f10"), "//h1/text()" },
                    { new Guid("da2e51c3-9a7f-4a02-9dfd-489410f46635"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]", new Guid("216b06c6-5f3b-409a-8f32-48e83f57596f"), "//h1[@class='article__title']/text()" },
                    { new Guid("dbac4f58-267e-4c59-86f1-fd7d978b78e8"), "//div[@itemprop='articleBody']", new Guid("b0c9dccd-967b-40b1-a3c4-a73febf76bbb"), "//h1/text()" },
                    { new Guid("de83b063-cd1a-4553-be3e-93cd69822cd0"), "//div[@class='js-mediator-article']", new Guid("0a3d63e2-a05f-4ebc-9a35-40d2adcea8db"), "//h1/text()" },
                    { new Guid("e71b65d0-8828-4b55-968b-ce70ccbde54f"), "//div[@class='topic-body__content']", new Guid("0942dace-6986-4122-9856-e033b2c6e101"), "//h1[@class='topic-body__titles']/span[@class='topic-body__title']/text()" },
                    { new Guid("ec4f1130-0b9a-4d39-93d8-e704b1534c6e"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()>1]", new Guid("dd59c1a1-2c75-45e4-b2b9-e40c6b4664df"), "//h1/text()" },
                    { new Guid("f2c53e11-1abe-4624-861b-42d41b642f79"), "//div[contains(@class, 'article__text ')]", new Guid("e8f3066a-ea98-47f0-a60d-a0076bb0670e"), "//h1/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_search_settings",
                columns: new[] { "id", "news_site_url", "news_url_x_path", "source_id" },
                values: new object[,]
                {
                    { new Guid("1cb608e2-6fef-434b-95c9-f5e985708265"), "https://ura.news/", "//a[contains(@href, '/news/')]/@href", new Guid("4dbb879f-798a-4731-8854-06befa039e51") },
                    { new Guid("203d557e-20b9-4e17-891d-51df518dc154"), "https://tass.ru/", "//a[contains(@class, 'tass_pkg_link-v5WdK') and contains(substring(@href, 2), '/')]/@href", new Guid("1c349160-7b68-4690-a1a6-047157579bca") },
                    { new Guid("288991a6-bab2-41d6-aee0-c9c0b6ae8042"), "https://life.ru/s/novosti", "//a[contains(@href, '/p/')]/@href", new Guid("8bb4c4fe-77e9-45e2-a03d-847e3b865b30") },
                    { new Guid("3133ba38-fb36-4ac2-a48c-6cb8f92a3a46"), "https://ixbt.games/news/", "//a[@class='card-link']/@href", new Guid("9e3d8818-06df-4d2a-b177-8ee0c4f0d82d") },
                    { new Guid("40c89f30-70c7-4dfa-9253-68212288e0a2"), "https://ria.ru/", "//a[contains(@class, 'cell-list__item-link')]/@href", new Guid("4b2ebed7-ce61-47df-a1a6-c926c1c2f9bd") },
                    { new Guid("45b6d6d2-7886-4d1a-b8d5-6cfd4aa3a857"), "https://www.belta.by/", "//a[contains(@href, 'https://www.belta.by/') and contains(@href, '/view/')]/@href", new Guid("0a3d63e2-a05f-4ebc-9a35-40d2adcea8db") },
                    { new Guid("5207d5da-16ca-4249-a807-659743a1fc3e"), "https://www.rbc.ru/", "//a[contains(@href, 'https://www.rbc.ru/') and contains(@href, '?from=')]/@href", new Guid("b4d72355-bb27-4222-bb6a-9e90dcce34cc") },
                    { new Guid("5b226b86-7d20-4524-921d-28c8a10b6aa4"), "https://www.sports.ru/news/", "//a[contains(@href, '.html') and not(contains(@href, '.html#comments'))]/@href", new Guid("f99a9ee3-db00-4d23-aa4b-9694840c88db") },
                    { new Guid("6d041dca-5c05-470d-813b-f8ebc3507f10"), "https://www.championat.com/news/1.html?utm_source=button&utm_medium=news", "//a[contains(@href, 'news-') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("b0acecea-0420-4b76-b949-7639d7c33fcf") },
                    { new Guid("6f7c6cf7-6ac2-42ec-9382-52937e754112"), "https://www.interfax.ru/", "//div[@class='timeline']//a[@tabindex=5]/@href", new Guid("50be9436-4634-4c4b-97f4-fa18f5ccdc05") },
                    { new Guid("7ceffe6a-7adc-4bb2-ab76-887bd234b051"), "https://iz.ru/news/", "//a[contains(@href, '?main_click')]/@href", new Guid("203e82f2-53d0-4adb-a995-7667ceff5c37") },
                    { new Guid("92e516f9-82c7-4aae-8d18-28da7fcd66cf"), "https://vz.ru/", "//a[contains(@href, '.html') and not(contains(@href, '#comments')) and not(contains(@href, '?')) and not(contains(@href, '/about/'))]/@href", new Guid("07a21532-964c-4293-b726-89479f8c2fc8") },
                    { new Guid("abc9409c-ecb0-452d-86e4-f9f5d42e38ad"), "https://lenta.ru/", "//a[starts-with(@href, '/news/')]/@href", new Guid("0942dace-6986-4122-9856-e033b2c6e101") },
                    { new Guid("ac94b8b9-d95d-4bf6-8470-8f74b8302fd8"), "https://aif.ru/", "//span[contains(@class, 'item_text__title')]/../@href", new Guid("2f638674-3cb2-4b2f-9d97-74fc7b272342") },
                    { new Guid("aea4efdf-ed09-4645-8af4-78d21b374b07"), "https://3dnews.ru/news/", "//div[@class='news-feed-all']//a[@class='entry-header']/h1/../@href", new Guid("dd59c1a1-2c75-45e4-b2b9-e40c6b4664df") },
                    { new Guid("b6cb5178-0c38-46aa-af8e-e972632ec2c9"), "https://tsargrad.tv/", "//a[contains(@class, 'news-item__link')]/@href", new Guid("216b06c6-5f3b-409a-8f32-48e83f57596f") },
                    { new Guid("bcef1146-4c1b-4041-ad3a-e94f378ce2fd"), "https://www.m24.ru/", "//a[contains(@href, '/news/')]/@href", new Guid("2c006e16-e863-4b20-abd8-b6c43263735d") },
                    { new Guid("be570164-ed91-4d37-826f-470c2c07cbf3"), "https://www.kommersant.ru/", "//a[contains(@href, '/doc/') and contains(@href, '?from=')]/@href", new Guid("b2e81db8-4502-42da-98ee-a0a1d23b5f10") },
                    { new Guid("cf919d1d-d6ad-4627-8b62-9f556ea1ac44"), "https://www.pravda.ru/", "//a[contains(@href, '/news/') and not(@href='https://www.pravda.ru/news/')]/@href", new Guid("ba9d3f93-0b4c-45d6-a3a9-d221040486bc") },
                    { new Guid("d298e71b-59d3-4b12-8556-733fee8580c2"), "https://svpressa.ru/all/news/", "//a[contains(@href, '/news/') and not(contains(@href, '?')) and not(starts-with(@href, '/all/news/'))]/@href", new Guid("517abf9f-8a45-46df-82f8-370d5be9b893") },
                    { new Guid("d7c1dd67-0b5d-419d-942a-73ebdfe28b08"), "https://www.ixbt.com/news/", "//a[starts-with(@href, '/news/') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("b0c9dccd-967b-40b1-a3c4-a73febf76bbb") },
                    { new Guid("d90b3ef1-9eca-4b9b-a81d-b93199ce1ca4"), "https://russian.rt.com/", "//a[contains(@class, 'link') and contains(@href, 'news/')]/@href", new Guid("e8f3066a-ea98-47f0-a60d-a0076bb0670e") },
                    { new Guid("e909ff2b-24a7-4e42-bd82-6c2bcc88685b"), "https://www.gazeta.ru/news/", "//a[contains(@href, '/news/') and contains(@href, '.shtml') and not(contains(@href, '?'))]/@href", new Guid("80132545-590e-45d4-bde3-149d747a6039") },
                    { new Guid("f9b24ebe-e3d1-4c92-aed3-6626a734c8b2"), "https://rg.ru/", "//a[contains(@href, '.html')]/@href", new Guid("361a2b5b-5a5f-45b4-b104-c1a0a424d2f3") }
                });

            migrationBuilder.InsertData(
                table: "news_source_logos",
                columns: new[] { "id", "source_id", "url" },
                values: new object[] { new Guid("9273e6d7-7672-452f-95ee-ed67fcf4e397"), new Guid("9e3d8818-06df-4d2a-b177-8ee0c4f0d82d"), "https://sun13-2.userapi.com/s/v1/ig2/_ID-2w6Llad8ig5_987dKAfh1pyLdj7HfLHqGx9HxyDjoEDN7wxR0ZWJm5ja1Ey6UuQXaEYEBW1Zd51cpRrjSGfS.jpg?size=100x100&quality=96&crop=22,22,626,626&ava=1" });

            migrationBuilder.InsertData(
                table: "news_parse_editor_settings",
                columns: new[] { "id", "is_required", "name_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("047a8e90-5b01-4b91-984d-99bccb0aed17"), false, "//div[contains(@class, 'styles_bodyWrapper')]//div[contains(@class, 'styles_authorsLinks')]/a/text()", new Guid("cf6558e6-f5a9-467c-adae-06ed80609454") },
                    { new Guid("062f0e93-0965-4c85-8ae3-5787a4931a28"), false, "//span[@itemprop='author']/span[@itemprop='name']/@content", new Guid("dbac4f58-267e-4c59-86f1-fd7d978b78e8") },
                    { new Guid("0d4daa16-c3b7-4f6e-a5ea-8c49130a34b8"), false, "//footer[@class='news-item__footer']/div[@class='news-item__footer-after-news']/p[position()=1]//span/text()", new Guid("11b2fa2c-0a2a-4543-a946-f25e4676b673") },
                    { new Guid("0ef6f860-7d65-4ccc-a244-417ef629a1cf"), false, "//article//header//div[@class='article-head__author-name']/a[@rel='author']/span/text()", new Guid("57914a06-b21a-46a4-bcff-9c7192f4bd3c") },
                    { new Guid("17a3f9dc-32bc-4edc-88c1-1d992df69ca5"), false, "//div[@class='topic-authors']/a[@class='topic-authors__author']/text()", new Guid("e71b65d0-8828-4b55-968b-ce70ccbde54f") },
                    { new Guid("2b8b8f9a-bf73-4f31-8a1f-5b9ac53a3fdf"), false, "//div[contains(@class, 'PageArticleContent_authors')]//a[contains(@class, 'LinksOfAuthor_item')]/text()", new Guid("4c4fc440-a5ba-4a6c-ac39-11875ff35b63") },
                    { new Guid("3245bb8d-688c-4339-9930-69a4e6ce4698"), false, "//div[@class='container-fluid publication-footer']//a[contains(@class, 'text-secondary')]/@title", new Guid("3c3b9bec-c4d2-4a7e-9422-0de3fcb23f52") },
                    { new Guid("40358f94-9a92-4e9c-a982-ba3e009f5ee9"), false, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']//a[@itemprop='author']//span[@itemprop='name']/text()", new Guid("ec4f1130-0b9a-4d39-93d8-e704b1534c6e") },
                    { new Guid("66703519-49c4-45a7-8235-321d08e7a376"), false, "//div[@itemprop='author']/span[@itemprop='name']/text()", new Guid("4cb92bd2-60e1-411d-88fd-c5c1f36a00ed") },
                    { new Guid("82b27a21-07c1-44ec-8556-80fdfd6f6eed"), false, "//div[@class='article_top']//div[@class='authors']//div[@class='autor']//span/text()", new Guid("0421c319-5f3b-4fea-b4d3-40113c3bdc84") },
                    { new Guid("d1e399a5-618b-4465-9e28-694fa1293f68"), false, "//div[@class='author']/span[@itemprop='author']/span[@itemprop='name']/a/text()", new Guid("1bf195b7-bab5-4cb4-86a3-7c4fe2419896") },
                    { new Guid("d769dde2-0179-4a9e-b35c-c16b00e92cf5"), false, "//div[@class='article__authors']//span[@class='article__authors__author']/span[@class='article__authors__author__name']/text()", new Guid("2016b325-82cc-4cb3-b1ab-1ed09054c230") },
                    { new Guid("dbfbeb29-1d20-4621-887a-f74946282604"), false, "//p[@class='doc__text document_authors']/text()", new Guid("d6d06280-2850-4729-a4ee-90a0b57ce934") },
                    { new Guid("e354f7fa-4551-494d-ab4b-b63385ff0fcf"), false, "//a[@class='article__author']/text()", new Guid("da2e51c3-9a7f-4a02-9dfd-489410f46635") },
                    { new Guid("f086d43d-3af1-4f4c-8777-c3572625b421"), false, "//div[contains(@class, 'full-article')]/div[@class='authors-block']//span[text()='Автор']/../a/text()", new Guid("42096330-4480-42f5-9569-12ccf5db6233") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_picture_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("011d3d50-2884-4c3f-b16c-aa3cb55c6b31"), false, new Guid("57914a06-b21a-46a4-bcff-9c7192f4bd3c"), "//article//header/div[@class='article-head__photo']/img/@src" },
                    { new Guid("06c13896-0d51-443c-bad8-a5322071ac60"), false, new Guid("0421c319-5f3b-4fea-b4d3-40113c3bdc84"), "//div[@class='img_box']/a[@class='zoom_js']/img/@src" },
                    { new Guid("2792710e-3c66-46e2-9ce0-5076cd62fa07"), false, new Guid("141c4527-7aa4-4f57-8acc-bf2605f9fe7e"), "//div[@class='photoview__open']/img/@src" },
                    { new Guid("2aa4dadb-58e5-49e0-b47d-d7621537204a"), false, new Guid("4cb92bd2-60e1-411d-88fd-c5c1f36a00ed"), "//div[@itemprop='articleBody']//div[@itemprop='image']/picture/img[@itemprop='contentUrl']/@src" },
                    { new Guid("2e6a8e3e-0e9c-4da5-bb3b-aff1c2692ea9"), false, new Guid("d6959c5f-84f1-4f95-ad41-fb63318d5893"), "//article/figure/img/@src" },
                    { new Guid("4e22e9b4-8cde-4194-a294-c32748150d58"), false, new Guid("cf6558e6-f5a9-467c-adae-06ed80609454"), "//article//header/div[contains(@class, 'styles_cover_media')]/img/@src" },
                    { new Guid("5ea1b322-3111-49e7-919f-d83875308775"), false, new Guid("60e45cd4-62b2-433e-86de-c576ca116a1e"), "//div[contains(@class, 'big_photo')]//div[@class='big_photo__img']//img/@src" },
                    { new Guid("625df56d-a77b-47ac-a2a7-d67cffa13a76"), false, new Guid("e71b65d0-8828-4b55-968b-ce70ccbde54f"), "//div[contains(@class, 'topic-body__title-image')]//img[contains(@class, 'picture__image')]/@src" },
                    { new Guid("630bc152-60db-4037-9d0e-97d3db78bfcb"), false, new Guid("de83b063-cd1a-4553-be3e-93cd69822cd0"), "//div[@class='inner_content']//div[@class='main_img']//img/@src" },
                    { new Guid("7c936fab-0e64-49a7-afd9-2672c76ab089"), false, new Guid("3c3b9bec-c4d2-4a7e-9422-0de3fcb23f52"), "//a[@class='glightbox']/img[contains(@class, 'pub-cover')]/@src" },
                    { new Guid("8303616f-292c-47a4-9e1b-24781b6f7205"), false, new Guid("1bf195b7-bab5-4cb4-86a3-7c4fe2419896"), "//div[@class='b_article-media']//div[@class='mainarea-wrapper']/figure/img[@class='item-image-front']/@src" },
                    { new Guid("882601db-fbfb-4f02-9780-3d921ab6f997"), false, new Guid("ec4f1130-0b9a-4d39-93d8-e704b1534c6e"), "//div[contains(@class, 'article-entry')]//div[contains(@class, 'entry-body')]//div[@class='source-wrapper']/img[@itemprop='image']/@src" },
                    { new Guid("9034fff9-c814-4fa1-a187-8a7d5b17c2d2"), false, new Guid("1b01b353-acdb-4c52-8ed1-483e2e295620"), "//div[contains(@class, 'HeaderMedia_image')]//img[contains(@class, 'Image_image')]/@src" },
                    { new Guid("c7d27053-6dbb-4333-bcdc-8e502a5240e8"), false, new Guid("da2e51c3-9a7f-4a02-9dfd-489410f46635"), "//div[@class='article__media']//img/@src" },
                    { new Guid("d3bd8093-e045-476e-b22f-7f23f208d7d9"), false, new Guid("40520c7e-8de4-4ec2-8947-46966c8ca551"), "//div[@class='b-material-incut-m-image']//@src" },
                    { new Guid("fdf3f81e-0450-40b8-9300-938dfdb4afd1"), false, new Guid("42096330-4480-42f5-9569-12ccf5db6233"), "//div[contains(@class, 'full-article')]/div[contains(@class, 'gallery')]/picture/img/@src" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "published_at_culture_info", "published_at_format", "published_at_x_path" },
                values: new object[,]
                {
                    { new Guid("1f24e2eb-eb99-4708-b36b-5e35aafec619"), false, new Guid("c51c7571-6d0f-4f28-959f-0d61f212bc85"), "ru-RU", "yyyy-MM-ddTHH:mm:ss", "//article[@itemprop='articleBody']/meta[@itemprop='datePublished']/@content" },
                    { new Guid("1fac0b8f-0ec1-46ed-ba85-ed24d439ff6d"), false, new Guid("0421c319-5f3b-4fea-b4d3-40113c3bdc84"), "ru-RU", "dd.MM.yyyy HH:mm", "//div[@class='article_top']//div[@class='date']//time/text()" },
                    { new Guid("2a64741a-8ee0-43b9-95e4-d920ee195794"), false, new Guid("141c4527-7aa4-4f57-8acc-bf2605f9fe7e"), "ru-RU", "HH:mm dd.MM.yyyy", "//div[@class='article__info']//div[@class='article__info-date']/a/text()" },
                    { new Guid("382e02e6-5765-436c-9802-83ae357e6bdf"), false, new Guid("60e45cd4-62b2-433e-86de-c576ca116a1e"), "ru-RU", "yyyy-MM-ddTHH:mm:ssZ", "//div[@class='article_page__left__top__left']//div[@class='article_page__left__top__time']//time/@datetime" },
                    { new Guid("5faf0212-5409-404c-bcf6-c9996f839253"), false, new Guid("d6959c5f-84f1-4f95-ad41-fb63318d5893"), "ru-RU", "dd MMMM yyyy, HH:mm", "//article/div[@class='header']/span/text()" },
                    { new Guid("6803a409-8030-44ff-95ee-65790597c0dc"), false, new Guid("1bf195b7-bab5-4cb4-86a3-7c4fe2419896"), "ru-RU", "yyyy-MM-ddTHH:mm:sszzz", "//article/div[@class='b_article-header']//time[@itemprop='datePublished']/@datetime" },
                    { new Guid("767b0283-f682-4fdf-b3d2-5a6debd29cb3"), false, new Guid("4cb92bd2-60e1-411d-88fd-c5c1f36a00ed"), "ru-RU", "yyyy-MM-ddTHH:mm:sszzz", "//div[@class='publication-info']/time[@itemprop='datePublished']/@datetime" },
                    { new Guid("7c6021ef-fb97-4a19-9412-aae6fc233580"), false, new Guid("f2c53e11-1abe-4624-861b-42d41b642f79"), "ru-RU", "yyyy-MM-d HH:mm", "//div[contains(@class, 'article__date-autor-shortcode')]/div[contains(@class, 'article__date')]/time[@class='date']/@datetime" },
                    { new Guid("83e23e26-0a94-4df5-8f8e-607106e1a4bd"), false, new Guid("3c3b9bec-c4d2-4a7e-9422-0de3fcb23f52"), "ru-RU", "yyyy-MM-dd HH:mm:ss", "//div[contains(@class, 'publication-footer')]//div[contains(@class, 'pubdatetime')]//div[contains(@class, 'badge-time')]/text()" },
                    { new Guid("854675a3-4f28-406e-b455-bb84b127a2f1"), false, new Guid("ec4f1130-0b9a-4d39-93d8-e704b1534c6e"), "ru-RU", "yyyy-MM-ddTHH:mm:sszzz", "//div[contains(@class, 'article-entry')]//div[@class='entry-info']/span[@itemprop='datePublished']/@content" },
                    { new Guid("a0bbc83b-2f92-4455-b875-1e98b615c10a"), false, new Guid("2016b325-82cc-4cb3-b1ab-1ed09054c230"), "ru-RU", "yyyy-MM-ddTHH:mm:sszzz", "//div[@class='article__header__info-block']/time[@class='article__header__date']/@datetime" },
                    { new Guid("a629ba0e-7a55-4028-9bdd-9cba858485a6"), false, new Guid("57914a06-b21a-46a4-bcff-9c7192f4bd3c"), "ru-RU", "dd MMMM yyyy, HH:mm МСК", "//article//header//time[@class='article-head__date']/text()" },
                    { new Guid("a66e6416-4b45-4f36-b9ea-3bc0ead4f913"), false, new Guid("40520c7e-8de4-4ec2-8947-46966c8ca551"), "ru-RU", "HH:mm", "//p[@class='b-material__date']/text()" },
                    { new Guid("ae9b2fe4-3de8-46aa-847d-dde85ae109e2"), false, new Guid("d6d06280-2850-4729-a4ee-90a0b57ce934"), "ru-RU", "yyyy-MM-ddTHH:mm:sszzz", "//div[@class='doc_header__time']/time[@class='doc_header__publish_time']/@datetime" },
                    { new Guid("b0fdd63a-1a24-4395-9473-ff0ace1a1313"), false, new Guid("de83b063-cd1a-4553-be3e-93cd69822cd0"), "ru-RU", "dd MMMM yyyy, HH:mm", "//div[@class='date_full']/text()" },
                    { new Guid("b17ba60c-49d0-4137-98d3-fe8d63e3261a"), false, new Guid("dbac4f58-267e-4c59-86f1-fd7d978b78e8"), "ru-RU", "dd MMMM yyyy в HH:mm", "//div[@class='b-article__top-author']/p[@class='date']/text()" },
                    { new Guid("b278b9b8-6606-48a9-a82a-57162d3359c7"), false, new Guid("11b2fa2c-0a2a-4543-a946-f25e4676b673"), "ru-RU", "yyyy-MM-ddTHH:mm:sszzz", "//header[@class='news-item__header']//time/@content" },
                    { new Guid("c4db775b-f1eb-4d0d-839a-ccc0abf7c528"), false, new Guid("42096330-4480-42f5-9569-12ccf5db6233"), "ru-RU", "dd.MM.yyyy HH:mm", "//div[contains(@class, 'full-article')]//time/text()" },
                    { new Guid("db09b9da-f79d-4966-a200-9a13f281039b"), false, new Guid("e71b65d0-8828-4b55-968b-ce70ccbde54f"), "ru-RU", "HH:mm, dd MMMM yyyy", "//div[@class='topic-page__header']//a[contains(@class, 'topic-header__time')]/text()" },
                    { new Guid("f774ce95-7b8a-4b36-a418-e012f60997d6"), false, new Guid("4c4fc440-a5ba-4a6c-ac39-11875ff35b63"), "ru-RU", "dd.MM.yyyy HH:mm", "//div[contains(@class, 'PageArticleContent_date')]/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_sub_title_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("159ac7f7-79b3-46cc-9607-30fe721c302a"), false, new Guid("cf6558e6-f5a9-467c-adae-06ed80609454"), "//article//header//p[contains(@class, 'styles_subtitle')]/text()" },
                    { new Guid("1c656c3e-48ea-4750-9c30-aff348a25b08"), false, new Guid("2016b325-82cc-4cb3-b1ab-1ed09054c230"), "//div[contains(@class, 'article__text')]/div[@class='article__text__overview']/span/text()" },
                    { new Guid("27761103-be16-4135-83e5-abfb4815608a"), false, new Guid("f2c53e11-1abe-4624-861b-42d41b642f79"), "//div[contains(@class, 'article__summary')]/text()" },
                    { new Guid("3e270f49-327c-49bd-8214-a2e29daa60da"), false, new Guid("1bf195b7-bab5-4cb4-86a3-7c4fe2419896"), "//h2/text()" },
                    { new Guid("4b410eba-fd85-455e-88b7-fc8b2c58008a"), false, new Guid("dbac4f58-267e-4c59-86f1-fd7d978b78e8"), "//h4/text()" },
                    { new Guid("689c97e2-77d2-41d4-9b84-7791dc2e335c"), false, new Guid("42096330-4480-42f5-9569-12ccf5db6233"), "//h1/text()" },
                    { new Guid("69bbb3ca-33cb-4d4f-989f-431a885f42f1"), false, new Guid("d6d06280-2850-4729-a4ee-90a0b57ce934"), "//header[@class='doc_header']/h2[contains(@class, 'doc_header__subheader')]/text()" },
                    { new Guid("721d66fa-644a-4a0d-9d83-5a744c73ba5b"), false, new Guid("d6959c5f-84f1-4f95-ad41-fb63318d5893"), "//h4/text()" },
                    { new Guid("81a0c7ba-16f9-4391-a1b4-c6910ac4d10d"), false, new Guid("4c4fc440-a5ba-4a6c-ac39-11875ff35b63"), "//div[contains(@class, 'PageArticleContent_lead')]/text()" },
                    { new Guid("b658641c-8a0d-40c6-97d6-4196e11f0892"), false, new Guid("ec4f1130-0b9a-4d39-93d8-e704b1534c6e"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()=1]/text()" },
                    { new Guid("b80d15a3-6b4a-4bf2-a464-921b4362823c"), false, new Guid("1b01b353-acdb-4c52-8ed1-483e2e295620"), "//h3/text()" },
                    { new Guid("cdcf9ff2-96df-4f17-9baa-588f2ec9fc38"), false, new Guid("e71b65d0-8828-4b55-968b-ce70ccbde54f"), "//div[contains(@class, 'topic-body__title')]/text()" },
                    { new Guid("df9418c9-f8ec-47b8-96a3-e3e55128710e"), false, new Guid("3c3b9bec-c4d2-4a7e-9422-0de3fcb23f52"), "//div[@class='container-fluid shifted']/p[@class='announce lead']/text()" },
                    { new Guid("f2e9e503-f64f-459f-a7ab-9bdeaee1fe79"), false, new Guid("141c4527-7aa4-4f57-8acc-bf2605f9fe7e"), "//h1[@class='article__second-title']/text()" },
                    { new Guid("f3d87fb5-1d19-4b2d-9c12-54494fc89f8e"), false, new Guid("da2e51c3-9a7f-4a02-9dfd-489410f46635"), "//div[@class='article__intro']/p/text()" }
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
                name: "ix_news_sources_title_site_url",
                table: "news_sources",
                columns: new[] { "title", "site_url" });

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
                name: "news_parse_picture_settings");

            migrationBuilder.DropTable(
                name: "news_parse_published_at_settings");

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
                name: "news_parse_settings");

            migrationBuilder.DropTable(
                name: "news");

            migrationBuilder.DropTable(
                name: "news_editors");

            migrationBuilder.DropTable(
                name: "news_sources");
        }
    }
}
