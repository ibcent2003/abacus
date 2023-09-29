﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class DropHeader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "Header");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Header",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   Name = table.Column<string>(nullable: false),
                   IsUsedInSearchFlow = table.Column<int>(nullable: false),
                   Description = table.Column<string>(nullable: true),
                   ModifiedBy = table.Column<string>(maxLength: 50, nullable: false),
                   ModifiedDate = table.Column<DateTime>(nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Header", x => x.Id);
               });
        }
    }
}
