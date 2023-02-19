using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Homework29.AddHightToActorMigartion
{
    public partial class AddHightToActor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "awarding_competitiors",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AwardingId = table.Column<int>(nullable: false),
                    ActorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_awarding_competitiors", x => x.id);
                    table.ForeignKey(
                        name: "FK_awarding_competitiors_actors_ActorId",
                        column: x => x.ActorId,
                        principalSchema: "public",
                        principalTable: "actors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_awarding_competitiors_awardings_AwardingId",
                        column: x => x.AwardingId,
                        principalSchema: "public",
                        principalTable: "awardings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_awarding_competitiors_ActorId",
                schema: "public",
                table: "awarding_competitiors",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_awarding_competitiors_AwardingId",
                schema: "public",
                table: "awarding_competitiors",
                column: "AwardingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "awarding_competitiors",
                schema: "public");
        }
    }
}
