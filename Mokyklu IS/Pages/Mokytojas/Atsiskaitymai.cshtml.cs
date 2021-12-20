using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mokyklu_IS.Model;

namespace Mokyklu_IS.Pages.Mokytojas
{
    public class AtsiskaitymaiModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public AtsiskaitymaiModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public int ID { get; set; }
        [BindProperty]
        public Atsiskaitymas Nauja { get; set; }
        public IEnumerable<Atsiskaitymas> Atsiskaitymas { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            if (HttpContext.Session.GetString("id") == null)
            {
                return RedirectToPage("/Login");
            }
            else if (HttpContext.Session.GetString("role") != "Mokytojas")
            {
                return RedirectToPage("/Login");
            }

            ID = id;
            Atsiskaitymas = await _db.Atsiskaitymas.Where(m => m.fk_Klase == id && m.fk_Mokytojas == HttpContext.Session.GetString("id")).ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            Nauja.fk_Klase = id;
            Nauja.fk_Mokytojas = HttpContext.Session.GetString("id");

            await _db.Atsiskaitymas.AddAsync(Nauja);
            await _db.SaveChangesAsync();
            return RedirectToPage("/Mokytojas/Atsiskaitymai", new { ID = id });
        }

        public async Task<IActionResult> OnPostDelete(string id)
        {
            string line = id;
            string[] Data = line.Split(' ');

            var reg = await _db.Atsiskaitymas.FindAsync(int.Parse(Data[0]));
            if (reg == null)
            {
                return NotFound();
            }
            _db.Atsiskaitymas.Remove(reg);
            await _db.SaveChangesAsync();

            return RedirectToPage("/Mokytojas/Atsiskaitymai", new { ID = int.Parse(Data[1]) });
        }
    }
}
