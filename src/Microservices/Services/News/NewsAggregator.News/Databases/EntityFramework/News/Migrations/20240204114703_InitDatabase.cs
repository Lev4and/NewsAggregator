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
                    { new Guid("00fe3972-5e76-4ad4-99b2-0bc188a8217d"), true, "https://www.belta.by/", "БелТА" },
                    { new Guid("03eea996-bb1b-4065-a816-91e6bfd785cd"), true, "https://www.gazeta.ru/", "Газета.Ru" },
                    { new Guid("0f2deeea-77a9-4e7b-80ce-65b209d3f218"), true, "https://life.ru/", "Life" },
                    { new Guid("15365028-80e9-4b6e-ad56-2a22aa58c706"), true, "https://3dnews.ru/", "3Dnews.ru" },
                    { new Guid("1f471d10-1256-47c5-aee2-bae488b7603c"), false, "https://tsargrad.tv/", "Царьград" },
                    { new Guid("236932a8-d37b-49b8-9f5a-b078cc0f96e2"), true, "https://ura.news/", "Ura.ru" },
                    { new Guid("30f6021e-4c33-47a8-9007-cc1a2bdc6e8e"), true, "https://russian.rt.com/", "RT на русском" },
                    { new Guid("36fea04e-fffb-4b9b-9b0a-4056de2a99f3"), true, "https://ixbt.games/", "iXBT.games" },
                    { new Guid("3c1aa3b6-bf82-47ae-aad9-7f046df1b656"), true, "https://svpressa.ru/", "СвободнаяПресса" },
                    { new Guid("3f78951d-64e5-4928-8311-4b6e05277f3f"), true, "https://ria.ru/", "РИА Новости" },
                    { new Guid("40c57819-1ebf-40eb-bbaf-861a7b6f3dbe"), true, "https://tass.ru/", "ТАСС" },
                    { new Guid("46f83d9c-17b4-48c4-9815-5e5d9ea330c1"), true, "https://www.pravda.ru/", "Правда.ру" },
                    { new Guid("4b464590-ab44-4598-b829-aeddb20dad69"), true, "https://www.kommersant.ru/", "Коммерсантъ" },
                    { new Guid("4dd33a6f-6aa5-4642-8944-42f5fedf217e"), true, "https://www.ixbt.com/", "iXBT.com" },
                    { new Guid("6e140034-9153-4963-8df8-f55bec5a8969"), true, "https://aif.ru/", "Аргументы и факты" },
                    { new Guid("76549bac-35f4-49a2-8c2d-2f83eee5b957"), true, "https://www.m24.ru/", "Москва 24" },
                    { new Guid("9958c853-4681-4375-947b-4e065769d011"), false, "https://iz.ru/", "Известия" },
                    { new Guid("9cc4ff97-bf99-4403-b857-8adb696df295"), true, "https://lenta.ru/", "Лента.Ру" },
                    { new Guid("a38feb1c-dbaa-4a1f-a266-d7fdfc6d444b"), true, "https://www.championat.com/", "Чемпионат.com" },
                    { new Guid("b03b016c-c791-4657-b8e8-1daccbd249c4"), true, "https://vz.ru/", "ВЗГЛЯД.РУ" },
                    { new Guid("b1c5544d-6db3-42c6-a4a1-7984bdf31a58"), true, "https://www.rbc.ru/", "РБК" },
                    { new Guid("e186aa2e-c5d2-470d-a1fd-313a40c8210c"), true, "https://rg.ru/", "Российская газета" },
                    { new Guid("e4ee59a5-7bc8-452a-ae28-0f25df77be91"), true, "https://www.sports.ru/", "Storts.ru" },
                    { new Guid("f85d2f33-c745-4c9f-bbfa-4e1611743585"), false, "https://www.interfax.ru/", "Интерфакс" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_settings",
                columns: new[] { "id", "description_x_path", "source_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("03f14cc8-3246-4547-9b3e-e1ac16f7a821"), "//div[@itemprop='articleBody']", new Guid("9958c853-4681-4375-947b-4e065769d011"), "//h1/span/text()" },
                    { new Guid("15d8f20c-0add-42ff-82b0-41a5db14fe4b"), "//div[contains(@class, 'news-item__content')]", new Guid("e4ee59a5-7bc8-452a-ae28-0f25df77be91"), "//h1/text()" },
                    { new Guid("26297a42-1d07-43db-96b4-f933657dae77"), "//article", new Guid("40c57819-1ebf-40eb-bbaf-861a7b6f3dbe"), "//h1/text()" },
                    { new Guid("37eff250-5741-4a51-96c6-6e576d8321ad"), "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]", new Guid("3c1aa3b6-bf82-47ae-aad9-7f046df1b656"), "//h1[@class='b-text__title']/text()" },
                    { new Guid("405eb757-9757-4633-b7fc-4511b035b0ab"), "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]", new Guid("f85d2f33-c745-4c9f-bbfa-4e1611743585"), "//h1/text()" },
                    { new Guid("43882537-2afc-430a-992b-598f0f074430"), "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]", new Guid("46f83d9c-17b4-48c4-9815-5e5d9ea330c1"), "//h1/text()" },
                    { new Guid("47eda3b6-0fa1-4f4b-adab-50ca962bfeef"), "//div[@itemprop='articleBody']", new Guid("03eea996-bb1b-4065-a816-91e6bfd785cd"), "//h1/text()" },
                    { new Guid("4ad01f6b-c1d8-41c0-aff2-f2da123bb56e"), "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]", new Guid("0f2deeea-77a9-4e7b-80ce-65b209d3f218"), "//h1/text()" },
                    { new Guid("507ef82b-fa45-4672-ad31-c7d1987ac158"), "//div[contains(@class, 'PageContentCommonStyling_text')]", new Guid("e186aa2e-c5d2-470d-a1fd-313a40c8210c"), "//h1/text()" },
                    { new Guid("5092e3eb-24ec-45db-bdc7-07e4e6ab228c"), "//div[@class='js-mediator-article']", new Guid("00fe3972-5e76-4ad4-99b2-0bc188a8217d"), "//h1/text()" },
                    { new Guid("5308b8e6-0415-4ab9-9ced-be009ebc1fe7"), "//div[contains(@class, 'article__text ')]", new Guid("30f6021e-4c33-47a8-9007-cc1a2bdc6e8e"), "//h1/text()" },
                    { new Guid("5432355d-4cec-48aa-8580-02b30dcb5f8f"), "//div[contains(@class, 'container-fluid shifted') and not(p[@class='announce lead']) and not(h1) and not(hr)]", new Guid("36fea04e-fffb-4b9b-9b0a-4056de2a99f3"), "//h1/text()" },
                    { new Guid("837496a8-0ca5-43db-a729-4c43ace71f5b"), "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]", new Guid("76549bac-35f4-49a2-8c2d-2f83eee5b957"), "//h1/text()" },
                    { new Guid("8b19e205-bfac-41d7-bf58-dcb1863f4f10"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]", new Guid("1f471d10-1256-47c5-aee2-bae488b7603c"), "//h1[@class='article__title']/text()" },
                    { new Guid("ae9e7bd7-29aa-4029-90db-22fbe8da9961"), "//div[@itemprop='articleBody']/*[not(name()='div')]", new Guid("236932a8-d37b-49b8-9f5a-b078cc0f96e2"), "//h1/text()" },
                    { new Guid("b0da9c97-c38b-4f4d-b77b-7f9bfc7b806f"), "//div[@itemprop='articleBody']", new Guid("4dd33a6f-6aa5-4642-8944-42f5fedf217e"), "//h1/text()" },
                    { new Guid("bac87346-963e-448c-9041-ee55c80e4538"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()>1]", new Guid("15365028-80e9-4b6e-ad56-2a22aa58c706"), "//h1/text()" },
                    { new Guid("c303fe12-7046-488c-806d-087a70368c3a"), "//article/div[@class='article-content']/*[not(@class)]", new Guid("a38feb1c-dbaa-4a1f-a266-d7fdfc6d444b"), "//article/header/div[@class='article-head__title']/text()" },
                    { new Guid("c6b96c11-9e98-41c8-8031-ce35aeb8352c"), "//div[@class='article_text']", new Guid("6e140034-9153-4963-8df8-f55bec5a8969"), "//h1/text()" },
                    { new Guid("da19d83e-606a-4d17-bd7a-c8868948c79c"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]", new Guid("4b464590-ab44-4598-b829-aeddb20dad69"), "//h1/text()" },
                    { new Guid("f1cd5170-ea9f-4697-aef3-b3df84ea73a6"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview'))]", new Guid("b1c5544d-6db3-42c6-a4a1-7984bdf31a58"), "//h1/text()" },
                    { new Guid("f4db655f-9b67-406a-964c-ee917a260148"), "//div[@class='topic-body__content']", new Guid("9cc4ff97-bf99-4403-b857-8adb696df295"), "//h1[@class='topic-body__titles']/span[@class='topic-body__title']/text()" },
                    { new Guid("f720910b-b9f1-4bd6-8f10-e246711b405c"), "//article/div[@class='news_text']", new Guid("b03b016c-c791-4657-b8e8-1daccbd249c4"), "//h1/text()" },
                    { new Guid("f8143847-61e3-41d3-92f5-e1faeea13c78"), "//div[contains(@class, 'article__body')]", new Guid("3f78951d-64e5-4928-8311-4b6e05277f3f"), "//div[@class='article__title']/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_search_settings",
                columns: new[] { "id", "news_site_url", "news_url_x_path", "source_id" },
                values: new object[,]
                {
                    { new Guid("13d94a54-73ef-47f0-a56e-259000fca67b"), "https://www.ixbt.com/news/", "//a[starts-with(@href, '/news/') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("4dd33a6f-6aa5-4642-8944-42f5fedf217e") },
                    { new Guid("1d763d14-a526-444d-982d-a6ad97000947"), "https://www.m24.ru/", "//a[contains(@href, '/news/')]/@href", new Guid("76549bac-35f4-49a2-8c2d-2f83eee5b957") },
                    { new Guid("3065901a-7ac8-4da3-8575-062caaef50e4"), "https://aif.ru/", "//span[contains(@class, 'item_text__title')]/../@href", new Guid("6e140034-9153-4963-8df8-f55bec5a8969") },
                    { new Guid("3991ad05-aad2-46d7-b7d7-d3f413c58ddd"), "https://www.gazeta.ru/news/", "//a[contains(@href, '/news/') and contains(@href, '.shtml') and not(contains(@href, '?'))]/@href", new Guid("03eea996-bb1b-4065-a816-91e6bfd785cd") },
                    { new Guid("4770a053-2a04-49b1-916d-baa58c9b34ba"), "https://vz.ru/", "//a[contains(@href, '.html') and not(contains(@href, '#comments')) and not(contains(@href, '?')) and not(contains(@href, '/about/'))]/@href", new Guid("b03b016c-c791-4657-b8e8-1daccbd249c4") },
                    { new Guid("5c5c085f-617e-4a23-833f-facd6b46916e"), "https://www.championat.com/news/1.html?utm_source=button&utm_medium=news", "//a[contains(@href, 'news-') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("a38feb1c-dbaa-4a1f-a266-d7fdfc6d444b") },
                    { new Guid("67e35a2c-c853-4009-9ebd-15cd64c3d72b"), "https://rg.ru/", "//a[contains(@href, '.html')]/@href", new Guid("e186aa2e-c5d2-470d-a1fd-313a40c8210c") },
                    { new Guid("7935ab2b-cfb9-4985-a0fa-2bafb1756691"), "https://3dnews.ru/news/", "//div[@class='news-feed-all']//a[@class='entry-header']/h1/../@href", new Guid("15365028-80e9-4b6e-ad56-2a22aa58c706") },
                    { new Guid("8877e888-17be-43b5-bbb7-1e2483fb7424"), "https://tass.ru/", "//a[contains(@class, 'tass_pkg_link-v5WdK') and contains(substring(@href, 2), '/') and not(contains(@href, '/spec/')) and not(contains(@href, 'spec.tass.ru'))]/@href", new Guid("40c57819-1ebf-40eb-bbaf-861a7b6f3dbe") },
                    { new Guid("892c6b49-495f-4528-abb6-a443328eda72"), "https://ria.ru/", "//a[contains(@class, 'cell-list__item-link')]/@href", new Guid("3f78951d-64e5-4928-8311-4b6e05277f3f") },
                    { new Guid("9067801c-322f-4506-8a9a-9d93673f7645"), "https://svpressa.ru/all/news/", "//a[contains(@href, '/news/') and not(contains(@href, '?')) and not(starts-with(@href, '/all/news/'))]/@href", new Guid("3c1aa3b6-bf82-47ae-aad9-7f046df1b656") },
                    { new Guid("a72004af-fe9e-43d2-9894-b35a67a2b25a"), "https://www.kommersant.ru/", "//a[contains(@href, '/doc/') and contains(@href, '?from=')]/@href", new Guid("4b464590-ab44-4598-b829-aeddb20dad69") },
                    { new Guid("aa557800-92db-4c4e-96fd-9bc001e9896d"), "https://ura.news/", "//a[contains(@href, '/news/')]/@href", new Guid("236932a8-d37b-49b8-9f5a-b078cc0f96e2") },
                    { new Guid("b29099c2-2dbc-45cf-ba3b-51c306cb1775"), "https://www.rbc.ru/", "//a[contains(@href, 'https://www.rbc.ru/') and contains(@href, '?from=')]/@href", new Guid("b1c5544d-6db3-42c6-a4a1-7984bdf31a58") },
                    { new Guid("b3d701fa-247a-4884-905d-e55cd6fd9f69"), "https://tsargrad.tv/", "//a[contains(@class, 'news-item__link')]/@href", new Guid("1f471d10-1256-47c5-aee2-bae488b7603c") },
                    { new Guid("bc636c39-aa67-4376-935b-3e316a0cf36c"), "https://russian.rt.com/", "//a[contains(@class, 'link') and contains(@href, 'news/')]/@href", new Guid("30f6021e-4c33-47a8-9007-cc1a2bdc6e8e") },
                    { new Guid("d2159872-34e9-4755-b470-af5121ad35b8"), "https://life.ru/s/novosti", "//a[contains(@href, '/p/')]/@href", new Guid("0f2deeea-77a9-4e7b-80ce-65b209d3f218") },
                    { new Guid("d319b82f-43fe-4e1e-bb92-f35b17673283"), "https://www.pravda.ru/", "//a[contains(@href, '/news/') and not(@href='https://www.pravda.ru/news/')]/@href", new Guid("46f83d9c-17b4-48c4-9815-5e5d9ea330c1") },
                    { new Guid("db3bde63-444e-42a9-b9c4-b6f73c756495"), "https://lenta.ru/", "//a[starts-with(@href, '/news/')]/@href", new Guid("9cc4ff97-bf99-4403-b857-8adb696df295") },
                    { new Guid("dcbfabdc-8fc6-4507-95fa-4bc5213ce7ee"), "https://www.interfax.ru/", "//div[@class='timeline']//a[@tabindex=5]/@href", new Guid("f85d2f33-c745-4c9f-bbfa-4e1611743585") },
                    { new Guid("eb34f329-def7-4636-b68b-e09ea58589a8"), "https://ixbt.games/news/", "//a[@class='card-link']/@href", new Guid("36fea04e-fffb-4b9b-9b0a-4056de2a99f3") },
                    { new Guid("eecefe7b-85aa-45a4-9a61-97aacec59139"), "https://iz.ru/news/", "//a[contains(@href, '?main_click')]/@href", new Guid("9958c853-4681-4375-947b-4e065769d011") },
                    { new Guid("f3481627-9238-4ce5-9358-95a696e7578d"), "https://www.belta.by/", "//a[contains(@href, 'https://www.belta.by/') and contains(@href, '/view/')]/@href", new Guid("00fe3972-5e76-4ad4-99b2-0bc188a8217d") },
                    { new Guid("fa7a2484-84bf-46b9-a877-ec29d0da89b9"), "https://www.sports.ru/news/", "//a[contains(@href, '.html') and not(contains(@href, '.html#comments'))]/@href", new Guid("e4ee59a5-7bc8-452a-ae28-0f25df77be91") }
                });

            migrationBuilder.InsertData(
                table: "news_source_logos",
                columns: new[] { "id", "source_id", "url" },
                values: new object[,]
                {
                    { new Guid("0354ec52-14e5-49be-a3dc-61576eec194d"), new Guid("9958c853-4681-4375-947b-4e065769d011"), "https://cdn.iz.ru/profiles/portal/themes/purple/images/favicons/apple-icon-120x120.png" },
                    { new Guid("0399cad9-0b65-4e23-aa71-a1eb83395840"), new Guid("3c1aa3b6-bf82-47ae-aad9-7f046df1b656"), "https://svpressa.ru/favicon-96x96.png?v=1471426270000" },
                    { new Guid("05fd4ff3-649f-4d2e-b06b-a1dc8d2fa38d"), new Guid("b1c5544d-6db3-42c6-a4a1-7984bdf31a58"), "https://s.rbk.ru/v10_rbcnews_static/common/common-10.10.116/images/apple-touch-icon-120x120.png" },
                    { new Guid("173c20c0-8700-43e6-8bf5-95d4629562ca"), new Guid("46f83d9c-17b4-48c4-9815-5e5d9ea330c1"), "https://www.pravda.ru/pix/apple-touch-icon.png" },
                    { new Guid("25683cf6-ecf8-4c03-ad31-0f2be7ddcefd"), new Guid("30f6021e-4c33-47a8-9007-cc1a2bdc6e8e"), "https://russian.rt.com/static/img/listing-uwc-logo.png" },
                    { new Guid("345371a6-280c-497f-b05b-9d6c8ca1dd2c"), new Guid("4b464590-ab44-4598-b829-aeddb20dad69"), "https://im.kommersant.ru/ContentFlex/images/favicons2020/apple-touch-icon-120.png" },
                    { new Guid("470e526a-eab5-40d6-b22e-e516e2da1d44"), new Guid("3f78951d-64e5-4928-8311-4b6e05277f3f"), "https://cdnn21.img.ria.ru/i/favicons/favicon.svg" },
                    { new Guid("690e236b-46f5-4d26-8b3a-d4fc197cc817"), new Guid("00fe3972-5e76-4ad4-99b2-0bc188a8217d"), "https://www.belta.by/images/storage/banners/000016_a133e848cb2e7b1debb7102d19e4d139_work.svg" },
                    { new Guid("7b612b8a-b577-4f59-8220-088fdd4fc49c"), new Guid("15365028-80e9-4b6e-ad56-2a22aa58c706"), "https://3dnews.ru/assets/images/3dnews_logo_soc.png" },
                    { new Guid("7f9ec5ac-bd2c-42a6-b7a3-278cbcf6235e"), new Guid("f85d2f33-c745-4c9f-bbfa-4e1611743585"), "https://www.interfax.ru/touch-icon-iphone-retina.png" },
                    { new Guid("83192521-8291-4431-accf-310506c0a32a"), new Guid("a38feb1c-dbaa-4a1f-a266-d7fdfc6d444b"), "https://st.championat.com/i/favicon/apple-touch-icon.png" },
                    { new Guid("a06501ff-f4b2-425f-b9aa-4442c783feea"), new Guid("236932a8-d37b-49b8-9f5a-b078cc0f96e2"), "https://ura.news/apple-touch-icon.png" },
                    { new Guid("af200241-242c-4f44-85f4-5f5ac0e726d8"), new Guid("03eea996-bb1b-4065-a816-91e6bfd785cd"), "https://static.gazeta.ru/nm2021/img/icons/favicon.svg" },
                    { new Guid("b49eb8d1-7ad6-4e2e-9507-1b10bc9d545b"), new Guid("b03b016c-c791-4657-b8e8-1daccbd249c4"), "https://vz.ru/apple-touch-icon.png" },
                    { new Guid("b7966075-e15f-4996-bd42-02e1982bbffc"), new Guid("76549bac-35f4-49a2-8c2d-2f83eee5b957"), "https://www.m24.ru/img/fav/apple-touch-icon.png" },
                    { new Guid("c3708774-2d6a-42ca-b9b2-b7a4d58be0b8"), new Guid("40c57819-1ebf-40eb-bbaf-861a7b6f3dbe"), "https://tass.ru/favicon/180.svg" },
                    { new Guid("c82793e1-0d48-48c3-9d7c-952158ad5b5a"), new Guid("9cc4ff97-bf99-4403-b857-8adb696df295"), "https://icdn.lenta.ru/images/icons/icon-256x256.png" },
                    { new Guid("cabebc4b-c59b-4a8d-ad3f-557423c543ed"), new Guid("6e140034-9153-4963-8df8-f55bec5a8969"), "https://chel.aif.ru/img/icon/apple-touch-icon.png?37f" },
                    { new Guid("d1e87742-3b7e-4a10-88fa-591a3431fa22"), new Guid("0f2deeea-77a9-4e7b-80ce-65b209d3f218"), "https://life.ru/appletouch/apple-icon-120х120.png" },
                    { new Guid("d4965c12-cb03-40f6-93e7-d3b8db797d3d"), new Guid("e186aa2e-c5d2-470d-a1fd-313a40c8210c"), "https://cdnstatic.rg.ru/images/touch-icon-iphone-retina.png" },
                    { new Guid("e6d3e02a-f2b2-4a65-810b-c7a786b90b9a"), new Guid("1f471d10-1256-47c5-aee2-bae488b7603c"), "https://ural.tsargrad.tv/favicons/apple-touch-icon-120x120.png?s2" },
                    { new Guid("f4ddad08-0077-4e34-b3cf-d793af115352"), new Guid("36fea04e-fffb-4b9b-9b0a-4056de2a99f3"), "https://ixbt.games/images/favicon/gt/apple-touch-icon.png" },
                    { new Guid("f7c5a974-eff4-449c-b04b-4064fb3b5fb0"), new Guid("4dd33a6f-6aa5-4642-8944-42f5fedf217e"), "https://www.ixbt.com/favicon.ico" },
                    { new Guid("faafab04-8ec7-49fb-9380-7f3461d8feb3"), new Guid("e4ee59a5-7bc8-452a-ae28-0f25df77be91"), "https://www.sports.ru/apple-touch-icon-120.png" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_editor_settings",
                columns: new[] { "id", "is_required", "name_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("0498ae7c-bf77-4a94-ab57-62e4f5cdf766"), true, "//article//header//div[@class='article-head__author-name']/a[@rel='author']/span/text()", new Guid("c303fe12-7046-488c-806d-087a70368c3a") },
                    { new Guid("1023916f-2e34-44f7-9c56-eb551a5997da"), false, "//div[@class='article__authors']//*[@class='article__authors__author']/span[@class='article__authors__author__name']/text()", new Guid("f1cd5170-ea9f-4697-aef3-b3df84ea73a6") },
                    { new Guid("28c47e7e-9cb9-44ac-8fef-db69ecb461cb"), true, "//div[@class='container-fluid publication-footer']//a[contains(@class, 'text-secondary')]/@title", new Guid("5432355d-4cec-48aa-8580-02b30dcb5f8f") },
                    { new Guid("434a57c2-df2e-4327-9c14-d336823c1ceb"), false, "//div[@class='topic-authors']/a[@class='topic-authors__author']/text()", new Guid("f4db655f-9b67-406a-964c-ee917a260148") },
                    { new Guid("5d020291-83b9-4a5c-8280-e5b8c346d2f5"), true, "//a[@class='article__author']/text()", new Guid("8b19e205-bfac-41d7-bf58-dcb1863f4f10") },
                    { new Guid("5ddd382d-6199-47fa-b9c1-7c4eb4bec5b9"), false, "//p[@class='doc__text document_authors']/text()", new Guid("da19d83e-606a-4d17-bd7a-c8868948c79c") },
                    { new Guid("5df1f3b9-55e9-4a6c-8060-31de16bd2a35"), true, "//div[contains(@class, 'full-article')]/div[@class='authors-block']//span[text()='Автор']/../a/text()", new Guid("43882537-2afc-430a-992b-598f0f074430") },
                    { new Guid("7aedb872-14c8-437f-9459-ce21be48e011"), true, "//div[contains(@class, 'styles_bodyWrapper')]//div[contains(@class, 'styles_authorsLinks')]/a/text()", new Guid("4ad01f6b-c1d8-41c0-aff2-f2da123bb56e") },
                    { new Guid("85fe66da-bd00-4247-adb7-69f39b2a0b4d"), true, "//div[contains(@class, 'PageArticleContent_authors')]//a[contains(@class, 'LinksOfAuthor_item')]/text()", new Guid("507ef82b-fa45-4672-ad31-c7d1987ac158") },
                    { new Guid("9d0c93a1-2fc8-4a46-9e58-9c215552b826"), true, "//footer[@class='news-item__footer']/div[@class='news-item__footer-after-news']/p[position()=1]//span/text()", new Guid("15d8f20c-0add-42ff-82b0-41a5db14fe4b") },
                    { new Guid("cbd2e23f-6cae-40b3-9c97-6ba88bce7442"), true, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']//a[@itemprop='author']//span[@itemprop='name']/text()", new Guid("bac87346-963e-448c-9041-ee55c80e4538") },
                    { new Guid("e83cf535-7603-4b71-b5ba-73df46bd21bf"), true, "//span[@itemprop='author']/span[@itemprop='name']/@content", new Guid("b0da9c97-c38b-4f4d-b77b-7f9bfc7b806f") },
                    { new Guid("ed3b6a60-2aa7-4a89-8190-2f0b8d372ef8"), true, "//div[@class='article_top']//div[@class='authors']//div[@class='autor']//span/text()", new Guid("c6b96c11-9e98-41c8-8031-ce35aeb8352c") },
                    { new Guid("f01cbb62-4a6e-48eb-9e9a-ad563d624334"), true, "//div[@itemprop='author']/span[@itemprop='name']/text()", new Guid("ae9e7bd7-29aa-4029-90db-22fbe8da9961") },
                    { new Guid("f1005822-b923-4805-89d4-538111166b37"), false, "//div[@class='author']/span[@itemprop='author']/span[@itemprop='name']/a/text()", new Guid("47eda3b6-0fa1-4f4b-adab-50ca962bfeef") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_picture_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("0aa3f583-1d0f-4002-8af9-a57f8fca6cd6"), false, new Guid("43882537-2afc-430a-992b-598f0f074430"), "//div[contains(@class, 'full-article')]/div[contains(@class, 'gallery')]/picture/img/@src" },
                    { new Guid("17d1e7f7-57a6-4970-92df-f9f542be3388"), false, new Guid("47eda3b6-0fa1-4f4b-adab-50ca962bfeef"), "//div[@class='b_article-media']//div[@class='mainarea-wrapper']/figure/img[@class='item-image-front']/@src" },
                    { new Guid("48b8c4df-464a-4101-8a5a-e16a3b2efdef"), false, new Guid("f720910b-b9f1-4bd6-8f10-e246711b405c"), "//article/figure/img/@src" },
                    { new Guid("4fd27d41-eafc-4694-bc2d-776593534acc"), true, new Guid("5432355d-4cec-48aa-8580-02b30dcb5f8f"), "//a[@class='glightbox']/img[contains(@class, 'pub-cover')]/@src" },
                    { new Guid("5fe58a47-6995-4e20-838a-ee3cf484e51f"), false, new Guid("bac87346-963e-448c-9041-ee55c80e4538"), "//div[contains(@class, 'article-entry')]//div[contains(@class, 'entry-body')]//div[@class='source-wrapper']/img[@itemprop='image']/@src" },
                    { new Guid("6af6fd41-db00-4d58-8b58-35a435ec3db8"), false, new Guid("f8143847-61e3-41d3-92f5-e1faeea13c78"), "//div[@class='photoview__open']/img/@src" },
                    { new Guid("7111c223-b150-43ef-b8e6-bc22d01ace79"), true, new Guid("03f14cc8-3246-4547-9b3e-e1ac16f7a821"), "//div[contains(@class, 'big_photo')]//div[@class='big_photo__img']//img/@src" },
                    { new Guid("7c206779-01e8-4223-93b9-91d5699ee6db"), false, new Guid("4ad01f6b-c1d8-41c0-aff2-f2da123bb56e"), "//article//header/div[contains(@class, 'styles_cover_media')]/img/@src" },
                    { new Guid("8151f31c-b5ea-4251-b68c-6444d306f93e"), false, new Guid("26297a42-1d07-43db-96b4-f933657dae77"), "//div[contains(@class, 'HeaderMedia_image')]//img[contains(@class, 'Image_image')]/@src" },
                    { new Guid("9e09ada3-9684-4b85-a24d-ed30906d964b"), false, new Guid("c6b96c11-9e98-41c8-8031-ce35aeb8352c"), "//div[@class='img_box']/a[@class='zoom_js']/img/@src" },
                    { new Guid("aaf644ab-4af7-4514-a3d9-7df406b11153"), false, new Guid("f4db655f-9b67-406a-964c-ee917a260148"), "//div[contains(@class, 'topic-body__title-image')]//img[contains(@class, 'picture__image')]/@src" },
                    { new Guid("b19bec24-3b73-436a-84db-f0f7ea5ed7e6"), true, new Guid("ae9e7bd7-29aa-4029-90db-22fbe8da9961"), "//div[@itemprop='articleBody']//div[@itemprop='image']/picture/img[@itemprop='contentUrl']/@src" },
                    { new Guid("c8c1b784-ba03-4a12-a39c-cd11735570f1"), false, new Guid("c303fe12-7046-488c-806d-087a70368c3a"), "//article//header/div[@class='article-head__photo']/img/@src" },
                    { new Guid("d0a6e3c7-947d-4501-9341-fb55710d33e7"), false, new Guid("837496a8-0ca5-43db-a729-4c43ace71f5b"), "//div[@class='b-material-incut-m-image']//@src" },
                    { new Guid("ded141b6-596f-44ec-ad89-d940be7a3f58"), false, new Guid("5092e3eb-24ec-45db-bdc7-07e4e6ab228c"), "//div[@class='inner_content']//div[@class='main_img']//img/@src" },
                    { new Guid("e2823450-64aa-4b07-8267-0f43a5241dd8"), true, new Guid("8b19e205-bfac-41d7-bf58-dcb1863f4f10"), "//div[@class='article__media']//img/@src" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "published_at_culture_info", "published_at_time_zone_info_id", "published_at_x_path" },
                values: new object[,]
                {
                    { new Guid("0c25140f-0d23-49ad-b21a-c46cf052eaf3"), true, new Guid("15d8f20c-0add-42ff-82b0-41a5db14fe4b"), "ru-RU", null, "//header[@class='news-item__header']//time/@content" },
                    { new Guid("112334af-7a0b-43db-8466-cd57cba997be"), true, new Guid("47eda3b6-0fa1-4f4b-adab-50ca962bfeef"), "ru-RU", null, "//article/div[@class='b_article-header']//time[@itemprop='datePublished']/@datetime" },
                    { new Guid("12a0672c-8f99-41ac-9851-25dac6073874"), true, new Guid("5308b8e6-0415-4ab9-9ced-be009ebc1fe7"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'article__date-autor-shortcode')]/div[contains(@class, 'article__date')]/time[@class='date']/@datetime" },
                    { new Guid("2bb93b3a-3e62-4845-95a4-8f6e6dc98c2b"), true, new Guid("da19d83e-606a-4d17-bd7a-c8868948c79c"), "ru-RU", null, "//div[@class='doc_header__time']/time[@class='doc_header__publish_time']/@datetime" },
                    { new Guid("3900ffcd-86d7-4113-b15f-74c50c19fd10"), true, new Guid("405eb757-9757-4633-b7fc-4511b035b0ab"), "ru-RU", "Russian Standard Time", "//article[@itemprop='articleBody']/meta[@itemprop='datePublished']/@content" },
                    { new Guid("4b6c3a23-c05f-47be-9cef-5966be38ec63"), true, new Guid("f720910b-b9f1-4bd6-8f10-e246711b405c"), "ru-RU", "Russian Standard Time", "//article/div[@class='header']/span/text()" },
                    { new Guid("691b2369-b7a8-442a-bb75-a0ea2c284b1f"), true, new Guid("03f14cc8-3246-4547-9b3e-e1ac16f7a821"), "ru-RU", null, "//div[@class='article_page__left__top__left']//div[@class='article_page__left__top__time']//time/@datetime" },
                    { new Guid("744138ab-3c79-47f1-860d-3bc5251007ab"), true, new Guid("f4db655f-9b67-406a-964c-ee917a260148"), "ru-RU", "Russian Standard Time", "//div[@class='topic-page__header']//a[contains(@class, 'topic-header__time')]/text()" },
                    { new Guid("7842cf9d-6a34-4faf-8d13-3659c1556522"), true, new Guid("c6b96c11-9e98-41c8-8031-ce35aeb8352c"), "ru-RU", "Russian Standard Time", "//div[@class='article_top']//div[@class='date']//time/text()" },
                    { new Guid("7b7bf895-a198-4784-8f08-4b634e239dcf"), true, new Guid("507ef82b-fa45-4672-ad31-c7d1987ac158"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'PageArticleContent_date')]/text()" },
                    { new Guid("7bf4045e-fc7f-4e68-97f4-e01abd5c0e41"), true, new Guid("f1cd5170-ea9f-4697-aef3-b3df84ea73a6"), "ru-RU", null, "//div[@class='article__header__info-block']/time[@class='article__header__date']/@datetime" },
                    { new Guid("971513cb-103f-4beb-9623-0ccd1c157b8a"), true, new Guid("b0da9c97-c38b-4f4d-b77b-7f9bfc7b806f"), "ru-RU", "Russian Standard Time", "//div[@class='b-article__top-author']/p[@class='date']/text()" },
                    { new Guid("9d7b6b68-5e68-44ef-826c-575b86633940"), true, new Guid("26297a42-1d07-43db-96b4-f933657dae77"), "ru-RU", "UTC", "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark')]//span[@ca-ts]/text()" },
                    { new Guid("9f985148-d9de-4e2c-b38e-0a4da42ef951"), true, new Guid("ae9e7bd7-29aa-4029-90db-22fbe8da9961"), "ru-RU", null, "//div[@class='publication-info']/time[@itemprop='datePublished']/@datetime" },
                    { new Guid("a2d0d4d8-70b8-42e1-9131-b1457e00ccbb"), true, new Guid("8b19e205-bfac-41d7-bf58-dcb1863f4f10"), "ru-RU", "Russian Standard Time", "//div[@class='article__meta']/time/text()" },
                    { new Guid("ac684469-1887-44f4-9c42-7305635da9d9"), true, new Guid("43882537-2afc-430a-992b-598f0f074430"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'full-article')]//time/text()" },
                    { new Guid("b94fd24e-ee0c-4be7-9407-aec7a9c305b6"), true, new Guid("bac87346-963e-448c-9041-ee55c80e4538"), "ru-RU", null, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']/span[@itemprop='datePublished']/@content" },
                    { new Guid("bb094552-53c9-4e66-83d8-d41eeb3df7dd"), true, new Guid("837496a8-0ca5-43db-a729-4c43ace71f5b"), "ru-RU", "Russian Standard Time", "//p[@class='b-material__date']/text()" },
                    { new Guid("c414e15d-0016-40e2-b267-a4d17feceedf"), true, new Guid("5092e3eb-24ec-45db-bdc7-07e4e6ab228c"), "ru-RU", "Russian Standard Time", "//div[@class='date_full']/text()" },
                    { new Guid("d536b812-05e7-4ab8-8aab-de0757547248"), false, new Guid("5432355d-4cec-48aa-8580-02b30dcb5f8f"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'pubdatetime')]/text()" },
                    { new Guid("e8f58583-8875-4e61-8d34-006dd13e04af"), true, new Guid("c303fe12-7046-488c-806d-087a70368c3a"), "ru-RU", "Russian Standard Time", "//article//header//time[@class='article-head__date']/text()" },
                    { new Guid("edaed307-c842-4e3a-a561-93a25aa674e3"), true, new Guid("4ad01f6b-c1d8-41c0-aff2-f2da123bb56e"), "ru-RU", "UTC", "//article//header//div[contains(@class, 'styles_meta')]//div[contains(@class, 'styles_metaItem')]/text()" },
                    { new Guid("f9758d9b-2fd7-4563-a373-ecaf81210604"), true, new Guid("f8143847-61e3-41d3-92f5-e1faeea13c78"), "ru-RU", "Russian Standard Time", "//div[@class='article__info']//div[@class='article__info-date']/a/text()" },
                    { new Guid("ff2b4bfe-ab55-427a-a760-3701c17d262d"), true, new Guid("37eff250-5741-4a51-96c6-6e576d8321ad"), "ru-RU", "Russian Standard Time", "//div[@class='b-text__date']/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_sub_title_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("1aadd64e-db08-4061-aebd-15f8ba0fdd70"), false, new Guid("da19d83e-606a-4d17-bd7a-c8868948c79c"), "//header[@class='doc_header']/h2[contains(@class, 'doc_header__subheader')]/text()" },
                    { new Guid("29687747-1d7a-4cf0-a35c-261416e2dea3"), true, new Guid("43882537-2afc-430a-992b-598f0f074430"), "//h1/text()" },
                    { new Guid("3c911ebc-26cd-4f46-8249-f19894b0ec82"), true, new Guid("5308b8e6-0415-4ab9-9ced-be009ebc1fe7"), "//div[contains(@class, 'article__summary')]/text()" },
                    { new Guid("3eaf56e3-956d-49f4-993d-05201012f4fa"), true, new Guid("bac87346-963e-448c-9041-ee55c80e4538"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()=1]/text()" },
                    { new Guid("451f5042-7f19-4a34-99f5-5e02a6dc0ff9"), true, new Guid("5432355d-4cec-48aa-8580-02b30dcb5f8f"), "//div[@class='container-fluid shifted']/p[@class='announce lead']/text()" },
                    { new Guid("5b657fb5-737d-4ef3-9440-3b7ca29f6745"), false, new Guid("f4db655f-9b67-406a-964c-ee917a260148"), "//div[contains(@class, 'topic-body__title')]/text()" },
                    { new Guid("6c9ae525-a334-4eb8-8556-a266736db6ca"), false, new Guid("507ef82b-fa45-4672-ad31-c7d1987ac158"), "//div[contains(@class, 'PageArticleContent_lead')]/text()" },
                    { new Guid("799a8602-265c-417d-b854-531dc5f5f2a5"), false, new Guid("b0da9c97-c38b-4f4d-b77b-7f9bfc7b806f"), "//h4/text()" },
                    { new Guid("9648fa37-de2d-437c-a953-1887fb1ce461"), true, new Guid("8b19e205-bfac-41d7-bf58-dcb1863f4f10"), "//div[@class='article__intro']/p/text()" },
                    { new Guid("b72efd38-0a71-40e3-ac0f-62e6e9a21f4b"), false, new Guid("26297a42-1d07-43db-96b4-f933657dae77"), "//h3/text()" },
                    { new Guid("ba381fa1-fe5f-41be-a32d-e89a18cdc65b"), false, new Guid("4ad01f6b-c1d8-41c0-aff2-f2da123bb56e"), "//article//header//p[contains(@class, 'styles_subtitle')]/text()" },
                    { new Guid("c8f9bd9d-6b40-4353-883d-a7aadbceecf7"), false, new Guid("f1cd5170-ea9f-4697-aef3-b3df84ea73a6"), "//div[contains(@class, 'article__text')]/div[@class='article__text__overview']/span/text()" },
                    { new Guid("e6f45d7b-1b19-4792-a202-12babe4b8134"), false, new Guid("f720910b-b9f1-4bd6-8f10-e246711b405c"), "//h4/text()" },
                    { new Guid("ec173f42-eab0-4809-bb1b-95e75255dd01"), true, new Guid("47eda3b6-0fa1-4f4b-adab-50ca962bfeef"), "//h2/text()" },
                    { new Guid("fe87e07b-eaf5-4e93-ae81-85c7ef54f322"), true, new Guid("f8143847-61e3-41d3-92f5-e1faeea13c78"), "//h1[@class='article__second-title']/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_published_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("06a7bdf5-118c-4e57-be46-95e7e9591aba"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("691b2369-b7a8-442a-bb75-a0ea2c284b1f") },
                    { new Guid("091adea9-fb49-4fa8-9467-6fa9afe1d09a"), "dd MMMM  HH:mm", new Guid("ff2b4bfe-ab55-427a-a760-3701c17d262d") },
                    { new Guid("0b968ef6-2c93-4c7b-bc26-f484f4ce08e9"), "dd MMMM, HH:mm", new Guid("9d7b6b68-5e68-44ef-826c-575b86633940") },
                    { new Guid("1b08d5b1-891b-4914-9090-148f76e4863b"), "HH:mm", new Guid("bb094552-53c9-4e66-83d8-d41eeb3df7dd") },
                    { new Guid("20b6f741-7e0d-4d7b-b5e8-60075df9eb71"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("0c25140f-0d23-49ad-b21a-c46cf052eaf3") },
                    { new Guid("23c13014-bb8c-48e1-94d3-1957aa99331a"), "dd.MM.yyyy HH:mm", new Guid("7842cf9d-6a34-4faf-8d13-3659c1556522") },
                    { new Guid("30795dad-46dc-4fe4-9a5f-cbc1abe75048"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("7bf4045e-fc7f-4e68-97f4-e01abd5c0e41") },
                    { new Guid("365cfd4c-8bed-4851-b922-0a57402d895b"), "yyyy-MM-dd HH:mm:ss", new Guid("d536b812-05e7-4ab8-8aab-de0757547248") },
                    { new Guid("38e99331-edd3-492b-a5b7-5abc86249198"), "dd MMMM yyyy, HH:mm", new Guid("9d7b6b68-5e68-44ef-826c-575b86633940") },
                    { new Guid("41980f1c-1b0b-4031-ab44-af252dd0f977"), "HH:mm", new Guid("a2d0d4d8-70b8-42e1-9131-b1457e00ccbb") },
                    { new Guid("4d1399d3-be91-40c8-ae53-71966376ed43"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("b94fd24e-ee0c-4be7-9407-aec7a9c305b6") },
                    { new Guid("59081f35-3e41-49c7-bdcb-33134d791dcc"), "dd MMMM, HH:mm", new Guid("bb094552-53c9-4e66-83d8-d41eeb3df7dd") },
                    { new Guid("67db1590-987d-4006-ac97-b3d34689f5eb"), "dd MMMM yyyy HH:mm", new Guid("ff2b4bfe-ab55-427a-a760-3701c17d262d") },
                    { new Guid("7ac816df-cd31-4a84-982b-8c0d96a42b46"), "dd MMMM yyyy, HH:mm", new Guid("4b6c3a23-c05f-47be-9cef-5966be38ec63") },
                    { new Guid("7e11a3f7-8463-41d4-9fcd-b13e4322d87c"), "yyyy-MM-d HH:mm", new Guid("12a0672c-8f99-41ac-9851-25dac6073874") },
                    { new Guid("7f5af63f-d30f-4b91-afea-41a874e6ec6a"), "dd MMMM yyyy, HH:mm,", new Guid("9d7b6b68-5e68-44ef-826c-575b86633940") },
                    { new Guid("871fc5fc-7136-439d-bc10-6b38952f5e12"), "HH:mm dd.MM.yyyy", new Guid("f9758d9b-2fd7-4563-a373-ecaf81210604") },
                    { new Guid("935d339a-e8f5-4a61-ac83-fc4ffcf173dd"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("112334af-7a0b-43db-8466-cd57cba997be") },
                    { new Guid("a0ca45de-3ee5-4ca7-93eb-192f3150cd24"), "HH:mm, dd MMMM yyyy", new Guid("744138ab-3c79-47f1-860d-3bc5251007ab") },
                    { new Guid("a1f13bf3-364c-461a-819e-aacfa8acf30f"), "dd MMMM, HH:mm,", new Guid("9d7b6b68-5e68-44ef-826c-575b86633940") },
                    { new Guid("a3027a66-7693-4e44-a3e5-f912f69787fc"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("9f985148-d9de-4e2c-b38e-0a4da42ef951") },
                    { new Guid("a66597c0-dbe7-4055-b6db-4adbf76cf8e3"), "dd MMMM yyyy, HH:mm", new Guid("c414e15d-0016-40e2-b267-a4d17feceedf") },
                    { new Guid("ad6c2ab5-45d5-442a-88ab-79f29c8463dc"), "dd MMMM yyyy в HH:mm", new Guid("971513cb-103f-4beb-9623-0ccd1c157b8a") },
                    { new Guid("b1c10a15-25e1-447e-a14a-c7425154934f"), "dd.MM.yyyy HH:mm", new Guid("7b7bf895-a198-4784-8f08-4b634e239dcf") },
                    { new Guid("b51e7069-70c3-42c7-80c9-8b85b5c5ac72"), "dd.MM.yyyy HH:mm", new Guid("ac684469-1887-44f4-9c42-7305635da9d9") },
                    { new Guid("be9b42d0-d1ff-44bf-b601-294a6277d7d4"), "dd MMMM yyyy, HH:mm", new Guid("bb094552-53c9-4e66-83d8-d41eeb3df7dd") },
                    { new Guid("c824b1ed-375b-4685-b0e2-7ce259eaa24a"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("2bb93b3a-3e62-4845-95a4-8f6e6dc98c2b") },
                    { new Guid("d762bc4f-9873-4a0a-9e52-707d3a6a149a"), "dd MMMM, HH:mm", new Guid("edaed307-c842-4e3a-a561-93a25aa674e3") },
                    { new Guid("e1124b15-d038-4169-852f-2ff30d9cf9ba"), "dd MMMM yyyy, HH:mm МСК", new Guid("e8f58583-8875-4e61-8d34-006dd13e04af") },
                    { new Guid("e2070111-f328-4f8b-b8a2-79a50d21e37c"), "dd MMMM yyyy, HH:mm", new Guid("edaed307-c842-4e3a-a561-93a25aa674e3") },
                    { new Guid("e61e9ec7-3442-48c1-92b0-425d8338cb9c"), "dd MMMM yyyy HH:mm", new Guid("a2d0d4d8-70b8-42e1-9131-b1457e00ccbb") },
                    { new Guid("f407c9e9-9d49-454f-9a0c-c82e02f6b447"), "yyyy-MM-ddTHH:mm:ss", new Guid("3900ffcd-86d7-4113-b15f-74c50c19fd10") }
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
