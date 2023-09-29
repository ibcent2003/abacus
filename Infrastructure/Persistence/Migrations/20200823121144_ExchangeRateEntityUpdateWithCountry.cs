using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class ExchangeRateEntityUpdateWithCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "ExchangeRates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_CountryId",
                table: "ExchangeRates",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExchangeRates_Countries_CountryId",
                table: "ExchangeRates",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExchangeRates_Countries_CountryId",
                table: "ExchangeRates");

            migrationBuilder.DropIndex(
                name: "IX_ExchangeRates_CountryId",
                table: "ExchangeRates");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "ExchangeRates");
        }
    }
}
