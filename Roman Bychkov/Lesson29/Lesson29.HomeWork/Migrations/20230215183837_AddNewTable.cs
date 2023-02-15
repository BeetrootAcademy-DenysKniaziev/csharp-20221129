using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Lesson29.HomeWork.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "production_film",
                schema: "public");
        }
    }
}
