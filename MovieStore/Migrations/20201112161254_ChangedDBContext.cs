using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieStore.Migrations
{
    public partial class ChangedDBContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actor",
                columns: table => new
                {
                    ActorNum = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActorFName = table.Column<string>(nullable: true),
                    ActorLName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor", x => x.ActorNum);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionNum = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tTansactionDate = table.Column<string>(nullable: true),
                    CustomerNum = table.Column<int>(nullable: true),
                    MovieNum = table.Column<int>(nullable: true),
                    IsRental = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionNum);
                    table.ForeignKey(
                        name: "FK_Transactions_Customers_CustomerNum",
                        column: x => x.CustomerNum,
                        principalTable: "Customers",
                        principalColumn: "CustomerNum",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Movies_MovieNum",
                        column: x => x.MovieNum,
                        principalTable: "Movies",
                        principalColumn: "MovieNum",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    PurchaseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionNum = table.Column<int>(nullable: true),
                    PurchasePrice = table.Column<decimal>(type: "decimal(15,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.PurchaseId);
                    table.ForeignKey(
                        name: "FK_Purchases_Transactions_TransactionNum",
                        column: x => x.TransactionNum,
                        principalTable: "Transactions",
                        principalColumn: "TransactionNum",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    RentalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionNum = table.Column<int>(nullable: true),
                    RentalPrice = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    IsLate = table.Column<bool>(nullable: false),
                    DaysLate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.RentalId);
                    table.ForeignKey(
                        name: "FK_Rentals_Transactions_TransactionNum",
                        column: x => x.TransactionNum,
                        principalTable: "Transactions",
                        principalColumn: "TransactionNum",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_TransactionNum",
                table: "Purchases",
                column: "TransactionNum");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_TransactionNum",
                table: "Rentals",
                column: "TransactionNum");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CustomerNum",
                table: "Transactions",
                column: "CustomerNum");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_MovieNum",
                table: "Transactions",
                column: "MovieNum");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actor");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
