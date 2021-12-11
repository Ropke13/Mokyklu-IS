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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Registracija Registracija { get; set; }
        public IEnumerable<Model.Mokinys> Mokinys { get; set; }
        public async Task OnGet(string ID)
        {
            Mokinys = await _db.Mokinys.ToListAsync();
            Registracija = await _db.Registracija.FindAsync(int.Parse(ID));
        }
    }
}
