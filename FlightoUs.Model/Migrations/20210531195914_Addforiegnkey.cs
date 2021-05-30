using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightoUs.Model.Migrations
{
    public partial class Addforiegnkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lead_User_AssignToUser",
                table: "Lead");

            migrationBuilder.DropIndex(
                name: "IX_Lead_AssignToUser",
                table: "Lead");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Lead",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lead_UserId",
                table: "Lead",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lead_User_UserId",
                table: "Lead",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lead_User_UserId",
                table: "Lead");

            migrationBuilder.DropIndex(
                name: "IX_Lead_UserId",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Lead");

            migrationBuilder.CreateIndex(
                name: "IX_Lead_AssignToUser",
                table: "Lead",
                column: "AssignToUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Lead_User_AssignToUser",
                table: "Lead",
                column: "AssignToUser",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
