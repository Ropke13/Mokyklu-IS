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
    public class Mokiniu_SarasasModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Mokiniu_SarasasModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Model.Mokytojas> Mokytojas { get; set; }

        public async Task OnGet()
        {
            Mokytojas = await _db.Mokytojas.ToListAsync();
        }
    }
}
