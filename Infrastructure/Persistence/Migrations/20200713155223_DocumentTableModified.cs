using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class DocumentTableModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DocumentSource",
                table: "Subscribers",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProcessName",
                table: "Subscribers",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SubmittedBy",
                table: "Subscribers",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmittedOn",
                table: "Subscribers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DocumentSource",
                table: "Documents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcessName",
                table: "Documents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubmittedBy",
                table: "Documents",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmittedOn",
                table: "Documents",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentSource",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "ProcessName",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "SubmittedBy",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "SubmittedOn",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "DocumentSource",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "ProcessName",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "SubmittedBy",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "SubmittedOn",
                table: "Documents");
        }
    }
}
