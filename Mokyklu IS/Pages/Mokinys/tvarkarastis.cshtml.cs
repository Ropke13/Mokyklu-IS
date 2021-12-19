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
    public class tvarkarastisModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public tvarkarastisModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public string id { get; set; }
        public Model.Mokinys Mokinys { get; set; }
        public Klase Klase { get; set; }
        public IEnumerable<Tvarkarastis> Tvarkarastis { get; set; }
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
            Tvarkarastis = await _db.Tvarkarastis.ToListAsync();

            return Page();
        }
    }
}
