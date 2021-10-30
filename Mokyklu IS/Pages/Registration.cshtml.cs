using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Mokyklu_IS.Pages
{
    public class RegistrationModel : PageModel
    {
        private readonly ILogger<RegistrationModel> _logger;

        public RegistrationModel(ILogger<RegistrationModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
        }
    }
}
