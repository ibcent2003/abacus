using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class UserApprovalRolesEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrganisationApprovalRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(maxLength: 50, nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    DeletedBy = table.Column<string>(maxLength: 50, nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    SubscriberId = table.Column<int>(nullable: false),
                    RoleName = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganisationApprovalRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganisationApprovalRoles_Subscribers_SubscriberId",
                        column: x => x.SubscriberId,
                        principalTable: "Subscribers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganisationUserApprovalRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(maxLength: 50, nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    DeletedBy = table.Column<string>(maxLength: 50, nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<string>(maxLength: 40, nullable: false),
                    SubscriberId = table.Column<int>(nullable: false),
                    OrganisationApprovalRoleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganisationUserApprovalRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganisationUserApprovalRole_OrganisationApprovalRoles_OrganisationApprovalRoleId",
                        column: x => x.OrganisationApprovalRoleId,
                        principalTable: "OrganisationApprovalRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganisationUserApprovalRole_Subscribers_SubscriberId",
                        column: x => x.SubscriberId,
                        principalTable: "Subscribers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrganisationApprovalRoles_SubscriberId",
                table: "OrganisationApprovalRoles",
                column: "SubscriberId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganisationUserApprovalRole_OrganisationApprovalRoleId",
                table: "OrganisationUserApprovalRole",
                column: "OrganisationApprovalRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganisationUserApprovalRole_SubscriberId",
                table: "OrganisationUserApprovalRole",
                column: "SubscriberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganisationUserApprovalRole");

            migrationBuilder.DropTable(
                name: "OrganisationApprovalRoles");
        }
    }
}
