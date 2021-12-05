using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mokyklu_IS.Model
{
    public class Registracija
    {
        [Key]
        public int Id_Registracija { get; set; }
        [Required]
        public string Prisijungimo_vardas { get; set; }
        [Required]
        public string Slaptazodis { get; set; }
        [Required]
        public string Vardas { get; set; }
        [Required]
        public string Pavarde { get; set; }
        [Required]
        public bool Ar_patvirtinta { get; set; }
        [Required]
        public string Telefono_nr { get; set; }
        [Required]
        public string Asmens_kodas { get; set; }
        [Required]
        public string Role { get; set; }

    }
}
