using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class AddsubscriberIdToRequiredDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInternalUse",
                table: "RequiredDocuments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SubscriberId",
                table: "RequiredDocuments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequiredDocuments_SubscriberId",
                table: "RequiredDocuments",
                column: "SubscriberId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequiredDocuments_Subscribers_SubscriberId",
                table: "RequiredDocuments",
                column: "SubscriberId",
                principalTable: "Subscribers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequiredDocuments_Subscribers_SubscriberId",
                table: "RequiredDocuments");

            migrationBuilder.DropIndex(
                name: "IX_RequiredDocuments_SubscriberId",
                table: "RequiredDocuments");

            migrationBuilder.DropColumn(
                name: "IsInternalUse",
                table: "RequiredDocuments");

            migrationBuilder.DropColumn(
                name: "SubscriberId",
                table: "RequiredDocuments");
        }
    }
}
