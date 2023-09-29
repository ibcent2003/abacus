using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class VehicleSearchPoolEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleSearchPools",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MakeName = table.Column<string>(maxLength: 50, nullable: false),
                    ModelName = table.Column<string>(maxLength: 50, nullable: false),
                    VehicleTypeName = table.Column<string>(maxLength: 50, nullable: false),
                    SpecialFeatureName = table.Column<string>(maxLength: 10, nullable: false),
                    SeatingCapacity = table.Column<int>(maxLength: 10, nullable: false),
                    EngineCapacity = table.Column<string>(maxLength: 10, nullable: false),
                    FuelType = table.Column<string>(maxLength: 10, nullable: false),
                    Year = table.Column<int>(maxLength: 10, nullable: false),
                    OwnedBy = table.Column<string>(maxLength: 50, nullable: true),
                    UserId = table.Column<string>(maxLength: 50, nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    HDV = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactonDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleSearchPools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleSearchPools_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleSearchPools_CurrencyId",
                table: "VehicleSearchPools",
                column: "CurrencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleSearchPools");
        }
    }
}
