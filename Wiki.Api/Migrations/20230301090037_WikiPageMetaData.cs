using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wiki.Api.Migrations
{
    /// <inheritdoc />
    public partial class WikiPageMetaData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WikiPageMeta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MetaKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MetaValue = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WikiPageMeta", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WikiPageMeta");
        }
    }
}
