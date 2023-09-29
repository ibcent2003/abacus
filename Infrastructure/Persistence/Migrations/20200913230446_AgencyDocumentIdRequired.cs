using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class AgencyDocumentIdRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AgencyDocuments_HSCodePoolId",
                table: "AgencyDocuments",
                column: "HSCodePoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_AgencyDocuments_HSCodePools_HSCodePoolId",
                table: "AgencyDocuments",
                column: "HSCodePoolId",
                principalTable: "HSCodePools",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgencyDocuments_HSCodePools_HSCodePoolId",
                table: "AgencyDocuments");

            migrationBuilder.DropIndex(
                name: "IX_AgencyDocuments_HSCodePoolId",
                table: "AgencyDocuments");
        }
    }
}
