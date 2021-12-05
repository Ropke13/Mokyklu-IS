using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mokyklu_IS.Model
{
    public class Susirinkimas
    {
        [Key]
        public int Id_Susirinkimas { get; set; }

        [Required]
        public string Priezastis { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public string Laikas { get; set; }
        [Required]
        public string Kabinetas { get; set; }
    }
}
