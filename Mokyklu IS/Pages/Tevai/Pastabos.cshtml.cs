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
    public class PastabosModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public PastabosModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Model.Mokinys Mokinys { get; set; }
        public Model.Mokytojas Mokytojas { get; set; }
        public IEnumerable<Pastaba> Pastaba { get; set; }
        public IEnumerable<PasM> Ats { get; set; }
        public class PasM
        {
            public string Tekstas { get; set; }
            public DateTime Data { get; set; }
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
            var pastabos = await _db.Pastaba.Where(m => m.fk_Mokinys == ID).ToListAsync();
            Ats = from mok in mokytojai join pas in pastabos on mok.Asmens_kodas equals pas.fk_Mokytojas select new PasM{ Tekstas = pas.Tekstas, Data = pas.Data, MVardas = mok.Vardas, MPavarde = mok.Pavarde };

            return Page();
        }
    }
}
