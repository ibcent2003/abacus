using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class VehicleSearchPoolEntityUpdateWithChassis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AssessedHSCode",
                table: "VehicleSearchPools",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChassisNo",
                table: "VehicleSearchPools",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssessedHSCode",
                table: "VehicleSearchPools");

            migrationBuilder.DropColumn(
                name: "ChassisNo",
                table: "VehicleSearchPools");
        }
    }
}
