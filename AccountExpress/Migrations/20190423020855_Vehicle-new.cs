using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountExpress.Migrations
{
    public partial class Vehiclenew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Brands",
                table: "Vehicles",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Brands",
                table: "Vehicles",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
