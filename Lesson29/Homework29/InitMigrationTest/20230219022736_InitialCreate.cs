using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Homework29.InitMigrationTest
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "actors",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(maxLength: 50, nullable: false),
                    last_name = table.Column<string>(maxLength: 50, nullable: false),
                    date_of_birth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "awards",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    award_name = table.Column<string>(maxLength: 100, nullable: false),
                    category = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_awards", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "films",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    film_name = table.Column<string>(maxLength: 50, nullable: false),
                    date_of_production = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_films", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "castings",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ActorId = table.Column<int>(nullable: false),
                    FilmId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_castings", x => x.id);
                    table.ForeignKey(
                        name: "FK_castings_actors_ActorId",
                        column: x => x.ActorId,
                        principalSchema: "public",
                        principalTable: "actors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_castings_films_FilmId",
                        column: x => x.FilmId,
                        principalSchema: "public",
                        principalTable: "films",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "awardings",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CastingId = table.Column<int>(nullable: false),
                    AwardId = table.Column<int>(nullable: false),
                    date_of_awarding = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_awardings", x => x.id);
                    table.ForeignKey(
                        name: "FK_awardings_awards_AwardId",
                        column: x => x.AwardId,
                        principalSchema: "public",
                        principalTable: "awards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_awardings_castings_CastingId",
                        column: x => x.CastingId,
                        principalSchema: "public",
                        principalTable: "castings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_awardings_AwardId",
                schema: "public",
                table: "awardings",
                column: "AwardId");

            migrationBuilder.CreateIndex(
                name: "IX_awardings_CastingId",
                schema: "public",
                table: "awardings",
                column: "CastingId");

            migrationBuilder.CreateIndex(
                name: "IX_castings_ActorId",
                schema: "public",
                table: "castings",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_castings_FilmId",
                schema: "public",
                table: "castings",
                column: "FilmId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "awardings",
                schema: "public");

            migrationBuilder.DropTable(
                name: "awards",
                schema: "public");

            migrationBuilder.DropTable(
                name: "castings",
                schema: "public");

            migrationBuilder.DropTable(
                name: "actors",
                schema: "public");

            migrationBuilder.DropTable(
                name: "films",
                schema: "public");
        }
    }
}
