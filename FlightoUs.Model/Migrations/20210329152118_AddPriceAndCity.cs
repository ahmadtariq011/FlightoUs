using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightoUs.Model.Migrations
{
    public partial class AddPriceAndCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "Ticket",
                newName: "TotalValue");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "Hotel",
                newName: "TotalValue");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Ticket",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "NetValue",
                table: "Ticket",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PSF",
                table: "Ticket",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "User_Id",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "AssignDate",
                table: "Lead",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Lead",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Hotel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Hotel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Hotel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "NetValue",
                table: "Hotel",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PSF",
                table: "Hotel",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "User_Id",
                table: "Hotel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_User_Id",
                table: "Ticket",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_User_Id",
                table: "Hotel",
                column: "User_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotel_User_User_Id",
                table: "Hotel",
                column: "User_Id",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_User_User_Id",
                table: "Ticket",
                column: "User_Id",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotel_User_User_Id",
                table: "Hotel");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_User_User_Id",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_User_Id",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Hotel_User_Id",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "User");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "NetValue",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "PSF",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "AssignDate",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "NetValue",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "PSF",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "Hotel");

            migrationBuilder.RenameColumn(
                name: "TotalValue",
                table: "Ticket",
                newName: "UnitPrice");

            migrationBuilder.RenameColumn(
                name: "TotalValue",
                table: "Hotel",
                newName: "UnitPrice");

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
