using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeepLearn.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddTextForTheoryBlocks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "text",
                table: "theory_blocks",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "text",
                table: "theory_blocks");
        }
    }
}
