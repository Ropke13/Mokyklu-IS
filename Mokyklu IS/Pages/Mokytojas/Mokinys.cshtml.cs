using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mokyklu_IS.Pages.Mokytojas
{
    public class MokinysModel : PageModel
    {
        [BindProperty]
        public string ID { get; set; }
        public void OnGet(string id)
        {
            ID = id;
        }
    }
}
