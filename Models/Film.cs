using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OMDb.Models
{
    public class Film
    {
        [Key]
        public int FilmId { get; set; }

        [Required(ErrorMessage = "Film adı alanı zorunludur!")]
        [MaxLength(100)]
        [MinLength(2)]
        public string Film_Adi { get; set; }

        [Required(ErrorMessage = "Film Açıklama alanı zorunludur!")]
        [MaxLength(100)]
        [MinLength(3)]
        public string Film_Aciklamasi { get; set; }

        [Required(ErrorMessage = "Film URL alanı zorunludur!")]
        public string Film_URL { get; set; }

        //public int Kategori_Id { get; set; }
        //Filmlerin kategorileri girilirken kategorilerin arasına ", " çift tırnak içerisindeki ifadeyi yazınız.Ve kategorilerin sadece ilk harfleri Büyük  olsun.Örneğin Aksiyon
        [Required(ErrorMessage = "Film Kategorileri alanı zorunludur!")]
        public string Film_Kategorileri { get; set; }

        public ICollection<FilmKategori> FilmKategoriler { get; set; }
        public ICollection<Yorum> Yorumlar { get; set; }
        //public ICollection<Oyuncu> Oyuncular { get; set; }
    }
}
