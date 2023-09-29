using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class CalculatedDutyentityUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "CalculatedDuties",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FuelType",
                table: "CalculatedDuties",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NoOfDoors",
                table: "CalculatedDuties",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SeatingCapacity",
                table: "CalculatedDuties",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SpecialFeatures",
                table: "CalculatedDuties",
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "CalculatedDuties");

            migrationBuilder.DropColumn(
                name: "FuelType",
                table: "CalculatedDuties");

            migrationBuilder.DropColumn(
                name: "NoOfDoors",
                table: "CalculatedDuties");

            migrationBuilder.DropColumn(
                name: "SeatingCapacity",
                table: "CalculatedDuties");

            migrationBuilder.DropColumn(
                name: "SpecialFeatures",
                table: "CalculatedDuties");
        }
    }
}
