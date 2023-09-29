using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.Application.Permission.Commands.AssignUserPermission;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.Permission.Pages
{
    [AuthorizePolicy(Policies.CanAssignUserPermissions)]
    public class AssignUserPermissionModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<AssignUserPermissionModel> _stringLocalizer;

        public AssignUserPermissionModel(IMediator mediator, IStringLocalizer<AssignUserPermissionModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string userId, string selectedPermissions, CancellationToken cancellationToken)
        {

            var result = await _mediator.Send(new AssignUserPermissionCommand
            {
                UserId = userId,
                SelectedPermissions = selectedPermissions

            }, cancellationToken);

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            return RedirectToPage("UserProfile", new { id = userId });
        }
    }
}
