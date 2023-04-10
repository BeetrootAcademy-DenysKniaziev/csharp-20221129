using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class test5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "user_id",
                schema: "public",
                table: "courses",
                newName: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_courses_UserId",
                schema: "public",
                table: "courses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_users_UserId",
                schema: "public",
                table: "courses",
                column: "UserId",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_users_UserId",
                schema: "public",
                table: "courses");

            migrationBuilder.DropIndex(
                name: "IX_courses_UserId",
                schema: "public",
                table: "courses");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "public",
                table: "courses",
                newName: "user_id");
        }
    }
}
