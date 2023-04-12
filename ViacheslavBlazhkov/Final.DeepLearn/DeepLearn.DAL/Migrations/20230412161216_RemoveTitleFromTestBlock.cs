using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeepLearn.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTitleFromTestBlock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "title",
                table: "test_blocks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "test_blocks",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
