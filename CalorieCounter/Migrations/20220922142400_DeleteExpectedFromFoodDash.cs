using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieCounter.Migrations
{
    public partial class DeleteExpectedFromFoodDash : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodDashes_Expected_ExpectedValuesId",
                table: "FoodDashes");

            migrationBuilder.DropIndex(
                name: "IX_FoodDashes_ExpectedValuesId",
                table: "FoodDashes");

            migrationBuilder.DropColumn(
                name: "ExpectedValuesId",
                table: "FoodDashes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExpectedValuesId",
                table: "FoodDashes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FoodDashes_ExpectedValuesId",
                table: "FoodDashes",
                column: "ExpectedValuesId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodDashes_Expected_ExpectedValuesId",
                table: "FoodDashes",
                column: "ExpectedValuesId",
                principalTable: "Expected",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
