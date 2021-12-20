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
    public class Pazimys_EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public Pazimys_EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public string line { get; set; }
        [BindProperty]
        public Pazimys Pazimys { get; set; }
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

            Pazimys = await _db.Pazimys.FindAsync(int.Parse(Data[0]));

            return Page();
        }
        public async Task<IActionResult> OnPost(string id)
        {
            line = id;
            string[] Data = line.Split(' ');

            var pazimysFromDb = await _db.Pazimys.FindAsync(Pazimys.Id_Pazimys);
            pazimysFromDb.Ivertis = Pazimys.Ivertis;
            pazimysFromDb.Vertinimo_priezastis = Pazimys.Vertinimo_priezastis;
            pazimysFromDb.Komentaras = Pazimys.Komentaras;

            await _db.SaveChangesAsync();

            return RedirectToPage("/Mokytojas/Pazimys", new { ID = Data[1] });
        }
    }
}
