using Microsoft.EntityFrameworkCore.Migrations;

namespace AMS.Migrations
{
    public partial class AddFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "fileAttached",
                table: "Tenants",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fileAttached",
                table: "Tenants");
        }
    }
}
