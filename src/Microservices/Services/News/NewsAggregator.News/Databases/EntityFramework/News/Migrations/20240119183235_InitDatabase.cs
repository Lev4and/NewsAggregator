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
                    { new Guid("0666d8fe-3a01-484a-9545-f18043e2fdc7"), false, "https://www.kommersant.ru/", "Коммерсантъ" },
                    { new Guid("1621dab4-8884-47d4-9d6a-d5ed618bad9d"), false, "https://aif.ru/", "Аргументы и факты" },
                    { new Guid("1b727884-b599-46ea-9559-f5ac8df72b37"), false, "https://www.rbc.ru/", "РБК" },
                    { new Guid("1d01237e-5703-4dd4-b656-ed8d8455fca9"), false, "https://www.m24.ru/", "Москва 24" },
                    { new Guid("1dd832b4-d648-4cc1-a66d-dc4a1aeb2d3e"), false, "https://russian.rt.com/", "RT на русском" },
                    { new Guid("26b6aa23-ec5a-4c2d-82e5-df6c4281840c"), false, "https://tass.ru/", "ТАСС" },
                    { new Guid("274c593b-e765-4e43-bf3b-ad8b3fde7f22"), false, "https://vz.ru/", "ВЗГЛЯД.РУ" },
                    { new Guid("28037fc3-f074-440a-95e5-2e1ed370269e"), false, "https://ura.news/", "Ura.ru" },
                    { new Guid("29f02fb2-a812-463f-aea3-5349fa7eb20a"), false, "https://3dnews.ru/", "3Dnews.ru" },
                    { new Guid("2cedf7b3-a21e-4a44-9c39-e272ad58633e"), false, "https://www.championat.com/", "Чемпионат.com" },
                    { new Guid("315e5042-c21f-4a97-8f5a-f85353e6b843"), false, "https://www.sports.ru/", "Storts.ru" },
                    { new Guid("423fb2ef-6fbb-4dba-aa42-a3a4e56ab9bc"), false, "https://iz.ru/", "Известия" },
                    { new Guid("4281d39b-6c67-4694-8051-80c8bfb42c85"), false, "https://lenta.ru/", "Лента.Ру" },
                    { new Guid("6869b0a0-a535-4618-aced-9b2fcf4e516d"), false, "https://www.ixbt.com/", "iXBT.com" },
                    { new Guid("7bc22a9a-d7c9-4f46-9d06-9089973dc8c1"), false, "https://ria.ru/", "РИА Новости" },
                    { new Guid("8176977e-0609-4039-9817-13ebd4a594c0"), false, "https://rg.ru/", "Российская газета" },
                    { new Guid("84d97c47-99a6-4111-9105-a5b23e6e661c"), false, "https://www.interfax.ru/", "Интерфакс" },
                    { new Guid("b779773d-2ce6-43f9-87f2-a09fa52bbde8"), false, "https://ixbt.games/", "iXBT.games" },
                    { new Guid("c44824c3-3012-48ec-a41a-447a03bcd7c7"), false, "https://life.ru/", "Life" },
                    { new Guid("dababa54-577a-4781-9b5d-22e58a926c41"), false, "https://tsargrad.tv/", "Царьград" },
                    { new Guid("e0f83a79-a04e-4ea9-9d44-a5921b6ed4f4"), false, "https://www.pravda.ru/", "Правда.ру" },
                    { new Guid("e51842f9-c29b-4a8f-95e5-27d9ef08c722"), false, "https://www.belta.by/", "БелТА" },
                    { new Guid("fdbffa3f-d8a5-457b-aee2-33d98d4e994d"), false, "https://svpressa.ru/", "СвободнаяПресса" },
                    { new Guid("ffedc8a3-77db-48a4-8c2e-cab85b7695cb"), false, "https://www.gazeta.ru/", "Газета.Ru" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_settings",
                columns: new[] { "id", "description_x_path", "source_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("054410f0-c56e-4c17-b1e7-8120ad59ef8f"), "//div[contains(@class, 'PageContentCommonStyling_text')]", new Guid("8176977e-0609-4039-9817-13ebd4a594c0"), "//h1/text()" },
                    { new Guid("1ac16379-85fc-4471-91bf-4fba750b8adb"), "//div[contains(@class, 'article__text ')]", new Guid("1dd832b4-d648-4cc1-a66d-dc4a1aeb2d3e"), "//h1/text()" },
                    { new Guid("21bb13d0-526d-4219-a28d-524d20b5442f"), "//div[@class='topic-body__content']", new Guid("4281d39b-6c67-4694-8051-80c8bfb42c85"), "//h1[@class='topic-body__titles']/span[@class='topic-body__title']/text()" },
                    { new Guid("2855d318-af0b-454e-8c7b-a54e7cf9cd31"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]", new Guid("0666d8fe-3a01-484a-9545-f18043e2fdc7"), "//h1/text()" },
                    { new Guid("319b201e-1df9-4b48-b2c1-5dc939d0697d"), "//article/div[@class='article-content']/*[not(@class)]", new Guid("2cedf7b3-a21e-4a44-9c39-e272ad58633e"), "//article/header/div[@class='article-head__title']/text()" },
                    { new Guid("33bf742f-b9f9-4a0c-9be0-b4531e62d91f"), "//div[@class='container-fluid shifted']/p[@class='announce lead']", new Guid("b779773d-2ce6-43f9-87f2-a09fa52bbde8"), "//h1/text()" },
                    { new Guid("355f72fb-f68d-4703-bb7c-3cdeb3aa986d"), "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]", new Guid("1d01237e-5703-4dd4-b656-ed8d8455fca9"), "//h1/text()" },
                    { new Guid("6ace34ff-46ab-461e-beb3-32c8ea8de4ff"), "//div[@itemprop='articleBody']", new Guid("423fb2ef-6fbb-4dba-aa42-a3a4e56ab9bc"), "//h1/span/text()" },
                    { new Guid("7d54652d-72ba-4c4f-afc2-6f5e9f56f071"), "//article", new Guid("26b6aa23-ec5a-4c2d-82e5-df6c4281840c"), "//h1/text()" },
                    { new Guid("7d56b5ea-757e-4892-bbf1-f1a1e8a68df8"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()>1]", new Guid("29f02fb2-a812-463f-aea3-5349fa7eb20a"), "//h1/text()" },
                    { new Guid("7f7819b0-75f5-4306-9018-d2302d5d36da"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]", new Guid("dababa54-577a-4781-9b5d-22e58a926c41"), "//h1[@class='article__title']/text()" },
                    { new Guid("885073d1-e496-4cb1-ad62-0557e55b6b7b"), "//div[@class='js-mediator-article']", new Guid("e51842f9-c29b-4a8f-95e5-27d9ef08c722"), "//h1/text()" },
                    { new Guid("98b0648b-309b-4fc2-a612-5c9a34d67e12"), "//div[contains(@class, 'news-item__content')]", new Guid("315e5042-c21f-4a97-8f5a-f85353e6b843"), "//h1/text()" },
                    { new Guid("9bff4cd2-8967-4dd2-b8bd-4523bca2b389"), "//div[@itemprop='articleBody']", new Guid("ffedc8a3-77db-48a4-8c2e-cab85b7695cb"), "//h1/text()" },
                    { new Guid("a9427434-9305-41ff-98da-9f5c6e28cde9"), "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]", new Guid("fdbffa3f-d8a5-457b-aee2-33d98d4e994d"), "//h1[@class='b-text__title']/text()" },
                    { new Guid("b39299f9-1927-4a06-9101-a9eb44fc7d33"), "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]", new Guid("e0f83a79-a04e-4ea9-9d44-a5921b6ed4f4"), "//h1/text()" },
                    { new Guid("b3dad0c5-1a66-4b9e-91e3-bb5c1a33f6d0"), "//div[contains(@class, 'article__body')]", new Guid("7bc22a9a-d7c9-4f46-9d06-9089973dc8c1"), "//div[@class='article__title']/text()" },
                    { new Guid("b5cba261-d4c2-430e-9476-c292ca02ea15"), "//article/div[@class='news_text']", new Guid("274c593b-e765-4e43-bf3b-ad8b3fde7f22"), "//h1/text()" },
                    { new Guid("c7b1282c-ec2a-4174-80dd-d6a4a27d4443"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview'))]", new Guid("1b727884-b599-46ea-9559-f5ac8df72b37"), "//h1/text()" },
                    { new Guid("d7851c41-54a0-40df-8fb7-1dd2827a7081"), "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]", new Guid("84d97c47-99a6-4111-9105-a5b23e6e661c"), "//h1/text()" },
                    { new Guid("da8fdc18-5867-4b6a-8867-3f23a385b47d"), "//div[@itemprop='articleBody']/*[not(name()='div')]", new Guid("28037fc3-f074-440a-95e5-2e1ed370269e"), "//h1/text()" },
                    { new Guid("df5dd5db-92ab-4b6b-8245-da3fbb28f055"), "//div[@class='article_text']", new Guid("1621dab4-8884-47d4-9d6a-d5ed618bad9d"), "//h1/text()" },
                    { new Guid("ed08b073-6c6d-4f23-b6f4-319eda95e90c"), "//div[@itemprop='articleBody']", new Guid("6869b0a0-a535-4618-aced-9b2fcf4e516d"), "//h1/text()" },
                    { new Guid("ee6767cd-b93f-48ae-96d1-0745548f1211"), "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]", new Guid("c44824c3-3012-48ec-a41a-447a03bcd7c7"), "//h1/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_search_settings",
                columns: new[] { "id", "news_site_url", "news_url_x_path", "source_id" },
                values: new object[,]
                {
                    { new Guid("13e26c4a-78ca-4f15-a4f7-3551f5d52394"), "https://lenta.ru/", "//a[starts-with(@href, '/news/')]/@href", new Guid("4281d39b-6c67-4694-8051-80c8bfb42c85") },
                    { new Guid("1cc0a1f2-d80a-43b7-ae0d-78eb30f9cc1e"), "https://ria.ru/", "//a[contains(@class, 'cell-list__item-link')]/@href", new Guid("7bc22a9a-d7c9-4f46-9d06-9089973dc8c1") },
                    { new Guid("22ab0be9-df5d-403b-9138-65382b1cb628"), "https://www.rbc.ru/", "//a[contains(@href, 'https://www.rbc.ru/') and contains(@href, '?from=')]/@href", new Guid("1b727884-b599-46ea-9559-f5ac8df72b37") },
                    { new Guid("30001825-59c1-45dc-be2f-a1ca2406c4ee"), "https://ura.news/", "//a[contains(@href, '/news/')]/@href", new Guid("28037fc3-f074-440a-95e5-2e1ed370269e") },
                    { new Guid("395e4351-9f51-45fa-a190-d5c50e6059e0"), "https://www.kommersant.ru/", "//a[contains(@href, '/doc/') and contains(@href, '?from=')]/@href", new Guid("0666d8fe-3a01-484a-9545-f18043e2fdc7") },
                    { new Guid("4fba90b0-702b-470a-af7d-e2fadee476c1"), "https://www.pravda.ru/", "//a[contains(@href, '/news/') and not(@href='https://www.pravda.ru/news/')]/@href", new Guid("e0f83a79-a04e-4ea9-9d44-a5921b6ed4f4") },
                    { new Guid("54466222-9e57-4432-a758-752f24f0eec5"), "https://www.sports.ru/news/", "//a[contains(@href, '.html') and not(contains(@href, '.html#comments'))]/@href", new Guid("315e5042-c21f-4a97-8f5a-f85353e6b843") },
                    { new Guid("64021833-6e34-4bba-a314-226db8f2dfb8"), "https://www.interfax.ru/", "//div[@class='timeline']//a[@tabindex=5]/@href", new Guid("84d97c47-99a6-4111-9105-a5b23e6e661c") },
                    { new Guid("6559ea43-32c2-4150-ba24-5ebaa43f717a"), "https://svpressa.ru/all/news/", "//a[contains(@href, '/news/') and not(contains(@href, '?')) and not(starts-with(@href, '/all/news/'))]/@href", new Guid("fdbffa3f-d8a5-457b-aee2-33d98d4e994d") },
                    { new Guid("74a05ca6-10ed-4f56-9a9a-d05f17a2b768"), "https://www.gazeta.ru/news/", "//a[contains(@href, '/news/') and contains(@href, '.shtml') and not(contains(@href, '?'))]/@href", new Guid("ffedc8a3-77db-48a4-8c2e-cab85b7695cb") },
                    { new Guid("7d925f61-e600-4923-827e-a7da12b81d38"), "https://rg.ru/", "//a[contains(@href, '.html')]/@href", new Guid("8176977e-0609-4039-9817-13ebd4a594c0") },
                    { new Guid("7e497b0f-3662-4dbc-8251-1b8dcfcd9b33"), "https://russian.rt.com/", "//a[contains(@class, 'link') and contains(@href, 'news/')]/@href", new Guid("1dd832b4-d648-4cc1-a66d-dc4a1aeb2d3e") },
                    { new Guid("83d55012-160d-4996-b9fb-8a3d5401ab4f"), "https://ixbt.games/news/", "//a[@class='card-link']/@href", new Guid("b779773d-2ce6-43f9-87f2-a09fa52bbde8") },
                    { new Guid("83e2f343-4216-4544-9b49-af2568cafb34"), "https://tsargrad.tv/", "//a[contains(@class, 'news-item__link')]/@href", new Guid("dababa54-577a-4781-9b5d-22e58a926c41") },
                    { new Guid("858075c0-4b5c-42ae-82e7-a010b388f9f0"), "https://tass.ru/", "//a[contains(@class, 'tass_pkg_link-v5WdK') and contains(substring(@href, 2), '/')]/@href", new Guid("26b6aa23-ec5a-4c2d-82e5-df6c4281840c") },
                    { new Guid("9bd27d44-7afc-4b20-b5f9-6fc285dd4f75"), "https://www.m24.ru/", "//a[contains(@href, '/news/')]/@href", new Guid("1d01237e-5703-4dd4-b656-ed8d8455fca9") },
                    { new Guid("c1115288-5f2e-48c5-981b-01eea9d02e6d"), "https://www.championat.com/news/1.html?utm_source=button&utm_medium=news", "//a[contains(@href, 'news-') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("2cedf7b3-a21e-4a44-9c39-e272ad58633e") },
                    { new Guid("c6f73424-87f6-4452-b13b-7e586f3c4577"), "https://www.belta.by/", "//a[contains(@href, 'https://www.belta.by/') and contains(@href, '/view/')]/@href", new Guid("e51842f9-c29b-4a8f-95e5-27d9ef08c722") },
                    { new Guid("cea91ed3-2cba-43a2-8262-23f3c1a6e5d9"), "https://3dnews.ru/news/", "//div[@class='news-feed-all']//a[@class='entry-header']/h1/../@href", new Guid("29f02fb2-a812-463f-aea3-5349fa7eb20a") },
                    { new Guid("cee0a5b1-2640-4870-aa2b-07b7dc617181"), "https://iz.ru/news/", "//a[contains(@href, '?main_click')]/@href", new Guid("423fb2ef-6fbb-4dba-aa42-a3a4e56ab9bc") },
                    { new Guid("d2364498-2af7-408d-b0bd-607bdd820f26"), "https://aif.ru/", "//span[contains(@class, 'item_text__title')]/../@href", new Guid("1621dab4-8884-47d4-9d6a-d5ed618bad9d") },
                    { new Guid("f2550085-7e4e-47f3-b7fe-f4be74c8de10"), "https://life.ru/s/novosti", "//a[contains(@href, '/p/')]/@href", new Guid("c44824c3-3012-48ec-a41a-447a03bcd7c7") },
                    { new Guid("f2ce9828-5abb-4084-8084-270952d83103"), "https://vz.ru/", "//a[contains(@href, '.html') and not(contains(@href, '#comments')) and not(contains(@href, '?')) and not(contains(@href, '/about/'))]/@href", new Guid("274c593b-e765-4e43-bf3b-ad8b3fde7f22") },
                    { new Guid("f7dc868c-3902-48f8-9a20-b4beda389366"), "https://www.ixbt.com/news/", "//a[starts-with(@href, '/news/') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("6869b0a0-a535-4618-aced-9b2fcf4e516d") }
                });

            migrationBuilder.InsertData(
                table: "news_source_logos",
                columns: new[] { "id", "source_id", "url" },
                values: new object[] { new Guid("460bf135-7741-469c-a1d8-b31935cd4293"), new Guid("b779773d-2ce6-43f9-87f2-a09fa52bbde8"), "https://sun13-2.userapi.com/s/v1/ig2/_ID-2w6Llad8ig5_987dKAfh1pyLdj7HfLHqGx9HxyDjoEDN7wxR0ZWJm5ja1Ey6UuQXaEYEBW1Zd51cpRrjSGfS.jpg?size=100x100&quality=96&crop=22,22,626,626&ava=1" });

            migrationBuilder.InsertData(
                table: "news_parse_editor_settings",
                columns: new[] { "id", "is_required", "name_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("03155581-c7af-429f-95df-ddfb18c09ff4"), false, "//a[@class='article__author']/text()", new Guid("7f7819b0-75f5-4306-9018-d2302d5d36da") },
                    { new Guid("0a319d19-f39b-45b9-9e83-941883a5d3e6"), false, "//div[contains(@class, 'PageArticleContent_authors')]//a[contains(@class, 'LinksOfAuthor_item')]/text()", new Guid("054410f0-c56e-4c17-b1e7-8120ad59ef8f") },
                    { new Guid("399f19b8-e86f-41c4-83c5-a6c522ae682e"), false, "//article//header//div[@class='article-head__author-name']/a[@rel='author']/span/text()", new Guid("319b201e-1df9-4b48-b2c1-5dc939d0697d") },
                    { new Guid("5b15a604-dcf8-4596-a3f5-e62b9d528e96"), false, "//div[@class='container-fluid publication-footer']//a[contains(@class, 'text-secondary')]/@title", new Guid("33bf742f-b9f9-4a0c-9be0-b4531e62d91f") },
                    { new Guid("74170964-16cf-42cc-b221-15e023bcfe9f"), false, "//div[contains(@class, 'styles_bodyWrapper')]//div[contains(@class, 'styles_authorsLinks')]/a/text()", new Guid("ee6767cd-b93f-48ae-96d1-0745548f1211") },
                    { new Guid("8b95f193-ec0b-4a25-bb86-a99f5c9fe456"), false, "//div[@class='article_top']//div[@class='authors']//div[@class='autor']//span/text()", new Guid("df5dd5db-92ab-4b6b-8245-da3fbb28f055") },
                    { new Guid("8f5fb7e3-1050-4256-87f9-15023acaef86"), false, "//div[@class='article__authors']//span[@class='article__authors__author']/span[@class='article__authors__author__name']/text()", new Guid("c7b1282c-ec2a-4174-80dd-d6a4a27d4443") },
                    { new Guid("903003d5-15d2-42c8-9e8d-7a08b8897efd"), false, "//footer[@class='news-item__footer']/div[@class='news-item__footer-after-news']/p[position()=1]//span/text()", new Guid("98b0648b-309b-4fc2-a612-5c9a34d67e12") },
                    { new Guid("b6b3dcea-ac58-4760-a807-24e6741031f9"), false, "//span[@itemprop='author']/span[@itemprop='name']/@content", new Guid("ed08b073-6c6d-4f23-b6f4-319eda95e90c") },
                    { new Guid("c3479b22-2254-40cf-a2a4-1aa89931ab96"), false, "//div[@class='topic-authors']/a[@class='topic-authors__author']/text()", new Guid("21bb13d0-526d-4219-a28d-524d20b5442f") },
                    { new Guid("d15ef936-a841-4d2e-848f-15ec47fd6d5b"), false, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']//a[@itemprop='author']//span[@itemprop='name']/text()", new Guid("7d56b5ea-757e-4892-bbf1-f1a1e8a68df8") },
                    { new Guid("d1b5ec78-b614-4100-85fc-53b7a4142c69"), false, "//div[contains(@class, 'full-article')]/div[@class='authors-block']//span[text()='Автор']/../a/text()", new Guid("b39299f9-1927-4a06-9101-a9eb44fc7d33") },
                    { new Guid("d6f0986f-f8a6-4c0c-951c-651d4baedf30"), false, "//div[@class='author']/span[@itemprop='author']/span[@itemprop='name']/a/text()", new Guid("9bff4cd2-8967-4dd2-b8bd-4523bca2b389") },
                    { new Guid("e064c35c-44e4-4d7e-910e-55ce781d1635"), false, "//p[@class='doc__text document_authors']/text()", new Guid("2855d318-af0b-454e-8c7b-a54e7cf9cd31") },
                    { new Guid("e2f250c9-a7d9-40d1-abee-dc58bfdae6b4"), false, "//div[@itemprop='author']/span[@itemprop='name']/text()", new Guid("da8fdc18-5867-4b6a-8867-3f23a385b47d") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_picture_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("02f2ac17-d75e-4334-8c03-2a4eb1f0c3d2"), false, new Guid("33bf742f-b9f9-4a0c-9be0-b4531e62d91f"), "//a[@class='glightbox']/img[contains(@class, 'pub-cover')]/@src" },
                    { new Guid("1492bce5-b89d-4d6c-9fed-a4400ec88330"), false, new Guid("b5cba261-d4c2-430e-9476-c292ca02ea15"), "//article/figure/img/@src" },
                    { new Guid("19d2a7df-6ba3-4e15-9900-e2b74092bcc3"), false, new Guid("da8fdc18-5867-4b6a-8867-3f23a385b47d"), "//div[@itemprop='articleBody']//div[@itemprop='image']/picture/img[@itemprop='contentUrl']/@src" },
                    { new Guid("1ccaccf5-4572-4a32-bb0a-da31e3e78ec8"), false, new Guid("b3dad0c5-1a66-4b9e-91e3-bb5c1a33f6d0"), "//div[@class='photoview__open']/img/@src" },
                    { new Guid("24c01f1c-fc44-4051-8f73-e69a709f2691"), false, new Guid("9bff4cd2-8967-4dd2-b8bd-4523bca2b389"), "//div[@class='b_article-media']//div[@class='mainarea-wrapper']/figure/img[@class='item-image-front']/@src" },
                    { new Guid("328f80ee-64f0-49cd-9631-2faabafe7990"), false, new Guid("6ace34ff-46ab-461e-beb3-32c8ea8de4ff"), "//div[contains(@class, 'big_photo')]//div[@class='big_photo__img']//img/@src" },
                    { new Guid("383f6fa0-821e-4a12-af67-4f080db419ee"), false, new Guid("ee6767cd-b93f-48ae-96d1-0745548f1211"), "//article//header/div[contains(@class, 'styles_cover_media')]/img/@src" },
                    { new Guid("4ab52500-314c-4e4f-b217-f996c17d8dda"), false, new Guid("885073d1-e496-4cb1-ad62-0557e55b6b7b"), "//div[@class='inner_content']//div[@class='main_img']//img/@src" },
                    { new Guid("545a672f-dbf8-4b02-8f31-b8ddcc642034"), false, new Guid("7d54652d-72ba-4c4f-afc2-6f5e9f56f071"), "//div[contains(@class, 'HeaderMedia_image')]//img[contains(@class, 'Image_image')]/@src" },
                    { new Guid("6facaa5b-ab4a-40a5-bc81-c812ebe785bf"), false, new Guid("df5dd5db-92ab-4b6b-8245-da3fbb28f055"), "//div[@class='img_box']/a[@class='zoom_js']/img/@src" },
                    { new Guid("77a8a75d-5c4f-4157-b841-6f9fde5fa959"), false, new Guid("319b201e-1df9-4b48-b2c1-5dc939d0697d"), "//article//header/div[@class='article-head__photo']/img/@src" },
                    { new Guid("7cc2a8ec-3a2e-4409-94a6-3d15f0d0d809"), false, new Guid("21bb13d0-526d-4219-a28d-524d20b5442f"), "//div[contains(@class, 'topic-body__title-image')]//img[contains(@class, 'picture__image')]/@src" },
                    { new Guid("84702fd3-11d2-4b58-b59e-723ac3997d9d"), false, new Guid("b39299f9-1927-4a06-9101-a9eb44fc7d33"), "//div[contains(@class, 'full-article')]/div[contains(@class, 'gallery')]/picture/img/@src" },
                    { new Guid("b26bc651-7475-4729-acec-1a65c3ace9b8"), false, new Guid("7d56b5ea-757e-4892-bbf1-f1a1e8a68df8"), "//div[contains(@class, 'article-entry')]//div[contains(@class, 'entry-body')]//div[@class='source-wrapper']/img[@itemprop='image']/@src" },
                    { new Guid("da55894f-5373-4ee8-8e3d-999aa01b5ae6"), false, new Guid("355f72fb-f68d-4703-bb7c-3cdeb3aa986d"), "//div[@class='b-material-incut-m-image']//@src" },
                    { new Guid("fa660b7a-6a2c-486a-98b0-cd792fd7205f"), false, new Guid("7f7819b0-75f5-4306-9018-d2302d5d36da"), "//div[@class='article__media']//img/@src" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "published_at_culture_info", "published_at_format", "published_at_x_path" },
                values: new object[,]
                {
                    { new Guid("310f03b3-884a-4e78-b370-d051ca8abd63"), false, new Guid("33bf742f-b9f9-4a0c-9be0-b4531e62d91f"), "ru-RU", "yyyy-MM-dd HH:mm:ss", "//div[contains(@class, 'publication-footer')]//div[contains(@class, 'pubdatetime')]//div[contains(@class, 'badge-time')]/text()" },
                    { new Guid("3573af63-3403-4a61-a58d-069c45223ac7"), false, new Guid("054410f0-c56e-4c17-b1e7-8120ad59ef8f"), "ru-RU", "dd.MM.yyyy HH:mm", "//div[contains(@class, 'PageArticleContent_date')]/text()" },
                    { new Guid("37fe0495-0b77-42a9-8b17-5e7d66b3b9fc"), false, new Guid("da8fdc18-5867-4b6a-8867-3f23a385b47d"), "ru-RU", "yyyy-MM-ddTHH:mm:sszzz", "//div[@class='publication-info']/time[@itemprop='datePublished']/@datetime" },
                    { new Guid("508d0219-e865-4089-87dd-c5a422a2fb7f"), false, new Guid("1ac16379-85fc-4471-91bf-4fba750b8adb"), "ru-RU", "yyyy-MM-d HH:mm", "//div[contains(@class, 'article__date-autor-shortcode')]/div[contains(@class, 'article__date')]/time[@class='date']/@datetime" },
                    { new Guid("5759c1e0-1900-41c4-b992-e890fa19e1b5"), false, new Guid("9bff4cd2-8967-4dd2-b8bd-4523bca2b389"), "ru-RU", "yyyy-MM-ddTHH:mm:sszzz", "//article/div[@class='b_article-header']//time[@itemprop='datePublished']/@datetime" },
                    { new Guid("58fa3ef1-898a-4011-b336-2533195d9d6f"), false, new Guid("b5cba261-d4c2-430e-9476-c292ca02ea15"), "ru-RU", "dd MMMM yyyy, HH:mm", "//article/div[@class='header']/span/text()" },
                    { new Guid("6310c276-5ae3-4f72-a008-78ce666dbd2d"), false, new Guid("b39299f9-1927-4a06-9101-a9eb44fc7d33"), "ru-RU", "dd.MM.yyyy HH:mm", "//div[contains(@class, 'full-article')]//time/text()" },
                    { new Guid("63182784-32c7-450c-89cc-a49af99b0ade"), false, new Guid("7d56b5ea-757e-4892-bbf1-f1a1e8a68df8"), "ru-RU", "yyyy-MM-ddTHH:mm:sszzz", "//div[contains(@class, 'article-entry')]//div[@class='entry-info']/span[@itemprop='datePublished']/@content" },
                    { new Guid("6b5b23ec-4870-48a3-9295-77fcd9a3a19a"), false, new Guid("98b0648b-309b-4fc2-a612-5c9a34d67e12"), "ru-RU", "yyyy-MM-ddTHH:mm:sszzz", "//header[@class='news-item__header']//time/@content" },
                    { new Guid("74174195-fb9b-4c24-a37d-8fa0eee0681b"), false, new Guid("c7b1282c-ec2a-4174-80dd-d6a4a27d4443"), "ru-RU", "yyyy-MM-ddTHH:mm:sszzz", "//div[@class='article__header__info-block']/time[@class='article__header__date']/@datetime" },
                    { new Guid("7cd49084-a893-44fd-b8b5-22864e35dfa9"), false, new Guid("b3dad0c5-1a66-4b9e-91e3-bb5c1a33f6d0"), "ru-RU", "HH:mm dd.MM.yyyy", "//div[@class='article__info']//div[@class='article__info-date']/a/text()" },
                    { new Guid("8f93d081-e1ed-4639-91c6-51c42edff171"), false, new Guid("2855d318-af0b-454e-8c7b-a54e7cf9cd31"), "ru-RU", "yyyy-MM-ddTHH:mm:sszzz", "//div[@class='doc_header__time']/time[@class='doc_header__publish_time']/@datetime" },
                    { new Guid("99b0b8cc-d1e1-4f86-96bc-64624549e721"), false, new Guid("d7851c41-54a0-40df-8fb7-1dd2827a7081"), "ru-RU", "yyyy-MM-ddTHH:mm:ss", "//article[@itemprop='articleBody']/meta[@itemprop='datePublished']/@content" },
                    { new Guid("a292ad5c-6949-40fe-8f08-c3c112a583df"), false, new Guid("21bb13d0-526d-4219-a28d-524d20b5442f"), "ru-RU", "HH:mm, dd MMMM yyyy", "//div[@class='topic-page__header']//a[contains(@class, 'topic-header__time')]/text()" },
                    { new Guid("a50a3c6c-4209-4dd8-9222-e098a9085e4d"), false, new Guid("319b201e-1df9-4b48-b2c1-5dc939d0697d"), "ru-RU", "dd MMMM yyyy, HH:mm МСК", "//article//header//time[@class='article-head__date']/text()" },
                    { new Guid("b1e1af9b-c413-4869-a7f7-aac46f879bb3"), false, new Guid("355f72fb-f68d-4703-bb7c-3cdeb3aa986d"), "ru-RU", "HH:mm", "//p[@class='b-material__date']/text()" },
                    { new Guid("c04e1a29-25d4-4eec-b95c-9db4a65682f3"), false, new Guid("885073d1-e496-4cb1-ad62-0557e55b6b7b"), "ru-RU", "dd MMMM yyyy, HH:mm", "//div[@class='date_full']/text()" },
                    { new Guid("c23752cc-ec87-443f-9aa6-23e8db90a454"), false, new Guid("ed08b073-6c6d-4f23-b6f4-319eda95e90c"), "ru-RU", "dd MMMM yyyy в HH:mm", "//div[@class='b-article__top-author']/p[@class='date']/text()" },
                    { new Guid("d14b1caf-82b2-488c-b489-3261bd7d4cd1"), false, new Guid("6ace34ff-46ab-461e-beb3-32c8ea8de4ff"), "ru-RU", "yyyy-MM-ddTHH:mm:ssZ", "//div[@class='article_page__left__top__left']//div[@class='article_page__left__top__time']//time/@datetime" },
                    { new Guid("e87af2cb-a18f-492c-bdbd-e9410f0f28d0"), false, new Guid("df5dd5db-92ab-4b6b-8245-da3fbb28f055"), "ru-RU", "dd.MM.yyyy HH:mm", "//div[@class='article_top']//div[@class='date']//time/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_sub_title_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("01acd26d-4ee4-4a7f-a864-b1d918b01375"), false, new Guid("7d56b5ea-757e-4892-bbf1-f1a1e8a68df8"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()=1]/text()" },
                    { new Guid("25f01932-8585-4ee9-bf14-45cee19cb316"), false, new Guid("9bff4cd2-8967-4dd2-b8bd-4523bca2b389"), "//h2/text()" },
                    { new Guid("3627c6c0-070b-43ad-ba60-1af26ffe6100"), false, new Guid("ee6767cd-b93f-48ae-96d1-0745548f1211"), "//article//header//p[contains(@class, 'styles_subtitle')]/text()" },
                    { new Guid("3b23800c-709f-4d74-afc6-427463fa5db4"), false, new Guid("21bb13d0-526d-4219-a28d-524d20b5442f"), "//div[contains(@class, 'topic-body__title')]/text()" },
                    { new Guid("58126330-8f36-4122-89f0-dfd1915ffe7f"), false, new Guid("b3dad0c5-1a66-4b9e-91e3-bb5c1a33f6d0"), "//h1[@class='article__second-title']/text()" },
                    { new Guid("666dfdd0-601a-46bc-93a5-5202f87dd82b"), false, new Guid("b39299f9-1927-4a06-9101-a9eb44fc7d33"), "//h1/text()" },
                    { new Guid("6863bcda-3eec-4950-957c-3cae9ef8891c"), false, new Guid("33bf742f-b9f9-4a0c-9be0-b4531e62d91f"), "//div[@class='container-fluid shifted']/p[@class='announce lead']/text()" },
                    { new Guid("70377ef1-ced6-46b3-ae39-d1d881e67be7"), false, new Guid("b5cba261-d4c2-430e-9476-c292ca02ea15"), "//h4/text()" },
                    { new Guid("78af778c-c8dc-4864-8025-22366fd79d5e"), false, new Guid("c7b1282c-ec2a-4174-80dd-d6a4a27d4443"), "//div[contains(@class, 'article__text')]/div[@class='article__text__overview']/span/text()" },
                    { new Guid("97a80552-f544-4845-8c19-a8969123111b"), false, new Guid("7d54652d-72ba-4c4f-afc2-6f5e9f56f071"), "//h3/text()" },
                    { new Guid("9eacd2ce-797f-475e-8783-7d8a0cd3b838"), false, new Guid("054410f0-c56e-4c17-b1e7-8120ad59ef8f"), "//div[contains(@class, 'PageArticleContent_lead')]/text()" },
                    { new Guid("a1a653f4-3d2e-4215-89af-4a70a4368d0f"), false, new Guid("1ac16379-85fc-4471-91bf-4fba750b8adb"), "//div[contains(@class, 'article__summary')]/text()" },
                    { new Guid("a2456620-2035-4647-b795-82df01d35060"), false, new Guid("2855d318-af0b-454e-8c7b-a54e7cf9cd31"), "//header[@class='doc_header']/h2[contains(@class, 'doc_header__subheader')]/text()" },
                    { new Guid("b7951ac4-5e83-4f55-bef5-91b4e184e816"), false, new Guid("ed08b073-6c6d-4f23-b6f4-319eda95e90c"), "//h4/text()" },
                    { new Guid("f1f9b647-ed97-4e5d-a36c-85c8df303dbc"), false, new Guid("7f7819b0-75f5-4306-9018-d2302d5d36da"), "//div[@class='article__intro']/p/text()" }
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
