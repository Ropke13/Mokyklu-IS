using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mokyklu_IS.Model;

namespace Mokyklu_IS.Pages.Mokytojas
{
    public class KlaseModel : PageModel
    {
        public Klase Klase { get; set; }
        public void OnGet()
        {
        }
    }
}
