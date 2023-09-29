using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class hsdocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //  name: "Docs",
            //  table: "HSCodeDocuments",
            //  nullable: false,
            //  defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HSCodeDocuments_DocumentTypes_DocumentTypeId",
                table: "HSCodeDocuments");

          

            migrationBuilder.DropColumn(
                name: "DocumentTypeId",
                table: "HSCodeDocuments");
        }
    }
}
