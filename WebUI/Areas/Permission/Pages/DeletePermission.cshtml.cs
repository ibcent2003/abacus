using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.Application.Permission.Commands.DeletePermission;
using Wbc.Application.Permission.Query.GetPermission;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.Permission.Pages
{
    [AuthorizePolicy(Policies.CanDeletePermission)]
    public class DeletePermissionModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<DeletePermissionModel> _stringLocalizer;

        public DeletePermissionModel(IMediator mediator, IStringLocalizer<DeletePermissionModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }

        [BindProperty]
        public DeletePermissionCommand Command { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Command = await _mediator.Send(new GetDeletePermissionCommandQuery { Id = id });

            if (Command == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            var result = await _mediator.Send(Command);

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            return RedirectToPage("ListTopResource");
        }
    }
}
