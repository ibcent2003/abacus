using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class SubscriberToDocumentRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocumentId",
                table: "Subscribers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Subscribers_DocumentId",
                table: "Subscribers",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribers_Documents_DocumentId",
                table: "Subscribers",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscribers_Documents_DocumentId",
                table: "Subscribers");

            migrationBuilder.DropIndex(
                name: "IX_Subscribers_DocumentId",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "Subscribers");
        }
    }
}
