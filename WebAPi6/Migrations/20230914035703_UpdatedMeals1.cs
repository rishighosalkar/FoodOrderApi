using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPi6.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedMeals1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RestaurantName",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RestaurantName",
                table: "Meals");
        }
    }
}
