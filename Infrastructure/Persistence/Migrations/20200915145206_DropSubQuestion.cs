using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class DropSubQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "SubQuestion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "SubQuestion",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   Name = table.Column<string>(nullable: false),
                   HeadingId = table.Column<int>(nullable: false),
                   SetupTypeId = table.Column<int>(nullable: false),
                   Category = table.Column<string>(maxLength: 50, nullable: true),
                   IsFinal = table.Column<bool>(nullable: false),
                   ModifiedBy = table.Column<string>(maxLength: 50, nullable: false),
                   ModifiedDate = table.Column<DateTime>(nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_SubQuestion", x => x.Id);
                   table.ForeignKey(
                       name: "FK_SubQuestion_Heading_HeadingId",
                       column: x => x.HeadingId,
                       principalTable: "Heading",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
                   table.ForeignKey(
                       name: "FK_SubQuestion_SetupType_SetupTypeId",
                       column: x => x.SetupTypeId,
                       principalTable: "SetupType",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
               });

            migrationBuilder.CreateIndex(
                name: "IX_SubQuestion_HeadingId",
                table: "SubQuestion",
                column: "HeadingId");

            migrationBuilder.CreateIndex(
                name: "IX_SubQuestion_SetupTypeId",
                table: "SubQuestion",
                column: "SetupTypeId");
        }
    }
}
