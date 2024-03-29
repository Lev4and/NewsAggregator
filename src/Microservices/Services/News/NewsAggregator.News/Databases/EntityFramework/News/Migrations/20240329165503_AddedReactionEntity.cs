using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NewsAggregator.News.Databases.EntityFramework.News.Migrations
{
    /// <inheritdoc />
    public partial class AddedReactionEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "reactions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reactions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "news_reactions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    news_id = table.Column<Guid>(type: "uuid", nullable: false),
                    reaction_id = table.Column<Guid>(type: "uuid", nullable: false),
                    ip_address = table.Column<string>(type: "text", nullable: false),
                    reacted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_reactions", x => x.id);
                    table.ForeignKey(
                        name: "fk_news_reactions_news_news_id",
                        column: x => x.news_id,
                        principalTable: "news",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_news_reactions_reactions_reaction_id",
                        column: x => x.reaction_id,
                        principalTable: "reactions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reaction_icons",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    reaction_id = table.Column<Guid>(type: "uuid", nullable: false),
                    icon_class = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reaction_icons", x => x.id);
                    table.ForeignKey(
                        name: "fk_reaction_icons_reactions_reaction_id",
                        column: x => x.reaction_id,
                        principalTable: "reactions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "reactions",
                columns: new[] { "id", "title" },
                values: new object[,]
                {
                    { new Guid("015aae0f-d855-4f47-b001-4b45c5a837db"), "Thumbs up" },
                    { new Guid("04cd624c-2d10-4be5-8128-7a529e690cc8"), "Thumbs down" },
                    { new Guid("181976e1-087d-42dc-9b2b-baeaa79431c7"), "Laughing" },
                    { new Guid("1ef9784e-14e3-4435-b536-9467a7a66176"), "Surprise" },
                    { new Guid("44135679-ac4c-4a3b-8f60-eb645bdda922"), "Smile" },
                    { new Guid("60e71cd7-12a3-4c2e-b626-ffba6415b814"), "Neutral" },
                    { new Guid("64f9b137-6ec4-4026-84f6-371fd15b2d7a"), "Astonished" },
                    { new Guid("79569ca3-5279-4f10-a69b-a1c01bc4aafc"), "Angry" },
                    { new Guid("7f2a58e7-34f8-4551-a1d6-8cd2f132351d"), "Frown" },
                    { new Guid("81f8a4e0-f850-411b-ba9a-6131c6768658"), "Tear" }
                });

            migrationBuilder.InsertData(
                table: "reaction_icons",
                columns: new[] { "id", "icon_class", "reaction_id" },
                values: new object[,]
                {
                    { new Guid("02c35a67-344b-4520-b04c-ea8e92d62dbf"), "bi-emoji-astonished-fill", new Guid("64f9b137-6ec4-4026-84f6-371fd15b2d7a") },
                    { new Guid("19ca1fb2-5435-4f26-90b6-9e96d0d6821c"), "bi-emoji-surprise-fill", new Guid("1ef9784e-14e3-4435-b536-9467a7a66176") },
                    { new Guid("2158fcf6-039c-49f4-8e2e-9867ba006e1f"), "bi-emoji-tear-fill", new Guid("81f8a4e0-f850-411b-ba9a-6131c6768658") },
                    { new Guid("26c1d336-5429-4343-ac30-651bab560ca9"), "bi-emoji-neutral-fill", new Guid("60e71cd7-12a3-4c2e-b626-ffba6415b814") },
                    { new Guid("2ffbe56a-543f-4f3b-8196-8886ce47f12a"), "bi-emoji-smile-fill", new Guid("44135679-ac4c-4a3b-8f60-eb645bdda922") },
                    { new Guid("334e08bb-a136-4977-a8e2-d24c01108242"), "bi-emoji-laughing-fill", new Guid("181976e1-087d-42dc-9b2b-baeaa79431c7") },
                    { new Guid("66874c88-c3f0-4836-b340-d186b264e32c"), "bi-hand-thumbs-up-fill", new Guid("015aae0f-d855-4f47-b001-4b45c5a837db") },
                    { new Guid("c815a7e1-385a-4b64-9351-04c32b9a45d5"), "bi-emoji-angry-fill", new Guid("79569ca3-5279-4f10-a69b-a1c01bc4aafc") },
                    { new Guid("e1f9ac21-e918-4ab7-a051-43e0fec7e7c5"), "bi-emoji-frown-fill", new Guid("7f2a58e7-34f8-4551-a1d6-8cd2f132351d") },
                    { new Guid("ef493f75-50d3-49c2-9aad-01edf6cd55c2"), "bi-hand-thumbs-down-fill", new Guid("04cd624c-2d10-4be5-8128-7a529e690cc8") }
                });

            migrationBuilder.CreateIndex(
                name: "ix_news_reactions_ip_address",
                table: "news_reactions",
                column: "ip_address");

            migrationBuilder.CreateIndex(
                name: "ix_news_reactions_news_id",
                table: "news_reactions",
                column: "news_id");

            migrationBuilder.CreateIndex(
                name: "ix_news_reactions_reacted_at",
                table: "news_reactions",
                column: "reacted_at");

            migrationBuilder.CreateIndex(
                name: "ix_news_reactions_reaction_id",
                table: "news_reactions",
                column: "reaction_id");

            migrationBuilder.CreateIndex(
                name: "ix_reaction_icons_reaction_id",
                table: "reaction_icons",
                column: "reaction_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_reactions_title",
                table: "reactions",
                column: "title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "news_reactions");

            migrationBuilder.DropTable(
                name: "reaction_icons");

            migrationBuilder.DropTable(
                name: "reactions");
        }
    }
}
