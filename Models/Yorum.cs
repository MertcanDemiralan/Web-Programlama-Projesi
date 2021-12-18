using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProgramlamaProjesi.Models
{
    public class Yorum
    {
        [Key]
        public int Id { get; set; }
        public int Yapan_Kullanici_Id { get; set; }
        public int Yapilan_Film_Id { get; set; }
        public string Yorum_Metni { get; set; }
        public float Yildiz { get; set; }

    }
}
