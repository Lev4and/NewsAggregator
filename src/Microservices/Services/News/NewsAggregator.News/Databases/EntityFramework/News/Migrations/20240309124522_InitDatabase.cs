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
                name: "news_views",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    news_id = table.Column<Guid>(type: "uuid", nullable: false),
                    ip_address = table.Column<string>(type: "text", nullable: false),
                    viewed_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_views", x => x.id);
                    table.ForeignKey(
                        name: "fk_news_views_news_news_id",
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
                    { new Guid("02acac9b-f048-4d7d-9505-8d2aa8e6a45e"), true, "https://www.interfax.ru/", "Интерфакс" },
                    { new Guid("03c0436b-ebf7-4a97-96b9-54d55c8dd5cd"), true, "https://www.ixbt.com/", "iXBT.com" },
                    { new Guid("05b68ddd-b4de-424b-8f34-f7f54ec12715"), true, "https://tass.ru/", "ТАСС" },
                    { new Guid("0953d5cb-41e3-49ec-9eea-dbbfc1ab67cc"), true, "https://regnum.ru/", "ИА REGNUM" },
                    { new Guid("0a591ee7-614c-4491-a7a9-ffe7c3157917"), true, "https://svpressa.ru/", "СвободнаяПресса" },
                    { new Guid("0c0a1024-262d-4256-9739-b921f8cf6720"), true, "https://www.kommersant.ru/", "Коммерсантъ" },
                    { new Guid("0c34dbe7-aadd-4673-9367-6c705a9519b0"), true, "https://www.womanhit.ru/", "Женский журнал WomanHit.ru" },
                    { new Guid("176e94f0-0804-4650-9bcc-4eb035fb6fa4"), true, "https://www.khl.ru/", "КХЛ" },
                    { new Guid("195d3d87-f062-4a10-890c-93cc5b4e76db"), true, "https://www.kinonews.ru/", "KinoNews.ru" },
                    { new Guid("1d5eee9e-c4a0-4157-a329-5ba8173ec789"), true, "https://www.fontanka.ru/", "ФОНТАНКА.ру" },
                    { new Guid("1d9ee65e-708d-44ce-a3d5-17cc2c04b91f"), true, "https://www.pravda.ru/", "Правда.ру" },
                    { new Guid("25164b7a-b375-4143-b2ed-8437c602fcc4"), true, "https://7days.ru/", "7дней.ru" },
                    { new Guid("258e3b3c-0a88-4a34-86bf-72eb342f9efd"), true, "https://www.avtovzglyad.ru/", "АвтоВзгляд" },
                    { new Guid("2684aa2e-d0e2-407a-bce3-8d0aa977adc9"), true, "https://russian.rt.com/", "RT на русском" },
                    { new Guid("279a61e4-b214-4c4a-9a58-cf2959fece74"), true, "https://www.ntv.ru/", "НТВ" },
                    { new Guid("2a1be939-2c32-4030-af8f-87ba407a9964"), true, "https://www.novorosinform.org/", "Новороссия" },
                    { new Guid("325212dd-78b6-4ce6-9c0c-7823f7c3975c"), true, "https://tsargrad.tv/", "Царьград" },
                    { new Guid("3256cb64-703f-4e40-ab98-24fce7336ac2"), true, "http://www.belta.by/", "БелТА" },
                    { new Guid("4ad9c4f7-0538-4a56-8c2e-2f2844513193"), true, "https://ria.ru/", "РИА Новости" },
                    { new Guid("5299fde1-d2be-4f3d-8a1f-35605285c000"), true, "https://www.starhit.ru/", "Сетевое издание «Онлайн журнал StarHit (СтарХит)" },
                    { new Guid("539df01b-c5f8-4e92-8e6a-a10ece734370"), true, "https://3dnews.ru/", "3Dnews.ru" },
                    { new Guid("581c50a3-1b84-445a-ba63-69480f578b46"), true, "https://www.cybersport.ru/", "Cybersport.ru" },
                    { new Guid("599eae9b-df46-4af2-b1c2-58cbeb39943f"), true, "https://radiosputnik.ru/", "Радио Sputnik" },
                    { new Guid("5bc703c2-1eda-40cc-99fd-a1ee7176033a"), true, "https://www.hltv.org/", "HLTV.org" },
                    { new Guid("65dd16a0-17a4-4fbb-b2b8-d1dbaf845e97"), true, "https://travelask.ru/", "TravelAsk" },
                    { new Guid("6c459642-9fb6-4028-8e72-4c031dd4937a"), true, "https://rg.ru/", "Российская газета" },
                    { new Guid("72035a56-7f9e-4e61-94a8-7af99322ebdd"), true, "https://74.ru/", "74.ru" },
                    { new Guid("77a23870-f64c-4090-9e92-603c7f80ea70"), true, "https://lenta.ru/", "Лента.Ру" },
                    { new Guid("7ee9a821-4a61-4362-808f-dac691997bdf"), true, "https://www.rbc.ru/", "РБК" },
                    { new Guid("82ab9f35-4373-4893-a747-6151efe10d2c"), true, "https://overclockers.ru/", "Overclockers" },
                    { new Guid("864dbd8e-5fed-462f-9e71-aabc04481ca9"), true, "https://www.sports.ru/", "Storts.ru" },
                    { new Guid("886f22e2-9d3e-4a7c-b2a6-a5a8a01c5165"), true, "https://www.kp.ru/", "Комсомольская правда" },
                    { new Guid("890c270c-e037-48a7-89b4-5e5bf409c505"), true, "https://www.1obl.ru/", "Первый областной" },
                    { new Guid("8c08ff73-c2e3-4c06-bc72-0463c84e31ee"), true, "https://ixbt.games/", "iXBT.games" },
                    { new Guid("8c5140f7-2c93-456f-a852-16204716e73c"), true, "https://www.championat.com/", "Чемпионат.com" },
                    { new Guid("8d4e4158-e198-4418-abc6-c5e1cdf04250"), true, "https://www.m24.ru/", "Москва 24" },
                    { new Guid("8f878cca-8778-487c-8862-bf93b0134f26"), true, "https://ura.news/", "Ura.ru" },
                    { new Guid("8fb6b7c9-e4c5-4787-909a-91cb468d4f86"), true, "https://www.zr.ru/", "Журнал \"За рулем\"" },
                    { new Guid("9008d75a-ce62-4f8a-99a4-4403ff1fc123"), true, "https://meduza.io/", "Meduza" },
                    { new Guid("93bf84b9-37b2-43bc-bc5d-b69f25936e0c"), true, "https://stopgame.ru/", "StopGame" },
                    { new Guid("97cf68d9-65d1-48e8-b333-11cc0a590f1f"), true, "https://rusvesna.su/", "Русская весна" },
                    { new Guid("9ef11fb0-edd8-4a8b-a24b-b7d3adc77918"), true, "https://www.5-tv.ru/", "Пятый канал" },
                    { new Guid("a9b85f74-5508-4269-91b1-9b39ee2d6b27"), true, "https://aif.ru/", "Аргументы и факты" },
                    { new Guid("aa190a4a-745e-452c-88ba-2b9155d46c5b"), true, "https://www.nytimes.com/", "The New York Times" },
                    { new Guid("c49b3ba3-3ba6-4ddc-8601-ce3b3d454c9d"), true, "https://iz.ru/", "Известия" },
                    { new Guid("cd575801-0d0c-4a70-9d9d-fb91c459d719"), true, "https://www.finam.ru/", "Финам.Ру" },
                    { new Guid("d561969c-3751-4e81-9837-a5d896707fe4"), true, "https://www.gazeta.ru/", "Газета.Ru" },
                    { new Guid("d6db5c5c-0e21-4aab-8f4b-433afafa26d1"), true, "https://ren.tv/", "РЕН ТВ" },
                    { new Guid("e2292a43-bacb-4797-8f10-7e919caf9c56"), true, "https://smart-lab.ru/", "SMART-LAB" },
                    { new Guid("e9d3d4d6-2c5f-4981-8789-d24ee1e561c2"), true, "https://vz.ru/", "ВЗГЛЯД.РУ" },
                    { new Guid("ec188daf-5a07-485b-a867-9135a382b571"), true, "https://edition.cnn.com/", "CNN" },
                    { new Guid("f533cbff-5433-48f4-a1a1-34e9c89f0821"), true, "https://life.ru/", "Life" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_settings",
                columns: new[] { "id", "html_description_x_path", "source_id", "text_description_x_path", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("0a8ab6d7-8dfd-4e89-b17a-d930991e5c57"), "//div[@class='article_text']", new Guid("a9b85f74-5508-4269-91b1-9b39ee2d6b27"), "//div[@class='article_text']//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("12c214fc-cc69-461c-aa49-9b1feba92c2e"), "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]", new Guid("8d4e4158-e198-4418-abc6-c5e1cdf04250"), "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("16e4ff95-a5bf-489a-a59b-dc1b455c8a62"), "//section[@itemprop='articleBody']/*", new Guid("258e3b3c-0a88-4a34-86bf-72eb342f9efd"), "//section[@itemprop='articleBody']/*[not(name()='script')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("1fc11022-2d88-42ae-bd6d-032758049af4"), "//div[@class='widgets__item__text__inside']/*", new Guid("d6db5c5c-0e21-4aab-8f4b-433afafa26d1"), "//div[@class='widgets__item__text__inside']//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("22036ea4-0190-4ccc-bc0f-5a77c4b78deb"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]", new Guid("0c0a1024-262d-4256-9739-b921f8cf6720"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("276af382-dc02-4eb4-94fe-dcdadb713afe"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview')) and not(contains(@class, 'article__main-image'))]", new Guid("7ee9a821-4a61-4362-808f-dac691997bdf"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview')) and not(contains(@class, 'article__main-image'))]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("2dd377de-9eb7-4b27-adf4-398755baaaee"), "//div[contains(@class, 'article__body')]/*", new Guid("599eae9b-df46-4af2-b1c2-58cbeb39943f"), "//div[contains(@class, 'article__body')]//*[not(name()='script')]/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("339b5526-f1f9-4d89-9f07-68611ccb5919"), "//div[@itemprop='articleBody']/*", new Guid("c49b3ba3-3ba6-4ddc-8601-ce3b3d454c9d"), "//div[@itemprop='articleBody']//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("37ea2837-b550-4a69-a54e-1d17e387ff7c"), "//div[@class='only__text']/*", new Guid("2a1be939-2c32-4030-af8f-87ba407a9964"), "//div[@class='only__text']/*[not(name()='script')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("3b5c605f-a7a1-4d17-98c9-e49c74d10e9f"), "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]", new Guid("f533cbff-5433-48f4-a1a1-34e9c89f0821"), "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("4389214c-a07b-471a-bc95-73b7c495d580"), "//section[@itemprop='articleBody']/*", new Guid("1d5eee9e-c4a0-4157-a329-5ba8173ec789"), "//section[@itemprop='articleBody']//p//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("442fa986-5691-4dc7-aefa-69eea326bf01"), "//div[@class='article-text']/*[not(name()='div' and @class='picture-wrapper')]", new Guid("0953d5cb-41e3-49ec-9eea-dbbfc1ab67cc"), "//div[@class='article-text']/*[not(name()='div' and @class='picture-wrapper')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("44766c3e-3618-47e4-b1c5-e27f4b079424"), "//div[@itemprop='articleBody']/*", new Guid("890c270c-e037-48a7-89b4-5e5bf409c505"), "//div[@itemprop='articleBody']/*//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("48a43db8-ac32-409d-b5d9-3cb2aef71912"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]", new Guid("325212dd-78b6-4ce6-9c0c-7823f7c3975c"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("4e81b91f-d336-4b9c-a506-7b92ec6094d3"), "//div[contains(@class, 'PageContentCommonStyling_text')]/*[not(name() = 'rg-video')]", new Guid("6c459642-9fb6-4028-8e72-4c031dd4937a"), "//div[contains(@class, 'PageContentCommonStyling_text')]/*[not(name() = 'rg-video')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("517c7c39-9682-4e85-962b-ace3a1144ea7"), "//div[contains(@class, 'material-content')]/*", new Guid("82ab9f35-4373-4893-a747-6151efe10d2c"), "//div[contains(@class, 'material-content')]/p//text()", "//a[@class='header']/text()" },
                    { new Guid("578b96e7-9885-43bc-a757-0aec5cddaf5b"), "//div[@data-gtm-el='content-body']/*[not(name()='div' and @data-wide='true')]", new Guid("886f22e2-9d3e-4a7c-b2a6-a5a8a01c5165"), "//div[@data-gtm-el='content-body']/*[not(name()='div' and @data-wide='true')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("5ba45cbe-6e75-4175-85dd-1c9eff7d3d3b"), "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]", new Guid("0a591ee7-614c-4491-a7a9-ffe7c3157917"), "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("5f4d0a7f-fcb4-41ae-987f-2fdf3f456e9d"), "//div[@id='article_body']/*", new Guid("9ef11fb0-edd8-4a8b-a24b-b7d3adc77918"), "//div[@id='article_body']//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("6428b94e-7c36-4f75-b45c-ae076d55dd01"), "//div[@class='newsDetail-content__info']/*[not(name()='h1') and not(name()='h5')]", new Guid("176e94f0-0804-4650-9bcc-4eb035fb6fa4"), "//div[@class='newsDetail-content__info']/*[not(name()='h1') and not(name()='h5')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("6c0da7df-74ef-4b96-b3cd-1a3817de9170"), "//span[@itemprop='articleBody']/*", new Guid("0c34dbe7-aadd-4673-9367-6c705a9519b0"), "//span[@itemprop='articleBody']//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("755c983a-6e37-411f-a6b5-1ef28fcb2abe"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/*[position()>4]", new Guid("539df01b-c5f8-4e92-8e6a-a10ece734370"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/*[position()>4 and not(name()='script')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("8334ba09-9b47-4ea4-8d3f-feb02deceb09"), "//div[contains(@class, 'js-mediator-article')]/*[position()>1]", new Guid("581c50a3-1b84-445a-ba63-69480f578b46"), "//div[contains(@class, 'js-mediator-article')]/*[position()>1]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("8686874a-05a4-42ea-80bc-c9ad27c3d8ff"), "//article/div[@class='article-content']/*[not(@class)]", new Guid("8c5140f7-2c93-456f-a852-16204716e73c"), "//article/div[@class='article-content']/*[not(@class)]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("880d766c-5672-457f-98ca-60ca11637984"), "//div[@itemprop='articleBody']/*", new Guid("65dd16a0-17a4-4fbb-b2b8-d1dbaf845e97"), "//div[@itemprop='articleBody']//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("8ac035cc-a118-4e61-bbf3-db636e336f4f"), "//div[@id='content']//div[contains(@class, 'topic')]/div[@class='content']/*", new Guid("e2292a43-bacb-4797-8f10-7e919caf9c56"), "//div[@id='content']//div[contains(@class, 'topic')]/div[@class='content']//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("8fbb4720-0c12-4be3-a087-fdfd04595e67"), "//section[@name='articleBody']/*", new Guid("aa190a4a-745e-452c-88ba-2b9155d46c5b"), "//section[@name='articleBody']/*//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("926554c1-213a-4dfd-96ed-c5b0db283ff2"), "//article/div[@class='news_text']", new Guid("e9d3d4d6-2c5f-4981-8789-d24ee1e561c2"), "//article/div[@class='news_text']//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("981e6415-1c99-49e7-9faf-55c35eed1c83"), "//div[@itemprop='articleBody']/*[position()>2]", new Guid("03c0436b-ebf7-4a97-96b9-54d55c8dd5cd"), "//div[@itemprop='articleBody']/*[position()>2]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("9f42918a-5400-4abe-8c96-efde954ab87e"), "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]", new Guid("1d9ee65e-708d-44ce-a3d5-17cc2c04b91f"), "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]//text()", "//meta[@name='title']/@content" },
                    { new Guid("a0f009fa-c0de-48bf-973a-a0751d04b717"), "//div[@itemprop='articleBody']/*[not(name()='figure' and position()=1)]", new Guid("72035a56-7f9e-4e61-94a8-7af99322ebdd"), "//div[@itemprop='articleBody']/*[not(name()='figure') and not(lazyhydrate)]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("a2bfe55a-6d48-4d2e-8b27-907233517a3e"), "//article/*", new Guid("05b68ddd-b4de-424b-8f34-f7f54ec12715"), "//article/*//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("a2d6e3f4-6fda-46e2-aa85-39eb18c85de9"), "//div[@class='news-content__body']//div[contains(@class, 'content-text')]/*", new Guid("279a61e4-b214-4c4a-9a58-cf2959fece74"), "//div[@class='news-content__body']//div[contains(@class, 'content-text')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("ae9c317a-7ef6-41a4-95f1-3ca87eed0277"), "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]", new Guid("02acac9b-f048-4d7d-9505-8d2aa8e6a45e"), "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("b0ad231f-52d9-4cdc-ab56-4e1b73411aed"), "//div[@class='js-mediator-article']", new Guid("3256cb64-703f-4e40-ab98-24fce7336ac2"), "//div[@class='js-mediator-article']//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("b94ffa83-703d-49d0-982d-ec5c8a5bd084"), "//article//div[@class='newstext-con']/*[position()>2]", new Guid("5bc703c2-1eda-40cc-99fd-a1ee7176033a"), "//article//div[@class='newstext-con']/*[position()>2]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("c76d5ca3-52df-4f4f-991a-05b65407daf7"), "//div[contains(@class, 'news-item__content')]", new Guid("864dbd8e-5fed-462f-9e71-aabc04481ca9"), "//div[contains(@class, 'news-item__content')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("c80caa5e-9567-4654-94c6-1f6828fc2d0e"), "//div[contains(@class, 'article__body')]", new Guid("4ad9c4f7-0538-4a56-8c2e-2f2844513193"), "//div[contains(@class, 'article__body')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("c95b3a67-c65c-435e-b1dc-96aaac8a13d9"), "//div[@class='material-7days__paragraf-content']/*[not(name()='div' and @itemprop='image' and position()=1)]", new Guid("25164b7a-b375-4143-b2ed-8437c602fcc4"), "//div[@class='material-7days__paragraf-content']//p//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("cb551d20-f4cf-47a6-bcba-5428dbb555e1"), "//div[@class='textart']/div[not(@class)]/*", new Guid("195d3d87-f062-4a10-890c-93cc5b4e76db"), "//div[@class='textart']/div[not(@class)]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("d28c88f1-9cb9-4a86-a2bf-d5debde5a805"), "//div[@itemprop='articleBody']/*[not(name()='div')]", new Guid("8f878cca-8778-487c-8862-bf93b0134f26"), "//div[@itemprop='articleBody']/*[not(name()='div')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("d29bb306-e411-466c-8862-3515266e4a4b"), "//div[@itemprop='articleBody']/*", new Guid("ec188daf-5a07-485b-a867-9135a382b571"), "//div[@itemprop='articleBody']/*//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("d6297613-fd5c-4d45-ba9c-4a8e78b558a3"), "//div[contains(@class, 'styled__StoryBody')]/*[not(name()='p' and contains(@class, 'styled__StoryParagraph') and position()=1) and not(name()='div' and contains(@class, 'styled__StoryImgContainer') and position()=2)]", new Guid("8fb6b7c9-e4c5-4787-909a-91cb468d4f86"), "//div[contains(@class, 'styled__StoryBody')]/*[not(name()='p' and contains(@class, 'styled__StoryParagraph') and position()=1) and not(name()='div' and contains(@class, 'styled__StoryImgContainer') and position()=2)]//text()", "//meta[@name='og:title']/@content" },
                    { new Guid("df6c1dc1-f352-4b80-84a8-54a4fd90246c"), "//div[contains(@class, 'article__text ')]", new Guid("2684aa2e-d0e2-407a-bce3-8d0aa977adc9"), "//div[contains(@class, 'article__text ')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("e01cf720-5a6c-4f99-9acc-b45ff8b0b277"), "//div[@class='GeneralMaterial-module-article']/*[position()>1]", new Guid("9008d75a-ce62-4f8a-99a4-4403ff1fc123"), "//div[@class='GeneralMaterial-module-article']/*[position()>1]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("e89d9898-a84a-43b2-a909-85ed4753a60a"), "//div[contains(@class, 'field-type-text-long')]/*", new Guid("97cf68d9-65d1-48e8-b333-11cc0a590f1f"), "//div[contains(@class, 'field-type-text-long')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("f50e1187-7865-47c5-9364-b981c479421b"), "//section[contains(@class, '_page-section')]/div[contains(@class, '_content_')]/*", new Guid("93bf84b9-37b2-43bc-bc5d-b69f25936e0c"), "//section[contains(@class, '_page-section')]/div[contains(@class, '_content_')]/*[contains(@class, '_text_')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("f59e0993-0b63-4be7-9f13-49a92f8b8301"), "//div[@itemprop='articleBody']/*", new Guid("d561969c-3751-4e81-9837-a5d896707fe4"), "//div[@itemprop='articleBody']/*//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("f62b9c01-f69e-4ca1-b306-772184659e30"), "//div[@class='topic-body__content']", new Guid("77a23870-f64c-4090-9e92-603c7f80ea70"), "//div[@class='topic-body__content']//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("f672a55c-4c9e-4684-8973-16306be0902a"), "//div[contains(@class, 'finfin-local-plugin-publication-item-item-')]/*", new Guid("cd575801-0d0c-4a70-9d9d-fb91c459d719"), "//div[contains(@class, 'finfin-local-plugin-publication-item-item-')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("f7fc7d0c-b481-4c99-9e58-a516a14cb4b0"), "//div[contains(@class, 'container-fluid shifted') and not(p[@class='announce lead']) and not(h1) and not(hr)]", new Guid("8c08ff73-c2e3-4c06-bc72-0463c84e31ee"), "//div[contains(@class, 'container-fluid shifted') and not(p[@class='announce lead']) and not(h1) and not(hr)]//text()", "//meta[@name='og:title']/@content" },
                    { new Guid("fb70f1d7-bdb3-4352-bfde-704e077b7c7c"), "//section[@itemprop='articleBody']/div[@class='ds-article-content-block-and-creative-container' and position()>1]", new Guid("5299fde1-d2be-4f3d-8a1f-35605285c000"), "//section[@itemprop='articleBody']/div[@class='ds-article-content-block-and-creative-container' and position()>1]//text()", "//meta[@property='og:title']/@content" }
                });

            migrationBuilder.InsertData(
                table: "news_search_settings",
                columns: new[] { "id", "news_site_url", "news_url_x_path", "source_id" },
                values: new object[,]
                {
                    { new Guid("10e9ca77-02ec-4deb-96b0-c92295c53ffc"), "https://www.starhit.ru/novosti/", "//a[@class='announce-inline-tile__label-container']/@href", new Guid("5299fde1-d2be-4f3d-8a1f-35605285c000") },
                    { new Guid("11c26db9-12ab-4434-9549-af4da5b9ecbf"), "https://regnum.ru/news", "//a[not(@href='/news/') and starts-with(@href, '/news/')]/@href", new Guid("0953d5cb-41e3-49ec-9eea-dbbfc1ab67cc") },
                    { new Guid("1775c419-cf22-49fa-948f-d54bdfb78d24"), "https://3dnews.ru/news/", "//div[@class='news-feed-all']//a[@class='entry-header']/h1/../@href", new Guid("539df01b-c5f8-4e92-8e6a-a10ece734370") },
                    { new Guid("191de3ae-7e85-4f6b-9584-9333bf06e511"), "https://www.championat.com/news/1.html?utm_source=button&utm_medium=news", "//a[contains(@href, 'news-') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("8c5140f7-2c93-456f-a852-16204716e73c") },
                    { new Guid("29feaabf-7026-4087-84af-636d54e01c87"), "https://russian.rt.com/", "//a[contains(@class, 'link') and contains(@href, 'news/')]/@href", new Guid("2684aa2e-d0e2-407a-bce3-8d0aa977adc9") },
                    { new Guid("2eaa2319-e1ca-4c11-8bab-37df0b62302b"), "https://www.rbc.ru/", "//a[contains(@href, 'https://www.rbc.ru/') and contains(@href, '?from=')]/@href", new Guid("7ee9a821-4a61-4362-808f-dac691997bdf") },
                    { new Guid("2fda8440-464a-427f-a96d-aeaf83f48755"), "https://7days.ru/news/", "//a[contains(@class, '7days__item_href') and starts-with(@href, '/news/')]/@href", new Guid("25164b7a-b375-4143-b2ed-8437c602fcc4") },
                    { new Guid("326dcf86-0645-4faf-bc5d-4a4f5ebc9042"), "https://www.hltv.org/", "//a[contains(@href, '/news/')]/@href", new Guid("5bc703c2-1eda-40cc-99fd-a1ee7176033a") },
                    { new Guid("36baa463-9cf6-4f1c-8716-02d14e267356"), "https://www.sports.ru/news/", "//a[contains(@href, '.html') and not(contains(@href, '.html#comments')) and not (contains(@href, '/blogs/'))]/@href", new Guid("864dbd8e-5fed-462f-9e71-aabc04481ca9") },
                    { new Guid("376139cb-9f6f-4059-8708-435320984f0e"), "https://tass.ru/", "//a[contains(@class, 'tass_pkg_link-v5WdK') and contains(substring(@href, 2), '/') and not(contains(@href, '/spec/')) and not(contains(@href, 'spec.tass.ru'))]/@href", new Guid("05b68ddd-b4de-424b-8f34-f7f54ec12715") },
                    { new Guid("46ec2d1e-819b-4c6d-8d78-bfbdd44d37dc"), "https://www.novorosinform.org/", "//a[contains(@href, '.html')]/@href", new Guid("2a1be939-2c32-4030-af8f-87ba407a9964") },
                    { new Guid("49aebed4-d5e9-4d75-93f2-5875b77d8b51"), "https://overclockers.ru/news", "//div[contains(@class, 'event')]//a[not(contains(@href, '#comments'))]/@href", new Guid("82ab9f35-4373-4893-a747-6151efe10d2c") },
                    { new Guid("4a2c7618-37fd-48dd-b8a2-9948a8fe90b3"), "https://www.kp.ru/", "//a[contains(@href, '/news/')]/@href", new Guid("886f22e2-9d3e-4a7c-b2a6-a5a8a01c5165") },
                    { new Guid("5aec376f-24db-45a3-8dd6-e59f62f61733"), "https://edition.cnn.com/", "//a[contains(@href, '.html')]/@href", new Guid("ec188daf-5a07-485b-a867-9135a382b571") },
                    { new Guid("5da26075-4574-4b57-bf5d-4346f8427d43"), "http://www.belta.by/", "//a[contains(@href, 'www.belta.by') and contains(@href, '/view/')]/@href", new Guid("3256cb64-703f-4e40-ab98-24fce7336ac2") },
                    { new Guid("620c4128-f3a5-4923-ba61-0fc51af28cff"), "https://smart-lab.ru/news/", "//a[not(@href='/blog/') and starts-with(@href, '/blog/') and contains(@href, '.php')]/@href", new Guid("e2292a43-bacb-4797-8f10-7e919caf9c56") },
                    { new Guid("640708eb-2b66-436d-9422-8e59ae9ea881"), "https://svpressa.ru/all/news/", "//a[contains(@href, '/news/') and not(contains(@href, '?')) and not(starts-with(@href, '/all/news/'))]/@href", new Guid("0a591ee7-614c-4491-a7a9-ffe7c3157917") },
                    { new Guid("6a74ce54-2478-40e1-85b8-2ae0f07769b6"), "https://www.5-tv.ru/news/", "//a[not(@href='https://www.5-tv.ru/news/') and starts-with(@href, 'https://www.5-tv.ru/news/')]/@href", new Guid("9ef11fb0-edd8-4a8b-a24b-b7d3adc77918") },
                    { new Guid("6df2694c-77b7-45ac-bb96-474a6afad3b8"), "https://www.ntv.ru/novosti/", "//a[not(@href='/novosti/') and not(@href='/novosti/authors') and starts-with(@href, '/novosti/')]/@href", new Guid("279a61e4-b214-4c4a-9a58-cf2959fece74") },
                    { new Guid("6f6df8c8-a429-449a-a80e-2091a041b7e0"), "https://travelask.ru/news", "//a[not(@href='/news/') and starts-with(@href, '/news/')]/@href", new Guid("65dd16a0-17a4-4fbb-b2b8-d1dbaf845e97") },
                    { new Guid("70568003-2cd3-449b-b156-7fe24a9ab7e4"), "https://meduza.io/", "//a[not(@href='/news/') and starts-with(@href, '/news/')]/@href", new Guid("9008d75a-ce62-4f8a-99a4-4403ff1fc123") },
                    { new Guid("71c33cc0-0eeb-4ab9-acdf-05d20270c7a1"), "https://stopgame.ru/news", "//div[contains(@class, 'list-view')]//div[contains(@class, '_card')]/a/@href", new Guid("93bf84b9-37b2-43bc-bc5d-b69f25936e0c") },
                    { new Guid("7223921e-ecf8-4f56-966b-369da8c8d54e"), "https://www.pravda.ru/", "//a[contains(@href, '/news/') and not(@href='https://www.pravda.ru/news/')]/@href", new Guid("1d9ee65e-708d-44ce-a3d5-17cc2c04b91f") },
                    { new Guid("80f0deb0-1a71-473e-9fe9-f6985319e73d"), "https://tsargrad.tv/", "//a[contains(@class, 'news-item__link')]/@href", new Guid("325212dd-78b6-4ce6-9c0c-7823f7c3975c") },
                    { new Guid("83a8eb53-f37f-47d0-b822-a66a40ce031a"), "https://www.interfax.ru/", "//div[@class='timeline']//a[@tabindex=5]/@href", new Guid("02acac9b-f048-4d7d-9505-8d2aa8e6a45e") },
                    { new Guid("89f5d344-c0e5-4edc-bdb8-dd7ca0d80866"), "https://ren.tv/news/", "//a[starts-with(@href, '/news/')]/@href", new Guid("d6db5c5c-0e21-4aab-8f4b-433afafa26d1") },
                    { new Guid("8da158fb-9397-432c-89fa-0a81fcfa1e25"), "https://www.kommersant.ru/", "//a[contains(@href, '/doc/') and contains(@href, '?from=')]/@href", new Guid("0c0a1024-262d-4256-9739-b921f8cf6720") },
                    { new Guid("9ca4c33d-8a0c-48f5-b028-b21ca8e26903"), "https://ura.news/", "//a[contains(@href, '/news/')]/@href", new Guid("8f878cca-8778-487c-8862-bf93b0134f26") },
                    { new Guid("a4ac87ae-e85c-4489-9d07-7df12cbce151"), "https://rusvesna.su/news", "//a[not(@href='/news/') and starts-with(@href, '/news/')]/@href", new Guid("97cf68d9-65d1-48e8-b333-11cc0a590f1f") },
                    { new Guid("a647f5ef-1c16-4e14-ae4f-1a9a0339f50b"), "https://ixbt.games/news/", "//a[@class='card-link']/@href", new Guid("8c08ff73-c2e3-4c06-bc72-0463c84e31ee") },
                    { new Guid("a6e7afdd-4c46-4805-b320-2b379a6a7ffe"), "https://aif.ru/", "//span[contains(@class, 'item_text__title')]/../@href", new Guid("a9b85f74-5508-4269-91b1-9b39ee2d6b27") },
                    { new Guid("adc9b75b-aa51-4370-bfd0-984645cbf511"), "https://www.fontanka.ru/24hours_news.html", "//section//ul/li[@class='IBae3']//a[@class='IBd3']/@href", new Guid("1d5eee9e-c4a0-4157-a329-5ba8173ec789") },
                    { new Guid("ae298fdd-6a37-466a-a0e3-092f05300651"), "https://www.1obl.ru/news/", "//a[starts-with(@href, '/news/') and not(contains(@href, '?'))]/@href", new Guid("890c270c-e037-48a7-89b4-5e5bf409c505") },
                    { new Guid("ae551f9e-ffea-4abc-b3a2-81c503898c79"), "https://www.zr.ru/news/", "//a[contains(@href, '/news/') and not(starts-with(@href, '/news/')) and not(starts-with(@href, 'https://'))]/@href", new Guid("8fb6b7c9-e4c5-4787-909a-91cb468d4f86") },
                    { new Guid("b540ef19-ee0e-4ee9-89b8-473aed71d1c5"), "https://www.cybersport.ru/", "//a[contains(@href, '/tags/')]/@href", new Guid("581c50a3-1b84-445a-ba63-69480f578b46") },
                    { new Guid("bbbdbc51-980f-4418-8a87-f53a30f09b61"), "https://74.ru/", "//a[starts-with(@href, '/text/') and not(contains(@href, '?')) and not(contains(@href, 'comments/')) and not(@href='/text/')]/@href", new Guid("72035a56-7f9e-4e61-94a8-7af99322ebdd") },
                    { new Guid("c162d88c-4153-4f13-99e9-398388994d50"), "https://radiosputnik.ru/", "//a[starts-with(@href, 'https://radiosputnik.ru/') and contains(@href, '.html')]/@href", new Guid("599eae9b-df46-4af2-b1c2-58cbeb39943f") },
                    { new Guid("c4b2fb8d-9b0f-432e-a39b-8ad78f27881a"), "https://vz.ru/", "//a[contains(@href, '.html') and not(contains(@href, '#comments')) and not(contains(@href, '?')) and not(contains(@href, '/about/'))]/@href", new Guid("e9d3d4d6-2c5f-4981-8789-d24ee1e561c2") },
                    { new Guid("c87554a5-5f09-4da3-aa18-b4b382dd3368"), "https://lenta.ru/", "//a[starts-with(@href, '/news/')]/@href", new Guid("77a23870-f64c-4090-9e92-603c7f80ea70") },
                    { new Guid("c971c3c8-7069-4317-8cff-2fd4ce42c708"), "https://ria.ru/", "//a[contains(@class, 'cell-list__item-link')]/@href", new Guid("4ad9c4f7-0538-4a56-8c2e-2f2844513193") },
                    { new Guid("cc405744-054a-4c78-804e-f1cf03a00887"), "https://www.kinonews.ru/news/", "//a[contains(@href, '/news_') and not(contains(@href, 'comments')) and not(contains(@href, 'news_p'))]/@href", new Guid("195d3d87-f062-4a10-890c-93cc5b4e76db") },
                    { new Guid("d438464d-b7e5-4d0a-b119-5fe8c1277dbe"), "https://www.avtovzglyad.ru/news/", "//a[@class='news-card__link']/@href", new Guid("258e3b3c-0a88-4a34-86bf-72eb342f9efd") },
                    { new Guid("d8ab024e-42d1-4e1e-9084-d142caf10a8d"), "https://www.finam.ru/", "//a[starts-with(@href, 'publications/item/') or starts-with(@href, '/publications/item/')]/@href", new Guid("cd575801-0d0c-4a70-9d9d-fb91c459d719") },
                    { new Guid("db3c651c-099e-479d-9046-c8dc7f613784"), "https://life.ru/s/novosti", "//a[contains(@href, '/p/')]/@href", new Guid("f533cbff-5433-48f4-a1a1-34e9c89f0821") },
                    { new Guid("dbd4ce72-db4f-4775-b589-c05c09f0107e"), "https://www.nytimes.com/", "//a[contains(@href, '.html')]/@href", new Guid("aa190a4a-745e-452c-88ba-2b9155d46c5b") },
                    { new Guid("df073432-c46c-4cbd-a741-faa5f5eb0d85"), "https://www.m24.ru/", "//a[contains(@href, '/news/')]/@href", new Guid("8d4e4158-e198-4418-abc6-c5e1cdf04250") },
                    { new Guid("df1a0482-9390-4c6b-acd3-79f0dbc37f06"), "https://rg.ru/", "//a[contains(@href, '.html')]/@href", new Guid("6c459642-9fb6-4028-8e72-4c031dd4937a") },
                    { new Guid("dfc290e0-11b6-475c-a551-96bbdf1aa3bc"), "https://www.gazeta.ru/news/", "//a[contains(@href, '/news/') and contains(@href, '.shtml') and not(contains(@href, '?'))]/@href", new Guid("d561969c-3751-4e81-9837-a5d896707fe4") },
                    { new Guid("e4da0ae9-1cc2-4355-885b-b8c3876fba3a"), "https://iz.ru/news/", "//a[contains(@href, '?main_click')]/@href", new Guid("c49b3ba3-3ba6-4ddc-8601-ce3b3d454c9d") },
                    { new Guid("f2c1132c-577c-4112-b2b9-06a84ab35419"), "https://www.womanhit.ru/", "//a[not(@href='/stars/news/') and starts-with(@href, '/stars/news/')]/@href", new Guid("0c34dbe7-aadd-4673-9367-6c705a9519b0") },
                    { new Guid("f5f6520c-66d2-438d-b8a2-6397522c5cec"), "https://www.khl.ru/news/", "//a[starts-with(@href, '/news/') and contains(@href, '.html')]/@href", new Guid("176e94f0-0804-4650-9bcc-4eb035fb6fa4") },
                    { new Guid("fd317222-64b8-4e6c-9a47-5c648cdffcc4"), "https://www.ixbt.com/news/", "//a[starts-with(@href, '/news/') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("03c0436b-ebf7-4a97-96b9-54d55c8dd5cd") }
                });

            migrationBuilder.InsertData(
                table: "news_source_logos",
                columns: new[] { "id", "original", "small", "source_id" },
                values: new object[,]
                {
                    { new Guid("0a574e2c-a69e-4cdc-853c-363604de2bc5"), "https://meduza.io/apple-touch-icon-180.png", "https://meduza.io/favicon-32x32.png", new Guid("9008d75a-ce62-4f8a-99a4-4403ff1fc123") },
                    { new Guid("125c6947-0fcd-481c-8d9f-34c81bf08df9"), "https://cdn.hsmedia.ru/public/favicon/starhit/apple-touch-icon.png", "https://cdn.hsmedia.ru/public/favicon/starhit/favicon.png", new Guid("5299fde1-d2be-4f3d-8a1f-35605285c000") },
                    { new Guid("14a5646d-daed-4f7f-aa8d-af472346df13"), "https://stopgame.ru/favicon_512.png", "https://stopgame.ru/favicon.ico", new Guid("93bf84b9-37b2-43bc-bc5d-b69f25936e0c") },
                    { new Guid("14ceaf35-6234-4171-ad73-2e00c9c2aa53"), "https://tsargrad.tv/favicons/apple-touch-icon-180x180.png?s2", "https://tsargrad.tv/favicons/favicon-32x32.png?s2", new Guid("325212dd-78b6-4ce6-9c0c-7823f7c3975c") },
                    { new Guid("1e13e02b-4fe1-48dc-bd4f-8094d4c98a55"), "https://cdn.iz.ru/profiles/portal/themes/purple/images/favicons/android-icon-192x192.png", "https://cdn.iz.ru/profiles/portal/themes/purple/images/favicons/favicon-32x32.png", new Guid("c49b3ba3-3ba6-4ddc-8601-ce3b3d454c9d") },
                    { new Guid("22d3a806-a978-4329-bf3a-de4fe2c3c174"), "https://st.championat.com/i/favicon/apple-touch-icon.png", "https://st.championat.com/i/favicon/favicon-32x32.png", new Guid("8c5140f7-2c93-456f-a852-16204716e73c") },
                    { new Guid("23a3f516-271d-4823-8913-f044e9671a9c"), "https://www.pravda.ru/pix/apple-touch-icon.png", "https://www.pravda.ru/favicon.ico", new Guid("1d9ee65e-708d-44ce-a3d5-17cc2c04b91f") },
                    { new Guid("28a33c2a-7e6d-4d07-ab7c-8bad8eda6bf1"), "https://www.hltv.org/img/static/favicon/apple-touch-icon.png", "https://www.hltv.org/img/static/favicon/favicon-32x32.png", new Guid("5bc703c2-1eda-40cc-99fd-a1ee7176033a") },
                    { new Guid("2e752080-9a59-4f72-a37f-8b0ed31055aa"), "https://www.kinonews.ru/favicon.ico", "https://www.kinonews.ru/favicon.ico", new Guid("195d3d87-f062-4a10-890c-93cc5b4e76db") },
                    { new Guid("3073fd72-7d89-4d71-9271-d7b945d6d630"), "https://edition.cnn.com/media/sites/cnn/apple-touch-icon.png", "https://edition.cnn.com/media/sites/cnn/favicon.ico", new Guid("ec188daf-5a07-485b-a867-9135a382b571") },
                    { new Guid("317663f0-7c0b-4a17-b4d5-f9b216fe0ede"), "https://overclockers.ru/assets/apple-touch-icon-120x120.png", "https://overclockers.ru/assets/apple-touch-icon.png", new Guid("82ab9f35-4373-4893-a747-6151efe10d2c") },
                    { new Guid("3713d005-84c9-4a06-9611-609b5bf5957e"), "https://aif.ru/img/icon/apple-touch-icon.png?44f", "https://aif.ru/img/icon/favicon-32x32.png?44f", new Guid("a9b85f74-5508-4269-91b1-9b39ee2d6b27") },
                    { new Guid("371abc69-86f8-4380-b0fb-691663c16ff1"), "https://rusvesna.su/favicon.ico", "https://rusvesna.su/favicon.ico", new Guid("97cf68d9-65d1-48e8-b333-11cc0a590f1f") },
                    { new Guid("39935288-f67f-4fb4-a641-01a516810881"), "https://s.rbk.ru/v10_rbcnews_static/common/common-10.10.120/images/android-chrome-512x512.png", "https://s.rbk.ru/v10_rbcnews_static/common/common-10.10.120/images/favicon.png", new Guid("7ee9a821-4a61-4362-808f-dac691997bdf") },
                    { new Guid("3bba7623-6471-4241-9af5-e1924375ac7b"), "https://cdn-static.ntv.ru/images/favicons/android-chrome-192x192.png", "https://cdn-static.ntv.ru/images/favicons/favicon-32x32.png", new Guid("279a61e4-b214-4c4a-9a58-cf2959fece74") },
                    { new Guid("3ecbc73b-abcf-46f1-a7bf-b185c9a02a19"), "https://www.m24.ru/img/fav/apple-touch-icon.png", "https://www.m24.ru/img/fav/favicon-32x32.png", new Guid("8d4e4158-e198-4418-abc6-c5e1cdf04250") },
                    { new Guid("3ed0f08e-ec3b-4720-b813-53da7d37e9bf"), "https://svpressa.ru/favicon-96x96.png?v=1471426270000", "https://svpressa.ru/favicon-32x32.png?v=1471426270000", new Guid("0a591ee7-614c-4491-a7a9-ffe7c3157917") },
                    { new Guid("45fee38d-2bd6-4a90-b50d-ac586b8d7e37"), "https://static.ngs.ru/jtnews/dist/static/favicons/apple/apple-favicon-74-180.png", "https://static.ngs.ru/jtnews/dist/static/favicons/favicon-rugion-32.ico", new Guid("72035a56-7f9e-4e61-94a8-7af99322ebdd") },
                    { new Guid("4f3db552-b7a4-4ce3-8746-dac9ac682e56"), "https://im.kommersant.ru/ContentFlex/images/favicons2020/apple-touch-icon-180.png", "https://im.kommersant.ru/ContentFlex/images/favicons2020/favicon-32.png", new Guid("0c0a1024-262d-4256-9739-b921f8cf6720") },
                    { new Guid("55fb817f-f231-4cfe-bf59-b83fefd5cf2c"), "https://static.gazeta.ru/nm2021/img/icons/favicon.svg", "https://static.gazeta.ru/nm2021/img/icons/favicon.svg", new Guid("d561969c-3751-4e81-9837-a5d896707fe4") },
                    { new Guid("569457c2-d0ca-4451-a54d-ddf193e070db"), "https://www.ixbt.com/favicon.ico", "https://www.ixbt.com/favicon.ico", new Guid("03c0436b-ebf7-4a97-96b9-54d55c8dd5cd") },
                    { new Guid("5ac9f79e-1574-4f5c-9ce1-8b4245fb2b38"), "https://www.sports.ru/apple-touch-icon-1024.png", "https://www.sports.ru/apple-touch-icon-76.png", new Guid("864dbd8e-5fed-462f-9e71-aabc04481ca9") },
                    { new Guid("62a9eb4e-862d-4f42-9dbf-683501dddcf1"), "https://www.novorosinform.org/favicon.ico?v3", "https://www.novorosinform.org/favicon.ico?v3", new Guid("2a1be939-2c32-4030-af8f-87ba407a9964") },
                    { new Guid("6b2696b6-e68b-4791-b45b-b8773c5bf250"), "https://smart-lab.ru/templates/skin/smart-lab-x3/images/favicon.ico", "https://smart-lab.ru/templates/skin/smart-lab-x3/images/favicon.ico", new Guid("e2292a43-bacb-4797-8f10-7e919caf9c56") },
                    { new Guid("6bbbb550-87b2-42e6-ae76-978a41a693f8"), "https://ura.news/apple-touch-icon.png", "https://s.ura.news/favicon.ico?3", new Guid("8f878cca-8778-487c-8862-bf93b0134f26") },
                    { new Guid("7eb8347a-feb9-4e11-9196-e23c7b12cc33"), "https://www.fontanka.ru/static/assets/favicons/apple/apple-favicon-180.png", "https://www.fontanka.ru/static/assets/favicons/apple/apple-favicon-76-precomposed.png", new Guid("1d5eee9e-c4a0-4157-a329-5ba8173ec789") },
                    { new Guid("7f9d4632-dec4-4ded-8e92-86930bce32a1"), "https://www.zr.ru/favicons/safari-pinned-tab.svg", "https://www.zr.ru/favicons/favicon.ico", new Guid("8fb6b7c9-e4c5-4787-909a-91cb468d4f86") },
                    { new Guid("848aeb5f-ceec-4b74-a189-4d77e3b4cd96"), "https://vz.ru/apple-touch-icon.png", "https://vz.ru/static/images/favicon.ico", new Guid("e9d3d4d6-2c5f-4981-8789-d24ee1e561c2") },
                    { new Guid("86b06b1a-8cb6-45e3-90b3-6da1dd44d755"), "https://www.nytimes.com/vi-assets/static-assets/apple-touch-icon-28865b72953380a40aa43318108876cb.png", "https://www.nytimes.com/vi-assets/static-assets/ios-default-homescreen-57x57-dark-b395ebcad5b63aff9285aab58e31035e.png", new Guid("aa190a4a-745e-452c-88ba-2b9155d46c5b") },
                    { new Guid("893fc5eb-a0bc-48e5-9cd8-1b0448d937a5"), "https://s9.travelask.ru/favicons/apple-touch-icon-180x180.png", "https://s9.travelask.ru/favicons/favicon-32x32.png", new Guid("65dd16a0-17a4-4fbb-b2b8-d1dbaf845e97") },
                    { new Guid("8c516a4c-5125-46a7-96c1-304bd89c34f8"), "https://www.finam.ru/favicon-144x144.png", "https://www.finam.ru/favicon.png", new Guid("cd575801-0d0c-4a70-9d9d-fb91c459d719") },
                    { new Guid("8c99a21f-b086-4635-bcc3-22d4c0f74ce6"), "https://www.belta.by/images/storage/banners/000016_a133e848cb2e7b1debb7102d19e4d139_work.svg", "https://www.belta.by/images/storage/banners/000016_a133e848cb2e7b1debb7102d19e4d139_work.svg", new Guid("3256cb64-703f-4e40-ab98-24fce7336ac2") },
                    { new Guid("a1fc72ed-5bb4-49d1-8562-6b859f8cc063"), "https://www.womanhit.ru/static/front/img/favicon.ico?v=2", "https://www.womanhit.ru/static/front/img/favicon.ico?v=2", new Guid("0c34dbe7-aadd-4673-9367-6c705a9519b0") },
                    { new Guid("a2fc627a-9f68-4751-9580-c8f6a1f59c91"), "https://cdnstatic.rg.ru/images/touch-icon-ipad-retina_512x512.png", "https://rg.ru/favicon.ico", new Guid("6c459642-9fb6-4028-8e72-4c031dd4937a") },
                    { new Guid("a5c9b0ab-aea6-4da8-9ead-ab279d787b7a"), "https://www.avtovzglyad.ru/static/images/favicon/safari-pinned-tab.svg", "https://www.avtovzglyad.ru/static/images/favicon/favicon-32x32.png", new Guid("258e3b3c-0a88-4a34-86bf-72eb342f9efd") },
                    { new Guid("a6987146-1946-4129-836e-6bc7c30f1e17"), "https://regnum.ru/favicons/apple-touch-icon.png?v=202305", "https://regnum.ru/favicons/favicon-32x32.png?v=202305", new Guid("0953d5cb-41e3-49ec-9eea-dbbfc1ab67cc") },
                    { new Guid("ab40ad3e-3cb4-42be-8829-313406fa0ac9"), "https://www.khl.ru/img/icons/152x152.png", "https://www.khl.ru/img/icons/32x32.png", new Guid("176e94f0-0804-4650-9bcc-4eb035fb6fa4") },
                    { new Guid("b793c42e-add0-4056-8a37-dd822d9c1a19"), "https://cdnn21.img.ria.ru/i/favicons/favicon.svg", "https://cdnn21.img.ria.ru/i/favicons/favicon.ico", new Guid("4ad9c4f7-0538-4a56-8c2e-2f2844513193") },
                    { new Guid("be2ab088-9fc0-465b-ae6f-5a864e777a09"), "https://www.cybersport.ru/favicon-192x192.png", "https://www.cybersport.ru/favicon-32x32.png", new Guid("581c50a3-1b84-445a-ba63-69480f578b46") },
                    { new Guid("d1aa34c7-f889-4d8d-99cc-2eca0cd3d747"), "https://ixbt.games/images/favicon/gt/apple-touch-icon.png", "https://ixbt.games/images/favicon/gt/apple-touch-icon.png", new Guid("8c08ff73-c2e3-4c06-bc72-0463c84e31ee") },
                    { new Guid("d4a631fe-3ce4-4aa8-b2e6-e6d1039cfcef"), "https://img5tv.cdnvideo.ru/shared/img/favicon_24.png", "https://img5tv.cdnvideo.ru/shared/img/favicon_24.png", new Guid("9ef11fb0-edd8-4a8b-a24b-b7d3adc77918") },
                    { new Guid("dff4f6d5-6ab1-4ba6-855a-df4728c68587"), "https://icdn.lenta.ru/images/icons/icon-256x256.png", "https://icdn.lenta.ru/favicon.ico", new Guid("77a23870-f64c-4090-9e92-603c7f80ea70") },
                    { new Guid("e13854f2-09b9-4ff4-96b5-820ddd1ac180"), "https://www.interfax.ru/touch-icon-ipad-retina.png", "https://www.interfax.ru/touch-icon-iphone.png", new Guid("02acac9b-f048-4d7d-9505-8d2aa8e6a45e") },
                    { new Guid("e23674ac-1cdc-4d10-8172-039cf627435a"), "https://tass.ru/favicon/180.svg", "https://tass.ru/favicon/57.png", new Guid("05b68ddd-b4de-424b-8f34-f7f54ec12715") },
                    { new Guid("e2b05044-7621-4b7e-a479-f444ebcb1752"), "https://life.ru/appletouch/apple-icon-180%D1%85180.png", "https://life.ru/favicon-32%D1%8532.png", new Guid("f533cbff-5433-48f4-a1a1-34e9c89f0821") },
                    { new Guid("e462f3e4-e7c1-48ce-b699-8bde725c0ab2"), "https://7days.ru/android-icon-192x192.png", "https://7days.ru/favicon-32x32.png", new Guid("25164b7a-b375-4143-b2ed-8437c602fcc4") },
                    { new Guid("e59043e4-0cf8-49cd-8387-2db5f9db7160"), "https://cdnn21.img.ria.ru/i/favicons/radiosputnik/apple-touch-icon.png", "https://cdnn21.img.ria.ru/i/favicons/radiosputnik/favicon.ico", new Guid("599eae9b-df46-4af2-b1c2-58cbeb39943f") },
                    { new Guid("e7e0e993-f4fd-47b9-9923-5c8d564fbffa"), "https://russian.rt.com/static/blocks/touch-icon/apple-touch-icon-144x144-precomposed.png", "https://russian.rt.com/favicon.ico", new Guid("2684aa2e-d0e2-407a-bce3-8d0aa977adc9") },
                    { new Guid("ef3c379e-714a-431f-843d-bc28630c7537"), "https://s01.stc.yc.kpcdn.net/s0/2.1.321/adaptive/favicon-128.png", "https://s01.stc.yc.kpcdn.net/s0/2.1.321/adaptive/favicon-32.png", new Guid("886f22e2-9d3e-4a7c-b2a6-a5a8a01c5165") },
                    { new Guid("f023c3df-d9d9-4e14-8d3b-fb4d26a95713"), "https://ren.tv/apple-touch-icon.png", "https://ren.tv/favicon-32x32.png", new Guid("d6db5c5c-0e21-4aab-8f4b-433afafa26d1") },
                    { new Guid("fa69546d-6fcc-4ecb-9004-7b468a2f35fc"), "https://www.1obl.ru/apple-touch-icon.png", "https://www.1obl.ru/favicon-32x32.png", new Guid("890c270c-e037-48a7-89b4-5e5bf409c505") },
                    { new Guid("fca067d0-22d3-49d6-ad58-b4d1fd746f26"), "https://3dnews.ru/assets/images/3dnews_logo_soc.png", "https://3dnews.ru/assets/3dnews_logo_color.png", new Guid("539df01b-c5f8-4e92-8e6a-a10ece734370") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_editor_settings",
                columns: new[] { "id", "is_required", "name_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("0530e3a0-fc83-4165-8cf5-d5398c953692"), false, "//meta[@name='mediator_author']/@content", new Guid("df6c1dc1-f352-4b80-84a8-54a4fd90246c") },
                    { new Guid("0616d011-5d62-4e44-aaab-35c9f81fb75e"), false, "//p[@class='doc__text document_authors']/text()", new Guid("22036ea4-0190-4ccc-bc0f-5a77c4b78deb") },
                    { new Guid("0a5daf71-a530-432c-b544-b5bf4407e650"), false, "//div[contains(@class, 'PageArticleContent_authors')]//a[contains(@class, 'LinksOfAuthor_item')]/text()", new Guid("4e81b91f-d336-4b9c-a506-7b92ec6094d3") },
                    { new Guid("0ed90b8c-ec81-43e2-a923-fabf02043ead"), false, "//div[@class='article_top']//div[@class='authors']//div[@class='autor']//span/text()", new Guid("0a8ab6d7-8dfd-4e89-b17a-d930991e5c57") },
                    { new Guid("181d0aac-5e57-4bcd-b381-89ebe290ff28"), false, "//div[@class='GeneralMaterial-module-materialHeader']//div[contains(@class, 'MetaItem-module_hasSource') and not(time)]/text()", new Guid("e01cf720-5a6c-4f99-9acc-b45ff8b0b277") },
                    { new Guid("1ce467c5-a12a-4f99-8afb-538fa636b486"), false, "//meta[@name='author']/@content", new Guid("fb70f1d7-bdb3-4352-bfde-704e077b7c7c") },
                    { new Guid("223a3b07-2f91-4064-bc36-d4c0b16d8ebe"), false, "//div[@class='author']/span[@itemprop='author']/span[@itemprop='name']/a/text()", new Guid("f59e0993-0b63-4be7-9f13-49a92f8b8301") },
                    { new Guid("2cfbfbf1-0e9c-418e-a03e-5214c76fae33"), false, "//div[@class='newsDetail-body__item-header']/a[contains(@class, 'newsDetail-person')]//p[contains(@class, 'newsDetail-person__info-name')]/text()", new Guid("6428b94e-7c36-4f75-b45c-ae076d55dd01") },
                    { new Guid("32a0b18a-17df-4fdf-8fd2-e396f260ef85"), false, "//article//span[@class='author']/a[@class='authorName']/span/text()", new Guid("b94ffa83-703d-49d0-982d-ec5c8a5bd084") },
                    { new Guid("3c340edd-32cb-4b28-9e70-d008055dc684"), false, "//a[@class='article__author']/text()", new Guid("48a43db8-ac32-409d-b5d9-3cb2aef71912") },
                    { new Guid("4b01430d-dcc1-477b-a3af-10182b3cefb4"), false, "//div[@class='preview__author-block']//div[@class='author__about']/a[@itemprop='name']/@content", new Guid("16e4ff95-a5bf-489a-a59b-dc1b455c8a62") },
                    { new Guid("5116108b-f25a-4366-a551-27c67151d14f"), false, "//meta[@name='mediator_author']/@content", new Guid("755c983a-6e37-411f-a6b5-1ef28fcb2abe") },
                    { new Guid("57e6af13-e9db-4d4f-b8ae-ece43185c974"), false, "//meta[@name='article:author']/@content", new Guid("5f4d0a7f-fcb4-41ae-987f-2fdf3f456e9d") },
                    { new Guid("60dcb0bf-1237-46f6-ad69-0ad3b8668749"), false, "//meta[@property='article:author']/@content", new Guid("8686874a-05a4-42ea-80bc-c9ad27c3d8ff") },
                    { new Guid("6794fa05-aba0-46cc-8993-2e392dd0682a"), false, "//meta[@property='article:author']/@content", new Guid("f672a55c-4c9e-4684-8973-16306be0902a") },
                    { new Guid("68153356-1fc3-429f-a8e0-17aa6e6ddeb9"), false, "//footer[@class='news-item__footer']/div[@class='news-item__footer-after-news']/p[position()=1]//span/text()", new Guid("c76d5ca3-52df-4f4f-991a-05b65407daf7") },
                    { new Guid("78dbad09-c5ca-4248-b562-9356d8189e57"), false, "//meta[@property='ajur:article:authors']/@content", new Guid("4389214c-a07b-471a-bc95-73b7c495d580") },
                    { new Guid("817dee6b-2180-4102-8776-f455978c0d48"), false, "//article/p[@class='author']/text()", new Guid("926554c1-213a-4dfd-96ed-c5b0db283ff2") },
                    { new Guid("82ce9085-d7ee-4fb6-a376-de986682dfc7"), false, "//div[@class='article__content']//strong[text()='Автор:']/../text()", new Guid("37ea2837-b550-4a69-a54e-1d17e387ff7c") },
                    { new Guid("83163e10-ed3a-43e3-b1ab-b1eada16d6c6"), false, "//div[contains(@class, 'styled__StoryInfoAuthors')]/div[contains(@class, 'styled__InfoAuthor')]//span[contains(@class, 'styled__AuthorName')]/text()", new Guid("d6297613-fd5c-4d45-ba9c-4a8e78b558a3") },
                    { new Guid("83848f79-09d8-45b6-ae88-003290883b51"), false, "//span[@itemprop='author']/span[@itemprop='name']/@content", new Guid("981e6415-1c99-49e7-9faf-55c35eed1c83") },
                    { new Guid("96b190b5-146c-4b88-9738-feb83beef28b"), false, "//div[@itemprop='author']/span[@itemprop='name']/text()", new Guid("d28c88f1-9cb9-4a86-a2bf-d5debde5a805") },
                    { new Guid("9dbf2bd4-4bd7-4620-8ba2-2daa30d1ebdf"), false, "//div[@class='topic-authors']/a[@class='topic-authors__author']/text()", new Guid("f62b9c01-f69e-4ca1-b306-772184659e30") },
                    { new Guid("a529ff0a-e84e-4f70-ba42-125d552cb432"), false, "//meta[@property='author']/@content", new Guid("a2d6e3f4-6fda-46e2-aa85-39eb18c85de9") },
                    { new Guid("a8d7646d-247c-4a06-9c7f-f6f451132ddd"), false, "//div[@class='article__authors']//*[@class='article__authors__author']/span[@class='article__authors__author__name']/text()", new Guid("276af382-dc02-4eb4-94fe-dcdadb713afe") },
                    { new Guid("aedb95cb-3c34-43b2-8f5f-6db28c0812d4"), false, "//article//header//div[@class='b-authors']/div[@class='b-author' and position()=1]//text()", new Guid("5ba45cbe-6e75-4175-85dd-1c9eff7d3d3b") },
                    { new Guid("b0970ca9-c76e-4477-9fcb-357d331d5ebe"), false, "//span[@class='author']/a/text()", new Guid("517c7c39-9682-4e85-962b-ace3a1144ea7") },
                    { new Guid("b5822411-8ae5-46cc-b686-920ee77a14e7"), false, "//*[@itemprop='author']/*[@itemprop='name']//text()", new Guid("44766c3e-3618-47e4-b1c5-e27f4b079424") },
                    { new Guid("b75ea3d6-4e91-4c2e-9ddd-c9f21d1b6ae4"), false, "//div[@itemprop='author']//p[@itemprop='name']/text()", new Guid("a0f009fa-c0de-48bf-973a-a0751d04b717") },
                    { new Guid("bbdb6742-c281-4d3b-93f8-fbed50eb7f0f"), false, "//div[@class='blog-post-info']//div[@itemprop='author']//span[@itemprop='name']/text()", new Guid("880d766c-5672-457f-98ca-60ca11637984") },
                    { new Guid("c9c01f96-293d-475b-853b-a97c59b0604c"), false, "//div[@id='content']//div[contains(@class, 'topic')]/ul[contains(@class, 'blog_more')]//li[@class='author']//text()", new Guid("8ac035cc-a118-4e61-bbf3-db636e336f4f") },
                    { new Guid("ca498443-faf9-4a5f-a8fc-a84bb1d254d5"), false, "//div[@class='container-fluid publication-footer']//a[contains(@class, 'text-secondary')]/@title", new Guid("f7fc7d0c-b481-4c99-9e58-a516a14cb4b0") },
                    { new Guid("ce3342b4-3f6f-4074-a5c6-31368f890987"), false, "//div[contains(@class, 'styles_bodyWrapper')]//div[contains(@class, 'styles_authorsLinks')]/a/text()", new Guid("3b5c605f-a7a1-4d17-98c9-e49c74d10e9f") },
                    { new Guid("d16bf610-110b-4b5d-b276-9a20649916d6"), false, "//meta[@property='article:author']/@content", new Guid("cb551d20-f4cf-47a6-bcba-5428dbb555e1") },
                    { new Guid("dd31d8f2-4b32-4ca4-b870-6139d1b493ca"), false, "//meta[@property='article:author']/@content", new Guid("339b5526-f1f9-4d89-9f07-68611ccb5919") },
                    { new Guid("eaafb744-5813-46ca-bd71-0a1900277fb4"), false, "//meta[@name='author']/@content", new Guid("9f42918a-5400-4abe-8c96-efde954ab87e") },
                    { new Guid("f15f215b-aec7-43ba-be7a-a6af118248f8"), false, "//meta[@property='article:author']/@content", new Guid("2dd377de-9eb7-4b27-adf4-398755baaaee") },
                    { new Guid("f6e427ac-e48d-4d04-8afc-2e54b31bdd13"), false, "//meta[@name='author']/@content", new Guid("d29bb306-e411-466c-8862-3515266e4a4b") },
                    { new Guid("f7409a1d-6e72-4fd0-8602-7b0b1d207ea3"), false, "//span[@itemprop='name']/a/text()", new Guid("8fbb4720-0c12-4be3-a087-fdfd04595e67") },
                    { new Guid("f82d98a0-d8a8-42a6-859a-f73c752c992f"), false, "//section[contains(@class, '_page-section')]//div[contains(@class, '_bottom-info_')]//span[contains(@class, '_user-info__name_')]/text()", new Guid("f50e1187-7865-47c5-9364-b981c479421b") },
                    { new Guid("fa755afb-86f7-4a66-b1bf-43b282e5db20"), false, "//div[@class='article__announce-authors']/a[@itemprop='author']/span[@itemprop='name']/text()", new Guid("6c0da7df-74ef-4b96-b3cd-1a3817de9170") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_modified_at_settings",
                columns: new[] { "id", "is_required", "modified_at_culture_info", "modified_at_time_zone_info_id", "modified_at_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("28f61e5b-8adf-4dee-8c57-37d55d930d2d"), false, "ru-RU", null, "//meta[@itemprop='dateModified']/@content", new Guid("44766c3e-3618-47e4-b1c5-e27f4b079424") },
                    { new Guid("2fb44e75-27f0-410f-b9ef-cc7c80457f08"), false, "ru-RU", null, "//meta[@property='article:modified_time']/@content", new Guid("48a43db8-ac32-409d-b5d9-3cb2aef71912") },
                    { new Guid("300a86e9-2c1f-4adf-8648-e24fa7364b53"), false, "ru-RU", "Russian Standard Time", "//meta[@property='article:modified_time']/@content", new Guid("2dd377de-9eb7-4b27-adf4-398755baaaee") },
                    { new Guid("3608df25-da4f-4281-96d7-30c3db0a654e"), false, "ru-RU", "Russian Standard Time", "//meta[@itemprop='dateModified']/@content", new Guid("c95b3a67-c65c-435e-b1dc-96aaac8a13d9") },
                    { new Guid("437f092e-352e-4283-a6da-dcae22e0dcbf"), false, "en-US", null, "//meta[@property='article:modified_time']/@content", new Guid("8fbb4720-0c12-4be3-a087-fdfd04595e67") },
                    { new Guid("4e2ac486-74d8-41fd-acd1-40e123cae87e"), false, "ru-RU", "Russian Standard Time", "//meta[@property='article:modified_time']/@content", new Guid("880d766c-5672-457f-98ca-60ca11637984") },
                    { new Guid("4fc08b5f-3019-4024-acd7-1a73afa4f79a"), false, "ru-RU", null, "//meta[@property='article:modified_time']/@content", new Guid("9f42918a-5400-4abe-8c96-efde954ab87e") },
                    { new Guid("50d5c4a8-0d8b-4554-a53f-6aa2511d0aed"), false, "ru-RU", "Russian Standard Time", "//meta[@property='og:updated_time']/@content", new Guid("e89d9898-a84a-43b2-a909-85ed4753a60a") },
                    { new Guid("541f9351-3d63-4a22-9d31-4882b0d88aff"), false, "ru-RU", null, "//meta[@itemprop='dateModified']/@content", new Guid("a0f009fa-c0de-48bf-973a-a0751d04b717") },
                    { new Guid("5e7de5e1-e085-4292-a2b3-1d078946a666"), false, "ru-RU", null, "//meta[@itemprop='dateModified']/@content", new Guid("276af382-dc02-4eb4-94fe-dcdadb713afe") },
                    { new Guid("649f4984-5d0d-4888-acf5-2e74aa1d72b5"), false, "ru-RU", "Russian Standard Time", "//meta[@property='article:modified_time']/@content", new Guid("c80caa5e-9567-4654-94c6-1f6828fc2d0e") },
                    { new Guid("879b33a4-59e0-4025-85b1-d939dee96c68"), false, "ru-RU", "Russian Standard Time", "//meta[@property='article:modified_time']/@content", new Guid("578b96e7-9885-43bc-a757-0aec5cddaf5b") },
                    { new Guid("8c88dba9-9c0d-4f31-bdf6-89529df4d78c"), false, "ru-RU", null, "//meta[@itemprop='dateModified']/@content", new Guid("6c0da7df-74ef-4b96-b3cd-1a3817de9170") },
                    { new Guid("8d2f3849-9516-4038-ae4a-e943e3c9c646"), false, "ru-RU", null, "//meta[@property='article:modified_time']/@content", new Guid("22036ea4-0190-4ccc-bc0f-5a77c4b78deb") },
                    { new Guid("8d5f5fa4-e890-4770-aa1b-7291ba2d04ca"), false, "ru-RU", "Russian Standard Time", "//meta[@itemprop='dateModified']/@content", new Guid("ae9c317a-7ef6-41a4-95f1-3ca87eed0277") },
                    { new Guid("91080107-6910-4971-ad22-260c87cd253c"), false, "ru-RU", "Russian Standard Time", "//meta[@property='article:modified_time']/@content", new Guid("5f4d0a7f-fcb4-41ae-987f-2fdf3f456e9d") },
                    { new Guid("98951eef-10b0-44c4-ab26-18eeab0c80d7"), false, "ru-RU", "Russian Standard Time", "//meta[@property='article:modified_time']/@content", new Guid("b0ad231f-52d9-4cdc-ab56-4e1b73411aed") },
                    { new Guid("9ad251b2-9ac1-44f2-99f9-590b0ce91ee9"), false, "ru-RU", null, "//meta[@property='article:modified_time']/@content", new Guid("1fc11022-2d88-42ae-bd6d-032758049af4") },
                    { new Guid("a2419c06-784a-4624-ab75-17546afbe5f2"), false, "ru-RU", null, "//meta[@itemprop='dateModified']/@content", new Guid("fb70f1d7-bdb3-4352-bfde-704e077b7c7c") },
                    { new Guid("bc3fecbc-854b-4df5-9a0c-e105fc97eea0"), false, "en-US", null, "//meta[@property='article:modified_time']/@content", new Guid("d29bb306-e411-466c-8862-3515266e4a4b") },
                    { new Guid("cbaabdd3-8363-4c46-8851-94a093c6bfb8"), false, "ru-RU", "Russian Standard Time", "//meta[@property='article:modified_time']/@content", new Guid("4e81b91f-d336-4b9c-a506-7b92ec6094d3") },
                    { new Guid("d7a0df16-25f2-4d51-ad3e-3d93bd9ef318"), false, "ru-RU", null, "//meta[@property='article:modified_time']/@content", new Guid("8334ba09-9b47-4ea4-8d3f-feb02deceb09") },
                    { new Guid("e76fa99b-25f9-4ccf-a924-a847ada87fe9"), false, "ru-RU", null, "//meta[@property='article:modified_time']/@content", new Guid("339b5526-f1f9-4d89-9f07-68611ccb5919") },
                    { new Guid("e7dd8c17-706d-4827-a169-315fe30643ef"), false, "ru-RU", "UTC", "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark_update')]//span[@ca-ts]/text()", new Guid("a2bfe55a-6d48-4d2e-8b27-907233517a3e") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_picture_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("015b67a7-246b-4eca-a24c-8e0dfad4ad61"), false, new Guid("48a43db8-ac32-409d-b5d9-3cb2aef71912"), "//meta[@property='og:image']/@content" },
                    { new Guid("04a059e3-1a63-4d44-a88c-79dd5ba6be2f"), false, new Guid("442fa986-5691-4dc7-aefa-69eea326bf01"), "//meta[@property='og:image']/@content" },
                    { new Guid("10565775-4f88-4c44-8d18-61be7b5736c9"), false, new Guid("16e4ff95-a5bf-489a-a59b-dc1b455c8a62"), "//meta[@property='og:image']/@content" },
                    { new Guid("117b76dc-1663-4e13-a349-05b5b37f9e10"), false, new Guid("e01cf720-5a6c-4f99-9acc-b45ff8b0b277"), "//meta[@property='og:image']/@content" },
                    { new Guid("1397c889-ca29-4394-b56e-38bcbf669dfa"), false, new Guid("276af382-dc02-4eb4-94fe-dcdadb713afe"), "//meta[@itemprop='url']/@content" },
                    { new Guid("184f5cee-fdbb-4a46-a4fd-7d87d9d7d61a"), false, new Guid("926554c1-213a-4dfd-96ed-c5b0db283ff2"), "//meta[@property='og:image']/@content" },
                    { new Guid("1e0a6ec9-e038-4016-be88-49c11b1a1227"), false, new Guid("22036ea4-0190-4ccc-bc0f-5a77c4b78deb"), "//meta[@property='og:image']/@content" },
                    { new Guid("1facbbfe-0ab5-4b6f-bf1e-4a9f2a844f79"), false, new Guid("d28c88f1-9cb9-4a86-a2bf-d5debde5a805"), "//meta[@property='og:image']/@content" },
                    { new Guid("2ae692a6-0d7b-43b4-89bb-dd9fda4c1f5a"), false, new Guid("981e6415-1c99-49e7-9faf-55c35eed1c83"), "//meta[@property='og:image']/@content" },
                    { new Guid("2ee32d5e-353a-4677-9606-6ad901d9412a"), false, new Guid("4389214c-a07b-471a-bc95-73b7c495d580"), "//meta[@property='og:image']/@content" },
                    { new Guid("3261f08f-7e8a-47c7-ae55-5dd50179e85d"), false, new Guid("9f42918a-5400-4abe-8c96-efde954ab87e"), "//meta[@property='og:image']/@content" },
                    { new Guid("32a74994-78bf-40a8-b568-777c1d42cf5e"), false, new Guid("c95b3a67-c65c-435e-b1dc-96aaac8a13d9"), "//meta[@property='og:image']/@content" },
                    { new Guid("355ce9ea-d85a-4aac-ac07-94972293bba6"), false, new Guid("a2d6e3f4-6fda-46e2-aa85-39eb18c85de9"), "//meta[@property='og:image']/@content" },
                    { new Guid("3d29d868-47d6-4444-b7a2-4c7b3e11c4e1"), false, new Guid("cb551d20-f4cf-47a6-bcba-5428dbb555e1"), "//meta[@property='og:image']/@content" },
                    { new Guid("47b0432f-ede7-4140-9782-e4259165163f"), false, new Guid("1fc11022-2d88-42ae-bd6d-032758049af4"), "//meta[@property='og:image']/@content" },
                    { new Guid("4e62b153-5f94-4f4d-817c-8bf4656020b9"), false, new Guid("44766c3e-3618-47e4-b1c5-e27f4b079424"), "//meta[@property='og:image']/@content" },
                    { new Guid("54ce6b6d-9918-4af4-acba-f37567a14441"), false, new Guid("d6297613-fd5c-4d45-ba9c-4a8e78b558a3"), "//meta[@name='og:image']/@content" },
                    { new Guid("574cf67a-d147-4155-97ad-513d7669724a"), false, new Guid("c76d5ca3-52df-4f4f-991a-05b65407daf7"), "//meta[@property='og:image']/@content" },
                    { new Guid("5b41f328-565f-4f9e-9643-f2c167417ece"), false, new Guid("df6c1dc1-f352-4b80-84a8-54a4fd90246c"), "//meta[@property='og:image']/@content" },
                    { new Guid("61537e4b-7f6f-4cce-9979-7125e5ff8b9d"), false, new Guid("8334ba09-9b47-4ea4-8d3f-feb02deceb09"), "//meta[@property='og:image']/@content" },
                    { new Guid("68461e2b-868d-48ef-af50-bc97761989ec"), false, new Guid("a0f009fa-c0de-48bf-973a-a0751d04b717"), "//meta[@property='og:image']/@content" },
                    { new Guid("6a058686-67b1-45b0-83ea-bdda30c86b6b"), false, new Guid("4e81b91f-d336-4b9c-a506-7b92ec6094d3"), "//meta[@property='og:image']/@content" },
                    { new Guid("7117185f-363d-4f3d-9a28-ad5819185779"), false, new Guid("ae9c317a-7ef6-41a4-95f1-3ca87eed0277"), "//meta[@property='og:image']/@content" },
                    { new Guid("7c6dcbbe-0adb-4eb8-90ab-f01a1467fd83"), false, new Guid("f50e1187-7865-47c5-9364-b981c479421b"), "//meta[@property='og:image']/@content" },
                    { new Guid("7da61a1c-3ed5-4128-8c88-f55da6b92ff6"), false, new Guid("755c983a-6e37-411f-a6b5-1ef28fcb2abe"), "//meta[@property='og:image']/@content" },
                    { new Guid("87668dea-dee1-4741-a206-2a2e70101910"), false, new Guid("c80caa5e-9567-4654-94c6-1f6828fc2d0e"), "//meta[@property='og:image']/@content" },
                    { new Guid("8e344e58-e6e3-4e3e-bd20-fc8ab55ec14b"), false, new Guid("fb70f1d7-bdb3-4352-bfde-704e077b7c7c"), "//meta[@property='og:image']/@content" },
                    { new Guid("914ba03c-c58b-4661-9d59-e4e7160d64c7"), false, new Guid("e89d9898-a84a-43b2-a909-85ed4753a60a"), "//meta[@property='og:image']/@content" },
                    { new Guid("924d68a2-c76c-44d7-95af-ff2f021c8a70"), false, new Guid("517c7c39-9682-4e85-962b-ace3a1144ea7"), "//meta[@property='og:image']/@content" },
                    { new Guid("92e669d0-4bee-4a72-ac59-033c030cd4c5"), false, new Guid("b94ffa83-703d-49d0-982d-ec5c8a5bd084"), "//meta[@property='og:image']/@content" },
                    { new Guid("98db473d-8528-42b3-bccf-c4a95591f77f"), false, new Guid("b0ad231f-52d9-4cdc-ab56-4e1b73411aed"), "//meta[@property='og:image']/@content" },
                    { new Guid("9a789a67-d606-4fa4-8bcc-8ec3bf124874"), false, new Guid("a2bfe55a-6d48-4d2e-8b27-907233517a3e"), "//meta[@property='og:image']/@content" },
                    { new Guid("9eed3756-e284-43d4-b820-346bf7ddc259"), false, new Guid("880d766c-5672-457f-98ca-60ca11637984"), "//meta[@property='og:image']/@content" },
                    { new Guid("a88ee27d-fe86-4a91-bba4-6e59dae35aab"), false, new Guid("2dd377de-9eb7-4b27-adf4-398755baaaee"), "//meta[@property='og:image']/@content" },
                    { new Guid("bb2a2162-1648-40b6-9570-10a2a99bee7a"), false, new Guid("37ea2837-b550-4a69-a54e-1d17e387ff7c"), "//meta[@property='og:image']/@content" },
                    { new Guid("bbb1e31c-b7ec-4107-b3d6-a60b25e56e24"), false, new Guid("f7fc7d0c-b481-4c99-9e58-a516a14cb4b0"), "//meta[@name='og:image']/@content" },
                    { new Guid("c5c40894-1388-4eaa-9c4a-8b48c036b66f"), false, new Guid("8ac035cc-a118-4e61-bbf3-db636e336f4f"), "//meta[@property='og:image']/@content" },
                    { new Guid("c7e52afc-68f0-4dbb-ace3-7dbbe359332c"), false, new Guid("0a8ab6d7-8dfd-4e89-b17a-d930991e5c57"), "//meta[@property='og:image']/@content" },
                    { new Guid("da5ddb5c-7abe-4c9f-8136-be23914f246f"), false, new Guid("6428b94e-7c36-4f75-b45c-ae076d55dd01"), "//meta[@property='og:image']/@content" },
                    { new Guid("dbf6d2f4-a7ec-40cf-9006-104c634db36e"), false, new Guid("3b5c605f-a7a1-4d17-98c9-e49c74d10e9f"), "//meta[@property='og:image']/@content" },
                    { new Guid("de018243-027e-4c5c-841c-29b61265d24d"), false, new Guid("f672a55c-4c9e-4684-8973-16306be0902a"), "//meta[@property='og:image']/@content" },
                    { new Guid("e8602522-c430-478e-84f7-12fe68d89898"), false, new Guid("8fbb4720-0c12-4be3-a087-fdfd04595e67"), "//meta[@property='og:image']/@content" },
                    { new Guid("ecbe3a77-2585-49be-949b-dbfd888fa819"), false, new Guid("5ba45cbe-6e75-4175-85dd-1c9eff7d3d3b"), "//meta[@property='og:image']/@content" },
                    { new Guid("ece7dc7d-78a0-4329-8410-f63f076ffe9e"), false, new Guid("12c214fc-cc69-461c-aa49-9b1feba92c2e"), "//meta[@property='og:image']/@content" },
                    { new Guid("ed6331ef-1dd8-4ff6-b7b5-49b360724c77"), false, new Guid("339b5526-f1f9-4d89-9f07-68611ccb5919"), "//meta[@property='og:image']/@content" },
                    { new Guid("ee42e233-b661-460e-9d91-49e0958edc00"), false, new Guid("d29bb306-e411-466c-8862-3515266e4a4b"), "//meta[@property='og:image']/@content" },
                    { new Guid("f4d3a141-ee53-49bd-a756-7b46cb14308a"), false, new Guid("578b96e7-9885-43bc-a757-0aec5cddaf5b"), "//meta[@property='og:image']/@content" },
                    { new Guid("f8d26a84-f1ce-465d-89e2-649cf25dabdd"), false, new Guid("f59e0993-0b63-4be7-9f13-49a92f8b8301"), "//meta[@property='og:image']/@content" },
                    { new Guid("f9efc713-b8aa-4ec5-84f7-b3dc3130b370"), false, new Guid("5f4d0a7f-fcb4-41ae-987f-2fdf3f456e9d"), "//meta[@property='og:image']/@content" },
                    { new Guid("f9f04c3a-e0fd-4fd7-b2c6-47a55b8d8837"), false, new Guid("f62b9c01-f69e-4ca1-b306-772184659e30"), "//meta[@property='og:image']/@content" },
                    { new Guid("fd1a2215-7885-4291-86a2-eb39910f6a74"), false, new Guid("8686874a-05a4-42ea-80bc-c9ad27c3d8ff"), "//meta[@property='og:image']/@content" },
                    { new Guid("ff1f259c-043d-4c98-9aec-d530ab109964"), false, new Guid("6c0da7df-74ef-4b96-b3cd-1a3817de9170"), "//meta[@property='og:image']/@content" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "published_at_culture_info", "published_at_time_zone_info_id", "published_at_x_path" },
                values: new object[,]
                {
                    { new Guid("06150fae-9f35-46f6-afb3-5a6666fd34a1"), true, new Guid("8334ba09-9b47-4ea4-8d3f-feb02deceb09"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("0c3cf546-81b1-4a2b-b0e1-ec5bc049821d"), false, new Guid("f7fc7d0c-b481-4c99-9e58-a516a14cb4b0"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'pubdatetime')]//div[contains(@class, 'badge-time')]//text()" },
                    { new Guid("2184b160-4ac8-4e4a-bfa0-e19bbdb87865"), true, new Guid("ae9c317a-7ef6-41a4-95f1-3ca87eed0277"), "ru-RU", "Russian Standard Time", "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("2223cc9e-9ad1-4d22-9b6a-1486d2a8d607"), true, new Guid("c76d5ca3-52df-4f4f-991a-05b65407daf7"), "ru-RU", null, "//header[@class='news-item__header']//time/@content" },
                    { new Guid("24bb919d-db61-45b5-9bce-e7eadf90ddcd"), true, new Guid("4389214c-a07b-471a-bc95-73b7c495d580"), "ru-RU", null, "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("276062d0-a0c0-4cbc-a3b6-4006207c6abd"), true, new Guid("df6c1dc1-f352-4b80-84a8-54a4fd90246c"), "ru-RU", null, "//meta[@name='mediator_published_time']/@content" },
                    { new Guid("2bc1a097-491b-464d-a811-c8bdf6e43191"), true, new Guid("d28c88f1-9cb9-4a86-a2bf-d5debde5a805"), "ru-RU", null, "//div[@class='publication-info']/time[@itemprop='datePublished']/@datetime" },
                    { new Guid("2fd57d16-6f4d-4323-8eb4-0b3fa541b698"), true, new Guid("276af382-dc02-4eb4-94fe-dcdadb713afe"), "ru-RU", null, "//div[@class='article__header__info-block']/time[@class='article__header__date']/@datetime" },
                    { new Guid("33279872-ff96-4e67-999e-ee6c6e70a257"), true, new Guid("e01cf720-5a6c-4f99-9acc-b45ff8b0b277"), "ru-RU", "UTC", "//div[@class='GeneralMaterial-module-materialHeader']//div[contains(@class, 'MetaItem-module_datetime')]/time/text()" },
                    { new Guid("497e6236-8e37-4e06-b7e4-9547b8a3c9e8"), true, new Guid("f62b9c01-f69e-4ca1-b306-772184659e30"), "ru-RU", "Russian Standard Time", "//div[@class='topic-page__header']//a[contains(@class, 'topic-header__time')]/text()" },
                    { new Guid("4b301397-2495-4508-be2a-ed74adefa156"), true, new Guid("c80caa5e-9567-4654-94c6-1f6828fc2d0e"), "ru-RU", "Russian Standard Time", "//meta[@property='article:published_time']/@content" },
                    { new Guid("4b39ce1c-17b4-4d1d-b322-9d10562a18df"), true, new Guid("44766c3e-3618-47e4-b1c5-e27f4b079424"), "ru-RU", null, "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("4c634df1-77e6-4931-8e34-58e16e0fc92a"), true, new Guid("d29bb306-e411-466c-8862-3515266e4a4b"), "en-US", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("55ddeb78-a4f8-46e6-aaec-786e540a3e06"), true, new Guid("2dd377de-9eb7-4b27-adf4-398755baaaee"), "ru-RU", "Russian Standard Time", "//meta[@property='article:published_time']/@content" },
                    { new Guid("5ffebdc3-6c7e-4b31-83df-8a9676f96a3a"), true, new Guid("a2bfe55a-6d48-4d2e-8b27-907233517a3e"), "ru-RU", "UTC", "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark')]//span[@ca-ts]/text()" },
                    { new Guid("61bada83-0cac-41e1-8e15-6a0bc2b12493"), true, new Guid("5ba45cbe-6e75-4175-85dd-1c9eff7d3d3b"), "ru-RU", "Russian Standard Time", "//div[@class='b-text__date']/text()" },
                    { new Guid("71b0b369-1301-4638-b6c0-b561dfd9db36"), true, new Guid("a0f009fa-c0de-48bf-973a-a0751d04b717"), "ru-RU", null, "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("74107823-c563-47af-a257-a7ed73ba8fa2"), true, new Guid("12c214fc-cc69-461c-aa49-9b1feba92c2e"), "ru-RU", "Russian Standard Time", "//p[@class='b-material__date']/text()" },
                    { new Guid("767ee3cb-1a6f-462d-833d-0b49599e4d49"), true, new Guid("6c0da7df-74ef-4b96-b3cd-1a3817de9170"), "ru-RU", null, "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("79696516-c4cc-4712-8903-6720126cdbb2"), true, new Guid("578b96e7-9885-43bc-a757-0aec5cddaf5b"), "ru-RU", "Russian Standard Time", "//meta[@property='article:published_time']/@content" },
                    { new Guid("797abeaf-0611-4865-99a5-b22685f02696"), true, new Guid("8686874a-05a4-42ea-80bc-c9ad27c3d8ff"), "ru-RU", "Russian Standard Time", "//article//header//time[@class='article-head__date']/text()" },
                    { new Guid("80759c35-1193-4967-9838-e12ff789333b"), true, new Guid("b0ad231f-52d9-4cdc-ab56-4e1b73411aed"), "ru-RU", "Russian Standard Time", "//meta[@property='article:published_time']/@content" },
                    { new Guid("8592808e-3aea-4519-aca6-6f1ec1fc14c3"), true, new Guid("4e81b91f-d336-4b9c-a506-7b92ec6094d3"), "ru-RU", "Russian Standard Time", "//meta[@property='article:published_time']/@content" },
                    { new Guid("864d9c45-53ba-466b-a63e-28e2ad3566d3"), true, new Guid("880d766c-5672-457f-98ca-60ca11637984"), "ru-RU", "Russian Standard Time", "//meta[@property='article:published_time']/@content" },
                    { new Guid("88fdb3c2-4eba-4c3a-ba50-9f99d2f74d6b"), true, new Guid("cb551d20-f4cf-47a6-bcba-5428dbb555e1"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("8a5f72d5-2468-467b-8197-b4c389a8194d"), true, new Guid("8fbb4720-0c12-4be3-a087-fdfd04595e67"), "en-US", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("8bc80405-d80d-4aaf-a60e-2fcfc0b371c4"), true, new Guid("9f42918a-5400-4abe-8c96-efde954ab87e"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("94c71826-bf69-4b64-80a4-0e899f370965"), true, new Guid("22036ea4-0190-4ccc-bc0f-5a77c4b78deb"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("96b0ecd9-8e6b-4159-afff-42b0a320421c"), true, new Guid("926554c1-213a-4dfd-96ed-c5b0db283ff2"), "ru-RU", "Russian Standard Time", "//article/div[@class='header']/span/text()" },
                    { new Guid("9be5bd0e-b468-4347-903a-611a489527f8"), true, new Guid("fb70f1d7-bdb3-4352-bfde-704e077b7c7c"), "ru-RU", null, "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("9da8283e-6771-4f35-a3b3-7e4f31406460"), true, new Guid("f672a55c-4c9e-4684-8973-16306be0902a"), "ru-RU", "Russian Standard Time", "//span[@id='publication-date']/text()" },
                    { new Guid("b321d9ca-3f4c-47fd-a421-eaa7a1e64927"), true, new Guid("6428b94e-7c36-4f75-b45c-ae076d55dd01"), "ru-RU", "Russian Standard Time", "//div[@class='newsDetail-body__item-subHeader']/time/text()" },
                    { new Guid("b8ee0e55-976d-4ead-b492-190154b494a7"), true, new Guid("517c7c39-9682-4e85-962b-ace3a1144ea7"), "ru-RU", "Russian Standard Time", "//span[@class='date']/time/@datetime" },
                    { new Guid("b999811b-b6bf-4172-aebe-71c694487280"), true, new Guid("16e4ff95-a5bf-489a-a59b-dc1b455c8a62"), "ru-RU", "Russian Standard Time", "//div[@class='article-details']/span[@class='article-details__time']/time/@datetime" },
                    { new Guid("bccd84b7-7110-4db5-a411-0b697fa079ba"), true, new Guid("a2d6e3f4-6fda-46e2-aa85-39eb18c85de9"), "ru-RU", "Russian Standard Time", "//section[contains(@class, 'news-content')]/div[@class='content-top']//p[contains(@class, 'content-top__date')]/text()" },
                    { new Guid("c70ea2de-6523-457c-a566-b44fb4dfff87"), true, new Guid("755c983a-6e37-411f-a6b5-1ef28fcb2abe"), "ru-RU", null, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']/span[@itemprop='datePublished']/@content" },
                    { new Guid("cce741df-430b-45f8-ba73-c4a7fed76fc8"), true, new Guid("37ea2837-b550-4a69-a54e-1d17e387ff7c"), "ru-RU", "Russian Standard Time", "//div[@class='article__content']//time/text()" },
                    { new Guid("d2a9e838-ea09-4db1-8870-f4730e060655"), true, new Guid("e89d9898-a84a-43b2-a909-85ed4753a60a"), "ru-RU", "Russian Standard Time", "//span[@class='submitted-by']/text()" },
                    { new Guid("d3b2d9d8-2e17-4431-95de-c10fcbae4e17"), true, new Guid("c95b3a67-c65c-435e-b1dc-96aaac8a13d9"), "ru-RU", "Russian Standard Time", "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("d719b356-4bd5-4173-aa76-9dc73f9f11d7"), true, new Guid("8ac035cc-a118-4e61-bbf3-db636e336f4f"), "ru-RU", "Russian Standard Time", "//div[@id='content']//div[contains(@class, 'topic')]/ul[contains(@class, 'blog_more')]//li[@class='date']/text()" },
                    { new Guid("d8558ca5-0081-45d0-8ed3-991a29122ad0"), true, new Guid("981e6415-1c99-49e7-9faf-55c35eed1c83"), "ru-RU", "Russian Standard Time", "//div[@class='b-article__top-author']/p[@class='date']/text()" },
                    { new Guid("d9e70fef-775f-4963-a89b-8fb036b2d4ac"), true, new Guid("48a43db8-ac32-409d-b5d9-3cb2aef71912"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("e3a0629b-b49c-488e-af91-e8595118719e"), true, new Guid("f59e0993-0b63-4be7-9f13-49a92f8b8301"), "ru-RU", null, "//meta[@itemprop='dateModified']/@content" },
                    { new Guid("e647493c-ec7f-42ba-96cb-b80a06379221"), true, new Guid("b94ffa83-703d-49d0-982d-ec5c8a5bd084"), "en-US", "Central Europe Standard Time", "//article//div[@class='article-info']/div[@class='date']/text()" },
                    { new Guid("e8ec0621-95f8-42c9-8e5c-c535a0f76e51"), true, new Guid("3b5c605f-a7a1-4d17-98c9-e49c74d10e9f"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("edcb9807-e3ff-491c-86b2-7ad038b795a4"), true, new Guid("0a8ab6d7-8dfd-4e89-b17a-d930991e5c57"), "ru-RU", "Russian Standard Time", "//div[@class='article_top']//div[@class='date']//time/text()" },
                    { new Guid("f45a7692-9384-4a2b-b02a-e5b6e8cfccee"), true, new Guid("1fc11022-2d88-42ae-bd6d-032758049af4"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("f6ee7ff8-18f3-4a44-8e79-32df466924e9"), true, new Guid("5f4d0a7f-fcb4-41ae-987f-2fdf3f456e9d"), "ru-RU", "Russian Standard Time", "//meta[@property='article:published_time']/@content" },
                    { new Guid("fa4b7bb2-c760-4e0d-96ac-21dd5154751d"), true, new Guid("339b5526-f1f9-4d89-9f07-68611ccb5919"), "ru-RU", null, "//meta[@property='article:published_time']/@content" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_sub_title_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("003c8b3c-ea73-4a35-9290-73e8b68f4ade"), false, new Guid("a2d6e3f4-6fda-46e2-aa85-39eb18c85de9"), "//meta[@property='og:description']/@content" },
                    { new Guid("003e8875-f679-4ca1-a61d-e85ad3af3727"), false, new Guid("c95b3a67-c65c-435e-b1dc-96aaac8a13d9"), "//meta[@property='og:description']/@content" },
                    { new Guid("04e66e3d-2bac-4426-a370-90176a19a125"), false, new Guid("cb551d20-f4cf-47a6-bcba-5428dbb555e1"), "//div[@class='block-page-new']/h2/text()" },
                    { new Guid("07c255e8-de55-4291-98ba-cd212d9aca26"), false, new Guid("880d766c-5672-457f-98ca-60ca11637984"), "//meta[@property='og:description']/@content" },
                    { new Guid("0908f0b6-be46-42bf-a035-4d01ea9e5995"), false, new Guid("37ea2837-b550-4a69-a54e-1d17e387ff7c"), "//meta[@property='og:description']/@content" },
                    { new Guid("0f9ae286-9f32-4d6f-bf9a-a8740efc9148"), false, new Guid("8ac035cc-a118-4e61-bbf3-db636e336f4f"), "//meta[@name='DESCRIPTION']/@content" },
                    { new Guid("14b369fa-8d74-4775-bacd-9b990c515873"), false, new Guid("c76d5ca3-52df-4f4f-991a-05b65407daf7"), "//meta[@property='og:description']/@content" },
                    { new Guid("1ddb7b84-9be9-4c01-a26b-af681b2f38c8"), false, new Guid("44766c3e-3618-47e4-b1c5-e27f4b079424"), "//meta[@property='og:description']/@content" },
                    { new Guid("201ef5d1-7c3f-4d59-8b5f-9a3aba134a24"), false, new Guid("339b5526-f1f9-4d89-9f07-68611ccb5919"), "//meta[@property='og:description']/@content" },
                    { new Guid("2bad65ad-2a5a-457a-b89b-108ee6a9df96"), false, new Guid("4389214c-a07b-471a-bc95-73b7c495d580"), "//meta[@property='og:description']/@content" },
                    { new Guid("2dd9eeaf-0ef6-464f-9867-e0be0241ce38"), false, new Guid("fb70f1d7-bdb3-4352-bfde-704e077b7c7c"), "//p[contains(@itemprop, 'alternativeHeadline')]/text()" },
                    { new Guid("39448ca5-a796-472d-be23-1759bfccd302"), false, new Guid("5f4d0a7f-fcb4-41ae-987f-2fdf3f456e9d"), "//meta[@property='og:description']/@content" },
                    { new Guid("3fd8d9b0-8cb5-4fa5-8918-be71b248c24b"), false, new Guid("df6c1dc1-f352-4b80-84a8-54a4fd90246c"), "//meta[@property='og:description']/@content" },
                    { new Guid("479700be-a994-46ed-8a0b-24a99fc4b839"), false, new Guid("b94ffa83-703d-49d0-982d-ec5c8a5bd084"), "//meta[@property='og:description']/@content" },
                    { new Guid("4a644874-7e6b-4e0e-8dd6-eca154a4aaa7"), false, new Guid("f7fc7d0c-b481-4c99-9e58-a516a14cb4b0"), "//meta[@name='og:description']/@content" },
                    { new Guid("4d9089d4-7f36-4f64-b54f-ed0eabf3fb3a"), false, new Guid("c80caa5e-9567-4654-94c6-1f6828fc2d0e"), "//meta[@property='og:description']/@content" },
                    { new Guid("4e58f0ef-3050-43f8-8496-ec8005567dcd"), false, new Guid("755c983a-6e37-411f-a6b5-1ef28fcb2abe"), "//meta[@property='og:description']/@content" },
                    { new Guid("4e7ae257-d7f2-4548-b43e-cf07a8696d72"), false, new Guid("8334ba09-9b47-4ea4-8d3f-feb02deceb09"), "//meta[@property='og:description']/@content" },
                    { new Guid("58dd618a-bf9d-4d8a-a181-0d50a1db165c"), false, new Guid("517c7c39-9682-4e85-962b-ace3a1144ea7"), "//meta[@name='description']/@content" },
                    { new Guid("5a063703-dd93-45a7-a54d-f31216c9c2fd"), false, new Guid("5ba45cbe-6e75-4175-85dd-1c9eff7d3d3b"), "//meta[@property='og:description']/@content" },
                    { new Guid("5a3a8d63-82a6-4f67-8650-50052cc15f6a"), false, new Guid("8fbb4720-0c12-4be3-a087-fdfd04595e67"), "//meta[@property='og:description']/@content" },
                    { new Guid("5ef349bb-6b1e-417b-a0d0-8d5aa3aee3be"), false, new Guid("578b96e7-9885-43bc-a757-0aec5cddaf5b"), "//meta[@property='og:description']/@content" },
                    { new Guid("608a7fe4-108f-47e3-92eb-b1997e728439"), false, new Guid("f672a55c-4c9e-4684-8973-16306be0902a"), "//meta[@property='og:description']/@content" },
                    { new Guid("65f3c8c8-66c3-4dfc-8db3-7e50a0a46968"), false, new Guid("f59e0993-0b63-4be7-9f13-49a92f8b8301"), "//meta[@property='og:description']/@content" },
                    { new Guid("67eed7aa-6891-4cd4-9eeb-7ff54a7f2d7c"), false, new Guid("22036ea4-0190-4ccc-bc0f-5a77c4b78deb"), "//meta[@name='description']/@content" },
                    { new Guid("72caaa96-fb60-4bce-803c-b396c00b5345"), false, new Guid("d6297613-fd5c-4d45-ba9c-4a8e78b558a3"), "//div[contains(@class, 'styled__StoryBody')]/p[contains(@class, 'styled__StoryParagraph') and position()=1]/text()" },
                    { new Guid("73047588-2d16-420b-90b2-f03a3a315c2e"), false, new Guid("442fa986-5691-4dc7-aefa-69eea326bf01"), "//meta[@property='og:description']/@content" },
                    { new Guid("82048577-ec53-4280-b072-510ad7833fcc"), false, new Guid("f62b9c01-f69e-4ca1-b306-772184659e30"), "//meta[@property='og:description']/@content" },
                    { new Guid("82378f03-1397-4656-bc36-d3b7d0ee11e1"), false, new Guid("9f42918a-5400-4abe-8c96-efde954ab87e"), "//meta[@name='description']/@content" },
                    { new Guid("8437f5e8-e019-47ae-b09e-ea11ae3d6da7"), false, new Guid("a2bfe55a-6d48-4d2e-8b27-907233517a3e"), "//meta[@property='og:description']/@content" },
                    { new Guid("86508cce-e8c5-455d-a543-3f70e2cea189"), false, new Guid("e01cf720-5a6c-4f99-9acc-b45ff8b0b277"), "//meta[@property='og:description']/@content" },
                    { new Guid("8f462445-7e37-49df-916a-7794920b0908"), false, new Guid("6428b94e-7c36-4f75-b45c-ae076d55dd01"), "//meta[@property='og:description']/@content" },
                    { new Guid("9e11ff25-e82f-4a13-9723-1cdb7b250fa6"), false, new Guid("16e4ff95-a5bf-489a-a59b-dc1b455c8a62"), "//meta[@name='description']/@content" },
                    { new Guid("9e7a0df2-69e8-4dc5-98d8-2d6ed928daf9"), false, new Guid("e89d9898-a84a-43b2-a909-85ed4753a60a"), "//meta[@property='og:description']/@content" },
                    { new Guid("a246d951-f984-415a-8fb4-1adf7ce67733"), false, new Guid("b0ad231f-52d9-4cdc-ab56-4e1b73411aed"), "//meta[@property='og:description']/@content" },
                    { new Guid("ba816153-09ee-48d9-85ce-f026057b7843"), false, new Guid("f50e1187-7865-47c5-9364-b981c479421b"), "//meta[@property='og:description']/@content" },
                    { new Guid("bcfc81f7-e2c9-4850-910d-4f69cedec5d6"), false, new Guid("1fc11022-2d88-42ae-bd6d-032758049af4"), "//meta[@property='og:description']/@content" },
                    { new Guid("c538c47b-8e26-4471-a937-10625d5b7ec5"), false, new Guid("ae9c317a-7ef6-41a4-95f1-3ca87eed0277"), "//meta[@property='og:description']/@content" },
                    { new Guid("c74b4ff2-8c8c-44c6-93c8-e932abed183c"), false, new Guid("3b5c605f-a7a1-4d17-98c9-e49c74d10e9f"), "//meta[@property='og:description']/@content" },
                    { new Guid("c797a856-b3b2-47a0-a1ab-568d6eaaa77e"), false, new Guid("2dd377de-9eb7-4b27-adf4-398755baaaee"), "//meta[@property='og:description']/@content" },
                    { new Guid("ccff1930-20cd-45f6-bfad-36d40df3273b"), false, new Guid("981e6415-1c99-49e7-9faf-55c35eed1c83"), "//meta[@property='og:description']/@content" },
                    { new Guid("d14f3e72-4e14-42b4-9b88-5278b9ef317e"), false, new Guid("0a8ab6d7-8dfd-4e89-b17a-d930991e5c57"), "//meta[@property='og:description']/@content" },
                    { new Guid("d388b93d-1c28-4372-b3e8-0df3f0a6446a"), false, new Guid("926554c1-213a-4dfd-96ed-c5b0db283ff2"), "//meta[@property='og:description']/@content" },
                    { new Guid("d7e5f6f9-565a-4d52-8fcd-6b714d52072a"), false, new Guid("48a43db8-ac32-409d-b5d9-3cb2aef71912"), "//meta[@property='og:description']/@content" },
                    { new Guid("d941b91b-97f8-443f-a5ec-a37d61f10131"), false, new Guid("d29bb306-e411-466c-8862-3515266e4a4b"), "//meta[@name='description']/@content" },
                    { new Guid("dfb00a29-254d-4545-a3b2-5b213ee42dd3"), false, new Guid("d28c88f1-9cb9-4a86-a2bf-d5debde5a805"), "//meta[@itemprop='description']/@content" },
                    { new Guid("dfb7c894-45be-4bb0-8805-fd0c19c4b442"), false, new Guid("8686874a-05a4-42ea-80bc-c9ad27c3d8ff"), "//meta[@property='og:description']/@content" },
                    { new Guid("dff6b447-a453-46bf-a231-e6c505f6b407"), false, new Guid("4e81b91f-d336-4b9c-a506-7b92ec6094d3"), "//meta[@property='og:description']/@content" },
                    { new Guid("ee68109a-5dc2-4ee0-94c4-d5b2bc988b0d"), false, new Guid("12c214fc-cc69-461c-aa49-9b1feba92c2e"), "//meta[@property='og:description']/@content" },
                    { new Guid("eec9a5e3-be6a-41fc-8bea-0011be5306ff"), false, new Guid("6c0da7df-74ef-4b96-b3cd-1a3817de9170"), "//meta[@name='description']/@content" },
                    { new Guid("f52db070-8137-4b2f-bd2a-38df1278a8db"), false, new Guid("276af382-dc02-4eb4-94fe-dcdadb713afe"), "//meta[@property='og:description']/@content" },
                    { new Guid("f7d4a009-ad00-4a5c-a357-314653720ed0"), false, new Guid("a0f009fa-c0de-48bf-973a-a0751d04b717"), "//meta[@property='og:description']/@content" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_video_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("29092055-b688-4fea-919b-896ccd631190"), false, new Guid("4e81b91f-d336-4b9c-a506-7b92ec6094d3"), "//div[contains(@class, 'PageContentCommonStyling_text')]/rg-video//video/@src" },
                    { new Guid("3ee17a0e-dd0b-4bcd-bf84-a515fc676d1a"), false, new Guid("f62b9c01-f69e-4ca1-b306-772184659e30"), "//div[contains(@class, 'eagleplayer')]//video/@src" },
                    { new Guid("5400cba2-ba39-411f-8ebe-38b872a53244"), false, new Guid("12c214fc-cc69-461c-aa49-9b1feba92c2e"), "//meta[@property='og:video:url']/@content" },
                    { new Guid("58e47920-1714-464a-ba75-69cef040880c"), false, new Guid("c80caa5e-9567-4654-94c6-1f6828fc2d0e"), "//div[@class='article__header']//div[@class='media__video']//video/@src" },
                    { new Guid("69a251fa-cfd2-431b-833c-de2c2d44aa37"), false, new Guid("48a43db8-ac32-409d-b5d9-3cb2aef71912"), "//meta[@property='og:video']/@content" },
                    { new Guid("6e44da01-1ff1-496c-9822-d33db0bb2e7a"), false, new Guid("5f4d0a7f-fcb4-41ae-987f-2fdf3f456e9d"), "//meta[@property='og:video']/@content" },
                    { new Guid("8434f54f-67a5-40a5-ba1b-b6af2279e2e5"), false, new Guid("b94ffa83-703d-49d0-982d-ec5c8a5bd084"), "//article//div[@class='videoWrapper' and @itemprop='video']/iframe[@class='video']/@src" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_modified_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_modified_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("02dd3a5a-2d5c-458e-a885-fa5ff5437ca2"), "yyyy-MM-ddTHH:mm:ss\"+0300\"", new Guid("91080107-6910-4971-ad22-260c87cd253c") },
                    { new Guid("0bd416b4-42c4-4e83-8ee9-04ec643c567b"), "yyyyMMddTHHmm", new Guid("300a86e9-2c1f-4adf-8648-e24fa7364b53") },
                    { new Guid("14d7bc19-97b6-4c90-9417-cf14a3a9a5fc"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("e76fa99b-25f9-4ccf-a924-a847ada87fe9") },
                    { new Guid("19564256-09d7-4d2b-873a-4377c345a602"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("9ad251b2-9ac1-44f2-99f9-590b0ce91ee9") },
                    { new Guid("1b3e2a90-1062-4c66-a403-d218d3bbd686"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("541f9351-3d63-4a22-9d31-4882b0d88aff") },
                    { new Guid("202fb8a6-d480-4b87-b533-a2e6f95029ac"), "yyyy-MM-dd HH:mm:ss", new Guid("98951eef-10b0-44c4-ab26-18eeab0c80d7") },
                    { new Guid("32fdd9fd-5569-4d78-be18-94bab537445f"), "yyyy-MM-ddTHH:mm:ss.fff\"Z+0300\"", new Guid("879b33a4-59e0-4025-85b1-d939dee96c68") },
                    { new Guid("4125ab4a-b483-4923-9d47-b99ba6be3327"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("4fc08b5f-3019-4024-acd7-1a73afa4f79a") },
                    { new Guid("6cc31f0d-7bb6-4a27-adba-5ef7a4955ae5"), "yyyy-MM-dd", new Guid("3608df25-da4f-4281-96d7-30c3db0a654e") },
                    { new Guid("7bbae360-b8d0-4555-9ed2-f69d938e49ce"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("a2419c06-784a-4624-ab75-17546afbe5f2") },
                    { new Guid("8ced9ab9-5e14-47a0-b7ad-fc17a15c664d"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("5e7de5e1-e085-4292-a2b3-1d078946a666") },
                    { new Guid("8ee7d0b8-adb5-4eb0-b961-412cc83835e0"), "yyyy-MM-ddTHH:mm:ss.fffZ", new Guid("437f092e-352e-4283-a6da-dcae22e0dcbf") },
                    { new Guid("8f890cf6-6f0e-43d0-a479-70b4f73bd232"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("8c88dba9-9c0d-4f31-bdf6-89529df4d78c") },
                    { new Guid("90e06fb0-20eb-4038-99c9-b6db4237a60d"), "yyyy-MM-dd HH:mm", new Guid("50d5c4a8-0d8b-4554-a53f-6aa2511d0aed") },
                    { new Guid("98eb1a04-8222-49cb-96a2-8f8b7f063fd2"), "yyyy-MM-ddTHH:mm:ss", new Guid("cbaabdd3-8363-4c46-8851-94a093c6bfb8") },
                    { new Guid("a80ba8c8-12df-454f-bd46-733680fa67a1"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("8d2f3849-9516-4038-ae4a-e943e3c9c646") },
                    { new Guid("ab3d64e9-9341-4d15-8bc8-71f9ed3a37b1"), "yyyyMMddTHHmm", new Guid("649f4984-5d0d-4888-acf5-2e74aa1d72b5") },
                    { new Guid("b5b391f7-7070-4c2c-8084-de7891066c4d"), "yyyy-MM-ddTHH:mm:ss\"+0300\"", new Guid("4e2ac486-74d8-41fd-acd1-40e123cae87e") },
                    { new Guid("b7b1da42-eb43-4ea4-8362-6706f3a438ca"), "yyyy-MM-ddTHH:mm:ss", new Guid("8d5f5fa4-e890-4770-aa1b-7291ba2d04ca") },
                    { new Guid("bbf94ebd-dbd9-4f50-a726-13db159106a6"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("28f61e5b-8adf-4dee-8c57-37d55d930d2d") },
                    { new Guid("ce2680d4-310e-4b76-b2aa-fb603381d187"), "\"обновлено\" d MMMM, HH:mm", new Guid("e7dd8c17-706d-4827-a169-315fe30643ef") },
                    { new Guid("d01b56d8-d8c8-47e0-a353-76e772dfb069"), "yyyy-MM-ddTHH:mm:ss.fffZ", new Guid("bc3fecbc-854b-4df5-9a0c-e105fc97eea0") },
                    { new Guid("ec773ce8-0b1c-4856-8e15-2444f2340d89"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("d7a0df16-25f2-4d51-ad3e-3d93bd9ef318") },
                    { new Guid("f0637436-3514-42dd-adab-b667d02172d1"), "\"обновлено\" d MMMM yyyy, HH:mm", new Guid("e7dd8c17-706d-4827-a169-315fe30643ef") },
                    { new Guid("f7051f60-430b-4e18-93d6-44df7fcf99d3"), "yyyy-MM-ddTHH:mmzzz", new Guid("2fb44e75-27f0-410f-b9ef-cc7c80457f08") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_published_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("00bd7cb5-cfb4-4138-a190-9fe1af46b29a"), "yyyy-MM-ddTHH:mm:ss\"+0300\"", new Guid("f6ee7ff8-18f3-4a44-8e79-32df466924e9") },
                    { new Guid("031a5f72-7bb2-44ad-b050-56eae284cea4"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("2fd57d16-6f4d-4323-8eb4-0b3fa541b698") },
                    { new Guid("0681cbe5-4985-405a-9f24-a5f2af0927bf"), "yyyy-MM-dd HH:mm:ss", new Guid("0c3cf546-81b1-4a2b-b0e1-ec5bc049821d") },
                    { new Guid("06a8197d-d829-4757-915e-9176c3db2e6d"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("2bc1a097-491b-464d-a811-c8bdf6e43191") },
                    { new Guid("09debcae-3dc1-4785-9cd5-15d2cc8f356d"), "dd MMMM yyyy, HH:mm", new Guid("d719b356-4bd5-4173-aa76-9dc73f9f11d7") },
                    { new Guid("0b067c7e-47a3-4857-93d3-6693d7e9456f"), "d MMMM yyyy, HH:mm", new Guid("b321d9ca-3f4c-47fd-a421-eaa7a1e64927") },
                    { new Guid("0e5079d7-85c8-441b-a8fa-cef65f2f735c"), "dd MMMM yyyy, HH:mm", new Guid("74107823-c563-47af-a257-a7ed73ba8fa2") },
                    { new Guid("154a1cb8-9091-48a3-ab13-5d7a2460fc1b"), "d MMMM yyyy \"в\" HH:mm", new Guid("d8558ca5-0081-45d0-8ed3-991a29122ad0") },
                    { new Guid("1ec73820-714c-4a25-8ec4-366aad67bc80"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("e3a0629b-b49c-488e-af91-e8595118719e") },
                    { new Guid("1fbda07c-9234-4e33-b61a-3aef04f2f924"), "yyyy-MM-ddTHH:mm:ss.fffZ", new Guid("06150fae-9f35-46f6-afb3-5a6666fd34a1") },
                    { new Guid("21e0c5cc-f7e5-4b3c-82d0-f7bb255e564b"), "d-M-yyyy HH:mm", new Guid("e647493c-ec7f-42ba-96cb-b80a06379221") },
                    { new Guid("22c1e6e3-616b-402a-9547-3f74827663e8"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("767ee3cb-1a6f-462d-833d-0b49599e4d49") },
                    { new Guid("2c343983-df37-42f8-86e0-7c5008bfe8a1"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("4b39ce1c-17b4-4d1d-b322-9d10562a18df") },
                    { new Guid("2fcf02a3-92a6-4894-b900-7ffe5fb57eea"), "d MMMM yyyy, HH:mm\" •\"", new Guid("96b0ecd9-8e6b-4159-afff-42b0a320421c") },
                    { new Guid("3c3fcf80-a31a-4426-b0f8-06b2b754b90a"), "HH:mm, d MMMM yyyy", new Guid("497e6236-8e37-4e06-b7e4-9547b8a3c9e8") },
                    { new Guid("45394174-80bb-40f9-9c80-79eb885a295e"), "dd.MM.yyyy, HH:mm", new Guid("bccd84b7-7110-4db5-a411-0b697fa079ba") },
                    { new Guid("4b082056-618a-46fa-86cf-90cbac86a787"), "HH:mm, d MMMM yyyy", new Guid("33279872-ff96-4e67-999e-ee6c6e70a257") },
                    { new Guid("50a7b28b-04aa-484c-b016-38b10ad4c83a"), "HH:mm", new Guid("74107823-c563-47af-a257-a7ed73ba8fa2") },
                    { new Guid("53634cd6-adb5-4833-b37b-fe296341fd8f"), "d MMMM, HH:mm,", new Guid("5ffebdc3-6c7e-4b31-83df-8a9676f96a3a") },
                    { new Guid("55a3b7d5-50f7-4759-bc37-2579a7245ab2"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("276062d0-a0c0-4cbc-a3b6-4006207c6abd") },
                    { new Guid("6959aa58-af3a-4f69-8948-91313a0069f7"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("71b0b369-1301-4638-b6c0-b561dfd9db36") },
                    { new Guid("76b32d11-9070-4f9f-8db4-e12d38e411ce"), "d MMMM yyyy, HH:mm \"МСК\"", new Guid("797abeaf-0611-4865-99a5-b22685f02696") },
                    { new Guid("81ab86f2-76b2-44c2-b460-d88d688d195b"), "dd.MM.yyyy \"-\" HH:mm", new Guid("d2a9e838-ea09-4db1-8870-f4730e060655") },
                    { new Guid("8440f3cd-5938-4348-a8ae-b1f61081c593"), "yyyy-MM-ddTHH:mm:ss\"+0300\"", new Guid("864d9c45-53ba-466b-a63e-28e2ad3566d3") },
                    { new Guid("88808d30-e06f-4369-ad9a-4efdfb51bb53"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("c70ea2de-6523-457c-a566-b44fb4dfff87") },
                    { new Guid("890bf270-4a88-45c6-8418-63708fbf71cd"), "dd MMMM HH:mm", new Guid("cce741df-430b-45f8-ba73-c4a7fed76fc8") },
                    { new Guid("8ab937b0-839f-4333-bc48-6440a1f9dd2a"), "dd.MM.yyyy HH:mm", new Guid("edcb9807-e3ff-491c-86b2-7ad038b795a4") },
                    { new Guid("94ac93d2-bcae-4b5a-8871-cb86d51ad4d0"), "yyyy-MM-dd", new Guid("d3b2d9d8-2e17-4431-95de-c10fcbae4e17") },
                    { new Guid("95e1cccb-059f-4c4a-bd37-d3d693f184fb"), "yyyy-MM-ddTHH:mm:ss", new Guid("8592808e-3aea-4519-aca6-6f1ec1fc14c3") },
                    { new Guid("9b14efb3-b06d-44c3-b89b-58d0c45a181a"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("8bc80405-d80d-4aaf-a60e-2fcfc0b371c4") },
                    { new Guid("9b6fb774-6008-407a-8319-ac358ea37f6d"), "d MMMM yyyy, HH:mm,", new Guid("5ffebdc3-6c7e-4b31-83df-8a9676f96a3a") },
                    { new Guid("9dc7b874-93cc-40d1-9427-b27da26804c0"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("24bb919d-db61-45b5-9bce-e7eadf90ddcd") },
                    { new Guid("a81a90bc-7b0d-4c09-9fb8-321b1da95951"), "yyyy-MM-ddTHH:mmzzz", new Guid("d9e70fef-775f-4963-a89b-8fb036b2d4ac") },
                    { new Guid("ab60b195-ebcb-44d6-93c3-51cb40be3854"), "yyyyMMddTHHmm", new Guid("4b301397-2495-4508-be2a-ed74adefa156") },
                    { new Guid("b3976e61-8169-447e-80b9-a57bf650a44f"), "yyyy-MM-ddTHH:mm:ss.fffZ", new Guid("4c634df1-77e6-4931-8e34-58e16e0fc92a") },
                    { new Guid("b490670c-4faa-4a62-81db-48187386a739"), "yyyy-MM-dd HH:mm", new Guid("b8ee0e55-976d-4ead-b492-190154b494a7") },
                    { new Guid("b871f454-e5a2-4bef-8c7d-5d43b4b70793"), "yyyy-MM-ddTHH:mm:ss.fffZ", new Guid("8a5f72d5-2468-467b-8197-b4c389a8194d") },
                    { new Guid("bcf25db0-c51d-47c8-863f-99b88c5b8d18"), "yyyy-MM-ddTHH:mm:ss.fff\"Z+0300\"", new Guid("79696516-c4cc-4712-8903-6720126cdbb2") },
                    { new Guid("bf13d350-dcfd-4f5b-88c7-aa5421b45777"), "yyyy-MM-dd HH:mm:ss", new Guid("80759c35-1193-4967-9838-e12ff789333b") },
                    { new Guid("c665b6da-ccf9-4762-8f7e-ec9948e15992"), "d MMMM, HH:mm", new Guid("5ffebdc3-6c7e-4b31-83df-8a9676f96a3a") },
                    { new Guid("c78a3a5f-448e-4d0a-aae8-553929c983cf"), "dd MMMM yyyy HH:mm", new Guid("cce741df-430b-45f8-ba73-c4a7fed76fc8") },
                    { new Guid("c8264c3c-fa9c-45f7-a6b9-1666a96f6ec2"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("94c71826-bf69-4b64-80a4-0e899f370965") },
                    { new Guid("cad3fb68-8a6d-4948-a536-410201ed3f13"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("fa4b7bb2-c760-4e0d-96ac-21dd5154751d") },
                    { new Guid("cbfb0c45-53e0-42fe-b714-86ca622e9d33"), "dd.MM.yyyy HH:mm", new Guid("9da8283e-6771-4f35-a3b3-7e4f31406460") },
                    { new Guid("d16c573c-5b67-4add-b8de-4c4d2168fcbb"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("f45a7692-9384-4a2b-b02a-e5b6e8cfccee") },
                    { new Guid("d7d7cb93-2557-4a8a-ac04-43e68bebf812"), "d MMMM yyyy HH:mm", new Guid("61bada83-0cac-41e1-8e15-6a0bc2b12493") },
                    { new Guid("e0a49b6d-0238-4dce-b4ae-37afa00e74e9"), "dd MMMM, HH:mm", new Guid("74107823-c563-47af-a257-a7ed73ba8fa2") },
                    { new Guid("e47b17e5-2dec-40c2-a4f8-421748e6a1c3"), "d MMMM yyyy", new Guid("b999811b-b6bf-4172-aebe-71c694487280") },
                    { new Guid("e61b8460-9555-415c-aa16-6750259c4168"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("2223cc9e-9ad1-4d22-9b6a-1486d2a8d607") },
                    { new Guid("e6e829a7-aea2-4dde-9cb7-2286c7415e33"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("9be5bd0e-b468-4347-903a-611a489527f8") },
                    { new Guid("e7ac25e3-9306-4c73-8852-5f7741172082"), "yyyyMMddTHHmm", new Guid("55ddeb78-a4f8-46e6-aaec-786e540a3e06") },
                    { new Guid("ef1c989b-d659-4d5b-ba92-207111ec312e"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("e8ec0621-95f8-42c9-8e5c-c535a0f76e51") },
                    { new Guid("f05c52ee-73c9-4f4c-8df3-aba256964f25"), "yyyy-MM-ddTHH:mm:ss", new Guid("2184b160-4ac8-4e4a-bfa0-e19bbdb87865") },
                    { new Guid("f46676be-9258-4993-b417-ac06c2234136"), "d MMMM yyyy, HH:mm", new Guid("5ffebdc3-6c7e-4b31-83df-8a9676f96a3a") },
                    { new Guid("fc627d9c-4b9b-4413-be4a-c76f48852179"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("88fdb3c2-4eba-4c3a-ba50-9f99d2f74d6b") },
                    { new Guid("fe67851e-370b-49ce-a123-516c3a168818"), "d MMMM  HH:mm", new Guid("61bada83-0cac-41e1-8e15-6a0bc2b12493") }
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

            migrationBuilder.CreateIndex(
                name: "ix_news_views_ip_address",
                table: "news_views",
                column: "ip_address");

            migrationBuilder.CreateIndex(
                name: "ix_news_views_news_id",
                table: "news_views",
                column: "news_id");

            migrationBuilder.CreateIndex(
                name: "ix_news_views_viewed_at",
                table: "news_views",
                column: "viewed_at");
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
                name: "news_views");

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
