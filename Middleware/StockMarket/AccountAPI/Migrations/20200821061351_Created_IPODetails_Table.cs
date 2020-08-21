using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountAPI.Migrations
{
    public partial class Created_IPODetails_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IPODetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyCode = table.Column<string>(maxLength: 15, nullable: false),
                    StockExchange = table.Column<string>(maxLength: 30, nullable: false),
                    PricePerShare = table.Column<double>(nullable: false),
                    TotalShares = table.Column<long>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Remrks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPODetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IPODetails_Company_CompanyCode",
                        column: x => x.CompanyCode,
                        principalTable: "Company",
                        principalColumn: "CompanyCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IPODetails_CompanyCode",
                table: "IPODetails",
                column: "CompanyCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IPODetails");
        }
    }
}
