using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieStore.Migrations
{
    public partial class changedPurchasefields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchasePrice",
                table: "Purchases");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PurchasePrice",
                table: "Purchases",
                type: "decimal(15,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
