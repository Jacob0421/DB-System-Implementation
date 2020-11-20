using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieStore.Migrations
{
    public partial class changedTransactionFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Movies_MovieNum",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_MovieNum",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "MovieNum",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "TransactionMovieMovieNum",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "TransactionDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "TransactionDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NameOnCard",
                table: "TransactionDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LName",
                table: "TransactionDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FName",
                table: "TransactionDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ExpirationDate",
                table: "TransactionDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreditCardNumber",
                table: "TransactionDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "TransactionDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CVV",
                table: "TransactionDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "TransactionDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionMovieMovieNum",
                table: "Transactions",
                column: "TransactionMovieMovieNum");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Movies_TransactionMovieMovieNum",
                table: "Transactions",
                column: "TransactionMovieMovieNum",
                principalTable: "Movies",
                principalColumn: "MovieNum",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Movies_TransactionMovieMovieNum",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_TransactionMovieMovieNum",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TransactionMovieMovieNum",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "MovieNum",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "TransactionDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "TransactionDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "NameOnCard",
                table: "TransactionDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LName",
                table: "TransactionDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FName",
                table: "TransactionDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ExpirationDate",
                table: "TransactionDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CreditCardNumber",
                table: "TransactionDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "TransactionDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CVV",
                table: "TransactionDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "TransactionDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_MovieNum",
                table: "Transactions",
                column: "MovieNum");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Movies_MovieNum",
                table: "Transactions",
                column: "MovieNum",
                principalTable: "Movies",
                principalColumn: "MovieNum",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
