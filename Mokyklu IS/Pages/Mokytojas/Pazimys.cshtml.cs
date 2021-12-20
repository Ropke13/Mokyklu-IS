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
    public class PazimysModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public PazimysModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public class MPazimys : Pazimys
        {
            public string atsiskaitymas { get; set; }
        }
        [BindProperty]
        public string ID { get; set; }

        [BindProperty]
        public Pazimys Pazimys { get; set; }

        [BindProperty]
        public IEnumerable<MPazimys> Ats { get; set; }
        public IEnumerable<Pazimys> Pazimiai { get; set; }
        public IEnumerable<Atsiskaitymas> Atsiskaitymai { get; set; }
        [BindProperty]
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

            Pazimiai = await _db.Pazimys.Where(m => m.fk_Mokinys == id).ToListAsync();
            Mokinys = await _db.Mokinys.FindAsync(id);
            Atsiskaitymai = await _db.Atsiskaitymas.Where(m => m.fk_Mokytojas == HttpContext.Session.GetString("id") && m.fk_Klase == Mokinys.fk_Klase).ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostSubmit(string id)
        {
            int ats = int.Parse(Request.Form["test"]);
            if(ats != 0)
            {
                Pazimys.fk_Atsiskaitymas = ats;
            }
            Pazimys.fk_Mokytojas = HttpContext.Session.GetString("id");
            Pazimys.fk_Mokinys = ID;
            await _db.Pazimys.AddAsync(Pazimys);
            await _db.SaveChangesAsync();

            return RedirectToPage("/Mokytojas/Pazimys", new { ID = id});
        }
        public async Task<IActionResult> OnPostDelete(string id)
        {
            string line = id;
            string[] Data = line.Split(' ');

            var reg = await _db.Pazimys.FindAsync(int.Parse(Data[0]));
            if (reg == null)
            {
                return NotFound();
            }
            _db.Pazimys.Remove(reg);
            await _db.SaveChangesAsync();

            return RedirectToPage("/Mokytojas/Pazimys", new { ID = int.Parse(Data[1]) });
        }
    }
}
