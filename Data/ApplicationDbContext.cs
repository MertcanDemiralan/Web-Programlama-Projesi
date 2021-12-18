using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebProgramlamaProjesi.Models;

namespace WebProgramlamaProjesi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Admin> Adminler { get; set; }
        public DbSet<Film> Filmler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Oyuncu> Oyuncular { get; set; }
        public DbSet<Yorum> Yorumlar { get; set; }
    }
}
