using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mokyklu_IS.Model;

namespace Mokyklu_IS.Pages.Mokytojas
{
    public class Atsiskaitymas_EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public Atsiskaitymas_EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public string line { get; set; }
        [BindProperty]
        public Atsiskaitymas Atsiskaitymas { get; set; }
        public async Task<IActionResult> OnGet(string id)
        {
            if (HttpContext.Session.GetString("id") == null)
            {
                return RedirectToPage("/Login");
            }
            else if (HttpContext.Session.GetString("role") != "Mokytojas")
            {
                return RedirectToPage("/Login");
            }
            line = id;
            string[] Data = line.Split(' ');

            Atsiskaitymas = await _db.Atsiskaitymas.FindAsync(int.Parse(Data[0]));

            return Page();
        }
        public async Task<IActionResult> OnPost(string id)
        {
            line = id;
            string[] Data = line.Split(' ');

            var ndFromDb = await _db.Atsiskaitymas.FindAsync(Atsiskaitymas.Id_Atsiskaitymas);
            ndFromDb.Tema = Atsiskaitymas.Tema;
            ndFromDb.laikas = Atsiskaitymas.laikas;
            ndFromDb.Data = Atsiskaitymas.Data;

            await _db.SaveChangesAsync();

            return RedirectToPage("/Mokytojas/Atsiskaitymai", new { ID = int.Parse(Data[1]) });
        }
    }
}
