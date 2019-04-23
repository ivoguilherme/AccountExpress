using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountExpress.Migrations
{
    public partial class Rent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Daily",
                table: "Rent",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DelayRate",
                table: "Rent",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "IdCustomers",
                table: "Rent",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdVehicles",
                table: "Rent",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "PickupDate",
                table: "Rent",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDate",
                table: "Rent",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TypeOfRent",
                table: "Rent",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Daily",
                table: "Rent");

            migrationBuilder.DropColumn(
                name: "DelayRate",
                table: "Rent");

            migrationBuilder.DropColumn(
                name: "IdCustomers",
                table: "Rent");

            migrationBuilder.DropColumn(
                name: "IdVehicles",
                table: "Rent");

            migrationBuilder.DropColumn(
                name: "PickupDate",
                table: "Rent");

            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "Rent");

            migrationBuilder.DropColumn(
                name: "TypeOfRent",
                table: "Rent");
        }
    }
}
