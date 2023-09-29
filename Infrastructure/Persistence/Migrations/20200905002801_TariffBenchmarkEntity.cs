using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class TariffBenchmarkEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TariffBenchmarks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HSCode = table.Column<string>(maxLength: 20, nullable: true),
                    keywords = table.Column<string>(nullable: true),
                    CountryName = table.Column<string>(nullable: true),
                    Code = table.Column<string>(maxLength: 10, nullable: true),
                    ProductValue = table.Column<float>(nullable: false),
                    Unit = table.Column<string>(nullable: true),
                    Packaging = table.Column<string>(nullable: true),
                    Qty = table.Column<float>(nullable: false),
                    SUOM = table.Column<string>(nullable: true),
                    UnitFOB = table.Column<decimal>(type: "decimal(20,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TariffBenchmarks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TariffBenchmarks");
        }
    }
}
