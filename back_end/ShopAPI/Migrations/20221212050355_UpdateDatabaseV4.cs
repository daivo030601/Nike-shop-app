using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopAPI.Migrations
{
    public partial class UpdateDatabaseV4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_recipeItem",
                table: "recipeItem");

            migrationBuilder.DropIndex(
                name: "IX_recipeItem_RecipeId",
                table: "recipeItem");

            migrationBuilder.DropColumn(
                name: "RecipeItemId",
                table: "recipeItem");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "recipe");

            migrationBuilder.RenameColumn(
                name: "Quatity",
                table: "product",
                newName: "Quantity");

            migrationBuilder.AddColumn<float>(
                name: "Total",
                table: "recipeItem",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "RecipeItemId",
                table: "recipe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_recipeItem",
                table: "recipeItem",
                columns: new[] { "RecipeId", "ProductId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_recipeItem",
                table: "recipeItem");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "recipeItem");

            migrationBuilder.DropColumn(
                name: "RecipeItemId",
                table: "recipe");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "product",
                newName: "Quatity");

            migrationBuilder.AddColumn<int>(
                name: "RecipeItemId",
                table: "recipeItem",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<float>(
                name: "Total",
                table: "recipe",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddPrimaryKey(
                name: "PK_recipeItem",
                table: "recipeItem",
                column: "RecipeItemId");

            migrationBuilder.CreateIndex(
                name: "IX_recipeItem_RecipeId",
                table: "recipeItem",
                column: "RecipeId");
        }
    }
}
