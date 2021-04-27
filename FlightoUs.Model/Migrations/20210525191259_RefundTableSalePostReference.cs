using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightoUs.Model.Migrations
{
    public partial class RefundTableSalePostReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeadName",
                table: "Refund");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Refund",
                newName: "lead_Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Refund",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "SalePostId",
                table: "Refund",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sale_Id",
                table: "Refund",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "User_Id",
                table: "Refund",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Refund_SalePostId",
                table: "Refund",
                column: "SalePostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Refund_SalePost_SalePostId",
                table: "Refund",
                column: "SalePostId",
                principalTable: "SalePost",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Refund_SalePost_SalePostId",
                table: "Refund");

            migrationBuilder.DropIndex(
                name: "IX_Refund_SalePostId",
                table: "Refund");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Refund");

            migrationBuilder.DropColumn(
                name: "SalePostId",
                table: "Refund");

            migrationBuilder.DropColumn(
                name: "Sale_Id",
                table: "Refund");

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "Refund");

            migrationBuilder.RenameColumn(
                name: "lead_Id",
                table: "Refund",
                newName: "UserName");

            migrationBuilder.AddColumn<string>(
                name: "LeadName",
                table: "Refund",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
