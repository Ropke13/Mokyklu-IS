using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mokyklu_IS.Model;

namespace Mokyklu_IS.Pages.Admin
{
    public class PaskiruTvarkykleModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public PaskiruTvarkykleModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Registracija> Registracija { get; set; }

        public async Task OnGet()
        {
            Registracija = await _db.Registracija.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var reg = await _db.Registracija.FindAsync(id);
            if (reg == null)
            {
                return NotFound();
            }
            _db.Registracija.Remove(reg);
            await _db.SaveChangesAsync();

            return RedirectToPage("/Admin/PaskiruTvarkykle");
        }

        public async Task<IActionResult> OnPostPatvirtinti(int id)
        {
            Model.Mokinys Mokinys = new Model.Mokinys();
            Model.Mokytojas Mokytojas = new Model.Mokytojas();
            Tevas Tevas = new Tevas();

            var reg = await _db.Registracija.FindAsync(id);
            if(reg.Role == "Tevas")
            {
                Tevas.Asmens_kodas = reg.Asmens_kodas;
                Tevas.fk_Registracija = reg.Id_Registracija;
                Tevas.Vardas = reg.Vardas;
                Tevas.Pavarde = reg.Pavarde;
                Tevas.Telefono_nr = reg.Telefono_nr;

                reg.Ar_patvirtinta = true;

                await _db.Tevas.AddAsync(Tevas);
                await _db.SaveChangesAsync();
                return RedirectToPage("/Admin/PaskiruTvarkykle");

            }
            if(reg.Role == "Mokinys")
            {
                Mokinys.Vardas = reg.Vardas;
                Mokinys.Pavarde = reg.Pavarde;
                Mokinys.fk_Registracija = reg.Id_Registracija;
                Mokinys.Asmens_kodas = reg.Asmens_kodas;
                Mokinys.Telefono_nr = reg.Telefono_nr;

                reg.Ar_patvirtinta = true;

                await _db.Mokinys.AddAsync(Mokinys);
                await _db.SaveChangesAsync();
                return RedirectToPage("/Admin/PaskiruTvarkykle");
            }
            if(reg.Role == "Mokytojas")
            {
                Mokytojas.Vardas = reg.Vardas;
                Mokytojas.Pavarde = reg.Pavarde;
                Mokytojas.fk_Registracija = reg.Id_Registracija;
                Mokytojas.Asmens_kodas = reg.Asmens_kodas;
                Mokytojas.Telefono_nr = reg.Telefono_nr;

                reg.Ar_patvirtinta = true;

                await _db.Mokytojas.AddAsync(Mokytojas);
                await _db.SaveChangesAsync();
                return RedirectToPage("/Admin/PaskiruTvarkykle");
            }
            return RedirectToPage("/Admin/PaskiruTvarkykle");
        }
    }
}
