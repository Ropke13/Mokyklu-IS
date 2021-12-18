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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Model.Mokinys> Mokinys { get; set; }
        public IEnumerable<Tevas> Tevai { get; set; }
        public string UserID { get; set; }
        public IEnumerable<Model.Mokinys> Vaikai { get; set; }

        public async Task OnGet()
        {
            UserID = HttpContext.Session.GetString("id");
            Vaikai = await _db.Mokinys.Where(m => m.fk_Tevas == UserID).ToListAsync();
        }
    }
}
