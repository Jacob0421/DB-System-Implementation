using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieStore.Migrations
{
    public partial class addedforeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MainTransactionTransactionNum",
                table: "TransactionDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetails_MainTransactionTransactionNum",
                table: "TransactionDetails",
                column: "MainTransactionTransactionNum");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionDetails_Transactions_MainTransactionTransactionNum",
                table: "TransactionDetails",
                column: "MainTransactionTransactionNum",
                principalTable: "Transactions",
                principalColumn: "TransactionNum",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionDetails_Transactions_MainTransactionTransactionNum",
                table: "TransactionDetails");

            migrationBuilder.DropIndex(
                name: "IX_TransactionDetails_MainTransactionTransactionNum",
                table: "TransactionDetails");

            migrationBuilder.DropColumn(
                name: "MainTransactionTransactionNum",
                table: "TransactionDetails");
        }
    }
}
