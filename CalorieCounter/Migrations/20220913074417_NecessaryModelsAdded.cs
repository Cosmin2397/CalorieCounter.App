using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieCounter.Migrations
{
    public partial class NecessaryModelsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Expecteds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpectedKcal = table.Column<double>(type: "float", nullable: false),
                    ExpectedProtein = table.Column<double>(type: "float", nullable: false),
                    ExpectedCarbs = table.Column<double>(type: "float", nullable: false),
                    ExpectedFats = table.Column<double>(type: "float", nullable: false),
                    ExpectedFibers = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expecteds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodDashes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Meal = table.Column<int>(type: "int", nullable: false),
                    TotalMealWeight = table.Column<double>(type: "float", nullable: false),
                    TotalMealKcal = table.Column<double>(type: "float", nullable: false),
                    TotalWeight = table.Column<double>(type: "float", nullable: false),
                    TotalKcal = table.Column<double>(type: "float", nullable: false),
                    TotalProtein = table.Column<double>(type: "float", nullable: false),
                    TotalCarbs = table.Column<double>(type: "float", nullable: false),
                    TotalFats = table.Column<double>(type: "float", nullable: false),
                    TotalFibers = table.Column<double>(type: "float", nullable: false),
                    DayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodDashes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DaysTotal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DayFoodsId = table.Column<int>(type: "int", nullable: false),
                    ExpectedValuesId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaysTotal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DaysTotal_Expecteds_ExpectedValuesId",
                        column: x => x.ExpectedValuesId,
                        principalTable: "Expecteds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DaysTotal_FoodDashes_DayFoodsId",
                        column: x => x.DayFoodsId,
                        principalTable: "FoodDashes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodToAdd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Servings = table.Column<int>(type: "int", nullable: false),
                    ServingWeight = table.Column<int>(type: "int", nullable: false),
                    TotalWeight = table.Column<double>(type: "float", nullable: false),
                    TotalKcalFood = table.Column<double>(type: "float", nullable: false),
                    TotalProteinFood = table.Column<double>(type: "float", nullable: false),
                    TotalCarbsFood = table.Column<double>(type: "float", nullable: false),
                    TotalFatsFood = table.Column<double>(type: "float", nullable: false),
                    TotalFibersFood = table.Column<double>(type: "float", nullable: false),
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    MealTypeId = table.Column<int>(type: "int", nullable: false),
                    FoodDashId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodToAdd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodToAdd_FoodDashes_FoodDashId",
                        column: x => x.FoodDashId,
                        principalTable: "FoodDashes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FoodToAdd_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DaysTotal_DayFoodsId",
                table: "DaysTotal",
                column: "DayFoodsId");

            migrationBuilder.CreateIndex(
                name: "IX_DaysTotal_ExpectedValuesId",
                table: "DaysTotal",
                column: "ExpectedValuesId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodToAdd_FoodDashId",
                table: "FoodToAdd",
                column: "FoodDashId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodToAdd_FoodId",
                table: "FoodToAdd",
                column: "FoodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DaysTotal");

            migrationBuilder.DropTable(
                name: "FoodToAdd");

            migrationBuilder.DropTable(
                name: "Expecteds");

            migrationBuilder.DropTable(
                name: "FoodDashes");
        }
    }
}
