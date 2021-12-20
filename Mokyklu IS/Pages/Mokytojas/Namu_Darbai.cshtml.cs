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
    public class Namu_DarbaiModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Namu_DarbaiModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public int ID { get; set; }
        [BindProperty]
        public Namu_Darbas Nauja { get; set; }
        public IEnumerable<Namu_Darbas> ND { get; set; }
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
            ND = await _db.Namu_Darbas.Where(m => m.fk_Klase == id && m.fk_Mokytojas == HttpContext.Session.GetString("id")).ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            Nauja.fk_Klase = id;
            Nauja.fk_Mokytojas = HttpContext.Session.GetString("id");

            await _db.Namu_Darbas.AddAsync(Nauja);
            await _db.SaveChangesAsync();
            return RedirectToPage("/Mokytojas/Namu_Darbai", new { ID = id });
        }
    }
}
