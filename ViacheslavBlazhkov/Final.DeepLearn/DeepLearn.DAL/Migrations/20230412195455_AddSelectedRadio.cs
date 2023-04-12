using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeepLearn.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddSelectedRadio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SelectedAnswerId",
                table: "test_blocks",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectedAnswerId",
                table: "test_blocks");
        }
    }
}
