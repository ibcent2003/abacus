using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class DropTariff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "HSCodeTariff");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "HSCodeTariff",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   HsCode = table.Column<string>(maxLength: 20, nullable: false),
                   HeadingId = table.Column<int>(nullable: false),
                   QuestionId = table.Column<int>(nullable: false),
                   HeaderId = table.Column<int>(nullable: false),
                   Flow = table.Column<string>(maxLength: 5, nullable: false),
                   Photo = table.Column<string>(maxLength: 100, nullable: true),
                   Description = table.Column<string>(nullable: true),
                   LegalNote = table.Column<string>(nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_HSCodeTariff", x => x.Id);
                   table.ForeignKey(
                       name: "FK_HSCodeTariff_Header_HeaderId",
                       column: x => x.HeaderId,
                       principalTable: "Header",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
                   table.ForeignKey(
                       name: "FK_HSCodeTariff_Heading_HeadingId",
                       column: x => x.HeadingId,
                       principalTable: "Heading",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
               });

            migrationBuilder.CreateIndex(
                name: "IX_HSCodeTariff_HeaderId",
                table: "HSCodeTariff",
                column: "HeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_HSCodeTariff_HeadingId",
                table: "HSCodeTariff",
                column: "HeadingId");
        }
    }
}
