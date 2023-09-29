using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class ProcessSubmittedDocumentEntity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcessSubmittedDocument_ProcessRequiredDocuments_ProcessRequiredDocumentId",
                table: "ProcessSubmittedDocument");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcessSubmittedDocument",
                table: "ProcessSubmittedDocument");

            migrationBuilder.RenameTable(
                name: "ProcessSubmittedDocument",
                newName: "ProcessSubmittedDocuments");

            migrationBuilder.RenameIndex(
                name: "IX_ProcessSubmittedDocument_ProcessRequiredDocumentId",
                table: "ProcessSubmittedDocuments",
                newName: "IX_ProcessSubmittedDocuments_ProcessRequiredDocumentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcessSubmittedDocuments",
                table: "ProcessSubmittedDocuments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessSubmittedDocuments_ProcessRequiredDocuments_ProcessRequiredDocumentId",
                table: "ProcessSubmittedDocuments",
                column: "ProcessRequiredDocumentId",
                principalTable: "ProcessRequiredDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcessSubmittedDocuments_ProcessRequiredDocuments_ProcessRequiredDocumentId",
                table: "ProcessSubmittedDocuments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcessSubmittedDocuments",
                table: "ProcessSubmittedDocuments");

            migrationBuilder.RenameTable(
                name: "ProcessSubmittedDocuments",
                newName: "ProcessSubmittedDocument");

            migrationBuilder.RenameIndex(
                name: "IX_ProcessSubmittedDocuments_ProcessRequiredDocumentId",
                table: "ProcessSubmittedDocument",
                newName: "IX_ProcessSubmittedDocument_ProcessRequiredDocumentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcessSubmittedDocument",
                table: "ProcessSubmittedDocument",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessSubmittedDocument_ProcessRequiredDocuments_ProcessRequiredDocumentId",
                table: "ProcessSubmittedDocument",
                column: "ProcessRequiredDocumentId",
                principalTable: "ProcessRequiredDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
