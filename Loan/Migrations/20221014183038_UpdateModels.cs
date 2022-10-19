using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AMS.Migrations
{
    public partial class UpdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Tenants_TenantId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Parkings_Tenants_TenantId",
                table: "Parkings");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Tenants_TenantId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Tenants_TenantId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Visitors_Tenants_TenantId",
                table: "Visitors");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Visitors",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Visitors_TenantId",
                table: "Visitors",
                newName: "IX_Visitors_CustomerId");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Reservations",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_TenantId",
                table: "Reservations",
                newName: "IX_Reservations_CustomerId");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Payments",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_TenantId",
                table: "Payments",
                newName: "IX_Payments_CustomerId");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Parkings",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Parkings_TenantId",
                table: "Parkings",
                newName: "IX_Parkings_CustomerId");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Invoice",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_TenantId",
                table: "Invoice",
                newName: "IX_Invoice_CustomerId");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    IDNumber = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Occupation = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    HomeAddress = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Customers_CustomerId",
                table: "Invoice",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parkings_Customers_CustomerId",
                table: "Parkings",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Customers_CustomerId",
                table: "Payments",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Customers_CustomerId",
                table: "Reservations",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visitors_Customers_CustomerId",
                table: "Visitors",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Customers_CustomerId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Parkings_Customers_CustomerId",
                table: "Parkings");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Customers_CustomerId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Customers_CustomerId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Visitors_Customers_CustomerId",
                table: "Visitors");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Visitors",
                newName: "TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_Visitors_CustomerId",
                table: "Visitors",
                newName: "IX_Visitors_TenantId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Reservations",
                newName: "TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_CustomerId",
                table: "Reservations",
                newName: "IX_Reservations_TenantId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Payments",
                newName: "TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_CustomerId",
                table: "Payments",
                newName: "IX_Payments_TenantId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Parkings",
                newName: "TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_Parkings_CustomerId",
                table: "Parkings",
                newName: "IX_Parkings_TenantId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Invoice",
                newName: "TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_CustomerId",
                table: "Invoice",
                newName: "IX_Invoice_TenantId");

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    HomeAddress = table.Column<string>(type: "TEXT", nullable: true),
                    IDNumber = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    NextOfKinAdress = table.Column<string>(type: "TEXT", nullable: true),
                    NextOfKinFullName = table.Column<string>(type: "TEXT", nullable: true),
                    NextOfKinNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Occupation = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Photo = table.Column<string>(type: "TEXT", nullable: true),
                    ProofOfIncome = table.Column<string>(type: "TEXT", nullable: true),
                    fileAttached = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Tenants_TenantId",
                table: "Invoice",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parkings_Tenants_TenantId",
                table: "Parkings",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Tenants_TenantId",
                table: "Payments",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Tenants_TenantId",
                table: "Reservations",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visitors_Tenants_TenantId",
                table: "Visitors",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
