using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ispit.BooksAntunVajdic.Data.Migrations
{
    /// <inheritdoc />
    public partial class drugamigracija : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Publishers",
                newName: "NamePublisher");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NamePublisher",
                table: "Publishers",
                newName: "Name");
        }
    }
}
