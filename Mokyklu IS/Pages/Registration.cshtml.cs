using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Mokyklu_IS.Model;

namespace Mokyklu_IS.Pages
{
    public class RegistrationModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public RegistrationModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public string Error { get; set; }
        [BindProperty]
        public Registracija Registracija { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostPatvirtinti()
        {
            string role = Request.Form["role"];
            string repeat = Request.Form["psw-repeat"];
            Registracija.Ar_patvirtinta = false;
            Registracija.Role = role;
            if(Registracija.Slaptazodis != repeat)
            {
                Error = "Slaptazodziai nesutampa!";
                return Page();
            }

            await _db.Registracija.AddAsync(Registracija);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
