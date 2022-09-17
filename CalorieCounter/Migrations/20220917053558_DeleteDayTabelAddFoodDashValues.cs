using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieCounter.Migrations
{
    public partial class DeleteDayTabelAddFoodDashValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DaysTotal");

            migrationBuilder.RenameColumn(
                name: "DayId",
                table: "FoodDashes",
                newName: "UserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "FoodDashes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodDashes_Expected_ExpectedValuesId",
                table: "FoodDashes");

            migrationBuilder.DropIndex(
                name: "IX_FoodDashes_ExpectedValuesId",
                table: "FoodDashes");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "FoodDashes");

            migrationBuilder.DropColumn(
                name: "ExpectedValuesId",
                table: "FoodDashes");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "FoodDashes",
                newName: "DayId");

            migrationBuilder.CreateTable(
                name: "DaysTotal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayFoodsId = table.Column<int>(type: "int", nullable: false),
                    ExpectedValuesId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaysTotal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DaysTotal_Expected_ExpectedValuesId",
                        column: x => x.ExpectedValuesId,
                        principalTable: "Expected",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DaysTotal_FoodDashes_DayFoodsId",
                        column: x => x.DayFoodsId,
                        principalTable: "FoodDashes",
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
        }
    }
}
