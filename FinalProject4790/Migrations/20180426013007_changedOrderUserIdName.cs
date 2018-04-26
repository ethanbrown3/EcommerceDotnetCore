using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FinalProject4790.Migrations
{
    public partial class changedOrderUserIdName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderUserId",
                table: "Orders",
                newName: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Orders",
                newName: "OrderUserId");
        }
    }
}
