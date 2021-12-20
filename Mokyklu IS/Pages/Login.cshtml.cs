using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
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
        public string Error { get; set; }
        public IEnumerable<Registracija> Registracija { get; set; }
        public IEnumerable<Model.Mokytojas> Mokytojas { get; set; }
        public IEnumerable<Tevas> Tevas { get; set; }
        public IEnumerable<Administratorius> Admin { get; set; }
        public IEnumerable<Model.Mokinys> Mokinys { get; set; }

        public async Task<IActionResult> OnPost()
        {
            HttpContext.Session.SetString("id", "");
            Tevas = await _db.Tevas.ToListAsync();
            Registracija = await _db.Registracija.ToListAsync();
            Mokytojas = await _db.Mokytojas.ToListAsync();
            Mokinys = await _db.Mokinys.ToListAsync();
            Admin = await _db.Administratorius.ToListAsync();
            string pris_vard = Request.Form["pris_vardas"];
            string password = Request.Form["psw"];
            foreach(var item in Registracija)
            {
                if(item.Prisijungimo_vardas == pris_vard && item.Slaptazodis == password)
                {
                    if(item.Ar_patvirtinta == false)
                    {
                        Error = "Jūsų paskyra dar nepatvirtinta";
                        return Page();
                    }
                    int id = item.Id_Registracija;
                    var role = item.Role;
                    switch (role)
                    {
                        case "Mokinys":
                            foreach(var mok in Mokinys)
                            {
                                if (mok.fk_Registracija == id && item.Ar_patvirtinta == true)
                                {
                                    HttpContext.Session.SetString("id", mok.Asmens_kodas);
                                    HttpContext.Session.SetString("role", role);
                                    return RedirectToPage("/Mokinys/Index");
                                }
                            }
                            break;
                        case "Mokytojas":
                            foreach (var mok in Mokytojas)
                            {
                                if (mok.fk_Registracija == id && item.Ar_patvirtinta == true)
                                {
                                    HttpContext.Session.SetString("id", mok.Asmens_kodas);
                                    HttpContext.Session.SetString("role", role);
                                    return RedirectToPage("/Mokytojas/Index");
                                }
                            }
                            break;
                        case "Tevas":
                            foreach (var mok in Tevas)
                            {
                                if (mok.fk_Registracija == id && item.Ar_patvirtinta == true)
                                {
                                    HttpContext.Session.SetString("id", mok.Asmens_kodas);
                                    HttpContext.Session.SetString("role", role);
                                    return RedirectToPage("/Tevai/Index");
                                }

                            }
                            break;
                        default:
                            foreach (var mok in Admin)
                            {
                                if (mok.fk_Registracija == id)
                                {
                                    HttpContext.Session.SetString("id", mok.Tabelio_nr.ToString());
                                    HttpContext.Session.SetString("role", role);
                                    return RedirectToPage("/Admin/Index");
                                }
                            }
                            break;
                    }
                }
            }
            Error = "Įvestas neteisingas slaptažodis arba prisijungimo vardas";
            return Page();

        }
    }
}
