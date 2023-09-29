using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.Application.Permission.Commands.CreateOrganisationalApprovalRole;
using Wbc.Application.Permission.Query.GetOrganisationApprovalRole;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.Permission.Pages
{
    [AuthorizePolicy(Policies.CanAddOrganisationApprovalRole)]
    public class AddOrganisationApprovalRoleModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<AddOrganisationApprovalRoleModel> _stringLocalizer;

        public AddOrganisationApprovalRoleModel(IMediator mediator, IStringLocalizer<AddOrganisationApprovalRoleModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }

        [BindProperty]
        public CreateOrganisationalApprovalRoleCommand Command { get; set; }
        public async Task<IActionResult> OnGet()
        {
            Command = await _mediator.Send(new GetAddOrganisationApprovalRoleCommandQuery());

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
