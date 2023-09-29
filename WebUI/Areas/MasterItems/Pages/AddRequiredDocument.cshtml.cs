using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.Application.MasterItems.Command.CreateRequiredDocument;
using Wbc.Application.MasterItems.Query.GetRequiredDocument;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.MasterItems.Pages
{
    [AuthorizePolicy(Policies.CanAddRequiredDocument)]
    public class AddRequiredDocumentModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<AddRequiredDocumentModel> _stringLocalizer;

        public AddRequiredDocumentModel(IMediator mediator, IStringLocalizer<AddRequiredDocumentModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }

        [BindProperty]
        public AddRequiredDocumentCommand Command { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Command = await _mediator.Send(new GetAddRequiredDocumentCommandQuery());

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
