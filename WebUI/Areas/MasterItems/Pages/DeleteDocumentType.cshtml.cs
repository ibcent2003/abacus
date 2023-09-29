using System.Threading.Tasks;
using Application.MasterItems.Command.DeleteDocumentType;
using Application.MasterItems.Query.GetDocumentType;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.MasterItems.Pages
{
    [AuthorizePolicy(Policies.CanDeleteDocumentType)]
    public class DeleteDocumentTypeModel : PageModel
    {
        private readonly IStringLocalizer<DeleteDocumentTypeModel> _stringLocalizer;
        private readonly IMediator _mediator;

        public DeleteDocumentTypeModel(IStringLocalizer<DeleteDocumentTypeModel> stringLocalizer, IMediator mediator)
        {
            _stringLocalizer = stringLocalizer;
            _mediator = mediator;
        }

        [BindProperty]
        public DeleteDocumentTypeCommand Command { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Command = await _mediator.Send(new GetDeleteDocumentTypeCommandQuery { Id = id });

            if (Command == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            var result = await _mediator.Send(Command);

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            return RedirectToPage("ListDocumentType");
        }
    }
}
