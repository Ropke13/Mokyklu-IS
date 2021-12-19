using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mokyklu_IS.Model;

namespace Mokyklu_IS.Pages.Admin
{
    public class Mokiniu_Sarasas_LenteleModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Mokiniu_Sarasas_LenteleModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Model.Mokytojas Mokytojas { get; set; }
        public IEnumerable<Model.Mokinys> MokinysL { get; set; }
        public IEnumerable<Destymas> Destymas { get; set; }
        public IEnumerable<Klase> Klase { get; set; }

        public async Task<IActionResult> OnGet(string ID)
        {
            if (HttpContext.Session.GetString("id") == null)
            {
                return RedirectToPage("/Login");
            }
            else if (HttpContext.Session.GetString("role") != "Administratorius")
            {
                return RedirectToPage("/Login");
            }

            Mokytojas = await _db.Mokytojas.FindAsync(ID);
            Destymas = await _db.Destymas.ToListAsync();
            MokinysL = await _db.Mokinys.ToListAsync();
            Klase = await _db.Klase.ToListAsync();

            return Page();
        }
    }
}
