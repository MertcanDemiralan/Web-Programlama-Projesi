using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProje.Migrations
{
    public partial class Kategori2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kategoriler_Filmler_FilmId",
                table: "Kategoriler");

            migrationBuilder.DropIndex(
                name: "IX_Kategoriler_FilmId",
                table: "Kategoriler");

            migrationBuilder.DropColumn(
                name: "FilmId",
                table: "Kategoriler");

            migrationBuilder.CreateTable(
                name: "FilmKategori",
                columns: table => new
                {
                    FilmlerFilmId = table.Column<int>(type: "int", nullable: false),
                    KategorilerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmKategori", x => new { x.FilmlerFilmId, x.KategorilerId });
                    table.ForeignKey(
                        name: "FK_FilmKategori_Filmler_FilmlerFilmId",
                        column: x => x.FilmlerFilmId,
                        principalTable: "Filmler",
                        principalColumn: "FilmId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmKategori_Kategoriler_KategorilerId",
                        column: x => x.KategorilerId,
                        principalTable: "Kategoriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmKategori_KategorilerId",
                table: "FilmKategori",
                column: "KategorilerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmKategori");

            migrationBuilder.AddColumn<int>(
                name: "FilmId",
                table: "Kategoriler",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kategoriler_FilmId",
                table: "Kategoriler",
                column: "FilmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kategoriler_Filmler_FilmId",
                table: "Kategoriler",
                column: "FilmId",
                principalTable: "Filmler",
                principalColumn: "FilmId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
