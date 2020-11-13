using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieStore.Migrations
{
    public partial class ChangedToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Customers_CustomerNum",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CustomerNum",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerNum",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CustomerNum",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerDOB",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerFirstName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerLastName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerPassword",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerUserName",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "CustomerUserNum",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserNum",
                table: "Customers",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "UserDOB",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserFirstName",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserLastName",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserPassword",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserUserName",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "UserNum");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CustomerUserNum",
                table: "Transactions",
                column: "CustomerUserNum");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Customers_CustomerUserNum",
                table: "Transactions",
                column: "CustomerUserNum",
                principalTable: "Customers",
                principalColumn: "UserNum",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Customers_CustomerUserNum",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CustomerUserNum",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerUserNum",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "UserNum",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UserDOB",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UserFirstName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UserLastName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UserPassword",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UserUserName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "role",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "CustomerNum",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerNum",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "CustomerDOB",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerFirstName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerLastName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerPassword",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerUserName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "CustomerNum");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CustomerNum",
                table: "Transactions",
                column: "CustomerNum");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Customers_CustomerNum",
                table: "Transactions",
                column: "CustomerNum",
                principalTable: "Customers",
                principalColumn: "CustomerNum",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
