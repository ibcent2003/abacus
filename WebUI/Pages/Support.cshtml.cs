using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Wbc.WebUI.Pages
{
    [AllowAnonymous]
    public class SupportModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
