using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OMDb.Models
{
    public class FilmKategori
    {
        [Key]
        public int FilmKategoriId { get; set; }
        public int KategoriId { get; set; }
        public Kategori Kategori { get; set; }
        public int FilmId { get; set; }
        public Film Film { get; set; }
    }
}
