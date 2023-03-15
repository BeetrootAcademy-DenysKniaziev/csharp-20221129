using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedDescriptionCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                schema: "public",
                table: "courses",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                schema: "public",
                table: "courses");
        }
    }
}
