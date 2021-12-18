using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProgramlamaProjesi.Models
{
    public class Kategori
    {
        public int Id { get; set; }
        public string Kategori_Adı { get; set; }
        public ICollection<Film> Filmler { get; set; }
    }
}
