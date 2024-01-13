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
                    { new Guid("050312cb-6cf9-4766-9263-75f95938f9c7"), "https://russian.rt.com/", "RT на русском" },
                    { new Guid("0ea145fe-a0f4-46a7-8597-068cb95fb2ff"), "https://ixbt.games/", "iXBT.games" },
                    { new Guid("4997217c-f159-4668-a9fd-6697678db1b6"), "https://www.kommersant.ru/", "Коммерсантъ" },
                    { new Guid("529ccea7-cf42-40d8-af84-f93a2c440c89"), "https://www.rbc.ru/", "РБК" },
                    { new Guid("683431f7-d3c1-40b8-ac66-80c74fd4e9ca"), "https://ria.ru/", "РИА Новости" },
                    { new Guid("8ecad013-10ce-4882-9e6b-af68fc6f95fd"), "https://iz.ru/", "Известия" },
                    { new Guid("93767cbd-51aa-46af-8249-f4fddef79f37"), "https://rg.ru/", "Российская газета" },
                    { new Guid("a81b52eb-f01c-414e-9a8a-3fbf0fcdc853"), "https://tsargrad.tv/", "Царьград" },
                    { new Guid("aa6ef9e9-4cd4-41e3-97a9-a1f9a1de84ca"), "https://www.sports.ru/", "Storts.ru" },
                    { new Guid("cc3b0b2b-5c7d-431b-b04e-c8dc57523fe8"), "https://tass.ru/", "ТАСС" },
                    { new Guid("d962b87b-7ac0-4914-a777-36eb06c018e3"), "https://lenta.ru/", "Лента.Ру" },
                    { new Guid("e4dd54b4-d89f-4c24-bcfd-efa9915b5e49"), "https://aif.ru/", "Аргументы и факты" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_settings",
                columns: new[] { "id", "description_x_path", "source_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("1383be44-578c-43ac-86dd-719a41b944d8"), "//div[@class='container-fluid shifted']/p[@class='announce lead']", new Guid("0ea145fe-a0f4-46a7-8597-068cb95fb2ff"), "//h1/text()" },
                    { new Guid("1c56c345-d6b1-460d-8ebf-292fd4e61deb"), "//article", new Guid("cc3b0b2b-5c7d-431b-b04e-c8dc57523fe8"), "//h1/text()" },
                    { new Guid("26b9f458-5202-42c9-8570-ec7a1ec55435"), "//div[contains(@class, 'article__body')]", new Guid("683431f7-d3c1-40b8-ac66-80c74fd4e9ca"), "//div[@class='article__title']/text()" },
                    { new Guid("2c508167-057b-4126-91db-e9445cb66586"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]", new Guid("4997217c-f159-4668-a9fd-6697678db1b6"), "//h1/text()" },
                    { new Guid("631aa164-b1af-4d1d-931a-6383ebce52ea"), "//div[contains(@class, 'news-item__content')]", new Guid("aa6ef9e9-4cd4-41e3-97a9-a1f9a1de84ca"), "//h1/text()" },
                    { new Guid("a2ed1566-7612-426e-bc4d-f04d3727f176"), "//div[contains(@class, 'article__text ')]", new Guid("050312cb-6cf9-4766-9263-75f95938f9c7"), "//h1/text()" },
                    { new Guid("a73e8452-fbcc-4eae-b91e-cc62f5d7d25b"), "//div[@class='article_text']", new Guid("e4dd54b4-d89f-4c24-bcfd-efa9915b5e49"), "//h1/text()" },
                    { new Guid("aac7f941-198b-4435-adc7-f0efe88c141e"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]", new Guid("a81b52eb-f01c-414e-9a8a-3fbf0fcdc853"), "//h1[@class='article__title']/text()" },
                    { new Guid("ad25c99a-4955-4c7d-a4d1-12a2ef2c2aa3"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview'))]", new Guid("529ccea7-cf42-40d8-af84-f93a2c440c89"), "//h1/text()" },
                    { new Guid("c5f2a745-6262-464c-9d53-33dfaa4c758d"), "//div[contains(@class, 'PageContentCommonStyling_text')]", new Guid("93767cbd-51aa-46af-8249-f4fddef79f37"), "//h1/text()" },
                    { new Guid("dd644e43-2d0d-4a83-a5fb-c2c51f0f7fc5"), "//div[@class='topic-body__content']", new Guid("d962b87b-7ac0-4914-a777-36eb06c018e3"), "//h1[@class='topic-body__titles']/span[@class='topic-body__title']/text()" },
                    { new Guid("decc83cf-90e4-4edc-9f4c-87e7c166d1b2"), "//div[@itemprop='articleBody']", new Guid("8ecad013-10ce-4882-9e6b-af68fc6f95fd"), "//h1/span/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_search_settings",
                columns: new[] { "id", "news_site_url", "news_url_x_path", "source_id" },
                values: new object[,]
                {
                    { new Guid("08a951b4-e4dc-42a4-8738-9050978cb009"), "https://www.sports.ru/news/", "//a[contains(@href, '.html') and not(contains(@href, '.html#comments'))]/@href", new Guid("aa6ef9e9-4cd4-41e3-97a9-a1f9a1de84ca") },
                    { new Guid("0ef7f3b0-847e-4b65-a154-31ab5a1c1010"), "https://russian.rt.com/", "//a[contains(@class, 'link') and contains(@href, 'news/')]/@href", new Guid("050312cb-6cf9-4766-9263-75f95938f9c7") },
                    { new Guid("3bfbc11a-7c34-4e18-9497-3bf5b4348039"), "https://aif.ru/", "//span[contains(@class, 'item_text__title')]/../@href", new Guid("e4dd54b4-d89f-4c24-bcfd-efa9915b5e49") },
                    { new Guid("5e65e607-ff04-46a7-b393-fd80d908fc33"), "https://www.kommersant.ru/", "//a[contains(@href, '/doc/') and contains(@href, '?from=')]/@href", new Guid("4997217c-f159-4668-a9fd-6697678db1b6") },
                    { new Guid("702e82b0-af35-448b-8ff5-b59dd8f8c348"), "https://tass.ru/", "//a[contains(@class, 'tass_pkg_link-v5WdK') and contains(substring(@href, 2), '/')]/@href", new Guid("cc3b0b2b-5c7d-431b-b04e-c8dc57523fe8") },
                    { new Guid("882694f9-6448-4331-a312-aa6920bce9ec"), "https://ixbt.games/news/", "//a[@class='card-link']/@href", new Guid("0ea145fe-a0f4-46a7-8597-068cb95fb2ff") },
                    { new Guid("887b7fd5-3f87-49b7-8ac2-6f281d17696c"), "https://iz.ru/news/", "//a[contains(@href, '?main_click')]/@href", new Guid("8ecad013-10ce-4882-9e6b-af68fc6f95fd") },
                    { new Guid("8b9569b8-5f9c-4d87-87a6-03e6c3920e4e"), "https://rg.ru/", "//a[contains(@href, '.html')]/@href", new Guid("93767cbd-51aa-46af-8249-f4fddef79f37") },
                    { new Guid("bf6f8de8-3391-4218-89a5-d462746281f4"), "https://ria.ru/", "//a[contains(@class, 'cell-list__item-link')]/@href", new Guid("683431f7-d3c1-40b8-ac66-80c74fd4e9ca") },
                    { new Guid("d7436560-769a-4f9a-8801-ed141349fc76"), "https://www.rbc.ru/", "//a[contains(@href, 'https://www.rbc.ru/') and contains(@href, '?from=')]/@href", new Guid("529ccea7-cf42-40d8-af84-f93a2c440c89") },
                    { new Guid("dbd6f650-627f-4515-b0a9-4c2167306ba7"), "https://tsargrad.tv/", "//a[contains(@class, 'news-item__link')]/@href", new Guid("a81b52eb-f01c-414e-9a8a-3fbf0fcdc853") },
                    { new Guid("ed893a75-0b38-4466-bc7a-fbc162b0bfe0"), "https://lenta.ru/", "//a[starts-with(@href, '/news/') or starts-with(@href, '/articles/')]/@href", new Guid("d962b87b-7ac0-4914-a777-36eb06c018e3") }
                });

            migrationBuilder.InsertData(
                table: "news_source_logos",
                columns: new[] { "id", "source_id", "url" },
                values: new object[] { new Guid("874033f3-210e-4f52-ae40-2a95ecc831c4"), new Guid("0ea145fe-a0f4-46a7-8597-068cb95fb2ff"), "https://sun13-2.userapi.com/s/v1/ig2/_ID-2w6Llad8ig5_987dKAfh1pyLdj7HfLHqGx9HxyDjoEDN7wxR0ZWJm5ja1Ey6UuQXaEYEBW1Zd51cpRrjSGfS.jpg?size=100x100&quality=96&crop=22,22,626,626&ava=1" });

            migrationBuilder.InsertData(
                table: "news_parse_editor_settings",
                columns: new[] { "id", "name_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("073c2e30-5414-4ab2-b170-ebae36de120c"), "//div[@class='topic-authors']/a[@class='topic-authors__author']/text()", new Guid("dd644e43-2d0d-4a83-a5fb-c2c51f0f7fc5") },
                    { new Guid("87c83431-a2e5-4b8e-8580-c1a14cca0b87"), "//p[@class='doc__text document_authors']/text()", new Guid("2c508167-057b-4126-91db-e9445cb66586") },
                    { new Guid("9b1082a8-7923-4d51-8c24-fa1fc9cf55e9"), "//div[@class='article_top']//div[@class='authors']//div[@class='autor']//span/text()", new Guid("a73e8452-fbcc-4eae-b91e-cc62f5d7d25b") },
                    { new Guid("9e1a1363-aa48-4171-b0d9-bb6806dd8960"), "//div[@class='container-fluid publication-footer']//a[contains(@class, 'text-secondary')]/@title", new Guid("1383be44-578c-43ac-86dd-719a41b944d8") },
                    { new Guid("aa7b5f99-6b05-4810-b160-076a6cb416f9"), "//div[@class='article__authors']//span[@class='article__authors__author']/span[@class='article__authors__author__name']/text()", new Guid("ad25c99a-4955-4c7d-a4d1-12a2ef2c2aa3") },
                    { new Guid("c5651680-8df9-4398-bef0-8eba705d6d68"), "//div[contains(@class, 'PageArticleContent_authors')]//a[contains(@class, 'LinksOfAuthor_item')]/text()", new Guid("c5f2a745-6262-464c-9d53-33dfaa4c758d") },
                    { new Guid("e137bb04-17b6-4619-9caf-a6eedf6cff0b"), "//footer[@class='news-item__footer']/div[@class='news-item__footer-after-news']/p[position()=1]//span/text()", new Guid("631aa164-b1af-4d1d-931a-6383ebce52ea") },
                    { new Guid("e2f95d85-74c9-46f3-a022-5102048d9343"), "//a[@class='article__author']/text()", new Guid("aac7f941-198b-4435-adc7-f0efe88c141e") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_picture_settings",
                columns: new[] { "id", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("1c75a693-3747-4e0e-a23b-704d8e518c37"), new Guid("decc83cf-90e4-4edc-9f4c-87e7c166d1b2"), "//div[contains(@class, 'big_photo')]//div[@class='big_photo__img']//img/@src" },
                    { new Guid("34078231-e122-48bf-ab2a-a82781c9eea7"), new Guid("aac7f941-198b-4435-adc7-f0efe88c141e"), "//div[@class='article__media']//img/@src" },
                    { new Guid("3aaa85b2-7af3-4049-9bf5-49b953cd8ef0"), new Guid("dd644e43-2d0d-4a83-a5fb-c2c51f0f7fc5"), "//div[contains(@class, 'topic-body__title-image')]//img[contains(@class, 'picture__image')]/@src" },
                    { new Guid("99fb8c21-b381-4bdd-984c-9da6889606ba"), new Guid("1c56c345-d6b1-460d-8ebf-292fd4e61deb"), "//div[contains(@class, 'HeaderMedia_image')]//img[contains(@class, 'Image_image')]/@src" },
                    { new Guid("b65f8965-2253-4d30-a111-3c642d7670e2"), new Guid("26b9f458-5202-42c9-8570-ec7a1ec55435"), "//div[@class='photoview__open']/img/@src" },
                    { new Guid("d9c9f714-509c-430c-8b68-58e905c1cb73"), new Guid("a73e8452-fbcc-4eae-b91e-cc62f5d7d25b"), "//div[@class='img_box']/a[@class='zoom_js']/img/@src" },
                    { new Guid("ee7d74c9-88cd-43af-b197-92fc41c0f279"), new Guid("1383be44-578c-43ac-86dd-719a41b944d8"), "//a[@class='glightbox']/img[contains(@class, 'pub-cover')]/@src" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings",
                columns: new[] { "id", "parse_settings_id", "published_at_culture_info", "published_at_format", "published_at_x_path" },
                values: new object[,]
                {
                    { new Guid("1b76216e-8dba-42f8-b479-338dbc2f7573"), new Guid("c5f2a745-6262-464c-9d53-33dfaa4c758d"), "ru-RU", "dd.MM.yyyy HH:mm", "//div[contains(@class, 'PageArticleContent_date')]/text()" },
                    { new Guid("35e8fb04-4a55-4e5c-a7aa-9eb09e471753"), new Guid("a73e8452-fbcc-4eae-b91e-cc62f5d7d25b"), "ru-RU", "dd.MM.yyyy HH:mm", "//div[@class='article_top']//div[@class='date']//time/text()" },
                    { new Guid("38dab17b-3408-4ffc-9109-f77754751676"), new Guid("a2ed1566-7612-426e-bc4d-f04d3727f176"), "ru-RU", "yyyy-MM-d HH:mm", "//div[contains(@class, 'article__date-autor-shortcode')]/div[contains(@class, 'article__date')]/time[@class='date']/@datetime" },
                    { new Guid("4cc57ed1-e6a7-48cc-aa48-4cf279abffa3"), new Guid("decc83cf-90e4-4edc-9f4c-87e7c166d1b2"), "ru-RU", "yyyy-MM-ddTHH:mm:ssZ", "//div[@class='article_page__left__top__left']//div[@class='article_page__left__top__time']//time/@datetime" },
                    { new Guid("4e4c0dad-e4d5-4e9e-a482-4477f031fbf3"), new Guid("1383be44-578c-43ac-86dd-719a41b944d8"), "ru-RU", "yyyy-MM-dd HH:mm:ss", "//div[contains(@class, 'publication-footer')]//div[contains(@class, 'pubdatetime')]//div[contains(@class, 'badge-time')]/text()" },
                    { new Guid("72b9db06-cfb9-4ae8-857a-29c0e28734cf"), new Guid("2c508167-057b-4126-91db-e9445cb66586"), "ru-RU", "yyyy-MM-ddTHH:mm:sszzz", "//div[@class='doc_header__time']/time[@class='doc_header__publish_time']/@datetime" },
                    { new Guid("74ba93b8-e695-4391-9f9d-6cf8f0012bfb"), new Guid("631aa164-b1af-4d1d-931a-6383ebce52ea"), "ru-RU", "yyyy-MM-ddTHH:mm:sszzz", "//header[@class='news-item__header']//time/@content" },
                    { new Guid("7620a563-1534-47e8-b594-717409e0038e"), new Guid("ad25c99a-4955-4c7d-a4d1-12a2ef2c2aa3"), "ru-RU", "yyyy-MM-ddTHH:mm:sszzz", "//div[@class='article__header__info-block']/time[@class='article__header__date']/@datetime" },
                    { new Guid("83d93366-761f-4048-9b16-13aeef17b533"), new Guid("26b9f458-5202-42c9-8570-ec7a1ec55435"), "ru-RU", "HH:mm dd.MM.yyyy", "//div[@class='article__info']//div[@class='article__info-date']/a/text()" },
                    { new Guid("c560a2f9-6162-4c74-a6d4-c3022be4b6b2"), new Guid("dd644e43-2d0d-4a83-a5fb-c2c51f0f7fc5"), "ru-RU", "HH:mm, d M yyyy", "//div[@class='topic-page__header']//a[contains(@class, 'topic-header__time')]/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_sub_title_settings",
                columns: new[] { "id", "parse_settings_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("187b1c95-8b78-4721-ac97-69d77ab4c9a0"), new Guid("2c508167-057b-4126-91db-e9445cb66586"), "//header[@class='doc_header']/h2[@class='doc_header__subheader']/text()" },
                    { new Guid("3ffb1649-1bcb-4716-b576-0e22a92eb9cf"), new Guid("c5f2a745-6262-464c-9d53-33dfaa4c758d"), "//div[contains(@class, 'PageArticleContent_lead')]/text()" },
                    { new Guid("8371cfb6-3fde-426d-aeeb-98fccfd6b4d6"), new Guid("1383be44-578c-43ac-86dd-719a41b944d8"), "//div[@class='container-fluid shifted']/p[@class='announce lead']/text()" },
                    { new Guid("a2e6708d-36bb-4565-8133-cdb4cd3c1524"), new Guid("a2ed1566-7612-426e-bc4d-f04d3727f176"), "//div[contains(@class, 'article__summary')]/text()" },
                    { new Guid("cae3c938-1210-48b2-963d-1f5c5efff697"), new Guid("26b9f458-5202-42c9-8570-ec7a1ec55435"), "//h1[@class='article__second-title']/text()" },
                    { new Guid("cb4b87c9-d9e8-4e31-a1c6-a513df4763f6"), new Guid("1c56c345-d6b1-460d-8ebf-292fd4e61deb"), "//h3/text()" },
                    { new Guid("ceedda9b-2a28-487d-8946-b89f8516bc78"), new Guid("aac7f941-198b-4435-adc7-f0efe88c141e"), "//div[@class='article__intro']/p/text()" },
                    { new Guid("cf89100c-d2cb-40f8-85ee-611bb9961f7b"), new Guid("dd644e43-2d0d-4a83-a5fb-c2c51f0f7fc5"), "//div[contains(@class, 'topic-body__title')]/text()" },
                    { new Guid("ec1dca90-a72e-412d-b30a-fdb99587b1ac"), new Guid("ad25c99a-4955-4c7d-a4d1-12a2ef2c2aa3"), "//div[contains(@class, 'article__text')]/div[@class='article__text__overview']/span/text()" }
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
