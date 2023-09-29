using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class HSCodeDocumentUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocumentCategoryId",
                table: "HSCodeDocuments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HSCodeDocuments_DocumentCategoryId",
                table: "HSCodeDocuments",
                column: "DocumentCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_HSCodeDocuments_DocumentCategories_DocumentCategoryId",
                table: "HSCodeDocuments",
                column: "DocumentCategoryId",
                principalTable: "DocumentCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HSCodeDocuments_DocumentCategories_DocumentCategoryId",
                table: "HSCodeDocuments");

            migrationBuilder.DropIndex(
                name: "IX_HSCodeDocuments_DocumentCategoryId",
                table: "HSCodeDocuments");

            migrationBuilder.DropColumn(
                name: "DocumentCategoryId",
                table: "HSCodeDocuments");
        }
    }
}
