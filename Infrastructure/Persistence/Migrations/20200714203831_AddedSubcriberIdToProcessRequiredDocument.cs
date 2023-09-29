using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class AddedSubcriberIdToProcessRequiredDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Subscribers");

            migrationBuilder.AddColumn<int>(
                name: "SubscriberId",
                table: "ProcessRequiredDocuments",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFinalised",
                table: "Documents",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_ProcessRequiredDocuments_SubscriberId",
                table: "ProcessRequiredDocuments",
                column: "SubscriberId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessRequiredDocuments_Subscribers_SubscriberId",
                table: "ProcessRequiredDocuments",
                column: "SubscriberId",
                principalTable: "Subscribers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcessRequiredDocuments_Subscribers_SubscriberId",
                table: "ProcessRequiredDocuments");

            migrationBuilder.DropIndex(
                name: "IX_ProcessRequiredDocuments_SubscriberId",
                table: "ProcessRequiredDocuments");

            migrationBuilder.DropColumn(
                name: "SubscriberId",
                table: "ProcessRequiredDocuments");

            migrationBuilder.DropColumn(
                name: "IsFinalised",
                table: "Documents");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Subscribers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
