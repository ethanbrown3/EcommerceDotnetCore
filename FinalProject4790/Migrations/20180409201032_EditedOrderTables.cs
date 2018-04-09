using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FinalProject4790.Migrations
{
    public partial class EditedOrderTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLineItems_Orders_OrderId",
                table: "OrderLineItems");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "OrderLineItems",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "OrderLineItemOrderId",
                table: "OrderLineItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "OrderLineItemPrice",
                table: "OrderLineItems",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "OrderLineItemQuantity",
                table: "OrderLineItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLineItems_Orders_OrderId",
                table: "OrderLineItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLineItems_Orders_OrderId",
                table: "OrderLineItems");

            migrationBuilder.DropColumn(
                name: "OrderLineItemOrderId",
                table: "OrderLineItems");

            migrationBuilder.DropColumn(
                name: "OrderLineItemPrice",
                table: "OrderLineItems");

            migrationBuilder.DropColumn(
                name: "OrderLineItemQuantity",
                table: "OrderLineItems");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "OrderLineItems",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLineItems_Orders_OrderId",
                table: "OrderLineItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
