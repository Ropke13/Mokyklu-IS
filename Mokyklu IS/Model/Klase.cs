using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mokyklu_IS.Model
{
    public class Klase
    {
        [Key]
        public int Id_Klase { get; set; }

        [Required]
        public string Pavadinimas { get; set; }
        [Required]
        public int Metai { get; set; }


    }
}
