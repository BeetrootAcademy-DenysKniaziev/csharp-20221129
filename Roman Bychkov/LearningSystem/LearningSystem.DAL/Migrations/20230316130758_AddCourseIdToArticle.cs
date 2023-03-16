using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddCourseIdToArticle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_arcticles_courses_CourseId",
                schema: "public",
                table: "arcticles");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                schema: "public",
                table: "arcticles",
                newName: "course_id");

            migrationBuilder.RenameIndex(
                name: "IX_arcticles_CourseId",
                schema: "public",
                table: "arcticles",
                newName: "IX_arcticles_course_id");

            migrationBuilder.AddForeignKey(
                name: "FK_arcticles_courses_course_id",
                schema: "public",
                table: "arcticles",
                column: "course_id",
                principalSchema: "public",
                principalTable: "courses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_arcticles_courses_course_id",
                schema: "public",
                table: "arcticles");

            migrationBuilder.RenameColumn(
                name: "course_id",
                schema: "public",
                table: "arcticles",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_arcticles_course_id",
                schema: "public",
                table: "arcticles",
                newName: "IX_arcticles_CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_arcticles_courses_CourseId",
                schema: "public",
                table: "arcticles",
                column: "CourseId",
                principalSchema: "public",
                principalTable: "courses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
