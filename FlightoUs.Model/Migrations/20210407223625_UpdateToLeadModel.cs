using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightoUs.Model.Migrations
{
    public partial class UpdateToLeadModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassOfTravel",
                table: "Lead",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerType",
                table: "Lead",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureDate",
                table: "Lead",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FreeText",
                table: "Lead",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LeadTitle",
                table: "Lead",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDate",
                table: "Lead",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassOfTravel",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "CustomerType",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "DepartureDate",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "FreeText",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "LeadTitle",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "Lead");
        }
    }
}
