using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lesson35.Migrations
{
    /// <inheritdoc />
    public partial class ICr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "products",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "products",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "products",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "products",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "people",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "people",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "people",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "people",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "orders",
                newName: "id");

            migrationBuilder.AddColumn<DateTime>(
                name: "order_time",
                table: "orders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "order_time",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "products",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "products",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "people",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "people",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "people",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "people",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "orders",
                newName: "Id");
        }
    }
}
