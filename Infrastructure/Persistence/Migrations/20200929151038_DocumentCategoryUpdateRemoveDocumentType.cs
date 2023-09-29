using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class DocumentCategoryUpdateRemoveDocumentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentCategories_DocumentTypes",
                table: "DocumentCategories");

            //migrationBuilder.DropIndex(
            //    name: "IX_DocumentCategories_DocumentTypeId",
            //    table: "DocumentCategories");

            migrationBuilder.DropColumn(
                name: "DocumentTypeId",
                table: "DocumentCategories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocumentTypeId",
                table: "DocumentCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentCategories_DocumentTypeId",
                table: "DocumentCategories",
                column: "DocumentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentCategories_DocumentTypes_DocumentTypeId",
                table: "DocumentCategories",
                column: "DocumentTypeId",
                principalTable: "DocumentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
