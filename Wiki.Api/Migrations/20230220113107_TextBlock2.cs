using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wiki.Api.Migrations
{
    /// <inheritdoc />
    public partial class TextBlock2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Paragraph",
                table: "TextBlock",
                newName: "Body");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Body",
                table: "TextBlock",
                newName: "Paragraph");
        }
    }
}
