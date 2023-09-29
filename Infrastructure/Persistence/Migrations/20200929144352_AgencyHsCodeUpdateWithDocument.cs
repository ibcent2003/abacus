using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class AgencyHsCodeUpdateWithDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocumentTypeId",
                table: "AgencyHsCodes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AgencyHsCodes_DocumentTypeId",
                table: "AgencyHsCodes",
                column: "DocumentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AgencyHsCodes_DocumentTypes_DocumentTypeId",
                table: "AgencyHsCodes",
                column: "DocumentTypeId",
                principalTable: "DocumentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgencyHsCodes_DocumentTypes_DocumentTypeId",
                table: "AgencyHsCodes");

            migrationBuilder.DropIndex(
                name: "IX_AgencyHsCodes_DocumentTypeId",
                table: "AgencyHsCodes");

            migrationBuilder.DropColumn(
                name: "DocumentTypeId",
                table: "AgencyHsCodes");
        }
    }
}
