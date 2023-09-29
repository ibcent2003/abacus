using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class VehicleFactoryEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleFactories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MakeName = table.Column<string>(nullable: false),
                    ModelName = table.Column<string>(nullable: false),
                    ChassisNo = table.Column<string>(maxLength: 50, nullable: true),
                    AssessedHSCode = table.Column<string>(maxLength: 50, nullable: true),
                    Condition = table.Column<string>(maxLength: 50, nullable: true),
                    SpecialFeatures = table.Column<string>(maxLength: 50, nullable: true),
                    NoOfDoors = table.Column<int>(nullable: false),
                    ManufactureYear = table.Column<string>(maxLength: 50, nullable: true),
                    EngineCapacity = table.Column<string>(maxLength: 50, nullable: true),
                    HDV = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VehicleType = table.Column<string>(nullable: false),
                    Currency = table.Column<string>(maxLength: 50, nullable: true),
                    SeatingCapacity = table.Column<int>(nullable: false),
                    FuelType = table.Column<string>(maxLength: 50, nullable: true),
                    Colour = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleFactories", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleFactories");
        }
    }
}
