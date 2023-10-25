using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AnimeApp.Migrations
{
    /// <inheritdoc />
    public partial class NewManyToMany21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimeApplicationUsers_AspNetUsers_ApplicationUserId",
                table: "AnimeApplicationUsers");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "AnimeApplicationUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "RelId",
                table: "AnimeApplicationUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimeApplicationUsers",
                table: "AnimeApplicationUsers",
                column: "RelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeApplicationUsers_AspNetUsers_ApplicationUserId",
                table: "AnimeApplicationUsers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimeApplicationUsers_AspNetUsers_ApplicationUserId",
                table: "AnimeApplicationUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimeApplicationUsers",
                table: "AnimeApplicationUsers");

            migrationBuilder.DropColumn(
                name: "RelId",
                table: "AnimeApplicationUsers");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "AnimeApplicationUsers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeApplicationUsers_AspNetUsers_ApplicationUserId",
                table: "AnimeApplicationUsers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
