using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.Application.Permission.Commands.DeleteOrganisationApprovalRole;
using Wbc.Application.Permission.Query.GetOrganisationApprovalRole;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.Permission.Pages
{
    [AuthorizePolicy(Policies.CanDeleteOrganisationApprovalRole)]
    public class DeleteOrganisationApprovalRoleModel : PageModel
    {
        private readonly IStringLocalizer<DeleteOrganisationApprovalRoleModel> _stringLocalizer;
        private readonly IMediator _mediator;

        public DeleteOrganisationApprovalRoleModel(IStringLocalizer<DeleteOrganisationApprovalRoleModel> stringLocalizer, IMediator mediator)
        {
            _stringLocalizer = stringLocalizer;
            _mediator = mediator;
        }

        [BindProperty]
        public DeleteOrganisationApprovalRoleCommand Command { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Command = await _mediator.Send(new GetDeleteOrganisationApprovalRoleCommandQuery { Id = id });

            if (Command == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            var dummy = await _mediator.Send(Command);

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            return RedirectToPage("ListOrganisationApprovalRole");
        }
    }
}
