using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class TariffEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tariffs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HsCodePoolId = table.Column<int>(nullable: false),
                    HSCodeTariffTaxId = table.Column<int>(nullable: false),
                    TariffValue = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    IsRate = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tariffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tariffs_hSCodeTariffTaxes_HSCodeTariffTaxId",
                        column: x => x.HSCodeTariffTaxId,
                        principalTable: "hSCodeTariffTaxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tariffs_HSCodePools_HsCodePoolId",
                        column: x => x.HsCodePoolId,
                        principalTable: "HSCodePools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tariffs_HSCodeTariffTaxId",
                table: "tariffs",
                column: "HSCodeTariffTaxId");

            migrationBuilder.CreateIndex(
                name: "IX_tariffs_HsCodePoolId",
                table: "tariffs",
                column: "HsCodePoolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tariffs");
        }
    }
}
