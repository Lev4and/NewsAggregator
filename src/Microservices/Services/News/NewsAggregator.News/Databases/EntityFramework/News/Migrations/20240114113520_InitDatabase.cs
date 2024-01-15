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
                    { new Guid("09ffcd85-9795-4f77-8e55-68d40e34d87a"), "https://russian.rt.com/", "RT на русском" },
                    { new Guid("0e267466-ad14-4f7b-8b00-d278dc128fd7"), "https://rg.ru/", "Российская газета" },
                    { new Guid("14e6bb2d-d968-439d-a6d9-e817e215d1dc"), "https://www.ixbt.com/", "iXBT.com" },
                    { new Guid("16425339-cf3e-4837-8613-c6d08cd42ea6"), "https://ria.ru/", "РИА Новости" },
                    { new Guid("2583f477-fce2-4fe5-a341-81e30883bc06"), "https://vz.ru/", "ВЗГЛЯД.РУ" },
                    { new Guid("2651f767-ffa8-48b8-a4cc-2b7b7fb68cd2"), "https://www.m24.ru/", "Москва 24" },
                    { new Guid("2c7ef109-2d05-477e-941f-e0f5a937ad7b"), "https://www.pravda.ru/", "Правда.ру" },
                    { new Guid("2eb0a1ad-38ed-4aa2-8a73-4d80f156f815"), "https://aif.ru/", "Аргументы и факты" },
                    { new Guid("5a57967a-9ab6-48e6-8a13-87b706ae9b85"), "https://ixbt.games/", "iXBT.games" },
                    { new Guid("5e452802-0e39-404c-8ed8-f7b89590a713"), "https://www.championat.com/", "Чемпионат.com" },
                    { new Guid("98fac15c-fc17-4012-a827-cf12e4fc72fc"), "https://www.rbc.ru/", "РБК" },
                    { new Guid("9fdb31aa-50e3-42e2-b5e0-1a734d7a57bb"), "https://ura.news/", "Ura.ru" },
                    { new Guid("a05bc4f7-d5bc-490b-8593-0171551c9958"), "https://www.belta.by/", "БелТА" },
                    { new Guid("a6e56b29-cb95-428a-b676-1607db592bce"), "https://www.sports.ru/", "Storts.ru" },
                    { new Guid("ab6e74cd-405f-489f-8672-c8923c8fa9ec"), "https://iz.ru/", "Известия" },
                    { new Guid("ab9e4601-c959-407e-9ef2-58bc670d6152"), "https://www.interfax.ru/", "Интерфакс" },
                    { new Guid("cbdf304c-d447-4297-a5d4-7261ada925de"), "https://3dnews.ru/", "3Dnews.ru" },
                    { new Guid("ce169d0d-96fb-4acb-9663-6d01117e7ea4"), "https://www.gazeta.ru/", "Газета.Ru" },
                    { new Guid("d74c7a85-d4a8-44bc-8c5f-bc5f71b60c75"), "https://tass.ru/", "ТАСС" },
                    { new Guid("d8c2325c-a066-4d5f-a080-bc4a8086b9e4"), "https://tsargrad.tv/", "Царьград" },
                    { new Guid("dbbce0f9-e7bc-4b7f-aa77-6b5b8319ffad"), "https://life.ru/", "Life" },
                    { new Guid("f3759f29-9364-4e39-87d3-8e21a330ab48"), "https://svpressa.ru/", "СвободнаяПресса" },
                    { new Guid("f6f82166-9205-4978-b093-c39b66fab4f3"), "https://www.kommersant.ru/", "Коммерсантъ" },
                    { new Guid("f882277e-6851-4590-bcb9-424a7751c1af"), "https://lenta.ru/", "Лента.Ру" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_settings",
                columns: new[] { "id", "description_x_path", "source_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("01902fcd-cd21-4d96-bf1f-5dfc7812381e"), "//div[@itemprop='articleBody']", new Guid("ab6e74cd-405f-489f-8672-c8923c8fa9ec"), "//h1/span/text()" },
                    { new Guid("048afc27-d220-4129-918b-d5a1e9989e21"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview'))]", new Guid("98fac15c-fc17-4012-a827-cf12e4fc72fc"), "//h1/text()" },
                    { new Guid("1199fb6e-d599-4e79-8fcf-c327e287c527"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]", new Guid("d8c2325c-a066-4d5f-a080-bc4a8086b9e4"), "//h1[@class='article__title']/text()" },
                    { new Guid("121162a8-6a7c-4e61-9e54-ef037e135a8d"), "//article/div[@class='article-content']/*[not(@class)]", new Guid("5e452802-0e39-404c-8ed8-f7b89590a713"), "//article/header/div[@class='article-head__title']/text()" },
                    { new Guid("13c63e40-ce79-41e4-9b46-dcafe1cce434"), "//div[@class='topic-body__content']", new Guid("f882277e-6851-4590-bcb9-424a7751c1af"), "//h1[@class='topic-body__titles']/span[@class='topic-body__title']/text()" },
                    { new Guid("1a7ff9f2-4a8f-4138-857c-16e9873187db"), "//article/div[@class='news_text']", new Guid("2583f477-fce2-4fe5-a341-81e30883bc06"), "//h1/text()" },
                    { new Guid("2428fc94-f50e-473d-b266-4d797fac1316"), "//article", new Guid("d74c7a85-d4a8-44bc-8c5f-bc5f71b60c75"), "//h1/text()" },
                    { new Guid("38481a31-8043-454c-b720-49c4efb3aeef"), "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]", new Guid("2c7ef109-2d05-477e-941f-e0f5a937ad7b"), "//div[@class='title article-header']/text()" },
                    { new Guid("3933a019-c0e5-4e34-a33e-9373cee6758a"), "//div[contains(@class, 'PageContentCommonStyling_text')]", new Guid("0e267466-ad14-4f7b-8b00-d278dc128fd7"), "//h1/text()" },
                    { new Guid("4edefbc4-7e11-4710-9002-bd557198d69d"), "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]", new Guid("f3759f29-9364-4e39-87d3-8e21a330ab48"), "//h1[@class='b-text__title']/text()" },
                    { new Guid("583e3321-929d-4526-ba27-734c0fd62f23"), "//div[@class='js-mediator-article']", new Guid("a05bc4f7-d5bc-490b-8593-0171551c9958"), "//h1/text()" },
                    { new Guid("62b37a37-4fd7-4dbe-8b53-25e936db2e02"), "//div[contains(@class, 'article__body')]", new Guid("16425339-cf3e-4837-8613-c6d08cd42ea6"), "//div[@class='article__title']/text()" },
                    { new Guid("7ad5cd9a-4de7-42d1-9d50-a705754196f5"), "//div[@itemprop='articleBody']", new Guid("14e6bb2d-d968-439d-a6d9-e817e215d1dc"), "//h1/text()" },
                    { new Guid("a69e9126-aa28-4fe5-a7bd-be9d6117938e"), "//div[@itemprop='articleBody']", new Guid("ce169d0d-96fb-4acb-9663-6d01117e7ea4"), "//h1/text()" },
                    { new Guid("b2628384-b53c-4e6d-a380-f06b7fa40fa1"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]", new Guid("f6f82166-9205-4978-b093-c39b66fab4f3"), "//h1/text()" },
                    { new Guid("b59d6368-6740-4aed-af58-ae2f5383f88e"), "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]", new Guid("ab9e4601-c959-407e-9ef2-58bc670d6152"), "//h1/text()" },
                    { new Guid("bd5e633f-793a-44d7-bee4-6104660d8326"), "//div[@itemprop='articleBody']/*[not(name()='div')]", new Guid("9fdb31aa-50e3-42e2-b5e0-1a734d7a57bb"), "//h1/text()" },
                    { new Guid("beeb9b0d-f3c3-4051-9a83-ea8758fcf977"), "//div[@class='container-fluid shifted']/p[@class='announce lead']", new Guid("5a57967a-9ab6-48e6-8a13-87b706ae9b85"), "//h1/text()" },
                    { new Guid("c015cb02-92f7-40ca-846c-afe21950a399"), "//div[contains(@class, 'news-item__content')]", new Guid("a6e56b29-cb95-428a-b676-1607db592bce"), "//h1/text()" },
                    { new Guid("c38454ee-bc5a-4045-9924-7098e80f1976"), "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]", new Guid("2651f767-ffa8-48b8-a4cc-2b7b7fb68cd2"), "//h1/text()" },
                    { new Guid("d5f3849b-40cb-4ceb-bbcd-8903b97d8e93"), "//div[@class='article_text']", new Guid("2eb0a1ad-38ed-4aa2-8a73-4d80f156f815"), "//h1/text()" },
                    { new Guid("d8bd2f21-e873-442f-bec7-c9a7930d2db1"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()>1]", new Guid("cbdf304c-d447-4297-a5d4-7261ada925de"), "//h1/text()" },
                    { new Guid("de1c0851-8bd0-42f4-adcb-c57c9f397cdb"), "//div[contains(@class, 'article__text ')]", new Guid("09ffcd85-9795-4f77-8e55-68d40e34d87a"), "//h1/text()" },
                    { new Guid("f40d9536-44e5-45cf-95a0-ed05a887ee19"), "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]", new Guid("dbbce0f9-e7bc-4b7f-aa77-6b5b8319ffad"), "//h1/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_search_settings",
                columns: new[] { "id", "news_site_url", "news_url_x_path", "source_id" },
                values: new object[,]
                {
                    { new Guid("22905a11-43f0-486e-84cc-9fd43327c74a"), "https://www.pravda.ru/", "//a[contains(@href, '/news/') and not(@href='https://www.pravda.ru/news/')]/@href", new Guid("2c7ef109-2d05-477e-941f-e0f5a937ad7b") },
                    { new Guid("27cc2dbf-0d0a-4430-bef8-7bf0aaed474e"), "https://ria.ru/", "//a[contains(@class, 'cell-list__item-link')]/@href", new Guid("16425339-cf3e-4837-8613-c6d08cd42ea6") },
                    { new Guid("2a3106bb-a209-4322-bea4-63f4819ec3b2"), "https://svpressa.ru/all/news/", "//a[contains(@href, '/news/') and not(contains(@href, '?')) and not(starts-with(@href, '/all/news/'))]/@href", new Guid("f3759f29-9364-4e39-87d3-8e21a330ab48") },
                    { new Guid("3821fe2e-dd7b-475c-b53c-d1a89a0fe4b0"), "https://www.rbc.ru/", "//a[contains(@href, 'https://www.rbc.ru/') and contains(@href, '?from=')]/@href", new Guid("98fac15c-fc17-4012-a827-cf12e4fc72fc") },
                    { new Guid("3dfe41ae-02c8-45e4-b187-21c49a44743e"), "https://www.belta.by/", "//a[contains(@href, 'https://www.belta.by/') and contains(@href, '/view/')]/@href", new Guid("a05bc4f7-d5bc-490b-8593-0171551c9958") },
                    { new Guid("42c2f24e-da8e-4726-8ba1-8e81c8584cc1"), "https://russian.rt.com/", "//a[contains(@class, 'link') and contains(@href, 'news/')]/@href", new Guid("09ffcd85-9795-4f77-8e55-68d40e34d87a") },
                    { new Guid("5e84e942-114b-40ff-8a5a-da5148d61302"), "https://www.championat.com/news/1.html?utm_source=button&utm_medium=news", "//a[contains(@href, 'news-') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("5e452802-0e39-404c-8ed8-f7b89590a713") },
                    { new Guid("6c5bb4da-4884-46ac-864c-4041e0ed042d"), "https://3dnews.ru/news/", "//div[@class='news-feed-all']//a[@class='entry-header']/h1/../@href", new Guid("cbdf304c-d447-4297-a5d4-7261ada925de") },
                    { new Guid("6c5f313d-75d3-4a86-9ba4-efe4ff2a041d"), "https://www.gazeta.ru/news/", "//a[contains(@href, '/news/') and contains(@href, '.shtml') and not(contains(@href, '?'))]/@href", new Guid("ce169d0d-96fb-4acb-9663-6d01117e7ea4") },
                    { new Guid("77238363-0944-406f-a46e-ac690142d524"), "https://life.ru/s/novosti", "//a[contains(@href, '/p/')]/@href", new Guid("dbbce0f9-e7bc-4b7f-aa77-6b5b8319ffad") },
                    { new Guid("782facc0-bc10-48b4-80d5-b00325abab27"), "https://www.interfax.ru/", "//div[@class='timeline']//a[@tabindex=5]/@href", new Guid("ab9e4601-c959-407e-9ef2-58bc670d6152") },
                    { new Guid("83068fcd-f12d-424e-8ba1-7b4218ee34a9"), "https://rg.ru/", "//a[contains(@href, '.html')]/@href", new Guid("0e267466-ad14-4f7b-8b00-d278dc128fd7") },
                    { new Guid("8f276814-1da6-422b-b770-4970fea81243"), "https://www.kommersant.ru/", "//a[contains(@href, '/doc/') and contains(@href, '?from=')]/@href", new Guid("f6f82166-9205-4978-b093-c39b66fab4f3") },
                    { new Guid("9029ac66-809d-4fa8-92ac-eb09a5593436"), "https://aif.ru/", "//span[contains(@class, 'item_text__title')]/../@href", new Guid("2eb0a1ad-38ed-4aa2-8a73-4d80f156f815") },
                    { new Guid("9dd4cd23-9cdd-4444-adaf-75490c022b1a"), "https://vz.ru/", "//a[contains(@href, '.html') and not(contains(@href, '#comments')) and not(contains(@href, '?')) and not(contains(@href, '/about/'))]/@href", new Guid("2583f477-fce2-4fe5-a341-81e30883bc06") },
                    { new Guid("a256c76a-22ad-45ba-8cc2-f23be83d3fa0"), "https://www.m24.ru/", "//a[contains(@href, '/news/')]/@href", new Guid("2651f767-ffa8-48b8-a4cc-2b7b7fb68cd2") },
                    { new Guid("b15433b1-2042-483d-8f4d-275b9a8cd607"), "https://ura.news/", "//a[contains(@href, '/news/')]/@href", new Guid("9fdb31aa-50e3-42e2-b5e0-1a734d7a57bb") },
                    { new Guid("d16f631f-c864-4c60-a7f5-2e48f2b63f22"), "https://lenta.ru/", "//a[starts-with(@href, '/news/') or starts-with(@href, '/articles/')]/@href", new Guid("f882277e-6851-4590-bcb9-424a7751c1af") },
                    { new Guid("d9490955-73d7-4ccd-a12d-0298676ccf69"), "https://tass.ru/", "//a[contains(@class, 'tass_pkg_link-v5WdK') and contains(substring(@href, 2), '/')]/@href", new Guid("d74c7a85-d4a8-44bc-8c5f-bc5f71b60c75") },
                    { new Guid("da57a56d-f11e-4da3-993b-828934cf8953"), "https://www.sports.ru/news/", "//a[contains(@href, '.html') and not(contains(@href, '.html#comments'))]/@href", new Guid("a6e56b29-cb95-428a-b676-1607db592bce") },
                    { new Guid("dcbbc026-5b5d-466c-9d9a-19a30da14526"), "https://iz.ru/news/", "//a[contains(@href, '?main_click')]/@href", new Guid("ab6e74cd-405f-489f-8672-c8923c8fa9ec") },
                    { new Guid("df855cd6-bf2c-43a4-9dc7-e45467b93691"), "https://ixbt.games/news/", "//a[@class='card-link']/@href", new Guid("5a57967a-9ab6-48e6-8a13-87b706ae9b85") },
                    { new Guid("ef50c26c-d074-4f3b-85aa-6a98e42df17e"), "https://www.ixbt.com/news/", "//a[starts-with(@href, '/news/') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("14e6bb2d-d968-439d-a6d9-e817e215d1dc") },
                    { new Guid("f5001665-65be-4778-bcf5-35d9074a6103"), "https://tsargrad.tv/", "//a[contains(@class, 'news-item__link')]/@href", new Guid("d8c2325c-a066-4d5f-a080-bc4a8086b9e4") }
                });

            migrationBuilder.InsertData(
                table: "news_source_logos",
                columns: new[] { "id", "source_id", "url" },
                values: new object[] { new Guid("96db53de-f002-4e78-9872-f1286c51cc08"), new Guid("5a57967a-9ab6-48e6-8a13-87b706ae9b85"), "https://sun13-2.userapi.com/s/v1/ig2/_ID-2w6Llad8ig5_987dKAfh1pyLdj7HfLHqGx9HxyDjoEDN7wxR0ZWJm5ja1Ey6UuQXaEYEBW1Zd51cpRrjSGfS.jpg?size=100x100&quality=96&crop=22,22,626,626&ava=1" });

            migrationBuilder.InsertData(
                table: "news_parse_editor_settings",
                columns: new[] { "id", "is_required", "name_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("0447ce9e-0d45-4d03-89ac-8581145663df"), false, "//div[@itemprop='author']/span[@itemprop='name']/text()", new Guid("bd5e633f-793a-44d7-bee4-6104660d8326") },
                    { new Guid("0a643c92-9fc7-4271-ba76-628be8896cc6"), false, "//div[@class='author']/span[@itemprop='author']/span[@itemprop='name']/a/text()", new Guid("a69e9126-aa28-4fe5-a7bd-be9d6117938e") },
                    { new Guid("18c9baa2-ead4-456d-93c1-5980861fc762"), false, "//span[@itemprop='author']/span[@itemprop='name']/@content", new Guid("7ad5cd9a-4de7-42d1-9d50-a705754196f5") },
                    { new Guid("4e76fd02-c6cb-4cfd-8062-8666eb1498d7"), false, "//div[contains(@class, 'styles_bodyWrapper')]//div[contains(@class, 'styles_authorsLinks')]/a/text()", new Guid("f40d9536-44e5-45cf-95a0-ed05a887ee19") },
                    { new Guid("557f1ea5-b05b-4fb9-a891-6f03f754dac5"), false, "//div[@class='topic-authors']/a[@class='topic-authors__author']/text()", new Guid("13c63e40-ce79-41e4-9b46-dcafe1cce434") },
                    { new Guid("6034acae-fee9-4001-ad57-25dfcdf2913b"), false, "//div[@class='article__authors']//span[@class='article__authors__author']/span[@class='article__authors__author__name']/text()", new Guid("048afc27-d220-4129-918b-d5a1e9989e21") },
                    { new Guid("8a305001-16ef-4c01-9fb7-87a8d7e5181b"), false, "//p[@class='doc__text document_authors']/text()", new Guid("b2628384-b53c-4e6d-a380-f06b7fa40fa1") },
                    { new Guid("9960f528-e582-44ec-8784-91e2aaad7f0b"), false, "//footer[@class='news-item__footer']/div[@class='news-item__footer-after-news']/p[position()=1]//span/text()", new Guid("c015cb02-92f7-40ca-846c-afe21950a399") },
                    { new Guid("a4487be2-332a-4b31-8b3a-1cbb4649a8f3"), false, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']//a[@itemprop='author']//span[@itemprop='name']/text()", new Guid("d8bd2f21-e873-442f-bec7-c9a7930d2db1") },
                    { new Guid("cd0f71c9-5001-4ada-9c93-21ad4ff152b2"), false, "//div[contains(@class, 'full-article')]/div[@class='authors-block']//span[text()='Автор']/../a/text()", new Guid("38481a31-8043-454c-b720-49c4efb3aeef") },
                    { new Guid("cf51679e-4658-4c80-89c5-17fc3de7cdb4"), false, "//article//header//div[@class='article-head__author-name']/a[@rel='author']/span/text()", new Guid("121162a8-6a7c-4e61-9e54-ef037e135a8d") },
                    { new Guid("dbb5d05d-ca10-41c6-8362-b376e6be59dc"), false, "//div[@class='article_top']//div[@class='authors']//div[@class='autor']//span/text()", new Guid("d5f3849b-40cb-4ceb-bbcd-8903b97d8e93") },
                    { new Guid("e80ddfbe-f4f5-4904-8c72-b5292b433361"), false, "//div[@class='container-fluid publication-footer']//a[contains(@class, 'text-secondary')]/@title", new Guid("beeb9b0d-f3c3-4051-9a83-ea8758fcf977") },
                    { new Guid("ec219c28-247b-471e-92f1-cc23ffb9fb21"), false, "//div[contains(@class, 'PageArticleContent_authors')]//a[contains(@class, 'LinksOfAuthor_item')]/text()", new Guid("3933a019-c0e5-4e34-a33e-9373cee6758a") },
                    { new Guid("f8452007-e414-4e32-9a3a-e7fe448dd9e9"), false, "//a[@class='article__author']/text()", new Guid("1199fb6e-d599-4e79-8fcf-c327e287c527") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_picture_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("104c6919-3fbb-4c8f-ad3b-523f37972ce3"), false, new Guid("583e3321-929d-4526-ba27-734c0fd62f23"), "//div[@class='inner_content']//div[@class='main_img']//img/@src" },
                    { new Guid("1bc1c0a0-691b-42dc-86b1-0ff1406119e8"), false, new Guid("d5f3849b-40cb-4ceb-bbcd-8903b97d8e93"), "//div[@class='img_box']/a[@class='zoom_js']/img/@src" },
                    { new Guid("1e79ee61-dc5c-4eeb-9632-775bb33f54cc"), false, new Guid("d8bd2f21-e873-442f-bec7-c9a7930d2db1"), "//div[contains(@class, 'article-entry')]//div[contains(@class, 'entry-body')]//div[@class='source-wrapper']/img[@itemprop='image']/@src" },
                    { new Guid("469d60fa-2a8f-433a-98a3-0f10160eb375"), false, new Guid("1199fb6e-d599-4e79-8fcf-c327e287c527"), "//div[@class='article__media']//img/@src" },
                    { new Guid("48c77a34-1d10-4b2a-9a4c-d8c7a9787b93"), false, new Guid("13c63e40-ce79-41e4-9b46-dcafe1cce434"), "//div[contains(@class, 'topic-body__title-image')]//img[contains(@class, 'picture__image')]/@src" },
                    { new Guid("663c37be-3057-4e83-8173-fa4ea99dc132"), false, new Guid("01902fcd-cd21-4d96-bf1f-5dfc7812381e"), "//div[contains(@class, 'big_photo')]//div[@class='big_photo__img']//img/@src" },
                    { new Guid("76002a71-4908-4653-a2ce-ad37107a5097"), false, new Guid("a69e9126-aa28-4fe5-a7bd-be9d6117938e"), "//div[@class='b_article-media']//div[@class='mainarea-wrapper']/figure/img[@class='item-image-front']/@src" },
                    { new Guid("8381dc9f-ef9b-46a3-a458-4ac1f21c5545"), false, new Guid("62b37a37-4fd7-4dbe-8b53-25e936db2e02"), "//div[@class='photoview__open']/img/@src" },
                    { new Guid("970c9a11-0351-4cec-a491-dbd27cd4bd4f"), false, new Guid("beeb9b0d-f3c3-4051-9a83-ea8758fcf977"), "//a[@class='glightbox']/img[contains(@class, 'pub-cover')]/@src" },
                    { new Guid("993f5306-e7a0-4747-a1dd-cee580b2b110"), false, new Guid("121162a8-6a7c-4e61-9e54-ef037e135a8d"), "//article//header/div[@class='article-head__photo']/img/@src" },
                    { new Guid("99b4102a-cce9-46c2-b7ed-7fda19a730ca"), false, new Guid("38481a31-8043-454c-b720-49c4efb3aeef"), "//div[contains(@class, 'full-article')]/div[contains(@class, 'gallery')]/picture/img/@src" },
                    { new Guid("aecefde1-848d-450f-96dc-32dcd4d678d3"), false, new Guid("f40d9536-44e5-45cf-95a0-ed05a887ee19"), "//article//header/div[contains(@class, 'styles_cover_media')]/img/@src" },
                    { new Guid("bf4194e1-c62d-4586-a043-d26851a2db50"), false, new Guid("2428fc94-f50e-473d-b266-4d797fac1316"), "//div[contains(@class, 'HeaderMedia_image')]//img[contains(@class, 'Image_image')]/@src" },
                    { new Guid("cc4bf93a-cd61-4ae7-98b9-e00501a4ffcb"), false, new Guid("bd5e633f-793a-44d7-bee4-6104660d8326"), "//div[@itemprop='articleBody']//div[@itemprop='image']/picture/img[@itemprop='contentUrl']/@src" },
                    { new Guid("d0948c9c-7751-4db2-862d-450837584825"), false, new Guid("1a7ff9f2-4a8f-4138-857c-16e9873187db"), "//article/figure/img/@src" },
                    { new Guid("fc58cb55-6475-47c8-a230-0e1103e564c6"), false, new Guid("c38454ee-bc5a-4045-9924-7098e80f1976"), "//div[@class='b-material-incut-m-image']//@src" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "published_at_culture_info", "published_at_format", "published_at_x_path" },
                values: new object[,]
                {
                    { new Guid("0ace0c78-e1fa-4c04-a8a7-62661ff70a1d"), false, new Guid("1a7ff9f2-4a8f-4138-857c-16e9873187db"), "ru-RU", "dd M yyyy, HH:mm", "//article/div[@class='header']/span/text()" },
                    { new Guid("29a41b0b-2fae-4a80-bbcf-752254bc2df2"), false, new Guid("beeb9b0d-f3c3-4051-9a83-ea8758fcf977"), "ru-RU", "yyyy-MM-dd HH:mm:ss", "//div[contains(@class, 'publication-footer')]//div[contains(@class, 'pubdatetime')]//div[contains(@class, 'badge-time')]/text()" },
                    { new Guid("3ac8274e-b682-4d31-9f9e-2d22789119b8"), false, new Guid("7ad5cd9a-4de7-42d1-9d50-a705754196f5"), "ru-RU", "dd M yyyy в HH:mm", "//div[@class='b-article__top-author']/p[@class='date']/text()" },
                    { new Guid("43a31e4a-08a9-40f9-9ad2-a11e1d303fd7"), false, new Guid("c38454ee-bc5a-4045-9924-7098e80f1976"), "ru-RU", "HH:mm", "//p[@class='b-material__date']/text()" },
                    { new Guid("447ed99c-f28a-47d3-b100-29ef7f7a92f5"), false, new Guid("3933a019-c0e5-4e34-a33e-9373cee6758a"), "ru-RU", "dd.MM.yyyy HH:mm", "//div[contains(@class, 'PageArticleContent_date')]/text()" },
                    { new Guid("477b48ff-eade-4fe2-bce2-75bd42a55ee5"), false, new Guid("01902fcd-cd21-4d96-bf1f-5dfc7812381e"), "ru-RU", "yyyy-MM-ddTHH:mm:ssZ", "//div[@class='article_page__left__top__left']//div[@class='article_page__left__top__time']//time/@datetime" },
                    { new Guid("4d01ba31-2bcf-4b8c-8e9c-af523b84be32"), false, new Guid("583e3321-929d-4526-ba27-734c0fd62f23"), "ru-RU", "dd M yyyy, HH:mm", "//div[@class='date_full']/text()" },
                    { new Guid("4dc98414-5c74-49f0-bb3a-0d075ff8e47d"), false, new Guid("13c63e40-ce79-41e4-9b46-dcafe1cce434"), "ru-RU", "HH:mm, d M yyyy", "//div[@class='topic-page__header']//a[contains(@class, 'topic-header__time')]/text()" },
                    { new Guid("558dbd47-cf6f-4815-86b9-0c14453e2990"), false, new Guid("d5f3849b-40cb-4ceb-bbcd-8903b97d8e93"), "ru-RU", "dd.MM.yyyy HH:mm", "//div[@class='article_top']//div[@class='date']//time/text()" },
                    { new Guid("7727460b-c679-41e6-a052-1b99e3c2e109"), false, new Guid("d8bd2f21-e873-442f-bec7-c9a7930d2db1"), "ru-RU", "yyyy-MM-ddTHH:mm:sszzz", "//div[contains(@class, 'article-entry')]//div[@class='entry-info']/span[@itemprop='datePublished']/@content" },
                    { new Guid("8129b5c7-8dcb-4dbd-87c0-eb8d780319a6"), false, new Guid("121162a8-6a7c-4e61-9e54-ef037e135a8d"), "ru-RU", "dd M yyyy, HH:mm", "//article//header//time[@class='article-head__date']/text()" },
                    { new Guid("8453b75e-e1af-4c46-89a4-e870eca3bdcf"), false, new Guid("b59d6368-6740-4aed-af58-ae2f5383f88e"), "ru-RU", "yyyy-MM-ddTHH:mm:ss", "//article[@itemprop='articleBody']/meta[@itemprop='datePublished']/@content" },
                    { new Guid("aa3c2586-f5b6-4605-8e67-d13dacedae5d"), false, new Guid("62b37a37-4fd7-4dbe-8b53-25e936db2e02"), "ru-RU", "HH:mm dd.MM.yyyy", "//div[@class='article__info']//div[@class='article__info-date']/a/text()" },
                    { new Guid("b814183d-5ece-4ce1-bf14-5e8b489a90eb"), false, new Guid("bd5e633f-793a-44d7-bee4-6104660d8326"), "ru-RU", "yyyy-MM-ddTHH:mm:sszzz", "//div[@class='publication-info']/time[@itemprop='datePublished']/@datetime" },
                    { new Guid("c2b6a038-9b64-45ba-9d54-9eca2c38086e"), false, new Guid("048afc27-d220-4129-918b-d5a1e9989e21"), "ru-RU", "yyyy-MM-ddTHH:mm:sszzz", "//div[@class='article__header__info-block']/time[@class='article__header__date']/@datetime" },
                    { new Guid("c4476e2e-f94d-473c-b8e2-1ce17202af99"), false, new Guid("c015cb02-92f7-40ca-846c-afe21950a399"), "ru-RU", "yyyy-MM-ddTHH:mm:sszzz", "//header[@class='news-item__header']//time/@content" },
                    { new Guid("c7702441-b477-4297-9121-a3bf4b0f4041"), false, new Guid("38481a31-8043-454c-b720-49c4efb3aeef"), "ru-RU", "dd.MM.yyyy HH:mm", "//div[contains(@class, 'full-article')]//time/text()" },
                    { new Guid("e0f78653-0a00-4acc-bb1f-58af7ee64d74"), false, new Guid("a69e9126-aa28-4fe5-a7bd-be9d6117938e"), "ru-RU", "yyyy-MM-ddTHH:mm:sszzz", "//article/div[@class='b_article-header']//time[@itemprop='datePublished']/@datetime" },
                    { new Guid("eaaf0d83-eb7b-49f6-a1c1-b79e76aaf696"), false, new Guid("b2628384-b53c-4e6d-a380-f06b7fa40fa1"), "ru-RU", "yyyy-MM-ddTHH:mm:sszzz", "//div[@class='doc_header__time']/time[@class='doc_header__publish_time']/@datetime" },
                    { new Guid("fbf1aced-5867-4e8a-a7f3-bf199b5e5511"), false, new Guid("de1c0851-8bd0-42f4-adcb-c57c9f397cdb"), "ru-RU", "yyyy-MM-d HH:mm", "//div[contains(@class, 'article__date-autor-shortcode')]/div[contains(@class, 'article__date')]/time[@class='date']/@datetime" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_sub_title_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("167fff8c-8c12-47b3-abdd-7997aa398612"), false, new Guid("7ad5cd9a-4de7-42d1-9d50-a705754196f5"), "//h4/text()" },
                    { new Guid("1dc5cf37-2008-4195-9dca-67e84017135d"), false, new Guid("13c63e40-ce79-41e4-9b46-dcafe1cce434"), "//div[contains(@class, 'topic-body__title')]/text()" },
                    { new Guid("243e40d4-416e-488e-af7e-7ad3936a1459"), false, new Guid("2428fc94-f50e-473d-b266-4d797fac1316"), "//h3/text()" },
                    { new Guid("2c6390fb-9d03-4fae-809e-f67af8767d5b"), false, new Guid("b2628384-b53c-4e6d-a380-f06b7fa40fa1"), "//header[@class='doc_header']/h2[@class='doc_header__subheader']/text()" },
                    { new Guid("2e99158f-454e-4138-a07e-576894bb0ee3"), false, new Guid("a69e9126-aa28-4fe5-a7bd-be9d6117938e"), "//h2/text()" },
                    { new Guid("38fa98cb-0d8a-4b61-988c-85ad34ef58b3"), false, new Guid("1a7ff9f2-4a8f-4138-857c-16e9873187db"), "//h4/text()" },
                    { new Guid("59903f24-bf76-4baf-95a5-f5d812322abf"), false, new Guid("1199fb6e-d599-4e79-8fcf-c327e287c527"), "//div[@class='article__intro']/p/text()" },
                    { new Guid("78f26ba9-6ae7-4ed3-9b71-d339cfec903d"), false, new Guid("f40d9536-44e5-45cf-95a0-ed05a887ee19"), "//article//header//p[contains(@class, 'styles_subtitle')]/text()" },
                    { new Guid("79257204-b4e7-4087-a6c6-a225f8384f44"), false, new Guid("beeb9b0d-f3c3-4051-9a83-ea8758fcf977"), "//div[@class='container-fluid shifted']/p[@class='announce lead']/text()" },
                    { new Guid("86f85603-56af-4c36-bd28-51eaaf405845"), false, new Guid("048afc27-d220-4129-918b-d5a1e9989e21"), "//div[contains(@class, 'article__text')]/div[@class='article__text__overview']/span/text()" },
                    { new Guid("aeb67563-05f6-441f-a437-200e27a7e105"), false, new Guid("de1c0851-8bd0-42f4-adcb-c57c9f397cdb"), "//div[contains(@class, 'article__summary')]/text()" },
                    { new Guid("c6a008f0-48b8-4233-96ac-363b780fd72a"), false, new Guid("d8bd2f21-e873-442f-bec7-c9a7930d2db1"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()=1]/text()" },
                    { new Guid("e03c4986-061d-43b8-84e6-084fc1fbba2a"), false, new Guid("62b37a37-4fd7-4dbe-8b53-25e936db2e02"), "//h1[@class='article__second-title']/text()" },
                    { new Guid("ec2b073a-2122-43c2-be01-32af1c033720"), false, new Guid("38481a31-8043-454c-b720-49c4efb3aeef"), "//h1/text()" },
                    { new Guid("ee8a486e-ad5f-47d3-a4b6-38e4e460f55e"), false, new Guid("3933a019-c0e5-4e34-a33e-9373cee6758a"), "//div[contains(@class, 'PageArticleContent_lead')]/text()" }
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
