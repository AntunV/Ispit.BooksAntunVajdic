﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ispit.BooksAntunVajdic.Data.Migrations
{
    /// <inheritdoc />
    public partial class trecamigracija : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Books",
                newName: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Books",
                newName: "Name");
        }
    }
}
