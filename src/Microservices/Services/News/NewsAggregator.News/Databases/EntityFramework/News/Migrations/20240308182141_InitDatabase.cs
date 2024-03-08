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
                name: "news_parse_needs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    news_url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_parse_needs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "news_parse_network_errors",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    news_url = table.Column<string>(type: "text", nullable: false),
                    message = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_parse_network_errors", x => x.id);
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
                    name = table.Column<string>(type: "text", nullable: false)
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
                    html_description_x_path = table.Column<string>(type: "text", nullable: false),
                    text_description_x_path = table.Column<string>(type: "text", nullable: false)
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
                    small = table.Column<string>(type: "text", nullable: false),
                    original = table.Column<string>(type: "text", nullable: false)
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
                    modified_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
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
                name: "news_parse_modified_at_settings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    parse_settings_id = table.Column<Guid>(type: "uuid", nullable: false),
                    modified_at_x_path = table.Column<string>(type: "text", nullable: false),
                    modified_at_culture_info = table.Column<string>(type: "text", nullable: false),
                    modified_at_time_zone_info_id = table.Column<string>(type: "text", nullable: true),
                    is_required = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_parse_modified_at_settings", x => x.id);
                    table.ForeignKey(
                        name: "fk_news_parse_modified_at_settings_news_parse_settings_parse_s",
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
                name: "news_parse_video_settings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    parse_settings_id = table.Column<Guid>(type: "uuid", nullable: false),
                    url_x_path = table.Column<string>(type: "text", nullable: false),
                    is_required = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_parse_video_settings", x => x.id);
                    table.ForeignKey(
                        name: "fk_news_parse_video_settings_news_parse_settings_parse_setting",
                        column: x => x.parse_settings_id,
                        principalTable: "news_parse_settings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "news_html_descriptions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    news_id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_html_descriptions", x => x.id);
                    table.ForeignKey(
                        name: "fk_news_html_descriptions_news_news_id",
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
                name: "news_text_descriptions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    news_id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_text_descriptions", x => x.id);
                    table.ForeignKey(
                        name: "fk_news_text_descriptions_news_news_id",
                        column: x => x.news_id,
                        principalTable: "news",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "news_videos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    news_id = table.Column<Guid>(type: "uuid", nullable: false),
                    url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_videos", x => x.id);
                    table.ForeignKey(
                        name: "fk_news_videos_news_news_id",
                        column: x => x.news_id,
                        principalTable: "news",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "news_parse_modified_at_settings_formats",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    news_parse_modified_at_settings_id = table.Column<Guid>(type: "uuid", nullable: false),
                    format = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_parse_modified_at_settings_formats", x => x.id);
                    table.ForeignKey(
                        name: "fk_news_parse_modified_at_settings_formats_news_parse_modified",
                        column: x => x.news_parse_modified_at_settings_id,
                        principalTable: "news_parse_modified_at_settings",
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
                    { new Guid("024bf66d-fae4-4678-9faf-c6a3418221e2"), true, "https://tsargrad.tv/", "Царьград" },
                    { new Guid("0e3bcbc4-0335-446f-9f55-7e5991cf323b"), true, "https://www.1obl.ru/", "Первый областной" },
                    { new Guid("120c1eb0-2091-4761-835b-2820d293e095"), true, "https://www.cybersport.ru/", "Cybersport.ru" },
                    { new Guid("16e35cc8-694b-4223-b387-2d7679636caf"), true, "https://svpressa.ru/", "СвободнаяПресса" },
                    { new Guid("1b8fc9cc-aa5b-4490-8085-c44b36fa2bb1"), true, "https://overclockers.ru/", "Overclockers" },
                    { new Guid("208d2f6b-cb35-4cc2-8a17-c6def75bef0b"), true, "https://www.pravda.ru/", "Правда.ру" },
                    { new Guid("21113e8f-1e06-466f-811c-0cfaf9536b14"), true, "https://www.avtovzglyad.ru/", "АвтоВзгляд" },
                    { new Guid("28a71c4e-f3f4-48e0-b352-b5415b68f686"), true, "https://7days.ru/", "7дней.ru" },
                    { new Guid("304a2909-9f70-454b-b6f8-d552bb100c28"), true, "https://www.nytimes.com/", "The New York Times" },
                    { new Guid("3daae37b-a18c-4b2b-8742-8aee77828cbe"), true, "https://ren.tv/", "РЕН ТВ" },
                    { new Guid("3f435341-1635-4994-bd89-eea6156d07ce"), true, "https://edition.cnn.com/", "CNN" },
                    { new Guid("4c73e64e-da0a-49ef-ac5d-8f908b186e1f"), true, "https://russian.rt.com/", "RT на русском" },
                    { new Guid("4f5d618a-69a1-4a67-b65b-b369b9134541"), true, "http://www.belta.by/", "БелТА" },
                    { new Guid("5b68725a-4307-42f5-ac89-d44e69ee8df5"), true, "https://www.sports.ru/", "Storts.ru" },
                    { new Guid("625b8a1b-7830-4127-8ab2-2d304b4662fb"), true, "https://www.zr.ru/", "Журнал \"За рулем\"" },
                    { new Guid("65aa2dc3-6a9d-4e7c-bced-c85aed22c910"), true, "https://ria.ru/", "РИА Новости" },
                    { new Guid("6947dbd1-d2b5-4732-8760-4a94e0c8879c"), true, "https://stopgame.ru/", "StopGame" },
                    { new Guid("6b0cabab-8e3c-4ff0-be6e-939e0ebf0383"), true, "https://iz.ru/", "Известия" },
                    { new Guid("6bef019c-cd42-4ab3-9fc0-b21f22726af3"), true, "https://www.novorosinform.org/", "Новороссия" },
                    { new Guid("71e2381c-c339-4ad0-a209-9d989270d2f7"), true, "https://www.championat.com/", "Чемпионат.com" },
                    { new Guid("72c7e5c0-8257-4433-b34a-cce21a656e51"), true, "https://ixbt.games/", "iXBT.games" },
                    { new Guid("77f5c742-e4ea-4b63-b516-f280268c792c"), true, "https://www.hltv.org/", "HLTV.org" },
                    { new Guid("79b4d151-f885-40ce-9669-e68fc4edb9f4"), true, "https://aif.ru/", "Аргументы и факты" },
                    { new Guid("8a89df5b-5179-4d88-a5c5-6f6ee67bb2e1"), true, "https://www.interfax.ru/", "Интерфакс" },
                    { new Guid("98aaf1f7-0053-4c0a-a92a-2cb9d5ca3940"), true, "https://3dnews.ru/", "3Dnews.ru" },
                    { new Guid("a317a7f5-6486-466d-9d3d-01d1e7272fa6"), true, "https://tass.ru/", "ТАСС" },
                    { new Guid("a562c1ba-1e31-46de-97f1-3603f971134f"), true, "https://ura.news/", "Ura.ru" },
                    { new Guid("a9fd3239-5c85-4ba7-939f-4a13a1f13360"), true, "https://www.gazeta.ru/", "Газета.Ru" },
                    { new Guid("aef5f837-723b-46f6-8fbb-23c6d676fc41"), true, "https://www.kp.ru/", "Комсомольская правда" },
                    { new Guid("c19d353c-6129-41a4-aef3-f18129dd3803"), true, "https://www.kinonews.ru/", "KinoNews.ru" },
                    { new Guid("cb4a20e5-59bb-4cee-bd0b-86f8cf1a9caa"), true, "https://www.m24.ru/", "Москва 24" },
                    { new Guid("cdae94d1-c386-4457-8ff9-d1970517bf8a"), true, "https://www.ixbt.com/", "iXBT.com" },
                    { new Guid("d109ba65-70d8-41c2-b224-b4cc94063f23"), true, "https://rg.ru/", "Российская газета" },
                    { new Guid("d8ec020f-0f6f-4899-bf8c-1b5bb85f1850"), true, "https://lenta.ru/", "Лента.Ру" },
                    { new Guid("dd441e77-8357-4e8d-94ab-1decab475028"), true, "https://www.starhit.ru/", "Сетевое издание «Онлайн журнал StarHit (СтарХит)" },
                    { new Guid("e029682f-be30-49c0-8073-b247510ee1e9"), true, "https://www.kommersant.ru/", "Коммерсантъ" },
                    { new Guid("e90e1b86-f3fe-46eb-be7e-70406402ffed"), true, "https://www.rbc.ru/", "РБК" },
                    { new Guid("ead50a5e-f82a-47ea-91ec-9f979ffda913"), true, "https://life.ru/", "Life" },
                    { new Guid("f8209327-2505-411c-aa34-43c121d2e6a9"), true, "https://74.ru/", "74.ru" },
                    { new Guid("fdafb795-5097-4fc1-ae29-afa7cba95c6f"), true, "https://vz.ru/", "ВЗГЛЯД.РУ" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_settings",
                columns: new[] { "id", "html_description_x_path", "source_id", "text_description_x_path", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("09bab5dc-85be-4de4-b367-a25873e0d234"), "//div[contains(@class, 'news-item__content')]", new Guid("5b68725a-4307-42f5-ac89-d44e69ee8df5"), "//div[contains(@class, 'news-item__content')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("0e457f7a-e5f5-4760-bf44-c4f9f1e577c1"), "//article/*", new Guid("a317a7f5-6486-466d-9d3d-01d1e7272fa6"), "//article/*//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("1a1f7948-4616-418b-8bb0-6e1aac8f8479"), "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]", new Guid("cb4a20e5-59bb-4cee-bd0b-86f8cf1a9caa"), "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("1da16ea7-d5e7-4335-8da3-4e7b9e1e1b19"), "//article//div[@class='newstext-con']/*[position()>2]", new Guid("77f5c742-e4ea-4b63-b516-f280268c792c"), "//article//div[@class='newstext-con']/*[position()>2]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("1f825d8f-d379-44bc-8cac-c98e31ae9c92"), "//section[@name='articleBody']/*", new Guid("304a2909-9f70-454b-b6f8-d552bb100c28"), "//section[@name='articleBody']/*//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("26a8493d-b4c3-42ad-ba39-47f1b1305eb4"), "//div[contains(@class, 'material-content')]/*", new Guid("1b8fc9cc-aa5b-4490-8085-c44b36fa2bb1"), "//div[contains(@class, 'material-content')]/p//text()", "//a[@class='header']/text()" },
                    { new Guid("27667d0d-aad5-4f71-8381-06fe749ab003"), "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]", new Guid("8a89df5b-5179-4d88-a5c5-6f6ee67bb2e1"), "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("3263bfd3-30cf-46ed-922c-cf67945673db"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]", new Guid("024bf66d-fae4-4678-9faf-c6a3418221e2"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("359ded84-b968-4056-ba91-28dc661f5e83"), "//div[contains(@class, 'article__text ')]", new Guid("4c73e64e-da0a-49ef-ac5d-8f908b186e1f"), "//div[contains(@class, 'article__text ')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("44535c6f-e113-42fc-aa5b-fa8b9f5e2616"), "//section[@itemprop='articleBody']/*", new Guid("21113e8f-1e06-466f-811c-0cfaf9536b14"), "//section[@itemprop='articleBody']/*[not(name()='script')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("448d8fc1-481a-461a-a69b-987fc0c45065"), "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]", new Guid("16e35cc8-694b-4223-b387-2d7679636caf"), "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("5dba0bd0-af79-4e68-accb-56edeab32824"), "//div[@itemprop='articleBody']/*[not(name()='figure' and position()=1)]", new Guid("f8209327-2505-411c-aa34-43c121d2e6a9"), "//div[@itemprop='articleBody']/*[not(name()='figure') and not(lazyhydrate)]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("65975b6b-9d0d-424d-b175-62f993dd50a3"), "//div[@class='widgets__item__text__inside']/*", new Guid("3daae37b-a18c-4b2b-8742-8aee77828cbe"), "//div[@class='widgets__item__text__inside']//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("6653304f-d205-448c-aa38-759cdf6626d3"), "//article/div[@class='news_text']", new Guid("fdafb795-5097-4fc1-ae29-afa7cba95c6f"), "//article/div[@class='news_text']//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("6998cc17-8709-4c06-9880-afa48c46f9c0"), "//div[@class='only__text']/*", new Guid("6bef019c-cd42-4ab3-9fc0-b21f22726af3"), "//div[@class='only__text']/*[not(name()='script')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("6aefd5c6-b2d1-4bee-8a4b-ce1f37add4b1"), "//div[contains(@class, 'styled__StoryBody')]/*[not(name()='p' and contains(@class, 'styled__StoryParagraph') and position()=1) and not(name()='div' and contains(@class, 'styled__StoryImgContainer') and position()=2)]", new Guid("625b8a1b-7830-4127-8ab2-2d304b4662fb"), "//div[contains(@class, 'styled__StoryBody')]/*[not(name()='p' and contains(@class, 'styled__StoryParagraph') and position()=1) and not(name()='div' and contains(@class, 'styled__StoryImgContainer') and position()=2)]//text()", "//meta[@name='og:title']/@content" },
                    { new Guid("6fc6a863-f0d8-46b6-b0ad-2d2442877c5c"), "//section[contains(@class, '_page-section')]/div[contains(@class, '_content_')]/*", new Guid("6947dbd1-d2b5-4732-8760-4a94e0c8879c"), "//section[contains(@class, '_page-section')]/div[contains(@class, '_content_')]/*[contains(@class, '_text_')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("6feaf29f-abc6-40a0-b67b-a97aa3168517"), "//div[@class='material-7days__paragraf-content']/*[not(name()='div' and @itemprop='image' and position()=1)]", new Guid("28a71c4e-f3f4-48e0-b352-b5415b68f686"), "//div[@class='material-7days__paragraf-content']//p//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("73796890-1148-4579-bb51-4f7f8a58a358"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview')) and not(contains(@class, 'article__main-image'))]", new Guid("e90e1b86-f3fe-46eb-be7e-70406402ffed"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview')) and not(contains(@class, 'article__main-image'))]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("74740f98-e16f-4a19-a912-f55599ac11cf"), "//div[contains(@class, 'js-mediator-article')]/*[position()>1]", new Guid("120c1eb0-2091-4761-835b-2820d293e095"), "//div[contains(@class, 'js-mediator-article')]/*[position()>1]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("7a605ab8-2b62-4eac-8b1b-6d28c6a21383"), "//div[@class='topic-body__content']", new Guid("d8ec020f-0f6f-4899-bf8c-1b5bb85f1850"), "//div[@class='topic-body__content']//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("7deef4e3-16c2-4772-9379-4582ba8ffbad"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/*[position()>4]", new Guid("98aaf1f7-0053-4c0a-a92a-2cb9d5ca3940"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/*[position()>4 and not(name()='script')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("81307884-8826-4760-a010-b565004590c9"), "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]", new Guid("ead50a5e-f82a-47ea-91ec-9f979ffda913"), "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("8cf9d9f2-e41d-44de-ac63-22b1e11070a8"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]", new Guid("e029682f-be30-49c0-8073-b247510ee1e9"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("981978b4-413a-4340-b808-29b97ebd86db"), "//div[@itemprop='articleBody']/*", new Guid("3f435341-1635-4994-bd89-eea6156d07ce"), "//div[@itemprop='articleBody']/*//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("9922640b-8132-4151-9ee0-db9829ac19fd"), "//div[@itemprop='articleBody']/*", new Guid("0e3bcbc4-0335-446f-9f55-7e5991cf323b"), "//div[@itemprop='articleBody']/*//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("9974031e-0bf9-4d8f-8ee8-3254089a88a9"), "//div[contains(@class, 'container-fluid shifted') and not(p[@class='announce lead']) and not(h1) and not(hr)]", new Guid("72c7e5c0-8257-4433-b34a-cce21a656e51"), "//div[contains(@class, 'container-fluid shifted') and not(p[@class='announce lead']) and not(h1) and not(hr)]//text()", "//meta[@name='og:title']/@content" },
                    { new Guid("a97f39cb-d3a5-44cf-bf61-f47642205679"), "//article/div[@class='article-content']/*[not(@class)]", new Guid("71e2381c-c339-4ad0-a209-9d989270d2f7"), "//article/div[@class='article-content']/*[not(@class)]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("ac148104-b6f5-4630-817a-d4786dd9e04b"), "//div[@class='article_text']", new Guid("79b4d151-f885-40ce-9669-e68fc4edb9f4"), "//div[@class='article_text']//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("b623d45b-6588-47bf-8c3b-fd31ee726fdc"), "//div[@class='textart']/div[not(@class)]/*", new Guid("c19d353c-6129-41a4-aef3-f18129dd3803"), "//div[@class='textart']/div[not(@class)]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("bc5ec3a6-867e-44a8-938a-00da5abe6d8c"), "//div[@itemprop='articleBody']/*", new Guid("6b0cabab-8e3c-4ff0-be6e-939e0ebf0383"), "//div[@itemprop='articleBody']//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("c60d2d6e-50cd-4ea5-941b-fc7382f3c4af"), "//div[@itemprop='articleBody']/*[position()>2]", new Guid("cdae94d1-c386-4457-8ff9-d1970517bf8a"), "//div[@itemprop='articleBody']/*[position()>2]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("cdd2103e-e1ef-47eb-989b-7c52e43727df"), "//div[contains(@class, 'article__body')]", new Guid("65aa2dc3-6a9d-4e7c-bced-c85aed22c910"), "//div[contains(@class, 'article__body')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("d8700826-685f-413e-9324-53509bcb7507"), "//div[@itemprop='articleBody']/*", new Guid("a9fd3239-5c85-4ba7-939f-4a13a1f13360"), "//div[@itemprop='articleBody']/*//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("dff850f5-6d5e-4c06-b22d-fe7c9fa22f92"), "//div[@class='js-mediator-article']", new Guid("4f5d618a-69a1-4a67-b65b-b369b9134541"), "//div[@class='js-mediator-article']//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("e47fa173-4329-47ea-a14c-f391be2c29d8"), "//div[contains(@class, 'PageContentCommonStyling_text')]/*[not(name() = 'rg-video')]", new Guid("d109ba65-70d8-41c2-b224-b4cc94063f23"), "//div[contains(@class, 'PageContentCommonStyling_text')]/*[not(name() = 'rg-video')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("edc56c97-8950-497b-8d45-731f571aa949"), "//section[@itemprop='articleBody']/div[@class='ds-article-content-block-and-creative-container' and position()>1]", new Guid("dd441e77-8357-4e8d-94ab-1decab475028"), "//section[@itemprop='articleBody']/div[@class='ds-article-content-block-and-creative-container' and position()>1]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("f3887ff4-881c-4db3-92a4-95c9d0a9e0be"), "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]", new Guid("208d2f6b-cb35-4cc2-8a17-c6def75bef0b"), "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]//text()", "//meta[@name='title']/@content" },
                    { new Guid("f6c5d879-e7a7-4467-9d97-17d82d2bb9f7"), "//div[@data-gtm-el='content-body']/*[not(name()='div' and @data-wide='true')]", new Guid("aef5f837-723b-46f6-8fbb-23c6d676fc41"), "//div[@data-gtm-el='content-body']/*[not(name()='div' and @data-wide='true')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("fe6dd38b-cc58-4cbd-8431-f8a97d4cb5cc"), "//div[@itemprop='articleBody']/*[not(name()='div')]", new Guid("a562c1ba-1e31-46de-97f1-3603f971134f"), "//div[@itemprop='articleBody']/*[not(name()='div')]//text()", "//meta[@property='og:title']/@content" }
                });

            migrationBuilder.InsertData(
                table: "news_search_settings",
                columns: new[] { "id", "news_site_url", "news_url_x_path", "source_id" },
                values: new object[,]
                {
                    { new Guid("06f85c2c-6a88-4eea-8175-223738939aa3"), "https://rg.ru/", "//a[contains(@href, '.html')]/@href", new Guid("d109ba65-70d8-41c2-b224-b4cc94063f23") },
                    { new Guid("0caf9ba0-a112-4300-a7f6-9aa81c348c32"), "https://ixbt.games/news/", "//a[@class='card-link']/@href", new Guid("72c7e5c0-8257-4433-b34a-cce21a656e51") },
                    { new Guid("0d3963b7-5565-478a-a30c-e80e52587707"), "https://www.championat.com/news/1.html?utm_source=button&utm_medium=news", "//a[contains(@href, 'news-') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("71e2381c-c339-4ad0-a209-9d989270d2f7") },
                    { new Guid("0e7220f1-81b7-4efd-9613-239a8c88cae0"), "https://www.sports.ru/news/", "//a[contains(@href, '.html') and not(contains(@href, '.html#comments')) and not (contains(@href, '/blogs/'))]/@href", new Guid("5b68725a-4307-42f5-ac89-d44e69ee8df5") },
                    { new Guid("114a6a12-fdb5-4e7d-82da-9b5e2ae3a0fc"), "https://74.ru/", "//a[starts-with(@href, '/text/') and not(contains(@href, '?')) and not(contains(@href, 'comments/')) and not(@href='/text/')]/@href", new Guid("f8209327-2505-411c-aa34-43c121d2e6a9") },
                    { new Guid("18388439-0b88-404e-b613-372d6644ea3f"), "https://www.kommersant.ru/", "//a[contains(@href, '/doc/') and contains(@href, '?from=')]/@href", new Guid("e029682f-be30-49c0-8073-b247510ee1e9") },
                    { new Guid("305b12b2-1562-4ea9-a4cd-1206ba218152"), "https://www.nytimes.com/", "//a[contains(@href, '.html')]/@href", new Guid("304a2909-9f70-454b-b6f8-d552bb100c28") },
                    { new Guid("3f75b2d8-b9a6-4af1-b5be-512c2557ed1f"), "https://vz.ru/", "//a[contains(@href, '.html') and not(contains(@href, '#comments')) and not(contains(@href, '?')) and not(contains(@href, '/about/'))]/@href", new Guid("fdafb795-5097-4fc1-ae29-afa7cba95c6f") },
                    { new Guid("4103e31c-70fa-45ec-9d5e-acf26e82dcc1"), "https://www.novorosinform.org/", "//a[contains(@href, '.html')]/@href", new Guid("6bef019c-cd42-4ab3-9fc0-b21f22726af3") },
                    { new Guid("41955614-d1fd-4d71-8ec0-6423c60de844"), "https://stopgame.ru/news", "//div[contains(@class, 'list-view')]//div[contains(@class, '_card')]/a/@href", new Guid("6947dbd1-d2b5-4732-8760-4a94e0c8879c") },
                    { new Guid("4717d66f-f08a-4dc2-96c4-a766e0576097"), "https://ura.news/", "//a[contains(@href, '/news/')]/@href", new Guid("a562c1ba-1e31-46de-97f1-3603f971134f") },
                    { new Guid("50b57ded-038c-4fb3-99c2-191e381955ba"), "https://www.kp.ru/", "//a[contains(@href, '/news/')]/@href", new Guid("aef5f837-723b-46f6-8fbb-23c6d676fc41") },
                    { new Guid("532895ee-390e-4dc6-b82f-38ff5d07d420"), "https://tass.ru/", "//a[contains(@class, 'tass_pkg_link-v5WdK') and contains(substring(@href, 2), '/') and not(contains(@href, '/spec/')) and not(contains(@href, 'spec.tass.ru'))]/@href", new Guid("a317a7f5-6486-466d-9d3d-01d1e7272fa6") },
                    { new Guid("55bf0b06-f8d1-4cb1-8bba-3e01b9bd942e"), "https://overclockers.ru/news", "//div[contains(@class, 'event')]//a[not(contains(@href, '#comments'))]/@href", new Guid("1b8fc9cc-aa5b-4490-8085-c44b36fa2bb1") },
                    { new Guid("5a42b565-cc4a-444c-a777-de3ac24f1891"), "https://7days.ru/news/", "//a[contains(@class, '7days__item_href') and starts-with(@href, '/news/')]/@href", new Guid("28a71c4e-f3f4-48e0-b352-b5415b68f686") },
                    { new Guid("64d72e6b-4346-4726-aa24-a55113a9e534"), "https://aif.ru/", "//span[contains(@class, 'item_text__title')]/../@href", new Guid("79b4d151-f885-40ce-9669-e68fc4edb9f4") },
                    { new Guid("65517110-a0d7-491e-b14a-234dffe65604"), "https://www.avtovzglyad.ru/news/", "//a[@class='news-card__link']/@href", new Guid("21113e8f-1e06-466f-811c-0cfaf9536b14") },
                    { new Guid("6560579d-f922-4c0f-a811-764d95d0663f"), "https://www.m24.ru/", "//a[contains(@href, '/news/')]/@href", new Guid("cb4a20e5-59bb-4cee-bd0b-86f8cf1a9caa") },
                    { new Guid("661c61f6-0f69-49b2-9005-dee2a38a67b1"), "https://lenta.ru/", "//a[starts-with(@href, '/news/')]/@href", new Guid("d8ec020f-0f6f-4899-bf8c-1b5bb85f1850") },
                    { new Guid("6c5d7339-230b-49a9-867f-25f15b8255e5"), "https://tsargrad.tv/", "//a[contains(@class, 'news-item__link')]/@href", new Guid("024bf66d-fae4-4678-9faf-c6a3418221e2") },
                    { new Guid("71d7f89e-ec96-44fe-81b6-1c81d3dc8c73"), "https://edition.cnn.com/", "//a[contains(@href, '.html')]/@href", new Guid("3f435341-1635-4994-bd89-eea6156d07ce") },
                    { new Guid("7dca8219-2a58-42dc-8b5c-9e342580c5be"), "https://russian.rt.com/", "//a[contains(@class, 'link') and contains(@href, 'news/')]/@href", new Guid("4c73e64e-da0a-49ef-ac5d-8f908b186e1f") },
                    { new Guid("8dcc9bef-1d34-450d-97e4-34b4b98399c7"), "https://svpressa.ru/all/news/", "//a[contains(@href, '/news/') and not(contains(@href, '?')) and not(starts-with(@href, '/all/news/'))]/@href", new Guid("16e35cc8-694b-4223-b387-2d7679636caf") },
                    { new Guid("8e3b3276-eeb6-419c-8e62-b88886ff9c8b"), "https://www.cybersport.ru/", "//a[contains(@href, '/tags/')]/@href", new Guid("120c1eb0-2091-4761-835b-2820d293e095") },
                    { new Guid("995cfae1-9a74-4bac-a925-ac29d5750122"), "https://www.interfax.ru/", "//div[@class='timeline']//a[@tabindex=5]/@href", new Guid("8a89df5b-5179-4d88-a5c5-6f6ee67bb2e1") },
                    { new Guid("a8ef0a94-9582-40b4-a8b8-d4a67d47f076"), "https://www.pravda.ru/", "//a[contains(@href, '/news/') and not(@href='https://www.pravda.ru/news/')]/@href", new Guid("208d2f6b-cb35-4cc2-8a17-c6def75bef0b") },
                    { new Guid("aa25c2a2-3359-4d48-9a20-0213959bc84e"), "https://life.ru/s/novosti", "//a[contains(@href, '/p/')]/@href", new Guid("ead50a5e-f82a-47ea-91ec-9f979ffda913") },
                    { new Guid("b0bd783a-5b73-4e4a-9629-cdd4f99f38a6"), "https://www.rbc.ru/", "//a[contains(@href, 'https://www.rbc.ru/') and contains(@href, '?from=')]/@href", new Guid("e90e1b86-f3fe-46eb-be7e-70406402ffed") },
                    { new Guid("ca8fdb2c-a8dc-4ba7-9ad3-97208215f233"), "https://www.ixbt.com/news/", "//a[starts-with(@href, '/news/') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("cdae94d1-c386-4457-8ff9-d1970517bf8a") },
                    { new Guid("d25c52b9-d9fc-4769-bc4b-46c7c153cc5e"), "https://ria.ru/", "//a[contains(@class, 'cell-list__item-link')]/@href", new Guid("65aa2dc3-6a9d-4e7c-bced-c85aed22c910") },
                    { new Guid("d6b4a082-5914-4b55-a708-bc6c634b8763"), "https://www.hltv.org/", "//a[contains(@href, '/news/')]/@href", new Guid("77f5c742-e4ea-4b63-b516-f280268c792c") },
                    { new Guid("da7bd550-7798-49cf-b788-54247e1ee703"), "https://www.kinonews.ru/news/", "//a[contains(@href, '/news_') and not(contains(@href, 'comments')) and not(contains(@href, 'news_p'))]/@href", new Guid("c19d353c-6129-41a4-aef3-f18129dd3803") },
                    { new Guid("de63a991-961e-4340-8ab1-45f399111175"), "http://www.belta.by/", "//a[contains(@href, 'www.belta.by') and contains(@href, '/view/')]/@href", new Guid("4f5d618a-69a1-4a67-b65b-b369b9134541") },
                    { new Guid("de6c773c-768b-43b7-8bdb-f246fdc221b1"), "https://iz.ru/news/", "//a[contains(@href, '?main_click')]/@href", new Guid("6b0cabab-8e3c-4ff0-be6e-939e0ebf0383") },
                    { new Guid("ea547525-d6b8-4bdd-a30e-333bf9e03091"), "https://www.1obl.ru/news/", "//a[starts-with(@href, '/news/') and not(contains(@href, '?'))]/@href", new Guid("0e3bcbc4-0335-446f-9f55-7e5991cf323b") },
                    { new Guid("edb40ade-1f22-4f42-bb9c-b20eba0f20a1"), "https://www.gazeta.ru/news/", "//a[contains(@href, '/news/') and contains(@href, '.shtml') and not(contains(@href, '?'))]/@href", new Guid("a9fd3239-5c85-4ba7-939f-4a13a1f13360") },
                    { new Guid("f3deb8d6-2b01-4a17-8cc1-d5fa2a5512c4"), "https://3dnews.ru/news/", "//div[@class='news-feed-all']//a[@class='entry-header']/h1/../@href", new Guid("98aaf1f7-0053-4c0a-a92a-2cb9d5ca3940") },
                    { new Guid("f93a690b-17b1-4928-ab93-6b3dcc98ce1f"), "https://www.starhit.ru/novosti/", "//a[@class='announce-inline-tile__label-container']/@href", new Guid("dd441e77-8357-4e8d-94ab-1decab475028") },
                    { new Guid("fc80a443-246b-4596-9984-ac3d1bcf09ee"), "https://ren.tv/news/", "//a[starts-with(@href, '/news/')]/@href", new Guid("3daae37b-a18c-4b2b-8742-8aee77828cbe") },
                    { new Guid("fe37c961-096b-4cde-937f-67b90e762d92"), "https://www.zr.ru/news/", "//a[contains(@href, '/news/') and not(starts-with(@href, '/news/')) and not(starts-with(@href, 'https://'))]/@href", new Guid("625b8a1b-7830-4127-8ab2-2d304b4662fb") }
                });

            migrationBuilder.InsertData(
                table: "news_source_logos",
                columns: new[] { "id", "original", "small", "source_id" },
                values: new object[,]
                {
                    { new Guid("08baef7f-dab0-454e-8685-7dc4552c81d0"), "https://tass.ru/favicon/180.svg", "https://tass.ru/favicon/57.png", new Guid("a317a7f5-6486-466d-9d3d-01d1e7272fa6") },
                    { new Guid("09cc90b2-bc59-4e8f-a149-5c798b4fd36c"), "https://overclockers.ru/assets/apple-touch-icon-120x120.png", "https://overclockers.ru/assets/apple-touch-icon.png", new Guid("1b8fc9cc-aa5b-4490-8085-c44b36fa2bb1") },
                    { new Guid("09d7a3b3-ff4e-49fc-af27-c3ec4a1f159f"), "https://st.championat.com/i/favicon/apple-touch-icon.png", "https://st.championat.com/i/favicon/favicon-32x32.png", new Guid("71e2381c-c339-4ad0-a209-9d989270d2f7") },
                    { new Guid("0c2609ed-b46a-4aac-8733-9fb2bb61ebed"), "https://www.1obl.ru/apple-touch-icon.png", "https://www.1obl.ru/favicon-32x32.png", new Guid("0e3bcbc4-0335-446f-9f55-7e5991cf323b") },
                    { new Guid("123913c6-6a63-4d0b-9712-28f24fae970b"), "https://www.ixbt.com/favicon.ico", "https://www.ixbt.com/favicon.ico", new Guid("cdae94d1-c386-4457-8ff9-d1970517bf8a") },
                    { new Guid("1669d569-4178-4fa2-968c-a157e4de7691"), "https://svpressa.ru/favicon-96x96.png?v=1471426270000", "https://svpressa.ru/favicon-32x32.png?v=1471426270000", new Guid("16e35cc8-694b-4223-b387-2d7679636caf") },
                    { new Guid("167e9554-da0b-42bb-aa14-c0ebbd058beb"), "https://www.zr.ru/favicons/safari-pinned-tab.svg", "https://www.zr.ru/favicons/favicon.ico", new Guid("625b8a1b-7830-4127-8ab2-2d304b4662fb") },
                    { new Guid("207c49f6-edac-4794-9932-220595b4c872"), "https://s01.stc.yc.kpcdn.net/s0/2.1.321/adaptive/favicon-128.png", "https://s01.stc.yc.kpcdn.net/s0/2.1.321/adaptive/favicon-32.png", new Guid("aef5f837-723b-46f6-8fbb-23c6d676fc41") },
                    { new Guid("390b0985-a03f-4d63-8bef-9174dbee70c3"), "https://cdnstatic.rg.ru/images/touch-icon-ipad-retina_512x512.png", "https://rg.ru/favicon.ico", new Guid("d109ba65-70d8-41c2-b224-b4cc94063f23") },
                    { new Guid("3a4edd11-2918-48ed-b68d-5ee12da0b0e5"), "https://static.ngs.ru/jtnews/dist/static/favicons/apple/apple-favicon-74-180.png", "https://static.ngs.ru/jtnews/dist/static/favicons/favicon-rugion-32.ico", new Guid("f8209327-2505-411c-aa34-43c121d2e6a9") },
                    { new Guid("3ab14189-5e83-42e1-ab9a-43db2fd5e11f"), "https://cdn.iz.ru/profiles/portal/themes/purple/images/favicons/android-icon-192x192.png", "https://cdn.iz.ru/profiles/portal/themes/purple/images/favicons/favicon-32x32.png", new Guid("6b0cabab-8e3c-4ff0-be6e-939e0ebf0383") },
                    { new Guid("3f5d4eca-781b-471b-9fce-a49769d63357"), "https://stopgame.ru/favicon_512.png", "https://stopgame.ru/favicon.ico", new Guid("6947dbd1-d2b5-4732-8760-4a94e0c8879c") },
                    { new Guid("40a5db2a-9531-4173-964b-5ccf97c5ad1f"), "https://www.sports.ru/apple-touch-icon-1024.png", "https://www.sports.ru/apple-touch-icon-76.png", new Guid("5b68725a-4307-42f5-ac89-d44e69ee8df5") },
                    { new Guid("4624633a-e872-4eb9-b50d-d8aa65b1111f"), "https://vz.ru/apple-touch-icon.png", "https://vz.ru/static/images/favicon.ico", new Guid("fdafb795-5097-4fc1-ae29-afa7cba95c6f") },
                    { new Guid("495194af-89f3-4ce9-97f8-4df02548bf7d"), "https://im.kommersant.ru/ContentFlex/images/favicons2020/apple-touch-icon-180.png", "https://im.kommersant.ru/ContentFlex/images/favicons2020/favicon-32.png", new Guid("e029682f-be30-49c0-8073-b247510ee1e9") },
                    { new Guid("4bdf8246-abb6-47da-9ebb-7874ebbaf456"), "https://ren.tv/apple-touch-icon.png", "https://ren.tv/favicon-32x32.png", new Guid("3daae37b-a18c-4b2b-8742-8aee77828cbe") },
                    { new Guid("50ca78be-6688-4b74-897f-e4e027c4b5d2"), "https://s.rbk.ru/v10_rbcnews_static/common/common-10.10.120/images/android-chrome-512x512.png", "https://s.rbk.ru/v10_rbcnews_static/common/common-10.10.120/images/favicon.png", new Guid("e90e1b86-f3fe-46eb-be7e-70406402ffed") },
                    { new Guid("539a4ccc-ede2-4119-ac8a-c5a57ee60940"), "https://tsargrad.tv/favicons/apple-touch-icon-180x180.png?s2", "https://tsargrad.tv/favicons/favicon-32x32.png?s2", new Guid("024bf66d-fae4-4678-9faf-c6a3418221e2") },
                    { new Guid("573ab60a-a3f4-4734-966a-ffd5dc7ac61d"), "https://www.hltv.org/img/static/favicon/apple-touch-icon.png", "https://www.hltv.org/img/static/favicon/favicon-32x32.png", new Guid("77f5c742-e4ea-4b63-b516-f280268c792c") },
                    { new Guid("6e870068-b9b3-4cca-a10e-f544ae3e4fdb"), "https://3dnews.ru/assets/images/3dnews_logo_soc.png", "https://3dnews.ru/assets/3dnews_logo_color.png", new Guid("98aaf1f7-0053-4c0a-a92a-2cb9d5ca3940") },
                    { new Guid("7600e17e-3aa8-40c5-9675-de4e4a4a0c8a"), "https://www.novorosinform.org/favicon.ico?v3", "https://www.novorosinform.org/favicon.ico?v3", new Guid("6bef019c-cd42-4ab3-9fc0-b21f22726af3") },
                    { new Guid("786ce99e-6aa2-4a1c-876a-db74d7fcefcb"), "https://aif.ru/img/icon/apple-touch-icon.png?44f", "https://aif.ru/img/icon/favicon-32x32.png?44f", new Guid("79b4d151-f885-40ce-9669-e68fc4edb9f4") },
                    { new Guid("7c21aa32-a9c5-40ad-bed6-a17453011de5"), "https://icdn.lenta.ru/images/icons/icon-256x256.png", "https://icdn.lenta.ru/favicon.ico", new Guid("d8ec020f-0f6f-4899-bf8c-1b5bb85f1850") },
                    { new Guid("83fc3d2d-222f-4b43-8b06-8cd661a329dc"), "https://life.ru/appletouch/apple-icon-180%D1%85180.png", "https://life.ru/favicon-32%D1%8532.png", new Guid("ead50a5e-f82a-47ea-91ec-9f979ffda913") },
                    { new Guid("866cbbeb-2d30-4f29-b86f-355f17f528c9"), "https://www.nytimes.com/vi-assets/static-assets/apple-touch-icon-28865b72953380a40aa43318108876cb.png", "https://www.nytimes.com/vi-assets/static-assets/ios-default-homescreen-57x57-dark-b395ebcad5b63aff9285aab58e31035e.png", new Guid("304a2909-9f70-454b-b6f8-d552bb100c28") },
                    { new Guid("8df6e52a-0eb9-4722-8574-899212b39af7"), "https://edition.cnn.com/media/sites/cnn/apple-touch-icon.png", "https://edition.cnn.com/media/sites/cnn/favicon.ico", new Guid("3f435341-1635-4994-bd89-eea6156d07ce") },
                    { new Guid("a85f8fdf-29ee-4337-a21e-96c9e3e7afd1"), "https://www.cybersport.ru/favicon-192x192.png", "https://www.cybersport.ru/favicon-32x32.png", new Guid("120c1eb0-2091-4761-835b-2820d293e095") },
                    { new Guid("bbc66922-09bb-47f9-96d6-528beeb35f50"), "https://ura.news/apple-touch-icon.png", "https://s.ura.news/favicon.ico?3", new Guid("a562c1ba-1e31-46de-97f1-3603f971134f") },
                    { new Guid("be092ea7-5058-41d3-aee8-5bc523654737"), "https://www.kinonews.ru/favicon.ico", "https://www.kinonews.ru/favicon.ico", new Guid("c19d353c-6129-41a4-aef3-f18129dd3803") },
                    { new Guid("bff37233-9098-4360-ba69-fa6fb84adb8a"), "https://7days.ru/android-icon-192x192.png", "https://7days.ru/favicon-32x32.png", new Guid("28a71c4e-f3f4-48e0-b352-b5415b68f686") },
                    { new Guid("c01f8379-8866-4a69-8ab5-e86cfc6e3a03"), "https://cdnn21.img.ria.ru/i/favicons/favicon.svg", "https://cdnn21.img.ria.ru/i/favicons/favicon.ico", new Guid("65aa2dc3-6a9d-4e7c-bced-c85aed22c910") },
                    { new Guid("c46a153f-ca7b-45d0-a603-8dea495fd21e"), "https://static.gazeta.ru/nm2021/img/icons/favicon.svg", "https://static.gazeta.ru/nm2021/img/icons/favicon.svg", new Guid("a9fd3239-5c85-4ba7-939f-4a13a1f13360") },
                    { new Guid("ce61ff3e-f980-4ed1-9b2c-df69e8941f4b"), "https://cdn.hsmedia.ru/public/favicon/starhit/apple-touch-icon.png", "https://cdn.hsmedia.ru/public/favicon/starhit/favicon.png", new Guid("dd441e77-8357-4e8d-94ab-1decab475028") },
                    { new Guid("dbe09cfe-274a-4793-a481-d719a2f70ee7"), "https://www.pravda.ru/pix/apple-touch-icon.png", "https://www.pravda.ru/favicon.ico", new Guid("208d2f6b-cb35-4cc2-8a17-c6def75bef0b") },
                    { new Guid("debfa3f1-9d85-45fe-927e-4a61928cce2a"), "https://www.belta.by/images/storage/banners/000016_a133e848cb2e7b1debb7102d19e4d139_work.svg", "https://www.belta.by/images/storage/banners/000016_a133e848cb2e7b1debb7102d19e4d139_work.svg", new Guid("4f5d618a-69a1-4a67-b65b-b369b9134541") },
                    { new Guid("dfa4e78a-fd78-4635-b5a4-251a3b375509"), "https://ixbt.games/images/favicon/gt/apple-touch-icon.png", "https://ixbt.games/images/favicon/gt/apple-touch-icon.png", new Guid("72c7e5c0-8257-4433-b34a-cce21a656e51") },
                    { new Guid("e194a4c8-4f8b-4faf-9e61-57d29cd7e551"), "https://www.m24.ru/img/fav/apple-touch-icon.png", "https://www.m24.ru/img/fav/favicon-32x32.png", new Guid("cb4a20e5-59bb-4cee-bd0b-86f8cf1a9caa") },
                    { new Guid("e6935012-7f61-49e1-949f-f17eefc9a621"), "https://russian.rt.com/static/blocks/touch-icon/apple-touch-icon-144x144-precomposed.png", "https://russian.rt.com/favicon.ico", new Guid("4c73e64e-da0a-49ef-ac5d-8f908b186e1f") },
                    { new Guid("f322fe73-212e-44fc-8e07-90456fe30c3c"), "https://www.interfax.ru/touch-icon-ipad-retina.png", "https://www.interfax.ru/touch-icon-iphone.png", new Guid("8a89df5b-5179-4d88-a5c5-6f6ee67bb2e1") },
                    { new Guid("fa661941-e02e-464d-9224-a2fa4fa3dae9"), "https://www.avtovzglyad.ru/static/images/favicon/safari-pinned-tab.svg", "https://www.avtovzglyad.ru/static/images/favicon/favicon-32x32.png", new Guid("21113e8f-1e06-466f-811c-0cfaf9536b14") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_editor_settings",
                columns: new[] { "id", "is_required", "name_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("0e9f42e9-c775-4133-b954-30ab51e817a0"), false, "//div[@class='article__authors']//*[@class='article__authors__author']/span[@class='article__authors__author__name']/text()", new Guid("73796890-1148-4579-bb51-4f7f8a58a358") },
                    { new Guid("1942be1f-199c-42d4-87df-f64712a0ecda"), false, "//span[@itemprop='author']/span[@itemprop='name']/@content", new Guid("c60d2d6e-50cd-4ea5-941b-fc7382f3c4af") },
                    { new Guid("2ef0dbd4-e856-4e6d-8ae3-93e64d08c4cc"), false, "//section[contains(@class, '_page-section')]//div[contains(@class, '_bottom-info_')]//span[contains(@class, '_user-info__name_')]/text()", new Guid("6fc6a863-f0d8-46b6-b0ad-2d2442877c5c") },
                    { new Guid("40c60e0f-fbad-4591-95b7-a59f5af0acc0"), false, "//span[@itemprop='name']/a/text()", new Guid("1f825d8f-d379-44bc-8cac-c98e31ae9c92") },
                    { new Guid("46e1a5c2-18a0-45c3-91f8-56bb66967e56"), false, "//div[@class='container-fluid publication-footer']//a[contains(@class, 'text-secondary')]/@title", new Guid("9974031e-0bf9-4d8f-8ee8-3254089a88a9") },
                    { new Guid("53c0587f-f6cc-44ed-82b8-d9ac6df03ead"), false, "//div[@itemprop='author']/span[@itemprop='name']/text()", new Guid("fe6dd38b-cc58-4cbd-8431-f8a97d4cb5cc") },
                    { new Guid("5e70d5a1-9135-4abf-b37e-03acccf75522"), false, "//meta[@property='article:author']/@content", new Guid("b623d45b-6588-47bf-8c3b-fd31ee726fdc") },
                    { new Guid("825b07b4-3f2d-40c1-939f-6a938330e7c3"), false, "//div[@class='article__content']//strong[text()='Автор:']/../text()", new Guid("6998cc17-8709-4c06-9880-afa48c46f9c0") },
                    { new Guid("8efc4864-2122-4b45-af5f-21e0ecb4dcf8"), false, "//*[@itemprop='author']/*[@itemprop='name']//text()", new Guid("9922640b-8132-4151-9ee0-db9829ac19fd") },
                    { new Guid("901ca21f-efe3-433f-8ccd-7270645d1a65"), false, "//div[contains(@class, 'PageArticleContent_authors')]//a[contains(@class, 'LinksOfAuthor_item')]/text()", new Guid("e47fa173-4329-47ea-a14c-f391be2c29d8") },
                    { new Guid("94dcbf73-dece-48da-860c-0f110a794be0"), false, "//a[@class='article__author']/text()", new Guid("3263bfd3-30cf-46ed-922c-cf67945673db") },
                    { new Guid("9756eb3b-8299-42b2-a6b7-9080ffc37080"), false, "//meta[@name='author']/@content", new Guid("981978b4-413a-4340-b808-29b97ebd86db") },
                    { new Guid("9c88fbe2-ef56-4f52-8960-074bae893726"), false, "//meta[@name='mediator_author']/@content", new Guid("7deef4e3-16c2-4772-9379-4582ba8ffbad") },
                    { new Guid("a3389c8e-3d74-4ffe-a14c-f143c826ad34"), false, "//div[@class='author']/span[@itemprop='author']/span[@itemprop='name']/a/text()", new Guid("d8700826-685f-413e-9324-53509bcb7507") },
                    { new Guid("a5d6b7ec-b8a3-47e8-b2ff-1fcfc98d8e8b"), false, "//div[contains(@class, 'styled__StoryInfoAuthors')]/div[contains(@class, 'styled__InfoAuthor')]//span[contains(@class, 'styled__AuthorName')]/text()", new Guid("6aefd5c6-b2d1-4bee-8a4b-ce1f37add4b1") },
                    { new Guid("abe705f9-0fc8-47e2-a11f-0efe7ab1b4e0"), false, "//meta[@property='article:author']/@content", new Guid("bc5ec3a6-867e-44a8-938a-00da5abe6d8c") },
                    { new Guid("aeed4ed9-1f06-4494-ab19-a15beac2a072"), false, "//div[@itemprop='author']//p[@itemprop='name']/text()", new Guid("5dba0bd0-af79-4e68-accb-56edeab32824") },
                    { new Guid("af821dc4-8ae4-4db4-9914-7b8689dac20c"), false, "//div[@class='topic-authors']/a[@class='topic-authors__author']/text()", new Guid("7a605ab8-2b62-4eac-8b1b-6d28c6a21383") },
                    { new Guid("b1ad5c75-7aa8-47d6-aeb8-5fe012f0f340"), false, "//span[@class='author']/a/text()", new Guid("26a8493d-b4c3-42ad-ba39-47f1b1305eb4") },
                    { new Guid("bbbce2c5-01c9-4403-82dc-0b33bc85de54"), false, "//article//span[@class='author']/a[@class='authorName']/span/text()", new Guid("1da16ea7-d5e7-4335-8da3-4e7b9e1e1b19") },
                    { new Guid("cd7a8f75-b8a4-43c2-947e-03dc9eeed394"), false, "//meta[@name='mediator_author']/@content", new Guid("359ded84-b968-4056-ba91-28dc661f5e83") },
                    { new Guid("cf6235c0-c22d-49cb-876a-c968fcc1f3ea"), false, "//meta[@name='author']/@content", new Guid("edc56c97-8950-497b-8d45-731f571aa949") },
                    { new Guid("d0657676-bc3c-43c4-9bc4-352fdb2d1cd8"), false, "//p[@class='doc__text document_authors']/text()", new Guid("8cf9d9f2-e41d-44de-ac63-22b1e11070a8") },
                    { new Guid("d37658a5-725e-4081-a07d-25c41e1d6661"), false, "//footer[@class='news-item__footer']/div[@class='news-item__footer-after-news']/p[position()=1]//span/text()", new Guid("09bab5dc-85be-4de4-b367-a25873e0d234") },
                    { new Guid("d7320229-1fa8-4049-a3f0-60b505c687b0"), false, "//div[@class='preview__author-block']//div[@class='author__about']/a[@itemprop='name']/@content", new Guid("44535c6f-e113-42fc-aa5b-fa8b9f5e2616") },
                    { new Guid("d9ea7412-277c-4935-ad2a-8a9b9f3eaa22"), false, "//article//header//div[@class='b-authors']/div[@class='b-author' and position()=1]//text()", new Guid("448d8fc1-481a-461a-a69b-987fc0c45065") },
                    { new Guid("dc8aaa2a-505c-4f3e-8d73-a8c4936fe379"), false, "//div[@class='article_top']//div[@class='authors']//div[@class='autor']//span/text()", new Guid("ac148104-b6f5-4630-817a-d4786dd9e04b") },
                    { new Guid("e213920a-5c90-486c-b6e0-6e99e191358f"), false, "//meta[@property='article:author']/@content", new Guid("a97f39cb-d3a5-44cf-bf61-f47642205679") },
                    { new Guid("ec6ffae7-1494-4ded-bead-159a18d5b5a5"), false, "//meta[@name='author']/@content", new Guid("f3887ff4-881c-4db3-92a4-95c9d0a9e0be") },
                    { new Guid("eeff5579-ba48-44c4-960c-1f6afd0949f0"), false, "//div[contains(@class, 'styles_bodyWrapper')]//div[contains(@class, 'styles_authorsLinks')]/a/text()", new Guid("81307884-8826-4760-a010-b565004590c9") },
                    { new Guid("fe083f65-f651-423c-9e23-ab3067b6e02f"), false, "//article/p[@class='author']/text()", new Guid("6653304f-d205-448c-aa38-759cdf6626d3") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_modified_at_settings",
                columns: new[] { "id", "is_required", "modified_at_culture_info", "modified_at_time_zone_info_id", "modified_at_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("2bfc263a-2801-4513-8f87-58e3f35c8471"), false, "ru-RU", null, "//meta[@property='article:modified_time']/@content", new Guid("bc5ec3a6-867e-44a8-938a-00da5abe6d8c") },
                    { new Guid("2cb2a292-cdfd-4ac9-a3ff-cb4a4a5a21de"), false, "ru-RU", null, "//meta[@itemprop='dateModified']/@content", new Guid("9922640b-8132-4151-9ee0-db9829ac19fd") },
                    { new Guid("2f9f8df8-4976-4637-bcad-cdb7dd43d4f3"), false, "ru-RU", null, "//meta[@property='article:modified_time']/@content", new Guid("8cf9d9f2-e41d-44de-ac63-22b1e11070a8") },
                    { new Guid("32a800b2-bfcf-448e-b9d4-a23303d2f525"), false, "ru-RU", "Russian Standard Time", "//meta[@itemprop='dateModified']/@content", new Guid("27667d0d-aad5-4f71-8381-06fe749ab003") },
                    { new Guid("4f876aa4-80f1-4f74-a157-0ccdbab1b7b1"), false, "ru-RU", "Russian Standard Time", "//meta[@property='article:modified_time']/@content", new Guid("dff850f5-6d5e-4c06-b22d-fe7c9fa22f92") },
                    { new Guid("595bf985-3ee3-4b44-a0c6-bccaf92ffacc"), false, "ru-RU", "Russian Standard Time", "//meta[@property='article:modified_time']/@content", new Guid("e47fa173-4329-47ea-a14c-f391be2c29d8") },
                    { new Guid("5b46161e-e039-45ca-9e1c-e26ff656c4f3"), false, "ru-RU", null, "//meta[@property='article:modified_time']/@content", new Guid("3263bfd3-30cf-46ed-922c-cf67945673db") },
                    { new Guid("663461f7-da79-45fb-8d0a-7dde8ff7a38b"), false, "ru-RU", null, "//meta[@property='article:modified_time']/@content", new Guid("f3887ff4-881c-4db3-92a4-95c9d0a9e0be") },
                    { new Guid("70397b96-d1a7-48da-80a7-583b99244e5a"), false, "en-US", null, "//meta[@property='article:modified_time']/@content", new Guid("981978b4-413a-4340-b808-29b97ebd86db") },
                    { new Guid("7e36a979-7787-45dd-baab-f397430ccc47"), false, "ru-RU", "Russian Standard Time", "//meta[@itemprop='dateModified']/@content", new Guid("6feaf29f-abc6-40a0-b67b-a97aa3168517") },
                    { new Guid("82c81b79-bd9b-49b3-82a4-733a4ebd8aac"), false, "en-US", null, "//meta[@property='article:modified_time']/@content", new Guid("1f825d8f-d379-44bc-8cac-c98e31ae9c92") },
                    { new Guid("af5aa565-4222-4de1-9383-076b7fcef9ca"), false, "ru-RU", "UTC", "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark_update')]//span[@ca-ts]/text()", new Guid("0e457f7a-e5f5-4760-bf44-c4f9f1e577c1") },
                    { new Guid("bc0e6568-303b-4b00-81f3-281f34653b40"), false, "ru-RU", null, "//meta[@property='article:modified_time']/@content", new Guid("74740f98-e16f-4a19-a912-f55599ac11cf") },
                    { new Guid("c5900125-0680-45d7-8f38-bf3a8d7201b5"), false, "ru-RU", null, "//meta[@itemprop='article:modifiedA_time']/@content", new Guid("65975b6b-9d0d-424d-b175-62f993dd50a3") },
                    { new Guid("d062f27a-5ae7-410e-9695-8181335c0994"), false, "ru-RU", null, "//meta[@itemprop='dateModified']/@content", new Guid("edc56c97-8950-497b-8d45-731f571aa949") },
                    { new Guid("dd70bcb1-0b71-43b3-a414-ce5bbb46f558"), false, "ru-RU", null, "//meta[@itemprop='dateModified']/@content", new Guid("5dba0bd0-af79-4e68-accb-56edeab32824") },
                    { new Guid("ddec65cf-70ae-49d0-9009-540a80970d6d"), false, "ru-RU", "Russian Standard Time", "//meta[@property='article:modified_time']/@content", new Guid("f6c5d879-e7a7-4467-9d97-17d82d2bb9f7") },
                    { new Guid("f1b74531-d13d-483c-9d1d-3463d91f5d40"), false, "ru-RU", null, "//meta[@itemprop='dateModified']/@content", new Guid("73796890-1148-4579-bb51-4f7f8a58a358") },
                    { new Guid("f415c060-0a80-4f7f-8818-b246f1b50cb2"), false, "ru-RU", "Russian Standard Time", "//meta[@property='article:modified_time']/@content", new Guid("cdd2103e-e1ef-47eb-989b-7c52e43727df") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_picture_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("04344662-5ba1-4190-a878-194bbd1fb979"), false, new Guid("359ded84-b968-4056-ba91-28dc661f5e83"), "//meta[@property='og:image']/@content" },
                    { new Guid("0679e8b2-6633-4e92-a8c5-0be83b23f6d4"), false, new Guid("74740f98-e16f-4a19-a912-f55599ac11cf"), "//meta[@property='og:image']/@content" },
                    { new Guid("09ab0c18-827e-4fb9-b852-d36ad8cec123"), false, new Guid("65975b6b-9d0d-424d-b175-62f993dd50a3"), "//meta[@property='og:image']/@content" },
                    { new Guid("0aa196c5-2091-4022-bb2f-4abca03d9140"), false, new Guid("73796890-1148-4579-bb51-4f7f8a58a358"), "//meta[@itemprop='url']/@content" },
                    { new Guid("0e2fa92e-f71c-4463-827f-aa7eb165ffd5"), false, new Guid("c60d2d6e-50cd-4ea5-941b-fc7382f3c4af"), "//meta[@property='og:image']/@content" },
                    { new Guid("13c0e2ec-c0e0-4e61-894c-76e4c117f1a9"), false, new Guid("3263bfd3-30cf-46ed-922c-cf67945673db"), "//meta[@property='og:image']/@content" },
                    { new Guid("25414e03-3767-477c-8075-6665be3a9ed6"), false, new Guid("fe6dd38b-cc58-4cbd-8431-f8a97d4cb5cc"), "//meta[@property='og:image']/@content" },
                    { new Guid("26375f8d-cd23-47a7-bdcc-58200ae5c773"), false, new Guid("5dba0bd0-af79-4e68-accb-56edeab32824"), "//meta[@property='og:image']/@content" },
                    { new Guid("2fb49037-4c51-40c3-92c7-d5efa281efa7"), false, new Guid("27667d0d-aad5-4f71-8381-06fe749ab003"), "//meta[@property='og:image']/@content" },
                    { new Guid("38c1aee4-4fe7-43e8-b2e1-c49659fbd325"), false, new Guid("6653304f-d205-448c-aa38-759cdf6626d3"), "//meta[@property='og:image']/@content" },
                    { new Guid("3ff9476f-c27b-4a15-b692-0e98a66e22dc"), false, new Guid("1da16ea7-d5e7-4335-8da3-4e7b9e1e1b19"), "//meta[@property='og:image']/@content" },
                    { new Guid("44c16d4c-1542-4cfa-b344-8f0ad830c321"), false, new Guid("9922640b-8132-4151-9ee0-db9829ac19fd"), "//meta[@property='og:image']/@content" },
                    { new Guid("44cc2ad1-1615-4628-99f8-b05227055ea1"), false, new Guid("81307884-8826-4760-a010-b565004590c9"), "//meta[@property='og:image']/@content" },
                    { new Guid("48020154-4542-489d-847a-1e52e70ccae4"), false, new Guid("09bab5dc-85be-4de4-b367-a25873e0d234"), "//meta[@property='og:image']/@content" },
                    { new Guid("552b97d0-c36a-42c5-9f68-3f6c0c9bb33d"), false, new Guid("e47fa173-4329-47ea-a14c-f391be2c29d8"), "//meta[@property='og:image']/@content" },
                    { new Guid("5a2abe50-1598-4796-8a8a-2c67bf0392f2"), false, new Guid("6998cc17-8709-4c06-9880-afa48c46f9c0"), "//meta[@property='og:image']/@content" },
                    { new Guid("64ba90c6-ab72-4c53-865d-b8713477532f"), false, new Guid("6feaf29f-abc6-40a0-b67b-a97aa3168517"), "//meta[@property='og:image']/@content" },
                    { new Guid("64baf88f-729f-4569-b9eb-a377dc7f733f"), false, new Guid("cdd2103e-e1ef-47eb-989b-7c52e43727df"), "//meta[@property='og:image']/@content" },
                    { new Guid("70bd6545-15d7-4bfd-8d82-368a73f33d4b"), false, new Guid("6fc6a863-f0d8-46b6-b0ad-2d2442877c5c"), "//meta[@property='og:image']/@content" },
                    { new Guid("815997ae-69c5-465f-bd19-19d4c6246135"), false, new Guid("bc5ec3a6-867e-44a8-938a-00da5abe6d8c"), "//meta[@property='og:image']/@content" },
                    { new Guid("8a582183-bdd3-45d6-a83a-a5e5d154d7cc"), false, new Guid("26a8493d-b4c3-42ad-ba39-47f1b1305eb4"), "//meta[@property='og:image']/@content" },
                    { new Guid("8d49eb2b-19f8-4016-9cce-231b27938014"), false, new Guid("f6c5d879-e7a7-4467-9d97-17d82d2bb9f7"), "//meta[@property='og:image']/@content" },
                    { new Guid("9706a30c-fb27-4deb-aa7e-b9583a4fbbb0"), false, new Guid("dff850f5-6d5e-4c06-b22d-fe7c9fa22f92"), "//meta[@property='og:image']/@content" },
                    { new Guid("9719e7fa-4d37-4e5f-a412-d2c4433474e9"), false, new Guid("9974031e-0bf9-4d8f-8ee8-3254089a88a9"), "//meta[@name='og:image']/@content" },
                    { new Guid("a390e107-4db8-4a79-8650-119926c5d359"), false, new Guid("edc56c97-8950-497b-8d45-731f571aa949"), "//meta[@property='og:image']/@content" },
                    { new Guid("b2f45b57-7ea9-4561-ab44-c50825d84e9d"), false, new Guid("ac148104-b6f5-4630-817a-d4786dd9e04b"), "//meta[@property='og:image']/@content" },
                    { new Guid("becbb73f-87c8-4ece-aa33-bea1a19d88da"), false, new Guid("981978b4-413a-4340-b808-29b97ebd86db"), "//meta[@property='og:image']/@content" },
                    { new Guid("c03f138d-a001-41fc-b111-d3300deac9ff"), false, new Guid("44535c6f-e113-42fc-aa5b-fa8b9f5e2616"), "//meta[@property='og:image']/@content" },
                    { new Guid("c2b6b632-2931-4cd7-b843-235d56b656d5"), false, new Guid("7a605ab8-2b62-4eac-8b1b-6d28c6a21383"), "//meta[@property='og:image']/@content" },
                    { new Guid("c780becf-13bf-44bd-80db-921a0b5cd04b"), false, new Guid("f3887ff4-881c-4db3-92a4-95c9d0a9e0be"), "//meta[@property='og:image']/@content" },
                    { new Guid("c7f2b47e-8d80-41a5-afe0-8eab09ae7df9"), false, new Guid("7deef4e3-16c2-4772-9379-4582ba8ffbad"), "//meta[@property='og:image']/@content" },
                    { new Guid("cd04344f-1234-4d63-8e4f-aa27f135de9f"), false, new Guid("1a1f7948-4616-418b-8bb0-6e1aac8f8479"), "//meta[@property='og:image']/@content" },
                    { new Guid("d11e15c8-b95c-4f00-9e02-0fcbdb55d34d"), false, new Guid("1f825d8f-d379-44bc-8cac-c98e31ae9c92"), "//meta[@property='og:image']/@content" },
                    { new Guid("db2d2e21-1312-4b8f-ae9f-db551fe6f39b"), false, new Guid("b623d45b-6588-47bf-8c3b-fd31ee726fdc"), "//meta[@property='og:image']/@content" },
                    { new Guid("dc882acd-9ca0-4cdb-8753-e21c4dc96d65"), false, new Guid("6aefd5c6-b2d1-4bee-8a4b-ce1f37add4b1"), "//meta[@name='og:image']/@content" },
                    { new Guid("e4e5621e-7ba6-4627-a5ab-6f805552e69f"), false, new Guid("448d8fc1-481a-461a-a69b-987fc0c45065"), "//meta[@property='og:image']/@content" },
                    { new Guid("e93d1dcc-c085-45f0-8f67-aafcbea2911b"), false, new Guid("a97f39cb-d3a5-44cf-bf61-f47642205679"), "//meta[@property='og:image']/@content" },
                    { new Guid("ea590da0-3d81-42b2-9877-9f0dabfa5598"), false, new Guid("d8700826-685f-413e-9324-53509bcb7507"), "//meta[@property='og:image']/@content" },
                    { new Guid("ee334978-2240-4859-9ca6-2191189f6a12"), false, new Guid("0e457f7a-e5f5-4760-bf44-c4f9f1e577c1"), "//meta[@property='og:image']/@content" },
                    { new Guid("f64f6df8-5f7a-49de-8541-e6c7cd1a580b"), false, new Guid("8cf9d9f2-e41d-44de-ac63-22b1e11070a8"), "//meta[@property='og:image']/@content" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "published_at_culture_info", "published_at_time_zone_info_id", "published_at_x_path" },
                values: new object[,]
                {
                    { new Guid("005e998d-6106-42bd-815b-f7b70b5fcd52"), true, new Guid("359ded84-b968-4056-ba91-28dc661f5e83"), "ru-RU", null, "//meta[@name='mediator_published_time']/@content" },
                    { new Guid("0d065cba-c206-4b55-b248-6b7cb1abecfd"), true, new Guid("26a8493d-b4c3-42ad-ba39-47f1b1305eb4"), "ru-RU", "Russian Standard Time", "//span[@class='date']/time/@datetime" },
                    { new Guid("11bf0b89-a7a0-459f-aa31-bf74b9ef0319"), true, new Guid("27667d0d-aad5-4f71-8381-06fe749ab003"), "ru-RU", "Russian Standard Time", "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("21f4efe9-a482-45d5-836c-3a69d6ce0ec0"), true, new Guid("6653304f-d205-448c-aa38-759cdf6626d3"), "ru-RU", "Russian Standard Time", "//article/div[@class='header']/span/text()" },
                    { new Guid("24d1da38-f262-4dc5-b209-badd38966e03"), true, new Guid("65975b6b-9d0d-424d-b175-62f993dd50a3"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("2abd19a0-ff19-479a-abcf-9cbd85142b46"), true, new Guid("5dba0bd0-af79-4e68-accb-56edeab32824"), "ru-RU", null, "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("2f38a451-ef5c-453a-b5d6-805c5cba4cdc"), true, new Guid("6feaf29f-abc6-40a0-b67b-a97aa3168517"), "ru-RU", "Russian Standard Time", "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("33f00df8-babd-4634-9326-b59d674354ed"), true, new Guid("1a1f7948-4616-418b-8bb0-6e1aac8f8479"), "ru-RU", "Russian Standard Time", "//p[@class='b-material__date']/text()" },
                    { new Guid("3ac463d1-2688-44e2-828e-d3b99e5a2e8d"), true, new Guid("bc5ec3a6-867e-44a8-938a-00da5abe6d8c"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("45c0c1e9-d799-4c47-b145-55383c32536c"), true, new Guid("f6c5d879-e7a7-4467-9d97-17d82d2bb9f7"), "ru-RU", "Russian Standard Time", "//meta[@property='article:published_time']/@content" },
                    { new Guid("48d1a9ae-721f-445d-95cf-4d312a09234d"), true, new Guid("981978b4-413a-4340-b808-29b97ebd86db"), "en-US", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("55050554-4f5a-48b7-84a7-469cd2dafd28"), true, new Guid("b623d45b-6588-47bf-8c3b-fd31ee726fdc"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("594bc097-407b-4cab-9755-ebfe2cca58fd"), true, new Guid("09bab5dc-85be-4de4-b367-a25873e0d234"), "ru-RU", null, "//header[@class='news-item__header']//time/@content" },
                    { new Guid("6325a29e-39a8-4319-89b6-51b1c746ea04"), true, new Guid("74740f98-e16f-4a19-a912-f55599ac11cf"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("6a70df0f-527e-476e-b10a-024c35eeb611"), true, new Guid("6998cc17-8709-4c06-9880-afa48c46f9c0"), "ru-RU", "Russian Standard Time", "//div[@class='article__content']//time/text()" },
                    { new Guid("6b1cf98e-2071-4268-b393-7b0c10ada07e"), true, new Guid("cdd2103e-e1ef-47eb-989b-7c52e43727df"), "ru-RU", "Russian Standard Time", "//meta[@property='article:published_time']/@content" },
                    { new Guid("79887f1c-e4b7-4a7a-9f24-d3b98334b5ef"), true, new Guid("81307884-8826-4760-a010-b565004590c9"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("82582938-8e4f-4ed5-9518-b9a548ab135f"), true, new Guid("c60d2d6e-50cd-4ea5-941b-fc7382f3c4af"), "ru-RU", "Russian Standard Time", "//div[@class='b-article__top-author']/p[@class='date']/text()" },
                    { new Guid("878fad82-ad55-433c-a873-6ef0f93f6d64"), true, new Guid("7a605ab8-2b62-4eac-8b1b-6d28c6a21383"), "ru-RU", "Russian Standard Time", "//div[@class='topic-page__header']//a[contains(@class, 'topic-header__time')]/text()" },
                    { new Guid("92294882-c3cf-439e-b88c-fd11994e3fc9"), true, new Guid("44535c6f-e113-42fc-aa5b-fa8b9f5e2616"), "ru-RU", "Russian Standard Time", "//div[@class='article-details']/span[@class='article-details__time']/time/@datetime" },
                    { new Guid("93b9c8cb-eb88-49d9-9cb5-912280873ede"), true, new Guid("a97f39cb-d3a5-44cf-bf61-f47642205679"), "ru-RU", "Russian Standard Time", "//article//header//time[@class='article-head__date']/text()" },
                    { new Guid("95b212b4-c8fe-493d-971c-7a29a0bd7bfd"), true, new Guid("73796890-1148-4579-bb51-4f7f8a58a358"), "ru-RU", null, "//div[@class='article__header__info-block']/time[@class='article__header__date']/@datetime" },
                    { new Guid("9927b549-4129-4e8c-a205-6b2d02a1066f"), true, new Guid("edc56c97-8950-497b-8d45-731f571aa949"), "ru-RU", null, "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("acc21be1-5afe-4cdf-b438-7ca17134ea1f"), true, new Guid("7deef4e3-16c2-4772-9379-4582ba8ffbad"), "ru-RU", null, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']/span[@itemprop='datePublished']/@content" },
                    { new Guid("b0ad4ea8-aae2-4e51-b436-1588e78c2b78"), true, new Guid("e47fa173-4329-47ea-a14c-f391be2c29d8"), "ru-RU", "Russian Standard Time", "//meta[@property='article:published_time']/@content" },
                    { new Guid("b9340478-b4c9-4bee-83ad-c94beee214b5"), true, new Guid("9922640b-8132-4151-9ee0-db9829ac19fd"), "ru-RU", null, "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("ba6f22a0-2b35-46c3-ad30-a182de091d3b"), true, new Guid("fe6dd38b-cc58-4cbd-8431-f8a97d4cb5cc"), "ru-RU", null, "//div[@class='publication-info']/time[@itemprop='datePublished']/@datetime" },
                    { new Guid("bb95047c-2342-4f77-9a98-f3ace25e231c"), true, new Guid("1da16ea7-d5e7-4335-8da3-4e7b9e1e1b19"), "en-US", "Central Europe Standard Time", "//article//div[@class='article-info']/div[@class='date']/text()" },
                    { new Guid("bbcbe7a9-acc8-48a4-9a57-a3fcb3d9f955"), true, new Guid("dff850f5-6d5e-4c06-b22d-fe7c9fa22f92"), "ru-RU", "Russian Standard Time", "//meta[@property='article:published_time']/@content" },
                    { new Guid("bd63cdb5-d674-4525-955c-486ad2471bc5"), true, new Guid("ac148104-b6f5-4630-817a-d4786dd9e04b"), "ru-RU", "Russian Standard Time", "//div[@class='article_top']//div[@class='date']//time/text()" },
                    { new Guid("c7dff225-2713-42f7-827a-50f296ee979e"), true, new Guid("0e457f7a-e5f5-4760-bf44-c4f9f1e577c1"), "ru-RU", "UTC", "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark')]//span[@ca-ts]/text()" },
                    { new Guid("ca10377b-474e-43ae-85e9-a6fd4b63f751"), true, new Guid("1f825d8f-d379-44bc-8cac-c98e31ae9c92"), "en-US", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("cf78875a-8378-433b-be00-30d6bd6e2271"), true, new Guid("3263bfd3-30cf-46ed-922c-cf67945673db"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("d1f0e3e5-09d9-423a-9566-9eb930c323b8"), true, new Guid("d8700826-685f-413e-9324-53509bcb7507"), "ru-RU", null, "//meta[@itemprop='dateModified']/@content" },
                    { new Guid("da5f2269-40ed-4814-90a2-84ca4d0d7182"), true, new Guid("448d8fc1-481a-461a-a69b-987fc0c45065"), "ru-RU", "Russian Standard Time", "//div[@class='b-text__date']/text()" },
                    { new Guid("ed95ad40-a73d-4222-9cdd-cf25f92208fa"), true, new Guid("8cf9d9f2-e41d-44de-ac63-22b1e11070a8"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("f387855c-a11c-4fad-8db9-5aa100bc25e7"), true, new Guid("f3887ff4-881c-4db3-92a4-95c9d0a9e0be"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("fe8843f4-32a8-4db4-a4ed-9f5038d4ed8b"), false, new Guid("9974031e-0bf9-4d8f-8ee8-3254089a88a9"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'pubdatetime')]//div[contains(@class, 'badge-time')]//text()" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_sub_title_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("0779645e-43d8-4722-9ee2-8b21358a7d4d"), false, new Guid("44535c6f-e113-42fc-aa5b-fa8b9f5e2616"), "//meta[@name='description']/@content" },
                    { new Guid("09bef20e-ee5c-4290-b51e-5b351f8ad145"), false, new Guid("7deef4e3-16c2-4772-9379-4582ba8ffbad"), "//meta[@property='og:description']/@content" },
                    { new Guid("0def78a3-bf24-485f-a458-7a619acacb53"), false, new Guid("6aefd5c6-b2d1-4bee-8a4b-ce1f37add4b1"), "//div[contains(@class, 'styled__StoryBody')]/p[contains(@class, 'styled__StoryParagraph') and position()=1]/text()" },
                    { new Guid("12219cfb-f209-409e-b6ea-b7d0f3ef5456"), false, new Guid("ac148104-b6f5-4630-817a-d4786dd9e04b"), "//meta[@property='og:description']/@content" },
                    { new Guid("1c66cd54-bebf-4fce-a83c-8dbd9917fe3a"), false, new Guid("c60d2d6e-50cd-4ea5-941b-fc7382f3c4af"), "//meta[@property='og:description']/@content" },
                    { new Guid("2bb2cbe4-0fee-46f7-a4e0-80ed354ad59f"), false, new Guid("5dba0bd0-af79-4e68-accb-56edeab32824"), "//meta[@property='og:description']/@content" },
                    { new Guid("314d78f6-5597-458e-9021-feb9219d0e4c"), false, new Guid("edc56c97-8950-497b-8d45-731f571aa949"), "//p[contains(@itemprop, 'alternativeHeadline')]/text()" },
                    { new Guid("3d432a6c-f58e-4a06-a95f-49e57799503b"), false, new Guid("6653304f-d205-448c-aa38-759cdf6626d3"), "//meta[@property='og:description']/@content" },
                    { new Guid("455c3833-8116-4bef-a0d8-5e04c04fbc8e"), false, new Guid("8cf9d9f2-e41d-44de-ac63-22b1e11070a8"), "//meta[@name='description']/@content" },
                    { new Guid("46623638-3095-4a86-8a02-a7e274fd91e1"), false, new Guid("e47fa173-4329-47ea-a14c-f391be2c29d8"), "//meta[@property='og:description']/@content" },
                    { new Guid("4af9a0a2-2e14-45f0-a16f-2888ef42b4b6"), false, new Guid("f6c5d879-e7a7-4467-9d97-17d82d2bb9f7"), "//meta[@property='og:description']/@content" },
                    { new Guid("54309a16-7429-466d-b025-ff9487cf96ad"), false, new Guid("7a605ab8-2b62-4eac-8b1b-6d28c6a21383"), "//meta[@property='og:description']/@content" },
                    { new Guid("57e92ed6-bf84-478d-b29f-395375eec714"), false, new Guid("1f825d8f-d379-44bc-8cac-c98e31ae9c92"), "//meta[@property='og:description']/@content" },
                    { new Guid("58198d30-d05f-461f-9941-ae09a864828c"), false, new Guid("65975b6b-9d0d-424d-b175-62f993dd50a3"), "//meta[@property='og:description']/@content" },
                    { new Guid("5bd38f50-842f-4b9e-8168-e4a7e9b8e23d"), false, new Guid("dff850f5-6d5e-4c06-b22d-fe7c9fa22f92"), "//meta[@property='og:description']/@content" },
                    { new Guid("68640d4b-2a81-442e-9a29-ef2213e5f140"), false, new Guid("6feaf29f-abc6-40a0-b67b-a97aa3168517"), "//meta[@property='og:description']/@content" },
                    { new Guid("6dfc1544-1008-43cc-894d-4488663f4fcf"), false, new Guid("448d8fc1-481a-461a-a69b-987fc0c45065"), "//meta[@property='og:description']/@content" },
                    { new Guid("6f560a4d-f3dd-4660-a2fd-2125c6791964"), false, new Guid("359ded84-b968-4056-ba91-28dc661f5e83"), "//meta[@property='og:description']/@content" },
                    { new Guid("76190c72-d806-4d2d-b458-658abfa93e35"), false, new Guid("27667d0d-aad5-4f71-8381-06fe749ab003"), "//meta[@property='og:description']/@content" },
                    { new Guid("7ab47770-a88a-4bcb-9e3a-d77eff96e859"), false, new Guid("73796890-1148-4579-bb51-4f7f8a58a358"), "//meta[@property='og:description']/@content" },
                    { new Guid("7de487de-0635-4eb0-9509-a6621a0ab804"), false, new Guid("f3887ff4-881c-4db3-92a4-95c9d0a9e0be"), "//meta[@name='description']/@content" },
                    { new Guid("807f9eac-ce65-43de-bdf0-a6c9a284ab06"), false, new Guid("09bab5dc-85be-4de4-b367-a25873e0d234"), "//meta[@property='og:description']/@content" },
                    { new Guid("814194f8-f24f-4129-9677-97268255cf0e"), false, new Guid("9922640b-8132-4151-9ee0-db9829ac19fd"), "//meta[@property='og:description']/@content" },
                    { new Guid("8bd7005e-62c3-4385-b774-83ec9aea79bd"), false, new Guid("3263bfd3-30cf-46ed-922c-cf67945673db"), "//meta[@property='og:description']/@content" },
                    { new Guid("99591a2b-7572-49ab-84ff-50c36ccf4db4"), false, new Guid("981978b4-413a-4340-b808-29b97ebd86db"), "//meta[@name='description']/@content" },
                    { new Guid("9db11065-b024-4c6e-b760-f18410caca57"), false, new Guid("26a8493d-b4c3-42ad-ba39-47f1b1305eb4"), "//meta[@name='description']/@content" },
                    { new Guid("a1f6b6dc-99cc-4f15-926a-028a546b86e0"), false, new Guid("6998cc17-8709-4c06-9880-afa48c46f9c0"), "//meta[@property='og:description']/@content" },
                    { new Guid("b7512345-13ed-4f9f-b052-e227abcc4837"), false, new Guid("fe6dd38b-cc58-4cbd-8431-f8a97d4cb5cc"), "//meta[@itemprop='description']/@content" },
                    { new Guid("ba114bf9-9357-4d05-9126-faf562e5278d"), false, new Guid("81307884-8826-4760-a010-b565004590c9"), "//meta[@property='og:description']/@content" },
                    { new Guid("d93f5bcc-b118-479d-913d-e9b884f23ab2"), false, new Guid("9974031e-0bf9-4d8f-8ee8-3254089a88a9"), "//meta[@name='og:description']/@content" },
                    { new Guid("dd646aca-4451-4c30-a87a-dc95019fbb91"), false, new Guid("1da16ea7-d5e7-4335-8da3-4e7b9e1e1b19"), "//meta[@property='og:description']/@content" },
                    { new Guid("df38b344-99c6-4c1b-91aa-1ecdff87db22"), false, new Guid("d8700826-685f-413e-9324-53509bcb7507"), "//meta[@property='og:description']/@content" },
                    { new Guid("e1ecfed1-4c30-4faf-a669-b36d2800e519"), false, new Guid("cdd2103e-e1ef-47eb-989b-7c52e43727df"), "//meta[@property='og:description']/@content" },
                    { new Guid("e530b856-7244-4929-a71a-6e2f53b270bc"), false, new Guid("1a1f7948-4616-418b-8bb0-6e1aac8f8479"), "//meta[@property='og:description']/@content" },
                    { new Guid("ebdd009c-2cc0-4b41-8061-a08f5390d9fe"), false, new Guid("6fc6a863-f0d8-46b6-b0ad-2d2442877c5c"), "//meta[@property='og:description']/@content" },
                    { new Guid("ec0fd259-2f10-4e84-bc48-e4c77617021e"), false, new Guid("0e457f7a-e5f5-4760-bf44-c4f9f1e577c1"), "//meta[@property='og:description']/@content" },
                    { new Guid("f51b00fc-9302-470b-8175-9c55e0e3149b"), false, new Guid("bc5ec3a6-867e-44a8-938a-00da5abe6d8c"), "//meta[@property='og:description']/@content" },
                    { new Guid("f937b300-71b4-48e8-a157-d3250e541cdc"), false, new Guid("b623d45b-6588-47bf-8c3b-fd31ee726fdc"), "//div[@class='block-page-new']/h2/text()" },
                    { new Guid("f9657df0-63ea-4784-94ac-54860b3388b2"), false, new Guid("74740f98-e16f-4a19-a912-f55599ac11cf"), "//meta[@property='og:description']/@content" },
                    { new Guid("f9d29c7e-5fc8-480d-9b67-5f346446b071"), false, new Guid("a97f39cb-d3a5-44cf-bf61-f47642205679"), "//meta[@property='og:description']/@content" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_video_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("05685dfe-4d17-437a-94fb-94afa4523c18"), false, new Guid("cdd2103e-e1ef-47eb-989b-7c52e43727df"), "//div[@class='article__header']//div[@class='media__video']//video/@src" },
                    { new Guid("3876d850-70d0-4def-ab1c-2d76e3d75650"), false, new Guid("1a1f7948-4616-418b-8bb0-6e1aac8f8479"), "//meta[@property='og:video:url']/@content" },
                    { new Guid("7ec80801-7566-446f-9ec6-f893813b6447"), false, new Guid("7a605ab8-2b62-4eac-8b1b-6d28c6a21383"), "//div[contains(@class, 'eagleplayer')]//video/@src" },
                    { new Guid("a9bcdad6-bcf0-4d1b-beed-eae75213cfba"), false, new Guid("3263bfd3-30cf-46ed-922c-cf67945673db"), "//meta[@property='og:video']/@content" },
                    { new Guid("bab325a1-0e9f-42ac-b28d-95a13ab31893"), false, new Guid("1da16ea7-d5e7-4335-8da3-4e7b9e1e1b19"), "//article//div[@class='videoWrapper' and @itemprop='video']/iframe[@class='video']/@src" },
                    { new Guid("fcf9c1d8-d781-4b72-bdee-a9c9fe8ca15e"), false, new Guid("e47fa173-4329-47ea-a14c-f391be2c29d8"), "//div[contains(@class, 'PageContentCommonStyling_text')]/rg-video//video/@src" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_modified_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_modified_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("004a3175-e3a4-42a8-a989-4782db296c67"), "yyyy-MM-dd", new Guid("7e36a979-7787-45dd-baab-f397430ccc47") },
                    { new Guid("1763a297-d8ab-46b2-a952-d667844a3cd4"), "yyyyMMddTHHmm", new Guid("f415c060-0a80-4f7f-8818-b246f1b50cb2") },
                    { new Guid("1ec501d8-bed4-40b9-a938-ca30cb055d10"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("f1b74531-d13d-483c-9d1d-3463d91f5d40") },
                    { new Guid("213d303a-aaea-4f8c-9248-eaa3a6461288"), "yyyy-MM-ddTHH:mm:ss", new Guid("32a800b2-bfcf-448e-b9d4-a23303d2f525") },
                    { new Guid("2eeeff0c-0e32-4550-b9d7-3c30df977311"), "yyyy-MM-ddTHH:mm:ss", new Guid("595bf985-3ee3-4b44-a0c6-bccaf92ffacc") },
                    { new Guid("32ac4092-fb57-4ee3-87f5-2ba15dfc3f98"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("2bfc263a-2801-4513-8f87-58e3f35c8471") },
                    { new Guid("4bb59cac-e456-4e67-be74-e87bd575a9be"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("2cb2a292-cdfd-4ac9-a3ff-cb4a4a5a21de") },
                    { new Guid("4d49b679-d954-47df-ba3f-1abcbb176821"), "yyyy-MM-ddTHH:mm:ss.fff\"Z+0300\"", new Guid("ddec65cf-70ae-49d0-9009-540a80970d6d") },
                    { new Guid("56380ef8-2bc6-441a-b255-1c472642c09a"), "yyyy-MM-ddTHH:mm:ss.fffZ", new Guid("82c81b79-bd9b-49b3-82a4-733a4ebd8aac") },
                    { new Guid("776be61a-e857-4d31-8a3a-ed025f5b14bc"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("dd70bcb1-0b71-43b3-a414-ce5bbb46f558") },
                    { new Guid("7962abc9-2ad5-40bf-b858-a560bfd8c572"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("663461f7-da79-45fb-8d0a-7dde8ff7a38b") },
                    { new Guid("8634ca40-373d-49c3-b731-bc328be4c5a0"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("2f9f8df8-4976-4637-bcad-cdb7dd43d4f3") },
                    { new Guid("91dfb00c-bfb7-49e3-9348-822364c71685"), "\"обновлено\" d MMMM, HH:mm", new Guid("af5aa565-4222-4de1-9383-076b7fcef9ca") },
                    { new Guid("9c528dd9-dfa3-4551-9845-cfc34aa88dc6"), "yyyy-MM-ddTHH:mmzzz", new Guid("5b46161e-e039-45ca-9e1c-e26ff656c4f3") },
                    { new Guid("a2711834-fd4c-4e74-80c0-9d9d83f92a64"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("c5900125-0680-45d7-8f38-bf3a8d7201b5") },
                    { new Guid("b55949e6-a9fa-4131-9be4-3a054ed7494d"), "yyyy-MM-ddTHH:mm:ss.fffZ", new Guid("70397b96-d1a7-48da-80a7-583b99244e5a") },
                    { new Guid("bba3e249-737a-40fc-95f9-154bd3cd45cb"), "yyyy-MM-dd HH:mm:ss", new Guid("4f876aa4-80f1-4f74-a157-0ccdbab1b7b1") },
                    { new Guid("c44e77c3-8596-43f0-9598-796af39e1ce9"), "\"обновлено\" d MMMM yyyy, HH:mm", new Guid("af5aa565-4222-4de1-9383-076b7fcef9ca") },
                    { new Guid("c87558e8-62a7-42bf-af23-8d6572c1174f"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("d062f27a-5ae7-410e-9695-8181335c0994") },
                    { new Guid("d3d45798-c869-483f-b590-030a28211706"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("bc0e6568-303b-4b00-81f3-281f34653b40") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_published_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("004e5625-8779-487f-8bee-2bafb1c8eb9c"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("f387855c-a11c-4fad-8db9-5aa100bc25e7") },
                    { new Guid("03f2670c-d472-471b-9966-1af288cee7eb"), "d MMMM yyyy, HH:mm \"МСК\"", new Guid("93b9c8cb-eb88-49d9-9cb5-912280873ede") },
                    { new Guid("08154891-f191-49a7-8bd7-48a7e86d9b88"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("9927b549-4129-4e8c-a205-6b2d02a1066f") },
                    { new Guid("081ef9e8-31fe-4fa9-8af8-288d217156c4"), "d MMMM yyyy", new Guid("92294882-c3cf-439e-b88c-fd11994e3fc9") },
                    { new Guid("0e5054c3-a724-4260-a3ec-5a02d07d1457"), "yyyy-MM-dd", new Guid("2f38a451-ef5c-453a-b5d6-805c5cba4cdc") },
                    { new Guid("12d4bb28-9106-4e21-91c0-5171c546c849"), "yyyy-MM-ddTHH:mm:ss", new Guid("b0ad4ea8-aae2-4e51-b436-1588e78c2b78") },
                    { new Guid("2e21c347-63b5-406a-91a2-d508ca622e6b"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("55050554-4f5a-48b7-84a7-469cd2dafd28") },
                    { new Guid("2fe5c70f-c0fc-481a-a776-580012666124"), "d MMMM yyyy HH:mm", new Guid("da5f2269-40ed-4814-90a2-84ca4d0d7182") },
                    { new Guid("35812068-1e2f-4c9f-a2ad-5c744ff7af3e"), "d MMMM yyyy \"в\" HH:mm", new Guid("82582938-8e4f-4ed5-9518-b9a548ab135f") },
                    { new Guid("37e6bcdf-ff94-48eb-9e08-9e87a56ae4f1"), "dd MMMM yyyy HH:mm", new Guid("6a70df0f-527e-476e-b10a-024c35eeb611") },
                    { new Guid("3e71fd97-dc54-42ce-9127-5b3216d3bdec"), "dd.MM.yyyy HH:mm", new Guid("bd63cdb5-d674-4525-955c-486ad2471bc5") },
                    { new Guid("46361abf-2b20-46ef-aef4-ad04f79a596a"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("d1f0e3e5-09d9-423a-9566-9eb930c323b8") },
                    { new Guid("492a3efc-8f3b-47f6-b268-d7a1a84230ea"), "d MMMM yyyy, HH:mm\" •\"", new Guid("21f4efe9-a482-45d5-836c-3a69d6ce0ec0") },
                    { new Guid("54bbd105-1141-4d41-b7a9-8c288faca0e6"), "yyyy-MM-dd HH:mm:ss", new Guid("fe8843f4-32a8-4db4-a4ed-9f5038d4ed8b") },
                    { new Guid("5ae4d464-41fb-4307-ab00-39dd6f66d298"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("79887f1c-e4b7-4a7a-9f24-d3b98334b5ef") },
                    { new Guid("5bb5d4c4-04f4-44fe-9b95-2b94dca53f37"), "HH:mm", new Guid("33f00df8-babd-4634-9326-b59d674354ed") },
                    { new Guid("6c4e8976-7452-4f1f-bb17-69283d2930c3"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("005e998d-6106-42bd-815b-f7b70b5fcd52") },
                    { new Guid("6d368544-71b8-46d1-a701-5e02e82033a9"), "yyyy-MM-ddTHH:mm:ss.fffZ", new Guid("48d1a9ae-721f-445d-95cf-4d312a09234d") },
                    { new Guid("6e88469d-89eb-4301-9e4c-62d86d889fe9"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("ba6f22a0-2b35-46c3-ad30-a182de091d3b") },
                    { new Guid("711326c0-5f15-464d-af23-3d6736ad01b1"), "yyyy-MM-dd HH:mm:ss", new Guid("bbcbe7a9-acc8-48a4-9a57-a3fcb3d9f955") },
                    { new Guid("73d2aa87-66d5-4cb2-a92b-61fe34d376d0"), "d-M-yyyy HH:mm", new Guid("bb95047c-2342-4f77-9a98-f3ace25e231c") },
                    { new Guid("772d3c1f-d572-4aaf-8d72-e8b4756063a0"), "yyyy-MM-ddTHH:mm:ss.fffZ", new Guid("6325a29e-39a8-4319-89b6-51b1c746ea04") },
                    { new Guid("77589033-e1c4-4ce1-b1b4-1b37c17f5972"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("95b212b4-c8fe-493d-971c-7a29a0bd7bfd") },
                    { new Guid("7f64b517-9fc3-46ba-a3ce-f6c0c3e7d870"), "d MMMM  HH:mm", new Guid("da5f2269-40ed-4814-90a2-84ca4d0d7182") },
                    { new Guid("85ac5e7c-af8a-4c7f-90a5-92c87affb836"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("ed95ad40-a73d-4222-9cdd-cf25f92208fa") },
                    { new Guid("8b4a8260-28b3-429e-a973-6ae93e55c50a"), "dd MMMM, HH:mm", new Guid("33f00df8-babd-4634-9326-b59d674354ed") },
                    { new Guid("902776f3-6742-4135-aa58-043705d7cd69"), "yyyy-MM-ddTHH:mmzzz", new Guid("cf78875a-8378-433b-be00-30d6bd6e2271") },
                    { new Guid("907aa5e5-32b9-4027-a641-58c5723616f2"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("b9340478-b4c9-4bee-83ad-c94beee214b5") },
                    { new Guid("9fc7df6a-bf19-417c-9544-161c07fb76d0"), "d MMMM, HH:mm,", new Guid("c7dff225-2713-42f7-827a-50f296ee979e") },
                    { new Guid("a595e445-4ee4-4166-ada2-ada26e7be6cc"), "yyyyMMddTHHmm", new Guid("6b1cf98e-2071-4268-b393-7b0c10ada07e") },
                    { new Guid("ac36b160-51f1-4341-84a0-2db9ce576dce"), "yyyy-MM-dd HH:mm", new Guid("0d065cba-c206-4b55-b248-6b7cb1abecfd") },
                    { new Guid("ac92db30-146d-4505-aad5-22cc474a0422"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("594bc097-407b-4cab-9755-ebfe2cca58fd") },
                    { new Guid("b2af25e7-9ac4-41a2-913d-e22e73e6951e"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("3ac463d1-2688-44e2-828e-d3b99e5a2e8d") },
                    { new Guid("b8c791ea-5be0-420b-b5eb-12268be2c7e0"), "yyyy-MM-ddTHH:mm:ss.fff\"Z+0300\"", new Guid("45c0c1e9-d799-4c47-b145-55383c32536c") },
                    { new Guid("cca1ecf4-53a4-46d9-925f-40b8cd68d4b0"), "d MMMM yyyy, HH:mm", new Guid("c7dff225-2713-42f7-827a-50f296ee979e") },
                    { new Guid("d0ad4918-3efb-491a-907e-4414e0a05956"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("24d1da38-f262-4dc5-b209-badd38966e03") },
                    { new Guid("d1307d31-00b0-4999-b2c9-346bec9d9830"), "dd MMMM yyyy, HH:mm", new Guid("33f00df8-babd-4634-9326-b59d674354ed") },
                    { new Guid("d169d907-9b03-4255-839a-77ce05abfbf2"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("acc21be1-5afe-4cdf-b438-7ca17134ea1f") },
                    { new Guid("d596c366-454a-4a4e-85f0-9d0696018f64"), "yyyy-MM-ddTHH:mm:ss.fffZ", new Guid("ca10377b-474e-43ae-85e9-a6fd4b63f751") },
                    { new Guid("d7a00e01-c932-408d-8bbd-5f977a62cd78"), "d MMMM yyyy, HH:mm,", new Guid("c7dff225-2713-42f7-827a-50f296ee979e") },
                    { new Guid("ddd3eeeb-644e-4206-88a2-068cc61b5607"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("2abd19a0-ff19-479a-abcf-9cbd85142b46") },
                    { new Guid("deff99c3-3570-4ca1-b9f7-b72c993fb4ab"), "dd MMMM HH:mm", new Guid("6a70df0f-527e-476e-b10a-024c35eeb611") },
                    { new Guid("e328a431-98b0-45a6-962d-585b559a2a85"), "HH:mm, d MMMM yyyy", new Guid("878fad82-ad55-433c-a873-6ef0f93f6d64") },
                    { new Guid("ed4820a1-4296-430c-a1be-f98f23e04cce"), "d MMMM, HH:mm", new Guid("c7dff225-2713-42f7-827a-50f296ee979e") },
                    { new Guid("fe24c104-5d32-4187-a0ec-841ad999559d"), "yyyy-MM-ddTHH:mm:ss", new Guid("11bf0b89-a7a0-459f-aa31-bf74b9ef0319") }
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
                name: "ix_news_modified_at",
                table: "news",
                column: "modified_at");

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
                name: "ix_news_editors_name",
                table: "news_editors",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "ix_news_editors_source_id",
                table: "news_editors",
                column: "source_id");

            migrationBuilder.CreateIndex(
                name: "ix_news_html_descriptions_news_id",
                table: "news_html_descriptions",
                column: "news_id",
                unique: true);

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
                name: "ix_news_parse_modified_at_settings_parse_settings_id",
                table: "news_parse_modified_at_settings",
                column: "parse_settings_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_news_parse_modified_at_settings_formats_news_parse_modified",
                table: "news_parse_modified_at_settings_formats",
                column: "news_parse_modified_at_settings_id");

            migrationBuilder.CreateIndex(
                name: "ix_news_parse_needs_news_url",
                table: "news_parse_needs",
                column: "news_url");

            migrationBuilder.CreateIndex(
                name: "ix_news_parse_network_errors_news_url",
                table: "news_parse_network_errors",
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
                name: "ix_news_parse_video_settings_parse_settings_id",
                table: "news_parse_video_settings",
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

            migrationBuilder.CreateIndex(
                name: "ix_news_text_descriptions_news_id",
                table: "news_text_descriptions",
                column: "news_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_news_videos_news_id",
                table: "news_videos",
                column: "news_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "news_html_descriptions");

            migrationBuilder.DropTable(
                name: "news_parse_editor_settings");

            migrationBuilder.DropTable(
                name: "news_parse_errors");

            migrationBuilder.DropTable(
                name: "news_parse_modified_at_settings_formats");

            migrationBuilder.DropTable(
                name: "news_parse_needs");

            migrationBuilder.DropTable(
                name: "news_parse_network_errors");

            migrationBuilder.DropTable(
                name: "news_parse_picture_settings");

            migrationBuilder.DropTable(
                name: "news_parse_published_at_settings_formats");

            migrationBuilder.DropTable(
                name: "news_parse_sub_title_settings");

            migrationBuilder.DropTable(
                name: "news_parse_video_settings");

            migrationBuilder.DropTable(
                name: "news_pictures");

            migrationBuilder.DropTable(
                name: "news_search_settings");

            migrationBuilder.DropTable(
                name: "news_source_logos");

            migrationBuilder.DropTable(
                name: "news_sub_titles");

            migrationBuilder.DropTable(
                name: "news_text_descriptions");

            migrationBuilder.DropTable(
                name: "news_videos");

            migrationBuilder.DropTable(
                name: "news_parse_modified_at_settings");

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
