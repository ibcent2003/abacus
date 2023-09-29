using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class DependentPermissionPermissionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DependentPermissionId",
                table: "Permissions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_DependentPermissionId",
                table: "Permissions",
                column: "DependentPermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Permissions_DependentPermissionId",
                table: "Permissions",
                column: "DependentPermissionId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Permissions_DependentPermissionId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_DependentPermissionId",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "DependentPermissionId",
                table: "Permissions");
        }
    }
}
