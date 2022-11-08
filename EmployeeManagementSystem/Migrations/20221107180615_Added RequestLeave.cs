using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagementSystem.Migrations
{
    public partial class AddedRequestLeave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestLeave",
                columns: table => new
                {
                    LeaveID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(nullable: false),
                    LeaveType = table.Column<string>(nullable: true),
                    When = table.Column<DateTime>(nullable: false),
                    LeaveReason = table.Column<string>(nullable: true),
                    LeaveStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestLeave", x => x.LeaveID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestLeave");
        }
    }
}
