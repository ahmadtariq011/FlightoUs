using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightoUs.Model.Migrations
{
    public partial class ReciptModelAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReciptNo",
                table: "Recipt",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountPaid",
                table: "Recipt",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "Recipt",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "FormOfPayment",
                table: "Recipt",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemNo",
                table: "Recipt",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ServicePrice",
                table: "Recipt",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ServiceTitle",
                table: "Recipt",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "Recipt",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountPaid",
                table: "Recipt");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Recipt");

            migrationBuilder.DropColumn(
                name: "FormOfPayment",
                table: "Recipt");

            migrationBuilder.DropColumn(
                name: "ItemNo",
                table: "Recipt");

            migrationBuilder.DropColumn(
                name: "ServicePrice",
                table: "Recipt");

            migrationBuilder.DropColumn(
                name: "ServiceTitle",
                table: "Recipt");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Recipt");

            migrationBuilder.AlterColumn<string>(
                name: "ReciptNo",
                table: "Recipt",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
