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
    public class SusirinkimaiModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public SusirinkimaiModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public Tevas Tevas1 { get; set; }
        public string UserID { get; set; }
        public Susirinkimas Susirinkimas1 { get; set; }
        public async Task OnGet()
        {
            UserID = HttpContext.Session.GetString("id");
            Tevas1 = await _db.Tevas.Where(m => m.Asmens_kodas == UserID).FirstAsync();
            Susirinkimas1 = await _db.Susirinkimas.Where(m => m.Id_Susirinkimas == Tevas1.fk_Susirinkimas).FirstAsync();
        }
    }
}
