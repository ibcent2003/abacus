using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Wbc.Application.Common.Enums;
using Wbc.Application.Common.Interfaces;
using Wbc.WebUI.Filter;

namespace Wbc.WebUI.Pages
{
    //var canViewDutyApprovalList = await AuthorizationService.AuthorizeAsync(User, Policies.GetAttributeStringValue());
   [Authorize]
    public class DashboardModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
       private readonly ICurrentUserService _currentUserService;
        public DashboardModel(IHttpContextAccessor httpContextAccessor, ICurrentUserService currentUserService)
        {
            _httpContextAccessor = httpContextAccessor;
           _currentUserService = currentUserService;
        }

        public IActionResult OnGet()
        {
            var http = _httpContextAccessor.HttpContext;
            var isInRole = _currentUserService.GetCurrentUserRoles();
            
            if (isInRole.Contains("etrade Tool Admin"))
            {

                return RedirectToPage("/AdminDashboard", new { area = "Admin" });
            }
            return Page();
        }
    }
}
