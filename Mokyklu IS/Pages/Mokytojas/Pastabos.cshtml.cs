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
    public class PastabosModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public PastabosModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Pastaba Nauja { get; set; }
        public string ID { get; set; }
        public IEnumerable<Pastaba> Pastaba { get; set; }
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
            ID = id;
            Pastaba = await _db.Pastaba.Where(m => m.fk_Mokinys == id && m.fk_Mokytojas == HttpContext.Session.GetString("id")).ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPost(string id)
        {
            Nauja.fk_Mokinys = id;
            Nauja.fk_Mokytojas = HttpContext.Session.GetString("id");
            Nauja.Data = DateTime.Now;

            await _db.Pastaba.AddAsync(Nauja);
            await _db.SaveChangesAsync();
            return RedirectToPage("/Mokytojas/Pastabos", new { ID = id });
        }
    }
}
