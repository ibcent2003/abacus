using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class ProcessSubmittedDocumentEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "RequiredDocuments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "RequiredDocuments",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "RequiredDocuments",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "RequiredDocuments",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "RequiredDocuments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "RequiredDocuments",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "ProcessRequiredDocuments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ProcessRequiredDocuments",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "ProcessRequiredDocuments",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "ProcessRequiredDocuments",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "ProcessRequiredDocuments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "ProcessRequiredDocuments",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ProcessSubmittedDocument",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentOwnerId = table.Column<int>(nullable: false),
                    ProcessRequiredDocumentId = table.Column<int>(nullable: false),
                    DocumentUrl = table.Column<string>(maxLength: 25, nullable: false),
                    DocumentExtension = table.Column<string>(maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessSubmittedDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessSubmittedDocument_ProcessRequiredDocuments_ProcessRequiredDocumentId",
                        column: x => x.ProcessRequiredDocumentId,
                        principalTable: "ProcessRequiredDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProcessSubmittedDocument_ProcessRequiredDocumentId",
                table: "ProcessSubmittedDocument",
                column: "ProcessRequiredDocumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProcessSubmittedDocument");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "RequiredDocuments");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "RequiredDocuments");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "RequiredDocuments");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "RequiredDocuments");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "RequiredDocuments");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "RequiredDocuments");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "ProcessRequiredDocuments");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ProcessRequiredDocuments");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "ProcessRequiredDocuments");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "ProcessRequiredDocuments");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "ProcessRequiredDocuments");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "ProcessRequiredDocuments");
        }
    }
}
