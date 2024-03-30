using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsAggregator.News.Databases.EntityFramework.News.Migrations
{
    /// <inheritdoc />
    public partial class ChangedIconColorValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "reaction_icons",
                keyColumn: "id",
                keyValue: new Guid("2158fcf6-039c-49f4-8e2e-9867ba006e1f"),
                column: "icon_color",
                value: "aqua");

            migrationBuilder.UpdateData(
                table: "reaction_icons",
                keyColumn: "id",
                keyValue: new Guid("e1f9ac21-e918-4ab7-a051-43e0fec7e7c5"),
                column: "icon_color",
                value: "aqua");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "reaction_icons",
                keyColumn: "id",
                keyValue: new Guid("2158fcf6-039c-49f4-8e2e-9867ba006e1f"),
                column: "icon_color",
                value: "auqa");

            migrationBuilder.UpdateData(
                table: "reaction_icons",
                keyColumn: "id",
                keyValue: new Guid("e1f9ac21-e918-4ab7-a051-43e0fec7e7c5"),
                column: "icon_color",
                value: "auqa");
        }
    }
}
