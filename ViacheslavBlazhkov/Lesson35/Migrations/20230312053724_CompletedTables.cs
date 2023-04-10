using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lesson35.Migrations
{
    /// <inheritdoc />
    public partial class CompletedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_people_PersonId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_products_ProductId",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "orders",
                newName: "product_id");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "orders",
                newName: "person_id");

            migrationBuilder.RenameIndex(
                name: "IX_orders_ProductId",
                table: "orders",
                newName: "IX_orders_product_id");

            migrationBuilder.RenameIndex(
                name: "IX_orders_PersonId",
                table: "orders",
                newName: "IX_orders_person_id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_people_person_id",
                table: "orders",
                column: "person_id",
                principalTable: "people",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_products_product_id",
                table: "orders",
                column: "product_id",
                principalTable: "products",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_people_person_id",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_products_product_id",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "orders",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "person_id",
                table: "orders",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_orders_product_id",
                table: "orders",
                newName: "IX_orders_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_orders_person_id",
                table: "orders",
                newName: "IX_orders_PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_people_PersonId",
                table: "orders",
                column: "PersonId",
                principalTable: "people",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_products_ProductId",
                table: "orders",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "id");
        }
    }
}
