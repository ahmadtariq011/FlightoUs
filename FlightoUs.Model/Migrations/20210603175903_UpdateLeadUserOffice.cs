using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightoUs.Model.Migrations
{
    public partial class UpdateLeadUserOffice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LogTime",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FromCode",
                table: "Lead",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LeadGender",
                table: "Lead",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SecondaryPhoneNumber",
                table: "Lead",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToCode",
                table: "Lead",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogTime",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FromCode",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "LeadGender",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "SecondaryPhoneNumber",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "ToCode",
                table: "Lead");
        }
    }
}
