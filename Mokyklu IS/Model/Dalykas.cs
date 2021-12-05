using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mokyklu_IS.Model
{
    public class Dalykas
    {
        [Key]
        public int Id_Dalykas { get; set; }
        [Required]
        public string Pavadinimas { get; set; }
        public bool? Ar_isplestinis { get; set; }
    }
}
