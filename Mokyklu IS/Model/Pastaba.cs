using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mokyklu_IS.Model
{
    public class Pastaba
    {
        [Key]
        public int Id_Pastaba { get; set; }

        [Required]
        public string Tekstas { get; set; }
        [Required]
        public DateTime Data { get; set; }

        [ForeignKey("fk_Mokytojas")]
        public Mokytojas Mokytojas { get; set; }
        public string fk_Mokytojas { get; set; }

        [ForeignKey("fk_Mokinys")]
        public Mokinys Mokinys { get; set; }
        public string fk_Mokinys { get; set; }
    }
}
