using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieStore.Migrations
{
    public partial class changedRentalVariable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "rentalFinalCost",
                table: "Rentals",
                newName: "RentalFinalCost");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RentalFinalCost",
                table: "Rentals",
                newName: "rentalFinalCost");
        }
    }
}
