using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class AddResourceAreaEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resources_TopResources_ParentId",
                table: "Resources");

            migrationBuilder.DropIndex(
                name: "IX_Resources_ParentId",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "IconUrl",
                table: "TopResources");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "ResourceArea",
                table: "Resources");

            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "Resources",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ResourceAreas",
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
                    ParentId = table.Column<int>(nullable: false),
                    AreaName = table.Column<string>(maxLength: 30, nullable: false),
                    LocalizationKey = table.Column<string>(nullable: false),
                    IconUrl = table.Column<string>(maxLength: 15, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceAreas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceAreas_TopResources_ParentId",
                        column: x => x.ParentId,
                        principalTable: "TopResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resources_AreaId",
                table: "Resources",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceAreas_ParentId",
                table: "ResourceAreas",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_ResourceAreas_AreaId",
                table: "Resources",
                column: "AreaId",
                principalTable: "ResourceAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resources_ResourceAreas_AreaId",
                table: "Resources");

            migrationBuilder.DropTable(
                name: "ResourceAreas");

            migrationBuilder.DropIndex(
                name: "IX_Resources_AreaId",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "Resources");

            migrationBuilder.AddColumn<string>(
                name: "IconUrl",
                table: "TopResources",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Resources",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ResourceArea",
                table: "Resources",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_ParentId",
                table: "Resources",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_TopResources_ParentId",
                table: "Resources",
                column: "ParentId",
                principalTable: "TopResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
