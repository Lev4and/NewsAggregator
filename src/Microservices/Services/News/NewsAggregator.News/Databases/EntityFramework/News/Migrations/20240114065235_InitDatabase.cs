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
                    { new Guid("0e7dc564-09f5-4459-8ce6-484813d42d08"), "https://www.kommersant.ru/", "Коммерсантъ" },
                    { new Guid("115bcd5d-51a1-4e63-af0a-184ffcbdfec0"), "https://tass.ru/", "ТАСС" },
                    { new Guid("1380571d-e9e2-4afc-a030-0eca02b82d6e"), "https://www.pravda.ru/", "Правда.ру" },
                    { new Guid("1ab59068-a728-4342-b0f1-09061b6fbefa"), "https://www.interfax.ru/", "Интерфакс" },
                    { new Guid("24d4494e-c4fe-49d5-a380-298a567ac8f1"), "https://ura.news/", "Ura.ru" },
                    { new Guid("2ea241df-5591-49ef-92c3-4c126832a20d"), "https://ria.ru/", "РИА Новости" },
                    { new Guid("39e55c9c-6560-436b-8e87-2b78e0c8e0ab"), "https://www.m24.ru/", "Москва 24" },
                    { new Guid("4295ac40-1939-4131-b0dd-4523447075a6"), "https://3dnews.ru/", "3Dnews.ru" },
                    { new Guid("43463f89-8950-4e88-bc52-363ccda96a09"), "https://www.belta.by/", "БелТА" },
                    { new Guid("4c9c3280-88e7-437c-b174-c225612f084a"), "https://tsargrad.tv/", "Царьград" },
                    { new Guid("58fdc005-b020-4635-a893-9644cebb9439"), "https://rg.ru/", "Российская газета" },
                    { new Guid("59e341db-a401-4eff-882b-dc7edda2b0b9"), "https://ixbt.games/", "iXBT.games" },
                    { new Guid("654bab69-00cb-4fbd-8f4c-446a65b57305"), "https://www.ixbt.com/", "iXBT.com" },
                    { new Guid("8800fb2b-677e-4ee1-9c9e-a321189bcf09"), "https://vz.ru/", "ВЗГЛЯД.РУ" },
                    { new Guid("9ea7d130-c31f-48fd-b69e-32c29c55be44"), "https://www.rbc.ru/", "РБК" },
                    { new Guid("a0187c74-b425-423d-a622-aab48d7697d7"), "https://aif.ru/", "Аргументы и факты" },
                    { new Guid("a82aa7c5-5bb6-4987-9374-44b641b4f5d2"), "https://russian.rt.com/", "RT на русском" },
                    { new Guid("adcb0720-5103-4d0d-8415-230fd66366a0"), "https://www.gazeta.ru/", "Газета.Ru" },
                    { new Guid("db500443-d13d-4791-a560-666561cf7365"), "https://life.ru/", "Life" },
                    { new Guid("e76818b7-6a36-43a6-99bf-bebd255c9a57"), "https://www.championat.com/", "Чемпионат.com" },
                    { new Guid("e8db6165-c37c-4ecb-9d46-ef07d4aef75f"), "https://www.sports.ru/", "Storts.ru" },
                    { new Guid("ef2cb2f1-a2e4-4f55-8eae-77aeaf4d8c6e"), "https://svpressa.ru/", "СвободнаяПресса" },
                    { new Guid("f9eb9b5e-0173-417f-9b55-f8a9702407e3"), "https://lenta.ru/", "Лента.Ру" },
                    { new Guid("fb3e4c83-1dd5-460f-b5f0-da5ad00c6536"), "https://iz.ru/", "Известия" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_settings",
                columns: new[] { "id", "description_x_path", "source_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("02680e9e-2627-47b6-8aab-a243f1cdfcaf"), "//div[@class='container-fluid shifted']/p[@class='announce lead']", new Guid("59e341db-a401-4eff-882b-dc7edda2b0b9"), "//h1/text()" },
                    { new Guid("172f2f08-0a34-45ed-8777-476a3e0c7874"), "//div[@itemprop='articleBody']/*[not(name()='div')]", new Guid("24d4494e-c4fe-49d5-a380-298a567ac8f1"), "//h1/text()" },
                    { new Guid("1e86ead4-f28c-4b69-85d9-b3675a70da2e"), "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]", new Guid("ef2cb2f1-a2e4-4f55-8eae-77aeaf4d8c6e"), "//h1[@class='b-text__title']/text()" },
                    { new Guid("433ce9c2-c9b1-438d-80e3-bb04c17a0384"), "//article/div[@class='news_text']", new Guid("8800fb2b-677e-4ee1-9c9e-a321189bcf09"), "//h1/text()" },
                    { new Guid("48874118-b87f-4d97-934c-b8180a92c236"), "//div[contains(@class, 'article__body')]", new Guid("2ea241df-5591-49ef-92c3-4c126832a20d"), "//div[@class='article__title']/text()" },
                    { new Guid("51209d16-7bc6-4975-b2e7-ffdac5c77c46"), "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]", new Guid("1ab59068-a728-4342-b0f1-09061b6fbefa"), "//h1/text()" },
                    { new Guid("54904b2b-d860-4d70-a7d5-6008d98ff70f"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]", new Guid("0e7dc564-09f5-4459-8ce6-484813d42d08"), "//h1/text()" },
                    { new Guid("55e71f9c-954e-45b8-b8af-a4b7bcaa66ab"), "//div[@class='js-mediator-article']", new Guid("43463f89-8950-4e88-bc52-363ccda96a09"), "//h1/text()" },
                    { new Guid("5950ff35-5e1f-4bf9-99ef-046fc10e6a2c"), "//div[@itemprop='articleBody']", new Guid("654bab69-00cb-4fbd-8f4c-446a65b57305"), "//h1/text()" },
                    { new Guid("685ca8c8-9c9e-47db-95b1-9d8ff9e113c2"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]", new Guid("4c9c3280-88e7-437c-b174-c225612f084a"), "//h1[@class='article__title']/text()" },
                    { new Guid("7db57106-afc4-4691-a57e-c296a93063df"), "//div[contains(@class, 'news-item__content')]", new Guid("e8db6165-c37c-4ecb-9d46-ef07d4aef75f"), "//h1/text()" },
                    { new Guid("907ca9dd-8602-448e-bd51-443e31a77e41"), "//div[contains(@class, 'PageContentCommonStyling_text')]", new Guid("58fdc005-b020-4635-a893-9644cebb9439"), "//h1/text()" },
                    { new Guid("a0fe027b-b3ee-45ac-9de0-623c673e40f0"), "//div[@class='topic-body__content']", new Guid("f9eb9b5e-0173-417f-9b55-f8a9702407e3"), "//h1[@class='topic-body__titles']/span[@class='topic-body__title']/text()" },
                    { new Guid("a58273a6-4855-4031-b5a5-0dfe1b929a58"), "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]", new Guid("db500443-d13d-4791-a560-666561cf7365"), "//h1/text()" },
                    { new Guid("a76247a6-ad3a-4f0b-99de-d82d017417f7"), "//article", new Guid("115bcd5d-51a1-4e63-af0a-184ffcbdfec0"), "//h1/text()" },
                    { new Guid("b40dc921-cbc5-4ebb-b4b0-00091fe7483d"), "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]", new Guid("1380571d-e9e2-4afc-a030-0eca02b82d6e"), "//div[@class='title article-header']/text()" },
                    { new Guid("c52ff96e-22a1-4513-864c-f11f35c13537"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview'))]", new Guid("9ea7d130-c31f-48fd-b69e-32c29c55be44"), "//h1/text()" },
                    { new Guid("c7b74fc2-004a-4e6a-9ee2-f6618270f78a"), "//div[@itemprop='articleBody']", new Guid("fb3e4c83-1dd5-460f-b5f0-da5ad00c6536"), "//h1/span/text()" },
                    { new Guid("caab4ccb-1768-4720-aa56-73c542ebe6a6"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()>1]", new Guid("4295ac40-1939-4131-b0dd-4523447075a6"), "//h1/text()" },
                    { new Guid("d393ac8d-3e4e-4cea-a27d-d0cd6f8f1bfb"), "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]", new Guid("39e55c9c-6560-436b-8e87-2b78e0c8e0ab"), "//h1/text()" },
                    { new Guid("e56af18e-4a40-4bae-a199-1b84c198a2f2"), "//div[@class='article_text']", new Guid("a0187c74-b425-423d-a622-aab48d7697d7"), "//h1/text()" },
                    { new Guid("eccbbe9b-e4fc-42f4-b9d6-7d7c1329ea7a"), "//article/div[@class='article-content']/*[not(@class)]", new Guid("e76818b7-6a36-43a6-99bf-bebd255c9a57"), "//article/header/div[@class='article-head__title']/text()" },
                    { new Guid("fa594bd7-6e36-49f8-92bf-6bbd3a4f27b1"), "//div[contains(@class, 'article__text ')]", new Guid("a82aa7c5-5bb6-4987-9374-44b641b4f5d2"), "//h1/text()" },
                    { new Guid("fe78dcec-510d-4665-8609-9565c6cea249"), "//div[@itemprop='articleBody']", new Guid("adcb0720-5103-4d0d-8415-230fd66366a0"), "//h1/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_search_settings",
                columns: new[] { "id", "news_site_url", "news_url_x_path", "source_id" },
                values: new object[,]
                {
                    { new Guid("0518b17c-ad21-4a91-9550-2a16232b7b80"), "https://ura.news/", "//a[contains(@href, '/news/')]/@href", new Guid("24d4494e-c4fe-49d5-a380-298a567ac8f1") },
                    { new Guid("08f2af59-50b6-4f00-837f-725d860e5ab4"), "https://lenta.ru/", "//a[starts-with(@href, '/news/') or starts-with(@href, '/articles/')]/@href", new Guid("f9eb9b5e-0173-417f-9b55-f8a9702407e3") },
                    { new Guid("1c7d6762-6b63-4fcb-b8bb-2f6e9ff8b1d1"), "https://iz.ru/news/", "//a[contains(@href, '?main_click')]/@href", new Guid("fb3e4c83-1dd5-460f-b5f0-da5ad00c6536") },
                    { new Guid("28dc87f2-745c-4b7c-86e3-430595bc50a8"), "https://aif.ru/", "//span[contains(@class, 'item_text__title')]/../@href", new Guid("a0187c74-b425-423d-a622-aab48d7697d7") },
                    { new Guid("388a2fac-2892-4e12-ba5d-0e61e2054ec0"), "https://ria.ru/", "//a[contains(@class, 'cell-list__item-link')]/@href", new Guid("2ea241df-5591-49ef-92c3-4c126832a20d") },
                    { new Guid("42ed79f5-faa7-4e80-87a6-a3b06bc0c4b8"), "https://tass.ru/", "//a[contains(@class, 'tass_pkg_link-v5WdK') and contains(substring(@href, 2), '/')]/@href", new Guid("115bcd5d-51a1-4e63-af0a-184ffcbdfec0") },
                    { new Guid("4a018e31-a75c-4aec-b23c-55be125cc914"), "https://www.gazeta.ru/news/", "//a[contains(@href, '/news/') and contains(@href, '.shtml') and not(contains(@href, '?'))]/@href", new Guid("adcb0720-5103-4d0d-8415-230fd66366a0") },
                    { new Guid("4e9c3186-d870-495d-8f47-7e6b1efeb018"), "https://ixbt.games/news/", "//a[@class='card-link']/@href", new Guid("59e341db-a401-4eff-882b-dc7edda2b0b9") },
                    { new Guid("6ff6fb99-f526-4e11-bd61-8c1bea2bdd72"), "https://rg.ru/", "//a[contains(@href, '.html')]/@href", new Guid("58fdc005-b020-4635-a893-9644cebb9439") },
                    { new Guid("79686222-8092-490c-907e-2acaf2fe64a5"), "https://www.championat.com/news/1.html?utm_source=button&utm_medium=news", "//a[contains(@href, 'news-') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("e76818b7-6a36-43a6-99bf-bebd255c9a57") },
                    { new Guid("7a42251c-5442-4072-947f-af2c2b3c2fe2"), "https://www.m24.ru/", "//a[contains(@href, '/news/')]/@href", new Guid("39e55c9c-6560-436b-8e87-2b78e0c8e0ab") },
                    { new Guid("8ad12c01-a953-4dea-a89e-b2b8820654dd"), "https://www.ixbt.com/news/", "//a[starts-with(@href, '/news/') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("654bab69-00cb-4fbd-8f4c-446a65b57305") },
                    { new Guid("9a5aa201-9169-43d5-b35c-4f4db63a03a3"), "https://www.sports.ru/news/", "//a[contains(@href, '.html') and not(contains(@href, '.html#comments'))]/@href", new Guid("e8db6165-c37c-4ecb-9d46-ef07d4aef75f") },
                    { new Guid("a48f8ac7-fbb6-4f89-839f-062257b3dcda"), "https://life.ru/s/novosti", "//a[contains(@href, '/p/')]/@href", new Guid("db500443-d13d-4791-a560-666561cf7365") },
                    { new Guid("a5b6b59f-368b-46c7-afe4-80cf5f2bac63"), "https://vz.ru/", "//a[contains(@href, '.html') and not(contains(@href, '#comments')) and not(contains(@href, '?')) and not(contains(@href, '/about/'))]/@href", new Guid("8800fb2b-677e-4ee1-9c9e-a321189bcf09") },
                    { new Guid("a96c983b-ab96-4461-87bc-628d1f49641f"), "https://www.interfax.ru/", "//div[@class='timeline']//a[@tabindex=5]/@href", new Guid("1ab59068-a728-4342-b0f1-09061b6fbefa") },
                    { new Guid("c93a6599-2f8e-44db-bc4a-d0c66efa1e13"), "https://svpressa.ru/all/news/", "//a[contains(@href, '/news/') and not(contains(@href, '?')) and not(starts-with(@href, '/all/news/'))]/@href", new Guid("ef2cb2f1-a2e4-4f55-8eae-77aeaf4d8c6e") },
                    { new Guid("d1ae468c-b0e1-4fff-a5eb-e5c4b4b66167"), "https://www.pravda.ru/", "//a[contains(@href, '/news/') and not(@href='https://www.pravda.ru/news/')]/@href", new Guid("1380571d-e9e2-4afc-a030-0eca02b82d6e") },
                    { new Guid("d2371ef8-a7cf-4ca5-a9a6-bf0cd95d00bd"), "https://russian.rt.com/", "//a[contains(@class, 'link') and contains(@href, 'news/')]/@href", new Guid("a82aa7c5-5bb6-4987-9374-44b641b4f5d2") },
                    { new Guid("d517c0b0-840f-4bf9-a570-1f2bf83beb99"), "https://tsargrad.tv/", "//a[contains(@class, 'news-item__link')]/@href", new Guid("4c9c3280-88e7-437c-b174-c225612f084a") },
                    { new Guid("de2386f6-b870-4537-a72d-3dc4f7e6cc5d"), "https://3dnews.ru/news/", "//div[@class='news-feed-all']//a[@class='entry-header']/h1/../@href", new Guid("4295ac40-1939-4131-b0dd-4523447075a6") },
                    { new Guid("eab144bb-6e14-471f-9f27-33074a620224"), "https://www.kommersant.ru/", "//a[contains(@href, '/doc/') and contains(@href, '?from=')]/@href", new Guid("0e7dc564-09f5-4459-8ce6-484813d42d08") },
                    { new Guid("eb77fb20-4d53-43a4-8753-342bc867c469"), "https://www.belta.by/", "//a[contains(@href, 'https://www.belta.by/') and contains(@href, '/view/')]/@href", new Guid("43463f89-8950-4e88-bc52-363ccda96a09") },
                    { new Guid("efc72965-9c55-44f5-93b0-4e6d718a6110"), "https://www.rbc.ru/", "//a[contains(@href, 'https://www.rbc.ru/') and contains(@href, '?from=')]/@href", new Guid("9ea7d130-c31f-48fd-b69e-32c29c55be44") }
                });

            migrationBuilder.InsertData(
                table: "news_source_logos",
                columns: new[] { "id", "source_id", "url" },
                values: new object[] { new Guid("13952f4b-f79a-494a-a9be-e0e8654b2c85"), new Guid("59e341db-a401-4eff-882b-dc7edda2b0b9"), "https://sun13-2.userapi.com/s/v1/ig2/_ID-2w6Llad8ig5_987dKAfh1pyLdj7HfLHqGx9HxyDjoEDN7wxR0ZWJm5ja1Ey6UuQXaEYEBW1Zd51cpRrjSGfS.jpg?size=100x100&quality=96&crop=22,22,626,626&ava=1" });

            migrationBuilder.InsertData(
                table: "news_parse_editor_settings",
                columns: new[] { "id", "name_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("04f9223d-9de2-4701-ae72-e63d2a001aa9"), "//div[contains(@class, 'styles_bodyWrapper')]//div[contains(@class, 'styles_authorsLinks')]/a/text()", new Guid("a58273a6-4855-4031-b5a5-0dfe1b929a58") },
                    { new Guid("31a9928a-4b66-4480-bc76-90b9cd7fef50"), "//footer[@class='news-item__footer']/div[@class='news-item__footer-after-news']/p[position()=1]//span/text()", new Guid("7db57106-afc4-4691-a57e-c296a93063df") },
                    { new Guid("4fc3093d-43e3-487e-82f1-905c42d3f88b"), "//div[contains(@class, 'full-article')]/div[@class='authors-block']//span[text()='Автор']/../a/text()", new Guid("b40dc921-cbc5-4ebb-b4b0-00091fe7483d") },
                    { new Guid("5c49e9e8-e1fd-4f6d-986d-f412aadc3bab"), "//div[contains(@class, 'article-entry')]//div[@class='entry-info']//a[@itemprop='author']//span[@itemprop='name']/text()", new Guid("caab4ccb-1768-4720-aa56-73c542ebe6a6") },
                    { new Guid("5ddb1601-2f8f-473b-84d0-ecbf97c8ffd1"), "//div[@class='author']/span[@itemprop='author']/span[@itemprop='name']/a/text()", new Guid("fe78dcec-510d-4665-8609-9565c6cea249") },
                    { new Guid("663379d1-df67-4316-9e7f-a6a6af2bedb6"), "//span[@itemprop='author']/span[@itemprop='name']/@content", new Guid("5950ff35-5e1f-4bf9-99ef-046fc10e6a2c") },
                    { new Guid("6a7426e6-b8ca-4c58-a738-ebebc09010e9"), "//a[@class='article__author']/text()", new Guid("685ca8c8-9c9e-47db-95b1-9d8ff9e113c2") },
                    { new Guid("70f40466-280a-4d9d-897e-df2562df5cc9"), "//div[contains(@class, 'PageArticleContent_authors')]//a[contains(@class, 'LinksOfAuthor_item')]/text()", new Guid("907ca9dd-8602-448e-bd51-443e31a77e41") },
                    { new Guid("7ff9f1f3-2f31-4c6e-b631-d0147df73189"), "//div[@class='topic-authors']/a[@class='topic-authors__author']/text()", new Guid("a0fe027b-b3ee-45ac-9de0-623c673e40f0") },
                    { new Guid("933a205e-ed72-4212-aabd-aaf74c5684bc"), "//div[@class='article_top']//div[@class='authors']//div[@class='autor']//span/text()", new Guid("e56af18e-4a40-4bae-a199-1b84c198a2f2") },
                    { new Guid("c8ea0fc7-a3ba-4b0f-9b20-862627c3d38e"), "//p[@class='doc__text document_authors']/text()", new Guid("54904b2b-d860-4d70-a7d5-6008d98ff70f") },
                    { new Guid("cce61d75-4e27-480a-a632-26b659f4ea68"), "//div[@class='container-fluid publication-footer']//a[contains(@class, 'text-secondary')]/@title", new Guid("02680e9e-2627-47b6-8aab-a243f1cdfcaf") },
                    { new Guid("dac324db-e70b-46a4-8c7d-64ba09b5bbda"), "//div[@itemprop='author']/span[@itemprop='name']/text()", new Guid("172f2f08-0a34-45ed-8777-476a3e0c7874") },
                    { new Guid("ebe43dd3-a43e-4c74-a797-6c975553cb45"), "//article//header//div[@class='article-head__author-name']/a[@rel='author']/span/text()", new Guid("eccbbe9b-e4fc-42f4-b9d6-7d7c1329ea7a") },
                    { new Guid("f740153d-3252-40ce-bfc9-c1ebc72d32bc"), "//div[@class='article__authors']//span[@class='article__authors__author']/span[@class='article__authors__author__name']/text()", new Guid("c52ff96e-22a1-4513-864c-f11f35c13537") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_picture_settings",
                columns: new[] { "id", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("00f48862-341f-4c28-807b-e2ead474dd49"), new Guid("02680e9e-2627-47b6-8aab-a243f1cdfcaf"), "//a[@class='glightbox']/img[contains(@class, 'pub-cover')]/@src" },
                    { new Guid("119085d7-9470-48ac-a5db-dd9ab7f1fe10"), new Guid("55e71f9c-954e-45b8-b8af-a4b7bcaa66ab"), "//div[@class='inner_content']//div[@class='main_img']//img/@src" },
                    { new Guid("41a16ab7-e18e-43c0-9cdb-9af581ddc44a"), new Guid("a58273a6-4855-4031-b5a5-0dfe1b929a58"), "//article//header/div[contains(@class, 'styles_cover_media')]/img/@src" },
                    { new Guid("43d60c2b-920b-4d6b-92f2-58b93d7c0672"), new Guid("48874118-b87f-4d97-934c-b8180a92c236"), "//div[@class='photoview__open']/img/@src" },
                    { new Guid("46fae56e-7610-48b5-a1d2-78d7997c0a10"), new Guid("d393ac8d-3e4e-4cea-a27d-d0cd6f8f1bfb"), "//div[@class='b-material-incut-m-image']//@src" },
                    { new Guid("5fe246ec-dc0c-47b2-858e-0306f173c7cf"), new Guid("172f2f08-0a34-45ed-8777-476a3e0c7874"), "//div[@itemprop='articleBody']//div[@itemprop='image']/picture/img[@itemprop='contentUrl']/@src" },
                    { new Guid("6612f573-c330-456e-a10d-edcabb724331"), new Guid("a0fe027b-b3ee-45ac-9de0-623c673e40f0"), "//div[contains(@class, 'topic-body__title-image')]//img[contains(@class, 'picture__image')]/@src" },
                    { new Guid("70e94773-3ff4-4ee2-949e-8f15f37bdb26"), new Guid("433ce9c2-c9b1-438d-80e3-bb04c17a0384"), "//article/figure/img/@src" },
                    { new Guid("9a777f04-a808-4a6b-a3a8-c359b45f1b69"), new Guid("fe78dcec-510d-4665-8609-9565c6cea249"), "//div[@class='b_article-media']//div[@class='mainarea-wrapper']/figure/img[@class='item-image-front']/@src" },
                    { new Guid("b2e4f931-0abb-49bb-ae54-d61795bc6660"), new Guid("685ca8c8-9c9e-47db-95b1-9d8ff9e113c2"), "//div[@class='article__media']//img/@src" },
                    { new Guid("b503810d-9b56-48ce-bb77-5931de5862da"), new Guid("b40dc921-cbc5-4ebb-b4b0-00091fe7483d"), "//div[contains(@class, 'full-article')]/div[contains(@class, 'gallery')]/picture/img/@src" },
                    { new Guid("b6d82653-a48c-44ec-985e-ffd43e6c07b9"), new Guid("e56af18e-4a40-4bae-a199-1b84c198a2f2"), "//div[@class='img_box']/a[@class='zoom_js']/img/@src" },
                    { new Guid("c8ce2ec4-d874-4aa2-adc6-30c4acbb395b"), new Guid("caab4ccb-1768-4720-aa56-73c542ebe6a6"), "//div[contains(@class, 'article-entry')]//div[contains(@class, 'entry-body')]//div[@class='source-wrapper']/img[@itemprop='image']/@src" },
                    { new Guid("d2c997b3-78ea-4491-8b7c-673267953eeb"), new Guid("c7b74fc2-004a-4e6a-9ee2-f6618270f78a"), "//div[contains(@class, 'big_photo')]//div[@class='big_photo__img']//img/@src" },
                    { new Guid("d420f372-a74d-4377-8e6b-a63e6a633c31"), new Guid("a76247a6-ad3a-4f0b-99de-d82d017417f7"), "//div[contains(@class, 'HeaderMedia_image')]//img[contains(@class, 'Image_image')]/@src" },
                    { new Guid("dc42f140-f495-45f7-81d9-a1dc146320ea"), new Guid("eccbbe9b-e4fc-42f4-b9d6-7d7c1329ea7a"), "//article//header/div[@class='article-head__photo']/img/@src" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings",
                columns: new[] { "id", "parse_settings_id", "published_at_culture_info", "published_at_format", "published_at_x_path" },
                values: new object[,]
                {
                    { new Guid("23fdeec1-974c-4afa-b0d7-e61998903c2d"), new Guid("48874118-b87f-4d97-934c-b8180a92c236"), "ru-RU", "HH:mm dd.MM.yyyy", "//div[@class='article__info']//div[@class='article__info-date']/a/text()" },
                    { new Guid("4237006e-c429-4b14-a5ab-1396ab6c8d01"), new Guid("fa594bd7-6e36-49f8-92bf-6bbd3a4f27b1"), "ru-RU", "yyyy-MM-d HH:mm", "//div[contains(@class, 'article__date-autor-shortcode')]/div[contains(@class, 'article__date')]/time[@class='date']/@datetime" },
                    { new Guid("4b8375fb-fe36-4583-9066-885c8a70089d"), new Guid("fe78dcec-510d-4665-8609-9565c6cea249"), "ru-RU", "yyyy-MM-ddTHH:mm:sszzz", "//article/div[@class='b_article-header']//time[@itemprop='datePublished']/@datetime" },
                    { new Guid("5043a7ab-9a8c-4306-9967-44a6fa28fac8"), new Guid("caab4ccb-1768-4720-aa56-73c542ebe6a6"), "ru-RU", "yyyy-MM-ddTHH:mm:sszzz", "//div[contains(@class, 'article-entry')]//div[@class='entry-info']/span[@itemprop='datePublished']/@content" },
                    { new Guid("8ed7e62e-a544-4efb-8c79-ddf1133e1c70"), new Guid("51209d16-7bc6-4975-b2e7-ffdac5c77c46"), "ru-RU", "yyyy-MM-ddTHH:mm:ss", "//article[@itemprop='articleBody']/meta[@itemprop='datePublished']/@content" },
                    { new Guid("93f20cf6-eb00-4ccc-ba02-ccb36d31e208"), new Guid("7db57106-afc4-4691-a57e-c296a93063df"), "ru-RU", "yyyy-MM-ddTHH:mm:sszzz", "//header[@class='news-item__header']//time/@content" },
                    { new Guid("9501ed20-722a-442a-81f0-426cbbf24241"), new Guid("c7b74fc2-004a-4e6a-9ee2-f6618270f78a"), "ru-RU", "yyyy-MM-ddTHH:mm:ssZ", "//div[@class='article_page__left__top__left']//div[@class='article_page__left__top__time']//time/@datetime" },
                    { new Guid("9a0a3883-1811-48e3-9811-80a7c882124d"), new Guid("907ca9dd-8602-448e-bd51-443e31a77e41"), "ru-RU", "dd.MM.yyyy HH:mm", "//div[contains(@class, 'PageArticleContent_date')]/text()" },
                    { new Guid("9acbbba3-78b7-47ea-9ede-4cd536038c28"), new Guid("54904b2b-d860-4d70-a7d5-6008d98ff70f"), "ru-RU", "yyyy-MM-ddTHH:mm:sszzz", "//div[@class='doc_header__time']/time[@class='doc_header__publish_time']/@datetime" },
                    { new Guid("9d9b04ae-f7df-4554-90e4-beb27a1707a2"), new Guid("55e71f9c-954e-45b8-b8af-a4b7bcaa66ab"), "ru-RU", "dd M yyyy, HH:mm", "//div[@class='date_full']/text()" },
                    { new Guid("9f79f9f7-17ae-4163-aa9f-2598b271d6c9"), new Guid("a0fe027b-b3ee-45ac-9de0-623c673e40f0"), "ru-RU", "HH:mm, d M yyyy", "//div[@class='topic-page__header']//a[contains(@class, 'topic-header__time')]/text()" },
                    { new Guid("a35f19d3-cf8f-461e-b600-fe760676c7a2"), new Guid("eccbbe9b-e4fc-42f4-b9d6-7d7c1329ea7a"), "ru-RU", "dd M yyyy, HH:mm", "//article//header//time[@class='article-head__date']/text()" },
                    { new Guid("a37d4ce9-8304-412c-b157-765a056edf09"), new Guid("172f2f08-0a34-45ed-8777-476a3e0c7874"), "ru-RU", "yyyy-MM-ddTHH:mm:sszzz", "//div[@class='publication-info']/time[@itemprop='datePublished']/@datetime" },
                    { new Guid("b40877c2-362b-458a-989c-8826c5a8c8db"), new Guid("b40dc921-cbc5-4ebb-b4b0-00091fe7483d"), "ru-RU", "dd.MM.yyyy HH:mm", "//div[contains(@class, 'full-article')]//time/text()" },
                    { new Guid("ba9e1e95-b5f6-4e1f-aee6-c24c9ef43450"), new Guid("d393ac8d-3e4e-4cea-a27d-d0cd6f8f1bfb"), "ru-RU", "HH:mm", "//p[@class='b-material__date']/text()" },
                    { new Guid("bb28dd05-b306-4f7d-85ac-758857f9e3ff"), new Guid("e56af18e-4a40-4bae-a199-1b84c198a2f2"), "ru-RU", "dd.MM.yyyy HH:mm", "//div[@class='article_top']//div[@class='date']//time/text()" },
                    { new Guid("c86f076c-7abd-40fa-babf-885300485080"), new Guid("5950ff35-5e1f-4bf9-99ef-046fc10e6a2c"), "ru-RU", "dd M yyyy в HH:mm", "//div[@class='b-article__top-author']/p[@class='date']/text()" },
                    { new Guid("d2ae641b-4ac3-40fd-915c-6d4104b62eff"), new Guid("c52ff96e-22a1-4513-864c-f11f35c13537"), "ru-RU", "yyyy-MM-ddTHH:mm:sszzz", "//div[@class='article__header__info-block']/time[@class='article__header__date']/@datetime" },
                    { new Guid("d33a2e50-82ce-4888-a071-934bed259ba4"), new Guid("02680e9e-2627-47b6-8aab-a243f1cdfcaf"), "ru-RU", "yyyy-MM-dd HH:mm:ss", "//div[contains(@class, 'publication-footer')]//div[contains(@class, 'pubdatetime')]//div[contains(@class, 'badge-time')]/text()" },
                    { new Guid("d898ecf7-2c52-4619-b347-a9e94a34ea81"), new Guid("433ce9c2-c9b1-438d-80e3-bb04c17a0384"), "ru-RU", "dd M yyyy, HH:mm", "//article/div[@class='header']/span/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_sub_title_settings",
                columns: new[] { "id", "parse_settings_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("074c069d-1f7f-4c5e-b961-7b743f9e89d0"), new Guid("fa594bd7-6e36-49f8-92bf-6bbd3a4f27b1"), "//div[contains(@class, 'article__summary')]/text()" },
                    { new Guid("1246fc5f-c138-40b8-8a28-62a536c5d5d6"), new Guid("fe78dcec-510d-4665-8609-9565c6cea249"), "//h2/text()" },
                    { new Guid("1819f2cd-762f-492a-9d8e-bc751e30addb"), new Guid("02680e9e-2627-47b6-8aab-a243f1cdfcaf"), "//div[@class='container-fluid shifted']/p[@class='announce lead']/text()" },
                    { new Guid("32d6d9d4-b72a-4317-b271-370ad9647e10"), new Guid("b40dc921-cbc5-4ebb-b4b0-00091fe7483d"), "//h1/text()" },
                    { new Guid("3ae2c4a7-4a74-49da-b438-7e8ff01d3d9c"), new Guid("c52ff96e-22a1-4513-864c-f11f35c13537"), "//div[contains(@class, 'article__text')]/div[@class='article__text__overview']/span/text()" },
                    { new Guid("52b3f2f3-9ea1-4ef6-ad0a-9c31fa86abae"), new Guid("54904b2b-d860-4d70-a7d5-6008d98ff70f"), "//header[@class='doc_header']/h2[@class='doc_header__subheader']/text()" },
                    { new Guid("587db2bd-e7f3-45e9-a8ee-0c7008af573f"), new Guid("a76247a6-ad3a-4f0b-99de-d82d017417f7"), "//h3/text()" },
                    { new Guid("5bf55bc9-3d64-408e-9b08-77281d251250"), new Guid("a58273a6-4855-4031-b5a5-0dfe1b929a58"), "//article//header//p[contains(@class, 'styles_subtitle')]/text()" },
                    { new Guid("6137e726-98b6-4c7f-94c4-366090db3542"), new Guid("48874118-b87f-4d97-934c-b8180a92c236"), "//h1[@class='article__second-title']/text()" },
                    { new Guid("7b0e8900-e3c7-4631-b12f-2d0bd02c013d"), new Guid("a0fe027b-b3ee-45ac-9de0-623c673e40f0"), "//div[contains(@class, 'topic-body__title')]/text()" },
                    { new Guid("94117a90-50c0-4cf2-81d0-a36f5dbae60a"), new Guid("685ca8c8-9c9e-47db-95b1-9d8ff9e113c2"), "//div[@class='article__intro']/p/text()" },
                    { new Guid("a0fc5cac-854e-4750-a998-49db6edb5e29"), new Guid("5950ff35-5e1f-4bf9-99ef-046fc10e6a2c"), "//h4/text()" },
                    { new Guid("a8738187-2a3c-43c6-92db-1e4a52da1e9d"), new Guid("caab4ccb-1768-4720-aa56-73c542ebe6a6"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()=1]/text()" },
                    { new Guid("d71fd3c3-b993-4bd4-9925-eac007dcb0d6"), new Guid("907ca9dd-8602-448e-bd51-443e31a77e41"), "//div[contains(@class, 'PageArticleContent_lead')]/text()" },
                    { new Guid("ee7097b6-743e-4813-8b51-be7c6edcd2be"), new Guid("433ce9c2-c9b1-438d-80e3-bb04c17a0384"), "//h4/text()" }
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
