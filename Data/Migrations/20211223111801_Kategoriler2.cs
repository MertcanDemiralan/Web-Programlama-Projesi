using Microsoft.EntityFrameworkCore.Migrations;

namespace OMDb.Data.Migrations
{
    public partial class Kategoriler2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmKategori_Filmler_FilmId",
                table: "FilmKategori");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmKategori_Kategori_KategoriId",
                table: "FilmKategori");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kategori",
                table: "Kategori");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmKategori",
                table: "FilmKategori");

            migrationBuilder.RenameTable(
                name: "Kategori",
                newName: "Kategoriler");

            migrationBuilder.RenameTable(
                name: "FilmKategori",
                newName: "FilmKategoriler");

            migrationBuilder.RenameIndex(
                name: "IX_FilmKategori_KategoriId",
                table: "FilmKategoriler",
                newName: "IX_FilmKategoriler_KategoriId");

            migrationBuilder.RenameIndex(
                name: "IX_FilmKategori_FilmId",
                table: "FilmKategoriler",
                newName: "IX_FilmKategoriler_FilmId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kategoriler",
                table: "Kategoriler",
                column: "KategoriId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmKategoriler",
                table: "FilmKategoriler",
                column: "FilmKategoriId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmKategoriler_Filmler_FilmId",
                table: "FilmKategoriler",
                column: "FilmId",
                principalTable: "Filmler",
                principalColumn: "FilmId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmKategoriler_Kategoriler_KategoriId",
                table: "FilmKategoriler",
                column: "KategoriId",
                principalTable: "Kategoriler",
                principalColumn: "KategoriId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmKategoriler_Filmler_FilmId",
                table: "FilmKategoriler");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmKategoriler_Kategoriler_KategoriId",
                table: "FilmKategoriler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kategoriler",
                table: "Kategoriler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmKategoriler",
                table: "FilmKategoriler");

            migrationBuilder.RenameTable(
                name: "Kategoriler",
                newName: "Kategori");

            migrationBuilder.RenameTable(
                name: "FilmKategoriler",
                newName: "FilmKategori");

            migrationBuilder.RenameIndex(
                name: "IX_FilmKategoriler_KategoriId",
                table: "FilmKategori",
                newName: "IX_FilmKategori_KategoriId");

            migrationBuilder.RenameIndex(
                name: "IX_FilmKategoriler_FilmId",
                table: "FilmKategori",
                newName: "IX_FilmKategori_FilmId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kategori",
                table: "Kategori",
                column: "KategoriId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmKategori",
                table: "FilmKategori",
                column: "FilmKategoriId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmKategori_Filmler_FilmId",
                table: "FilmKategori",
                column: "FilmId",
                principalTable: "Filmler",
                principalColumn: "FilmId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmKategori_Kategori_KategoriId",
                table: "FilmKategori",
                column: "KategoriId",
                principalTable: "Kategori",
                principalColumn: "KategoriId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
