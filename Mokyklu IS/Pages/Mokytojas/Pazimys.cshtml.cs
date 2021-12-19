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

        public async Task OnGet(string id)
        {
            ID = id;
            if (HttpContext.Session.GetString("id") == null)
            {
                Response.Redirect("Login");   //Neveikia, nzn kaip padaryt kad veiktu
                //Nepavyko ir man su situo.
            }
            Pazimiai = await _db.Pazimys.Where(m => m.fk_Mokinys == id).ToListAsync();
            Mokinys = await _db.Mokinys.FindAsync(id);
            //Dingdavo id, nes po OnPost metodo mes redirectinom i tapati puslapi be id, fixed, apacioj.
            Atsiskaitymai = await _db.Atsiskaitymas.Where(m => m.fk_Mokytojas == HttpContext.Session.GetString("id") && m.fk_Klase == Mokinys.fk_Klase).ToListAsync();
            Ats = from ats in Atsiskaitymai
                  join paz in Pazimiai on ats.Id_Atsiskaitymas equals paz.fk_Atsiskaitymas
                  select new MPazimys
                  {
                      Id_Pazimys = paz.Id_Pazimys,
                      Ivertis = paz.Ivertis,
                      Vertinimo_priezastis = paz.Vertinimo_priezastis,
                      Komentaras = paz.Komentaras,
                      atsiskaitymas = ats.Tema
                  };
        }

        public async Task<IActionResult> OnPostSubmit(string id)
        {
            //Dabar jau viska paima, ka pakeiciau papasakosiu balsu nes tng rasyt xd
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
    }
}
