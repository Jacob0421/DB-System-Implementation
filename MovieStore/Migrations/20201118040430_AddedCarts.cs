using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieStore.Migrations
{
    public partial class AddedCarts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieNum = table.Column<int>(nullable: true),
                    CartOwnerUserNum = table.Column<int>(nullable: true),
                    IsRental = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Carts_Users_CartOwnerUserNum",
                        column: x => x.CartOwnerUserNum,
                        principalTable: "Users",
                        principalColumn: "UserNum",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Carts_Movies_MovieNum",
                        column: x => x.MovieNum,
                        principalTable: "Movies",
                        principalColumn: "MovieNum",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CartOwnerUserNum",
                table: "Carts",
                column: "CartOwnerUserNum");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_MovieNum",
                table: "Carts",
                column: "MovieNum");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");
        }
    }
}
