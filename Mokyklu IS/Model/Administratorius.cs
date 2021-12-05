using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mokyklu_IS.Model
{
    public class Administratorius
    {
        [Key]
        public int Tabelio_nr { get; set; }

        [Required]
        public string Vardas { get; set; }
        [Required]
        public string Pavarde { get; set; }
        [Required]
        public string Telefono_nr { get; set; }

        [Required]
        [ForeignKey("fk_Registracija")]
        public Registracija Registracija { get; set; }
        public int fk_Registracija { get; set; }
    }
}
