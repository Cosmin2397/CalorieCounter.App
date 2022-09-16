using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieCounter.Migrations
{
    public partial class AddAddToFoodTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DaysTotal_Expecteds_ExpectedValuesId",
                table: "DaysTotal");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodToAdd_FoodDashes_FoodDashId",
                table: "FoodToAdd");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodToAdd_Foods_FoodId",
                table: "FoodToAdd");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodToAdd",
                table: "FoodToAdd");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expecteds",
                table: "Expecteds");

            migrationBuilder.RenameTable(
                name: "FoodToAdd",
                newName: "FoodsToAdd");

            migrationBuilder.RenameTable(
                name: "Expecteds",
                newName: "Expected");

            migrationBuilder.RenameIndex(
                name: "IX_FoodToAdd_FoodId",
                table: "FoodsToAdd",
                newName: "IX_FoodsToAdd_FoodId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodToAdd_FoodDashId",
                table: "FoodsToAdd",
                newName: "IX_FoodsToAdd_FoodDashId");

            migrationBuilder.AlterColumn<double>(
                name: "Servings",
                table: "FoodsToAdd",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodsToAdd",
                table: "FoodsToAdd",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expected",
                table: "Expected",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DaysTotal_Expected_ExpectedValuesId",
                table: "DaysTotal",
                column: "ExpectedValuesId",
                principalTable: "Expected",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodsToAdd_FoodDashes_FoodDashId",
                table: "FoodsToAdd",
                column: "FoodDashId",
                principalTable: "FoodDashes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodsToAdd_Foods_FoodId",
                table: "FoodsToAdd",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DaysTotal_Expected_ExpectedValuesId",
                table: "DaysTotal");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodsToAdd_FoodDashes_FoodDashId",
                table: "FoodsToAdd");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodsToAdd_Foods_FoodId",
                table: "FoodsToAdd");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodsToAdd",
                table: "FoodsToAdd");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expected",
                table: "Expected");

            migrationBuilder.RenameTable(
                name: "FoodsToAdd",
                newName: "FoodToAdd");

            migrationBuilder.RenameTable(
                name: "Expected",
                newName: "Expecteds");

            migrationBuilder.RenameIndex(
                name: "IX_FoodsToAdd_FoodId",
                table: "FoodToAdd",
                newName: "IX_FoodToAdd_FoodId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodsToAdd_FoodDashId",
                table: "FoodToAdd",
                newName: "IX_FoodToAdd_FoodDashId");

            migrationBuilder.AlterColumn<int>(
                name: "Servings",
                table: "FoodToAdd",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodToAdd",
                table: "FoodToAdd",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expecteds",
                table: "Expecteds",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DaysTotal_Expecteds_ExpectedValuesId",
                table: "DaysTotal",
                column: "ExpectedValuesId",
                principalTable: "Expecteds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodToAdd_FoodDashes_FoodDashId",
                table: "FoodToAdd",
                column: "FoodDashId",
                principalTable: "FoodDashes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodToAdd_Foods_FoodId",
                table: "FoodToAdd",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
