﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class DocumentTypeUpdateWithCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "DocumentCategoryId",
            //    table: "DocumentTypes",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "DocumentTypeCategoryId",
            //    table: "DocumentTypes",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.CreateIndex(
            //    name: "IX_DocumentTypes_DocumentCategoryId",
            //    table: "DocumentTypes",
            //    column: "DocumentCategoryId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_DocumentTypes_DocumentCategories_DocumentCategoryId",
            //    table: "DocumentTypes",
            //    column: "DocumentCategoryId",
            //    principalTable: "DocumentCategories",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_DocumentTypes_DocumentCategories_DocumentCategoryId",
            //    table: "DocumentTypes");

            //migrationBuilder.DropIndex(
            //    name: "IX_DocumentTypes_DocumentCategoryId",
            //    table: "DocumentTypes");

            //migrationBuilder.DropColumn(
            //    name: "DocumentCategoryId",
            //    table: "DocumentTypes");

            //migrationBuilder.DropColumn(
            //    name: "DocumentTypeCategoryId",
            //    table: "DocumentTypes");
        }
    }
}
