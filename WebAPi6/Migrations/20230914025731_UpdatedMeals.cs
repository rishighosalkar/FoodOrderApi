using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPi6.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedMeals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Meals",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Meals");
        }
    }
}
