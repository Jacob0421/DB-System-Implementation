using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieStore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerNum = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerUserName = table.Column<string>(nullable: true),
                    CustomerPassword = table.Column<string>(nullable: true),
                    CustomerDOB = table.Column<string>(nullable: true),
                    CustomerFirstName = table.Column<string>(nullable: true),
                    CustomerLastName = table.Column<string>(nullable: true),
                    AmountOwed = table.Column<double>(nullable: false),
                    AmountPaid = table.Column<double>(nullable: false),
                    RecommendedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerNum);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieNum = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieTitle = table.Column<string>(nullable: true),
                    DirectorNum = table.Column<int>(nullable: false),
                    MovieRating = table.Column<string>(nullable: true),
                    MovieReleaseDate = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    AgeRating = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieNum);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
