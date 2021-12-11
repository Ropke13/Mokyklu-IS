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
    public class PriskyrimasModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public PriskyrimasModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Model.Mokinys> Mokinys { get; set; }
        public IEnumerable<Tevas> Tevas { get; set; }
        public async Task OnGet()
        {
            Mokinys = await _db.Mokinys.ToListAsync();
            Tevas = await _db.Tevas.ToListAsync();
        }
        public async Task<IActionResult> OnPostPatvirtinti(string id)
        {
            int number = int.Parse(Request.Form["role"]);

            if (number != 0)
            {
                var tev = await _db.Tevas.FindAsync(number);
                var mok = await _db.Mokinys.FindAsync(id);

                mok.fk_Tevas = tev.Asmens_kodas;

                await _db.SaveChangesAsync();

                return RedirectToPage("/Admin/Priskyrimas");
            }
            return RedirectToPage("/Admin/Priskyrimas");
        }
    }
}
