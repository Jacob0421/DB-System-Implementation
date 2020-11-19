using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieStore.Migrations
{
    public partial class changedRentalFieldName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Transactions_TransactionNum",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_TransactionNum",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "TransactionNum",
                table: "Rentals");

            migrationBuilder.AddColumn<int>(
                name: "RentalTransactionTransactionNum",
                table: "Rentals",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_RentalTransactionTransactionNum",
                table: "Rentals",
                column: "RentalTransactionTransactionNum");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Transactions_RentalTransactionTransactionNum",
                table: "Rentals",
                column: "RentalTransactionTransactionNum",
                principalTable: "Transactions",
                principalColumn: "TransactionNum",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Transactions_RentalTransactionTransactionNum",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_RentalTransactionTransactionNum",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "RentalTransactionTransactionNum",
                table: "Rentals");

            migrationBuilder.AddColumn<int>(
                name: "TransactionNum",
                table: "Rentals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_TransactionNum",
                table: "Rentals",
                column: "TransactionNum");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Transactions_TransactionNum",
                table: "Rentals",
                column: "TransactionNum",
                principalTable: "Transactions",
                principalColumn: "TransactionNum",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
