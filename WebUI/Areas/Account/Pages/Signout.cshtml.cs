using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Wbc.Application.Common.Interfaces;

namespace Wbc.WebUI.Areas.Account.Pages
{
    public class SignoutModel : PageModel
    {
        private readonly ICurrentUserService _userService;
        public SignoutModel(ICurrentUserService userService)
        {
            _userService = userService;
        }

        public IActionResult OnGet()
        {
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);

            return SignOut(new AuthenticationProperties { RedirectUri = "/Index" }, CookieAuthenticationDefaults.AuthenticationScheme, OpenIdConnectDefaults.AuthenticationScheme);

        }
    }
}
