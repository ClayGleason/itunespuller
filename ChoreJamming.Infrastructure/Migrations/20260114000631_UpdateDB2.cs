using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChoreJamming.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Explicit",
                table: "ChoreHistories");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "ChoreHistories");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "ChoreHistories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Explicit",
                table: "ChoreHistories",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "ChoreHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "ChoreHistories",
                type: "TEXT",
                nullable: true);
        }
    }
}
