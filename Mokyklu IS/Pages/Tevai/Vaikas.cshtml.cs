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
    public class VaikasModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public VaikasModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Model.Mokinys Mokinys { get; set; }

        public async Task OnGet(string ID)
        {
            Mokinys = await _db.Mokinys.FindAsync(ID);
        }
    }
}
