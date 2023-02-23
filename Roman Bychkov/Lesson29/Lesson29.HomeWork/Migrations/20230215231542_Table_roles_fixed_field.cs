using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lesson29.HomeWork.Migrations
{
    /// <inheritdoc />
    public partial class Table_roles_fixed_field : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilmdId",
                schema: "public",
                table: "roles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FilmdId",
                schema: "public",
                table: "roles",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
