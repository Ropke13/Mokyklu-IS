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
    public class namuDarbaiModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public namuDarbaiModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public string id { get; set; }
        public Model.Mokinys Mokinys { get; set; }
        public Klase Klase { get; set; }
        public IEnumerable<Namu_Darbas> Namu_Darbas { get; set; }
        public IEnumerable<Model.Mokytojas> Mokytojas { get; set; }
        public async Task OnGet()
        {
            id = HttpContext.Session.GetString("id");

            Mokinys = await _db.Mokinys.FindAsync(id);
            Klase = await _db.Klase.FindAsync(Mokinys.fk_Klase);

            Mokytojas = await _db.Mokytojas
                .Include(i=>i.Dalykas).ToListAsync();
            Namu_Darbas = await _db.Namu_Darbas.Where(m => m.fk_Klase == Klase.Id_Klase).ToListAsync();
        }
    }
}
