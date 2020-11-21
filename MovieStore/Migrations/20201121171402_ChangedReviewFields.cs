using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieStore.Migrations
{
    public partial class ChangedReviewFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Reviews");

            migrationBuilder.AddColumn<int>(
                name: "AuthorUserNum",
                table: "Reviews",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AuthorUserNum",
                table: "Reviews",
                column: "AuthorUserNum");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_AuthorUserNum",
                table: "Reviews",
                column: "AuthorUserNum",
                principalTable: "Users",
                principalColumn: "UserNum",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_AuthorUserNum",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_AuthorUserNum",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "AuthorUserNum",
                table: "Reviews");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
