using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NewsAggregator.News.Databases.EntityFramework.News.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabse : Migration
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
                    name_x_path = table.Column<string>(type: "text", nullable: false)
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
                    url_x_path = table.Column<string>(type: "text", nullable: false)
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
                    published_at_culture_info = table.Column<string>(type: "text", nullable: false)
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
                    title_x_path = table.Column<string>(type: "text", nullable: false)
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
                    { new Guid("03aa687b-0d82-46a8-bd8b-979217129cf3"), "https://iz.ru/", "Известия" },
                    { new Guid("163b8f18-3226-477e-9840-74a981d851af"), "https://russian.rt.com/", "RT на русском" },
                    { new Guid("53d1563f-e137-40dd-985e-3225b0c29e96"), "https://www.kommersant.ru/", "Коммерсантъ" },
                    { new Guid("5a3883b7-7f5c-4e2a-b407-a8704ab0302a"), "https://lenta.ru/", "Лента.Ру" },
                    { new Guid("5dbed43b-3452-4ec4-b1a8-553afb1b817b"), "https://life.ru/", "Life" },
                    { new Guid("83e28845-ad9a-44a6-b2bd-cfbe0aeff0ef"), "https://www.rbc.ru/", "РБК" },
                    { new Guid("88244007-1e8d-496d-b46b-3ca2a4a174c9"), "https://aif.ru/", "Аргументы и факты" },
                    { new Guid("958b69c9-5863-4219-bd0f-cafe19eba1b3"), "https://www.sports.ru/", "Storts.ru" },
                    { new Guid("97fa44a3-cdcd-4698-9c1c-0b5076d23aa6"), "https://www.m24.ru/", "Москва 24" },
                    { new Guid("9dab29ea-9ab7-4a8e-b065-8bd82f3f4a25"), "https://www.belta.by/", "БелТА" },
                    { new Guid("af45f126-5811-42a8-9b43-2b2949e54715"), "https://3dnews.ru/", "3Dnews.ru" },
                    { new Guid("b20b589e-e92a-4457-93d1-0a73580d63ce"), "https://ixbt.games/", "iXBT.games" },
                    { new Guid("b296ad9e-774a-49d8-9509-5afaee81fe8f"), "https://vz.ru/", "ВЗГЛЯД.РУ" },
                    { new Guid("b441ad17-2d82-409b-9549-dc96e7b2b53a"), "https://svpressa.ru/", "СвободнаяПресса" },
                    { new Guid("b69f0d7c-82cb-4c74-8569-9ebf8e2e0d01"), "https://www.ixbt.com/", "iXBT.com" },
                    { new Guid("b9b41c69-c49e-422d-a067-baf39a403f4d"), "https://ria.ru/", "РИА Новости" },
                    { new Guid("c35ef9c0-1b9e-45ce-9c7f-9504d3828924"), "https://tsargrad.tv/", "Царьград" },
                    { new Guid("cd4fe5b1-41bf-4046-be6d-96e83017f83b"), "https://rg.ru/", "Российская газета" },
                    { new Guid("d755e6bb-06b2-4904-b33a-47a4f4aaa631"), "https://www.championat.com/", "Чемпионат.com" },
                    { new Guid("fb27fffe-eae2-4ab4-9e52-485c63dd5f77"), "https://tass.ru/", "ТАСС" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_settings",
                columns: new[] { "id", "description_x_path", "source_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("12d234db-3113-456b-82be-06cb105b1ccc"), "//div[@class='topic-body__content']", new Guid("5a3883b7-7f5c-4e2a-b407-a8704ab0302a"), "//h1[@class='topic-body__titles']/span[@class='topic-body__title']/text()" },
                    { new Guid("13868206-9c51-4dc9-ad63-9636ec85e15f"), "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]", new Guid("5dbed43b-3452-4ec4-b1a8-553afb1b817b"), "//h1/text()" },
                    { new Guid("1ce57d8f-55b2-497c-8975-95c956a77145"), "//article/div[@class='news_text']", new Guid("b296ad9e-774a-49d8-9509-5afaee81fe8f"), "//h1/text()" },
                    { new Guid("32b21a08-12cf-40be-b6fe-23048bfe2870"), "//div[@itemprop='articleBody']", new Guid("b69f0d7c-82cb-4c74-8569-9ebf8e2e0d01"), "//h1/text()" },
                    { new Guid("43b1975e-9d0e-4756-83fa-0e6b1c9b9daf"), "//div[@class='js-mediator-article']", new Guid("9dab29ea-9ab7-4a8e-b065-8bd82f3f4a25"), "//h1/text()" },
                    { new Guid("57c4a8cb-5f57-405e-8426-e7de62c84fd7"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]", new Guid("c35ef9c0-1b9e-45ce-9c7f-9504d3828924"), "//h1[@class='article__title']/text()" },
                    { new Guid("594acb0b-ef82-46ee-a0a8-60b0ff6423c2"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview'))]", new Guid("83e28845-ad9a-44a6-b2bd-cfbe0aeff0ef"), "//h1/text()" },
                    { new Guid("6741d4d7-ce85-4673-acb4-3bb48340b038"), "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]", new Guid("97fa44a3-cdcd-4698-9c1c-0b5076d23aa6"), "//h1/text()" },
                    { new Guid("684767e0-f548-4ebd-8f74-1c5d2de65c26"), "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]", new Guid("b441ad17-2d82-409b-9549-dc96e7b2b53a"), "//h1[@class='b-text__title']/text()" },
                    { new Guid("858133ca-d250-4094-ba30-ed7498fa9d5b"), "//article/div[@class='article-content']/*[not(@class)]", new Guid("d755e6bb-06b2-4904-b33a-47a4f4aaa631"), "//article/header/div[@class='article-head__title']/text()" },
                    { new Guid("889eb0fd-f3bf-42f0-81bb-4fe573619a55"), "//div[@class='container-fluid shifted']/p[@class='announce lead']", new Guid("b20b589e-e92a-4457-93d1-0a73580d63ce"), "//h1/text()" },
                    { new Guid("930e12ce-e2e0-4750-aaf8-58976fece6d8"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]", new Guid("53d1563f-e137-40dd-985e-3225b0c29e96"), "//h1/text()" },
                    { new Guid("a0b75d49-4a62-4b69-a4a5-aedfd3fafe2f"), "//div[@itemprop='articleBody']", new Guid("03aa687b-0d82-46a8-bd8b-979217129cf3"), "//h1/span/text()" },
                    { new Guid("a5e45548-a59b-4749-bb25-aee6fe37de11"), "//div[contains(@class, 'article__body')]", new Guid("b9b41c69-c49e-422d-a067-baf39a403f4d"), "//div[@class='article__title']/text()" },
                    { new Guid("b61dd111-2c3b-4c38-9915-3633bd16acb9"), "//div[contains(@class, 'news-item__content')]", new Guid("958b69c9-5863-4219-bd0f-cafe19eba1b3"), "//h1/text()" },
                    { new Guid("ca496daa-a18a-4260-854a-c63ccbcaf2a3"), "//div[contains(@class, 'PageContentCommonStyling_text')]", new Guid("cd4fe5b1-41bf-4046-be6d-96e83017f83b"), "//h1/text()" },
                    { new Guid("cb2b1ef9-370b-4c66-a84d-42bb146b90c5"), "//div[contains(@class, 'article__text ')]", new Guid("163b8f18-3226-477e-9840-74a981d851af"), "//h1/text()" },
                    { new Guid("da72ed3d-2c3f-46a0-b4e2-460accc2f23c"), "//div[@class='article_text']", new Guid("88244007-1e8d-496d-b46b-3ca2a4a174c9"), "//h1/text()" },
                    { new Guid("e94c25b7-d012-4655-8321-8fdb95457eaa"), "//article", new Guid("fb27fffe-eae2-4ab4-9e52-485c63dd5f77"), "//h1/text()" },
                    { new Guid("ef936451-4dee-4212-8e53-6c3aff241781"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()>1]", new Guid("af45f126-5811-42a8-9b43-2b2949e54715"), "//h1/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_search_settings",
                columns: new[] { "id", "news_site_url", "news_url_x_path", "source_id" },
                values: new object[,]
                {
                    { new Guid("00cbc7a2-c3fb-4473-8314-d43f9f6585e6"), "https://ria.ru/", "//a[contains(@class, 'cell-list__item-link')]/@href", new Guid("b9b41c69-c49e-422d-a067-baf39a403f4d") },
                    { new Guid("03980e0b-a669-4d39-a7a8-c4e6c1d8f2de"), "https://iz.ru/news/", "//a[contains(@href, '?main_click')]/@href", new Guid("03aa687b-0d82-46a8-bd8b-979217129cf3") },
                    { new Guid("16258668-5402-46d9-ac11-40a9f9aa85bc"), "https://www.sports.ru/news/", "//a[contains(@href, '.html') and not(contains(@href, '.html#comments'))]/@href", new Guid("958b69c9-5863-4219-bd0f-cafe19eba1b3") },
                    { new Guid("1c884487-9c1a-4337-a975-40011e43302f"), "https://www.kommersant.ru/", "//a[contains(@href, '/doc/') and contains(@href, '?from=')]/@href", new Guid("53d1563f-e137-40dd-985e-3225b0c29e96") },
                    { new Guid("2d2f16a1-7f1a-4694-b4a5-1e9e59cafc48"), "https://www.ixbt.com/news/", "//a[starts-with(@href, '/news/') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("b69f0d7c-82cb-4c74-8569-9ebf8e2e0d01") },
                    { new Guid("5711851f-8010-4a69-a291-5960669384c1"), "https://lenta.ru/", "//a[starts-with(@href, '/news/') or starts-with(@href, '/articles/')]/@href", new Guid("5a3883b7-7f5c-4e2a-b407-a8704ab0302a") },
                    { new Guid("65784cc4-0cde-4a33-8ce7-42e20a843054"), "https://www.belta.by/", "//a[contains(@href, 'https://www.belta.by/') and contains(@href, '/view/')]/@href", new Guid("9dab29ea-9ab7-4a8e-b065-8bd82f3f4a25") },
                    { new Guid("6c010633-41a2-4592-8e2d-0400a2f0a0af"), "https://ixbt.games/news/", "//a[@class='card-link']/@href", new Guid("b20b589e-e92a-4457-93d1-0a73580d63ce") },
                    { new Guid("701bd8ee-2340-4847-ad7c-e560bff5676b"), "https://tsargrad.tv/", "//a[contains(@class, 'news-item__link')]/@href", new Guid("c35ef9c0-1b9e-45ce-9c7f-9504d3828924") },
                    { new Guid("7e731b43-5594-4b58-b01d-d5bc1a5c865c"), "https://www.m24.ru/", "//a[contains(@href, '/news/')]/@href", new Guid("97fa44a3-cdcd-4698-9c1c-0b5076d23aa6") },
                    { new Guid("94355d3f-20fe-4ecf-a3b2-321c1618f5e0"), "https://3dnews.ru/news/", "//div[@class='news-feed-all']//a[@class='entry-header']/h1/../@href", new Guid("af45f126-5811-42a8-9b43-2b2949e54715") },
                    { new Guid("a21f4386-d1c5-4b03-ab7a-1fb90ef7ef3d"), "https://www.championat.com/news/1.html?utm_source=button&utm_medium=news", "//a[contains(@href, 'news-') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("d755e6bb-06b2-4904-b33a-47a4f4aaa631") },
                    { new Guid("b3fca5d0-8aa0-4818-9bcc-e8baad983354"), "https://rg.ru/", "//a[contains(@href, '.html')]/@href", new Guid("cd4fe5b1-41bf-4046-be6d-96e83017f83b") },
                    { new Guid("b5a70dfb-b804-4f5c-b67e-2ba6178f11ad"), "https://vz.ru/", "//a[contains(@href, '.html') and not(contains(@href, '#comments')) and not(contains(@href, '?')) and not(contains(@href, '/about/'))]/@href", new Guid("b296ad9e-774a-49d8-9509-5afaee81fe8f") },
                    { new Guid("b6278f5a-6df7-4324-93fa-01e18c472093"), "https://svpressa.ru/all/news/", "//a[contains(@href, '/news/') and not(contains(@href, '?')) and not(starts-with(@href, '/all/news/'))]/@href", new Guid("b441ad17-2d82-409b-9549-dc96e7b2b53a") },
                    { new Guid("c10be67a-3ab8-43fd-95ff-4ffdf541fec5"), "https://tass.ru/", "//a[contains(@class, 'tass_pkg_link-v5WdK') and contains(substring(@href, 2), '/')]/@href", new Guid("fb27fffe-eae2-4ab4-9e52-485c63dd5f77") },
                    { new Guid("cc19632c-d036-44dc-95d9-e883c3d5cad3"), "https://aif.ru/", "//span[contains(@class, 'item_text__title')]/../@href", new Guid("88244007-1e8d-496d-b46b-3ca2a4a174c9") },
                    { new Guid("cc47be13-b145-40dd-8140-6ed213321d74"), "https://www.rbc.ru/", "//a[contains(@href, 'https://www.rbc.ru/') and contains(@href, '?from=')]/@href", new Guid("83e28845-ad9a-44a6-b2bd-cfbe0aeff0ef") },
                    { new Guid("dcda4796-fadc-4ea2-b7ae-9f92ac8f6ef3"), "https://life.ru/s/novosti", "//a[contains(@href, '/p/')]/@href", new Guid("5dbed43b-3452-4ec4-b1a8-553afb1b817b") },
                    { new Guid("f4de2b74-55c3-4237-9dee-05082195e819"), "https://russian.rt.com/", "//a[contains(@class, 'link') and contains(@href, 'news/')]/@href", new Guid("163b8f18-3226-477e-9840-74a981d851af") }
                });

            migrationBuilder.InsertData(
                table: "news_source_logos",
                columns: new[] { "id", "source_id", "url" },
                values: new object[] { new Guid("bd909b6b-88a9-4aa0-b9ba-d9e3e4ddbb5b"), new Guid("b20b589e-e92a-4457-93d1-0a73580d63ce"), "https://sun13-2.userapi.com/s/v1/ig2/_ID-2w6Llad8ig5_987dKAfh1pyLdj7HfLHqGx9HxyDjoEDN7wxR0ZWJm5ja1Ey6UuQXaEYEBW1Zd51cpRrjSGfS.jpg?size=100x100&quality=96&crop=22,22,626,626&ava=1" });

            migrationBuilder.InsertData(
                table: "news_parse_editor_settings",
                columns: new[] { "id", "name_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("19be60d5-2436-482c-8e4f-b24f4693a25f"), "//article//header//div[@class='article-head__author-name']/a[@rel='author']/span/text()", new Guid("858133ca-d250-4094-ba30-ed7498fa9d5b") },
                    { new Guid("2fcf2701-91a5-45e1-abb5-74520933328c"), "//div[@class='article__authors']//span[@class='article__authors__author']/span[@class='article__authors__author__name']/text()", new Guid("594acb0b-ef82-46ee-a0a8-60b0ff6423c2") },
                    { new Guid("37d78e65-e1aa-482f-9673-2b6c2ff38f9b"), "//div[contains(@class, 'article-entry')]//div[@class='entry-info']//a[@itemprop='author']//span[@itemprop='name']/text()", new Guid("ef936451-4dee-4212-8e53-6c3aff241781") },
                    { new Guid("535abd5c-01e5-464b-b3cb-61e1716331fe"), "//span[@itemprop='author']/span[@itemprop='name']/@content", new Guid("32b21a08-12cf-40be-b6fe-23048bfe2870") },
                    { new Guid("6324e2b8-eb18-4bbe-80f6-cfd6ff6ec3de"), "//div[@class='article_top']//div[@class='authors']//div[@class='autor']//span/text()", new Guid("da72ed3d-2c3f-46a0-b4e2-460accc2f23c") },
                    { new Guid("81a7c71f-2cd5-4d54-8be7-949c2ef39eaf"), "//div[contains(@class, 'styles_bodyWrapper')]//div[contains(@class, 'styles_authorsLinks')]/a/text()", new Guid("13868206-9c51-4dc9-ad63-9636ec85e15f") },
                    { new Guid("9fdf19b9-7ce0-4476-b5c1-b71b1c44c599"), "//p[@class='doc__text document_authors']/text()", new Guid("930e12ce-e2e0-4750-aaf8-58976fece6d8") },
                    { new Guid("ba31ceb7-16c5-4ec8-ba8d-23c69cdb5cd7"), "//div[@class='container-fluid publication-footer']//a[contains(@class, 'text-secondary')]/@title", new Guid("889eb0fd-f3bf-42f0-81bb-4fe573619a55") },
                    { new Guid("da099306-35e9-433e-bfbf-c49e528646b7"), "//div[contains(@class, 'PageArticleContent_authors')]//a[contains(@class, 'LinksOfAuthor_item')]/text()", new Guid("ca496daa-a18a-4260-854a-c63ccbcaf2a3") },
                    { new Guid("eb3543c9-8319-431c-bce2-1188dd32f471"), "//a[@class='article__author']/text()", new Guid("57c4a8cb-5f57-405e-8426-e7de62c84fd7") },
                    { new Guid("eb4756b8-a242-45dc-be69-f6c219e4881e"), "//div[@class='topic-authors']/a[@class='topic-authors__author']/text()", new Guid("12d234db-3113-456b-82be-06cb105b1ccc") },
                    { new Guid("fc1510a2-8ceb-47d7-96ba-3fa0df148bc1"), "//footer[@class='news-item__footer']/div[@class='news-item__footer-after-news']/p[position()=1]//span/text()", new Guid("b61dd111-2c3b-4c38-9915-3633bd16acb9") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_picture_settings",
                columns: new[] { "id", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("042086c1-237e-4139-9d71-eacb37e5fd02"), new Guid("1ce57d8f-55b2-497c-8975-95c956a77145"), "//article/figure/img/@src" },
                    { new Guid("0535989e-01e1-46c1-9fe1-89753769aab6"), new Guid("da72ed3d-2c3f-46a0-b4e2-460accc2f23c"), "//div[@class='img_box']/a[@class='zoom_js']/img/@src" },
                    { new Guid("097a23f0-9744-4f8a-bff3-92c4c3d5b52d"), new Guid("e94c25b7-d012-4655-8321-8fdb95457eaa"), "//div[contains(@class, 'HeaderMedia_image')]//img[contains(@class, 'Image_image')]/@src" },
                    { new Guid("184f11d5-8acd-4505-9362-42e1232416ab"), new Guid("6741d4d7-ce85-4673-acb4-3bb48340b038"), "//div[@class='b-material-incut-m-image']//@src" },
                    { new Guid("2d19b092-a654-40ec-948e-d0e852893a04"), new Guid("57c4a8cb-5f57-405e-8426-e7de62c84fd7"), "//div[@class='article__media']//img/@src" },
                    { new Guid("30a283bc-154f-47bf-995e-4c11abfc537c"), new Guid("889eb0fd-f3bf-42f0-81bb-4fe573619a55"), "//a[@class='glightbox']/img[contains(@class, 'pub-cover')]/@src" },
                    { new Guid("3c270447-dd9a-49cc-b61d-275ac1603da6"), new Guid("ef936451-4dee-4212-8e53-6c3aff241781"), "//div[contains(@class, 'article-entry')]//div[contains(@class, 'entry-body')]//div[@class='source-wrapper']/img[@itemprop='image']/@src" },
                    { new Guid("5ae8da2f-4440-4e99-a972-19615b46f005"), new Guid("858133ca-d250-4094-ba30-ed7498fa9d5b"), "//article//header/div[@class='article-head__photo']/img/@src" },
                    { new Guid("743479b3-e5d9-4474-82a5-dd73aa4517ee"), new Guid("a0b75d49-4a62-4b69-a4a5-aedfd3fafe2f"), "//div[contains(@class, 'big_photo')]//div[@class='big_photo__img']//img/@src" },
                    { new Guid("8dc140b6-29ed-4b08-a762-50d2f1980292"), new Guid("12d234db-3113-456b-82be-06cb105b1ccc"), "//div[contains(@class, 'topic-body__title-image')]//img[contains(@class, 'picture__image')]/@src" },
                    { new Guid("9a62a05d-1638-425d-8232-f34f7e978088"), new Guid("a5e45548-a59b-4749-bb25-aee6fe37de11"), "//div[@class='photoview__open']/img/@src" },
                    { new Guid("b541f77f-d85b-424c-aca1-0aa3dcfec2fa"), new Guid("13868206-9c51-4dc9-ad63-9636ec85e15f"), "//article//header/div[contains(@class, 'styles_cover_media')]/img/@src" },
                    { new Guid("c3dc7d95-d9bd-427d-891f-413b27978bf1"), new Guid("43b1975e-9d0e-4756-83fa-0e6b1c9b9daf"), "//div[@class='inner_content']//div[@class='main_img']//img/@src" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings",
                columns: new[] { "id", "parse_settings_id", "published_at_culture_info", "published_at_format", "published_at_x_path" },
                values: new object[,]
                {
                    { new Guid("036425e3-c1a4-48c3-8e9a-82542e427163"), new Guid("cb2b1ef9-370b-4c66-a84d-42bb146b90c5"), "ru-RU", "yyyy-MM-d HH:mm", "//div[contains(@class, 'article__date-autor-shortcode')]/div[contains(@class, 'article__date')]/time[@class='date']/@datetime" },
                    { new Guid("1a739b81-6ebd-4a7e-8b00-0a49bc58d1f8"), new Guid("594acb0b-ef82-46ee-a0a8-60b0ff6423c2"), "ru-RU", "yyyy-MM-ddTHH:mm:sszzz", "//div[@class='article__header__info-block']/time[@class='article__header__date']/@datetime" },
                    { new Guid("2ea77581-0308-4d6c-8c87-2f660702a18d"), new Guid("ca496daa-a18a-4260-854a-c63ccbcaf2a3"), "ru-RU", "dd.MM.yyyy HH:mm", "//div[contains(@class, 'PageArticleContent_date')]/text()" },
                    { new Guid("3eaa4c62-b627-4d08-a534-af7903472063"), new Guid("858133ca-d250-4094-ba30-ed7498fa9d5b"), "ru-RU", "dd M yyyy, HH:mm", "//article//header//time[@class='article-head__date']/text()" },
                    { new Guid("4ff5863e-59a5-4942-ad27-020047b5e676"), new Guid("32b21a08-12cf-40be-b6fe-23048bfe2870"), "ru-RU", "dd M yyyy в HH:mm", "//div[@class='b-article__top-author']/p[@class='date']/text()" },
                    { new Guid("6db3c926-1b4e-48de-bddc-d147df589dc1"), new Guid("da72ed3d-2c3f-46a0-b4e2-460accc2f23c"), "ru-RU", "dd.MM.yyyy HH:mm", "//div[@class='article_top']//div[@class='date']//time/text()" },
                    { new Guid("7792a775-b090-46e2-88d4-ea7dc49b3588"), new Guid("12d234db-3113-456b-82be-06cb105b1ccc"), "ru-RU", "HH:mm, d M yyyy", "//div[@class='topic-page__header']//a[contains(@class, 'topic-header__time')]/text()" },
                    { new Guid("a7c9b038-3e73-423c-b6f0-b984326f5054"), new Guid("ef936451-4dee-4212-8e53-6c3aff241781"), "ru-RU", "yyyy-MM-ddTHH:mm:sszzz", "//div[contains(@class, 'article-entry')]//div[@class='entry-info']/span[@itemprop='datePublished']/@content" },
                    { new Guid("af5af407-c816-4c7f-8ea8-51a464237780"), new Guid("a5e45548-a59b-4749-bb25-aee6fe37de11"), "ru-RU", "HH:mm dd.MM.yyyy", "//div[@class='article__info']//div[@class='article__info-date']/a/text()" },
                    { new Guid("b71818d1-afd8-4b8a-9f5f-a12d6815ace6"), new Guid("1ce57d8f-55b2-497c-8975-95c956a77145"), "ru-RU", "dd M yyyy, HH:mm", "//article/div[@class='header']/span/text()" },
                    { new Guid("c4e3fdb5-e56f-4d8f-ac9b-4ee6a0929403"), new Guid("889eb0fd-f3bf-42f0-81bb-4fe573619a55"), "ru-RU", "yyyy-MM-dd HH:mm:ss", "//div[contains(@class, 'publication-footer')]//div[contains(@class, 'pubdatetime')]//div[contains(@class, 'badge-time')]/text()" },
                    { new Guid("cd4e8cae-f5ed-4c2f-a7eb-2a5a401be816"), new Guid("a0b75d49-4a62-4b69-a4a5-aedfd3fafe2f"), "ru-RU", "yyyy-MM-ddTHH:mm:ssZ", "//div[@class='article_page__left__top__left']//div[@class='article_page__left__top__time']//time/@datetime" },
                    { new Guid("dc0170e3-4ca3-4bc5-bca5-91f1e5384b60"), new Guid("43b1975e-9d0e-4756-83fa-0e6b1c9b9daf"), "ru-RU", "dd M yyyy, HH:mm", "//div[@class='date_full']/text()" },
                    { new Guid("e3784025-432e-4a60-a618-797489d1b2b6"), new Guid("b61dd111-2c3b-4c38-9915-3633bd16acb9"), "ru-RU", "yyyy-MM-ddTHH:mm:sszzz", "//header[@class='news-item__header']//time/@content" },
                    { new Guid("ed4011f1-20b7-45ab-8f8f-43b82faeb9ff"), new Guid("930e12ce-e2e0-4750-aaf8-58976fece6d8"), "ru-RU", "yyyy-MM-ddTHH:mm:sszzz", "//div[@class='doc_header__time']/time[@class='doc_header__publish_time']/@datetime" },
                    { new Guid("fd69a4d9-1ae7-4782-9dcb-7607ac8012b5"), new Guid("6741d4d7-ce85-4673-acb4-3bb48340b038"), "ru-RU", "HH:mm", "//p[@class='b-material__date']/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_sub_title_settings",
                columns: new[] { "id", "parse_settings_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("025f500c-2f33-47d9-adc4-3f804c109273"), new Guid("cb2b1ef9-370b-4c66-a84d-42bb146b90c5"), "//div[contains(@class, 'article__summary')]/text()" },
                    { new Guid("03f362f5-0c7e-4565-96a1-2c2373337d9a"), new Guid("ca496daa-a18a-4260-854a-c63ccbcaf2a3"), "//div[contains(@class, 'PageArticleContent_lead')]/text()" },
                    { new Guid("1956d2db-8094-4e51-8198-029c9b507003"), new Guid("594acb0b-ef82-46ee-a0a8-60b0ff6423c2"), "//div[contains(@class, 'article__text')]/div[@class='article__text__overview']/span/text()" },
                    { new Guid("28837c75-3788-48e5-b2d3-00d1b8a1d605"), new Guid("13868206-9c51-4dc9-ad63-9636ec85e15f"), "//article//header//p[contains(@class, 'styles_subtitle')]/text()" },
                    { new Guid("3a523325-2c03-404d-a513-16fae493461a"), new Guid("12d234db-3113-456b-82be-06cb105b1ccc"), "//div[contains(@class, 'topic-body__title')]/text()" },
                    { new Guid("4148b352-dd50-422a-b70e-dc7d1d18d43d"), new Guid("57c4a8cb-5f57-405e-8426-e7de62c84fd7"), "//div[@class='article__intro']/p/text()" },
                    { new Guid("43b4d0f0-b127-4cb9-8bf3-cd90e6bf68ff"), new Guid("889eb0fd-f3bf-42f0-81bb-4fe573619a55"), "//div[@class='container-fluid shifted']/p[@class='announce lead']/text()" },
                    { new Guid("690dcb38-99b2-4091-8cf4-98f8feaa764a"), new Guid("930e12ce-e2e0-4750-aaf8-58976fece6d8"), "//header[@class='doc_header']/h2[@class='doc_header__subheader']/text()" },
                    { new Guid("c33b9645-2cf1-4f8a-a3c1-5fedf48770e3"), new Guid("e94c25b7-d012-4655-8321-8fdb95457eaa"), "//h3/text()" },
                    { new Guid("ceddc09b-da04-4563-998d-59e6bad97009"), new Guid("1ce57d8f-55b2-497c-8975-95c956a77145"), "//h4/text()" },
                    { new Guid("d0064c00-0c3d-4e99-aee8-4b8d8ec92f2c"), new Guid("ef936451-4dee-4212-8e53-6c3aff241781"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()=1]/text()" },
                    { new Guid("f5436a98-67d8-4f08-918b-1b6bacad6ba9"), new Guid("32b21a08-12cf-40be-b6fe-23048bfe2870"), "//h4/text()" },
                    { new Guid("fb085652-37db-4a41-ac6d-9b44d7c811b0"), new Guid("a5e45548-a59b-4749-bb25-aee6fe37de11"), "//h1[@class='article__second-title']/text()" }
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
