using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Mokyklu_IS.Model;

namespace Mokyklu_IS.Pages.Mokytojas
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public string UserID { get; set; }
        [BindProperty]
        public Registracija Registracija { get; set; }
        [BindProperty]
        public Model.Mokytojas Mokytojas { get; set; }

        public IEnumerable<Klase> Klases { get; set; }
        public IEnumerable<Destymas> Destymai { get; set; }

        public async Task OnGet()
        {
            UserID = HttpContext.Session.GetString("id");
            Mokytojas = await _db.Mokytojas.FindAsync(UserID);
            Klases = await _db.Klase.ToListAsync();
            Destymai = await _db.Destymas.ToListAsync();
        }
    }
}
