using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IEnumerable<Model.Mokinys> Mokinys { get; set; }
        public IEnumerable<Namu_Darbas> Namu_Darbas { get; set; }
        public IEnumerable<Dalykas> Dalykas { get; set; }
        public IEnumerable<Model.Mokytojas> Mokytojas { get; set; }
        public async Task OnGet()
        {
            Namu_Darbas = await _db.Namu_Darbas.ToListAsync();
            Dalykas = await _db.Dalykas.ToListAsync();
            Mokytojas = await _db.Mokytojas.ToListAsync();
        }
    }
}
