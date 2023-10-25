using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AnimeApp.Migrations
{
    /// <inheritdoc />
    public partial class Image4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnimeId",
                table: "Images",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RelatedAnime",
                table: "Images",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AnimeImages",
                columns: table => new
                {
                    RelId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ImageId = table.Column<int>(type: "integer", nullable: false),
                    AnimeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeImages", x => x.RelId);
                    table.ForeignKey(
                        name: "FK_AnimeImages_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "AnimeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeImages_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_AnimeId",
                table: "Images",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeImages_AnimeId",
                table: "AnimeImages",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeImages_ImageId",
                table: "AnimeImages",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Animes_AnimeId",
                table: "Images",
                column: "AnimeId",
                principalTable: "Animes",
                principalColumn: "AnimeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Animes_AnimeId",
                table: "Images");

            migrationBuilder.DropTable(
                name: "AnimeImages");

            migrationBuilder.DropIndex(
                name: "IX_Images_AnimeId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "AnimeId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "RelatedAnime",
                table: "Images");
        }
    }
}
