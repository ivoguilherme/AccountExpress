using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountExpress.Migrations
{
    public partial class General : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RentId",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RentId",
                table: "Customers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Rent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rent", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_RentId",
                table: "Vehicles",
                column: "RentId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_RentId",
                table: "Customers",
                column: "RentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Rent_RentId",
                table: "Customers",
                column: "RentId",
                principalTable: "Rent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Rent_RentId",
                table: "Vehicles",
                column: "RentId",
                principalTable: "Rent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Rent_RentId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Rent_RentId",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "Rent");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_RentId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Customers_RentId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "RentId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "RentId",
                table: "Customers");
        }
    }
}
