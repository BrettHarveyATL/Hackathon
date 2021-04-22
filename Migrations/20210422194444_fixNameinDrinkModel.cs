using Microsoft.EntityFrameworkCore.Migrations;

namespace SummerDrinks.Migrations
{
    public partial class fixNameinDrinkModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Drinks",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Drinks");
        }
    }
}
