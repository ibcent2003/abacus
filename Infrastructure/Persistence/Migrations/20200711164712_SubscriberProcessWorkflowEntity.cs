using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class SubscriberProcessWorkflowEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscribers_Processes_ProcessId",
                table: "Subscribers");

            migrationBuilder.DropIndex(
                name: "IX_Subscribers_ProcessId",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "ProcessId",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "WorkFlowProcessId",
                table: "Subscribers");

            migrationBuilder.AddColumn<string>(
                name: "WorkflowSchemeCode",
                table: "Subscribers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsInternal",
                table: "Processes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "SubscriberProcessWorkflows",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriberId = table.Column<int>(nullable: false),
                    ProcessId = table.Column<int>(nullable: false),
                    WorkflowSchemeCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriberProcessWorkflows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriberProcessWorkflows_Processes_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubscriberProcessWorkflows_Subscribers_SubscriberId",
                        column: x => x.SubscriberId,
                        principalTable: "Subscribers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubscriberProcessWorkflows_ProcessId",
                table: "SubscriberProcessWorkflows",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriberProcessWorkflows_SubscriberId",
                table: "SubscriberProcessWorkflows",
                column: "SubscriberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubscriberProcessWorkflows");

            migrationBuilder.DropColumn(
                name: "WorkflowSchemeCode",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "IsInternal",
                table: "Processes");

            migrationBuilder.AddColumn<int>(
                name: "ProcessId",
                table: "Subscribers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "WorkFlowProcessId",
                table: "Subscribers",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Subscribers_ProcessId",
                table: "Subscribers",
                column: "ProcessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribers_Processes_ProcessId",
                table: "Subscribers",
                column: "ProcessId",
                principalTable: "Processes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
