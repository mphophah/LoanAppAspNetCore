using Microsoft.EntityFrameworkCore.Migrations;

namespace AMS.Migrations
{
    public partial class FixingTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParKingNumber",
                table: "Parkings",
                newName: "ParkingNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParkingNumber",
                table: "Parkings",
                newName: "ParKingNumber");
        }
    }
}
