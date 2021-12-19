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

        public string id { get; set; }
        public Model.Mokinys Mokinys { get; set; }
        public Klase Klase { get; set; }
        public IEnumerable<Atsiskaitymas> Atsiskaitymas { get; set; }
        public IEnumerable<Model.Mokytojas> Mokytojas { get; set; }
        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.GetString("id") == null)
            {
                return RedirectToPage("/Login");
            }
            else if (HttpContext.Session.GetString("role") != "Mokinys")
            {
                return RedirectToPage("/Login");
            }

            id = HttpContext.Session.GetString("id");

            Mokinys = await _db.Mokinys.FindAsync(id);
            Klase = await _db.Klase.FindAsync(Mokinys.fk_Klase);

            Mokytojas = await _db.Mokytojas
                .Include(i => i.Dalykas).ToListAsync();
            Atsiskaitymas = await _db.Atsiskaitymas.Where(m => m.fk_Klase == Klase.Id_Klase).ToListAsync();

            return Page();
        }
    }
}
