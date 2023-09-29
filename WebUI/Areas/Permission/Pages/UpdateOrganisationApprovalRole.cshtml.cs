using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.Application.Permission.Commands.UpdateOrganisationApprovalRole;
using Wbc.Application.Permission.Query.GetOrganisationApprovalRole;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.Permission.Pages
{
    [AuthorizePolicy(Policies.CanUpdateOrganisationApprovalRole)]
    public class UpdateOrganisationApprovalRoleModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<UpdateOrganisationApprovalRoleModel> _stringLocalizer;
        public UpdateOrganisationApprovalRoleModel(IMediator mediator, IStringLocalizer<UpdateOrganisationApprovalRoleModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }
        [BindProperty]
        public UpdateOrganisationApprovalRoleCommand Command { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            Command = await _mediator.Send(new GetUpdateOrganisationApprovalRoleCommandQuery { Id = id });

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var result = await _mediator.Send(Command);

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            return RedirectToPage("ListOrganisationApprovalRole");
        }
    }
}
