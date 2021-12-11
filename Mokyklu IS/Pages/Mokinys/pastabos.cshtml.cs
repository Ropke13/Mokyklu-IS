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
    public class pastabosModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public pastabosModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Model.Mokinys> Mokinys { get; set; }
        public IEnumerable<Pastaba> Pastaba { get; set; }
        public IEnumerable<Model.Mokytojas> Mokytojas { get; set; }
        public async Task OnGet()
        {
            Pastaba = await _db.Pastaba.ToListAsync();
            Mokytojas = await _db.Mokytojas.ToListAsync();
        }
    }
}
