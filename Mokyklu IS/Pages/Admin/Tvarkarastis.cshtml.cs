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
    public class TvarkarastisModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public TvarkarastisModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public string Error { get; set; }
        public IEnumerable<Klase> Klase { get; set; }
        [BindProperty]
        public Tvarkarastis Tvarkarastis { get; set; }
        public IEnumerable<Tvarkarastis> Visi { get; set; }
        public async Task<IActionResult> OnGet(string Errorr)
        {
            if (HttpContext.Session.GetString("id") == null)
            {
                return RedirectToPage("/Login");
            }
            else if (HttpContext.Session.GetString("role") != "Administratorius")
            {
                return RedirectToPage("/Login");
            }
            Error = Errorr;
            Klase = await _db.Klase.ToListAsync();
            Visi = await _db.Tvarkarastis.ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            Visi = await _db.Tvarkarastis.ToListAsync();
            string pamoka = Request.Form["pamoka"];
            string diena = Request.Form["diena"];
            string laikas = Request.Form["laikas"];
            string klase = Request.Form["klase"];

            Tvarkarastis.Pamoka = pamoka;
            Tvarkarastis.Sav_Diena = diena;
            Tvarkarastis.Laikas = laikas;
            Tvarkarastis.Klase = klase;
            foreach(var item in Visi)
            {
                if(item.Klase == klase)
                {
                    if(item.Sav_Diena == diena && item.Laikas == laikas)
                    {
                        Error = "Diena ir laikas sutampa, pamokos irasyti negalima";
                        return RedirectToPage("/Admin/Tvarkarastis", new { Errorr = Error });
                    }
                }
            }
            await _db.Tvarkarastis.AddAsync(Tvarkarastis);
            await _db.SaveChangesAsync();
            return RedirectToPage("/Admin/Tvarkarastis");
        }
    }
}
