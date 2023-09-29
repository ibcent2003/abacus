using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class HasWorkflowApprovalProcess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Subscribers_DocumentId",
                table: "Subscribers");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Subscribers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Subscribers_DocumentId",
                table: "Subscribers",
                column: "DocumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Subscribers_DocumentId",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Subscribers");

            migrationBuilder.CreateIndex(
                name: "IX_Subscribers_DocumentId",
                table: "Subscribers",
                column: "DocumentId",
                unique: true);
        }
    }
}
