using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagementSystem.Migrations
{
    public partial class AddedPaymentrules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "Employee");

            migrationBuilder.CreateTable(
                name: "PaymentRules",
                columns: table => new
                {
                    PaymentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentRule = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentRules", x => x.PaymentID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentRules");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeID",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
