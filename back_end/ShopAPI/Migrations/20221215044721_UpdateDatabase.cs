using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopAPI.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecipeItemId",
                table: "recipe");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipeItemId",
                table: "recipe",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
