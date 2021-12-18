using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mokyklu_IS.Model;

namespace Mokyklu_IS.Pages.Mokytojas
{
    public class KlaseModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public KlaseModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public IEnumerable<Model.Mokinys> Mokiniai { get; set; }
        public Klase Klase { get; set; }
        public async Task OnGet(int id)
        {
            Klase = await _db.Klase.FindAsync(id);
            Mokiniai = await _db.Mokinys.Where(m => m.fk_Klase == id).ToListAsync();
        }
    }
}
