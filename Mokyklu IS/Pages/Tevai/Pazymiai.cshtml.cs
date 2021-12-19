using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mokyklu_IS.Model;
using Microsoft.AspNetCore.Http;

namespace Mokyklu_IS.Pages.Tevai
{
    public class PazymiaiModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public PazymiaiModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Model.Mokinys Mokinys { get; set; }
        public Model.Mokytojas Mokytojas { get; set; }
        public IEnumerable<Pazimys> Pazimys { get; set; }
        public IEnumerable<PazM> Ats { get; set; }
        public class PazM
        {
            public int Ivertis { get; set; }
            public string Priezastis { get; set; }
            public string Komentaras { get; set; }
            public string MVardas { get; set; }
            public string MPavarde { get; set; }
        }
        public async Task<IActionResult> OnGet(string ID)
        {
            if (HttpContext.Session.GetString("id") == null)
            {
                return RedirectToPage("/Login");
            }
            else if (HttpContext.Session.GetString("role") != "Tevas")
            {
                return RedirectToPage("/Login");
            }

            Mokinys = await _db.Mokinys.FindAsync(ID);
            var mokytojai = await _db.Mokytojas.ToListAsync();
            var pamoka = await _db.Atsiskaitymas.ToListAsync();
            var pazymiai = await _db.Pazimys.Where(m => m.fk_Mokinys == ID).ToListAsync();
            Ats = from mok in mokytojai join paz in pazymiai on mok.Asmens_kodas equals paz.fk_Mokytojas select new 
                  PazM { Ivertis = paz.Ivertis, Priezastis = paz.Vertinimo_priezastis, Komentaras = paz.Komentaras, MVardas = mok.Vardas, MPavarde = mok.Pavarde};

            return Page();
        }
    }
}
