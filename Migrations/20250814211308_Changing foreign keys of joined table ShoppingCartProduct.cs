using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShopForBags.Migrations
{
    /// <inheritdoc />
    public partial class ChangingforeignkeysofjoinedtableShoppingCartProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartProduct_Product_ShoppingCartId",
                table: "ShoppingCartProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartProduct_ShoppingCart_ProductId",
                table: "ShoppingCartProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartProduct_Product_ProductId",
                table: "ShoppingCartProduct",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartProduct_ShoppingCart_ShoppingCartId",
                table: "ShoppingCartProduct",
                column: "ShoppingCartId",
                principalTable: "ShoppingCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartProduct_Product_ProductId",
                table: "ShoppingCartProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartProduct_ShoppingCart_ShoppingCartId",
                table: "ShoppingCartProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartProduct_Product_ShoppingCartId",
                table: "ShoppingCartProduct",
                column: "ShoppingCartId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartProduct_ShoppingCart_ProductId",
                table: "ShoppingCartProduct",
                column: "ProductId",
                principalTable: "ShoppingCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
