using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lesson29.HomeWork.Migrations
{
    /// <inheritdoc />
    public partial class Added_table_roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorFilm_actor_ActorsId",
                schema: "public",
                table: "ActorFilm");

            migrationBuilder.DropForeignKey(
                name: "FK_genre_films_FilmId",
                schema: "public",
                table: "genre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_genre",
                schema: "public",
                table: "genre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_actor",
                schema: "public",
                table: "actor");

            migrationBuilder.RenameTable(
                name: "genre",
                schema: "public",
                newName: "genres",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "actor",
                schema: "public",
                newName: "actors",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "IX_genre_FilmId",
                schema: "public",
                table: "genres",
                newName: "IX_genres_FilmId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_genres",
                schema: "public",
                table: "genres",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_actors",
                schema: "public",
                table: "actors",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorFilm_actors_ActorsId",
                schema: "public",
                table: "ActorFilm",
                column: "ActorsId",
                principalSchema: "public",
                principalTable: "actors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_genres_films_FilmId",
                schema: "public",
                table: "genres",
                column: "FilmId",
                principalSchema: "public",
                principalTable: "films",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorFilm_actors_ActorsId",
                schema: "public",
                table: "ActorFilm");

            migrationBuilder.DropForeignKey(
                name: "FK_genres_films_FilmId",
                schema: "public",
                table: "genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_genres",
                schema: "public",
                table: "genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_actors",
                schema: "public",
                table: "actors");

            migrationBuilder.RenameTable(
                name: "genres",
                schema: "public",
                newName: "genre",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "actors",
                schema: "public",
                newName: "actor",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "IX_genres_FilmId",
                schema: "public",
                table: "genre",
                newName: "IX_genre_FilmId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_genre",
                schema: "public",
                table: "genre",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_actor",
                schema: "public",
                table: "actor",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorFilm_actor_ActorsId",
                schema: "public",
                table: "ActorFilm",
                column: "ActorsId",
                principalSchema: "public",
                principalTable: "actor",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_genre_films_FilmId",
                schema: "public",
                table: "genre",
                column: "FilmId",
                principalSchema: "public",
                principalTable: "films",
                principalColumn: "id");
        }
    }
}
