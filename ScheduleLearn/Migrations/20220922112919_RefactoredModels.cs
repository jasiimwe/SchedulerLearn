using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScheduleLearnApi.Migrations
{
    public partial class RefactoredModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "Account");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Shift",
                newName: "ShiftId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Next of Kin",
                newName: "NextOfKinId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "HistoryShfit",
                newName: "HistoryShiftId");

            migrationBuilder.RenameColumn(
                name: "Director",
                table: "HealthCenter",
                newName: "DirectorId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "HealthCenter",
                newName: "HealthCenterId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Division",
                newName: "DivisionId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Director",
                newName: "DirectorId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Account",
                newName: "AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Account",
                table: "Account",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Account",
                table: "Account");

            migrationBuilder.RenameTable(
                name: "Account",
                newName: "Accounts");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "User",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ShiftId",
                table: "Shift",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "NextOfKinId",
                table: "Next of Kin",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "HistoryShiftId",
                table: "HistoryShfit",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DirectorId",
                table: "HealthCenter",
                newName: "Director");

            migrationBuilder.RenameColumn(
                name: "HealthCenterId",
                table: "HealthCenter",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DivisionId",
                table: "Division",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DirectorId",
                table: "Director",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Accounts",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "Id");
        }
    }
}
