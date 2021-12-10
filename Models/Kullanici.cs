using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Programlama_Projesi.Models
{
    public class Kullanici:Kisi
    {
        public ICollection<Film> Favoriler { get; set; }

    }
}
