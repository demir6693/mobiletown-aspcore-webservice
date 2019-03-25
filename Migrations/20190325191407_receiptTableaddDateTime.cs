using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webshopApi.Migrations
{
    public partial class receiptTableaddDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateofReceipt",
                table: "Receipts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateofReceipt",
                table: "Receipts");
        }
    }
}
