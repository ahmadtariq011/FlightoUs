using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightoUs.Model.Migrations
{
    public partial class UpdateCodeFT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromCode",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "ToCode",
                table: "Lead");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FromCode",
                table: "Lead",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToCode",
                table: "Lead",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
