using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class UserHSCodePoolUpdateWithExportingCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContainerSize",
                table: "UserHSCodePools",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExportingCountryId",
                table: "UserHSCodePools",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Keyword",
                table: "UserHSCodePools",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContainerSize",
                table: "UserHSCodePools");

            migrationBuilder.DropColumn(
                name: "ExportingCountryId",
                table: "UserHSCodePools");

            migrationBuilder.DropColumn(
                name: "Keyword",
                table: "UserHSCodePools");
        }
    }
}
