using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.Application.Permission.Commands.UpdatePermission;
using Wbc.Application.Permission.Query.GetPermission;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.Permission.Pages
{
    [AuthorizePolicy(Policies.CanUpdatePermission)]
    public class UpdatePermissionModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<UpdatePermissionModel> _stringLocalizer;

        public UpdatePermissionModel(IMediator mediator, IStringLocalizer<UpdatePermissionModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }

        [BindProperty]
        public UpdatePermissionCommand Command { get; set; }
        public SelectList PermissionList { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            var vm = await _mediator.Send(new GetUpdatePermissionCommandQuery { Id = id });

            Command = vm.UpdatePermissionCommand;

            PermissionList = new SelectList(vm.PermissionDtos, "Id", "PersmissionDescription");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var vm = await _mediator.Send(new GetUpdatePermissionCommandQuery { Id = Command.Id });

                PermissionList = new SelectList(vm.PermissionDtos, "Id", "PersmissionDescription");

                return Page();
            }

            var result = await _mediator.Send(Command);

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            return RedirectToPage("ListPermission");
        }
    }
}
