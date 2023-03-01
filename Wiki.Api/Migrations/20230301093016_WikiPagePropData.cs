using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wiki.Api.Migrations
{
    /// <inheritdoc />
    public partial class WikiPagePropData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MetaValue",
                table: "WikiPageMeta",
                newName: "PropValue");

            migrationBuilder.RenameColumn(
                name: "MetaKey",
                table: "WikiPageMeta",
                newName: "PropKey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PropValue",
                table: "WikiPageMeta",
                newName: "MetaValue");

            migrationBuilder.RenameColumn(
                name: "PropKey",
                table: "WikiPageMeta",
                newName: "MetaKey");
        }
    }
}
