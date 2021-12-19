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
    public class VidurkiaiModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public VidurkiaiModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Model.Mokinys> Mokiniai { get; set; }
        public IEnumerable<Dalykas> Dalykas { get; set; }
        public IEnumerable<Pazimys> Pazimys { get; set; }
        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.GetString("id") == null)
            {
                return RedirectToPage("/Login");
            }
            else if (HttpContext.Session.GetString("role") != "Tevas")
            {
                return RedirectToPage("/Login");
            }

            Dalykas = await _db.Dalykas.ToListAsync();
            Mokiniai = await _db.Mokinys.Where(m => m.fk_Tevas == HttpContext.Session.GetString("id")).ToListAsync();
            Pazimys = await _db.Pazimys
                .Include(i => i.Mokytojas)
                .ThenInclude(j => j.Dalykas).ToListAsync();

            return Page();
        }
    }
}
