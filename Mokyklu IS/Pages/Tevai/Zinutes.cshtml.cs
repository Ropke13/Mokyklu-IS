using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mokyklu_IS.Model;
using Microsoft.AspNetCore.Http;

namespace Mokyklu_IS.Pages.Tevai
{
    public class ZinutesModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public ZinutesModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public Tevas Tevas1 { get; set; }
        public string UserID { get; set; }
        public IEnumerable<Model.Zinutes> Zinutes { get; set; }
        public IEnumerable<Zin> Ats { get; set; }
        public class Zin
        {
            public string Tekstas { get; set; }
            public DateTime Data { get; set; }
            public string MVardas { get; set; }
            public string MPavarde { get; set; }
        }
        public async Task OnGet()
        {
            UserID = HttpContext.Session.GetString("id");
            var mokytojai = await _db.Mokytojas.ToListAsync();
            var zinutes = await _db.Zinutes.Where(m => m.fk_Tevas == UserID).ToListAsync();
            Ats = from zin in zinutes join mok in mokytojai on zin.fk_Mokytojas equals mok.Asmens_kodas select new 
                  Zin { Tekstas = zin.Tekstas, Data = zin.Data, MVardas = mok.Vardas, MPavarde = mok.Pavarde };
        }
    }
}
