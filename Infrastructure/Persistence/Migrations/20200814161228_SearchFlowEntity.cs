using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class SearchFlowEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SearchFlow",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(nullable: false),
                    HeaderId = table.Column<int>(nullable: false),
                    Flow = table.Column<string>(nullable: false),
                    HeadingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchFlow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SearchFlow_Header_HeaderId",
                        column: x => x.HeaderId,
                        principalTable: "Header",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SearchFlow_Heading_HeadingId",
                        column: x => x.HeadingId,
                        principalTable: "Heading",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SearchFlow_HeaderId",
                table: "SearchFlow",
                column: "HeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_SearchFlow_HeadingId",
                table: "SearchFlow",
                column: "HeadingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SearchFlow");
        }
    }
}
