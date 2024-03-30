using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsAggregator.News.Databases.EntityFramework.News.Migrations
{
    /// <inheritdoc />
    public partial class AddedIconColorField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "icon_color",
                table: "reaction_icons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "reaction_icons",
                keyColumn: "id",
                keyValue: new Guid("02c35a67-344b-4520-b04c-ea8e92d62dbf"),
                column: "icon_color",
                value: "orange");

            migrationBuilder.UpdateData(
                table: "reaction_icons",
                keyColumn: "id",
                keyValue: new Guid("19ca1fb2-5435-4f26-90b6-9e96d0d6821c"),
                column: "icon_color",
                value: "lime");

            migrationBuilder.UpdateData(
                table: "reaction_icons",
                keyColumn: "id",
                keyValue: new Guid("2158fcf6-039c-49f4-8e2e-9867ba006e1f"),
                column: "icon_color",
                value: "auqa");

            migrationBuilder.UpdateData(
                table: "reaction_icons",
                keyColumn: "id",
                keyValue: new Guid("26c1d336-5429-4343-ac30-651bab560ca9"),
                column: "icon_color",
                value: "orange");

            migrationBuilder.UpdateData(
                table: "reaction_icons",
                keyColumn: "id",
                keyValue: new Guid("2ffbe56a-543f-4f3b-8196-8886ce47f12a"),
                column: "icon_color",
                value: "lime");

            migrationBuilder.UpdateData(
                table: "reaction_icons",
                keyColumn: "id",
                keyValue: new Guid("334e08bb-a136-4977-a8e2-d24c01108242"),
                column: "icon_color",
                value: "lime");

            migrationBuilder.UpdateData(
                table: "reaction_icons",
                keyColumn: "id",
                keyValue: new Guid("66874c88-c3f0-4836-b340-d186b264e32c"),
                column: "icon_color",
                value: "lime");

            migrationBuilder.UpdateData(
                table: "reaction_icons",
                keyColumn: "id",
                keyValue: new Guid("c815a7e1-385a-4b64-9351-04c32b9a45d5"),
                column: "icon_color",
                value: "red");

            migrationBuilder.UpdateData(
                table: "reaction_icons",
                keyColumn: "id",
                keyValue: new Guid("e1f9ac21-e918-4ab7-a051-43e0fec7e7c5"),
                column: "icon_color",
                value: "auqa");

            migrationBuilder.UpdateData(
                table: "reaction_icons",
                keyColumn: "id",
                keyValue: new Guid("ef493f75-50d3-49c2-9aad-01edf6cd55c2"),
                column: "icon_color",
                value: "red");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "icon_color",
                table: "reaction_icons");
        }
    }
}
