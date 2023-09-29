using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class HSCodeDocumentEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HSCodeDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HsCodePoolId = table.Column<int>(nullable: false),
                    DocumentTypeId = table.Column<int>(nullable: false)
                }
               );

            //migrationBuilder.CreateIndex(
            //    name: "IX_HSCodeDocuments_DocumentTypeId",
            //    table: "HSCodeDocuments",
            //    column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HSCodeDocuments_HsCodePoolId",
                table: "HSCodeDocuments",
                column: "HsCodePoolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HSCodeDocuments");
        }
    }
}
