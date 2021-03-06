using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OMDb.Models
{
    public class Yorum
    {
        [Key]
        public int YorumId { get; set; }
        [Required]
        [MaxLength(255)]
        [MinLength(3)]
        [Display(Name = "Yorum")]
        public string Text { get; set; }
        public int FilmId { get; set; }
        public Film Film { get; set; }
    }
}
