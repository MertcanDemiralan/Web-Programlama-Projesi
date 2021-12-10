using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Programlama_Projesi.Models
{
    public class Kisi
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Adı alanı zorunludur!")]
        [MaxLength(100)]
        [MinLength(3)]
        public String Adi { get; set; }

        [Required(ErrorMessage = "Soyadı alanı zorunludur!")]
        [MaxLength(100)]
        [MinLength(3)]
        public String Soyadi { get; set; }

        [Required(ErrorMessage = "Mail alanı zorunludur!")]
        [EmailAddress(ErrorMessage = "Lütfen Geçerli bir email giriniz")]
        public String Email { get; set; }
        [Required(ErrorMessage = "Şifre adı alanı zorunludur!")]
        public String Sifre { get; set; }

        [Required(ErrorMessage = "Şifre tekrarı adı alanı zorunludur!")]
        [Compare("Sifre", ErrorMessage = "Şifreler eşleşmiyor!")] 
        public String Sifre_Tekrar { get; set; }

        [Required(ErrorMessage = "Telefon alanı zorunludur!")]
        [Phone(ErrorMessage = "Lütfen Geçerli bir telefon giriniz!")]
        public string Telefon { get; set; }
    }
}
