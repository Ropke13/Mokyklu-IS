using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mokyklu_IS.Pages.Mokytojas
{
    public class MokinysModel : PageModel
    {
        [BindProperty]
        public string ID { get; set; }
        public IActionResult OnGet(string id)
        {
            if (HttpContext.Session.GetString("id") == null)
            {
                return RedirectToPage("/Login");
            }
            else if (HttpContext.Session.GetString("role") != "Mokytojas")
            {
                return RedirectToPage("/Login");
            }

            ID = id;

            return Page();
        }
    }
}
