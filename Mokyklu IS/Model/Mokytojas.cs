using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mokyklu_IS.Model
{
    public class Mokytojas
    {
        [Key]
        public int Id_Mokytojas { get; set; }
        [Required]
        public string Asmens_kodas { get; set; }
        [Required]
        public string Vardas { get; set; }
        [Required]
        public string Pavarde { get; set; }
        public bool? Ar_pilnu_etatu { get; set; }
        public int? Pamoku_sk { get; set; }
        [Required]
        public string Telefono_nr { get; set; }

        [Required]
        [ForeignKey("fk_Registracija")]
        public Registracija Registracija { get; set; }
        public int fk_Registracija { get; set; }

        [ForeignKey("fk_Dalykas")]
        public Dalykas Dalykas { get; set; }
        public int? fk_Dalykas { get; set; }
    }
}
