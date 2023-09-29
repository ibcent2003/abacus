using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Wbc.WebUI.Areas.Account.Pages
{
    [AllowAnonymous]
    public class SigninModel : PageModel
    {

        public IActionResult OnGet()
        {
            return Challenge(new AuthenticationProperties
            {
                RedirectUri = "/Index"

            }, CookieAuthenticationDefaults.AuthenticationScheme, OpenIdConnectDefaults.AuthenticationScheme);
        }
    }
}
