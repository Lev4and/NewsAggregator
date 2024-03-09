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
                    { new Guid("034485d8-4249-44e6-9079-92516cc5370d"), true, "https://7days.ru/", "7дней.ru" },
                    { new Guid("037b1c41-ab76-4071-8687-c644997daf13"), true, "https://www.ntv.ru/", "НТВ" },
                    { new Guid("042f72dd-41a6-48a1-a2a9-bdd2d9580792"), true, "https://russian.rt.com/", "RT на русском" },
                    { new Guid("046565c3-3d73-4bc2-b280-5a415385fdab"), true, "https://www.khl.ru/", "КХЛ" },
                    { new Guid("048880f9-0884-4d79-ac86-e578d5a91a7e"), true, "https://www.championat.com/", "Чемпионат.com" },
                    { new Guid("099c5dd0-0363-4421-b993-e39e0d2e0552"), true, "https://www.hltv.org/", "HLTV.org" },
                    { new Guid("0ea676bf-0a7f-48a4-b8d8-fb7986baf747"), true, "https://ixbt.games/", "iXBT.games" },
                    { new Guid("0fdcfbe0-b879-4215-afeb-5e1bad2c1ac0"), true, "https://www.rbc.ru/", "РБК" },
                    { new Guid("1db41ddd-7656-4a0a-a8aa-d7e5aa730241"), true, "https://life.ru/", "Life" },
                    { new Guid("2366e708-2aa5-4041-b2d4-2c9918b83d46"), true, "https://rg.ru/", "Российская газета" },
                    { new Guid("285000c2-a4d1-4180-9065-6d946a930c95"), true, "https://www.1obl.ru/", "Первый областной" },
                    { new Guid("31941989-b1f8-4f1c-9ea3-cffecda0259d"), true, "https://www.kinonews.ru/", "KinoNews.ru" },
                    { new Guid("38a33c60-f8ce-4c24-bfc7-076ac5db22bc"), true, "https://www.cybersport.ru/", "Cybersport.ru" },
                    { new Guid("39ba409e-9e89-47e7-82eb-e0e162934cc4"), true, "https://www.m24.ru/", "Москва 24" },
                    { new Guid("3fd9928c-7368-463a-a73c-a4724a9ce2db"), true, "https://tsargrad.tv/", "Царьград" },
                    { new Guid("49316956-ce63-47a7-905e-49cfba2a1346"), true, "https://www.interfax.ru/", "Интерфакс" },
                    { new Guid("4a19a958-b4cc-4046-8a1a-b98d6aeefaf2"), true, "https://overclockers.ru/", "Overclockers" },
                    { new Guid("52af54b4-474a-4887-b59a-2c6a7aace79e"), true, "https://www.sports.ru/", "Storts.ru" },
                    { new Guid("53854fd4-4a50-4f1e-a6f9-a56e195295fa"), true, "https://tass.ru/", "ТАСС" },
                    { new Guid("546d30a7-75e7-42da-9fd3-f893f4b7465e"), true, "https://iz.ru/", "Известия" },
                    { new Guid("5c7ac952-5266-4783-9131-b218d0fdfca6"), true, "https://regnum.ru/", "ИА REGNUM" },
                    { new Guid("6089c6f9-929a-4b1c-9502-2bf34aa7ce88"), true, "https://www.gazeta.ru/", "Газета.Ru" },
                    { new Guid("630133c1-ab04-489c-8120-22caebafbd82"), true, "https://rusvesna.su/", "Русская весна" },
                    { new Guid("726c806b-fb35-4509-8c6e-ede61dd4ae99"), true, "https://www.5-tv.ru/", "Пятый канал" },
                    { new Guid("7d1f9e68-45c2-4616-8767-e79fad6b5d93"), true, "https://www.finam.ru/", "Финам.Ру" },
                    { new Guid("7e67cde0-5285-4b5a-814f-29f6428191e2"), true, "https://vz.ru/", "ВЗГЛЯД.РУ" },
                    { new Guid("7e78e249-9d53-426f-bd04-9e8e869f1fd8"), true, "https://smart-lab.ru/", "SMART-LAB" },
                    { new Guid("7f77ce7b-20ba-43fc-8169-600d89500d6f"), true, "https://www.fontanka.ru/", "ФОНТАНКА.ру" },
                    { new Guid("7fa5327f-cefb-47cb-98e2-bd102dddeb2e"), true, "https://74.ru/", "74.ru" },
                    { new Guid("81ae4b08-dd7f-4859-89bc-6ce82c3c15de"), true, "https://www.nytimes.com/", "The New York Times" },
                    { new Guid("8c66cbb4-e235-4b22-8142-eaa151a7d815"), true, "https://travelask.ru/", "TravelAsk" },
                    { new Guid("8e2a64f9-1f64-48cf-8c9d-fddb55a24134"), true, "https://www.kommersant.ru/", "Коммерсантъ" },
                    { new Guid("989343fc-a8f6-4840-8746-6b3f3eb00f5d"), true, "https://meduza.io/", "Meduza" },
                    { new Guid("a5aa2308-3768-4661-a74a-069d8a54789f"), true, "https://svpressa.ru/", "СвободнаяПресса" },
                    { new Guid("af86051b-7d0d-47fb-a975-c67e1c68660e"), true, "https://www.pravda.ru/", "Правда.ру" },
                    { new Guid("b7d19db8-88b5-4707-9a32-4a2ba60be6cc"), true, "https://www.avtovzglyad.ru/", "АвтоВзгляд" },
                    { new Guid("b818a134-1513-49b2-94f7-5ef59a421268"), true, "https://ria.ru/", "РИА Новости" },
                    { new Guid("b870468c-f636-48b7-bdd5-66315913a89d"), true, "https://www.zr.ru/", "Журнал \"За рулем\"" },
                    { new Guid("be2aeff9-ee84-4ac7-9a99-a1148b909587"), true, "https://ren.tv/", "РЕН ТВ" },
                    { new Guid("c065d23b-fa82-4814-b8f6-63bd0a9a88ad"), true, "https://www.ixbt.com/", "iXBT.com" },
                    { new Guid("c3e25c8f-ae8b-4fb0-8b7b-b9b46c5c1e9b"), true, "https://www.womanhit.ru/", "Женский журнал WomanHit.ru" },
                    { new Guid("ce3fab46-ecd0-4546-a2de-767b84f4dddf"), true, "https://www.kp.ru/", "Комсомольская правда" },
                    { new Guid("d2432d6c-5d94-44c6-b281-931e19b3270f"), true, "https://stopgame.ru/", "StopGame" },
                    { new Guid("d9e1b3b4-7a52-4c41-b4b7-894487d475be"), true, "https://aif.ru/", "Аргументы и факты" },
                    { new Guid("da896a33-2bb7-4ecd-9c29-12ca213c3f40"), true, "https://www.starhit.ru/", "Сетевое издание «Онлайн журнал StarHit (СтарХит)" },
                    { new Guid("dc835f30-5ead-43e0-b3ed-fdd04e9b80a2"), true, "https://radiosputnik.ru/", "Радио Sputnik" },
                    { new Guid("e7d7761b-df6a-45bf-85e4-572bc7985ac0"), true, "https://3dnews.ru/", "3Dnews.ru" },
                    { new Guid("e81d4ca1-3bd7-4485-8864-3c861a99f4b4"), true, "https://edition.cnn.com/", "CNN" },
                    { new Guid("ed83c801-82ea-4a5b-8c52-87fa4aa48db4"), true, "https://lenta.ru/", "Лента.Ру" },
                    { new Guid("f2545d86-16b6-42ac-9668-4a78242935ed"), true, "http://www.belta.by/", "БелТА" },
                    { new Guid("fb0892ce-81d8-41ad-a760-c5dfe90f8ca4"), true, "https://www.novorosinform.org/", "Новороссия" },
                    { new Guid("fd2dcf64-58be-46da-bba5-c590750be1d5"), true, "https://ura.news/", "Ura.ru" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_settings",
                columns: new[] { "id", "html_description_x_path", "source_id", "text_description_x_path", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("03b00068-703d-4914-8aac-417321efa4a9"), "//div[@itemprop='articleBody']/*", new Guid("285000c2-a4d1-4180-9065-6d946a930c95"), "//div[@itemprop='articleBody']/*//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("0897a798-2068-4eec-a0c2-8e870f890d1a"), "//div[@class='newsDetail-content__info']/*[not(name()='h1') and not(name()='h5')]", new Guid("046565c3-3d73-4bc2-b280-5a415385fdab"), "//div[@class='newsDetail-content__info']/*[not(name()='h1') and not(name()='h5')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("156719cd-f144-4bd4-9b16-98ae0b5cc3ab"), "//div[@class='article_text']", new Guid("d9e1b3b4-7a52-4c41-b4b7-894487d475be"), "//div[@class='article_text']//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("1619f60f-04c0-4ece-83af-eeccd5a78430"), "//div[contains(@class, 'field-type-text-long')]/*", new Guid("630133c1-ab04-489c-8120-22caebafbd82"), "//div[contains(@class, 'field-type-text-long')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("19127150-51c8-4c1f-bc51-654223610c6e"), "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]", new Guid("1db41ddd-7656-4a0a-a8aa-d7e5aa730241"), "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("2008019e-0565-498c-aa87-525ccff923c2"), "//div[@itemprop='articleBody']/*", new Guid("8c66cbb4-e235-4b22-8142-eaa151a7d815"), "//div[@itemprop='articleBody']//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("2107b9c3-4d7d-4944-ac87-c764eb2d8d60"), "//div[@itemprop='articleBody']/*[not(name()='div')]", new Guid("fd2dcf64-58be-46da-bba5-c590750be1d5"), "//div[@itemprop='articleBody']/*[not(name()='div')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("2d66b024-5877-485b-8999-bd58ca67096f"), "//span[@itemprop='articleBody']/*", new Guid("c3e25c8f-ae8b-4fb0-8b7b-b9b46c5c1e9b"), "//span[@itemprop='articleBody']//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("2e3f695a-3da6-4548-b327-f8e7ab704eb1"), "//div[@class='news-content__body']//div[contains(@class, 'content-text')]/*", new Guid("037b1c41-ab76-4071-8687-c644997daf13"), "//div[@class='news-content__body']//div[contains(@class, 'content-text')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("306cc38e-3f24-4f5e-a4bf-507f46d7c885"), "//div[@class='topic-body__content']", new Guid("ed83c801-82ea-4a5b-8c52-87fa4aa48db4"), "//div[@class='topic-body__content']//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("3196c477-1ac2-48d5-807d-b3d0973e8d1d"), "//div[contains(@class, 'js-mediator-article')]/*[position()>1]", new Guid("38a33c60-f8ce-4c24-bfc7-076ac5db22bc"), "//div[contains(@class, 'js-mediator-article')]/*[position()>1]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("35c0f63c-2a03-4414-bcfd-b35d3daeab29"), "//div[@class='textart']/div[not(@class)]/*", new Guid("31941989-b1f8-4f1c-9ea3-cffecda0259d"), "//div[@class='textart']/div[not(@class)]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("3d33915f-3ab0-434d-b52f-138593f0d065"), "//div[@itemprop='articleBody']/*", new Guid("e81d4ca1-3bd7-4485-8864-3c861a99f4b4"), "//div[@itemprop='articleBody']/*//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("42afad4c-6ae3-40ea-b5f6-cf16b62e0850"), "//section[@name='articleBody']/*", new Guid("81ae4b08-dd7f-4859-89bc-6ce82c3c15de"), "//section[@name='articleBody']/*//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("4b6b8db8-7417-4bd5-a58b-f64b64e78bc2"), "//article/div[@class='article-content']/*[not(@class)]", new Guid("048880f9-0884-4d79-ac86-e578d5a91a7e"), "//article/div[@class='article-content']/*[not(@class)]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("4dfd8e60-07e6-4c61-9faf-ef3b4d848df5"), "//div[contains(@class, 'article__body')]/*", new Guid("dc835f30-5ead-43e0-b3ed-fdd04e9b80a2"), "//div[contains(@class, 'article__body')]//*[not(name()='script')]/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("55b29016-4fa6-4d26-878a-3a118bb2677d"), "//div[contains(@class, 'styled__StoryBody')]/*[not(name()='p' and contains(@class, 'styled__StoryParagraph') and position()=1) and not(name()='div' and contains(@class, 'styled__StoryImgContainer') and position()=2)]", new Guid("b870468c-f636-48b7-bdd5-66315913a89d"), "//div[contains(@class, 'styled__StoryBody')]/*[not(name()='p' and contains(@class, 'styled__StoryParagraph') and position()=1) and not(name()='div' and contains(@class, 'styled__StoryImgContainer') and position()=2)]//text()", "//meta[@name='og:title']/@content" },
                    { new Guid("59d85dc4-4116-4785-8dbd-3bb18a472330"), "//section[contains(@class, '_page-section')]/div[contains(@class, '_content_')]/*", new Guid("d2432d6c-5d94-44c6-b281-931e19b3270f"), "//section[contains(@class, '_page-section')]/div[contains(@class, '_content_')]/*[contains(@class, '_text_')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("62978095-e4c3-4f20-a5fc-04b2da4fc359"), "//div[@class='js-mediator-article']", new Guid("f2545d86-16b6-42ac-9668-4a78242935ed"), "//div[@class='js-mediator-article']//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("6318fb5a-64ae-4196-8220-7cc9a5a2efdc"), "//div[contains(@class, 'article__text ')]", new Guid("042f72dd-41a6-48a1-a2a9-bdd2d9580792"), "//div[contains(@class, 'article__text ')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("679f0b16-d471-403d-a539-2095de1336a3"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]", new Guid("3fd9928c-7368-463a-a73c-a4724a9ce2db"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("6ce32b95-fa84-41ea-9bea-dbb808394cc1"), "//div[contains(@class, 'news-item__content')]", new Guid("52af54b4-474a-4887-b59a-2c6a7aace79e"), "//div[contains(@class, 'news-item__content')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("6ecfaab6-6a48-4d8e-95a2-87788c567cb3"), "//div[contains(@class, 'article__body')]", new Guid("b818a134-1513-49b2-94f7-5ef59a421268"), "//div[contains(@class, 'article__body')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("7054689b-8c29-4c3e-b100-777bb5b84ac9"), "//section[@itemprop='articleBody']/*", new Guid("b7d19db8-88b5-4707-9a32-4a2ba60be6cc"), "//section[@itemprop='articleBody']/*[not(name()='script')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("70d810d5-c12c-4a38-a868-8a06ecf3d658"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/*[position()>4]", new Guid("e7d7761b-df6a-45bf-85e4-572bc7985ac0"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/*[position()>4 and not(name()='script')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("75076198-ce23-40d8-95a0-23991ed6e3e5"), "//div[@data-gtm-el='content-body']/*[not(name()='div' and @data-wide='true')]", new Guid("ce3fab46-ecd0-4546-a2de-767b84f4dddf"), "//div[@data-gtm-el='content-body']/*[not(name()='div' and @data-wide='true')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("75b4334a-b28d-408a-a5fe-38f22d6ddc9b"), "//div[@itemprop='articleBody']/*[not(name()='figure' and position()=1)]", new Guid("7fa5327f-cefb-47cb-98e2-bd102dddeb2e"), "//div[@itemprop='articleBody']/*[not(name()='figure') and not(lazyhydrate)]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("7bed5daf-f215-43a7-b5a5-d7415990edb1"), "//article/*", new Guid("53854fd4-4a50-4f1e-a6f9-a56e195295fa"), "//article/*//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("7f032ab4-4968-414a-9e61-02f32b4cd50b"), "//div[@class='material-7days__paragraf-content']/*[not(name()='div' and @itemprop='image' and position()=1)]", new Guid("034485d8-4249-44e6-9079-92516cc5370d"), "//div[@class='material-7days__paragraf-content']//p//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("81713e54-2a73-4102-85ce-9b766f3e13ff"), "//div[@class='GeneralMaterial-module-article']/*[position()>1]", new Guid("989343fc-a8f6-4840-8746-6b3f3eb00f5d"), "//div[@class='GeneralMaterial-module-article']/*[position()>1]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("821e1e9a-2d0f-4bff-adb3-7fabe3b4b5ff"), "//article/div[@class='news_text']", new Guid("7e67cde0-5285-4b5a-814f-29f6428191e2"), "//article/div[@class='news_text']//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("83f8b67e-fa3e-4d64-81e0-09a172db2318"), "//div[contains(@class, 'finfin-local-plugin-publication-item-item-')]/*", new Guid("7d1f9e68-45c2-4616-8767-e79fad6b5d93"), "//div[contains(@class, 'finfin-local-plugin-publication-item-item-')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("87c7fe8e-f736-4faa-a29a-1b331445b876"), "//div[@class='article-text']/*[not(name()='div' and @class='picture-wrapper')]", new Guid("5c7ac952-5266-4783-9131-b218d0fdfca6"), "//div[@class='article-text']/*[not(name()='div' and @class='picture-wrapper')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("8b6e31eb-20a6-497a-bd8f-6e9f4f93b1de"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview')) and not(contains(@class, 'article__main-image'))]", new Guid("0fdcfbe0-b879-4215-afeb-5e1bad2c1ac0"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview')) and not(contains(@class, 'article__main-image'))]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("8e37382a-44cc-44f0-9690-45aa7c60744d"), "//div[contains(@class, 'material-content')]/*", new Guid("4a19a958-b4cc-4046-8a1a-b98d6aeefaf2"), "//div[contains(@class, 'material-content')]/p//text()", "//a[@class='header']/text()" },
                    { new Guid("995d5406-8855-46fb-aa46-59ace5ddcf6e"), "//div[@itemprop='articleBody']/*", new Guid("6089c6f9-929a-4b1c-9502-2bf34aa7ce88"), "//div[@itemprop='articleBody']/*//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("a1f604b3-5c28-4f24-bcf3-c1bc15bc6cad"), "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]", new Guid("39ba409e-9e89-47e7-82eb-e0e162934cc4"), "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("a2f84687-7724-4640-be47-79ffb765d81f"), "//div[contains(@class, 'container-fluid shifted') and not(p[@class='announce lead']) and not(h1) and not(hr)]", new Guid("0ea676bf-0a7f-48a4-b8d8-fb7986baf747"), "//div[contains(@class, 'container-fluid shifted') and not(p[@class='announce lead']) and not(h1) and not(hr)]//text()", "//meta[@name='og:title']/@content" },
                    { new Guid("a62509ee-9637-4d1b-8947-c9f712eaddb5"), "//div[@id='content']//div[contains(@class, 'topic')]/div[@class='content']/*", new Guid("7e78e249-9d53-426f-bd04-9e8e869f1fd8"), "//div[@id='content']//div[contains(@class, 'topic')]/div[@class='content']//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("ac578b21-3c65-4ec9-b9fb-009aebe5bcc7"), "//div[contains(@class, 'PageContentCommonStyling_text')]/*[not(name() = 'rg-video')]", new Guid("2366e708-2aa5-4041-b2d4-2c9918b83d46"), "//div[contains(@class, 'PageContentCommonStyling_text')]/*[not(name() = 'rg-video')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("b1a4c064-a6c3-4f13-82b2-2a520a0f2ad9"), "//div[@class='widgets__item__text__inside']/*", new Guid("be2aeff9-ee84-4ac7-9a99-a1148b909587"), "//div[@class='widgets__item__text__inside']//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("b49ca6f0-c0f3-4791-aca2-5648202243d1"), "//section[@itemprop='articleBody']/div[@class='ds-article-content-block-and-creative-container' and position()>1]", new Guid("da896a33-2bb7-4ecd-9c29-12ca213c3f40"), "//section[@itemprop='articleBody']/div[@class='ds-article-content-block-and-creative-container' and position()>1]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("c2dd81db-dd40-4716-b221-55a7e0b24190"), "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]", new Guid("49316956-ce63-47a7-905e-49cfba2a1346"), "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("c5ab1cb6-5085-4fef-9229-9118e5948251"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]", new Guid("8e2a64f9-1f64-48cf-8c9d-fddb55a24134"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("c7f81de1-20cd-4e2a-b2d4-430a306acf51"), "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]", new Guid("af86051b-7d0d-47fb-a975-c67e1c68660e"), "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]//text()", "//meta[@name='title']/@content" },
                    { new Guid("d2c8667d-3ff9-4d72-80a9-5a4423e4c2bd"), "//div[@id='article_body']/*", new Guid("726c806b-fb35-4509-8c6e-ede61dd4ae99"), "//div[@id='article_body']//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("e08416a9-e75f-4514-bc80-bd081a71f202"), "//div[@itemprop='articleBody']/*[position()>2]", new Guid("c065d23b-fa82-4814-b8f6-63bd0a9a88ad"), "//div[@itemprop='articleBody']/*[position()>2]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("e4655368-4d2c-4502-958c-a99c0d9d1471"), "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]", new Guid("a5aa2308-3768-4661-a74a-069d8a54789f"), "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("ec76a389-1ee4-41ed-8a9a-2d2491451918"), "//div[@itemprop='articleBody']/*", new Guid("546d30a7-75e7-42da-9fd3-f893f4b7465e"), "//div[@itemprop='articleBody']//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("ef2cbff3-870a-45f3-95dd-fe20f7cea27d"), "//section[@itemprop='articleBody']/*", new Guid("7f77ce7b-20ba-43fc-8169-600d89500d6f"), "//section[@itemprop='articleBody']//p//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("f0629df9-ac23-4b35-9009-3eb3df7069c9"), "//article//div[@class='newstext-con']/*[position()>2]", new Guid("099c5dd0-0363-4421-b993-e39e0d2e0552"), "//article//div[@class='newstext-con']/*[position()>2]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("f73a6421-12af-4481-acef-b880a91d643d"), "//div[@class='only__text']/*", new Guid("fb0892ce-81d8-41ad-a760-c5dfe90f8ca4"), "//div[@class='only__text']/*[not(name()='script')]//text()", "//meta[@property='og:title']/@content" }
                });

            migrationBuilder.InsertData(
                table: "news_search_settings",
                columns: new[] { "id", "news_site_url", "news_url_x_path", "source_id" },
                values: new object[,]
                {
                    { new Guid("0109f664-72a7-4a0f-a815-04b4403b6212"), "https://www.novorosinform.org/", "//a[contains(@href, '.html')]/@href", new Guid("fb0892ce-81d8-41ad-a760-c5dfe90f8ca4") },
                    { new Guid("0c4acc98-b82b-4393-9d60-7af2af3bbc10"), "https://7days.ru/news/", "//a[contains(@class, '7days__item_href') and starts-with(@href, '/news/')]/@href", new Guid("034485d8-4249-44e6-9079-92516cc5370d") },
                    { new Guid("0e6f8fef-74c9-4a16-a0fa-4086f3ce4bf4"), "https://svpressa.ru/all/news/", "//a[contains(@href, '/news/') and not(contains(@href, '?')) and not(starts-with(@href, '/all/news/'))]/@href", new Guid("a5aa2308-3768-4661-a74a-069d8a54789f") },
                    { new Guid("10c504e4-80f3-40bd-b187-7eed2c0fdddd"), "https://tsargrad.tv/", "//a[contains(@class, 'news-item__link')]/@href", new Guid("3fd9928c-7368-463a-a73c-a4724a9ce2db") },
                    { new Guid("1896c15c-e8cf-439a-ba1f-bacce1c09ce6"), "https://www.rbc.ru/", "//a[contains(@href, 'https://www.rbc.ru/') and contains(@href, '?from=')]/@href", new Guid("0fdcfbe0-b879-4215-afeb-5e1bad2c1ac0") },
                    { new Guid("1a4f2253-7af1-4c0a-b5f0-ae0061aed157"), "https://www.zr.ru/news/", "//a[contains(@href, '/news/') and not(starts-with(@href, '/news/')) and not(starts-with(@href, 'https://'))]/@href", new Guid("b870468c-f636-48b7-bdd5-66315913a89d") },
                    { new Guid("1b12e6dc-3c13-4ee1-95fd-b5dc456f729a"), "https://radiosputnik.ru/", "//a[starts-with(@href, 'https://radiosputnik.ru/') and contains(@href, '.html')]/@href", new Guid("dc835f30-5ead-43e0-b3ed-fdd04e9b80a2") },
                    { new Guid("22749480-9c11-4386-b169-1ac0f0872590"), "https://ren.tv/news/", "//a[starts-with(@href, '/news/')]/@href", new Guid("be2aeff9-ee84-4ac7-9a99-a1148b909587") },
                    { new Guid("2396edf8-453a-4e57-ac03-74e5b5102076"), "https://aif.ru/", "//span[contains(@class, 'item_text__title')]/../@href", new Guid("d9e1b3b4-7a52-4c41-b4b7-894487d475be") },
                    { new Guid("253dbc39-7125-4197-8794-26ad558bc749"), "https://www.ixbt.com/news/", "//a[starts-with(@href, '/news/') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("c065d23b-fa82-4814-b8f6-63bd0a9a88ad") },
                    { new Guid("2cc025d5-22d3-4d26-9e6e-5205a51592b0"), "https://www.m24.ru/", "//a[contains(@href, '/news/')]/@href", new Guid("39ba409e-9e89-47e7-82eb-e0e162934cc4") },
                    { new Guid("2ceeca42-747e-4b23-929a-1c7c5e3e7003"), "https://www.womanhit.ru/", "//a[not(@href='/stars/news/') and starts-with(@href, '/stars/news/')]/@href", new Guid("c3e25c8f-ae8b-4fb0-8b7b-b9b46c5c1e9b") },
                    { new Guid("30bbbf97-9a1b-42a9-95aa-fe49fb934062"), "https://www.nytimes.com/", "//a[contains(@href, '.html')]/@href", new Guid("81ae4b08-dd7f-4859-89bc-6ce82c3c15de") },
                    { new Guid("339ca50e-c800-4f0e-9b7f-4c50d3dcf1a8"), "https://overclockers.ru/news", "//div[contains(@class, 'event')]//a[not(contains(@href, '#comments'))]/@href", new Guid("4a19a958-b4cc-4046-8a1a-b98d6aeefaf2") },
                    { new Guid("3ddae590-b86b-4307-9d10-02538ad40952"), "https://vz.ru/", "//a[contains(@href, '.html') and not(contains(@href, '#comments')) and not(contains(@href, '?')) and not(contains(@href, '/about/'))]/@href", new Guid("7e67cde0-5285-4b5a-814f-29f6428191e2") },
                    { new Guid("40b266bc-4d1a-4bec-ae59-743dcb61240c"), "https://ixbt.games/news/", "//a[@class='card-link']/@href", new Guid("0ea676bf-0a7f-48a4-b8d8-fb7986baf747") },
                    { new Guid("5ed39f3d-53a3-47c3-b5f1-922d8dc830c8"), "https://www.pravda.ru/", "//a[contains(@href, '/news/') and not(@href='https://www.pravda.ru/news/')]/@href", new Guid("af86051b-7d0d-47fb-a975-c67e1c68660e") },
                    { new Guid("6ee63d38-34ec-49d1-b8f2-e0f5395d23da"), "https://ura.news/", "//a[contains(@href, '/news/')]/@href", new Guid("fd2dcf64-58be-46da-bba5-c590750be1d5") },
                    { new Guid("702adaa7-c62e-4297-8396-5395e477931a"), "https://www.avtovzglyad.ru/news/", "//a[@class='news-card__link']/@href", new Guid("b7d19db8-88b5-4707-9a32-4a2ba60be6cc") },
                    { new Guid("749de020-e002-4c25-96a7-46b58cf0f59e"), "https://www.khl.ru/news/", "//a[starts-with(@href, '/news/') and contains(@href, '.html')]/@href", new Guid("046565c3-3d73-4bc2-b280-5a415385fdab") },
                    { new Guid("77125961-48b8-4046-a062-f3c675bb6175"), "https://life.ru/s/novosti", "//a[contains(@href, '/p/')]/@href", new Guid("1db41ddd-7656-4a0a-a8aa-d7e5aa730241") },
                    { new Guid("7b34b09f-c321-45ca-9542-447dccdf3089"), "https://www.hltv.org/", "//a[contains(@href, '/news/')]/@href", new Guid("099c5dd0-0363-4421-b993-e39e0d2e0552") },
                    { new Guid("84c03f80-4333-4a32-bd22-57d3c31b9755"), "https://www.ntv.ru/novosti/", "//a[not(@href='/novosti/') and not(@href='/novosti/authors') and starts-with(@href, '/novosti/')]/@href", new Guid("037b1c41-ab76-4071-8687-c644997daf13") },
                    { new Guid("85007304-d036-4577-a623-1a73d796873b"), "https://www.gazeta.ru/news/", "//a[contains(@href, '/news/') and contains(@href, '.shtml') and not(contains(@href, '?'))]/@href", new Guid("6089c6f9-929a-4b1c-9502-2bf34aa7ce88") },
                    { new Guid("8530545c-ca94-4d92-a133-6f1049dd69c0"), "https://smart-lab.ru/news/", "//a[not(@href='/blog/') and starts-with(@href, '/blog/') and contains(@href, '.php')]/@href", new Guid("7e78e249-9d53-426f-bd04-9e8e869f1fd8") },
                    { new Guid("872b8069-24ed-4490-9fd1-dc392e1c2af8"), "https://www.championat.com/news/1.html?utm_source=button&utm_medium=news", "//a[contains(@href, 'news-') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("048880f9-0884-4d79-ac86-e578d5a91a7e") },
                    { new Guid("8fece6bf-6911-4507-991a-18ddbef3b750"), "https://meduza.io/", "//a[not(@href='/news/') and starts-with(@href, '/news/')]/@href", new Guid("989343fc-a8f6-4840-8746-6b3f3eb00f5d") },
                    { new Guid("9bbe6eeb-7a92-49a4-bbaf-f83791380598"), "https://www.finam.ru/", "//a[starts-with(@href, 'publications/item/') or starts-with(@href, '/publications/item/')]/@href", new Guid("7d1f9e68-45c2-4616-8767-e79fad6b5d93") },
                    { new Guid("9c1ba513-2a00-4b18-83dc-42d5a6b3dffc"), "https://travelask.ru/news", "//a[not(@href='/news/') and starts-with(@href, '/news/')]/@href", new Guid("8c66cbb4-e235-4b22-8142-eaa151a7d815") },
                    { new Guid("a36c7628-8c91-46dd-8a75-1f5402e8039b"), "https://www.5-tv.ru/news/", "//a[not(@href='https://www.5-tv.ru/news/') and starts-with(@href, 'https://www.5-tv.ru/news/')]/@href", new Guid("726c806b-fb35-4509-8c6e-ede61dd4ae99") },
                    { new Guid("a5021b87-1935-4f70-bbcf-4e12f91d3f90"), "https://stopgame.ru/news", "//div[contains(@class, 'list-view')]//div[contains(@class, '_card')]/a/@href", new Guid("d2432d6c-5d94-44c6-b281-931e19b3270f") },
                    { new Guid("a8fc593f-d221-45f7-afaf-24b23f2f1a80"), "https://rusvesna.su/news", "//a[not(@href='/news/') and starts-with(@href, '/news/')]/@href", new Guid("630133c1-ab04-489c-8120-22caebafbd82") },
                    { new Guid("a971425a-5b9e-414d-8057-2d9a9574e7c1"), "https://74.ru/", "//a[starts-with(@href, '/text/') and not(contains(@href, '?')) and not(contains(@href, 'comments/')) and not(@href='/text/')]/@href", new Guid("7fa5327f-cefb-47cb-98e2-bd102dddeb2e") },
                    { new Guid("b575dcd9-5398-426e-b78c-97c9452a22c5"), "https://tass.ru/", "//a[contains(@class, 'tass_pkg_link-v5WdK') and contains(substring(@href, 2), '/') and not(contains(@href, '/spec/')) and not(contains(@href, 'spec.tass.ru'))]/@href", new Guid("53854fd4-4a50-4f1e-a6f9-a56e195295fa") },
                    { new Guid("bfb349b2-dbc3-4cd5-be3e-285d1a6d1d44"), "https://regnum.ru/news", "//a[not(@href='/news/') and starts-with(@href, '/news/')]/@href", new Guid("5c7ac952-5266-4783-9131-b218d0fdfca6") },
                    { new Guid("c08a0a10-a3b1-4495-8dff-03132905ab4b"), "https://lenta.ru/", "//a[starts-with(@href, '/news/')]/@href", new Guid("ed83c801-82ea-4a5b-8c52-87fa4aa48db4") },
                    { new Guid("c18cec20-aebf-454d-b2fb-a80d4ef31dd3"), "https://edition.cnn.com/", "//a[contains(@href, '.html')]/@href", new Guid("e81d4ca1-3bd7-4485-8864-3c861a99f4b4") },
                    { new Guid("cba15f11-3ea5-4390-909b-972de1342824"), "https://3dnews.ru/news/", "//div[@class='news-feed-all']//a[@class='entry-header']/h1/../@href", new Guid("e7d7761b-df6a-45bf-85e4-572bc7985ac0") },
                    { new Guid("d7ac4228-57ca-4789-8bcb-a501ad49d9b7"), "https://ria.ru/", "//a[contains(@class, 'cell-list__item-link')]/@href", new Guid("b818a134-1513-49b2-94f7-5ef59a421268") },
                    { new Guid("d88dd0ac-1544-43bc-8881-ba8849da906c"), "https://www.starhit.ru/novosti/", "//a[@class='announce-inline-tile__label-container']/@href", new Guid("da896a33-2bb7-4ecd-9c29-12ca213c3f40") },
                    { new Guid("e21528d9-aa5f-4bc0-863e-bafa6392ac9a"), "https://www.cybersport.ru/", "//a[contains(@href, '/tags/')]/@href", new Guid("38a33c60-f8ce-4c24-bfc7-076ac5db22bc") },
                    { new Guid("e4deabc0-3aa5-43d2-8a22-2ece13a300c5"), "https://www.kinonews.ru/news/", "//a[contains(@href, '/news_') and not(contains(@href, 'comments')) and not(contains(@href, 'news_p'))]/@href", new Guid("31941989-b1f8-4f1c-9ea3-cffecda0259d") },
                    { new Guid("e5a3cdf6-d53a-4f9a-b409-a87733c80b7f"), "https://rg.ru/", "//a[contains(@href, '.html')]/@href", new Guid("2366e708-2aa5-4041-b2d4-2c9918b83d46") },
                    { new Guid("edb13b07-0290-4345-8277-0740a11f0561"), "https://www.fontanka.ru/24hours_news.html", "//section//ul/li[@class='IBae3']//a[@class='IBd3']/@href", new Guid("7f77ce7b-20ba-43fc-8169-600d89500d6f") },
                    { new Guid("ef600e55-c7e8-4d20-935a-d85461bdc77a"), "https://www.kommersant.ru/", "//a[contains(@href, '/doc/') and contains(@href, '?from=')]/@href", new Guid("8e2a64f9-1f64-48cf-8c9d-fddb55a24134") },
                    { new Guid("efc221dd-d540-4968-86ff-f7a1eb1af915"), "http://www.belta.by/", "//a[contains(@href, 'www.belta.by') and contains(@href, '/view/')]/@href", new Guid("f2545d86-16b6-42ac-9668-4a78242935ed") },
                    { new Guid("f1240280-45fc-4d44-b1a0-a291ef55ef26"), "https://www.kp.ru/", "//a[contains(@href, '/news/')]/@href", new Guid("ce3fab46-ecd0-4546-a2de-767b84f4dddf") },
                    { new Guid("f40a3c74-13de-422f-986d-46d5bf358305"), "https://iz.ru/news/", "//a[contains(@href, '?main_click')]/@href", new Guid("546d30a7-75e7-42da-9fd3-f893f4b7465e") },
                    { new Guid("f5075972-6c0e-406b-b6b9-4c206b236821"), "https://www.sports.ru/news/", "//a[contains(@href, '.html') and not(contains(@href, '.html#comments')) and not (contains(@href, '/blogs/'))]/@href", new Guid("52af54b4-474a-4887-b59a-2c6a7aace79e") },
                    { new Guid("f6e1264d-cec5-4490-8ff8-a8e4e73ee48a"), "https://www.interfax.ru/", "//div[@class='timeline']//a[@tabindex=5]/@href", new Guid("49316956-ce63-47a7-905e-49cfba2a1346") },
                    { new Guid("fa2798fa-a544-4e6f-bf6b-15d1dc18678d"), "https://russian.rt.com/", "//a[contains(@class, 'link') and contains(@href, 'news/')]/@href", new Guid("042f72dd-41a6-48a1-a2a9-bdd2d9580792") },
                    { new Guid("fced900f-6013-460e-8086-103ac0013159"), "https://www.1obl.ru/news/", "//a[starts-with(@href, '/news/') and not(contains(@href, '?'))]/@href", new Guid("285000c2-a4d1-4180-9065-6d946a930c95") }
                });

            migrationBuilder.InsertData(
                table: "news_source_logos",
                columns: new[] { "id", "original", "small", "source_id" },
                values: new object[,]
                {
                    { new Guid("0bd7712d-3c86-4423-a0b7-133089306a85"), "https://vz.ru/apple-touch-icon.png", "https://vz.ru/static/images/favicon.ico", new Guid("7e67cde0-5285-4b5a-814f-29f6428191e2") },
                    { new Guid("0dd0ae8f-1d0e-4416-ad4e-f3cb4b7f9bc2"), "https://s.rbk.ru/v10_rbcnews_static/common/common-10.10.120/images/android-chrome-512x512.png", "https://s.rbk.ru/v10_rbcnews_static/common/common-10.10.120/images/favicon.png", new Guid("0fdcfbe0-b879-4215-afeb-5e1bad2c1ac0") },
                    { new Guid("21362224-ecd8-42f0-bb04-6c2805b859fc"), "https://edition.cnn.com/media/sites/cnn/apple-touch-icon.png", "https://edition.cnn.com/media/sites/cnn/favicon.ico", new Guid("e81d4ca1-3bd7-4485-8864-3c861a99f4b4") },
                    { new Guid("218c9613-83fb-4337-b0a4-f943dba43e18"), "https://life.ru/appletouch/apple-icon-180%D1%85180.png", "https://life.ru/favicon-32%D1%8532.png", new Guid("1db41ddd-7656-4a0a-a8aa-d7e5aa730241") },
                    { new Guid("22a47b6e-2a8b-45c8-9d90-4b2d298d2070"), "https://www.avtovzglyad.ru/static/images/favicon/safari-pinned-tab.svg", "https://www.avtovzglyad.ru/static/images/favicon/favicon-32x32.png", new Guid("b7d19db8-88b5-4707-9a32-4a2ba60be6cc") },
                    { new Guid("26de6ad3-8dd7-4bb9-9828-ff2851aedad4"), "https://ixbt.games/images/favicon/gt/apple-touch-icon.png", "https://ixbt.games/images/favicon/gt/apple-touch-icon.png", new Guid("0ea676bf-0a7f-48a4-b8d8-fb7986baf747") },
                    { new Guid("2a7630d3-275c-4dd0-bae8-16080dc835c1"), "https://cdnn21.img.ria.ru/i/favicons/radiosputnik/apple-touch-icon.png", "https://cdnn21.img.ria.ru/i/favicons/radiosputnik/favicon.ico", new Guid("dc835f30-5ead-43e0-b3ed-fdd04e9b80a2") },
                    { new Guid("2d4a3077-0e0d-42d9-88a1-cfacc640826c"), "https://static.ngs.ru/jtnews/dist/static/favicons/apple/apple-favicon-74-180.png", "https://static.ngs.ru/jtnews/dist/static/favicons/favicon-rugion-32.ico", new Guid("7fa5327f-cefb-47cb-98e2-bd102dddeb2e") },
                    { new Guid("2d68ca98-f195-4ccb-896e-fe37ad0ce82b"), "https://meduza.io/apple-touch-icon-180.png", "https://meduza.io/favicon-32x32.png", new Guid("989343fc-a8f6-4840-8746-6b3f3eb00f5d") },
                    { new Guid("317028d4-e0a8-4bcf-99bb-ed23c92f34a4"), "https://www.khl.ru/img/icons/152x152.png", "https://www.khl.ru/img/icons/32x32.png", new Guid("046565c3-3d73-4bc2-b280-5a415385fdab") },
                    { new Guid("36d8a7e5-426b-49b0-a0be-65d4cc0c34e9"), "https://www.kinonews.ru/favicon.ico", "https://www.kinonews.ru/favicon.ico", new Guid("31941989-b1f8-4f1c-9ea3-cffecda0259d") },
                    { new Guid("437bfc61-b46b-4dfe-9b9d-cccc67cc0208"), "https://cdnstatic.rg.ru/images/touch-icon-ipad-retina_512x512.png", "https://rg.ru/favicon.ico", new Guid("2366e708-2aa5-4041-b2d4-2c9918b83d46") },
                    { new Guid("606cb47d-fca8-44b1-ad38-42659cd17555"), "https://static.gazeta.ru/nm2021/img/icons/favicon.svg", "https://static.gazeta.ru/nm2021/img/icons/favicon.svg", new Guid("6089c6f9-929a-4b1c-9502-2bf34aa7ce88") },
                    { new Guid("65478535-3e54-44fd-91b0-9b032248f3ed"), "https://3dnews.ru/assets/images/3dnews_logo_soc.png", "https://3dnews.ru/assets/3dnews_logo_color.png", new Guid("e7d7761b-df6a-45bf-85e4-572bc7985ac0") },
                    { new Guid("67e28d08-1303-4b37-a0b8-d6652258df39"), "https://overclockers.ru/assets/apple-touch-icon-120x120.png", "https://overclockers.ru/assets/apple-touch-icon.png", new Guid("4a19a958-b4cc-4046-8a1a-b98d6aeefaf2") },
                    { new Guid("6a2997ac-298d-4fee-b245-f7e539d8ae88"), "https://www.m24.ru/img/fav/apple-touch-icon.png", "https://www.m24.ru/img/fav/favicon-32x32.png", new Guid("39ba409e-9e89-47e7-82eb-e0e162934cc4") },
                    { new Guid("6beb8e94-6eb4-4ffd-82c2-0263402d9960"), "https://www.womanhit.ru/static/front/img/favicon.ico?v=2", "https://www.womanhit.ru/static/front/img/favicon.ico?v=2", new Guid("c3e25c8f-ae8b-4fb0-8b7b-b9b46c5c1e9b") },
                    { new Guid("6f05ae10-fdec-4ca6-ad1f-5c73b22adacb"), "https://tsargrad.tv/favicons/apple-touch-icon-180x180.png?s2", "https://tsargrad.tv/favicons/favicon-32x32.png?s2", new Guid("3fd9928c-7368-463a-a73c-a4724a9ce2db") },
                    { new Guid("72fb91d3-9d4a-4cf4-8771-5521961be494"), "https://www.sports.ru/apple-touch-icon-1024.png", "https://www.sports.ru/apple-touch-icon-76.png", new Guid("52af54b4-474a-4887-b59a-2c6a7aace79e") },
                    { new Guid("77e5e329-dd01-4cd8-bc91-b12ddeebce26"), "https://www.novorosinform.org/favicon.ico?v3", "https://www.novorosinform.org/favicon.ico?v3", new Guid("fb0892ce-81d8-41ad-a760-c5dfe90f8ca4") },
                    { new Guid("7830220f-bde9-4444-9f89-92f1d5be4ba3"), "https://regnum.ru/favicons/apple-touch-icon.png?v=202305", "https://regnum.ru/favicons/favicon-32x32.png?v=202305", new Guid("5c7ac952-5266-4783-9131-b218d0fdfca6") },
                    { new Guid("7bd9f65b-5b4b-4994-95de-eb6ab5f204db"), "https://cdn.iz.ru/profiles/portal/themes/purple/images/favicons/android-icon-192x192.png", "https://cdn.iz.ru/profiles/portal/themes/purple/images/favicons/favicon-32x32.png", new Guid("546d30a7-75e7-42da-9fd3-f893f4b7465e") },
                    { new Guid("836737ae-346f-4363-9ab7-aa29f934ca1d"), "https://ura.news/apple-touch-icon.png", "https://s.ura.news/favicon.ico?3", new Guid("fd2dcf64-58be-46da-bba5-c590750be1d5") },
                    { new Guid("8851b83a-315c-4ec1-aaa9-862e040940c9"), "https://st.championat.com/i/favicon/apple-touch-icon.png", "https://st.championat.com/i/favicon/favicon-32x32.png", new Guid("048880f9-0884-4d79-ac86-e578d5a91a7e") },
                    { new Guid("88f9cf38-d525-44f0-a3e6-33019ad49dea"), "https://smart-lab.ru/templates/skin/smart-lab-x3/images/favicon.ico", "https://smart-lab.ru/templates/skin/smart-lab-x3/images/favicon.ico", new Guid("7e78e249-9d53-426f-bd04-9e8e869f1fd8") },
                    { new Guid("908a3501-9dd1-4e1b-8cf4-7a5b9b2395f9"), "https://svpressa.ru/favicon-96x96.png?v=1471426270000", "https://svpressa.ru/favicon-32x32.png?v=1471426270000", new Guid("a5aa2308-3768-4661-a74a-069d8a54789f") },
                    { new Guid("995cde5f-5ea0-468c-9f36-70c1c509e6d4"), "https://www.interfax.ru/touch-icon-ipad-retina.png", "https://www.interfax.ru/touch-icon-iphone.png", new Guid("49316956-ce63-47a7-905e-49cfba2a1346") },
                    { new Guid("99c65ba8-57a4-4154-9330-3e3d7ffce695"), "https://www.pravda.ru/pix/apple-touch-icon.png", "https://www.pravda.ru/favicon.ico", new Guid("af86051b-7d0d-47fb-a975-c67e1c68660e") },
                    { new Guid("9b37a6e1-5529-4503-8f2d-287791141e48"), "https://cdnn21.img.ria.ru/i/favicons/favicon.svg", "https://cdnn21.img.ria.ru/i/favicons/favicon.ico", new Guid("b818a134-1513-49b2-94f7-5ef59a421268") },
                    { new Guid("9bc47d42-43f7-46b2-aabf-95eb25f77b46"), "https://www.cybersport.ru/favicon-192x192.png", "https://www.cybersport.ru/favicon-32x32.png", new Guid("38a33c60-f8ce-4c24-bfc7-076ac5db22bc") },
                    { new Guid("9c8a2fec-f3a7-4402-a1b6-fd4faba932de"), "https://www.nytimes.com/vi-assets/static-assets/apple-touch-icon-28865b72953380a40aa43318108876cb.png", "https://www.nytimes.com/vi-assets/static-assets/ios-default-homescreen-57x57-dark-b395ebcad5b63aff9285aab58e31035e.png", new Guid("81ae4b08-dd7f-4859-89bc-6ce82c3c15de") },
                    { new Guid("a2d3a7a5-0efd-4e7b-9448-63729b443246"), "https://im.kommersant.ru/ContentFlex/images/favicons2020/apple-touch-icon-180.png", "https://im.kommersant.ru/ContentFlex/images/favicons2020/favicon-32.png", new Guid("8e2a64f9-1f64-48cf-8c9d-fddb55a24134") },
                    { new Guid("a415bcbc-6eda-4fe7-95f2-ad058bc569b2"), "https://img5tv.cdnvideo.ru/shared/img/favicon_24.png", "https://img5tv.cdnvideo.ru/shared/img/favicon_24.png", new Guid("726c806b-fb35-4509-8c6e-ede61dd4ae99") },
                    { new Guid("a5c9b266-8f94-4ebb-9c37-a4c2cbffd199"), "https://russian.rt.com/static/blocks/touch-icon/apple-touch-icon-144x144-precomposed.png", "https://russian.rt.com/favicon.ico", new Guid("042f72dd-41a6-48a1-a2a9-bdd2d9580792") },
                    { new Guid("a72779d8-c29a-412f-a030-bcc6f90e49e5"), "https://aif.ru/img/icon/apple-touch-icon.png?44f", "https://aif.ru/img/icon/favicon-32x32.png?44f", new Guid("d9e1b3b4-7a52-4c41-b4b7-894487d475be") },
                    { new Guid("a8e8bd31-c6ea-4919-b470-b7558787e9f3"), "https://7days.ru/android-icon-192x192.png", "https://7days.ru/favicon-32x32.png", new Guid("034485d8-4249-44e6-9079-92516cc5370d") },
                    { new Guid("a97e72c5-91b0-4d5c-8c50-afc7acba5093"), "https://www.hltv.org/img/static/favicon/apple-touch-icon.png", "https://www.hltv.org/img/static/favicon/favicon-32x32.png", new Guid("099c5dd0-0363-4421-b993-e39e0d2e0552") },
                    { new Guid("b0c1aba9-a410-48d1-8523-6d5265a25061"), "https://www.ixbt.com/favicon.ico", "https://www.ixbt.com/favicon.ico", new Guid("c065d23b-fa82-4814-b8f6-63bd0a9a88ad") },
                    { new Guid("b96a92b3-0b70-4602-a853-18f589c59576"), "https://s9.travelask.ru/favicons/apple-touch-icon-180x180.png", "https://s9.travelask.ru/favicons/favicon-32x32.png", new Guid("8c66cbb4-e235-4b22-8142-eaa151a7d815") },
                    { new Guid("bced7a57-e784-4f66-b87c-c4820bd7e083"), "https://tass.ru/favicon/180.svg", "https://tass.ru/favicon/57.png", new Guid("53854fd4-4a50-4f1e-a6f9-a56e195295fa") },
                    { new Guid("c23fc737-6161-4dad-a4ac-200e51d1879f"), "https://rusvesna.su/favicon.ico", "https://rusvesna.su/favicon.ico", new Guid("630133c1-ab04-489c-8120-22caebafbd82") },
                    { new Guid("cab50a98-084f-4e6d-958e-b0c47642378e"), "https://www.finam.ru/favicon-144x144.png", "https://www.finam.ru/favicon.png", new Guid("7d1f9e68-45c2-4616-8767-e79fad6b5d93") },
                    { new Guid("d784e7fb-ba2f-4b16-b385-313d80af58e3"), "https://cdn-static.ntv.ru/images/favicons/android-chrome-192x192.png", "https://cdn-static.ntv.ru/images/favicons/favicon-32x32.png", new Guid("037b1c41-ab76-4071-8687-c644997daf13") },
                    { new Guid("dd9edc0b-79df-4a04-ba0f-e009089a1556"), "https://cdn.hsmedia.ru/public/favicon/starhit/apple-touch-icon.png", "https://cdn.hsmedia.ru/public/favicon/starhit/favicon.png", new Guid("da896a33-2bb7-4ecd-9c29-12ca213c3f40") },
                    { new Guid("df8f735f-ff6a-457b-b08f-f63be194bb19"), "https://icdn.lenta.ru/images/icons/icon-256x256.png", "https://icdn.lenta.ru/favicon.ico", new Guid("ed83c801-82ea-4a5b-8c52-87fa4aa48db4") },
                    { new Guid("e8888eaa-b29c-423d-96be-8bc18ee2c5d1"), "https://www.1obl.ru/apple-touch-icon.png", "https://www.1obl.ru/favicon-32x32.png", new Guid("285000c2-a4d1-4180-9065-6d946a930c95") },
                    { new Guid("f1fbd012-5917-47c7-8c4f-62626fcc5d7c"), "https://stopgame.ru/favicon_512.png", "https://stopgame.ru/favicon.ico", new Guid("d2432d6c-5d94-44c6-b281-931e19b3270f") },
                    { new Guid("f3c01ad8-de0f-4624-bd7f-aef59f596741"), "https://www.zr.ru/favicons/safari-pinned-tab.svg", "https://www.zr.ru/favicons/favicon.ico", new Guid("b870468c-f636-48b7-bdd5-66315913a89d") },
                    { new Guid("f3fc5a26-d9bb-49f8-97f9-069290b027da"), "https://s01.stc.yc.kpcdn.net/s0/2.1.321/adaptive/favicon-128.png", "https://s01.stc.yc.kpcdn.net/s0/2.1.321/adaptive/favicon-32.png", new Guid("ce3fab46-ecd0-4546-a2de-767b84f4dddf") },
                    { new Guid("f49f1907-a45e-42d4-8d0b-7ca834a7e80c"), "https://www.belta.by/images/storage/banners/000016_a133e848cb2e7b1debb7102d19e4d139_work.svg", "https://www.belta.by/images/storage/banners/000016_a133e848cb2e7b1debb7102d19e4d139_work.svg", new Guid("f2545d86-16b6-42ac-9668-4a78242935ed") },
                    { new Guid("f4a53ef2-3dec-4d01-b332-c6af7547dbdb"), "https://www.fontanka.ru/static/assets/favicons/apple/apple-favicon-180.png", "https://www.fontanka.ru/static/assets/favicons/apple/apple-favicon-76-precomposed.png", new Guid("7f77ce7b-20ba-43fc-8169-600d89500d6f") },
                    { new Guid("fa78567c-0fcb-446a-b45b-1a857d2fca91"), "https://ren.tv/apple-touch-icon.png", "https://ren.tv/favicon-32x32.png", new Guid("be2aeff9-ee84-4ac7-9a99-a1148b909587") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_editor_settings",
                columns: new[] { "id", "is_required", "name_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("109003c1-3fdb-4aa5-8fb6-84dcecebb425"), false, "//section[contains(@class, '_page-section')]//div[contains(@class, '_bottom-info_')]//span[contains(@class, '_user-info__name_')]/text()", new Guid("59d85dc4-4116-4785-8dbd-3bb18a472330") },
                    { new Guid("11c95a88-d610-442c-8084-56a04d28c9bf"), false, "//meta[@name='mediator_author']/@content", new Guid("70d810d5-c12c-4a38-a868-8a06ecf3d658") },
                    { new Guid("29e9b3b6-a587-4bac-b5e0-c78ab71d9bae"), false, "//div[@class='blog-post-info']//div[@itemprop='author']//span[@itemprop='name']/text()", new Guid("2008019e-0565-498c-aa87-525ccff923c2") },
                    { new Guid("2d714a97-93b3-4fc1-afa7-c388e110c9af"), false, "//footer[@class='news-item__footer']/div[@class='news-item__footer-after-news']/p[position()=1]//span/text()", new Guid("6ce32b95-fa84-41ea-9bea-dbb808394cc1") },
                    { new Guid("307e5606-8cef-4cec-9482-fa086740493c"), false, "//article//header//div[@class='b-authors']/div[@class='b-author' and position()=1]//text()", new Guid("e4655368-4d2c-4502-958c-a99c0d9d1471") },
                    { new Guid("311bc0a4-49d2-4030-a12d-2108fc6c144e"), false, "//p[@class='doc__text document_authors']/text()", new Guid("c5ab1cb6-5085-4fef-9229-9118e5948251") },
                    { new Guid("329188d8-e480-4de9-a38b-668d43cf617e"), false, "//div[@class='article__content']//strong[text()='Автор:']/../text()", new Guid("f73a6421-12af-4481-acef-b880a91d643d") },
                    { new Guid("34e9907b-83d3-4466-b8d6-3590d327807d"), false, "//div[@class='topic-authors']/a[@class='topic-authors__author']/text()", new Guid("306cc38e-3f24-4f5e-a4bf-507f46d7c885") },
                    { new Guid("3ad1a7f5-52bb-4534-b41c-30bdff21f795"), false, "//div[@itemprop='author']//p[@itemprop='name']/text()", new Guid("75b4334a-b28d-408a-a5fe-38f22d6ddc9b") },
                    { new Guid("433bd8dd-e5cf-431f-b8ad-82815d5603ae"), false, "//meta[@property='article:author']/@content", new Guid("35c0f63c-2a03-4414-bcfd-b35d3daeab29") },
                    { new Guid("480a8e45-88e8-4dbf-80b5-64b2c1c1dd9e"), false, "//meta[@property='article:author']/@content", new Guid("4b6b8db8-7417-4bd5-a58b-f64b64e78bc2") },
                    { new Guid("489f1d76-e528-49af-bd4b-2f37f7787a18"), false, "//span[@class='author']/a/text()", new Guid("8e37382a-44cc-44f0-9690-45aa7c60744d") },
                    { new Guid("4c94b26c-2811-4c8d-a3c5-8c9a7cc9f9d6"), false, "//meta[@property='article:author']/@content", new Guid("83f8b67e-fa3e-4d64-81e0-09a172db2318") },
                    { new Guid("552a9c85-1375-4e56-a5ff-97094d5f9546"), false, "//div[@class='container-fluid publication-footer']//a[contains(@class, 'text-secondary')]/@title", new Guid("a2f84687-7724-4640-be47-79ffb765d81f") },
                    { new Guid("556a54c4-f28b-49f6-ad89-57ad669a2a68"), false, "//div[@class='article__announce-authors']/a[@itemprop='author']/span[@itemprop='name']/text()", new Guid("2d66b024-5877-485b-8999-bd58ca67096f") },
                    { new Guid("593bd9c7-7c93-49f1-9e4a-415c113130dc"), false, "//meta[@name='mediator_author']/@content", new Guid("6318fb5a-64ae-4196-8220-7cc9a5a2efdc") },
                    { new Guid("661ae3ee-f34c-44b9-8f04-45bd05357509"), false, "//meta[@name='author']/@content", new Guid("b49ca6f0-c0f3-4791-aca2-5648202243d1") },
                    { new Guid("6b589ef9-cbc2-4a77-baa2-af5f8cffb2bb"), false, "//div[@id='content']//div[contains(@class, 'topic')]/ul[contains(@class, 'blog_more')]//li[@class='author']//text()", new Guid("a62509ee-9637-4d1b-8947-c9f712eaddb5") },
                    { new Guid("6cf7d71c-77f2-4df7-a530-772129fddda8"), false, "//meta[@property='author']/@content", new Guid("2e3f695a-3da6-4548-b327-f8e7ab704eb1") },
                    { new Guid("743d48f7-fa92-473c-b5f0-4d0da2039a66"), false, "//span[@itemprop='author']/span[@itemprop='name']/@content", new Guid("e08416a9-e75f-4514-bc80-bd081a71f202") },
                    { new Guid("755b10dd-4b26-4931-adac-cd882479e13d"), false, "//div[contains(@class, 'PageArticleContent_authors')]//a[contains(@class, 'LinksOfAuthor_item')]/text()", new Guid("ac578b21-3c65-4ec9-b9fb-009aebe5bcc7") },
                    { new Guid("7ed8a79c-8432-428b-9f46-d060620b4835"), false, "//div[@class='preview__author-block']//div[@class='author__about']/a[@itemprop='name']/@content", new Guid("7054689b-8c29-4c3e-b100-777bb5b84ac9") },
                    { new Guid("850ae3a4-45ce-469d-9277-ffdf1fa1a4a4"), false, "//span[@itemprop='name']/a/text()", new Guid("42afad4c-6ae3-40ea-b5f6-cf16b62e0850") },
                    { new Guid("8d7305a8-550f-4546-b706-757d0117a86d"), false, "//div[contains(@class, 'styled__StoryInfoAuthors')]/div[contains(@class, 'styled__InfoAuthor')]//span[contains(@class, 'styled__AuthorName')]/text()", new Guid("55b29016-4fa6-4d26-878a-3a118bb2677d") },
                    { new Guid("9f7cedf3-ebc0-4921-8b96-81cbb6eb2870"), false, "//meta[@property='ajur:article:authors']/@content", new Guid("ef2cbff3-870a-45f3-95dd-fe20f7cea27d") },
                    { new Guid("a3844c0d-1fca-4127-9459-84bd7443b9fc"), false, "//article/p[@class='author']/text()", new Guid("821e1e9a-2d0f-4bff-adb3-7fabe3b4b5ff") },
                    { new Guid("ad8414b8-b636-4563-9b2b-5dcf155da0ca"), false, "//div[@itemprop='author']/span[@itemprop='name']/text()", new Guid("2107b9c3-4d7d-4944-ac87-c764eb2d8d60") },
                    { new Guid("b283be08-b458-4861-8913-eb3fe71df423"), false, "//a[@class='article__author']/text()", new Guid("679f0b16-d471-403d-a539-2095de1336a3") },
                    { new Guid("b381b53d-33f3-443d-aa31-599efb115088"), false, "//div[@class='article_top']//div[@class='authors']//div[@class='autor']//span/text()", new Guid("156719cd-f144-4bd4-9b16-98ae0b5cc3ab") },
                    { new Guid("b3d0a349-d061-43f1-abe7-1a20489e86c5"), false, "//div[@class='newsDetail-body__item-header']/a[contains(@class, 'newsDetail-person')]//p[contains(@class, 'newsDetail-person__info-name')]/text()", new Guid("0897a798-2068-4eec-a0c2-8e870f890d1a") },
                    { new Guid("bedec32a-a334-484d-9557-c6880bccad41"), false, "//meta[@name='author']/@content", new Guid("3d33915f-3ab0-434d-b52f-138593f0d065") },
                    { new Guid("bfa44a8a-e719-4873-8ec1-9aff9a5b6f28"), false, "//div[@class='article__authors']//*[@class='article__authors__author']/span[@class='article__authors__author__name']/text()", new Guid("8b6e31eb-20a6-497a-bd8f-6e9f4f93b1de") },
                    { new Guid("c6984acb-cc56-453f-8605-357ebd3f69b5"), false, "//div[@class='GeneralMaterial-module-materialHeader']//div[contains(@class, 'MetaItem-module_hasSource') and not(time)]/text()", new Guid("81713e54-2a73-4102-85ce-9b766f3e13ff") },
                    { new Guid("cee45efa-c5eb-45fd-8ad6-75583ae19314"), false, "//meta[@property='article:author']/@content", new Guid("ec76a389-1ee4-41ed-8a9a-2d2491451918") },
                    { new Guid("d02be6bc-f72c-4f58-bef7-1510697bb095"), false, "//meta[@name='author']/@content", new Guid("c7f81de1-20cd-4e2a-b2d4-430a306acf51") },
                    { new Guid("dfc60f79-cca7-4ef9-82b3-dad553da8528"), false, "//*[@itemprop='author']/*[@itemprop='name']//text()", new Guid("03b00068-703d-4914-8aac-417321efa4a9") },
                    { new Guid("e201e510-491c-47e4-b724-f7a10435a0a5"), false, "//article//span[@class='author']/a[@class='authorName']/span/text()", new Guid("f0629df9-ac23-4b35-9009-3eb3df7069c9") },
                    { new Guid("e837c5c9-d52b-42fd-8587-3442e919c6c2"), false, "//div[contains(@class, 'styles_bodyWrapper')]//div[contains(@class, 'styles_authorsLinks')]/a/text()", new Guid("19127150-51c8-4c1f-bc51-654223610c6e") },
                    { new Guid("eea738ff-d96c-419c-8794-5a67d8814340"), false, "//div[@class='author']/span[@itemprop='author']/span[@itemprop='name']/a/text()", new Guid("995d5406-8855-46fb-aa46-59ace5ddcf6e") },
                    { new Guid("f5200373-ca28-421d-a702-87434d5c0677"), false, "//meta[@name='article:author']/@content", new Guid("d2c8667d-3ff9-4d72-80a9-5a4423e4c2bd") },
                    { new Guid("f859f415-5aab-4199-9c0a-c71c06e45577"), false, "//meta[@property='article:author']/@content", new Guid("4dfd8e60-07e6-4c61-9faf-ef3b4d848df5") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_modified_at_settings",
                columns: new[] { "id", "is_required", "modified_at_culture_info", "modified_at_time_zone_info_id", "modified_at_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("00ab0ecc-8e73-49ad-92ca-cfbcab2ed1d3"), false, "ru-RU", "Russian Standard Time", "//meta[@property='article:modified_time']/@content", new Guid("d2c8667d-3ff9-4d72-80a9-5a4423e4c2bd") },
                    { new Guid("08ae81a0-cb14-49c5-b77a-42e1162fb2ab"), false, "ru-RU", null, "//meta[@property='article:modified_time']/@content", new Guid("3196c477-1ac2-48d5-807d-b3d0973e8d1d") },
                    { new Guid("175c664b-f971-4fc8-8b47-8fbb14e24771"), false, "ru-RU", "Russian Standard Time", "//meta[@property='article:modified_time']/@content", new Guid("ac578b21-3c65-4ec9-b9fb-009aebe5bcc7") },
                    { new Guid("1c96ff0d-45fa-4254-822d-9f127848003a"), false, "ru-RU", null, "//meta[@property='article:modified_time']/@content", new Guid("679f0b16-d471-403d-a539-2095de1336a3") },
                    { new Guid("1ca60f0d-729e-4018-a223-66032a638edc"), false, "ru-RU", null, "//meta[@property='article:modified_time']/@content", new Guid("b1a4c064-a6c3-4f13-82b2-2a520a0f2ad9") },
                    { new Guid("22389535-4e80-4b57-b911-3387cf9527cd"), false, "en-US", null, "//meta[@property='article:modified_time']/@content", new Guid("42afad4c-6ae3-40ea-b5f6-cf16b62e0850") },
                    { new Guid("29c93386-2dcd-431f-a8c0-aaba98c67aa6"), false, "ru-RU", null, "//meta[@property='article:modified_time']/@content", new Guid("ec76a389-1ee4-41ed-8a9a-2d2491451918") },
                    { new Guid("3bf6bd76-896c-488d-bdeb-7dfffc88b98f"), false, "ru-RU", null, "//meta[@itemprop='dateModified']/@content", new Guid("b49ca6f0-c0f3-4791-aca2-5648202243d1") },
                    { new Guid("468a5a57-c577-4eee-bc5a-ab7a67071032"), false, "en-US", null, "//meta[@property='article:modified_time']/@content", new Guid("3d33915f-3ab0-434d-b52f-138593f0d065") },
                    { new Guid("47966008-c06f-4450-9745-415b555de576"), false, "ru-RU", "Russian Standard Time", "//meta[@property='og:updated_time']/@content", new Guid("1619f60f-04c0-4ece-83af-eeccd5a78430") },
                    { new Guid("4ea1a7db-bdb4-4949-a906-1638536a5ebe"), false, "ru-RU", null, "//meta[@property='article:modified_time']/@content", new Guid("c5ab1cb6-5085-4fef-9229-9118e5948251") },
                    { new Guid("51d3b0fc-ddd4-4ef8-9974-fa31685f6c3e"), false, "ru-RU", null, "//meta[@itemprop='dateModified']/@content", new Guid("03b00068-703d-4914-8aac-417321efa4a9") },
                    { new Guid("5c6e6321-a8bc-47bf-bdaf-e7306d1b7e0a"), false, "ru-RU", null, "//meta[@itemprop='dateModified']/@content", new Guid("8b6e31eb-20a6-497a-bd8f-6e9f4f93b1de") },
                    { new Guid("6771b8c6-2418-432d-bcc6-1083035eb7c0"), false, "ru-RU", "Russian Standard Time", "//meta[@property='article:modified_time']/@content", new Guid("6ecfaab6-6a48-4d8e-95a2-87788c567cb3") },
                    { new Guid("a08b6951-4b09-4142-a6fc-52f930169424"), false, "ru-RU", "Russian Standard Time", "//meta[@property='article:modified_time']/@content", new Guid("4dfd8e60-07e6-4c61-9faf-ef3b4d848df5") },
                    { new Guid("a3e0bda5-75b2-43bc-a2cb-ab856acd16a0"), false, "ru-RU", "Russian Standard Time", "//meta[@itemprop='dateModified']/@content", new Guid("c2dd81db-dd40-4716-b221-55a7e0b24190") },
                    { new Guid("a955bb87-eb9d-4ab1-ac35-96896f12090f"), false, "ru-RU", "Russian Standard Time", "//meta[@property='article:modified_time']/@content", new Guid("2008019e-0565-498c-aa87-525ccff923c2") },
                    { new Guid("b2bb22cf-f26a-4791-b5c7-9ba1c8b10de6"), false, "ru-RU", null, "//meta[@itemprop='dateModified']/@content", new Guid("75b4334a-b28d-408a-a5fe-38f22d6ddc9b") },
                    { new Guid("b7ab0434-cd8f-43cd-a77e-146f95638775"), false, "ru-RU", "UTC", "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark_update')]//span[@ca-ts]/text()", new Guid("7bed5daf-f215-43a7-b5a5-d7415990edb1") },
                    { new Guid("b84c235e-a043-43f3-b0d3-021d80915af6"), false, "ru-RU", null, "//meta[@property='article:modified_time']/@content", new Guid("c7f81de1-20cd-4e2a-b2d4-430a306acf51") },
                    { new Guid("c98796a8-726e-411d-bb39-89928d55333f"), false, "ru-RU", "Russian Standard Time", "//meta[@property='article:modified_time']/@content", new Guid("75076198-ce23-40d8-95a0-23991ed6e3e5") },
                    { new Guid("ca566459-b062-457b-8671-ac84f978038c"), false, "ru-RU", "Russian Standard Time", "//meta[@itemprop='dateModified']/@content", new Guid("7f032ab4-4968-414a-9e61-02f32b4cd50b") },
                    { new Guid("e4581f29-23c0-420a-8684-49c244cd496b"), false, "ru-RU", null, "//meta[@itemprop='dateModified']/@content", new Guid("2d66b024-5877-485b-8999-bd58ca67096f") },
                    { new Guid("e7093f76-d7ca-43c6-a4de-2b6f9e1cb8e6"), false, "ru-RU", "Russian Standard Time", "//meta[@property='article:modified_time']/@content", new Guid("62978095-e4c3-4f20-a5fc-04b2da4fc359") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_picture_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("00dbbb18-90b9-47cc-98d0-3d9bdb67e452"), false, new Guid("35c0f63c-2a03-4414-bcfd-b35d3daeab29"), "//meta[@property='og:image']/@content" },
                    { new Guid("015f024c-78f3-4ea4-9907-60af65745b71"), false, new Guid("995d5406-8855-46fb-aa46-59ace5ddcf6e"), "//meta[@property='og:image']/@content" },
                    { new Guid("08722b89-5b1e-484d-969a-0a42baf575c7"), false, new Guid("7054689b-8c29-4c3e-b100-777bb5b84ac9"), "//meta[@property='og:image']/@content" },
                    { new Guid("0af774c4-bce8-45c3-a998-03550f7d8010"), false, new Guid("306cc38e-3f24-4f5e-a4bf-507f46d7c885"), "//meta[@property='og:image']/@content" },
                    { new Guid("10253883-29ff-4845-b44f-715d15080703"), false, new Guid("2d66b024-5877-485b-8999-bd58ca67096f"), "//meta[@property='og:image']/@content" },
                    { new Guid("1a2373e6-2f8b-400b-a77c-eabe5a572c9a"), false, new Guid("4b6b8db8-7417-4bd5-a58b-f64b64e78bc2"), "//meta[@property='og:image']/@content" },
                    { new Guid("1a839dc6-6328-472d-aa0a-1edcfe670165"), false, new Guid("a62509ee-9637-4d1b-8947-c9f712eaddb5"), "//meta[@property='og:image']/@content" },
                    { new Guid("207fb109-6574-4b6c-a30b-1cfe2d981bba"), false, new Guid("8b6e31eb-20a6-497a-bd8f-6e9f4f93b1de"), "//meta[@itemprop='url']/@content" },
                    { new Guid("2282c0ad-5f44-4cae-9452-8d5036f74a32"), false, new Guid("e4655368-4d2c-4502-958c-a99c0d9d1471"), "//meta[@property='og:image']/@content" },
                    { new Guid("2542bc3c-721d-43ae-839d-2ee9d67ec09f"), false, new Guid("2008019e-0565-498c-aa87-525ccff923c2"), "//meta[@property='og:image']/@content" },
                    { new Guid("27314dce-d2ef-4b68-b6c6-43a7a3f1ea87"), false, new Guid("d2c8667d-3ff9-4d72-80a9-5a4423e4c2bd"), "//meta[@property='og:image']/@content" },
                    { new Guid("3ae00f6e-be4e-4c0c-a1b3-dca395789f35"), false, new Guid("b1a4c064-a6c3-4f13-82b2-2a520a0f2ad9"), "//meta[@property='og:image']/@content" },
                    { new Guid("3ecdc4f1-b06d-4eb4-977a-dc3db6c876c7"), false, new Guid("6318fb5a-64ae-4196-8220-7cc9a5a2efdc"), "//meta[@property='og:image']/@content" },
                    { new Guid("47041b43-87a8-40a5-8afa-e51e23e38a15"), false, new Guid("2107b9c3-4d7d-4944-ac87-c764eb2d8d60"), "//meta[@property='og:image']/@content" },
                    { new Guid("48ed6679-211c-48f0-90cb-3d4daa8337a5"), false, new Guid("c5ab1cb6-5085-4fef-9229-9118e5948251"), "//meta[@property='og:image']/@content" },
                    { new Guid("48fd456f-0733-40fa-abae-11f68de1ca3f"), false, new Guid("3196c477-1ac2-48d5-807d-b3d0973e8d1d"), "//meta[@property='og:image']/@content" },
                    { new Guid("4fb6fb9f-4f3c-4b8a-99f3-ed06c7ab6c42"), false, new Guid("f0629df9-ac23-4b35-9009-3eb3df7069c9"), "//meta[@property='og:image']/@content" },
                    { new Guid("55903753-5bc9-4410-a9ec-6eedacc28672"), false, new Guid("42afad4c-6ae3-40ea-b5f6-cf16b62e0850"), "//meta[@property='og:image']/@content" },
                    { new Guid("563f8121-d458-491b-b5a4-3c4a5af23e53"), false, new Guid("ac578b21-3c65-4ec9-b9fb-009aebe5bcc7"), "//meta[@property='og:image']/@content" },
                    { new Guid("67e2af1f-ba12-4898-b980-283d75958877"), false, new Guid("6ecfaab6-6a48-4d8e-95a2-87788c567cb3"), "//meta[@property='og:image']/@content" },
                    { new Guid("724122b1-aaed-450c-909a-5f4c197847b6"), false, new Guid("7f032ab4-4968-414a-9e61-02f32b4cd50b"), "//meta[@property='og:image']/@content" },
                    { new Guid("791a6c5a-d40a-4f63-b7dd-383c99f2e684"), false, new Guid("ef2cbff3-870a-45f3-95dd-fe20f7cea27d"), "//meta[@property='og:image']/@content" },
                    { new Guid("8072cd23-608c-492d-a69d-6fba5e373e5a"), false, new Guid("81713e54-2a73-4102-85ce-9b766f3e13ff"), "//meta[@property='og:image']/@content" },
                    { new Guid("81cd74a2-0ef0-4c64-bfd9-47b9f292de2b"), false, new Guid("87c7fe8e-f736-4faa-a29a-1b331445b876"), "//meta[@property='og:image']/@content" },
                    { new Guid("8e7bb8df-02e7-4f3d-8141-ed604eab24ff"), false, new Guid("a1f604b3-5c28-4f24-bcf3-c1bc15bc6cad"), "//meta[@property='og:image']/@content" },
                    { new Guid("9182b1e0-d2a4-4576-b182-7b5006d5e262"), false, new Guid("156719cd-f144-4bd4-9b16-98ae0b5cc3ab"), "//meta[@property='og:image']/@content" },
                    { new Guid("91aec896-0501-4007-a9ba-40943fa9dd2f"), false, new Guid("ec76a389-1ee4-41ed-8a9a-2d2491451918"), "//meta[@property='og:image']/@content" },
                    { new Guid("936b621c-7c7e-4654-bd6a-f2b4cf7c8db1"), false, new Guid("59d85dc4-4116-4785-8dbd-3bb18a472330"), "//meta[@property='og:image']/@content" },
                    { new Guid("93a5f04b-0539-43fe-b642-4e16a5fcc2f0"), false, new Guid("6ce32b95-fa84-41ea-9bea-dbb808394cc1"), "//meta[@property='og:image']/@content" },
                    { new Guid("93e026bb-127d-4c66-816c-9cd6e98f1b08"), false, new Guid("75076198-ce23-40d8-95a0-23991ed6e3e5"), "//meta[@property='og:image']/@content" },
                    { new Guid("94fe632c-34fb-4929-9793-f478ad361a27"), false, new Guid("e08416a9-e75f-4514-bc80-bd081a71f202"), "//meta[@property='og:image']/@content" },
                    { new Guid("954eb341-508f-4bb1-ab50-72bdb9285969"), false, new Guid("a2f84687-7724-4640-be47-79ffb765d81f"), "//meta[@name='og:image']/@content" },
                    { new Guid("96e7a15d-5a1d-452e-b865-38f4aeac4a36"), false, new Guid("03b00068-703d-4914-8aac-417321efa4a9"), "//meta[@property='og:image']/@content" },
                    { new Guid("9a18eb38-d15f-4f2c-b122-1df7ad05187e"), false, new Guid("679f0b16-d471-403d-a539-2095de1336a3"), "//meta[@property='og:image']/@content" },
                    { new Guid("a2f7ffa7-f231-4eb2-b09e-5a024bf29ccc"), false, new Guid("2e3f695a-3da6-4548-b327-f8e7ab704eb1"), "//meta[@property='og:image']/@content" },
                    { new Guid("a82a9b78-9d42-4100-95bb-78a2c8ddae42"), false, new Guid("b49ca6f0-c0f3-4791-aca2-5648202243d1"), "//meta[@property='og:image']/@content" },
                    { new Guid("ab0090d0-03c4-4b7d-b2f8-604c8d9c222a"), false, new Guid("f73a6421-12af-4481-acef-b880a91d643d"), "//meta[@property='og:image']/@content" },
                    { new Guid("b4a541af-b883-4ca6-8cf6-609df0550bc9"), false, new Guid("821e1e9a-2d0f-4bff-adb3-7fabe3b4b5ff"), "//meta[@property='og:image']/@content" },
                    { new Guid("b5852ef9-6302-4860-ae40-df7fa82f1707"), false, new Guid("3d33915f-3ab0-434d-b52f-138593f0d065"), "//meta[@property='og:image']/@content" },
                    { new Guid("b7d99cb6-82b7-4d83-8cf0-4278521656db"), false, new Guid("83f8b67e-fa3e-4d64-81e0-09a172db2318"), "//meta[@property='og:image']/@content" },
                    { new Guid("b930b955-49b6-40b8-adf8-d7119177650c"), false, new Guid("1619f60f-04c0-4ece-83af-eeccd5a78430"), "//meta[@property='og:image']/@content" },
                    { new Guid("bb2ac4ed-ae05-4c43-aaf1-471b6d8fef42"), false, new Guid("4dfd8e60-07e6-4c61-9faf-ef3b4d848df5"), "//meta[@property='og:image']/@content" },
                    { new Guid("c8ba7228-7844-424f-b6e7-791477c247e1"), false, new Guid("19127150-51c8-4c1f-bc51-654223610c6e"), "//meta[@property='og:image']/@content" },
                    { new Guid("c9f208d5-7b3f-41e7-9c9f-a390423851b8"), false, new Guid("0897a798-2068-4eec-a0c2-8e870f890d1a"), "//meta[@property='og:image']/@content" },
                    { new Guid("db9574d8-40bc-4188-bd49-de6a9a835d8b"), false, new Guid("55b29016-4fa6-4d26-878a-3a118bb2677d"), "//meta[@name='og:image']/@content" },
                    { new Guid("dd7f9969-a3cb-4e0c-9cfe-96b8003eca37"), false, new Guid("c7f81de1-20cd-4e2a-b2d4-430a306acf51"), "//meta[@property='og:image']/@content" },
                    { new Guid("de471fe4-bc5b-49ff-8e62-1edf9710faa0"), false, new Guid("c2dd81db-dd40-4716-b221-55a7e0b24190"), "//meta[@property='og:image']/@content" },
                    { new Guid("e42d36e7-3b9e-4aab-8381-007bcf09c2e4"), false, new Guid("62978095-e4c3-4f20-a5fc-04b2da4fc359"), "//meta[@property='og:image']/@content" },
                    { new Guid("e8069056-ed17-4d44-a606-56b4eaeed856"), false, new Guid("7bed5daf-f215-43a7-b5a5-d7415990edb1"), "//meta[@property='og:image']/@content" },
                    { new Guid("ea45d26d-d7e2-438a-bc57-7738deeb6e99"), false, new Guid("70d810d5-c12c-4a38-a868-8a06ecf3d658"), "//meta[@property='og:image']/@content" },
                    { new Guid("f20f6932-5a84-4d1b-aaf6-bca803837142"), false, new Guid("75b4334a-b28d-408a-a5fe-38f22d6ddc9b"), "//meta[@property='og:image']/@content" },
                    { new Guid("fd7938ce-5d9e-4eba-a62f-5451b3ecf064"), false, new Guid("8e37382a-44cc-44f0-9690-45aa7c60744d"), "//meta[@property='og:image']/@content" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "published_at_culture_info", "published_at_time_zone_info_id", "published_at_x_path" },
                values: new object[,]
                {
                    { new Guid("00c39d15-2b12-47f0-9238-e503e1411bae"), true, new Guid("e4655368-4d2c-4502-958c-a99c0d9d1471"), "ru-RU", "Russian Standard Time", "//div[@class='b-text__date']/text()" },
                    { new Guid("036ce8ce-91dc-496c-b246-b5f8fe2ac010"), true, new Guid("2d66b024-5877-485b-8999-bd58ca67096f"), "ru-RU", null, "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("08956c99-de4f-4063-8b14-ec28d5c05689"), true, new Guid("3196c477-1ac2-48d5-807d-b3d0973e8d1d"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("0a907e64-f1e1-49cf-adf4-3f408264ae3b"), true, new Guid("8e37382a-44cc-44f0-9690-45aa7c60744d"), "ru-RU", "Russian Standard Time", "//span[@class='date']/time/@datetime" },
                    { new Guid("0f3ba400-1c4c-46be-8192-3d10a780bdd2"), true, new Guid("ef2cbff3-870a-45f3-95dd-fe20f7cea27d"), "ru-RU", null, "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("28dadf9f-2b01-4d24-83f7-5950a1a0bbc2"), true, new Guid("ac578b21-3c65-4ec9-b9fb-009aebe5bcc7"), "ru-RU", "Russian Standard Time", "//meta[@property='article:published_time']/@content" },
                    { new Guid("31d25177-f169-4423-8f37-5e67ab392671"), true, new Guid("e08416a9-e75f-4514-bc80-bd081a71f202"), "ru-RU", "Russian Standard Time", "//div[@class='b-article__top-author']/p[@class='date']/text()" },
                    { new Guid("3b0f64b3-2af6-48bd-b659-d95867125380"), true, new Guid("156719cd-f144-4bd4-9b16-98ae0b5cc3ab"), "ru-RU", "Russian Standard Time", "//div[@class='article_top']//div[@class='date']//time/text()" },
                    { new Guid("3b84a86f-f28e-42dc-938d-46c42373c994"), true, new Guid("3d33915f-3ab0-434d-b52f-138593f0d065"), "en-US", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("3bad97bd-fe72-4ae9-b25b-00c4f9e9e2f2"), true, new Guid("c5ab1cb6-5085-4fef-9229-9118e5948251"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("3efdbd25-0857-420a-aae0-7079565da46e"), true, new Guid("4dfd8e60-07e6-4c61-9faf-ef3b4d848df5"), "ru-RU", "Russian Standard Time", "//meta[@property='article:published_time']/@content" },
                    { new Guid("410def57-98a1-409e-a907-c708a4ae4b5f"), true, new Guid("2107b9c3-4d7d-4944-ac87-c764eb2d8d60"), "ru-RU", null, "//div[@class='publication-info']/time[@itemprop='datePublished']/@datetime" },
                    { new Guid("4b575a7e-893e-42bb-ad20-9e7a85fddd5c"), true, new Guid("2008019e-0565-498c-aa87-525ccff923c2"), "ru-RU", "Russian Standard Time", "//meta[@property='article:published_time']/@content" },
                    { new Guid("5440552f-31e3-42e8-94ee-08c708bdb8aa"), true, new Guid("a1f604b3-5c28-4f24-bcf3-c1bc15bc6cad"), "ru-RU", "Russian Standard Time", "//p[@class='b-material__date']/text()" },
                    { new Guid("5b044c02-2396-4fb2-a495-7318a166ef3e"), true, new Guid("75076198-ce23-40d8-95a0-23991ed6e3e5"), "ru-RU", "Russian Standard Time", "//meta[@property='article:published_time']/@content" },
                    { new Guid("5e1c0c7e-ccb4-40e7-bb34-769b39b280c3"), true, new Guid("75b4334a-b28d-408a-a5fe-38f22d6ddc9b"), "ru-RU", null, "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("60bb0674-b0fd-455a-b768-0467115bc35e"), true, new Guid("42afad4c-6ae3-40ea-b5f6-cf16b62e0850"), "en-US", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("60d07f93-6eba-4113-9d1d-2231abdf6ada"), true, new Guid("6318fb5a-64ae-4196-8220-7cc9a5a2efdc"), "ru-RU", null, "//meta[@name='mediator_published_time']/@content" },
                    { new Guid("6498ff7f-0037-4fa4-9fb2-018440a366ff"), true, new Guid("f73a6421-12af-4481-acef-b880a91d643d"), "ru-RU", "Russian Standard Time", "//div[@class='article__content']//time/text()" },
                    { new Guid("68653dc5-6b49-48b5-b21f-a8e779f22d07"), true, new Guid("a62509ee-9637-4d1b-8947-c9f712eaddb5"), "ru-RU", "Russian Standard Time", "//div[@id='content']//div[contains(@class, 'topic')]/ul[contains(@class, 'blog_more')]//li[@class='date']/text()" },
                    { new Guid("6f13ae65-cd7d-479f-bcfa-624c9a313eb2"), true, new Guid("679f0b16-d471-403d-a539-2095de1336a3"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("6fec6144-d68f-47b1-a0f3-b60db425e8a8"), true, new Guid("d2c8667d-3ff9-4d72-80a9-5a4423e4c2bd"), "ru-RU", "Russian Standard Time", "//meta[@property='article:published_time']/@content" },
                    { new Guid("71fb3d00-c4fb-4e5d-a34d-20edd62814e1"), true, new Guid("35c0f63c-2a03-4414-bcfd-b35d3daeab29"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("74d134ea-7f8a-43e8-b36f-1a0ac94c9b67"), true, new Guid("306cc38e-3f24-4f5e-a4bf-507f46d7c885"), "ru-RU", "Russian Standard Time", "//div[@class='topic-page__header']//a[contains(@class, 'topic-header__time')]/text()" },
                    { new Guid("76ec6711-ed3f-41b3-a049-982e02e2d13f"), true, new Guid("821e1e9a-2d0f-4bff-adb3-7fabe3b4b5ff"), "ru-RU", "Russian Standard Time", "//article/div[@class='header']/span/text()" },
                    { new Guid("7a81a582-bda5-4dd3-9808-347d4ac79ebe"), true, new Guid("2e3f695a-3da6-4548-b327-f8e7ab704eb1"), "ru-RU", "Russian Standard Time", "//section[contains(@class, 'news-content')]/div[@class='content-top']//p[contains(@class, 'content-top__date')]/text()" },
                    { new Guid("8066ae4e-ec44-46e1-87c5-3eafab8ac9ce"), true, new Guid("83f8b67e-fa3e-4d64-81e0-09a172db2318"), "ru-RU", "Russian Standard Time", "//span[@id='publication-date']/text()" },
                    { new Guid("817731bf-541d-44f4-a0d9-fa0953f53f8d"), true, new Guid("4b6b8db8-7417-4bd5-a58b-f64b64e78bc2"), "ru-RU", "Russian Standard Time", "//article//header//time[@class='article-head__date']/text()" },
                    { new Guid("98dea689-f48e-4a92-86dd-aba5bb1d0d8c"), true, new Guid("03b00068-703d-4914-8aac-417321efa4a9"), "ru-RU", null, "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("a0ef1a94-8774-450b-95a3-486f313a61e7"), true, new Guid("6ce32b95-fa84-41ea-9bea-dbb808394cc1"), "ru-RU", null, "//header[@class='news-item__header']//time/@content" },
                    { new Guid("a548dfa8-6b03-45fa-8741-0ccbf32e9a29"), true, new Guid("62978095-e4c3-4f20-a5fc-04b2da4fc359"), "ru-RU", "Russian Standard Time", "//meta[@property='article:published_time']/@content" },
                    { new Guid("a55e0e31-ddc9-4882-836d-180c0dc2300c"), true, new Guid("c7f81de1-20cd-4e2a-b2d4-430a306acf51"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("a9b2e069-d58b-491b-8642-712535f21b0a"), true, new Guid("7f032ab4-4968-414a-9e61-02f32b4cd50b"), "ru-RU", "Russian Standard Time", "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("ae2adba6-58bc-40f3-88d2-e19d1037c5f9"), false, new Guid("a2f84687-7724-4640-be47-79ffb765d81f"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'pubdatetime')]//div[contains(@class, 'badge-time')]//text()" },
                    { new Guid("c0fe19d7-097c-44e2-b070-432c237112b4"), true, new Guid("19127150-51c8-4c1f-bc51-654223610c6e"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("c4443a33-8877-4d5a-8b5e-09e849de2d1e"), true, new Guid("f0629df9-ac23-4b35-9009-3eb3df7069c9"), "en-US", "Central Europe Standard Time", "//article//div[@class='article-info']/div[@class='date']/text()" },
                    { new Guid("c5eb9a5f-7daf-46de-bbf9-58fb7a5b20e3"), true, new Guid("7bed5daf-f215-43a7-b5a5-d7415990edb1"), "ru-RU", "UTC", "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark')]//span[@ca-ts]/text()" },
                    { new Guid("c8dedaf7-6f6a-4cc7-960b-7cdefc34b858"), true, new Guid("c2dd81db-dd40-4716-b221-55a7e0b24190"), "ru-RU", "Russian Standard Time", "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("d1dc0013-58c6-4802-8f2c-dabbb8e44837"), true, new Guid("8b6e31eb-20a6-497a-bd8f-6e9f4f93b1de"), "ru-RU", null, "//div[@class='article__header__info-block']/time[@class='article__header__date']/@datetime" },
                    { new Guid("d7608fc9-f234-43cb-99eb-0e1af23a4234"), true, new Guid("995d5406-8855-46fb-aa46-59ace5ddcf6e"), "ru-RU", null, "//meta[@itemprop='dateModified']/@content" },
                    { new Guid("e250f18d-f22b-4953-aa0e-7ceb8bdc78ff"), true, new Guid("b49ca6f0-c0f3-4791-aca2-5648202243d1"), "ru-RU", null, "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("e5a1cc85-8191-46db-a335-3afe92a8a932"), true, new Guid("70d810d5-c12c-4a38-a868-8a06ecf3d658"), "ru-RU", null, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']/span[@itemprop='datePublished']/@content" },
                    { new Guid("e7719f59-e259-47d2-9ca1-511c784569d3"), true, new Guid("1619f60f-04c0-4ece-83af-eeccd5a78430"), "ru-RU", "Russian Standard Time", "//span[@class='submitted-by']/text()" },
                    { new Guid("e8fbb165-3c3d-416e-9cf0-85fbe4eba3cb"), true, new Guid("6ecfaab6-6a48-4d8e-95a2-87788c567cb3"), "ru-RU", "Russian Standard Time", "//meta[@property='article:published_time']/@content" },
                    { new Guid("effa7797-dae3-491c-82f0-709d64d8b3e3"), true, new Guid("0897a798-2068-4eec-a0c2-8e870f890d1a"), "ru-RU", "Russian Standard Time", "//div[@class='newsDetail-body__item-subHeader']/time/text()" },
                    { new Guid("f196df36-c2a1-4b5b-91c9-b12f34a322d4"), true, new Guid("81713e54-2a73-4102-85ce-9b766f3e13ff"), "ru-RU", "UTC", "//div[@class='GeneralMaterial-module-materialHeader']//div[contains(@class, 'MetaItem-module_datetime')]/time/text()" },
                    { new Guid("f254696e-b48d-4da9-a4dc-196e417b5685"), true, new Guid("7054689b-8c29-4c3e-b100-777bb5b84ac9"), "ru-RU", "Russian Standard Time", "//div[@class='article-details']/span[@class='article-details__time']/time/@datetime" },
                    { new Guid("fa772037-e197-45e7-a588-1b6c027a5118"), true, new Guid("ec76a389-1ee4-41ed-8a9a-2d2491451918"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("fb6ad2c2-0aa5-4f65-b69e-ffdd51d7c7dc"), true, new Guid("b1a4c064-a6c3-4f13-82b2-2a520a0f2ad9"), "ru-RU", null, "//meta[@property='article:published_time']/@content" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_sub_title_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("12152fe1-0f6d-4777-b65d-72cecbcb39a8"), false, new Guid("55b29016-4fa6-4d26-878a-3a118bb2677d"), "//div[contains(@class, 'styled__StoryBody')]/p[contains(@class, 'styled__StoryParagraph') and position()=1]/text()" },
                    { new Guid("13d0b635-8c96-4827-8f5b-40d7f3dc424f"), false, new Guid("c7f81de1-20cd-4e2a-b2d4-430a306acf51"), "//meta[@name='description']/@content" },
                    { new Guid("1471ec3b-20ff-4c9e-be70-07fe8d55e52b"), false, new Guid("f0629df9-ac23-4b35-9009-3eb3df7069c9"), "//meta[@property='og:description']/@content" },
                    { new Guid("161caf36-deae-4eb3-9325-e09dc5b897cb"), false, new Guid("b1a4c064-a6c3-4f13-82b2-2a520a0f2ad9"), "//meta[@property='og:description']/@content" },
                    { new Guid("171b345e-fb25-4551-85fc-e9c732d4845f"), false, new Guid("2008019e-0565-498c-aa87-525ccff923c2"), "//meta[@property='og:description']/@content" },
                    { new Guid("1e633402-cfd2-45a5-b75c-1e8b912e385d"), false, new Guid("7054689b-8c29-4c3e-b100-777bb5b84ac9"), "//meta[@name='description']/@content" },
                    { new Guid("254962cd-84e8-41fd-8351-461d0bad2b0f"), false, new Guid("1619f60f-04c0-4ece-83af-eeccd5a78430"), "//meta[@property='og:description']/@content" },
                    { new Guid("2761242a-6ccf-4ce3-b204-b0c971174aa5"), false, new Guid("3196c477-1ac2-48d5-807d-b3d0973e8d1d"), "//meta[@property='og:description']/@content" },
                    { new Guid("29ac3427-7be4-4baf-9370-99403850a3be"), false, new Guid("995d5406-8855-46fb-aa46-59ace5ddcf6e"), "//meta[@property='og:description']/@content" },
                    { new Guid("2f6d4f65-b2ae-45d1-93a2-9e96fe4323f7"), false, new Guid("a2f84687-7724-4640-be47-79ffb765d81f"), "//meta[@name='og:description']/@content" },
                    { new Guid("3205880d-3d18-4996-9641-db7bffe02ad9"), false, new Guid("679f0b16-d471-403d-a539-2095de1336a3"), "//meta[@property='og:description']/@content" },
                    { new Guid("3a971900-efcd-4742-ba32-2db06ce4db21"), false, new Guid("87c7fe8e-f736-4faa-a29a-1b331445b876"), "//meta[@property='og:description']/@content" },
                    { new Guid("3b43fc3e-58a5-451e-a932-7f9d52d4325b"), false, new Guid("4dfd8e60-07e6-4c61-9faf-ef3b4d848df5"), "//meta[@property='og:description']/@content" },
                    { new Guid("426a3712-df28-4d08-bc27-659e9a7a050b"), false, new Guid("c2dd81db-dd40-4716-b221-55a7e0b24190"), "//meta[@property='og:description']/@content" },
                    { new Guid("46ecbc71-896e-4a28-b4e0-567df6c3b3ad"), false, new Guid("e08416a9-e75f-4514-bc80-bd081a71f202"), "//meta[@property='og:description']/@content" },
                    { new Guid("49eca46c-2e1e-4249-a3e3-6199af4f854e"), false, new Guid("6318fb5a-64ae-4196-8220-7cc9a5a2efdc"), "//meta[@property='og:description']/@content" },
                    { new Guid("51cf7658-6ef4-4bd9-be5e-b63791908f71"), false, new Guid("3d33915f-3ab0-434d-b52f-138593f0d065"), "//meta[@name='description']/@content" },
                    { new Guid("55452096-2f4c-4c90-b743-9fbb3d6defb7"), false, new Guid("306cc38e-3f24-4f5e-a4bf-507f46d7c885"), "//meta[@property='og:description']/@content" },
                    { new Guid("5eea6636-bddc-4173-ae16-9bce180e33b6"), false, new Guid("c5ab1cb6-5085-4fef-9229-9118e5948251"), "//meta[@name='description']/@content" },
                    { new Guid("651303df-ecea-48ab-b5d5-229ddb378a8c"), false, new Guid("75b4334a-b28d-408a-a5fe-38f22d6ddc9b"), "//meta[@property='og:description']/@content" },
                    { new Guid("796034f0-634b-489c-be65-dd35412ea407"), false, new Guid("a62509ee-9637-4d1b-8947-c9f712eaddb5"), "//meta[@name='DESCRIPTION']/@content" },
                    { new Guid("7a4c9c14-db17-45c1-b627-a3875e8881ee"), false, new Guid("f73a6421-12af-4481-acef-b880a91d643d"), "//meta[@property='og:description']/@content" },
                    { new Guid("7b4f498e-4e27-4bdf-9e4e-fecdf7324eba"), false, new Guid("81713e54-2a73-4102-85ce-9b766f3e13ff"), "//meta[@property='og:description']/@content" },
                    { new Guid("7c63c91a-bbee-4ae5-9726-76b57b22254a"), false, new Guid("4b6b8db8-7417-4bd5-a58b-f64b64e78bc2"), "//meta[@property='og:description']/@content" },
                    { new Guid("7e60b993-4bd7-4f21-a7d4-87598603907a"), false, new Guid("ef2cbff3-870a-45f3-95dd-fe20f7cea27d"), "//meta[@property='og:description']/@content" },
                    { new Guid("8255400a-6b69-4ae1-81fe-1ad998887317"), false, new Guid("2e3f695a-3da6-4548-b327-f8e7ab704eb1"), "//meta[@property='og:description']/@content" },
                    { new Guid("832a75a5-4f06-4b0d-af02-b40e14754d37"), false, new Guid("35c0f63c-2a03-4414-bcfd-b35d3daeab29"), "//div[@class='block-page-new']/h2/text()" },
                    { new Guid("891de55c-b08c-44c3-9453-05e1d84923b9"), false, new Guid("03b00068-703d-4914-8aac-417321efa4a9"), "//meta[@property='og:description']/@content" },
                    { new Guid("93445ac2-711a-4c14-807f-63935d615bc7"), false, new Guid("156719cd-f144-4bd4-9b16-98ae0b5cc3ab"), "//meta[@property='og:description']/@content" },
                    { new Guid("95949f8e-be4b-4d6d-8609-482d4e556b02"), false, new Guid("6ecfaab6-6a48-4d8e-95a2-87788c567cb3"), "//meta[@property='og:description']/@content" },
                    { new Guid("96fdc64e-64e1-406f-818c-4591c094757c"), false, new Guid("7bed5daf-f215-43a7-b5a5-d7415990edb1"), "//meta[@property='og:description']/@content" },
                    { new Guid("9e3a0b1f-86f7-4ee7-8466-6bc0f567cf90"), false, new Guid("0897a798-2068-4eec-a0c2-8e870f890d1a"), "//meta[@property='og:description']/@content" },
                    { new Guid("a32ac871-d5db-4013-a92e-5369d311e4aa"), false, new Guid("8b6e31eb-20a6-497a-bd8f-6e9f4f93b1de"), "//meta[@property='og:description']/@content" },
                    { new Guid("b7434fc4-f3d4-460d-9236-ad4d5f140207"), false, new Guid("ac578b21-3c65-4ec9-b9fb-009aebe5bcc7"), "//meta[@property='og:description']/@content" },
                    { new Guid("b802dd62-62dd-4dc3-8653-473ad5fc9750"), false, new Guid("821e1e9a-2d0f-4bff-adb3-7fabe3b4b5ff"), "//meta[@property='og:description']/@content" },
                    { new Guid("bf73d151-be52-4a0b-8f0f-eab349fbc047"), false, new Guid("83f8b67e-fa3e-4d64-81e0-09a172db2318"), "//meta[@property='og:description']/@content" },
                    { new Guid("c058fc17-343c-4f45-85e6-3317cf0afb03"), false, new Guid("ec76a389-1ee4-41ed-8a9a-2d2491451918"), "//meta[@property='og:description']/@content" },
                    { new Guid("c1c4a31d-7b09-465a-a630-baae9ef331a0"), false, new Guid("6ce32b95-fa84-41ea-9bea-dbb808394cc1"), "//meta[@property='og:description']/@content" },
                    { new Guid("cfebb61b-223b-4ea7-bfa7-40b07a24da63"), false, new Guid("62978095-e4c3-4f20-a5fc-04b2da4fc359"), "//meta[@property='og:description']/@content" },
                    { new Guid("d0df6541-ddf2-4939-8099-1e801f9fcba5"), false, new Guid("2d66b024-5877-485b-8999-bd58ca67096f"), "//meta[@name='description']/@content" },
                    { new Guid("d2d5c2dd-8545-464a-9eac-d8844ec560c8"), false, new Guid("d2c8667d-3ff9-4d72-80a9-5a4423e4c2bd"), "//meta[@property='og:description']/@content" },
                    { new Guid("d3b49fb1-b5e7-428e-b72a-11b78ca6a1f2"), false, new Guid("8e37382a-44cc-44f0-9690-45aa7c60744d"), "//meta[@name='description']/@content" },
                    { new Guid("d77ea88b-69ba-46ad-b71c-9287c635e381"), false, new Guid("7f032ab4-4968-414a-9e61-02f32b4cd50b"), "//meta[@property='og:description']/@content" },
                    { new Guid("e0d137ab-d579-4968-afa8-09dbe36cf512"), false, new Guid("a1f604b3-5c28-4f24-bcf3-c1bc15bc6cad"), "//meta[@property='og:description']/@content" },
                    { new Guid("e2e3672e-7b15-4a17-b996-543ca5b02e7c"), false, new Guid("2107b9c3-4d7d-4944-ac87-c764eb2d8d60"), "//meta[@itemprop='description']/@content" },
                    { new Guid("e4c2dc39-2b89-4aec-8995-c3a4e6cbce8a"), false, new Guid("19127150-51c8-4c1f-bc51-654223610c6e"), "//meta[@property='og:description']/@content" },
                    { new Guid("f21e676d-cf98-48d2-8a39-9329e703aae6"), false, new Guid("e4655368-4d2c-4502-958c-a99c0d9d1471"), "//meta[@property='og:description']/@content" },
                    { new Guid("f9043bd0-9290-49a5-90ca-eb5221907313"), false, new Guid("b49ca6f0-c0f3-4791-aca2-5648202243d1"), "//p[contains(@itemprop, 'alternativeHeadline')]/text()" },
                    { new Guid("fa81eb1f-4778-4416-900c-12bb89258aba"), false, new Guid("70d810d5-c12c-4a38-a868-8a06ecf3d658"), "//meta[@property='og:description']/@content" },
                    { new Guid("fdc669ea-3e8d-49e6-8c24-0b57640e3f4f"), false, new Guid("42afad4c-6ae3-40ea-b5f6-cf16b62e0850"), "//meta[@property='og:description']/@content" },
                    { new Guid("feb51de4-05b9-4b75-b9cb-151af9bd40a5"), false, new Guid("75076198-ce23-40d8-95a0-23991ed6e3e5"), "//meta[@property='og:description']/@content" },
                    { new Guid("ffc6c159-8330-4787-9f42-cf21fe084d61"), false, new Guid("59d85dc4-4116-4785-8dbd-3bb18a472330"), "//meta[@property='og:description']/@content" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_video_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("19d8dcd2-06da-48c4-b0b5-75a812485255"), false, new Guid("d2c8667d-3ff9-4d72-80a9-5a4423e4c2bd"), "//meta[@property='og:video']/@content" },
                    { new Guid("1faa244b-1935-42f9-a392-304975689d6f"), false, new Guid("f0629df9-ac23-4b35-9009-3eb3df7069c9"), "//article//div[@class='videoWrapper' and @itemprop='video']/iframe[@class='video']/@src" },
                    { new Guid("215183bd-fd08-49d5-b4f1-05946c719913"), false, new Guid("a1f604b3-5c28-4f24-bcf3-c1bc15bc6cad"), "//meta[@property='og:video:url']/@content" },
                    { new Guid("6a3de5ec-d655-4056-96f0-d97019bcb884"), false, new Guid("306cc38e-3f24-4f5e-a4bf-507f46d7c885"), "//div[contains(@class, 'eagleplayer')]//video/@src" },
                    { new Guid("755a5d19-f3e3-435f-bb7f-002e16dafaf8"), false, new Guid("679f0b16-d471-403d-a539-2095de1336a3"), "//meta[@property='og:video']/@content" },
                    { new Guid("bdbc4c23-a75f-427e-95e5-52931bb4302c"), false, new Guid("ac578b21-3c65-4ec9-b9fb-009aebe5bcc7"), "//div[contains(@class, 'PageContentCommonStyling_text')]/rg-video//video/@src" },
                    { new Guid("dc6b94d1-f888-4863-abfe-b7ce3ac69111"), false, new Guid("6ecfaab6-6a48-4d8e-95a2-87788c567cb3"), "//div[@class='article__header']//div[@class='media__video']//video/@src" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_modified_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_modified_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("0c9953ac-ba6a-485a-bf14-515da043de89"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("29c93386-2dcd-431f-a8c0-aaba98c67aa6") },
                    { new Guid("128b3167-2d3c-4f98-b7cf-afd89233c5be"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("3bf6bd76-896c-488d-bdeb-7dfffc88b98f") },
                    { new Guid("16e214c6-01aa-400f-b035-4d360a16fdf4"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("5c6e6321-a8bc-47bf-bdaf-e7306d1b7e0a") },
                    { new Guid("2086138b-fe09-406d-84de-0c4642a8c1d7"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("4ea1a7db-bdb4-4949-a906-1638536a5ebe") },
                    { new Guid("3abc328f-8ddc-4732-97b0-6f4a1a39b5eb"), "yyyy-MM-ddTHH:mm:ss", new Guid("175c664b-f971-4fc8-8b47-8fbb14e24771") },
                    { new Guid("40fd6030-dccf-4c1a-b691-c7bb8ca666d5"), "yyyy-MM-ddTHH:mm:ss.fff\"Z+0300\"", new Guid("c98796a8-726e-411d-bb39-89928d55333f") },
                    { new Guid("42c31ac5-1aec-401d-bee4-0d4983cb663e"), "yyyy-MM-dd HH:mm:ss", new Guid("e7093f76-d7ca-43c6-a4de-2b6f9e1cb8e6") },
                    { new Guid("4cea069b-9d79-4dc7-b779-986b3adb5006"), "\"обновлено\" d MMMM, HH:mm", new Guid("b7ab0434-cd8f-43cd-a77e-146f95638775") },
                    { new Guid("5355e19f-afcb-4beb-870a-5ec542bede7b"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("51d3b0fc-ddd4-4ef8-9974-fa31685f6c3e") },
                    { new Guid("5e1d19ee-b379-4123-864c-a80d6e7176ee"), "yyyy-MM-ddTHH:mm:ss.fffZ", new Guid("22389535-4e80-4b57-b911-3387cf9527cd") },
                    { new Guid("605f8325-babc-4dcf-9aac-d9c4a1702f68"), "yyyy-MM-dd", new Guid("ca566459-b062-457b-8671-ac84f978038c") },
                    { new Guid("63ad15f5-708d-4045-b742-44f0e03f3f8d"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("1ca60f0d-729e-4018-a223-66032a638edc") },
                    { new Guid("67f11a87-dca5-4715-9792-944c0d778d9c"), "yyyy-MM-ddTHH:mm:ss\"+0300\"", new Guid("a955bb87-eb9d-4ab1-ac35-96896f12090f") },
                    { new Guid("75a09ba0-3933-4260-8542-43cd472e73ec"), "yyyy-MM-ddTHH:mm:ss", new Guid("a3e0bda5-75b2-43bc-a2cb-ab856acd16a0") },
                    { new Guid("844f2d49-287d-4155-89fe-5d57aa4e8aaf"), "yyyy-MM-ddTHH:mm:ss\"+0300\"", new Guid("00ab0ecc-8e73-49ad-92ca-cfbcab2ed1d3") },
                    { new Guid("8ab0a8f2-22d5-492c-b65b-3f008721a1ae"), "\"обновлено\" d MMMM yyyy, HH:mm", new Guid("b7ab0434-cd8f-43cd-a77e-146f95638775") },
                    { new Guid("8e86d083-4dae-4f5b-b208-f5367730c730"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("08ae81a0-cb14-49c5-b77a-42e1162fb2ab") },
                    { new Guid("a5947322-35a8-49d3-83b7-0d558a3df8cf"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("b84c235e-a043-43f3-b0d3-021d80915af6") },
                    { new Guid("b9c0d1f2-e9e6-4944-8f2b-de7261abe66c"), "yyyyMMddTHHmm", new Guid("6771b8c6-2418-432d-bcc6-1083035eb7c0") },
                    { new Guid("c5c65b57-a95d-4a7e-a6ef-d40fe30de456"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("e4581f29-23c0-420a-8684-49c244cd496b") },
                    { new Guid("cfb9e03b-a3df-400f-881e-c741a700116a"), "yyyy-MM-dd HH:mm", new Guid("47966008-c06f-4450-9745-415b555de576") },
                    { new Guid("d25f54f2-8e05-474c-a1fd-0424d31175bb"), "yyyy-MM-ddTHH:mm:ss.fffZ", new Guid("468a5a57-c577-4eee-bc5a-ab7a67071032") },
                    { new Guid("d4164464-a61a-443f-a9fc-b56eb6dfe845"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("b2bb22cf-f26a-4791-b5c7-9ba1c8b10de6") },
                    { new Guid("f37d1ba9-558b-4f4a-8fae-16fb66a213a5"), "yyyyMMddTHHmm", new Guid("a08b6951-4b09-4142-a6fc-52f930169424") },
                    { new Guid("f96d5d63-0c97-42a3-bb4b-f435703c3f2d"), "yyyy-MM-ddTHH:mmzzz", new Guid("1c96ff0d-45fa-4254-822d-9f127848003a") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_published_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("02183dc1-b287-47c6-9741-aac4b0ace789"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("5e1c0c7e-ccb4-40e7-bb34-769b39b280c3") },
                    { new Guid("077909d6-752a-46b1-a8cb-1efbff64a737"), "HH:mm, d MMMM yyyy", new Guid("f196df36-c2a1-4b5b-91c9-b12f34a322d4") },
                    { new Guid("1138ea17-064e-4f2a-bc68-13ef4cb7db0c"), "yyyyMMddTHHmm", new Guid("e8fbb165-3c3d-416e-9cf0-85fbe4eba3cb") },
                    { new Guid("13d69f63-5968-438e-be32-3c33fb0492dd"), "dd.MM.yyyy HH:mm", new Guid("8066ae4e-ec44-46e1-87c5-3eafab8ac9ce") },
                    { new Guid("1da40864-254d-434e-8a63-d2c69354d73f"), "d MMMM yyyy, HH:mm\" •\"", new Guid("76ec6711-ed3f-41b3-a049-982e02e2d13f") },
                    { new Guid("1f4ac4b0-1baf-4382-b849-d05350bb88b9"), "dd.MM.yyyy HH:mm", new Guid("3b0f64b3-2af6-48bd-b659-d95867125380") },
                    { new Guid("207a992b-1388-4893-bed4-32a9793eecd6"), "yyyy-MM-ddTHH:mm:ss.fffZ", new Guid("3b84a86f-f28e-42dc-938d-46c42373c994") },
                    { new Guid("23de5f91-86c6-4366-8fec-8306df534aa7"), "yyyy-MM-dd", new Guid("a9b2e069-d58b-491b-8642-712535f21b0a") },
                    { new Guid("2e4d9f8f-6425-4cd2-bba4-de463177fa03"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("fa772037-e197-45e7-a588-1b6c027a5118") },
                    { new Guid("3199a8ac-f0a3-444f-b6be-3f31bf3511d9"), "yyyy-MM-ddTHH:mm:ss.fffZ", new Guid("08956c99-de4f-4063-8b14-ec28d5c05689") },
                    { new Guid("38e40727-9a73-4742-9bf2-38f3445ce05f"), "yyyy-MM-ddTHH:mm:ss\"+0300\"", new Guid("6fec6144-d68f-47b1-a0f3-b60db425e8a8") },
                    { new Guid("3a08115a-4af3-4412-8f91-d8b4142c1d2c"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("fb6ad2c2-0aa5-4f65-b69e-ffdd51d7c7dc") },
                    { new Guid("3a8d1b7c-4b3e-4168-b29d-c8720421f94a"), "d MMMM yyyy, HH:mm \"МСК\"", new Guid("817731bf-541d-44f4-a0d9-fa0953f53f8d") },
                    { new Guid("462d0156-ff8e-4185-ba27-86d0186ad825"), "dd MMMM, HH:mm", new Guid("5440552f-31e3-42e8-94ee-08c708bdb8aa") },
                    { new Guid("48516c16-9775-49c8-9461-272c51c35863"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("a0ef1a94-8774-450b-95a3-486f313a61e7") },
                    { new Guid("4c42e04b-2fa1-4f63-8b49-61e526db8e5c"), "yyyy-MM-dd HH:mm:ss", new Guid("a548dfa8-6b03-45fa-8741-0ccbf32e9a29") },
                    { new Guid("52ffb0c6-c37e-4aa7-bcca-08b6564ef66b"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("036ce8ce-91dc-496c-b246-b5f8fe2ac010") },
                    { new Guid("54eb5f88-307f-4ff2-a5c3-d84a5f441549"), "d MMMM yyyy, HH:mm", new Guid("c5eb9a5f-7daf-46de-bbf9-58fb7a5b20e3") },
                    { new Guid("66262ae4-7578-4f31-983a-c05950c3d865"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("3bad97bd-fe72-4ae9-b25b-00c4f9e9e2f2") },
                    { new Guid("6b70a4bc-3a9c-4205-80ce-de7ebb394c69"), "dd.MM.yyyy \"-\" HH:mm", new Guid("e7719f59-e259-47d2-9ca1-511c784569d3") },
                    { new Guid("6c9db819-7052-4a09-8181-caf48791038e"), "yyyy-MM-ddTHH:mm:ss.fffZ", new Guid("60bb0674-b0fd-455a-b768-0467115bc35e") },
                    { new Guid("6d48ea45-da2a-4446-b762-d9a0c4bc8f4a"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("e5a1cc85-8191-46db-a335-3afe92a8a932") },
                    { new Guid("74528ab2-d627-40b7-a406-ac534dff190e"), "HH:mm", new Guid("5440552f-31e3-42e8-94ee-08c708bdb8aa") },
                    { new Guid("78d85e33-861a-452f-a801-53f9ea8bc250"), "yyyy-MM-ddTHH:mm:ss.fff\"Z+0300\"", new Guid("5b044c02-2396-4fb2-a495-7318a166ef3e") },
                    { new Guid("7c70b09b-dd52-4466-9114-f19982383168"), "d MMMM yyyy, HH:mm", new Guid("effa7797-dae3-491c-82f0-709d64d8b3e3") },
                    { new Guid("7f629464-d786-45cf-9afa-c46bbfbc1235"), "d MMMM yyyy HH:mm", new Guid("00c39d15-2b12-47f0-9238-e503e1411bae") },
                    { new Guid("8f5bd338-0745-47ef-9f2e-c1707b0a416c"), "d-M-yyyy HH:mm", new Guid("c4443a33-8877-4d5a-8b5e-09e849de2d1e") },
                    { new Guid("8fe45520-b26a-4f80-8d13-392e00f02d7f"), "HH:mm, d MMMM yyyy", new Guid("74d134ea-7f8a-43e8-b36f-1a0ac94c9b67") },
                    { new Guid("90a57e45-b29d-4c1a-a764-dea6c1207291"), "dd MMMM yyyy, HH:mm", new Guid("68653dc5-6b49-48b5-b21f-a8e779f22d07") },
                    { new Guid("97bcd548-f295-4eb1-b83c-1b5ac51b6fb4"), "yyyyMMddTHHmm", new Guid("3efdbd25-0857-420a-aae0-7079565da46e") },
                    { new Guid("99818992-3d72-4aec-9101-5bda8e3d52f9"), "dd MMMM HH:mm", new Guid("6498ff7f-0037-4fa4-9fb2-018440a366ff") },
                    { new Guid("9df0db48-9846-4288-b7f1-5282d99ee7af"), "dd MMMM yyyy, HH:mm", new Guid("5440552f-31e3-42e8-94ee-08c708bdb8aa") },
                    { new Guid("a2c2ca8d-52ee-4618-bc8c-5ee39679a53a"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("98dea689-f48e-4a92-86dd-aba5bb1d0d8c") },
                    { new Guid("a4b75f8b-6689-4401-811e-b57d3be04e1b"), "yyyy-MM-dd HH:mm:ss", new Guid("ae2adba6-58bc-40f3-88d2-e19d1037c5f9") },
                    { new Guid("a67fedc5-39af-4886-b571-6d932bdd498f"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("0f3ba400-1c4c-46be-8192-3d10a780bdd2") },
                    { new Guid("a9a16bdf-bde4-4fb8-9d82-bca5e3fcca50"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("d7608fc9-f234-43cb-99eb-0e1af23a4234") },
                    { new Guid("b0ad4149-5a16-4eeb-b4f5-c345bd57c2f1"), "d MMMM yyyy \"в\" HH:mm", new Guid("31d25177-f169-4423-8f37-5e67ab392671") },
                    { new Guid("b195c715-1bee-4ba9-94b1-183492bf680b"), "d MMMM, HH:mm,", new Guid("c5eb9a5f-7daf-46de-bbf9-58fb7a5b20e3") },
                    { new Guid("b426122d-06c0-4bcb-a038-cdbad3ea906f"), "d MMMM yyyy, HH:mm,", new Guid("c5eb9a5f-7daf-46de-bbf9-58fb7a5b20e3") },
                    { new Guid("bf4ca838-d9eb-43ab-9d3f-41dee178d6bb"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("e250f18d-f22b-4953-aa0e-7ceb8bdc78ff") },
                    { new Guid("c083d27a-dd5c-4a51-94f1-d1692f78ce67"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("d1dc0013-58c6-4802-8f2c-dabbb8e44837") },
                    { new Guid("c102501e-0aee-43d5-b7a7-2b1e159e1a98"), "yyyy-MM-ddTHH:mmzzz", new Guid("6f13ae65-cd7d-479f-bcfa-624c9a313eb2") },
                    { new Guid("c271734d-3b28-4bc7-880d-5c0964af0f56"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("c0fe19d7-097c-44e2-b070-432c237112b4") },
                    { new Guid("c369fe63-512d-4753-bb45-011ddc57c550"), "d MMMM  HH:mm", new Guid("00c39d15-2b12-47f0-9238-e503e1411bae") },
                    { new Guid("ce768bc1-c2ef-4a94-b5a8-2a75fa4fee1d"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("a55e0e31-ddc9-4882-836d-180c0dc2300c") },
                    { new Guid("d2fe920e-ddb5-45f3-855a-ea357b7899a7"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("71fb3d00-c4fb-4e5d-a34d-20edd62814e1") },
                    { new Guid("d4744636-053f-4025-b4ff-d4c56838baa0"), "dd MMMM yyyy HH:mm", new Guid("6498ff7f-0037-4fa4-9fb2-018440a366ff") },
                    { new Guid("dbc7ca9d-0e99-41c8-96c8-fef1b384dece"), "d MMMM, HH:mm", new Guid("c5eb9a5f-7daf-46de-bbf9-58fb7a5b20e3") },
                    { new Guid("e1149412-7012-465c-98ff-e265754156b1"), "dd.MM.yyyy, HH:mm", new Guid("7a81a582-bda5-4dd3-9808-347d4ac79ebe") },
                    { new Guid("e4b5447e-883f-4d17-ae15-da9a6fb0b095"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("60d07f93-6eba-4113-9d1d-2231abdf6ada") },
                    { new Guid("eaee9d8d-9f89-455c-ae9e-8762107fb6d1"), "yyyy-MM-ddTHH:mm:ss\"+0300\"", new Guid("4b575a7e-893e-42bb-ad20-9e7a85fddd5c") },
                    { new Guid("eb05e608-adf6-4eae-9d54-89529895d1cb"), "yyyy-MM-ddTHH:mm:ss", new Guid("28dadf9f-2b01-4d24-83f7-5950a1a0bbc2") },
                    { new Guid("f1bb3786-9964-410a-8e88-31e34c322990"), "d MMMM yyyy", new Guid("f254696e-b48d-4da9-a4dc-196e417b5685") },
                    { new Guid("f87c0ac9-c3a9-4e4c-bc94-663b7fd5867f"), "yyyy-MM-dd HH:mm", new Guid("0a907e64-f1e1-49cf-adf4-3f408264ae3b") },
                    { new Guid("fabf2552-4803-47e4-9eb0-f083fcd2eb6e"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("410def57-98a1-409e-a907-c708a4ae4b5f") },
                    { new Guid("ff2e0d8a-8298-4ad8-bded-bd1f4ccab111"), "yyyy-MM-ddTHH:mm:ss", new Guid("c8dedaf7-6f6a-4cc7-960b-7cdefc34b858") }
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
