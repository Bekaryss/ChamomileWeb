using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace СhamomileWeb.Data.Migrations
{
    public partial class Orderchangename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Customer",
                table: "Orders",
                newName: "CustomerName");

            migrationBuilder.CreateTable(
                name: "RouteTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CanceledCount = table.Column<int>(nullable: false),
                    CompletedCount = table.Column<int>(nullable: false),
                    Delivery = table.Column<string>(nullable: true),
                    Dispatch = table.Column<string>(nullable: true),
                    Distance = table.Column<double>(nullable: false),
                    FinishDate = table.Column<DateTime>(nullable: false),
                    OrderCount = table.Column<int>(nullable: false),
                    Percent = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    RefundedCount = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteTable", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RouteTable");

            migrationBuilder.RenameColumn(
                name: "CustomerName",
                table: "Orders",
                newName: "Customer");
        }
    }
}
