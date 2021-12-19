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
    public class ZinutesModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public ZinutesModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Zinutes Zinute { get; set; }
        public Tevas Tevas1 { get; set; }
        public string UserID { get; set; }
        public IEnumerable<Model.Zinutes> Zinutes { get; set; }
        public IEnumerable<Model.Mokytojas> Mokytojas { get; set; }
        public IEnumerable<Zin> Ats { get; set; }
        public class Zin
        {
            public int Id { get; set; }
            public string Tekstas { get; set; }
            public DateTime Data { get; set; }
            public string MVardas { get; set; }
            public string MPavarde { get; set; }
        }
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

            Mokytojas = await _db.Mokytojas.ToListAsync();
            UserID = HttpContext.Session.GetString("id");
            var mokytojai = await _db.Mokytojas.ToListAsync();
            var zinutes = await _db.Zinutes.Where(m => m.fk_Tevas == UserID).ToListAsync();
            Ats = from zin in zinutes join mok in mokytojai on zin.fk_Mokytojas equals mok.Asmens_kodas select new 
                  Zin { Id = zin.Id_Zinutes, Tekstas = zin.Tekstas, Data = zin.Data, MVardas = mok.Vardas, MPavarde = mok.Pavarde };

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            UserID = HttpContext.Session.GetString("id");
            string kam = Request.Form["gavejas"];
            Zinute.fk_Mokytojas = kam;
            Zinute.Data = DateTime.Now;
            Zinute.fk_Tevas = UserID;

            await _db.Zinutes.AddAsync(Zinute);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
