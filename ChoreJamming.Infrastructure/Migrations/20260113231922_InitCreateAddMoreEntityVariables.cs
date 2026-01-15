using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChoreJamming.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitCreateAddMoreEntityVariables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Explicit",
                table: "ChoreHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "ChoreHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReleaseDate",
                table: "ChoreHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
