using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mokyklu_IS.Model;

namespace Mokyklu_IS.Pages.Admin
{
    public class Paskyra_RedagavimasModel : PageModel
    {
        private ApplicationDbContext _db;

        public Paskyra_RedagavimasModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Registracija Registracija { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            if (HttpContext.Session.GetString("id") == null)
            {
                return RedirectToPage("/Login");
            }
            else if (HttpContext.Session.GetString("role") != "Administratorius")
            {
                return RedirectToPage("/Login");
            }
            Registracija = await _db.Registracija.FindAsync(id);

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
                var RegFromDb = await _db.Registracija.FindAsync(Registracija.Id_Registracija);
                RegFromDb.Vardas = Registracija.Vardas;
                RegFromDb.Pavarde = Registracija.Pavarde;
                RegFromDb.Telefono_nr = Registracija.Telefono_nr;
                RegFromDb.Asmens_kodas = Registracija.Asmens_kodas;

                await _db.SaveChangesAsync();

                return RedirectToPage("/Admin/PaskiruTvarkykle");
        }
    }
}
