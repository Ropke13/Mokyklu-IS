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
    public class Namu_Darbai_EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public Namu_Darbai_EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public string line { get; set; }
        [BindProperty]
        public Namu_Darbas ND { get; set; }
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
            line = id;
            string[] Data = line.Split(' ');

            ND = await _db.Namu_Darbas.FindAsync(int.Parse(Data[0]));

            return Page();
        }
        public async Task<IActionResult> OnPost(string id)
        {
            line = id;
            string[] Data = line.Split(' ');

            var ndFromDb = await _db.Namu_Darbas.FindAsync(ND.Id_Namu_darbas);
            ndFromDb.Tema = ND.Tema;
            ndFromDb.Uzduotis = ND.Uzduotis;
            ndFromDb.Data = ND.Data;

            await _db.SaveChangesAsync();

            return RedirectToPage("/Mokytojas/Namu_Darbai", new { ID = int.Parse(Data[1]) });
        }
    }
}
