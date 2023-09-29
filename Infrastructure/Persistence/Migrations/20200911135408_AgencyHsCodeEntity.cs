using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class AgencyHsCodeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgencyHsCodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgencyId = table.Column<int>(nullable: false),
                    HsCodePoolId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgencyHsCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgencyHsCodes_Agencies_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgencyHsCodes_HSCodePools_HsCodePoolId",
                        column: x => x.HsCodePoolId,
                        principalTable: "HSCodePools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgencyHsCodes_AgencyId",
                table: "AgencyHsCodes",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_AgencyHsCodes_HsCodePoolId",
                table: "AgencyHsCodes",
                column: "HsCodePoolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgencyHsCodes");
        }
    }
}
