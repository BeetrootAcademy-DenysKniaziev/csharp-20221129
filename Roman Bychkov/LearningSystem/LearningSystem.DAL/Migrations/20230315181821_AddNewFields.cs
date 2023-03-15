using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddNewFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "content",
                schema: "public",
                table: "courses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "number",
                schema: "public",
                table: "arcticles",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "content",
                schema: "public",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "number",
                schema: "public",
                table: "arcticles");
        }
    }
}
