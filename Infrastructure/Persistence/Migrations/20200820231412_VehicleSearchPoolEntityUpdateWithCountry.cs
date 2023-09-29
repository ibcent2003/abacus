using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class VehicleSearchPoolEntityUpdateWithCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "VehicleSearchPools",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleSearchPools_CountryId",
                table: "VehicleSearchPools",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleSearchPools_Countries_CountryId",
                table: "VehicleSearchPools",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleSearchPools_Countries_CountryId",
                table: "VehicleSearchPools");

            migrationBuilder.DropIndex(
                name: "IX_VehicleSearchPools_CountryId",
                table: "VehicleSearchPools");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "VehicleSearchPools");
        }
    }
}
