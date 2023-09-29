using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class UserTariffEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTariffs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HsCodePoolId = table.Column<int>(nullable: false),
                    HSCodeTariffTaxId = table.Column<int>(nullable: false),
                    TariffValue = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    IsRate = table.Column<bool>(nullable: false),
                    TransactionId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTariffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTariffs_hSCodeTariffTaxes_HSCodeTariffTaxId",
                        column: x => x.HSCodeTariffTaxId,
                        principalTable: "hSCodeTariffTaxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTariffs_HSCodePools_HsCodePoolId",
                        column: x => x.HsCodePoolId,
                        principalTable: "HSCodePools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTariffs_HSCodeTariffTaxId",
                table: "UserTariffs",
                column: "HSCodeTariffTaxId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTariffs_HsCodePoolId",
                table: "UserTariffs",
                column: "HsCodePoolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTariffs");
        }
    }
}
