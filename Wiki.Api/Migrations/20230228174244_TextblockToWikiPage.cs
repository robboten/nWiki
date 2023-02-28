using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wiki.Api.Migrations
{
    /// <inheritdoc />
    public partial class TextblockToWikiPage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TextBlock");

            migrationBuilder.CreateTable(
                name: "WikiPage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PageType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WikiPage", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WikiPage");

            migrationBuilder.CreateTable(
                name: "TextBlock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextBlock", x => x.Id);
                });
        }
    }
}
