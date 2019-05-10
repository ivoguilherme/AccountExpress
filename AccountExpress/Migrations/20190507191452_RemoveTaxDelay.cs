using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountExpress.Migrations
{
    public partial class RemoveTaxDelay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DelayRate",
                table: "Rent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "DelayRate",
                table: "Rent",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
