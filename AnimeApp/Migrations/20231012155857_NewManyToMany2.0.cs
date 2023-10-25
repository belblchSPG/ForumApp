using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimeApp.Migrations
{
    /// <inheritdoc />
    public partial class NewManyToMany20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimeApplicationUsers_AspNetUsers_applicationUserId",
                table: "AnimeApplicationUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AnimeApplicationUsers");

            migrationBuilder.RenameColumn(
                name: "applicationUserId",
                table: "AnimeApplicationUsers",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AnimeApplicationUsers_applicationUserId",
                table: "AnimeApplicationUsers",
                newName: "IX_AnimeApplicationUsers_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeApplicationUsers_AspNetUsers_ApplicationUserId",
                table: "AnimeApplicationUsers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimeApplicationUsers_AspNetUsers_ApplicationUserId",
                table: "AnimeApplicationUsers");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "AnimeApplicationUsers",
                newName: "applicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AnimeApplicationUsers_ApplicationUserId",
                table: "AnimeApplicationUsers",
                newName: "IX_AnimeApplicationUsers_applicationUserId");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "AnimeApplicationUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeApplicationUsers_AspNetUsers_applicationUserId",
                table: "AnimeApplicationUsers",
                column: "applicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
