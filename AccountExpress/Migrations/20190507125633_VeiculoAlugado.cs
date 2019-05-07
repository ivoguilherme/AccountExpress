using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountExpress.Migrations
{
    public partial class VeiculoAlugado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isRented",
                table: "Vehicles",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isRented",
                table: "Vehicles");
        }
    }
}
