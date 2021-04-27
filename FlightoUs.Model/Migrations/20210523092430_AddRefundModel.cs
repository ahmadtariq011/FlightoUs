using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightoUs.Model.Migrations
{
    public partial class AddRefundModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Refund",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PNR = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RefundType = table.Column<int>(type: "int", nullable: false),
                    LeadName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<int>(type: "int", nullable: false),
                    RefundStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refund", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Refund");
        }
    }
}
