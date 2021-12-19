using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mokyklu_IS.Model;

namespace Mokyklu_IS.Pages.Tevai
{
    public class TvarkarastisModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public TvarkarastisModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public string Id { get; set; }
        public Model.Mokinys Mokinys { get; set; }
        public Klase Klase { get; set; }
        public IEnumerable<Tvarkarastis> Tvarkarastis { get; set; }
        public async Task<IActionResult> OnGet(string id)
        {
            if (HttpContext.Session.GetString("id") == null)
            {
                return RedirectToPage("/Login");
            }
            else if (HttpContext.Session.GetString("role") != "Tevas")
            {
                return RedirectToPage("/Login");
            }

            Id = id;
            Mokinys = await _db.Mokinys.FindAsync(id);
            Klase = await _db.Klase.FindAsync(Mokinys.fk_Klase);
            Tvarkarastis = await _db.Tvarkarastis.ToListAsync();

            return Page();
        }
    }
}
