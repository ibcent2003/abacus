using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class WorkflowInboxMappingEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Subscribers_DocumentId",
                table: "Subscribers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransitionTime",
                table: "DocumentTransitionHistories",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_Subscribers_DocumentId",
                table: "Subscribers",
                column: "DocumentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscribers_ParentId",
                table: "Subscribers",
                column: "ParentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_WorkflowProcessId",
                table: "Documents",
                column: "WorkflowProcessId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropIndex(
                name: "IX_Subscribers_DocumentId",
                table: "Subscribers");

            migrationBuilder.DropIndex(
                name: "IX_Subscribers_ParentId",
                table: "Subscribers");

            migrationBuilder.DropIndex(
                name: "IX_Documents_WorkflowProcessId",
                table: "Documents");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransitionTime",
                table: "DocumentTransitionHistories",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscribers_DocumentId",
                table: "Subscribers",
                column: "DocumentId");
        }
    }
}
