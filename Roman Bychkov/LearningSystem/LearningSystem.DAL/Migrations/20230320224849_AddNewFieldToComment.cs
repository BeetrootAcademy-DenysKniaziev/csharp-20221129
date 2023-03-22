using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddNewFieldToComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "created",
                schema: "public",
                table: "users",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "created",
                schema: "public",
                table: "courses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "content",
                schema: "public",
                table: "comment",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "created",
                schema: "public",
                table: "comment",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created",
                schema: "public",
                table: "users");

            migrationBuilder.DropColumn(
                name: "created",
                schema: "public",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "content",
                schema: "public",
                table: "comment");

            migrationBuilder.DropColumn(
                name: "created",
                schema: "public",
                table: "comment");
        }
    }
}
