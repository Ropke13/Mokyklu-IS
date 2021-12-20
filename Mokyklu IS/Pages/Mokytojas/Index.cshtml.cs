using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Mokyklu_IS.Model;

namespace Mokyklu_IS.Pages.Mokytojas
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public int NePerZinutes { get; set; }
        public string UserID { get; set; }
        [BindProperty]
        public Model.Mokytojas Mokytojas { get; set; }
        public IEnumerable<Klase> Klases { get; set; }
        public IEnumerable<Klase> Ats { get; set; }
        public IEnumerable<Destymas> Destymai { get; set; }
        public IEnumerable<Zinutes> Zinutes { get; set; }

        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.GetString("id") == null)
            {
                return RedirectToPage("/Login");
            }
            else if (HttpContext.Session.GetString("role") != "Mokytojas")
            {
                return RedirectToPage("/Login");
            }

            UserID = HttpContext.Session.GetString("id");
            Mokytojas = await _db.Mokytojas.FindAsync(UserID);
            Destymai = await _db.Destymas.Where(m => m.fk_Mokytojas==UserID).ToListAsync();

            Zinutes = await _db.Zinutes.Where(m => m.fk_Mokytojas == UserID).ToListAsync();
            NePerZinutes = 0;
            foreach (var item in Zinutes)
            {
                if(item.ArPerskaityta == false)
                {
                    NePerZinutes++;
                }
            }

            Klases = await _db.Klase.ToListAsync();
            Ats = (from kl in Klases where Destymai.Any(d => d.fk_Klase.Equals(kl.Id_Klase)==true) select kl).ToList();

            var mokytojai = await _db.Mokytojas.ToListAsync();
            var pastabos = await _db.Pastaba.ToListAsync();
            var ats = from mok in mokytojai join pas in pastabos on mok.Asmens_kodas equals pas.fk_Mokytojas select new { Tekstas = pas.Tekstas, Data = pas.Data, MVardas = mok.Vardas, MPavarde = mok.Pavarde };
                
            return Page();
        }
    }
}
