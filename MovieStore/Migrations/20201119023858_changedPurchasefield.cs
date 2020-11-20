using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieStore.Migrations
{
    public partial class changedPurchasefield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Transactions_TransactionNum",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_TransactionNum",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "TransactionNum",
                table: "Purchases");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseTransactionTransactionNum",
                table: "Purchases",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_PurchaseTransactionTransactionNum",
                table: "Purchases",
                column: "PurchaseTransactionTransactionNum");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Transactions_PurchaseTransactionTransactionNum",
                table: "Purchases",
                column: "PurchaseTransactionTransactionNum",
                principalTable: "Transactions",
                principalColumn: "TransactionNum",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Transactions_PurchaseTransactionTransactionNum",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_PurchaseTransactionTransactionNum",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "PurchaseTransactionTransactionNum",
                table: "Purchases");

            migrationBuilder.AddColumn<int>(
                name: "TransactionNum",
                table: "Purchases",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_TransactionNum",
                table: "Purchases",
                column: "TransactionNum");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Transactions_TransactionNum",
                table: "Purchases",
                column: "TransactionNum",
                principalTable: "Transactions",
                principalColumn: "TransactionNum",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
