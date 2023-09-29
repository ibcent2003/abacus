using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class HSCodeRecordEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HSCodeRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HsCodePoolId = table.Column<int>(nullable: false),
                    Docs = table.Column<string>(nullable: false),
                    DocumentCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSCodeRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HSCodeRecords_DocumentCategories_DocumentCategoryId",
                        column: x => x.DocumentCategoryId,
                        principalTable: "DocumentCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HSCodeRecords_HSCodePools_HsCodePoolId",
                        column: x => x.HsCodePoolId,
                        principalTable: "HSCodePools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HSCodeRecords_DocumentCategoryId",
                table: "HSCodeRecords",
                column: "DocumentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_HSCodeRecords_HsCodePoolId",
                table: "HSCodeRecords",
                column: "HsCodePoolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HSCodeRecords");
        }
    }
}
