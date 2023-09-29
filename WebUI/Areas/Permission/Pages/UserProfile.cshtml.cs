using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Wbc.Application.Common.Enums;
using Wbc.WebUI.Filter;

namespace Wbc.WebUI.Areas.Permission.Pages
{
    [AuthorizePolicy(Policies.CanViewOrganisationalUserDetails)]
    public class UserProfileModel : PageModel
    {
        [BindProperty]
        public string UserId { get; set; }
        [BindProperty]
        public string SelectedPermissions { get; set; }
        public void OnGet(string id)
        {
            UserId = id;
        }
    }
}
