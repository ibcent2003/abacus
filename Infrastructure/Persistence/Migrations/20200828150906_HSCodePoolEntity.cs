using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class HSCodePoolEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Heading",
                table: "ClassifyHscodes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HSCodePools",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(maxLength: 50, nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    DeletedBy = table.Column<string>(maxLength: 50, nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    HSCode = table.Column<string>(maxLength: 20, nullable: false),
                    Heading = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    StandardUnitOfQuantity = table.Column<string>(maxLength: 10, nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSCodePools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HSCodePools_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HSCodePools_CountryId",
                table: "HSCodePools",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HSCodePools");

            migrationBuilder.DropColumn(
                name: "Heading",
                table: "ClassifyHscodes");
        }
    }
}
