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
                    { new Guid("01dd09e2-25ff-4639-8174-799d15a7eb4f"), true, "https://www.pravda.ru/", "Правда.ру" },
                    { new Guid("0fa8e5ea-4244-473f-9abd-8dcaf3707e8d"), true, "https://lenta.ru/", "Лента.Ру" },
                    { new Guid("106e7393-cf77-4eaf-92b0-9c436a16a1ad"), true, "https://aif.ru/", "Аргументы и факты" },
                    { new Guid("2184c942-1eb2-411d-a976-683402ed8b54"), true, "https://tass.ru/", "ТАСС" },
                    { new Guid("294e016c-f6a9-46b0-94f4-44b338ae53ae"), true, "https://www.ixbt.com/", "iXBT.com" },
                    { new Guid("34d0c0a0-e537-40bb-9511-257d5c2d6b68"), true, "https://ura.news/", "Ura.ru" },
                    { new Guid("47b71370-cede-413a-b18f-5d79bf685b00"), true, "https://svpressa.ru/", "СвободнаяПресса" },
                    { new Guid("487703fc-2e7e-474d-9899-014e085f461b"), false, "https://tsargrad.tv/", "Царьград" },
                    { new Guid("4dfbcc91-5924-4405-8fec-7586e6bb06bf"), true, "https://iz.ru/", "Известия" },
                    { new Guid("4f41e2c9-1c53-4e72-a40b-334b240659e6"), false, "https://ixbt.games/", "iXBT.games" },
                    { new Guid("5b025320-4dfb-4e1a-bd4c-cbab048a9887"), true, "https://ria.ru/", "РИА Новости" },
                    { new Guid("7dabab2c-ce13-4271-b318-28d3cbd4c79a"), true, "https://www.kommersant.ru/", "Коммерсантъ" },
                    { new Guid("855e70b2-8279-4709-a4a4-8e4292ca046f"), true, "https://www.m24.ru/", "Москва 24" },
                    { new Guid("9a98b275-8ce6-4343-98f6-88d8e4d7d1b8"), true, "https://3dnews.ru/", "3Dnews.ru" },
                    { new Guid("c238a1cd-a273-4c33-bf64-c8e5fd49c89a"), true, "https://www.gazeta.ru/", "Газета.Ru" },
                    { new Guid("c4c70a29-d889-4789-bf1f-73d7dbe3448b"), true, "https://www.interfax.ru/", "Интерфакс" },
                    { new Guid("c6238797-90c0-40e3-a62c-38288829a529"), true, "https://www.belta.by/", "БелТА" },
                    { new Guid("c8b92532-7530-4844-9b2e-131582c2192e"), true, "https://rg.ru/", "Российская газета" },
                    { new Guid("cb1580e3-5342-4eea-9bd2-da6114eceb69"), true, "https://www.sports.ru/", "Storts.ru" },
                    { new Guid("d07092e2-0010-42b3-b823-555909705bfe"), true, "https://www.rbc.ru/", "РБК" },
                    { new Guid("d667163b-f4a3-48c4-8c8a-ae8adb85bc49"), true, "https://life.ru/", "Life" },
                    { new Guid("e6df19fb-5945-4494-bdb0-7cb2b9efe746"), true, "https://russian.rt.com/", "RT на русском" },
                    { new Guid("e75c511f-9fa9-46e7-ac28-66868f8e574b"), true, "https://www.championat.com/", "Чемпионат.com" },
                    { new Guid("fc267691-ae48-4c5e-95be-1c9bc631d227"), true, "https://vz.ru/", "ВЗГЛЯД.РУ" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_settings",
                columns: new[] { "id", "description_x_path", "source_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("13982eaf-47d9-4d24-b9db-eb15c34e9940"), "//div[@class='container-fluid shifted']/p[@class='announce lead']", new Guid("4f41e2c9-1c53-4e72-a40b-334b240659e6"), "//h1/text()" },
                    { new Guid("1b6a8118-4743-4719-85ec-fa7549f5eaa3"), "//div[@class='js-mediator-article']", new Guid("c6238797-90c0-40e3-a62c-38288829a529"), "//h1/text()" },
                    { new Guid("23d9436f-0d7b-40e3-957a-3a019c1dc109"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()>1]", new Guid("9a98b275-8ce6-4343-98f6-88d8e4d7d1b8"), "//h1/text()" },
                    { new Guid("4ec5e6b4-7ba8-40c9-816f-64ed86900e53"), "//article/div[@class='news_text']", new Guid("fc267691-ae48-4c5e-95be-1c9bc631d227"), "//h1/text()" },
                    { new Guid("4fb1ad7e-ee34-45b8-b81c-251d94b8ad1f"), "//div[contains(@class, 'news-item__content')]", new Guid("cb1580e3-5342-4eea-9bd2-da6114eceb69"), "//h1/text()" },
                    { new Guid("5c9d7baf-aa66-4f1d-8558-95a3508b5aa2"), "//div[contains(@class, 'article__text ')]", new Guid("e6df19fb-5945-4494-bdb0-7cb2b9efe746"), "//h1/text()" },
                    { new Guid("5ea05fa3-4d71-49e7-8467-febe303b82b9"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]", new Guid("7dabab2c-ce13-4271-b318-28d3cbd4c79a"), "//h1/text()" },
                    { new Guid("6b400ee2-13e2-4e71-b94f-a07d7a4123c8"), "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]", new Guid("47b71370-cede-413a-b18f-5d79bf685b00"), "//h1[@class='b-text__title']/text()" },
                    { new Guid("774e9c7c-f642-465c-b93c-c2aacdf18b8f"), "//div[@class='topic-body__content']", new Guid("0fa8e5ea-4244-473f-9abd-8dcaf3707e8d"), "//h1[@class='topic-body__titles']/span[@class='topic-body__title']/text()" },
                    { new Guid("77b72f9f-6883-4f7f-9a24-5aa83531a35a"), "//div[@itemprop='articleBody']/*[not(name()='div')]", new Guid("34d0c0a0-e537-40bb-9511-257d5c2d6b68"), "//h1/text()" },
                    { new Guid("806fa257-eca5-419d-a26e-f1b7a3dcbcb3"), "//article/div[@class='article-content']/*[not(@class)]", new Guid("e75c511f-9fa9-46e7-ac28-66868f8e574b"), "//article/header/div[@class='article-head__title']/text()" },
                    { new Guid("8363a541-546f-4a17-8ca3-3a6f0f4aa6c6"), "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]", new Guid("01dd09e2-25ff-4639-8174-799d15a7eb4f"), "//h1/text()" },
                    { new Guid("84135793-ab32-4867-8bf1-8147b2b3c14c"), "//div[@itemprop='articleBody']", new Guid("c238a1cd-a273-4c33-bf64-c8e5fd49c89a"), "//h1/text()" },
                    { new Guid("84393779-d9b0-44f7-a563-d44269ff77b2"), "//div[contains(@class, 'PageContentCommonStyling_text')]", new Guid("c8b92532-7530-4844-9b2e-131582c2192e"), "//h1/text()" },
                    { new Guid("87b4be29-0d30-4a16-aa55-cfb56b544ec7"), "//div[@class='article_text']", new Guid("106e7393-cf77-4eaf-92b0-9c436a16a1ad"), "//h1/text()" },
                    { new Guid("8a984818-6b5c-42ff-af2b-7499cce1fdd3"), "//div[@itemprop='articleBody']", new Guid("4dfbcc91-5924-4405-8fec-7586e6bb06bf"), "//h1/span/text()" },
                    { new Guid("c03dfd86-0f2e-4c0a-87d3-26d61263c773"), "//div[contains(@class, 'article__body')]", new Guid("5b025320-4dfb-4e1a-bd4c-cbab048a9887"), "//div[@class='article__title']/text()" },
                    { new Guid("d3ff4b84-a0ff-4eb7-8ad4-9fbf56315c64"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]", new Guid("487703fc-2e7e-474d-9899-014e085f461b"), "//h1[@class='article__title']/text()" },
                    { new Guid("d6374200-a1cd-46cd-9f88-14c86ab30e08"), "//div[@itemprop='articleBody']", new Guid("294e016c-f6a9-46b0-94f4-44b338ae53ae"), "//h1/text()" },
                    { new Guid("e2be7c42-b23a-4849-b382-065f32cc9da6"), "//article", new Guid("2184c942-1eb2-411d-a976-683402ed8b54"), "//h1/text()" },
                    { new Guid("e95e4af0-61c4-4706-b19f-56d0452651c3"), "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]", new Guid("c4c70a29-d889-4789-bf1f-73d7dbe3448b"), "//h1/text()" },
                    { new Guid("f528a6df-4678-464b-9da9-97dd1b0b2fff"), "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]", new Guid("d667163b-f4a3-48c4-8c8a-ae8adb85bc49"), "//h1/text()" },
                    { new Guid("f80c5aa4-3026-4657-bb2b-90533ace23c5"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview'))]", new Guid("d07092e2-0010-42b3-b823-555909705bfe"), "//h1/text()" },
                    { new Guid("fb5d1bb1-a8df-4edf-8e02-2d4d9e28c57f"), "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]", new Guid("855e70b2-8279-4709-a4a4-8e4292ca046f"), "//h1/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_search_settings",
                columns: new[] { "id", "news_site_url", "news_url_x_path", "source_id" },
                values: new object[,]
                {
                    { new Guid("035bc0b6-dc5b-4eaf-8210-cfd501a023a1"), "https://vz.ru/", "//a[contains(@href, '.html') and not(contains(@href, '#comments')) and not(contains(@href, '?')) and not(contains(@href, '/about/'))]/@href", new Guid("fc267691-ae48-4c5e-95be-1c9bc631d227") },
                    { new Guid("08b4e01b-2410-4921-87e9-7f669a5ac066"), "https://aif.ru/", "//span[contains(@class, 'item_text__title')]/../@href", new Guid("106e7393-cf77-4eaf-92b0-9c436a16a1ad") },
                    { new Guid("1b071b54-7880-44c1-bc5e-d403fb2133d4"), "https://tass.ru/", "//a[contains(@class, 'tass_pkg_link-v5WdK') and contains(substring(@href, 2), '/')]/@href", new Guid("2184c942-1eb2-411d-a976-683402ed8b54") },
                    { new Guid("317de6d6-8693-49ff-b21e-5cffb88c0280"), "https://www.ixbt.com/news/", "//a[starts-with(@href, '/news/') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("294e016c-f6a9-46b0-94f4-44b338ae53ae") },
                    { new Guid("3bf8beb0-b638-4ae1-8a1d-1b833a6d483b"), "https://lenta.ru/", "//a[starts-with(@href, '/news/')]/@href", new Guid("0fa8e5ea-4244-473f-9abd-8dcaf3707e8d") },
                    { new Guid("41104bd1-d6b8-4f3f-837c-3354e1b56f67"), "https://svpressa.ru/all/news/", "//a[contains(@href, '/news/') and not(contains(@href, '?')) and not(starts-with(@href, '/all/news/'))]/@href", new Guid("47b71370-cede-413a-b18f-5d79bf685b00") },
                    { new Guid("467ba11c-f695-4e41-9dc0-58e22b7d410b"), "https://tsargrad.tv/", "//a[contains(@class, 'news-item__link')]/@href", new Guid("487703fc-2e7e-474d-9899-014e085f461b") },
                    { new Guid("4ae45096-2151-4a63-ac34-f7f5356291c6"), "https://rg.ru/", "//a[contains(@href, '.html')]/@href", new Guid("c8b92532-7530-4844-9b2e-131582c2192e") },
                    { new Guid("4b1b72fa-2c19-47f2-8a6f-8e82c2059966"), "https://www.pravda.ru/", "//a[contains(@href, '/news/') and not(@href='https://www.pravda.ru/news/')]/@href", new Guid("01dd09e2-25ff-4639-8174-799d15a7eb4f") },
                    { new Guid("5b1545af-7819-4999-9bb6-298ad10c8ffd"), "https://russian.rt.com/", "//a[contains(@class, 'link') and contains(@href, 'news/')]/@href", new Guid("e6df19fb-5945-4494-bdb0-7cb2b9efe746") },
                    { new Guid("6a341fd2-470a-4969-9c2b-bee12a02eb1b"), "https://www.kommersant.ru/", "//a[contains(@href, '/doc/') and contains(@href, '?from=')]/@href", new Guid("7dabab2c-ce13-4271-b318-28d3cbd4c79a") },
                    { new Guid("942da78e-c48a-4233-8391-a587ec271e23"), "https://www.m24.ru/", "//a[contains(@href, '/news/')]/@href", new Guid("855e70b2-8279-4709-a4a4-8e4292ca046f") },
                    { new Guid("967d54a8-1daf-4415-acd5-32e343f54bc6"), "https://www.championat.com/news/1.html?utm_source=button&utm_medium=news", "//a[contains(@href, 'news-') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("e75c511f-9fa9-46e7-ac28-66868f8e574b") },
                    { new Guid("9fce02ac-c29b-4202-857c-468669a01021"), "https://www.gazeta.ru/news/", "//a[contains(@href, '/news/') and contains(@href, '.shtml') and not(contains(@href, '?'))]/@href", new Guid("c238a1cd-a273-4c33-bf64-c8e5fd49c89a") },
                    { new Guid("a62728fa-16c3-4fe1-b672-270215ff18c3"), "https://3dnews.ru/news/", "//div[@class='news-feed-all']//a[@class='entry-header']/h1/../@href", new Guid("9a98b275-8ce6-4343-98f6-88d8e4d7d1b8") },
                    { new Guid("aa0a0a3b-c73b-4cbc-b73d-5408d060e8b1"), "https://iz.ru/news/", "//a[contains(@href, '?main_click')]/@href", new Guid("4dfbcc91-5924-4405-8fec-7586e6bb06bf") },
                    { new Guid("b081eadc-adaf-45c5-90b1-3ab61bafe616"), "https://www.rbc.ru/", "//a[contains(@href, 'https://www.rbc.ru/') and contains(@href, '?from=')]/@href", new Guid("d07092e2-0010-42b3-b823-555909705bfe") },
                    { new Guid("c647f9ef-4d1b-4379-8ebd-4e94888a3336"), "https://www.sports.ru/news/", "//a[contains(@href, '.html') and not(contains(@href, '.html#comments'))]/@href", new Guid("cb1580e3-5342-4eea-9bd2-da6114eceb69") },
                    { new Guid("c77a7d25-5c7b-4e51-8899-97ec6fa80bf9"), "https://ixbt.games/news/", "//a[@class='card-link']/@href", new Guid("4f41e2c9-1c53-4e72-a40b-334b240659e6") },
                    { new Guid("d60e5d48-fb65-4b49-9548-40f9c7f17925"), "https://ria.ru/", "//a[contains(@class, 'cell-list__item-link')]/@href", new Guid("5b025320-4dfb-4e1a-bd4c-cbab048a9887") },
                    { new Guid("e1c03a0d-6ccb-41c9-8957-98a7472ebf48"), "https://www.belta.by/", "//a[contains(@href, 'https://www.belta.by/') and contains(@href, '/view/')]/@href", new Guid("c6238797-90c0-40e3-a62c-38288829a529") },
                    { new Guid("e7454a43-e0ef-4c47-ae35-9b91392ecf45"), "https://www.interfax.ru/", "//div[@class='timeline']//a[@tabindex=5]/@href", new Guid("c4c70a29-d889-4789-bf1f-73d7dbe3448b") },
                    { new Guid("e7d44937-8065-4e09-9636-2b694cd638d6"), "https://ura.news/", "//a[contains(@href, '/news/')]/@href", new Guid("34d0c0a0-e537-40bb-9511-257d5c2d6b68") },
                    { new Guid("fb5db5e3-8012-4151-93cb-e9618cc93563"), "https://life.ru/s/novosti", "//a[contains(@href, '/p/')]/@href", new Guid("d667163b-f4a3-48c4-8c8a-ae8adb85bc49") }
                });

            migrationBuilder.InsertData(
                table: "news_source_logos",
                columns: new[] { "id", "source_id", "url" },
                values: new object[] { new Guid("df57af4a-ba39-40b8-b262-b696ebbe169a"), new Guid("4f41e2c9-1c53-4e72-a40b-334b240659e6"), "https://sun13-2.userapi.com/s/v1/ig2/_ID-2w6Llad8ig5_987dKAfh1pyLdj7HfLHqGx9HxyDjoEDN7wxR0ZWJm5ja1Ey6UuQXaEYEBW1Zd51cpRrjSGfS.jpg?size=100x100&quality=96&crop=22,22,626,626&ava=1" });

            migrationBuilder.InsertData(
                table: "news_parse_editor_settings",
                columns: new[] { "id", "is_required", "name_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("2fa87f8f-77e3-4a40-bb08-df1b179d08e4"), true, "//div[@class='article_top']//div[@class='authors']//div[@class='autor']//span/text()", new Guid("87b4be29-0d30-4a16-aa55-cfb56b544ec7") },
                    { new Guid("412d8535-f413-480f-a59c-2ba581d417e6"), false, "//p[@class='doc__text document_authors']/text()", new Guid("5ea05fa3-4d71-49e7-8467-febe303b82b9") },
                    { new Guid("43cce736-884f-4d68-9663-536d96a0ec4b"), true, "//article//header//div[@class='article-head__author-name']/a[@rel='author']/span/text()", new Guid("806fa257-eca5-419d-a26e-f1b7a3dcbcb3") },
                    { new Guid("48cd30b8-2d88-430c-9bbf-8be673efcb7c"), false, "//div[@class='topic-authors']/a[@class='topic-authors__author']/text()", new Guid("774e9c7c-f642-465c-b93c-c2aacdf18b8f") },
                    { new Guid("4a17666d-f9c0-4560-8137-a63de4025b2d"), true, "//div[contains(@class, 'PageArticleContent_authors')]//a[contains(@class, 'LinksOfAuthor_item')]/text()", new Guid("84393779-d9b0-44f7-a563-d44269ff77b2") },
                    { new Guid("55f828be-e945-4145-a0a5-cb6ef7b5400c"), false, "//div[@class='article__authors']//span[@class='article__authors__author']/span[@class='article__authors__author__name']/text()", new Guid("f80c5aa4-3026-4657-bb2b-90533ace23c5") },
                    { new Guid("5b64aeff-1add-4819-9aa6-bdf2a03ca909"), true, "//div[@class='container-fluid publication-footer']//a[contains(@class, 'text-secondary')]/@title", new Guid("13982eaf-47d9-4d24-b9db-eb15c34e9940") },
                    { new Guid("789ee004-4d92-4cd0-bdfd-e4fcbd1d623f"), true, "//a[@class='article__author']/text()", new Guid("d3ff4b84-a0ff-4eb7-8ad4-9fbf56315c64") },
                    { new Guid("85d588cc-87f8-4413-a507-9dde93638303"), true, "//span[@itemprop='author']/span[@itemprop='name']/@content", new Guid("d6374200-a1cd-46cd-9f88-14c86ab30e08") },
                    { new Guid("973da7aa-3331-4618-ac6c-acb2d90a99ec"), true, "//footer[@class='news-item__footer']/div[@class='news-item__footer-after-news']/p[position()=1]//span/text()", new Guid("4fb1ad7e-ee34-45b8-b81c-251d94b8ad1f") },
                    { new Guid("a170c6e0-44bd-4684-92e6-d644d10225a6"), true, "//div[@itemprop='author']/span[@itemprop='name']/text()", new Guid("77b72f9f-6883-4f7f-9a24-5aa83531a35a") },
                    { new Guid("a8dae2f3-ee5e-4f5e-a559-18869d7f24f8"), true, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']//a[@itemprop='author']//span[@itemprop='name']/text()", new Guid("23d9436f-0d7b-40e3-957a-3a019c1dc109") },
                    { new Guid("d4b3e185-c6d7-4964-a4b4-f13f7fc042db"), false, "//div[@class='author']/span[@itemprop='author']/span[@itemprop='name']/a/text()", new Guid("84135793-ab32-4867-8bf1-8147b2b3c14c") },
                    { new Guid("dc00a41a-e9b1-49ca-b25b-ded7933f8af4"), true, "//div[contains(@class, 'full-article')]/div[@class='authors-block']//span[text()='Автор']/../a/text()", new Guid("8363a541-546f-4a17-8ca3-3a6f0f4aa6c6") },
                    { new Guid("e71cc6e8-bb85-4a33-a607-08f825dc436f"), true, "//div[contains(@class, 'styles_bodyWrapper')]//div[contains(@class, 'styles_authorsLinks')]/a/text()", new Guid("f528a6df-4678-464b-9da9-97dd1b0b2fff") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_picture_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("0bf38a8f-24a6-471b-be65-206dd64c64f7"), false, new Guid("23d9436f-0d7b-40e3-957a-3a019c1dc109"), "//div[contains(@class, 'article-entry')]//div[contains(@class, 'entry-body')]//div[@class='source-wrapper']/img[@itemprop='image']/@src" },
                    { new Guid("0c7d55a2-9e84-4a0d-ab9d-bbd750ecca5a"), false, new Guid("806fa257-eca5-419d-a26e-f1b7a3dcbcb3"), "//article//header/div[@class='article-head__photo']/img/@src" },
                    { new Guid("1534c1db-64b4-446e-805d-42b738a798bc"), true, new Guid("fb5d1bb1-a8df-4edf-8e02-2d4d9e28c57f"), "//div[@class='b-material-incut-m-image']//@src" },
                    { new Guid("26111aba-b289-46db-8659-fcc4b7cc49ad"), false, new Guid("87b4be29-0d30-4a16-aa55-cfb56b544ec7"), "//div[@class='img_box']/a[@class='zoom_js']/img/@src" },
                    { new Guid("2e6e6d2a-517f-4273-bf82-aefdc4d74a9c"), false, new Guid("1b6a8118-4743-4719-85ec-fa7549f5eaa3"), "//div[@class='inner_content']//div[@class='main_img']//img/@src" },
                    { new Guid("56f5bc5e-f5dc-4f33-a8f0-13cf44f8a699"), true, new Guid("13982eaf-47d9-4d24-b9db-eb15c34e9940"), "//a[@class='glightbox']/img[contains(@class, 'pub-cover')]/@src" },
                    { new Guid("62d57242-b8ad-4db0-9f7d-4d498fc620a6"), false, new Guid("4ec5e6b4-7ba8-40c9-816f-64ed86900e53"), "//article/figure/img/@src" },
                    { new Guid("712d18a1-1b43-456b-95b9-92623aa0d24e"), false, new Guid("84135793-ab32-4867-8bf1-8147b2b3c14c"), "//div[@class='b_article-media']//div[@class='mainarea-wrapper']/figure/img[@class='item-image-front']/@src" },
                    { new Guid("7a4628eb-2e32-4813-b061-1b395020bbec"), false, new Guid("f528a6df-4678-464b-9da9-97dd1b0b2fff"), "//article//header/div[contains(@class, 'styles_cover_media')]/img/@src" },
                    { new Guid("7a590dd8-1f97-4724-b835-7ad47a4af6af"), true, new Guid("d3ff4b84-a0ff-4eb7-8ad4-9fbf56315c64"), "//div[@class='article__media']//img/@src" },
                    { new Guid("9e3fd19c-eec6-4659-8ad3-ba9967e4eb44"), true, new Guid("8a984818-6b5c-42ff-af2b-7499cce1fdd3"), "//div[contains(@class, 'big_photo')]//div[@class='big_photo__img']//img/@src" },
                    { new Guid("a813332c-13d6-49d2-a481-24bd6aef862f"), true, new Guid("77b72f9f-6883-4f7f-9a24-5aa83531a35a"), "//div[@itemprop='articleBody']//div[@itemprop='image']/picture/img[@itemprop='contentUrl']/@src" },
                    { new Guid("b1ffceab-f195-413d-b99c-7257a62b35ff"), false, new Guid("e2be7c42-b23a-4849-b382-065f32cc9da6"), "//div[contains(@class, 'HeaderMedia_image')]//img[contains(@class, 'Image_image')]/@src" },
                    { new Guid("bcc659dd-d3d3-4717-b530-e78fc2e1d510"), false, new Guid("c03dfd86-0f2e-4c0a-87d3-26d61263c773"), "//div[@class='photoview__open']/img/@src" },
                    { new Guid("cd065e66-b428-4c3b-bb32-fa52be511b44"), false, new Guid("774e9c7c-f642-465c-b93c-c2aacdf18b8f"), "//div[contains(@class, 'topic-body__title-image')]//img[contains(@class, 'picture__image')]/@src" },
                    { new Guid("e99d179c-87b7-45ed-be29-a22bc295b916"), true, new Guid("8363a541-546f-4a17-8ca3-3a6f0f4aa6c6"), "//div[contains(@class, 'full-article')]/div[contains(@class, 'gallery')]/picture/img/@src" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "published_at_culture_info", "published_at_time_zone_info_id", "published_at_x_path" },
                values: new object[,]
                {
                    { new Guid("0301c739-b3ed-49dd-81e7-3622b886223e"), true, new Guid("84393779-d9b0-44f7-a563-d44269ff77b2"), "ru-RU", null, "//div[contains(@class, 'PageArticleContent_date')]/text()" },
                    { new Guid("1110f676-3cff-40b1-bce9-f9fbf8670d6a"), true, new Guid("c03dfd86-0f2e-4c0a-87d3-26d61263c773"), "ru-RU", null, "//div[@class='article__info']//div[@class='article__info-date']/a/text()" },
                    { new Guid("239dba88-b9e9-4b43-aa6a-594e50bf792e"), true, new Guid("13982eaf-47d9-4d24-b9db-eb15c34e9940"), "ru-RU", null, "//div[contains(@class, 'publication-footer')]//div[contains(@class, 'pubdatetime')]//div[contains(@class, 'badge-time')]/text()" },
                    { new Guid("32131a26-33ac-4792-997b-67dc86bd83b9"), true, new Guid("77b72f9f-6883-4f7f-9a24-5aa83531a35a"), "ru-RU", null, "//div[@class='publication-info']/time[@itemprop='datePublished']/@datetime" },
                    { new Guid("40d198c1-49e5-441e-b861-bd353126a083"), true, new Guid("6b400ee2-13e2-4e71-b94f-a07d7a4123c8"), "ru-RU", null, "//div[@class='b-text__date']/text()" },
                    { new Guid("4a891695-2108-4830-bc76-9a5beee9b97f"), true, new Guid("e95e4af0-61c4-4706-b19f-56d0452651c3"), "ru-RU", null, "//article[@itemprop='articleBody']/meta[@itemprop='datePublished']/@content" },
                    { new Guid("4e44521b-845d-4e25-a009-f325dc624ad1"), true, new Guid("806fa257-eca5-419d-a26e-f1b7a3dcbcb3"), "ru-RU", "Russian Standard Time", "//article//header//time[@class='article-head__date']/text()" },
                    { new Guid("4e628be8-6dfe-45f4-b356-3db02a1562d2"), true, new Guid("4ec5e6b4-7ba8-40c9-816f-64ed86900e53"), "ru-RU", null, "//article/div[@class='header']/span/text()" },
                    { new Guid("640f4583-3762-4fc7-ae76-7d53013573a0"), true, new Guid("23d9436f-0d7b-40e3-957a-3a019c1dc109"), "ru-RU", null, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']/span[@itemprop='datePublished']/@content" },
                    { new Guid("6c6b89e4-1d92-41ce-b1d1-844e867b6e18"), true, new Guid("8a984818-6b5c-42ff-af2b-7499cce1fdd3"), "ru-RU", null, "//div[@class='article_page__left__top__left']//div[@class='article_page__left__top__time']//time/@datetime" },
                    { new Guid("75283542-9d51-4618-9058-a4185dfd245c"), true, new Guid("5c9d7baf-aa66-4f1d-8558-95a3508b5aa2"), "ru-RU", null, "//div[contains(@class, 'article__date-autor-shortcode')]/div[contains(@class, 'article__date')]/time[@class='date']/@datetime" },
                    { new Guid("7a54675c-ba92-4713-9b22-3c6dc984ae6c"), true, new Guid("1b6a8118-4743-4719-85ec-fa7549f5eaa3"), "ru-RU", null, "//div[@class='date_full']/text()" },
                    { new Guid("85e25ae9-ffe3-48b8-8544-23714b8e7eb6"), true, new Guid("774e9c7c-f642-465c-b93c-c2aacdf18b8f"), "ru-RU", null, "//div[@class='topic-page__header']//a[contains(@class, 'topic-header__time')]/text()" },
                    { new Guid("877ea725-9d8d-436a-ac76-2028d225a1eb"), true, new Guid("4fb1ad7e-ee34-45b8-b81c-251d94b8ad1f"), "ru-RU", null, "//header[@class='news-item__header']//time/@content" },
                    { new Guid("87d2b750-4f9c-4e8b-b28e-7d704171898e"), true, new Guid("d6374200-a1cd-46cd-9f88-14c86ab30e08"), "ru-RU", null, "//div[@class='b-article__top-author']/p[@class='date']/text()" },
                    { new Guid("a0948ee3-b602-46f1-909a-612b556846f8"), true, new Guid("e2be7c42-b23a-4849-b382-065f32cc9da6"), "ru-RU", null, "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark_publish')]//span[@ca-ts]/text()" },
                    { new Guid("c27cb571-1581-42c4-8fe8-89066e9cd97f"), true, new Guid("f528a6df-4678-464b-9da9-97dd1b0b2fff"), "ru-RU", null, "//article//header//div[contains(@class, 'styles_meta')]//div[contains(@class, 'styles_metaItem')]/text()" },
                    { new Guid("ccce8ef2-7ef6-4b9d-8b7e-7be93831931b"), true, new Guid("d3ff4b84-a0ff-4eb7-8ad4-9fbf56315c64"), "ru-RU", null, "//div[@class='article__meta']/time/text()" },
                    { new Guid("d94b949b-9e2e-455c-9132-92beb6d15c2f"), true, new Guid("f80c5aa4-3026-4657-bb2b-90533ace23c5"), "ru-RU", null, "//div[@class='article__header__info-block']/time[@class='article__header__date']/@datetime" },
                    { new Guid("e26d81af-8034-4b66-b890-14871a0aa85e"), true, new Guid("fb5d1bb1-a8df-4edf-8e02-2d4d9e28c57f"), "ru-RU", null, "//p[@class='b-material__date']/text()" },
                    { new Guid("f200c997-33a8-47d0-9d70-d668f9cded0c"), true, new Guid("87b4be29-0d30-4a16-aa55-cfb56b544ec7"), "ru-RU", null, "//div[@class='article_top']//div[@class='date']//time/text()" },
                    { new Guid("f728c9c4-46a3-406e-96ca-ff8bbefe2be8"), true, new Guid("84135793-ab32-4867-8bf1-8147b2b3c14c"), "ru-RU", null, "//article/div[@class='b_article-header']//time[@itemprop='datePublished']/@datetime" },
                    { new Guid("facc87ed-79de-4331-af38-a55e578354ce"), true, new Guid("8363a541-546f-4a17-8ca3-3a6f0f4aa6c6"), "ru-RU", null, "//div[contains(@class, 'full-article')]//time/text()" },
                    { new Guid("fd6fde86-91b2-4055-944e-df922792bccb"), true, new Guid("5ea05fa3-4d71-49e7-8467-febe303b82b9"), "ru-RU", null, "//div[@class='doc_header__time']/time[@class='doc_header__publish_time']/@datetime" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_sub_title_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("115081ae-41ef-4c7f-b515-18257f4c55c6"), false, new Guid("f528a6df-4678-464b-9da9-97dd1b0b2fff"), "//article//header//p[contains(@class, 'styles_subtitle')]/text()" },
                    { new Guid("3cec968f-e38a-4696-b2b4-659ea5212947"), false, new Guid("774e9c7c-f642-465c-b93c-c2aacdf18b8f"), "//div[contains(@class, 'topic-body__title')]/text()" },
                    { new Guid("43a31de2-1054-4477-9649-5fb5f6ac7f21"), true, new Guid("d3ff4b84-a0ff-4eb7-8ad4-9fbf56315c64"), "//div[@class='article__intro']/p/text()" },
                    { new Guid("554c8114-3fd6-46ff-9f5c-573e683411f8"), true, new Guid("8363a541-546f-4a17-8ca3-3a6f0f4aa6c6"), "//h1/text()" },
                    { new Guid("622f55a9-7202-4b4f-bc2e-14e9d2d5d3db"), true, new Guid("84135793-ab32-4867-8bf1-8147b2b3c14c"), "//h2/text()" },
                    { new Guid("77035d2e-677a-4019-b1a6-faf2d802a781"), false, new Guid("5ea05fa3-4d71-49e7-8467-febe303b82b9"), "//header[@class='doc_header']/h2[contains(@class, 'doc_header__subheader')]/text()" },
                    { new Guid("7bac4c27-7aee-4a67-8b4e-bfc4bc6b7953"), false, new Guid("e2be7c42-b23a-4849-b382-065f32cc9da6"), "//h3/text()" },
                    { new Guid("85121d0c-b193-46f3-8242-2406de66007e"), false, new Guid("4ec5e6b4-7ba8-40c9-816f-64ed86900e53"), "//h4/text()" },
                    { new Guid("a431f970-f4a9-4095-87dd-69b0c79cfacc"), true, new Guid("13982eaf-47d9-4d24-b9db-eb15c34e9940"), "//div[@class='container-fluid shifted']/p[@class='announce lead']/text()" },
                    { new Guid("a5211f77-5906-40c4-b104-36dff477f32c"), true, new Guid("c03dfd86-0f2e-4c0a-87d3-26d61263c773"), "//h1[@class='article__second-title']/text()" },
                    { new Guid("afd112bb-9b75-45e1-8cbc-f665f16e0b9e"), true, new Guid("23d9436f-0d7b-40e3-957a-3a019c1dc109"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()=1]/text()" },
                    { new Guid("d500e379-860b-47f9-86af-e11cedf814de"), false, new Guid("f80c5aa4-3026-4657-bb2b-90533ace23c5"), "//div[contains(@class, 'article__text')]/div[@class='article__text__overview']/span/text()" },
                    { new Guid("e8f7b058-106c-48b5-9525-9f149c35e1e2"), true, new Guid("5c9d7baf-aa66-4f1d-8558-95a3508b5aa2"), "//div[contains(@class, 'article__summary')]/text()" },
                    { new Guid("ede47109-eb34-47a9-aa4f-ff36f3ff3392"), false, new Guid("d6374200-a1cd-46cd-9f88-14c86ab30e08"), "//h4/text()" },
                    { new Guid("ede7cf81-c35f-48ab-9f67-36780807b79e"), false, new Guid("84393779-d9b0-44f7-a563-d44269ff77b2"), "//div[contains(@class, 'PageArticleContent_lead')]/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_published_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("05469217-b00b-4007-aa36-52bac41d0a69"), "dd MMMM yyyy, HH:mm", new Guid("7a54675c-ba92-4713-9b22-3c6dc984ae6c") },
                    { new Guid("066846f4-a1b2-4c65-851a-94004e96f768"), "dd MMMM yyyy, HH:mm", new Guid("4e628be8-6dfe-45f4-b356-3db02a1562d2") },
                    { new Guid("13b5eaf6-08d7-4e69-8bed-ba5ebef9a776"), "dd MMMM, HH:mm", new Guid("c27cb571-1581-42c4-8fe8-89066e9cd97f") },
                    { new Guid("192e3c04-28a1-4338-a790-2ae76a86b530"), "HH:mm, dd MMMM yyyy", new Guid("85e25ae9-ffe3-48b8-8544-23714b8e7eb6") },
                    { new Guid("2379a18c-579b-4954-8240-9f8c3928db3d"), "dd MMMM yyyy, HH:mm МСК", new Guid("4e44521b-845d-4e25-a009-f325dc624ad1") },
                    { new Guid("313dd5c9-4fe0-4316-b16c-346ae2c86b55"), "dd MMMM yyyy в HH:mm", new Guid("87d2b750-4f9c-4e8b-b28e-7d704171898e") },
                    { new Guid("32174a68-3272-4605-9e5d-549ca881ab5b"), "dd MMMM yyyy, HH:mm,", new Guid("a0948ee3-b602-46f1-909a-612b556846f8") },
                    { new Guid("424d1226-0511-4d53-966d-27f59a70d990"), "dd MMMM, HH:mm", new Guid("e26d81af-8034-4b66-b890-14871a0aa85e") },
                    { new Guid("4fbab705-2d48-47bb-b065-3b5121bc19f9"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("fd6fde86-91b2-4055-944e-df922792bccb") },
                    { new Guid("7329c49d-f71c-4ed9-8547-29fae97d9456"), "HH:mm dd.MM.yyyy", new Guid("1110f676-3cff-40b1-bce9-f9fbf8670d6a") },
                    { new Guid("763b667c-05b7-4fe7-8ad2-c0a7160f6ff5"), "dd MMMM yyyy, HH:mm", new Guid("e26d81af-8034-4b66-b890-14871a0aa85e") },
                    { new Guid("7a06108d-cba8-498e-be71-ec94a5552475"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("877ea725-9d8d-436a-ac76-2028d225a1eb") },
                    { new Guid("7a3ac23e-a310-4c0f-9e47-47bf76f89ab3"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("6c6b89e4-1d92-41ce-b1d1-844e867b6e18") },
                    { new Guid("7e539502-4512-4561-8675-85fa2ad4d27b"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("640f4583-3762-4fc7-ae76-7d53013573a0") },
                    { new Guid("82df79ce-2fb2-4143-abc9-4fa614abdddf"), "yyyy-MM-ddTHH:mm:ss", new Guid("4a891695-2108-4830-bc76-9a5beee9b97f") },
                    { new Guid("8b608b3f-18ac-4fbe-b8c5-32f1f5d7b5fb"), "dd.MM.yyyy HH:mm", new Guid("facc87ed-79de-4331-af38-a55e578354ce") },
                    { new Guid("8e66fb91-295a-4215-9fa5-307af4505cef"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("f728c9c4-46a3-406e-96ca-ff8bbefe2be8") },
                    { new Guid("93474fb1-b2f2-4396-adb4-7a137569d406"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("32131a26-33ac-4792-997b-67dc86bd83b9") },
                    { new Guid("9f3a76d8-ee75-4dd2-a680-68726408188d"), "yyyy-MM-dd HH:mm:ss", new Guid("239dba88-b9e9-4b43-aa6a-594e50bf792e") },
                    { new Guid("a0bbd6a1-2d74-4314-acd9-8df00f271bc3"), "dd MMMM yyyy, HH:mm", new Guid("a0948ee3-b602-46f1-909a-612b556846f8") },
                    { new Guid("b108c196-2298-450e-9493-10b1e7e71fdd"), "yyyy-MM-d HH:mm", new Guid("75283542-9d51-4618-9058-a4185dfd245c") },
                    { new Guid("bf302518-54a6-49d6-ad0e-7ccba5d99bc4"), "dd MMMM yyyy HH:mm", new Guid("ccce8ef2-7ef6-4b9d-8b7e-7be93831931b") },
                    { new Guid("cc42c4cf-7b69-4c97-bbdb-5c4864dd46ba"), "dd.MM.yyyy HH:mm", new Guid("0301c739-b3ed-49dd-81e7-3622b886223e") },
                    { new Guid("cc8f7439-034b-414d-af92-4040888a8fa8"), "dd MMMM, HH:mm,", new Guid("a0948ee3-b602-46f1-909a-612b556846f8") },
                    { new Guid("d8a7f19e-3f2a-4742-8bec-6841a3064c78"), "dd MMMM yyyy, HH:mm", new Guid("c27cb571-1581-42c4-8fe8-89066e9cd97f") },
                    { new Guid("e933a474-f9fb-4b5a-bd54-de8b8a6548b0"), "dd MMMM  HH:mm", new Guid("40d198c1-49e5-441e-b861-bd353126a083") },
                    { new Guid("ee0bd637-c250-445d-ad0e-4176ee364c23"), "dd.MM.yyyy HH:mm", new Guid("f200c997-33a8-47d0-9d70-d668f9cded0c") },
                    { new Guid("fb242f5e-85dc-4ca0-88bd-3da0b9c31eb2"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("d94b949b-9e2e-455c-9132-92beb6d15c2f") },
                    { new Guid("ff23b195-1d91-40cb-8e2a-210f26ea5448"), "dd MMMM, HH:mm", new Guid("a0948ee3-b602-46f1-909a-612b556846f8") }
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
