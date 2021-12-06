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
    public class PaskiruTvarkykleModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public PaskiruTvarkykleModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Registracija> Registracija { get; set; }

        public async Task OnGet()
        {
            Registracija = await _db.Registracija.ToListAsync();
        }
    }
}
