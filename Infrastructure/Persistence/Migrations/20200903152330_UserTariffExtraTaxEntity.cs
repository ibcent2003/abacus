using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class UserTariffExtraTaxEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTariffExtraTaxes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxName = table.Column<string>(maxLength: 100, nullable: false),
                    TaxValue = table.Column<decimal>(nullable: false),
                    UserHSCodePoolId = table.Column<int>(nullable: false),
                    TransactionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTariffExtraTaxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTariffExtraTaxes_UserHSCodePools_UserHSCodePoolId",
                        column: x => x.UserHSCodePoolId,
                        principalTable: "UserHSCodePools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTariffExtraTaxes_UserHSCodePoolId",
                table: "UserTariffExtraTaxes",
                column: "UserHSCodePoolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTariffExtraTaxes");
        }
    }
}
