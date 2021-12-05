using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mokyklu_IS.Model
{
    public class Tvarkarastis
    {
        [Key]
        public int Id_Tvarkarastis { get; set; }

        [Required]
        public string Pamoka { get; set; }
        [Required]
        public string Sav_Diena { get; set; }
        [Required]
        public string Laikas { get; set; }
        [Required]
        public string Klase { get; set; }
    }
}
