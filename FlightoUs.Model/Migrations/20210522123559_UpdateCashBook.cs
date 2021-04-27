using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightoUs.Model.Migrations
{
    public partial class UpdateCashBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Markup",
                table: "CashBook");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "CashBook");

            migrationBuilder.RenameColumn(
                name: "ToBeUsed",
                table: "CashBook",
                newName: "CreatedDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "CashBook",
                newName: "ToBeUsed");

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
        }
    }
}
