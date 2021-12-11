using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mokyklu_IS.Model
{
    public class Mokinys
    {
        [Key]
        public string Asmens_kodas { get; set; }
        [Required]
        public string Vardas { get; set; }
        [Required]
        public string Pavarde { get; set; }
        public int? Pamoku_sk { get; set; }
        public int? Dalyku_sk { get; set; }
        public string GimimoData { get; set; }
        [Required]
        public string Telefono_nr { get; set; }

        [ForeignKey("fk_Tevas")]
        public Tevas Tevas { get; set; }
        public string? fk_Tevas { get; set; }

        [ForeignKey("fk_Klase")]
        public Klase Klase { get; set; }
        public int? fk_Klase { get; set; }

        [Required]
        [ForeignKey("fk_Registracija")]
        public Registracija Registracija { get; set; }
        public int fk_Registracija { get; set; }
    }
}
