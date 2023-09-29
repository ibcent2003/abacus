using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class ClassifyHscodeEntityUpdateWithLVY : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "LVY",
                table: "ClassifyHscodes",
                type: "decimal(18,2)",
                maxLength: 10,
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LVY",
                table: "ClassifyHscodes");
        }
    }
}
