using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OMDb.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMDb.Data
{
    public class ApplicationDbContext : IdentityDbContext<Users>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Film> Filmler { get; set; }
        public DbSet<Yorum> Yorumlar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<FilmKategori> FilmKategoriler { get; set; }


    }
}
