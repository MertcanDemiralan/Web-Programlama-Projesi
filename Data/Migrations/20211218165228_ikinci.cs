using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProgramlamaProjesi.Data.Migrations
{
    public partial class ikinci : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adminler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifre_Tekrar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adminler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kategori_Adı = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifre_Tekrar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filmler",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Film_Adi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Film_Aciklamasi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    KullaniciId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmler", x => x.FilmId);
                    table.ForeignKey(
                        name: "FK_Filmler_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "Oyuncular",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Fotografi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oyuncular", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oyuncular_Filmler_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Filmler",
                        principalColumn: "FilmId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Yorumlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Yapan_Kullanici_Id = table.Column<int>(type: "int", nullable: false),
                    Yapilan_Film_Id = table.Column<int>(type: "int", nullable: false),
                    Yorum_Metni = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yildiz = table.Column<float>(type: "real", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yorumlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Yorumlar_Filmler_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Filmler",
                        principalColumn: "FilmId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmKategori_KategorilerId",
                table: "FilmKategori",
                column: "KategorilerId");

            migrationBuilder.CreateIndex(
                name: "IX_Filmler_KullaniciId",
                table: "Filmler",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Oyuncular_FilmId",
                table: "Oyuncular",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Yorumlar_FilmId",
                table: "Yorumlar",
                column: "FilmId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adminler");

            migrationBuilder.DropTable(
                name: "FilmKategori");

            migrationBuilder.DropTable(
                name: "Oyuncular");

            migrationBuilder.DropTable(
                name: "Yorumlar");

            migrationBuilder.DropTable(
                name: "Kategoriler");

            migrationBuilder.DropTable(
                name: "Filmler");

            migrationBuilder.DropTable(
                name: "Kullanicilar");
        }
    }
}
