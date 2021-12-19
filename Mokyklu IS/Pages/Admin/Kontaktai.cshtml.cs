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
    public class KontaktaiModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public KontaktaiModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Registracija> Registracija { get; set; }

        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.GetString("id") == null)
            {
                return RedirectToPage("/Login");
            }

            else if (HttpContext.Session.GetString("role") != "Administratorius")
            {
                return RedirectToPage("/Login");
            }

            Registracija = await _db.Registracija.ToListAsync();

            return Page();
        }
    }
}
