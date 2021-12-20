using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mokyklu_IS.Model;

namespace Mokyklu_IS.Pages.Mokytojas
{
    public class Pastabos_EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public Pastabos_EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public string line { get; set; }
        [BindProperty]
        public Pastaba Nauja { get; set; }
        public async Task<IActionResult> OnGet(string id)
        {
            line = id;
            string[] Data = line.Split(' ');

            if (HttpContext.Session.GetString("id") == null)
            {
                return RedirectToPage("/Login");
            }
            else if (HttpContext.Session.GetString("role") != "Mokytojas")
            {
                return RedirectToPage("/Login");
            }

            Nauja = await _db.Pastaba.FindAsync(int.Parse(Data[0]));

            return Page();
        }

        public async Task<IActionResult> OnPost(string id)
        {
            line = id;
            string[] Data = line.Split(' ');

            var pastabaFromDb = await _db.Pastaba.FindAsync(Nauja.Id_Pastaba);
            pastabaFromDb.Tekstas = Nauja.Tekstas;

            await _db.SaveChangesAsync();

            return RedirectToPage("/Mokytojas/Pastabos", new { ID = Data[1] });
        }
    }
}
