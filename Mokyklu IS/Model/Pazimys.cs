using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mokyklu_IS.Model
{
    public class Pazimys
    {
        [Key]
        public int Id_Pazimys { get; set; }
        [Required]
        public int Ivertis { get; set; }
        public string Vertinimo_priezastis { get; set; }
        public string Komentaras { get; set; }

        [ForeignKey("fk_Mokytojas")]
        public Mokytojas Mokytojas { get; set; }
        public string? fk_Mokytojas { get; set; }

        [ForeignKey("fk_Atsiskaitymas")]
        public Atsiskaitymas Atsiskaitymas { get; set; }
        public int? fk_Atsiskaitymas { get; set; }

        [ForeignKey("fk_Mokinys")]
        public Mokinys Mokinys { get; set; }
        public string? fk_Mokinys { get; set; }
    }
}
