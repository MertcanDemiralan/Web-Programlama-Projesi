using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Programlama_Projesi.Models
{
    public class FilmContext: DbContext
    {
        public DbSet<Film> Filmler { set; get; }
        public DbSet<Oyuncu> Oyuncular { set; get; }
        public DbSet<Kullanici> Kullanıcılar { set; get; }
        protected override void OnConfiguring(DbContextOptionsBuilder o)
        {
            o.UseSqlServer
                (@"Server=(localdb)\mssqllocaldb;
                 Database=FilmDB;Trusted_Connection=True;");
        }
    }
}
