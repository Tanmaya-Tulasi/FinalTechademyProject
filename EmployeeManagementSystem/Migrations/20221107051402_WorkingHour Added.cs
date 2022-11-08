using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagementSystem.Migrations
{
    public partial class WorkingHourAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkingHours",
                columns: table => new
                {
                    HoursID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(nullable: false),
                    CompanyWokingHours = table.Column<double>(nullable: false),
                    EmployeeWorkingHours = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingHours", x => x.HoursID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkingHours");
        }
    }
}
