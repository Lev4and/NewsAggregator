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
                    is_system = table.Column<bool>(type: "boolean", nullable: false),
                    is_enabled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_sources", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "news_tags",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_tags", x => x.id);
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
                name: "news_source_tags",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    source_id = table.Column<Guid>(type: "uuid", nullable: false),
                    tag_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_source_tags", x => x.id);
                    table.ForeignKey(
                        name: "fk_news_source_tags_news_sources_source_id",
                        column: x => x.source_id,
                        principalTable: "news_sources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_news_source_tags_news_tags_tag_id",
                        column: x => x.tag_id,
                        principalTable: "news_tags",
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
                columns: new[] { "id", "is_enabled", "is_system", "site_url", "title" },
                values: new object[,]
                {
                    { new Guid("05765a1b-b174-4ad1-9f63-3189a52303f9"), true, true, "https://www.starhit.ru/", "Сетевое издание «Онлайн журнал StarHit (СтарХит)" },
                    { new Guid("068fb7bb-4b76-4261-bc9a-274625fe8890"), true, true, "https://www.fontanka.ru/", "ФОНТАНКА.ру" },
                    { new Guid("136c7569-601c-4f16-9ca4-bd14bfa8c16a"), true, true, "https://www.nytimes.com/", "The New York Times" },
                    { new Guid("13f235b7-a6f6-4da4-83a1-13b5af26700a"), true, true, "https://www.pravda.ru/", "Правда.ру" },
                    { new Guid("170a9aef-a708-41a4-8370-a8526f2c055f"), true, true, "https://life.ru/", "Life" },
                    { new Guid("1994c4bc-aeb9-4242-81df-5bafffca6fd0"), true, true, "https://radiosputnik.ru/", "Радио Sputnik" },
                    { new Guid("296270ec-026b-4011-83ff-1466ba577864"), true, true, "https://www.kinonews.ru/", "KinoNews.ru" },
                    { new Guid("2fa2ff6a-9a8b-4a2d-b0e4-6e7e14679236"), true, true, "https://www.womanhit.ru/", "Женский журнал WomanHit.ru" },
                    { new Guid("31252741-4d0b-448f-b85c-d6538f7ca565"), true, true, "https://iz.ru/", "Известия" },
                    { new Guid("31b6f068-3f00-4250-bc74-62146525ba95"), true, true, "https://rg.ru/", "Российская газета" },
                    { new Guid("321e1615-6328-4532-85ac-22d53d59c164"), true, true, "https://74.ru/", "74.ru" },
                    { new Guid("33b14253-7c02-4b79-8490-c8ed10312230"), true, true, "https://www.5-tv.ru/", "Пятый канал" },
                    { new Guid("3a346f18-1781-408b-bc8d-2f8e4cbc64ea"), true, true, "https://meduza.io/", "Meduza" },
                    { new Guid("3b8c9766-f5d5-44ec-a014-45ddce4a9a0c"), true, true, "https://tsargrad.tv/", "Царьград" },
                    { new Guid("3e1f065a-c135-4429-941e-d870886b4147"), true, true, "https://www.sports.ru/", "Storts.ru" },
                    { new Guid("3e24ec11-86a4-4db8-9337-35a00988da7d"), true, true, "https://www.m24.ru/", "Москва 24" },
                    { new Guid("454f4f08-58cf-4ab7-9012-1e5ba663570c"), true, true, "https://www.avtovzglyad.ru/", "АвтоВзгляд" },
                    { new Guid("49bcf6b7-15bc-4f30-a3d6-3c88837aa039"), true, true, "https://www.championat.com/", "Чемпионат.com" },
                    { new Guid("57597b92-2b9d-422e-b0a7-9b11326c879b"), true, true, "https://www.interfax.ru/", "Интерфакс" },
                    { new Guid("5aebacd6-b4d5-4839-b2f0-533ff3329941"), true, true, "https://3dnews.ru/", "3Dnews.ru" },
                    { new Guid("5c3b0099-2a8a-49a5-8c68-d24ebc9fac07"), true, true, "https://edition.cnn.com/", "CNN" },
                    { new Guid("5d8e3050-5444-4709-afc3-18a8d46a71ba"), true, true, "https://russian.rt.com/", "RT на русском" },
                    { new Guid("604e9548-9b99-4bd4-ab90-4bf90b4a1807"), true, true, "https://ixbt.games/", "iXBT.games" },
                    { new Guid("60747323-2a4c-44e1-880d-7e5e36642645"), true, true, "https://regnum.ru/", "ИА REGNUM" },
                    { new Guid("65141fc2-760f-4866-86c5-08cc764cabac"), true, true, "https://smart-lab.ru/", "SMART-LAB" },
                    { new Guid("6854c858-b82d-44f5-bb48-620c9bf9825d"), true, true, "https://svpressa.ru/", "СвободнаяПресса" },
                    { new Guid("6c5fe2d4-8547-4fb0-8966-d148f8d77af7"), true, true, "https://www.ntv.ru/", "НТВ" },
                    { new Guid("70873440-0058-4669-aa74-352489f9e6da"), true, true, "https://www.1obl.ru/", "Первый областной" },
                    { new Guid("797060c0-3b47-4654-9176-32d719baad69"), true, true, "https://www.cybersport.ru/", "Cybersport.ru" },
                    { new Guid("7e889af8-0f19-44ab-96d4-241fd64fbcdb"), true, true, "https://tass.ru/", "ТАСС" },
                    { new Guid("9268835d-553d-4fbe-a0cb-0545b8019c68"), true, true, "https://aif.ru/", "Аргументы и факты" },
                    { new Guid("950d59d6-d94c-4396-a55e-cbcd2a9b533c"), true, true, "https://www.rbc.ru/", "РБК" },
                    { new Guid("9519622d-50f0-4a8d-8728-c58c12255b6f"), true, true, "https://www.khl.ru/", "КХЛ" },
                    { new Guid("9e3453b3-be81-4f3b-93da-45192677c6a9"), true, true, "https://www.finam.ru/", "Финам.Ру" },
                    { new Guid("a71c23bf-67e9-4955-bc8e-6226bd86ba90"), true, true, "https://www.zr.ru/", "Журнал \"За рулем\"" },
                    { new Guid("b2fb23b4-3f6d-440c-9ec0-99216f233fd0"), true, true, "https://rusvesna.su/", "Русская весна" },
                    { new Guid("b5594347-6ec0-44c0-b381-7ae47f04fa56"), true, true, "https://stopgame.ru/", "StopGame" },
                    { new Guid("b8d20577-6c4c-4bd7-a1b1-b58bb4914541"), true, true, "https://ria.ru/", "РИА Новости" },
                    { new Guid("b9ec9be8-e1f2-49d6-b461-b61872bb369c"), true, true, "https://travelask.ru/", "TravelAsk" },
                    { new Guid("ba078388-eedf-4ccb-af5f-3f686f4ece4a"), true, true, "https://7days.ru/", "7дней.ru" },
                    { new Guid("baaa533a-cb1a-46e7-bb9e-79d631affc87"), true, true, "https://www.kommersant.ru/", "Коммерсантъ" },
                    { new Guid("c169d8ad-a9fe-44e9-af6a-fd337ae10000"), true, true, "https://ren.tv/", "РЕН ТВ" },
                    { new Guid("c7b863af-0565-4bec-9238-9383272637ef"), true, true, "https://www.novorosinform.org/", "Новороссия" },
                    { new Guid("cb68ce1c-c741-41df-a1c9-8ce34529b421"), true, true, "https://www.kp.ru/", "Комсомольская правда" },
                    { new Guid("cc29eb91-2efb-4d57-8d14-bb5356cbfbb8"), true, true, "https://www.gazeta.ru/", "Газета.Ru" },
                    { new Guid("dac8cec6-c84d-4287-b0b9-71f4cf304c7e"), true, true, "https://overclockers.ru/", "Overclockers" },
                    { new Guid("e023416d-7d91-4d92-bd5f-37d57c54f6b4"), true, true, "https://www.ixbt.com/", "iXBT.com" },
                    { new Guid("e16286a8-78a9-4b86-ba4b-c844f7099336"), true, true, "https://ura.news/", "Ura.ru" },
                    { new Guid("e2ce0a01-9d10-4133-a989-618739aa3854"), true, true, "https://vz.ru/", "ВЗГЛЯД.РУ" },
                    { new Guid("e4b3e286-3589-49de-892b-d0d06e719115"), true, true, "https://www.hltv.org/", "HLTV.org" },
                    { new Guid("fb2f8557-ca7e-4ce2-86dd-b8a94ee02275"), true, true, "https://lenta.ru/", "Лента.Ру" },
                    { new Guid("fc0a229f-bde4-4f61-b4eb-75d1285665dd"), true, true, "http://www.belta.by/", "БелТА" }
                });

            migrationBuilder.InsertData(
                table: "news_tags",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("19db4d3d-b17a-45ff-9853-cdce9630c08f"), "Finance" },
                    { new Guid("2139e644-a9fa-49ce-8eea-7380e7936527"), "Video games" },
                    { new Guid("2e2cf727-d007-4293-8f2c-f8e54baf06ce"), "Woman" },
                    { new Guid("302d7e19-c80f-4e1a-8877-3e9b17f9baeb"), "Politics" },
                    { new Guid("34cc1d82-002a-4c8c-b783-e46d9c88dde5"), "Computer hardware" },
                    { new Guid("3afdf0a8-2504-4436-8483-2b9566b881f2"), "KHL" },
                    { new Guid("464a2260-130c-4a4b-8aa6-4f477cd1760f"), "Auto" },
                    { new Guid("47ea1951-5508-4647-a805-138a861974ff"), "Economy" },
                    { new Guid("4aaeef66-ae04-4d75-8920-72fb30031c53"), "Radio" },
                    { new Guid("4c65a245-2631-47ed-a84d-e4699e9a997c"), "Cybersport" },
                    { new Guid("529cd044-c4fe-4c50-8748-080584a48d12"), "IT" },
                    { new Guid("54d48566-0e56-4e41-a2c6-35f71d9e35fe"), "Chelyabinsk" },
                    { new Guid("5654a834-6f9a-4caa-a153-d4644204001c"), "Belarus" },
                    { new Guid("6c939d6c-0461-46c8-b9b6-83021b68df71"), "Sport" },
                    { new Guid("6fc28243-4b6e-4013-8121-0bc4d8397552"), "Saint-Petersburg" },
                    { new Guid("85e1d7f3-0150-48ac-9c29-17acec559f32"), "Movie" },
                    { new Guid("8e8ec992-5b4b-43d9-b290-73fbfcd8a32e"), "English" },
                    { new Guid("9503b07f-c97a-49e7-b177-97e3a293dc31"), "Russia" },
                    { new Guid("9f2effc4-5f9d-419a-83a9-598c41afc2b8"), "Moscow" },
                    { new Guid("aa8de58c-f61f-4b4c-ad4c-ff05245e052c"), "Hockey" },
                    { new Guid("ae20fd4f-a451-42cb-aae6-875d0bfacaa7"), "TV" },
                    { new Guid("b99b8260-8eb2-4a30-8d59-2f251a83e68c"), "Technologies" },
                    { new Guid("bcc08307-a922-4de1-aa17-8ff9dc438425"), "Show business" },
                    { new Guid("cbb60009-18c3-479b-a09a-cfe976fb5abd"), "UK" },
                    { new Guid("cfa03d74-4386-4e3f-a841-bb6498a02adc"), "Counter Strike" },
                    { new Guid("d57fa572-a720-432c-a372-b8ade1a7edff"), "Russian" },
                    { new Guid("e0a5af2c-cb45-40da-90d7-7ba59c662bcb"), "New York" },
                    { new Guid("f06891c5-6324-4bab-b836-a78a4d2c603d"), "USA" },
                    { new Guid("f74ca29a-e9bc-4111-94d7-ebe5beccd72c"), "Travel" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_settings",
                columns: new[] { "id", "html_description_x_path", "source_id", "text_description_x_path", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("052241f9-e3e7-4722-9f56-7202de4a331e"), "//article/div[@class='article-content']/*[not(@class)]", new Guid("49bcf6b7-15bc-4f30-a3d6-3c88837aa039"), "//article/div[@class='article-content']/*[not(@class)]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("11795391-d20d-48df-ab38-30f796737a43"), "//div[contains(@class, 'js-mediator-article')]/*[position()>1]", new Guid("797060c0-3b47-4654-9176-32d719baad69"), "//div[contains(@class, 'js-mediator-article')]/*[position()>1]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("14db83c2-cee9-47a2-b8fc-210bbbd399aa"), "//div[@class='article-text']/*[not(name()='div' and @class='picture-wrapper')]", new Guid("60747323-2a4c-44e1-880d-7e5e36642645"), "//div[@class='article-text']/*[not(name()='div' and @class='picture-wrapper')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("289bab5a-8dd4-4ca7-a510-ff6a496b3993"), "//div[@id='content']//div[contains(@class, 'topic')]/div[@class='content']/*", new Guid("65141fc2-760f-4866-86c5-08cc764cabac"), "//div[@id='content']//div[contains(@class, 'topic')]/div[@class='content']//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("28bff881-79f7-400c-ab5d-489176c269bb"), "//article/*", new Guid("7e889af8-0f19-44ab-96d4-241fd64fbcdb"), "//article/*//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("2d46f779-c13c-4699-9460-629e254a6444"), "//div[contains(@class, 'styled__StoryBody')]/*[not(name()='p' and contains(@class, 'styled__StoryParagraph') and position()=1) and not(name()='div' and contains(@class, 'styled__StoryImgContainer') and position()=2)]", new Guid("a71c23bf-67e9-4955-bc8e-6226bd86ba90"), "//div[contains(@class, 'styled__StoryBody')]/*[not(name()='p' and contains(@class, 'styled__StoryParagraph') and position()=1) and not(name()='div' and contains(@class, 'styled__StoryImgContainer') and position()=2)]//text()", "//meta[@name='og:title']/@content" },
                    { new Guid("2de49bdd-5c36-49ff-9a3b-a1f6ceb75e75"), "//div[@itemprop='articleBody']/*", new Guid("5c3b0099-2a8a-49a5-8c68-d24ebc9fac07"), "//div[@itemprop='articleBody']/*//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("32cad97f-b071-4e24-bdc9-10e5e58cf99b"), "//div[@class='textart']/div[not(@class)]/*", new Guid("296270ec-026b-4011-83ff-1466ba577864"), "//div[@class='textart']/div[not(@class)]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("3373c5b8-57e2-402b-9dfb-a0ae19e92336"), "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]", new Guid("170a9aef-a708-41a4-8370-a8526f2c055f"), "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("3c4ef27a-3157-4eff-a441-1e409c4b6c34"), "//section[@name='articleBody']/*", new Guid("136c7569-601c-4f16-9ca4-bd14bfa8c16a"), "//section[@name='articleBody']/*//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("44d47f91-a811-4cc3-a70f-f12236d1476d"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/*[position()>4]", new Guid("5aebacd6-b4d5-4839-b2f0-533ff3329941"), "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/*[position()>4 and not(name()='script')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("49c1bb0c-b546-4142-a7ba-4925f71a933c"), "//section[@itemprop='articleBody']/div[@class='ds-article-content-block-and-creative-container' and position()>1]", new Guid("05765a1b-b174-4ad1-9f63-3189a52303f9"), "//section[@itemprop='articleBody']/div[@class='ds-article-content-block-and-creative-container' and position()>1]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("4c29ab0b-01eb-466e-8dc3-fe05886f4332"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]", new Guid("3b8c9766-f5d5-44ec-a014-45ddce4a9a0c"), "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("52014d82-bd2b-47fb-9ba1-668df2126197"), "//div[contains(@class, 'PageContentCommonStyling_text')]/*[not(name() = 'rg-video')]", new Guid("31b6f068-3f00-4250-bc74-62146525ba95"), "//div[contains(@class, 'PageContentCommonStyling_text')]/*[not(name() = 'rg-video')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("52ac2f5a-3b95-4adc-9c2a-abd192a1ec26"), "//div[@itemprop='articleBody']/*", new Guid("b9ec9be8-e1f2-49d6-b461-b61872bb369c"), "//div[@itemprop='articleBody']//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("5726d5dd-18ac-4c5c-a5d1-f775f1dd0b20"), "//div[@id='article_body']/*", new Guid("33b14253-7c02-4b79-8490-c8ed10312230"), "//div[@id='article_body']//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("5c2d9dff-16d7-47f9-8d32-07f8fb52ac76"), "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]", new Guid("57597b92-2b9d-422e-b0a7-9b11326c879b"), "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("60a60886-4da0-4c2c-8635-a8ec57827667"), "//div[@itemprop='articleBody']/*", new Guid("cc29eb91-2efb-4d57-8d14-bb5356cbfbb8"), "//div[@itemprop='articleBody']/*//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("611bd50e-69f5-4598-8ad6-8b19771f1044"), "//div[@class='only__text']/*", new Guid("c7b863af-0565-4bec-9238-9383272637ef"), "//div[@class='only__text']/*[not(name()='script')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("613dbfcf-7f5c-4060-a92a-d2ec7586f4a3"), "//div[contains(@class, 'material-content')]/*", new Guid("dac8cec6-c84d-4287-b0b9-71f4cf304c7e"), "//div[contains(@class, 'material-content')]/p//text()", "//a[@class='header']/text()" },
                    { new Guid("68faffa0-b7e6-44bb-a958-441eb532bfbb"), "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]", new Guid("6854c858-b82d-44f5-bb48-620c9bf9825d"), "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("692ba156-95b9-4a24-9b0c-71b769e8d3a8"), "//div[@class='material-7days__paragraf-content']/*[not(name()='div' and @itemprop='image' and position()=1)]", new Guid("ba078388-eedf-4ccb-af5f-3f686f4ece4a"), "//div[@class='material-7days__paragraf-content']//p//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("6a7db6d7-c4ec-471c-93e2-9f7b9dd9180c"), "//div[@class='GeneralMaterial-module-article']/*[position()>1]", new Guid("3a346f18-1781-408b-bc8d-2f8e4cbc64ea"), "//div[@class='GeneralMaterial-module-article']/*[position()>1]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("6d16ec92-860e-4bd8-9618-1e5b2ac5a792"), "//div[contains(@class, 'finfin-local-plugin-publication-item-item-')]/*", new Guid("9e3453b3-be81-4f3b-93da-45192677c6a9"), "//div[contains(@class, 'finfin-local-plugin-publication-item-item-')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("76b3ad9b-48c5-4f9e-ab28-993ba795fdb1"), "//div[@data-gtm-el='content-body']/*[not(name()='div' and @data-wide='true')]", new Guid("cb68ce1c-c741-41df-a1c9-8ce34529b421"), "//div[@data-gtm-el='content-body']/*[not(name()='div' and @data-wide='true')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("77a6c5a1-b883-444f-ba7e-f0289943947f"), "//div[@class='js-mediator-article']", new Guid("fc0a229f-bde4-4f61-b4eb-75d1285665dd"), "//div[@class='js-mediator-article']//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("8c399ef5-9d29-4442-a621-52867b8e7f6d"), "//div[contains(@class, 'news-item__content')]", new Guid("3e1f065a-c135-4429-941e-d870886b4147"), "//div[contains(@class, 'news-item__content')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("921d7c0a-c084-4188-b243-d08580f65142"), "//div[@itemprop='articleBody']/*", new Guid("70873440-0058-4669-aa74-352489f9e6da"), "//div[@itemprop='articleBody']/*//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("929687ee-eb6f-4e95-852d-9635657d7f89"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview')) and not(contains(@class, 'article__main-image'))]", new Guid("950d59d6-d94c-4396-a55e-cbcd2a9b533c"), "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview')) and not(contains(@class, 'article__main-image'))]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("96ef6e5b-c81b-45e7-a715-1aa131d82ef2"), "//div[@itemprop='articleBody']/*[position()>2]", new Guid("e023416d-7d91-4d92-bd5f-37d57c54f6b4"), "//div[@itemprop='articleBody']/*[position()>2]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("9d11efde-ae9c-42a7-ac57-649bf5891e8a"), "//div[contains(@class, 'article__body')]", new Guid("b8d20577-6c4c-4bd7-a1b1-b58bb4914541"), "//div[contains(@class, 'article__body')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("9de1ef08-878b-4559-85af-a8b14d7ce68b"), "//div[@itemprop='articleBody']/*", new Guid("31252741-4d0b-448f-b85c-d6538f7ca565"), "//div[@itemprop='articleBody']//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("a03ca9fd-6e2d-4da5-9017-5feb6a9a1404"), "//div[@class='newsDetail-content__info']/*[not(name()='h1') and not(name()='h5')]", new Guid("9519622d-50f0-4a8d-8728-c58c12255b6f"), "//div[@class='newsDetail-content__info']/*[not(name()='h1') and not(name()='h5')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("a1b03754-30d4-4c65-946d-10995830a159"), "//article/div[@class='news_text']", new Guid("e2ce0a01-9d10-4133-a989-618739aa3854"), "//article/div[@class='news_text']//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("a39fd0cf-d695-451a-8ec5-b662eddf4e9e"), "//div[@class='topic-body__content']", new Guid("fb2f8557-ca7e-4ce2-86dd-b8a94ee02275"), "//div[@class='topic-body__content']//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("a7d88817-12e6-434a-8c25-949dde2609f4"), "//span[@itemprop='articleBody']/*", new Guid("2fa2ff6a-9a8b-4a2d-b0e4-6e7e14679236"), "//span[@itemprop='articleBody']//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("aed24362-5c8e-4b31-9bbe-bb068f9c0f01"), "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]", new Guid("13f235b7-a6f6-4da4-83a1-13b5af26700a"), "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]//text()", "//meta[@name='title']/@content" },
                    { new Guid("be3e061e-25f4-4b43-a9f6-45db165b6000"), "//section[contains(@class, '_page-section')]/div[contains(@class, '_content_')]/*", new Guid("b5594347-6ec0-44c0-b381-7ae47f04fa56"), "//section[contains(@class, '_page-section')]/div[contains(@class, '_content_')]/*[contains(@class, '_text_')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("c965a1d0-83b6-4018-a4a5-9c426a02943e"), "//div[contains(@class, 'field-type-text-long')]/*", new Guid("b2fb23b4-3f6d-440c-9ec0-99216f233fd0"), "//div[contains(@class, 'field-type-text-long')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("cba88caa-d8af-4e40-b8fa-14946187e939"), "//div[@class='widgets__item__text__inside']/*", new Guid("c169d8ad-a9fe-44e9-af6a-fd337ae10000"), "//div[@class='widgets__item__text__inside']//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("d36d75dc-add7-4e21-8a31-2f40f4033b14"), "//section[@itemprop='articleBody']/*", new Guid("068fb7bb-4b76-4261-bc9a-274625fe8890"), "//section[@itemprop='articleBody']//p//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("d477dceb-5655-432b-8bca-b2ca2d944d87"), "//div[@itemprop='articleBody']/*[not(name()='div')]", new Guid("e16286a8-78a9-4b86-ba4b-c844f7099336"), "//div[@itemprop='articleBody']/*[not(name()='div')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("da641510-f1dd-4fce-b895-cbf32dca79bf"), "//div[contains(@class, 'article__text ')]", new Guid("5d8e3050-5444-4709-afc3-18a8d46a71ba"), "//div[contains(@class, 'article__text ')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("dd419d1c-db40-4fd4-8f12-34206242d7cc"), "//div[contains(@class, 'article__body')]/*", new Guid("1994c4bc-aeb9-4242-81df-5bafffca6fd0"), "//div[contains(@class, 'article__body')]//*[not(name()='script')]/text()", "//meta[@property='og:title']/@content" },
                    { new Guid("e3fcdd00-2152-4d84-8f8c-bf70e4996990"), "//section[@itemprop='articleBody']/*", new Guid("454f4f08-58cf-4ab7-9012-1e5ba663570c"), "//section[@itemprop='articleBody']/*[not(name()='script')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("e4542056-2c68-43c6-a85c-9e4899556800"), "//div[@itemprop='articleBody']/*[not(name()='figure' and position()=1)]", new Guid("321e1615-6328-4532-85ac-22d53d59c164"), "//div[@itemprop='articleBody']/*[not(name()='figure') and not(lazyhydrate)]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("e8ea5810-3cc4-46dd-84d7-eb7b5cbf3f3b"), "//div[@class='article_text']", new Guid("9268835d-553d-4fbe-a0cb-0545b8019c68"), "//div[@class='article_text']//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("efd9bf27-abb2-46c2-bedb-dc7e745e55fb"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]", new Guid("baaa533a-cb1a-46e7-bb9e-79d631affc87"), "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("f1b027fc-2809-4eaa-9858-c49a8756852f"), "//div[contains(@class, 'container-fluid shifted') and not(p[@class='announce lead']) and not(h1) and not(hr)]", new Guid("604e9548-9b99-4bd4-ab90-4bf90b4a1807"), "//div[contains(@class, 'container-fluid shifted') and not(p[@class='announce lead']) and not(h1) and not(hr)]//text()", "//meta[@name='og:title']/@content" },
                    { new Guid("f63d1e4f-e82d-4020-8b9c-65beaab1d7c3"), "//article//div[@class='newstext-con']/*[position()>2]", new Guid("e4b3e286-3589-49de-892b-d0d06e719115"), "//article//div[@class='newstext-con']/*[position()>2]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("f6ef6598-401b-4cd8-8654-f3009b41593f"), "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]", new Guid("3e24ec11-86a4-4db8-9337-35a00988da7d"), "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]//text()", "//meta[@property='og:title']/@content" },
                    { new Guid("fa16a108-45c2-42e4-8323-b1f3ea3cdf46"), "//div[@class='news-content__body']//div[contains(@class, 'content-text')]/*", new Guid("6c5fe2d4-8547-4fb0-8966-d148f8d77af7"), "//div[@class='news-content__body']//div[contains(@class, 'content-text')]//text()", "//meta[@property='og:title']/@content" }
                });

            migrationBuilder.InsertData(
                table: "news_search_settings",
                columns: new[] { "id", "news_site_url", "news_url_x_path", "source_id" },
                values: new object[,]
                {
                    { new Guid("01116c2c-7bf6-496d-96f6-9d10d4b14e97"), "https://www.hltv.org/", "//a[contains(@href, '/news/')]/@href", new Guid("e4b3e286-3589-49de-892b-d0d06e719115") },
                    { new Guid("022c7083-ea41-4e42-b40e-a0d72dfb7956"), "https://tass.ru/", "//a[contains(@class, 'tass_pkg_link-v5WdK') and contains(substring(@href, 2), '/') and not(contains(@href, '/spec/')) and not(contains(@href, 'spec.tass.ru'))]/@href", new Guid("7e889af8-0f19-44ab-96d4-241fd64fbcdb") },
                    { new Guid("035b1374-e0cd-4b0a-a567-e0feff9852ff"), "https://www.nytimes.com/", "//a[contains(@href, '.html')]/@href", new Guid("136c7569-601c-4f16-9ca4-bd14bfa8c16a") },
                    { new Guid("04980ca4-2525-446d-ba36-b6ec342d951e"), "https://meduza.io/", "//a[not(@href='/news/') and starts-with(@href, '/news/')]/@href", new Guid("3a346f18-1781-408b-bc8d-2f8e4cbc64ea") },
                    { new Guid("0896d6d1-cbe7-4103-a47e-d9be4ad3c550"), "https://3dnews.ru/news/", "//div[@class='news-feed-all']//a[@class='entry-header']/h1/../@href", new Guid("5aebacd6-b4d5-4839-b2f0-533ff3329941") },
                    { new Guid("09a55b0c-4a3f-497c-9626-9b5b5e12ca26"), "https://www.womanhit.ru/", "//a[not(@href='/stars/news/') and starts-with(@href, '/stars/news/')]/@href", new Guid("2fa2ff6a-9a8b-4a2d-b0e4-6e7e14679236") },
                    { new Guid("0bd7b701-63de-48e9-8494-4faf1193e218"), "https://www.5-tv.ru/news/", "//a[not(@href='https://www.5-tv.ru/news/') and starts-with(@href, 'https://www.5-tv.ru/news/')]/@href", new Guid("33b14253-7c02-4b79-8490-c8ed10312230") },
                    { new Guid("0f9c275f-d418-4fea-abbf-ad3cda6d678c"), "https://www.rbc.ru/", "//a[contains(@href, 'https://www.rbc.ru/') and contains(@href, '?from=')]/@href", new Guid("950d59d6-d94c-4396-a55e-cbcd2a9b533c") },
                    { new Guid("112b8f16-4de2-4679-bed3-cf3c4ce5e1ed"), "https://radiosputnik.ru/", "//a[starts-with(@href, 'https://radiosputnik.ru/') and contains(@href, '.html')]/@href", new Guid("1994c4bc-aeb9-4242-81df-5bafffca6fd0") },
                    { new Guid("1b2f8ada-c349-4930-98ed-896d0b89093c"), "https://www.zr.ru/news/", "//a[contains(@href, '/news/') and not(starts-with(@href, '/news/')) and not(starts-with(@href, 'https://'))]/@href", new Guid("a71c23bf-67e9-4955-bc8e-6226bd86ba90") },
                    { new Guid("1dde178c-c061-428a-b0e3-1d7b7ddc5c7b"), "https://aif.ru/", "//span[contains(@class, 'item_text__title')]/../@href", new Guid("9268835d-553d-4fbe-a0cb-0545b8019c68") },
                    { new Guid("25667b44-614f-4c19-ad74-3be0c5f8c743"), "https://lenta.ru/", "//a[starts-with(@href, '/news/')]/@href", new Guid("fb2f8557-ca7e-4ce2-86dd-b8a94ee02275") },
                    { new Guid("27aa8343-30f4-40ef-a8ab-20d41e3097c4"), "https://tsargrad.tv/", "//a[contains(@class, 'news-item__link')]/@href", new Guid("3b8c9766-f5d5-44ec-a014-45ddce4a9a0c") },
                    { new Guid("285b962c-f8e9-4b05-95e9-81a0ff26cd26"), "https://www.novorosinform.org/", "//a[contains(@href, '.html')]/@href", new Guid("c7b863af-0565-4bec-9238-9383272637ef") },
                    { new Guid("3b9ca981-bc22-40e2-93be-e08c99369c45"), "https://vz.ru/", "//a[contains(@href, '.html') and not(contains(@href, '#comments')) and not(contains(@href, '?')) and not(contains(@href, '/about/'))]/@href", new Guid("e2ce0a01-9d10-4133-a989-618739aa3854") },
                    { new Guid("3dd178c2-7dd6-4f7d-9fa3-8aad161b000a"), "https://www.starhit.ru/novosti/", "//a[@class='announce-inline-tile__label-container']/@href", new Guid("05765a1b-b174-4ad1-9f63-3189a52303f9") },
                    { new Guid("4305d788-135a-4922-8cfb-7d5b8971835e"), "https://rusvesna.su/news", "//a[not(@href='/news/') and starts-with(@href, '/news/')]/@href", new Guid("b2fb23b4-3f6d-440c-9ec0-99216f233fd0") },
                    { new Guid("465f7ae0-072e-4df3-8d24-7a194b478c2a"), "https://www.kommersant.ru/", "//a[contains(@href, '/doc/') and contains(@href, '?from=')]/@href", new Guid("baaa533a-cb1a-46e7-bb9e-79d631affc87") },
                    { new Guid("4c8ceb60-a498-4b5a-b574-a84b2d890e59"), "https://iz.ru/news/", "//a[contains(@href, '?main_click')]/@href", new Guid("31252741-4d0b-448f-b85c-d6538f7ca565") },
                    { new Guid("505e7e1d-72a9-4f64-b2ab-faf55410329f"), "https://regnum.ru/news", "//a[not(@href='/news/') and starts-with(@href, '/news/')]/@href", new Guid("60747323-2a4c-44e1-880d-7e5e36642645") },
                    { new Guid("52805bca-3e28-413b-8da3-77c9411f6ae1"), "https://ixbt.games/news/", "//a[@class='card-link']/@href", new Guid("604e9548-9b99-4bd4-ab90-4bf90b4a1807") },
                    { new Guid("5337753f-c43d-4ffa-b966-6e926c3a0a1c"), "https://www.1obl.ru/news/", "//a[starts-with(@href, '/news/') and not(contains(@href, '?'))]/@href", new Guid("70873440-0058-4669-aa74-352489f9e6da") },
                    { new Guid("62c58603-8696-4a94-bd69-de1938895b9b"), "https://ura.news/", "//a[contains(@href, '/news/')]/@href", new Guid("e16286a8-78a9-4b86-ba4b-c844f7099336") },
                    { new Guid("62fe0769-6882-48b6-91c1-0f7a205aca05"), "https://7days.ru/news/", "//a[contains(@class, '7days__item_href') and starts-with(@href, '/news/')]/@href", new Guid("ba078388-eedf-4ccb-af5f-3f686f4ece4a") },
                    { new Guid("69765f00-a717-43b7-8c2e-59213979a3ed"), "https://www.kp.ru/", "//a[contains(@href, '/news/')]/@href", new Guid("cb68ce1c-c741-41df-a1c9-8ce34529b421") },
                    { new Guid("6b670151-2211-4da1-9313-86e1d58c9893"), "https://www.ntv.ru/novosti/", "//a[not(@href='/novosti/') and not(@href='/novosti/authors') and starts-with(@href, '/novosti/')]/@href", new Guid("6c5fe2d4-8547-4fb0-8966-d148f8d77af7") },
                    { new Guid("6d057994-d84f-4437-a8bc-bd4e427493ca"), "https://www.m24.ru/", "//a[contains(@href, '/news/')]/@href", new Guid("3e24ec11-86a4-4db8-9337-35a00988da7d") },
                    { new Guid("773dc871-3e67-4375-9ded-71969f1e0a81"), "https://overclockers.ru/news", "//div[contains(@class, 'event')]//a[not(contains(@href, '#comments'))]/@href", new Guid("dac8cec6-c84d-4287-b0b9-71f4cf304c7e") },
                    { new Guid("8325b474-7ad4-40bc-a721-82cf3f01d4c2"), "https://www.finam.ru/", "//a[starts-with(@href, 'publications/item/') or starts-with(@href, '/publications/item/')]/@href", new Guid("9e3453b3-be81-4f3b-93da-45192677c6a9") },
                    { new Guid("83f72716-09c4-4c46-97fc-255431a7f616"), "https://life.ru/s/novosti", "//a[contains(@href, '/p/')]/@href", new Guid("170a9aef-a708-41a4-8370-a8526f2c055f") },
                    { new Guid("84cb0a27-b2ef-4cd4-93d2-fcb0fdecf1d0"), "https://russian.rt.com/", "//a[contains(@class, 'link') and contains(@href, 'news/')]/@href", new Guid("5d8e3050-5444-4709-afc3-18a8d46a71ba") },
                    { new Guid("890e7953-5769-4023-922c-45094cb89251"), "https://www.ixbt.com/news/", "//a[starts-with(@href, '/news/') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("e023416d-7d91-4d92-bd5f-37d57c54f6b4") },
                    { new Guid("92324d14-49b0-409a-96e1-6a37a8691c6e"), "https://www.fontanka.ru/24hours_news.html", "//section//ul/li[@class='IBae3']//a[@class='IBd3']/@href", new Guid("068fb7bb-4b76-4261-bc9a-274625fe8890") },
                    { new Guid("938c857a-640d-413d-98bf-1f5c1872dbae"), "https://rg.ru/", "//a[contains(@href, '.html')]/@href", new Guid("31b6f068-3f00-4250-bc74-62146525ba95") },
                    { new Guid("99d95b1b-1ecf-42ec-8e95-e4dcc217762d"), "https://www.pravda.ru/", "//a[contains(@href, '/news/') and not(@href='https://www.pravda.ru/news/')]/@href", new Guid("13f235b7-a6f6-4da4-83a1-13b5af26700a") },
                    { new Guid("a13340f1-b8ad-4aed-8db3-3ce1bc26b977"), "https://travelask.ru/news", "//a[not(@href='/news/') and starts-with(@href, '/news/')]/@href", new Guid("b9ec9be8-e1f2-49d6-b461-b61872bb369c") },
                    { new Guid("a169d814-b17e-4062-a2b5-1599ede6783c"), "https://www.avtovzglyad.ru/news/", "//a[@class='news-card__link']/@href", new Guid("454f4f08-58cf-4ab7-9012-1e5ba663570c") },
                    { new Guid("a6f6a030-99b0-4828-af01-5c01d655be30"), "https://www.kinonews.ru/news/", "//a[contains(@href, '/news_') and not(contains(@href, 'comments')) and not(contains(@href, 'news_p'))]/@href", new Guid("296270ec-026b-4011-83ff-1466ba577864") },
                    { new Guid("b8e85938-97a8-47bf-aa33-c5bca3708e0e"), "https://www.gazeta.ru/news/", "//a[contains(@href, '/news/') and contains(@href, '.shtml') and not(contains(@href, '?'))]/@href", new Guid("cc29eb91-2efb-4d57-8d14-bb5356cbfbb8") },
                    { new Guid("bea34033-d382-4e18-9957-ad079cdb9a61"), "https://ria.ru/", "//a[contains(@class, 'cell-list__item-link')]/@href", new Guid("b8d20577-6c4c-4bd7-a1b1-b58bb4914541") },
                    { new Guid("beacb8f7-d53b-4785-a799-57b69c4cd3fc"), "https://svpressa.ru/all/news/", "//a[contains(@href, '/news/') and not(contains(@href, '?')) and not(starts-with(@href, '/all/news/'))]/@href", new Guid("6854c858-b82d-44f5-bb48-620c9bf9825d") },
                    { new Guid("cea22ad0-6634-4def-9b5b-f1e754ce2d8d"), "https://stopgame.ru/news", "//div[contains(@class, 'list-view')]//div[contains(@class, '_card')]/a/@href", new Guid("b5594347-6ec0-44c0-b381-7ae47f04fa56") },
                    { new Guid("cf99e4fc-dbe3-4be7-9f98-1eccfc954f39"), "https://www.interfax.ru/", "//div[@class='timeline']//a[@tabindex=5]/@href", new Guid("57597b92-2b9d-422e-b0a7-9b11326c879b") },
                    { new Guid("d292849b-0727-4311-b0ff-da147c4d344a"), "https://www.sports.ru/news/", "//a[contains(@href, '.html') and not(contains(@href, '.html#comments')) and not (contains(@href, '/blogs/'))]/@href", new Guid("3e1f065a-c135-4429-941e-d870886b4147") },
                    { new Guid("d6c237fe-b4c2-47b1-918f-298f4a9eafdf"), "https://www.khl.ru/news/", "//a[starts-with(@href, '/news/') and contains(@href, '.html')]/@href", new Guid("9519622d-50f0-4a8d-8728-c58c12255b6f") },
                    { new Guid("d9bee236-e02e-4940-a97f-7aa259961369"), "https://edition.cnn.com/", "//a[contains(@href, '.html')]/@href", new Guid("5c3b0099-2a8a-49a5-8c68-d24ebc9fac07") },
                    { new Guid("d9c7c3b0-bdc7-4bcc-afec-9423cb451086"), "http://www.belta.by/", "//a[contains(@href, 'www.belta.by') and contains(@href, '/view/')]/@href", new Guid("fc0a229f-bde4-4f61-b4eb-75d1285665dd") },
                    { new Guid("e1e2fd1c-8939-4531-90b3-3a8879319fb9"), "https://74.ru/", "//a[starts-with(@href, '/text/') and not(contains(@href, '?')) and not(contains(@href, 'comments/')) and not(@href='/text/')]/@href", new Guid("321e1615-6328-4532-85ac-22d53d59c164") },
                    { new Guid("e33af74d-60d3-4b07-8a1f-f35dd3a2965a"), "https://smart-lab.ru/news/", "//a[not(@href='/blog/') and starts-with(@href, '/blog/') and contains(@href, '.php')]/@href", new Guid("65141fc2-760f-4866-86c5-08cc764cabac") },
                    { new Guid("e69f2b5a-89e8-43df-aa5d-ca4139af6f95"), "https://www.championat.com/news/1.html?utm_source=button&utm_medium=news", "//a[contains(@href, 'news-') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href", new Guid("49bcf6b7-15bc-4f30-a3d6-3c88837aa039") },
                    { new Guid("f0a00f38-8859-4603-91db-251ada2ae73e"), "https://ren.tv/news/", "//a[starts-with(@href, '/news/')]/@href", new Guid("c169d8ad-a9fe-44e9-af6a-fd337ae10000") },
                    { new Guid("f75f5b07-588f-4a4d-afb2-3558f99b54d7"), "https://www.cybersport.ru/", "//a[contains(@href, '/tags/')]/@href", new Guid("797060c0-3b47-4654-9176-32d719baad69") }
                });

            migrationBuilder.InsertData(
                table: "news_source_logos",
                columns: new[] { "id", "original", "small", "source_id" },
                values: new object[,]
                {
                    { new Guid("021335ce-8d6b-47fc-9de8-503f4c248982"), "https://russian.rt.com/static/blocks/touch-icon/apple-touch-icon-144x144-precomposed.png", "https://russian.rt.com/favicon.ico", new Guid("5d8e3050-5444-4709-afc3-18a8d46a71ba") },
                    { new Guid("1949e476-a28c-49c7-8cef-114ed2f70618"), "https://svpressa.ru/favicon-96x96.png?v=1471426270000", "https://svpressa.ru/favicon-32x32.png?v=1471426270000", new Guid("6854c858-b82d-44f5-bb48-620c9bf9825d") },
                    { new Guid("1a1a5026-c9a6-4d74-9f36-721b47a79548"), "https://www.womanhit.ru/static/front/img/favicon.ico?v=2", "https://www.womanhit.ru/static/front/img/favicon.ico?v=2", new Guid("2fa2ff6a-9a8b-4a2d-b0e4-6e7e14679236") },
                    { new Guid("1aa24985-d52d-4f4e-8113-022a0216a2af"), "https://www.kinonews.ru/favicon.ico", "https://www.kinonews.ru/favicon.ico", new Guid("296270ec-026b-4011-83ff-1466ba577864") },
                    { new Guid("29e9a963-8850-4c05-9714-a4b59af20be4"), "https://tass.ru/favicon/180.svg", "https://tass.ru/favicon/57.png", new Guid("7e889af8-0f19-44ab-96d4-241fd64fbcdb") },
                    { new Guid("3472a1e0-4bf9-418a-8e9e-94830248020b"), "https://aif.ru/img/icon/apple-touch-icon.png?44f", "https://aif.ru/img/icon/favicon-32x32.png?44f", new Guid("9268835d-553d-4fbe-a0cb-0545b8019c68") },
                    { new Guid("375423fe-7b3a-4296-80f1-4072577524c0"), "https://www.cybersport.ru/favicon-192x192.png", "https://www.cybersport.ru/favicon-32x32.png", new Guid("797060c0-3b47-4654-9176-32d719baad69") },
                    { new Guid("3ee815d8-a253-47c7-9084-22cddbb490d4"), "https://rusvesna.su/favicon.ico", "https://rusvesna.su/favicon.ico", new Guid("b2fb23b4-3f6d-440c-9ec0-99216f233fd0") },
                    { new Guid("3fbe2b42-7817-422b-a3e1-020942b42d4b"), "https://st.championat.com/i/favicon/apple-touch-icon.png", "https://st.championat.com/i/favicon/favicon-32x32.png", new Guid("49bcf6b7-15bc-4f30-a3d6-3c88837aa039") },
                    { new Guid("427cf0f1-b0ef-4ab9-b181-63710edcf220"), "https://www.ixbt.com/favicon.ico", "https://www.ixbt.com/favicon.ico", new Guid("e023416d-7d91-4d92-bd5f-37d57c54f6b4") },
                    { new Guid("495799aa-0817-433e-9abe-5481c0f3d569"), "https://stopgame.ru/favicon_512.png", "https://stopgame.ru/favicon.ico", new Guid("b5594347-6ec0-44c0-b381-7ae47f04fa56") },
                    { new Guid("4975ba0c-d5eb-44cf-8743-2aa7d621c5d1"), "https://www.belta.by/images/storage/banners/000016_a133e848cb2e7b1debb7102d19e4d139_work.svg", "https://www.belta.by/images/storage/banners/000016_a133e848cb2e7b1debb7102d19e4d139_work.svg", new Guid("fc0a229f-bde4-4f61-b4eb-75d1285665dd") },
                    { new Guid("4af4b3b2-ca3d-4421-976f-0406c515033a"), "https://cdn-static.ntv.ru/images/favicons/android-chrome-192x192.png", "https://cdn-static.ntv.ru/images/favicons/favicon-32x32.png", new Guid("6c5fe2d4-8547-4fb0-8966-d148f8d77af7") },
                    { new Guid("4cf43716-885c-4a85-8d23-0ecc987da590"), "https://s01.stc.yc.kpcdn.net/s0/2.1.321/adaptive/favicon-128.png", "https://s01.stc.yc.kpcdn.net/s0/2.1.321/adaptive/favicon-32.png", new Guid("cb68ce1c-c741-41df-a1c9-8ce34529b421") },
                    { new Guid("504e7035-e6bb-434a-939c-5b4515ad4e48"), "https://ren.tv/apple-touch-icon.png", "https://ren.tv/favicon-32x32.png", new Guid("c169d8ad-a9fe-44e9-af6a-fd337ae10000") },
                    { new Guid("5195571a-9041-4d0e-a9d1-dddbc5c9cb39"), "https://www.hltv.org/img/static/favicon/apple-touch-icon.png", "https://www.hltv.org/img/static/favicon/favicon-32x32.png", new Guid("e4b3e286-3589-49de-892b-d0d06e719115") },
                    { new Guid("52827f36-597f-424c-bc69-6e71f2bdde5c"), "https://www.pravda.ru/pix/apple-touch-icon.png", "https://www.pravda.ru/favicon.ico", new Guid("13f235b7-a6f6-4da4-83a1-13b5af26700a") },
                    { new Guid("52cd41a3-05b6-4ed0-87d0-bb62bd1a742a"), "https://im.kommersant.ru/ContentFlex/images/favicons2020/apple-touch-icon-180.png", "https://im.kommersant.ru/ContentFlex/images/favicons2020/favicon-32.png", new Guid("baaa533a-cb1a-46e7-bb9e-79d631affc87") },
                    { new Guid("53f0c42f-abe9-46e6-8c49-a4939e81be95"), "https://life.ru/appletouch/apple-icon-180%D1%85180.png", "https://life.ru/favicon-32%D1%8532.png", new Guid("170a9aef-a708-41a4-8370-a8526f2c055f") },
                    { new Guid("5531cc3d-cee5-490a-aaac-20b826e1135b"), "https://www.sports.ru/apple-touch-icon-1024.png", "https://www.sports.ru/apple-touch-icon-76.png", new Guid("3e1f065a-c135-4429-941e-d870886b4147") },
                    { new Guid("5f715b2b-8509-4425-aaed-2da285f295d0"), "https://cdn.hsmedia.ru/public/favicon/starhit/apple-touch-icon.png", "https://cdn.hsmedia.ru/public/favicon/starhit/favicon.png", new Guid("05765a1b-b174-4ad1-9f63-3189a52303f9") },
                    { new Guid("68fa8065-fdc2-4e15-b2b1-3adb91d2d862"), "https://www.1obl.ru/apple-touch-icon.png", "https://www.1obl.ru/favicon-32x32.png", new Guid("70873440-0058-4669-aa74-352489f9e6da") },
                    { new Guid("6b5da5aa-29f4-4ee9-a310-db70936a1ff1"), "https://smart-lab.ru/templates/skin/smart-lab-x3/images/favicon.ico", "https://smart-lab.ru/templates/skin/smart-lab-x3/images/favicon.ico", new Guid("65141fc2-760f-4866-86c5-08cc764cabac") },
                    { new Guid("6e7dee47-3b1c-4ec8-b2c7-b6ec29fcc6f5"), "https://meduza.io/apple-touch-icon-180.png", "https://meduza.io/favicon-32x32.png", new Guid("3a346f18-1781-408b-bc8d-2f8e4cbc64ea") },
                    { new Guid("7083afb5-2799-44f7-a508-60369598da29"), "https://www.zr.ru/favicons/safari-pinned-tab.svg", "https://www.zr.ru/favicons/favicon.ico", new Guid("a71c23bf-67e9-4955-bc8e-6226bd86ba90") },
                    { new Guid("7e056d72-a4a4-4608-b393-b56d976a2bad"), "https://www.m24.ru/img/fav/apple-touch-icon.png", "https://www.m24.ru/img/fav/favicon-32x32.png", new Guid("3e24ec11-86a4-4db8-9337-35a00988da7d") },
                    { new Guid("872f13d3-d28d-44c4-bf38-ab69bb554e4a"), "https://www.fontanka.ru/static/assets/favicons/apple/apple-favicon-180.png", "https://www.fontanka.ru/static/assets/favicons/apple/apple-favicon-76-precomposed.png", new Guid("068fb7bb-4b76-4261-bc9a-274625fe8890") },
                    { new Guid("8db8aa26-06f6-4ebf-b2f6-81a02a20a288"), "https://ura.news/apple-touch-icon.png", "https://s.ura.news/favicon.ico?3", new Guid("e16286a8-78a9-4b86-ba4b-c844f7099336") },
                    { new Guid("915e2d86-b519-4034-a44f-991b0a446607"), "https://s9.travelask.ru/favicons/apple-touch-icon-180x180.png", "https://s9.travelask.ru/favicons/favicon-32x32.png", new Guid("b9ec9be8-e1f2-49d6-b461-b61872bb369c") },
                    { new Guid("955eb645-e135-46d6-990e-1348bcc962d8"), "https://overclockers.ru/assets/apple-touch-icon-120x120.png", "https://overclockers.ru/assets/apple-touch-icon.png", new Guid("dac8cec6-c84d-4287-b0b9-71f4cf304c7e") },
                    { new Guid("9e7d94a1-3960-4019-aa85-e4f384ec14ea"), "https://www.finam.ru/favicon-144x144.png", "https://www.finam.ru/favicon.png", new Guid("9e3453b3-be81-4f3b-93da-45192677c6a9") },
                    { new Guid("9f083bc5-a246-46d7-a2fe-eaa32d79a821"), "https://edition.cnn.com/media/sites/cnn/apple-touch-icon.png", "https://edition.cnn.com/media/sites/cnn/favicon.ico", new Guid("5c3b0099-2a8a-49a5-8c68-d24ebc9fac07") },
                    { new Guid("a0faaf8f-34af-43f7-af18-782f9c6214d4"), "https://cdnn21.img.ria.ru/i/favicons/favicon.svg", "https://cdnn21.img.ria.ru/i/favicons/favicon.ico", new Guid("b8d20577-6c4c-4bd7-a1b1-b58bb4914541") },
                    { new Guid("a1e75a31-deae-4634-8bd8-eea983e60bfc"), "https://tsargrad.tv/favicons/apple-touch-icon-180x180.png?s2", "https://tsargrad.tv/favicons/favicon-32x32.png?s2", new Guid("3b8c9766-f5d5-44ec-a014-45ddce4a9a0c") },
                    { new Guid("a5431839-5bf7-46f6-a2eb-c93b4b18e24f"), "https://cdn.iz.ru/profiles/portal/themes/purple/images/favicons/android-icon-192x192.png", "https://cdn.iz.ru/profiles/portal/themes/purple/images/favicons/favicon-32x32.png", new Guid("31252741-4d0b-448f-b85c-d6538f7ca565") },
                    { new Guid("a77ffd9e-beb2-43d6-bf02-94ad9bc1eccd"), "https://s.rbk.ru/v10_rbcnews_static/common/common-10.10.120/images/android-chrome-512x512.png", "https://s.rbk.ru/v10_rbcnews_static/common/common-10.10.120/images/favicon.png", new Guid("950d59d6-d94c-4396-a55e-cbcd2a9b533c") },
                    { new Guid("a786f93c-3c1d-4561-a699-58fba081cc37"), "https://regnum.ru/favicons/apple-touch-icon.png?v=202305", "https://regnum.ru/favicons/favicon-32x32.png?v=202305", new Guid("60747323-2a4c-44e1-880d-7e5e36642645") },
                    { new Guid("b22f3762-d5d6-4102-9817-a719bb0c220c"), "https://www.khl.ru/img/icons/152x152.png", "https://www.khl.ru/img/icons/32x32.png", new Guid("9519622d-50f0-4a8d-8728-c58c12255b6f") },
                    { new Guid("bafc4c68-8558-46d1-b778-0c2137188d93"), "https://www.novorosinform.org/favicon.ico?v3", "https://www.novorosinform.org/favicon.ico?v3", new Guid("c7b863af-0565-4bec-9238-9383272637ef") },
                    { new Guid("c4d13a4c-2f0d-41a4-a5e0-543e6a7dbad8"), "https://img5tv.cdnvideo.ru/shared/img/favicon_24.png", "https://img5tv.cdnvideo.ru/shared/img/favicon_24.png", new Guid("33b14253-7c02-4b79-8490-c8ed10312230") },
                    { new Guid("d1418d56-a990-448a-8334-a8cc8cec1b00"), "https://3dnews.ru/assets/images/3dnews_logo_soc.png", "https://3dnews.ru/assets/3dnews_logo_color.png", new Guid("5aebacd6-b4d5-4839-b2f0-533ff3329941") },
                    { new Guid("d227ada8-0869-4320-8e0b-29b4b57ace6f"), "https://7days.ru/android-icon-192x192.png", "https://7days.ru/favicon-32x32.png", new Guid("ba078388-eedf-4ccb-af5f-3f686f4ece4a") },
                    { new Guid("d7e0f8bc-64ec-4450-b8bb-82689f1d9012"), "https://static.gazeta.ru/nm2021/img/icons/favicon.svg", "https://static.gazeta.ru/nm2021/img/icons/favicon.svg", new Guid("cc29eb91-2efb-4d57-8d14-bb5356cbfbb8") },
                    { new Guid("db46c593-155d-4775-b999-dbe4eb772fb1"), "https://www.interfax.ru/touch-icon-ipad-retina.png", "https://www.interfax.ru/touch-icon-iphone.png", new Guid("57597b92-2b9d-422e-b0a7-9b11326c879b") },
                    { new Guid("def8f81b-0a9b-44fb-a6bc-26f398fb175c"), "https://ixbt.games/images/favicon/gt/apple-touch-icon.png", "https://ixbt.games/images/favicon/gt/apple-touch-icon.png", new Guid("604e9548-9b99-4bd4-ab90-4bf90b4a1807") },
                    { new Guid("e1eeadd2-6075-447a-8cda-0952e46496fc"), "https://www.nytimes.com/vi-assets/static-assets/apple-touch-icon-28865b72953380a40aa43318108876cb.png", "https://www.nytimes.com/vi-assets/static-assets/ios-default-homescreen-57x57-dark-b395ebcad5b63aff9285aab58e31035e.png", new Guid("136c7569-601c-4f16-9ca4-bd14bfa8c16a") },
                    { new Guid("e8db752b-966e-4c0f-9cab-895cda0de469"), "https://cdnn21.img.ria.ru/i/favicons/radiosputnik/apple-touch-icon.png", "https://cdnn21.img.ria.ru/i/favicons/radiosputnik/favicon.ico", new Guid("1994c4bc-aeb9-4242-81df-5bafffca6fd0") },
                    { new Guid("ef6108bf-e9c1-4f8b-b4f7-7e933b1c7ac3"), "https://www.avtovzglyad.ru/static/images/favicon/safari-pinned-tab.svg", "https://www.avtovzglyad.ru/static/images/favicon/favicon-32x32.png", new Guid("454f4f08-58cf-4ab7-9012-1e5ba663570c") },
                    { new Guid("ef6ba8cf-50e4-432b-9329-19097bff75e2"), "https://icdn.lenta.ru/images/icons/icon-256x256.png", "https://icdn.lenta.ru/favicon.ico", new Guid("fb2f8557-ca7e-4ce2-86dd-b8a94ee02275") },
                    { new Guid("f1b5322f-8f12-4a8d-ba28-ee5aaed34228"), "https://cdnstatic.rg.ru/images/touch-icon-ipad-retina_512x512.png", "https://rg.ru/favicon.ico", new Guid("31b6f068-3f00-4250-bc74-62146525ba95") },
                    { new Guid("f22a5c00-53d0-43b8-93a3-1cdac2e103cc"), "https://vz.ru/apple-touch-icon.png", "https://vz.ru/static/images/favicon.ico", new Guid("e2ce0a01-9d10-4133-a989-618739aa3854") },
                    { new Guid("f3318dd0-6ed3-4b25-ab34-6f4330317853"), "https://static.ngs.ru/jtnews/dist/static/favicons/apple/apple-favicon-74-180.png", "https://static.ngs.ru/jtnews/dist/static/favicons/favicon-rugion-32.ico", new Guid("321e1615-6328-4532-85ac-22d53d59c164") }
                });

            migrationBuilder.InsertData(
                table: "news_source_tags",
                columns: new[] { "id", "source_id", "tag_id" },
                values: new object[,]
                {
                    { new Guid("000a5ecc-fee2-486f-88de-ca43ce445849"), new Guid("31b6f068-3f00-4250-bc74-62146525ba95"), new Guid("9503b07f-c97a-49e7-b177-97e3a293dc31") },
                    { new Guid("025c4e26-53d0-469f-9c52-3cec92eda13a"), new Guid("cc29eb91-2efb-4d57-8d14-bb5356cbfbb8"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("050c5ae6-0a40-40fc-b900-4e16ec28159c"), new Guid("a71c23bf-67e9-4955-bc8e-6226bd86ba90"), new Guid("464a2260-130c-4a4b-8aa6-4f477cd1760f") },
                    { new Guid("06253ef3-b019-488a-a553-9da5fafb3ac1"), new Guid("9519622d-50f0-4a8d-8728-c58c12255b6f"), new Guid("9503b07f-c97a-49e7-b177-97e3a293dc31") },
                    { new Guid("06b2c915-82cf-4115-a537-cbc91d80783a"), new Guid("3e24ec11-86a4-4db8-9337-35a00988da7d"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("0ac9ad4a-29b6-4689-aadc-b3b75a3b034c"), new Guid("3e1f065a-c135-4429-941e-d870886b4147"), new Guid("6c939d6c-0461-46c8-b9b6-83021b68df71") },
                    { new Guid("0b19d00f-4483-4f55-818a-a7b34925b37b"), new Guid("e2ce0a01-9d10-4133-a989-618739aa3854"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("0b335897-3cb8-4bd8-8e01-3435785fdc9c"), new Guid("33b14253-7c02-4b79-8490-c8ed10312230"), new Guid("302d7e19-c80f-4e1a-8877-3e9b17f9baeb") },
                    { new Guid("0ee0d08c-66c0-4f83-ad46-92e3971d13d8"), new Guid("ba078388-eedf-4ccb-af5f-3f686f4ece4a"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("0eedd3af-e5dd-45f7-af31-15b9dee5c89f"), new Guid("70873440-0058-4669-aa74-352489f9e6da"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("151e6d99-9d03-4acb-8058-0f49bbb4a589"), new Guid("6854c858-b82d-44f5-bb48-620c9bf9825d"), new Guid("302d7e19-c80f-4e1a-8877-3e9b17f9baeb") },
                    { new Guid("1536f46f-ea14-4fb8-b8d5-9aae924266ff"), new Guid("70873440-0058-4669-aa74-352489f9e6da"), new Guid("9503b07f-c97a-49e7-b177-97e3a293dc31") },
                    { new Guid("1a3984fc-b3b1-4d9f-bdff-716636bb2353"), new Guid("49bcf6b7-15bc-4f30-a3d6-3c88837aa039"), new Guid("6c939d6c-0461-46c8-b9b6-83021b68df71") },
                    { new Guid("1bc5683b-b0fa-4a72-b9d8-bfc9c45360c6"), new Guid("e4b3e286-3589-49de-892b-d0d06e719115"), new Guid("cfa03d74-4386-4e3f-a841-bb6498a02adc") },
                    { new Guid("1e00ba56-95e3-41d7-8eb0-fb2a839faf9c"), new Guid("e16286a8-78a9-4b86-ba4b-c844f7099336"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("20725e40-3f1d-4089-8d74-9d08ae3f127d"), new Guid("7e889af8-0f19-44ab-96d4-241fd64fbcdb"), new Guid("9503b07f-c97a-49e7-b177-97e3a293dc31") },
                    { new Guid("2134a235-9b9d-4010-b627-2de04e044a0f"), new Guid("60747323-2a4c-44e1-880d-7e5e36642645"), new Guid("9503b07f-c97a-49e7-b177-97e3a293dc31") },
                    { new Guid("22aacfa5-7c90-4d6f-9b04-79805d6d01e3"), new Guid("068fb7bb-4b76-4261-bc9a-274625fe8890"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("24eaf488-7213-4419-8f9e-edb3222c7004"), new Guid("296270ec-026b-4011-83ff-1466ba577864"), new Guid("85e1d7f3-0150-48ac-9c29-17acec559f32") },
                    { new Guid("2565182d-475e-4217-8b8d-b2ba9dbeb092"), new Guid("fc0a229f-bde4-4f61-b4eb-75d1285665dd"), new Guid("302d7e19-c80f-4e1a-8877-3e9b17f9baeb") },
                    { new Guid("25a4e9e3-c047-485a-9684-c3f897c6d8b8"), new Guid("cc29eb91-2efb-4d57-8d14-bb5356cbfbb8"), new Guid("9503b07f-c97a-49e7-b177-97e3a293dc31") },
                    { new Guid("2753275a-efd1-41e9-84cd-8b5399cb2ea3"), new Guid("797060c0-3b47-4654-9176-32d719baad69"), new Guid("6c939d6c-0461-46c8-b9b6-83021b68df71") },
                    { new Guid("2765ef2f-338c-4f92-a1d2-4ed1dc54ed83"), new Guid("3a346f18-1781-408b-bc8d-2f8e4cbc64ea"), new Guid("302d7e19-c80f-4e1a-8877-3e9b17f9baeb") },
                    { new Guid("2d10c3ff-332e-46bb-a37b-0ca725ee91a1"), new Guid("170a9aef-a708-41a4-8370-a8526f2c055f"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("30042a38-0f29-4378-b9e9-12c64a043913"), new Guid("c169d8ad-a9fe-44e9-af6a-fd337ae10000"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("3073fa94-5ff5-411f-b8b7-25663045c4da"), new Guid("c169d8ad-a9fe-44e9-af6a-fd337ae10000"), new Guid("9503b07f-c97a-49e7-b177-97e3a293dc31") },
                    { new Guid("311ea1df-f338-4d3a-83f9-9f69c9fb5593"), new Guid("13f235b7-a6f6-4da4-83a1-13b5af26700a"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("3241b406-31e8-41a2-b9cd-efc585789d48"), new Guid("9268835d-553d-4fbe-a0cb-0545b8019c68"), new Guid("302d7e19-c80f-4e1a-8877-3e9b17f9baeb") },
                    { new Guid("32ea560c-f4ef-4bb9-844c-72206f5f0e5f"), new Guid("321e1615-6328-4532-85ac-22d53d59c164"), new Guid("9503b07f-c97a-49e7-b177-97e3a293dc31") },
                    { new Guid("33e60843-feb6-4f42-b171-b5dbd423ed3b"), new Guid("31b6f068-3f00-4250-bc74-62146525ba95"), new Guid("302d7e19-c80f-4e1a-8877-3e9b17f9baeb") },
                    { new Guid("33e821e2-c90d-45ed-a905-269ca20bf28f"), new Guid("7e889af8-0f19-44ab-96d4-241fd64fbcdb"), new Guid("302d7e19-c80f-4e1a-8877-3e9b17f9baeb") },
                    { new Guid("3442ffd8-d296-4f9a-8b56-e1c83a468053"), new Guid("cb68ce1c-c741-41df-a1c9-8ce34529b421"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("374ede54-919b-4c31-9738-18b31de40898"), new Guid("b9ec9be8-e1f2-49d6-b461-b61872bb369c"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("393c3856-dbc5-4620-9a35-635894691dfc"), new Guid("fc0a229f-bde4-4f61-b4eb-75d1285665dd"), new Guid("5654a834-6f9a-4caa-a153-d4644204001c") },
                    { new Guid("39b9de90-e868-41c1-8390-632d344850d7"), new Guid("b5594347-6ec0-44c0-b381-7ae47f04fa56"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("3a64826a-9a6f-4d7d-9798-1c86350846d1"), new Guid("33b14253-7c02-4b79-8490-c8ed10312230"), new Guid("ae20fd4f-a451-42cb-aae6-875d0bfacaa7") },
                    { new Guid("3e8627f0-f07d-4cab-a30b-08282bbdf928"), new Guid("fb2f8557-ca7e-4ce2-86dd-b8a94ee02275"), new Guid("302d7e19-c80f-4e1a-8877-3e9b17f9baeb") },
                    { new Guid("3f0c3643-d21d-4e8e-bf55-a01b42011215"), new Guid("b8d20577-6c4c-4bd7-a1b1-b58bb4914541"), new Guid("302d7e19-c80f-4e1a-8877-3e9b17f9baeb") },
                    { new Guid("4762d902-fdfe-413d-9c8d-76e619e81c7d"), new Guid("5aebacd6-b4d5-4839-b2f0-533ff3329941"), new Guid("34cc1d82-002a-4c8c-b783-e46d9c88dde5") },
                    { new Guid("4998ee1a-d54c-4d29-be1d-8df7c60ee7b3"), new Guid("49bcf6b7-15bc-4f30-a3d6-3c88837aa039"), new Guid("9503b07f-c97a-49e7-b177-97e3a293dc31") },
                    { new Guid("4b5473d0-5275-4615-94e2-596a86b383dd"), new Guid("1994c4bc-aeb9-4242-81df-5bafffca6fd0"), new Guid("302d7e19-c80f-4e1a-8877-3e9b17f9baeb") },
                    { new Guid("4b63e46c-1f07-4dc7-8c63-2a8eab4fb054"), new Guid("068fb7bb-4b76-4261-bc9a-274625fe8890"), new Guid("9503b07f-c97a-49e7-b177-97e3a293dc31") },
                    { new Guid("4cac9f6e-f034-4600-8272-a04aeca7f0b4"), new Guid("5d8e3050-5444-4709-afc3-18a8d46a71ba"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("4d30d497-e95e-428f-b8ed-b38f67a62894"), new Guid("dac8cec6-c84d-4287-b0b9-71f4cf304c7e"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("4ee63615-d18c-4f48-8b9a-8aff52d12006"), new Guid("05765a1b-b174-4ad1-9f63-3189a52303f9"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("4ef14b7a-d41d-4eab-b58d-db7ce19bcdbb"), new Guid("9e3453b3-be81-4f3b-93da-45192677c6a9"), new Guid("19db4d3d-b17a-45ff-9853-cdce9630c08f") },
                    { new Guid("4f09a167-0888-4ee7-9f0a-0cf691870de1"), new Guid("1994c4bc-aeb9-4242-81df-5bafffca6fd0"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("4f514879-ca5a-45a2-9c9c-4834f7f98bd7"), new Guid("e2ce0a01-9d10-4133-a989-618739aa3854"), new Guid("9503b07f-c97a-49e7-b177-97e3a293dc31") },
                    { new Guid("508b2fd4-609d-4ce2-925a-a18c7b9889db"), new Guid("e4b3e286-3589-49de-892b-d0d06e719115"), new Guid("8e8ec992-5b4b-43d9-b290-73fbfcd8a32e") },
                    { new Guid("50d237f6-59fa-44bc-96f4-344bab93f074"), new Guid("05765a1b-b174-4ad1-9f63-3189a52303f9"), new Guid("bcc08307-a922-4de1-aa17-8ff9dc438425") },
                    { new Guid("5136ab36-5504-49e6-9422-0afeff788cbf"), new Guid("e023416d-7d91-4d92-bd5f-37d57c54f6b4"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("5178aad8-b861-4640-afc6-c3bd1749ae94"), new Guid("fb2f8557-ca7e-4ce2-86dd-b8a94ee02275"), new Guid("9503b07f-c97a-49e7-b177-97e3a293dc31") },
                    { new Guid("5385f93d-42d7-4798-9868-d5c75a86fd8f"), new Guid("31b6f068-3f00-4250-bc74-62146525ba95"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("53a0fa14-82ed-49a0-9f6c-0ad21e2c8ff8"), new Guid("60747323-2a4c-44e1-880d-7e5e36642645"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("53d62165-056b-4061-9415-696925c16912"), new Guid("9e3453b3-be81-4f3b-93da-45192677c6a9"), new Guid("47ea1951-5508-4647-a805-138a861974ff") },
                    { new Guid("585e40dd-ec2b-41b6-b505-59603e1031f8"), new Guid("fb2f8557-ca7e-4ce2-86dd-b8a94ee02275"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("5c40c521-5f8b-4fd2-984c-78c7a3e583bd"), new Guid("5c3b0099-2a8a-49a5-8c68-d24ebc9fac07"), new Guid("ae20fd4f-a451-42cb-aae6-875d0bfacaa7") },
                    { new Guid("5ec2412d-81f3-4157-924d-44ad65e0a24a"), new Guid("49bcf6b7-15bc-4f30-a3d6-3c88837aa039"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("6159dd07-94f5-471e-b6ea-0cd73b2de872"), new Guid("c169d8ad-a9fe-44e9-af6a-fd337ae10000"), new Guid("ae20fd4f-a451-42cb-aae6-875d0bfacaa7") },
                    { new Guid("6225f6e1-2901-4727-8aa5-c34d46730169"), new Guid("5c3b0099-2a8a-49a5-8c68-d24ebc9fac07"), new Guid("cbb60009-18c3-479b-a09a-cfe976fb5abd") },
                    { new Guid("660485e7-ff2a-4375-979a-62769a8becfa"), new Guid("3b8c9766-f5d5-44ec-a014-45ddce4a9a0c"), new Guid("302d7e19-c80f-4e1a-8877-3e9b17f9baeb") },
                    { new Guid("674e3fd9-f4a8-4b81-9f11-4de28cc824dd"), new Guid("068fb7bb-4b76-4261-bc9a-274625fe8890"), new Guid("6fc28243-4b6e-4013-8121-0bc4d8397552") },
                    { new Guid("683efe05-2dee-444a-95e9-5f23909ef186"), new Guid("9519622d-50f0-4a8d-8728-c58c12255b6f"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("6884348a-7db9-49b3-81db-8300d6e0d72e"), new Guid("baaa533a-cb1a-46e7-bb9e-79d631affc87"), new Guid("9503b07f-c97a-49e7-b177-97e3a293dc31") },
                    { new Guid("688e1338-51ad-40c5-a537-4fcc91fd0ed0"), new Guid("e023416d-7d91-4d92-bd5f-37d57c54f6b4"), new Guid("34cc1d82-002a-4c8c-b783-e46d9c88dde5") },
                    { new Guid("6939baf3-2726-4b72-9ef2-ad710cdecc88"), new Guid("b2fb23b4-3f6d-440c-9ec0-99216f233fd0"), new Guid("302d7e19-c80f-4e1a-8877-3e9b17f9baeb") },
                    { new Guid("6a065cf7-5a1e-445f-98d1-043b96aa75e8"), new Guid("31252741-4d0b-448f-b85c-d6538f7ca565"), new Guid("302d7e19-c80f-4e1a-8877-3e9b17f9baeb") },
                    { new Guid("6a63cd8b-9bfd-4c7b-9fc4-add3af28ab09"), new Guid("65141fc2-760f-4866-86c5-08cc764cabac"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("6ce3a3ff-775d-4606-a3eb-462daa663500"), new Guid("e4b3e286-3589-49de-892b-d0d06e719115"), new Guid("4c65a245-2631-47ed-a84d-e4699e9a997c") },
                    { new Guid("6d9524d2-1101-493e-bd71-53d8ecf0e8de"), new Guid("baaa533a-cb1a-46e7-bb9e-79d631affc87"), new Guid("302d7e19-c80f-4e1a-8877-3e9b17f9baeb") },
                    { new Guid("6db9856b-05fa-4036-b700-6f6288bc8318"), new Guid("5c3b0099-2a8a-49a5-8c68-d24ebc9fac07"), new Guid("302d7e19-c80f-4e1a-8877-3e9b17f9baeb") },
                    { new Guid("70b71eaf-20ce-489e-bf24-77201fb2a506"), new Guid("60747323-2a4c-44e1-880d-7e5e36642645"), new Guid("302d7e19-c80f-4e1a-8877-3e9b17f9baeb") },
                    { new Guid("745d9370-217a-4c3c-9289-215003e963f2"), new Guid("3b8c9766-f5d5-44ec-a014-45ddce4a9a0c"), new Guid("9503b07f-c97a-49e7-b177-97e3a293dc31") },
                    { new Guid("75e4331e-76d5-48d0-998b-0765b6b7854d"), new Guid("950d59d6-d94c-4396-a55e-cbcd2a9b533c"), new Guid("9503b07f-c97a-49e7-b177-97e3a293dc31") },
                    { new Guid("7afa8562-f5b4-4cdf-92c0-af0594d4be4d"), new Guid("604e9548-9b99-4bd4-ab90-4bf90b4a1807"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("7c4772ef-afbb-4264-92b5-77389e8c0990"), new Guid("9268835d-553d-4fbe-a0cb-0545b8019c68"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("83188472-1463-4bcf-8d36-6166906332ac"), new Guid("b2fb23b4-3f6d-440c-9ec0-99216f233fd0"), new Guid("9503b07f-c97a-49e7-b177-97e3a293dc31") },
                    { new Guid("8477f4da-0bb6-4f77-9d5b-e8681d275e34"), new Guid("1994c4bc-aeb9-4242-81df-5bafffca6fd0"), new Guid("9503b07f-c97a-49e7-b177-97e3a293dc31") },
                    { new Guid("8512f634-1ddd-405a-841d-45545534904f"), new Guid("c169d8ad-a9fe-44e9-af6a-fd337ae10000"), new Guid("302d7e19-c80f-4e1a-8877-3e9b17f9baeb") },
                    { new Guid("853e103e-0105-46c0-869b-3b7c3ed19a46"), new Guid("b5594347-6ec0-44c0-b381-7ae47f04fa56"), new Guid("2139e644-a9fa-49ce-8eea-7380e7936527") },
                    { new Guid("85583770-ceb5-4114-b5dd-b00cc6dcb199"), new Guid("136c7569-601c-4f16-9ca4-bd14bfa8c16a"), new Guid("8e8ec992-5b4b-43d9-b290-73fbfcd8a32e") },
                    { new Guid("8949a721-7dfc-428c-a03d-6721e5b35879"), new Guid("3e24ec11-86a4-4db8-9337-35a00988da7d"), new Guid("9f2effc4-5f9d-419a-83a9-598c41afc2b8") },
                    { new Guid("89efc9f8-a1a8-4ca4-accb-72741ca89d18"), new Guid("9519622d-50f0-4a8d-8728-c58c12255b6f"), new Guid("aa8de58c-f61f-4b4c-ad4c-ff05245e052c") },
                    { new Guid("93013951-10cd-474a-834f-fa528a3fd95b"), new Guid("6c5fe2d4-8547-4fb0-8966-d148f8d77af7"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("931d85e9-49d4-44dd-b062-d8c7ce5d241a"), new Guid("9519622d-50f0-4a8d-8728-c58c12255b6f"), new Guid("6c939d6c-0461-46c8-b9b6-83021b68df71") },
                    { new Guid("934a294d-04fc-4f74-971c-1dac01b70086"), new Guid("136c7569-601c-4f16-9ca4-bd14bfa8c16a"), new Guid("f06891c5-6324-4bab-b836-a78a4d2c603d") },
                    { new Guid("942b3d98-af39-40f6-a2d4-e4acb4d48df2"), new Guid("a71c23bf-67e9-4955-bc8e-6226bd86ba90"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("95d32d18-c7c5-4749-8166-7d83d9ad9bf6"), new Guid("6854c858-b82d-44f5-bb48-620c9bf9825d"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("95fe22e4-5977-4f74-947d-9cc8dba28f47"), new Guid("c7b863af-0565-4bec-9238-9383272637ef"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("9730da62-1ba7-4f35-a1e0-6b7a0d6c4e3f"), new Guid("b2fb23b4-3f6d-440c-9ec0-99216f233fd0"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("97b780f9-1854-4ee2-88f9-cc9027152826"), new Guid("3b8c9766-f5d5-44ec-a014-45ddce4a9a0c"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("985748c8-d5a4-48c5-a41b-b23c8726d297"), new Guid("65141fc2-760f-4866-86c5-08cc764cabac"), new Guid("19db4d3d-b17a-45ff-9853-cdce9630c08f") },
                    { new Guid("99d1cd54-f21d-407d-b1e1-54a6bd79f6ab"), new Guid("13f235b7-a6f6-4da4-83a1-13b5af26700a"), new Guid("302d7e19-c80f-4e1a-8877-3e9b17f9baeb") },
                    { new Guid("9bed47b1-ba64-453a-91df-0c08b9ab61c1"), new Guid("fc0a229f-bde4-4f61-b4eb-75d1285665dd"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("9c690333-2c73-4cfc-b113-b4feb4fbc30a"), new Guid("797060c0-3b47-4654-9176-32d719baad69"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("9d0a0cea-e52f-4418-8652-3a152788a1ff"), new Guid("9e3453b3-be81-4f3b-93da-45192677c6a9"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("9d6cd55b-f966-4e6a-973d-d548d7183da2"), new Guid("321e1615-6328-4532-85ac-22d53d59c164"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("9f83d191-c57f-4c08-bdf9-6b0c97b8367c"), new Guid("e16286a8-78a9-4b86-ba4b-c844f7099336"), new Guid("302d7e19-c80f-4e1a-8877-3e9b17f9baeb") },
                    { new Guid("a02eecd4-f17b-42eb-beea-331873191aa9"), new Guid("6854c858-b82d-44f5-bb48-620c9bf9825d"), new Guid("9503b07f-c97a-49e7-b177-97e3a293dc31") },
                    { new Guid("a06bb1f8-a548-44b5-8d41-02af27aeeaf7"), new Guid("c7b863af-0565-4bec-9238-9383272637ef"), new Guid("302d7e19-c80f-4e1a-8877-3e9b17f9baeb") },
                    { new Guid("a0d39b98-3a62-4153-9a5f-b678bd754ff0"), new Guid("9e3453b3-be81-4f3b-93da-45192677c6a9"), new Guid("9503b07f-c97a-49e7-b177-97e3a293dc31") },
                    { new Guid("a12ba2dd-791c-44c0-963c-d0d0224f7aef"), new Guid("33b14253-7c02-4b79-8490-c8ed10312230"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("a12d8fd1-873f-4ac7-b4c5-4bffc6cb3479"), new Guid("6c5fe2d4-8547-4fb0-8966-d148f8d77af7"), new Guid("ae20fd4f-a451-42cb-aae6-875d0bfacaa7") },
                    { new Guid("a1ba384a-04c5-4886-a113-36d86fc8cf60"), new Guid("950d59d6-d94c-4396-a55e-cbcd2a9b533c"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("a3c4d53e-42e2-4639-a0e6-adb0ce838bdb"), new Guid("6c5fe2d4-8547-4fb0-8966-d148f8d77af7"), new Guid("302d7e19-c80f-4e1a-8877-3e9b17f9baeb") },
                    { new Guid("a5c23469-5399-4848-bf82-14e195c357ac"), new Guid("454f4f08-58cf-4ab7-9012-1e5ba663570c"), new Guid("464a2260-130c-4a4b-8aa6-4f477cd1760f") },
                    { new Guid("a881440d-08a1-41e0-86a7-64b3dec4d5d4"), new Guid("31252741-4d0b-448f-b85c-d6538f7ca565"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("ab8a6089-a6b8-4031-934e-d296f8253fd3"), new Guid("797060c0-3b47-4654-9176-32d719baad69"), new Guid("4c65a245-2631-47ed-a84d-e4699e9a997c") },
                    { new Guid("ad8b55a9-c949-469f-956a-5624ecb7f577"), new Guid("57597b92-2b9d-422e-b0a7-9b11326c879b"), new Guid("9503b07f-c97a-49e7-b177-97e3a293dc31") },
                    { new Guid("aec9b965-2433-4bf0-ac3d-0f01775a6a75"), new Guid("b8d20577-6c4c-4bd7-a1b1-b58bb4914541"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("afed64e4-db23-4f41-9519-6570621c0b30"), new Guid("65141fc2-760f-4866-86c5-08cc764cabac"), new Guid("9503b07f-c97a-49e7-b177-97e3a293dc31") },
                    { new Guid("b12ca17b-650c-4fbb-84a3-10057f365551"), new Guid("e2ce0a01-9d10-4133-a989-618739aa3854"), new Guid("302d7e19-c80f-4e1a-8877-3e9b17f9baeb") },
                    { new Guid("b246f291-1cb3-42fc-904c-fdca50162d28"), new Guid("b8d20577-6c4c-4bd7-a1b1-b58bb4914541"), new Guid("9503b07f-c97a-49e7-b177-97e3a293dc31") },
                    { new Guid("b27c172f-99b0-4441-a3a4-d499e302d509"), new Guid("c7b863af-0565-4bec-9238-9383272637ef"), new Guid("9503b07f-c97a-49e7-b177-97e3a293dc31") },
                    { new Guid("b2a8ec2b-61da-45fd-b98f-6b32d0ccf331"), new Guid("3e1f065a-c135-4429-941e-d870886b4147"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("b3e5aec3-aee3-41a6-a797-e56c87d2f920"), new Guid("70873440-0058-4669-aa74-352489f9e6da"), new Guid("54d48566-0e56-4e41-a2c6-35f71d9e35fe") },
                    { new Guid("b460f29d-8f45-4d10-9529-145c54287a6f"), new Guid("cb68ce1c-c741-41df-a1c9-8ce34529b421"), new Guid("302d7e19-c80f-4e1a-8877-3e9b17f9baeb") },
                    { new Guid("b681073b-3a8a-469e-8d03-db44364f0557"), new Guid("3a346f18-1781-408b-bc8d-2f8e4cbc64ea"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("b6d1bfd8-38e9-4365-936d-ed3c6c09b357"), new Guid("5aebacd6-b4d5-4839-b2f0-533ff3329941"), new Guid("529cd044-c4fe-4c50-8748-080584a48d12") },
                    { new Guid("bad63cda-47c7-45ef-867c-c271c48b2e13"), new Guid("b9ec9be8-e1f2-49d6-b461-b61872bb369c"), new Guid("f74ca29a-e9bc-4111-94d7-ebe5beccd72c") },
                    { new Guid("bc9d7be6-2e7e-4b7c-9859-b8047ce7ef81"), new Guid("7e889af8-0f19-44ab-96d4-241fd64fbcdb"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("c2535359-45dd-458c-9b5a-bf7991047d9b"), new Guid("170a9aef-a708-41a4-8370-a8526f2c055f"), new Guid("9503b07f-c97a-49e7-b177-97e3a293dc31") },
                    { new Guid("c3d9032b-5b1b-4c67-9267-fcf6a890a660"), new Guid("9519622d-50f0-4a8d-8728-c58c12255b6f"), new Guid("3afdf0a8-2504-4436-8483-2b9566b881f2") },
                    { new Guid("c3fc77db-1764-4453-a6e9-6f85ef5fde66"), new Guid("3e1f065a-c135-4429-941e-d870886b4147"), new Guid("9503b07f-c97a-49e7-b177-97e3a293dc31") },
                    { new Guid("c549c18b-8e40-4196-b6d7-ff9c9cb516ba"), new Guid("5d8e3050-5444-4709-afc3-18a8d46a71ba"), new Guid("302d7e19-c80f-4e1a-8877-3e9b17f9baeb") },
                    { new Guid("c55962cf-5967-4d67-a1a6-b2d1a856930b"), new Guid("33b14253-7c02-4b79-8490-c8ed10312230"), new Guid("9503b07f-c97a-49e7-b177-97e3a293dc31") },
                    { new Guid("c5e74bb8-c08b-4498-baad-11ce59564015"), new Guid("dac8cec6-c84d-4287-b0b9-71f4cf304c7e"), new Guid("34cc1d82-002a-4c8c-b783-e46d9c88dde5") },
                    { new Guid("c7585125-4dbc-4b56-aa3a-422a96ade9fb"), new Guid("950d59d6-d94c-4396-a55e-cbcd2a9b533c"), new Guid("302d7e19-c80f-4e1a-8877-3e9b17f9baeb") },
                    { new Guid("c8f40af2-f3b9-40de-ab83-dd5e74962bfb"), new Guid("5aebacd6-b4d5-4839-b2f0-533ff3329941"), new Guid("b99b8260-8eb2-4a30-8d59-2f251a83e68c") },
                    { new Guid("ca9c9fa1-182d-416f-af3c-53b470edbbaa"), new Guid("baaa533a-cb1a-46e7-bb9e-79d631affc87"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("cbc029ee-c8f0-493a-b9e7-837420e76734"), new Guid("321e1615-6328-4532-85ac-22d53d59c164"), new Guid("54d48566-0e56-4e41-a2c6-35f71d9e35fe") },
                    { new Guid("ce7a5f4b-071f-4c3e-af81-758a1b918c39"), new Guid("604e9548-9b99-4bd4-ab90-4bf90b4a1807"), new Guid("2139e644-a9fa-49ce-8eea-7380e7936527") },
                    { new Guid("d194cd94-eb02-471e-900c-2f298405b7c5"), new Guid("9268835d-553d-4fbe-a0cb-0545b8019c68"), new Guid("9503b07f-c97a-49e7-b177-97e3a293dc31") },
                    { new Guid("d49cfbc4-2c58-4d27-b68c-6ead4192affc"), new Guid("cb68ce1c-c741-41df-a1c9-8ce34529b421"), new Guid("9503b07f-c97a-49e7-b177-97e3a293dc31") },
                    { new Guid("d6550af5-7e26-49cc-b9bb-65ddfe9ccd67"), new Guid("e4b3e286-3589-49de-892b-d0d06e719115"), new Guid("6c939d6c-0461-46c8-b9b6-83021b68df71") },
                    { new Guid("d6846cf7-bca1-48d3-b78d-188d94e2f80a"), new Guid("5aebacd6-b4d5-4839-b2f0-533ff3329941"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("dc2ed602-baa8-4a9e-8f38-b1cf40d5bb59"), new Guid("57597b92-2b9d-422e-b0a7-9b11326c879b"), new Guid("302d7e19-c80f-4e1a-8877-3e9b17f9baeb") },
                    { new Guid("dd0ea6e1-0684-4a1e-b143-37bdb1ba7c5a"), new Guid("136c7569-601c-4f16-9ca4-bd14bfa8c16a"), new Guid("e0a5af2c-cb45-40da-90d7-7ba59c662bcb") },
                    { new Guid("dd4ff481-d8d3-410d-ad32-e39cf572071d"), new Guid("5d8e3050-5444-4709-afc3-18a8d46a71ba"), new Guid("9503b07f-c97a-49e7-b177-97e3a293dc31") },
                    { new Guid("e19e6158-1b33-4f1b-9757-6b50f180f007"), new Guid("ba078388-eedf-4ccb-af5f-3f686f4ece4a"), new Guid("bcc08307-a922-4de1-aa17-8ff9dc438425") },
                    { new Guid("e219d7a3-c5d4-4f54-a275-75c5bc9df4cb"), new Guid("170a9aef-a708-41a4-8370-a8526f2c055f"), new Guid("302d7e19-c80f-4e1a-8877-3e9b17f9baeb") },
                    { new Guid("e33ba004-f85b-4714-a381-ee25fafd52f0"), new Guid("13f235b7-a6f6-4da4-83a1-13b5af26700a"), new Guid("9503b07f-c97a-49e7-b177-97e3a293dc31") },
                    { new Guid("e3566a06-d006-4937-9bb5-90eade9d2bac"), new Guid("3e24ec11-86a4-4db8-9337-35a00988da7d"), new Guid("9503b07f-c97a-49e7-b177-97e3a293dc31") },
                    { new Guid("e71cb8fe-52b0-4e6e-b344-0e5631996192"), new Guid("2fa2ff6a-9a8b-4a2d-b0e4-6e7e14679236"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("e86d098a-4561-40b9-83e0-d35612ecfafe"), new Guid("65141fc2-760f-4866-86c5-08cc764cabac"), new Guid("47ea1951-5508-4647-a805-138a861974ff") },
                    { new Guid("e9e871d8-2a97-4117-bdd3-99a28be03cad"), new Guid("5c3b0099-2a8a-49a5-8c68-d24ebc9fac07"), new Guid("8e8ec992-5b4b-43d9-b290-73fbfcd8a32e") },
                    { new Guid("eb0ca62c-bf7c-40c8-946d-fadfd107cffb"), new Guid("296270ec-026b-4011-83ff-1466ba577864"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("eeb9e776-c05e-499f-ad3d-49dd23a8f1e1"), new Guid("3a346f18-1781-408b-bc8d-2f8e4cbc64ea"), new Guid("9503b07f-c97a-49e7-b177-97e3a293dc31") },
                    { new Guid("f075a7a6-561f-4cdf-b71e-dd7a1f8f960f"), new Guid("6c5fe2d4-8547-4fb0-8966-d148f8d77af7"), new Guid("9503b07f-c97a-49e7-b177-97e3a293dc31") },
                    { new Guid("f0c920e4-64c9-4b1f-b3ce-780a1d0c34b3"), new Guid("2fa2ff6a-9a8b-4a2d-b0e4-6e7e14679236"), new Guid("2e2cf727-d007-4293-8f2c-f8e54baf06ce") },
                    { new Guid("f28044d3-15c7-4bee-9b92-8b418e03a191"), new Guid("e16286a8-78a9-4b86-ba4b-c844f7099336"), new Guid("9503b07f-c97a-49e7-b177-97e3a293dc31") },
                    { new Guid("f534eefe-6616-4631-8354-c8e86140632b"), new Guid("e023416d-7d91-4d92-bd5f-37d57c54f6b4"), new Guid("b99b8260-8eb2-4a30-8d59-2f251a83e68c") },
                    { new Guid("f603da29-65c5-4713-80bd-ec8023b9c94d"), new Guid("454f4f08-58cf-4ab7-9012-1e5ba663570c"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("f60c2ec2-8e72-462f-8144-987d9ba37751"), new Guid("57597b92-2b9d-422e-b0a7-9b11326c879b"), new Guid("d57fa572-a720-432c-a372-b8ade1a7edff") },
                    { new Guid("f739b571-d14b-4366-8c75-4b39aadd24f7"), new Guid("136c7569-601c-4f16-9ca4-bd14bfa8c16a"), new Guid("302d7e19-c80f-4e1a-8877-3e9b17f9baeb") },
                    { new Guid("fa9322b8-0640-43ea-847f-4a05bf1b160d"), new Guid("cc29eb91-2efb-4d57-8d14-bb5356cbfbb8"), new Guid("302d7e19-c80f-4e1a-8877-3e9b17f9baeb") },
                    { new Guid("faddd74b-9234-4412-be8c-74b05ce04dc7"), new Guid("1994c4bc-aeb9-4242-81df-5bafffca6fd0"), new Guid("4aaeef66-ae04-4d75-8920-72fb30031c53") },
                    { new Guid("fc69d2fa-df60-45d6-8e79-41105f488cbf"), new Guid("e023416d-7d91-4d92-bd5f-37d57c54f6b4"), new Guid("529cd044-c4fe-4c50-8748-080584a48d12") },
                    { new Guid("fd0b4b8f-5731-4e4f-a96b-f80093af1630"), new Guid("31252741-4d0b-448f-b85c-d6538f7ca565"), new Guid("9503b07f-c97a-49e7-b177-97e3a293dc31") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_editor_settings",
                columns: new[] { "id", "is_required", "name_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("02333a48-69aa-4492-a33f-3ac9324d3970"), false, "//footer[@class='news-item__footer']/div[@class='news-item__footer-after-news']/p[position()=1]//span/text()", new Guid("8c399ef5-9d29-4442-a621-52867b8e7f6d") },
                    { new Guid("0f72771a-3c4e-4a38-9ab5-fe96f01728af"), false, "//meta[@property='author']/@content", new Guid("fa16a108-45c2-42e4-8323-b1f3ea3cdf46") },
                    { new Guid("0f7f9888-b12e-48cc-931c-8380d9e8e7e4"), false, "//meta[@property='article:author']/@content", new Guid("6d16ec92-860e-4bd8-9618-1e5b2ac5a792") },
                    { new Guid("118e708c-8b15-496c-bffd-1f30c5679ba8"), false, "//section[contains(@class, '_page-section')]//div[contains(@class, '_bottom-info_')]//span[contains(@class, '_user-info__name_')]/text()", new Guid("be3e061e-25f4-4b43-a9f6-45db165b6000") },
                    { new Guid("17461131-afc7-41bd-af3b-0f2cda2dd935"), false, "//div[@class='article_top']//div[@class='authors']//div[@class='autor']//span/text()", new Guid("e8ea5810-3cc4-46dd-84d7-eb7b5cbf3f3b") },
                    { new Guid("20786554-85aa-42a5-80f3-953dccb09f55"), false, "//meta[@name='author']/@content", new Guid("aed24362-5c8e-4b31-9bbe-bb068f9c0f01") },
                    { new Guid("325ee59a-478b-4ea2-991b-06c65c269bbe"), false, "//div[@class='container-fluid publication-footer']//a[contains(@class, 'text-secondary')]/@title", new Guid("f1b027fc-2809-4eaa-9858-c49a8756852f") },
                    { new Guid("39793598-0239-4802-87f3-f04d404eee1c"), false, "//p[@class='doc__text document_authors']/text()", new Guid("efd9bf27-abb2-46c2-bedb-dc7e745e55fb") },
                    { new Guid("3dc22c77-8081-46cf-b981-fb88b2bfcece"), false, "//meta[@property='article:author']/@content", new Guid("dd419d1c-db40-4fd4-8f12-34206242d7cc") },
                    { new Guid("4664ca50-bfde-4200-a8eb-af35872e79dd"), false, "//meta[@property='article:author']/@content", new Guid("052241f9-e3e7-4722-9f56-7202de4a331e") },
                    { new Guid("47aebca8-87d6-4241-81c5-a65b23518f8a"), false, "//article//header//div[@class='b-authors']/div[@class='b-author' and position()=1]//text()", new Guid("68faffa0-b7e6-44bb-a958-441eb532bfbb") },
                    { new Guid("48a9b834-59bb-4398-8526-318c506c58eb"), false, "//span[@itemprop='name']/a/text()", new Guid("3c4ef27a-3157-4eff-a441-1e409c4b6c34") },
                    { new Guid("4b846398-fc4c-4c1f-adac-2bc61fea6752"), false, "//div[@class='preview__author-block']//div[@class='author__about']/a[@itemprop='name']/@content", new Guid("e3fcdd00-2152-4d84-8f8c-bf70e4996990") },
                    { new Guid("502c8f33-a803-4578-83b9-a024d2b92510"), false, "//meta[@name='author']/@content", new Guid("2de49bdd-5c36-49ff-9a3b-a1f6ceb75e75") },
                    { new Guid("5b0a65b8-54c9-432e-8962-d3016e02c01e"), false, "//meta[@name='article:author']/@content", new Guid("5726d5dd-18ac-4c5c-a5d1-f775f1dd0b20") },
                    { new Guid("5e370949-45e8-4537-8855-cba4ecc363b4"), false, "//a[@class='article__author']/text()", new Guid("4c29ab0b-01eb-466e-8dc3-fe05886f4332") },
                    { new Guid("62ed2534-e043-4f4d-a1ac-b9be0a4d9bbd"), false, "//div[@class='article__content']//strong[text()='Автор:']/../text()", new Guid("611bd50e-69f5-4598-8ad6-8b19771f1044") },
                    { new Guid("6718a708-10eb-4943-be1b-5be29565414f"), false, "//div[@class='topic-authors']/a[@class='topic-authors__author']/text()", new Guid("a39fd0cf-d695-451a-8ec5-b662eddf4e9e") },
                    { new Guid("6d70075b-0b7b-4da3-8e5b-a312f268a3a9"), false, "//div[@itemprop='author']/span[@itemprop='name']/text()", new Guid("d477dceb-5655-432b-8bca-b2ca2d944d87") },
                    { new Guid("6ef19113-6578-47ed-93c8-b2b61cd13d08"), false, "//div[contains(@class, 'styled__StoryInfoAuthors')]/div[contains(@class, 'styled__InfoAuthor')]//span[contains(@class, 'styled__AuthorName')]/text()", new Guid("2d46f779-c13c-4699-9460-629e254a6444") },
                    { new Guid("73e2d740-d23b-44d5-b0a4-634da72f0daf"), false, "//span[@class='author']/a/text()", new Guid("613dbfcf-7f5c-4060-a92a-d2ec7586f4a3") },
                    { new Guid("7a85f179-0e73-4d6e-9792-5d93a47e0484"), false, "//article//span[@class='author']/a[@class='authorName']/span/text()", new Guid("f63d1e4f-e82d-4020-8b9c-65beaab1d7c3") },
                    { new Guid("8e018d32-828c-478d-a19f-8a06fd1fa797"), false, "//div[contains(@class, 'PageArticleContent_authors')]//a[contains(@class, 'LinksOfAuthor_item')]/text()", new Guid("52014d82-bd2b-47fb-9ba1-668df2126197") },
                    { new Guid("8f7062f8-e5f9-429b-900f-98412ea04f84"), false, "//div[@class='GeneralMaterial-module-materialHeader']//div[contains(@class, 'MetaItem-module_hasSource') and not(time)]/text()", new Guid("6a7db6d7-c4ec-471c-93e2-9f7b9dd9180c") },
                    { new Guid("91108b0c-0f51-4946-b639-e9b8e67c48b9"), false, "//div[@class='author']/span[@itemprop='author']/span[@itemprop='name']/a/text()", new Guid("60a60886-4da0-4c2c-8635-a8ec57827667") },
                    { new Guid("9a6e6c25-1720-4eea-b8df-2195d32dfb46"), false, "//div[@class='article__authors']//*[@class='article__authors__author']/span[@class='article__authors__author__name']/text()", new Guid("929687ee-eb6f-4e95-852d-9635657d7f89") },
                    { new Guid("9dc5c8f6-835a-44c5-bb98-2d988cd7001d"), false, "//div[@class='newsDetail-body__item-header']/a[contains(@class, 'newsDetail-person')]//p[contains(@class, 'newsDetail-person__info-name')]/text()", new Guid("a03ca9fd-6e2d-4da5-9017-5feb6a9a1404") },
                    { new Guid("a5a0d928-4db3-49a7-8a52-2ba8d93fd651"), false, "//meta[@name='mediator_author']/@content", new Guid("44d47f91-a811-4cc3-a70f-f12236d1476d") },
                    { new Guid("a7340062-15ee-4ea9-b6c5-1ea46f299c49"), false, "//div[@class='blog-post-info']//div[@itemprop='author']//span[@itemprop='name']/text()", new Guid("52ac2f5a-3b95-4adc-9c2a-abd192a1ec26") },
                    { new Guid("b6c8fbce-f0fa-4d28-b166-8ee9efb9f04f"), false, "//meta[@property='ajur:article:authors']/@content", new Guid("d36d75dc-add7-4e21-8a31-2f40f4033b14") },
                    { new Guid("c89266cc-1f5c-4839-8b7c-e86ba789c36d"), false, "//div[@id='content']//div[contains(@class, 'topic')]/ul[contains(@class, 'blog_more')]//li[@class='author']//text()", new Guid("289bab5a-8dd4-4ca7-a510-ff6a496b3993") },
                    { new Guid("c8b007a9-e3db-4231-9a5f-5aa3f103e49a"), false, "//article/p[@class='author']/text()", new Guid("a1b03754-30d4-4c65-946d-10995830a159") },
                    { new Guid("cae0e909-1bff-4b11-8c86-70eff32fa743"), false, "//div[contains(@class, 'styles_bodyWrapper')]//div[contains(@class, 'styles_authorsLinks')]/a/text()", new Guid("3373c5b8-57e2-402b-9dfb-a0ae19e92336") },
                    { new Guid("ce13e4cd-82df-4d2b-87e1-9256c5ef8c7c"), false, "//div[@itemprop='author']//p[@itemprop='name']/text()", new Guid("e4542056-2c68-43c6-a85c-9e4899556800") },
                    { new Guid("d553ac3d-a4af-4359-9e9b-802bf0c62bcc"), false, "//meta[@property='article:author']/@content", new Guid("9de1ef08-878b-4559-85af-a8b14d7ce68b") },
                    { new Guid("d577c838-8fed-45ba-850b-18bf437c06f3"), false, "//meta[@property='article:author']/@content", new Guid("32cad97f-b071-4e24-bdc9-10e5e58cf99b") },
                    { new Guid("dd3601cc-4a2c-480f-9860-9f5183d8c67a"), false, "//meta[@name='author']/@content", new Guid("49c1bb0c-b546-4142-a7ba-4925f71a933c") },
                    { new Guid("e1a6a4f1-57ab-48e6-aaee-b9ece2104cf3"), false, "//meta[@name='mediator_author']/@content", new Guid("da641510-f1dd-4fce-b895-cbf32dca79bf") },
                    { new Guid("e70fb7e3-35e6-4afa-ace8-b93a95bf5121"), false, "//div[@class='article__announce-authors']/a[@itemprop='author']/span[@itemprop='name']/text()", new Guid("a7d88817-12e6-434a-8c25-949dde2609f4") },
                    { new Guid("f28a4798-e796-400d-ab07-ddb5bb21be43"), false, "//*[@itemprop='author']/*[@itemprop='name']//text()", new Guid("921d7c0a-c084-4188-b243-d08580f65142") },
                    { new Guid("f6679100-82e3-4e0d-98a9-de90246ccf3a"), false, "//span[@itemprop='author']/span[@itemprop='name']/@content", new Guid("96ef6e5b-c81b-45e7-a715-1aa131d82ef2") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_modified_at_settings",
                columns: new[] { "id", "is_required", "modified_at_culture_info", "modified_at_time_zone_info_id", "modified_at_x_path", "parse_settings_id" },
                values: new object[,]
                {
                    { new Guid("033e507a-cb9d-403f-a8cb-48238e03607b"), false, "en-US", null, "//meta[@property='article:modified_time']/@content", new Guid("2de49bdd-5c36-49ff-9a3b-a1f6ceb75e75") },
                    { new Guid("0a1fc27b-5f76-4a98-acd2-c3f98852d1c0"), false, "ru-RU", null, "//meta[@itemprop='dateModified']/@content", new Guid("e4542056-2c68-43c6-a85c-9e4899556800") },
                    { new Guid("25fa301c-d896-4a5e-b580-2dba44900fb6"), false, "ru-RU", null, "//meta[@property='article:modified_time']/@content", new Guid("efd9bf27-abb2-46c2-bedb-dc7e745e55fb") },
                    { new Guid("307744f1-4338-481a-b849-b8d88c196cc3"), false, "ru-RU", "UTC", "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark_update')]//span[@ca-ts]/text()", new Guid("28bff881-79f7-400c-ab5d-489176c269bb") },
                    { new Guid("348a6cf9-f469-4f19-a12c-bdc3f525947c"), false, "ru-RU", null, "//meta[@itemprop='dateModified']/@content", new Guid("49c1bb0c-b546-4142-a7ba-4925f71a933c") },
                    { new Guid("350279da-c53a-42a7-abad-a3097a881261"), false, "ru-RU", null, "//meta[@property='article:modified_time']/@content", new Guid("cba88caa-d8af-4e40-b8fa-14946187e939") },
                    { new Guid("39d1b1e4-aa28-41b0-a55a-fffe8e406645"), false, "ru-RU", null, "//meta[@property='article:modified_time']/@content", new Guid("4c29ab0b-01eb-466e-8dc3-fe05886f4332") },
                    { new Guid("3c897305-c4ad-42b1-9cb8-a550d075139c"), false, "ru-RU", "Russian Standard Time", "//meta[@property='article:modified_time']/@content", new Guid("9d11efde-ae9c-42a7-ac57-649bf5891e8a") },
                    { new Guid("458c1359-0212-451f-9c05-a6d043114989"), false, "ru-RU", "Russian Standard Time", "//meta[@property='article:modified_time']/@content", new Guid("dd419d1c-db40-4fd4-8f12-34206242d7cc") },
                    { new Guid("4adf1a9f-ac4c-4f17-932b-aac460d0d2f2"), false, "en-US", null, "//meta[@property='article:modified_time']/@content", new Guid("3c4ef27a-3157-4eff-a441-1e409c4b6c34") },
                    { new Guid("4aeb273b-8983-4ed7-adf0-74ff9bdfb4ab"), false, "ru-RU", "Russian Standard Time", "//meta[@property='article:modified_time']/@content", new Guid("52ac2f5a-3b95-4adc-9c2a-abd192a1ec26") },
                    { new Guid("59699417-64ea-4f42-9573-68a21d4fdbe7"), false, "ru-RU", null, "//meta[@property='article:modified_time']/@content", new Guid("9de1ef08-878b-4559-85af-a8b14d7ce68b") },
                    { new Guid("62afc18d-a34f-4989-8c4c-2a5d7deabf6b"), false, "ru-RU", "Russian Standard Time", "//meta[@property='article:modified_time']/@content", new Guid("77a6c5a1-b883-444f-ba7e-f0289943947f") },
                    { new Guid("6dc53704-3d38-47f9-9efa-7604da400355"), false, "ru-RU", "Russian Standard Time", "//meta[@itemprop='dateModified']/@content", new Guid("692ba156-95b9-4a24-9b0c-71b769e8d3a8") },
                    { new Guid("700ffddc-d0a5-450a-b756-deabd7bfed18"), false, "ru-RU", "Russian Standard Time", "//meta[@property='article:modified_time']/@content", new Guid("76b3ad9b-48c5-4f9e-ab28-993ba795fdb1") },
                    { new Guid("75386858-8fad-48aa-bea8-d5aec36c1f8f"), false, "ru-RU", null, "//meta[@itemprop='dateModified']/@content", new Guid("a7d88817-12e6-434a-8c25-949dde2609f4") },
                    { new Guid("90f502b6-e728-4f0a-b937-c264a9e683fd"), false, "ru-RU", "Russian Standard Time", "//meta[@property='article:modified_time']/@content", new Guid("52014d82-bd2b-47fb-9ba1-668df2126197") },
                    { new Guid("91c40a45-f102-46d4-bd9b-4e11869f18cd"), false, "ru-RU", null, "//meta[@property='article:modified_time']/@content", new Guid("aed24362-5c8e-4b31-9bbe-bb068f9c0f01") },
                    { new Guid("9980ee74-f655-40af-b44e-c9feb0e0bd40"), false, "ru-RU", null, "//meta[@itemprop='dateModified']/@content", new Guid("921d7c0a-c084-4188-b243-d08580f65142") },
                    { new Guid("a62f2d07-0e56-4bdc-a6de-c061d313bea9"), false, "ru-RU", "Russian Standard Time", "//meta[@property='og:updated_time']/@content", new Guid("c965a1d0-83b6-4018-a4a5-9c426a02943e") },
                    { new Guid("b8626e48-242d-48e4-aa30-8ca2936a0d59"), false, "ru-RU", "Russian Standard Time", "//meta[@itemprop='dateModified']/@content", new Guid("5c2d9dff-16d7-47f9-8d32-07f8fb52ac76") },
                    { new Guid("c8cda125-f32f-492a-9d65-c1e0abb69300"), false, "ru-RU", "Russian Standard Time", "//meta[@property='article:modified_time']/@content", new Guid("5726d5dd-18ac-4c5c-a5d1-f775f1dd0b20") },
                    { new Guid("da1fb28b-2afb-461a-9cf2-6e65a9c6963d"), false, "ru-RU", null, "//meta[@property='article:modified_time']/@content", new Guid("11795391-d20d-48df-ab38-30f796737a43") },
                    { new Guid("ffa17401-2b75-485d-a098-da254f125362"), false, "ru-RU", null, "//meta[@itemprop='dateModified']/@content", new Guid("929687ee-eb6f-4e95-852d-9635657d7f89") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_picture_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("09f7efa7-635a-4a7b-9e00-dbee344eaf0a"), false, new Guid("44d47f91-a811-4cc3-a70f-f12236d1476d"), "//meta[@property='og:image']/@content" },
                    { new Guid("0ae45f17-84aa-42b2-801b-ff153d8d99b1"), false, new Guid("52014d82-bd2b-47fb-9ba1-668df2126197"), "//meta[@property='og:image']/@content" },
                    { new Guid("0da669ee-feb9-4403-bc90-9af266fab309"), false, new Guid("5726d5dd-18ac-4c5c-a5d1-f775f1dd0b20"), "//meta[@property='og:image']/@content" },
                    { new Guid("1119d2b6-db6a-4750-8263-9fb0025cc536"), false, new Guid("8c399ef5-9d29-4442-a621-52867b8e7f6d"), "//meta[@property='og:image']/@content" },
                    { new Guid("140c9334-8e52-4c07-a0a2-f4842820af31"), false, new Guid("f1b027fc-2809-4eaa-9858-c49a8756852f"), "//meta[@name='og:image']/@content" },
                    { new Guid("181a1d07-35cc-4e75-9a36-330c319c6590"), false, new Guid("c965a1d0-83b6-4018-a4a5-9c426a02943e"), "//meta[@property='og:image']/@content" },
                    { new Guid("1927aaba-9fb9-4caf-a3f6-1586a082e21a"), false, new Guid("49c1bb0c-b546-4142-a7ba-4925f71a933c"), "//meta[@property='og:image']/@content" },
                    { new Guid("1f4694bc-c0d7-405c-ae73-88053c0ebc14"), false, new Guid("e3fcdd00-2152-4d84-8f8c-bf70e4996990"), "//meta[@property='og:image']/@content" },
                    { new Guid("28112804-6fee-47fe-ad2e-9cdf4e982a82"), false, new Guid("9d11efde-ae9c-42a7-ac57-649bf5891e8a"), "//meta[@property='og:image']/@content" },
                    { new Guid("2b7405f0-8db7-447b-a239-4b8454cba04b"), false, new Guid("289bab5a-8dd4-4ca7-a510-ff6a496b3993"), "//meta[@property='og:image']/@content" },
                    { new Guid("2e408438-34d0-4ec7-9183-f14c49c50ad6"), false, new Guid("052241f9-e3e7-4722-9f56-7202de4a331e"), "//meta[@property='og:image']/@content" },
                    { new Guid("3238cb06-5baa-4d87-a6a7-d3b826c1da59"), false, new Guid("2de49bdd-5c36-49ff-9a3b-a1f6ceb75e75"), "//meta[@property='og:image']/@content" },
                    { new Guid("3291c20c-0487-47a3-a428-fdcb0bdde0b6"), false, new Guid("cba88caa-d8af-4e40-b8fa-14946187e939"), "//meta[@property='og:image']/@content" },
                    { new Guid("375e4eca-f067-486a-a3cd-5045165dd9e1"), false, new Guid("76b3ad9b-48c5-4f9e-ab28-993ba795fdb1"), "//meta[@property='og:image']/@content" },
                    { new Guid("3b81d060-ce40-45bb-8ceb-81c10e88e2a8"), false, new Guid("da641510-f1dd-4fce-b895-cbf32dca79bf"), "//meta[@property='og:image']/@content" },
                    { new Guid("48dd42bd-47ea-4a97-aeff-bb84db84e6b2"), false, new Guid("aed24362-5c8e-4b31-9bbe-bb068f9c0f01"), "//meta[@property='og:image']/@content" },
                    { new Guid("515be790-404d-48ca-8d97-642a505b2149"), false, new Guid("5c2d9dff-16d7-47f9-8d32-07f8fb52ac76"), "//meta[@property='og:image']/@content" },
                    { new Guid("64c04564-82ae-449f-9264-840c277b648c"), false, new Guid("e4542056-2c68-43c6-a85c-9e4899556800"), "//meta[@property='og:image']/@content" },
                    { new Guid("679b3f84-a212-422b-a41d-3544ae6c997a"), false, new Guid("2d46f779-c13c-4699-9460-629e254a6444"), "//meta[@name='og:image']/@content" },
                    { new Guid("6d23a40c-508d-4914-9c4e-4ca0e9db1985"), false, new Guid("6d16ec92-860e-4bd8-9618-1e5b2ac5a792"), "//meta[@property='og:image']/@content" },
                    { new Guid("6f3531a6-db42-459a-ab24-08493edc3ac0"), false, new Guid("611bd50e-69f5-4598-8ad6-8b19771f1044"), "//meta[@property='og:image']/@content" },
                    { new Guid("784347e1-cdbd-42dc-a71e-c0bf6dc1bd60"), false, new Guid("3373c5b8-57e2-402b-9dfb-a0ae19e92336"), "//meta[@property='og:image']/@content" },
                    { new Guid("7ab23797-333a-428f-a8c2-620267ac2310"), false, new Guid("929687ee-eb6f-4e95-852d-9635657d7f89"), "//meta[@itemprop='url']/@content" },
                    { new Guid("7bf75c22-3ba4-42df-987a-468cbae9d132"), false, new Guid("96ef6e5b-c81b-45e7-a715-1aa131d82ef2"), "//meta[@property='og:image']/@content" },
                    { new Guid("7c9e261c-a090-44f1-92b8-e4d0e6b1d9b5"), false, new Guid("efd9bf27-abb2-46c2-bedb-dc7e745e55fb"), "//meta[@property='og:image']/@content" },
                    { new Guid("7d69c14b-403d-4216-ac58-f66c87bee0c8"), false, new Guid("f63d1e4f-e82d-4020-8b9c-65beaab1d7c3"), "//meta[@property='og:image']/@content" },
                    { new Guid("7e8d5e93-0edd-4054-8d1b-86b738bca16b"), false, new Guid("f6ef6598-401b-4cd8-8654-f3009b41593f"), "//meta[@property='og:image']/@content" },
                    { new Guid("84f20ff4-fb12-45de-b7de-e9d7844f6935"), false, new Guid("a7d88817-12e6-434a-8c25-949dde2609f4"), "//meta[@property='og:image']/@content" },
                    { new Guid("86d081ed-0909-49c3-98fe-324f17415c27"), false, new Guid("a1b03754-30d4-4c65-946d-10995830a159"), "//meta[@property='og:image']/@content" },
                    { new Guid("8dfefc74-7200-46f5-94be-3fe0efa0894c"), false, new Guid("9de1ef08-878b-4559-85af-a8b14d7ce68b"), "//meta[@property='og:image']/@content" },
                    { new Guid("99e62b88-dd05-4581-a2e1-eb1f2616a05f"), false, new Guid("a03ca9fd-6e2d-4da5-9017-5feb6a9a1404"), "//meta[@property='og:image']/@content" },
                    { new Guid("9fcdbc5c-80af-454f-84f8-a8411f6b0184"), false, new Guid("52ac2f5a-3b95-4adc-9c2a-abd192a1ec26"), "//meta[@property='og:image']/@content" },
                    { new Guid("a6d5c07c-a1a6-4b00-9b58-babe896712fb"), false, new Guid("fa16a108-45c2-42e4-8323-b1f3ea3cdf46"), "//meta[@property='og:image']/@content" },
                    { new Guid("a8742001-52bb-4beb-852c-913eff64dceb"), false, new Guid("3c4ef27a-3157-4eff-a441-1e409c4b6c34"), "//meta[@property='og:image']/@content" },
                    { new Guid("ac6a9a56-dada-4c70-b614-1b8fa635a812"), false, new Guid("68faffa0-b7e6-44bb-a958-441eb532bfbb"), "//meta[@property='og:image']/@content" },
                    { new Guid("afb5bb1e-5cb0-4176-b2e0-99f6efb399dd"), false, new Guid("28bff881-79f7-400c-ab5d-489176c269bb"), "//meta[@property='og:image']/@content" },
                    { new Guid("b1ce7387-38c3-475c-a085-0984b9ba8b00"), false, new Guid("dd419d1c-db40-4fd4-8f12-34206242d7cc"), "//meta[@property='og:image']/@content" },
                    { new Guid("b28db8a4-5df8-4f99-9d5e-7013a3d053c8"), false, new Guid("11795391-d20d-48df-ab38-30f796737a43"), "//meta[@property='og:image']/@content" },
                    { new Guid("b9639099-40e4-4346-93ed-1aa69d2fd95c"), false, new Guid("d36d75dc-add7-4e21-8a31-2f40f4033b14"), "//meta[@property='og:image']/@content" },
                    { new Guid("baa19068-8f2f-445e-8450-27967074fac5"), false, new Guid("921d7c0a-c084-4188-b243-d08580f65142"), "//meta[@property='og:image']/@content" },
                    { new Guid("bb45ff0a-06f3-46ea-9921-c4f45270334e"), false, new Guid("4c29ab0b-01eb-466e-8dc3-fe05886f4332"), "//meta[@property='og:image']/@content" },
                    { new Guid("bf4cfe59-066b-4d7c-ab2c-ca2690648826"), false, new Guid("be3e061e-25f4-4b43-a9f6-45db165b6000"), "//meta[@property='og:image']/@content" },
                    { new Guid("c8d55c4c-0a8b-4133-b85d-6ca0df5a5671"), false, new Guid("e8ea5810-3cc4-46dd-84d7-eb7b5cbf3f3b"), "//meta[@property='og:image']/@content" },
                    { new Guid("c9ff2c75-e65b-4fb4-a3a0-789c15973fac"), false, new Guid("60a60886-4da0-4c2c-8635-a8ec57827667"), "//meta[@property='og:image']/@content" },
                    { new Guid("d5de3a68-32d4-4553-ae39-ad3eb1509cc5"), false, new Guid("a39fd0cf-d695-451a-8ec5-b662eddf4e9e"), "//meta[@property='og:image']/@content" },
                    { new Guid("d8dc9296-e936-406b-aad9-916f05f1b3fe"), false, new Guid("6a7db6d7-c4ec-471c-93e2-9f7b9dd9180c"), "//meta[@property='og:image']/@content" },
                    { new Guid("da259816-c238-4a5e-af4b-be606546572f"), false, new Guid("613dbfcf-7f5c-4060-a92a-d2ec7586f4a3"), "//meta[@property='og:image']/@content" },
                    { new Guid("e8ae178c-a3c7-4ec4-8af8-d1431ef0b1a5"), false, new Guid("77a6c5a1-b883-444f-ba7e-f0289943947f"), "//meta[@property='og:image']/@content" },
                    { new Guid("e9c5bd35-588d-49c8-b0d0-3eda43d0afea"), false, new Guid("14db83c2-cee9-47a2-b8fc-210bbbd399aa"), "//meta[@property='og:image']/@content" },
                    { new Guid("efc3e79b-1827-40e8-a072-7f1cac6e991b"), false, new Guid("692ba156-95b9-4a24-9b0c-71b769e8d3a8"), "//meta[@property='og:image']/@content" },
                    { new Guid("f30aba5c-0d63-4f7b-9f68-1dc1629cd449"), false, new Guid("32cad97f-b071-4e24-bdc9-10e5e58cf99b"), "//meta[@property='og:image']/@content" },
                    { new Guid("fc8fc0b9-ccd3-4dcf-9b07-1e7031097188"), false, new Guid("d477dceb-5655-432b-8bca-b2ca2d944d87"), "//meta[@property='og:image']/@content" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "published_at_culture_info", "published_at_time_zone_info_id", "published_at_x_path" },
                values: new object[,]
                {
                    { new Guid("00106a66-61a0-4abd-b58e-9f9b4ed2c07d"), true, new Guid("9de1ef08-878b-4559-85af-a8b14d7ce68b"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("076e2817-f0e0-4f4a-ae55-08210a7e1a7d"), true, new Guid("28bff881-79f7-400c-ab5d-489176c269bb"), "ru-RU", "UTC", "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark')]//span[@ca-ts]/text()" },
                    { new Guid("0cea5575-ec4f-4b14-a0cc-49185e1d1768"), true, new Guid("cba88caa-d8af-4e40-b8fa-14946187e939"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("1fe09b4f-73bd-4979-8206-439489299a64"), true, new Guid("2de49bdd-5c36-49ff-9a3b-a1f6ceb75e75"), "en-US", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("20903a2a-fdf2-4909-8478-bbfd57c492be"), true, new Guid("77a6c5a1-b883-444f-ba7e-f0289943947f"), "ru-RU", "Russian Standard Time", "//meta[@property='article:published_time']/@content" },
                    { new Guid("21890de7-31ad-4c9e-a749-05f565d45905"), true, new Guid("e8ea5810-3cc4-46dd-84d7-eb7b5cbf3f3b"), "ru-RU", "Russian Standard Time", "//div[@class='article_top']//div[@class='date']//time/text()" },
                    { new Guid("22c82c40-fe3a-4394-ab34-295e3c094dcf"), true, new Guid("289bab5a-8dd4-4ca7-a510-ff6a496b3993"), "ru-RU", "Russian Standard Time", "//div[@id='content']//div[contains(@class, 'topic')]/ul[contains(@class, 'blog_more')]//li[@class='date']/text()" },
                    { new Guid("2622b86a-c47b-4143-a11e-f2aad18faa8e"), false, new Guid("f1b027fc-2809-4eaa-9858-c49a8756852f"), "ru-RU", "Russian Standard Time", "//div[contains(@class, 'pubdatetime')]//div[contains(@class, 'badge-time')]//text()" },
                    { new Guid("3785f3c0-c9d3-4e29-a0b8-46fa78983506"), true, new Guid("dd419d1c-db40-4fd4-8f12-34206242d7cc"), "ru-RU", "Russian Standard Time", "//meta[@property='article:published_time']/@content" },
                    { new Guid("3f29a12c-5e1c-45de-bf8b-96897f8ac962"), true, new Guid("d477dceb-5655-432b-8bca-b2ca2d944d87"), "ru-RU", null, "//div[@class='publication-info']/time[@itemprop='datePublished']/@datetime" },
                    { new Guid("47328c5f-5e86-4b2d-be25-fe9198a946fc"), true, new Guid("efd9bf27-abb2-46c2-bedb-dc7e745e55fb"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("4a335cad-bc2f-442e-9c89-74da04bbde90"), true, new Guid("3373c5b8-57e2-402b-9dfb-a0ae19e92336"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("4a6be1f2-8429-4185-a9c6-03aeda076dcd"), true, new Guid("f6ef6598-401b-4cd8-8654-f3009b41593f"), "ru-RU", "Russian Standard Time", "//p[@class='b-material__date']/text()" },
                    { new Guid("5c23cab5-7864-429b-9080-ba88f81c6751"), true, new Guid("f63d1e4f-e82d-4020-8b9c-65beaab1d7c3"), "en-US", "Central Europe Standard Time", "//article//div[@class='article-info']/div[@class='date']/text()" },
                    { new Guid("5e7874b1-13e9-4cf5-a96a-6612fe3661cf"), true, new Guid("6a7db6d7-c4ec-471c-93e2-9f7b9dd9180c"), "ru-RU", "UTC", "//div[@class='GeneralMaterial-module-materialHeader']//div[contains(@class, 'MetaItem-module_datetime')]/time/text()" },
                    { new Guid("6f87ed33-a16c-465a-8784-33c69ef9bb0c"), true, new Guid("929687ee-eb6f-4e95-852d-9635657d7f89"), "ru-RU", null, "//div[@class='article__header__info-block']/time[@class='article__header__date']/@datetime" },
                    { new Guid("79e88ebb-d542-4d19-a212-6c21f2688c77"), true, new Guid("e4542056-2c68-43c6-a85c-9e4899556800"), "ru-RU", null, "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("80bc5b20-336c-4ac1-9ee0-e231d0ef74c7"), true, new Guid("6d16ec92-860e-4bd8-9618-1e5b2ac5a792"), "ru-RU", "Russian Standard Time", "//span[@id='publication-date']/text()" },
                    { new Guid("8208ff9e-fbf8-4206-b4d8-e7f7287b2dec"), true, new Guid("613dbfcf-7f5c-4060-a92a-d2ec7586f4a3"), "ru-RU", "Russian Standard Time", "//span[@class='date']/time/@datetime" },
                    { new Guid("82ed5673-25e2-497f-aaea-3dd42ecd4f85"), true, new Guid("44d47f91-a811-4cc3-a70f-f12236d1476d"), "ru-RU", null, "//div[contains(@class, 'article-entry')]//div[@class='entry-info']/span[@itemprop='datePublished']/@content" },
                    { new Guid("89fc1310-fff8-4cdc-aff5-c4285f9ab73c"), true, new Guid("68faffa0-b7e6-44bb-a958-441eb532bfbb"), "ru-RU", "Russian Standard Time", "//div[@class='b-text__date']/text()" },
                    { new Guid("8bf5f85a-aba6-48a5-8704-3f6c4f51d9d1"), true, new Guid("32cad97f-b071-4e24-bdc9-10e5e58cf99b"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("8ff05689-5c68-4f41-9023-4bfead386fed"), true, new Guid("c965a1d0-83b6-4018-a4a5-9c426a02943e"), "ru-RU", "Russian Standard Time", "//span[@class='submitted-by']/text()" },
                    { new Guid("9bfd49d6-dcb9-4a65-80f5-c9ac3b6b490d"), true, new Guid("692ba156-95b9-4a24-9b0c-71b769e8d3a8"), "ru-RU", "Russian Standard Time", "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("a17cf1af-be32-4074-9b36-6f5481ecbf14"), true, new Guid("da641510-f1dd-4fce-b895-cbf32dca79bf"), "ru-RU", null, "//meta[@name='mediator_published_time']/@content" },
                    { new Guid("a2c411a5-4b6a-4ed8-b383-b1a4f05b4605"), true, new Guid("aed24362-5c8e-4b31-9bbe-bb068f9c0f01"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("a4130bc3-4c5f-451f-92f1-73e1c1745fc6"), true, new Guid("4c29ab0b-01eb-466e-8dc3-fe05886f4332"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("a5685486-3a98-45aa-96b7-d25cd5e40c5d"), true, new Guid("052241f9-e3e7-4722-9f56-7202de4a331e"), "ru-RU", "Russian Standard Time", "//article//header//time[@class='article-head__date']/text()" },
                    { new Guid("b208c066-da95-4c32-baec-ff448a07f62d"), true, new Guid("60a60886-4da0-4c2c-8635-a8ec57827667"), "ru-RU", null, "//meta[@itemprop='dateModified']/@content" },
                    { new Guid("b2514b4f-e07a-44e1-977b-9013bd07ea0c"), true, new Guid("a39fd0cf-d695-451a-8ec5-b662eddf4e9e"), "ru-RU", "Russian Standard Time", "//div[@class='topic-page__header']//a[contains(@class, 'topic-header__time')]/text()" },
                    { new Guid("b5afbf6f-9a28-4814-8ec0-80b43048c284"), true, new Guid("9d11efde-ae9c-42a7-ac57-649bf5891e8a"), "ru-RU", "Russian Standard Time", "//meta[@property='article:published_time']/@content" },
                    { new Guid("bc3f2794-f10e-4745-ba8e-286b6aa58707"), true, new Guid("611bd50e-69f5-4598-8ad6-8b19771f1044"), "ru-RU", "Russian Standard Time", "//div[@class='article__content']//time/text()" },
                    { new Guid("c00312de-2ba3-4047-b80c-e5624577ad29"), true, new Guid("921d7c0a-c084-4188-b243-d08580f65142"), "ru-RU", null, "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("c6115996-838b-4309-813e-d520085af7df"), true, new Guid("e3fcdd00-2152-4d84-8f8c-bf70e4996990"), "ru-RU", "Russian Standard Time", "//div[@class='article-details']/span[@class='article-details__time']/time/@datetime" },
                    { new Guid("cbe14234-0158-487c-b0c0-2117107b9a34"), true, new Guid("fa16a108-45c2-42e4-8323-b1f3ea3cdf46"), "ru-RU", "Russian Standard Time", "//section[contains(@class, 'news-content')]/div[@class='content-top']//p[contains(@class, 'content-top__date')]/text()" },
                    { new Guid("ccc2a5c5-02fd-4a8d-ace5-7f41742f442b"), true, new Guid("3c4ef27a-3157-4eff-a441-1e409c4b6c34"), "en-US", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("d153a1fc-66c6-4313-adc9-36850ec82124"), true, new Guid("76b3ad9b-48c5-4f9e-ab28-993ba795fdb1"), "ru-RU", "Russian Standard Time", "//meta[@property='article:published_time']/@content" },
                    { new Guid("d3c31d01-f7fd-42e6-8378-3df623d1fc09"), true, new Guid("a03ca9fd-6e2d-4da5-9017-5feb6a9a1404"), "ru-RU", "Russian Standard Time", "//div[@class='newsDetail-body__item-subHeader']/time/text()" },
                    { new Guid("da19d28d-156b-47a0-868b-18f4ec0c8114"), true, new Guid("11795391-d20d-48df-ab38-30f796737a43"), "ru-RU", null, "//meta[@property='article:published_time']/@content" },
                    { new Guid("dc0d0ef7-eb9e-4632-b75e-9d7d9ba44daa"), true, new Guid("8c399ef5-9d29-4442-a621-52867b8e7f6d"), "ru-RU", null, "//header[@class='news-item__header']//time/@content" },
                    { new Guid("e07f5d48-7c9a-4425-ae9f-788d26a63f23"), true, new Guid("52014d82-bd2b-47fb-9ba1-668df2126197"), "ru-RU", "Russian Standard Time", "//meta[@property='article:published_time']/@content" },
                    { new Guid("e6bd53e0-c868-451c-87a5-e048343b2759"), true, new Guid("49c1bb0c-b546-4142-a7ba-4925f71a933c"), "ru-RU", null, "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("e762bdb6-dfae-410b-9478-3ff4b45dbe70"), true, new Guid("5c2d9dff-16d7-47f9-8d32-07f8fb52ac76"), "ru-RU", "Russian Standard Time", "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("eaf8f8a4-7781-4285-b447-1e3309b2edbf"), true, new Guid("52ac2f5a-3b95-4adc-9c2a-abd192a1ec26"), "ru-RU", "Russian Standard Time", "//meta[@property='article:published_time']/@content" },
                    { new Guid("f02b9ed4-7b5b-4572-bf74-604513ced86b"), true, new Guid("a1b03754-30d4-4c65-946d-10995830a159"), "ru-RU", "Russian Standard Time", "//article/div[@class='header']/span/text()" },
                    { new Guid("f3f8cc16-9599-42fa-acea-c66be06e0d13"), true, new Guid("5726d5dd-18ac-4c5c-a5d1-f775f1dd0b20"), "ru-RU", "Russian Standard Time", "//meta[@property='article:published_time']/@content" },
                    { new Guid("f4df8c3f-efa8-4fa5-bb34-91942ecec22a"), true, new Guid("a7d88817-12e6-434a-8c25-949dde2609f4"), "ru-RU", null, "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("fdad3f1e-646d-4fe0-b46f-cf5a2d320981"), true, new Guid("d36d75dc-add7-4e21-8a31-2f40f4033b14"), "ru-RU", null, "//meta[@itemprop='datePublished']/@content" },
                    { new Guid("fed30888-ff5a-4843-8a23-fa452ed88675"), true, new Guid("96ef6e5b-c81b-45e7-a715-1aa131d82ef2"), "ru-RU", "Russian Standard Time", "//div[@class='b-article__top-author']/p[@class='date']/text()" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_sub_title_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "title_x_path" },
                values: new object[,]
                {
                    { new Guid("051b16f3-07e7-49c7-ae63-d49e01d685e6"), false, new Guid("11795391-d20d-48df-ab38-30f796737a43"), "//meta[@property='og:description']/@content" },
                    { new Guid("07eddb61-de8e-46d8-ae6a-8f146d04e693"), false, new Guid("929687ee-eb6f-4e95-852d-9635657d7f89"), "//meta[@property='og:description']/@content" },
                    { new Guid("0c0b371b-5c93-4577-b625-7d520237ce5d"), false, new Guid("da641510-f1dd-4fce-b895-cbf32dca79bf"), "//meta[@property='og:description']/@content" },
                    { new Guid("0f75da21-14e8-47a2-81e2-01c5e05b5f9f"), false, new Guid("4c29ab0b-01eb-466e-8dc3-fe05886f4332"), "//meta[@property='og:description']/@content" },
                    { new Guid("15009b74-1ebf-4de7-b127-24e412d887b1"), false, new Guid("f63d1e4f-e82d-4020-8b9c-65beaab1d7c3"), "//meta[@property='og:description']/@content" },
                    { new Guid("191181df-86e6-43c2-9643-5e9bb0ad62ac"), false, new Guid("c965a1d0-83b6-4018-a4a5-9c426a02943e"), "//meta[@property='og:description']/@content" },
                    { new Guid("19df7bef-b4dd-4a35-991a-49c9a28ebfeb"), false, new Guid("cba88caa-d8af-4e40-b8fa-14946187e939"), "//meta[@property='og:description']/@content" },
                    { new Guid("1f572948-8062-4f2a-9603-54fd0815ff44"), false, new Guid("f1b027fc-2809-4eaa-9858-c49a8756852f"), "//meta[@name='og:description']/@content" },
                    { new Guid("255720d2-2188-4d40-ac74-86e2f87c78c7"), false, new Guid("692ba156-95b9-4a24-9b0c-71b769e8d3a8"), "//meta[@property='og:description']/@content" },
                    { new Guid("2656349d-0958-4779-a36a-cca96fe04b6a"), false, new Guid("d36d75dc-add7-4e21-8a31-2f40f4033b14"), "//meta[@property='og:description']/@content" },
                    { new Guid("30955c5b-0b5c-4655-9581-4972b4fc0df5"), false, new Guid("8c399ef5-9d29-4442-a621-52867b8e7f6d"), "//meta[@property='og:description']/@content" },
                    { new Guid("34d00cc0-a590-4e50-a6d8-6c4c7511c4d8"), false, new Guid("60a60886-4da0-4c2c-8635-a8ec57827667"), "//meta[@property='og:description']/@content" },
                    { new Guid("4087fb58-d428-4c26-b88d-b20e5715a6f8"), false, new Guid("a1b03754-30d4-4c65-946d-10995830a159"), "//meta[@property='og:description']/@content" },
                    { new Guid("45ebf04d-7b70-4c43-882d-af3d6ac3c687"), false, new Guid("a7d88817-12e6-434a-8c25-949dde2609f4"), "//meta[@name='description']/@content" },
                    { new Guid("48759786-80ce-4ea1-84c2-f5cbb3b3e9d9"), false, new Guid("77a6c5a1-b883-444f-ba7e-f0289943947f"), "//meta[@property='og:description']/@content" },
                    { new Guid("4a01f0ed-4373-4b4c-be4c-5d8b23cd7b4b"), false, new Guid("44d47f91-a811-4cc3-a70f-f12236d1476d"), "//meta[@property='og:description']/@content" },
                    { new Guid("4b514907-cb5c-4b5c-aaa9-1d581955c40b"), false, new Guid("14db83c2-cee9-47a2-b8fc-210bbbd399aa"), "//meta[@property='og:description']/@content" },
                    { new Guid("4ff736eb-a44a-4880-aa4f-f70988527bfe"), false, new Guid("6a7db6d7-c4ec-471c-93e2-9f7b9dd9180c"), "//meta[@property='og:description']/@content" },
                    { new Guid("5118a64e-b1fe-4226-b0f6-da9d0eb13ed0"), false, new Guid("9d11efde-ae9c-42a7-ac57-649bf5891e8a"), "//meta[@property='og:description']/@content" },
                    { new Guid("527db9fa-2e2a-4f4e-b9eb-b9055994211f"), false, new Guid("a39fd0cf-d695-451a-8ec5-b662eddf4e9e"), "//meta[@property='og:description']/@content" },
                    { new Guid("552e2547-f0f4-4536-ac2b-0368eb0d03c6"), false, new Guid("5c2d9dff-16d7-47f9-8d32-07f8fb52ac76"), "//meta[@property='og:description']/@content" },
                    { new Guid("568f8fd4-3715-4895-a979-509ce2da11e2"), false, new Guid("be3e061e-25f4-4b43-a9f6-45db165b6000"), "//meta[@property='og:description']/@content" },
                    { new Guid("60431c05-e7a1-4c09-a2d3-940896b52565"), false, new Guid("3373c5b8-57e2-402b-9dfb-a0ae19e92336"), "//meta[@property='og:description']/@content" },
                    { new Guid("688c8958-8946-4e0c-a943-3a614eedf013"), false, new Guid("6d16ec92-860e-4bd8-9618-1e5b2ac5a792"), "//meta[@property='og:description']/@content" },
                    { new Guid("6996d64b-f805-4868-a6d1-6d287f568e83"), false, new Guid("921d7c0a-c084-4188-b243-d08580f65142"), "//meta[@property='og:description']/@content" },
                    { new Guid("75075f9b-f14d-4720-8311-933ae0383523"), false, new Guid("3c4ef27a-3157-4eff-a441-1e409c4b6c34"), "//meta[@property='og:description']/@content" },
                    { new Guid("7d88f1e1-8458-403d-8d83-3d076b4cedd4"), false, new Guid("fa16a108-45c2-42e4-8323-b1f3ea3cdf46"), "//meta[@property='og:description']/@content" },
                    { new Guid("7e4b4a81-f9e7-4830-9127-6fd86379db9a"), false, new Guid("e4542056-2c68-43c6-a85c-9e4899556800"), "//meta[@property='og:description']/@content" },
                    { new Guid("86d2ce89-f28a-4779-be9c-1832701f99d4"), false, new Guid("052241f9-e3e7-4722-9f56-7202de4a331e"), "//meta[@property='og:description']/@content" },
                    { new Guid("8cb13ca5-b19a-47dd-93f4-13f82a2afaab"), false, new Guid("f6ef6598-401b-4cd8-8654-f3009b41593f"), "//meta[@property='og:description']/@content" },
                    { new Guid("999110e1-29e6-4a98-8361-743dd7f8bf07"), false, new Guid("e3fcdd00-2152-4d84-8f8c-bf70e4996990"), "//meta[@name='description']/@content" },
                    { new Guid("9e43be0a-592d-4c1a-8525-9545d8fada04"), false, new Guid("32cad97f-b071-4e24-bdc9-10e5e58cf99b"), "//div[@class='block-page-new']/h2/text()" },
                    { new Guid("a33df3a5-b0b4-4c61-8978-67452ed955c9"), false, new Guid("289bab5a-8dd4-4ca7-a510-ff6a496b3993"), "//meta[@name='DESCRIPTION']/@content" },
                    { new Guid("a811b3a1-c233-4875-9930-b99032c4fe99"), false, new Guid("a03ca9fd-6e2d-4da5-9017-5feb6a9a1404"), "//meta[@property='og:description']/@content" },
                    { new Guid("b07f324a-9029-4214-8521-01187ec7376d"), false, new Guid("efd9bf27-abb2-46c2-bedb-dc7e745e55fb"), "//meta[@name='description']/@content" },
                    { new Guid("b96057cb-5a77-4785-a20d-c7bbb0c4752e"), false, new Guid("5726d5dd-18ac-4c5c-a5d1-f775f1dd0b20"), "//meta[@property='og:description']/@content" },
                    { new Guid("c4ac25c5-d5da-4126-b298-8803c12b4930"), false, new Guid("d477dceb-5655-432b-8bca-b2ca2d944d87"), "//meta[@itemprop='description']/@content" },
                    { new Guid("c4d81a5f-b716-4dec-9ddf-3c908343be6a"), false, new Guid("aed24362-5c8e-4b31-9bbe-bb068f9c0f01"), "//meta[@name='description']/@content" },
                    { new Guid("c694b06f-3d99-4ec4-b939-374b524b728f"), false, new Guid("613dbfcf-7f5c-4060-a92a-d2ec7586f4a3"), "//meta[@name='description']/@content" },
                    { new Guid("c8a3d258-c774-4ac2-85ae-08f7ede167d4"), false, new Guid("28bff881-79f7-400c-ab5d-489176c269bb"), "//meta[@property='og:description']/@content" },
                    { new Guid("c8e216e4-355b-42c5-babf-cb9ae005b27c"), false, new Guid("52ac2f5a-3b95-4adc-9c2a-abd192a1ec26"), "//meta[@property='og:description']/@content" },
                    { new Guid("cbcb009b-37f0-4cf5-882c-df9a9e7dc908"), false, new Guid("dd419d1c-db40-4fd4-8f12-34206242d7cc"), "//meta[@property='og:description']/@content" },
                    { new Guid("de397d9b-55d7-45f3-b03b-66584a58d137"), false, new Guid("e8ea5810-3cc4-46dd-84d7-eb7b5cbf3f3b"), "//meta[@property='og:description']/@content" },
                    { new Guid("df87f204-4c84-408d-b84b-392e39d40b1f"), false, new Guid("96ef6e5b-c81b-45e7-a715-1aa131d82ef2"), "//meta[@property='og:description']/@content" },
                    { new Guid("e20418bb-871d-4c31-a56b-9038d36a37e1"), false, new Guid("68faffa0-b7e6-44bb-a958-441eb532bfbb"), "//meta[@property='og:description']/@content" },
                    { new Guid("e250183d-d316-4ef3-b7cf-887ce77ac342"), false, new Guid("2d46f779-c13c-4699-9460-629e254a6444"), "//div[contains(@class, 'styled__StoryBody')]/p[contains(@class, 'styled__StoryParagraph') and position()=1]/text()" },
                    { new Guid("e3d307d2-0cd5-42d2-9c7c-2fab779bb299"), false, new Guid("49c1bb0c-b546-4142-a7ba-4925f71a933c"), "//p[contains(@itemprop, 'alternativeHeadline')]/text()" },
                    { new Guid("e68f6ef8-cd76-4fc8-b98b-cb2bc02c3dfd"), false, new Guid("76b3ad9b-48c5-4f9e-ab28-993ba795fdb1"), "//meta[@property='og:description']/@content" },
                    { new Guid("eb234374-29cf-43b4-ae0f-5e8a80aaf132"), false, new Guid("611bd50e-69f5-4598-8ad6-8b19771f1044"), "//meta[@property='og:description']/@content" },
                    { new Guid("ee437f1b-e11b-48cd-9db5-645c3537edf1"), false, new Guid("9de1ef08-878b-4559-85af-a8b14d7ce68b"), "//meta[@property='og:description']/@content" },
                    { new Guid("f179e895-457c-4ccf-88ff-b4562edb1f33"), false, new Guid("52014d82-bd2b-47fb-9ba1-668df2126197"), "//meta[@property='og:description']/@content" },
                    { new Guid("f32f03ee-4548-4259-ac50-d791451cb1d7"), false, new Guid("2de49bdd-5c36-49ff-9a3b-a1f6ceb75e75"), "//meta[@name='description']/@content" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_video_settings",
                columns: new[] { "id", "is_required", "parse_settings_id", "url_x_path" },
                values: new object[,]
                {
                    { new Guid("4d2c5172-fc50-4854-bd47-44511c0fd763"), false, new Guid("4c29ab0b-01eb-466e-8dc3-fe05886f4332"), "//meta[@property='og:video']/@content" },
                    { new Guid("55100c78-3692-482c-af91-808f1a4f29a4"), false, new Guid("a39fd0cf-d695-451a-8ec5-b662eddf4e9e"), "//div[contains(@class, 'eagleplayer')]//video/@src" },
                    { new Guid("5a25f140-9895-4deb-9e9e-d048799446d3"), false, new Guid("5726d5dd-18ac-4c5c-a5d1-f775f1dd0b20"), "//meta[@property='og:video']/@content" },
                    { new Guid("8bface35-e140-4937-8b51-06597bcfc862"), false, new Guid("52014d82-bd2b-47fb-9ba1-668df2126197"), "//div[contains(@class, 'PageContentCommonStyling_text')]/rg-video//video/@src" },
                    { new Guid("b5ff5316-a5a2-44b7-855f-7af3788ab3e9"), false, new Guid("f63d1e4f-e82d-4020-8b9c-65beaab1d7c3"), "//article//div[@class='videoWrapper' and @itemprop='video']/iframe[@class='video']/@src" },
                    { new Guid("f0a8b4c3-22d5-4aa7-be0c-0250cfa04d53"), false, new Guid("f6ef6598-401b-4cd8-8654-f3009b41593f"), "//meta[@property='og:video:url']/@content" },
                    { new Guid("f3733384-2b0f-4b5e-bf44-040e6452b896"), false, new Guid("9d11efde-ae9c-42a7-ac57-649bf5891e8a"), "//div[@class='article__header']//div[@class='media__video']//video/@src" }
                });

            migrationBuilder.InsertData(
                table: "news_parse_modified_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_modified_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("05acbeac-ea1d-41c7-b658-ab3971501e2b"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("9980ee74-f655-40af-b44e-c9feb0e0bd40") },
                    { new Guid("06d2ec66-84f2-448c-808e-d5a50facb4cc"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("ffa17401-2b75-485d-a098-da254f125362") },
                    { new Guid("10a053d0-a81c-42a6-a032-1a217bc6e9c1"), "yyyy-MM-ddTHH:mm:ss", new Guid("b8626e48-242d-48e4-aa30-8ca2936a0d59") },
                    { new Guid("3217adeb-8d21-4a5c-82df-83883177308f"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("0a1fc27b-5f76-4a98-acd2-c3f98852d1c0") },
                    { new Guid("331d2e46-95f3-42de-9a4c-a7dd3312647a"), "yyyy-MM-dd HH:mm", new Guid("a62f2d07-0e56-4bdc-a6de-c061d313bea9") },
                    { new Guid("405dd507-6429-4fd3-a76f-7c211adbb18e"), "yyyyMMddTHHmm", new Guid("458c1359-0212-451f-9c05-a6d043114989") },
                    { new Guid("4084a0b1-75dd-4ab0-9b43-d2d569dfc7c7"), "\"обновлено\" d MMMM yyyy, HH:mm", new Guid("307744f1-4338-481a-b849-b8d88c196cc3") },
                    { new Guid("4601b17e-822b-4b19-862c-a0a6c5b7a23c"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("91c40a45-f102-46d4-bd9b-4e11869f18cd") },
                    { new Guid("4acbd680-8c5e-48a3-ae91-d66c2107150a"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("75386858-8fad-48aa-bea8-d5aec36c1f8f") },
                    { new Guid("61a158be-a01d-42c1-a474-2bbc66775a60"), "\"обновлено\" d MMMM, HH:mm", new Guid("307744f1-4338-481a-b849-b8d88c196cc3") },
                    { new Guid("61f79112-d8a1-4562-8a1d-6f5e64928a50"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("da1fb28b-2afb-461a-9cf2-6e65a9c6963d") },
                    { new Guid("7258af78-93ae-46b1-9c4a-418769158262"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("350279da-c53a-42a7-abad-a3097a881261") },
                    { new Guid("73cf32f0-bb16-4319-935b-76de58df264b"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("59699417-64ea-4f42-9573-68a21d4fdbe7") },
                    { new Guid("83158dac-180c-45f5-b13f-82b253c3f0be"), "yyyy-MM-ddTHH:mm:ss.fffZ", new Guid("4adf1a9f-ac4c-4f17-932b-aac460d0d2f2") },
                    { new Guid("97301aa5-3306-4948-a4f9-0ad1c5d3cda0"), "yyyy-MM-ddTHH:mm:ss\"+0300\"", new Guid("c8cda125-f32f-492a-9d65-c1e0abb69300") },
                    { new Guid("9ac871c4-a009-4f03-8920-3166aa64deeb"), "yyyy-MM-dd HH:mm:ss", new Guid("62afc18d-a34f-4989-8c4c-2a5d7deabf6b") },
                    { new Guid("9baa0874-10a0-4e13-8fc9-fb95036b8958"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("348a6cf9-f469-4f19-a12c-bdc3f525947c") },
                    { new Guid("a622e5c8-becb-44ac-809b-89da6191fa11"), "yyyy-MM-ddTHH:mm:ss", new Guid("90f502b6-e728-4f0a-b937-c264a9e683fd") },
                    { new Guid("b86762b0-61e7-4b60-8d55-84285b2ba9f9"), "yyyy-MM-ddTHH:mm:ss\"+0300\"", new Guid("4aeb273b-8983-4ed7-adf0-74ff9bdfb4ab") },
                    { new Guid("c18f4a2e-e149-4310-9311-f46c52acada0"), "yyyy-MM-ddTHH:mmzzz", new Guid("39d1b1e4-aa28-41b0-a55a-fffe8e406645") },
                    { new Guid("c4c8a06a-a104-4e0e-87d1-4fa02bdfa36a"), "yyyyMMddTHHmm", new Guid("3c897305-c4ad-42b1-9cb8-a550d075139c") },
                    { new Guid("d2673a76-54a4-4013-8596-c648d3e16aa7"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("25fa301c-d896-4a5e-b580-2dba44900fb6") },
                    { new Guid("d5896f93-bbef-44cb-82c4-6c0c73e4f4c9"), "yyyy-MM-dd", new Guid("6dc53704-3d38-47f9-9efa-7604da400355") },
                    { new Guid("fa45d026-0db8-4968-8753-da586b527e27"), "yyyy-MM-ddTHH:mm:ss.fff\"Z+0300\"", new Guid("700ffddc-d0a5-450a-b756-deabd7bfed18") },
                    { new Guid("ff02bb15-206e-4c8b-940e-c077740c4e8d"), "yyyy-MM-ddTHH:mm:ss.fffZ", new Guid("033e507a-cb9d-403f-a8cb-48238e03607b") }
                });

            migrationBuilder.InsertData(
                table: "news_parse_published_at_settings_formats",
                columns: new[] { "id", "format", "news_parse_published_at_settings_id" },
                values: new object[,]
                {
                    { new Guid("013ad3fa-fc09-4bce-a62a-5b23dfaf4b55"), "HH:mm, d MMMM yyyy", new Guid("b2514b4f-e07a-44e1-977b-9013bd07ea0c") },
                    { new Guid("04d00724-05cc-4ca5-a951-889b75da6f97"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("82ed5673-25e2-497f-aaea-3dd42ecd4f85") },
                    { new Guid("04fe3029-59e0-4670-9a51-99593a0f8041"), "yyyy-MM-dd HH:mm:ss", new Guid("2622b86a-c47b-4143-a11e-f2aad18faa8e") },
                    { new Guid("055ce086-a067-43f4-98ad-4b3b039328d6"), "d-M-yyyy HH:mm", new Guid("5c23cab5-7864-429b-9080-ba88f81c6751") },
                    { new Guid("05a46c75-81a5-4b37-b01f-7ef41ba35858"), "yyyy-MM-ddTHH:mm:ss\"+0300\"", new Guid("eaf8f8a4-7781-4285-b447-1e3309b2edbf") },
                    { new Guid("098793a2-d99d-494b-afba-e727e26214b7"), "dd.MM.yyyy HH:mm", new Guid("21890de7-31ad-4c9e-a749-05f565d45905") },
                    { new Guid("0b9c2546-034c-44d5-b328-fc29b3b96db4"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("3f29a12c-5e1c-45de-bf8b-96897f8ac962") },
                    { new Guid("2f4dba30-cd44-4a34-a28b-50d3d6db53d1"), "d MMMM yyyy, HH:mm,", new Guid("076e2817-f0e0-4f4a-ae55-08210a7e1a7d") },
                    { new Guid("3d264810-c568-4d66-9762-43c1467a6cd2"), "d MMMM, HH:mm,", new Guid("076e2817-f0e0-4f4a-ae55-08210a7e1a7d") },
                    { new Guid("3d3f9878-e5a6-4163-acb9-afe1346b3cf2"), "yyyy-MM-ddTHH:mm:ss", new Guid("e762bdb6-dfae-410b-9478-3ff4b45dbe70") },
                    { new Guid("490ce35b-c2e5-4008-93f1-632720e22073"), "yyyy-MM-ddTHH:mmzzz", new Guid("a4130bc3-4c5f-451f-92f1-73e1c1745fc6") },
                    { new Guid("509eae6c-481c-4a9d-9a9a-bd20b2ae533e"), "d MMMM, HH:mm", new Guid("076e2817-f0e0-4f4a-ae55-08210a7e1a7d") },
                    { new Guid("5161d08b-a97d-4fa1-ad5a-069c3b5dc41a"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("b208c066-da95-4c32-baec-ff448a07f62d") },
                    { new Guid("558de16f-ff6b-412c-9526-c6dd265565f4"), "d MMMM yyyy HH:mm", new Guid("89fc1310-fff8-4cdc-aff5-c4285f9ab73c") },
                    { new Guid("56366b43-4d17-44a6-9bdd-1cb63ec7dcfb"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("a17cf1af-be32-4074-9b36-6f5481ecbf14") },
                    { new Guid("5b48664a-bb06-480d-bbd4-c7acebf918db"), "yyyyMMddTHHmm", new Guid("3785f3c0-c9d3-4e29-a0b8-46fa78983506") },
                    { new Guid("63435dc7-a82d-43d8-80e9-f5e1307ec3ab"), "d MMMM yyyy \"в\" HH:mm", new Guid("fed30888-ff5a-4843-8a23-fa452ed88675") },
                    { new Guid("664d9377-1900-4561-aa21-c2b0a7a1f8ac"), "dd MMMM yyyy, HH:mm", new Guid("22c82c40-fe3a-4394-ab34-295e3c094dcf") },
                    { new Guid("677d695e-ddcc-4a66-aa7f-ff1ccdb726dd"), "yyyy-MM-dd HH:mm", new Guid("8208ff9e-fbf8-4206-b4d8-e7f7287b2dec") },
                    { new Guid("699ff8c9-5f7e-4216-8e21-23627129bab9"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("8bf5f85a-aba6-48a5-8704-3f6c4f51d9d1") },
                    { new Guid("6b286540-6b0b-42b6-a696-aed7dd5844c8"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("0cea5575-ec4f-4b14-a0cc-49185e1d1768") },
                    { new Guid("6c0231f6-71e1-4911-959c-9c93c1408781"), "dd MMMM, HH:mm", new Guid("4a6be1f2-8429-4185-a9c6-03aeda076dcd") },
                    { new Guid("6c536ec8-3a65-4fa3-9862-f7744d5b1e1f"), "yyyy-MM-ddTHH:mm:ss.fffZ", new Guid("da19d28d-156b-47a0-868b-18f4ec0c8114") },
                    { new Guid("715c49ba-24ae-40af-b0b5-cacd488cb00e"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("4a335cad-bc2f-442e-9c89-74da04bbde90") },
                    { new Guid("78b09bbf-a311-4d1a-9d00-d054898f1354"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("79e88ebb-d542-4d19-a212-6c21f2688c77") },
                    { new Guid("79934951-c9f9-4230-8eb5-2d3a80f4d4f4"), "yyyy-MM-ddTHH:mm:ss.fff\"Z+0300\"", new Guid("d153a1fc-66c6-4313-adc9-36850ec82124") },
                    { new Guid("7a4a173c-cad8-4a09-adef-caecda7f5283"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("6f87ed33-a16c-465a-8784-33c69ef9bb0c") },
                    { new Guid("7b5a7ff9-dc44-4399-8049-30505337726e"), "HH:mm", new Guid("4a6be1f2-8429-4185-a9c6-03aeda076dcd") },
                    { new Guid("7ff54b73-3ea0-49c6-9702-ad9fe746e1c9"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("f4df8c3f-efa8-4fa5-bb34-91942ecec22a") },
                    { new Guid("81fdba6b-e423-47c5-b9bf-cd08dc7fce42"), "dd MMMM yyyy HH:mm", new Guid("bc3f2794-f10e-4745-ba8e-286b6aa58707") },
                    { new Guid("8e6578d8-62d7-4761-a9a2-60e8cfd4da58"), "d MMMM yyyy, HH:mm\" •\"", new Guid("f02b9ed4-7b5b-4572-bf74-604513ced86b") },
                    { new Guid("94e51912-995a-4976-a4a0-4cc03ffe4e82"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("a2c411a5-4b6a-4ed8-b383-b1a4f05b4605") },
                    { new Guid("95c6753e-1df4-4708-9b80-6976c6b91292"), "yyyy-MM-ddTHH:mm:ssZ", new Guid("e6bd53e0-c868-451c-87a5-e048343b2759") },
                    { new Guid("9b3343e0-5099-4696-a6b4-c00035cc78b3"), "d MMMM yyyy, HH:mm", new Guid("d3c31d01-f7fd-42e6-8378-3df623d1fc09") },
                    { new Guid("9c7e361a-0096-483d-8f8a-edae7e347e1a"), "d MMMM yyyy", new Guid("c6115996-838b-4309-813e-d520085af7df") },
                    { new Guid("a28a5ac8-e766-4c34-823a-a5703f3ef96b"), "dd.MM.yyyy \"-\" HH:mm", new Guid("8ff05689-5c68-4f41-9023-4bfead386fed") },
                    { new Guid("a3e3e93d-5850-4f27-885b-d80d10d72a8e"), "d MMMM yyyy, HH:mm \"МСК\"", new Guid("a5685486-3a98-45aa-96b7-d25cd5e40c5d") },
                    { new Guid("a614d044-0c1d-4a5a-b547-a22ec2fdd1c0"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("dc0d0ef7-eb9e-4632-b75e-9d7d9ba44daa") },
                    { new Guid("a9340a6d-ec66-49fc-8150-3a6a698e999e"), "HH:mm, d MMMM yyyy", new Guid("5e7874b1-13e9-4cf5-a96a-6612fe3661cf") },
                    { new Guid("af484c5e-0924-4f42-bcc5-8c4407ea9a92"), "yyyy-MM-ddTHH:mm:ss\"+0300\"", new Guid("f3f8cc16-9599-42fa-acea-c66be06e0d13") },
                    { new Guid("b0dec36b-12b0-4ff1-af8c-7feff35137de"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("c00312de-2ba3-4047-b80c-e5624577ad29") },
                    { new Guid("b871e83e-0792-470a-8610-4264a83c16b1"), "dd MMMM yyyy, HH:mm", new Guid("4a6be1f2-8429-4185-a9c6-03aeda076dcd") },
                    { new Guid("bd0d7dc4-64d5-4daa-a89d-ca0609a09d29"), "yyyy-MM-ddTHH:mm:ss", new Guid("e07f5d48-7c9a-4425-ae9f-788d26a63f23") },
                    { new Guid("be418012-872b-49b6-bce4-f91a9bf8ef1d"), "dd.MM.yyyy HH:mm", new Guid("80bc5b20-336c-4ac1-9ee0-e231d0ef74c7") },
                    { new Guid("c0377df6-a447-44bb-9698-cd37f084d4be"), "dd.MM.yyyy, HH:mm", new Guid("cbe14234-0158-487c-b0c0-2117107b9a34") },
                    { new Guid("c0ff192d-ad34-459b-8fe8-49d20e6c5f41"), "yyyy-MM-dd HH:mm:ss", new Guid("20903a2a-fdf2-4909-8478-bbfd57c492be") },
                    { new Guid("c66b5e6c-d604-4a55-b38f-f9ae415ecd1c"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("fdad3f1e-646d-4fe0-b46f-cf5a2d320981") },
                    { new Guid("cdc7b365-0e9b-405d-b948-4c074942dcc3"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("47328c5f-5e86-4b2d-be25-fe9198a946fc") },
                    { new Guid("d647a983-f4e1-4610-9ee7-5d8163fdd865"), "yyyy-MM-ddTHH:mm:sszzz", new Guid("00106a66-61a0-4abd-b58e-9f9b4ed2c07d") },
                    { new Guid("d70086c1-dd34-40a7-b8d5-225689fd993c"), "yyyy-MM-dd", new Guid("9bfd49d6-dcb9-4a65-80f5-c9ac3b6b490d") },
                    { new Guid("d7afea6f-76d6-4684-86ce-f4d232f21786"), "d MMMM  HH:mm", new Guid("89fc1310-fff8-4cdc-aff5-c4285f9ab73c") },
                    { new Guid("da39c45c-178d-4b8c-8944-9d77de2690d0"), "d MMMM yyyy, HH:mm", new Guid("076e2817-f0e0-4f4a-ae55-08210a7e1a7d") },
                    { new Guid("e0b7abad-a103-4050-92c5-36017a518376"), "yyyy-MM-ddTHH:mm:ss.fffZ", new Guid("ccc2a5c5-02fd-4a8d-ace5-7f41742f442b") },
                    { new Guid("f9ff1b0c-54ca-43d5-8781-01783db54288"), "dd MMMM HH:mm", new Guid("bc3f2794-f10e-4745-ba8e-286b6aa58707") },
                    { new Guid("fb9e24ab-9e5b-4641-ac8b-df59d34811d1"), "yyyy-MM-ddTHH:mm:ss.fffZ", new Guid("1fe09b4f-73bd-4979-8206-439489299a64") },
                    { new Guid("fdae85e3-de1e-4d29-a496-fa6ffedc616a"), "yyyyMMddTHHmm", new Guid("b5afbf6f-9a28-4814-8ec0-80b43048c284") }
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
                name: "ix_news_source_tags_source_id",
                table: "news_source_tags",
                column: "source_id");

            migrationBuilder.CreateIndex(
                name: "ix_news_source_tags_tag_id",
                table: "news_source_tags",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "ix_news_sources_is_enabled",
                table: "news_sources",
                column: "is_enabled");

            migrationBuilder.CreateIndex(
                name: "ix_news_sources_is_system",
                table: "news_sources",
                column: "is_system");

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
                name: "ix_news_tags_name",
                table: "news_tags",
                column: "name");

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
                name: "news_source_tags");

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
                name: "news_tags");

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
