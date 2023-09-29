using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class ExtraDocumentValuesUpdatedWithAgencyHscode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgencyHsCodeId",
                table: "ExtraDocumentValues",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ExtraDocumentValues_AgencyHsCodeId",
                table: "ExtraDocumentValues",
                column: "AgencyHsCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraDocumentValues_AgencyHsCodes_AgencyHsCodeId",
                table: "ExtraDocumentValues",
                column: "AgencyHsCodeId",
                principalTable: "AgencyHsCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExtraDocumentValues_AgencyHsCodes_AgencyHsCodeId",
                table: "ExtraDocumentValues");

            migrationBuilder.DropIndex(
                name: "IX_ExtraDocumentValues_AgencyHsCodeId",
                table: "ExtraDocumentValues");

            migrationBuilder.DropColumn(
                name: "AgencyHsCodeId",
                table: "ExtraDocumentValues");
        }
    }
}
