using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class AgencyUpdateWithCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Agencies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Agencies_CountryId",
                table: "Agencies",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agencies_Countries_CountryId",
                table: "Agencies",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agencies_Countries_CountryId",
                table: "Agencies");

            migrationBuilder.DropIndex(
                name: "IX_Agencies_CountryId",
                table: "Agencies");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Agencies");
        }
    }
}
