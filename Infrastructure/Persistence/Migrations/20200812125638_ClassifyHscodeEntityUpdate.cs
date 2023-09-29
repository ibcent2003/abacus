using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class ClassifyHscodeEntityUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImportExcise",
                table: "ClassifyHscodes");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ClassifyHscodes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StandardUnitOfQuantity",
                table: "ClassifyHscodes",
                maxLength: 10,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ClassifyHscodes");

            migrationBuilder.DropColumn(
                name: "StandardUnitOfQuantity",
                table: "ClassifyHscodes");

            migrationBuilder.AddColumn<decimal>(
                name: "ImportExcise",
                table: "ClassifyHscodes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
