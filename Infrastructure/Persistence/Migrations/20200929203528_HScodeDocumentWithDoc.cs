using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class HScodeDocumentWithDoc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_HSCodeDocuments_DocumentTypes_DocumentTypeId",
            //    table: "HSCodeDocuments");

            //migrationBuilder.DropIndex(
            //    name: "IX_HSCodeDocuments_DocumentTypeId",
            //    table: "HSCodeDocuments");

            //migrationBuilder.DropColumn(
            //    name: "DocumentTypeId",
            //    table: "HSCodeDocuments");

            migrationBuilder.AddColumn<string>(
                name: "Docs",
                table: "HSCodeDocuments",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Docs",
                table: "HSCodeDocuments");

            migrationBuilder.AddColumn<int>(
                name: "DocumentTypeId",
                table: "HSCodeDocuments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HSCodeDocuments_DocumentTypeId",
                table: "HSCodeDocuments",
                column: "DocumentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_HSCodeDocuments_DocumentTypes_DocumentTypeId",
                table: "HSCodeDocuments",
                column: "DocumentTypeId",
                principalTable: "DocumentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
