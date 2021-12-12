using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProje.Models
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

        public ICollection<Kategori> Kategoriler { get; set; }
        public ICollection<Yorum> Yorumlar { get; set; }
        public ICollection<Oyuncu> Oyuncular { get; set; }
    }
}
