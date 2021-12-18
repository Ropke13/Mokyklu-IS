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
        public Pazimys Pazimys { get; set; }

        [BindProperty]
        public IEnumerable<MPazimys> Ats { get; set; }
        public IEnumerable<Pazimys> Pazimiai { get; set; }
        public IEnumerable<Atsiskaitymas> Atsiskaitymai { get; set; }
        [BindProperty]
        public Model.Mokinys Mokinys { get; set; }

        public async Task OnGet(string id)
        {
            if (HttpContext.Session.GetString("id") == null)
            {
                Redirect("/Mokytojas/Index");   //Neveikia, nzn kaip padaryt kad veiktu
            }
            Pazimiai = await _db.Pazimys.Where(m => m.fk_Mokinys == id).ToListAsync();
            Mokinys = await _db.Mokinys.FindAsync(id);
            //Sesija dingsta tai neranda atsisakitymu po post metodo
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
            //Nepaima nei priezasties, nei komentaro, nei mokinio, nzn kodel, kitus laukus paima
            int ats = int.Parse(Request.Form["test"]);
            if(ats != 0)
            {
                Pazimys.fk_Atsiskaitymas = ats;
            }
            Pazimys.fk_Mokytojas = HttpContext.Session.GetString("id");
            Pazimys.fk_Mokinys = id;
            await _db.Pazimys.AddAsync(Pazimys);
            await _db.SaveChangesAsync();
            return RedirectToPage("/Mokytojas/Pazimys");
        }
    }
}
