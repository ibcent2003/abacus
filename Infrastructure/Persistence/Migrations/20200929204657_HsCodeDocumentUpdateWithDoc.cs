using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class HsCodeDocumentUpdateWithDoc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HSCodeDocuments_DocumentTypes_DocumentTypeId",
                table: "HSCodeDocuments");

            //migrationBuilder.DropIndex(
            //    name: "IX_HSCodeDocuments_DocumentTypeId",
            //    table: "HSCodeDocuments");

            migrationBuilder.DropColumn(
                name: "DocumentTypeId",
                table: "HSCodeDocuments");
        }
    }
}
