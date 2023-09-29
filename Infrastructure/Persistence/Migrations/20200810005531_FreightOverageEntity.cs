using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class FreightOverageEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FreightOverages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleTypeId = table.Column<int>(nullable: false),
                    OverAgeName = table.Column<string>(maxLength: 250, nullable: false),
                    OverAgeRate = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    MinimumAge = table.Column<int>(nullable: false),
                    MaximumAge = table.Column<int>(nullable: false),
                    FreightName = table.Column<string>(maxLength: 250, nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    MinimumCC = table.Column<int>(nullable: false),
                    MaximumCC = table.Column<int>(nullable: false),
                    HsCode = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreightOverages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FreightOverages_VehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FreightOverages_VehicleTypeId",
                table: "FreightOverages",
                column: "VehicleTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FreightOverages");
        }
    }
}
