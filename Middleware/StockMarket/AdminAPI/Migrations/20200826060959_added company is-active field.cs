using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminAPI.Migrations
{
    public partial class addedcompanyisactivefield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Company",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Company");
        }
    }
}
