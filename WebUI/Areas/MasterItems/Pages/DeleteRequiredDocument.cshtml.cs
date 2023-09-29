using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.Application.MasterItems.Command.DeleteRequiredDocument;
using Wbc.Application.MasterItems.Query.GetRequiredDocument;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.MasterItems.Pages
{
    [AuthorizePolicy(Policies.CanDeleteRequiredDocument)]
    public class DeleteRequiredDocumentModel : PageModel
    {


        private readonly IStringLocalizer<DeleteRequiredDocumentModel> _stringLocalizer;
        private readonly IMediator _mediator;

        public DeleteRequiredDocumentModel(IStringLocalizer<DeleteRequiredDocumentModel> stringLocalizer, IMediator mediator)
        {
            _stringLocalizer = stringLocalizer;
            _mediator = mediator;
        }

        [BindProperty]
        public DeleteRequiredDocumentCommand Command { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Command = await _mediator.Send(new GetDeleteRequiredDocumentCommandQuery { Id = id });

            if (Command == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            var dummy = await _mediator.Send(Command);

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            return RedirectToPage("ListRequiredDocument");
        }
    }
}
