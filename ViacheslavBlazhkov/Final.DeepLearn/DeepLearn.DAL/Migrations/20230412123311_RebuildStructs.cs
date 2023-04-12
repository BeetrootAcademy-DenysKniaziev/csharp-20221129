using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeepLearn.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RebuildStructs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "module_id",
                table: "modules",
                newName: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_theory_blocks_lesson_id",
                table: "theory_blocks",
                column: "lesson_id");

            migrationBuilder.CreateIndex(
                name: "IX_modules_course_id",
                table: "modules",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_lessons_module_id",
                table: "lessons",
                column: "module_id");

            migrationBuilder.AddForeignKey(
                name: "FK_lessons_modules_module_id",
                table: "lessons",
                column: "module_id",
                principalTable: "modules",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_modules_courses_course_id",
                table: "modules",
                column: "course_id",
                principalTable: "courses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_theory_blocks_lessons_lesson_id",
                table: "theory_blocks",
                column: "lesson_id",
                principalTable: "lessons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lessons_modules_module_id",
                table: "lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_modules_courses_course_id",
                table: "modules");

            migrationBuilder.DropForeignKey(
                name: "FK_theory_blocks_lessons_lesson_id",
                table: "theory_blocks");

            migrationBuilder.DropIndex(
                name: "IX_theory_blocks_lesson_id",
                table: "theory_blocks");

            migrationBuilder.DropIndex(
                name: "IX_modules_course_id",
                table: "modules");

            migrationBuilder.DropIndex(
                name: "IX_lessons_module_id",
                table: "lessons");

            migrationBuilder.RenameColumn(
                name: "course_id",
                table: "modules",
                newName: "module_id");
        }
    }
}
