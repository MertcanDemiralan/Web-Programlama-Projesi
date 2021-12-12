using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProje.Models
{
    public class FilmContext : DbContext
    {
        public DbSet<Admin> Adminler { get; set; }
        public DbSet<Film> Filmler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Oyuncu> Oyuncular { get; set; }
        public DbSet<Yorum> Yorumlar { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder o)
        {
            o.UseSqlServer
                (@"Server=(localdb)\mssqllocaldb;
                 Database=FilmDB;Trusted_Connection=True;");
        }
    }
}
