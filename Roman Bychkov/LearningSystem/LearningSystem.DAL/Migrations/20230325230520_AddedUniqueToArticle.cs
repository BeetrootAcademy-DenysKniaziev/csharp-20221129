using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedUniqueToArticle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_articles_course_id",
                schema: "public",
                table: "articles");

            migrationBuilder.CreateIndex(
                name: "IX_articles_course_id_number",
                schema: "public",
                table: "articles",
                columns: new[] { "course_id", "number" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_articles_course_id_number",
                schema: "public",
                table: "articles");

            migrationBuilder.CreateIndex(
                name: "IX_articles_course_id",
                schema: "public",
                table: "articles",
                column: "course_id");
        }
    }
}
