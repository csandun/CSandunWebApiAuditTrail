using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSandunWebApiAuditTrail.Migrations
{
    public partial class addalterlogaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Action",
                table: "AuditLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Action",
                table: "AuditLogs");
        }
    }
}
