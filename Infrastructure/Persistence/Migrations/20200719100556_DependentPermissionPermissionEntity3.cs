using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class DependentPermissionPermissionEntity3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Permissions_DependentPermissionId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_DependentPermissionId",
                table: "Permissions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
