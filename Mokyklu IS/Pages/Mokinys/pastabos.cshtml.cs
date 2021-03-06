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
    public class pastabosModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public pastabosModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Model.Mokinys> Mokinys { get; set; }
        public IEnumerable<Pastaba> Pastaba { get; set; }
        public IEnumerable<Model.Mokytojas> Mokytojas { get; set; }
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

            Mokytojas = await _db.Mokytojas.ToListAsync();

            string UserID = HttpContext.Session.GetString("id");
            var Mokinys = await _db.Mokinys.FindAsync(UserID);

            Pastaba = await _db.Pastaba.Where(m => m.fk_Mokinys == UserID).ToListAsync();

            return Page();
        }
    }
}
