using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChoreJamming.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "ChoreHistories",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "ChoreHistories");
        }
    }
}
