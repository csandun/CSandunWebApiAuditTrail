using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSandunWebApiAuditTrail.Migrations
{
    public partial class addtodosisdelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "TodoItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "TodoItems");
        }
    }
}
