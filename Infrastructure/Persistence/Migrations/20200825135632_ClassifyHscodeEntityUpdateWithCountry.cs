using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class ClassifyHscodeEntityUpdateWithCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "ClassifyHscodes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ClassifyHscodes_CountryId",
                table: "ClassifyHscodes",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassifyHscodes_Countries_CountryId",
                table: "ClassifyHscodes",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassifyHscodes_Countries_CountryId",
                table: "ClassifyHscodes");

            migrationBuilder.DropIndex(
                name: "IX_ClassifyHscodes_CountryId",
                table: "ClassifyHscodes");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "ClassifyHscodes");
        }
    }
}
