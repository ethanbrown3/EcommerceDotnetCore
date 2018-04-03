using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FinalProject4790.Migrations
{
    public partial class UpdatedLineItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Products_ProductId",
                table: "LineItems");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "LineItems",
                newName: "LineItemProductId");

            migrationBuilder.RenameIndex(
                name: "IX_LineItems_ProductId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Products_LineItemProductId",
                table: "LineItems");

            migrationBuilder.RenameColumn(
                name: "LineItemProductId",
                table: "LineItems",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_LineItems_LineItemProductId",
                table: "LineItems",
                newName: "IX_LineItems_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Products_ProductId",
                table: "LineItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
