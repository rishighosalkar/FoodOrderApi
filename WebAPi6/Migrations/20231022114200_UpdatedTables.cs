using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPi6.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Meals_MealId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_MealId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MealId",
                table: "Orders",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Meals_MealId",
                table: "Orders",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id");
        }
    }
}
