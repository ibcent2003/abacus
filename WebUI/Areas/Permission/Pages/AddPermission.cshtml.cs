using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.Application.Permission.Commands.CreatePermission;
using Wbc.Application.Permission.Query.GetPermission;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.Permission.Pages
{
    [AuthorizePolicy(Policies.CanAddPermission)]
    public class AddPermissionModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<AddPermissionModel> _stringLocalizer;

        public AddPermissionModel(IMediator mediator, IStringLocalizer<AddPermissionModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }

        [BindProperty]
        public AddPermissionCommand Command { get; set; }
        public SelectList PermissionList { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            var resourceVm = await _mediator.Send(new GetAddPermissionCommandQuery());

            PermissionList = new SelectList(resourceVm.PermissionDtos, "Id", "PersmissionDescription");

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                var resourceVm = await _mediator.Send(new GetAddPermissionCommandQuery());

                PermissionList = new SelectList(resourceVm.PermissionDtos, "Id", "PersmissionDescription");

                return Page();
            }

            var dummy = await _mediator.Send(Command);

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            return RedirectToPage("ListPermission");
        }


    }
}
