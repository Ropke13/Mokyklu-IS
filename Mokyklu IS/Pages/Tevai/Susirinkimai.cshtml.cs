using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mokyklu_IS.Model;
using Microsoft.AspNetCore.Http;

namespace Mokyklu_IS.Pages.Tevai
{
    public class SusirinkimaiModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public SusirinkimaiModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public Tevas Tevas { get; set; }
        public Susirinkimas Susirinkimas { get; set; }
        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.GetString("id") == null)
            {
                return RedirectToPage("/Login");
            }
            else if (HttpContext.Session.GetString("role") != "Tevas")
            {
                return RedirectToPage("/Login");
            }

            string UserID = HttpContext.Session.GetString("id");

            Tevas = await _db.Tevas.FindAsync(UserID);
            Susirinkimas = await _db.Susirinkimas.Where(m => m.Id_Susirinkimas == Tevas.fk_Susirinkimas).FirstAsync();

            return Page();
        }
    }
}
