using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace WebProje.Models
{
    public class Oyuncu
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Oyuncu Adı alanı zorunludur!")]
        [MaxLength(100)]
        [MinLength(3)]
        public string Adi { get; set; }

        [Required(ErrorMessage = "Oyuncu Soyadı alanı zorunludur!")]
        [MaxLength(100)]
        [MinLength(3)]
        public string Soyadi { get; set; }

        [Required(ErrorMessage = "Fotoğraf alanı zorunludur!")]
        public string Fotografi { get; set; }

    }
}
