using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProgramlamaProjesi.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Admin Adı alanı zorunludur!")]
        [MaxLength(100)]
        [MinLength(3)]
        [Display(Name = "Admin Adı")]
        public string Adi { get; set; }

        [Required(ErrorMessage = "Admin Soyadı alanı zorunludur!")]
        [MaxLength(100)]
        [MinLength(3)]
        [Display(Name = "Admin Soyadı")]
        public string Soyadi { get; set; }

        [Required(ErrorMessage = "Mail alanı zorunludur!")]
        [EmailAddress(ErrorMessage = "Lütfen Geçerli bir email giriniz")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre adı alanı zorunludur!")]
        public string Sifre { get; set; }

        [Required(ErrorMessage = "Şifre tekrarı adı alanı zorunludur!")]
        [Compare("Sifre", ErrorMessage = "Şifreler eşleşmiyor!")]
        public string Sifre_Tekrar { get; set; }

        [Required(ErrorMessage = "Telefon alanı zorunludur!")]
        [Phone(ErrorMessage = "Lütfen Geçerli bir telefon giriniz!")]
        public string Telefon { get; set; }

    }
}
