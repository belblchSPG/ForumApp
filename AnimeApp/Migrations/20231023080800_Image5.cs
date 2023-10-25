using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimeApp.Migrations
{
    /// <inheritdoc />
    public partial class Image5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Animes_AnimeId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_AnimeId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "AnimeId",
                table: "Images");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnimeId",
                table: "Images",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_AnimeId",
                table: "Images",
                column: "AnimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Animes_AnimeId",
                table: "Images",
                column: "AnimeId",
                principalTable: "Animes",
                principalColumn: "AnimeId");
        }
    }
}
