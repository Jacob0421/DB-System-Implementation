using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieStore.Migrations
{
    public partial class AddedPriceFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PurchasePrice",
                table: "Movies",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RentalPrice",
                table: "Movies",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchasePrice",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "RentalPrice",
                table: "Movies");
        }
    }
}
