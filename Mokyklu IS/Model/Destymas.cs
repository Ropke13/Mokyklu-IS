using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mokyklu_IS.Model
{
    public class Destymas
    {
        [ForeignKey("fk_Klase")]
        public Klase Klase { get; set; }
        public int? fk_Klase { get; set; }

        [ForeignKey("fk_Mokytojas")]
        public Mokytojas Mokytojas { get; set; }
        public string fk_Mokytojas { get; set; }
    }
}
