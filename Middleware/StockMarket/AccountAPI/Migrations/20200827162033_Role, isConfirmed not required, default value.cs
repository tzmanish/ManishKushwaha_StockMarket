using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountAPI.Migrations
{
    public partial class RoleisConfirmednotrequireddefaultvalue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Confirmed",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "User",
                nullable: false,
                defaultValue: Role.user,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "isConfirmed",
                table: "User",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isConfirmed",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Confirmed",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
