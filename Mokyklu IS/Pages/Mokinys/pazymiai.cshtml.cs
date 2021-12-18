using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mokyklu_IS.Model;
using Microsoft.AspNetCore.Http;

namespace Mokyklu_IS.Pages.Mokinys
{
    public class pazymiaiModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public pazymiaiModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Model.Pazimys> Pazymys { get; set; }
        public IEnumerable<Model.Atsiskaitymas> Atsiskaitymas { get; set; }
        public IEnumerable<Model.Dalykas> Dalykas { get; set; }
        public IEnumerable<Model.Mokytojas> Mokytojas { get; set; }
        public async Task OnGet()
        {
            Atsiskaitymas = await _db.Atsiskaitymas.ToListAsync();
            Dalykas = await _db.Dalykas.ToListAsync();
            Mokytojas = await _db.Mokytojas.ToListAsync();

            string UserID = HttpContext.Session.GetString("id");
            var Mokinys = await _db.Mokinys.FindAsync(UserID);

            Pazymys = await _db.Pazimys.Where(m => m.fk_Mokinys == UserID).ToListAsync();
        }
    }
}
