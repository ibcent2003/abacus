using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class CalculatedDutyUpdateWithCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "CalculatedDuties",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CalculatedDuties_CountryId",
                table: "CalculatedDuties",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CalculatedDuties_Countries_CountryId",
                table: "CalculatedDuties",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalculatedDuties_Countries_CountryId",
                table: "CalculatedDuties");

            migrationBuilder.DropIndex(
                name: "IX_CalculatedDuties_CountryId",
                table: "CalculatedDuties");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "CalculatedDuties");
        }
    }
}
