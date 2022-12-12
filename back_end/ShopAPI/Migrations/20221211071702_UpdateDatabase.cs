using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopAPI.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColorProducts");

            migrationBuilder.DropTable(
                name: "SizeProducts");

            migrationBuilder.DropColumn(
                name: "RecipeItemId",
                table: "recipe");

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

            migrationBuilder.CreateTable(
                name: "colorProduct",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_colorProduct", x => new { x.ColorId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_colorProduct_color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "color",
                        principalColumn: "ColorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_colorProduct_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sizeProduct",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sizeProduct", x => new { x.SizeId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_sizeProduct_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sizeProduct_size_SizeId",
                        column: x => x.SizeId,
                        principalTable: "size",
                        principalColumn: "SizeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_ColorId",
                table: "product",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_product_SizeId",
                table: "product",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_colorProduct_ProductId",
                table: "colorProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_sizeProduct_ProductId",
                table: "sizeProduct",
                column: "ProductId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_color_ColorId",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_size_SizeId",
                table: "product");

            migrationBuilder.DropTable(
                name: "colorProduct");

            migrationBuilder.DropTable(
                name: "sizeProduct");

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

            migrationBuilder.AddColumn<int>(
                name: "RecipeItemId",
                table: "recipe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ColorProducts",
                columns: table => new
                {
                    ColorsColorId = table.Column<int>(type: "int", nullable: false),
                    ProductsProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorProducts", x => new { x.ColorsColorId, x.ProductsProductId });
                    table.ForeignKey(
                        name: "FK_ColorProducts_color_ColorsColorId",
                        column: x => x.ColorsColorId,
                        principalTable: "color",
                        principalColumn: "ColorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColorProducts_product_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SizeProducts",
                columns: table => new
                {
                    ProductsProductId = table.Column<int>(type: "int", nullable: false),
                    SizesSizeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeProducts", x => new { x.ProductsProductId, x.SizesSizeId });
                    table.ForeignKey(
                        name: "FK_SizeProducts_product_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SizeProducts_size_SizesSizeId",
                        column: x => x.SizesSizeId,
                        principalTable: "size",
                        principalColumn: "SizeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColorProducts_ProductsProductId",
                table: "ColorProducts",
                column: "ProductsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SizeProducts_SizesSizeId",
                table: "SizeProducts",
                column: "SizesSizeId");
        }
    }
}
