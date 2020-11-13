using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieStore.Migrations
{
    public partial class ChangedToUser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Customers_CustomerUserNum",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserNum");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_CustomerUserNum",
                table: "Transactions",
                column: "CustomerUserNum",
                principalTable: "Users",
                principalColumn: "UserNum",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_CustomerUserNum",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Customers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "UserNum");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Customers_CustomerUserNum",
                table: "Transactions",
                column: "CustomerUserNum",
                principalTable: "Customers",
                principalColumn: "UserNum",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
