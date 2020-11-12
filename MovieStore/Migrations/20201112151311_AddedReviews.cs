using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieStore.Migrations
{
    public partial class AddedReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewNum = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieNum = table.Column<int>(nullable: true),
                    ReviewTitle = table.Column<string>(nullable: true),
                    MovieTitle = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    ReviewBody = table.Column<string>(nullable: true),
                    ReviewDate = table.Column<string>(nullable: true),
                    StarRating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewNum);
                    table.ForeignKey(
                        name: "FK_Reviews_Movies_MovieNum",
                        column: x => x.MovieNum,
                        principalTable: "Movies",
                        principalColumn: "MovieNum",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MovieNum",
                table: "Reviews",
                column: "MovieNum");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");
        }
    }
}
