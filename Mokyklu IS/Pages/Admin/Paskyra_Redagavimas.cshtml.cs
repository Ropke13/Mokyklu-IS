using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task OnGet(int id)
        {
            Registracija = await _db.Registracija.FindAsync(id);
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
