using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class CalculatedDutyEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalculatedDuties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleType = table.Column<string>(maxLength: 500, nullable: false),
                    ChassisNo = table.Column<string>(nullable: false),
                    VehicleMake = table.Column<string>(nullable: false),
                    VehicleModel = table.Column<string>(nullable: false),
                    YearOfManufacture = table.Column<string>(nullable: false),
                    HDV = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CC = table.Column<string>(nullable: false),
                    DepreciationAllow = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FOB = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Freight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Insurance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CIFForginCurrency = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyName = table.Column<string>(nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CIFLocalCurrency = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HsCode = table.Column<string>(nullable: false),
                    ImportDuty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProcessingFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VAT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Shipper = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NHIL = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InterestCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ecowas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetworkCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EXIM = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetChargeVAT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExamFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetChargeNHIL = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SpecialImpLevy = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OverAgePenalty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalDutyBeforeDeduction = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalDutyAfterDeduction = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    TransactionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculatedDuties", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculatedDuties");
        }
    }
}
