using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mokyklu_IS.Model;

namespace Mokyklu_IS.Pages.Admin
{
    public class Mokiniu_Sarasas_LenteleModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Mokiniu_Sarasas_LenteleModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Model.Mokytojas> Mokytojas { get; set; }
        public IEnumerable<Destymas> Destymas { get; set; }
        public IEnumerable<Klase> Klase { get; set; }
        public IEnumerable<Model.Mokinys> Mokinys { get; set; }

        public async Task OnGet()
        {
            Mokytojas = await _db.Mokytojas.ToListAsync();
            Destymas = await _db.Destymas.ToListAsync();
            Klase = await _db.Klase.ToListAsync();
            Mokinys = await _db.Mokinys.ToListAsync();
        }
    }
}
