using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class AddPermissionIdToResourceEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Policy",
                table: "Resources");

            migrationBuilder.AddColumn<int>(
                name: "PermissionId",
                table: "Resources",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Resources_PermissionId",
                table: "Resources",
                column: "PermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Permissions_PermissionId",
                table: "Resources",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Permissions_PermissionId",
                table: "Resources");

            migrationBuilder.DropIndex(
                name: "IX_Resources_PermissionId",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "PermissionId",
                table: "Resources");

            migrationBuilder.AddColumn<string>(
                name: "Policy",
                table: "Resources",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
