using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mokyklu_IS.Model;

namespace Mokyklu_IS.Pages.Mokinys
{
    public class atsiskaitymaiModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public atsiskaitymaiModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Model.Mokinys> Mokinys { get; set; }
        public IEnumerable<Atsiskaitymas> Atsiskaitymas { get; set; }
        public IEnumerable<Dalykas> Dalykas { get; set; }
        public IEnumerable<Model.Mokytojas> Mokytojas { get; set; }
        public async Task OnGet()
        {
            Atsiskaitymas = await _db.Atsiskaitymas.ToListAsync();
            Dalykas = await _db.Dalykas.ToListAsync();
            Mokytojas = await _db.Mokytojas.ToListAsync();
        }
    }
}
