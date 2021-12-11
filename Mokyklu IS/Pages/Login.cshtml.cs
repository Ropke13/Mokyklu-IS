using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mokyklu_IS.Model;

namespace Mokyklu_IS.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public LoginModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Registracija> Registracija { get; set; }
        public IEnumerable<Model.Mokytojas> Mokytojas { get; set; }
        public IEnumerable<Tevas> Tevas { get; set; }
        public IEnumerable<Administratorius> Admin { get; set; }
        public IEnumerable<Model.Mokinys> Mokinys { get; set; }

        public async Task OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            Tevas = await _db.Tevas.ToListAsync();
            Registracija = await _db.Registracija.ToListAsync();
            Mokytojas = await _db.Mokytojas.ToListAsync();
            Mokinys = await _db.Mokinys.ToListAsync();
            string pris_vard = Request.Form["pris_vardas"];
            string password = Request.Form["psw"];
            foreach(var item in Registracija)
            {
                if(item.Prisijungimo_vardas == pris_vard && item.Slaptazodis == password)
                {
                    int id = item.Id_Registracija;
                    foreach(var mok in Mokinys)
                    {
                        if (mok.fk_Registracija == id && item.Ar_patvirtinta == true)
                        {
                            return RedirectToPage("/Mokinys/Index", new { ID = mok.Id_Mokinys });
                        }
                    }
                    foreach (var mok in Mokytojas)
                    {
                        if (mok.fk_Registracija == id && item.Ar_patvirtinta == true)
                        {
                            return RedirectToPage("/Mokytojas/Index", new { ID = mok.Id_Mokytojas });
                        }
                    }
                    foreach (var mok in Tevas)
                    {
                        if (mok.fk_Registracija == id && item.Ar_patvirtinta == true)
                        {
                            return RedirectToPage("/Tevai/Index", new { ID = mok.Id_Tevas });
                        }

                    }
                    foreach (var mok in Admin)
                    {
                        if (mok.fk_Registracija == id)
                        {
                            return RedirectToPage("/Admin/Index", new { ID = id });
                        }
                    }
                }
            }
            return RedirectToPage("Login");

        }
    }
}
