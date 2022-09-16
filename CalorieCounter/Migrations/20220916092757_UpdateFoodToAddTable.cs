using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieCounter.Migrations
{
    public partial class UpdateFoodToAddTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Meal",
                table: "FoodDashes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "FoodDashes");

            migrationBuilder.DropColumn(
                name: "TotalMealKcal",
                table: "FoodDashes");

            migrationBuilder.DropColumn(
                name: "TotalMealWeight",
                table: "FoodDashes");

            migrationBuilder.AddColumn<int>(
                name: "DashId",
                table: "FoodsToAdd",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DashId",
                table: "FoodsToAdd");

            migrationBuilder.AddColumn<int>(
                name: "Meal",
                table: "FoodDashes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FoodDashes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "TotalMealKcal",
                table: "FoodDashes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalMealWeight",
                table: "FoodDashes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
