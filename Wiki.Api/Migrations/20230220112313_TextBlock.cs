using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wiki.Api.Migrations
{
    /// <inheritdoc />
    public partial class TextBlock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Character");

            migrationBuilder.CreateTable(
                name: "TextBlock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Paragraph = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextBlock", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TextBlock");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Character",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
