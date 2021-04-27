using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightoUs.Model.Migrations
{
    public partial class SalePostTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Children",
                table: "SalePost",
                newName: "HotelCategory");

            migrationBuilder.RenameColumn(
                name: "Adults",
                table: "SalePost",
                newName: "ClientType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HotelCategory",
                table: "SalePost",
                newName: "Children");

            migrationBuilder.RenameColumn(
                name: "ClientType",
                table: "SalePost",
                newName: "Adults");
        }
    }
}
