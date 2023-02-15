using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lesson29.HomeWork.Migrations
{
    /// <inheritdoc />
    public partial class An_unnecessary_genrefilm_connection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmGenre",
                schema: "public");

            migrationBuilder.AddColumn<int>(
                name: "FilmId",
                schema: "public",
                table: "genre",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_genre_FilmId",
                schema: "public",
                table: "genre",
                column: "FilmId");

            migrationBuilder.AddForeignKey(
                name: "FK_genre_films_FilmId",
                schema: "public",
                table: "genre",
                column: "FilmId",
                principalSchema: "public",
                principalTable: "films",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_genre_films_FilmId",
                schema: "public",
                table: "genre");

            migrationBuilder.DropIndex(
                name: "IX_genre_FilmId",
                schema: "public",
                table: "genre");

            migrationBuilder.DropColumn(
                name: "FilmId",
                schema: "public",
                table: "genre");

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
                        name: "FK_FilmGenre_genre_GenresId",
                        column: x => x.GenresId,
                        principalSchema: "public",
                        principalTable: "genre",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmGenre_GenresId",
                schema: "public",
                table: "FilmGenre",
                column: "GenresId");
        }
    }
}
