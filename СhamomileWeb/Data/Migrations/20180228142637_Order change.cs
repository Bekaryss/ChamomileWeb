using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace СhamomileWeb.Data.Migrations
{
    public partial class Orderchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientType",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "CustomerType",
                table: "Orders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerType",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "ClientType",
                table: "Orders",
                nullable: false,
                defaultValue: 0);
        }
    }
}
