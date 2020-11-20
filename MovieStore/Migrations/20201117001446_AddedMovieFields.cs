using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieStore.Migrations
{
    public partial class AddedMovieFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tTansactionDate",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "AgeRating",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Movies");

            migrationBuilder.AddColumn<string>(
                name: "TransactionDate",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MovieRating",
                table: "Movies",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DirectorNum",
                table: "Movies",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "AgeRating1",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GenreName",
                table: "Movies",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Age_Ratings",
                columns: table => new
                {
                    AgeRating = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Age_Ratings", x => x.AgeRating);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    DirectorNum = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(nullable: true),
                    LName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.DirectorNum);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreName);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_AgeRating1",
                table: "Movies",
                column: "AgeRating1");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_DirectorNum",
                table: "Movies",
                column: "DirectorNum");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreName",
                table: "Movies",
                column: "GenreName");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Age_Ratings_AgeRating1",
                table: "Movies",
                column: "AgeRating1",
                principalTable: "Age_Ratings",
                principalColumn: "AgeRating",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Directors_DirectorNum",
                table: "Movies",
                column: "DirectorNum",
                principalTable: "Directors",
                principalColumn: "DirectorNum",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genre_GenreName",
                table: "Movies",
                column: "GenreName",
                principalTable: "Genre",
                principalColumn: "GenreName",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Age_Ratings_AgeRating1",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Directors_DirectorNum",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genre_GenreName",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "Age_Ratings");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropIndex(
                name: "IX_Movies_AgeRating1",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_DirectorNum",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_GenreName",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "TransactionDate",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "AgeRating1",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "GenreName",
                table: "Movies");

            migrationBuilder.AddColumn<string>(
                name: "tTansactionDate",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MovieRating",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DirectorNum",
                table: "Movies",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AgeRating",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
