using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FinalProject4790.Migrations
{
    public partial class RenameLineItemToCartLineItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Products_LineItemProductId",
                table: "LineItems");

            migrationBuilder.RenameColumn(
                name: "ShoppingCartId",
                table: "LineItems",
                newName: "CartShoppingCartId");

            migrationBuilder.RenameColumn(
                name: "LineItemQuantity",
                table: "LineItems",
                newName: "CartLineItemQuantity");

            migrationBuilder.RenameColumn(
                name: "LineItemProductId",
                table: "LineItems",
                newName: "CartLineItemProductId");

            migrationBuilder.RenameColumn(
                name: "LineItemId",
                table: "LineItems",
                newName: "CartLineItemId");

            migrationBuilder.RenameIndex(
                name: "IX_LineItems_LineItemProductId",
                table: "LineItems",
                newName: "IX_LineItems_CartLineItemProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Products_CartLineItemProductId",
                table: "LineItems",
                column: "CartLineItemProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Products_CartLineItemProductId",
                table: "LineItems");

            migrationBuilder.RenameColumn(
                name: "CartShoppingCartId",
                table: "LineItems",
                newName: "ShoppingCartId");

            migrationBuilder.RenameColumn(
                name: "CartLineItemQuantity",
                table: "LineItems",
                newName: "LineItemQuantity");

            migrationBuilder.RenameColumn(
                name: "CartLineItemProductId",
                table: "LineItems",
                newName: "LineItemProductId");

            migrationBuilder.RenameColumn(
                name: "CartLineItemId",
                table: "LineItems",
                newName: "LineItemId");

            migrationBuilder.RenameIndex(
                name: "IX_LineItems_CartLineItemProductId",
                table: "LineItems",
                newName: "IX_LineItems_LineItemProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Products_LineItemProductId",
                table: "LineItems",
                column: "LineItemProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
