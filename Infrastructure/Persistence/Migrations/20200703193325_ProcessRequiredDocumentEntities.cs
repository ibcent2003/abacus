using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class ProcessRequiredDocumentEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Subscribers",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(125)",
                oldMaxLength: 125);

            migrationBuilder.AddColumn<int>(
                name: "ProcessId",
                table: "Subscribers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Processes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessName = table.Column<string>(maxLength: 125, nullable: false),
                    ProcessDescription = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequiredDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentName = table.Column<string>(maxLength: 125, nullable: false),
                    DocumentDescription = table.Column<string>(maxLength: 250, nullable: false),
                    DocumentFormatString = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequiredDocuments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessRequiredDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessId = table.Column<int>(nullable: false),
                    RequiredDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessRequiredDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessRequiredDocuments_Processes_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcessRequiredDocuments_RequiredDocuments_RequiredDocumentId",
                        column: x => x.RequiredDocumentId,
                        principalTable: "RequiredDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subscribers_ProcessId",
                table: "Subscribers",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessRequiredDocuments_ProcessId",
                table: "ProcessRequiredDocuments",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessRequiredDocuments_RequiredDocumentId",
                table: "ProcessRequiredDocuments",
                column: "RequiredDocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribers_Processes_ProcessId",
                table: "Subscribers",
                column: "ProcessId",
                principalTable: "Processes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscribers_Processes_ProcessId",
                table: "Subscribers");

            migrationBuilder.DropTable(
                name: "ProcessRequiredDocuments");

            migrationBuilder.DropTable(
                name: "Processes");

            migrationBuilder.DropTable(
                name: "RequiredDocuments");

            migrationBuilder.DropIndex(
                name: "IX_Subscribers_ProcessId",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "ProcessId",
                table: "Subscribers");

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Subscribers",
                type: "nvarchar(125)",
                maxLength: 125,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 256);
        }
    }
}
