using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightoUs.Model.Migrations
{
    public partial class UpdateCashBookModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CashType",
                table: "CashBook",
                newName: "PaymentMode");

            migrationBuilder.AddColumn<decimal>(
                name: "Markup",
                table: "CashBook",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "CashBook",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ToBeUsed",
                table: "CashBook",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Markup",
                table: "CashBook");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "CashBook");

            migrationBuilder.DropColumn(
                name: "ToBeUsed",
                table: "CashBook");

            migrationBuilder.RenameColumn(
                name: "PaymentMode",
                table: "CashBook",
                newName: "CashType");
        }
    }
}
