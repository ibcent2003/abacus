using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class DropKeyword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
              name: "Keyword");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Keyword",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    RelatedName = table.Column<string>(nullable: true),
                    HeadingId = table.Column<int>(nullable: false),
                    IsFinal = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keyword", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Keyword_Heading_HeadingId",
                        column: x => x.HeadingId,
                        principalTable: "Heading",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Keyword_HeadingId",
                table: "Keyword",
                column: "HeadingId");
        }
    }
}
