using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LearningSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "courses",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    course_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "images",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    image_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    path = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_images", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    image = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    password = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    mail = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "arcticles",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    arcticle_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CourseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_arcticles", x => x.id);
                    table.ForeignKey(
                        name: "FK_arcticles_courses_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "public",
                        principalTable: "courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "comment",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ArticleId = table.Column<int>(type: "integer", nullable: false),
                    ArcticleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => x.id);
                    table.ForeignKey(
                        name: "FK_comment_arcticles_ArcticleId",
                        column: x => x.ArcticleId,
                        principalSchema: "public",
                        principalTable: "arcticles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comment_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "like_article",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Liked = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ArticleId = table.Column<int>(type: "integer", nullable: false),
                    ArcticleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_like_article", x => x.id);
                    table.ForeignKey(
                        name: "FK_like_article_arcticles_ArcticleId",
                        column: x => x.ArcticleId,
                        principalSchema: "public",
                        principalTable: "arcticles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_like_article_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "like_comment",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Liked = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CommentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_like_comment", x => x.id);
                    table.ForeignKey(
                        name: "FK_like_comment_comment_CommentId",
                        column: x => x.CommentId,
                        principalSchema: "public",
                        principalTable: "comment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_like_comment_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArcticleImage_ImagesId",
                schema: "public",
                table: "ArcticleImage",
                column: "ImagesId");

            migrationBuilder.CreateIndex(
                name: "IX_arcticles_CourseId",
                schema: "public",
                table: "arcticles",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_comment_ArcticleId",
                schema: "public",
                table: "comment",
                column: "ArcticleId");

            migrationBuilder.CreateIndex(
                name: "IX_comment_UserId",
                schema: "public",
                table: "comment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_like_article_ArcticleId",
                schema: "public",
                table: "like_article",
                column: "ArcticleId");

            migrationBuilder.CreateIndex(
                name: "IX_like_article_UserId",
                schema: "public",
                table: "like_article",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_like_comment_CommentId",
                schema: "public",
                table: "like_comment",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_like_comment_UserId",
                schema: "public",
                table: "like_comment",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArcticleImage",
                schema: "public");

            migrationBuilder.DropTable(
                name: "like_article",
                schema: "public");

            migrationBuilder.DropTable(
                name: "like_comment",
                schema: "public");

            migrationBuilder.DropTable(
                name: "images",
                schema: "public");

            migrationBuilder.DropTable(
                name: "comment",
                schema: "public");

            migrationBuilder.DropTable(
                name: "arcticles",
                schema: "public");

            migrationBuilder.DropTable(
                name: "users",
                schema: "public");

            migrationBuilder.DropTable(
                name: "courses",
                schema: "public");
        }
    }
}
