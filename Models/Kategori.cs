using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OMDb.Models
{
    public class Kategori
    {
        [Key]
        public int KategoriId { get; set; }
        [Required(ErrorMessage = "Kategori adı alanı zorunludur!")]
        [MaxLength(100)]
        [MinLength(2)]
        public string Kategori_Adi { get; set; }
        public ICollection<FilmKategori> FilmKategoriler { get; set; }


    }
}
