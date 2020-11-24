using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieStore.Migrations
{
    public partial class AddedActorMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActorMovieMovieNum",
                table: "Actor",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Actor_ActorMovieMovieNum",
                table: "Actor",
                column: "ActorMovieMovieNum");

            migrationBuilder.AddForeignKey(
                name: "FK_Actor_Movies_ActorMovieMovieNum",
                table: "Actor",
                column: "ActorMovieMovieNum",
                principalTable: "Movies",
                principalColumn: "MovieNum",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actor_Movies_ActorMovieMovieNum",
                table: "Actor");

            migrationBuilder.DropIndex(
                name: "IX_Actor_ActorMovieMovieNum",
                table: "Actor");

            migrationBuilder.DropColumn(
                name: "ActorMovieMovieNum",
                table: "Actor");
        }
    }
}
