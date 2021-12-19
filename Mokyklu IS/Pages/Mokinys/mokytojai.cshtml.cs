using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mokyklu_IS.Model;

namespace Mokyklu_IS.Pages.Mokinys
{
    public class mokytojaiModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public mokytojaiModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public string Id { get; set; }
        public int klaseId { get; set; }
        public Model.Mokinys Mokinys { get; set; }
        public IEnumerable<Destymas> Destymas { get; set; }
        public IEnumerable<Klase> Klase { get; set; }
        public IEnumerable<Dalykas> Dalykas { get; set; }
        public IEnumerable<Model.Mokytojas> Mokytojas { get; set; }
        public async Task OnGet()
        {
            Id = HttpContext.Session.GetString("id");
            Mokinys = await _db.Mokinys.FindAsync(Id);
            Destymas = await _db.Destymas.ToListAsync();
            Klase = await _db.Klase.ToListAsync();
            foreach(var item in Klase)
            {
                if (item.Id_Klase == Mokinys.fk_Klase) klaseId = item.Id_Klase; break;
            }
            Mokytojas = await _db.Mokytojas.ToListAsync();
            Dalykas = await _db.Dalykas.ToListAsync();
        }
    }
}
