using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lesson29.Migrations
{
    /// <inheritdoc />
    public partial class AddPhoneField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                schema: "public",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                schema: "public",
                table: "users");
        }
    }
}
