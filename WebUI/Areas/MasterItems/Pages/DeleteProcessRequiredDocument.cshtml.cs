using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.Application.MasterItems.Command.DeleteProcessRequiredDocument;
using Wbc.Application.MasterItems.Query.GetProcessRequiredDocument;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.MasterItems.Pages
{
    [AuthorizePolicy(Policies.CanDeleteProcessRequiredDocument)]
    public class DeleteProcessRequiredDocumentModel : PageModel
    {
        private readonly IStringLocalizer<DeleteProcessRequiredDocumentModel> _stringLocalizer;
        private readonly IMediator _mediator;

        public DeleteProcessRequiredDocumentModel(IStringLocalizer<DeleteProcessRequiredDocumentModel> stringLocalizer, IMediator mediator)
        {
            _stringLocalizer = stringLocalizer;
            _mediator = mediator;
        }

        [BindProperty]
        public DeleteProcessRequiredDocumentCommand Command { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Command = await _mediator.Send(new GetDeleteProcessRequiredDocumentCommandQuery { Id = id });

            if (Command == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            var dummy = await _mediator.Send(Command);

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            return RedirectToPage("ListProcessRequiredDocument");
        }


        public async Task<IActionResult> OnPostAsync()
        {
            var result = await _mediator.Send(Command);

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            return RedirectToPage("AddProcessRequiredDocument", new { id = Command.ProcessId });
        }

    }
}
