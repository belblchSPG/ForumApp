using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimeApp.Migrations
{
    /// <inheritdoc />
    public partial class NewManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimeApplicationUsers",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    applicationUserId = table.Column<string>(type: "text", nullable: false),
                    AnimeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_AnimeApplicationUsers_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "AnimeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeApplicationUsers_AspNetUsers_applicationUserId",
                        column: x => x.applicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimeApplicationUsers_AnimeId",
                table: "AnimeApplicationUsers",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeApplicationUsers_applicationUserId",
                table: "AnimeApplicationUsers",
                column: "applicationUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeApplicationUsers");
        }
    }
}
