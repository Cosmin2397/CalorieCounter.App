using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieCounter.Migrations
{
    public partial class addUserToProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "FoodsToAdd",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "FoodDashes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Expected",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "FoodsToAdd");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "FoodDashes");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Expected");
        }
    }
}
