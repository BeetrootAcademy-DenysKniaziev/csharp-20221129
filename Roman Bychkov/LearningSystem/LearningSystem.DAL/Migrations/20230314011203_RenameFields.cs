using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RenameFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comment_arcticles_ArcticleId",
                schema: "public",
                table: "comment");

            migrationBuilder.DropForeignKey(
                name: "FK_like_article_arcticles_ArcticleId",
                schema: "public",
                table: "like_article");

            migrationBuilder.DropTable(
                name: "ArcticleImage",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_like_article_ArcticleId",
                schema: "public",
                table: "like_article");

            migrationBuilder.DropIndex(
                name: "IX_comment_ArcticleId",
                schema: "public",
                table: "comment");

            migrationBuilder.DropColumn(
                name: "Liked",
                schema: "public",
                table: "like_comment");

            migrationBuilder.DropColumn(
                name: "ArcticleId",
                schema: "public",
                table: "like_article");

            migrationBuilder.DropColumn(
                name: "ArcticleId",
                schema: "public",
                table: "comment");

            migrationBuilder.CreateTable(
                name: "ArticleImage",
                schema: "public",
                columns: table => new
                {
                    ArticlesId = table.Column<int>(type: "integer", nullable: false),
                    ImagesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleImage", x => new { x.ArticlesId, x.ImagesId });
                    table.ForeignKey(
                        name: "FK_ArticleImage_arcticles_ArticlesId",
                        column: x => x.ArticlesId,
                        principalSchema: "public",
                        principalTable: "arcticles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleImage_images_ImagesId",
                        column: x => x.ImagesId,
                        principalSchema: "public",
                        principalTable: "images",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_like_article_ArticleId",
                schema: "public",
                table: "like_article",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_comment_ArticleId",
                schema: "public",
                table: "comment",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleImage_ImagesId",
                schema: "public",
                table: "ArticleImage",
                column: "ImagesId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comment_arcticles_ArticleId",
                schema: "public",
                table: "comment");

            migrationBuilder.DropForeignKey(
                name: "FK_like_article_arcticles_ArticleId",
                schema: "public",
                table: "like_article");

            migrationBuilder.DropTable(
                name: "ArticleImage",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_like_article_ArticleId",
                schema: "public",
                table: "like_article");

            migrationBuilder.DropIndex(
                name: "IX_comment_ArticleId",
                schema: "public",
                table: "comment");

            migrationBuilder.AddColumn<bool>(
                name: "Liked",
                schema: "public",
                table: "like_comment",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ArcticleId",
                schema: "public",
                table: "like_article",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ArcticleId",
                schema: "public",
                table: "comment",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ArcticleImage",
                schema: "public",
                columns: table => new
                {
                    ArcticlesId = table.Column<int>(type: "integer", nullable: false),
                    ImagesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArcticleImage", x => new { x.ArcticlesId, x.ImagesId });
                    table.ForeignKey(
                        name: "FK_ArcticleImage_arcticles_ArcticlesId",
                        column: x => x.ArcticlesId,
                        principalSchema: "public",
                        principalTable: "arcticles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArcticleImage_images_ImagesId",
                        column: x => x.ImagesId,
                        principalSchema: "public",
                        principalTable: "images",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_like_article_ArcticleId",
                schema: "public",
                table: "like_article",
                column: "ArcticleId");

            migrationBuilder.CreateIndex(
                name: "IX_comment_ArcticleId",
                schema: "public",
                table: "comment",
                column: "ArcticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArcticleImage_ImagesId",
                schema: "public",
                table: "ArcticleImage",
                column: "ImagesId");

            migrationBuilder.AddForeignKey(
                name: "FK_comment_arcticles_ArcticleId",
                schema: "public",
                table: "comment",
                column: "ArcticleId",
                principalSchema: "public",
                principalTable: "arcticles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_like_article_arcticles_ArcticleId",
                schema: "public",
                table: "like_article",
                column: "ArcticleId",
                principalSchema: "public",
                principalTable: "arcticles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
