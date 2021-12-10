using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Web_Programlama_Projesi.Models
{
    public class Oyuncu
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Oyuncu Adı alanı zorunludur!")]
        [MaxLength(100)]
        [MinLength(3)]
        public String Adi { get; set; }

        [Required(ErrorMessage = "Oyuncu Soyadı alanı zorunludur!")]
        [MaxLength(100)]
        [MinLength(3)]
        public String Soyadi { get; set; }

        [Required(ErrorMessage = "Fotoğraf alanı zorunludur!")]
        public String Fotografi { get; set; }

    }
}
