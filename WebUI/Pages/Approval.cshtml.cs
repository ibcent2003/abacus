using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.Application.Workflow.Commands.ExecuteApprovalCommand;
using Wbc.Application.Workflow.Query.GetApprovalCommands;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Pages
{
    public class ApprovalModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<ApprovalModel> _stringLocalizer;

        public ApprovalModel(IMediator mediator, IStringLocalizer<ApprovalModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }

        public async Task<IActionResult> OnPostAsync(ApprovalCommandsVm model)
        {
            if (!ModelState.IsValid) return RedirectToRoute(model.DocumentSource);

            var result = await _mediator.Send(new ExecuteApprovalCommand
            {
                CommandName = model.SelectedCommand,
                Comment = model.Comments,
                ProcessId = model.ProcessId
            });

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            return RedirectToPage("Inbox", new { area = "Workflow" });
        }
    }
}
