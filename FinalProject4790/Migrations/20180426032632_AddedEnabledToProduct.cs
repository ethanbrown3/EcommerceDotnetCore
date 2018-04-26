using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FinalProject4790.Migrations
{
    public partial class AddedEnabledToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "enabled",
                table: "Products",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "enabled",
                table: "Products");
        }
    }
}
