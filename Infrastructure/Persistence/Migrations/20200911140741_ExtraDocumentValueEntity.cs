using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class ExtraDocumentValueEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExtraDocumentValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentTypeId = table.Column<int>(nullable: false),
                    ExtraName = table.Column<string>(nullable: false),
                    ExtraValue = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraDocumentValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExtraDocumentValues_DocumentTypes_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExtraDocumentValues_DocumentTypeId",
                table: "ExtraDocumentValues",
                column: "DocumentTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExtraDocumentValues");
        }
    }
}
