using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class UserApprovalRolesEntity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganisationUserApprovalRole_OrganisationApprovalRoles_OrganisationApprovalRoleId",
                table: "OrganisationUserApprovalRole");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganisationUserApprovalRole_Subscribers_SubscriberId",
                table: "OrganisationUserApprovalRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganisationUserApprovalRole",
                table: "OrganisationUserApprovalRole");

            migrationBuilder.RenameTable(
                name: "OrganisationUserApprovalRole",
                newName: "OrganisationUserApprovalRoles");

            migrationBuilder.RenameIndex(
                name: "IX_OrganisationUserApprovalRole_SubscriberId",
                table: "OrganisationUserApprovalRoles",
                newName: "IX_OrganisationUserApprovalRoles_SubscriberId");

            migrationBuilder.RenameIndex(
                name: "IX_OrganisationUserApprovalRole_OrganisationApprovalRoleId",
                table: "OrganisationUserApprovalRoles",
                newName: "IX_OrganisationUserApprovalRoles_OrganisationApprovalRoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganisationUserApprovalRoles",
                table: "OrganisationUserApprovalRoles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganisationUserApprovalRoles_OrganisationApprovalRoles_OrganisationApprovalRoleId",
                table: "OrganisationUserApprovalRoles",
                column: "OrganisationApprovalRoleId",
                principalTable: "OrganisationApprovalRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganisationUserApprovalRoles_Subscribers_SubscriberId",
                table: "OrganisationUserApprovalRoles",
                column: "SubscriberId",
                principalTable: "Subscribers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganisationUserApprovalRoles_OrganisationApprovalRoles_OrganisationApprovalRoleId",
                table: "OrganisationUserApprovalRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganisationUserApprovalRoles_Subscribers_SubscriberId",
                table: "OrganisationUserApprovalRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganisationUserApprovalRoles",
                table: "OrganisationUserApprovalRoles");

            migrationBuilder.RenameTable(
                name: "OrganisationUserApprovalRoles",
                newName: "OrganisationUserApprovalRole");

            migrationBuilder.RenameIndex(
                name: "IX_OrganisationUserApprovalRoles_SubscriberId",
                table: "OrganisationUserApprovalRole",
                newName: "IX_OrganisationUserApprovalRole_SubscriberId");

            migrationBuilder.RenameIndex(
                name: "IX_OrganisationUserApprovalRoles_OrganisationApprovalRoleId",
                table: "OrganisationUserApprovalRole",
                newName: "IX_OrganisationUserApprovalRole_OrganisationApprovalRoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganisationUserApprovalRole",
                table: "OrganisationUserApprovalRole",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganisationUserApprovalRole_OrganisationApprovalRoles_OrganisationApprovalRoleId",
                table: "OrganisationUserApprovalRole",
                column: "OrganisationApprovalRoleId",
                principalTable: "OrganisationApprovalRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganisationUserApprovalRole_Subscribers_SubscriberId",
                table: "OrganisationUserApprovalRole",
                column: "SubscriberId",
                principalTable: "Subscribers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
