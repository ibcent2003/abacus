using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class VehicleSearchPoolUpdateCurrencyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleSearchPools_Currencies_CurrencyId",
                table: "VehicleSearchPools");

            migrationBuilder.DropIndex(
                name: "IX_VehicleSearchPools_CurrencyId",
                table: "VehicleSearchPools");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "VehicleSearchPools");

            migrationBuilder.AddColumn<int>(
                name: "CurrencyName",
                table: "VehicleSearchPools",
                maxLength: 20,
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyName",
                table: "VehicleSearchPools");

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "VehicleSearchPools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleSearchPools_CurrencyId",
                table: "VehicleSearchPools",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleSearchPools_Currencies_CurrencyId",
                table: "VehicleSearchPools",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
