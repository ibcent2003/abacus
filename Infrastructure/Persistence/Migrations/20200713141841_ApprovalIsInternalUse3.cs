using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class ApprovalIsInternalUse3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganisationApprovalRoles_Subscribers_SubscriberId",
                table: "OrganisationApprovalRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganisationUserApprovalRoles_Subscribers_SubscriberId",
                table: "OrganisationUserApprovalRoles");

            migrationBuilder.AlterColumn<int>(
                name: "SubscriberId",
                table: "OrganisationUserApprovalRoles",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SubscriberId",
                table: "OrganisationApprovalRoles",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganisationApprovalRoles_Subscribers_SubscriberId",
                table: "OrganisationApprovalRoles",
                column: "SubscriberId",
                principalTable: "Subscribers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganisationUserApprovalRoles_Subscribers_SubscriberId",
                table: "OrganisationUserApprovalRoles",
                column: "SubscriberId",
                principalTable: "Subscribers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganisationApprovalRoles_Subscribers_SubscriberId",
                table: "OrganisationApprovalRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganisationUserApprovalRoles_Subscribers_SubscriberId",
                table: "OrganisationUserApprovalRoles");

            migrationBuilder.AlterColumn<int>(
                name: "SubscriberId",
                table: "OrganisationUserApprovalRoles",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SubscriberId",
                table: "OrganisationApprovalRoles",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganisationApprovalRoles_Subscribers_SubscriberId",
                table: "OrganisationApprovalRoles",
                column: "SubscriberId",
                principalTable: "Subscribers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganisationUserApprovalRoles_Subscribers_SubscriberId",
                table: "OrganisationUserApprovalRoles",
                column: "SubscriberId",
                principalTable: "Subscribers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
