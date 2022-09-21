using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScheduleLearnApi.Migrations
{
    public partial class AddedWardModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ward",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    DivisionId = table.Column<string>(type: "TEXT", nullable: false),
                    CenterId = table.Column<string>(type: "TEXT", nullable: false),
                    InchargeId = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    NumberOfWorkers = table.Column<int>(type: "INTEGER", nullable: false),
                    MinimunHoursAday = table.Column<int>(type: "INTEGER", nullable: false),
                    MaximumHoursAday = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ward", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ward");
        }
    }
}
