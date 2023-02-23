using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Lesson29.HomeWork.Migrations
{
    /// <inheritdoc />
    public partial class Deleted_useless_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "genre_film",
                schema: "public");

            migrationBuilder.DropTable(
                name: "production_film",
                schema: "public");

            migrationBuilder.CreateTable(
                name: "FilmGenre",
                schema: "public",
                columns: table => new
                {
                    FilmsId = table.Column<int>(type: "integer", nullable: false),
                    GenresId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmGenre", x => new { x.FilmsId, x.GenresId });
                    table.ForeignKey(
                        name: "FK_FilmGenre_films_FilmsId",
                        column: x => x.FilmsId,
                        principalSchema: "public",
                        principalTable: "films",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmGenre_genres_GenresId",
                        column: x => x.GenresId,
                        principalSchema: "public",
                        principalTable: "genres",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmGenre_GenresId",
                schema: "public",
                table: "FilmGenre",
                column: "GenresId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmGenre",
                schema: "public");

            migrationBuilder.CreateTable(
                name: "genre_film",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FilmId = table.Column<int>(type: "integer", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genre_film", x => x.id);
                    table.ForeignKey(
                        name: "FK_genre_film_films_FilmId",
                        column: x => x.FilmId,
                        principalSchema: "public",
                        principalTable: "films",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_genre_film_genres_GenreId",
                        column: x => x.GenreId,
                        principalSchema: "public",
                        principalTable: "genres",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "production_film",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FilmId = table.Column<int>(type: "integer", nullable: false),
                    ProductionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_production_film", x => x.id);
                    table.ForeignKey(
                        name: "FK_production_film_films_FilmId",
                        column: x => x.FilmId,
                        principalSchema: "public",
                        principalTable: "films",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_production_film_production_ProductionId",
                        column: x => x.ProductionId,
                        principalSchema: "public",
                        principalTable: "production",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_genre_film_FilmId",
                schema: "public",
                table: "genre_film",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_genre_film_GenreId",
                schema: "public",
                table: "genre_film",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_production_film_FilmId",
                schema: "public",
                table: "production_film",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_production_film_ProductionId",
                schema: "public",
                table: "production_film",
                column: "ProductionId");
        }
    }
}
