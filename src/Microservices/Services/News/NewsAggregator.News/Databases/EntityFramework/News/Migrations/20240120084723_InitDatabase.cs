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
                    { new Guid("00ed2c36-52d9-4942-8e58-52bcb7bc59e6"), true, "https://3dnews.ru/", "3Dnews.ru" },
                    { new Guid("1159d566-121f-443f-9b84-11afd7a4870f"), true, "https://www.pravda.ru/", "Правда.ру" },
                    { new Guid("178dfee9-b532-412c-bd0b-d43022b5dfeb"), true, "https://tass.ru/", "ТАСС" },
                    { new Guid("184afd0a-4d60-46af-af71-f8a3bb4ba280"), true, "https://iz.ru/", "Известия" },
                    { new Guid("2d8bae2c-fd99-4126-94d5-ad95df152f32"), true, "https://www.gazeta.ru/", "Газета.Ru" },
                    { new Guid("41214063-2b18-40a2-9a46-816c5d3ad561"), false, "https://tsargrad.tv/", "Царьград" },
                    { new Guid("4ad61638-312c-4c29-843c-b20be6933d30"), false, "https://ixbt.games/", "iXBT.games" },
                    { new Guid("597f02c0-4827-4078-bafa-f31e82adda09"), true, "https://svpressa.ru/", "СвободнаяПресса" },
                    { new Guid("6e8fd2b6-28c2-47e1-a105-a794b3844244"), true, "https://www.interfax.ru/", "Интерфакс" },
                    { new Guid("8f10aa6b-b493-4934-8ca8-d162a12aaeeb"), true, "https://ura.news/", "Ura.ru" },
                    { new Guid("9e36c282-f36d-4c85-a350-66a476abad57"), true, "https://lenta.ru/", "Лента.Ру" },
                    { new Guid("b0fecee0-1a86-4a26-8aa1-2cb369daea41"), true, "https://ria.ru/", "РИА Новости" },
                    { new Guid("b543c4ab-486f-4ef1-99a7-23300b8167fd"), true, "https://www.sports.ru/", "Storts.ru" },
                    { new Guid("b6a8e23c-2bf2-46ef-ab4e-63560a34f340"), true, "https://rg.ru/", "Российская газета" },
                    { new Guid("b709641e-f7cc-4f89-b490-504a280d26c0"), true, "https://www.championat.com/", "Чемпионат.com" },
                    { new Guid("ba5810ae-8f01-4c7a-9a78-4d89fb2d3393"), true, "https://www.kommersant.ru/", "Коммерсантъ" },
                    { new Guid("c2237c30-d5e2-42c1-953c-866ed76c4327"), true, "https://vz.ru/", "ВЗГЛЯД.РУ" },
                    { new Guid("c418d61c-35bc-43d5-9c72-3967fe0f3673"), true, "https://www.m24.ru/", "Москва 24" },
                    { new Guid("ccf52228-4b47-49c2-bb9c-4bfb3e0dcd0c"), true, "https://life.ru/", "Life" },
                    { new Guid("d0e6929f-dba7-4814-ae9d-87f06ac83c6b"), true, "https://www.belta.by/", "БелТА" },
                    { new Guid("d1543805-f0f8-4d0c-9fed-e66ea92e6767"), true, "https://www.ixbt.com/", "iXBT.com" },
                    { new Guid("ddbb8274-4768-44ca-829d-a0e00b3ab872"), true, "https://aif.ru/", "Аргументы и факты" },
                    { new Guid("df053819-31e3-4c35-b040-8d0c71f74c86"), true, "https://www.rbc.ru/", "РБК" },
                    { new Guid("ed28d273-2647-48c8-8128-a207cc48ab52"), true, "https://russian.rt.com/", "RT на русском" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_settings",
                columns: new[] { "id", "description_x_path", "source_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("0d274984-638c-4a77-bb2f-11a60407dfa5"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview'))]", new Guid("df053819-31e3-4c35-b040-8d0c71f74c86"), "//h1/text()" },
                    { new Guid("1ca6674e-160b-472e-8790-9aad8ad5485d"), "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]", new Guid("597f02c0-4827-4078-bafa-f31e82adda09"), "//h1[@class='b-text__title']/text()" },
                    { new Guid("1d3c557d-1039-4c0d-9b1f-94daf20f724c"), "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]", new Guid("ccf52228-4b47-49c2-bb9c-4bfb3e0dcd0c"), "//h1/text()" },
                    { new Guid("26d53dad-f531-42a8-90d2-943d63e37f38"), "//article", new Guid("178dfee9-b532-412c-bd0b-d43022b5dfeb"), "//h1/text()" },
                    { new Guid("28d94507-17df-444d-8cef-a43d9ccb7051"), "//div[@class='container-fluid shifted']/p[@class='announce lead']", new Guid("4ad61638-312c-4c29-843c-b20be6933d30"), "//h1/text()" },
                    { new Guid("336942d6-03cb-4c84-8cd1-e36bc176055a"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()>1]", new Guid("00ed2c36-52d9-4942-8e58-52bcb7bc59e6"), "//h1/text()" },
                    { new Guid("3c77cf1e-342b-4556-bdfb-d92dc1ae67a4"), "//div[@class='topic-body__content']", new Guid("9e36c282-f36d-4c85-a350-66a476abad57"), "//h1[@class='topic-body__titles']/span[@class='topic-body__title']/text()" },
                    { new Guid("42b63dbb-03df-4cc7-b806-9b6e0add6388"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]", new Guid("41214063-2b18-40a2-9a46-816c5d3ad561"), "//h1[@class='article__title']/text()" },
                    { new Guid("48470c41-befa-4b36-9a8e-9f4316f56da7"), "//div[contains(@class, 'article__body')]", new Guid("b0fecee0-1a86-4a26-8aa1-2cb369daea41"), "//div[@class='article__title']/text()" },
                    { new Guid("644de1ee-e5a1-40f8-98d5-2151332e712c"), "//div[contains(@class, 'article__text ')]", new Guid("ed28d273-2647-48c8-8128-a207cc48ab52"), "//h1/text()" },
                    { new Guid("7c8909a8-d2c1-4ff5-bf62-148191a82db8"), "//div[contains(@class, 'PageContentCommonStyling_text')]", new Guid("b6a8e23c-2bf2-46ef-ab4e-63560a34f340"), "//h1/text()" },
                    { new Guid("82fec421-80ae-4b97-bf67-087cbf24b155"), "//div[@itemprop='articleBody']", new Guid("2d8bae2c-fd99-4126-94d5-ad95df152f32"), "//h1/text()" },
                    { new Guid("97fbee8d-a94f-426c-808e-92ae39968dcb"), "//div[@itemprop='articleBody']", new Guid("184afd0a-4d60-46af-af71-f8a3bb4ba280"), "//h1/span/text()" },
                    { new Guid("9aae8d03-5b5a-4d96-ac34-15906dc789d5"), "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]", new Guid("c418d61c-35bc-43d5-9c72-3967fe0f3673"), "//h1/text()" },
                    { new Guid("a606968e-4228-4d62-8df9-0749b534927b"), "//div[@itemprop='articleBody']/*[not(name()='div')]", new Guid("8f10aa6b-b493-4934-8ca8-d162a12aaeeb"), "//h1/text()" },
                    { new Guid("c58d217c-0a09-4116-82b6-383ee16f4fcf"), "//div[@class='js-mediator-article']", new Guid("d0e6929f-dba7-4814-ae9d-87f06ac83c6b"), "//h1/text()" },
                    { new Guid("c8c27644-afe6-4bf9-90bb-f527dd7af5d8"), "//div[@class='article_text']", new Guid("ddbb8274-4768-44ca-829d-a0e00b3ab872"), "//h1/text()" },
                    { new Guid("cf46599d-4076-45b7-8139-9a862461d8dd"), "//article/div[@class='article-content']/*[not(@class)]", new Guid("b709641e-f7cc-4f89-b490-504a280d26c0"), "//article/header/div[@class='article-head__title']/text()" },
                    { new Guid("dbcf9d8c-5773-4329-97fd-9461c2516221"), "//div[contains(@class, 'news-item__content')]", new Guid("b543c4ab-486f-4ef1-99a7-23300b8167fd"), "//h1/text()" },
                    { new Guid("e5c67458-2df9-4406-904a-3dfa74ddf63e"), "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]", new Guid("6e8fd2b6-28c2-47e1-a105-a794b3844244"), "//h1/text()" },
                    { new Guid("eeaeb779-1621-41cb-a549-b80826f1b10c"), "//article/div[@class='news_text']", new Guid("c2237c30-d5e2-42c1-953c-866ed76c4327"), "//h1/text()" },
                    { new Guid("f3d5510b-aefd-486d-9f51-bf731923e50d"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]", new Guid("ba5810ae-8f01-4c7a-9a78-4d89fb2d3393"), "//h1/text()" },
                    { new Guid("fb0d0f6d-593c-49b1-8f34-bf3ecf33d671"), "//div[@itemprop='articleBody']", new Guid("d1543805-f0f8-4d0c-9fed-e66ea92e6767"), "//h1/text()" },
                    { new Guid("fe11f3a4-7ed2-4296-8528-81e9ce99aa34"), "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]", new Guid("1159d566-121f-443f-9b84-11afd7a4870f"), "//h1/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_search_settings",
                columns: new[] { "id", "news_site_url", "news_url_x_path", "source_id" },
                values: new object[,]
                {
                    { new Guid("1c5faffb-793e-4a91-9a48-55c639a83814"), "https://lenta.ru/", "//a[starts-with(@href, '/news/')]/@href", new Guid("9e36c282-f36d-4c85-a350-66a476abad57") },
                    { new Guid("1e1a167b-f96f-4d3f-8c58-6d47bd4582f8"), "https://ria.ru/", "//a[contains(@class, 'cell-list__item-link')]/@href", new Guid("b0fecee0-1a86-4a26-8aa1-2cb369daea41") },
                    { new Guid("2f8ad6e4-98d4-4409-8db6-f3c2beb7914d"), "https://svpressa.ru/all/news/", "//a[contains(@href, '/news/') and not(contains(@href, '?')) and not(starts-with(@href, '/all/news/'))]/@href", new Guid("597f02c0-4827-4078-bafa-f31e82adda09") },
                    { new Guid("351e3fbf-a81e-48d7-b31b-6be90aff3c14"), "https://tass.ru/", "//a[contains(@class, 'tass_pkg_link-v5WdK') and contains(substring(@href, 2), '/')]/@href", new Guid("178dfee9-b532-412c-bd0b-d43022b5dfeb") },
                    { new Guid("3b61c56e-9cf4-4c57-bb64-95ba8036eeb9"), "https://www.m24.ru/", "//a[contains(@href, '/news/')]/@href", new Guid("c418d61c-35bc-43d5-9c72-3967fe0f3673") },
                    { new Guid("3f426fe0-2e3e-410b-a018-57932da439b0"), "https://life.ru/s/novosti", "//a[contains(@href, '/p/')]/@href", new Guid("ccf52228-4b47-49c2-bb9c-4bfb3e0dcd0c") },
                    { new Guid("456b6dbc-fed3-4d88-b6d8-abf1b7c80eb1"), "https://www.pravda.ru/", "//a[contains(@href, '/news/') and not(@href='https://www.pravda.ru/news/')]/@href", new Guid("1159d566-121f-443f-9b84-11afd7a4870f") },
                    { new Guid("4b52af45-ed09-4b9c-881c-e7afdd7b6eab"), "https://ixbt.games/news/", "//a[@class='card-link']/@href", new Guid("4ad61638-312c-4c29-843c-b20be6933d30") },
                    { new Guid("5f46806c-8fa0-4409-8087-dc91d2b30f35"), "https://www.gazeta.ru/news/", "//a[contains(@href, '/news/') and contains(@href, '.shtml') and not(contains(@href, '?'))]/@href", new Guid("2d8bae2c-fd99-4126-94d5-ad95df152f32") },
                    { new Guid("6387fb25-b066-4682-8b89-bac08bc9f7c3"), "https://www.belta.by/", "//a[contains(@href, 'https://www.belta.by/') and contains(@href, '/view/')]/@href", new Guid("d0e6929f-dba7-4814-ae9d-87f06ac83c6b") },
                    { new Guid("64faf797-b223-42a2-adc4-c9d7e8edf110"), "https://www.ixbt.com/news/", "//a[starts-with(@href, '/news/') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("d1543805-f0f8-4d0c-9fed-e66ea92e6767") },
                    { new Guid("67dd9185-3e7e-4480-8eae-60b44ad05cd5"), "https://www.sports.ru/news/", "//a[contains(@href, '.html') and not(contains(@href, '.html#comments'))]/@href", new Guid("b543c4ab-486f-4ef1-99a7-23300b8167fd") },
                    { new Guid("72279021-1898-49a2-b498-ce9e9b273e8a"), "https://aif.ru/", "//span[contains(@class, 'item_text__title')]/../@href", new Guid("ddbb8274-4768-44ca-829d-a0e00b3ab872") },
                    { new Guid("74ce67ac-acf8-46f4-9470-f328bdfe8d50"), "https://www.kommersant.ru/", "//a[contains(@href, '/doc/') and contains(@href, '?from=')]/@href", new Guid("ba5810ae-8f01-4c7a-9a78-4d89fb2d3393") },
                    { new Guid("7965c61f-4507-41b3-a50d-aaef77452e38"), "https://vz.ru/", "//a[contains(@href, '.html') and not(contains(@href, '#comments')) and not(contains(@href, '?')) and not(contains(@href, '/about/'))]/@href", new Guid("c2237c30-d5e2-42c1-953c-866ed76c4327") },
                    { new Guid("7f1854b5-bbc3-4a3c-bae8-147a834e0b75"), "https://3dnews.ru/news/", "//div[@class='news-feed-all']//a[@class='entry-header']/h1/../@href", new Guid("00ed2c36-52d9-4942-8e58-52bcb7bc59e6") },
                    { new Guid("8692efec-4bc8-4a40-a4f1-748b4a0effbd"), "https://rg.ru/", "//a[contains(@href, '.html')]/@href", new Guid("b6a8e23c-2bf2-46ef-ab4e-63560a34f340") },
                    { new Guid("8c765a11-f3de-4662-98da-530020315967"), "https://www.rbc.ru/", "//a[contains(@href, 'https://www.rbc.ru/') and contains(@href, '?from=')]/@href", new Guid("df053819-31e3-4c35-b040-8d0c71f74c86") },
                    { new Guid("9f4bde7c-7b17-4c7f-b1d2-9044a3347604"), "https://iz.ru/news/", "//a[contains(@href, '?main_click')]/@href", new Guid("184afd0a-4d60-46af-af71-f8a3bb4ba280") },
                    { new Guid("a6b2b4e7-556a-4a8f-a22c-38d03ffd843b"), "https://www.interfax.ru/", "//div[@class='timeline']//a[@tabindex=5]/@href", new Guid("6e8fd2b6-28c2-47e1-a105-a794b3844244") },
                    { new Guid("cb5f66d5-60a8-47e5-8bbf-74992518b372"), "https://www.championat.com/news/1.html?utm_source=button&utm_medium=news", "//a[contains(@href, 'news-') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("b709641e-f7cc-4f89-b490-504a280d26c0") },
                    { new Guid("cd0e5687-9920-40cd-9274-3a997465c518"), "https://russian.rt.com/", "//a[contains(@class, 'link') and contains(@href, 'news/')]/@href", new Guid("ed28d273-2647-48c8-8128-a207cc48ab52") },
                    { new Guid("d0b1d038-e887-42ea-a6ef-32260607fa53"), "https://ura.news/", "//a[contains(@href, '/news/')]/@href", new Guid("8f10aa6b-b493-4934-8ca8-d162a12aaeeb") },
                    { new Guid("e2300ba3-20f3-4d5e-9565-ce93e8f56f7a"), "https://tsargrad.tv/", "//a[contains(@class, 'news-item__link')]/@href", new Guid("41214063-2b18-40a2-9a46-816c5d3ad561") }
                });

            migrationBuilder.InsertData(
                table: "news_source_logos",
                columns: new[] { "id", "source_id", "url" },
                values: new object[] { new Guid("cdea89d4-90f0-44d3-84ad-89cb38efcdd4"), new Guid("4ad61638-312c-4c29-843c-b20be6933d30"), "https://sun13-2.userapi.com/s/v1/ig2/_ID-2w6Llad8ig5_987dKAfh1pyLdj7HfLHqGx9HxyDjoEDN7wxR0ZWJm5ja1Ey6UuQXaEYEBW1Zd51cpRrjSGfS.jpg?size=100x100&quality=96&crop=22,22,626,626&ava=1" });

            migrationBuilder.InsertData(
                table: "news_parse_editor_settings",
                columns: new[] { "id", "is_required", "name_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("07c8fe33-c52d-4689-a3ca-e83ffbcb3749"), true, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']//a[@itemprop='author']//span[@itemprop='name']/text()", new Guid("336942d6-03cb-4c84-8cd1-e36bc176055a") },
                    { new Guid("0dbc44f0-52f1-43b0-9a01-08d807f627e7"), true, "//span[@itemprop='author']/span[@itemprop='name']/@content", new Guid("fb0d0f6d-593c-49b1-8f34-bf3ecf33d671") },
                    { new Guid("2f5456bd-d61c-4f57-8ffc-ef1259c3bbfd"), true, "//div[contains(@class, 'styles_bodyWrapper')]//div[contains(@class, 'styles_authorsLinks')]/a/text()", new Guid("1d3c557d-1039-4c0d-9b1f-94daf20f724c") },
                    { new Guid("3342da34-3443-4920-9481-8b45f821e1c3"), false, "//div[@class='author']/span[@itemprop='author']/span[@itemprop='name']/a/text()", new Guid("82fec421-80ae-4b97-bf67-087cbf24b155") },
                    { new Guid("3699bb75-3f18-4e57-acf3-d18dabbe6280"), false, "//div[@class='topic-authors']/a[@class='topic-authors__author']/text()", new Guid("3c77cf1e-342b-4556-bdfb-d92dc1ae67a4") },
                    { new Guid("48e786a2-6669-4bab-8737-07976f43f07e"), true, "//a[@class='article__author']/text()", new Guid("42b63dbb-03df-4cc7-b806-9b6e0add6388") },
                    { new Guid("78f6c48c-f253-4494-ad7b-a14f4fa9e517"), true, "//div[contains(@class, 'full-article')]/div[@class='authors-block']//span[text()='Автор']/../a/text()", new Guid("fe11f3a4-7ed2-4296-8528-81e9ce99aa34") },
                    { new Guid("7b39c12b-7d0e-4fba-8a72-865b11aa380a"), false, "//div[@class='article__authors']//span[@class='article__authors__author']/span[@class='article__authors__author__name']/text()", new Guid("0d274984-638c-4a77-bb2f-11a60407dfa5") },
                    { new Guid("7e7180c3-6e33-4554-8b27-96c327a50924"), true, "//article//header//div[@class='article-head__author-name']/a[@rel='author']/span/text()", new Guid("cf46599d-4076-45b7-8139-9a862461d8dd") },
                    { new Guid("82eb9270-75b2-4951-aa15-35fb57e6b23a"), false, "//p[@class='doc__text document_authors']/text()", new Guid("f3d5510b-aefd-486d-9f51-bf731923e50d") },
                    { new Guid("93edb377-fb80-4c1c-b2ea-ee2f522546a1"), true, "//div[@class='container-fluid publication-footer']//a[contains(@class, 'text-secondary')]/@title", new Guid("28d94507-17df-444d-8cef-a43d9ccb7051") },
                    { new Guid("a1d152cb-0ab9-499a-b836-d1049c757dbd"), true, "//div[@class='article_top']//div[@class='authors']//div[@class='autor']//span/text()", new Guid("c8c27644-afe6-4bf9-90bb-f527dd7af5d8") },
                    { new Guid("a3e73895-48f5-44bd-bdc4-9964f8bcdfb0"), true, "//div[contains(@class, 'PageArticleContent_authors')]//a[contains(@class, 'LinksOfAuthor_item')]/text()", new Guid("7c8909a8-d2c1-4ff5-bf62-148191a82db8") },
                    { new Guid("d9541377-8e24-4430-831b-f0967b8c3f4a"), true, "//footer[@class='news-item__footer']/div[@class='news-item__footer-after-news']/p[position()=1]//span/text()", new Guid("dbcf9d8c-5773-4329-97fd-9461c2516221") },
                    { new Guid("f75f340d-0274-4652-a178-4081f6dfab2a"), true, "//div[@itemprop='author']/span[@itemprop='name']/text()", new Guid("a606968e-4228-4d62-8df9-0749b534927b") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_picture_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("09aef7e5-9194-4d39-9f30-cbab7a797020"), true, new Guid("97fbee8d-a94f-426c-808e-92ae39968dcb"), "//div[contains(@class, 'big_photo')]//div[@class='big_photo__img']//img/@src" },
                    { new Guid("118f8fcf-0a3e-4df9-af3a-4c4410f68240"), false, new Guid("48470c41-befa-4b36-9a8e-9f4316f56da7"), "//div[@class='photoview__open']/img/@src" },
                    { new Guid("23edb6d2-55c2-4aaa-9255-4b84263e12b5"), false, new Guid("c8c27644-afe6-4bf9-90bb-f527dd7af5d8"), "//div[@class='img_box']/a[@class='zoom_js']/img/@src" },
                    { new Guid("279c385e-9d26-4a25-b45e-dfc2ab8cb048"), false, new Guid("cf46599d-4076-45b7-8139-9a862461d8dd"), "//article//header/div[@class='article-head__photo']/img/@src" },
                    { new Guid("31fb6285-2b98-460d-a6a7-862157754e9e"), false, new Guid("26d53dad-f531-42a8-90d2-943d63e37f38"), "//div[contains(@class, 'HeaderMedia_image')]//img[contains(@class, 'Image_image')]/@src" },
                    { new Guid("5a503d19-93e3-469a-a0b3-754fff6f4fc3"), false, new Guid("82fec421-80ae-4b97-bf67-087cbf24b155"), "//div[@class='b_article-media']//div[@class='mainarea-wrapper']/figure/img[@class='item-image-front']/@src" },
                    { new Guid("639b2ad8-b98d-4cc1-9c6a-46027a6fcbaa"), true, new Guid("42b63dbb-03df-4cc7-b806-9b6e0add6388"), "//div[@class='article__media']//img/@src" },
                    { new Guid("6436f965-d173-41ca-bcae-a2c59d4fc459"), true, new Guid("28d94507-17df-444d-8cef-a43d9ccb7051"), "//a[@class='glightbox']/img[contains(@class, 'pub-cover')]/@src" },
                    { new Guid("6f542e62-14c4-438a-aa95-d417e131db52"), false, new Guid("c58d217c-0a09-4116-82b6-383ee16f4fcf"), "//div[@class='inner_content']//div[@class='main_img']//img/@src" },
                    { new Guid("9d034d2b-fc76-4cf3-aae1-0a31817da77f"), false, new Guid("1d3c557d-1039-4c0d-9b1f-94daf20f724c"), "//article//header/div[contains(@class, 'styles_cover_media')]/img/@src" },
                    { new Guid("cf4260b5-58a1-4fe2-9053-6eeb2940ea81"), false, new Guid("3c77cf1e-342b-4556-bdfb-d92dc1ae67a4"), "//div[contains(@class, 'topic-body__title-image')]//img[contains(@class, 'picture__image')]/@src" },
                    { new Guid("d81faef8-63a8-409b-9c35-cb83a6bff9e5"), true, new Guid("a606968e-4228-4d62-8df9-0749b534927b"), "//div[@itemprop='articleBody']//div[@itemprop='image']/picture/img[@itemprop='contentUrl']/@src" },
                    { new Guid("ec38fad7-8bc3-49f7-a487-122b45dfe0de"), false, new Guid("336942d6-03cb-4c84-8cd1-e36bc176055a"), "//div[contains(@class, 'article-entry')]//div[contains(@class, 'entry-body')]//div[@class='source-wrapper']/img[@itemprop='image']/@src" },
                    { new Guid("eea02d84-4a4d-4c9a-bb9a-0cf4d013332d"), true, new Guid("9aae8d03-5b5a-4d96-ac34-15906dc789d5"), "//div[@class='b-material-incut-m-image']//@src" },
                    { new Guid("f64b7542-3b87-43b6-8b3d-52ac76fd6b3b"), false, new Guid("eeaeb779-1621-41cb-a549-b80826f1b10c"), "//article/figure/img/@src" },
                    { new Guid("f8c8e4a2-24ff-4edf-bddc-39c6492026cb"), true, new Guid("fe11f3a4-7ed2-4296-8528-81e9ce99aa34"), "//div[contains(@class, 'full-article')]/div[contains(@class, 'gallery')]/picture/img/@src" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "published_at_culture_info", "published_at_x_path" },
                values: new object[,]
                {
                    { new Guid("095b158d-86cb-4af0-96d3-1606ce363685"), true, new Guid("97fbee8d-a94f-426c-808e-92ae39968dcb"), "ru-RU", "//div[@class='article_page__left__top__left']//div[@class='article_page__left__top__time']//time/@datetime" },
                    { new Guid("1eef7ed8-eb17-4419-a09f-8bbcd5a02c50"), true, new Guid("1ca6674e-160b-472e-8790-9aad8ad5485d"), "ru-RU", "//div[@class='b-text__date']/text()" },
                    { new Guid("2329a649-4065-4ed3-a4bf-2db9e7a2d4a3"), true, new Guid("e5c67458-2df9-4406-904a-3dfa74ddf63e"), "ru-RU", "//article[@itemprop='articleBody']/meta[@itemprop='datePublished']/@content" },
                    { new Guid("23a50cd2-1937-4234-b55c-91599f7847c7"), true, new Guid("eeaeb779-1621-41cb-a549-b80826f1b10c"), "ru-RU", "//article/div[@class='header']/span/text()" },
                    { new Guid("2dccab0a-29f3-4c75-bd07-e32a1a5cc06a"), true, new Guid("f3d5510b-aefd-486d-9f51-bf731923e50d"), "ru-RU", "//div[@class='doc_header__time']/time[@class='doc_header__publish_time']/@datetime" },
                    { new Guid("30f38f8f-3c35-490c-8943-a933842f48bf"), true, new Guid("3c77cf1e-342b-4556-bdfb-d92dc1ae67a4"), "ru-RU", "//div[@class='topic-page__header']//a[contains(@class, 'topic-header__time')]/text()" },
                    { new Guid("342ed437-9adf-4f94-8e60-a209dd2978af"), true, new Guid("0d274984-638c-4a77-bb2f-11a60407dfa5"), "ru-RU", "//div[@class='article__header__info-block']/time[@class='article__header__date']/@datetime" },
                    { new Guid("349f9b54-80f5-4d70-9b30-0a2c7a25fb56"), true, new Guid("c8c27644-afe6-4bf9-90bb-f527dd7af5d8"), "ru-RU", "//div[@class='article_top']//div[@class='date']//time/text()" },
                    { new Guid("34ee2e52-28bb-4294-8a46-cb7f4a1c3a0d"), true, new Guid("fb0d0f6d-593c-49b1-8f34-bf3ecf33d671"), "ru-RU", "//div[@class='b-article__top-author']/p[@class='date']/text()" },
                    { new Guid("57daaf59-47b5-4707-bc8a-9b56c7f3127d"), true, new Guid("1d3c557d-1039-4c0d-9b1f-94daf20f724c"), "ru-RU", "//article//header//div[contains(@class, 'styles_meta')]//div[contains(@class, 'styles_metaItem')]/text()" },
                    { new Guid("58f398ac-441b-430c-9986-92923662d714"), true, new Guid("fe11f3a4-7ed2-4296-8528-81e9ce99aa34"), "ru-RU", "//div[contains(@class, 'full-article')]//time/text()" },
                    { new Guid("6d875013-4495-4d06-be0f-05fef9d036c0"), true, new Guid("7c8909a8-d2c1-4ff5-bf62-148191a82db8"), "ru-RU", "//div[contains(@class, 'PageArticleContent_date')]/text()" },
                    { new Guid("75a28766-da36-4c09-a294-af5a0db139f9"), true, new Guid("336942d6-03cb-4c84-8cd1-e36bc176055a"), "ru-RU", "//div[contains(@class, 'article-entry')]//div[@class='entry-info']/span[@itemprop='datePublished']/@content" },
                    { new Guid("7b8b874c-3c90-4f50-b9c9-993c8722dda7"), true, new Guid("dbcf9d8c-5773-4329-97fd-9461c2516221"), "ru-RU", "//header[@class='news-item__header']//time/@content" },
                    { new Guid("7ea280da-baf5-4272-a87c-c3d0b96c7f30"), true, new Guid("c58d217c-0a09-4116-82b6-383ee16f4fcf"), "ru-RU", "//div[@class='date_full']/text()" },
                    { new Guid("81c3adcd-c07d-4d2c-a965-ac0b7e174e9b"), true, new Guid("28d94507-17df-444d-8cef-a43d9ccb7051"), "ru-RU", "//div[contains(@class, 'publication-footer')]//div[contains(@class, 'pubdatetime')]//div[contains(@class, 'badge-time')]/text()" },
                    { new Guid("8bd8bd86-8219-471e-bbe8-726f62df54a8"), true, new Guid("82fec421-80ae-4b97-bf67-087cbf24b155"), "ru-RU", "//article/div[@class='b_article-header']//time[@itemprop='datePublished']/@datetime" },
                    { new Guid("95b64213-6305-45cb-a71e-2a4ffee8073d"), true, new Guid("cf46599d-4076-45b7-8139-9a862461d8dd"), "ru-RU", "//article//header//time[@class='article-head__date']/text()" },
                    { new Guid("aa83320a-287f-4ce2-b027-9141b8e9aa31"), true, new Guid("48470c41-befa-4b36-9a8e-9f4316f56da7"), "ru-RU", "//div[@class='article__info']//div[@class='article__info-date']/a/text()" },
                    { new Guid("d132f7a4-dafc-4a62-87c5-67a94668976e"), true, new Guid("a606968e-4228-4d62-8df9-0749b534927b"), "ru-RU", "//div[@class='publication-info']/time[@itemprop='datePublished']/@datetime" },
                    { new Guid("d700165d-6187-4cd8-9da3-aacf4cad1818"), true, new Guid("26d53dad-f531-42a8-90d2-943d63e37f38"), "ru-RU", "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark_publish')]//span[@ca-ts]/text()" },
                    { new Guid("e2f0e36e-1a26-4a97-8b36-4d13fa5ab339"), true, new Guid("9aae8d03-5b5a-4d96-ac34-15906dc789d5"), "ru-RU", "//p[@class='b-material__date']/text()" },
                    { new Guid("eb406d0c-601c-4d5b-b4d8-abf018ad7a07"), true, new Guid("42b63dbb-03df-4cc7-b806-9b6e0add6388"), "ru-RU", "//div[@class='article__meta']/time/text()" },
                    { new Guid("fb9b6390-430f-45a8-82cb-34a799a0c1b7"), true, new Guid("644de1ee-e5a1-40f8-98d5-2151332e712c"), "ru-RU", "//div[contains(@class, 'article__date-autor-shortcode')]/div[contains(@class, 'article__date')]/time[@class='date']/@datetime" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_sub_title_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("3c83f7b1-9720-41c7-a07c-45d1694e837e"), true, new Guid("48470c41-befa-4b36-9a8e-9f4316f56da7"), "//h1[@class='article__second-title']/text()" },
                    { new Guid("401e99c2-7898-4921-a762-011ca3678bbc"), true, new Guid("28d94507-17df-444d-8cef-a43d9ccb7051"), "//div[@class='container-fluid shifted']/p[@class='announce lead']/text()" },
                    { new Guid("459ce395-bcbf-48af-bcc9-e1008b2721a9"), false, new Guid("26d53dad-f531-42a8-90d2-943d63e37f38"), "//h3/text()" },
                    { new Guid("6dae5b94-6e46-4a36-9605-577d71db3961"), false, new Guid("7c8909a8-d2c1-4ff5-bf62-148191a82db8"), "//div[contains(@class, 'PageArticleContent_lead')]/text()" },
                    { new Guid("9499c8dd-b1be-409b-a659-fe040ffe5617"), false, new Guid("f3d5510b-aefd-486d-9f51-bf731923e50d"), "//header[@class='doc_header']/h2[contains(@class, 'doc_header__subheader')]/text()" },
                    { new Guid("9a870f08-e655-4e1f-badf-fdccedc136d1"), true, new Guid("644de1ee-e5a1-40f8-98d5-2151332e712c"), "//div[contains(@class, 'article__summary')]/text()" },
                    { new Guid("afeecaf9-903f-44ce-a11e-60fe1a1a0df4"), false, new Guid("fb0d0f6d-593c-49b1-8f34-bf3ecf33d671"), "//h4/text()" },
                    { new Guid("b8b168f7-f207-49c3-8a63-7542f945950d"), false, new Guid("1d3c557d-1039-4c0d-9b1f-94daf20f724c"), "//article//header//p[contains(@class, 'styles_subtitle')]/text()" },
                    { new Guid("c8043d0f-9b30-4c90-8f73-e5b61105d43b"), true, new Guid("fe11f3a4-7ed2-4296-8528-81e9ce99aa34"), "//h1/text()" },
                    { new Guid("df99c300-3e3c-45cf-b518-776e819ad063"), false, new Guid("0d274984-638c-4a77-bb2f-11a60407dfa5"), "//div[contains(@class, 'article__text')]/div[@class='article__text__overview']/span/text()" },
                    { new Guid("eb5342d4-06ba-493a-84e1-7a14237508f6"), true, new Guid("82fec421-80ae-4b97-bf67-087cbf24b155"), "//h2/text()" },
                    { new Guid("ef04de1a-f968-4263-be18-0e73a3cbd8d6"), true, new Guid("336942d6-03cb-4c84-8cd1-e36bc176055a"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()=1]/text()" },
                    { new Guid("ef8f18bf-c6bd-48c2-a1fa-83df1fb7913e"), true, new Guid("42b63dbb-03df-4cc7-b806-9b6e0add6388"), "//div[@class='article__intro']/p/text()" },
                    { new Guid("f365f0f2-5b0a-4457-b3b6-69fb26800bc8"), false, new Guid("3c77cf1e-342b-4556-bdfb-d92dc1ae67a4"), "//div[contains(@class, 'topic-body__title')]/text()" },
                    { new Guid("f39b2396-a833-46ac-a6da-16afbed95b26"), false, new Guid("eeaeb779-1621-41cb-a549-b80826f1b10c"), "//h4/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_published_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("028c3f8a-0354-4e47-aed0-59d170710769"), "HH:mm, dd MMMM yyyy", new Guid("30f38f8f-3c35-490c-8943-a933842f48bf") },
                    { new Guid("188fd03a-c3a2-48ce-a9e8-cf5e6628d14a"), "dd MMMM yyyy, HH:mm", new Guid("57daaf59-47b5-4707-bc8a-9b56c7f3127d") },
                    { new Guid("1ca6ad81-106f-4bd1-9d8f-673e4c9ad93f"), "dd MMMM, HH:mm", new Guid("57daaf59-47b5-4707-bc8a-9b56c7f3127d") },
                    { new Guid("1d56d7a3-30c1-4543-823f-56694e704704"), "dd MMMM yyyy в HH:mm", new Guid("34ee2e52-28bb-4294-8a46-cb7f4a1c3a0d") },
                    { new Guid("34a41d42-dd3c-4f70-a852-b42c41ef8dee"), "dd.MM.yyyy HH:mm", new Guid("58f398ac-441b-430c-9986-92923662d714") },
                    { new Guid("5047e6ba-43be-46f1-8c1e-5bc93b0381ea"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("7b8b874c-3c90-4f50-b9c9-993c8722dda7") },
                    { new Guid("60f529bf-2a7e-478b-86bb-c47bb0a581e1"), "dd MMMM yyyy, HH:mm МСК", new Guid("95b64213-6305-45cb-a71e-2a4ffee8073d") },
                    { new Guid("6c5dc801-15f1-428c-a06f-8fc944b56047"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("2dccab0a-29f3-4c75-bd07-e32a1a5cc06a") },
                    { new Guid("6d14f6a5-547a-41ba-9920-93d7557810ce"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("342ed437-9adf-4f94-8e60-a209dd2978af") },
                    { new Guid("703f2098-fb13-4289-becf-c7f9c04cd532"), "dd.MM.yyyy HH:mm", new Guid("6d875013-4495-4d06-be0f-05fef9d036c0") },
                    { new Guid("783214dd-aeb7-49ea-bb5e-44bee1c11c98"), "dd MMMM, HH:mm,", new Guid("d700165d-6187-4cd8-9da3-aacf4cad1818") },
                    { new Guid("8735325f-923e-497c-b553-e9a464c4c33e"), "dd MMMM  HH:mm", new Guid("1eef7ed8-eb17-4419-a09f-8bbcd5a02c50") },
                    { new Guid("8cbf6c91-b4d5-4865-b12b-a8673e2acb2b"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("8bd8bd86-8219-471e-bbe8-726f62df54a8") },
                    { new Guid("959a231d-fb5d-4249-8a2f-07636b281f39"), "dd MMMM, HH:mm", new Guid("e2f0e36e-1a26-4a97-8b36-4d13fa5ab339") },
                    { new Guid("acc667db-f19d-4dbd-9d33-0d2950001c33"), "dd.MM.yyyy HH:mm", new Guid("349f9b54-80f5-4d70-9b30-0a2c7a25fb56") },
                    { new Guid("ad207ff2-aeae-4792-832c-7dbb4f84a712"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("095b158d-86cb-4af0-96d3-1606ce363685") },
                    { new Guid("b1da984d-8225-4975-8087-b1e99b7d9dba"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("d132f7a4-dafc-4a62-87c5-67a94668976e") },
                    { new Guid("ba6e94be-8132-4667-98f5-0c39bc4abb65"), "yyyy-MM-d HH:mm", new Guid("fb9b6390-430f-45a8-82cb-34a799a0c1b7") },
                    { new Guid("be7db496-4c95-4d0c-bae7-af5175ec62e9"), "dd MMMM yyyy, HH:mm", new Guid("d700165d-6187-4cd8-9da3-aacf4cad1818") },
                    { new Guid("c2762ecf-1455-404d-be41-b14fcc12f574"), "yyyy-MM-dd HH:mm:ss", new Guid("81c3adcd-c07d-4d2c-a965-ac0b7e174e9b") },
                    { new Guid("c2f15be6-bc92-41f2-9243-f19618e018a1"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("75a28766-da36-4c09-a294-af5a0db139f9") },
                    { new Guid("c5dd947b-9e9f-464c-98a0-7e0848862862"), "dd MMMM, HH:mm", new Guid("d700165d-6187-4cd8-9da3-aacf4cad1818") },
                    { new Guid("cd2aec8c-6555-49bf-8279-d3e99b1879ee"), "yyyy-MM-ddTHH:mm:ss", new Guid("2329a649-4065-4ed3-a4bf-2db9e7a2d4a3") },
                    { new Guid("cec98fe7-4c12-4080-8c8f-4b7efcaaf7f2"), "dd MMMM yyyy, HH:mm", new Guid("7ea280da-baf5-4272-a87c-c3d0b96c7f30") },
                    { new Guid("e58404b4-f65c-4cfc-9cd6-2efd72b25b0d"), "dd MMMM yyyy HH:mm", new Guid("eb406d0c-601c-4d5b-b4d8-abf018ad7a07") },
                    { new Guid("ecc333b7-c20b-4843-aebe-5fad94fc2ef3"), "dd MMMM yyyy, HH:mm", new Guid("e2f0e36e-1a26-4a97-8b36-4d13fa5ab339") },
                    { new Guid("f0f96bc8-04ba-4c8c-a4b2-85bd4ed6088a"), "dd MMMM yyyy, HH:mm,", new Guid("d700165d-6187-4cd8-9da3-aacf4cad1818") },
                    { new Guid("f2b46764-1bf8-4a10-83f3-1d1f37b8cc62"), "dd MMMM yyyy, HH:mm", new Guid("23a50cd2-1937-4234-b55c-91599f7847c7") },
                    { new Guid("fb101567-1027-4371-8700-3d2471ae9e79"), "HH:mm dd.MM.yyyy", new Guid("aa83320a-287f-4ce2-b027-9141b8e9aa31") }
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
