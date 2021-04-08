using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightoUs.Model.Migrations
{
    public partial class ReciptModelThirdServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ServiceTitle",
                table: "Recipt",
                newName: "ThirdServiceTitle");

            migrationBuilder.RenameColumn(
                name: "ServicePrice",
                table: "Recipt",
                newName: "ThirdServicePrice");

            migrationBuilder.AddColumn<decimal>(
                name: "FirstServicePrice",
                table: "Recipt",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "FirstServiceTitle",
                table: "Recipt",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SecondServicePrice",
                table: "Recipt",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "SecondServiceTitle",
                table: "Recipt",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstServicePrice",
                table: "Recipt");

            migrationBuilder.DropColumn(
                name: "FirstServiceTitle",
                table: "Recipt");

            migrationBuilder.DropColumn(
                name: "SecondServicePrice",
                table: "Recipt");

            migrationBuilder.DropColumn(
                name: "SecondServiceTitle",
                table: "Recipt");

            migrationBuilder.RenameColumn(
                name: "ThirdServiceTitle",
                table: "Recipt",
                newName: "ServiceTitle");

            migrationBuilder.RenameColumn(
                name: "ThirdServicePrice",
                table: "Recipt",
                newName: "ServicePrice");
        }
    }
}
