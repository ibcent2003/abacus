using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class VehicleSearchPoolUpdatePool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CalculatedBy",
                table: "VehicleSearchPools",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CalculatedDate",
                table: "VehicleSearchPools",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DutyResult",
                table: "VehicleSearchPools",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalculatedBy",
                table: "VehicleSearchPools");

            migrationBuilder.DropColumn(
                name: "CalculatedDate",
                table: "VehicleSearchPools");

            migrationBuilder.DropColumn(
                name: "DutyResult",
                table: "VehicleSearchPools");
        }
    }
}
