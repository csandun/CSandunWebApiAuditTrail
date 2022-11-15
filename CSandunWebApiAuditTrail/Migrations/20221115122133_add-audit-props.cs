using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSandunWebApiAuditTrail.Migrations
{
    public partial class addauditprops : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "TodoItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "TodoItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "TodoItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOnUtc",
                table: "TodoItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "TodoItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOnUtc",
                table: "TodoItems",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "DeletedOnUtc",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "ModifiedOnUtc",
                table: "TodoItems");
        }
    }
}
