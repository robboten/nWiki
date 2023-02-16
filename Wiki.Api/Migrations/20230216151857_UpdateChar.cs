using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Wiki.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateChar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Character");

            migrationBuilder.AlterColumn<string>(
                name: "PortraitUrl",
                table: "Character",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "Id", "Birthday", "Name", "PortraitUrl", "Quote", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 16, 16, 18, 57, 864, DateTimeKind.Local).AddTicks(8322), "Zev", "https://github.com/NoahFerm/Wiki1.0/blob/main/Wiki/bilder/zev.png?raw=true", "Integer vehicula vitae velit quis semper. Aliquam porta erat sit amet aliquam lobortis. Vivamus et ligula eget justo pharetra sagittis. Fusce lorem ipsum, sagittis quis turpis a, maximus auctor ipsum.", "" },
                    { 2, new DateTime(2023, 2, 16, 16, 18, 57, 864, DateTimeKind.Local).AddTicks(8395), "Alex", "https://github.com/NoahFerm/Wiki1.0/blob/main/Wiki/bilder/alex.png?raw=true", "Integer vehicula vitae velit quis semper. Aliquam porta erat sit amet aliquam lobortis. Vivamus et ligula eget justo pharetra sagittis. Fusce lorem ipsum, sagittis quis turpis a, maximus auctor ipsum.", "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Character",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Character",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "PortraitUrl",
                table: "Character",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Character",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
