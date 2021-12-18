using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mokyklu_IS.Model;
using Microsoft.AspNetCore.Http;

namespace Mokyklu_IS.Pages.Mokinys
{
    public class atsiskaitymaiModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public atsiskaitymaiModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public Model.Mokinys Mokinys { get; set; }
        public IEnumerable<Atsiskaitymas> Atsiskaitymas { get; set; }
        public IEnumerable<Dalykas> Dalykas { get; set; }
        public IEnumerable<Model.Mokytojas> Mokytojas { get; set; }
        public async Task OnGet()
        {
            string UserID = HttpContext.Session.GetString("id");
            Mokinys = await _db.Mokinys.FindAsync(UserID);
            Dalykas = await _db.Dalykas.ToListAsync(); // wow
            Atsiskaitymas = await _db.Atsiskaitymas.Where(m => m.fk_Klase == Mokinys.fk_Klase).ToListAsync();
        }
    }
}
