using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class ApprovalIsInternalUse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInternalUse",
                table: "OrganisationUserApprovalRoles",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsInternalUse",
                table: "OrganisationApprovalRoles",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInternalUse",
                table: "OrganisationUserApprovalRoles");

            migrationBuilder.DropColumn(
                name: "IsInternalUse",
                table: "OrganisationApprovalRoles");
        }
    }
}
