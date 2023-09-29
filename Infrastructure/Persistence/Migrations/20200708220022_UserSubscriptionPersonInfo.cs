using Microsoft.EntityFrameworkCore.Migrations;

namespace Wbc.Infrastructure.Persistence.Migrations
{
    public partial class UserSubscriptionPersonInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "UserSubscriptions",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "UserSubscriptions",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "UserSubscriptions",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "UserSubscriptions",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "UserSubscriptions",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "UserSubscriptions");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "UserSubscriptions");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "UserSubscriptions");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "UserSubscriptions");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "UserSubscriptions");
        }
    }
}
