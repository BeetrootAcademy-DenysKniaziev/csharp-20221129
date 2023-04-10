using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangedNameOfTableArticleAndChangedConditions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_arcticles_courses_course_id",
                schema: "public",
                table: "arcticles");

            migrationBuilder.DropForeignKey(
                name: "FK_comment_arcticles_ArticleId",
                schema: "public",
                table: "comment");

            migrationBuilder.DropForeignKey(
                name: "FK_like_article_arcticles_ArticleId",
                schema: "public",
                table: "like_article");

            migrationBuilder.DropPrimaryKey(
                name: "PK_arcticles",
                schema: "public",
                table: "arcticles");

            migrationBuilder.RenameTable(
                name: "arcticles",
                schema: "public",
                newName: "articles",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "IX_arcticles_course_id",
                schema: "public",
                table: "articles",
                newName: "IX_articles_course_id");

            migrationBuilder.AlterColumn<string>(
                name: "content",
                schema: "public",
                table: "courses",
                type: "character varying(10000)",
                maxLength: 10000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "content",
                schema: "public",
                table: "articles",
                type: "character varying(10000)",
                maxLength: 10000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_articles",
                schema: "public",
                table: "articles",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_articles_courses_course_id",
                schema: "public",
                table: "articles",
                column: "course_id",
                principalSchema: "public",
                principalTable: "courses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comment_articles_ArticleId",
                schema: "public",
                table: "comment",
                column: "ArticleId",
                principalSchema: "public",
                principalTable: "articles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_like_article_articles_ArticleId",
                schema: "public",
                table: "like_article",
                column: "ArticleId",
                principalSchema: "public",
                principalTable: "articles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_articles_courses_course_id",
                schema: "public",
                table: "articles");

            migrationBuilder.DropForeignKey(
                name: "FK_comment_articles_ArticleId",
                schema: "public",
                table: "comment");

            migrationBuilder.DropForeignKey(
                name: "FK_like_article_articles_ArticleId",
                schema: "public",
                table: "like_article");

            migrationBuilder.DropPrimaryKey(
                name: "PK_articles",
                schema: "public",
                table: "articles");

            migrationBuilder.RenameTable(
                name: "articles",
                schema: "public",
                newName: "arcticles",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "IX_articles_course_id",
                schema: "public",
                table: "arcticles",
                newName: "IX_arcticles_course_id");

            migrationBuilder.AlterColumn<string>(
                name: "content",
                schema: "public",
                table: "courses",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(10000)",
                oldMaxLength: 10000);

            migrationBuilder.AlterColumn<string>(
                name: "content",
                schema: "public",
                table: "arcticles",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10000)",
                oldMaxLength: 10000);

            migrationBuilder.AddPrimaryKey(
                name: "PK_arcticles",
                schema: "public",
                table: "arcticles",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_arcticles_courses_course_id",
                schema: "public",
                table: "arcticles",
                column: "course_id",
                principalSchema: "public",
                principalTable: "courses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comment_arcticles_ArticleId",
                schema: "public",
                table: "comment",
                column: "ArticleId",
                principalSchema: "public",
                principalTable: "arcticles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_like_article_arcticles_ArticleId",
                schema: "public",
                table: "like_article",
                column: "ArticleId",
                principalSchema: "public",
                principalTable: "arcticles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
