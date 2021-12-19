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
    public class tvarkarastisModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public tvarkarastisModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Tvarkarastis> Tvarkarastis { get; set; }
        public async Task OnGet()
        {
            Tvarkarastis = await _db.Tvarkarastis.ToListAsync();
        }
    }
}
