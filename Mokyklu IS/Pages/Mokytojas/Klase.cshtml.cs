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
    public class KlaseModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public KlaseModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public IEnumerable<Model.Mokinys> Mokiniai { get; set; }
        public Klase Klase { get; set; }
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
            Klase = await _db.Klase.FindAsync(id);
            Mokiniai = await _db.Mokinys.Where(m => m.fk_Klase == id).ToListAsync();

            return Page();
        }
    }
}
