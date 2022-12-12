using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopAPI.Migrations
{
    public partial class UpdateDatabaseV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_color_ColorId",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_size_SizeId",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_ColorId",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_SizeId",
                table: "product");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "product");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_ColorId",
                table: "product",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_product_SizeId",
                table: "product",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_product_color_ColorId",
                table: "product",
                column: "ColorId",
                principalTable: "color",
                principalColumn: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_product_size_SizeId",
                table: "product",
                column: "SizeId",
                principalTable: "size",
                principalColumn: "SizeId");
        }
    }
}
