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
    public class MokinysModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public MokinysModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public string ID { get; set; }
        public Model.Mokinys Mokinys { get; set; }
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

            ID = id;
            Mokinys = await _db.Mokinys.FindAsync(id);

            return Page();
        }
    }
}
