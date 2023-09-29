using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class DropHeading : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "Heading");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Heading",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   ChapterId = table.Column<int>(nullable: false),
                   Name = table.Column<string>(maxLength: 10, nullable: false),
                   ModifiedBy = table.Column<string>(maxLength: 50, nullable: false),
                   ModifiedDate = table.Column<DateTime>(nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Heading", x => x.Id);
                   table.ForeignKey(
                       name: "FK_Heading_Chapter_ChapterId",
                       column: x => x.ChapterId,
                       principalTable: "Chapter",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
               });

            migrationBuilder.CreateIndex(
                name: "IX_Heading_ChapterId",
                table: "Heading",
                column: "ChapterId");
        }
    }
}
