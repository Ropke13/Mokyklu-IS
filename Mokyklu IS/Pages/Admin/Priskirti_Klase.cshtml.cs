using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mokyklu_IS.Model;

namespace Mokyklu_IS.Pages.Admin
{
    public class Priskirti_KlaseModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Priskirti_KlaseModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Model.Mokinys> Mokinys { get; set; }
        public IEnumerable<Klase> Klase { get; set; }
        public async Task OnGet()
        {
            Mokinys = await _db.Mokinys.ToListAsync();
            Klase = await _db.Klase.ToListAsync();
        }
        public async Task<IActionResult> OnPostPatvirtinti(int id)
        {
            int number = int.Parse(Request.Form["role"]);

            if (number != 0)
            {
                var klas = await _db.Klase.FindAsync(number);
                var mok = await _db.Mokinys.FindAsync(id);

                mok.fk_Klase = klas.Id_Klase;

                await _db.SaveChangesAsync();

                return RedirectToPage("/Admin/Priskirti_Klase");
            }
            return RedirectToPage("/Admin/Priskirti_Klase");
        }
    }
}
