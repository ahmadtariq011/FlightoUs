using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightoUs.Model.Migrations
{
    public partial class updateremarkstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Remarks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "User_Id",
                table: "Remarks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Remarks_UserId",
                table: "Remarks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Remarks_User_UserId",
                table: "Remarks",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Remarks_User_UserId",
                table: "Remarks");

            migrationBuilder.DropIndex(
                name: "IX_Remarks_UserId",
                table: "Remarks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Remarks");

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "Remarks");
        }
    }
}
