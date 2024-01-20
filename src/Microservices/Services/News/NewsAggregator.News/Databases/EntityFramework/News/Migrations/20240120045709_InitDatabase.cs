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
                columns: new[] { "id", "is_enabled", "site_url", "title" },
                values: new object[,]
                {
                    { new Guid("0e191193-a3cd-4fa9-ae89-c20197729139"), false, "https://www.gazeta.ru/", "Газета.Ru" },
                    { new Guid("108dc436-3701-4dcc-a5c5-74f3ce9b6551"), false, "https://tsargrad.tv/", "Царьград" },
                    { new Guid("25f28d98-ce9b-4644-a2e6-73b307e8d5dc"), false, "https://www.ixbt.com/", "iXBT.com" },
                    { new Guid("381e641e-e2a3-4643-a926-714ef9e15260"), false, "https://www.rbc.ru/", "РБК" },
                    { new Guid("3b0060b2-846b-4e02-8d42-fdf87bed697b"), false, "https://vz.ru/", "ВЗГЛЯД.РУ" },
                    { new Guid("4a7c0dee-e6d0-4463-900e-d06d1d927380"), false, "https://aif.ru/", "Аргументы и факты" },
                    { new Guid("543699bd-41c1-4b53-9da7-ef1686fe317f"), false, "https://life.ru/", "Life" },
                    { new Guid("75828a25-07f1-4d6a-8ec1-695ddb04a57d"), false, "https://www.sports.ru/", "Storts.ru" },
                    { new Guid("7d996633-9009-4b19-959d-035723090271"), false, "https://www.belta.by/", "БелТА" },
                    { new Guid("8c46af6e-c294-4f28-9574-aab5f0a0f1f2"), false, "https://lenta.ru/", "Лента.Ру" },
                    { new Guid("8e7adb56-ce86-4f07-9f79-47c355628173"), false, "https://www.interfax.ru/", "Интерфакс" },
                    { new Guid("8ff0f02e-8c61-4929-9ca5-5f454a8fa4ff"), false, "https://www.kommersant.ru/", "Коммерсантъ" },
                    { new Guid("9f73cbf2-21ca-402a-be1a-b1ba5ec48f2e"), false, "https://www.m24.ru/", "Москва 24" },
                    { new Guid("a4925934-eb97-408a-ac0b-398058a23e63"), false, "https://ria.ru/", "РИА Новости" },
                    { new Guid("ad977e9b-4c12-4a06-a513-16d9ed971d09"), false, "https://russian.rt.com/", "RT на русском" },
                    { new Guid("b2ffce25-5218-4c6f-ad15-6e6e8ad00bea"), false, "https://tass.ru/", "ТАСС" },
                    { new Guid("b455ed1c-d855-41b7-a6c4-d2e54bc6d239"), false, "https://www.championat.com/", "Чемпионат.com" },
                    { new Guid("c6c1077d-86d1-459f-a0e9-6fb8d3de75c5"), false, "https://rg.ru/", "Российская газета" },
                    { new Guid("ce9f4f17-fd5b-4c8c-8ed4-622f07ce9a8d"), false, "https://3dnews.ru/", "3Dnews.ru" },
                    { new Guid("d0c0455f-e035-4db0-bb56-24f55933605f"), false, "https://iz.ru/", "Известия" },
                    { new Guid("d5b5bedd-169c-452b-a82e-2d9fe1d032a2"), false, "https://ura.news/", "Ura.ru" },
                    { new Guid("d7dc63ce-b93e-43a9-a1f4-9079d6e5c9fb"), false, "https://ixbt.games/", "iXBT.games" },
                    { new Guid("ddb9b4ca-5a73-4787-9294-401232464b8a"), false, "https://www.pravda.ru/", "Правда.ру" },
                    { new Guid("de41591b-876c-4461-a5c2-1aa6fd110afe"), false, "https://svpressa.ru/", "СвободнаяПресса" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_settings",
                columns: new[] { "id", "description_x_path", "source_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("06811943-267a-4f2d-a8c8-95f3351215a0"), "//div[@itemprop='articleBody']/*[not(name()='div')]", new Guid("d5b5bedd-169c-452b-a82e-2d9fe1d032a2"), "//h1/text()" },
                    { new Guid("104efb97-85e8-4f8c-b114-dc6f4ba696a0"), "//article/div[@class='news_text']", new Guid("3b0060b2-846b-4e02-8d42-fdf87bed697b"), "//h1/text()" },
                    { new Guid("11aadafb-a4dd-4a58-8629-cf8ce75f8204"), "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]", new Guid("543699bd-41c1-4b53-9da7-ef1686fe317f"), "//h1/text()" },
                    { new Guid("297459d1-05fd-4ff0-8a27-b6ed3b38c9a9"), "//div[@itemprop='articleBody']", new Guid("d0c0455f-e035-4db0-bb56-24f55933605f"), "//h1/span/text()" },
                    { new Guid("333e711c-df42-4d46-b184-f7fc0be9755d"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()>1]", new Guid("ce9f4f17-fd5b-4c8c-8ed4-622f07ce9a8d"), "//h1/text()" },
                    { new Guid("5c012385-7d49-433d-864e-c4801fad3b62"), "//div[@class='container-fluid shifted']/p[@class='announce lead']", new Guid("d7dc63ce-b93e-43a9-a1f4-9079d6e5c9fb"), "//h1/text()" },
                    { new Guid("60a8bf17-3a84-4005-b5dc-e3f3c41a0bfa"), "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]", new Guid("9f73cbf2-21ca-402a-be1a-b1ba5ec48f2e"), "//h1/text()" },
                    { new Guid("639a227f-1145-413f-a31f-625806a98e56"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]", new Guid("8ff0f02e-8c61-4929-9ca5-5f454a8fa4ff"), "//h1/text()" },
                    { new Guid("652ad3d6-0b0c-4e03-b63d-d423353f09e9"), "//div[contains(@class, 'news-item__content')]", new Guid("75828a25-07f1-4d6a-8ec1-695ddb04a57d"), "//h1/text()" },
                    { new Guid("796b244d-62d6-4850-b1a4-a63c1a0424fc"), "//div[@class='js-mediator-article']", new Guid("7d996633-9009-4b19-959d-035723090271"), "//h1/text()" },
                    { new Guid("84aa6a1c-1069-4e84-89be-412d24c0e8f0"), "//div[contains(@class, 'article__text ')]", new Guid("ad977e9b-4c12-4a06-a513-16d9ed971d09"), "//h1/text()" },
                    { new Guid("8c992ec3-4fdd-4227-af28-40a8c7147b3e"), "//div[contains(@class, 'PageContentCommonStyling_text')]", new Guid("c6c1077d-86d1-459f-a0e9-6fb8d3de75c5"), "//h1/text()" },
                    { new Guid("916855b4-fc97-4912-b377-4989a4dbec35"), "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]", new Guid("de41591b-876c-4461-a5c2-1aa6fd110afe"), "//h1[@class='b-text__title']/text()" },
                    { new Guid("99a2089f-d817-44d1-bb9a-54bd8f75231e"), "//div[@class='article_text']", new Guid("4a7c0dee-e6d0-4463-900e-d06d1d927380"), "//h1/text()" },
                    { new Guid("a24d3d69-7a37-4ec4-8bca-f36b9cee8c45"), "//article/div[@class='article-content']/*[not(@class)]", new Guid("b455ed1c-d855-41b7-a6c4-d2e54bc6d239"), "//article/header/div[@class='article-head__title']/text()" },
                    { new Guid("a7358504-c166-448e-aec0-06551efba665"), "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]", new Guid("8e7adb56-ce86-4f07-9f79-47c355628173"), "//h1/text()" },
                    { new Guid("b64bd6e6-96bb-4418-8605-ef8f321ff51d"), "//div[@class='topic-body__content']", new Guid("8c46af6e-c294-4f28-9574-aab5f0a0f1f2"), "//h1[@class='topic-body__titles']/span[@class='topic-body__title']/text()" },
                    { new Guid("bf4f907b-40f3-40e5-84d7-01f355db17a0"), "//div[contains(@class, 'article__body')]", new Guid("a4925934-eb97-408a-ac0b-398058a23e63"), "//div[@class='article__title']/text()" },
                    { new Guid("c3634855-64eb-4317-abfd-374fbcdf212d"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview'))]", new Guid("381e641e-e2a3-4643-a926-714ef9e15260"), "//h1/text()" },
                    { new Guid("e1c3962b-1f29-4c19-bcb1-bae0b937bbfd"), "//div[@itemprop='articleBody']", new Guid("25f28d98-ce9b-4644-a2e6-73b307e8d5dc"), "//h1/text()" },
                    { new Guid("e33c1f1e-c340-47d8-a7b1-e83706121acf"), "//div[@itemprop='articleBody']", new Guid("0e191193-a3cd-4fa9-ae89-c20197729139"), "//h1/text()" },
                    { new Guid("ede76a6c-a708-4b49-b85f-8effdb219e16"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]", new Guid("108dc436-3701-4dcc-a5c5-74f3ce9b6551"), "//h1[@class='article__title']/text()" },
                    { new Guid("eefea549-6e8d-4091-a73c-921d2736b37d"), "//article", new Guid("b2ffce25-5218-4c6f-ad15-6e6e8ad00bea"), "//h1/text()" },
                    { new Guid("fcd68569-c792-482d-8182-302340ec987e"), "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]", new Guid("ddb9b4ca-5a73-4787-9294-401232464b8a"), "//h1/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_search_settings",
                columns: new[] { "id", "news_site_url", "news_url_x_path", "source_id" },
                values: new object[,]
                {
                    { new Guid("00dbb644-0027-4e8e-b33f-8e30e8000ec4"), "https://www.championat.com/news/1.html?utm_source=button&utm_medium=news", "//a[contains(@href, 'news-') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("b455ed1c-d855-41b7-a6c4-d2e54bc6d239") },
                    { new Guid("04659b45-9794-4855-8157-548ccc9304ea"), "https://tass.ru/", "//a[contains(@class, 'tass_pkg_link-v5WdK') and contains(substring(@href, 2), '/')]/@href", new Guid("b2ffce25-5218-4c6f-ad15-6e6e8ad00bea") },
                    { new Guid("059d9283-1710-4224-99e0-5705c06db49e"), "https://ria.ru/", "//a[contains(@class, 'cell-list__item-link')]/@href", new Guid("a4925934-eb97-408a-ac0b-398058a23e63") },
                    { new Guid("0c3694c0-d25c-40d2-bae9-3838cebee0fe"), "https://ixbt.games/news/", "//a[@class='card-link']/@href", new Guid("d7dc63ce-b93e-43a9-a1f4-9079d6e5c9fb") },
                    { new Guid("30c30bc0-907f-4425-ad2a-91843ab1c367"), "https://www.sports.ru/news/", "//a[contains(@href, '.html') and not(contains(@href, '.html#comments'))]/@href", new Guid("75828a25-07f1-4d6a-8ec1-695ddb04a57d") },
                    { new Guid("3916df72-62cc-4828-981e-a49204335a8a"), "https://www.ixbt.com/news/", "//a[starts-with(@href, '/news/') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("25f28d98-ce9b-4644-a2e6-73b307e8d5dc") },
                    { new Guid("3942a1a0-8eb8-4142-b5a3-5bee6c38b801"), "https://www.kommersant.ru/", "//a[contains(@href, '/doc/') and contains(@href, '?from=')]/@href", new Guid("8ff0f02e-8c61-4929-9ca5-5f454a8fa4ff") },
                    { new Guid("5ebbd419-e718-479e-9b6a-3337b6464e4b"), "https://www.belta.by/", "//a[contains(@href, 'https://www.belta.by/') and contains(@href, '/view/')]/@href", new Guid("7d996633-9009-4b19-959d-035723090271") },
                    { new Guid("7b7a305a-0bb5-48a8-ab3e-ed6ff22cfca3"), "https://www.gazeta.ru/news/", "//a[contains(@href, '/news/') and contains(@href, '.shtml') and not(contains(@href, '?'))]/@href", new Guid("0e191193-a3cd-4fa9-ae89-c20197729139") },
                    { new Guid("8c9de735-a215-4ef7-8b17-977cc198bdbe"), "https://3dnews.ru/news/", "//div[@class='news-feed-all']//a[@class='entry-header']/h1/../@href", new Guid("ce9f4f17-fd5b-4c8c-8ed4-622f07ce9a8d") },
                    { new Guid("942afacf-f043-4d49-bd13-3d1ea9c6d6ee"), "https://life.ru/s/novosti", "//a[contains(@href, '/p/')]/@href", new Guid("543699bd-41c1-4b53-9da7-ef1686fe317f") },
                    { new Guid("946663b8-869b-4db8-9464-831b901ddaba"), "https://www.m24.ru/", "//a[contains(@href, '/news/')]/@href", new Guid("9f73cbf2-21ca-402a-be1a-b1ba5ec48f2e") },
                    { new Guid("96ea066b-27df-4781-8e71-aa1ff2e89b8b"), "https://aif.ru/", "//span[contains(@class, 'item_text__title')]/../@href", new Guid("4a7c0dee-e6d0-4463-900e-d06d1d927380") },
                    { new Guid("a4d274e0-e920-4e7b-8fd0-703f7fe4b658"), "https://www.interfax.ru/", "//div[@class='timeline']//a[@tabindex=5]/@href", new Guid("8e7adb56-ce86-4f07-9f79-47c355628173") },
                    { new Guid("ad9ee4a1-7f3f-4689-90c1-8101177dfc1f"), "https://russian.rt.com/", "//a[contains(@class, 'link') and contains(@href, 'news/')]/@href", new Guid("ad977e9b-4c12-4a06-a513-16d9ed971d09") },
                    { new Guid("af84aa4d-0885-49d9-9ded-99ae1a879829"), "https://iz.ru/news/", "//a[contains(@href, '?main_click')]/@href", new Guid("d0c0455f-e035-4db0-bb56-24f55933605f") },
                    { new Guid("b91b6888-9d31-46e5-ae9a-aea72571f77c"), "https://svpressa.ru/all/news/", "//a[contains(@href, '/news/') and not(contains(@href, '?')) and not(starts-with(@href, '/all/news/'))]/@href", new Guid("de41591b-876c-4461-a5c2-1aa6fd110afe") },
                    { new Guid("bc8e51f7-04ec-45c3-9264-852b5c140373"), "https://www.pravda.ru/", "//a[contains(@href, '/news/') and not(@href='https://www.pravda.ru/news/')]/@href", new Guid("ddb9b4ca-5a73-4787-9294-401232464b8a") },
                    { new Guid("d11fef47-67e4-4bd0-88f1-1cfda742ffce"), "https://lenta.ru/", "//a[starts-with(@href, '/news/')]/@href", new Guid("8c46af6e-c294-4f28-9574-aab5f0a0f1f2") },
                    { new Guid("e1857db5-b24b-4efe-a231-30c4750e6cad"), "https://vz.ru/", "//a[contains(@href, '.html') and not(contains(@href, '#comments')) and not(contains(@href, '?')) and not(contains(@href, '/about/'))]/@href", new Guid("3b0060b2-846b-4e02-8d42-fdf87bed697b") },
                    { new Guid("e29bce9f-2676-4601-a124-be74f6eb652b"), "https://ura.news/", "//a[contains(@href, '/news/')]/@href", new Guid("d5b5bedd-169c-452b-a82e-2d9fe1d032a2") },
                    { new Guid("e51bca0f-3511-4e85-8123-4df13e5f6baf"), "https://tsargrad.tv/", "//a[contains(@class, 'news-item__link')]/@href", new Guid("108dc436-3701-4dcc-a5c5-74f3ce9b6551") },
                    { new Guid("eb057d7b-9004-41d8-bf59-36b65af7fd0a"), "https://rg.ru/", "//a[contains(@href, '.html')]/@href", new Guid("c6c1077d-86d1-459f-a0e9-6fb8d3de75c5") },
                    { new Guid("f6033cea-342c-4700-b7d1-b6d260755e41"), "https://www.rbc.ru/", "//a[contains(@href, 'https://www.rbc.ru/') and contains(@href, '?from=')]/@href", new Guid("381e641e-e2a3-4643-a926-714ef9e15260") }
                });

            migrationBuilder.InsertData(
                table: "news_source_logos",
                columns: new[] { "id", "source_id", "url" },
                values: new object[] { new Guid("87e402ec-3b34-456b-9bd1-8fd2f37d11af"), new Guid("d7dc63ce-b93e-43a9-a1f4-9079d6e5c9fb"), "https://sun13-2.userapi.com/s/v1/ig2/_ID-2w6Llad8ig5_987dKAfh1pyLdj7HfLHqGx9HxyDjoEDN7wxR0ZWJm5ja1Ey6UuQXaEYEBW1Zd51cpRrjSGfS.jpg?size=100x100&quality=96&crop=22,22,626,626&ava=1" });

            migrationBuilder.InsertData(
                table: "news_parse_editor_settings",
                columns: new[] { "id", "is_required", "name_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("05c29fc9-514d-40ee-a6c2-f3e9ebd01cfe"), false, "//p[@class='doc__text document_authors']/text()", new Guid("639a227f-1145-413f-a31f-625806a98e56") },
                    { new Guid("06da314d-5483-4d6d-873a-6fb82af55b19"), false, "//div[@itemprop='author']/span[@itemprop='name']/text()", new Guid("06811943-267a-4f2d-a8c8-95f3351215a0") },
                    { new Guid("16378a93-f6dc-4714-8556-03ab72782757"), false, "//div[@class='article_top']//div[@class='authors']//div[@class='autor']//span/text()", new Guid("99a2089f-d817-44d1-bb9a-54bd8f75231e") },
                    { new Guid("3ff2308d-1010-41b1-a8bf-85a6ddf3bc13"), false, "//div[contains(@class, 'full-article')]/div[@class='authors-block']//span[text()='Автор']/../a/text()", new Guid("fcd68569-c792-482d-8182-302340ec987e") },
                    { new Guid("8bd2ba06-73f6-4f56-9f7f-978141f7cbf5"), false, "//div[contains(@class, 'styles_bodyWrapper')]//div[contains(@class, 'styles_authorsLinks')]/a/text()", new Guid("11aadafb-a4dd-4a58-8629-cf8ce75f8204") },
                    { new Guid("8ea47e6b-8fa0-437a-a1f0-cc8606c5ce0d"), false, "//div[@class='author']/span[@itemprop='author']/span[@itemprop='name']/a/text()", new Guid("e33c1f1e-c340-47d8-a7b1-e83706121acf") },
                    { new Guid("9ba2ea69-0e2b-4a33-b628-a7eb43188317"), false, "//div[@class='topic-authors']/a[@class='topic-authors__author']/text()", new Guid("b64bd6e6-96bb-4418-8605-ef8f321ff51d") },
                    { new Guid("9e2733d2-8900-465d-b248-1488077342dc"), false, "//div[contains(@class, 'PageArticleContent_authors')]//a[contains(@class, 'LinksOfAuthor_item')]/text()", new Guid("8c992ec3-4fdd-4227-af28-40a8c7147b3e") },
                    { new Guid("c17583ba-1356-41fc-9849-2b50a2cd9b44"), false, "//footer[@class='news-item__footer']/div[@class='news-item__footer-after-news']/p[position()=1]//span/text()", new Guid("652ad3d6-0b0c-4e03-b63d-d423353f09e9") },
                    { new Guid("c5d27159-c6c5-48e3-8518-198db90f3642"), false, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']//a[@itemprop='author']//span[@itemprop='name']/text()", new Guid("333e711c-df42-4d46-b184-f7fc0be9755d") },
                    { new Guid("cc8220b2-68e0-43c1-a36c-93f122da8d13"), false, "//div[@class='container-fluid publication-footer']//a[contains(@class, 'text-secondary')]/@title", new Guid("5c012385-7d49-433d-864e-c4801fad3b62") },
                    { new Guid("dbd9f5b2-9c60-406c-8e0c-dfdd867bd076"), false, "//a[@class='article__author']/text()", new Guid("ede76a6c-a708-4b49-b85f-8effdb219e16") },
                    { new Guid("dcfcff16-7ef7-423d-afd1-5ff3feee9f93"), false, "//article//header//div[@class='article-head__author-name']/a[@rel='author']/span/text()", new Guid("a24d3d69-7a37-4ec4-8bca-f36b9cee8c45") },
                    { new Guid("eb9a59a7-beb2-40be-926a-b86ff7462840"), false, "//span[@itemprop='author']/span[@itemprop='name']/@content", new Guid("e1c3962b-1f29-4c19-bcb1-bae0b937bbfd") },
                    { new Guid("f1fde91b-4bee-4370-8bf1-170d65af102f"), false, "//div[@class='article__authors']//span[@class='article__authors__author']/span[@class='article__authors__author__name']/text()", new Guid("c3634855-64eb-4317-abfd-374fbcdf212d") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_picture_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("0ca35586-d73b-4d20-b0ec-0d7d29846b36"), false, new Guid("5c012385-7d49-433d-864e-c4801fad3b62"), "//a[@class='glightbox']/img[contains(@class, 'pub-cover')]/@src" },
                    { new Guid("0f10bcfc-3eea-4d10-bc40-2afb66198f16"), false, new Guid("a24d3d69-7a37-4ec4-8bca-f36b9cee8c45"), "//article//header/div[@class='article-head__photo']/img/@src" },
                    { new Guid("2979b532-f3a1-44f4-9563-5c9a53b87b92"), false, new Guid("bf4f907b-40f3-40e5-84d7-01f355db17a0"), "//div[@class='photoview__open']/img/@src" },
                    { new Guid("2c1902e2-3b28-49ac-8507-edf045c21394"), false, new Guid("796b244d-62d6-4850-b1a4-a63c1a0424fc"), "//div[@class='inner_content']//div[@class='main_img']//img/@src" },
                    { new Guid("39573887-45b4-4963-8c2a-561ff7166f3d"), false, new Guid("eefea549-6e8d-4091-a73c-921d2736b37d"), "//div[contains(@class, 'HeaderMedia_image')]//img[contains(@class, 'Image_image')]/@src" },
                    { new Guid("49ea3e16-0b6f-4084-a1e2-29acf2d6bc42"), false, new Guid("104efb97-85e8-4f8c-b114-dc6f4ba696a0"), "//article/figure/img/@src" },
                    { new Guid("5bb63f3e-62a4-4db1-a089-584e5cde704b"), false, new Guid("b64bd6e6-96bb-4418-8605-ef8f321ff51d"), "//div[contains(@class, 'topic-body__title-image')]//img[contains(@class, 'picture__image')]/@src" },
                    { new Guid("643b4f2f-1f6a-4726-9e0d-3d8ad17c48ad"), false, new Guid("297459d1-05fd-4ff0-8a27-b6ed3b38c9a9"), "//div[contains(@class, 'big_photo')]//div[@class='big_photo__img']//img/@src" },
                    { new Guid("72896d24-b21e-421a-9e2d-759e8fb7c58c"), false, new Guid("e33c1f1e-c340-47d8-a7b1-e83706121acf"), "//div[@class='b_article-media']//div[@class='mainarea-wrapper']/figure/img[@class='item-image-front']/@src" },
                    { new Guid("745b9362-fcef-40df-936b-921dffb30b66"), false, new Guid("ede76a6c-a708-4b49-b85f-8effdb219e16"), "//div[@class='article__media']//img/@src" },
                    { new Guid("8fc143dc-029c-46af-adad-636a851c30b5"), false, new Guid("99a2089f-d817-44d1-bb9a-54bd8f75231e"), "//div[@class='img_box']/a[@class='zoom_js']/img/@src" },
                    { new Guid("95da3037-09ee-4cf6-b747-80fcd6f0b160"), false, new Guid("fcd68569-c792-482d-8182-302340ec987e"), "//div[contains(@class, 'full-article')]/div[contains(@class, 'gallery')]/picture/img/@src" },
                    { new Guid("9f724093-314a-4677-a56c-340caf19c77d"), false, new Guid("60a8bf17-3a84-4005-b5dc-e3f3c41a0bfa"), "//div[@class='b-material-incut-m-image']//@src" },
                    { new Guid("acfd4024-1032-41f3-90d1-7c9638487ed5"), false, new Guid("11aadafb-a4dd-4a58-8629-cf8ce75f8204"), "//article//header/div[contains(@class, 'styles_cover_media')]/img/@src" },
                    { new Guid("c9523051-5ae8-4d7f-86a2-0dc92ad458e1"), false, new Guid("333e711c-df42-4d46-b184-f7fc0be9755d"), "//div[contains(@class, 'article-entry')]//div[contains(@class, 'entry-body')]//div[@class='source-wrapper']/img[@itemprop='image']/@src" },
                    { new Guid("f52408fc-403f-4a43-88f2-b41a5e78aecc"), false, new Guid("06811943-267a-4f2d-a8c8-95f3351215a0"), "//div[@itemprop='articleBody']//div[@itemprop='image']/picture/img[@itemprop='contentUrl']/@src" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "published_at_culture_info", "published_at_format", "published_at_x_path" },
                values: new object[,]
                {
                    { new Guid("058b2015-7491-49cc-89d5-2c9e922a4c4c"), false, new Guid("06811943-267a-4f2d-a8c8-95f3351215a0"), "ru-RU", "yyyy-MM-ddTHH:mm:sszzz", "//div[@class='publication-info']/time[@itemprop='datePublished']/@datetime" },
                    { new Guid("10306c52-2838-4e54-88c3-47da023caf92"), false, new Guid("fcd68569-c792-482d-8182-302340ec987e"), "ru-RU", "dd.MM.yyyy HH:mm", "//div[contains(@class, 'full-article')]//time/text()" },
                    { new Guid("158d0989-d154-43dd-bd85-10105ecece7d"), false, new Guid("99a2089f-d817-44d1-bb9a-54bd8f75231e"), "ru-RU", "dd.MM.yyyy HH:mm", "//div[@class='article_top']//div[@class='date']//time/text()" },
                    { new Guid("1c539b6b-7d84-4653-ae05-f0fa5070515e"), false, new Guid("333e711c-df42-4d46-b184-f7fc0be9755d"), "ru-RU", "yyyy-MM-ddTHH:mm:sszzz", "//div[contains(@class, 'article-entry')]//div[@class='entry-info']/span[@itemprop='datePublished']/@content" },
                    { new Guid("1cbf95e5-2db5-4f75-a418-962e10b8169f"), false, new Guid("104efb97-85e8-4f8c-b114-dc6f4ba696a0"), "ru-RU", "dd MMMM yyyy, HH:mm", "//article/div[@class='header']/span/text()" },
                    { new Guid("38a9a406-c8c8-45bd-b2a0-c5ba8d8a4db6"), false, new Guid("639a227f-1145-413f-a31f-625806a98e56"), "ru-RU", "yyyy-MM-ddTHH:mm:sszzz", "//div[@class='doc_header__time']/time[@class='doc_header__publish_time']/@datetime" },
                    { new Guid("3a2040cb-e49f-47c0-9ef5-5c08074335d5"), false, new Guid("8c992ec3-4fdd-4227-af28-40a8c7147b3e"), "ru-RU", "dd.MM.yyyy HH:mm", "//div[contains(@class, 'PageArticleContent_date')]/text()" },
                    { new Guid("51e47dbc-2da9-46ca-9081-76c24a6cf1c9"), false, new Guid("e33c1f1e-c340-47d8-a7b1-e83706121acf"), "ru-RU", "yyyy-MM-ddTHH:mm:sszzz", "//article/div[@class='b_article-header']//time[@itemprop='datePublished']/@datetime" },
                    { new Guid("54eb5ad4-1d15-4ea6-9259-cc2d63df129c"), false, new Guid("297459d1-05fd-4ff0-8a27-b6ed3b38c9a9"), "ru-RU", "yyyy-MM-ddTHH:mm:ssZ", "//div[@class='article_page__left__top__left']//div[@class='article_page__left__top__time']//time/@datetime" },
                    { new Guid("5f976996-d21b-4bc4-b456-bb33051f8811"), false, new Guid("a24d3d69-7a37-4ec4-8bca-f36b9cee8c45"), "ru-RU", "dd MMMM yyyy, HH:mm МСК", "//article//header//time[@class='article-head__date']/text()" },
                    { new Guid("98734092-f0de-4250-bfbf-6cae90452cd7"), false, new Guid("5c012385-7d49-433d-864e-c4801fad3b62"), "ru-RU", "yyyy-MM-dd HH:mm:ss", "//div[contains(@class, 'publication-footer')]//div[contains(@class, 'pubdatetime')]//div[contains(@class, 'badge-time')]/text()" },
                    { new Guid("a0cdc652-48c1-4b17-8cd1-9243092898fb"), false, new Guid("bf4f907b-40f3-40e5-84d7-01f355db17a0"), "ru-RU", "HH:mm dd.MM.yyyy", "//div[@class='article__info']//div[@class='article__info-date']/a/text()" },
                    { new Guid("a667b150-7a1a-4593-b9ad-953ba3f18843"), false, new Guid("e1c3962b-1f29-4c19-bcb1-bae0b937bbfd"), "ru-RU", "dd MMMM yyyy в HH:mm", "//div[@class='b-article__top-author']/p[@class='date']/text()" },
                    { new Guid("b337860b-3181-4dd0-b00d-4c289f6acc0c"), false, new Guid("84aa6a1c-1069-4e84-89be-412d24c0e8f0"), "ru-RU", "yyyy-MM-d HH:mm", "//div[contains(@class, 'article__date-autor-shortcode')]/div[contains(@class, 'article__date')]/time[@class='date']/@datetime" },
                    { new Guid("c1def389-f1f9-425e-ab03-2215fa3c8262"), false, new Guid("a7358504-c166-448e-aec0-06551efba665"), "ru-RU", "yyyy-MM-ddTHH:mm:ss", "//article[@itemprop='articleBody']/meta[@itemprop='datePublished']/@content" },
                    { new Guid("c8ed82c6-adc8-4755-980f-32bb9336d329"), false, new Guid("b64bd6e6-96bb-4418-8605-ef8f321ff51d"), "ru-RU", "HH:mm, dd MMMM yyyy", "//div[@class='topic-page__header']//a[contains(@class, 'topic-header__time')]/text()" },
                    { new Guid("d3c751b9-df14-4145-a336-cce1f37c663a"), false, new Guid("60a8bf17-3a84-4005-b5dc-e3f3c41a0bfa"), "ru-RU", "HH:mm", "//p[@class='b-material__date']/text()" },
                    { new Guid("de6d8cac-6dbd-490c-8000-e1c7a11e3d61"), false, new Guid("c3634855-64eb-4317-abfd-374fbcdf212d"), "ru-RU", "yyyy-MM-ddTHH:mm:sszzz", "//div[@class='article__header__info-block']/time[@class='article__header__date']/@datetime" },
                    { new Guid("e290c1e9-4d33-4b10-8e38-1e3265563841"), false, new Guid("796b244d-62d6-4850-b1a4-a63c1a0424fc"), "ru-RU", "dd MMMM yyyy, HH:mm", "//div[@class='date_full']/text()" },
                    { new Guid("f0fa14ed-2fa6-4263-8994-e23e08d47f8a"), false, new Guid("652ad3d6-0b0c-4e03-b63d-d423353f09e9"), "ru-RU", "yyyy-MM-ddTHH:mm:sszzz", "//header[@class='news-item__header']//time/@content" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_sub_title_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("0120ba75-493f-4a78-9d89-2b9a4b624b77"), false, new Guid("5c012385-7d49-433d-864e-c4801fad3b62"), "//div[@class='container-fluid shifted']/p[@class='announce lead']/text()" },
                    { new Guid("106d18bb-868e-4ee6-abac-c3e818273d75"), false, new Guid("e1c3962b-1f29-4c19-bcb1-bae0b937bbfd"), "//h4/text()" },
                    { new Guid("2ee14dad-6785-4e8e-8b2e-18093dfdc18b"), false, new Guid("11aadafb-a4dd-4a58-8629-cf8ce75f8204"), "//article//header//p[contains(@class, 'styles_subtitle')]/text()" },
                    { new Guid("3442f29f-c40c-4e4e-849c-0e7f1d4f345d"), false, new Guid("84aa6a1c-1069-4e84-89be-412d24c0e8f0"), "//div[contains(@class, 'article__summary')]/text()" },
                    { new Guid("653019f8-21dd-405c-9d32-df4b97a2c689"), false, new Guid("eefea549-6e8d-4091-a73c-921d2736b37d"), "//h3/text()" },
                    { new Guid("66b45158-90bd-4f0e-a179-a72c98ab2227"), false, new Guid("333e711c-df42-4d46-b184-f7fc0be9755d"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()=1]/text()" },
                    { new Guid("70554b34-c2e7-43a1-81d8-6b05ae6011d9"), false, new Guid("639a227f-1145-413f-a31f-625806a98e56"), "//header[@class='doc_header']/h2[contains(@class, 'doc_header__subheader')]/text()" },
                    { new Guid("797533c0-6f2d-470a-bee6-960e034390e3"), false, new Guid("bf4f907b-40f3-40e5-84d7-01f355db17a0"), "//h1[@class='article__second-title']/text()" },
                    { new Guid("9ab1ac2b-a171-4a68-a31f-f13599075492"), false, new Guid("c3634855-64eb-4317-abfd-374fbcdf212d"), "//div[contains(@class, 'article__text')]/div[@class='article__text__overview']/span/text()" },
                    { new Guid("a16df8f2-3191-40d0-bba8-e7f753a485e4"), false, new Guid("ede76a6c-a708-4b49-b85f-8effdb219e16"), "//div[@class='article__intro']/p/text()" },
                    { new Guid("abce57be-178f-4c94-a0f4-f80d09c42993"), false, new Guid("b64bd6e6-96bb-4418-8605-ef8f321ff51d"), "//div[contains(@class, 'topic-body__title')]/text()" },
                    { new Guid("bfa9877f-b0f3-4ea0-bbff-029bf30fda84"), false, new Guid("104efb97-85e8-4f8c-b114-dc6f4ba696a0"), "//h4/text()" },
                    { new Guid("c6a39232-fd19-41c5-b538-1d90a9233dd7"), false, new Guid("e33c1f1e-c340-47d8-a7b1-e83706121acf"), "//h2/text()" },
                    { new Guid("ce9d2c5f-786a-4764-a2ff-3e73929b20af"), false, new Guid("8c992ec3-4fdd-4227-af28-40a8c7147b3e"), "//div[contains(@class, 'PageArticleContent_lead')]/text()" },
                    { new Guid("e6954b0f-cfa3-4bf7-b2df-c3cc867df45c"), false, new Guid("fcd68569-c792-482d-8182-302340ec987e"), "//h1/text()" }
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
