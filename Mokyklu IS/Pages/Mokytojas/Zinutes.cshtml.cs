using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mokyklu_IS.Model;

namespace Mokyklu_IS.Pages.Mokytojas
{
    public class ZinutesModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public ZinutesModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Zinutes> Zinutes { get; set; }
        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.GetString("id") == null)
            {
                return RedirectToPage("/Login");
            }
            else if (HttpContext.Session.GetString("role") != "Mokytojas")
            {
                return RedirectToPage("/Login");
            }

            Zinutes = await _db.Zinutes.Where(m => m.fk_Mokytojas == HttpContext.Session.GetString("id"))
                .Include(m => m.Tevas).ToListAsync();

            foreach(var item in Zinutes)
            {
                if(item.ArPerskaityta == false)
                {
                    var zinuteFromDb = await _db.Zinutes.FindAsync(item.Id_Zinutes);
                    zinuteFromDb.ArPerskaityta = true;

                    await _db.SaveChangesAsync();
                }
            }

            return Page();
        }
    }
}
