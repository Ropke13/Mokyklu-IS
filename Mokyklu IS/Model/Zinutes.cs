using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mokyklu_IS.Model
{
    public class Zinutes
    {
        [Key]
        public int Id_Zinutes { get; set; }
        [Required]
        public string Tekstas { get; set; }
        [Required]
        public DateTime Data { get; set; }

        [ForeignKey("fk_Tevas")]
        public Tevas Tevas { get; set; }
        public string? fk_Tevas { get; set; }

        [ForeignKey("fk_Mokytojas")]
        public Mokytojas Mokytojas { get; set; }
        public string? fk_Mokytojas { get; set; }
    }
}
