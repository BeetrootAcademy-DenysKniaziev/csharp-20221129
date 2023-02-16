using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lesson29.HomeWork.Migrations
{
    /// <inheritdoc />
    public partial class Added_new_table_genre_film : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_genres_films_FilmId",
                schema: "public",
                table: "genres");

            migrationBuilder.DropIndex(
                name: "IX_genres_FilmId",
                schema: "public",
                table: "genres");

            migrationBuilder.DropColumn(
                name: "FilmId",
                schema: "public",
                table: "genres");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FilmId",
                schema: "public",
                table: "genres",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_genres_FilmId",
                schema: "public",
                table: "genres",
                column: "FilmId");

            migrationBuilder.AddForeignKey(
                name: "FK_genres_films_FilmId",
                schema: "public",
                table: "genres",
                column: "FilmId",
                principalSchema: "public",
                principalTable: "films",
                principalColumn: "id");
        }
    }
}
