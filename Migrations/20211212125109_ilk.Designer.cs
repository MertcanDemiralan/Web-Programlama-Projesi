﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebProje.Models;

namespace WebProje.Migrations
{
    [DbContext(typeof(FilmContext))]
    [Migration("20211212125109_ilk")]
    partial class ilk
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Web_Programlama_Projesi.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sifre_Tekrar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyadi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Adminler");
                });

            modelBuilder.Entity("Web_Programlama_Projesi.Models.Film", b =>
                {
                    b.Property<int>("FilmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Film_Aciklamasi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Film_Adi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("KullaniciId")
                        .HasColumnType("int");

                    b.HasKey("FilmId");

                    b.HasIndex("KullaniciId");

                    b.ToTable("Filmler");
                });

            modelBuilder.Entity("Web_Programlama_Projesi.Models.Kategori", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FilmId")
                        .HasColumnType("int");

                    b.Property<int>("Kategori_Adı")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FilmId");

                    b.ToTable("Kategoriler");
                });

            modelBuilder.Entity("Web_Programlama_Projesi.Models.Kullanici", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sifre_Tekrar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyadi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("Web_Programlama_Projesi.Models.Oyuncu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("FilmId")
                        .HasColumnType("int");

                    b.Property<string>("Fotografi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyadi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("FilmId");

                    b.ToTable("Oyuncular");
                });

            modelBuilder.Entity("Web_Programlama_Projesi.Models.Yorum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FilmId")
                        .HasColumnType("int");

                    b.Property<int>("Yapan_Kullanici_Id")
                        .HasColumnType("int");

                    b.Property<int>("Yapilan_Film_Id")
                        .HasColumnType("int");

                    b.Property<float>("Yildiz")
                        .HasColumnType("real");

                    b.Property<string>("Yorum_Metni")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FilmId");

                    b.ToTable("Yorumlar");
                });

            modelBuilder.Entity("Web_Programlama_Projesi.Models.Film", b =>
                {
                    b.HasOne("Web_Programlama_Projesi.Models.Kullanici", null)
                        .WithMany("Favoriler")
                        .HasForeignKey("KullaniciId");
                });

            modelBuilder.Entity("Web_Programlama_Projesi.Models.Kategori", b =>
                {
                    b.HasOne("Web_Programlama_Projesi.Models.Film", null)
                        .WithMany("Kategoriler")
                        .HasForeignKey("FilmId");
                });

            modelBuilder.Entity("Web_Programlama_Projesi.Models.Oyuncu", b =>
                {
                    b.HasOne("Web_Programlama_Projesi.Models.Film", null)
                        .WithMany("Oyuncular")
                        .HasForeignKey("FilmId");
                });

            modelBuilder.Entity("Web_Programlama_Projesi.Models.Yorum", b =>
                {
                    b.HasOne("Web_Programlama_Projesi.Models.Film", null)
                        .WithMany("Yorumlar")
                        .HasForeignKey("FilmId");
                });

            modelBuilder.Entity("Web_Programlama_Projesi.Models.Film", b =>
                {
                    b.Navigation("Kategoriler");

                    b.Navigation("Oyuncular");

                    b.Navigation("Yorumlar");
                });

            modelBuilder.Entity("Web_Programlama_Projesi.Models.Kullanici", b =>
                {
                    b.Navigation("Favoriler");
                });
#pragma warning restore 612, 618
        }
    }
}
