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
                    published_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
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
                    { new Guid("1407f1fe-0545-460a-9f88-a8b2add6ac0f"), true, "https://rg.ru/", "Российская газета" },
                    { new Guid("1651c650-eb7b-4428-88d0-fe8c742d22dc"), false, "https://ixbt.games/", "iXBT.games" },
                    { new Guid("16d794ba-9bf7-4853-9015-69be2528f942"), true, "https://www.m24.ru/", "Москва 24" },
                    { new Guid("1cef4477-1856-4388-a753-cecd83248c38"), false, "https://www.interfax.ru/", "Интерфакс" },
                    { new Guid("1dcf109c-849e-4aae-a47b-9cdc0be06d54"), true, "https://aif.ru/", "Аргументы и факты" },
                    { new Guid("35270115-3e93-41f5-a60b-37d98193302d"), true, "https://www.pravda.ru/", "Правда.ру" },
                    { new Guid("3faa37f4-ea17-46f1-b685-c74a9c8454af"), true, "https://www.belta.by/", "БелТА" },
                    { new Guid("464fc489-ec00-4593-81af-b764d0a7feab"), true, "https://3dnews.ru/", "3Dnews.ru" },
                    { new Guid("5bb29681-721c-421c-91af-5cb8510a0102"), false, "https://iz.ru/", "Известия" },
                    { new Guid("660a7c13-8aa0-419e-afd8-3c131674acee"), true, "https://www.ixbt.com/", "iXBT.com" },
                    { new Guid("6e34c489-6c84-4c94-9ec5-7a1e11cfc4ab"), true, "https://russian.rt.com/", "RT на русском" },
                    { new Guid("7566efd7-bb98-4b52-9557-4cba288b8065"), true, "https://www.rbc.ru/", "РБК" },
                    { new Guid("877de276-b0e2-4f1b-b264-d027e4eb1f21"), true, "https://svpressa.ru/", "СвободнаяПресса" },
                    { new Guid("b3e60111-63e3-40f5-8582-f6a4afae9bef"), true, "https://lenta.ru/", "Лента.Ру" },
                    { new Guid("bcbcc243-3adb-4cca-8ab2-fce1eded78cc"), true, "https://vz.ru/", "ВЗГЛЯД.РУ" },
                    { new Guid("c1b7fbaf-1c79-46be-84df-de899d80a8e0"), true, "https://www.sports.ru/", "Storts.ru" },
                    { new Guid("c235b6f7-3dfa-4d82-9190-1e1996c12f38"), true, "https://www.gazeta.ru/", "Газета.Ru" },
                    { new Guid("c5b4c601-4c89-4e95-8660-c5ab09cf6f64"), false, "https://tsargrad.tv/", "Царьград" },
                    { new Guid("ca029e54-9483-4839-8c6c-33fd57eb1d14"), true, "https://ura.news/", "Ura.ru" },
                    { new Guid("cc5aab61-9d83-464f-8bfb-a2be7b12d09a"), true, "https://www.championat.com/", "Чемпионат.com" },
                    { new Guid("cd0ec883-6406-4105-8897-7aa29a871b1f"), true, "https://life.ru/", "Life" },
                    { new Guid("d8680051-c816-4dfb-90d0-b0469d81900d"), true, "https://tass.ru/", "ТАСС" },
                    { new Guid("de3238f6-8883-443a-8fb6-6db5336523ec"), true, "https://ria.ru/", "РИА Новости" },
                    { new Guid("f152c902-ac05-47bf-916a-ab4f691212b9"), true, "https://www.kommersant.ru/", "Коммерсантъ" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_settings",
                columns: new[] { "id", "description_x_path", "source_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("0705dc0c-b029-4f15-ae9c-381de1b30d35"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]", new Guid("c5b4c601-4c89-4e95-8660-c5ab09cf6f64"), "//h1[@class='article__title']/text()" },
                    { new Guid("1f436ed2-b03c-4a7f-90ee-7de243eac143"), "//div[contains(@class, 'article__body')]", new Guid("de3238f6-8883-443a-8fb6-6db5336523ec"), "//div[@class='article__title']/text()" },
                    { new Guid("263b754f-cc1f-406c-80c6-55cce11c8cc0"), "//div[@itemprop='articleBody']", new Guid("5bb29681-721c-421c-91af-5cb8510a0102"), "//h1/span/text()" },
                    { new Guid("3b6c32e4-c53f-4865-b291-c3f8d505e069"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]", new Guid("f152c902-ac05-47bf-916a-ab4f691212b9"), "//h1/text()" },
                    { new Guid("40d53873-b083-4f13-bc77-a75f0d3cae96"), "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]", new Guid("35270115-3e93-41f5-a60b-37d98193302d"), "//h1/text()" },
                    { new Guid("5433db97-3772-4c02-8470-bbae58b3d4cd"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview'))]", new Guid("7566efd7-bb98-4b52-9557-4cba288b8065"), "//h1/text()" },
                    { new Guid("5e602853-5b66-4e9d-b39e-42c9d87cdd9e"), "//div[contains(@class, 'news-item__content')]", new Guid("c1b7fbaf-1c79-46be-84df-de899d80a8e0"), "//h1/text()" },
                    { new Guid("7a1777ad-4f46-4c4f-ad23-4c3c1a3fe6dc"), "//div[contains(@class, 'article__text ')]", new Guid("6e34c489-6c84-4c94-9ec5-7a1e11cfc4ab"), "//h1/text()" },
                    { new Guid("7c5ba28d-b7e6-4b9a-8c90-b8dabe4aa3a2"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()>1]", new Guid("464fc489-ec00-4593-81af-b764d0a7feab"), "//h1/text()" },
                    { new Guid("8165c08a-1969-4619-826d-9db884ee709b"), "//div[@class='js-mediator-article']", new Guid("3faa37f4-ea17-46f1-b685-c74a9c8454af"), "//h1/text()" },
                    { new Guid("82dc0bd2-5b87-4ba8-861c-9868ad3598fa"), "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]", new Guid("cd0ec883-6406-4105-8897-7aa29a871b1f"), "//h1/text()" },
                    { new Guid("839988ce-8120-4f17-a54d-fb00438ac53d"), "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]", new Guid("16d794ba-9bf7-4853-9015-69be2528f942"), "//h1/text()" },
                    { new Guid("8d7391a7-5e85-4681-bad8-38d183d1879b"), "//div[@class='article_text']", new Guid("1dcf109c-849e-4aae-a47b-9cdc0be06d54"), "//h1/text()" },
                    { new Guid("8f03d496-b03c-4fd4-863d-b7bdaf240d04"), "//article", new Guid("d8680051-c816-4dfb-90d0-b0469d81900d"), "//h1/text()" },
                    { new Guid("9bcf4c31-2bf4-48d9-beed-52ff2ac43c66"), "//div[@class='topic-body__content']", new Guid("b3e60111-63e3-40f5-8582-f6a4afae9bef"), "//h1[@class='topic-body__titles']/span[@class='topic-body__title']/text()" },
                    { new Guid("9ed4e3a8-dafe-4563-bbc9-d3451637e914"), "//div[@itemprop='articleBody']", new Guid("660a7c13-8aa0-419e-afd8-3c131674acee"), "//h1/text()" },
                    { new Guid("bb1b121c-d92f-4add-b94f-d44d33b4cc6c"), "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]", new Guid("1cef4477-1856-4388-a753-cecd83248c38"), "//h1/text()" },
                    { new Guid("c48ffab0-ef25-49cb-98bc-0317e0b48a7f"), "//div[@class='container-fluid shifted']/p[@class='announce lead']", new Guid("1651c650-eb7b-4428-88d0-fe8c742d22dc"), "//h1/text()" },
                    { new Guid("d4fb8626-e133-41ff-820d-f992ec68b395"), "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]", new Guid("877de276-b0e2-4f1b-b264-d027e4eb1f21"), "//h1[@class='b-text__title']/text()" },
                    { new Guid("d798add7-1159-43d2-9202-fdda15631bc9"), "//div[@itemprop='articleBody']", new Guid("c235b6f7-3dfa-4d82-9190-1e1996c12f38"), "//h1/text()" },
                    { new Guid("db46e84f-3232-48e2-bf7e-15e5fbfd4f2c"), "//article/div[@class='news_text']", new Guid("bcbcc243-3adb-4cca-8ab2-fce1eded78cc"), "//h1/text()" },
                    { new Guid("e1b7ca70-76bc-439f-8e0d-947b3140d8d4"), "//div[@itemprop='articleBody']/*[not(name()='div')]", new Guid("ca029e54-9483-4839-8c6c-33fd57eb1d14"), "//h1/text()" },
                    { new Guid("e87bdd7f-426c-49ca-8df2-169eb373fb47"), "//article/div[@class='article-content']/*[not(@class)]", new Guid("cc5aab61-9d83-464f-8bfb-a2be7b12d09a"), "//article/header/div[@class='article-head__title']/text()" },
                    { new Guid("fb266c0a-9568-4318-b758-842365edd093"), "//div[contains(@class, 'PageContentCommonStyling_text')]", new Guid("1407f1fe-0545-460a-9f88-a8b2add6ac0f"), "//h1/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_search_settings",
                columns: new[] { "id", "news_site_url", "news_url_x_path", "source_id" },
                values: new object[,]
                {
                    { new Guid("11427ad4-1ad5-498f-8d7d-0548cfdc4b68"), "https://www.interfax.ru/", "//div[@class='timeline']//a[@tabindex=5]/@href", new Guid("1cef4477-1856-4388-a753-cecd83248c38") },
                    { new Guid("164a73cb-49c6-4105-a7b9-178b243d076c"), "https://www.belta.by/", "//a[contains(@href, 'https://www.belta.by/') and contains(@href, '/view/')]/@href", new Guid("3faa37f4-ea17-46f1-b685-c74a9c8454af") },
                    { new Guid("1a7b51e9-293c-4a2c-b2fc-69e8eb2cc552"), "https://ura.news/", "//a[contains(@href, '/news/')]/@href", new Guid("ca029e54-9483-4839-8c6c-33fd57eb1d14") },
                    { new Guid("2401cf95-8418-4a2f-8f94-8ecdc3a9a62c"), "https://www.gazeta.ru/news/", "//a[contains(@href, '/news/') and contains(@href, '.shtml') and not(contains(@href, '?'))]/@href", new Guid("c235b6f7-3dfa-4d82-9190-1e1996c12f38") },
                    { new Guid("34deefab-f4a6-4904-a28c-6b930411fda8"), "https://www.championat.com/news/1.html?utm_source=button&utm_medium=news", "//a[contains(@href, 'news-') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("cc5aab61-9d83-464f-8bfb-a2be7b12d09a") },
                    { new Guid("38a7772c-e331-4651-9a54-c2d653f4f590"), "https://aif.ru/", "//span[contains(@class, 'item_text__title')]/../@href", new Guid("1dcf109c-849e-4aae-a47b-9cdc0be06d54") },
                    { new Guid("3f0d5cf4-d342-4e9c-9d2a-69ed61afdb38"), "https://ria.ru/", "//a[contains(@class, 'cell-list__item-link')]/@href", new Guid("de3238f6-8883-443a-8fb6-6db5336523ec") },
                    { new Guid("4d6d7d8e-6f14-4d43-ab88-76adbab77aee"), "https://vz.ru/", "//a[contains(@href, '.html') and not(contains(@href, '#comments')) and not(contains(@href, '?')) and not(contains(@href, '/about/'))]/@href", new Guid("bcbcc243-3adb-4cca-8ab2-fce1eded78cc") },
                    { new Guid("667985ea-4fe1-4f92-81bc-7921cbe22ebd"), "https://rg.ru/", "//a[contains(@href, '.html')]/@href", new Guid("1407f1fe-0545-460a-9f88-a8b2add6ac0f") },
                    { new Guid("6ad40f9e-9fcc-47da-82c3-30605ee2588a"), "https://russian.rt.com/", "//a[contains(@class, 'link') and contains(@href, 'news/')]/@href", new Guid("6e34c489-6c84-4c94-9ec5-7a1e11cfc4ab") },
                    { new Guid("6cf52d18-a471-45b3-b101-5c9fc98e111a"), "https://life.ru/s/novosti", "//a[contains(@href, '/p/')]/@href", new Guid("cd0ec883-6406-4105-8897-7aa29a871b1f") },
                    { new Guid("7bbb61b0-eda2-4f5e-bfeb-9f14024c181e"), "https://iz.ru/news/", "//a[contains(@href, '?main_click')]/@href", new Guid("5bb29681-721c-421c-91af-5cb8510a0102") },
                    { new Guid("8452b706-6379-41c5-8279-3cbfcd140373"), "https://www.kommersant.ru/", "//a[contains(@href, '/doc/') and contains(@href, '?from=')]/@href", new Guid("f152c902-ac05-47bf-916a-ab4f691212b9") },
                    { new Guid("905add5e-d45b-4ba7-aa2c-839b987618b7"), "https://www.sports.ru/news/", "//a[contains(@href, '.html') and not(contains(@href, '.html#comments'))]/@href", new Guid("c1b7fbaf-1c79-46be-84df-de899d80a8e0") },
                    { new Guid("a3531ce1-7a1b-418f-89f3-c789d0ce7825"), "https://tass.ru/", "//a[contains(@class, 'tass_pkg_link-v5WdK') and contains(substring(@href, 2), '/') and not(contains(@href, '/spec/')) and not(contains(@href, 'spec.tass.ru'))]/@href", new Guid("d8680051-c816-4dfb-90d0-b0469d81900d") },
                    { new Guid("ae2fffdd-2b14-42a7-bc2f-b77a524f8942"), "https://ixbt.games/news/", "//a[@class='card-link']/@href", new Guid("1651c650-eb7b-4428-88d0-fe8c742d22dc") },
                    { new Guid("ba4f6bd8-0529-41b5-99bf-b3e9eb1431cb"), "https://www.m24.ru/", "//a[contains(@href, '/news/')]/@href", new Guid("16d794ba-9bf7-4853-9015-69be2528f942") },
                    { new Guid("bc614c07-1144-4767-afda-0ab75e1c2ebd"), "https://www.ixbt.com/news/", "//a[starts-with(@href, '/news/') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("660a7c13-8aa0-419e-afd8-3c131674acee") },
                    { new Guid("bfe48d2d-78fc-4bec-9fd6-6b7bc73bdd45"), "https://3dnews.ru/news/", "//div[@class='news-feed-all']//a[@class='entry-header']/h1/../@href", new Guid("464fc489-ec00-4593-81af-b764d0a7feab") },
                    { new Guid("d3c3e88a-4cd1-4d07-9a01-5fdd6dd4aee3"), "https://svpressa.ru/all/news/", "//a[contains(@href, '/news/') and not(contains(@href, '?')) and not(starts-with(@href, '/all/news/'))]/@href", new Guid("877de276-b0e2-4f1b-b264-d027e4eb1f21") },
                    { new Guid("d46396be-0d74-4b60-89f9-79b2055bb14f"), "https://lenta.ru/", "//a[starts-with(@href, '/news/')]/@href", new Guid("b3e60111-63e3-40f5-8582-f6a4afae9bef") },
                    { new Guid("d9ba818f-a013-4359-8226-66e0eb4b8509"), "https://www.rbc.ru/", "//a[contains(@href, 'https://www.rbc.ru/') and contains(@href, '?from=')]/@href", new Guid("7566efd7-bb98-4b52-9557-4cba288b8065") },
                    { new Guid("da3e590c-b692-4c78-b022-913557dc3460"), "https://tsargrad.tv/", "//a[contains(@class, 'news-item__link')]/@href", new Guid("c5b4c601-4c89-4e95-8660-c5ab09cf6f64") },
                    { new Guid("e0e31d34-282b-4b6d-9224-5a82df9ec955"), "https://www.pravda.ru/", "//a[contains(@href, '/news/') and not(@href='https://www.pravda.ru/news/')]/@href", new Guid("35270115-3e93-41f5-a60b-37d98193302d") }
                });

            migrationBuilder.InsertData(
                table: "news_source_logos",
                columns: new[] { "id", "source_id", "url" },
                values: new object[] { new Guid("60476c14-5a8f-4aa3-9065-c137f88b00a1"), new Guid("1651c650-eb7b-4428-88d0-fe8c742d22dc"), "https://sun13-2.userapi.com/s/v1/ig2/_ID-2w6Llad8ig5_987dKAfh1pyLdj7HfLHqGx9HxyDjoEDN7wxR0ZWJm5ja1Ey6UuQXaEYEBW1Zd51cpRrjSGfS.jpg?size=100x100&quality=96&crop=22,22,626,626&ava=1" });

            migrationBuilder.InsertData(
                table: "news_parse_editor_settings",
                columns: new[] { "id", "is_required", "name_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("033db773-c6ce-40a1-ad0e-1081d057cb00"), true, "//div[@class='container-fluid publication-footer']//a[contains(@class, 'text-secondary')]/@title", new Guid("c48ffab0-ef25-49cb-98bc-0317e0b48a7f") },
                    { new Guid("0aa26444-cc32-44ec-b9df-c45a0cf7d51a"), true, "//div[@class='article_top']//div[@class='authors']//div[@class='autor']//span/text()", new Guid("8d7391a7-5e85-4681-bad8-38d183d1879b") },
                    { new Guid("0b770f04-414c-40f9-a7dd-6d2546806b78"), true, "//div[contains(@class, 'PageArticleContent_authors')]//a[contains(@class, 'LinksOfAuthor_item')]/text()", new Guid("fb266c0a-9568-4318-b758-842365edd093") },
                    { new Guid("25a5ab8a-f8b2-4e65-8764-340b063abcab"), false, "//div[@class='topic-authors']/a[@class='topic-authors__author']/text()", new Guid("9bcf4c31-2bf4-48d9-beed-52ff2ac43c66") },
                    { new Guid("40babe88-5aa3-47fd-a749-228c0d4b18d0"), true, "//article//header//div[@class='article-head__author-name']/a[@rel='author']/span/text()", new Guid("e87bdd7f-426c-49ca-8df2-169eb373fb47") },
                    { new Guid("59bcec75-75b6-4211-b4ec-6e0518273efb"), true, "//span[@itemprop='author']/span[@itemprop='name']/@content", new Guid("9ed4e3a8-dafe-4563-bbc9-d3451637e914") },
                    { new Guid("5a2967d0-35d7-48a5-9801-d0689acab853"), true, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']//a[@itemprop='author']//span[@itemprop='name']/text()", new Guid("7c5ba28d-b7e6-4b9a-8c90-b8dabe4aa3a2") },
                    { new Guid("68ca459e-06ea-4d7a-8d56-a5c433273b3b"), true, "//div[contains(@class, 'full-article')]/div[@class='authors-block']//span[text()='Автор']/../a/text()", new Guid("40d53873-b083-4f13-bc77-a75f0d3cae96") },
                    { new Guid("8aaddc9c-0e7d-42f8-9285-52f64bd020a6"), true, "//div[contains(@class, 'styles_bodyWrapper')]//div[contains(@class, 'styles_authorsLinks')]/a/text()", new Guid("82dc0bd2-5b87-4ba8-861c-9868ad3598fa") },
                    { new Guid("a10386c6-d7a1-43eb-b7d8-ca71281c3a72"), false, "//div[@class='author']/span[@itemprop='author']/span[@itemprop='name']/a/text()", new Guid("d798add7-1159-43d2-9202-fdda15631bc9") },
                    { new Guid("b1c3ec64-4d7a-4124-84be-6b6fb60a4f35"), true, "//div[@itemprop='author']/span[@itemprop='name']/text()", new Guid("e1b7ca70-76bc-439f-8e0d-947b3140d8d4") },
                    { new Guid("cb45cc01-d584-4ac7-9a51-0354c09bc311"), false, "//div[@class='article__authors']//*[@class='article__authors__author']/span[@class='article__authors__author__name']/text()", new Guid("5433db97-3772-4c02-8470-bbae58b3d4cd") },
                    { new Guid("ce613413-850b-4e7c-bc5a-dee35ce6fb27"), true, "//footer[@class='news-item__footer']/div[@class='news-item__footer-after-news']/p[position()=1]//span/text()", new Guid("5e602853-5b66-4e9d-b39e-42c9d87cdd9e") },
                    { new Guid("db805481-239d-4b89-9106-bb1dcc59fa13"), false, "//p[@class='doc__text document_authors']/text()", new Guid("3b6c32e4-c53f-4865-b291-c3f8d505e069") },
                    { new Guid("e7a79e52-6cc9-41a6-a64f-67639aba6f5c"), true, "//a[@class='article__author']/text()", new Guid("0705dc0c-b029-4f15-ae9c-381de1b30d35") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_picture_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("109dc337-55a5-4e01-87b2-d86bb0547be0"), false, new Guid("8f03d496-b03c-4fd4-863d-b7bdaf240d04"), "//div[contains(@class, 'HeaderMedia_image')]//img[contains(@class, 'Image_image')]/@src" },
                    { new Guid("2247ea4d-5443-4d43-a1c3-796725a95397"), true, new Guid("263b754f-cc1f-406c-80c6-55cce11c8cc0"), "//div[contains(@class, 'big_photo')]//div[@class='big_photo__img']//img/@src" },
                    { new Guid("235a99fa-0135-4184-9323-fda8b3547c48"), false, new Guid("40d53873-b083-4f13-bc77-a75f0d3cae96"), "//div[contains(@class, 'full-article')]/div[contains(@class, 'gallery')]/picture/img/@src" },
                    { new Guid("2989adb1-f57a-4976-ad44-ec071bc2c380"), true, new Guid("e1b7ca70-76bc-439f-8e0d-947b3140d8d4"), "//div[@itemprop='articleBody']//div[@itemprop='image']/picture/img[@itemprop='contentUrl']/@src" },
                    { new Guid("3a3ce7b8-77d4-4def-86a6-ef3790abe2b0"), false, new Guid("839988ce-8120-4f17-a54d-fb00438ac53d"), "//div[@class='b-material-incut-m-image']//@src" },
                    { new Guid("6980c925-0359-4a29-972a-112e669d5131"), false, new Guid("7c5ba28d-b7e6-4b9a-8c90-b8dabe4aa3a2"), "//div[contains(@class, 'article-entry')]//div[contains(@class, 'entry-body')]//div[@class='source-wrapper']/img[@itemprop='image']/@src" },
                    { new Guid("72481736-d9ab-4772-9627-f3893df7853a"), false, new Guid("d798add7-1159-43d2-9202-fdda15631bc9"), "//div[@class='b_article-media']//div[@class='mainarea-wrapper']/figure/img[@class='item-image-front']/@src" },
                    { new Guid("784eaebf-c1e6-4c54-b136-8f2c199e9f67"), false, new Guid("1f436ed2-b03c-4a7f-90ee-7de243eac143"), "//div[@class='photoview__open']/img/@src" },
                    { new Guid("7907e42b-715a-47f7-bcd8-5fde8c0b2303"), false, new Guid("e87bdd7f-426c-49ca-8df2-169eb373fb47"), "//article//header/div[@class='article-head__photo']/img/@src" },
                    { new Guid("9201d848-d5e6-404b-a94b-7a341acaf1ce"), false, new Guid("db46e84f-3232-48e2-bf7e-15e5fbfd4f2c"), "//article/figure/img/@src" },
                    { new Guid("9a31f369-0144-4ea6-a75f-76853a858cda"), false, new Guid("9bcf4c31-2bf4-48d9-beed-52ff2ac43c66"), "//div[contains(@class, 'topic-body__title-image')]//img[contains(@class, 'picture__image')]/@src" },
                    { new Guid("a9245da7-fc20-479d-9a41-b066141e0ef5"), true, new Guid("0705dc0c-b029-4f15-ae9c-381de1b30d35"), "//div[@class='article__media']//img/@src" },
                    { new Guid("af385167-143d-4b6d-a06b-ace2a3b2f0d2"), false, new Guid("8165c08a-1969-4619-826d-9db884ee709b"), "//div[@class='inner_content']//div[@class='main_img']//img/@src" },
                    { new Guid("c37f7e11-056e-437c-a282-56edd472f29a"), true, new Guid("c48ffab0-ef25-49cb-98bc-0317e0b48a7f"), "//a[@class='glightbox']/img[contains(@class, 'pub-cover')]/@src" },
                    { new Guid("d4cc8d74-434a-4b58-aea6-27e73d7cc688"), false, new Guid("82dc0bd2-5b87-4ba8-861c-9868ad3598fa"), "//article//header/div[contains(@class, 'styles_cover_media')]/img/@src" },
                    { new Guid("e5c1fcfd-3d35-4989-a129-c288b69efdf9"), false, new Guid("8d7391a7-5e85-4681-bad8-38d183d1879b"), "//div[@class='img_box']/a[@class='zoom_js']/img/@src" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "published_at_culture_info", "published_at_time_zone_info_id", "published_at_x_path" },
                values: new object[,]
                {
                    { new Guid("1348288a-1f69-4aa5-9e98-6edbb5530aba"), true, new Guid("8d7391a7-5e85-4681-bad8-38d183d1879b"), "ru-RU", "Russian Standard Time", "//div[@class='article_top']//div[@class='date']//time/text()" },
                    { new Guid("207d93a1-9b59-4f2c-bbc8-184c684f7e64"), true, new Guid("7c5ba28d-b7e6-4b9a-8c90-b8dabe4aa3a2"), "ru-RU", null, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']/span[@itemprop='datePublished']/@content" },
                    { new Guid("2815d8cd-248f-479e-b552-b0e9da131f69"), true, new Guid("5e602853-5b66-4e9d-b39e-42c9d87cdd9e"), "ru-RU", null, "//header[@class='news-item__header']//time/@content" },
                    { new Guid("2af17174-b1c8-4784-a7b8-09680162e730"), true, new Guid("8165c08a-1969-4619-826d-9db884ee709b"), "ru-RU", "Russian Standard Time", "//div[@class='date_full']/text()" },
                    { new Guid("2d743d4b-e5e8-47c0-aaeb-4ea9729ce944"), true, new Guid("40d53873-b083-4f13-bc77-a75f0d3cae96"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'full-article')]//time/text()" },
                    { new Guid("3442d039-1560-45eb-8caa-9f40fe82e8c3"), true, new Guid("263b754f-cc1f-406c-80c6-55cce11c8cc0"), "ru-RU", null, "//div[@class='article_page__left__top__left']//div[@class='article_page__left__top__time']//time/@datetime" },
                    { new Guid("405c9671-a221-4747-a952-14a65066fa72"), true, new Guid("5433db97-3772-4c02-8470-bbae58b3d4cd"), "ru-RU", null, "//div[@class='article__header__info-block']/time[@class='article__header__date']/@datetime" },
                    { new Guid("40cb5a8e-449e-4b58-8382-3e91f8401b26"), true, new Guid("82dc0bd2-5b87-4ba8-861c-9868ad3598fa"), "ru-RU", "UTC", "//article//header//div[contains(@class, 'styles_meta')]//div[contains(@class, 'styles_metaItem')]/text()" },
                    { new Guid("525c33da-458a-47c8-b2e6-465512ebe92f"), true, new Guid("e87bdd7f-426c-49ca-8df2-169eb373fb47"), "ru-RU", "Russian Standard Time", "//article//header//time[@class='article-head__date']/text()" },
                    { new Guid("547206cf-506b-4622-8ad5-1dd98b1b00cc"), true, new Guid("c48ffab0-ef25-49cb-98bc-0317e0b48a7f"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'publication-footer')]//div[contains(@class, 'pubdatetime')]//div[contains(@class, 'badge-time')]/text()" },
                    { new Guid("6386f0e3-ef95-4f5d-9e4a-8e25ff2ebcab"), true, new Guid("9ed4e3a8-dafe-4563-bbc9-d3451637e914"), "ru-RU", "Russian Standard Time", "//div[@class='b-article__top-author']/p[@class='date']/text()" },
                    { new Guid("7602ed31-1780-424c-b6f7-8151d488570d"), true, new Guid("3b6c32e4-c53f-4865-b291-c3f8d505e069"), "ru-RU", null, "//div[@class='doc_header__time']/time[@class='doc_header__publish_time']/@datetime" },
                    { new Guid("792fb15b-11c4-462c-88f7-e064419f890d"), true, new Guid("e1b7ca70-76bc-439f-8e0d-947b3140d8d4"), "ru-RU", null, "//div[@class='publication-info']/time[@itemprop='datePublished']/@datetime" },
                    { new Guid("9d0b278d-bdfe-4454-86ea-c9ec5e874fd1"), true, new Guid("fb266c0a-9568-4318-b758-842365edd093"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'PageArticleContent_date')]/text()" },
                    { new Guid("a667d45e-fe82-4f6f-93c9-7978f38a1b2a"), true, new Guid("7a1777ad-4f46-4c4f-ad23-4c3c1a3fe6dc"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'article__date-autor-shortcode')]/div[contains(@class, 'article__date')]/time[@class='date']/@datetime" },
                    { new Guid("a85f7361-17f5-401d-9fe1-bc9c1c448906"), true, new Guid("d4fb8626-e133-41ff-820d-f992ec68b395"), "ru-RU", "Russian Standard Time", "//div[@class='b-text__date']/text()" },
                    { new Guid("a9280717-3102-4d5b-9265-31061a83cb66"), true, new Guid("839988ce-8120-4f17-a54d-fb00438ac53d"), "ru-RU", "Russian Standard Time", "//p[@class='b-material__date']/text()" },
                    { new Guid("b36e5663-e4fd-4e38-b647-b39ab84fd787"), true, new Guid("9bcf4c31-2bf4-48d9-beed-52ff2ac43c66"), "ru-RU", "Russian Standard Time", "//div[@class='topic-page__header']//a[contains(@class, 'topic-header__time')]/text()" },
                    { new Guid("d4bdd0c3-f7a6-4a9e-a2f4-a4a8c805fb20"), true, new Guid("d798add7-1159-43d2-9202-fdda15631bc9"), "ru-RU", null, "//article/div[@class='b_article-header']//time[@itemprop='datePublished']/@datetime" },
                    { new Guid("d4c54bbf-3856-4644-b811-393165246686"), true, new Guid("db46e84f-3232-48e2-bf7e-15e5fbfd4f2c"), "ru-RU", "Russian Standard Time", "//article/div[@class='header']/span/text()" },
                    { new Guid("e125c505-edf1-4dde-84fb-9f03d7de70f3"), true, new Guid("bb1b121c-d92f-4add-b94f-d44d33b4cc6c"), "ru-RU", "Russian Standard Time", "//article[@itemprop='articleBody']/meta[@itemprop='datePublished']/@content" },
                    { new Guid("efb16e6a-72fb-44fe-bd96-a98b7046cad0"), true, new Guid("8f03d496-b03c-4fd4-863d-b7bdaf240d04"), "ru-RU", "UTC", "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark')]//span[@ca-ts]/text()" },
                    { new Guid("f2d7670b-30c2-48e3-b9c8-000214fbb60d"), true, new Guid("0705dc0c-b029-4f15-ae9c-381de1b30d35"), "ru-RU", "Russian Standard Time", "//div[@class='article__meta']/time/text()" },
                    { new Guid("f64ebc02-7241-4635-8080-28cd4eaf5165"), true, new Guid("1f436ed2-b03c-4a7f-90ee-7de243eac143"), "ru-RU", "Russian Standard Time", "//div[@class='article__info']//div[@class='article__info-date']/a/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_sub_title_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("0f6068cb-f892-452d-9446-98cc27932b1c"), false, new Guid("9ed4e3a8-dafe-4563-bbc9-d3451637e914"), "//h4/text()" },
                    { new Guid("2573f912-edcf-48da-bd7e-5d7643bcd485"), true, new Guid("0705dc0c-b029-4f15-ae9c-381de1b30d35"), "//div[@class='article__intro']/p/text()" },
                    { new Guid("25ac36c3-2987-4543-9e0f-29ae59c65a0b"), true, new Guid("1f436ed2-b03c-4a7f-90ee-7de243eac143"), "//h1[@class='article__second-title']/text()" },
                    { new Guid("277ba816-e3fd-46a4-9f2b-3c8493f1725d"), true, new Guid("c48ffab0-ef25-49cb-98bc-0317e0b48a7f"), "//div[@class='container-fluid shifted']/p[@class='announce lead']/text()" },
                    { new Guid("2fa24829-4940-42e8-9070-2ed83fb3b5dc"), true, new Guid("d798add7-1159-43d2-9202-fdda15631bc9"), "//h2/text()" },
                    { new Guid("475ab6ee-65b2-4bb4-a361-7023ebdf0769"), true, new Guid("40d53873-b083-4f13-bc77-a75f0d3cae96"), "//h1/text()" },
                    { new Guid("a0bbc1b2-9449-41f2-8db6-a040a94e77a8"), false, new Guid("db46e84f-3232-48e2-bf7e-15e5fbfd4f2c"), "//h4/text()" },
                    { new Guid("ac0ca8c2-6e15-468f-ae15-65d6a92df199"), true, new Guid("7c5ba28d-b7e6-4b9a-8c90-b8dabe4aa3a2"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()=1]/text()" },
                    { new Guid("af51ee2c-391b-4e03-8002-50cbd961a57e"), true, new Guid("7a1777ad-4f46-4c4f-ad23-4c3c1a3fe6dc"), "//div[contains(@class, 'article__summary')]/text()" },
                    { new Guid("b314a72d-843a-4eb2-9167-7ef787f1557c"), false, new Guid("9bcf4c31-2bf4-48d9-beed-52ff2ac43c66"), "//div[contains(@class, 'topic-body__title')]/text()" },
                    { new Guid("cd78e646-9b42-44ce-82c3-07f65607ef23"), false, new Guid("82dc0bd2-5b87-4ba8-861c-9868ad3598fa"), "//article//header//p[contains(@class, 'styles_subtitle')]/text()" },
                    { new Guid("db1c8270-376f-4902-b05b-cbac1a2c7b50"), false, new Guid("3b6c32e4-c53f-4865-b291-c3f8d505e069"), "//header[@class='doc_header']/h2[contains(@class, 'doc_header__subheader')]/text()" },
                    { new Guid("f94e3f38-ff58-481b-bc2a-1992450f4f5f"), false, new Guid("8f03d496-b03c-4fd4-863d-b7bdaf240d04"), "//h3/text()" },
                    { new Guid("faed594f-bb07-4aea-ac7f-2a1a6b7dfcd5"), false, new Guid("5433db97-3772-4c02-8470-bbae58b3d4cd"), "//div[contains(@class, 'article__text')]/div[@class='article__text__overview']/span/text()" },
                    { new Guid("faf0bc95-dd53-4a57-98c7-ffbe3929cc04"), false, new Guid("fb266c0a-9568-4318-b758-842365edd093"), "//div[contains(@class, 'PageArticleContent_lead')]/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_published_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("0abf20c9-4ea7-40cc-8d83-aafb1f3b90b1"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("d4bdd0c3-f7a6-4a9e-a2f4-a4a8c805fb20") },
                    { new Guid("0b94da0f-f8ff-4609-9fcd-8de715485d32"), "dd MMMM yyyy, HH:mm", new Guid("d4c54bbf-3856-4644-b811-393165246686") },
                    { new Guid("1a7bd74b-ec22-4a5e-ae42-97d1118251a1"), "HH:mm", new Guid("a9280717-3102-4d5b-9265-31061a83cb66") },
                    { new Guid("1dca3d8e-9503-42d1-a2a6-106eb680805d"), "dd MMMM yyyy, HH:mm", new Guid("2af17174-b1c8-4784-a7b8-09680162e730") },
                    { new Guid("2522c9fd-4fea-4715-bb21-1d705c5b0724"), "dd MMMM, HH:mm", new Guid("a9280717-3102-4d5b-9265-31061a83cb66") },
                    { new Guid("278d22ff-0eb9-46a9-91c1-207e6e70679a"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("2815d8cd-248f-479e-b552-b0e9da131f69") },
                    { new Guid("2d49b085-f24c-413b-9f70-66d24816f2be"), "dd MMMM yyyy, HH:mm", new Guid("efb16e6a-72fb-44fe-bd96-a98b7046cad0") },
                    { new Guid("34893942-8e6c-47c3-bb27-8b38a9ce8821"), "dd MMMM, HH:mm", new Guid("efb16e6a-72fb-44fe-bd96-a98b7046cad0") },
                    { new Guid("3b043d86-9683-41de-aa51-a28f7d07fe65"), "yyyy-MM-dd HH:mm:ss", new Guid("547206cf-506b-4622-8ad5-1dd98b1b00cc") },
                    { new Guid("41faa5d3-aaf1-43d5-b9ed-3f4214b0dd37"), "dd MMMM  HH:mm", new Guid("a85f7361-17f5-401d-9fe1-bc9c1c448906") },
                    { new Guid("4e1fd01e-50b8-436e-ac93-3a3b18cbca55"), "dd MMMM yyyy, HH:mm,", new Guid("efb16e6a-72fb-44fe-bd96-a98b7046cad0") },
                    { new Guid("5bce3b09-f86d-41a2-a2d2-a3ed0790034e"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("405c9671-a221-4747-a952-14a65066fa72") },
                    { new Guid("7505796e-ee04-4e6f-82c3-953aec3c3966"), "yyyy-MM-d HH:mm", new Guid("a667d45e-fe82-4f6f-93c9-7978f38a1b2a") },
                    { new Guid("7ada67e9-c62f-4706-a2f4-40b44c6ed5e9"), "dd MMMM yyyy, HH:mm МСК", new Guid("525c33da-458a-47c8-b2e6-465512ebe92f") },
                    { new Guid("7f441f4f-8439-48ea-b7ad-7a810cb01a1f"), "HH:mm", new Guid("f2d7670b-30c2-48e3-b9c8-000214fbb60d") },
                    { new Guid("815060f7-4c78-41d3-88c2-169d6bda7d45"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("7602ed31-1780-424c-b6f7-8151d488570d") },
                    { new Guid("9517aeb4-1c6d-43f9-a13e-37c188fe08df"), "dd MMMM, HH:mm", new Guid("40cb5a8e-449e-4b58-8382-3e91f8401b26") },
                    { new Guid("9d9f29e1-360a-4a6d-8a52-5f67762e2d5e"), "dd MMMM, HH:mm,", new Guid("efb16e6a-72fb-44fe-bd96-a98b7046cad0") },
                    { new Guid("a5e504bc-5d0f-40a7-af08-1803cabef157"), "yyyy-MM-ddTHH:mm:ss", new Guid("e125c505-edf1-4dde-84fb-9f03d7de70f3") },
                    { new Guid("ab9739a0-8381-4b76-b6b1-cd696b93e308"), "dd MMMM yyyy HH:mm", new Guid("f2d7670b-30c2-48e3-b9c8-000214fbb60d") },
                    { new Guid("ae9c1d57-f4df-4734-9844-9f52ec710da4"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("207d93a1-9b59-4f2c-bbc8-184c684f7e64") },
                    { new Guid("b1a7c61b-a3b7-436a-a85f-cb7774b5067a"), "dd.MM.yyyy HH:mm", new Guid("2d743d4b-e5e8-47c0-aaeb-4ea9729ce944") },
                    { new Guid("b92b1fb6-6afd-4b27-bddd-1d46e7cd6cd3"), "dd.MM.yyyy HH:mm", new Guid("9d0b278d-bdfe-4454-86ea-c9ec5e874fd1") },
                    { new Guid("bda544ed-3e63-4812-b5e7-6dc9acad38d3"), "HH:mm, dd MMMM yyyy", new Guid("b36e5663-e4fd-4e38-b647-b39ab84fd787") },
                    { new Guid("c6f766fc-ec52-4545-822c-a1f1bc268c0e"), "dd MMMM yyyy в HH:mm", new Guid("6386f0e3-ef95-4f5d-9e4a-8e25ff2ebcab") },
                    { new Guid("cfcfcf1b-8e25-48df-a59c-523f1ea965ee"), "HH:mm dd.MM.yyyy", new Guid("f64ebc02-7241-4635-8080-28cd4eaf5165") },
                    { new Guid("d94ca145-7c82-44f1-9ea3-7b694b04c371"), "dd.MM.yyyy HH:mm", new Guid("1348288a-1f69-4aa5-9e98-6edbb5530aba") },
                    { new Guid("e25bb4f2-4643-44b0-bc2c-e89b9df3044d"), "dd MMMM yyyy, HH:mm", new Guid("40cb5a8e-449e-4b58-8382-3e91f8401b26") },
                    { new Guid("ed2f74c8-5dd1-475e-8020-89122a33e2ef"), "dd MMMM yyyy HH:mm", new Guid("a85f7361-17f5-401d-9fe1-bc9c1c448906") },
                    { new Guid("efd11bc6-1fa4-427f-82db-6dc58197d44f"), "dd MMMM yyyy, HH:mm", new Guid("a9280717-3102-4d5b-9265-31061a83cb66") },
                    { new Guid("f15911b1-4bc3-46c7-bc2a-e2a1f6a37aa3"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("3442d039-1560-45eb-8caa-9f40fe82e8c3") },
                    { new Guid("f3d5f833-f6d6-4756-89f0-6153a83be17c"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("792fb15b-11c4-462c-88f7-e064419f890d") }
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
