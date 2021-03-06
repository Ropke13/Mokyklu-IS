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
    public class Priskirti_KlaseModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Priskirti_KlaseModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Model.Mokinys> Mokinys { get; set; }
        public IEnumerable<Klase> Klase { get; set; }
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

            Mokinys = await _db.Mokinys.ToListAsync();
            Klase = await _db.Klase.ToListAsync();

            return Page();
        }
        public async Task<IActionResult> OnPostPatvirtinti(string id)
        {
            string number = Request.Form["role"];
            char[] MyChar = { '0', ' ', ',' };

            foreach (char c in MyChar)
            {
                number = number.Replace(c.ToString(), String.Empty);
            }

            if (number != "NULL")
            {
                var klas = await _db.Klase.FindAsync(int.Parse(number));
                var mok = await _db.Mokinys.FindAsync(id);

                mok.fk_Klase = klas.Id_Klase;

                await _db.SaveChangesAsync();

                return RedirectToPage("/Admin/Priskirti_Klase");
            }
            return RedirectToPage("/Admin/Priskirti_Klase");
        }
    }
}
